using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

 namespace LawMate.Workflow
{
    [DefaultPropertyAttribute("Workflow_Step_Description_Qualifier_Eng")]
    public class Decision : Step
    {
        Point[] myPointArray ={ new Point(), new Point(), new Point(), new Point() };
        System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

        public Decision(Diagram d, lmDatasets.ActivityConfig.ACSeriesRow acsr)
        {
            myDiagram = d;
            myACS = acsr;
            mySize = new Size(d.DefaultStepWidth, d.DefaultStepHeight);
        }

        public override void Refresh()
        {

            Brush BrushShadow = myDiagram.BrushSemiTrans;

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            bool isInternalDecision = (myACS.GetActivityFieldRows().Length > 0);
            string StepText = myACS["Desc" + UIHelper.AtMng.AppMan.Language].ToString(); //UIHelper.AtMng.acMng.GetACSeries().GetNodeText(myACS, atriumBE.StepType.Decision, true);
            string stepCode = myACS.StepCode;

            SizeF StepCodeBoxSize = myDiagram.drawingSurface.MeasureString(myACS.StepCode, myDiagram.SelectedFont);
            int boxWidth = (int)StepCodeBoxSize.Width + 20;
            Rectangle topRectangle = new Rectangle(myRectangle.Left + (myRectangle.Width/2) - (boxWidth/2) , myRectangle.Top- myDiagram.DefaultDecisionHeightIncrease, boxWidth, 18);

            if (!IsSelected)
            {
                //offset rectangles to draw shadow
                InflatePoints(myDiagram.recInflate + 1, true);
                topRectangle.Inflate(myDiagram.recInflate + 1, myDiagram.recInflate + 1);
                myDiagram.drawingSurface.FillPolygon(myDiagram.BrushDrawingSurface, myPointArray);
                myDiagram.drawingSurface.FillRectangle(myDiagram.BrushDrawingSurface, topRectangle);
                InflatePoints(myDiagram.recInflate + 1, false);
                topRectangle.Inflate((myDiagram.recInflate + 1) * -1, (myDiagram.recInflate + 1) * -1);

                OffsetPoints(myDiagram.recOffset, myDiagram.recOffset);
                topRectangle.Offset(myDiagram.recOffset, myDiagram.recOffset);
                myDiagram.drawingSurface.FillPolygon(myDiagram.BrushSemiTrans, myPointArray);
                myDiagram.drawingSurface.FillRectangle(myDiagram.BrushSemiTrans, topRectangle);
                OffsetPoints(myDiagram.recOffset * -1, myDiagram.recOffset * -1);
                topRectangle.Offset(myDiagram.recOffset * -1, myDiagram.recOffset * -1);

            }
            else
            {
                InflatePoints(myDiagram.recInflate, true);
                topRectangle.Inflate(myDiagram.recInflate , myDiagram.recInflate );
                myDiagram.drawingSurface.FillPolygon(myDiagram.BrushSelected, myPointArray);
                myDiagram.drawingSurface.FillRectangle(myDiagram.BrushSelected, topRectangle);
                InflatePoints(myDiagram.recInflate , false);
                topRectangle.Inflate((myDiagram.recInflate ) * -1, (myDiagram.recInflate ) * -1);
            }


            myDiagram.drawingSurface.DrawPolygon(myDiagram.PenSteelBlue, myPointArray);
            myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, topRectangle);

            if (isInternalDecision)
            {
                myDiagram.drawingSurface.FillPolygon(myDiagram.BrushLightSteelBlue, myPointArray);
                myDiagram.drawingSurface.FillRectangle(myDiagram.BrushLightSteelBlue, topRectangle);
            }
            else
            {
                myDiagram.drawingSurface.FillPolygon(myDiagram.BrushWhite, myPointArray);
                myDiagram.drawingSurface.FillRectangle(myDiagram.BrushWhite, topRectangle);
            }

            if (myACS.ActivityCodeRow != null)
            {
                myDiagram.drawingSurface.DrawString(StepText, myDiagram.DrawFont, myDiagram.BrushBlack, myRectangle, stringFormat);
                if (isInternalDecision)
                {
                    myDiagram.drawingSurface.DrawImage(Properties.Resources.batch, topRectangle.Left + 3, topRectangle.Top + 3);
                    myDiagram.drawingSurface.DrawString(myACS.StepCode, myDiagram.DrawFont, myDiagram.BrushBlack, topRectangle.Left + 43, topRectangle.Top + 10, stringFormat);
                }
                else
                {
                    myDiagram.drawingSurface.DrawImage(Properties.Resources.decision, topRectangle.Left + 2, topRectangle.Top + 2);
                    myDiagram.drawingSurface.DrawString(myACS.StepCode, myDiagram.DrawFont, myDiagram.BrushBlack, topRectangle.Left + 40, topRectangle.Top + 10, stringFormat);
                }
            }


