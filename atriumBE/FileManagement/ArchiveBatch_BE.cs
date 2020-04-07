using System;
using System.IO;
using System.Collections.Specialized;
using System.Reflection;
using System.Data;
using atLogic;
using lmDatasets;
using atriumBE.Properties;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ArchiveBatchBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.ArchiveBatchDataTable myArchiveBatchDT;
		
		internal ArchiveBatchBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.ArchiveBatch)
		{
			myA=pBEMng;
			myArchiveBatchDT=(atriumDB.ArchiveBatchDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetArchiveBatch();
        }
        public atriumDAL.ArchiveBatchDAL myDAL
        {
            get
            {
                return (atriumDAL.ArchiveBatchDAL)myODAL;
            }
        }


		public atriumDB.ArchiveBatchRow Load(int ArchiveId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().ArchiveBatchLoad(ArchiveId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(ArchiveId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(ArchiveId));
                }
            }
			return myArchiveBatchDT.FindByArchiveId(ArchiveId);

		}


		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			
			string ObjectName = this.myArchiveBatchDT.TableName;
			atriumDB.ArchiveBatchRow dr=(atriumDB.ArchiveBatchRow)ddr;
			switch(dc.ColumnName)
			{
				case "ArchiveDate":
                    if(!dr.IsArchiveDateNull())
					    myA.IsValidDate(Resources.ArchiveBatchArchiveDate, dr.ArchiveDate, true, DebtorBE.CSLBegin, DateTime.Today,Resources.ValidationCSLBegin, Resources.ValidationToday);
					
					break;
				default:
					break;
			}
		}

		public const int ciFilenumber = 0;
		public const int ciLastName = 1;
		public const int ciFirstName = 2;
		public const int ciAccessionNumber = 3;
		public const int ciRoom = 4;
		public const int ciBay = 5;
		public const int ciBoxNumber = 6;
		public const int ciProcessCode = 7;


		public  bool ValidateArchiveData(atriumManager cm, StreamReader tsRead, bool pbPackingList)
		{
			try
			{
				string sPathFileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),@"\output\errorlog_" + DateTime.Today.ToString("yyyymmdd") + ".log" );
				long nCount = 1;
				string header  = tsRead.ReadLine();
				bool bErrorsExist = false;
				bool bFirstError= false;
				bool bLineError= false;
				string sErrorString = "";
				int iErrorCount = 0;
				string sErrorType = "";
				StreamWriter tsWrite = new StreamWriter(sPathFileName,false);


				while(tsRead.Peek()!= -1)
				{
					StringCollection avarText = new StringCollection();
					avarText.AddRange(tsRead.ReadLine().Split(new Char[] {','}));
					if (!(avarText[ciProcessCode].Length > 0))
					{
						if (pbPackingList)
						{
							if (!(avarText[ciBoxNumber].Length > 0))
							{
								SetErrVars (ref bFirstError,ref bErrorsExist,ref bLineError);
								sErrorString = "Box Number";
							}
						}
						else
						{
							//	for final, loop through line validating all required fields
							for (int i=0; i==6; i++)
							{
								switch(i)
								{
									case ciAccessionNumber:
										goto case ciBoxNumber;
									case ciRoom: 
										goto case ciBoxNumber;
									case ciBay:
										goto case ciBoxNumber;
									case ciBoxNumber:
										if (!(avarText[i].Length > 0))
										{
											//  set flags as to whether an error exists and whether it is the
											//  first error encountered
											if (iErrorCount == 0)
											{
												SetErrVars( ref bFirstError,ref bErrorsExist,ref bLineError);
											}
											iErrorCount += 1;
											switch(i)
											{
												case ciAccessionNumber:
													sErrorType = "Accession Number";
													break;
												case ciRoom:
													sErrorType = "Room";
													break;
												case ciBay:
													sErrorType = "Bay";
													break;
												case ciBoxNumber:
													sErrorType = "Box Number";
													break;
											}										
											//  build error string
											if (iErrorCount > 1)
												sErrorString = sErrorString + ", and " + sErrorType;
											else
												sErrorString = sErrorType;
										}
										break;
								}
							}
						}
					}

					//	log errors
					if (bLineError)
					{
						// create error log file only if required
						if (bFirstError)
						{
							//cm.ErrorLogName = sPathFileName;
							bFirstError = false;
						}
						InputToErrorLog (avarText, tsWrite, sErrorString);
						bLineError = false;
						iErrorCount = 0;
						sErrorString = "";
					}
					nCount = nCount + 1;
				}
				if (!bErrorsExist)
					return true;
				else
					return false;
			}
			catch(Exception exc)
			{
				throw exc;
			}
		}

		public static void InputToErrorLog(StringCollection avarText, StreamWriter tsWrite, string sErrorString)
		{
			try
			{
				string sMainString;
				sMainString = avarText[ciLastName] + ", " + avarText[ciFirstName] + " (" + avarText[ciFilenumber] + ") is missing the " + sErrorString + ".";
				tsWrite.WriteLine(sMainString);
				tsWrite.Close();
			}
			catch (Exception exc)
			{
				throw exc;
			}
		}

		public static void SetErrVars(ref bool bFirstError,ref bool bErrorsExist,ref bool bLineError)
		{
			if(!bErrorsExist)
			{
				bFirstError = true;
				bErrorsExist = true;
			}
			bLineError = true;
		}


		public  void UpdateArchiveData(atriumManager cm, StreamReader ptsRead, bool pbPackingList)
		{
			try
			{
              
                string pbSql = "update efile set boxnumber ={1} where filetype='CL' and filenumber ='{0}'";
                string archfSql = "update efile set statuscode='A',boxnumber={1} where filetype='CL' and filenumber ='{0}'; ";
                string archaSql = "update ab set ab.accessionnumber='{1}' from archivebatch ab inner join efile f on ab.archiveid=f.fileid where filetype='CL' and filenumber ='{0}'; ";
                string clearSql = "delete from archivebatch where archiveid in (select fileid from efile where  filetype='CL' and filenumber ='{0}')";

                ptsRead.ReadLine();
                while (ptsRead.Peek() != -1)
                {
                    string line = ptsRead.ReadLine();
                    string[] avarText=line.Split(new Char[] { ',' });
                    //avarText.AddRange(ptsRead.ReadLine().Split(new Char[] { ',' }));
                    //oDebtor = cm.GetDebtor(avarText[ciSIN]);
                    //dsAtrium.DebtorRow dr = oDebtor[0];
                    //dr.BeginEdit();

                    //            ' take only values where there is no ProcessCode value
                    int valueParsed;
                    if (Int32.TryParse(avarText[ciBoxNumber].Trim(), out valueParsed) && !(avarText[ciProcessCode].Length>0))

                    {
                        if (pbPackingList)
                        {
                            myA.AtMng.AppMan.ExecuteNonQuery(String.Format(pbSql, avarText[ciFilenumber],avarText[ciBoxNumber]));
                        }
                        else
                        {
                            //dr.AccessionNumber = avarText[ciAccessionNumber];
                            //dr.Room = avarText[ciRoom];
                            //dr.Bay = Convert.ToInt32(avarText[ciBay]);
                            //dr.BoxNumber = Convert.ToInt32(avarText[ciBoxNumber]);
                            //dr.StatusCode = "A";
                            myA.AtMng.AppMan.ExecuteNonQuery(string.Format(archfSql, avarText[ciFilenumber], avarText[ciBoxNumber]) + string.Format(archaSql, avarText[ciFilenumber], avarText[ciAccessionNumber]));
                            //myA.AtMng.AppMan.ExecuteNonQuery(string.Format(archaSql, avarText[ciFilenumber],avarText[ciAccessionNumber]));
                        }
                    }
                    else if (avarText[ciBoxNumber].Trim()=="EO")
                    {
                        myA.AtMng.AppMan.ExecuteNonQuery(String.Format(archfSql, avarText[ciFilenumber], "null"));
                    }
                    else
                    {
                        //where there is a process code value, remove archiving date (thus making record available for next archiving batch)
                        myA.AtMng.AppMan.ExecuteNonQuery(String.Format(clearSql, avarText[ciFilenumber]));
                    }

                    //// in order to override "most recent PCA code can't be blank" requirement, turn validate off
                    //dr.AcceptChanges();
                    ////            With oDebtor
                    ////                .ValidateON = false
                    ////                .Save
                    ////                .ValidateON = true
                    //            End With
                }
			}
			catch(Exception exc)
			{
				throw exc;
			}
		}


        public string CreateArchiveBatch(DateTime archiveDate, DateTime lastActivityDate)
        {
            //   procedure updates archive date value as appropriate (thus making record available for 
            //   archiving), and uses getarchivecsv (which in turn uses getarchivelist) to build a 
            //   csv file

            this.myA.IsValidDate("Archive Date", archiveDate, false, DateTime.Today.AddMonths(-3), DateTime.Today.AddMonths(3), "3 months ago", "3 months from now");
            this.myA.IsValidDate("Last Activity date", lastActivityDate, false, DateTime.Today.AddMonths(-24), DateTime.Today, "2 years ago", Resources.ValidationToday);
            //SqlHelper.ExecuteNonQuery(sqlCon,"sp_CreateArchivingBatch",archiveDate,lastActivityDate);
            return GetArchiveCSV(archiveDate);
        }


        public DataTable GetArchiveList(DateTime archiveDate)
        {
            DataTable olist = new DataTable("ArchiveList");
            olist = myA.DALMngr.ExecuteDataset("GetArchiveBatch",archiveDate).Tables[0];
            return olist;
        }

        public string GetArchiveCSV(DateTime archiveDate)
        {
            //    procedure creates a csv file having all records available for archiving (based on 
            //	  archive date having a value)
            string sFileName = "ArchiveBatch_" + archiveDate.ToString("yyyymmdd") + ".csv";
            DataTable olist = new DataTable();
            olist = this.GetArchiveList(archiveDate);
            string sStringData = "SIN, Last Name, First Name, Accession Number, Room, Bay, Box Number, Process Code, Max Activity Date, File ID, Archiving Date, Status Code, Filed Last Name, Filed First Name";

            string fullPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"\output\");
            fullPath = System.IO.Path.Combine(fullPath, sFileName);
            this.myA.WriteDataTableToCSV(fullPath, olist, sStringData, false);
            return sFileName;
        }

        public bool ManageArchiveData(string psFileName, bool psPackingList)
        {
            try
            {
                //     procedure validates and updates archive data
                using (FileStream fstr = new FileStream(psFileName, FileMode.Open))
                {

                    using (StreamReader tsRead = new StreamReader(fstr))
                    {

                        if (true || ValidateArchiveData(this.myA.AtMng, tsRead, psPackingList))
                        {
                            fstr.Seek(0, SeekOrigin.Begin);
                            UpdateArchiveData(this.myA.AtMng, tsRead, psPackingList);
                            return true;
                        }
                        else
                            throw new AtriumException(Resources.CLASMateArchiveFailed);
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

    }
}

