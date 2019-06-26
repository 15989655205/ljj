using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// Currency 的摘要说明
    /// </summary>
    public class Currency : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentType = "text/plain";
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            if (bu == null)
            {
                context.Response.Write("登录超时，请重新登录。");
                return;
            }

            string msg = string.Empty;
            switch (context.Request["action"])
            {
                case "list": msg = GetList(context); break;
                case "save": msg = SaveStock(context); break;
                default: break;
            }
            context.Response.Write(msg);
        }

        public string GetList(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("SP_StockMessage", WCDataAction.Query2);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@Where", " 1=1 ");
            dsp.InputPars.Add("@Sort", " ID  desc");
            dsp.InputPars.Add("@PageSize", context.Request.Form["rows"]);
            dsp.InputPars.Add("@PageIndex", context.Request.Form["page"]);
            if (db.Execute(dsp).ExecuteState)
            {
                if (dsp.OutputDataSet.Tables[0].Rows.Count > 0)
                {
                    return JsonHelper.DataTable2Json_Datagrid(dsp.OutputDataSet.Tables[0], Convert.ToInt32(dsp.OutputPars["@RecordCount"].ToString()));
                }
            }
            return "{\"total\":0,\"rows\":[]}";
        }

        public string SaveStock(HttpContext context)
        {
            string allStr = context.Request["allstr"];
            string addStr = context.Request["addstr"];
            string updateStr = context.Request["updatestr"];
            string delStr = context.Request["delstr"];

            List<Model.jxc_Currency> insert = new List<Model.jxc_Currency>();
            insert = JsonSerializerHelper.JSONStringToList<Model.jxc_Currency>(addStr);
            List<Model.jxc_Currency> update = new List<Model.jxc_Currency>();
            update = JsonSerializerHelper.JSONStringToList<Model.jxc_Currency>(updateStr);
            List<Model.jxc_Currency> delete = new List<Model.jxc_Currency>();
            delete = JsonSerializerHelper.JSONStringToList<Model.jxc_Currency>(delStr);
            string result = new BLL.jxc_Currency().EditStock(insert, update, delete, ((Model.BaseUser)context.Session["login"]).UserID);
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