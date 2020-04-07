using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

namespace LawMate
{
    public partial class fApptRecurrence : Form
    {

        public enum RecurrenceFrequency // values from ApptRecurrenceType table
        {
            Daily = 0,
            Weekly = 1,
            Monthly = 2
        }

        FileManager fmCurrent;
        atriumDB.AppointmentRow originalApptRow;

        private string frequencyText = string.Empty;

        public fApptRecurrence(FileManager fm, atriumDB.AppointmentRow ar)
        {
            InitializeComponent();
            fmCurrent = fm;
            originalApptRow = ar;
            Init();
        }

        private void Init()
        {
            DataTable dtAppRecurrenceType = fmCurrent.Codes("vApptRecurrenceType");
            UIHelper.ComboBoxInit(dtAppRecurrenceType, RecurrenceUIMultiDropDown, fmCurrent);

            if (originalApptRow.IsApptRecurrenceIdNull() || originalApptRow.ApptRecurrenceRow.RecurrenceRemoved)
            {
                RemoveRecurrenceUIButton.Enabled = false;
                RecurrenceUIMultiDropDown.SelectedValue = RecurrenceFrequency.Daily;
                AdjustDropDownNumbers();
            }
            else
            {
                AdjustRecurrencePanels(originalApptRow.ApptRecurrenceRow.ApptRecurrenceTypeId);
                RecurrenceUIMultiDropDown.SelectedValue = originalApptRow.ApptRecurrenceRow.ApptRecurrenceTypeId;
                AdjustDropDownNumbers();
                SetFormValues();
            }
            RecurrenceUIMultiDropDown.Focus();
        }

        private void SetFormValues()
        {
            MondayUICheckBox.Checked = originalApptRow.ApptRecurrenceRow.Monday;
            TuesdayUICheckBox.Checked = originalApptRow.ApptRecurrenceRow.Tuesday;
            WednesdayUICheckBox.Checked = originalApptRow.ApptRecurrenceRow.Wednesday;
            ThursdayUICheckBox.Checked = originalApptRow.ApptRecurrenceRow.Thursday;
            FridayUICheckBox.Checked = originalApptRow.ApptRecurrenceRow.Friday;
            SaturdayUICheckBox.Checked = originalApptRow.ApptRecurrenceRow.Saturday;
            SundayUICheckBox.Checked = originalApptRow.ApptRecurrenceRow.Sunday;
            EndDateRangeCalendarCombo.Value = originalApptRow.ApptRecurrenceRow.EndRangeDate.DateTime;
        }

        private void AdjustRecurrencePanels(int recurrenceId)
        {
            if (recurrenceId >= 0)
            {
                switch (recurrenceId)
                {
                    case (int)RecurrenceFrequency.Weekly:
                        EndsPanel.Location = new System.Drawing.Point(0, DaysPanel.Location.Y + DaysPanel.Height); // place Ends panel underneath days panel

                        int day;
                        foreach (Control ctl in DaysPanel.Controls) // select and disable current day of week by default
                        {
                            if (ctl.GetType() == typeof(Janus.Windows.EditControls.UICheckBox))
                            {
                                Janus.Windows.EditControls.UICheckBox jUICheckBox = (Janus.Windows.EditControls.UICheckBox)ctl;
                                int.TryParse(jUICheckBox.Tag.ToString(), out day);

                                if (day == (int)originalApptRow.StartDateLocal.DayOfWeek)
                                {
                                    jUICheckBox.Checked = true;
                                    jUICheckBox.Enabled = false;
                                    break;
                                }
                            }
                        }
                        DaysPanel.Visible = true;
                        break;
                    default:
                        DaysPanel.Visible = false;
                        UncheckDays();
                        EndsPanel.Location = new System.Drawing.Point(0, DaysPanel.Location.Y); // place Ends panel on top of days panel
                        break;
                }
            }
        }

        private void AdjustDropDownNumbers()
        {
            int selectedValue;

            bool parseInt = int.TryParse(RecurrenceUIMultiDropDown.SelectedValue.ToString(), out selectedValue);

            if (parseInt)
            {
                int maxNumber = 0;
                switch (selectedValue)
                {
                    case (int)RecurrenceFrequency.Daily:
                        frequencyText = Properties.Resources.RecurrenceEndByDay;
                        maxNumber = 30;
                        break;
                    case (int)RecurrenceFrequency.Weekly:
                        frequencyText = Properties.Resources.RecurrenceEndByWeek;
                        maxNumber = 5;
                        break;
                    case (int)RecurrenceFrequency.Monthly:
                        frequencyText = Properties.Resources.RecurrenceEndByMonth;
                        maxNumber = 12;
                        break;
                }
                // set EveryUIComboBox values
                EveryUIComboBox.Items.Clear();
                for (int i = 1; i <= maxNumber; i++)
                    EveryUIComboBox.Items.Add(i);
                if (originalApptRow.ApptRecurrenceRow == null || originalApptRow.ApptRecurrenceRow.OccursEvery <= 0 || originalApptRow.ApptRecurrenceRow.RecurrenceRemoved)
                    EveryUIComboBox.SelectedIndex = 0;
                else
                    if (originalApptRow.ApptRecurrenceRow.OccursEvery > EveryUIComboBox.Items.Count)
                    {
                        EveryUIComboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        EveryUIComboBox.SelectedIndex = originalApptRow.ApptRecurrenceRow.OccursEvery - 1;
                    }

                AdjustEndByLabel();
            }
        }

