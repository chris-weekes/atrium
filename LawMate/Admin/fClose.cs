using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

 namespace LawMate.Admin
{
    public enum PeriodEnum
    {
        Monthly = 0,
        Annual = 1
    }

    public partial class fClose : fBase
    {
        DataTable dtAnnual;
        DataTable dtMonthly;

        public fClose()
        {
            InitializeComponent();
        }
        public fClose(Form f)
            : base(f)
        {
            InitializeComponent();
            ucFileSelectBox1.AtMng = AtMng;
            ucFileSelectBox1.FileId = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                bool OKToContinue = false;
                if (MessageBox.Show("Are you sure you want to close the listed files and open new ones?", "Confirm File Closure", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    OKToContinue = true;

                if (OKToContinue)
                {
                    gridExMonthlyFiles.DataSource = null;
                    gridExAnnualFiles.DataSource = null;
                    string ffn = AtMng.GetFile((int)ucFileSelectBox1.FileId).CurrentFile.FullPath;
                    AtMng.GetFilePeriod().Load();

                    DateTime newPeriod = calendarCombo1.Value;
                    DateTime periodToClose = DateTime.Today;
                    foreach (CodesDB.FilePeriodRow fpr in AtMng.CodeDB.FilePeriod)
                    {
                        PeriodEnum per = PeriodEnum.Annual;

                        switch (fpr.DatePart.ToLower())
                        {
                            case "y":
                                periodToClose = newPeriod.AddYears(-fpr.PeriodLength);
                                dtAnnual = AtMng.AppMan.ExecuteDataset("FilesToClose", fpr.PeriodId, ffn, periodToClose).Tables[0];
                                per = PeriodEnum.Annual;
                                break;
                            //case "q":
                            //    periodToClose = newPeriod.AddMonths(-fpr.PeriodLength * 3);
                            //    break;
                            case "m":
                                periodToClose = newPeriod.AddMonths(-fpr.PeriodLength);
                                dtMonthly = AtMng.AppMan.ExecuteDataset("FilesToClose", fpr.PeriodId, ffn, periodToClose).Tables[0];
                                per = PeriodEnum.Monthly;
                                break;
                            default:
                                //unknow datepart value
                                break;
                        }

                        if (per == PeriodEnum.Annual)
                        {
                            ApplyClosure(dtAnnual, newPeriod, fpr, periodToClose);
                            gridExAnnualFiles.RootTable.Caption = "Annual Files (" + dtAnnual.Rows.Count.ToString() + " files)";
                            gridExAnnualFiles.DataSource = dtAnnual;
                            gridExAnnualFiles.Refetch();
                        }
                        else if (per == PeriodEnum.Monthly)
                        {
                            ApplyClosure(dtMonthly, newPeriod, fpr, periodToClose);
                            gridExMonthlyFiles.DataSource = dtMonthly;
                            gridExMonthlyFiles.RootTable.Caption = "Monthly Files (" + dtMonthly.Rows.Count.ToString() + " files)";
                            gridExMonthlyFiles.Refetch();
                        }
                    }
                    MessageBox.Show("File Closure Operation Completed.\n\nThe Affected Files are listed in their appropriate grid", "Periodic File Closure Operation", MessageBoxButtons.OK);
                    btnClose.Enabled = false;
                }
            }
            catch (Exception x)
            {
              
                gridExAnnualFiles.DataSource = null;
                gridExMonthlyFiles.DataSource = null;
                UIHelper.HandleUIException(x);
            }
        }

        private void ApplyClosure(DataTable dt, DateTime newPeriod, CodesDB.FilePeriodRow fpr, DateTime periodToClose)
        {
            foreach (DataRow dr in dt.Rows)
            {

                FileManager fm = AtMng.GetFile((int)dr[0]);

                //close file
                fm.CurrentFile.ClosedDate = DateTime.Today;
                fm.CurrentFile.StatusCode = "C";
                fm.CurrentFile.CloseCode = "PER";


                //get parent filemanger
                FileManager fmp = AtMng.GetFile(fm.EFile.GetEfileParentRow(fm.CurrentFile).FileId);

                //create new file
                FileManager fmnew = AtMng.CreateFile(fmp);
                if (!fmp.CurrentFile.FileMetaTypeRow.SubFileAutoNumber)
                {
                    fmnew.CurrentFile.FileNumber = "999";
                }
                fmnew.CurrentFile.NameE = String.Format(fpr.NewFileNameFormat, newPeriod, newPeriod.AddYears(1));
                fmnew.CurrentFile.NameF = String.Format(fpr.NewFileNameFormat, newPeriod, newPeriod.AddYears(1));
                fmnew.CurrentFile.FileType = fm.CurrentFile.FileType;
                fmnew.CurrentFile.MetaType = fm.CurrentFile.MetaType;
                fmnew.CurrentFile.PeriodId = fm.CurrentFile.PeriodId;
                fmnew.CurrentFile.PeriodStartDate = newPeriod;
                fmnew.CurrentFile.OpenedDate = DateTime.Today;

                foreach (atriumDB.FileOfficeRow fo_r in fmnew.CurrentFile.GetFileOfficeRows())
                {
                    fo_r.Delete();

                }

                foreach (atriumDB.FileOfficeRow fo_r in fm.CurrentFile.GetFileOfficeRows())
                {
                    atriumDB.FileOfficeRow fmnew_or =(atriumDB.FileOfficeRow) fmnew.GetFileOffice().Add(fmnew.CurrentFile);

                    fmnew_or.OfficeId = fo_r.OfficeId;
                    fmnew_or.IsLead = fo_r.IsLead;
                    fmnew_or.IsOwner = fo_r.IsOwner;
                    fmnew_or.IsClient = fo_r.IsClient;
                    fmnew_or.IsPrimary = fo_r.IsPrimary;

                    fmnew_or.PercentAlloc = fo_r.PercentAlloc;
                    
                    if (!fo_r.IsOrderNumberNull())
                        fmnew_or.OrderNumber = fo_r.OrderNumber;
                    
                }

                

                //clone shortcuts
                foreach (atriumDB.FileXRefRow fxr in fm.CurrentFile.GetFileXRefRowsByEFile_FileXRefParent())
                {
                    if (fxr.LinkType == 2)
                    {
                        if (chkCreate.Checked)
                        {
                            atriumDB.FileXRefRow fxrnew = (atriumDB.FileXRefRow)fmnew.GetFileXRef().Add(fmnew.CurrentFile);
                            fxrnew.LinkType = 2;
                            fxrnew.Name = fxr.Name.Replace(String.Format(fpr.NewFileNameFormat, periodToClose, periodToClose.AddYears(1)), "") + String.Format(fpr.NewFileNameFormat, newPeriod, newPeriod.AddYears(1));
                            fxrnew.OtherFileId = fmnew.CurrentFileId;
                            fxrnew.FileId = fxr.FileId;
                        }
                        if (chkDel.Checked)
                        {
                            fxr.Delete();
                        }
                    }
                }
                if (chkCloneContacts.Checked)
                {

                    atriumDB.FileContactRow[] fcrs = (atriumDB.FileContactRow[])fm.DB.FileContact.Select("Active=1");
                    foreach (atriumDB.FileContactRow fcr in fcrs)
                    {
                        atriumDB.FileContactRow fcrnew = (atriumDB.FileContactRow)fmnew.GetFileContact().Add(fmnew.CurrentFile);
                        fcrnew.ContactId = fcr.ContactId;
                        fcrnew.ContactType = fcr.ContactType;
                    }
                }

                //update containerfileid in series
                lmDatasets.ActivityConfig.SeriesRow[] srs = (lmDatasets.ActivityConfig.SeriesRow[])fm.AtMng.acMng.DB.Series.Select("ContainerFileId=" + fm.CurrentFileId.ToString());
                foreach (lmDatasets.ActivityConfig.SeriesRow sr in srs)
                {
                    sr.ContainerFileId = fmnew.CurrentFileId;
                }

                if (!fm.DB.HasErrors & !fmnew.DB.HasErrors)
                {
                    atLogic.BusinessProcess bp = fm.GetBP();

                    bp.AddForUpdate(fm.EFile);
                    bp.AddForUpdate(fm.GetFileXRef());
                    bp.AddForUpdate(fm.GetFileOffice());
                   
                    bp.Update();

                    dr["Closed"] = true;


                    atLogic.BusinessProcess bpNew = fm.GetBP();

                    bpNew.AddForUpdate(fmnew.EFile);
                    bpNew.AddForUpdate(fmnew.GetFileXRef());
                    bpNew.AddForUpdate(fmnew.GetFileOffice());
                    bpNew.AddForUpdate(fmnew.GetFileContact());
                
                  
                    bpNew.AddForUpdate(fm.AtMng.acMng.GetSeries());

                    bpNew.Update();

                    //this handles the TOC and security
                    bpNew.Clear();

                    //check for break inheritance
                    List<int> toDel = new List<int>();
                    if (fm.EFile.GetParentFileXref(fm.CurrentFile).secBreakInherit)
                    {
                        fmnew.EFile.BreakInherit();
                        //delete existing rules
                        for (int j = 0; j < fmnew.DB.secFileRule.Rows.Count; j++)
                        {
                             toDel.Add(fmnew.DB.secFileRule[j].Id);

                        }

                    }
                    //clone security settings
                   // fm.GetsecFileRule().LoadByFileId(fm.CurrentFileId);
                    int i = 0;
                    foreach (atriumDB.secFileRuleRow sfr in fm.DB.secFileRule)
                    {
                        if (!sfr.Inherited)
                        {
                            atriumDB.secFileRuleRow sfrnew = (atriumDB.secFileRuleRow)fmnew.GetsecFileRule().Add(fmnew.CurrentFile);
                            sfrnew.Id = i;
                            i++;
                            sfrnew.Inherited = false;
                            sfrnew.ApplyTo = sfr.ApplyTo;
                            sfrnew.Disabled = sfr.Disabled;
                            sfrnew.StartDate = sfr.StartDate;
                            sfrnew.EndDate = sfr.EndDate;
                            sfrnew.GroupId = sfr.GroupId;
                            sfrnew.RuleId = sfr.RuleId;

                        }
                    }

                    
                    bpNew.AddForUpdate(fmnew.EFile);
                    bpNew.AddForUpdate(fmnew.GetsecFileRule());
                    bpNew.Update();

                    bpNew.Clear();
                    for (int j = 0; j < fmnew.DB.secFileRule.Rows.Count; j++)
                    {
                        if (toDel.Contains(fmnew.DB.secFileRule[j].Id))
                            fmnew.DB.secFileRule[j].Delete();

                    }
                    bpNew.AddForUpdate(fmnew.GetsecFileRule());
                    bpNew.Update();

                    dr["NewFileOpened"] = true;
                    dr.EndEdit();

                   
                }
                //to prevent massive memory use
                fm.Dispose();
                fmnew.Dispose();
                fmp.Dispose();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                gridExAnnualFiles.DataSource = null;
                gridExMonthlyFiles.DataSource = null;

                string ffn = AtMng.GetFile((int)ucFileSelectBox1.FileId).CurrentFile.FullPath;
                AtMng.GetFilePeriod().Load();

                DateTime newPeriod = calendarCombo1.Value;
                DateTime periodToClose = DateTime.Today;
                foreach (CodesDB.FilePeriodRow fpr in AtMng.CodeDB.FilePeriod)
                {
                    switch (fpr.DatePart.ToLower())
                    {
                        case "y":
                            periodToClose = newPeriod.AddYears(-fpr.PeriodLength);
                            dtAnnual = AtMng.AppMan.ExecuteDataset("FilesToClose", fpr.PeriodId, ffn, periodToClose).Tables[0];
                            gridExAnnualFiles.DataSource = dtAnnual;
                            gridExAnnualFiles.RootTable.Caption = "Annual Files (" + dtAnnual.Rows.Count.ToString() + " files)";
                            gridExAnnualFiles.DataMember = "";
                            break;
                        case "m":
                            periodToClose = newPeriod.AddMonths(-fpr.PeriodLength);
                            dtMonthly = AtMng.AppMan.ExecuteDataset("FilesToClose", fpr.PeriodId, ffn, periodToClose).Tables[0];
                            gridExMonthlyFiles.RootTable.Caption = "Monthly Files (" + dtMonthly.Rows.Count.ToString() + " files)";
                            gridExMonthlyFiles.DataSource = dtMonthly;
                            gridExMonthlyFiles.DataMember = "";
                            break;
                        default:
                            //unknow datepart value
                            break;
                    }
                }
                btnClose.Enabled = true;
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void calendarCombo1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                btnClose.Enabled = false;
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }

        private void ucFileSelectBox1_FileChanged(object sender, EventArgs e)
        {
            try
            {
                btnClose.Enabled = false;
            }
            catch (Exception x)
            {

                UIHelper.HandleUIException(x);
            }
        }
    }
}

