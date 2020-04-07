using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fNotify : Form
    {
        public fBase FromForm;
        bool FadeIn = true;
        double maxOpacity = 0.75;

        protected override bool ShowWithoutActivation { get { return true; } }

        protected override CreateParams CreateParams
        {
            get
            {
                //make sure Top Most property on form is set to false
                //otherwise this doesn't work
                int WS_EX_TOPMOST = 0x00000008;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TOPMOST;
                return cp;
            }
        }


        public fNotify()
        {
            InitializeComponent();
            //this.Location =new Point(Screen.PrimaryScreen.Bounds.Right - this.Width,Screen.PrimaryScreen.Bounds.Bottom - this.Height);
            //Init(maxOpacity, 0);
            //FadeIn = false;
            //timer1.Enabled = true;
        }
        int myApptId;
        public fNotify(fCalendar calendar, int apptId)
        {
            InitializeComponent();
            FromForm = calendar;
            pnlLawMail.Text = String.Format(LawMate.Properties.Resources.AppMailNotice, FromForm.MainForm.AtMng.AppMan.AppName);
            this.Location = new Point((FromForm.MainForm.Bounds.Right - 15 - this.Width), (FromForm.MainForm.Bounds.Bottom - 15 - this.Height));
            lblMailCountMessage.Text = LawMate.Properties.Resources.AppointmentSoon;

            linkLabel1.Text = LawMate.Properties.Resources.CalendarDisplayName;
            myApptId = apptId;
            this.Opacity = 0;
            this.Show();
            timerFade.Enabled = true;
        }
        public fNotify(fBFList bflist, int MailCount)
        {
            InitializeComponent();
            FromForm = bflist;
            pnlLawMail.Text = String.Format(LawMate.Properties.Resources.AppMailNotice, FromForm.MainForm.AtMng.AppMan.AppName);
            this.Location = new Point((FromForm.MainForm.Bounds.Right - 15 - this.Width), (FromForm.MainForm.Bounds.Bottom - 15 - this.Height));
            Init(0, MailCount);
        }

        private void Init(double OpacityStart, int MailCount)
        {
            if (MailCount == 1)
                lblMailCountMessage.Text = String.Format(LawMate.Properties.Resources.YouHave1NewLawMailMessage, FromForm.MainForm.AtMng.AppMan.AppName);
            else if (MailCount > 1)
                lblMailCountMessage.Text = String.Format(LawMate.Properties.Resources.YouHave0NewLawMailMessages, MailCount, FromForm.MainForm.AtMng.AppMan.AppName);
            else
                lblMailCountMessage.Text = LawMate.Properties.Resources.ThereAreNewMessagesInYourBFList;
            
            this.Opacity = OpacityStart;
            this.Show();
            timerFade.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (FromForm != null)
                {
                    if(myApptId!=0)
                    {
                        fCalendar fc = (fCalendar)FromForm;
                        fc.MoreInfo("Appointment", myApptId);
                    }
                    FromForm.ParentForm.Activate();
                    FromForm.Focus();
                    FromForm.Activate();
                }
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                FadeIn = false;
                timerFade.Enabled = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void timerFade_Tick(object sender, EventArgs e)
        {
            try
            {
                if (FadeIn)
                {
                    this.Opacity += 0.05;
                    if (this.Opacity >= maxOpacity-.05)
                    {
                        this.Opacity = maxOpacity;
                        timerFade.Enabled = false;
                        FadeIn = false;
                        timer1.Enabled = true;
                    }
                }
                else
                {
                    this.Opacity -= 0.05;
                    if (this.Opacity <= .05)
                    {
                        this.Opacity = 0;
                        timerFade.Enabled = false;
                        this.Close();
                    }

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void pnlLawMail_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                timerFade.Enabled = false;
                this.Opacity = 1;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void pnlLawMail_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                timer1.Interval = 2000;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiPanelManager1_PanelClosedChanged(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}