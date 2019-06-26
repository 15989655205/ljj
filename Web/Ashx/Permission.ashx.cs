using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.DBUtility;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Web.SessionState;
using System.Data;
using Maticsoft.BLL;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// Permission 的摘要说明
    /// </summary>
    public class Permission : IHttpHandler,IReadOnlySessionState
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
            string type = context.Request["type"];
            string reValue = string.Empty;
            switch (type)
            {
                case "list": reValue = GetAllPermission(context); break;
                case "Role_Page": reValue = GetRolePage(context); break;
                case "sub_per": reValue = SubPer(context); break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string GetAllPermission(HttpContext hc)
        {
            DataTable dt = new DataTable();
            string table = " BaseMenu a left join BasePage b on a.PageID=b.PageID ";
            string show = " MenuID, ParentMenuID, a.PageID, MenuName, Cmds, dbo.getPermissionNames(Cmds)PerNames, ''value ";
            string where = " 1=1 ";
            int total = 0;
            dt = DbHelperSQL.GetList_ProcPage(table, " ParentMenuID,IDX ", show, 1, int.MaxValue, out total, "asc", where).Tables[0];
            string JsonString = ("{\"total:\":" + dt.Rows.Count + ",\"rows\":[");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    JsonString += "{";
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        JsonString += "\"" + dt.Columns[i].ColumnName + "\":\"" + dr[i] + "\",";
                    }
                    if (dr["ParentMenuID"].ToString() != "0")
                    {
                        JsonString += "\"_parentId\":\"" + dr["ParentMenuID"] + "\",";
                    }
                    if (dt.Select(" ParentMenuID=" + dr["MenuID"]).Length > 0)
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
            return dt.Rows.Count > 0 ? JsonString.ToString() : null;
        }

        private string GetRolePage(HttpContext context)
        {
            string result = "";
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_permission", WCDataAction.Query1);
            dsp.InputPars.Add("@RolseID", context.Request["RolseID"]);
            if (db.Execute(dsp).ExecuteState)
            {
                result = dsp.OutputPars["@strOut"].ToString();
            }
            return result;
        }

        private string SubPer(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_permission", WCDataAction.Query2);
            dsp.InputPars.Add("@sql", context.Request["SQLString"]);
            dsp.InputPars.Add("@RolseID", context.Request["RolseID"]);

            //dsp.InputPars.Add("@name", ((Model.BaseUser)context.Session["login"]).UserName);
            //dsp.InputPars.Add("@operation", "修改");
            dsp.InputPars.Add("@createPerson",( (Model.BaseUser)context.Session["login"]).UserName );
            //dsp.InputPars.Add("@updatePerson", ((Model.BaseUser)context.Session["login"]).UserName);
            //dsp.InputPars.Add("@updateTime",DateTime.Now);
            if (db.Execute(dsp).ExecuteState)
            {
                return "保存成功。";
            }
            else
            {
                return "保存失败。";
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