            if (myACS.RowState == System.Data.DataRowState.Modified)
            {
                Rectangle modRectangle = new Rectangle(myRectangle.Left+12, myRectangle.Top-8, 18, 18);
                myDiagram.drawingSurface.FillRectangle(myDiagram.BrushSelected, modRectangle);
                myDiagram.drawingSurface.DrawImage(Properties.Resources.edit3, myRectangle.Left +13, myRectangle.Top - 7);
            }
                

            stringFormat.Dispose();

        }
        public override void Draw(Point p)
        {
            myRectangle = new Rectangle(p, mySize);

            myPointArray[0] = new Point(p.X, myRectangle.Top + myRectangle.Height / 2);//left
            myPointArray[1] = new Point(p.X + myRectangle.Width / 2, myRectangle.Top - myDiagram.DefaultDecisionHeightIncrease );//top
            myPointArray[2] = new Point(p.X + myRectangle.Width, myRectangle.Top + myRectangle.Height / 2);//right
            myPointArray[3] = new Point(p.X + myRectangle.Width / 2, myRectangle.Top + myRectangle.Height + myDiagram.DefaultDecisionHeightIncrease);//bottom

            gp.AddPolygon(myPointArray);

            Refresh();
        }

        private void OffsetPoints(int offsetX,int OffsetY)
        {
            myPointArray[0].Offset(offsetX, OffsetY);
            myPointArray[1].Offset(offsetX, OffsetY);
            myPointArray[2].Offset(offsetX, OffsetY);
            myPointArray[3].Offset(offsetX, OffsetY);
        }

        private void InflatePoints(int inflateNum, bool Inflate)
        {
            if (Inflate)
            {
                myPointArray[0].X -= inflateNum+1;
                myPointArray[1].Y -= inflateNum;
                myPointArray[2].X += inflateNum;
                myPointArray[3].Y += inflateNum+1;
            }
            else
            {
                myPointArray[0].X += inflateNum+1;
                myPointArray[1].Y += inflateNum;
                myPointArray[2].X -= inflateNum;
                myPointArray[3].Y -= inflateNum+1;
            }
 
        }

        public override bool HitTest(System.Drawing.Point p)
        {
            return gp.IsVisible(p); 
        }

        [DescriptionAttribute("Workflow step code"),
        CategoryAttribute("2. Workflow Step Description")]
        public string Workflow_Step_Code
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

        [DescriptionAttribute("The english description for the workflow step."),
    CategoryAttribute("2. Workflow Step Description")]
        public string Workflow_Step_Description_Qualifier_Eng
        {
            get { return myACS.IsDescEngNull() ? "" : myACS.DescEng; }
            set
            {
                if (value == "")
                    myACS.SetDescEngNull();
                else
                    myACS.DescEng = value;
            }
        }

        [DescriptionAttribute("The french description for the workflow step."),
     CategoryAttribute("2. Workflow Step Description")]
        public string Workflow_Step_Description_Qualifier_Fre
        {
            get { return myACS.IsDescFreNull() ? "" : myACS.DescFre; }
            set
            {
                if (value == "")
                    myACS.SetDescFreNull();
                else
                    myACS.DescFre = value;
            }
        }

        [DescriptionAttribute("The type of step."),
      CategoryAttribute("3. Workflow Step Properties")]
        public atriumBE.StepType Step_Type
        {
            get { return (atriumBE.StepType)myACS.StepType; }
        }

        [DescriptionAttribute("Indicates whether the workflow step is the first step in a process."),
      CategoryAttribute("3. Workflow Step Properties"),
       BrowsableAttribute(false)]
        public bool Start
        {
            get { return myACS.Start; }
            set { myACS.Start = value; }
        }

