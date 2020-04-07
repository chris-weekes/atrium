using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

 namespace LawMate.Workflow
{
    public class SubProcess : Activity
    {
        public SubProcess(Diagram d, lmDatasets.ActivityConfig.ACSeriesRow acsr)
            : base(d, acsr)
        {
        }

        public override void Refresh()
        {
            lmDatasets.ActivityConfig.SeriesRow[] sr = (lmDatasets.ActivityConfig.SeriesRow[])UIHelper.AtMng.acMng.DB.Series.Select("SeriesId="+myACS.SubseriesId);
            string tabText;
            string StepText;

            if (sr.Length > 0)
            {
                tabText= " " + sr[0].SeriesCode;
                StepText = sr[0]["SeriesDesc" + UIHelper.AtMng.AppMan.Language].ToString();
            }
            else
            {
                tabText="PROCESS DELETED";
                StepText = "Worfklow/SeriesId " + myACS.SubseriesId + " could not be found";
            }

            Brush BrushShadow = myDiagram.BrushSemiTrans;
            Brush drawBrush = myDiagram.BrushWhite;
            Pen PenDraw = myDiagram.PenSteelBlue;

            if (IsSelected)
            {
                BrushShadow = myDiagram.BrushSelected;
                PenDraw = Pens.Firebrick;
            }

            SizeF StepCodeBoxSize = myDiagram.drawingSurface.MeasureString(tabText, myDiagram.FontUnderlineBold);
            Rectangle topRectangle = new Rectangle(myRectangle.Left, myRectangle.Top - 18, (int)StepCodeBoxSize.Width + 22, 18);


            if (!IsSelected)
            {
                //offset rectangles to draw shadow
                myRectangle.Inflate(myDiagram.recInflate + 1, myDiagram.recInflate + 1);
                topRectangle.Inflate(myDiagram.recInflate + 1, myDiagram.recInflate + 1);
                myDiagram.drawingSurface.FillRectangle(myDiagram.BrushDrawingSurface, myRectangle);
                myDiagram.drawingSurface.FillRectangle(myDiagram.BrushDrawingSurface, topRectangle);
                myRectangle.Inflate((myDiagram.recInflate + 1) * -1, (myDiagram.recInflate + 1) * -1);
                topRectangle.Inflate((myDiagram.recInflate + 1) * -1, (myDiagram.recInflate + 1) * -1);


                myRectangle.Offset(myDiagram.recOffset, myDiagram.recOffset);
                topRectangle.Offset(myDiagram.recOffset, myDiagram.recOffset);
                myDiagram.drawingSurface.FillRectangle(BrushShadow, myRectangle);
                myDiagram.drawingSurface.FillRectangle(BrushShadow, topRectangle);
                myRectangle.Offset(myDiagram.recOffset * -1, myDiagram.recOffset * -1);
                topRectangle.Offset(myDiagram.recOffset * -1, myDiagram.recOffset * -1);
            }
            else
            {
                //offset rectangles to draw shadow
                myRectangle.Inflate(myDiagram.recInflate, myDiagram.recInflate);
                topRectangle.Inflate(myDiagram.recInflate, myDiagram.recInflate);
                myDiagram.drawingSurface.FillRectangle(BrushShadow, myRectangle);
                myDiagram.drawingSurface.FillRectangle(BrushShadow, topRectangle);
                myRectangle.Inflate(myDiagram.recInflate * -1, myDiagram.recInflate * -1);
                topRectangle.Inflate(myDiagram.recInflate * -1, myDiagram.recInflate * -1);
            }

            StringFormat sFormat = new StringFormat();
            sFormat.LineAlignment = StringAlignment.Center;
            sFormat.Alignment = StringAlignment.Center;


            myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, myRectangle);
            myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, topRectangle);
            myDiagram.drawingSurface.FillRectangle(myDiagram.BrushWhite, topRectangle.Left, topRectangle.Top, topRectangle.Width, topRectangle.Height + 1);
            myDiagram.drawingSurface.DrawImage(Properties.Resources.subprocess, myRectangle.Left + 4, myRectangle.Top - 16);
            myDiagram.drawingSurface.FillRectangle(myDiagram.BrushWhite, myRectangle);
            myDiagram.drawingSurface.DrawString(tabText, myDiagram.SelectedFont, Brushes.Blue, topRectangle.Left+20, topRectangle.Top+2);
            myDiagram.drawingSurface.DrawString(StepText, myDiagram.FontUnderlineBold, Brushes.Blue, myRectangle, sFormat);

