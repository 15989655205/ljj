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
    /// SupplierType 的摘要说明
    /// </summary>
    public class SupplierType : IHttpHandler, IRequiresSessionState
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
                case "combobox":
                    reValue = Combobox(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        public string QueryList(HttpContext context)
        {
            string table = " SupplierType ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "Code";
            switch (sort)
            {
                case "CreateUser": sort = "dbo.getUserName_fu(CreateUser)"; break;
                case "UpdateUser": sort = "dbo.getUserName_fu(UpdateUser)"; break;
                case "Enabled": sort = "dbo.getDictCaption(9,Enabled)"; break;
                default: break;
            }
            string show =
               " ID, Code, Name, Enabled, dbo.getDictCaption(9,Enabled)EnabledName, Remark, " +
               " dbo.getUserName_fu(CreateUser)CreateUser, convert(nvarchar,CreateDate,120)CreateDate, " +
               " dbo.getUserName_fu(UpdateUser)UpdateUser, convert(nvarchar,UpdateDate,120)UpdateDate ";
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "asc";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where +=
                    " and ( " +
                    "     Name like '%" + key + "%' " +
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

        public string Combobox(HttpContext context)
        {
            DataTable dt = new BLL.SupplierType().GetList().Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_ValueText(dt, "value", "text");
        }

        public string Add(HttpContext context)
        {
            try
            {
                return new BLL.SupplierType().Add(GetSupplierType(context)) > 0 ? "ok" : "保存失败。";
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
                return new BLL.SupplierType().Update(GetSupplierType(context)) ? "ok" : "保存失败。";
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
                int count= new BLL.SupplierType().DeleteList(context.Request.Params["cbx_select"]);
                return count == 1 ? "删除成功。" : count == 0 ? "有供应商的类别未删除。" : "删除失败。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public Model.SupplierType GetSupplierType(HttpContext context)
        {
            Model.SupplierType st = new Model.SupplierType();
            if (context.Request["action"] == "add")
            {
                st.CreateDate = DateTime.Now;
                st.CreateUser = (context.Session["login"] as Model.BaseUser).UserName;
            }
            else
            {
                st.ID = long.Parse(context.Request.Form["hdID"]); 
                st.Code = context.Request.Form["hdCode"].Trim();
                st.UpdateDate = DateTime.Now;
                st.UpdateUser = (context.Session["login"] as Model.BaseUser).UserName;
            }
           
            st.Name = context.Request.Form["txtName"].Trim();
            st.Remark = context.Request.Form["txtRemark"].Trim();
            return st;
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