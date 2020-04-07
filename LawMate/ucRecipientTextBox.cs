using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

 namespace LawMate
{
    public delegate void RecipientAddedToRecipientBoxHandler(object sender, ControlEventArgs e);
    public delegate void RecipientRemovedFromRecipientBoxHandler(object sender, ControlEventArgs e);


    public partial class ucRecipientTextBox : UserControl
    {
        public event RecipientAddedToRecipientBoxHandler RecipientAdded;
        public event RecipientRemovedFromRecipientBoxHandler RecipientRemoved;

        DataView dvRecip;
        atriumBE.DocManager dm;
        docDB.DocumentRow currentMsg;

        string myRecipType = "1";
        bool myReadOnly = false;
        System.Drawing.Color tbBackColor = System.Drawing.SystemColors.Window;


       

        bool allowMultiple = true;

        public bool AllowMultiple
        {
            get { return allowMultiple; }
            set { allowMultiple = value; }
        }
        Dictionary<int, docDB.RecipientRow> added = new Dictionary<int, docDB.RecipientRow>();

        public bool HasRecipients
        {
            get { return dvRecip.Count>0; }
        }

        bool usesNewDocViewer = false;
        public bool UsesNewDocViewer
        {
            get { return usesNewDocViewer; }
            set { usesNewDocViewer = value; }
        }

