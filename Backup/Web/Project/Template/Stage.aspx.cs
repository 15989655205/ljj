using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project.Template
{
    public partial class Stage : System.Web.UI.Page
    {
        protected string stageType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                DataSet ds = new BLL.Common().GetList("select value,text from project_stage_type");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                stageType = DBUtility.JsonHelper.DataTable2Json_Combo(dt);
            }
        }
    }
}