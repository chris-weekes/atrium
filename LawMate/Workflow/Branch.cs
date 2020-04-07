using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

 namespace LawMate.Workflow
{
    [DefaultPropertyAttribute("Workflow_Step_Description_Qualifier_Eng")]
    public class Branch:Step
    {
        System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
        Point[] myPoints ={ new Point(), new Point(), new Point(), new Point(), new Point(), new Point(), new Point(), new Point(), new Point(), new Point(), new Point(), new Point() };

        public Branch(Diagram d, lmDatasets.ActivityConfig.ACSeriesRow acsr)
        {
            myDiagram = d;
            myACS = acsr;
            mySize = new Size(d.DefaultStepWidth, d.DefaultStepHeight);
        }

        public override void Refresh()
        {
            string StepText = UIHelper.AtMng.acMng.GetACSeries().GetNodeText(myACS, atriumBE.StepType.Branch, true);

            OffsetPoints(3,3);
            myDiagram.drawingSurface.FillPolygon(Brushes.DarkGray, myPoints);            
            OffsetPoints(-3,-3);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            if (IsSelected)
            {
                myDiagram.drawingSurface.FillPolygon(myDiagram.BrushSelected,myPoints);
                myDiagram.drawingSurface.DrawPolygon(myDiagram.PenBlack, myPoints);
                if (myACS.ActivityCodeRow != null)
                    myDiagram.drawingSurface.DrawString(StepText, myDiagram.SelectedFont, myDiagram.BrushWhite, myRectangle, stringFormat);
            }
            else
            {
                myDiagram.drawingSurface.FillPolygon(myDiagram.BrushWhite, myPoints);
                myDiagram.drawingSurface.DrawPolygon(myDiagram.PenBlack, myPoints);
                if (myACS.ActivityCodeRow != null)
                    myDiagram.drawingSurface.DrawString(StepText, myDiagram.DrawFont, myDiagram.BrushBlack, myRectangle, stringFormat);
            }
            stringFormat.Dispose();
        }

        public override void Draw(Point p)
        {
            myRectangle = new Rectangle(p, mySize);

            int x0 = mySize.Width / 3;
            int x1 = mySize.Width / 3 * 2;
            int x2 = mySize.Width;

            int y0 = mySize.Height / 3;
            int y1 = mySize.Height / 3 * 2;
            int y2 = mySize.Height;

            myPoints[0] = new Point(p.X+ x0,p.Y);
            myPoints[1] = new Point(p.X+x1,p.Y);
            myPoints[2] =new Point(p.X+x1,p.Y+y0);
            myPoints[3] =new Point(p.X+x2,p.Y+y0);
            myPoints[4] =new Point(p.X+x2,p.Y+y1);
            myPoints[5] =new Point(p.X+x1,p.Y+y1);
            myPoints[6] =new Point(p.X+x1,p.Y+y2);
            myPoints[7] =new Point(p.X+x0,p.Y+y2);
            myPoints[8] =new Point(p.X+x0,p.Y+y1);
            myPoints[9] =new Point(p.X,p.Y+y1);
            myPoints[10] =new Point(p.X,p.Y+y0);
            myPoints[11] =new Point(p.X+x0,p.Y+y0);

            gp.AddPolygon(myPoints);

            Refresh();
        }

        private void OffsetPoints(int OffsetX,int OffsetY)
        {
            myPoints[0].Offset(OffsetX, OffsetY);
            myPoints[1].Offset(OffsetX, OffsetY);
            myPoints[2].Offset(OffsetX, OffsetY);
            myPoints[3].Offset(OffsetX, OffsetY);
            myPoints[4].Offset(OffsetX, OffsetY);
            myPoints[5].Offset(OffsetX, OffsetY);
            myPoints[6].Offset(OffsetX, OffsetY);
            myPoints[7].Offset(OffsetX, OffsetY);
            myPoints[8].Offset(OffsetX, OffsetY);
            myPoints[9].Offset(OffsetX, OffsetY);
            myPoints[10].Offset(OffsetX, OffsetY);
            myPoints[11].Offset(OffsetX, OffsetY);
        }

