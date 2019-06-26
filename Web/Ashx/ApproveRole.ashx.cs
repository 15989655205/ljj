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
    /// ApproveRole 的摘要说明
    /// </summary>
    public class ApproveRole : IHttpHandler, IReadOnlySessionState
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
                case "edit":
                    reValue = Edit(context);
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
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string where = " 1=1 ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " and (role_name like '%" + key + "%' or role_level like '%" + key + "%' )";
            }
            string table = "approve_role";
            string show = "sid,role_name,role_level,role_status";

            dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);

        }

        public string Edit(HttpContext context)
        {
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.approve_role> insert = new List<Model.approve_role>();
            insert = JsonSerializerHelper.JSONStringToList<Model.approve_role>(addstr);
            List<Model.approve_role> update = new List<Model.approve_role>();
            update = JsonSerializerHelper.JSONStringToList<Model.approve_role>(updatestr);
            List<Model.approve_role> del = new List<Model.approve_role>();
            del = JsonSerializerHelper.JSONStringToList<Model.approve_role>(delstr);

            return null;//new BLL.approve_role().Edit(insert, update, del);
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