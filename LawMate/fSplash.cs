using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Media;

 namespace LawMate
{
    /// <summary>
    /// Summary description for fSplash.
    /// </summary>
    public class fSplash : System.Windows.Forms.Form
    {
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.EditControls.UIProgressBar progressBar1;
        private Label lblTxt;
        private PictureBox pictureBox4;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        //SoundPlayer sound;

        public fSplash()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            setMessageText(String.Format(Properties.Resources.UILoggingIntoLawMate, Properties.Resources.AppName));
            this.label4.Text = Properties.Resources.AppName + "\nVersion: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); ;
            if (Properties.Resources.AppName == "LawMate")
                pictureBox4.Image = Properties.Resources.lawmateSplash;
            if (Properties.Resources.AppName == "Atrium")
                pictureBox4.Image = Properties.Resources.atriumlogo;
                //pictureBox4.Image = Properties.Resources.AtriumSplashEngFre;
            


        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        public void setMessageText(string txt)
        {
            //Activate();
            lblTxt.Text = txt;
            Refresh();
        }
        public void incrementProgressBar(int inc)
        {
            //Activate();

            if (progressBar1.Value + inc > 100)
                progressBar1.Value = 100;
            else
                progressBar1.Value = progressBar1.Value + inc;
            Refresh();
        }
        public void resetForm()
        {
            //Activate();

            progressBar1.Value = 0;
            lblTxt.Text = "";// Properties.Resources.retrievingData;
            Refresh();
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSplash));
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new Janus.Windows.EditControls.UIProgressBar();
            this.lblTxt = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(372, 39);
            this.label4.TabIndex = 12;
            this.label4.Text = "[appName]\r\n[appVersion]";
            // 
            // pictureBox9
            // 
            this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox9.Location = new System.Drawing.Point(15, 206);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(472, 1);
            this.pictureBox9.TabIndex = 11;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(393, 210);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(94, 26);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.pictureBox8.Location = new System.Drawing.Point(0, 0);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(503, 344);
            this.pictureBox8.TabIndex = 10;
            this.pictureBox8.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackgroundFormatStyle.BackColor = System.Drawing.Color.White;
            this.progressBar1.BorderStyle = Janus.Windows.UI.BorderStyle.None;
            this.progressBar1.Location = new System.Drawing.Point(8, 315);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.OfficeCustomColor = System.Drawing.Color.Olive;
            this.progressBar1.Size = new System.Drawing.Size(486, 21);
            this.progressBar1.TabIndex = 15;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // lblTxt
            // 
            this.lblTxt.Location = new System.Drawing.Point(15, 264);
            this.lblTxt.Name = "lblTxt";
            this.lblTxt.Size = new System.Drawing.Size(479, 43);
            this.lblTxt.TabIndex = 16;
            this.lblTxt.Text = "[message]";
            this.lblTxt.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(8, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(486, 199);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // fSplash
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(503, 344);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox8);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fSplash";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
