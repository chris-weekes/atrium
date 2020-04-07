using System;
using System.Collections.Generic;
using System.Windows.Forms;
using atriumBE;

 namespace LawMate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                SingleInstanceApplication application = new SingleInstanceApplication();
                //SingleInstanceApplication.Application.SplashScreen = new fSplash();


                //SingleInstanceApplication.Application.MinimumSplashScreenDisplayTime = 5000;

                SingleInstanceApplication.Application.UnhandledException += new Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventHandler(Application_UnhandledException);
                SingleInstanceApplication.Application.Run(args);

            }
            catch (Exception x)
            {
                FatalException x1=new FatalException("Fatal Exception",x);
                UIHelper.HandleUIException(x1);
                x1 = null;
                UIHelper.AtMng = null;
            }
        }

        static void Application_UnhandledException(object sender, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
        {
            UIHelper.HandleUIException(e.Exception);
        }

    }
}