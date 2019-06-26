using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.ADAndNotice
{
    public partial class noticeview : System.Web.UI.Page
    {
        protected DataTable dt = new DataTable();
        protected string time = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = new BLL.notice().GetList(" id=" + (Request.QueryString["id"] == null ? "0" : Request.QueryString["id"])).Tables[0];
                dt.Rows.Add(dt.NewRow());
                time += "<table>";
                time += "<tr>";
                time += "<td>创建人：</td><td>" + dt.Rows[0]["create_name"].ToString() + "</td>";
                time += "<td>创建时间：</td><td>" + dt.Rows[0]["create_date"].ToString() + "</td>";
                time += "</tr>";
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["update_name"].ToString()) || !string.IsNullOrWhiteSpace(dt.Rows[0]["update_date"].ToString()))
                {
                    time += "<tr>";
                    time += "<td>修改人：</td><td>" + dt.Rows[0]["update_name"].ToString() + "</td>";
                    time += "<td>修改时间：</td><td>" + dt.Rows[0]["update_date"].ToString() + "</td>";
                    time += "</tr>";
                }
                time += "</table>";
            }
        }
    }
}