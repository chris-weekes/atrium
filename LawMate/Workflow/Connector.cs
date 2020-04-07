using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;


 namespace LawMate.Workflow
{
    public abstract class Connector
    {
        abstract public void Refresh();
        abstract public void Draw(Step s1, Step s2);
        abstract public bool HitTest(System.Drawing.Point p);

        public bool IsSelected = false;

        public lmDatasets.ActivityConfig.ACDependencyRow myACD;
    }


    public class NextStep : Connector
    {

        [DescriptionAttribute("The sequence by which the connectors will be drawn."),
        CategoryAttribute("1. Connector Property")]
        public short? Drawing_Sequence
        {
            get { return myACD.IsSeqNull() ? null : (short?)myACD.Seq; }
            set
            {
                if (value == null)
                    myACD.SetSeqNull();
                else
                    myACD.Seq = (short)value;
            }
        }
        [CategoryAttribute("1. Connector Property")]
        public string Connector_Description_Eng
        {
            get { return myACD.IsDescEngNull() ? "" : myACD.DescEng; }
            set
            {
                if (value == "")
                    myACD.SetDescEngNull();
                else
                    myACD.DescEng = value;
            }
        }
        [CategoryAttribute("1. Connector Property")]
        public string Connector_Description_Fre
        {
            get { return myACD.IsDescFreNull() ? "" : myACD.DescFre; }
            set
            {
                if (value == "")
                    myACD.SetDescFreNull();
                else
                    myACD.DescFre = value;
            }
        }

        [TypeConverter(typeof(BFConverter)), 
        CategoryAttribute("1. Connector Property"),
        DescriptionAttribute("The BF Template that relates to the connector.")]
        public string BF_Template
        {
            get
            {
                if (myACD.ACBFRow != null)
                    return BFConverter.ac[myACD.ACBFId];
                else
                    return null;
            }
            set
            {
                myACD.ACBFId = BFConverter.acV[value]; ;
            }
        }

        public Step End;
        public Step Start;

        protected Point[] myPts;

        protected Diagram myDiagram;

