using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ProcessBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.ProcessDataTable myProcessDT;

		
		internal ProcessBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.Process)
		{
			myA=pBEMng;
			myProcessDT=(atriumDB.ProcessDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetProcess();
        }

        public atriumDAL.ProcessDAL myDAL
        {
            get
            {
                return (atriumDAL.ProcessDAL)myODAL;
            }
        }
                  
        /// <summary>
        /// Moves a process to another file
        /// </summary>
        /// <param name="pr">process to move</param>
        /// <param name="toFile">Target file</param>
        private void Move(atriumDB.ProcessRow pr, int toFileId,atriumDB.ActivityRow splitOn)
        {

            FileManager toFM = myA.AtMng.GetFile(toFileId);
            //need to check permissions on target file
            if (!toFM.GetProcess().CanAdd(toFM.CurrentFile))
                throw new AtriumException(Properties.Resources.YouNeedAddProcessPermissionOnTheDestinationFile);


            CheckMove(pr);

            //this needs to be here
            myA.GetActivity().LoadByProcessId(pr.ProcessId);

            //sort activities by thread
            atriumDB.ActivityRow[] ars=(atriumDB.ActivityRow[])myA.DB.Activity.Select("processid=" + pr.ProcessId.ToString(), "ConversationIndex");
            atriumDB.ProcessRow newPr = null;
            int oldFileid = pr.FileId;
            bool moveProc = false;
            
            if (splitOn != null && ars.Length>1 && ars[0].ActivityId!=splitOn.ActivityId)
            {
                //create new process for split thread
                newPr = (atriumDB.ProcessRow)Add(myA.CurrentFile);

                newPr.Active = pr.Active;
                //newPr.CurrentStep = pr.CurrentStep;
                newPr.NameE = pr.NameE;
                newPr.NameF = pr.NameF;
                newPr.SeriesId = pr.SeriesId;
                //newPr.Thread = pr.Thread;
                
            }
            else
            {
                pr.FileId = toFileId;

                pr.Thread = pr.ProcessId.ToString();
                moveProc = true;
                foreach (atriumDB.ProcessContextRow pcr in pr.GetProcessContextRows())
                {
                    pcr.FileId = toFileId;
                }
            }

            //move all activties on process
            foreach (atriumDB.ActivityRow par in pr.GetActivityRows())
            {
                if (splitOn == null || par.ConversationIndex.CompareTo(splitOn.ConversationIndex) >= 0)
                {
                    myA.GetActivity()._Move(par, toFileId);

                    if (newPr != null)
                        par.ProcessId = newPr.ProcessId;
                }
            }

            if (moveProc)
            {
                FileManager fmOld = myA.AtMng.GetFile(oldFileid);
                atriumDB.ProcessRow prOld = fmOld.DB.Process.FindByProcessId(pr.ProcessId);
                if (prOld != null)
                {
                    prOld.Delete();
                    prOld.AcceptChanges();
                }
            }

        }

        internal void CheckMove(atriumDB.ProcessRow pr)
        {
            //need to check permissions on current process
            if (!CanDelete(pr))
                throw new AtriumException(Properties.Resources.YouNeedDeletePermissionOnTheProcessToMoveIt);


            //don't move a create file process
            //ActivityConfig.SeriesRow sr = myA.AtMng.acMng.DB.Series.FindBySeriesId(pr.SeriesId);
            //if(!sr.AllowMove)

            //if (sr.CreatesFile)
            //    throw new AtriumException("You can't move an activity on a process that creates the file.");

            //don't move a process that is threaded - ie a child process
                //if (pr.Thread.Contains("-"))
                //    throw new AtriumException("You cannot move an activity that is on a process directly related to another process.");

                ////don't move a process that has child processes
                //foreach (atriumDB.ProcessRow prr in myA.AtMng.GetFile(pr.FileId, false).DB.Process)
                //{
                //    if (prr.Thread.StartsWith(pr.Thread) && prr.ProcessId != pr.ProcessId)
                //        throw new AtriumException("You can't move an activity that is on the process that created the file (or is a top-level process in the file.");
                //}
            
        }

        public atriumDB.ProcessRow Load(int ProcessId)
		{
            atriumDB.ProcessRow pr = myProcessDT.FindByProcessId(ProcessId);
            if (pr == null)
            {
                if (myA.AtMng.AppMan.UseService)
                {
                    Fill(myA.AtMng.AppMan.AtriumX().ProcessLoad(ProcessId, myA.AtMng.AppMan.AtriumXCon));
                }
                else
                {
                    try
                    {
                        Fill(myDAL.Load(ProcessId));
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        RecoverDAL();
                        Fill(myDAL.Load(ProcessId));
                    }
                }
                pr= myProcessDT.FindByProcessId(ProcessId);
            }
            
            return pr;
		}


      
        protected override void AfterAdd(DataRow row)
        {
            atriumDB.ProcessRow dr = (atriumDB.ProcessRow)row;
            string ObjectName = this.myProcessDT.TableName;

            dr.ProcessId = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.Active = false;
            dr.Thread = dr.ProcessId.ToString();
            dr.Paused = false;
        }

        internal atriumDB.ProcessRow[] FindAllProcess(atriumDB.ProcessRow pr1, int currentProcid)
        {

            return (atriumDB.ProcessRow[])myA.DB.Process.Select("(ProcessId=" + pr1.ProcessId.ToString() + " or Thread like '" + pr1.Thread + "-%') and processid<>"+currentProcid.ToString());
        }

        public atriumDB.ProcessRow ParentProcess(atriumDB.ProcessRow pr, bool active)
        {
            if (pr.IsFirstActivityIdNull())
                return null;
            else
            {
                string[] parents= pr.Thread.Split('-');
                for (int i = parents.Length-2; i >=0; i--)
                {
                    atriumDB.ProcessRow pr1= myProcessDT.FindByProcessId(Convert.ToInt32(parents[i]));
                    if (pr1 != null)
                    {
                        if (!active)
                            return pr1;
                        else if (pr1.Active)
                            return pr1;
                    }

                }
                return null;
            }
        }
        public override bool CanAdd(DataRow parent)
        {
            atriumDB.EFileRow er = (atriumDB.EFileRow)parent;
            if (er.RowState == DataRowState.Added)
                return true;
            return AllowAdd || myA.AtMng.SecurityManager.CanAdd(er.FileId, atSecurity.SecurityManager.Features.Process) > atSecurity.SecurityManager.ExPermissions.No;
        }

        public void SetActive(atriumDB.ProcessRow pr)
        {
            foreach (atriumDB.ActivityRow ar in pr.GetActivityRows())
            {
                foreach (atriumDB.ActivityBFRow abr in ar.GetActivityBFRows())
                {
                    if (!abr.Completed & !(abr.ACBFId == ActivityBFBE.USERBFID | abr.isMail))
                    {
                        if (!pr.Active)
                        {
                            pr.Active = true;
                            
                        }
                        return;
                    }
                }
            }
            if(pr.Active)
                pr.Active = false;
        }

	}
}