        public bool IsScrollVisible
        {
            get
            {
                if (flowLayoutPanelRecipient.VerticalScroll.Visible)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsReadOnly
        {
            // true = Read
            // false = Compose
            get { return myReadOnly; }
            set
            {
                myReadOnly = value;
                if (myReadOnly)
                {
                    tbBackColor = SystemColors.Control; //System.Drawing.Color.FromArgb(194, 212, 232);
                    flowLayoutPanelRecipient.BackColor = SystemColors.Control;  //System.Drawing.Color.FromArgb(194, 212, 232);
                    flowLayoutPanelRecipient.Padding = new Padding(0, 1, 0, 0);
                    if(!usesNewDocViewer) 
                        this.BorderStyle = BorderStyle.None;
                    if(flowLayoutPanelRecipient.Controls.Contains(tbNewRecipient))
                        flowLayoutPanelRecipient.Controls.Remove(tbNewRecipient);
                }
                else
                {
                    tbBackColor = (Color)System.Drawing.SystemColors.Window;
                    flowLayoutPanelRecipient.BackColor = System.Drawing.SystemColors.Window;
                    flowLayoutPanelRecipient.Padding = new Padding(2, 1, 10, 0);
                    if (!usesNewDocViewer) 
                        this.BorderStyle = BorderStyle.FixedSingle;
                    if (!flowLayoutPanelRecipient.Controls.Contains(tbNewRecipient))
                        flowLayoutPanelRecipient.Controls.Add(tbNewRecipient);
                    
                    
                }
                foreach(Janus.Windows.GridEX.EditControls.EditBox eb in flowLayoutPanelRecipient.Controls)
                {
                    ToggleRecipReadOnly(eb);
                }
                tbNewRecipient.BackColor = tbBackColor;
            }
        }

        public string RecipType
        {
            // 1 = TO
            // 2 = CC
            // 3 = BCC
            get { return myRecipType; }
            set { myRecipType = value; }
        }

        public ucRecipientTextBox()
        {
            InitializeComponent();
        }

        public void Init(atriumBE.DocManager _dm, docDB.DocumentRow doc)
        {
            dm = _dm;
            currentMsg = doc;
            //get autocomplete list for addresses
            AutoCompleteStringCollection aSend = new AutoCompleteStringCollection();
            DataTable dt = dm.AtMng.RecipientGetRecentSent();
            foreach (DataRow dr in dt.Rows)
            {
                aSend.Add(dr["Address"].ToString());
            }
            tbNewRecipient.AutoCompleteCustomSource = aSend;

            dvRecip = new DataView(doc.Table.DataSet.Tables["Recipient"], "docid=" + currentMsg.DocId.ToString() + " and Type='" + myRecipType + "'", "", DataViewRowState.CurrentRows);
            Reload();
            //if (myReadOnly)
            //    flowLayoutPanelRecipient.Controls.Remove(tbNewRecipient);
        }

        public void Reload()
        {
            flowLayoutPanelRecipient.Controls.Clear();
            flowLayoutPanelRecipient.Visible = false;
            foreach (DataRowView dvr in dvRecip)
            {
                CreateRecip((docDB.RecipientRow)dvr.Row);
            }
            
            //if (dvRecip.Count == 0)
            //    mbHasRecipients = false;
            //else
            //    mbHasRecipients = true;

            //if (!IsReadOnly)
            //{
            //    flowLayoutPanelRecipient.Controls.Add(tbNewRecipient);
            //}

            flowLayoutPanelRecipient.VerticalScroll.Value = 0;

            flowLayoutPanelRecipient.Visible = true;

            if (HasRecipients & !AllowMultiple)
                tbNewRecipient.Visible = false;
            if (!HasRecipients)
            {
                tbNewRecipient.Visible = true;
                if (!flowLayoutPanelRecipient.Controls.Contains(tbNewRecipient))
                    flowLayoutPanelRecipient.Controls.Add(tbNewRecipient);
            }
        }
    
        void CreateRecip(docDB.RecipientRow r)
        {
            if (r.Name == "")
                return;

            Janus.Windows.Common.SuperTipSettings jstSettings = new Janus.Windows.Common.SuperTipSettings();

            Janus.Windows.GridEX.EditControls.EditBox eb = new Janus.Windows.GridEX.EditControls.EditBox();
            eb.Name = r.RecipId.ToString();
            eb.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            eb.BackColor = tbBackColor;
            eb.ReadOnly = true;
            eb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            eb.Tag = r;
            eb.Text = r.Name;
            eb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            eb.TabStop = false;
            eb.MouseUp += tbNewRecipient_MouseUp;
            eb.ShortcutsEnabled = false;
            eb.ButtonClick += new EventHandler(eb_ButtonClick);
            if (!r.IsAddressNull())
            {
                jstSettings.Text = r.Address;
                janusSuperTip1.SetSuperTip(eb, jstSettings);
            }

            if (!r.IsOfficerIdNull()) //resolved to officer
                eb.Image = Properties.Resources.RecipientOfficer2;
            else if (!r.IsListIdNull()) //resolved to list
            {
                eb.Image = Properties.Resources.recipientDistList;
                eb.Font = new Font(eb.Font.FontFamily, 8, FontStyle.Underline | FontStyle.Bold);
            }
            else //does not recognize/resolve
                eb.Image = Properties.Resources.RecipientUnknown;


            ToggleRecipReadOnly(eb);
            if (myReadOnly)
                flowLayoutPanelRecipient.Controls.Add(eb);
            else
            {
                flowLayoutPanelRecipient.Controls.Remove(tbNewRecipient);
                flowLayoutPanelRecipient.Controls.Add(eb);
                flowLayoutPanelRecipient.Controls.Add(tbNewRecipient);
                if (!AllowMultiple)
                    tbNewRecipient.Visible = false;
                else
                    tbNewRecipient.Visible = true;
            }

            if (added.ContainsKey(r.RecipId))
                return;

            added.Add(r.RecipId, r);
        }

        private void ToggleRecipReadOnly(Janus.Windows.GridEX.EditControls.EditBox eb)
        {
            if (eb.Name == "tbNewRecipient")
                return;

            if (!myReadOnly)
            {
                eb.Height = 20;
                eb.HoverMode = Janus.Windows.GridEX.HoverMode.Highlight;
                eb.ForeColor = System.Drawing.Color.Blue;
                eb.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.TextButton;
                eb.ButtonText = "X";
                eb.ButtonFont = new Font(eb.Font.FontFamily, 6, FontStyle.Regular);
                eb.BackColor = tbBackColor;

                eb.Width = System.Windows.Forms.TextRenderer.MeasureText(eb.Text, eb.Font).Width + 38;
                //eb.Font = new System.Drawing.Font(this.Font, FontStyle.Underline);
            }
            else
            {
                eb.HoverMode = Janus.Windows.GridEX.HoverMode.None;
                eb.ForeColor = System.Drawing.Color.Black;
                eb.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.NoButton;
                eb.Height = 20;
                eb.Width = System.Windows.Forms.TextRenderer.MeasureText(eb.Text, eb.Font).Width + 22;
                eb.BackColor = tbBackColor;

            }
        }

        public void Add(string email)
        {
            Add(email, email);
        }

        private global::System.Object missing = global::System.Type.Missing;

        public void Add(string userInput, string display)
        {
            docDB.RecipientRow newR = (docDB.RecipientRow)dm.GetRecipient().Add(currentMsg);
            try
            {
                dm.GetRecipient().Resolve(userInput, display, newR,true);
                newR.Type = myRecipType;
                CreateRecip(newR);
            }
            catch(atLogic.ValidationException xV)
            {
                dm.DB.Recipient.RemoveRecipientRow(newR);

                tbNewRecipient.Text = "";
                throw xV;
            }
            catch(atLogic.AtriumException xA)
            {
                dm.DB.Recipient.RemoveRecipientRow(newR);

                tbNewRecipient.Text = "";
            }
            catch (Exception x)
            {
                dm.DB.Recipient.RemoveRecipientRow(newR);
                
                tbNewRecipient.Text = "";

                throw new LMException("There is a problem with your Outlook/Exchange configuration.  You cannot send external emails from Atrium.");
            }
        }

        void eb_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.GridEX.EditControls.EditBox eb = (Janus.Windows.GridEX.EditControls.EditBox)sender;

                int rid = System.Convert.ToInt32(eb.Name);
                added.Remove(rid);
                dm.DB.Recipient.FindByRecipId(rid).updateDate = DateTime.Now;
                dm.DB.Recipient.FindByRecipId(rid).Delete();

                flowLayoutPanelRecipient.Controls.Remove(eb);
                tbNewRecipient.Visible = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void Cancel()
        {
            foreach (docDB.RecipientRow r in added.Values)
            {
                r.Delete();
            }
        }

        private void flowLayoutPanelRecipient_ControlAdded(object sender, ControlEventArgs e)
        {
            try
            {
                flowLayoutPanelRecipient.ScrollControlIntoView(e.Control);
                if (RecipientAdded != null)
                    RecipientAdded(sender, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void flowLayoutPanelRecipient_ControlRemoved(object sender, ControlEventArgs e)
        {
            try
            {
                if (RecipientRemoved != null)
                    RecipientRemoved(sender, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void flowLayoutPanelRecipient_Click(object sender, EventArgs e)
        {
            try
            {
                if (!myReadOnly)
                    tbNewRecipient.Focus();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tbNewRecipient_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tbNewRecipient.Text != "")
                {
                    Add(tbNewRecipient.Text);
                    tbNewRecipient.Text = "";
                    tbNewRecipient.Focus();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem ctx = (ToolStripMenuItem)sender;
                Control c = (Control)ctx.Owner.Tag;
                lmDatasets.docDB.RecipientRow r = (lmDatasets.docDB.RecipientRow)c.Tag;

                atriumBE.FileManager myFm = dm.AtMng.GetFile(currentMsg.FileId);
                myFm.GetDocMng().GetRecipient().AddRecipToFile(r, true, "FNA");
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tsAddToAddressBook_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem ctx = (ToolStripMenuItem)sender;
                Control c = (Control)ctx.Owner.Tag;
                lmDatasets.docDB.RecipientRow r = (lmDatasets.docDB.RecipientRow)c.Tag;

                //get users addressbook file
                atriumBE.FileManager myFm = dm.AtMng.GetFile(dm.AtMng.WorkingAsOfficer.MyFileId);
                myFm.GetDocMng().GetRecipient().AddRecipToFile(r, true, "FAB");
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void tbNewRecipient_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //JLL Commented out on 2013-01-29 until such time as a requirement is established in regards to contact management
                    //Control c = (Control)sender;
                    //Janus.Windows.GridEX.EditControls.EditBox eb = (Janus.Windows.GridEX.EditControls.EditBox)c;
                    //selectedPersonToolStripMenuItem.Text = eb.Text;
                    //ctxMenuRecip.Tag = sender;
                    //eb.Focus();
                    //eb.SelectAll();
                    //ctxMenuRecip.Show(c.PointToScreen(e.Location));
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tbNewRecipient_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == ';')
            //{
            //    Add(tbNewRecipient.Text.Replace(";", ""));
            //    tbNewRecipient.Text = "";

            //}
        }

        private void ctxMenuRecip_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                ContextMenuStrip ctx = (ContextMenuStrip)sender;
                Control c = (Control)ctx.Tag;
                lmDatasets.docDB.RecipientRow r = (lmDatasets.docDB.RecipientRow)c.Tag;
                
                if (!r.IsListIdNull())
                    e.Cancel = true;
                else
                    tsAdd.Enabled = true;

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}
