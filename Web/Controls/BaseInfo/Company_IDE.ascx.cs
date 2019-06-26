using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Controls.BaseInfo
{
    public partial class Company_IDE : System.Web.UI.UserControl
    {
        //protected DataTable dt = new DataTable();
        protected Model.CompanyInformation companyModel = new Model.CompanyInformation();
        protected string type = "";
        protected string sid = "";
        protected bool isSave = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = Request["action"] != null ? Request["action"].Trim() : "";
            sid = Request["sid"] != null ? Request["sid"].Trim() : "";
            if (type != "add")
            {
                companyModel = new BLL.CompanyInformation().GetModel(int.Parse(sid));
            }
        }
    }
}