        public NextStep(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
        {
            myDiagram = d;
            myACD = acd;
        }

        public override void Draw(Step s1, Step s2)
        {
            Start = s1;
            End = s2;

            //bool dupHorizontal = false;
            //bool dupVertical = false;
            //if (s1.gridY == s2.gridY || s1.gridX == s2.gridX)
            //{
            //    foreach (Connector conn in myDiagram.myConnectors.Values)
            //    {
            //        Step ss1 = myDiagram.mySteps[myDiagram.GetCurrentStepKey(conn.myACD)];
            //        Step ss2 = myDiagram.mySteps[myDiagram.GetNextStepKey(conn.myACD)];

            //        if
            //    }
            //}


            Point p1, p2;
            if (s1.gridY < s2.gridY)
            {
                p1 = s1.Bottom;
                p1.Offset(0, myDiagram.recInflate);
                //p2 = s2.Top;
                p2 = s2.Left;
                p2.Offset(myDiagram.recInflate * -1, 0);
            }
            else if (s1.gridY > s2.gridY)
            {
                p1 = s1.Top;
                p1.Offset(0, myDiagram.recInflate * -1);
                p2 = s2.Bottom;
                p2.Offset(0, myDiagram.recInflate);
            }
            else
            {
                if (s1.gridX > s2.gridX)
                {
                    p1 = s1.Left;
                    p1.Offset(myDiagram.recInflate * -1, 0);
                    p2 = s2.Right;
                    p2.Offset(myDiagram.recInflate, 0);
                }
                else
                {

                    if (myDiagram.HitConnector(new Point(s1.Right.X + myDiagram.recInflate, s1.Right.Y)) == null)
                    {
                        p1 = s1.Right;
                        p1.Offset(myDiagram.recInflate, 0);
                    }
                    else
                    {
                        p1 = s1.Bottom;
                        p1.Offset(0, myDiagram.recInflate);
                    }
                    p2 = s2.Left;
                    p2.Offset(myDiagram.recInflate * -1, 0);
                }
            }
            
            myPts = new Point[2] { p1, p2 };

            Refresh();
        }

        public override void Refresh()
        {
            System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(3, 3, true);
            System.Drawing.Drawing2D.AdjustableArrowCap arrowCap2 = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);
            Pen pn;
            Pen pn2;
            Font drawFont = myDiagram.DrawFont;
            Brush drawBrush = myDiagram.BrushWhite;
            Brush drawString = myDiagram.BrushBlack;
            Brush drawRole = myDiagram.BrushWhite;

            if (myACD != null)
            {
                if (myACD.ACBFRow != null && !myACD.ACBFRow.IsRoleCodeNull())
                {
                    System.Data.DataTable dtRole = UIHelper.AtMng.GetFile().Codes("RoleCode");
                    System.Data.DataRow[] drRole = dtRole.Select("RoleCode='" + myACD.ACBFRow.RoleCode + "'", "");
                    if (drRole.Length == 0)
                    {
                        dtRole = UIHelper.AtMng.GetFile().Codes("ContactType");
                        drRole = dtRole.Select("ContactTypeCode='" + myACD.ACBFRow.RoleCode + "'", "");
                    }
                    if (!drRole[0].IsNull("WFBGColor"))
                    {
                        int intBrushColor = (int)drRole[0]["WFBGColor"];
                        if (intBrushColor != 0)
                        {
                            Color BrushColor = Color.FromArgb(intBrushColor);
                            drawRole = new SolidBrush(BrushColor);
                        }
                    }
                }


                pn = new Pen(Color.White, 4);
                pn2 = new Pen(Color.LightSteelBlue, 4);
                pn.CustomEndCap = arrowCap;
                pn2.CustomEndCap = arrowCap;
            }
            else
            {
                pn = new Pen(Color.Yellow, 2);
                pn2 = new Pen(Color.LightSteelBlue, 2);
                pn.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                pn2.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
            }
            
            if (IsSelected)
            {
                pn = new Pen(Color.Firebrick, 4);
                pn2 = new Pen(Color.White, 4);
                pn.CustomEndCap = arrowCap;
                pn2.CustomEndCap = arrowCap;
                drawFont = myDiagram.SelectedFont;
                drawBrush = myDiagram.BrushSelected;
            }
            


            Rectangle ConnectorBox = new Rectangle();
            Point cntr = new Point((myPts[0].X + myPts[myPts.Length - 1].X) / 2 - 12, (myPts[0].Y + myPts[myPts.Length - 1].Y) / 2 - 7);
            bool drawBox = false;
            string BoxText = "";
            if (myACD != null && !myACD.IsDescEngNull())
            {
                BoxText = myACD.DescEng;
                SizeF boxSize = myDiagram.drawingSurface.MeasureString(BoxText, drawFont);
                if (myDiagram.HitStep(cntr) == null)
                    ConnectorBox = new Rectangle(cntr.X - 2, cntr.Y, (int)boxSize.Width + 1, (int)boxSize.Height);
                else
                {
                    Point nPoint = FindDrawLocation(cntr);
                    ConnectorBox = new Rectangle(nPoint.X - 2, nPoint.Y, (int)boxSize.Width + 1, (int)boxSize.Height);
                }
                //ConnectorBox = new Rectangle(cntr.X-2, cntr.Y, (int)boxSize.Width+1, (int)boxSize.Height);
                myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, ConnectorBox);
                drawBox = true;
                
            }
            if (myACD != null && myACD.ACBFRow != null)
            {
                BoxText = myACD.ACBFRow.BFCode;
                SizeF boxSize = myDiagram.drawingSurface.MeasureString(BoxText, drawFont);
                if (myDiagram.HitStep(cntr) == null)
                    ConnectorBox = new Rectangle(cntr.X - 2, cntr.Y, (int)boxSize.Width + 1, (int)boxSize.Height);
                else
                {
                    Point nPoint = FindDrawLocation(cntr);
                    ConnectorBox = new Rectangle(nPoint.X - 2, nPoint.Y, (int)boxSize.Width + 1, (int)boxSize.Height);
                }
                myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, ConnectorBox);
                if(myPts[0].X == myPts[1].X)
                    myDiagram.drawingSurface.DrawImage(Properties.Resources.act, ConnectorBox.X -17 , ConnectorBox.Y-1 );
                else
                    myDiagram.drawingSurface.DrawImage(Properties.Resources.act, ConnectorBox.X + (ConnectorBox.Width / 2) - 8, ConnectorBox.Y - 16);
                drawBox = true;
            }



            OffsetMyYPoints(1);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyYPoints(-2);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyYPoints(1);
            myDiagram.drawingSurface.DrawLines(pn, myPts);
            
            if (drawBox)
            {
                StringFormat sformat = new StringFormat();
                sformat.Alignment = StringAlignment.Center;
                sformat.LineAlignment = StringAlignment.Center;
                
                myDiagram.drawingSurface.FillRectangle(drawRole, ConnectorBox);
                myDiagram.drawingSurface.DrawString(BoxText, drawFont, drawString, ConnectorBox, sformat);

                if (myACD.RowState == System.Data.DataRowState.Modified)
                    myDiagram.drawingSurface.DrawString("* [edited] *", myDiagram.SelectedFont, Brushes.Black,cntr.X+8,cntr.Y-8,sformat);

                sformat.Dispose();
            }

