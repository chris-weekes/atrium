using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

 namespace LawMate.Workflow
{
    public class NonRecorded : Activity
    {
        public NonRecorded(Diagram d, lmDatasets.ActivityConfig.ACSeriesRow acsr)
            : base(d, acsr)
        {
        }

        public override void Refresh()
        {
            string StepText = UIHelper.AtMng.acMng.GetACSeries().GetNodeText(myACS, atriumBE.StepType.NonRecorded, true);

            if (StepText == "")
                StepText = "[No description provided]";

            Brush BrushShadow = myDiagram.BrushSemiTrans;
            Brush drawBrush = myDiagram.BrushWhiteSmoke;
            Pen PenDraw = myDiagram.PenSteelBlue;

            if (IsSelected)
            {
                BrushShadow = myDiagram.BrushSelected;
                PenDraw = Pens.Firebrick;
            }

            Rectangle topRectangle = new Rectangle(myRectangle.Left, myRectangle.Top - 18, 22, 18);

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


            myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, myRectangle);
            myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, topRectangle);
            myDiagram.drawingSurface.FillRectangle(myDiagram.BrushWhiteSmoke, topRectangle.Left, topRectangle.Top, topRectangle.Width, topRectangle.Height + 1);
            myDiagram.drawingSurface.DrawImage(Properties.Resources.nonrecorded, topRectangle.Left + 4, topRectangle.Top + 1);
            myDiagram.drawingSurface.FillRectangle(myDiagram.BrushWhiteSmoke, myRectangle);

            if (myACS.ActivityCodeRow != null)
                    myDiagram.drawingSurface.DrawString(StepText, myDiagram.DrawFont, myDiagram.BrushBlack, myRectangle);
            

            if (myACS.RowState == System.Data.DataRowState.Modified)
                myDiagram.drawingSurface.DrawString("* [edited] *", myDiagram.SelectedFont, Brushes.Black, myRectangle.Left, myRectangle.Bottom - 16);

        }

        [DescriptionAttribute("The object (table) that contains the field which will receive the activity date."),
       CategoryAttribute("Activity Details"),
      BrowsableAttribute(false)]
        public override string Associated_Object
        {
            get { return myACS.ActivityCodeRow.AssociatedObject; }
        }

        [DescriptionAttribute("The field that will receive the activity date as its value."),
        CategoryAttribute("Activity Details"),
       BrowsableAttribute(false)]
        public override string Associated_Field
        {
            get { return myACS.ActivityCodeRow.AssociatedField; }
        }

        [DescriptionAttribute("Inidicates whether the activity is of type communication."),
        CategoryAttribute("Activity Details"),
        BrowsableAttribute(false),
        DefaultValueAttribute(false)]
        public override bool Contains_Document
        {
            get { return myACS.ActivityCodeRow.Communication; }

        }

        [DescriptionAttribute("Indicates whether to skip the related fields in the Activity Wizard."),
        CategoryAttribute("Activity Details"),
        BrowsableAttribute(false),
        DefaultValueAttribute(false)]
        public override bool Skip_Related_Fields
        {
            get { return myACS.ActivityCodeRow.SkipRelatedFields; }

        }

        [DescriptionAttribute("Indicates whether the disbursement tab will show in the Activity Wizard."),
        CategoryAttribute("Activity Details"),
        BrowsableAttribute(false),
        DefaultValueAttribute(false)]
        public override bool Go_To_Disbursements
        {
            get { return myACS.ActivityCodeRow.GoToDisbursements; }

        }

        [DescriptionAttribute("The initial section to start on in the Activity Wizard."),
      CategoryAttribute("Workflow Step Properties"),
        BrowsableAttribute(false)]
        public override atriumBE.Step Initial_Wizard_Section
        {
            get { return (atriumBE.Step)myACS.InitialStep; }
        }

        [DescriptionAttribute("Indicates whether the activity can only be entered once for the entirety of the process."),
       CategoryAttribute("Workflow Step Properties"),
       BrowsableAttribute(false)]
        public override bool Once_Only
        {
            get { return myACS.OnceOnly; }
           
        }

        [DescriptionAttribute("Role (Actor) that will perform the activity."),
       CategoryAttribute("Workflow Step Properties"),
       BrowsableAttribute(false)]
        public override string Role
        {
            get { return myACS.RoleCode; }
            
        }

        [DescriptionAttribute("Indicates whether the workflow step can be entered by the owner office."),
   CategoryAttribute("3. Workflow Step Properties"), BrowsableAttribute(false)]
        public override bool For_Owner
        {
            get { return myACS.ForOwner; }
            set { myACS.ForOwner = value; }
        }

        [DescriptionAttribute("Indicates whether the workflow step can be entered by the lead office."),
    CategoryAttribute("3. Workflow Step Properties"), BrowsableAttribute(false)]
        public override bool For_Lead
        {
            get { return myACS.ForLead; }
            set { myACS.ForLead = value; }
        }

        [DescriptionAttribute("Indicates whether the workflow step can be entered by an office who is not the lead or owner (previous office/temporary access office)."),
    CategoryAttribute("3. Workflow Step Properties"), BrowsableAttribute(false)]
        public override bool For_Agent
        {
            get { return myACS.ForAgent; }
            set { myACS.ForAgent = value; }
        }

        [DescriptionAttribute("Indicates whether the workflow step can be entered by the client."),
    CategoryAttribute("3. Workflow Step Properties"), BrowsableAttribute(false)]
        public override bool For_Client
        {
            get { return myACS.ForClient; }
            set { myACS.ForClient = value; }
        }

        [DescriptionAttribute("Help for the AC Info step"),
            CategoryAttribute("4. Workflow Step Help"), BrowsableAttribute(false)]
        public virtual string ACInfoE
        {
            get { return myACS.ACInfoE; }
            set { myACS.ACInfoE = value; }
        }
        [DescriptionAttribute("Help for the AC Info step"),
             CategoryAttribute("4. Workflow Step Help"), BrowsableAttribute(false)]
        public virtual string ACInfoF
        {
            get { return myACS.ACInfoF; }
            set { myACS.ACInfoF = value; }
        }
    }
}
