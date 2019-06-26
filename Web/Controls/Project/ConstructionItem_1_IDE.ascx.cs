using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Controls.Project
{
    public partial class ConstructionItem_1_IDE : System.Web.UI.UserControl
    {
        protected string showContent = "", showItem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string isConstruction = Request.Params["is_system"] == null ? "" : Request.Params["is_system"].Trim();
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