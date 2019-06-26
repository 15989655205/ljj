using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ProductType 的摘要说明
    /// </summary>
    public class ProductType : IHttpHandler, IReadOnlySessionState
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
                case "ComboTree":
                    reValue = ComboTree(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            DataTable dt = new BLL.ProductType().GetList("").Tables[0];
            return DT2GTree(dt, "ParentID");
        }

        private string ComboTree(HttpContext context)
        {
            DataTable dt = new BLL.ProductType().GetList("Level<>3").Tables[0];
            return new DBUtility.JsonHelper().DataTable2Json_Tree(dt, "ID", "CodeName", "ParentID", 0, "", "");
        }

        /// <summary>
        /// 将table转换为treegrid的json形式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="type"></param>
        /// <param name="pidName"></param>
        /// <returns></returns>
        public string DT2GTree(DataTable dt, string pidName)
        {
            string JsonString = "{\"total\":" + dt.Rows.Count + ",\"rows\":[";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    JsonString += "{";
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        JsonString += "\"" + dt.Columns[i].ColumnName + "\":\"" + dr[i] + "\",";
                    }
                    if (dr[pidName].ToString() != "0")
                    {
                        JsonString += "\"_parentId\":\"" + dr[pidName] + "\",";
                    }
                    if (dt.Select(" ParentID=" + dr["ID"]).Length > 0)
                    {
                        JsonString += "\"state\":\"closed\"";
                    }
                    else
                    {
                        JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    }
                    JsonString += "},";
                }
                JsonString = JsonString.Remove(JsonString.Length - 1, 1);
            }
            JsonString += "]}";
            return JsonString.ToString();
        }

        private string Add(HttpContext context)
        {
            try
            {
                return new BLL.ProductType().Add(GetProductType(context));//? "ok" : "保存失败。";
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
                return new BLL.ProductType().Update(GetProductType(context), long.Parse(context.Request.Form["OldParentID"])) ? "ok" : "保存失败。";
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
                return new BLL.ProductType().DeleteList(context.Request.Params["cbx_select"]) ? "删除成功。" : "有子部门或员工的部门没有删除。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private Model.ProductType GetProductType(HttpContext context)
        {
            Model.ProductType pt = new Model.ProductType();
            if (context.Request["action"] == "add")
            {
                pt.CreateDate = DateTime.Now;
                pt.CreateUser = (context.Session["login"] as Model.BaseUser).UserName;               
            }
            else
            {
                pt.UpdateDate = DateTime.Now;
                pt.UpdateUser = (context.Session["login"] as Model.BaseUser).UserName;
                pt.ID = long.Parse(context.Request.Form["ID"]);                
                pt.Code = context.Request.Form["Code"];
               
            }
            pt.ParentID = string.IsNullOrWhiteSpace(context.Request.Form["ParentID"]) ? 0 : long.Parse(context.Request.Form["ParentID"]);
            pt.Level = int.Parse(context.Request.Form["Level"]);    
            pt.Name = context.Request.Form["Name"];
            pt.Remark = context.Request.Form["Remark"];
            return pt;
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