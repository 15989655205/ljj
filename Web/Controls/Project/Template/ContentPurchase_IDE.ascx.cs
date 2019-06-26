using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Controls.Project.Template
{
    public partial class ContentPurchase_IDE : System.Web.UI.UserControl
    {
        protected string showContent = "", showItem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string isConstruction = Request.Params["isConstruction"] == null ? "" : Request.Params["isConstruction"].Trim();
                showContent = "货物类别";
                showItem = "工作细目";
            }
        }
    }
}