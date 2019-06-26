using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;
using System.Text;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// BaseDepartment 的摘要说明
    /// </summary>
    public class BaseDepartment : IHttpHandler, IRequiresSessionState
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

        private string QueryList(HttpContext context)
        {
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 ";           
            string fields =
                " DeptID, ParentDeptID, DeptName, CONVERT(NVARCHAR(10),CreatedDate,120)CreatedDate, CreatedGuy, " +
                " UpdatedGuy, CONVERT(NVARCHAR(10),UpdatedDate,120)UpdatedDate, Remark, " +
                " dbo.getUserName(CreatedGuy)CreatedGuyName, dbo.getUserName(UpdatedGuy)UpdatedGuyName ";
            DataTable dt = new BLL.BaseDepartment().GetList(fields, where).Tables[0];
            return DT2GTree(dt, "ParentDeptID");
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
                    if (dt.Select(" ParentDeptID=" + dr["DeptID"]).Length > 0)
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
            return  JsonString.ToString();
        }

        private string Add(HttpContext context)
        {
            try
            {
                return new BLL.BaseDepartment().Add(GetBaseDepartment(context)) ? "ok" : "保存失败。";
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
                return new BLL.BaseDepartment().Update(GetBaseDepartment(context)) ? "ok" : "保存失败。";
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
                return new BLL.BaseDepartment().DeleteList(context.Request.Params["cbx_select"]) ? "删除成功。" : "有子部门或员工的部门没有删除。";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private Model.BaseDepartment GetBaseDepartment(HttpContext context)
        {
            Model.BaseDepartment dep = new Model.BaseDepartment();
            dep.DeptName = context.Request.Form["txtDeptName"].Trim();
            dep.ParentDeptID = string.IsNullOrWhiteSpace(context.Request.Form["txtParentDeptID"]) ? 0 : int.Parse(context.Request.Form["txtParentDeptID"]);
            if (context.Request["action"] == "add")
            {
                dep.CreatedDate = DateTime.Now;
                dep.CreatedGuy = Convert.ToInt32((context.Session["login"] as Model.BaseUser).UserID);
            }
            else
            {
                dep.DeptID = int.Parse(context.Request.Form["hdID"]);
                dep.UpdatedDate = DateTime.Now;
                dep.UpdatedGuy = Convert.ToInt32((context.Session["login"] as Model.BaseUser).UserID);
            }
            dep.Remark = context.Request.Form["txtRemark"].Trim();
            return dep;
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