using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using lmDatasets;

 namespace LawMate.Workflow
{
    public class Diagram
    {
        public bool HideObsolete = true;

        public int imgWidth;
        public int imgHeight;
      
        //collection for steps
        public Dictionary<string,Step> mySteps=new Dictionary<string,Step>();

        //collection for start and finish steps
        private List<Step> myOtherSteps = new List<Step>();

        //collection for connectors
        public Dictionary<int,Connector> myConnectors=new Dictionary<int,Connector>();
        //collection for start and finish connectors
        private List<Connector> myOtherConnectors = new List<Connector>();

        //reference to drawing surface
        public Graphics drawingSurface;

        public bool DrawMailConnectors = true;
        public bool DrawBFOnlyConnectors = true;
        public bool DrawEnableDisableLinkConnectors = true;

        public int DefaultStepWidth = 160;
        public int DefaultStepHeight = 56;
        public int DefaultDecisionHeightIncrease = 16;
        public int DefaultWidthGap = 225;
        public int DefaultHeightGap = 130;
        public int recInflate = 5;
        public int recOffset = 5;

        public Brush BrushWhiteSmoke = Brushes.WhiteSmoke;
        public Brush BrushLightSteelBlue = Brushes.LightSteelBlue;
        public Brush BrushBlack = Brushes.Black;
        public Brush BrushGray = Brushes.DarkGray;
        public Brush BrushWhite = Brushes.White;
        public Brush BrushSelected = Brushes.Firebrick;
        public Brush BrushBlue = Brushes.Blue;
        public Brush BrushSillyQuestion = Brushes.Gainsboro;
        public Brush BrushNotInSeries = Brushes.Orange;
        public SolidBrush BrushSemiTrans =  new SolidBrush(Color.FromArgb(128, Color.LightSteelBlue));

        public Pen PenBlack = new Pen(Brushes.Black, 1);
        public Pen PenSteelBlue = new Pen(Brushes.SteelBlue, 1);
        public Pen PenWhite = new Pen(Brushes.White, 1);
        public Pen PenSelected = new Pen(Brushes.DarkSlateBlue, 1);
        
        public Font DrawFont = new Font("Calibri",7.75f);
        public Font FontUnderlineBold = new Font("Calibri", 7.5f, FontStyle.Underline | FontStyle.Bold);
        public Font SelectedFont = new Font("Calibri", 7.5f, FontStyle.Bold);
        
        public SolidBrush DrawBrush = new SolidBrush(Color.Black);
        public StringFormat DrawFormat = new StringFormat();

        public Step SelectedStep;
        public Connector SelectedConnector;

        private Color drawingSurfaceBGColor = Color.FromArgb(219, 235, 255);
        public SolidBrush BrushDrawingSurface = new SolidBrush(Color.FromArgb(219, 235, 255));
        private Point curPoint;
        private int maxY = 0,maxX=0;
        Dictionary<ActivityConfig.ACSeriesRow, string> FlowGrid = new Dictionary<ActivityConfig.ACSeriesRow, string>();

        internal Dictionary<string, int> Lanes = new Dictionary<string, int>();

        //JLL: changed from private to public so diagram exposes series row to verify if acseries is part of workflow when drawing activity at Activity.cs Refresh method
        public lmDatasets.ActivityConfig.SeriesRow mySeries;

        public Diagram(Graphics g,ActivityConfig.ACSeriesRow initialStep)
        {
            mySeries = initialStep.SeriesRow;
            drawingSurface = g;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;


            drawingSurface.Clear(drawingSurfaceBGColor);
            
            curPoint = new Point(100, 10);
            BFConverter.Init();

            if (initialStep != null)
            {
                AddStep(initialStep);
            }
        }

