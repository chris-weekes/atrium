using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using atDates;

 namespace LawMate
{
    public partial class ucDateRange : UserControl
    {
        public ucDateRange()
        {
            InitializeComponent();
            LoadComboBoxItems();
        }

        private void LoadComboBoxItems()
        {
            cbDateRangeOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(""));
            cbDateRangeOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.DateRangeToday));
            cbDateRangeOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.DateRangeThisWeek));
            cbDateRangeOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.DateRangeLastWeek));
            cbDateRangeOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.DateRangeThisMonth));
            cbDateRangeOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.DateRangeLastMonth));
            cbDateRangeOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.DateRangeThisYear));
            cbDateRangeOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.DateRangeLastYear));
            cbDateRangeOptions.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem(Properties.Resources.DateRangeCustom));

        }
        public int Mode
        {
            set
            {
                cbDateRangeOptions.SelectedIndex = value;
            }
            get
            {
                return cbDateRangeOptions.SelectedIndex;
            }
        }
        public void SetToNull()
        {
            cbDateRangeOptions.SelectedIndex = 0;
        }

        public void SetToCustomDateRange()
        {
            cbDateRangeOptions.SelectedIndex = 8;
            calDocDate1.Focus();
            //calDocDate1.DropDownCalendar.Show();
        }

        public Nullable<DateTime> BeginDate
        {
            get 
            {
                if (calDocDate1.IsNullDate)
                    return null;
                else
                    return calDocDate1.Value; 
            }
            set 
            {
                if (value == null)
                    calDocDate1.IsNullDate = true;
                else
                {
                    calDocDate1.IsNullDate = false;
                    calDocDate1.Value = (DateTime)value;
                }
            }
        }
        public Nullable<DateTime> EndDate
        {
            get 
            {
                if (calDocDate2.IsNullDate)
                    return null;
                else
                {
                    TimeSpan ts = new TimeSpan(23, 59, 59);
                    DateTime d = calDocDate2.Value;
                    return d.Date.Add(ts) ;
                }
            }
            set 
            {
                if (value == null)
                    calDocDate2.IsNullDate = true;
                else
                {
                    calDocDate2.IsNullDate = false;
                    calDocDate2.Value = (DateTime)value; 
            
                }
            }
        }

        public bool EndDateVisible
        {
            get 
            {
                if (calDocDate2.Visible)
                    return true;

                return false;
            }
        }

        private void setLblVisibility(bool lblvisible)
        {
            lblFromDate.Visible = lblvisible;
            lblToDate.Visible = lblvisible;
            calDocDate2.Visible = lblvisible;
        
        }
        private void cbDocDateOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            BeginDate = null;
            EndDate = null;
            switch (cbDateRangeOptions.SelectedIndex)
            {
                case 0:
                    setLblVisibility(false);
                    BeginDate = null;
                    EndDate = null;
                    break;
                case 1: //today
                    setLblVisibility(false);
                    BeginDate = StandardDate.Today.BeginDate;
                    EndDate = null;
                    break;
                case 2: //this week
                    setLblVisibility(true);
                    BeginDate = StandardDate.ThisWeek.BeginDate;
                    EndDate = StandardDate.ThisWeek.EndDate;
                    break;
                case 3: //last week
                    setLblVisibility(true);
                    BeginDate = StandardDate.LastWeek.BeginDate;
                    EndDate = StandardDate.LastWeek.EndDate;
                    break;
                case 4: //this month
                    setLblVisibility(true);
                    BeginDate = StandardDate.ThisMonth.BeginDate;
                    EndDate = StandardDate.ThisMonth.EndDate;
                    break;
                case 5: //last month
                    setLblVisibility(true);
                    BeginDate = StandardDate.LastMonth.BeginDate;
                    EndDate = StandardDate.LastMonth.EndDate;
                    break;
                case 6: //this year
                    setLblVisibility(true);
                    BeginDate = StandardDate.ThisYear.BeginDate;
                    EndDate = StandardDate.ThisYear.EndDate;
                    break;
                case 7: //last year
                    setLblVisibility(true);
                    BeginDate = StandardDate.LastYear.BeginDate;
                    EndDate = StandardDate.LastYear.EndDate;
                    break;
                case 8: //custom dates
                    setLblVisibility(true);
                    BeginDate = null;
                    EndDate = null;
                    break;
            }
        }

        private void calDocDate1_ValueChanged(object sender, EventArgs e)
        {
            Janus.Windows.CalendarCombo.CalendarCombo cb = (Janus.Windows.CalendarCombo.CalendarCombo)sender;

            if (calDocDate1.Value > calDocDate2.Value && calDocDate2.Visible && !calDocDate2.IsNullDate)
            {
                lblInvalidDate.Visible = true;
                cb.IsNullDate = true;
            }
            else
                lblInvalidDate.Visible = false;

        }

        private void calDocDate1_KeyDown(object sender, KeyEventArgs e)
        {
            UIHelper.TodaysDateShortcutKey(sender, e);
        }

    }
}
