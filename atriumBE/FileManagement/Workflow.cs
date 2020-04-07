using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using lmDatasets;
using atLogic;
using atriumBE.Properties;



namespace atriumBE
{

    public class NextStep
    {
        public ActivityConfig.ACSeriesRow acs;
        public string LinkText = "";
        public atriumDB.ActivityRow prevAc;
        public CurrentFlow Children;
        public bool Enabled = true;
        public bool Paused = false;
        public Stack<ParentChildStep> FlowQ = null;
    }
    public class CurrentFlow
    {
        public atriumDB.ProcessRow Process;
        public ActivityConfig.SeriesRow Series;
        public bool NewSeries = false;
        //create collection of next steps
        //public List<ActivityConfig.ACSeriesRow> NextSteps = new List<ActivityConfig.ACSeriesRow>();
        public Dictionary<int, NextStep> NextSteps = new Dictionary<int, NextStep>();

    }

    public class AvailableSeries
    {
        public ActivityConfig.SeriesRow Series;
        public Dictionary<int, NextStep> FirstSteps = new Dictionary<int, NextStep>();
    }

    public class Workflow
    {
        FileManager myFM;

        Dictionary<int, int> fileProcesses = new Dictionary<int, int>();
        Dictionary<int, int> activeProcesses = new Dictionary<int, int>();
        CurrentFlow currentAP;
        CurrentFlow topAP;
        Dictionary<int, CurrentFlow> currentFlows;
        Stack<ParentChildStep> flowQ;

        internal Workflow(FileManager fm)
        {
            myFM = fm;

        }


        public FileManager FM
        {
            get { return myFM; }
        }

        public Dictionary<int, CurrentFlow> NextSteps()
        {
            flowQ = null;
            currentFlows = new Dictionary<int, CurrentFlow>();

            //follow each active process on file
            //ignore turned-off processes
            foreach (atriumDB.ProcessRow pr in myFM.DB.Process.Select("(Active=1 or active=0) and fileid="+ myFM.CurrentFile.FileId.ToString(),"EntryDate,ProcessId")) //
            {
                CurrentFlow ap = NextSteps(pr);

                if (pr.Active)// & || ap.NextSteps.Count > 0
                    currentFlows.Add(pr.ProcessId, ap);

                BuildOKToAdd(ap);
            }
            return currentFlows;
        }

        private void BuildOKToAdd(CurrentFlow ap)
        {
            foreach (NextStep ns1 in ap.NextSteps.Values)
            {
                NextStep ns = SillyQuestion(ns1);

                StepType st = (StepType)ns.acs.StepType;


                if (st == StepType.Activity)
                {

                    if (ns.Enabled)
                        FM.CurrentActivityProcess.AcSeriesOKToAdd.Add(ns.acs);
                }
                if (ns.Children != null)
                    BuildOKToAdd(ns.Children);
                
            }
        }
        public NextStep SillyQuestion(NextStep ns)
        {

            return SillyQuestion(ns, FM);

            //StepType st = (StepType)ns.acs.StepType;

            ////check for silly question
            //if (st == StepType.Decision && ns.acs.GetActivityFieldRows().Length > 0)
            //{
            //    NextStep answer = null;
            //    ACEngine sillyEngine = new ACEngine(FM);
            //    bool isTrue = sillyEngine.SillyQuestion(ns.acs);
            //    //find right path
            //    foreach (NextStep a1 in ns.Children.NextSteps.Values)
            //    {
            //        if (isTrue && (a1.LinkText.StartsWith("Yes") || a1.LinkText.StartsWith("Oui")))
            //        {
            //            answer = a1;

            //            break;
            //        }
            //        else if (!isTrue && (a1.LinkText.StartsWith("No") || a1.LinkText.StartsWith("Non")))
            //        {
            //            answer = a1;

            //            break;

            //        }
            //    }


            //    //follow it
            //    if (answer.Children != null)
            //        return SillyQuestion(answer);
            //    else
            //        return answer;
            //}
            //return ns;
        }
        //not used CJW 2014-2-19
        //public Dictionary<int, CurrentFlow> NextSteps(atriumDB.ActivityRow ar)
        //{
        //    currentFlows = new Dictionary<int, CurrentFlow>();