        public Diagram(Graphics g)
        {
            drawingSurface = g;

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            BFConverter.Init();

        }

        
        public void Draw( ActivityConfig.SeriesRow workflow)
        {   
            mySeries = workflow;

            Reset();

            curPoint = new Point(10, 30);
            maxX = 0;
            maxY = 0;
            int countOfStarts = 0;
            foreach (lmDatasets.ActivityConfig.ACSeriesRow acs in workflow.GetACSeriesRows())
            {
                if (HideObsolete & acs.Obsolete)
                {}
                else
                {

                    bool isStart = UIHelper.AtMng.acMng.GetACSeries().IsStart(acs);

                    if (isStart)
                    {
                        Start s1 = new Start(this);
                        myOtherSteps.Add(s1);
                        maxY = countOfStarts;

                        curPoint.Y = maxY * DefaultHeightGap + 30;

                        Point checkAheadPoint = new Point(curPoint.X + DefaultWidthGap+60, curPoint.Y + 27);
                        while(HitStep(checkAheadPoint)!=null)
                        {   
                            countOfStarts++;
                            maxY++;
                            curPoint.Y = maxY * DefaultHeightGap + 30;
                            checkAheadPoint = new Point(curPoint.X + DefaultWidthGap + 60, curPoint.Y + 27);
                        }

                        s1.Draw(curPoint);

                        s1.gridX = maxX;
                        s1.gridY = maxY;

                        curPoint.X = 50;


                        if (!acs.Start)
                            acs.Start = true;

                        AddStep(acs);
                        AddConnector(s1, mySteps[GetStepKey(acs)]);

                        curPoint.X = 10;
                        maxX = 0;

                        if (SelectedStep == null & SelectedConnector == null)
                            SelectStep(mySteps[GetStepKey(acs)]);

                        maxY++;
                        countOfStarts++;
                    }
                    else
                    {
                        //check to see if it is not a start
                        if (acs.Start)
                            acs.Start = false;

                    }
                }
            }
            drawingSurface.Clear(drawingSurfaceBGColor);
            Refresh();
            
        }

      
        public string GetStepKey(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            if (acs.SeriesId != mySeries.SeriesId)
                return "s" + acs.SeriesId.ToString();
            else
                return "a" + acs.ACSeriesId.ToString();
        }
        private string GetStepKey(lmDatasets.ActivityConfig.SeriesRow sr)
        {
            return "s" + sr.SeriesId.ToString();
        }
        public string GetNextStepKey(lmDatasets.ActivityConfig.ACDependencyRow acd)
        {
            if (acd.ACSeriesRowByPreviousSteps.SeriesId != mySeries.SeriesId)
                return "s" + acd.ACSeriesRowByPreviousSteps.SeriesId.ToString();
            else
                return "a" + acd.NextStepId.ToString();
        }
        public string GetCurrentStepKey(lmDatasets.ActivityConfig.ACDependencyRow acd)
        {
            if (acd.ACSeriesRowByNextSteps.SeriesId != mySeries.SeriesId)
                return "s" + acd.ACSeriesRowByNextSteps.SeriesId.ToString();
            else
                return "a" + acd.CurrentStepId.ToString();
        }
        public void AddConnector(lmDatasets.ActivityConfig.ACDependencyRow acd)
        {
            if (!myConnectors.ContainsKey(acd.ACDependencyId))
            {
                Step s1 = mySteps[GetCurrentStepKey( acd)];
                Step s2 = mySteps[GetNextStepKey( acd)];

                Connector c = null;

                switch ((atriumBE.ConnectorType)acd.LinkType)
                {
                    case atriumBE.ConnectorType.Auto:
                        c = new Auto(this, acd);
                        break;
                    case atriumBE.ConnectorType.NextStep:
                        c = new NextStep(this, acd);
                        break;
                    case atriumBE.ConnectorType.Transfer:
                        c = new Transfer(this, acd);
                        break;
                    case atriumBE.ConnectorType.Enable:
                        c = new Enable(this, acd);
                        break;
                    case atriumBE.ConnectorType.Disable:
                        c = new Disable(this, acd);
                        break;
                    case atriumBE.ConnectorType.BFOnly:
                        c = new BFOnly(this, acd);
                        break;
                    case atriumBE.ConnectorType.Answer:
                        c = new Answer(this, acd);
                        break;
                    case atriumBE.ConnectorType.Reply:
                        c = new Reply(this, acd);
                        break;
                    case atriumBE.ConnectorType.ReplyAll:
                        c = new ReplyAll(this, acd);
                        break;
                    case atriumBE.ConnectorType.Forward:
                        c = new Forward(this, acd);
                        break;
                    case atriumBE.ConnectorType.Obsolete:
                        c = new Obsolete(this,acd);
                        break;
                }

                c.Draw(s1, s2);
                if (SelectedConnector != null)
                {
                    if (SelectedConnector.myACD.ACDependencyId==acd.ACDependencyId)
                        SelectConnector(c);
                }

                myConnectors.Add(acd.ACDependencyId, c);

            }
        }

