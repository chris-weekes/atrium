using System;
using System.Data;
using atLogic;
using lmDatasets;
using atriumBE.Properties;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class AKABE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.AKADataTable myAKADT;
		
		internal AKABE(FileManager pBEMng):base(pBEMng,pBEMng.DB.AKA)
		{
			myA=pBEMng;
			myAKADT=(atriumDB.AKADataTable)myDT;
        }
        public atriumDAL.AKADAL myDAL
        {
            get
            {
                return (atriumDAL.AKADAL)myODAL;
            }
        }

		

	

		protected override void AfterAdd(DataRow row)
		{
			atriumDB.AKARow dr=(atriumDB.AKARow)row;
			string ObjectName = this.myAKADT.TableName;

			//System.Diagnostics.Debug.WriteLine(dr["ContactId"] + dr.RowState.ToString() );

			dr.AKAID=this.myA.AtMng.PKIDGet(ObjectName,10);            
		}

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myAKADT.TableName;
			atriumDB.AKARow dr=(atriumDB.AKARow)ddr;
			switch(dc.ColumnName)
			{
				case "FirstName":
                    if (dr.IsFirstNameNull())
                        throw new RequiredException(Resources.FirstName);
					break;
				case "LastName":
					if (dr.IsLastNameNull())
                        throw new RequiredException(Resources.LastName);
                    break;
				default:
					break;
			}
		}
		protected override void BeforeUpdate(DataRow  row)
		{
			atriumDB.AKARow dr = (atriumDB.AKARow) row;
			this.BeforeChange(dr.Table.Columns["LastName"],dr);
			this.BeforeChange(dr.Table.Columns["FirstName"],dr);

		}
		protected override void BeforeDelete(DataRow row)
		{
			atriumDB.AKARow dr = (atriumDB.AKARow) row;
			string ObjectName = this.myAKADT.TableName;
			this.myA.GetActivity().DeleteRelatedCA(this.myA.CurrentFile.FileId, ObjectName, dr.AKAID);
		}

	
        //public override DataRow[] GetParentRow()
        //{
        //    if(!this.myA.CurrentFile.IsOpponentIDNull())
        //        return new DataRow[] { this.myA.GetCLASMng().GetDebtor().Load(this.myA.CurrentFile.OpponentID) };
        //    else
        //        return null;
        //}
	}
}

