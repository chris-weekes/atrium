using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    [DefaultBindingProperty("FileId")]
     public partial class ucFileSelectBox : UserControl, UserControls.IRequiredCtl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool isChanged = false;

        public event EventHandler FileChanged;
        protected virtual void OnFileChanged()
        {
            if (FileChanged != null)
                FileChanged(this, new EventArgs());
        }

        private atriumBE.atriumManager myAtmng;
       
        private fBrowse fileBrowser;
        private Janus.Windows.Common.SuperTipSettings jstSettings = new Janus.Windows.Common.SuperTipSettings();

        public atriumBE.atriumManager AtMng
        {
            get { return myAtmng; }
            set { myAtmng = value; }
        }

        private object fileId;

        [Bindable(BindableSupport.Yes)]
        [Browsable(false)]
        public object FileId
        {
            get { return fileId; }
            set
            {
              
             
                if (AtMng == null)
                    return;

                if (fileId != null && value != null && fileId.ToString() == value.ToString() && editBox1.Text != "")
                    return;
                fileId = value;

                if(fileId==null || fileId.GetType()!=typeof(int))
                {
                    editBox1.Text ="";

                    jstSettings.Text = "";
                    jstSettings.HeaderText = "";
                    jstSettings.HeaderImage = null;// Properties.Resources.folder;
                    janusSuperTip1.SetSuperTip(editBox1, jstSettings);
                }
                else
                {
                    try
                    {
                        
                        lmDatasets.appDB.EFileSearchDataTable efsdt = AtMng.FileSearchByFileId((int)fileId);
                        lmDatasets.appDB.EFileSearchRow efr = efsdt[0];
                        if (string.IsNullOrEmpty(efr.FullFileNumber))
                            editBox1.Text = efr.Name;
                        else
                            editBox1.Text = efr.Name + " (" + efr.FullFileNumber + ")";
                        editBox1.Image = Properties.Resources.folder;
                        jstSettings.Text = efr.FullFileNumber + "\n\n" + efr.FullPath;
                        jstSettings.HeaderText = efr.Name;
                        jstSettings.HeaderImage = Properties.Resources.folder;
                        janusSuperTip1.SetSuperTip(editBox1, jstSettings);
                        //tag value will store whether access is allowed
                        editBox1.Tag = true;
                    }
                    catch (Exception x)
                    {
                        //assume you don't have access to the file
                        editBox1.Text = "File Access Denied";
                        editBox1.Image = Properties.Resources.noaccess;
                        jstSettings.Text = "You do not have access to the file specified in this field.";
                        jstSettings.HeaderText = "File Access Denied";
                        jstSettings.HeaderImage = Properties.Resources.noaccess;
                        janusSuperTip1.SetSuperTip(editBox1, jstSettings);
                        //tag value will store whether access is allowed
                        editBox1.Tag = false;
                    }


                    

                    
                }
                //need to test for value change still+
                if (PropertyChanged != null && isChanged)
                {
                    PropertyChangedEventArgs pce = new PropertyChangedEventArgs("FileId");
                    PropertyChanged(this, pce);
                }
                OnTextChanged(new EventArgs());
                isChanged = false;
            }

        }
        public ucFileSelectBox()
        {
            InitializeComponent();


        }

        private bool readOnly;
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                editBox1.ButtonEnabled = !value;
                if (readOnly)
                    editBox1.BackColor = SystemColors.Control;
                else
                    editBox1.BackColor = SystemColors.Window;
            }
        }

        [Category("Layout")]
        public Color ReqColor
        {
            get
            {
                return editBox1.BackColor; 
            }
            set
            {
                editBox1.BackColor = value;
            }
        }

        public bool IsPopulated
        {
            get { return this.Text != ""; }
        }

        [Category("Data")]
        public override string Text
        {
            get
            {
                return editBox1.Text;
            }
        }

        private void editBox1_ButtonClick(object sender, EventArgs e)
        {
            if (fileBrowser == null)
                fileBrowser = new fBrowse(AtMng, 0, false, false, false, true);

            //tag stores value for AccessAllowed to target file  
            //JLL 2010-08-23 added:
            //&& FileId.GetType()!=typeof(System.DBNull) 
            //as FileId was set to DBNull in admin Issues screen

            if (FileId!=null && FileId.GetType()!=typeof(System.DBNull) && (bool)editBox1.Tag)
                fileBrowser.FindFile((int)FileId);

            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                if (fileBrowser.SelectedFile != null)
                {
                    isChanged = true;
                    FileId = fileBrowser.FileId;
                }
            }
        }

        private void editBox1_TextChanged(object sender, EventArgs e)
        {
            OnFileChanged();
        }


        public void RequiredAction()
        {
           
        }
    }
}
