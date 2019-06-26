using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using Maticsoft.DBUtility;
using System.Text;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ProductBom 的摘要说明
    /// </summary>
    public class ProductBom : IHttpHandler, IReadOnlySessionState
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
                    reValue = BomList(context);
                    break;
                case "bomSave":
                    reValue = BomSave(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            string pid = context.Request["pid"] != null ? context.Request["pid"].Trim() : "";
            int total = 0;
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "id";
            string where = " 1=1 and ParentID='"+pid+"'";
            string table = "ProductColor";
            string show = "*";
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string BomList(HttpContext context)
        {
            string id = context.Request["id"] != null ? context.Request["id"].Trim() : "";
            string pid = context.Request["pid"] != null ? context.Request["pid"].Trim() : "";
            //int total = 0;
            //int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            //int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            //string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            //string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "id";
            //string where = " 1=1 and PID='" + pid + "'";
            //string table = "v_ProductShip";
            //string show = "*";
            DataTable dt = new DataTable();
            //DataSet ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            string where = "";
            if (id != pid)
            {
                where = " where PID=(select CID from ProductShip where ID=" + id + ")";
            }
            else
            {
                where = " where PID=" + id;
            }
            DataSet ds = new BLL.Common().GetList("select (Code+ColorCode)PCCode, *,(select count(1) from ProductShip where PID=v_ProductShip.CID) child from v_ProductShip " + where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DT2GridTree(dt, 0, "PID", pid);
            string json = "";
            //if (id == "0")
            //{
            //    json += "{\"total\":";
            //    //JsonString.Append(dt.Rows.Count.ToString());
            //    json += dt.Rows.Count.ToString();
            //    json += ",";
            //    json += "\"rows\":";
            //}

            json += DT2GridTree(dt, 0, "PID", pid); 

            //if (id == "0")
            //{
            //    json += "}";
            //}

            return json;
        }

        private string BomSave(HttpContext context)
        {
            string pid = context.Request["pid"] != null ? context.Request["pid"].Trim() : "";
            string allstr = context.Request.Params["allstr"].Trim();
            List<Model.ProductShip> all = new List<Model.ProductShip>();
            all = JsonSerializerHelper.JSONStringToList<Model.ProductShip>(allstr);

            return new DAL.Product().BomSave(all,pid);
        }

        public static string DT2GridTree(DataTable dt, int type, string pidName,string pid)
        {
            StringBuilder JsonString = new StringBuilder();
            //JsonString.Append("{\"total\":" + dt.Rows.Count + ",\"rows\":[");
            JsonString.Append("[");
            if (dt != null && dt.Rows.Count > 0)
            {
                //JsonString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    if (dt.Rows[i]["PID"].ToString().Trim() == pid)
                    {
                        JsonString.Append("\"iconCls\":\"icon-file\",");
                    }
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + DBUtility.JsonHelper.DataConversion(dt.Rows[i][j].ToString()) + "\",");
                    }
                    if (dt.Rows[i][pidName].ToString().Trim() != pid)
                    {
                        JsonString.Append("\"_parentId\":\"" + DBUtility.JsonHelper.DataConversion(dt.Rows[i][pidName].ToString()) + "\",");
                    }
                    if (dt.Rows[i]["child"].ToString().Trim() != "0")
                    {
                        JsonString.Append("\"state\":\"closed\"");
                    }
                    else
                    {
                        JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    }
                    JsonString.Append("},");
                }
                if (dt.Rows.Count > 0)
                {
                    JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                }
                //JsonString.Append("]");
                //return JsonString.ToString();
            }
            else
            {
                //return null;
            }
            JsonString.Append("]");
            //JsonString = JsonString.Remove(JsonString.Length - 1, 1);
            //JsonString.Append("]}");
            return JsonString.ToString();
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