        //    atriumDB.ProcessRow pr = ar.ProcessRow;

        //    CurrentFlow ap = NextSteps(pr);

        //    if (ap.NextSteps.Count > 0)
        //        currentFlows.Add(pr.ProcessId, ap);

        //    return currentFlows;
        //}

        private CurrentFlow NextSteps(atriumDB.ProcessRow pr)
        {
            flowQ = null;
            fileProcesses.Clear();
            activeProcesses.Clear();
            foreach (atriumDB.ProcessRow pr1 in myFM.CurrentFile.GetProcessRows())
            {
                fileProcesses.Add(pr1.ProcessId, pr1.SeriesId);
                if (pr1.Active)
                    activeProcesses.Add(pr1.ProcessId, pr1.SeriesId);
            }

            if (pr == null)
                throw new Exception("Activity process is null.  Contact the system administrator");

            CurrentFlow ap;
            if (!pr.Active)//& currentFlows.Count>0
            {
                atriumDB.ProcessRow prparent=FM.GetProcess().ParentProcess(pr,true);
                if (prparent == null)
                {
                    ap = new CurrentFlow();
                    ap.Process = pr;
                }
                else
                    ap = currentFlows[prparent.ProcessId];
            }
            else 
            {
                ap=  new CurrentFlow();
                ap.Process = pr;
            }
            topAP = ap;
            currentAP = ap;

            foreach (atriumDB.ActivityRow ar in pr.GetActivityRows())
            {
                ActivityConfig.ACSeriesRow asr = myFM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(ar.ACSeriesId);
                NextSteps(currentAP, asr, ar);

                /*
                foreach (ActivityConfig.ACDependencyRow acdr in asr.GetACDependencyRowsByPreviousSteps())
                {
                    //do not remove step if it was enabled
                    if (!acdr.Enable & ap.NextSteps.Contains(acdr.ACSeriesRowByPreviousSteps))
                        ap.NextSteps.Remove(acdr.ACSeriesRowByPreviousSteps);
                }
                */

            }

            //a bit of a kluge
            //check for branch only and remove
            int removeid=0;
            foreach (NextStep ns in ap.NextSteps.Values)
            {
                if (ns.acs.StepType == (int)StepType.Branch && ns.Children.NextSteps.Count == 0)
                    removeid = ns.acs.ACSeriesId;
                    
            }
            if(removeid!=0)
                ap.NextSteps.Remove(removeid);

            return ap;
        }

        private void NextSteps(CurrentFlow ap, ActivityConfig.ACSeriesRow asr, atriumDB.ActivityRow prevAc)
        {
            if (asr == null)
                return;

            //remove current step
            if (ap.NextSteps.ContainsKey(asr.ACSeriesId))
            {
                if ((StepType)ap.NextSteps[asr.ACSeriesId].acs.StepType == StepType.Activity || (StepType)ap.NextSteps[asr.ACSeriesId].acs.StepType == StepType.NonRecorded)
                    ap.NextSteps.Remove(asr.ACSeriesId);
            }


//            if (asr.GetACDependencyRowsByNextSteps().Length == 0) merged on may 9 2014
            ActivityConfig.ACDependencyRow[] acds = (ActivityConfig.ACDependencyRow[])FM.AtMng.acMng.DB.ACDependency.Select("LinkType  in (0,4,8) and CurrentStepID=" + asr.ACSeriesId.ToString());
            if (asr.StepType != (int)StepType.NonRecorded && acds.Length == 0)
            {
                ActivityConfig.ACSeriesRow acss = FM.GetActivity().FindParentStep(prevAc);

                //check for bf completion?
                //should we use the step before this?
                if (acss != null)
                {
                    //foreach (ActivityConfig.ACDependencyRow acdr in acss.GetACDependencyRowsByNextSteps())
                    //TFS#53658 CJW 2013-09-16 
                    foreach (ActivityConfig.ACDependencyRow acdr in FM.AtMng.acMng.DB.ACDependency.Select("CurrentStepID=" + acss.ACSeriesId.ToString(), "Seq"))
                    {

                        bool add1 = true;
                        if (!acdr.IsACBFIdNull())
                        {
                            atriumDB.ActivityBFRow[] abfr = (atriumDB.ActivityBFRow[])myFM.DB.ActivityBF.Select("Activityid=" + prevAc.ActivityId.ToString() + "and ACDepId=" + acdr.ACDependencyId + " and ACBFId=" + acdr.ACBFId.ToString());
                            if (abfr.Length > 0)
                            {
                                //if (abfr[0].ActivityRow.ACSeriesId == acdr.CurrentStepId)
                                //{
                                if (abfr[0].Completed)
                                    add1 = false;
                                //}
                            }
                            else
                            {
                                //TFS#54408 CJW 2013-09-16 don't add next step if precursor bf is not on file
                                add1 = false;
                            }

                        }
                        if (add1)
                            NextSteps(ap, acss, prevAc);

                    }
                }

            }
            else
            {
                //add  next steps
                //foreach (ActivityConfig.ACDependencyRow acdr in asr.GetACDependencyRowsByNextSteps())
                //TFS#53658 CJW 2013-09-16 
                foreach (ActivityConfig.ACDependencyRow acdr in FM.AtMng.acMng.DB.ACDependency.Select("CurrentStepID="+asr.ACSeriesId.ToString(),"Seq"))
                {
                    ActivityConfig.ACSeriesRow nextStep = acdr.ACSeriesRowByPreviousSteps;

                    NextSteps(nextStep, ap, prevAc, acdr);
                }
            }

        }

