using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// windows 的摘要说明
    /// </summary>
    public class windows : IHttpHandler, IReadOnlySessionState
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
                case "productColor":
                    reValue = ProductColor(context);
                    break;
                case "ProjectProductBatch":
                    reValue = ProjectProductBatch(context);
                    break;
                case "product":
                    reValue = Product(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        private string Product(HttpContext context)
        {
            int total = 0;
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "asc";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "Name";
            string where = "";//" 1=1 and id not in (select * from dbo.getTable(isnull(dbo.getParentNode(" + id + ")," + id + "),',')) and id not in(" + childs + ")";
            string table = "Product";
            string show = "*,dbo.getProductUnitName(Unit) UnitName";
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string ProductColor(HttpContext context)
        {
            string id = context.Request["id"] != null ? context.Request["id"].Trim() : "0";
            string childs =context.Request["child"]!=null ? context.Request["child"].Trim() : "0";
            if (childs.Trim() == "")
            {
                childs = "0";
            }
            int total = 0;
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "id";
            string where = " 1=1 and id not in (select * from dbo.getTable(isnull(dbo.getParentNode(" + id + ")," + id + "),',')) and id not in(" + childs + ")";
            string table = "v_ProductColorShip";
            string show = "(Code+ColorCode)PCCode,*";
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string ProjectProductBatch(HttpContext context)
        {
            string productID = context.Request["productID"] != null ? context.Request["productID"].Trim() : "0";
            productID =!string.IsNullOrEmpty(productID) ? context.Request["productID"].Trim() : "0";
            int total = 0;
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "id";
            string where = " 1=1 and id not in (" + productID + ") ";
            string table = "v_ProductColorShip";
            string show = "(Code+ColorCode)PCCode,*";
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
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