using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// Approve_role 的摘要说明
    /// </summary>
    public class Approve_role : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Session["login"] == null)
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
                case "checkRn":
                    reValue = checkRn(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        { 
            string table = " approve_role ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : " role_level ";
            switch (sort)
            {
                case "create_personName": sort = "dbo.getUserName(create_person)"; break;
                case "update_personName": sort = "dbo.getUserName(update_person)"; break;
                default: break;
            }
            string show =
               " sid, role_name, role_level, role_status, remark, create_person, CONVERT(NVARCHAR(10),create_date,120)create_date, " +
               " update_person, CONVERT(NVARCHAR(10),update_date,120)update_date, " +
               " dbo.getUserName(create_person)create_personName, dbo.getUserName(update_person)update_personName ";
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "asc";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " and ( " +
                    "     role_name like '%" + key + "%' " +
                    "     or role_level like '%" + key + "%' " +
                    "     or role_status like '%" + key + "%' " +
                    "     or remark like '%" + key + "%' " +
                    "     or create_date like '%" + key + "%' " +
                    "     or update_date like '%" + key + "%' " +
                    "     or dbo.getUserName(create_person) like '%" + key + "%' " +
                    "     or dbo.getUserName(update_person) like '%" + key + "%' " +
                    "     or Remark like '%" + key + "%' " +
                    " )";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string Add(HttpContext context)
        {
            try
            {
                return new BLL.approve_role().Add(Getapprove_role(context)) ? "ok" : "保存失败。";
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
                return new BLL.approve_role().Update(Getapprove_role(context)) ? "ok" : "保存失败。";
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
                return new BLL.approve_role().DeleteList(selectid) ? "ok" : "删除失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private Model.approve_role Getapprove_role(HttpContext context)
        {
            Model.approve_role role = new Model.approve_role();
            role.role_name = context.Request.Form["txtrole_name"].Trim();
            role.role_level = int.Parse(context.Request.Form["txtrole_level"]);
            role.remark = context.Request.Form["txtremark"].Trim();
            if (context.Request["action"] == "add")
            {
                role.create_date = DateTime.Now;
                role.create_person = (context.Session["login"] as Model.BaseUser).UserID.ToString();
            }
            else
            {
                role.sid = int.Parse(context.Request.Form["hdID"]);
                role.update_date = DateTime.Now;
                role.update_person = (context.Session["login"] as Model.BaseUser).UserID.ToString();
            }
            return role;
        }

        private string checkRn(HttpContext context)
        {
            try
            {
                return new BLL.approve_role().Exists(context.Request["value"]) ? "存在" : "";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
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