        private void AdjustEndByLabel()
        {
            int selectedValue = 0;
            bool parseInt = false;

            if(RecurrenceUIMultiDropDown.SelectedValue != null)
                parseInt = int.TryParse(RecurrenceUIMultiDropDown.SelectedValue.ToString(), out selectedValue);

            if (parseInt)
            {
                switch (selectedValue)
                {
                    case (int)RecurrenceFrequency.Weekly:
                        string days = string.Empty;
                        if (SundayUICheckBox.Checked)
                            days += Properties.Resources.RecurrenceSundays + ", ";
                        if (MondayUICheckBox.Checked)
                            days += Properties.Resources.RecurrenceMondays + ", ";
                        if (TuesdayUICheckBox.Checked)
                            days += Properties.Resources.RecurrenceTuesdays + ", ";
                        if (WednesdayUICheckBox.Checked)
                            days += Properties.Resources.RecurrenceWednesdays + ", ";
                        if (ThursdayUICheckBox.Checked)
                            days += Properties.Resources.RecurrenceThursdays + ", ";
                        if (FridayUICheckBox.Checked)
                            days += Properties.Resources.RecurrenceFridays + ", ";
                        if (SaturdayUICheckBox.Checked)
                            days += Properties.Resources.RecurrenceSaturdays + ", ";
                        if (days.Length > 0)
                            days = days.TrimEnd(days[days.Length - 1]);
                        EndByLabel.Text = String.Format(Properties.Resources.RecurrenceEndByLabelWeekly, EveryUIComboBox.Text.ToString(), frequencyText, days, EndDateRangeCalendarCombo.Value.ToLongDateString());
                        break;
                     default:
                        EndByLabel.Text = String.Format(Properties.Resources.RecurrenceEndByLabel, EveryUIComboBox.Text.ToString(), frequencyText, EndDateRangeCalendarCombo.Value.ToLongDateString());            
                        break;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
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

        private void RecurrenceUIMultiDropDown_ASelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                AdjustRecurrencePanels(RecurrenceUIMultiDropDown.SelectedIndex);
                AdjustDropDownNumbers(); 
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void UpdateAppRecurrenceRow()
        {
            // creates / updates the appointment recurrence record
            if (originalApptRow.ApptRecurrenceRow == null)
            {
                originalApptRow.ApptRecurrenceRow = (lmDatasets.atriumDB.ApptRecurrenceRow)fmCurrent.GetApptRecurrence().Add(originalApptRow);
                originalApptRow.OriginalRecurrence = true;
            }

            originalApptRow.ApptRecurrenceRow.FileId = originalApptRow.FileId;
            originalApptRow.ApptRecurrenceRow.ApptRecurrenceTypeId = (int)RecurrenceUIMultiDropDown.SelectedValue;
            originalApptRow.ApptRecurrenceRow.OccursEvery = (int)EveryUIComboBox.SelectedItem.Value;
            originalApptRow.ApptRecurrenceRow.StartRangeDate = originalApptRow.StartDate;
            originalApptRow.ApptRecurrenceRow.EndRangeDate = EndDateRangeCalendarCombo.Value;

            if (originalApptRow.ApptRecurrenceRow.ApptRecurrenceTypeId == (int)RecurrenceFrequency.Weekly)
            {
                originalApptRow.ApptRecurrenceRow.Monday = MondayUICheckBox.Checked;
                originalApptRow.ApptRecurrenceRow.Tuesday = TuesdayUICheckBox.Checked;
                originalApptRow.ApptRecurrenceRow.Wednesday = WednesdayUICheckBox.Checked;
                originalApptRow.ApptRecurrenceRow.Thursday = ThursdayUICheckBox.Checked;
                originalApptRow.ApptRecurrenceRow.Friday = FridayUICheckBox.Checked;
                originalApptRow.ApptRecurrenceRow.Saturday = SaturdayUICheckBox.Checked;
                originalApptRow.ApptRecurrenceRow.Sunday = SundayUICheckBox.Checked;
            }
            else
            {
                originalApptRow.ApptRecurrenceRow.Monday = false;
                originalApptRow.ApptRecurrenceRow.Tuesday = false;
                originalApptRow.ApptRecurrenceRow.Wednesday = false;
                originalApptRow.ApptRecurrenceRow.Thursday = false;
                originalApptRow.ApptRecurrenceRow.Friday = false;
                originalApptRow.ApptRecurrenceRow.Saturday = false;
                originalApptRow.ApptRecurrenceRow.Sunday = false;
            }

            originalApptRow.ApptRecurrenceRow.RecurrenceRemoved = false;
            originalApptRow.ApptRecurrenceId = originalApptRow.ApptRecurrenceRow.ApptRecurrenceId;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateAppRecurrenceRow();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

            this.Close();
        }

        private void RemoveRecurrenceUIButton_Click(object sender, EventArgs e)
        {
            // flag recurrence as removed
            try
            {
                if(UIHelper.ConfirmDelete(Properties.Resources.ConfirmDeleteAppRecurrence))
                {
                    originalApptRow.ApptRecurrenceRow.RecurrenceRemoved = true;
                    this.Close();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void EveryUIComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (EveryUIComboBox.SelectedIndex >= 0)
                {
                    AdjustEndByLabel();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void EndDateRangeCalendarCombo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                AdjustEndByLabel();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void UncheckDays()
        {
            // uncheck all days
            foreach (Control ctl in DaysPanel.Controls)
            {
                if (ctl.GetType() == typeof(Janus.Windows.EditControls.UICheckBox))
                {
                    Janus.Windows.EditControls.UICheckBox jUICheckBox = (Janus.Windows.EditControls.UICheckBox)ctl;
                    jUICheckBox.Checked = false;
                }
            }
        }

        private void DayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AdjustEndByLabel();
        }
    }
}