        private void NextSteps(ActivityConfig.ACSeriesRow nextStep, CurrentFlow ap, atriumDB.ActivityRow prevAc, ActivityConfig.ACDependencyRow acdr)
        {
            bool add = true;
          
            bool pause = false;

            //do not add step if it is not a next step or answer
            if (acdr.LinkType != (int)ConnectorType.NextStep & acdr.LinkType != (int)ConnectorType.Answer)
                add = false;

            //check filetype rule
        
                if (!AllowForFileType(nextStep,myFM))
                    add = false;
            //}

            //do not add step if it is a disable link
            //if (acdr.LinkType==(int)ConnectorType.Disable)
            //    add = false;


            //if ((StepType)nextStep.StepType == StepType.Activity)
            //{
            //check role
            bool    enable = IsEnabled(nextStep);
            if (acdr.LinkType == (int)ConnectorType.Enable)
            {
                //exclude processes that violate instance rules - onceperfile,singleinstanceperfile
                ActivityConfig.SeriesRow sr = nextStep.SeriesRow;
                if (sr.OncePerFile & fileProcesses.ContainsValue(sr.SeriesId))
                    add = false;

                if (sr.SingleInstancePerFile & activeProcesses.ContainsValue(sr.SeriesId))
                    add = false;

            }

            //do not add steps from an exclusive switch if we have taken one path
            //this gets handled by the bf rule if there is a bf
            //do not add step if bf to it is completed
            //
            if (prevAc !=null && !acdr.IsACBFIdNull())
            {
                atriumDB.ActivityBFRow[] abfr = (atriumDB.ActivityBFRow[])myFM.DB.ActivityBF.Select("Activityid=" + prevAc.ActivityId.ToString() + "and ACDepId=" + acdr.ACDependencyId + " and ACBFId=" + acdr.ACBFId.ToString());

                if (abfr.Length > 0)
                {
                    if (abfr[0].Completed)
                        add = false;
//need to find a better more flexible mechanism than '100 days'
//                    else if (abfr[0].BFDate > DateTime.Today.AddDays(100))
//                        add = false;
                }
                else
                {
                    //TFS#54408 CJW 2013-09-16 don't add next step if precursor bf is not on file
                    //TODO: maybe we don't need this here after all?
                    //may be we do!!!!!!!!!!!!!!!!!!
                    add = false;
                }
            }

            //check to see if process is paused
            if (prevAc != null && prevAc.ProcessRow.Paused)
                pause = true;

            //?do not add step if it is unique in process and has been done already?
            if (ap.Process != null && nextStep.OnceOnly & myFM.DB.Activity.Select("ProcessID=" + ap.Process.ProcessId.ToString() + " and ACSeriesID=" + acdr.NextStepId.ToString()).Length > 0)
                add = false;

            if (add)
            {
                NextStep ns = new NextStep();

                if (!acdr.IsDescEngNull())
                {
                    //if it is the first step in a subprocess don't add the link text
                    if (!nextStep.Start)
                        ns.LinkText = acdr["Desc"+myFM.AppMan.Language] + ": ";
                }
                ns.acs = nextStep;
                ns.prevAc = prevAc;
                ns.Enabled = enable;
                ns.Paused = pause;
                if (ns.Paused)
                    ns.Enabled = false;
                if (flowQ != null)
                    ns.FlowQ = new Stack<ParentChildStep>(flowQ);

                bool merged = false;
                if (ap.NextSteps.ContainsKey(ns.acs.ACSeriesId))
                {
              
                    currentAP = topAP;
                    merged = true;
              
                }
                else
                    ap.NextSteps.Add(ns.acs.ACSeriesId, ns);

                if (ap.NextSteps.Count == 1)
                    ap.Series = ns.acs.SeriesRow;

                if (ap.Process!=null && ap.Process.SeriesId != ap.Series.SeriesId)
                    ap.NewSeries = true;

                if ((StepType)ns.acs.StepType != StepType.Activity)
                {
                    CurrentFlow apNew = new CurrentFlow();
                    apNew.Process = ap.Process;
                    ns.Children = apNew;
                    if (nextStep.StepType == (int)StepType.Branch)
                        currentAP = apNew;

                    if ((StepType)ns.acs.StepType == StepType.Subseries)
                    {
                        if (flowQ == null)
                            flowQ = new Stack<ParentChildStep>();
                        //apNew.Process = null;

                        //drill into sub process
                        //find start ac series
                        //
                        lmDatasets.ActivityConfig.ACSeriesRow subStart = null;

                        //CJW 2013-6-18 added obsolete = false see PITS#41039
                        subStart = (lmDatasets.ActivityConfig.ACSeriesRow)FM.AtMng.acMng.DB.ACSeries.Select("Start = true and obsolete= false and SeriesID=" + ns.acs.SubseriesId.ToString())[0];

                        ParentChildStep pcs = new ParentChildStep();
                        pcs.ParentStep = ns.acs;
                        pcs.ChildStep = subStart.SeriesRow;

                        flowQ.Push(pcs);

                        NextSteps(subStart, apNew, prevAc, acdr);

                        flowQ.Pop();

                        if (apNew.NextSteps.Count == 0)
                        {
                            //sub process is complete
                            //goto next step from subseries
                            NextSteps(apNew, nextStep, prevAc);
                        }
                        else
                        {
                            //sub process is active
                        }
                    }
                    else
                    {
                        //drilldown thru flow-tree
                        if (ns.acs.StepType == (int)StepType.Merge)
                        {
                            //check to see if the merge condition is met
                            if (merged)
                            {
                                ap.NextSteps.Clear();
                          
                                NextSteps(ap, nextStep, prevAc);
                            }
                          
                        }
                        else
                        {
                            NextSteps(apNew, nextStep, prevAc);
                            currentAP = topAP;
                        }
                    }
                }

            }
        }

