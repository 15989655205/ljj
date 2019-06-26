using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Project
{
    public partial class MyProjectPlan : System.Web.UI.Page
    {
        protected string type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //0为未完成，1为已完成，""为所有
                type = Request.Params["type"] == null ? "" : Request.Params["type"].Trim();
            }
        }
    }
}