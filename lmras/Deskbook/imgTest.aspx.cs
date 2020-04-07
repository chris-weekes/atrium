using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lmras
{
    public partial class imgTest : System.Web.UI.Page
    {
        public atriumDAL.atriumDALManager myatDAL;

        protected void Page_Load(object sender, EventArgs e)
        {
            myatDAL = new atriumDAL.atriumDALManager("lmadmin", "3bTsP6Xl", "DATABASE1");

        }
    }
}