        [DescriptionAttribute("Indicates whether the workflow step is obsolete (i.e. it cannot be deleted from the process as activities exist based in its model, and it must be hidden as a possible path in the actual execution of the process.)"),
     CategoryAttribute("3. Workflow Step Properties")]
        public bool Obsolete
        {
            get { return myACS.Obsolete; }
            set { myACS.Obsolete = value; }
        }

        [DescriptionAttribute("Number used to sequence (default sort) the workflow steps in the workflow steps grid panel."),
     CategoryAttribute("3. Workflow Step Properties")]
        public int Sequence
        {
            get { return myACS.Seq; }
            //set { myACS.Seq = value; }
        }

       // [TypeConverter(typeof(RoleCodeConverter)), DescriptionAttribute("Role (Actor) that will perform the activity."),
       //CategoryAttribute("3. Step Properties")]
       // public string Role_Code
       // {
       //     get
       //     {
       //         if (!myACS.IsRoleCodeNull())
       //             return RoleCodeConverter.roles[myACS.RoleCode];
       //         else
       //             return null;
       //     }
       //     set
       //     {
       //         if (value == null || value == "")
       //             myACS.SetRoleCodeNull();
       //         else
       //             myACS.RoleCode = RoleCodeConverter.rolesV[value]; ;
       //     }
       // }

        [DescriptionAttribute("Path to the english help section associated with this workflow step."),
               CategoryAttribute("4. Workflow Step Help")]
        public string Help_Eng
        {
            get { return myACS.IsHelpENull() ? "" : myACS.HelpE; }
            set
            {
                if (value == "")
                    myACS.SetHelpENull();
                else
                    myACS.HelpE = value;
            }
        }

        [DescriptionAttribute("Path to the french help section associated with this workflow step."),
     CategoryAttribute("4. Workflow Step Help")]
        public string Help_Fre
        {
            get { return myACS.IsHelpFNull() ? "" : myACS.HelpF; }
            set
            {
                if (value == "")
                    myACS.SetHelpFNull();
                else
                    myACS.HelpF = value;
            }
        }

        [DescriptionAttribute("The code for the inherited step template."),
     CategoryAttribute("1. Inherited Template Step"),]
        public string Template_Step_Code
        {
            get { return myACS.ActivityCodeRow.ActivityCode; }
            //set { myACS.ActivityCodeRow.ActivityCode = value; }
        }

        [DescriptionAttribute("The english description for the inherited step template."),
   CategoryAttribute("1. Inherited Template Step")]
        public string Template_Step_Description_Eng
        {
            get { return myACS.ActivityCodeRow.ActivityNameEng; }
            //set { myACS.ActivityCodeRow.ActivityNameEng = value; }
        }

        [DescriptionAttribute("The french description for the inherited step template."),
     CategoryAttribute("1. Inherited Template Step")]
        public string Template_Step_Description_Fre
        {
            get { return myACS.ActivityCodeRow.ActivityNameFre; }
            //set { myACS.ActivityCodeRow.ActivityNameFre = value; }
        }
        [DescriptionAttribute("Indicates whether the instance of this activity code is read-only."),
       CategoryAttribute("Activity Details"),
       DefaultValueAttribute(false),
       BrowsableAttribute(false)]
        public bool Read_Only
        {
            get { return myACS.ActivityCodeRow.ReadOnly; }
           // set { myACS.ActivityCodeRow.GoToDisbursements = value; }
        }

        [DescriptionAttribute("Indicates whether this activity is obsolete.  The activity no longer appears as available in the application.  Existing instances of the activity still remain."),
        CategoryAttribute("Activity Details"),
        DefaultValueAttribute(false),
       BrowsableAttribute(false)]
        public bool AC_Obsolete
        {
            get { return myACS.ActivityCodeRow.Obsolete; }
           // set { myACS.ActivityCodeRow.Obsolete = value; }
        }


        [BrowsableAttribute(false)]
        public override Point Out
        {
            get { return myPointArray[2]; }
        }

        [BrowsableAttribute(false)]
        public override Point In
        {
            get { return myPointArray[0]; }
        }

        [BrowsableAttribute(false)]
        public override Point Top
        {
            get { return myPointArray[1]; }
        }

        [BrowsableAttribute(false)]
        public override Point Bottom
        {
            get { return myPointArray[3]; }
        }

        [BrowsableAttribute(false)]
        public override Point Left
        {
            get { return myPointArray[0]; }
        }

        [BrowsableAttribute(false)]
        public override Point Right
        {
            get { return myPointArray[2]; }
        }
    }
}
