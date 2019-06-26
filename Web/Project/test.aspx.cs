using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Project
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime sDate = DateTime.Parse("2013-01-02");
            DateTime eDate = DateTime.Parse("2013-01-05");

            TimeSpan ts = eDate.AddDays(1).Subtract(sDate);
        }
    }
}