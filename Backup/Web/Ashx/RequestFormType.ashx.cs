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
    /// RequestFormType 的摘要说明
    /// </summary>
    public class RequestFormType : IHttpHandler, IReadOnlySessionState
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
                    reValue = QueryList(context);
                    break;
                case "edit":
                    reValue = Edit(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            DataTable dt = new DataTable();
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " and (type_name like '%" + key + "%' or remark like '%" + key + "%' )";
            }
            string table = "request_form_type";
            string show = "*";
            string orderFiled = "sid";

            dt = new BLL.BaseUser().GetList(table, orderFiled, show, page, rows, out total, "asc", where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);

        }

        private string Edit(HttpContext context)
        {
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.request_form_type> insert = new List<Model.request_form_type>();
            insert = JsonSerializerHelper.JSONStringToList<Model.request_form_type>(addstr);
            List<Model.request_form_type> update = new List<Model.request_form_type>();
            update = JsonSerializerHelper.JSONStringToList<Model.request_form_type>(updatestr);
            List<Model.request_form_type> del = new List<Model.request_form_type>();
            del = JsonSerializerHelper.JSONStringToList<Model.request_form_type>(delstr);

            return new BLL.request_form_type().Edit(insert, update, del);
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