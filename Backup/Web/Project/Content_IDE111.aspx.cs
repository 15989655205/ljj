using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Project
{
    public partial class Content_IDE111 : System.Web.UI.Page
    {
        protected string showContent = "", showItem = "",pssid="",action="",sid="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string isConstruction = Request.Params["isConstruction"] == null ? "" : Request.Params["isConstruction"].Trim();
                pssid = Request.Params["pssid"] == null ? "" : Request.Params["pssid"].Trim();
                action = Request.Params["action"] == null ? "" : Request.Params["action"].Trim();
                sid = Request.Params["sid"] == null ? "" : Request.Params["sid"].Trim();
                if (isConstruction == "1")
                {
                    showContent = "空间";
                    showItem = "图纸及索引号";
                }
                else
                {
                    showContent = "工作内容";
                    showItem = "细目";
                }
            }
        }
    }
}