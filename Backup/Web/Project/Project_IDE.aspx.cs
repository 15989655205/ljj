using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Project
{
    public partial class Project_IDE : System.Web.UI.Page
    {
        protected string sid = "",type="";
        protected Model.project model = new Model.project();
        protected string v1 = "", v2 = "", v3 = "",v10="";
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
                        try
                        {
                            string v1Str = model.v1 != null ? model.v1 : "";
                            string v2Str = model.v2 != null ? model.v2 : "";
                            v10 = model.v10 != null ? model.v10 : "未分类";
                            if (v1Str != "")
                            {
                                v1 = DbHelperSQL.GetSingle("select dbo.getUserNames_fu('" + v1Str + "')").ToString();
                            }
                            if (v2Str != "")
                            {
                                v2 = DbHelperSQL.GetSingle("select dbo.getUserNames_fu('" + v2Str + "')").ToString();
                            }
                        }
                        catch
                        {
                        }
                        //v3 = DbHelperSQL.GetSingle("select dbo.getUserNames_fu('" + model.v3 != null ? model.v3 : "" + "')").ToString();
                    }
                }
            }
        }
    }
}