        public override bool HitTest(System.Drawing.Point p)
        {
            return gp.IsVisible(p);
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
        [DescriptionAttribute("Indicates whether the workflow step is obsolete (i.e. it cannot be deleted from the process as activities exist based in its model, and it must be hidden as a possible path in the actual execution of the process.)"),
     CategoryAttribute("3. Workflow Step Properties")]
        public bool Obsolete
        {
            get { return myACS.Obsolete; }
            set { myACS.Obsolete = value; }
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

        [BrowsableAttribute(false)]
        public override Point Out
        {
            get { return new Point(myRectangle.Right, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }

        [BrowsableAttribute(false)]
        public override Point In
        {
            get { return new Point(myRectangle.Left, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }

        [BrowsableAttribute(false)]
        public override Point Top
        {
            get { return new Point((myRectangle.Left + myRectangle.Right) / 2, myRectangle.Top); }
        }

        [BrowsableAttribute(false)]
        public override Point Bottom
        {
            get { return new Point((myRectangle.Left + myRectangle.Right) / 2, myRectangle.Bottom); }
        }

        [BrowsableAttribute(false)]
        public override Point Left
        {
            get { return new Point(myRectangle.Left, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }

        [BrowsableAttribute(false)]
        public override Point Right
        {
            get { return new Point(myRectangle.Right, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }
    }
    [DefaultPropertyAttribute("Workflow_Step_Description_Qualifier_Eng")]
    public class Wait : Step
    {

        Point[] myPointArray ={ new Point(), new Point(), new Point(), new Point() };
        System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

        public Wait(Diagram d, lmDatasets.ActivityConfig.ACSeriesRow acsr)
        {
            myDiagram = d;
            myACS = acsr;
            mySize = new Size(d.DefaultStepWidth, d.DefaultStepHeight);
        }

        public override void Refresh()
        {
            Font fnt = new Font(myDiagram.DrawFont.FontFamily, 24, FontStyle.Bold);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            //string StepText = UIHelper.AtMng.acMng.GetACSeries().GetNodeText(myACS, atriumBE.StepType.Merge, true);

            OffsetPoints(3);
            myDiagram.drawingSurface.FillPolygon(Brushes.DarkGray, myPointArray);
            OffsetPoints(-3);


            if (IsSelected)
            {
                myDiagram.drawingSurface.FillPolygon(myDiagram.BrushSelected, myPointArray);
                myDiagram.drawingSurface.DrawPolygon(myDiagram.PenBlack, myPointArray);
                if (myACS.ActivityCodeRow != null)
                    myDiagram.drawingSurface.DrawString("+", fnt, myDiagram.BrushWhite, myRectangle, stringFormat);
            }
            else
            {
                myDiagram.drawingSurface.FillPolygon(myDiagram.BrushWhite, myPointArray);
                myDiagram.drawingSurface.DrawPolygon(myDiagram.PenBlack, myPointArray);
                if (myACS.ActivityCodeRow != null)
                    myDiagram.drawingSurface.DrawString("+", fnt, myDiagram.BrushBlack, myRectangle, stringFormat);
            }

            stringFormat.Dispose();
        }

        public override void Draw(Point p)
        {
            myRectangle = new Rectangle(p, mySize);

            myPointArray[0] = new Point(p.X, myRectangle.Top + myRectangle.Height / 2);//left
            myPointArray[1] = new Point(p.X + myRectangle.Width / 2, myRectangle.Top);//top
            myPointArray[2] = new Point(p.X + myRectangle.Width, myRectangle.Top + myRectangle.Height / 2);//right
            myPointArray[3] = new Point(p.X + myRectangle.Width / 2, myRectangle.Top + myRectangle.Height);//bottom

            gp.AddPolygon(myPointArray);

            Refresh();
        }

        public override bool HitTest(System.Drawing.Point p)
        {
            return gp.IsVisible(p);
        }

        private void OffsetPoints(int offsetValue)
        {
            myPointArray[0].Offset(offsetValue, offsetValue);
            myPointArray[1].Offset(offsetValue, offsetValue);
            myPointArray[2].Offset(offsetValue, offsetValue);
            myPointArray[3].Offset(offsetValue, offsetValue);
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


        [DescriptionAttribute("The english description for the workflow step."),
    CategoryAttribute("2. Workflow Step Description")]
        public string Workflow_Step_Description_Qualifier_Eng
        {
            get { return myACS.IsDescEngNull() ? "" : myACS.DescEng; }
            //set
            //{
            //    if (value == "")
            //        myACS.SetDescEngNull();
            //    else
            //        myACS.DescEng = value;
            //}
        }

        [DescriptionAttribute("The french description for the workflow step."),
    CategoryAttribute("2. Workflow Step Description")]
        public string Workflow_Step_Description_Qualifier_Fre
        {
            get { return myACS.IsDescFreNull() ? "" : myACS.DescFre; }
            //set
            //{
            //    if (value == "")
            //        myACS.SetDescFreNull();
            //    else
            //        myACS.DescFre = value;
            //}
        }

        [DescriptionAttribute("The type of step."),
       CategoryAttribute("3. Workflow Step Properties")]
        public atriumBE.StepType Step_Type
        {
            get { return (atriumBE.StepType)myACS.StepType; }
        }

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

        [BrowsableAttribute(false)]
        public override Point Out
        {
            get { return new Point(myRectangle.Right, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }

        [BrowsableAttribute(false)]
        public override Point In
        {
            get { return new Point(myRectangle.Left, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }

        [BrowsableAttribute(false)]
        public override Point Top
        {
            get { return new Point((myRectangle.Left + myRectangle.Right) / 2, myRectangle.Top); }
        }

        [BrowsableAttribute(false)]
        public override Point Bottom
        {
            get { return new Point((myRectangle.Left + myRectangle.Right) / 2, myRectangle.Bottom); }
        }

        [BrowsableAttribute(false)]
        public override Point Left
        {
            get { return new Point(myRectangle.Left, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }

        [BrowsableAttribute(false)]
        public override Point Right
        {
            get { return new Point(myRectangle.Right, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }
    }
}