        private bool IsEnabled(ActivityConfig.ACSeriesRow nextStep )
        {
            bool enable=true;

            //JLL 2018-04-23
            //if (myFM.AtMng.SecurityManager.CanOverride(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
            //    return enable;

            if (!nextStep.IsRoleCodeNull())
            {
                if (!myFM.AtMng.OfficeMng.GetOfficer().IsInRole(nextStep.RoleCode) & !myFM.GetFileContact().IsInRole(nextStep.RoleCode))
                    enable = false; ;
            }

            if (enable & (nextStep.ForAgent | nextStep.ForClient | nextStep.ForLead | nextStep.ForOwner))
            {
                //get fileoffice row
                lmDatasets.atriumDB.FileOfficeRow[] fos = (lmDatasets.atriumDB.FileOfficeRow[])myFM.DB.FileOffice.Select("Fileid=" + myFM.CurrentFile.FileId.ToString() + " and OfficeId=" + myFM.AtMng.WorkingAsOfficer.OfficeId.ToString());
                if (fos.Length != 1)
                    enable = false;
                else
                {
                    lmDatasets.atriumDB.FileOfficeRow fo = fos[0];
                    //check isowner etc.
                    enable = false;
                    if (nextStep.ForOwner & fo.IsOwner)
                    {
                        enable = true;
                    }
                    if (nextStep.ForLead & fo.IsLead)
                    {
                        enable = true;
                    }
                    if (nextStep.ForClient & fo.IsClient)
                    {
                        enable = true;
                    }
                    if (nextStep.ForAgent & fo.IsAgent)
                    {
                        enable = true;
                    }
                }
            }
            return enable;
        }

