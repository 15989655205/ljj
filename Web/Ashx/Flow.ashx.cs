using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// Flow 的摘要说明
    /// </summary>
    public class Flow : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            if (bu == null)
            {
                context.Response.Write("登录超时，请重新登录。");
                return;
            }
            string type = context.Request["action"];
            string reValue = "";
            switch (type)
            {
                case "list":
                    reValue = QueryList(context);
                    break;
                case "sub_list":
                    reValue = SubList(context);
                    break;
                case "add":
                    reValue = Add(context);
                    break;
                case "edit":
                    reValue = Edit(context);
                    break;
                case "dels":
                    reValue = Dels(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        public string QueryList(HttpContext context)
        {
            DataTable dt = new DataTable();
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "asc";
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "type_name";
            string where = " 1=1 ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                string status = "";
                if (key == "生效")
                {
                    status = "1";
                }
                else
                {
                    status = "0";
                }
                where += " and (flow_name like '%" + key + "%' or form like '%" + key + "%' or dept like '%" + key + "%' or flow_status like '%" + status + "%' )";
            }
            string table = "flow_master a left outer join request_form b on a.rf_sid=b.sid left outer join request_form_type c on b.rft_sid=c.sid";
            string show = "a.sid,a.flow_name,a.rf_sid,a.dept_sid,a.post_sid,a.flow_status,a.remark,a.form as form_name,a.dept as DeptName, a.post as RoleName,c.type_name";

            dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);

        }

        public string SubList(HttpContext context)
        {
            DataTable dt = new DataTable();
            //int total = 0;
            //int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            //int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            //string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "asc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string sid = context.Request["sid"];
            //string where = " flow_sid= " + sid;
            //if (key != "" && !string.IsNullOrEmpty(key))
            //{
            //where += " and (role_name like '%" + key + "%' or role_level like '%" + key + "%' )";
            //}
            //string table = "v_flow_node";
            //string show = "sid,flow_sid,node_no,node_type,node_name,node_status,appr_dept,appr_dept_type,appr_role,appr_count,appr_time,appr_must,remark,flow_name,node_type_name,DeptName,RoleName";

            //dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            dt = new BLL.Common().GetList("select sid,flow_sid,node_no,node_type,node_name,node_status,appr_dept,appr_dept_type,appr_role,appr_count,appr_time,appr_must,remark,flow_name,node_type_name,DeptName,RoleName from v_flow_node where flow_sid=" + sid + " order by node_no asc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);

        }

        public string Add(HttpContext context)
        {
            string Name = context.Request["Name"].Trim();
            string chkStatus = context.Request["chkStatus"].Trim();
            string ApplyForm = context.Request["ApplyForm"].Trim();
            string ApplyBanding = context.Request["ApplyBanding"].Trim();
            string ApplyDept = context.Request["ApplyDept"].Trim();
            string Description = context.Request["Description"].Trim();
            string dept = context.Request["dept"].Trim();
            string post = context.Request["post"].Trim();
            string form = context.Request["form"].Trim();
            string addstr = context.Request["addstr"].Trim();
            string updatestr = context.Request["updatestr"].Trim();
            string delstr = context.Request["delstr"].Trim();
            Model.flow_master flowMasterModel = new Model.flow_master();
            flowMasterModel.flow_name = Name;
            flowMasterModel.flow_status = Convert.ToInt32(chkStatus);
            flowMasterModel.remark = Description;
            flowMasterModel.dept = dept;
            flowMasterModel.post = post;
            flowMasterModel.form = form;
            flowMasterModel.create_person = "";//context.Session["UserID"].ToString();
            flowMasterModel.rf_sid = Convert.ToInt32(ApplyForm);
            if (ApplyBanding.Length > 0)
            {
                if (ApplyBanding.Substring(0, 1) == ",")
                {
                    ApplyBanding = ApplyBanding + ",";
                }
                else
                {
                    ApplyBanding = "," + ApplyBanding + ",";
                }
            }
            flowMasterModel.post_sid = ApplyBanding;
            if (ApplyDept.Length > 0)
            {
                if (ApplyDept.Substring(0, 1) == ",")
                {
                    ApplyDept = ApplyDept + ",";
                }
                else
                {
                    ApplyDept = "," + ApplyDept + ",";
                }
            }
            flowMasterModel.dept_sid = ApplyDept;



            List<Model.flow_node> details = new List<Model.flow_node>();

            details = JsonSerializerHelper.JSONStringToList<Model.flow_node>(addstr);

            //return BllOAProcess.InsertFlow(oaFlowMasterInfo, details);
            return new BLL.flow_master().InsertFlow(flowMasterModel, details);
        }

        public string Edit(HttpContext context)
        {
            string sid = context.Request.Params["sid"].Trim();
            string Name = context.Request["Name"].Trim();
            string chkStatus = context.Request["chkStatus"].Trim();
            string ApplyForm = context.Request["ApplyForm"].Trim();
            string ApplyBanding = context.Request["ApplyBanding"].Trim();
            string ApplyDept = context.Request["ApplyDept"].Trim();
            string dept = context.Request["dept"].Trim();
            string post = context.Request["post"].Trim();
            string form = context.Request["form"].Trim();
            string Description = context.Request["Description"].Trim();
            string addstr = context.Request["addstr"].Trim();
            string updatestr = context.Request["updatestr"].Trim();
            string delstr = context.Request["delstr"].Trim();

            Model.flow_master flowMasterModel = new BLL.flow_master().GetModel(int.Parse(sid));
            flowMasterModel.flow_name = Name;
            flowMasterModel.flow_status = Convert.ToInt32(chkStatus);
            flowMasterModel.remark = Description;
            flowMasterModel.dept = dept;
            flowMasterModel.post = post;
            flowMasterModel.form = form;
            flowMasterModel.create_person = "";//context.Session["UserID"].ToString();
            flowMasterModel.rf_sid = Convert.ToInt32(ApplyForm);
            if (ApplyBanding.Length > 0)
            {
                if (ApplyBanding.Substring(0, 1) == ",")
                {
                    ApplyBanding = ApplyBanding + ",";
                }
                else
                {
                    ApplyBanding = "," + ApplyBanding + ",";
                }
            }
            flowMasterModel.post_sid = ApplyBanding;
            if (ApplyDept.Length > 0)
            {
                if (ApplyDept.Substring(0, 1) == ",")
                {
                    ApplyDept = ApplyDept + ",";
                }
                else
                {
                    ApplyDept = "," + ApplyDept + ",";
                }
            }
            flowMasterModel.dept_sid = ApplyDept;



            //List<Model.flow_node> details = new List<Model.flow_node>();
            //details = JsonSerializerHelper.JSONStringToList<Model.flow_node>(addstr);
            List<Model.flow_node> insert = new List<Model.flow_node>();
            insert = JsonSerializerHelper.JSONStringToList<Model.flow_node>(addstr);
            List<Model.flow_node> update = new List<Model.flow_node>();
            update = JsonSerializerHelper.JSONStringToList<Model.flow_node>(updatestr);
            List<Model.flow_node> del = new List<Model.flow_node>();
            del = JsonSerializerHelper.JSONStringToList<Model.flow_node>(delstr);

            //return BllOAProcess.InsertFlow(oaFlowMasterInfo, details);
            return new BLL.flow_master().UpdateFlow(flowMasterModel, insert, update, del);
        }

        public string Dels(HttpContext context)
        {
            string selectid = context.Request.Params["cbx_select"].Trim();
            return new BLL.flow_master().DeleteFlow(selectid);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}