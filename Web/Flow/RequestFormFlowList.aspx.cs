using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Flow
{
    public partial class RequestFormFlowList : System.Web.UI.Page
    {
        protected string url = "";
        protected string rfsid = "";
        protected DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rfsid = Request.QueryString["rfsid"].Trim();
                url = Request.QueryString["url"].Trim();
                Model.BaseUser bu = (Model.BaseUser)Session["login"];

                dt = new BLL.flow_master().GetList(" rf_sid=" + rfsid+" and dept_sid like '%,"+bu.DeptID+",%' and post_sid like '%,"+bu.ApprRole+",%'").Tables[0];
            }
        }
    }
}