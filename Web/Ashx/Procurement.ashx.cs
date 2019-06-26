using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// Procurement 的摘要说明
    /// </summary>
    public class Procurement : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = string.Empty;
            string action = context.Request["action"];
            switch (action)
            {
                case "list": msg = GetList(context); break;
                default: break;
            }
            context.Response.Write(msg);
        }

        public string GetList(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("SP_StockMessage", WCDataAction.Query7);
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

       

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}