            pn.Dispose();
            pn2.Dispose();
            arrowCap.Dispose();            
        }

        private void VerifyForSharedPath()
        {
 
        }

        private Point FindDrawLocation(Point currentCenter)
        {
            Point rPoint;
            int inc=20;
            rPoint=currentCenter;

            if (myPts[0].X == myPts[1].X) // vertical line, move up or down
            {
                if (myPts[0].Y < myPts[1].Y) //step 1 above step2
                {
                    while (myDiagram.HitStep(rPoint) != null)
                    {
                        rPoint.Y -= inc;
                    }
                }
                else // step1 below step2
                {
                    while (myDiagram.HitStep(rPoint) != null)
                    {
                        rPoint.Y += inc;
                    }
                }
            }
            if (myPts[0].Y == myPts[1].Y) // horizontal line, move up or down
            {
                if (myPts[0].X < myPts[1].X) //step 1 to the left of step2
                {
                    while (myDiagram.HitStep(rPoint) != null)
                    {
                        rPoint.X -= inc;
                    }
                }
                else // step1 to the right of step2
                {
                    while (myDiagram.HitStep(rPoint) != null)
                    {
                        rPoint.X += inc;
                    }
                }
            }
            else // diagonal line //move back small percentage at a time
            {
                int xp, yp;
                bool xIs12 = false;
                bool yIs12 = false;

                if (myPts[0].X < myPts[1].X)
                {
                    xIs12 = true;
                    xp = myPts[1].X - myPts[0].X;
                }
                else
                    xp = myPts[0].X - myPts[1].X;

                if (myPts[0].Y < myPts[1].Y)
                {
                    yIs12 = true;
                    yp = myPts[1].Y - myPts[0].Y;
                }
                else
                    yp = myPts[0].Y - myPts[1].Y;

                double decXValue = xp * 0.15;
                double decYValue = yp * 0.15;
                if (decXValue < 1)
                    decXValue = 1;
                if (decYValue < 1)
                    decYValue = 1;

                if(xIs12)
                    rPoint.X -= (int)decXValue;
                else
                    rPoint.X += (int)decXValue;
                if(yIs12)
                    rPoint.Y -= (int)decYValue;
                else
                    rPoint.Y += (int)decYValue;

            }

            return rPoint;

        }


        public override bool HitTest(System.Drawing.Point p)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            Pen pn = new Pen(Color.Black, 10);

            gp.AddLines(myPts);
            gp.Widen(pn);

            gp.IsVisible(p);

            pn.Dispose();

            return gp.IsVisible(p);

            
        }

        protected void OffsetMyPoints(int OffsetValue)
        {
            myPts[0].Offset(OffsetValue, OffsetValue);
            myPts[1].Offset(OffsetValue, OffsetValue);
        }

        protected void OffsetMyXPoints(int OffsetValue)
        {
            myPts[0].Offset(OffsetValue, 0);
            myPts[1].Offset(OffsetValue, 0);
        }

        protected void OffsetMyYPoints(int OffsetValue)
        {
            myPts[0].Offset(0, OffsetValue);
            myPts[1].Offset(0, OffsetValue);
        }
    }

    public class Obsolete : NextStep
    {
        public Obsolete(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
            : base(d, acd)
        {
        }

        public override void Refresh()
        {
            Pen pn;
            Pen pn2;

            System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(3, 3, true);

            if (IsSelected)
            {
                pn = new Pen(Color.Gray, 3);    
                pn2 = new Pen(Color.DarkGray, 3);
                
            }
            else
            {
                pn = new Pen(Color.LightGray, 3);
                pn2 = new Pen(Color.Gray, 3);
            }

            pn.CustomEndCap = arrowCap;
            pn.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pn2.CustomEndCap = arrowCap;
            pn2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            OffsetMyPoints(1);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyPoints(-1);
            myDiagram.drawingSurface.DrawLines(pn, myPts);

            pn.Dispose();
            pn2.Dispose();
            arrowCap.Dispose();
        }
    }

    public class BFOnly : NextStep
    {
        public BFOnly(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
            : base(d, acd)
        {
        }

        public override void Refresh()
        {
            if (myDiagram.DrawBFOnlyConnectors)
            {

                System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 5, true);

                Pen pn;
                Pen pn2;
                Brush drawBrush = Brushes.Orange;

                if (IsSelected)
                {
                    pn = new Pen(Color.Firebrick, 3);
                    pn2 = new Pen(Color.Firebrick, 3);
                }
                else
                {
                    pn = new Pen(Color.Orange, 3);
                    pn2 = new Pen(myDiagram.BrushDrawingSurface, 3);
                }

                pn.CustomEndCap = arrowCap;
                pn.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                pn2.CustomEndCap = arrowCap;
                pn2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;


                Rectangle ConnectorBox = new Rectangle();
                Point cntr = new Point((myPts[0].X + myPts[myPts.Length - 1].X) / 2 - 12, (myPts[0].Y + myPts[myPts.Length - 1].Y) / 2 - 7);
                string BoxText = "";
                if (myACD != null && myACD.ACBFRow != null)
                {
                    BoxText = myACD.ACBFRow.BFCode;
                    SizeF boxSize = myDiagram.drawingSurface.MeasureString(BoxText, myDiagram.DrawFont);
                    ConnectorBox = new Rectangle(cntr.X - 2, cntr.Y, (int)boxSize.Width + 1, (int)boxSize.Height);
                    myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, ConnectorBox);
                    if (myPts[0].X == myPts[1].X)
                        myDiagram.drawingSurface.DrawImage(Properties.Resources.BFListCalendar, ConnectorBox.X - 17, ConnectorBox.Y - 1);
                    else
                        myDiagram.drawingSurface.DrawImage(Properties.Resources.BFListCalendar, ConnectorBox.X + (ConnectorBox.Width / 2) - 8, ConnectorBox.Y - 16);
                }

                OffsetMyYPoints(1);
                myDiagram.drawingSurface.DrawLines(pn2, myPts);
                OffsetMyYPoints(-2);
                myDiagram.drawingSurface.DrawLines(pn2, myPts);
                OffsetMyYPoints(1);
                myDiagram.drawingSurface.DrawLines(pn, myPts);

                

                if (myACD != null)
                {
                    StringFormat sformat = new StringFormat();
                    sformat.Alignment = StringAlignment.Center;
                    sformat.LineAlignment = StringAlignment.Center;

                    myDiagram.drawingSurface.FillRectangle(myDiagram.BrushWhite, ConnectorBox);
                    myDiagram.drawingSurface.DrawString(BoxText, myDiagram.DrawFont, myDiagram.BrushBlack, ConnectorBox, sformat);

                    if (myACD.RowState == System.Data.DataRowState.Modified)
                        myDiagram.drawingSurface.DrawString("* [edited] *", myDiagram.SelectedFont, Brushes.Black, cntr.X + 8, cntr.Y - 8, sformat);

                    sformat.Dispose();
                }

                pn.Dispose();
                pn2.Dispose();
                arrowCap.Dispose();

            }
        }
    }
    public class Transfer : NextStep
    {
        public Transfer(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
            : base(d, acd)
        {
        }

        public override void Refresh()
        {
            System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 5, true);

            Pen pn;
            Pen pn2;
            Brush drawBrush = Brushes.LightYellow;

            if (IsSelected)
            {
                pn = new Pen(Color.Firebrick, 3);
                pn2 = new Pen(Color.Firebrick, 3);
            }
            else
            {
                pn = new Pen(Color.LightYellow, 3);
                pn2 = new Pen(Color.LightSteelBlue , 3);
            }

            pn.CustomEndCap = arrowCap;
            pn2.CustomEndCap = arrowCap;

            RectangleF ConnectorBox = new RectangleF();
            Point cntr = new Point();

            if (myACD != null)
            {
                cntr = new Point((myPts[0].X + myPts[myPts.Length - 1].X) / 2 - 10, (myPts[0].Y + myPts[myPts.Length - 1].Y) / 2 - 10);
                
                SizeF boxSize = new SizeF(19, 19);
                ConnectorBox = new RectangleF(cntr, boxSize);
                myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSelected, ConnectorBox.X, ConnectorBox.Y, ConnectorBox.Width, ConnectorBox.Height);
            }

            OffsetMyYPoints(1);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyYPoints(-2);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyYPoints(1);
            myDiagram.drawingSurface.DrawLines(pn, myPts);


            if (myACD != null)
            {
                StringFormat sformat = new StringFormat();
                sformat.Alignment = StringAlignment.Center;
                sformat.LineAlignment = StringAlignment.Center;

                myDiagram.drawingSurface.FillRectangle(drawBrush, ConnectorBox);
                myDiagram.drawingSurface.DrawImage(Properties.Resources.linkConnector, ConnectorBox.X + 2, ConnectorBox.Y + 2,16, 16);

                if (myACD.RowState == System.Data.DataRowState.Modified)
                    myDiagram.drawingSurface.DrawString("* [edited] *", myDiagram.SelectedFont, Brushes.Black, cntr.X + 8, cntr.Y - 8, sformat);

                sformat.Dispose();
            }

            pn.Dispose();
            pn2.Dispose();
            arrowCap.Dispose();
        }
    }


    public class Enable : NextStep
    {
        public Enable(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
            : base(d, acd)
        {
        }

        public override void Refresh()
        {
            System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 5, true);

            Pen pn;
            Pen pn2;
            Brush drawBrush = Brushes.LightGreen;


            if (IsSelected)
            {
                pn = new Pen(Color.Firebrick, 3);
                pn2 = new Pen(Color.Firebrick, 3);
            }
            else
            {
                pn = new Pen(Color.LightGreen, 3);
                pn2 = new Pen(Color.LightSteelBlue, 3);
            }

            pn.CustomEndCap = arrowCap;
            pn2.CustomEndCap = arrowCap;

            RectangleF ConnectorBox = new RectangleF();
            Point cntr = new Point();

            if (myACD != null)
            {
                cntr = new Point((myPts[0].X + myPts[myPts.Length - 1].X) / 2 - 12, (myPts[0].Y + myPts[myPts.Length - 1].Y) / 2 - 12);

                SizeF boxSize = new SizeF(19, 19);
                ConnectorBox = new RectangleF(cntr, boxSize);
                myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, ConnectorBox.X, ConnectorBox.Y, ConnectorBox.Width, ConnectorBox.Height);
            }

            OffsetMyYPoints(1);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyYPoints(-2);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyYPoints(1);
            myDiagram.drawingSurface.DrawLines(pn, myPts);


            if (myACD != null)
            {
                StringFormat sformat = new StringFormat();
                sformat.Alignment = StringAlignment.Center;
                sformat.LineAlignment = StringAlignment.Center;

                myDiagram.drawingSurface.FillRectangle(drawBrush, ConnectorBox);
                myDiagram.drawingSurface.DrawImage(Properties.Resources.power_on, ConnectorBox.X + 2, ConnectorBox.Y + 2, 16, 16);

                if (myACD.RowState == System.Data.DataRowState.Modified)
                    myDiagram.drawingSurface.DrawString("* [edited] *", myDiagram.SelectedFont, Brushes.Black, cntr.X + 8, cntr.Y - 8, sformat);

                sformat.Dispose();
            }

            pn.Dispose();
            pn2.Dispose();
            arrowCap.Dispose();

        }
    }

    public class Disable : NextStep
    {
        public Disable(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
            : base(d, acd)
        {
        }

        public override void Refresh()
        {
            System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 5, true);

            Pen pn;
            Pen pn2;
            Brush drawBrush = Brushes.MistyRose;


            if (IsSelected)
            {
                pn = new Pen(Color.Firebrick, 3);
                pn2 = new Pen(Color.Firebrick, 3);
            }
            else
            {
                pn = new Pen(Color.MistyRose, 3);
                pn2 = new Pen(Color.LightSteelBlue, 3);
            }

            pn.CustomEndCap = arrowCap;
            pn2.CustomEndCap = arrowCap;

            RectangleF ConnectorBox = new RectangleF();
            Point cntr = new Point();

            if (myACD != null)
            {
                cntr = new Point((myPts[0].X + myPts[myPts.Length - 1].X) / 2 - 12, (myPts[0].Y + myPts[myPts.Length - 1].Y) / 2 - 12);

                SizeF boxSize = new SizeF(19, 19);
                ConnectorBox = new RectangleF(cntr, boxSize);
                myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, ConnectorBox.X, ConnectorBox.Y, ConnectorBox.Width, ConnectorBox.Height);
            }

            OffsetMyYPoints(1);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyYPoints(-2);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyYPoints(1);
            myDiagram.drawingSurface.DrawLines(pn, myPts);


            if (myACD != null)
            {
                StringFormat sformat = new StringFormat();
                sformat.Alignment = StringAlignment.Center;
                sformat.LineAlignment = StringAlignment.Center;

                myDiagram.drawingSurface.FillRectangle(drawBrush, ConnectorBox);
                myDiagram.drawingSurface.DrawImage(Properties.Resources.power_off, ConnectorBox.X + 2, ConnectorBox.Y + 2, 16, 16);

                if (myACD.RowState == System.Data.DataRowState.Modified)
                    myDiagram.drawingSurface.DrawString("* [edited] *", myDiagram.SelectedFont, Brushes.Black, cntr.X + 8, cntr.Y - 8, sformat);

                sformat.Dispose();
            }

            pn.Dispose();
            pn2.Dispose();
            arrowCap.Dispose();
        }
    }

    public class Answer : NextStep
    {
        public Answer(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
            : base(d, acd)
        {
        }
    }

    public class Reply : NextStep
    {
        public Reply(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
            : base(d, acd)
        {
 
        }
        public override void Draw(Step s1, Step s2)
        {

            Start = s1;
            End = s2;
            bool isHorizontal = (s1.gridY == s2.gridY);
            bool isVertical = (s1.gridX == s2.gridX);
            Point p1, p2;
            if (s1.gridY < s2.gridY)
            {
                p1 = s1.Bottom;
                p1.Offset(0, myDiagram.recInflate);
                p2 = s2.Left;
                p2.Offset(myDiagram.recInflate * -1, 0);
            }
            else if (s1.gridY > s2.gridY)
            {
                p1 = s1.Top;
                p1.Offset(0, myDiagram.recInflate * -1);
                p2 = s2.Bottom;
                p2.Offset(0, myDiagram.recInflate);
            }
            else
            {
                if (s1.gridX > s2.gridX)
                {
                    p1 = s1.Left;
                    p1.Offset(myDiagram.recInflate * -1, 0);
                    p2 = s2.Right;
                    p2.Offset(myDiagram.recInflate, 0);
                }
                else
                {
                    p1 = s1.Right;
                    p1.Offset(0, myDiagram.recInflate);
                    p2 = s2.Left;
                    p2.Offset(myDiagram.recInflate * -1, 0);
                }
            }
            if (isHorizontal)
            {
                p1.Offset(0, 20);
                p2.Offset(0, 20);
            }
            else if (isVertical)
            {
                p1.Offset(20, 0);
                p2.Offset(20, 0);
            }
                
            myPts = new Point[2] { p1, p2 };

            Refresh();
        }
        public override void Refresh()
        {
            if (myDiagram.DrawMailConnectors)
            {
                System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);

                Pen pn;
                Pen pn2;
                Brush drawBrush = Brushes.LightCoral;

                if (IsSelected)
                {
                    pn = new Pen(Color.Firebrick, 2);
                    pn2 = new Pen(Color.Firebrick, 2);
                }
                else
                {
                    pn = new Pen(Color.LightCoral, 3);
                    pn2 = new Pen(myDiagram.BrushDrawingSurface, 3);
                }

                pn.CustomStartCap = arrowCap;
                pn2.CustomStartCap = arrowCap;

                Rectangle ConnectorBox = new Rectangle();
                Point cntr = new Point((myPts[0].X + myPts[myPts.Length - 1].X) / 2 - 6, (myPts[0].Y + myPts[myPts.Length - 1].Y) / 2 - 6);
                if (myACD != null)
                {
                    ConnectorBox = new Rectangle(cntr.X -8 , cntr.Y-2, 30 , 16);
                    myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, ConnectorBox);
                }

                OffsetMyYPoints(1);
                myDiagram.drawingSurface.DrawLines(pn2, myPts);
                OffsetMyYPoints(-2);
                myDiagram.drawingSurface.DrawLines(pn2, myPts);
                OffsetMyYPoints(1);
                myDiagram.drawingSurface.DrawLines(pn, myPts);



                if (myACD != null)
                {
                    StringFormat sformat = new StringFormat();
                    sformat.Alignment = StringAlignment.Center;
                    sformat.LineAlignment = StringAlignment.Center;

                    myDiagram.drawingSurface.FillRectangle(myDiagram.BrushWhite, ConnectorBox);
                    myDiagram.drawingSurface.DrawImage(Properties.Resources.mailConnectors, ConnectorBox.X + 2, ConnectorBox.Y +1);
                    myDiagram.drawingSurface.DrawString("R", myDiagram.DrawFont, myDiagram.BrushBlack, ConnectorBox.X + 22, ConnectorBox.Y+10, sformat);

                    if (myACD.RowState == System.Data.DataRowState.Modified)
                        myDiagram.drawingSurface.DrawString("* [edited] *", myDiagram.SelectedFont, Brushes.Black, cntr.X + 8, cntr.Y - 8, sformat);

                    sformat.Dispose();
                }

                pn.Dispose();
                pn2.Dispose();
                arrowCap.Dispose();
            }
        }
    }
    public class ReplyAll : NextStep
    {
        public ReplyAll(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
            : base(d, acd)
        {

        }
        public override void Draw(Step s1, Step s2)
        {

            Start = s1;
            End = s2;
            bool isHorizontal = (s1.gridY == s2.gridY);
            bool isVertical = (s1.gridX == s2.gridX);
            Point p1, p2;
            if (s1.gridY < s2.gridY)
            {
                p1 = s1.Bottom;
                p1.Offset(0, myDiagram.recInflate);
                p2 = s2.Left;
                p2.Offset(myDiagram.recInflate * -1, 0);
            }
            else if (s1.gridY > s2.gridY)
            {
                p1 = s1.Top;
                p1.Offset(0, myDiagram.recInflate * -1);
                p2 = s2.Bottom;
                p2.Offset(0, myDiagram.recInflate);
            }
            else
            {
                if (s1.gridX > s2.gridX)
                {
                    p1 = s1.Left;
                    p1.Offset(myDiagram.recInflate * -1, 0);
                    p2 = s2.Right;
                    p2.Offset(myDiagram.recInflate, 0);
                }
                else
                {
                    p1 = s1.Right;
                    p1.Offset(0, myDiagram.recInflate);
                    p2 = s2.Left;
                    p2.Offset(myDiagram.recInflate * -1, 0);
                }
            }
            if (isHorizontal)
            {
                p1.Offset(0, 20);
                p2.Offset(0, 20);
            }
            else if (isVertical)
            {
                p1.Offset(20, 0);
                p2.Offset(20, 0);
            }

            myPts = new Point[2] { p1, p2 };

            Refresh();
            
        }
        public override void Refresh()
        {
            if (myDiagram.DrawMailConnectors)
            {
                System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);

                Pen pn;
                Pen pn2;
                Brush drawBrush = Brushes.LightCoral;

                if (IsSelected)
                {
                    pn = new Pen(Color.Firebrick, 2);
                    pn2 = new Pen(Color.Firebrick, 2);
                }
                else
                {
                    pn = new Pen(Color.LightCoral, 3);
                    pn2 = new Pen(myDiagram.BrushDrawingSurface, 3);
                }

                pn.CustomStartCap = arrowCap;
                pn2.CustomStartCap = arrowCap;

                Rectangle ConnectorBox = new Rectangle();
                Point cntr = new Point((myPts[0].X + myPts[myPts.Length - 1].X) / 2 - 6, (myPts[0].Y + myPts[myPts.Length - 1].Y) / 2 - 6);
                if (myACD != null)
                {
                    ConnectorBox = new Rectangle(cntr.X - 8, cntr.Y - 2, 38, 16);
                    myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, ConnectorBox);
                }

                OffsetMyYPoints(1);
                myDiagram.drawingSurface.DrawLines(pn2, myPts);
                OffsetMyYPoints(-2);
                myDiagram.drawingSurface.DrawLines(pn2, myPts);
                OffsetMyYPoints(1);
                myDiagram.drawingSurface.DrawLines(pn, myPts);



                if (myACD != null)
                {
                    StringFormat sformat = new StringFormat();
                    sformat.Alignment = StringAlignment.Center;
                    sformat.LineAlignment = StringAlignment.Center;

                    myDiagram.drawingSurface.FillRectangle(myDiagram.BrushWhite, ConnectorBox);
                    myDiagram.drawingSurface.DrawImage(Properties.Resources.mailConnectors, ConnectorBox.X + 2, ConnectorBox.Y + 1);
                    myDiagram.drawingSurface.DrawString("RA", myDiagram.DrawFont, myDiagram.BrushBlack, ConnectorBox.X + 26, ConnectorBox.Y + 10, sformat);

                    if (myACD.RowState == System.Data.DataRowState.Modified)
                        myDiagram.drawingSurface.DrawString("* [edited] *", myDiagram.SelectedFont, Brushes.Black, cntr.X + 8, cntr.Y - 8, sformat);

                    sformat.Dispose();
                }

                pn.Dispose();
                pn2.Dispose();
                arrowCap.Dispose();
            }
        }
    }
    public class Forward : NextStep
    {
        public Forward(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
            : base(d, acd)
        {

        }
        public override void Draw(Step s1, Step s2)
        {
            Start = s1;
            End = s2;
            bool isHorizontal = (s1.gridY == s2.gridY);
            bool isVertical = (s1.gridX == s2.gridX);
            Point p1, p2;
            if (s1.gridY < s2.gridY)
            {
                p1 = s1.Bottom;
                p1.Offset(0, myDiagram.recInflate);
                p2 = s2.Left;
                p2.Offset(myDiagram.recInflate * -1, 0);
            }
            else if (s1.gridY > s2.gridY)
            {
                p1 = s1.Top;
                p1.Offset(0, myDiagram.recInflate * -1);
                p2 = s2.Bottom;
                p2.Offset(0, myDiagram.recInflate);
            }
            else
            {
                if (s1.gridX > s2.gridX)
                {
                    p1 = s1.Left;
                    p1.Offset(myDiagram.recInflate * -1, 0);
                    p2 = s2.Right;
                    p2.Offset(myDiagram.recInflate, 0);
                }
                else
                {
                    p1 = s1.Right;
                    p1.Offset(0, myDiagram.recInflate);
                    p2 = s2.Left;
                    p2.Offset(myDiagram.recInflate * -1, 0);
                }
            }
            if (isHorizontal)
            {
                p1.Offset(0, 20);
                p2.Offset(0, 20);
            }
            else if (isVertical)
            {
                p1.Offset(20, 0);
                p2.Offset(20, 0);
            }

            myPts = new Point[2] { p1, p2 };

            Refresh();
            
        }
        public override void Refresh()
        {
            if (myDiagram.DrawMailConnectors)
            {
                System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);

                Pen pn;
                Pen pn2;
                Brush drawBrush = Brushes.LightCoral;

                if (IsSelected)
                {
                    pn = new Pen(Color.Firebrick, 2);
                    pn2 = new Pen(Color.Firebrick, 2);
                }
                else
                {
                    pn = new Pen(Color.LightCoral, 3);
                    pn2 = new Pen(myDiagram.BrushDrawingSurface, 3);
                }

                pn.CustomStartCap = arrowCap;
                pn2.CustomStartCap = arrowCap;

                Rectangle ConnectorBox = new Rectangle();
                Point cntr = new Point((myPts[0].X + myPts[myPts.Length - 1].X) / 2 - 6, (myPts[0].Y + myPts[myPts.Length - 1].Y) / 2 - 6);
                if (myACD != null)
                {
                    ConnectorBox = new Rectangle(cntr.X - 8, cntr.Y - 2, 46, 16);
                    myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, ConnectorBox);
                }

                OffsetMyYPoints(1);
                myDiagram.drawingSurface.DrawLines(pn2, myPts);
                OffsetMyYPoints(-2);
                myDiagram.drawingSurface.DrawLines(pn2, myPts);
                OffsetMyYPoints(1);
                myDiagram.drawingSurface.DrawLines(pn, myPts);



                if (myACD != null)
                {
                    StringFormat sformat = new StringFormat();
                    sformat.Alignment = StringAlignment.Center;
                    sformat.LineAlignment = StringAlignment.Center;

                    myDiagram.drawingSurface.FillRectangle(myDiagram.BrushWhite, ConnectorBox);
                    myDiagram.drawingSurface.DrawImage(Properties.Resources.mailConnectors, ConnectorBox.X + 2, ConnectorBox.Y + 1);
                    myDiagram.drawingSurface.DrawString("FWD", myDiagram.DrawFont, myDiagram.BrushBlack, ConnectorBox.X + 32, ConnectorBox.Y + 10, sformat);

                    if (myACD.RowState == System.Data.DataRowState.Modified)
                        myDiagram.drawingSurface.DrawString("* [edited] *", myDiagram.SelectedFont, Brushes.Black, cntr.X + 8, cntr.Y - 8, sformat);

                    sformat.Dispose();
                }

                pn.Dispose();
                pn2.Dispose();
                arrowCap.Dispose();
            }
        }
    }

    public class Auto : NextStep
    {
        public Auto(Diagram d, lmDatasets.ActivityConfig.ACDependencyRow acd)
            : base(d, acd)
        {
        }

        public override void Refresh()
        {
            System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 5, true);

            Pen pn;
            Pen pn2;
            Brush drawBrush = Brushes.PowderBlue;


            if (IsSelected)
            {
                pn = new Pen(Color.Firebrick, 3);
                pn2 = new Pen(Color.Firebrick, 3);
            }
            else
            {
                pn = new Pen(Color.PowderBlue, 3);
                pn2 = new Pen(Color.LightSteelBlue, 3);
            }

            pn.CustomEndCap = arrowCap;
            pn2.CustomEndCap = arrowCap;

            RectangleF ConnectorBox = new RectangleF();
            Point cntr = new Point();

            if (myACD != null)
            {
                cntr = new Point((myPts[0].X + myPts[myPts.Length - 1].X) / 2 - 10, (myPts[0].Y + myPts[myPts.Length - 1].Y) / 2 - 10);

                SizeF boxSize = new SizeF(19, 19);
                ConnectorBox = new RectangleF(cntr, boxSize);
                myDiagram.drawingSurface.DrawRectangle(myDiagram.PenSteelBlue, ConnectorBox.X, ConnectorBox.Y, ConnectorBox.Width, ConnectorBox.Height);
            }

            OffsetMyYPoints(1);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyYPoints(-2);
            myDiagram.drawingSurface.DrawLines(pn2, myPts);
            OffsetMyYPoints(1);
            myDiagram.drawingSurface.DrawLines(pn, myPts);


            if (myACD != null)
            {
                StringFormat sformat = new StringFormat();
                sformat.Alignment = StringAlignment.Center;
                sformat.LineAlignment = StringAlignment.Center;

                myDiagram.drawingSurface.FillRectangle(drawBrush, ConnectorBox);
                myDiagram.drawingSurface.DrawImage(Properties.Resources.automaticstep2, ConnectorBox.X + 2, ConnectorBox.Y + 2, 16, 16);

                if (myACD.RowState == System.Data.DataRowState.Modified)
                    myDiagram.drawingSurface.DrawString("* [edited] *", myDiagram.SelectedFont, Brushes.Black, cntr.X + 8, cntr.Y - 8, sformat);

                sformat.Dispose();
            }

            pn.Dispose();
            pn2.Dispose();
            arrowCap.Dispose();
        }
    }


    public class BFConverter : StringConverter
    {
        public static Dictionary<int, string> ac = new Dictionary<int, string>();
        public static Dictionary<string, int> acV = new Dictionary<string, int>();

        public BFConverter()
        {
        }

        public static void Init()
        {
            System.Data.DataView dvAC = new System.Data.DataView(UIHelper.AtMng.acMng.DB.ACBF, "Obsolete=false", "BFCode", System.Data.DataViewRowState.CurrentRows);
            ac.Clear();
            acV.Clear();
            foreach (System.Data.DataRowView dvr in dvAC)
            {
                lmDatasets.ActivityConfig.ACBFRow acr = (lmDatasets.ActivityConfig.ACBFRow)dvr.Row;
                ac.Add(acr.ACBFId, acr.BFCode + " - " + acr.BFDescriptionEng);
                acV.Add(acr.BFCode + " - " + acr.BFDescriptionEng, acr.ACBFId);
            }
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(ac.Values);
        }

    }

}
