using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Maticsoft.DBUtility;
using System.Data;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// kaoqin 的摘要说明
    /// </summary>
    public class kaoqin : IHttpHandler, IReadOnlySessionState
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
            //context.Response.Write("Hello World");
            string action = context.Request["action"];
            string reValue = "";
            switch (action)
            {
                case "myCheck":
                    reValue = GetMyCheck(context);
                    break;
                case "AllCheck":
                    reValue = GetAllCheck(context);
                    break;
                case"s_myCheck":
                    reValue = SMyCheck(context);
                    break;
                case"s_AllCheck":
                    reValue = SAllCheck(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        private string SAllCheck(HttpContext context)
        {
            string result = "{\"total\":0,\"rows\":[]}";
            DataTable dt = new DataTable();
            string where = "1=1";
            if (context.Request["userName"] != "" || !string.IsNullOrEmpty(context.Request["userName"]))
            {
                where += " and Name like '%" + context.Request["userName"]+"%'";
            }

            if (context.Request["workID"] != "" || !string.IsNullOrEmpty(context.Request["workID"]))
            {
                where += " and WorkID like '%" + context.Request["workID"]+"%'";
            }
            if (!string.IsNullOrEmpty(context.Request["startTime"]) & !string.IsNullOrEmpty(context.Request["endTime"]))
            {
                where += " and KaoQinRiQi between '" + context.Request["startTime"].ToString().Trim() + " 00:00:00'" + " and '" + context.Request["endTime"].Trim() + " 23:59:59'";
            }
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "asc";
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "b.UserID";
            
            string table = "ERPKaoQin as a inner join BaseUser as b on a.UserID=b.UserID";
            string show = "convert(nvarchar(14),a.KaoQinRiQi,23) as T,(isnull((convert(nvarchar(40),DengJiTime1,20)),'')+case when GuiDingTime1<DengJiTime1 then ' (迟到)' when DengJiTime1 is NULL then '未登记' else ' (正常)' end) as DengJiTime1,(isnull((convert(nvarchar(40),DengJiTime2,20)),'')+case when GuiDingTime2>DengJiTime2 then ' (早退)' when DengJiTime2 is NULL then '未登记'  else ' (正常)' end) as DengJiTime2,(isnull((convert(nvarchar(40),DengJiTime3,20)),'')+case when GuiDingTime3<DengJiTime3 then ' (迟到)' when DengJiTime3 is NULL then '未登记'  else ' (正常)' end) as DengJiTime3,(isnull((convert(nvarchar(40),DengJiTime4,20)),'')+case when GuiDingTime4>DengJiTime4 then ' (早退)' when DengJiTime4 is NULL then '未登记' else ' (正常)' end) as DengJiTime4,b.* ";

            dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            result = DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            return result;
        }

        private string SMyCheck(HttpContext context)
        {
            string result = "{\"total\":0,\"rows\":[]}";
            if (context.Session["login"] == null)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('登录信息安全时限过期，请重新登录！');top.location='../Login.aspx'</script>");
            }
            else
            {
                DataTable dt = new DataTable();
                Model.BaseUser buModel = (Model.BaseUser)context.Session["login"];
                int total = 0;
                int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
                int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
                string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
                string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "asc";
                string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "b.UserID";
                string where = " 1=1 and a.UserID=" + buModel.UserID + " and KaoQinRiQi between '" + context.Request["startTime"].ToString().Trim() + " 00:00:00'" + " and '" + context.Request["endTime"].Trim() + " 23:59:59'"; ;
                string table = "ERPKaoQin as a inner join BaseUser as b on a.UserID=b.UserID";
                string show = "convert(nvarchar(14),a.KaoQinRiQi,23) as T,(isnull((convert(nvarchar(40),DengJiTime1,20)),'')+case when GuiDingTime1<DengJiTime1 then ' (迟到)' when DengJiTime1 is NULL then '未登记' else ' (正常)' end) as DengJiTime1,(isnull((convert(nvarchar(40),DengJiTime2,20)),'')+case when GuiDingTime2>DengJiTime2 then ' (早退)' when DengJiTime2 is NULL then '未登记'  else ' (正常)' end) as DengJiTime2,(isnull((convert(nvarchar(40),DengJiTime3,20)),'')+case when GuiDingTime3<DengJiTime3 then ' (迟到)' when DengJiTime3 is NULL then '未登记'  else ' (正常)' end) as DengJiTime3,(isnull((convert(nvarchar(40),DengJiTime4,20)),'')+case when GuiDingTime4>DengJiTime4 then ' (早退)' when DengJiTime4 is NULL then '未登记' else ' (正常)' end) as DengJiTime4,b.* ";

                dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
                result = DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            }

            return result;
        }

        private string GetAllCheck(HttpContext context)
        {
            string result = "{\"total\":0,\"rows\":[]}";
            //Model.BaseUser buModel = (Model.BaseUser)context.Session["login"];
            //WCDataProvider db = new WCDataProvider();
            //WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_kaoqin", WCDataAction.Query2);
            ////dsp.InputPars.Add("@UserID", buModel.UserID);
            //if (db.Execute(dsp).ExecuteState)
            //{
            //    DataTable dt = dsp.OutputDataSet.Tables[0];
            //    if (dt.Rows.Count > 0)
            //    {
            //        result = DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
            //    }
            //    //else
            //    //{
            //    //    result = "{[]}";
            //    //}
            //}
            DataTable dt = new DataTable();
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "asc";
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "b.UserID";
            string where = " 1=1 ";
            string table = "ERPKaoQin as a inner join BaseUser as b on a.UserID=b.UserID";
            string show = "convert(nvarchar(14),a.KaoQinRiQi,23) as T,(isnull((convert(nvarchar(40),DengJiTime1,20)),'')+case when GuiDingTime1<DengJiTime1 then ' (迟到)' when DengJiTime1 is NULL then '未登记' else ' (正常)' end) as DengJiTime1,(isnull((convert(nvarchar(40),DengJiTime2,20)),'')+case when GuiDingTime2>DengJiTime2 then ' (早退)' when DengJiTime2 is NULL then '未登记'  else ' (正常)' end) as DengJiTime2,(isnull((convert(nvarchar(40),DengJiTime3,20)),'')+case when GuiDingTime3<DengJiTime3 then ' (迟到)' when DengJiTime3 is NULL then '未登记'  else ' (正常)' end) as DengJiTime3,(isnull((convert(nvarchar(40),DengJiTime4,20)),'')+case when GuiDingTime4>DengJiTime4 then ' (早退)' when DengJiTime4 is NULL then '未登记' else ' (正常)' end) as DengJiTime4,b.* ";

            dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            result= DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            return result;
        }

        private string GetMyCheck(HttpContext context)
        {
            string result = "{\"total\":0,\"rows\":[]}";
            if (context.Session["login"] == null)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('登录信息安全时限过期，请重新登录！');top.location='../Login.aspx'</script>");
            }
            else
            {
                DataTable dt = new DataTable();
                Model.BaseUser buModel = (Model.BaseUser)context.Session["login"];
                //WCDataProvider db = new WCDataProvider();
                //WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_kaoqin", WCDataAction.Query1);
                //dsp.InputPars.Add("@UserID", buModel.UserID);
                //if (db.Execute(dsp).ExecuteState)
                //{
                //    DataTable dt = dsp.OutputDataSet.Tables[0];
                //    if (dt.Rows.Count > 0)
                //    {
                //        result = DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
                //    }
                //    //else
                //    //{
                //    //    result="{[]}";
                //    //}
                //}
                int total = 0;
                int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
                int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
                string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
                string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "asc";
                string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "b.UserID";
                string where = " 1=1 and a.UserID="+ buModel.UserID;
                string table = "ERPKaoQin as a inner join BaseUser as b on a.UserID=b.UserID";
                string show = "convert(nvarchar(14),a.KaoQinRiQi,23) as T,(isnull((convert(nvarchar(40),DengJiTime1,20)),'')+case when GuiDingTime1<DengJiTime1 then ' (迟到)' when DengJiTime1 is NULL then '未登记' else ' (正常)' end) as DengJiTime1,(isnull((convert(nvarchar(40),DengJiTime2,20)),'')+case when GuiDingTime2>DengJiTime2 then ' (早退)' when DengJiTime2 is NULL then '未登记'  else ' (正常)' end) as DengJiTime2,(isnull((convert(nvarchar(40),DengJiTime3,20)),'')+case when GuiDingTime3<DengJiTime3 then ' (迟到)' when DengJiTime3 is NULL then '未登记'  else ' (正常)' end) as DengJiTime3,(isnull((convert(nvarchar(40),DengJiTime4,20)),'')+case when GuiDingTime4>DengJiTime4 then ' (早退)' when DengJiTime4 is NULL then '未登记' else ' (正常)' end) as DengJiTime4,b.* ";

                dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
                return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);

            }
            return result;
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