        public Dictionary<int, CurrentFlow> EnabledProcesses()
        {
            //create collection of available Processes
            Dictionary<int, CurrentFlow> enabledProcesses = new Dictionary<int, CurrentFlow>();

            fileProcesses.Clear();
            activeProcesses.Clear();
            foreach (atriumDB.ProcessRow pr in myFM.CurrentFile.GetProcessRows())
            {
                fileProcesses.Add(pr.ProcessId, pr.SeriesId);
                if (pr.Active)
                    activeProcesses.Add(pr.ProcessId, pr.SeriesId);
            }


            //go through activities on file in seq
            foreach (atriumDB.ActivityRow ar in FM.DB.Activity.Select("", "ActivityID"))
            {
                ActivityConfig.ACSeriesRow acs = FM.GetActivity().GetACSeriesRow(ar);
              
                //go through this acseries next steps to see if they enable or disable a process
                foreach (ActivityConfig.ACDependencyRow acdr in acs.GetACDependencyRowsByNextSteps())
                {
                    if (acdr.ACSeriesRowByPreviousSteps.StepType == (int)StepType.Subseries && (acdr.LinkType == (int)ConnectorType.Enable | acdr.LinkType == (int)ConnectorType.Transfer | acdr.LinkType == (int)ConnectorType.Disable))
                    {
                        //the link is to a subprocess
                        bool add = true;
                        ActivityConfig.SeriesRow sr = FM.AtMng.acMng.DB.Series.FindBySeriesId(acdr.ACSeriesRowByPreviousSteps.SubseriesId);
                        
                        CurrentFlow enabledSeries;
                        if (enabledProcesses.ContainsKey(sr.SeriesId))
                        {
                            enabledSeries = enabledProcesses[sr.SeriesId];

                        }
                        else
                        {
                            enabledSeries = new CurrentFlow();

                            enabledSeries.Series = sr;
                        }
                        
                        //exclude processes that violate instance rules - onceperfile,singleinstanceperfile
                        if (sr.OncePerFile & fileProcesses.ContainsValue(sr.SeriesId))
                            add = false;

                        if (sr.SingleInstancePerFile & activeProcesses.ContainsValue(sr.SeriesId))
                            add = false;

                        if (add)
                        {
                            ActivityConfig.ACSeriesRow[] seriesSteps =(ActivityConfig.ACSeriesRow[]) FM.AtMng.acMng.DB.ACSeries.Select("Seriesid=" + sr.SeriesId.ToString(), "seq,stepcode");
                            foreach (ActivityConfig.ACSeriesRow acsr in seriesSteps)
                            {
                                atriumDB.ActivityRow arp = null;
                                bool addstep = false;
                                if (acsr.Start)
                                {

                                    if (acdr.LinkType == (int)ConnectorType.Enable)
                                    {
                                        //need to track parent process here
                                        addstep = true;
                                    }
                                    if (acdr.LinkType == (int)ConnectorType.Transfer )
                                    {
                                        //need to track parent process here
                                        addstep = true;
                                        arp = ar;
                                        if (!fileProcesses.ContainsKey(arp.ProcessId))
                                            arp = null;
                                    }
                                    if (acdr.LinkType == (int)ConnectorType.Disable)
                                    {
                                        //need to track parent process here
                                        addstep = false;

                                        //remove next step
                                        if (enabledSeries.NextSteps.ContainsKey(acsr.ACSeriesId))
                                        {
                                            enabledSeries.NextSteps.Remove(acsr.ACSeriesId);
                                        }
                                        //remove series
                                        if (enabledProcesses.ContainsKey(sr.SeriesId))
                                        {
                                            enabledProcesses.Remove(sr.SeriesId);
                                        }
                                    }
                                    if (addstep)
                                    {
                                        //check filetype rule
                                        //addstep = AllowForFileType(acsr,myFM);
                                        addstep = Allowed(acsr, myFM.AtMng, myFM);
                                    }

                                    //if ok add
                                    if (addstep && !enabledSeries.NextSteps.ContainsKey(acsr.ACSeriesId))
                                    {
                                        NextStep ns = new NextStep();
                                        ns.acs = acsr;
                                        ns.Enabled = IsEnabled(acsr);
                                        if (arp == null)
                                            ns.prevAc = null;
                                        else
                                            ns.prevAc = arp;

                                        enabledSeries.NextSteps.Add(acsr.ACSeriesId, ns);

                                        //recurse check for next steps
                                        if (acsr.StepType != (int)StepType.Activity && acsr.GetACDependencyRowsByNextSteps().Length > 0)
                                        {
                                            CurrentFlow newFlow = new CurrentFlow();
                                            newFlow.Series = acsr.SeriesRow;
                                            ns.Children = newFlow;
                                            NextSteps(newFlow, acsr, arp);
                                        }
                                    }

                                }
                            }
                        }
                        if (enabledSeries.NextSteps.Count > 0 && !enabledProcesses.ContainsKey(sr.SeriesId))
                        {
                            
                            enabledProcesses.Add(sr.SeriesId, enabledSeries);
                        }
                    }
                        
                }
            }
            foreach (CurrentFlow ap in enabledProcesses.Values)
            {
                BuildOKToAdd(ap);
            }
            return enabledProcesses;
        }

