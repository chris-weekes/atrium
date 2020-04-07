using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using lmDatasets;

namespace LawMate
{
    public class UIHelper
    {
        //JLL added 2015-08-30
        public static int AdjustHeightInt(Control control, int variableToAdjust)
        {
            float dpiX;
            int returnInt = variableToAdjust;
            Graphics graphics = control.CreateGraphics();
            dpiX = graphics.DpiX;
            if (dpiX > 96)
                returnInt = (int)(variableToAdjust * 1.25);

            return returnInt;
        }

        public static void SetNonProdUI(IWin32Window frm, Janus.Windows.Common.VisualStyleManager vsm)
        {
            vsm.ColorSchemes[0].OfficeColorScheme = Janus.Windows.Common.OfficeColorScheme.Custom;
            vsm.ColorSchemes[0].OfficeCustomColor = Color.PaleGoldenrod;

            vsm.ColorSchemes[1].OfficeColorScheme = Janus.Windows.Common.OfficeColorScheme.Custom;
            vsm.ColorSchemes[1].OfficeCustomColor = Color.DarkGray;
        }

        public static void MoveTab(Janus.Windows.UI.Dock.UIPanelGroup pnlTab, string operation)
        {
            try
            {
                int pnlCount = pnlTab.Panels.Count;

                switch (operation)
                {
                    case "first":
                        int fSelectPanelIndex = 0;
                        int fInc = 0;
                        while (pnlCount > fSelectPanelIndex + 1)
                        {
                            if (!pnlTab.Panels[fSelectPanelIndex + fInc].Closed && pnlTab.Panels[fSelectPanelIndex + fInc].Enabled)
                            {
                                pnlTab.SelectedPanel = pnlTab.Panels[fSelectPanelIndex + fInc];
                                break;
                            }
                            fInc++;
                        }
                        break;

                    case "next":

                        int nSelectPanelIndex = pnlTab.Panels.IndexOf(pnlTab.SelectedPanel);
                        int nInc = 1;
                        while (pnlCount > nSelectPanelIndex + 1)
                        {
                            if (!pnlTab.Panels[nSelectPanelIndex + nInc].Closed && pnlTab.Panels[nSelectPanelIndex + nInc].Enabled)
                            {
                                pnlTab.SelectedPanel = pnlTab.Panels[nSelectPanelIndex + nInc];
                                break;
                            }
                            nInc++;
                        }
                        break;

                    case "previous":

                        int pSelectPanelIndex = pnlTab.Panels.IndexOf(pnlTab.SelectedPanel);
                        int pInc = 1;
                        while (pSelectPanelIndex > 0)
                        {
                            if (!pnlTab.Panels[pSelectPanelIndex - pInc].Closed && pnlTab.Panels[pSelectPanelIndex - pInc].Enabled)
                            {
                                pnlTab.SelectedPanel = pnlTab.Panels[pSelectPanelIndex - pInc];
                                break;
                            }
                            pInc++;
                        }
                        break;

                    case "last":

                        for (int a = pnlCount; a > 0; a--)
                        {
                            if (!pnlTab.Panels[a - 1].Closed && pnlTab.Panels[a - 1].Enabled)
                            {
                                pnlTab.SelectedPanel = pnlTab.Panels[a - 1];
                                break;
                            }
                        }

                        break;
                    default:
                        break;
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        static atriumBE.atriumManager atmng;
        public static atriumBE.atriumManager AtMng
        {
            get { return atmng; }
            set { atmng = value; }
        }

        public static atriumBE.atriumManager Login()
        {

            try
            {

                atriumBE.Servers servers = new atriumBE.Servers();

                servers.ReadXml(AppPath + "\\serverlist.xml");


                fLogin fl = new fLogin();
                fl.ServerList = servers;
                for (int i = 1; i <= 5; i++)
                {
                    try
                    {
                        //prompt for userid
                        fl.ShowDialog();

                        if (fl.isCancel) //if cancel is clicked, exit app
                        {
                            throw new Exception("quit");
                        }
                        else    //try to logon with provided credentials
                        {
                            string UserLang;
                            if (fl.EnglishRadio.Checked)
                            {
                                UserLang = "ENG";
                                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                                Application.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                            }
                            else
                            {
                                UserLang = "FRE";
                                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-CA");
                                Application.CurrentCulture = new System.Globalization.CultureInfo("fr-CA");
                            }

                            atriumBE.Servers.ServerRow server = servers.Server.FindByserverName(fl.cboServer.Text);

                            if (server.remoteUrl.ToUpper() == "CLICKONCE" && System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                            {
                                string an = Application.ProductName;
                                server.remoteUrl = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.UpdateLocation.AbsoluteUri.Replace("/deploy/" + an + ".application", "");
                                server.proxyUrl = server.remoteUrl;
                            }
                            if (server.trustedConnection)
                            {
                                AtMng = new atriumBE.AtriumApp(UserLang, server).AtMng;
                            }
                            else
                            {
                                AtMng = new atriumBE.AtriumApp(fl.editBox1.Text, fl.editBox2.Text, UserLang, server, fl.fwPassword.Text).AtMng;
                            }

                            System.Diagnostics.Trace.WriteLine("Successful logon by " + AtMng.OfficerLoggedOn.UserName);

                            fl.Close();

                            return AtMng;

                        }




                    }
                    catch (Exception xt)
                    {
                        if (xt.Message == "quit")
                            throw;

                        if (i < 5)
                        {
                            //keep trying
                            MessageBox.Show(xt.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }

                }

                fl.Close();
                throw new Exception(Properties.Resources.LoginMaxAttempts);


            }
            catch (Exception x)
            {
                if (x.Message != "quit")
                    MessageBox.Show(x.Message, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                throw;
            }

        }

        public static byte[] GetFileIcon(string fName)
        {
            System.Drawing.Icon icon = UIHelper.GetFileIconSH(fName.Trim());
            if (icon != null)
            {
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(System.Drawing.Bitmap));

                byte[] blob = (byte[])tc.ConvertTo(icon.ToBitmap(), typeof(byte[]));
                return blob;
            }
            else
                return null;

        }

        public static System.Drawing.Icon GetFileIconSH(string fName)
        {
            if (fName == null || fName == "")
                return null;

            if (fName.ToLower() == ".htm")
                return Properties.Resources.rc_html;

            IntPtr hImgSmall;    //the handle to the system image list
            //IntPtr hImgLarge;    //the handle to the system image list
            SHFILEINFO shinfo = new SHFILEINFO();


            //Use this to get the small Icon
            hImgSmall = Win32.SHGetFileInfo(fName, Win32.FILE_ATTRIBUTE_NORMAL, ref shinfo,
                                               (uint)Marshal.SizeOf(shinfo),
                                                Win32.SHGFI_ICON |
                                                Win32.SHGFI_SMALLICON | Win32.SHGFI_USEFILEATTRIBUTES);

            //Use this to get the large Icon
            //hImgLarge = SHGetFileInfo(fName, 0,
            //ref shinfo, (uint)Marshal.SizeOf(shinfo),
            //Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);

            //The icon is returned in the hIcon member of the shinfo
            //struct
            if ((int)shinfo.hIcon == 0)
                return null;
            else
            {
                System.Drawing.Icon myIcon =
                           System.Drawing.Icon.FromHandle(shinfo.hIcon);

                return myIcon;
            }
        }

        public static string GetRoleCodeTypeAndDescription(string roleCode, bool returnDescriptionOnly)
        {
            System.Data.DataTable dtRole = AtMng.GetFile().Codes("RoleCode");
            System.Data.DataRow[] drRole = dtRole.Select("RoleCode='" + roleCode + "'", "");
            string roleType = "Global";
            string roleDesc;
            if (drRole.Length == 0)
            {
                roleType = "File-Based";
                dtRole = UIHelper.AtMng.GetFile().Codes("ContactType");
                drRole = dtRole.Select("ContactTypeCode='" + roleCode + "'", "");
                roleDesc = drRole[0]["ContactTypeDescEng"].ToString();
            }
            else
                roleDesc = drRole[0]["RoleEng"].ToString();

            if (returnDescriptionOnly)
                return roleDesc;
            else
                return roleType + " Role: " + roleDesc;
        }

        public static void LoadDocShortcuts(System.Windows.Forms.TreeNode treeNode, atriumBE.atriumManager atmng)
        {
            if (treeNode == null)
                return;

            int fileid;
            if (treeNode.Tag.GetType() == typeof(int))
                fileid = (int)treeNode.Tag;
            else
            {
                appDB.EFileSearchRow efsr = (appDB.EFileSearchRow)treeNode.Tag;
                fileid = efsr.FileId;
            }

            appDB.EFileSearchDataTable dt = atmng.FileSearchByParentFileId(fileid);

            //DocManager DMDocShortcut = atmng.GetFile(fileid, false).GetDocMng();
            //DMDocShortcut.GetDocXRef().LoadByFileId(fileid);

            docDB.DocXRefDataTable docSCs = atmng.DocShortcuts(fileid);
            docDB.DocXRefRow[] dxrs = (docDB.DocXRefRow[])docSCs.Select("", "Name");
            foreach (docDB.DocXRefRow docXrefRow in dxrs)
            {
                System.Windows.Forms.TreeNode nd = new System.Windows.Forms.TreeNode();
                nd.Name = "nodeDocXRef" + docXrefRow.DocId.ToString();
                nd.Tag = docXrefRow;
                nd.Text = docXrefRow.Name;
                nd.ImageKey = "docShortcut.gif";
                nd.SelectedImageKey = "docShortcut.gif";
                treeNode.Nodes.Add(nd);
            }
            treeNode.Expand();
        }

        public static void DocumentCheckOutAction(UserControls.DocCheckOutActionEnum CheckOutAction, lmDatasets.docDB.DocumentRow dr, atriumBE.DocManager dm, UserControls.ucDoc ucdoc)
        {
            ucdoc.Clear();
            string checkOutDocPath = "";
            switch (CheckOutAction)
            {
                case UserControls.DocCheckOutActionEnum.CheckOut:
                    checkOutDocPath = dm.GetDocument().Checkout(dr);
                    break;
                case UserControls.DocCheckOutActionEnum.CheckIn:
                    dm.GetDocument().Checkin(dr);



                    break;
                case UserControls.DocCheckOutActionEnum.UndoCheckOut:
                    dm.GetDocument().UndoCheckout(dr);
                    break;
            }

            ucdoc.ToggleCheckout();
            ucdoc.Preview();

            if (CheckOutAction == UserControls.DocCheckOutActionEnum.CheckOut)
                LaunchNative(checkOutDocPath, ucdoc, "");
        }

        public static void DocumentCheckOutAction(UserControls.DocCheckOutActionEnum CheckOutAction, lmDatasets.docDB.DocumentRow dr, atriumBE.DocManager dm, UserControls.ucDocView ucdoc)
        {
            ucdoc.Clear();
            string checkOutDocPath = "";
            switch (CheckOutAction)
            {
                case UserControls.DocCheckOutActionEnum.CheckOut:
                    checkOutDocPath = dm.GetDocument().Checkout(dr);
                    break;
                case UserControls.DocCheckOutActionEnum.CheckIn:
                    dm.GetDocument().Checkin(dr);
                    break;
                case UserControls.DocCheckOutActionEnum.UndoCheckOut:
                    if (MessageBox.Show(Properties.Resources.UIConfirmUndoCheckout, Properties.Resources.UIConfirmUndoCheckoutCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        dm.GetDocument().UndoCheckout(dr);
                    break;
            }

            ucdoc.ToggleCheckout();
            ucdoc.Preview();

            if (CheckOutAction == UserControls.DocCheckOutActionEnum.CheckOut)
                LaunchNativeN(checkOutDocPath, ucdoc, "");
        }

        public static void DocumentCheckIn(lmDatasets.docDB.DocumentRow dr, atriumBE.DocManager dm, UserControls.ucDoc ucdoc)
        {
            ucdoc.Clear();

            ucdoc.ToggleCheckout();
            ucdoc.Preview();
        }

        public static void DocumentUndoCheckOut(lmDatasets.docDB.DocumentRow dr, atriumBE.DocManager dm, UserControls.ucDoc ucdoc)
        {
            ucdoc.Clear();

            ucdoc.ToggleCheckout();
            ucdoc.Preview();
        }

        public static void CreateNewDocXRef(atriumBE.atriumManager atmng, lmDatasets.docDB.DocumentRow dr)
        {
            fBrowse fBrowseDocShortcut = new fBrowse(atmng, 0, false, false, false, true);
            fBrowseDocShortcut.FindFile(atmng.WorkingAsOfficer.ShortcutsId);
            if (fBrowseDocShortcut.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fDocXRef fdocxref = new fDocXRef();
                fdocxref.SetDefaultName(dr.efSubject);
                fdocxref.ShowDialog();
                if (fdocxref.Cancel)
                {
                    fdocxref.Close();
                    return;
                }
                else
                {
                    atriumBE.FileManager fmngr = atmng.GetFile(fBrowseDocShortcut.SelectedFile.FileId);
                    atriumBE.DocManager docmngr = fmngr.GetDocMng();
                    lmDatasets.docDB.DocXRefRow docXrefNew = (lmDatasets.docDB.DocXRefRow)docmngr.GetDocXRef().Add(fmngr.CurrentFile);
                    docXrefNew.Name = fdocxref.textBoxValue();
                    docXrefNew.DocId = dr.DocId;
                    docXrefNew.FileId = fBrowseDocShortcut.SelectedFile.FileId;
                    atLogic.BusinessProcess bp = fmngr.GetBP();
                    bp.AddForUpdate(docmngr.GetDocXRef());
                    bp.Update();
                }
            }
        }

        public static void BindComboBox(ComboBox cb, DataTable dt, string valMember, string dispMember)
        {
            cb.DataSource = null;
            DataView dv = new DataView(dt);
            cb.DataSource = dv;
            cb.ValueMember = valMember;
            cb.DisplayMember = dispMember;

        }

        public static void TableHasErrorsOnSaveMessBox(DataSet ds)
        {
            string err = "";
            foreach (DataTable dt in ds.Tables)
            {
                if (dt.HasErrors)
                {
                    foreach (DataRow dr in dt.GetErrors())
                    {
                        err += String.Format("{0} Row Error: {1}\n\r", dt.TableName, dr.RowError);
                        foreach (DataColumn dc in dr.GetColumnsInError())
                        {
                            err += String.Format("Column {0} error: {1}\n\r", dc.ColumnName, dr.GetColumnError(dc));
                        }
                    }
                }
            }

            MessageBox.Show(Properties.Resources.UICantSaveWhileErrors + "\n\r\n\r" + err);
        }

        public static string FormatMinutes(int minutes)
        {
            TimeSpan ts = new TimeSpan(0, minutes, 0);

            string vhours = "00";
            string vminutes = "00";
            int h = ts.Hours + ts.Days * 24;
            if (h > 0 && h < 10)
                vhours = "0" + h.ToString();
            else if (h >= 10)
                vhours = h.ToString();

            if (ts.Minutes > 0 && ts.Minutes < 10)
                vminutes = "0" + ts.Minutes.ToString();
            else if (ts.Minutes >= 10)
                vminutes = ts.Minutes.ToString();

            return vhours + ":" + vminutes;
        }

        public static void GridEnabledChanged(Janus.Windows.GridEX.GridEX grd)
        {
            if (grd.Enabled)
            {
                //grd.BackColor = SystemColors.Window;
                //grd.BorderStyle = Janus.Windows.GridEX.BorderStyle.SunkenLight3D;
                //grd.Font = new Font(grd.Font, FontStyle.Regular);
            }
            else
            {
                //grd.BackColor = SystemColors.ControlLight;
                //grd.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
                //grd.Font = new Font(grd.Font, FontStyle.Italic);
            }
        }

        public static void ComboBoxInit(string codeTable, ComboBox cb, atriumBE.FileManager fm, string valMember, string dispMember)
        {
            DataTable dt = fm.Codes(codeTable);
            BindComboBox(cb, dt, valMember, dispMember);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public static void ComboBoxInit(string codeTable, ComboBox cb, atriumBE.FileManager fm)
        {
            DataTable dt = fm.Codes(codeTable);
            string desc = Translate(fm, cb.DisplayMember);
            BindComboBox(cb, dt, cb.ValueMember, desc);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public static void ComboBoxInit(object datasource, ComboBox cb, atriumBE.FileManager fm)
        {
            DataTable dt = (DataTable)datasource;
            string desc = Translate(fm, cb.DisplayMember);
            BindComboBox(cb, dt, cb.ValueMember, desc);
            cb.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public static void ComboBoxInit(DataTable dt, Janus.Windows.GridEX.GridEXDropDown cb, atriumBE.FileManager fm)
        {
            cb.Columns[0].DataMember = Translate(fm, cb.Columns[0].DataMember);
            if (cb.Columns.Count > 1)
                cb.Columns[1].DataMember = Translate(fm, cb.Columns[1].DataMember);
            cb.DisplayMember = Translate(fm, cb.DisplayMember);
            cb.SetDataBinding(dt, "");

        }

        public static void ComboBoxInit(string codeTable, Janus.Windows.GridEX.GridEXDropDown cb, atriumBE.FileManager fm)
        {
            DataTable dt = fm.Codes(codeTable);
            cb.Columns[0].DataMember = Translate(fm, cb.Columns[0].DataMember);
            if (cb.Columns.Count > 1)
                cb.Columns[1].DataMember = Translate(fm, cb.Columns[1].DataMember);
            cb.DisplayMember = Translate(fm, cb.DisplayMember);
            cb.SetDataBinding(dt, "");

        }

        public static void ComboBoxInit(string codeTable, UserControls.ucMultiDropDown cb, atriumBE.FileManager fm)
        {
            DataTable dt = fm.Codes(codeTable);

            cb.DisplayMember = Translate(fm, cb.DisplayMember);
            cb.Column2 = Translate(fm, cb.Column2);
            cb.SetDataBinding(dt, "");

        }

        public static void ComboBoxInit(object datasource, UserControls.ucMultiDropDown cb, atriumBE.FileManager fm)
        {

            cb.DisplayMember = Translate(fm, cb.DisplayMember);
            cb.Column2 = Translate(fm, cb.Column2);
            cb.SetDataBinding(datasource, "");

        }

        public static void ComboBoxInit(DataTable datasource, Janus.Windows.EditControls.UIComboBox cb, string valueMember, string displayMember)
        {
            cb.DataSource = null;
            DataView dv = new DataView(datasource);
            cb.DataSource = dv;
            cb.ValueMember = valueMember;
            cb.DisplayMember = displayMember;

        }
        
        public static void ComboBoxInit(string codeTable, Janus.Windows.EditControls.UIComboBox cb, atriumBE.FileManager fm)
        {
            DataTable dt = fm.Codes(codeTable);
            DataView dv = new DataView(dt);
            cb.DataSource = dv;
            //cb.ValueMember = dt.Columns[0].ColumnName;

            string desc = Translate(fm, cb.DisplayMember);

            cb.DisplayMember = desc;
        }

        public static void ComboBoxInit(string codeTable, Janus.Windows.EditControls.UIComboBox cb, atriumBE.FileManager fm, string valMember, string dispMember)
        {
            DataTable dt = fm.Codes(codeTable);
            DataView dv = new DataView(dt);
            cb.DataSource = dv;
            cb.ValueMember = valMember;
            cb.DisplayMember = dispMember;
        }

        public static string Translate(atriumBE.FileManager fm, string column)
        {
            

            return fm.AtMng.Translate(column);
        }

        public static void MultiColumnComboInit(string codeTable, Janus.Windows.GridEX.EditControls.MultiColumnCombo cb, atriumBE.FileManager fm)
        {
            DataTable dt = fm.Codes(codeTable);
            DataView dv = new DataView(dt);
            cb.DataSource = dv;
            //cb.ValueMember = dt.Columns[0].ColumnName;

            string desc = Translate(fm, cb.DisplayMember);

            cb.DisplayMember = desc;
        }

        public static void CheckedComboBoxInit(string codeTable, CheckedListBox clb, atriumBE.FileManager fm)
        {
            CheckedComboBoxInit(codeTable, clb, fm, null);
        }

        public static void CheckedComboBoxInit(string codeTable, CheckedListBox clb, atriumBE.FileManager fm, atLogic.WhereClause wc)
        {
            DataTable dt;
            if (wc == null)
                dt = fm.Codes(codeTable);
            else
                dt = fm.Codes(codeTable, wc, true);

            string desc = Translate(fm, dt.Columns[1].ColumnName);

            foreach (DataRow dr in dt.Rows)
            {
                clb.Items.Add(dr[0].ToString() + " - " + dr[desc].ToString(), false);
            }
        }

        static string appRegKey = @"HKEY_CURRENT_USER\Software\Asptek\Atrium";
        public static void SaveSetting(string valueName, string data)
        {
            Microsoft.Win32.Registry.SetValue(appRegKey, valueName, data);
        }

        public static string GetSetting(string valueName, string defaultValue)
        {
            string s = GetSetting(valueName);
            if (s == null || s == "")
                return defaultValue;
            else
                return s;
        }

        public static string GetSetting(string valueName)
        {
            return (string)Microsoft.Win32.Registry.GetValue(appRegKey, valueName, "");
        }

        public static void HandleUIException(Exception x1)
        {
            //System.Diagnostics.Trace.TraceError("{2} {0}\n\r{1}", x1.Message, x1.StackTrace, DateTime.Now);
            
            try
            {
                LogError(x1);
            }
            catch (Exception x)
            { //ignore
            }

            string msg = x1.Message;

            if (x1.InnerException != null)
            {
                msg += Environment.NewLine + Environment.NewLine + "[" + x1.InnerException.Message + "]";

                //2011-01-21 ugly hack
                //When Inner Exception is concurrency error, its an AtriumException and the wizard ConcurrencyException handler doesn't handle it and show friendly message
                // speak w/ CW re improving ugly hack
                if (x1.InnerException.Message.StartsWith("Concurrency error"))
                {
                    MessageBox.Show(Form.ActiveForm,String.Format("Another user has modified this file while you were attempting to perform this step.\n\nUnfortunately, {0} is unable to save your changes at this time. Once you click OK, {0} will display another error message, and, when clicking OK, the New Activity Wizard will close and the data on the file will be reloaded.\n\n{0} will also automatically create a suspended activity for your entry, purely for the purposes of recovering your document, if need be.\n\nYou will not be able to resume this suspended activity.", Properties.Resources.AppName), "File modified by another user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (x1.GetType() == typeof(LMException))
            {
                MessageBox.Show(Form.ActiveForm, msg, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (x1.GetType() == typeof(atLogic.AtriumException))
            {
                MessageBox.Show(Form.ActiveForm, msg, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (x1.GetType() == typeof(atLogic.UpdateFailedException))
            {
                MessageBox.Show(Form.ActiveForm, msg, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                //Microsoft.SqlServer.MessageBox.ExceptionMessageBox emb = new Microsoft.SqlServer.MessageBox.ExceptionMessageBox(x1);
                //emb.Caption = Application.ProductName;
                //emb.Symbol = Microsoft.SqlServer.MessageBox.ExceptionMessageBoxSymbol.Error;
                //emb.Show(null);
                MessageBox.Show(Form.ActiveForm, msg, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LogError(Exception x1)
        {
            //if (x1.InnerException != null)
            //    LogError(x1.InnerException);
            //AtMng.LogEvent("Error", Environment.UserName, AtMng.OfficerLoggedOn.UserName, AtMng.WorkingAsOfficer.UserName, x1.GetType().ToString(), x1.Source, x1.Message, x1.StackTrace);
            AtMng.LogError(x1);
        }

        class controlCacheRO
        {
            public bool Readonly {get; set;}
            public Color BackColor { get; set; }
        }

        private static controlCacheRO newCCRO(bool readOnly, Color backColor)
        {
            controlCacheRO ccRO = new controlCacheRO();
            ccRO.Readonly = readOnly;
            ccRO.BackColor = backColor;

            return ccRO;
        }

        public static void EnableControls(BindingSource bs, bool enable)
        {
            //foreach (Binding b in bs.CurrencyManager.Bindings)
            //{
            //    b.Control.Enabled = enable;
            //}
            //return;
            foreach (Binding b in bs.CurrencyManager.Bindings)
            {
                if (HasProperty(b.Control, "ReadOnly"))
                {
                    

                    if (b.Control.Enabled)
                    {
                        var property = b.Control.GetType().GetProperty("ReadOnly");
                        if (b.Control.Tag == null || b.Control.Tag == System.DBNull.Value || b.Control.Tag.ToString() == "")
                        {
                            //cache read-noly setting
                            //b.Control.Tag = property.GetValue(b.Control, null);
                            b.Control.Tag = newCCRO((bool)property.GetValue(b.Control, null), b.Control.BackColor);
                        }
                        //if(!enable)
                        //{
                        //    //cahce current read-only setting
                        //    //b.Control.Tag = property.GetValue(b.Control, null);
                        //    b.Control.Tag = newCCRO((bool)property.GetValue(b.Control, null), b.Control.BackColor);
                        //}

                        if (enable)
                        {
                            controlCacheRO ccro = (controlCacheRO)b.Control.Tag;
                            //property.SetValue(b.Control,(bool) b.Control.Tag, null);
                            property.SetValue(b.Control, ccro.Readonly, null);
                            b.Control.BackColor = ccro.BackColor;
                        }
                        else
                        {
                            property.SetValue(b.Control, true, null);
                            if (HasProperty(b.Control, "BackColor"))
                                b.Control.BackColor = SystemColors.Control;

                            //nasty ucdocview workaround
                            if (b.Control.Name == "tbSubjectMail" || b.Control.Name=="calEfDateMail")
                                b.Control.BackColor = SystemColors.Window;
                        }
                        
                    }
                }
                else
                {
                    b.Control.Enabled = enable;
                    //if (enable)
                    //{
                    //    if (b.Control.Tag != null)
                    //        b.Control.Enabled = (bool)b.Control.Tag;
                    //    else
                    //        b.Control.Enabled = enable;
                    //}
                    //else
                    //{
                    //    b.Control.Tag = b.Control.Enabled;
                    //    b.Control.Enabled = enable;
                    //}
                }
            }
        }
        public static bool HasProperty( Control objectToCheck, string propertyName)
        {
            try
            {
                var type = objectToCheck.GetType();
                return type.GetProperty(propertyName) != null;
            }
            catch (Exception x )
            {
                // ambiguous means there is more than one result,
                // which means: a method with that name does exist
                return false;
            }
        } 
        public static void TextBoxTextCounter(object sender, Janus.Windows.GridEX.EditControls.NumericEditBox tbCounter, int maxChar)
        {
            TextBox tbText = (TextBox)sender;
            //if (tbText.Text.Length >= maxChar)
            //    tbText.Text = tbText.Text.Substring(0, maxChar);
            int ReverseCounter = maxChar - tbText.Text.Length;
            tbCounter.Text = ReverseCounter.ToString();
        }

        public static void TextBoxTextCounter(Janus.Windows.GridEX.EditControls.EditBox eb, Janus.Windows.GridEX.EditControls.NumericEditBox tbCounter, int maxChar)
        {
            int ReverseCounter = maxChar - eb.Text.Length;
            tbCounter.Text = ReverseCounter.ToString();

            if (ReverseCounter < 0)
            {
                tbCounter.BackColor = Color.Yellow;
                tbCounter.ForeColor = Color.Red;
            }
            else
            {
                tbCounter.BackColor = SystemColors.ControlLight;
                tbCounter.ForeColor = SystemColors.ControlDark;
            }
        }

        public static void TodaysDateShortcutKey(object sender, KeyEventArgs e)
        {
            try
            {
                Janus.Windows.CalendarCombo.CalendarCombo cb = (Janus.Windows.CalendarCombo.CalendarCombo)sender;
                if (e.Control && e.KeyCode == Keys.T)
                {
                    cb.Value = DateTime.Today;
                    cb.Text = cb.Value.ToString();
                }
            }
            catch (Exception x)
            {
                HandleUIException(x);
            }
        }

        public static void TodaysDateShortcutKeyGridEx(object sender, KeyEventArgs e)
        {
            try
            {
                Janus.Windows.GridEX.GridEX grd = (Janus.Windows.GridEX.GridEX)sender;
                if (grd.CurrentColumn != null && grd.CurrentColumn.EditType == Janus.Windows.GridEX.EditType.CalendarCombo && e.Control && e.KeyCode == Keys.T)
                    grd.CurrentRow.Cells[grd.CurrentColumn].Value = DateTime.Today;
            }
            catch (Exception x)
            {
                HandleUIException(x);
            }
        }

        public static bool startsWithVowel(string value)
        {
            if ("aeiouAEIOU".IndexOf(value.Substring(0, 1))>=0)
            {
                return true;
            }
            return false;
        }

        public static void RtbClearFormat(RichTextBox rtb)
        {
            Font stylefont = new Font(rtb.Font, FontStyle.Regular);
            rtb.SelectAll();
            rtb.SelectionFont = stylefont;
            rtb.Focus();
        }

        public static void RtbFormat(RichTextBox rtb, FontStyle fntStyle)
        {
            bool isBold = rtb.SelectionFont.Bold;
            bool isItalic = rtb.SelectionFont.Italic;
            bool isUnderline = rtb.SelectionFont.Underline;

            System.Drawing.FontStyle newFontStyle = FontStyle.Regular;

            if (fntStyle == FontStyle.Bold)
                isBold = !rtb.SelectionFont.Bold;
            if (fntStyle == FontStyle.Italic)
                isItalic = !rtb.SelectionFont.Italic;
            if (fntStyle == FontStyle.Underline)
                isUnderline = !rtb.SelectionFont.Underline;

            if (isBold & isItalic & isUnderline)
                newFontStyle = FontStyle.Bold | FontStyle.Italic | FontStyle.Underline;
            if (isBold & !isItalic & isUnderline)
                newFontStyle = FontStyle.Bold | FontStyle.Underline;
            if (isBold & isItalic & !isUnderline)
                newFontStyle = FontStyle.Bold | FontStyle.Italic;
            if (isBold & !isItalic & !isUnderline)
                newFontStyle = FontStyle.Bold;
            if (!isBold & isItalic & isUnderline)
                newFontStyle = FontStyle.Italic | FontStyle.Underline;
            if (!isBold & !isItalic & isUnderline)
                newFontStyle = FontStyle.Underline;
            if (!isBold & isItalic & !isUnderline)
                newFontStyle = FontStyle.Italic;
            if (!isBold & !isItalic & !isUnderline)
                newFontStyle = FontStyle.Regular;

            Font stylefont = new Font(rtb.SelectionFont, newFontStyle);
            rtb.SelectionFont = stylefont;
            rtb.Focus();
        }

        public static void CannotEditAppointment()
        {
            MessageBox.Show(Properties.Resources.UICannotEditAppointment, Properties.Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void ConfirmCannotDeleteLastIssue()
        {
            MessageBox.Show(Properties.Resources.UICannotDeleteLastIssue, Properties.Resources.UICannotDeleteLastIssueCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void NoAppealGroundSelected()
        {
            MessageBox.Show(Properties.Resources.UINoAppealGroundSelected, Properties.Resources.UINoAppealGroundSelectedCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool ConfirmDelete()
        {
            if (MessageBox.Show(Properties.Resources.UIConfirmDelete, Properties.Resources.UIConfirmDeleteCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                return true;

            return false;
        }
        public static bool ConfirmDeleteReminders()
        {
            if (MessageBox.Show(Properties.Resources.UIConfirmDeleteReminders, Properties.Resources.UIConfirmDeleteRemindersCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                return true;

            return false;
        }


        public static bool ConfirmDelete(string message)
        {
            if (MessageBox.Show(message, Properties.Resources.UIConfirmDeleteCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                return true;

            return false;
        }

        public static bool ConfirmDelete(string message, string caption)
        {
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                return true;

            return false;
        }

        public static void EnableCommandBarCommand(Janus.Windows.UI.CommandBars.UICommand cmd, bool enable)
        {
            if (enable)
                cmd.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                cmd.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        }

        public static void Cancel(BindingSource bs)
        {
            bs.CancelEdit();
            if (bs.Current != null)
            {
                DataRow dr = ((DataRowView)bs.Current).Row;
                dr.CancelEdit();
                dr.RejectChanges();
                dr.ClearErrors();
            }
        }

        public static void Cancel(BindingSource bs, DataTable dt)
        {
            bs.CancelEdit();
            if (dt.HasErrors)
            {
                foreach (DataRow dr in dt.GetErrors())
                {
                    dr.ClearErrors();
                }
            }
            dt.RejectChanges();
        }

        public static void Cancel(DataSet ds)
        {
            if (ds.HasErrors)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    if (dt.HasErrors)
                    {
                        foreach (DataRow dr in dt.GetErrors())
                        {
                            dr.ClearErrors();
                        }
                    }
                }
            }
            ds.RejectChanges();
        }

        public static int AddDDFieldAsActivityFieldRow(appDB.ddFieldRow ddfr, ActivityConfig.ACSeriesRow Acs, string objectAlias, string tableName, short StepNum)
        {
            lmDatasets.ActivityConfig.ActivityFieldRow afr = (lmDatasets.ActivityConfig.ActivityFieldRow)atmng.acMng.GetActivityField().Add(Acs);
            afr.TaskType = "F";
            afr.TaskName = "Related Field";
            afr.ObjectName = tableName;
            afr.ObjectAlias = objectAlias;
            if (StepNum == 100 || StepNum == -10)
                afr.Step = 0;
            else
                afr.Step = StepNum;

            if (!ddfr.IsNull("FieldName"))
                afr.FieldName = ddfr.FieldName;
            if (!ddfr.IsNull("LeftEng"))
                afr.LabelEng = ddfr.LeftEng;
            if (!ddfr.IsNull("LeftFre"))
                afr.LabelFre = ddfr.LeftFre;
            if (!ddfr.IsNull("FieldType"))
                afr.FieldType = ddfr.FieldType;
            if (!ddfr.IsNull("Lookup"))
                afr.LookUp = ddfr.Lookup;
            if (!ddfr.IsNull("DefaultSystemValue"))
                afr.DefaultSystemValue = ddfr.DefaultSystemValue;
            if (!ddfr.IsNull("InputMask"))
                afr.Mask = ddfr.InputMask;
            if (!ddfr.IsNull("HelpEng"))
                afr.HelpE = ddfr.HelpEng;
            if (!ddfr.IsNull("HelpFre"))
                afr.HelpF = ddfr.HelpFre;

            return afr.ActivityFieldID;
        }

        //public static void AddDDFieldsAsActivityFieldRows(string TableName, int InstanceNum, lmDatasets.ActivityConfig.ACSeriesRow acs, atriumBE.atriumManager atmng)
        //{
        //    lmDatasets.ActivityConfig.ActivityFieldRow newRecAFR = (lmDatasets.ActivityConfig.ActivityFieldRow)atmng.acMng.GetActivityField().Add(acs);
        //    newRecAFR.TaskType = "N";
        //    newRecAFR.Instance = InstanceNum;
        //    newRecAFR.TaskName = "New Record";
        //    newRecAFR.ObjectName = TableName;
        //    newRecAFR.FieldName = "New Record";
        //    newRecAFR.Step = -10;

        //    foreach (lmDatasets.appDB.ddFieldRow ddfr in atmng.DB.ddField.Select("TableName='" + TableName + "' and AllowInRelatedFields=1", "FieldName"))
        //    {
        //        lmDatasets.ActivityConfig.ActivityFieldRow newFieldAFR = (lmDatasets.ActivityConfig.ActivityFieldRow)atmng.acMng.GetActivityField().Add(acs);

        //        //if (TableName == "Document" || TableName == "Recipient" || TableName == "DocContent")
        //        //    newFieldAFR.TaskType = "R";
        //        //else if (TableName == "ActivityTime")
        //        //    newFieldAFR.TaskType = "T";
        //        //else
        //        newFieldAFR.TaskType = "F";

        //        newFieldAFR.Instance = InstanceNum;
        //        newFieldAFR.ObjectName = TableName;
        //        if (!ddfr.IsNull("FieldName"))
        //            newFieldAFR.FieldName = ddfr.FieldName;
        //        if (!ddfr.IsNull("LeftEng"))
        //            newFieldAFR.LabelEng = ddfr.LeftEng;
        //        if (!ddfr.IsNull("LeftFre"))
        //            newFieldAFR.LabelFre = ddfr.LeftFre;
        //        if (!ddfr.IsNull("FieldType"))
        //            newFieldAFR.FieldType = ddfr.FieldType;
        //        if (!ddfr.IsNull("Lookup"))
        //            newFieldAFR.LookUp = ddfr.Lookup;
        //        if (!ddfr.IsNull("DefaultSystemValue"))
        //            newFieldAFR.DefaultSystemValue = ddfr.DefaultSystemValue;
        //        if (!ddfr.IsNull("InputMask"))
        //            newFieldAFR.Mask = ddfr.InputMask;
        //        if (!ddfr.IsNull("HelpEng"))
        //            newFieldAFR.HelpE = ddfr.HelpEng;
        //        if (!ddfr.IsNull("HelpFre"))
        //            newFieldAFR.HelpF = ddfr.HelpFre;
        //    }
        //}

        //public static void AddTableColumnsAsActivityFieldRows(DataTable dt, int InstanceNum, lmDatasets.ActivityConfig.ACSeriesRow acs, atriumBE.atriumManager atmng)
        //{
        //    lmDatasets.ActivityConfig.ActivityFieldRow afrNewRec = (lmDatasets.ActivityConfig.ActivityFieldRow)atmng.acMng.GetActivityField().Add(acs);
        //    afrNewRec.TaskType = "N";
        //    afrNewRec.Instance = InstanceNum;
        //    afrNewRec.TaskName = "New Record";
        //    afrNewRec.ObjectName = dt.TableName;
        //    afrNewRec.FieldName = "New Record";
        //    afrNewRec.Step = -10;

        //    foreach (DataColumn dc in dt.Columns)
        //    {
        //        if (dc.ColumnName != "entryUser" && dc.ColumnName != "entryDate" && dc.ColumnName != "updateUser" && dc.ColumnName != "updateDate" && dc.ColumnName != "ts")
        //        {
        //            lmDatasets.ActivityConfig.ActivityFieldRow afr = (lmDatasets.ActivityConfig.ActivityFieldRow)atmng.acMng.GetActivityField().Add(acs);
        //            //if (dt.TableName == "Document" || dt.TableName == "Recipient" || dt.TableName == "DocContent")
        //            //    afr.TaskType = "R";
        //            //else if (dt.TableName == "ActivityTime")
        //            //    afr.TaskType = "T";
        //            //else
        //            afr.TaskType = "F";
        //            afr.Instance = InstanceNum;
        //            afr.ObjectName = dt.TableName;
        //            afr.FieldName = dc.ColumnName;
        //            afr.LabelEng = dc.ColumnName;
        //            afr.LabelFre = dc.ColumnName;
        //        }
        //    }
        //}

        public static void UncheckItemsInCheckedListBox(CheckedListBox clb)
        {
            foreach (int chckIndex in clb.CheckedIndices)
            {
                clb.SetItemChecked(chckIndex, false);
            }
        }
        public static void ImportConvertMail(fMain main, atriumBE.FileManager ActFM, int acid, int docId)
        {
            fFile ffns = main.OpenFile(ActFM.CurrentFile.FileId);
            try
            {
                ffns.ReadOnly = true;
                fACWizard facwr = new fACWizard(ActFM, atriumBE.ACEngine.Step.PickActivity, acid, docId, "CONVERT");
                ffns.HookupWizClose(facwr);
                ffns.fileToc.LoadTOC();
                if (facwr.ShowDialog() != DialogResult.OK)
                {
                    facwr.Close();
                    throw new LMException("Import cancelled.");
                }
                facwr.Close();
            }
            catch (Exception x1)
            {
                ffns.ReadOnly = false;
                ActFM.KillACEngine();
                throw x1;
            }
        }
        public static void DoConvertMenu(int fileId, Janus.Windows.UI.CommandBars.UICommand cmd, lmDatasets.ActivityConfig.ACSeriesRow acSeriesRow, bool clear)
        {
            DoConvertMenu(fileId, cmd, acSeriesRow, clear, false);
        }
        public static void DoConvertMenu(int fileId, Janus.Windows.UI.CommandBars.UICommand cmd, lmDatasets.ActivityConfig.ACSeriesRow acSeriesRow, bool clear, bool onlyContainers)
        {
            //clear current items
            if (clear)
                cmd.Commands.Clear();

            //add new items
            lmDatasets.ActivityConfig.ACSeriesRow acsr = acSeriesRow;

            foreach (lmDatasets.ActivityConfig.ACConvertRow acr in acsr.GetACConvertRowsByACSeries_ACConvert())
            {
                atriumBE.FileManager fm = AtMng.GetFile(fileId);

                lmDatasets.ActivityConfig.ACSeriesRow acsrC = acr.ACSeriesRowByACSeries_ACConvert1;
                atriumBE.FileManager fmc = fm;
                if (!acsrC.SeriesRow.IsContainerFileIdNull())
                    fmc = AtMng.GetFile(acsrC.SeriesRow.ContainerFileId);

                bool add = !onlyContainers;
                if (onlyContainers)
                    add = !acsrC.SeriesRow.IsContainerFileIdNull();

                if (add & atriumBE.Workflow.Allowed(acsrC, AtMng, fmc))
                {
                    Janus.Windows.UI.CommandBars.UICommand newCmd;
                    //add new items
                    string key = "tsConvertAC" + acsrC.ACSeriesId.ToString();
                    if (cmd.CommandManager.Commands.Contains(key))
                    {
                        newCmd = cmd.CommandManager.Commands[key];
                    }
                    else
                    {

                        newCmd = new Janus.Windows.UI.CommandBars.UICommand();
                        newCmd.Key = key;
                    }

                    newCmd.Text = AtMng.acMng.GetACSeries().GetNodeText(acsrC, (atriumBE.StepType)acsrC.StepType, false);
                    newCmd.Tag = acsrC;
                    newCmd.Image = Properties.Resources.act;
                    newCmd.ShowInCustomizeDialog = false;
                    cmd.Commands.Add(newCmd);
                }
            }
        }

        public static void DoRevertMenu(atriumBE.atriumManager atmng, Janus.Windows.UI.CommandBars.UICommand cmd, lmDatasets.ActivityConfig.ACSeriesRow acSeriesRow)
        {
            //clear current items
            cmd.Commands.Clear();
            cmd.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            //add new items
            lmDatasets.ActivityConfig.ACSeriesRow acsr = acSeriesRow;
            foreach (lmDatasets.ActivityConfig.ACConvertRow acr in acsr.GetACConvertRowsByACSeries_ACConvert1())
            {
                lmDatasets.ActivityConfig.ACSeriesRow acsrC = acr.ACSeriesRowByACSeries_ACConvert;
                if (!acsrC.Obsolete)
                {
                    Janus.Windows.UI.CommandBars.UICommand newCmd = new Janus.Windows.UI.CommandBars.UICommand();
                    newCmd.Key = "tsRevertAC" + acsrC.ACSeriesId.ToString();
                    newCmd.Text = atmng.acMng.GetACSeries().GetNodeText(acsrC, (atriumBE.StepType)acsrC.StepType, false);
                    newCmd.Tag = acsrC;
                    cmd.Commands.Add(newCmd);

                    cmd.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
            }
        }


        public static void DoNewBFMenu(atriumBE.FileManager FM, Janus.Windows.UI.CommandBars.UIContextMenu contextMenu)
        {
            contextMenu.Commands.Clear();

            atriumDB.FileContactRow[] fileContacts = (atriumDB.FileContactRow[])FM.DB.FileContact.Select();
            foreach(atriumDB.FileContactRow fcr in fileContacts)
            {
                if (FM.GetFileContact().IsAnAtriumUser(fcr))
                {
                    Janus.Windows.UI.CommandBars.UICommand fCmd = new Janus.Windows.UI.CommandBars.UICommand();
                    fCmd.Key = "tsNewRoleBF" + fcr.ContactType;
                    string column = FM.AtMng.Translate(fcr.Table.Columns["ContactTypeDescEng"].ColumnName);
                    fCmd.Text = Properties.Resources.NewBFFileBasedRole + " - " + fcr[column].ToString() + " (" + fcr.ContactType + ")";
                    fCmd.Tag = fcr.ContactType;
                    fCmd.Image = Properties.Resources.roles;
                    contextMenu.Commands.Add(fCmd);
                }
            }

            if (contextMenu.Commands.Count > 0)
                contextMenu.Commands.AddSeparator();
            
            Janus.Windows.UI.CommandBars.UICommand newCmd = new Janus.Windows.UI.CommandBars.UICommand();
            newCmd.Key = "tsNewDirectBF";
            newCmd.Text = Properties.Resources.NewBFDirect + " - " + FM.AtMng.WorkingAsOfficer.DisplayName + " (" + FM.AtMng.WorkingAsOfficer.OfficerCode + ")";
            newCmd.Image = Properties.Resources.officer;
            newCmd.Tag = FM.AtMng.WorkingAsOfficer.OfficerId;
            contextMenu.Commands.Add(newCmd);
        }

        public static void GroupRowVerify(object sender, EventArgs e)
        {
            Janus.Windows.GridEX.GridEX grd = (Janus.Windows.GridEX.GridEX)sender;
            if (grd.CurrentRow.RowType == Janus.Windows.GridEX.RowType.GroupHeader)
                grd.Row++;
        }

        public static string AppPath
        {
            get
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string BuildContains(SearchContainsOptions containsType, string fldValue)
        {
            string tvalue = "";
            string trimFldvalue = fldValue.Trim();
            string sOp = "";
            char splitter = ' ';
            int i;
            switch (containsType)
            {
                case SearchContainsOptions.ExactMatch:
                    tvalue = " \" " + trimFldvalue + " \" ";
                    break;

                case SearchContainsOptions.AllOfTheTerms:
                    Array vc = trimFldvalue.Split(splitter);

                    for (i = 0; i < vc.Length; i++)
                    {
                        tvalue += sOp + vc.GetValue(i);
                        sOp = " AND ";
                    }
                    break;

                case SearchContainsOptions.AtLeastOneOfTheTerms:
                    Array vc2 = trimFldvalue.Split(splitter);

                    for (i = 0; i < vc2.Length; i++)
                    {
                        tvalue += sOp + vc2.GetValue(i);
                        sOp = " OR ";
                    }
                    break;
                case SearchContainsOptions.BooleanSearch:
                    tvalue = trimFldvalue;
                    break;
            }
            return tvalue;
        }

        public static void LaunchNativeN(string checkOutFile, UserControls.ucDocView ucdoc, string ucdocMessage)
        {

            if (ucdoc != null && checkOutFile.EndsWith("xls"))
            {
                ucdoc.HideContent("The spreadsheet has been closed from this view to allow proper display in its external application (i.e. MS Excel)");
            }
            System.Diagnostics.Process procx = new System.Diagnostics.Process();
            procx.StartInfo.FileName = checkOutFile;
            foreach (string v in procx.StartInfo.Verbs)
            {
                if (v.ToLower() == "open")
                    procx.StartInfo.Verb = v;
            }
            try
            {
                procx.Start();
            }
            catch (Win32Exception winX)
            {
                throw new LMException("Can't open " + checkOutFile, winX);
            }
        }

        public static void LaunchNative(string checkOutFile, UserControls.ucDoc ucdoc, string ucdocMessage)
        {
            if (ucdoc != null && checkOutFile.EndsWith("xls"))
            {
                ucdoc.NoDoc("The spreadsheet has been closed from this view to allow proper display in its external application (i.e. MS Excel)");
                //ucdoc.AllowActionToolbar = true;
            }
            System.Diagnostics.Process procx = new System.Diagnostics.Process();
            procx.StartInfo.FileName = checkOutFile;
            foreach (string v in procx.StartInfo.Verbs)
            {
                if (v.ToLower() == "open")
                    procx.StartInfo.Verb = v;
            }

            try
            {
                procx.Start();
            }
            catch (Win32Exception winX)
            {
                // UIHelper.HandleUIException( winX);
                throw new LMException("Can't open " + checkOutFile, winX);
            }
        }

        public static void MoveAcBF(int toFileid, List<DataRow> tomove)
        {
            //get fm for target file
            atriumBE.FileManager fmTo = AtMng.GetFile(toFileid);
            fmTo.InitActivityProcess();

            //we need to group these by fileid and underlying activityid
            Dictionary<int, string> acfile = new Dictionary<int, string>();
            foreach (atriumDB.ActivityBFRow abr in tomove)
            {
                atriumDB.ActivityRow ar = fmTo.GetActivity().Load(abr.ActivityId);

                if (!acfile.ContainsKey(abr.FileId))
                {
                    acfile.Add(abr.FileId, abr.ActivityId.ToString());
                }
                else
                {
                    acfile[abr.FileId] += "," + abr.ActivityId.ToString();
                }
            }
            foreach (int fileid in acfile.Keys)
            {

                atriumDB.ActivityRow[] ars = (atriumDB.ActivityRow[])fmTo.DB.Activity.Select("ActivityId in(" + acfile[fileid] + ")");

                fmTo.GetActivity().Move(ars, fmTo.CurrentFile.FileId);

                //save
                try
                {
                    atLogic.BusinessProcess bp = fmTo.GetBP();
                    fmTo.GetActivity().Update(bp);
                    bp.Update();


                }
                catch (Exception x)
                {

                    fmTo.DB.RejectChanges();
                    UIHelper.HandleUIException(x);
                }
            }

        }

        public static void MoveFile(atriumBE.FileManager thisfm, int targetFileId)
        {
            //check to see if target file is autonumber
            bool auto = thisfm.AtMng.GetFile(targetFileId).CurrentFile.FileMetaTypeRow.SubFileAutoNumber;
            string newNumber = null;
            if (!auto)
            {
                //prompt for new filenumber
                fNewFileNum f = new fNewFileNum();
                f.SetDefaultNumber(thisfm.CurrentFile.FileNumber);
                f.Text = "Confirm file number for " + thisfm.CurrentFile.Name;
                if (f.ShowDialog() == DialogResult.OK)
                    newNumber = f.NewNumber();
                else
                    throw new LMException("User cancelled move operation");
            }
            thisfm.EFile.Move(thisfm.CurrentFile, targetFileId, auto, newNumber);
        }

        public static void MoveFileShortcut(atriumBE.FileManager thisfm, int efileXrefId, int targetFileId)
        {

            lmDatasets.atriumDB.FileXRefRow fxr = thisfm.DB.FileXRef.FindById(efileXrefId);
            if (fxr == null)
                fxr = thisfm.GetFileXRef().Load(efileXrefId);
            fxr.FileId = targetFileId;
            if (fxr.HasErrors)
            {
                string msg = fxr.GetColumnError("FileId");
                fxr.RejectChanges();
                throw new LMException(msg);
            }

        }

        public static void FormatDateGridEXColumn(string column, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            if (e.Row.DataRow != null)
            {
                if (e.Row.Cells[column].Value != null && e.Row.Cells[column].Value.ToString().Trim() != string.Empty)
                {
                    DateTime tm = (DateTime)e.Row.Cells[column].Value;
                    e.Row.Cells[column].Text = UIHelper.FormatDateYYYYMMDD(tm);
                }
            }
        }

        public static string FormatDateYYYYMMDD(DateTime date)
        {
            string mnth;
            string day;

            if (date.Month < 10)
                mnth = "0" + date.Month.ToString();
            else
                mnth = date.Month.ToString();

            if (date.Day < 10)
                day = "0" + date.Day.ToString();
            else
                day = date.Day.ToString();

            return date.Year + "/" + mnth + "/" + day;

        }

        public static void GridExPrintPreview(Janus.Windows.GridEX.GridEXPrintDocument grdPrintDoc)
        {
            grdPrintDoc.PrepareDocument();
            grdPrintDoc.PageFooterRight = DateTime.Today.ToLongDateString();
            PrintPreviewDialog ppDialog = new PrintPreviewDialog();
            ppDialog.Document = grdPrintDoc;
            ppDialog.Document.DefaultPageSettings.Landscape = true;
            ppDialog.ShowDialog();
        }

        public static void GridExPrintDocument(Janus.Windows.GridEX.GridEXPrintDocument grdPrintDoc)
        {
            grdPrintDoc.PrepareDocument();
            grdPrintDoc.PageFooterRight = DateTime.Today.ToLongDateString();
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = grdPrintDoc;
            printDialog.Document.DefaultPageSettings.Landscape = true;
            printDialog.AllowCurrentPage = true;
            printDialog.AllowPrintToFile = true;
            printDialog.AllowSelection = true;
            printDialog.AllowSomePages = true;
            printDialog.ShowNetwork = true;
            printDialog.ShowHelp = true;
            printDialog.UseEXDialog = true;

            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();
        }

        public static void GridToggleSelectMode(Janus.Windows.GridEX.GridEX grid)
        {
            //only toggle grids that are capable of it
            if (grid.RootTable.Columns[0].ShowRowSelector == true)
            {
                if (atmng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.GridSelectionMode, atriumBE.OfficerPrefsBE.vGridSelectionModeMulti) == atriumBE.OfficerPrefsBE.vGridSelectionModeMulti) // GetSetting("SelectionMode","multi") == "multi"
                {

                    grid.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
                    grid.RootTable.Columns[0].Visible = false;
                    grid.UseGroupRowSelector = false;
                }
                else
                {
                    grid.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                    grid.RootTable.Columns[0].Visible = true;
                    grid.UseGroupRowSelector = true;
                }
            }
        }

        public static List<DataRow> GridGetSelectedData(Janus.Windows.GridEX.GridEX grid)
        {
            List<DataRow> rows = new List<DataRow>();
            if (grid.SelectionMode != Janus.Windows.GridEX.SelectionMode.SingleSelection)
            {
                foreach (Janus.Windows.GridEX.GridEXSelectedItem gsi in grid.SelectedItems)
                {
                    if (gsi.RowType == Janus.Windows.GridEX.RowType.Record)
                        rows.Add(((DataRowView)gsi.GetRow().DataRow).Row);
                }

            }
            else
            {
                foreach (Janus.Windows.GridEX.GridEXRow gsi in grid.GetCheckedRows())
                {
                    rows.Add(((DataRowView)gsi.DataRow).Row);
                }
            }
            if (rows.Count == 0)
                throw new LMException("No items are selected");
            //    rows.Add(((DataRowView)grid.CurrentRow.DataRow).Row);

            return rows;
        }

        public static void SetDataTableAsGridDataSource(Janus.Windows.GridEX.GridEX grid, DataTable dataTable)
        {
            grid.DataSource = dataTable;
            int i = 0;
            foreach (DataColumn dc in dataTable.Columns)
            {
                grid.RootTable.Columns[i].DataMember = dataTable.Columns[i].ColumnName;
                i++;
            }
        }

        public static int GridGetSelectedCount(Janus.Windows.GridEX.GridEX grid)
        {
            if (grid.SelectionMode != Janus.Windows.GridEX.SelectionMode.SingleSelection)
            {
                int count = 0;
                foreach (Janus.Windows.GridEX.GridEXSelectedItem gsi in grid.SelectedItems)
                {
                    if (gsi.RowType == Janus.Windows.GridEX.RowType.Record)
                        count++;
                }

                return count;
            }
            else
            {
                return grid.GetCheckedRows().Length;
            }
        }

        public static void ToggleGroupBoxWarning(Janus.Windows.EditControls.UIGroupBox gb, string GroupboxText, bool FormatForEmphasis)
        {
            if (GroupboxText != null)
                gb.Text = GroupboxText;

            if (FormatForEmphasis)
            {
                gb.Image = Properties.Resources.warning_16x16;
                gb.BackColor = Color.LemonChiffon;
                gb.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            }
            else
            {
                gb.Image = null;
                gb.BackColor = Color.Transparent;
                gb.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Standard;
            }

        }

        public static void ToggleUIButton(Janus.Windows.EditControls.UIButton uibtn, bool FormatForEmphasis)
        {
            if (FormatForEmphasis)
            {
                uibtn.BackColor = Color.Gold;
            }
            else
            {
                uibtn.BackColor = Color.Empty;
            }
        }

        public static string ArgbColorToHtml(int ArgbColor)
        {
            if (System.Drawing.Color.Transparent == Color.FromArgb(ArgbColor))
                return "Transparent";
            return string.Concat("#", (ArgbColor & 0x00FFFFFF).ToString("X6"));
        }

        public static void AcSeriesIconBuild(Janus.Windows.EditControls.UIComboBox comboBox)
        {
            System.Windows.Forms.ImageList imgList = new ImageList();
            imgList.Images.Add(Properties.Resources.folder);
            imgList.Images.Add(Properties.Resources.msgS);
            imgList.Images.Add(Properties.Resources.clock);
            imgList.Images.Add(Properties.Resources.form);
            imgList.Images.Add(Properties.Resources.documentscreen);
            imgList.Images.Add(Properties.Resources.FileContainer);
            imgList.Images.Add(Properties.Resources.Memo_icon);
            imgList.Images.Add(Properties.Resources.office_building);
            imgList.Images.Add(Properties.Resources.opinion);
            imgList.Images.Add(Properties.Resources.ReviseDocument);
            imgList.Images.Add(Properties.Resources.FaxMachine);
            imgList.Images.Add(Properties.Resources.MailComposeNew);

            comboBox.ImageList = imgList;
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Folder", "folder", 0));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Enveloppe", "msgS", 1));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Timekeeping", "clock", 2));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Document", "form", 3));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Multiple Documents", "documentscreen", 4));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Container", "FileContainer", 5));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Memo", "Memo_icon", 6));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Office", "office_building", 7));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Opinion", "opinion", 8));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Revise Document", "ReviseDocument", 9));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Fax", "FaxMachine", 10));
            comboBox.Items.Add(new Janus.Windows.EditControls.UIComboBoxItem("Compose Email", "MailComposeNew", 11));
        }

        public static ImageList browseImgList()
        {
            ImageList imgList = new ImageList();
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.ImageSize = new Size(16, 16);
            imgList.Images.Add(Properties.Resources.folder); // index 0

            imgList.Images.Add(Properties.Resources.ContainerCube); // index 1
            imgList.Images.Add(Properties.Resources.FileContainer); // index 2
            imgList.Images.Add(Properties.Resources.filenodepng); // index 3
            imgList.Images.Add(Properties.Resources.whitefolder2); // index 4

            imgList.Images.Add(Properties.Resources.docShortcut); // index 5
            imgList.Images.Add(Properties.Resources.fileShortcut); // index 6

            imgList.Images.Add(Properties.Resources.fsA); // index 7
            imgList.Images.Add(Properties.Resources.fsC); // index 8
            imgList.Images.Add(Properties.Resources.fsM); // index 9
            imgList.Images.Add(Properties.Resources.fsO); // index 10
            imgList.Images.Add(Properties.Resources.fsP); // index 11

            imgList.Images.Add(Properties.Resources.XRefFile); // index 12

            imgList.Images.Add(Properties.Resources.mail5); // index 13
            imgList.Images.Add(Properties.Resources.allemail); // index 14
            imgList.Images.Add(Properties.Resources.BFListCalendar); // index 15
            imgList.Images.Add(Properties.Resources.checkbox); // index 16
            imgList.Images.Add(Properties.Resources.otkCalendar1); // index 17
            imgList.Images.Add(Properties.Resources.opinion); // index 18
            imgList.Images.Add(Properties.Resources.DocumentCheckOut); // index 19
            imgList.Images.Add(Properties.Resources.DraftDocumentPNG); // index 20
            imgList.Images.Add(Properties.Resources.clock3); // index 21
            imgList.Images.Add(Properties.Resources.sentItems); // index 22
            imgList.Images.Add(Properties.Resources.doc2); // index 23
            imgList.Images.Add(Properties.Resources.search); // index 24
            imgList.Images.Add(Properties.Resources.address_book); // index 25
            imgList.Images.Add(Properties.Resources.shortcut2); // index 26
            imgList.Images.Add(Properties.Resources.filedot); // index 27
            imgList.Images.Add(Properties.Resources.office); // index 28
            imgList.Images.Add(Properties.Resources.cube2); // index 29
            imgList.Images.Add(Properties.Resources.atrium16x16); // index 30
            imgList.Images.Add(Properties.Resources.FileStack); // index 31
            imgList.Images.Add(Properties.Resources.nodeauto); // index 32
            imgList.Images.Add(Properties.Resources.nodenotauto); // index 33
            imgList.Images.Add(Properties.Resources.priorityHigh1); // index 34
            imgList.Images.Add(Properties.Resources.priorityUrgent1); // index 35
            imgList.Images.Add(Properties.Resources.blank); // index 36

            return imgList;
        }

        public static string GetAcronymTimeZoneLabel()
        {
            if (atmng.AppMan.Language.ToUpper() == "FRE")
            {
                string tzv = "";
                switch (TimeZone.CurrentTimeZone.StandardName)
                {
                    case "Eastern Standard Time":   // case "HEURE NORMALE DE L'EST":
                        tzv = "HNE";
                        break;
                    case "Newfoundland Standard Time": // case "HEURE NORMALE DE TERRE-NEUVE":
                        tzv = "HNTN";
                        break;
                    case "Atlantic Standard Time": // case "HEURE NORMALE DE L'ATLANTIQUE":
                        tzv = "HNA";
                        break;
                    case "Central Standard Time"://case "HEURE NORMALE DU CENTRE":
                        tzv = "HNC";
                        break;
                    case "Mountain Standard Time": // case "HEURE NORMALE DES ROCHEUSES":
                        tzv = "HNR";
                        break;
                    case "Pacific Standard Time":// case "HEURE NORMALE DU PACIFIQUE":
                        tzv = "HNP";
                        break;
                    default:
                        tzv = TimeZoneInfo.Local.StandardName;
                        break;
                }

                return tzv;

            }
            else if (atmng.AppMan.Language.ToUpper() == "ENG")
            {
                string tzv = "";
                switch (TimeZone.CurrentTimeZone.StandardName)
                {
                    case "Eastern Standard Time":
                        tzv = "EST";
                        break;
                    case "Newfoundland Standard Time":
                        tzv = "NST";
                        break;
                    case "Atlantic Standard Time":
                        tzv = "AST";
                        break;
                    case "Central Standard Time":
                        tzv = "CST";
                        break;
                    case "Mountain Standard Time":
                        tzv = "MST";
                        break;
                    case "Pacific Standard Time":
                        tzv = "PST";
                        break;
                    default:
                        tzv = TimeZoneInfo.Local.StandardName;
                        break;
                }

                return tzv;

            }
            else
                return TimeZoneInfo.Local.StandardName;
        }

        public static string GetTimeZoneLabel()
        {
            if (atmng.AppMan.Language.ToUpper() == "ENG" && System.Globalization.CultureInfo.InstalledUICulture.Name == "fr-CA")
            {
                string tzv = "";
                switch (TimeZone.CurrentTimeZone.StandardName.ToUpper())
                {
                    case "HEURE NORMALE DE L'EST":
                        tzv = "Eastern Standard Time";
                        break;
                    case "HEURE NORMALE DE TERRE-NEUVE":
                        tzv = "Newfoundland Standard Time";
                        break;
                    case "HEURE NORMALE DE L'ATLANTIQUE":
                        tzv = "Atlantic Standard Time";
                        break;
                    case "HEURE NORMALE DU CENTRE":
                        tzv = "Central Standard Time";
                        break;
                    case "HEURE NORMALE DES ROCHEUSES":
                        tzv = "Mountain Standard Time";
                        break;
                    case "HEURE NORMALE DU PACIFIQUE":
                        tzv = "Pacific Standard Time";
                        break;
                    default:
                        tzv = TimeZoneInfo.Local.StandardName;
                        break;
                }

                return tzv;

            }
            else if (atmng.AppMan.Language.ToUpper() == "FRE" && System.Globalization.CultureInfo.InstalledUICulture.Name == "en-US")
            {
                string tzv = "";
                switch (TimeZone.CurrentTimeZone.StandardName)
                {
                    case "Eastern Standard Time":
                        tzv = "Heure Normale de l'Est";
                        break;
                    case "Newfoundland Standard Time":
                        tzv = "Heure Normale de Terre-Neuve";
                        break;
                    case "Atlantic Standard Time":
                        tzv = "Heure Normale de l'Atlantique";
                        break;
                    case "Central Standard Time":
                        tzv = "Heure Normale du Centre";
                        break;
                    case "Mountain Standard Time":
                        tzv = "Heure Normale des Rocheuses";
                        break;
                    case "Pacific Standard Time":
                        tzv = "Heure Normale du Pacifique";
                        break;
                    default:
                        tzv = TimeZoneInfo.Local.StandardName;
                        break;
                }

                return tzv;

            }
            else
                return TimeZoneInfo.Local.StandardName;
        }

        public static string GetSizeReadable(long i)
        {
            string sign = (i < 0 ? "-" : "");
            double readable = (i < 0 ? -i : i);
            string suffix;
            if (i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (double)(i >> 50);
            }
            else if (i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (double)(i >> 40);
            }
            else if (i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (double)(i >> 30);
            }
            else if (i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (double)(i >> 20);
            }
            else if (i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (double)(i >> 10);
            }
            else if (i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = (double)i;
            }
            else
            {
                return i.ToString(sign + "0 B"); // Byte
            }
            readable = readable / 1024;

            return sign + readable.ToString("0.### ") + suffix;
        }

        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
        }

        //2017-08-28
        //JLL: returns actual scaling factor
        public static float getScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

            return ScreenScalingFactor; // 1.25 = 125%
        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    public class Win32
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0;    // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1;    // 'Small icon
        public const uint SHGFI_USEFILEATTRIBUTES = 0x10;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x80;

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath,
                                    uint dwFileAttributes,
                                    ref SHFILEINFO psfi,
                                    uint cbSizeFileInfo,
                                    uint uFlags);

        // Import GetFocus() from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto,
           CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();

        public static Control GetFocusControl()
        {
            Control focusControl = null;
            IntPtr focusHandle = GetFocus();
            if (focusHandle != IntPtr.Zero)
                // returns null if handle is not to a .NET control
                focusControl = Control.FromHandle(focusHandle);
            return focusControl;
        }
    }

    public class FatalException : ApplicationException
    {
        public FatalException(string message, Exception x)
            : base(message, x)
        {
        }
    }

    public class RollbackException : ApplicationException
    {
        public RollbackException(string message, Exception x)
            : base(message, x)
        {
        }
    }

    public class LMException : atLogic.AtriumException
    {
        public LMException(string message)
            : base(message)
        {
        }
        public LMException(string message, Exception x)
            : base(message, x)
        {
        }
    }

    public enum SearchContainsOptions
    {
        ExactMatch,
        AllOfTheTerms,
        AtLeastOneOfTheTerms,
        BooleanSearch
    }
}
