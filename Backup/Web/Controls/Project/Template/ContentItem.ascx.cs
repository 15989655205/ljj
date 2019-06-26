using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Controls.Project.Template
{
    public partial class ContentItem : System.Web.UI.UserControl
    {
        protected string showContent = "", showItem = "", type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string isConstruction = Request.Params["isConstruction"] == null ? "" : Request.Params["isConstruction"].Trim();
                type = isConstruction;
                switch (isConstruction)
                {
                    case "1":
                        showContent = "空间";
                        showItem = "图纸及索引号";
                        break;
                    case "0":
                        showContent = "工作内容";
                        showItem = "细目";
                        break;
                    case "2":
                        showContent = "货物类别";
                        showItem = "工作细目";
                        break;
                    case "3":
                        showContent = "加工类别";
                        showItem = "内容";
                        break;
                }
            }
        }
    }
}