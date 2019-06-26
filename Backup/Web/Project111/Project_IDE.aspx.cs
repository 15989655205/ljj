using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Project111
{
    public partial class Project_IDE : System.Web.UI.Page
    {
        protected string sid = "",type="";
        protected Model.project model = new Model.project();
        protected string v1 = "", v2 = "", v3 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sid = Request.Params["sid"] == null ? "" : Request.Params["sid"].Trim();
                type = Request.Params["action"] == null ? "" : Request.Params["action"].Trim();
                if (sid != "")
                {
                    model = new BLL.project().GetModel(int.Parse(sid));
                    if (model != null)
                    {
                        v1 = DbHelperSQL.GetSingle("select dbo.getUserNames_fu('" + model.v1 + "')").ToString();
                        v2 = DbHelperSQL.GetSingle("select dbo.getUserNames_fu('" + model.v2 + "')").ToString();
                        v3 = DbHelperSQL.GetSingle("select dbo.getUserNames_fu('" + model.v3 + "')").ToString();
                    }
                }
            }
        }
    }
}