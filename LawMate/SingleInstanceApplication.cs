using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;

 namespace LawMate
{
    // SingleInstanceApplication.cs
    class SingleInstanceApplication : WindowsFormsApplicationBase
    {

        
        static SingleInstanceApplication application;
        protected override void OnCreateMainForm()
        {
            string[] args=new string[this.CommandLineArgs.Count];
            this.CommandLineArgs.CopyTo(args, 0);
            if (args.Length == 1 && args[0] == "-admin")
                this.MainForm = new LawMate.Admin.fMain();
            else
                this.MainForm = new fMain(args);

        }

        internal static SingleInstanceApplication Application
        {
            get
            {
                if (application == null)
                {
                    application = new SingleInstanceApplication();
                    
                }
                
                return application;
            }
        }

        protected override void OnShutdown()
        {
            if (UIHelper.AtMng != null)
            {
                try
                {
                    //delete temp file folder
                    string temp = UIHelper.AtMng.AppMan.TempPath;
                    if (System.IO.Directory.Exists(temp))
                    {
                        string[] files = System.IO.Directory.GetFiles(temp, "*", System.IO.SearchOption.AllDirectories);
                        foreach (string f in files)
                        {
                            try
                            {
                                System.IO.File.SetAttributes(f, System.IO.FileAttributes.Normal);
                                System.IO.File.Delete(f);
                            }
                            catch (Exception x)
                            { }

                        }
                        System.IO.Directory.Delete(temp, true);
                    }
                }
                catch (System.Exception x)
                {
                    //UIHelper.HandleUIException(x);
                }

                UIHelper.AtMng.AppMan.Dispose();
                UIHelper.AtMng = null;
            }
            base.OnShutdown();
        }
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            try
            {
                if (UIHelper.GetSetting("UserLanguage") == "ENG")
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

                }
                else if(UIHelper.GetSetting("UserLanguage") == "FRE")
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-CA");

                }

                fMain.splash = new fSplash();
                fMain.splash.Show();
                UIHelper.Login();
                fMain.splash.incrementProgressBar(10);
                
                return true;
            }
            catch (Exception x)
            {
                eventArgs.Cancel = true;
                return false;
            }

        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            fMain f = (fMain)this.MainForm;
            string[] args = new string[eventArgs.CommandLine.Count];
            eventArgs.CommandLine.CopyTo(args, 0);

            f.ProcessCommandArgs(args);

        }

        // Must call base constructor to ensure correct initial 
        // WindowsFormsApplicationBase configuration
        public SingleInstanceApplication()
        {

            
            // This ensures the underlying single-SDI framework is employed, 
            // and OnStartupNextInstance is fired
            this.IsSingleInstance = LawMate.Properties.Settings.Default.SingleInstance;
            
        }
        
       
    }
}
