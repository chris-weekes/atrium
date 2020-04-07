using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

 namespace LawMate.Workflow
{
    public class Move:NonRecorded
    {
        System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
        Point[] myPoints ={ new Point(), new Point(), new Point(), new Point(), new Point(), new Point(), new Point()};

        public Move(Diagram d, lmDatasets.ActivityConfig.ACSeriesRow acsr)
            : base(d, acsr)
        {
        }
        public override void Refresh()
        {
            
            string StepText = UIHelper.AtMng.acMng.GetACSeries().GetNodeText(myACS, atriumBE.StepType.Move, true);

            OffsetPoints(3, 3);
            myDiagram.drawingSurface.FillPolygon(Brushes.DarkGray, myPoints);
            OffsetPoints(-3, -3);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            if (IsSelected)
            {
                myDiagram.drawingSurface.FillPolygon(myDiagram.BrushSelected, myPoints);
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

            int x1 = mySize.Width / 3 * 2;
            int x2 = mySize.Width;

            int y1 = mySize.Height / 5;
            int y2 = mySize.Height / 2;
            int y3 = mySize.Height / 5 * 4;
            int y4 = mySize.Height;

            myPoints[0] = new Point(p.X, p.Y + y1);
            myPoints[1] = new Point(p.X + x1, p.Y + y1);
            myPoints[2] = new Point(p.X + x1, p.Y);
            myPoints[3] = new Point(p.X + x2, p.Y + y2);
            myPoints[4] = new Point(p.X + x1, p.Y + y4);
            myPoints[5] = new Point(p.X + x1, p.Y + y3);
            myPoints[6] = new Point(p.X, p.Y + y3);

            gp.AddPolygon(myPoints);

            Refresh();
        }
        private void OffsetPoints(int OffsetX, int OffsetY)
        {
            myPoints[0].Offset(OffsetX, OffsetY);
            myPoints[1].Offset(OffsetX, OffsetY);
            myPoints[2].Offset(OffsetX, OffsetY);
            myPoints[3].Offset(OffsetX, OffsetY);
            myPoints[4].Offset(OffsetX, OffsetY);
            myPoints[5].Offset(OffsetX, OffsetY);
            myPoints[6].Offset(OffsetX, OffsetY);
        }

      
    }
    public class Convert : NonRecorded
    {
        GraphicsPath gp;
        public Convert(Diagram d, lmDatasets.ActivityConfig.ACSeriesRow acsr)
            : base(d, acsr)
        {
        }
        public override void Refresh()
        {
            string StepText = UIHelper.AtMng.acMng.GetACSeries().GetNodeText(myACS, atriumBE.StepType.Convert, true);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            if (IsSelected)
            {
                myDiagram.drawingSurface.FillPath(myDiagram.BrushSelected, gp);
                myDiagram.drawingSurface.DrawPath(myDiagram.PenBlack, gp);
                if (myACS.ActivityCodeRow != null)
                    myDiagram.drawingSurface.DrawString(StepText, myDiagram.SelectedFont, myDiagram.BrushWhite, myRectangle, stringFormat);
            }
            else
            {
                myDiagram.drawingSurface.FillPath(myDiagram.BrushWhite, gp);
                myDiagram.drawingSurface.DrawPath(myDiagram.PenBlack, gp);
                if (myACS.ActivityCodeRow != null)
                    myDiagram.drawingSurface.DrawString(StepText, myDiagram.DrawFont, myDiagram.BrushBlack, myRectangle, stringFormat);
            }
            stringFormat.Dispose();

             
        }
        public override void Draw(Point p)
        {
            myRectangle = new Rectangle(p, mySize);
            gp = Create(p.X, p.Y, mySize.Width, mySize.Height, 8);
        }

        public static GraphicsPath Create(int x, int y, int width,
             int height, int radius)
        {
            int xw = x + width;
            int yh = y + height;
            int xwr = xw - radius;
            int yhr = yh - radius;
            int xr = x + radius;
            int yr = y + radius;
            int r2 = radius * 2;
            int xwr2 = xw - r2;
            int yhr2 = yh - r2;

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            //Top Left Corner
            p.AddArc(x, y, r2, r2, 180, 90);

            //Top Edge
            p.AddLine(xr, y, xwr, y);

            //Top Right Corner
            p.AddArc(xwr2, y, r2, r2, 270, 90);

            //Right Edge
            p.AddLine(xw, yr, xw, yhr);

            //Bottom Right Corner
            p.AddArc(xwr2, yhr2, r2, r2, 0, 90);

            //Bottom Edge
            p.AddLine(xwr, yh, xr, yh);

            //Bottom Left Corner
            p.AddArc(x, yhr2, r2, r2, 90, 90);
            
            //Left Edge
            p.AddLine(x, yhr, x, yr);

            p.CloseFigure();
            return p;
        }
    }

}
