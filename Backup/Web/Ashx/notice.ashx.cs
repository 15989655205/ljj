using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// notice 的摘要说明
    /// </summary>
    public class notice : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            if (bu == null && context.Request["action"] != "list")
            {
                context.Response.Write("登录超时，请重新登录。");
                return;
            }
            string reValue = string.Empty;
            switch (context.Request["action"])
            {
                case "list":
                    reValue = QueryList(context);
                    break;
                case "add":
                    reValue = Add(context);
                    break;
                case "edit":
                    reValue = Update(context);
                    break;
                case "dels":
                    reValue = Dels(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            string table = " notice ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : " CreateTime ";
            switch (sort)
            {
                case "create_name": sort = "dbo.getUserName(CreateUserID)"; break;
                case "create_date": sort = "CreateTime"; break;
                case "update_name": sort = "dbo.getUserName(UpdateUserID)"; break;
                case "update_date": sort = "UpdateTime"; break;
                default: break;
            }
            string show =
               " id, title, summary, intro, notice_content, dbo.getUserName(CreateUserID)create_name, convert(nvarchar,CreateTime,120)create_date, " +
               " dbo.getUserName(UpdateUserID)update_name, convert(nvarchar,UpdateTime,120)update_date ";
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " and(title like '%" + key + "%' " +
                    "     or summary like '%" + key + "%' " +
                    "     or dbo.getUserName(CreateUserID) like '%" + key + "%' " +
                    "     or CreateTime like '%" + key + "%' " +
                    "     or dbo.getUserName(UpdateUserID) like '%" + key + "%' " +
                    "     or UpdateTime like '%" + key + "%' " +                    
                    " )";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string Add(HttpContext context)
        {
            try
            {
                return new BLL.notice().Add(Getnotice(context)) > 0 ? "ok" : "保存失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private string Update(HttpContext context)
        {
            try
            {
                return new BLL.notice().Update(Getnotice(context)) ? "ok" : "保存失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private string Dels(HttpContext context)
        {
            try
            {
                string selectid = context.Request.Params["cbx_select"].Trim();
                return new BLL.notice().DeleteList(selectid) ? "ok" : "删除失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private Model.notice Getnotice(HttpContext context)
        {
            Model.notice n = new Model.notice();
            n.title = context.Request["title"].Trim();
            n.summary = context.Request["summary"].Trim();
            n.intro = context.Request["intro"].Trim();
            n.notice_content = context.Request["notice_content"];
            if (context.Request["action"] == "add")
            {
                n.CreateTime = DateTime.Now;
                n.CreateUserID = (context.Session["login"] as Model.BaseUser).UserID;
            }
            else
            {
                n.id = int.Parse(context.Request["id"]);
                n.UpdateTime = DateTime.Now;
                n.UpdateUserID = (context.Session["login"] as Model.BaseUser).UserID;
            }
            return n;
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