        private void AddConnector(Step s1, Step s2)
        {
            Connector c = new NextStep(this, null);
            myOtherConnectors.Add(c);
            c.Draw(s1, s2);
        }


        
        public void AddStep(lmDatasets.ActivityConfig.ACSeriesRow acs)
        {
            curPoint.Y = maxY * DefaultHeightGap + 30;
            if (!mySteps.ContainsKey(GetStepKey(acs)))
            {
                Point p = new Point(curPoint.X + 20, curPoint.Y + 27);
                
                

                if (HitStep(p) != null)
                {
                    maxY++;
                    curPoint.Y = maxY * DefaultHeightGap + 30;
                }

                if(!Lanes.ContainsKey("y"+maxY.ToString()))
                {
                    Lanes.Add("y" + maxY.ToString(), 0);
                    Lanes.Add("yp" + maxY.ToString(), 0);
                }
                if (!Lanes.ContainsKey("x" + maxX.ToString()))
                {
                    Lanes.Add("x" + maxX.ToString(), 0);
                    Lanes.Add("xp" + maxX.ToString(), 0);
                }

                bool incY = false;
           
                Step s = null;
               
                switch ((atriumBE.StepType)acs.StepType)
                {
                    case atriumBE.StepType.Form:
                    case atriumBE.StepType.Action:
                    case atriumBE.StepType.Rule:
                    case atriumBE.StepType.Activity:
                        s = new Activity(this, acs);
                        break;
                    case atriumBE.StepType.NonRecorded:
                        s = new NonRecorded(this, acs);
                        break;
                    case atriumBE.StepType.Decision:
                        s = new Decision(this, acs);
                        break;
                    case atriumBE.StepType.Branch:
                        s = new Branch(this, acs);
                        break;
                    case atriumBE.StepType.Merge:
                        s = new Wait(this, acs);
                        break;
                    case atriumBE.StepType.Subseries:
                        s = new SubProcess(this, acs);
                        break;
                    case atriumBE.StepType.Move:
                        s = new Move(this, acs);
                        break;
                    case atriumBE.StepType.Convert:
                        s = new Convert(this,acs);
                        break;
                    default:
                        s = new NonRecorded(this, acs);
                        break;
                }
                
                s.gridX = maxX;
                s.gridY = maxY;

                if (SelectedStep != null)
                {
                    if (SelectedStep.myACS.ACSeriesId == acs.ACSeriesId)
                        SelectStep(s);
                }
                mySteps.Add(GetStepKey(acs), s);
                s.Draw(curPoint);

                
                    
                if ( acs.GetACDependencyRowsByNextSteps().Length == 0)
                {
                    if ((atriumBE.StepType)acs.StepType == atriumBE.StepType.Activity | (atriumBE.StepType)acs.StepType == atriumBE.StepType.NonRecorded || (atriumBE.StepType)acs.StepType == atriumBE.StepType.Subseries || (atriumBE.StepType)acs.StepType == atriumBE.StepType.Move || (atriumBE.StepType)acs.StepType == atriumBE.StepType.Convert)
                    {
                        if (acs.Finish != UIHelper.AtMng.acMng.GetACSeries().IsFinish(acs))
                            acs.Finish = UIHelper.AtMng.acMng.GetACSeries().IsFinish(acs);

                        bool isASubEnaDisLink = false;
                        
                        foreach (ActivityConfig.ACDependencyRow acdep in acs.GetACDependencyRowsByPreviousSteps())
                        {
                            if (acdep.LinkType == (int)atriumBE.ConnectorType.Disable || acdep.LinkType == (int)atriumBE.ConnectorType.Enable || acdep.LinkType == (int)atriumBE.ConnectorType.Transfer)
                            {
                                isASubEnaDisLink = true;
                                return;
                            }
                        }

                        if (!isASubEnaDisLink)
                        {
                            curPoint.X += 166;
                            maxX++;
                            Finish s1 = new Finish(this);
                            s1.gridX = maxX;
                            s1.gridY = maxY;

                            myOtherSteps.Add(s1);
                            s1.Draw(curPoint);

                            AddConnector(s, s1);

                            curPoint.X -= 166;
                            maxX--;
                        }
                    }
                }
                else
                {
                    
                    curPoint.X += DefaultWidthGap;
                    maxX++;

                    
                    if (acs.Finish != UIHelper.AtMng.acMng.GetACSeries().IsFinish(acs))
                        acs.Finish = UIHelper.AtMng.acMng.GetACSeries().IsFinish(acs);

                    lmDatasets.ActivityConfig acdb = (lmDatasets.ActivityConfig)acs.Table.DataSet;
                    lmDatasets.ActivityConfig.ACDependencyRow[] acdrs =(lmDatasets.ActivityConfig.ACDependencyRow[]) acdb.ACDependency.Select("CurrentStepid="+acs.ACSeriesId.ToString(),"Seq");
                    foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in acdrs)
                    {
                       
                        bool okToAdd = true;
                        if (HideObsolete & (atriumBE.ConnectorType)acdr.LinkType == atriumBE.ConnectorType.Obsolete)
                            okToAdd = false;

                        if (!DrawEnableDisableLinkConnectors && (acdr.LinkType == (int)atriumBE.ConnectorType.Enable || acdr.LinkType == (int)atriumBE.ConnectorType.Disable || acdr.LinkType == (int)atriumBE.ConnectorType.Transfer))
                            okToAdd = false;
                        
                        if(okToAdd)
                        {
                            AddStep(acdr.ACSeriesRowByPreviousSteps);
                            AddConnector(acdr);
                        }
                    }
                    //curPoint.Y -= (DefaultHeightGap * addCount);
                    curPoint.X -= DefaultWidthGap;
                    //maxY = maxY - addCount;
                    maxX--;
                }
            }

