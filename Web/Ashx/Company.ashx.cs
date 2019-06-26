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
    /// Company 的摘要说明
    /// </summary>
    public class Company : IHttpHandler, IReadOnlySessionState
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
                case "Number": reValue = Number(context); break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            string table = "CompanyInformation";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "Number";
            string show =
                " ID, Number, Abbreviation, FullName, Address, EnAddress, Head, FixedPhone, MobilePhone, Fax, ZipCode, " +
                " OpeningBank, Account, CustomsCode, LegalRepresentative, Remark, EnAbbreviation, EnFullName, CreateUser, "+                       " CreateDate, UpdateUser, UpdateDate";
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
                    " and (" +
                    "     Number like '%" + key + "%' " +
                    "     or Abbreviation like '%" + key + "%' " +
                    "     or FullName like '%" + key + "%' " +
                    "     or Address like '%" + key + "%' " +
                    "     or EnAddress like '%" + key + "%' " +
                    "     or Head like '%" + key + "%' " +
                    "     or FixedPhone like '%" + key + "%' " +
                    "     or MobilePhone like '%" + key + "%' " +
                    "     or Fax like '%" + key + "%' " +
                    "     or ZipCode like '%" + key + "%' " +
                    "     or OpeningBank like '%" + key + "%' " +
                    "     or Account like '%" + key + "%' " +
                    "     or CustomsCode like '%" + key + "%' " +
                    "     or LegalRepresentative like '%" + key + "%' " +
                    "     or Remark like '%" + key + "%'" +
                    "     or EnAbbreviation like '%" + key + "%'" +
                    "     or EnFullName like '%" + key + "%'" +
                    "     or CreateUser like '%" + key + "%'" +
                    "     or CreateDate like '%" + key + "%'" +
                    "     or UpdateUser like '%" + key + "%'" +
                    "     or UpdateDate like '%" + key + "%'" +
                    " ) ";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string Add(HttpContext context)
        {
            try
            {
                return new BLL.CompanyInformation().Add(GetCompany(context)) > 0 ? "ok" : "保存失败。";
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
                return new BLL.CompanyInformation().Update(GetCompany(context)) ? "ok" : "保存失败。";
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
                return new BLL.CompanyInformation().DeleteList(selectid) ? "ok" : "删除失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private Model.CompanyInformation GetCompany(HttpContext context)
        {
            Model.CompanyInformation companyModel = new Model.CompanyInformation();
            companyModel.ID = context.Request["action"] == "add" ? 0 : int.Parse(context.Request.Form["hdID"].Trim());
            companyModel.Number = context.Request.Form["txtNumber"].Trim();
            companyModel.Abbreviation = context.Request.Form["txtAbbreviation"].Trim();
            companyModel.FullName = context.Request.Form["txtFullName"].Trim();
            companyModel.Address = context.Request.Form["txtAddress"].Trim();
            companyModel.EnAddress = context.Request.Form["txtEnAddress"].Trim();
            companyModel.Head = context.Request.Form["txtHead"].Trim();
            companyModel.FixedPhone = context.Request.Form["txtFixedPhone"].Trim();
            companyModel.MobilePhone = context.Request.Form["txtMobilePhone"].Trim();
            companyModel.Fax = context.Request.Form["txtFax"].Trim();
            companyModel.ZipCode = context.Request.Form["txtZipCode"].Trim();
            companyModel.OpeningBank = context.Request.Form["txtOpeningBank"].Trim();
            companyModel.Account = context.Request.Form["txtAccount"].Trim();
            companyModel.CustomsCode = context.Request.Form["txtCustomsCode"].Trim();
            companyModel.LegalRepresentative = context.Request.Form["txtLegalRepresentative"].Trim();
            companyModel.Remark = context.Request.Form["txtRemark"].Trim();
            companyModel.EnFullName = context.Request.Form["txtEnFullName"].Trim();
            companyModel.EnAbbreviation = context.Request.Form["txtEnAbbreviation"].Trim();
            companyModel.CreateUser = ((Model.BaseUser)context.Session["login"]).UserName;
            companyModel.CreateDate =DateTime.Now;
            companyModel.UpdateUser = ((Model.BaseUser)context.Session["login"]).UserName;
            companyModel.UpdateDate = DateTime.Now;
            return companyModel;
        }

        private string Number(HttpContext hc)
        {
            return new BLL.CompanyInformation().ExistsToNumber(hc.Request["value"].Trim()) ? "存在" : "";
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