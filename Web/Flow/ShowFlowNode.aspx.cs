using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Flow
{
    public partial class ShowFlowNode : System.Web.UI.Page
    {
        protected string fsid = "";
        protected DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fsid = Request.QueryString["flow_sid"].Trim();
                dt = new BLL.Common().GetList("select sid,flow_sid,node_no,node_type,node_name,node_status,appr_dept,appr_dept_type,appr_role,appr_count,appr_time,appr_must,remark,flow_name,node_type_name,DeptName,RoleName from v_flow_node where flow_sid=" + fsid + " order by node_no asc").Tables[0];
            }
        }
    }
}