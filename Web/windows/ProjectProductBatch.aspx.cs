using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.windows
{
    public partial class ProjectProductBatch : System.Web.UI.Page
    {
        protected string productID = "", childs = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    productID = Request.QueryString["productID"] == null ? "" : Request.QueryString["productID"].Trim();
                    childs = Request.QueryString["child"] != null ? Request.QueryString["child"].Trim() : "0";
                }
                catch
                {
                }
            }
        }
    }
}