using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.BaseInfo
{
    public partial class Product_Bom : System.Web.UI.Page
    {
        protected string id = "";
        protected Model.v_ProductColor model = new Model.v_ProductColor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    id = Request.QueryString["id"] == null ? "" : Request.QueryString["id"].Trim();
                    if (id != "")
                        model = new DAL.v_ProductColor().GetModel(long.Parse(id));
                    //code.Text = model.Code;
                    //name.Text = model.Name;
                }
                catch
                {
                }
            }
        }
    }
}