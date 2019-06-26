using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace Maticsoft.Web.Flow
{
    public partial class HandleRequestForm : System.Web.UI.Page
    {
        protected string sid = "", rfsid = "", action = "",node="",nodeType="",currNode="",type="";
        protected string[] arrStr = null;
        protected Model.application_form afModel = new Model.application_form();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    sid = Request.Params["sid"].Trim();
                    rfsid = Request.Params["rfsid"] == null ? "" : Request.Params["rfsid"].Trim();
                    action = Request.Params["action"] == null ? "" : Request.Params["action"].Trim();
                    currNode = Request.Params["currNode"] == null ? "" : Request.Params["currNode"].Trim();
                    type = Request.Params["type"] == null ? "" : Request.Params["type"].Trim();
                    afModel = new BLL.application_form().GetModel(int.Parse(sid));
                    this.Label1.Text = Server.HtmlDecode(afModel.af_content);
                    //type1.Value = type;
                    Model.BaseUser bu = (Model.BaseUser)Session["login"];
                    GetNode(sid);

                    string ntsid = Request.Params["ntsid"] == null ? "" : Request.Params["ntsid"].Trim();
                    Model.node_type ntModel= new BLL.node_type().GetModel(int.Parse(ntsid));
                    nodeType = ntModel.node_type_name;
                    arrStr = ntModel.value1.Split('|');
                }
            }
            catch
            {
            }
        }

        public void GetNode(string sid)
        {
            //string type = Request.Params["action"].Trim();
            DataTable nodeDt = new DataTable();
            //if (type == "add")
            nodeDt = new BLL.Common().GetList("select * from v_request_form_appr where af_sid=" + sid).Tables[0];//new BLL.flow_node().GetList(" flow_sid=" + flow_ddl.SelectedValue).Tables[0];
            node += "<table class='oa_Flow_Appr_Table'>";
            node += "<tr><th>节点</th><th>节点类型</th><th>类型</th><th>办理部门</th><th>办理角色</th><th>办理方式</th><th>办理状态</th><th>这一节点办理人</th></tr>";
            for (int i = 0; i < nodeDt.Rows.Count; i++)
            {
                node += "<tr>";
                node += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["node_no"].ToString().Trim() + "</td>";
                node += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["node_type_name"].ToString().Trim() + "</td>";
                node += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["dept_type"].ToString().Trim() + "</td>";
                node += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["DeptName"].ToString().Trim() + "</td>";
                node += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["role_name"].ToString().Trim() + "</td>";
                node += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["appr_mode"].ToString().Trim() + "</td>";
                node += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["ApprStatus"].ToString().Trim() + "</td>";
                node += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["ApprMan"].ToString().Trim() + "</td>";
                node += "</tr>";
            }
            node += "</table>";
        }
    }
}