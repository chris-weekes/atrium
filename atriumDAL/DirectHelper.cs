using System;
using System.Collections.Generic;
using System.Text;

namespace atriumDAL
{
    public class DirectHelper:atriumDALManager 
    {


        public DirectHelper(System.Net.NetworkCredential nc, string dbConnect)
            : base(nc, dbConnect)
        {
        }

        public DirectHelper(string user, string pwd, string dbConnect)
            : base(user, pwd,dbConnect)
        {
        }
    }
}
