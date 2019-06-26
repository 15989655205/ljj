using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Project111
{
    public partial class MyProjectPlan_IDE : System.Web.UI.Page
    {
        protected DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.BaseUser bu = Session["login"] as Model.BaseUser;
                string table =
                    " project a  " +
                    " join project_stage b on a.sid=b.p_sid " +
                    " join project_group c on b.sid=c.ps_sid " +
                    " join project_specific_item d on c.sid=d.group_sid and d.parent_sid=0  " +
                    " join project_specific_item e on d.sid=e.parent_sid and e.sid=" + Request.QueryString["si_sid"] + " " +
                    " join project_work_implement g on e.sid=g.psi_sid and ','+g.implementer_sid+',' like '%," + bu.UserName + ",%' ";
                string show =
                    " a.sid project_id, project_name, project_code, " +
                    " b.sid stage_id, stage_name, " +
                    " c.sid group_id, group_name, " +
                    " d.sid jobduties_id, d.name jobduties_name, " +
                    " e.sid detail_id, e.name detail_name, convert(nvarchar,e.begin_date,120)begin_date, convert(nvarchar,e.end_date,120)end_date, " +
                    "     dbo.getImplementer_name(e.sid)names, dbo.getImplement(e.sid)implement_name ";
                string where = " 1=1 ";
                int total = 0;
                dt = DbHelperSQL.GetList_ProcPage(table, "project_code", show, 1, 1, out total, "asc", where).Tables[0];
                dt.Rows.Add(dt.NewRow());                
            }
        }
    }
}