            sFormat.Dispose();
        }


        //JL: commented out 2009-06-04 - this code freaks out when selectedstep in diagram is subprocess - Subprocess property
        //[TypeConverter(typeof(SeriesConverter)), DescriptionAttribute("Name"),
        //CategoryAttribute("Subprocess")]
        //public string Subprocess
        //{
        //    get
        //    {
        //        if (!myACS.IsSubseriesIdNull())
        //            return SeriesConverter.ac[myACS.SubseriesId];
        //        else
        //            return null;
        //    }
        //    set
        //    {
        //        myACS.SubseriesId  = SeriesConverter.acV[value]; ;
        //    }
        //}


        //Hide Properties

        [DescriptionAttribute("The code that relates to the activity."),
   CategoryAttribute("1. Inherited Activity"), BrowsableAttribute(false)]
        public new string Activity_Code
        {
            get { return myACS.ActivityCodeRow.ActivityCode; }
            //set { myACS.ActivityCodeRow.ActivityCode = value; }
        }

        [DescriptionAttribute("The english description for the activity."),
     CategoryAttribute("1. Inherited Activity"), BrowsableAttribute(false)]
        public new string AC_Description_Eng
        {
            get { return myACS.ActivityCodeRow.ActivityNameEng; }
            //set { myACS.ActivityCodeRow.ActivityNameEng = value; }
        }

        [DescriptionAttribute("The french description for the activity."),
     CategoryAttribute("1. Inherited Activity"), BrowsableAttribute(false)]
        public new string AC_Description_Fre
        {
            get { return myACS.ActivityCodeRow.ActivityNameFre; }
            //set { myACS.ActivityCodeRow.ActivityNameFre = value; }
        }
        [DescriptionAttribute("The object (table) that contains the field which will receive the activity date."),
        CategoryAttribute("Activity Details"),
       BrowsableAttribute(false)]
        public new string Associated_Object
        {
            get { return myACS.ActivityCodeRow.AssociatedObject; }
        }

        [DescriptionAttribute("The field that will receive the activity date as its value."),
        CategoryAttribute("Activity Details"),
       BrowsableAttribute(false)]
        public new string Associated_Field
        {
            get { return myACS.ActivityCodeRow.AssociatedField; }
        }

        [DescriptionAttribute("Inidicates whether the activity is of type communication."),
        CategoryAttribute("Activity Details"),
        BrowsableAttribute(false),
        DefaultValueAttribute(false)]
        public new bool Communication_Activity
        {
            get { return myACS.ActivityCodeRow.Communication; }

        }

        [DescriptionAttribute("Indicates whether to skip the related fields in the Activity Wizard."),
        CategoryAttribute("Activity Details"),
        BrowsableAttribute(false),
        DefaultValueAttribute(false)]
        public new bool Skip_Related_Fields
        {
            get { return myACS.ActivityCodeRow.SkipRelatedFields; }

        }

        [DescriptionAttribute("Indicates whether the disbursement tab will show in the Activity Wizard."),
        CategoryAttribute("Activity Details"),
        BrowsableAttribute(false),
        DefaultValueAttribute(false)]
        public new bool Go_To_Disbursements
        {
            get { return myACS.ActivityCodeRow.GoToDisbursements; }

        }

        [DescriptionAttribute("Workflow Step Code"),
       CategoryAttribute("2. Workflow Step Description")]
        public new string Workflow_Step_Code
        {
            get { return myACS.StepCode; }
            set
            {
                //if (value== "")
                //    myACS.SetSuffixNull();
                //else
                myACS.StepCode = value;
            }
        }
        [DescriptionAttribute("The english description for the activity."),
    CategoryAttribute("2. Step Description"), BrowsableAttribute(false)]
        public new string ACSeries_Description_Eng
        {
            get { return myACS.IsDescEngNull() ? "" : myACS.DescEng; }
        }

        [DescriptionAttribute("The french description for the activity."),
     CategoryAttribute("2. Step Description"), BrowsableAttribute(false)]
        public new string ACSeries_Description_Fre
        {
            get { return myACS.IsDescFreNull() ? "" : myACS.DescFre; }
        }

        [DescriptionAttribute("The initial step to start on in the Activity Wizard."),
      CategoryAttribute("Step Properties"),
       BrowsableAttribute(false)]
        public new atriumBE.Step Initial_Step
        {
            get { return (atriumBE.Step)myACS.InitialStep; }
        }

        [DescriptionAttribute("Indicates whether the activity can only be entered once for the entirety of the process."),
        CategoryAttribute("Step Properties"),
       BrowsableAttribute(false)]
        public new bool Once_Only
        {
            get { return myACS.OnceOnly; }

        }

        [DescriptionAttribute("Role (Actor) that will perform the activity."),
        CategoryAttribute("Step Properties"), BrowsableAttribute(false)]
        public new string Role_Code
        {
            get { return myACS.RoleCode; }

        }
        [DescriptionAttribute("Path to the english help section associated with this step."),
             CategoryAttribute("4. Step Help"), BrowsableAttribute(false)]
        public new string Help_Eng
        {
            get { return myACS.IsHelpENull() ? "" : myACS.HelpE; }
        }

        [DescriptionAttribute("Path to the french help section associated with this step."),
      CategoryAttribute("4. Step Help"), BrowsableAttribute(false)]
        public new string Help_Fre
        {
            get { return myACS.IsHelpFNull() ? "" : myACS.HelpF; }
        }
        [DescriptionAttribute("Indicates whether the activity can be entered by the owner office."),
    CategoryAttribute("3. Step Properties"), BrowsableAttribute(false)]
        public new bool For_Owner
        {
            get { return myACS.ForOwner; }
            set { myACS.ForOwner = value; }
        }

        [DescriptionAttribute("Indicates whether the activity can be entered by the lead office."),
     CategoryAttribute("3. Step Properties"), BrowsableAttribute(false)]
        public new bool For_Lead
        {
            get { return myACS.ForLead; }
            set { myACS.ForLead = value; }
        }

        [DescriptionAttribute("Indicates whether the activity can be entered by an office who is not the lead or owner (previous office/temporary access office)."),
     CategoryAttribute("3. Step Properties"), BrowsableAttribute(false)]
        public new bool For_Agent
        {
            get { return myACS.ForAgent; }
            set { myACS.ForAgent = value; }
        }

        [DescriptionAttribute("Indicates whether the activity can be entered by the client."),
     CategoryAttribute("3. Step Properties"), BrowsableAttribute(false)]
        public new bool For_Client
        {
            get { return myACS.ForClient; }
            set { myACS.ForClient = value; }
        }
        

       

    }
}
