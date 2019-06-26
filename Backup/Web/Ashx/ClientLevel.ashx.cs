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
    /// ClientLevel 的摘要说明
    /// </summary>
    public class ClientLevel : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Session["login"] == null)
            {
                context.Response.Write("登录超时，请重新登录。");
                return;
            }
            string type = context.Request["action"];
            string reValue = "";
            switch (type)
            {
                case "list": reValue = QueryList(context); break;
                case "add": reValue = Add(context); break;
                case "update": reValue = Update(context); break;
                case "dels": reValue = Dels(context); break;
                case "cb": reValue = GetComboBox(context); break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            string table = "ClientLevel";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "Code";
            //switch (sort)
            //{
            //    case "ReferencePrice": sort = "dbo.getDictCaption(10,ReferencePrice)"; break;
            //    case "CreateUser": sort = "dbo.getUserName(CreateUser)"; break;
            //    case "CreateDate": sort = "convert(nvarchar,CreateDate,120)"; break;
            //    case "UpdateUser": sort = "dbo.getUserName(UpdateUser)"; break;
            //    case "UpdateDate": sort = "convert(nvarchar,UpdateDate,120)"; break;
            //    default:break;
            //}
            string show =
                "ID, Code, Name, ReferencePrice, dbo.getDictCaption(10,ReferencePrice)ReferencePriceName, Percentage, Remark," +
                "dbo.getUserName(CreateUser)CreateUser, convert(nvarchar,CreateDate,120)CreateDate," +
                "dbo.getUserName(UpdateUser)UpdateUser, convert(nvarchar,UpdateDate,120)UpdateDate";
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
                    " and(Code like '%" + key + "%' " +
                    "     or Name like '%" + key + "%' " +
                    "     or dbo.getDictCaption(10,ReferencePrice) like '%" + key + "%' " +
                    "     or Percentage like '%" + key + "%' " +
                    "     or Remark like '%" + key + "%' " +
                    "     or dbo.getUserName(CreateUser) like '%" + key + "%' " +
                    "     or convert(nvarchar,CreateDate,120) like '%" + key + "%' " +
                    "     or dbo.getUserName(UpdateUser) like '%" + key + "%' " +
                    "     or convert(nvarchar,UpdateDate,120) like '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string Add(HttpContext context)
        {
            try
            {
                return new BLL.ClientLevel().Add(GetClientLevel(context)) > 0 ? "ok" : "保存失败。";
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
                return new BLL.ClientLevel().Update(GetClientLevel(context)) ? "ok" : "保存失败。";
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
                return new BLL.ClientLevel().DeleteList(selectid) ? "ok" : "删除失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private Model.ClientLevel GetClientLevel(HttpContext hc)
        {
            Model.ClientLevel cl = new Model.ClientLevel();
            if (hc.Request["action"] == "add")
            {
                cl.CreateUser = (hc.Session["login"] as Model.BaseUser).UserID;
                cl.CreateDate = DateTime.Now;
            }
            else
            {
                cl.ID = long.Parse(hc.Request.Form["ID"].Trim());
                cl.UpdateUser = (hc.Session["login"] as Model.BaseUser).UserID;
                cl.UpdateDate = DateTime.Now;
            }
            cl.Name = hc.Request.Form["Name"].Trim();
            cl.Remark = hc.Request.Form["Remark"].Trim();
            cl.Percentage = decimal.Parse(hc.Request.Form["Percentage"].Trim());
            cl.ReferencePrice = int.Parse(hc.Request.Form["ReferencePrice"].Trim());
            return cl;
        }

        private string GetComboBox(HttpContext hc)
        {
            DataTable dt = new BLL.ClientLevel().GetList().Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_ValueText(dt, "value", "text");
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