using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Flow
{
    public partial class MyWork_IDE : System.Web.UI.Page
    {
        //protected string type = "", rfsid="";
        //Model.BaseUser bu = new Model.BaseUser();
        //protected DataTable nodeDt = new DataTable();
        protected string type = "";
        protected string tempContent = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string rfsid = Request.Params["rfsid"].Trim();
                    type = Request.Params["action"].Trim();
                    hrfsid.Value = rfsid;
                    haction.Value = type;
                    //type1.Value = type;
                    Model.BaseUser bu = (Model.BaseUser)Session["login"];
                    DataTable dt = new BLL.flow_master().GetList(" rf_sid=" + rfsid + " and dept_sid like '%," + bu.DeptID + ",%' and post_sid like '%," + bu.ApprRole + ",%'").Tables[0];
                    flow_ddl.DataSource = dt;
                    flow_ddl.DataValueField = "sid";
                    flow_ddl.DataTextField = "flow_name";
                    flow_ddl.DataBind();
                    Model.request_form model = new BLL.request_form().GetModel(int.Parse(rfsid));
                    switch (type)
                    {
                        case "add":
                            show.Visible = false;
                            split.Visible = false;
                           
                            GetFormContent(model == null ? "" : model.content_str);
                            flow_name.Text = DBUtility.DbHelperSQL.GetSingle("select dbo.getDeptName('" + bu.DeptID + "')").ToString().Trim() + " " + bu.Name.Trim() + "<" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ">" + model.form_name.Trim();
                            break;
                        case "copy":
                            show.Visible = false;
                            split.Visible = false;
                            SetValue();
                            flow_name.Text = DBUtility.DbHelperSQL.GetSingle("select dbo.getDeptName('" + bu.DeptID + "')").ToString().Trim() + " " + bu.Name.Trim() + "<" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ">" + model.form_name.Trim();
                            isVal.Checked = false;
                            break;
                        case "update":
                            show.Visible = false;
                            split.Visible = false;
                            SetValue();
                            break;
                        case "view":
                            split.Visible = false;
                            submit.Visible = false;
                            SetValue();
                            break;
                        default:
                            break;
                    }
                    GetNode();
                }
            }
            catch
            {
            }
        }

        public void SetValue()
        {
            hsid.Value = Request.Params["sid"].Trim();
            Model.application_form afModel = new BLL.application_form().GetModel(int.Parse(hsid.Value));
            flow_ddl.SelectedValue = afModel.fm_sid;
            flow_name.Text = afModel.af_name;
            this.Label1.Text = Server.HtmlDecode(afModel.af_content);
            if (afModel.rfs_sid == 1)
            {
                isVal.Checked = false;
            }
            else
            {
                isVal.Checked = true;
            }
            remark.Text = afModel.remark;
            tempContent = this.Label1.Text;
        }

        protected void GetFormContent(string content)
        {
            Model.BaseUser bu = (Model.BaseUser)Session["login"];
            this.Label1.Text = Server.HtmlDecode(content);
            if (bu != null)
            {
                //替换各种宏控件
                Model.BaseDepartment departModel = new BLL.BaseDepartment().GetModel(bu.DeptID);
                this.Label1.Text = this.Label1.Text.Replace("宏控件-用户部门", departModel == null ? "" : departModel.DeptName.Trim());
                this.Label1.Text = this.Label1.Text.Replace("宏控件-用户姓名", bu.Name);
                this.Label1.Text = this.Label1.Text.Replace("宏控件-用户角色", bu.Roles);
                this.Label1.Text = this.Label1.Text.Replace("宏控件-用户职位", bu.ApprRole);
                this.Label1.Text = this.Label1.Text.Replace("宏控件-当前时间(日期)", DateTime.Now.ToShortDateString());
            }
            this.Label1.Text = this.Label1.Text.Replace("background-color:#E0ECFF;", "background-color:#ffffff;");
            
            this.Label1.Text = this.Label1.Text.Replace("name=\"my97date\"", "name=\"mydate\" onfocus=\"WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'})\" class=\"Wdate\" ");
            this.Label1.Text = this.Label1.Text.Replace("name=\"myfloat\"", "name=\"mfloat\" class=\"easyui-numberbox\" data-options=\"precision:2\" ");
            this.Label1.Text = this.Label1.Text.Replace("name=\"mynum\"", "name=\"mnum\" class=\"easyui-numberbox\" ");
            //this.Label1.Text = "<center>" + this.Label1.Text + "</center>";
            tempContent = this.Label1.Text;
        }

        protected void flow_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNode();
        }

        public void GetNode()
        {
        //    //string type = Request.Params["action"].Trim();
        //    DataTable nodeDt = new DataTable();
        //    Model.BaseUser bu = (Model.BaseUser)Session["login"];
        //    Label2.Text = "";
        //    //if (type == "add")
        //    nodeDt = new BLL.Common().GetList("select * from v_appr_flow_node where flow_sid=" + flow_ddl.SelectedValue).Tables[0];//new BLL.flow_node().GetList(" flow_sid=" + flow_ddl.SelectedValue).Tables[0];
        //    Label2.Text += "<table class='oa_Flow_Appr_Table'>";
        //    Label2.Text += "<tr><th>节点</th><th>节点名称</th><th>节点类型</th><th>类型</th><th>办理部门</th><th>办理角色</th><th>办理方式</th><th>节点办理人</th>"+(type=="add"?"":"<th>状态</th>")+"</tr>";
        //    string apprNode = DBUtility.DbHelperSQL.GetSingle("select [curr_node_no] from dbo.application_form").ToString().Trim();
        //    string apprStatus = DBUtility.DbHelperSQL.GetSingle("select rf_status from dbo.application_form").ToString().Trim(); 
        //    for (int i = 0; i < nodeDt.Rows.Count; i++)
        //    {
        //        Label2.Text += "<tr>";
        //        Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["node_no"].ToString().Trim() + "</td>";
        //        Label2.Text += "<td class=''>" + nodeDt.Rows[i]["node_name"].ToString().Trim() + "</td>";
        //        Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["node_type_name"].ToString().Trim() + "</td>";
        //        Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["dept_type"].ToString().Trim() + "</td>";
        //        string depStr = "";
        //        if (nodeDt.Rows[i]["appr_dept_type"].ToString().Trim() == "0")
        //        {
        //            depStr = nodeDt.Rows[i]["deptname"].ToString().Trim();
        //        }
        //        else
        //        {
        //            depStr = DBUtility.DbHelperSQL.GetSingle("select dbo.getDeptName('" + bu.DeptID + "')").ToString().Trim();
        //        }
        //        Label2.Text += "<td class='' style='text-align:center;'>" + depStr + "</td>";
        //        Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["role_name"].ToString().Trim() + "</td>";
        //        Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["appr_mode"].ToString().Trim() + "</td>";
        //        //Label2.Text += "<td class=''></td>";
        //        string str = "select dbo.fnApprUsers('" + (nodeDt.Rows[i]["appr_dept_type"].ToString().Trim() == "0" ? nodeDt.Rows[i]["appr_dept"].ToString().Trim() : bu.DeptID.ToString().Trim()) + "','" + nodeDt.Rows[i]["appr_role"].ToString().Trim() + "')";
        //        object obj_tmp = DBUtility.DbHelperSQL.GetSingle(str);
        //        string tmp = (obj_tmp == null ? "" : obj_tmp.ToString().Trim());
        //        Label2.Text += "<td class='' style='text-align:center;'>" + tmp + "</td>";
        //        if (type != "add")
        //        {
        //            string status = "";
        //            if (int.Parse(apprNode) > int.Parse(nodeDt.Rows[i]["node_no"].ToString().Trim()))
        //            {
        //                status = "已通过";
        //            }
        //            else if (int.Parse(apprNode) < int.Parse(nodeDt.Rows[i]["node_no"].ToString().Trim()))
        //            {
        //                status = "待处理";
        //            }
        //            else if (apprStatus == "0"||apprStatus==""||apprStatus==null)
        //            {
        //                status = "待处理";
        //            }
        //            else if (apprStatus == "1")
        //            {
        //                status = "处理中";
        //            }
        //            else if (apprStatus == "2")
        //            {
        //                status = "已通过";
        //            }
        //            else if (apprStatus == "3")
        //            {
        //                status = "退回";
        //            }
        //            Label2.Text += "<td class='' style='text-align:center;'>" + status + "</td>";
        //        }
        //        Label2.Text += "</tr>";
        //    }
        //    Label2.Text += "</table>";
        //}
            if (haction.Value == "add" || haction.Value == "update" || haction.Value == "copy")
            {
                DataTable nodeDt = new DataTable();
                Model.BaseUser bu = (Model.BaseUser)Session["login"];
                Label2.Text = "";
                //if (type == "add")
                nodeDt = new BLL.Common().GetList("select * from v_appr_flow_node where flow_sid='" + flow_ddl.SelectedValue+"'").Tables[0];//new BLL.flow_node().GetList(" flow_sid=" + flow_ddl.SelectedValue).Tables[0];
                Label2.Text += "<table class='oa_Flow_Appr_Table'>";
                Label2.Text += "<tr><th>节点</th><th>节点名称</th><th>节点类型</th><th>类型</th><th>办理部门</th><th>办理角色</th><th>办理方式</th><th>节点办理人</th></tr>";
                string apprNode = DBUtility.DbHelperSQL.GetSingle("select [curr_node_no] from dbo.application_form").ToString().Trim();
                string apprStatus = DBUtility.DbHelperSQL.GetSingle("select rf_status from dbo.application_form").ToString().Trim();
                for (int i = 0; i < nodeDt.Rows.Count; i++)
                {
                    Label2.Text += "<tr>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["node_no"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class=''>" + nodeDt.Rows[i]["node_name"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["node_type_name"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["dept_type"].ToString().Trim() + "</td>";
                    string depStr = "";
                    if (nodeDt.Rows[i]["appr_dept_type"].ToString().Trim() == "0")
                    {
                        depStr = nodeDt.Rows[i]["deptname"].ToString().Trim();
                    }
                    else
                    {
                        depStr = DBUtility.DbHelperSQL.GetSingle("select dbo.getDeptName('" + bu.DeptID + "')").ToString().Trim();
                    }
                    Label2.Text += "<td class='' style='text-align:center;'>" + depStr + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["role_name"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["appr_mode"].ToString().Trim() + "</td>";
                    //Label2.Text += "<td class=''></td>";
                    string str = "select dbo.fnApprUsers('" + (nodeDt.Rows[i]["appr_dept_type"].ToString().Trim() == "0" ? nodeDt.Rows[i]["appr_dept"].ToString().Trim() : bu.DeptID.ToString().Trim()) + "','" + nodeDt.Rows[i]["appr_role"].ToString().Trim() + "')";
                    object obj_tmp = DBUtility.DbHelperSQL.GetSingle(str);
                    string tmp = (obj_tmp == null ? "" : obj_tmp.ToString().Trim());
                    Label2.Text += "<td class='' style='text-align:center;'>" + tmp + "</td>";
                    Label2.Text += "</tr>";
                }
                Label2.Text += "</table>";
            }
            else
            {
                DataTable nodeDt = new DataTable();
                //if (type == "add")
                nodeDt = new BLL.Common().GetList("select * from v_request_form_appr where af_sid='" + hsid.Value+"'").Tables[0];//new BLL.flow_node().GetList(" flow_sid=" + flow_ddl.SelectedValue).Tables[0];
                Label2.Text += "<table class='oa_Flow_Appr_Table'>";
                Label2.Text += "<tr><th>节点</th><th>节点类型</th><th>类型</th><th>审核部门</th><th>审核角色</th><th>审核方式</th><th>审核状态</th><th>这一节点审核人</th></tr>";
                for (int i = 0; i < nodeDt.Rows.Count; i++)
                {
                    Label2.Text += "<tr>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["node_no"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["node_type_name"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["dept_type"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["DeptName"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["role_name"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["appr_mode"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["ApprStatus"].ToString().Trim() + "</td>";
                    Label2.Text += "<td class='' style='text-align:center;'>" + nodeDt.Rows[i]["ApprMan"].ToString().Trim() + "</td>";
                    Label2.Text += "</tr>";
                }
                Label2.Text += "</table>";
            }
            //string type = Request.Params["action"].Trim();
            
        }
    }
}