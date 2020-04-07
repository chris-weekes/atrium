using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;


 namespace LawMate.Workflow
{
    public class Start : Step
    {

        public Start(Diagram d)
        {
            myDiagram = d;
            mySize = new Size(Properties.Resources.workflowStart.Width, d.DefaultStepHeight);
        }

        public override void Refresh()
        {
            Point StartPnt = myRectangle.Location;
            myDiagram.drawingSurface.DrawImage(Properties.Resources.workflowStart, StartPnt.X, StartPnt.Y + (myRectangle.Height / 2) - (Properties.Resources.workflowStart.Height / 2));
        }

        public override void Draw(Point p)
        {
            myRectangle = new Rectangle(p, mySize);
            Refresh();
        }

        public override bool HitTest(System.Drawing.Point p)
        {
            return myRectangle.Contains(p);
        }

        public override Point Out
        {
            get { return new Point(myRectangle.Right, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }
        public override Point In
        {
            get { return new Point(myRectangle.Left, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }
        public override Point Top
        {
            get { return new Point((myRectangle.Left + myRectangle.Right) / 2, myRectangle.Top); }
        }
        public override Point Bottom
        {
            get { return new Point((myRectangle.Left + myRectangle.Right) / 2, myRectangle.Bottom); }
        }
        public override Point Left
        {
            get { return new Point(myRectangle.Left, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }
        public override Point Right
        {
            get { return new Point(myRectangle.Right, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }
    }

    public class Finish : Step
    {
        public Finish(Diagram d)
        {
            myDiagram = d;
            mySize = new Size(24, d.DefaultStepHeight);
        }

        public override void Refresh()
        {
            Point EndPnt = myRectangle.Location;
            myDiagram.drawingSurface.DrawImage(Properties.Resources.worklfowEnd, EndPnt.X, EndPnt.Y + (myRectangle.Height / 2) - 12, 24, 24);
        }

        public override void Draw(Point p)
        {
            myRectangle = new Rectangle(p, mySize);
            Refresh();
        }

        public override bool HitTest(System.Drawing.Point p)
        {
            return myRectangle.Contains(p);
        }

        public override Point Out
        {
            get { return new Point(myRectangle.Right, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }
        public override Point In
        {
            get { return new Point(myRectangle.Left, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }
        public override Point Top
        {
            get { return new Point((myRectangle.Left + myRectangle.Right) / 2, myRectangle.Top); }
        }
        public override Point Bottom
        {
            get { return new Point((myRectangle.Left + myRectangle.Right) / 2, myRectangle.Bottom); }
        }
        public override Point Left
        {
            get { return new Point(myRectangle.Left, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }
        public override Point Right
        {
            get { return new Point(myRectangle.Right, (myRectangle.Top + myRectangle.Bottom) / 2); }
        }

    }
}