        public Dictionary<int, CurrentFlow> EnabledProcesses2()
        {
            //create collection of available Processes
            Dictionary<int, CurrentFlow> enabledProcesses = new Dictionary<int, CurrentFlow>();

            fileProcesses.Clear();
            activeProcesses.Clear();
            foreach (atriumDB.ProcessRow pr in myFM.CurrentFile.GetProcessRows())
            {
                fileProcesses.Add(pr.ProcessId, pr.SeriesId);
                if (pr.Active)
                    activeProcesses.Add(pr.ProcessId, pr.SeriesId);
            }


            //go through series table
            //filter it based on file type

            foreach (ActivityConfig.SeriesRow sr in myFM.AtMng.acMng.DB.Series.Select("Obsolete=false", "SeriesDesc" + myFM.AppMan.Language))
            {
                bool add = true;
                CurrentFlow enabledSeries = new CurrentFlow();
                enabledSeries.Series = sr;

                //exclude processes that violate instance rules - onceperfile,singleinstanceperfile
                if (sr.OncePerFile & fileProcesses.ContainsValue(sr.SeriesId))
                    add = false;

                if (sr.SingleInstancePerFile & activeProcesses.ContainsValue(sr.SeriesId))
                    add = false;

                if (add)
                {
                    //look for sub series steps
                    ActivityConfig.ACSeriesRow[] acss = (ActivityConfig.ACSeriesRow[])FM.AtMng.acMng.DB.ACSeries.Select("Subseriesid=" + sr.SeriesId.ToString());
                    //verify that start activity is available
                    foreach (ActivityConfig.ACSeriesRow acsr in sr.GetACSeriesRows())
                    {
                        atriumDB.ActivityRow arp = null;
                        bool addstep = false;
                        if (acsr.Start)
                        {
                            //check dependencies for each sub series step
                            foreach (ActivityConfig.ACSeriesRow acsrs in acss)
                            {
                                foreach (ActivityConfig.ACDependencyRow acdr in acsrs.GetACDependencyRowsByPreviousSteps())
                                {
                                    //see if the previous activity has been done
                                    bool isDone = myFM.DB.Activity.Select("ACSeriesID=" + acdr.CurrentStepId.ToString()).Length > 0;
                                    //check enable link
                                    if (acdr.LinkType == (int)ConnectorType.Enable & isDone)
                                    {
                                        //need to track parent process here
                                        addstep = true;
                                    }

                                    //check transfer link - only if it is working as  enable
                                    //TODO need to check whether enabling activity was in an active process
                                    if (acdr.LinkType == (int)ConnectorType.Transfer & isDone)
                                    {
                                        //need to track parent process here
                                        arp = (atriumDB.ActivityRow)myFM.DB.Activity.Select("ACSeriesID=" + acdr.CurrentStepId.ToString())[0];
                                        if (!activeProcesses.ContainsKey(arp.ProcessId))
                                            arp = null;
                                        addstep = true;
                                    }
                                    //check disable link
                                    if (acdr.LinkType == (int)ConnectorType.Disable & isDone)
                                    {
                                        addstep = false;
                                    }
                                }
                            }

                            if (addstep)
                            {
                                //check filetype rule
                                //addstep = AllowForFileType(acsr,myFM);
                                addstep = Allowed(acsr, myFM.AtMng, myFM);
                            }

                            //if ok add
                            if (addstep)
                            {
                                NextStep ns = new NextStep();
                                ns.acs = acsr;
                                if (arp == null)
                                    ns.prevAc = null;
                                else
                                    ns.prevAc = arp;

                                enabledSeries.NextSteps.Add(acsr.ACSeriesId, ns);

                                //recurse check for next steps
                                if (acsr.StepType != (int)StepType.Activity && acsr.GetACDependencyRowsByNextSteps().Length > 0)
                                {
                                    CurrentFlow newFlow = new CurrentFlow();
                                    newFlow.Series = acsr.SeriesRow;
                                    ns.Children = newFlow;
                                    NextSteps(newFlow, acsr, arp);
                                }
                            }
                        }
                    }

                    if (enabledSeries.NextSteps.Count > 0)
                    {
                        enabledProcesses.Add(sr.SeriesId, enabledSeries);
                    }
                }
            }
            return enabledProcesses;
        }


