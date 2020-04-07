using System;

namespace atLogic
{
	/// <summary>
	/// Summary description for WhereClause.
	/// </summary>
	public class WhereClause
	{
		string myWhere="", myAnd="", uiWhere="", uiAnd="";
		int myNumTerms=0;
		const int MAXTERMS = 40;

        public string Operator = " And ";

		public void Add(string field,string compare,DateTime val1,DateTime val2,string friendlyFieldName)
		{
			Build(field,compare,"'"+val1+"'","'"+val2+"'",friendlyFieldName);
		}
        public void Add(string field, string compare, DateTime val1, DateTime val2)
        {
            Build(field, compare, "'" + val1.ToString("s") + "'", "'" + val2.ToString("s") + "'", "");
        }

        public void Add(string field, string compare, int val, string friendlyFieldName)
		{
			Build(field,compare,val.ToString(),"",friendlyFieldName);
		}
        public void Add(string field, string compare, int val)
        {
            Build(field, compare, val.ToString(), "", "");
        }
        public void Add(string field, string compare, string val, string friendlyFieldName)
		{
            if (compare.ToUpper() == "IN" || compare.ToUpper() == "NOT IN")
				Build(field,compare,val,"",friendlyFieldName);
            else
			{
				val = val.Replace( "'", "''");
				Build(field,compare,"'"+val+"'","",friendlyFieldName);
			}
		}
        public void Add(string field, string compare, string val)
        {
            Add(field, compare, val, "");
        }
        public void Add(string field, string[] aList, string friendlyFieldName) //In clause
        {
            string vvalue = "";
            string vComma="";

            foreach (string s in aList)
            {
                vvalue += vComma +"'" + s.Replace("'","''") + "'";
                vComma = ", ";
            }
            Build(field, "IN", vvalue,"",friendlyFieldName);
        }
        public void Add(string field, string[] aList) //In clause
        {
            Add(field, aList, "");
        }
        public void Add(string field, System.Collections.ICollection cList, string friendlyFieldName)
        {
            string vvalue = "";
            string vComma = "";

            foreach (object item in cList)
            {
                string itemValue = item.ToString().Replace("'", "''");

                vvalue += vComma + "'" + itemValue.Substring(0, itemValue.IndexOf(" - ")) + "'";
                vComma = ", ";
            }
            Build(field, "IN", vvalue,"",friendlyFieldName);
        }
        public void Add(string field, System.Collections.ICollection cList)
        {
            Add(field, cList, "");
        }
        public void Add(string field, int[] aList, string friendlyFieldName) //In clause
        {
            string vvalue = "";
            string vComma = "";
            foreach (int i in aList)
            {
                vvalue += vComma + i;
                vComma = ", ";
            }
            Build(field, "IN", vvalue,"",friendlyFieldName);
        }
        public void Add(string field, int[] aList) //In clause
        {
            Add(field, aList, "");
        }

        public void Add(string field, string compare, DateTime val, string friendlyFieldName)
		{
            Build(field, compare, "'" + val.ToString("s") + "'", "", friendlyFieldName);
		}
        public void Add(string field, string compare, DateTime val)
        {
            Build(field, compare, "'" + val.ToString("s") + "'", "", "");
        }
        public void Add(string field, string compare, bool val, string friendlyFieldName)
		{
			if(val)
				Build(field,compare,"1","",friendlyFieldName);
			else
				Build(field,compare,"0","",friendlyFieldName);
		}
        public void Add(string field, string compare, bool val)
        {
            Add(field, compare, val, "");
        }
        public void Add(string field, string compare)
        {
            if (compare == "=")
                compare = "Is Null";
            else if (compare == "<>")
                compare = "Not Is Null";
            else
                throw new Exception("Unexpected error building where clause");

            Build(field, compare, "", "","");
        }

        public void And(WhereClause wc)
        {
            And(wc.Filter());
        }
        public void And(string filter)
        {
            if (myNumTerms == 0)
                myWhere = " (" + filter + ") ";
            else
                myWhere = "(" + myWhere + ") and (" + filter + ") ";

            myNumTerms++;
            if (myNumTerms == 1)
            {
                myAnd = Operator;
                uiAnd = "\r\n";
            }
        }
		private void Build(string field,string compare,string val1,string val2,string friendlyFieldName)
		{
			if (myNumTerms > MAXTERMS )
				throw new Exception("Unexpected error building where clause");
			        
			switch( compare.ToLower())
			{
				case  "between":
					myWhere = myWhere + myAnd + field + " between " + val1 + " and "  + val2 ;
                    uiWhere = uiWhere + uiAnd + friendlyFieldName + " is between " + val1 + " and " + val2;
					break;
				case "like" :
					myWhere = myWhere + myAnd + field + " like " + val1; //.Insert(val1.Length-1, "%") ;   JLL: 2017-01-02 commented out for the purposes of implementing quick search Exact match feature
                    uiWhere = uiWhere + uiAnd + friendlyFieldName + " matches " + val1;
					break;
                case "likeboth":
                    val1=val1.Insert(1, "%");
                    myWhere = myWhere + myAnd + field + " like " + val1.Insert(val1.Length - 1, "%");
                    uiWhere = uiWhere + uiAnd + friendlyFieldName + " matches " + val1;
                    break;
                case "contains":
                    myWhere = myWhere + myAnd + " contains( " + field+ "," + val1 +")";
                    uiWhere = uiWhere + uiAnd + friendlyFieldName + " contains value(s): " + val1;
                    break;
                case "not in":
                          myWhere = myWhere + myAnd + "(" + field + " not in (" + val1 + "))";
                    uiWhere = uiWhere + uiAnd + friendlyFieldName + " not in value(s): " + val1;
                    break;
                case "in":
                    myWhere = myWhere + myAnd + "(" + field + " in (" + val1 + "))";
                    uiWhere = uiWhere + uiAnd + friendlyFieldName + " in value(s): " + val1;
                    break;
                default:
                    if (val2 == "'Null'")
                    {
                        myWhere = myWhere + myAnd + "(" + field + " Is Null or " + field + compare + " " + val1 + ")";
                        uiWhere = uiWhere + uiAnd + friendlyFieldName + " is blank (i.e. no values) or " + field + compare + " " + val1;
                    }
                    else
                    {
                        myWhere = myWhere + myAnd + "(" + field + " " + compare + " " + val1 + ")";
                        uiWhere = uiWhere + uiAnd + friendlyFieldName + " " + compare + " " + val1;
                    }
						
			
					break;
			}   
			myNumTerms++;
            if (myNumTerms == 1)
            {
                myAnd = Operator;
                uiAnd = "\r\n";
            }

		}
		public string Clause()
		{

			if (myWhere.Length == 0)
				return "";
			else
				return "Where "+myWhere;

		}
        public string uiClause()
        {
            if (uiWhere.Length == 0)
                return "";
            else
                return uiWhere;
        }

        public string Filter()
        {
            return myWhere;
        }

		public void Clear()
		{
			myWhere = "";
			myAnd="";
			myNumTerms = 0;
            uiWhere = "";
            uiAnd = "";


		}

	}
}
