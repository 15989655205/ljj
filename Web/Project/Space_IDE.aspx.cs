using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Project
{
    public partial class Space_IDE : System.Web.UI.Page
    {
        protected int psid=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string psid1 = Request["psid"];
            int.TryParse(psid1, out psid);

        }
    }
}