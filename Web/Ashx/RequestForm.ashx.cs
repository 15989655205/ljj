using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// RequestForm 的摘要说明
    /// </summary>
    public class RequestForm : IHttpHandler, IReadOnlySessionState
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
                case "add":
                    reValue = Add(context);
                    break;
                case "update":
                    reValue = Update(context);
                    break;
                case "dels":
                    reValue = Dels(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        public string QueryList(HttpContext context)
        {
            DataTable dt = new DataTable();
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "asc";
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "type_name";
            string where = " 1=1 ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " and (form_name like '%" + key + "%' or type_name like '%" + key + "%' )";
            }
            string table = "v_request_form";
            string show = "sid,form_name,rft_sid,url,rf_status,type_name,remark,create_date";

            dt = new BLL.BaseUser().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);

        }

        public string Edit(HttpContext context)
        {
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.request_form> insert = new List<Model.request_form>();
            insert = JsonSerializerHelper.JSONStringToList<Model.request_form>(addstr);
            List<Model.request_form> update = new List<Model.request_form>();
            update = JsonSerializerHelper.JSONStringToList<Model.request_form>(updatestr);
            List<Model.request_form> del = new List<Model.request_form>();
            del = JsonSerializerHelper.JSONStringToList<Model.request_form>(delstr);

            return new BLL.request_form().Edit(insert, update, del);
        }

        public string Add(HttpContext context)
        {
            string formName = context.Request.Params["form_name"].Trim();
            string formType = context.Request.Params["form_type"].Trim();
            string isVal = context.Request.Params["hval"].Trim();
            string remark = context.Request.Params["remark"].Trim();
            string content = context.Server.HtmlEncode(context.Request.Params["content1"].Trim());
            Model.request_form model = new Model.request_form();
            model.form_name = formName;
            model.rft_sid = int.Parse(formType);
            model.rf_status = int.Parse(isVal);
            model.remark = remark;
            model.content_str = content;
            return new BLL.request_form().Add(model);
        }

        public string Update(HttpContext context)
        {
            string sid = context.Request.Params["sid"].Trim();
            Model.request_form model = new BLL.request_form().GetModel(int.Parse(sid));
            string formName = context.Request.Params["form_name"].Trim();
            string formType = context.Request.Params["form_type"].Trim();
            string isVal = context.Request.Params["hval"].Trim();
            string remark = context.Request.Params["remark"].Trim();
            string content = context.Server.HtmlEncode(context.Request.Params["content1"].Trim());
           
            model.form_name = formName;
            model.rft_sid = int.Parse(formType);
            model.rf_status = int.Parse(isVal);
            model.remark = remark;
            model.content_str = content;
            return new BLL.request_form().Update(model);
        }

        public string Dels(HttpContext context)
        {
            string selectid = context.Request.Params["cbx_select"].Trim();
            return new BLL.request_form().DeleteList(selectid);
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