            if (curPoint.X > imgWidth)
                imgWidth = curPoint.X;
            if (curPoint.Y > imgHeight)
                imgHeight = curPoint.Y;
        }

        public void SaveAsImg(string file)
        {
            Bitmap bmp = new Bitmap(imgWidth + DefaultWidthGap, imgHeight + DefaultHeightGap);
            
           
            Graphics origG = drawingSurface;
            
            drawingSurface = Graphics.FromImage(bmp);
            drawingSurface.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            drawingSurface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            drawingSurface.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            
            Color ctemp = drawingSurfaceBGColor;
            drawingSurfaceBGColor = Color.White;

            Refresh();

            
            bmp.Save(file);//, System.Drawing.Imaging.ImageFormat.Tiff);

            drawingSurface=origG;
            drawingSurfaceBGColor = ctemp;

            Refresh();
        }


        public void Refresh()
        {
            try
            {
                drawingSurface.Clear(drawingSurfaceBGColor);
                foreach (Connector c in myConnectors.Values)
                {
                    c.Refresh();
                }
                foreach (Connector c in myOtherConnectors)
                {
                    c.Refresh();
                }
                foreach (Step s in myOtherSteps)
                {
                    s.Refresh();
                }
                foreach (Step s in mySteps.Values)
                {
                    s.Refresh();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void Reset()
        {
            myConnectors.Clear();
            mySteps.Clear();
            myOtherConnectors.Clear();
            myOtherSteps.Clear();

            SelectedStep = null;
            SelectedConnector = null;
            Lanes.Clear();
            FlowGrid.Clear();
        }


        public Step StartHitStep(Point p)
        {
            for (int i = 0; i < myOtherSteps.Count; i++)
            {
                if (myOtherSteps[i].HitTest(p))
                    return myOtherSteps[i];
            }
            return null;
        }

        public Step HitStep(Point p)
        {
            foreach(Step s in mySteps.Values)
            {
                if (s.HitTest(p))
                    return s;
            }
            return null;
        }

        public Connector HitConnector(Point p)
        {
            foreach (Connector s in myConnectors.Values)
            {
                if (s.HitTest(p))
                    return s;
            }
            return null;
        }

        public Start HitStart(Point p)
        {
            
            foreach (Step s in myOtherSteps)
            {
                if (s.GetType() == typeof(Workflow.Start) && s.HitTest(p))
                {
                    Start st = (Start)s;
                    return st;
                }
            }
            return null;
        }

        public void SelectStep(Step s)
        {
            ClearSelectedObject();

            SelectedStep = s;
            SelectedStep.IsSelected = true;
            SelectedStep.Refresh();
        }
        public void SelectConnector(Connector c)
        {
            ClearSelectedObject();

            SelectedConnector = c;
            SelectedConnector.IsSelected = true;
            SelectedConnector.Refresh();
        }
        public  void ClearSelectedObject()
        {
            if (SelectedStep != null)
            {
                SelectedStep.IsSelected = false;
                SelectedStep.Refresh();
            }
            SelectedStep = null;
            if (SelectedConnector != null)
            {
                SelectedConnector.IsSelected = false;
                SelectedConnector.Refresh();
            }
            SelectedConnector = null; ;
        }

        //private void AddSubProcess(lmDatasets.ActivityConfig.ACSeriesRow acs)
        //{
        //    //drill down to find another process
        //    //or a link back into this one
        //    //

        //    foreach (lmDatasets.ActivityConfig.ACSeriesRow acse in acs.SeriesRow.GetACSeriesRows())
        //    {
        //        foreach (lmDatasets.ActivityConfig.ACDependencyRow acd in acse.GetACDependencyRowsByNextSteps())
        //        {
        //            if (acd.ACSeriesRowByPreviousSteps.SeriesId != acse.SeriesId && acd.ACSeriesRowByPreviousSteps.SeriesId!=mySeries.SeriesId)
        //            {
        //                //add process
        //                //
        //                curPoint.X += 275;
        //                maxX++;

        //                if (!mySteps.ContainsKey(GetStepKey(acd.ACSeriesRowByPreviousSteps)))
        //                {
        //                    Step s = new SubProcess(this, acd.ACSeriesRowByPreviousSteps);
        //                    mySteps.Add(GetStepKey(acd.ACSeriesRowByPreviousSteps), s);
        //                    s.Draw(curPoint);
        //                    s.gridX = maxX;
        //                    s.gridY = maxY;
        //                    // and drill
        //                    // down

        //                    AddSubProcess(acd.ACSeriesRowByPreviousSteps);

        //                }
        //                AddConnector(acd);
        //                curPoint.X -= 275;
        //                maxX--;

        //            }
        //            else
        //            {
        //                curPoint.X += 275;
        //                maxX++;

        //                AddStep(acd.ACSeriesRowByPreviousSteps);

        //                AddConnector(acd);
        //                curPoint.X -= 275;
        //                maxX--;

        //            }
        //        }
        //    }
        //}
    }
}