        public Dictionary<int, CurrentFlow> AvailableProcesses()
        {
            //create collection of available Processes
            Dictionary<int, CurrentFlow> availableProcesses = new Dictionary<int, CurrentFlow>();

            fileProcesses.Clear();
            activeProcesses.Clear();
            foreach (atriumDB.ProcessRow pr in myFM.CurrentFile.GetProcessRows())
            {
                fileProcesses.Add(pr.ProcessId, pr.SeriesId);
                if (pr.Active)
                    activeProcesses.Add(pr.ProcessId, pr.SeriesId);
            }


            //go through series table
            //filter it based on file type

            foreach (ActivityConfig.SeriesRow sr in myFM.AtMng.acMng.DB.Series.Select("Obsolete=false", "SeriesDesc" + myFM.AppMan.Language))
            {
                bool add = true;
                //AvailableSeries availSeries = new AvailableSeries();
                //availSeries.Series = sr;
                CurrentFlow curFlow = new CurrentFlow();
                curFlow.Series = sr;

                //exclude processes that violate instance rules - onceperfile,singleinstanceperfile
                if (sr.OncePerFile & fileProcesses.ContainsValue(sr.SeriesId))
                    add = false;

                if (sr.SingleInstancePerFile & activeProcesses.ContainsValue(sr.SeriesId))
                    add = false;

                if (add)
                {
                    //look for sub series steps
                //    ActivityConfig.ACSeriesRow[] acss = (ActivityConfig.ACSeriesRow[])FM.AtMng.acMng.DB.ACSeries.Select("Subseriesid=" + sr.SeriesId.ToString());
                    //verify that start activity is available
                    ActivityConfig.ACSeriesRow[] seriesSteps = (ActivityConfig.ACSeriesRow[])FM.AtMng.acMng.DB.ACSeries.Select("Seriesid=" + sr.SeriesId.ToString(), "seq,stepcode");
                    foreach (ActivityConfig.ACSeriesRow acsr in seriesSteps)
                    {
                        bool addstep = false;
                        if (acsr.Start)
                        {  

                            if(sr.AlwaysAvailable)
                                addstep = true;

                            if (addstep)
                            {
                                //check filetype rule
                                //addstep = AllowForFileType(acsr,myFM);
                                addstep = Allowed(acsr, myFM.AtMng, myFM);
                            }

                            //if ok add
                            if (addstep)
                            {
                                NextStep ns = new NextStep();
                                ns.acs = acsr;
                                ns.Enabled = IsEnabled(acsr);
                                ns.prevAc = null;
                                curFlow.NextSteps.Add(acsr.ACSeriesId, ns);

                                //recurse check for next steps
                                if (acsr.StepType !=(int)StepType.Activity &&  acsr.GetACDependencyRowsByNextSteps().Length > 0)
                                {
                                   
                                    CurrentFlow newFlow = new CurrentFlow();
                                    newFlow.Series = acsr.SeriesRow;
                                    ns.Children = newFlow;
                                    NextSteps(newFlow, acsr, null);
                                }
                            }
                        }
                    }

                    if (curFlow.NextSteps.Count > 0)
                    {
                        availableProcesses.Add(sr.SeriesId, curFlow);
                    }
                }
            }
            foreach (CurrentFlow ap in availableProcesses.Values)
            {
                BuildOKToAdd(ap);
            }

            return availableProcesses;
        }

