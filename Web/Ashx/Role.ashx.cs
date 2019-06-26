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
    /// Role 的摘要说明
    /// </summary>
    public class Role : IHttpHandler, IReadOnlySessionState
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
            string where = " 1=1 ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " and (RoleID like '%" + key + "%' or RoleName like '%" + key + "%' or Note like '%" + key + "%' )";
            }
            string table = "BaseRole";
            string show = "*";
            string orderFiled = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "RoleID";
            string sort = context.Request.Form["order"] != null ? context.Request.Form["order"] : "asc";//"RoleID";

            dt = new BLL.BaseUser().GetList(table, orderFiled, show, page, rows, out total, sort, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);

        }

        public string Edit(HttpContext context)
        {
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.BaseRole> insert = new List<Model.BaseRole>();
            insert = JsonSerializerHelper.JSONStringToList<Model.BaseRole>(addstr);
            List<Model.BaseRole> update = new List<Model.BaseRole>();
            update = JsonSerializerHelper.JSONStringToList<Model.BaseRole>(updatestr);
            List<Model.BaseRole> del = new List<Model.BaseRole>();
            del = JsonSerializerHelper.JSONStringToList<Model.BaseRole>(delstr);

            return new BLL.BaseRole().Edit(insert, update, del);
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