using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.DBUtility;
using System.Data;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// Supplier 的摘要说明
    /// </summary>
    public class Supplier : IHttpHandler, IRequiresSessionState
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
                default: break;
            }
            context.Response.Write(reValue);
        }

        public string QueryList(HttpContext context)
        {
            string table = 
                " (select a.ID, a.TypeID, b.Code ST_Code, b.Name, a.Code, a.Enabled, dbo.getDictCaption(9,a.Enabled)EnabledName, " +
                "     Abbreviation, a.FullName, a.EnAbbreviation, a.EnFullName, a.Address, " +
                "     EnAddress, a.Margin, a.TaxRate, a.TypeCode, a.Currency, " +
                "     ZipCode, a.PaymentTerms, a.Principal, a.Linkman, a.Buyer, " +
                "     PurchasingCycle, a.PurchasingCycleTable, a.PurchasingGoodsCycle, a.PaymentMethod, a.LandTransportation, " +
                "     SeaTransportation, a.AirTransportation, a.OtherTransportation, a.DepositBank, a.BankAccount, " +
                "     PSubject, a.POSubject, a.TSubject, a.PCProject, a.TCProject, " +
                "     Fixed, a.Fax, a.Mobile, a.Status, a.Remark, " +
                "     dbo.getUserName_fu(a.CreateUser)CreateUser, convert(nvarchar,a.CreateDate,120)CreateDate, " +
                "     dbo.getUserName_fu(a.UpdateUser)UpdateUser, convert(nvarchar,a.UpdateDate,120)UpdateDate "+
                " from Supplier a join SupplierType b on a.TypeID=b.ID)t ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "Code";
            switch (sort)
            {
                case "CreateUser": sort = "dbo.getUserName_fu(CreateUser)"; break;
                case "UpdateUser": sort = "dbo.getUserName_fu(UpdateUser)"; break;
                case "Enabled": sort = "dbo.getDictCaption(9,Enabled)"; break;
                default: break;
            }
            string show = " * ";
               
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "asc";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where +=
                    " and(Name like '%" + key + "%' " +
                    "     or Code like '%" + key + "%' " +
                    "     or dbo.getDictCaption(9,Enabled) like '%" + key + "%' " +
                    "     or Remark like '%" + key + "%' " +
                    "     or dbo.getUserName_fu(CreateUser) like '%" + key + "%' " +
                    "     or convert(nvarchar,CreateDate,120) like '%" + key + "%' " +
                    "     or dbo.getUserName_fu(UpdateUser) like '%" + key + "%' " +
                    "     or convert(nvarchar,UpdateDate,120) like '%" + key + "%' " +
                    " )";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        public string Add(HttpContext context)
        {
            try
            {
                return new BLL.Supplier().Add(GetSupplier(context), context.Request.Form["ST_Code"]) > 0 ? "ok" : "保存失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string Update(HttpContext context)
        {
            try
            {
                return new BLL.Supplier().Update(GetSupplier(context), context.Request.Form["ST_Code"]) ? "ok" : "保存失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string Dels(HttpContext context)
        {
            try
            {
                //int count = new BLL.Supplier().DeleteList(context.Request.Params["cbx_select"]);
                //return count == 1 ? "删除成功。" : count == 0 ? "有供应商的类别未删除。" : "删除失败。";
                return new BLL.Supplier().DeleteList(context.Request.Params["cbx_select"]) ? "删除成功。" : "删除失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public Model.Supplier GetSupplier(HttpContext context)
        {
            Model.Supplier s = new Model.Supplier();
            if (context.Request["action"] == "add")
            {
                s.CreateDate = DateTime.Now;
                s.CreateUser = (context.Session["login"] as Model.BaseUser).UserName;
            }
            else
            {
                s.ID = long.Parse(context.Request.Form["hdID"]);
                s.Code = context.Request.Form["hdCode"].Trim();
                s.UpdateDate = DateTime.Now;
                s.UpdateUser = (context.Session["login"] as Model.BaseUser).UserName;
            }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["Margin"]))
            {
                s.Margin = decimal.Parse(context.Request.Form["Margin"]);
            }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["TaxRate"]))
            {
                s.TaxRate = decimal.Parse(context.Request.Form["TaxRate"]);
            }
            s.TypeID = context.Request.Form["TypeID"].Trim();
            s.Enabled = context.Request.Form["Enabled"] == null ? true : false;
            s.Abbreviation = context.Request.Form["Abbreviation"].Trim();
            s.Address = context.Request.Form["Address"].Trim();
            s.AirTransportation = context.Request.Form["AirTransportation"].Trim();
            s.BankAccount = context.Request.Form["BankAccount"].Trim();
            s.Buyer = context.Request.Form["Buyer"].Trim();
            s.Currency = context.Request.Form["Currency"].Trim();
            s.DepositBank = context.Request.Form["DepositBank"].Trim();
            s.EnAbbreviation = context.Request.Form["EnAbbreviation"].Trim();
            s.EnAddress = context.Request.Form["EnAddress"].Trim();
            s.EnFullName = context.Request.Form["EnFullName"].Trim();
            s.FullName = context.Request.Form["FullName"].Trim();
            s.LandTransportation = context.Request.Form["LandTransportation"].Trim();
            s.Linkman = context.Request.Form["Linkman"].Trim();
            s.OtherTransportation = context.Request.Form["OtherTransportation"].Trim();
            s.PaymentMethod = context.Request.Form["PaymentMethod"].Trim();
            s.PaymentTerms = context.Request.Form["PaymentTerms"].Trim();
            s.PCProject = context.Request.Form["PCProject"].Trim();
            s.POSubject = context.Request.Form["POSubject"].Trim();
            s.Principal = context.Request.Form["Principal"].Trim();
            s.PSubject = context.Request.Form["PSubject"].Trim();
            s.PurchasingCycle = context.Request.Form["PurchasingCycle"].Trim();
            s.PurchasingCycleTable = context.Request.Form["PurchasingCycleTable"].Trim();
            s.PurchasingGoodsCycle = context.Request.Form["PurchasingGoodsCycle"].Trim();
            s.Remark = context.Request.Form["Remark"].Trim();
            s.SeaTransportation = context.Request.Form["SeaTransportation"].Trim();
            s.TCProject = context.Request.Form["TCProject"].Trim();
            s.TSubject = context.Request.Form["TSubject"].Trim();
            s.TypeCode = context.Request.Form["TypeCode"].Trim();           
            s.ZipCode = context.Request.Form["ZipCode"].Trim();
            return s;
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