        public NextStep SillyQuestion(NextStep ns, FileManager fmCurrent)
        {
            StepType st = (StepType)ns.acs.StepType;

            //check for silly question
            if (st == StepType.Decision && ns.acs.GetActivityFieldRows().Length > 0)
            {
                NextStep answer = null;
                ACEngine sillyEngine = new ACEngine(fmCurrent);
                bool isTrue = sillyEngine.SillyQuestion(ns.acs);
                //find right path
                foreach (NextStep a1 in ns.Children.NextSteps.Values)
                {
                    if (isTrue && (a1.LinkText.StartsWith("Yes") || a1.LinkText.StartsWith("Oui")))
                    {
                        answer = a1;

                        break;
                    }
                    else if (!isTrue && (a1.LinkText.StartsWith("No") || a1.LinkText.StartsWith("Non")))
                    {
                        answer = a1;

                        break;

                    }
                }


                //follow it
                if (answer.Children != null)
                    return SillyQuestion(answer, fmCurrent);
                else
                    return answer;
            }
            return ns;
        }

        private static bool AllowForFileType(ActivityConfig.ACSeriesRow acsr,FileManager fm)
        {
            bool add = true;
            if (acsr.GetACFileTypeRows().Length != 0)
            {
                bool ok = !acsr.AllowFileType;
                foreach (ActivityConfig.ACFileTypeRow acftr in acsr.GetACFileTypeRows())
                {
                    bool ok1 = true, ok2 = true, ok3 = true;

                    if (!acftr.IsFileTypeNull() && acftr.FileType != fm.CurrentFile.FileType)
                    { ok1 = false; }
                    if (!acftr.IsMetaFileTypeNull() && acftr.MetaFileType != fm.CurrentFile.MetaType)
                    { ok2 = false; }
                    if (!acftr.IsFullFileNumberNull() && !fm.CurrentFile.FullFileNumber.StartsWith(acftr.FullFileNumber))
                    { ok3 = false; }

                    if(ok1 &ok2 &ok3)
                        ok=acsr.AllowFileType;

                }
                if (!ok)
                    add = false;
            }
            return add;
          
        }

        public static bool AllowedForRole(ActivityConfig.ACSeriesRow acsr,atriumManager atmng, FileManager fm)
        {

            if (!acsr.IsRoleCodeNull())
            {
                if (atmng.OfficeMng.GetOfficer().IsInRole(acsr.RoleCode) || (fm!=null && fm.GetFileContact().IsInRole(acsr.RoleCode)))
                    return true;
                else
                    return false;

            }
            else
                return true;
            
        }
        public static bool Allowed(ActivityConfig.ACSeriesRow acsr, atriumManager atmng, FileManager fm)
        {
            bool allow = false;

            //check  security
            if (atmng.SecurityManager.CanAdd(fm.CurrentFileId, atSecurity.SecurityManager.Features.Activity) > atSecurity.SecurityManager.ExPermissions.No)
            {
                if (acsr.InitialStep == (int)ACEngine.Step.CreateFile | acsr.InitialStep == (int)ACEngine.Step.PickIssue)
                    allow = fm.CurrentFile.FileMetaTypeRow.AllowSubFiles;
                else
                    allow = fm.CurrentFile.FileMetaTypeRow.AllowActivities;
                return AllowForFileType(acsr, fm) & AllowedForRole(acsr, atmng, fm) & !acsr.Obsolete & allow;
            }
            else
            {
                return false;
            }
        }

    }
}
