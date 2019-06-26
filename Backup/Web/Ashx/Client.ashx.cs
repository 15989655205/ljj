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
    /// Client 的摘要说明
    /// </summary>
    public class Client : IHttpHandler, IReadOnlySessionState
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
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            string table = "Client";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "Code";
            string show =
                "ID, Code, Name, dbo.getClientLevel(CLevel)CLevel, dbo.getDictCaption(11,Type)Type," +
                "Address, Head, Phone, Tel, Fax, Email, BusinessLicense, Currency, Parities,"+
                "convert(nvarchar,ReconciliationDate,23)ReconciliationDate," +
                "convert(nvarchar,SetupDate,23)SetupDate, Supplier, Status, Area, Industry, Remark," +
                "convert(nvarchar,BeginDate,23)BeginDate,convert(nvarchar,EndDate,23)EndDate," +
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
                    "     or dbo.getClientLevel(CLevel) like '%" + key + "%' " +
                    "     or dbo.getDictCaption(11,Type) like '%" + key + "%' " +
                    "     or Address like '%" + key + "%' " +
                    "     or Head like '%" + key + "%' " +
                    "     or Phone like '%" + key + "%' " +
                    "     or Tel like '%" + key + "%' " +
                    "     or Fax like '%" + key + "%' " +
                    "     or Email like '%" + key + "%' " +
                    "     or BusinessLicense like '%" + key + "%' " +
                    "     or Parities like '%" + key + "%' " +
                    "     or convert(nvarchar,ReconciliationDate,23) like '%" + key + "%' " +
                    "     or convert(nvarchar,SetupDate,23) like '%" + key + "%' " +
                    "     or Industry like '%" + key + "%' " +
                    "     or Area like '%" + key + "%' " +
                    "     or convert(nvarchar,BeginDate,23) like '%" + key + "%' " +
                    "     or convert(nvarchar,EndDate,23) like '%" + key + "%' " +
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
                return new BLL.Client().Add(GetClient(context)) > 0 ? "ok" : "保存失败。";
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
                return new BLL.Client().Update(GetClient(context)) ? "ok" : "保存失败。";
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
                return new BLL.Client().DeleteList(selectid) ? "ok" : "删除失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private Model.Client GetClient(HttpContext hc)
        {
            Model.Client c = new Model.Client();
            if (hc.Request["action"] == "add")
            {
                c.CreateUser = (hc.Session["login"] as Model.BaseUser).UserID;
                c.CreateDate = DateTime.Now;
            }
            else
            {
                c.ID = long.Parse(hc.Request.Form["ID"].Trim());
                c.UpdateUser = (hc.Session["login"] as Model.BaseUser).UserID;
                c.UpdateDate = DateTime.Now;
            }
            c.Code = hc.Request.Form["Code"].Trim();
            c.Name = hc.Request.Form["Name"].Trim();
            c.Address = hc.Request.Form["Address"].Trim();
            c.Area = hc.Request.Form["Area"].Trim();
            c.BeginDate = DateTime.Parse(hc.Request.Form["BeginDate"].Trim());
            c.BusinessLicense = hc.Request.Form["BusinessLicense"].Trim();
            c.CLevel = long.Parse(hc.Request.Form["CLevel"].Trim());
            c.Currency = hc.Request.Form["Currency"].Trim();
            c.Email = hc.Request.Form["Email"].Trim();
            c.EndDate = DateTime.Parse(hc.Request.Form["EndDate"].Trim());
            c.Fax = hc.Request.Form["Fax"].Trim();
            c.Head = hc.Request.Form["Head"].Trim();
            c.Industry = hc.Request.Form["Industry"].Trim();
            c.Parities = decimal.Parse(hc.Request.Form["Parities"].Trim());
            c.Phone = hc.Request.Form["Phone"].Trim();
            c.ReconciliationDate = DateTime.Parse(hc.Request.Form["ReconciliationDate"].Trim());
            c.SetupDate = DateTime.Parse(hc.Request.Form["SetupDate"].Trim());
            c.Supplier = hc.Request.Form["Supplier"] == "1";
            c.Type = long.Parse(hc.Request.Form["Type"].Trim());
            c.Remark = hc.Request.Form["Remark"].Trim();
            return c;
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