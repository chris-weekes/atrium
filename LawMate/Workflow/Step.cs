using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

 namespace LawMate.Workflow
{
    public abstract class Step
    {
        protected Rectangle myRectangle;
        protected Size mySize;
        protected Diagram myDiagram;
        public lmDatasets.ActivityConfig.ACSeriesRow myACS;

        public int gridX = 0, gridY = 0;
        public bool IsSelected = false;


        public abstract void Refresh();
        public abstract void Draw(Point p);
        public abstract bool HitTest(Point p);
        //public abstract Point Center { get; }
        public abstract Point Out { get; }
        public abstract Point In { get; }
        public abstract Point Top { get; }
        public abstract Point Bottom { get; }
        public abstract Point Left { get; }
        public abstract Point Right { get; }


    }

}
