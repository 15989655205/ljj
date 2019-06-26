using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.ADAndNotice
{
    public partial class Notice_IDE : System.Web.UI.Page
    {
        protected string type = string.Empty;
        protected DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                type = Request.QueryString["type"];
                dt = new BLL.notice().GetList(" id=" + (Request.QueryString["id"] == null ? "0" : Request.QueryString["id"])).Tables[0];
                dt.Rows.Add(dt.NewRow());
            }
        }
    }
}