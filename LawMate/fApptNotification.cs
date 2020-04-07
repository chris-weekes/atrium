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
    public partial class fApptNotification :  Form
    {
        FileManager currentFM;
        
        public fApptNotification()
        {
            InitializeComponent();
        }

       ~fApptNotification()  // destructor
        {
            this.Close();
         
        }


        private static fApptNotification  _instance = null;
        public static fApptNotification Instance(FileManager FM, DataTable dt)
        { 
                if (_instance == null)
                    _instance = new fApptNotification(FM,  dt);
                return _instance;
        }


        public object Datasource 
        {
            set
            {
           //     DataView dv = new DataView((DataTable)value, "", "StartDateLocal", DataViewRowState.CurrentRows | DataViewRowState.Added  | DataViewRowState.ModifiedCurrent );
                bSourceAppointmentDataview.DataSource = value;
                bSourceAppointmentDataview.Sort = "StartDateLocal";
                DataTable dt = (DataTable)(value); 
                SetFormHeader(dt.Rows.Count); 
            }
        }

   
        public fApptNotification(FileManager fm, DataTable dt)
        {
            try
            {
             //   DataView dv = new DataView(dt, "", "StartDateLocal", DataViewRowState.CurrentRows | DataViewRowState.Added | DataViewRowState.ModifiedCurrent  );
                InitializeComponent();
                UIHelper.ComboBoxInit("AppointmentNotification", ucDDReminder, fm);
                currentFM = fm;
                bSourceAppointmentDataview.DataSource = dt;
                bSourceAppointmentDataview.Sort = "StartDateLocal";
                SetFormHeader(dt.Rows.Count); 
                this.lblSubject.Text = dt.Rows[0][1].ToString();
                
             
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);

            }

        }

        private void SetFormHeader(int rowCount)
        {
            try 
            {

                if (rowCount > 1)
                    this.Text = rowCount.ToString() + " " + Properties.Resources.ResxReminders;
                else
                    this.Text = rowCount.ToString() + " " + Properties.Resources.ResxReminder;

               // int rowCount = gridEXNotification.GetRows().Length;// Count;// RootTable.Get.GridEX.Get.RowCount;

                //DataTable dt = (DataTable)bSourceAppointmentDataview.DataSource;
                //if (currentFM.AppMan.Language.ToUpper() == "ENG")
                //{
                //    if (rowCount > 1)
                //        this.Text = rowCount.ToString() + " "+ Properties.Resources.ResxReminders;
                //    else
                //        this.Text = rowCount.ToString() + " "+Properties.Resources.ResxReminder;
                //}
                //else
                //{
                //    if (rowCount > 1)
                //        this.Text = rowCount.ToString() + " Rappels";
                //    else
                //        this.Text = rowCount.ToString() + " Rappel";

               // }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
           
            
        }
    
          

        private void btnDismissAll_Click(object sender, EventArgs e)
        {
            try
            {
                int attendeeId;
                if (UIHelper.ConfirmDeleteReminders())
                {

                    foreach (Janus.Windows.GridEX.GridEXRow gri in gridEXNotification.GetRows())
                    {
                        if (gri.RowType == Janus.Windows.GridEX.RowType.Record)
                        {
                             
                            attendeeId = (int)gri.Cells["AttendeeId"].Value;
                            atriumDB.AttendeeRow attrow = currentFM.DB.Attendee.FindByAttendeeId(attendeeId);
                            if (!attrow.IsNotificationDismissNull())
                            {
                                attrow.BeginEdit();
                                attrow.NotificationDismiss  = true;
                                attrow.Interval = 0; 
                                attrow.EndEdit();
                            
                            }
                           
                        }
                    }
                    
                    atLogic.BusinessProcess bp = currentFM.GetBP();
                    bp.AddForUpdate(currentFM.DB.Attendee);
                    bp.Update();

                    this.Close();
                }
            
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        } 

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            try 
            {
               int attendeeId;
               List<DataRow> rowList = new List<DataRow>();
                
               foreach (Janus.Windows.GridEX.GridEXSelectedItem gsi in gridEXNotification.SelectedItems)
               {
                   if (gsi.RowType == Janus.Windows.GridEX.RowType.Record)
                   {
                       rowList.Add(((DataRowView)gsi.GetRow().DataRow).Row);
                   }
               }

               if (rowList.Count > 0)
               {
                   foreach (DataRow dr in rowList)
                   {
                       attendeeId = (int)dr["AttendeeId"];//.ItemArray[0];
                       atriumDB.AttendeeRow attrow = currentFM.DB.Attendee.FindByAttendeeId(attendeeId);
                       if (!attrow.IsNotificationDismissNull())
                       {
                           attrow.BeginEdit();
                           attrow.NotificationDismiss = true;
                           attrow.Interval  = 0;
                           
                           attrow.EndEdit();
                       }
                       dr.Delete();
                       dr.AcceptChanges();
                   }
                   atLogic.BusinessProcess bp = currentFM.GetBP();
                   bp.AddForUpdate(currentFM.DB.Attendee);
                   bp.Update();

                   DataTable dt =(DataTable) bSourceAppointmentDataview.DataSource;
                   if (dt.Rows.Count == 0)
                       this.Close();
                   SetFormHeader(dt.Rows.Count);
                   Refresh();
               }
               else
               {
                  this.Close();
               }
            }
            catch (Exception x)
            {
               UIHelper.HandleUIException(x);
            }
        }

        private void gridEX_SelectionChanged(object sender, EventArgs e)
        {
             int countItems = this.gridEXNotification.SelectedItems.Count;
             try
             { 
                 if(countItems > 0)
                 { 
                     if (countItems == 1)
                     {

                         Janus.Windows.GridEX.GridEXRow ger = gridEXNotification.CurrentRow;
                         this.lblSubject.Text = ger.Cells["Subject"].Value.ToString();
                         DateTime dateTime = (DateTime) ger.Cells["StartDateLocal"].Value;

                         if (currentFM.AppMan.Language.ToUpper() == "ENG")
                             this.lblStartDate.Text = dateTime.ToString("MMMM dd, yyyy @ hh:mm tt", System.Globalization.CultureInfo.CreateSpecificCulture("en-CA")) ;
                         else
                             this.lblStartDate.Text = dateTime.ToString("dd MMMM yyyy à HH:mm", System.Globalization.CultureInfo.CreateSpecificCulture("fr-CA"));
                     }
                     else
                     {
                         this.lblSubject.Text = countItems.ToString() + " "+Properties.Resources.ResxRemindersSelected;
                         this.lblStartDate.Text = "";

                         //if (currentFM.AppMan.Language.ToUpper() == "ENG")
                         //    this.lblSubject.Text = countItems.ToString() + " reminders are selected";
                         //else
                         //    this.lblSubject.Text = countItems.ToString() + " rappels sont sélectionnés";
                     }
                 }
             }
             catch (Exception x)
             {
                 UIHelper.HandleUIException(x);
             }
       }

        private void btnSnooze_Click(object sender, EventArgs e)
        {
            try
            {
                int attendeeId;
                List<DataRow> rowList = new List<DataRow>();

                foreach (Janus.Windows.GridEX.GridEXSelectedItem gsi in gridEXNotification.SelectedItems)
                {
                    if (gsi.RowType == Janus.Windows.GridEX.RowType.Record)
                    {
                        rowList.Add(((DataRowView)gsi.GetRow().DataRow).Row);
                    }
                }

                if (rowList.Count > 0)
                {
                    foreach (DataRow dr in rowList)
                    {
                        attendeeId = (int)dr.ItemArray[0];
                        atriumDB.AttendeeRow attrow = currentFM.DB.Attendee.FindByAttendeeId(attendeeId);
                        atriumDB.AppointmentRow approw =  attrow.AppointmentRow;
                        if (!attrow.IsNotificationDismissNull())
                        {
                            attrow.BeginEdit();
                            attrow.NotificationDismiss = false;
                            int SelectedValue;
                            bool result = Int32.TryParse(ucDDReminder.SelectedValue.ToString(), out SelectedValue);
                            if (result)
                                attrow.Interval = SelectedValue;
                            //
                            // Activate this option in 1.10
                            //
                            //TimeSpan TS = approw.StartDateLocal.Subtract(DateTime.Now);
                            //int SelectedValue;
                            //bool result = Int32.TryParse(ucDDReminder.SelectedValue.ToString(), out SelectedValue);
                            //if (result)
                            //{
                            //    double interval = TS.TotalMinutes - SelectedValue;
                            //    attrow.Interval = Convert.ToInt32(interval);
                            //}
                            

                             
                            attrow.EndEdit();
                        }
                        dr.Delete();
                        dr.AcceptChanges();
                    }
                    atLogic.BusinessProcess bp = currentFM.GetBP();
                    bp.AddForUpdate(currentFM.DB.Attendee);
                    bp.Update();

                    DataTable dt = (DataTable)bSourceAppointmentDataview.DataSource;
                    if (dt.Rows.Count == 0)
                        this.Close();
                    SetFormHeader(dt.Rows.Count);
                    Refresh();
                    
                    

                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }
    }
}

 