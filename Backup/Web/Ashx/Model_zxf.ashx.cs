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
    /// Model_zxf 的摘要说明
    /// </summary>
    public class Model_zxf : IHttpHandler, IRequiresSessionState
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
            string Type = context.Request["action"];
            string revalue = "";
            switch (Type)
            {
                case "AllImpt":
                    revalue = SelectAllImpt(context);
                    break;
                case"ImptEdit":
                    revalue = ImptEdit(context);
                    break;
                case "AllGroup":
                    revalue = selectAllGroup(context);
                    break;
                case"GroupEdit":
                    revalue = GroupEdit(context);
                    break;
                case"allWorkFlow":
                    revalue = selectAllWorkFlow(context);
                    break;
                case "flow_edit":
                    revalue = WrokFlowEdit(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(revalue);
        }

        public string WrokFlowEdit(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];

            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.work_flow_model> insert = new List<Model.work_flow_model>();
            insert = JsonSerializerHelper.JSONStringToList<Model.work_flow_model>(addstr);
            List<Model.work_flow_model> update = new List<Model.work_flow_model>();
            update = JsonSerializerHelper.JSONStringToList<Model.work_flow_model>(updatestr);
            List<Model.work_flow_model> del = new List<Model.work_flow_model>();
            del = JsonSerializerHelper.JSONStringToList<Model.work_flow_model>(delstr);
            List<Model.work_flow_model> SN = new List<Model.work_flow_model>();
            SN = JsonSerializerHelper.JSONStringToList<Model.work_flow_model>(allstr);
            return new BLL.work_flow_model().Edit(insert, update, del, SN,bu.UserName);
        }

        public string selectAllWorkFlow(HttpContext context)
        {

            string result;
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList("select id, work_flow_name,SN,remark,create_person,create_date,update_person,update_date from work_flow_model where 1=1 order by SN").Tables[0];
            result = DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
            return result;
        }

        public string GroupEdit(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_group_model> insert = new List<Model.project_group_model>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_group_model>(addstr);
            List<Model.project_group_model> update = new List<Model.project_group_model>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_group_model>(updatestr);
            List<Model.project_group_model> del = new List<Model.project_group_model>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_group_model>(delstr);

             
            return new BLL.project_group_model().Edit(insert, update, del,bu.UserName);
        }

        public string selectAllGroup(HttpContext context)
        {
            string result;
            DataTable dt = new DataTable();
            string where = "1=1";
            dt = new BLL.Common().GetList("select sid,group_name,remark,create_person,create_date,update_person,update_date from project_group_model").Tables[0];
            if (dt.Rows.Count > 0)
            {
                result = DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
            }
            else
            {
                result = "{\"total\":0,\"rows\":[]}";
            }

            return result;
        }

        public string ImptEdit(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];

            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.implement> insert = new List<Model.implement>();
            insert = JsonSerializerHelper.JSONStringToList<Model.implement>(addstr);
            List<Model.implement> update = new List<Model.implement>();
            update = JsonSerializerHelper.JSONStringToList<Model.implement>(updatestr);
            List<Model.implement> del = new List<Model.implement>();
            del = JsonSerializerHelper.JSONStringToList<Model.implement>(delstr);

            return new BLL.implement().Edit(insert, update, del, bu.UserName);
        }

        public string SelectAllImpt(HttpContext context)
        {
            string result;
            DataTable dt = new DataTable();
            string where = "1=1";
            dt = new BLL.Common().GetList("select sid,implement_name,remark,create_person,create_date,update_person,update_date from implement").Tables[0];
            //int total = 0;
            //int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            //int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            //string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "asc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "implement_name";
            //string table = "implement";
            //string show = "sid,implement_name,remark";
            //dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            if (dt.Rows.Count>0)
            {
                result = DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
            }
            else
            {
                result = "{\"total\":0,\"rows\":[]}";
            }
            
            return result;
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