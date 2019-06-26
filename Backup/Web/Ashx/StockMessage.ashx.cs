using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.DBUtility;
using System.Data;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// StockMessage 的摘要说明
    /// </summary>
    public class StockMessage : IHttpHandler, IRequiresSessionState
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

            string msg = string.Empty;
            switch (context.Request["action"])
            {
                case "list": msg = GetList(context); break;
                case "save": msg = SaveStock(context); break;
                case "list1": msg = GetList1(context); break;
                case "save1": msg = SaveStock1(context); break;
                case "list2": msg = GetList2(context); break;
                case "save2": msg = SaveStock2(context); break;
                case "list3": msg = GetList3(context); break;
                case "save3": msg = SaveStock3(context); break;
                case "list4": msg = GetList4(context); break;
                case "save4": msg = SaveStock4(context); break;
                case "list5": msg = GetList5(context); break;
                case "save5": msg = SaveStock5(context); break;
                    
                default: break;
            }
            context.Response.Write(msg);
        }

        public string GetList(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("SP_StockMessage", WCDataAction.Query1);
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
                   string allStr=context.Request["allstr"];
                   string addStr =context.Request["addstr"];
                   string updateStr =context.Request["updatestr"];
                   string delStr =context.Request["delstr"];

                   List<Model.StockMessage> insert = new List<Model.StockMessage>();
                   insert = JsonSerializerHelper.JSONStringToList<Model.StockMessage>(addStr);
                   List<Model.StockMessage> update = new List<Model.StockMessage>();
                   update = JsonSerializerHelper.JSONStringToList<Model.StockMessage>(updateStr);
                   List<Model.StockMessage> delete = new List<Model.StockMessage>();
                   delete = JsonSerializerHelper.JSONStringToList<Model.StockMessage>(delStr);
                   string result = new BLL.StockMessage().EditStock(insert, update, delete, ((Model.BaseUser)context.Session["login"]).UserID);
                   return result;

        }

        public string GetList1(HttpContext context)
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

        public string SaveStock1(HttpContext context)
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

        public string GetList2(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("SP_StockMessage", WCDataAction.Query3);
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

        public string SaveStock2(HttpContext context)
        {
            string allStr = context.Request["allstr"];
            string addStr = context.Request["addstr"];
            string updateStr = context.Request["updatestr"];
            string delStr = context.Request["delstr"];

            List<Model.jxc_Payment> insert = new List<Model.jxc_Payment>();
            insert = JsonSerializerHelper.JSONStringToList<Model.jxc_Payment>(addStr);
            List<Model.jxc_Payment> update = new List<Model.jxc_Payment>();
            update = JsonSerializerHelper.JSONStringToList<Model.jxc_Payment>(updateStr);
            List<Model.jxc_Payment> delete = new List<Model.jxc_Payment>();
            delete = JsonSerializerHelper.JSONStringToList<Model.jxc_Payment>(delStr);
            string result = new BLL.jxc_Payment().EditStock(insert, update, delete, ((Model.BaseUser)context.Session["login"]).UserID);
            return result;

        }

        public string GetList3(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("SP_StockMessage", WCDataAction.Query4);
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

        public string SaveStock3(HttpContext context)
        {
            string allStr = context.Request["allstr"];
            string addStr = context.Request["addstr"];
            string updateStr = context.Request["updatestr"];
            string delStr = context.Request["delstr"];

            List<Model.jxc_Transport> insert = new List<Model.jxc_Transport>();
            insert = JsonSerializerHelper.JSONStringToList<Model.jxc_Transport>(addStr);
            List<Model.jxc_Transport> update = new List<Model.jxc_Transport>();
            update = JsonSerializerHelper.JSONStringToList<Model.jxc_Transport>(updateStr);
            List<Model.jxc_Transport> delete = new List<Model.jxc_Transport>();
            delete = JsonSerializerHelper.JSONStringToList<Model.jxc_Transport>(delStr);
            string result = new BLL.jxc_Transport().EditStock(insert, update, delete, ((Model.BaseUser)context.Session["login"]).UserID);
            return result;

        }

        public string GetList4(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("SP_StockMessage", WCDataAction.Query5);
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

        public string SaveStock4(HttpContext context)
        {
            string allStr = context.Request["allstr"];
            string addStr = context.Request["addstr"];
            string updateStr = context.Request["updatestr"];
            string delStr = context.Request["delstr"];

            List<Model.jxc_InvoiceType> insert = new List<Model.jxc_InvoiceType>();
            insert = JsonSerializerHelper.JSONStringToList<Model.jxc_InvoiceType>(addStr);
            List<Model.jxc_InvoiceType> update = new List<Model.jxc_InvoiceType>();
            update = JsonSerializerHelper.JSONStringToList<Model.jxc_InvoiceType>(updateStr);
            List<Model.jxc_InvoiceType> delete = new List<Model.jxc_InvoiceType>();
            delete = JsonSerializerHelper.JSONStringToList<Model.jxc_InvoiceType>(delStr);
            string result = new BLL.jxc_InvoiceType().EditStock(insert, update, delete, ((Model.BaseUser)context.Session["login"]).UserID);
            return result;

        }

        public string GetList5(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("SP_StockMessage", WCDataAction.Query6);
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

        public string SaveStock5(HttpContext context)
        {
            string allStr = context.Request["allstr"];
            string addStr = context.Request["addstr"];
            string updateStr = context.Request["updatestr"];
            string delStr = context.Request["delstr"];

            List<Model.jxc_PlanType> insert = new List<Model.jxc_PlanType>();
            insert = JsonSerializerHelper.JSONStringToList<Model.jxc_PlanType>(addStr);
            List<Model.jxc_PlanType> update = new List<Model.jxc_PlanType>();
            update = JsonSerializerHelper.JSONStringToList<Model.jxc_PlanType>(updateStr);
            List<Model.jxc_PlanType> delete = new List<Model.jxc_PlanType>();
            delete = JsonSerializerHelper.JSONStringToList<Model.jxc_PlanType>(delStr);
            string result = new BLL.jxc_PlanType().EditStock(insert, update, delete, ((Model.BaseUser)context.Session["login"]).UserID);
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