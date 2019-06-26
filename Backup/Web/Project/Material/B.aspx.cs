using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project.Material
{
    public partial class B : System.Web.UI.Page
    {

        protected string projectName = "";
        protected string FileNumber = "";
        protected string location = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from v_ProjectMaterialB";
            DataSet ds= new DAL.Common().GetList(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                projectName = ds.Tables[0].Rows[0]["project_name"].ToString();
            }
        }
    }
}