using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Flow
{
    public partial class RequestFormTable : System.Web.UI.Page
    {
        protected DataTable pdt = new DataTable();
        protected BLL.request_form rfBLL = new BLL.request_form();
        protected BLL.Common comBll = new BLL.Common();
        protected Model.BaseUser bu = new Model.BaseUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pdt = new BLL.request_form_type().GetList("status=1").Tables[0];
                bu = (Model.BaseUser)Session["login"];
            }
        }
    }
}