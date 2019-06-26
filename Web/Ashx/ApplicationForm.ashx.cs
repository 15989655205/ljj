using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ApplicationForm 的摘要说明
    /// </summary>
    public class ApplicationForm : IHttpHandler,IReadOnlySessionState
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
                case "add":
                    reValue = Add(context);
                    break;
                case "copy":
                    reValue = Add(context);
                    break;
                case "update":
                    reValue = Update(context);
                    break;
                case "del":
                    reValue = Del(context);
                    break;
                case "myApply":
                    reValue = RequestFormList(context);
                    break;
                case "waitMeAppr":
                    reValue =WaitMeApprList(context);
                    break;
                case "handle":
                    reValue = Handle(context);
                    break;
                case "myAppr":
                    reValue = MyApprList(context);
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
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
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

        public string Add(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string fmsid = context.Request.Params["fmsid"].Trim();
            string flow_name = context.Request.Params["flow_name"].Trim();
            string rfsid = context.Request.Params["rfsid"].Trim();
            string remark = context.Request.Params["remark"].Trim();
            string isval = context.Request.Params["isval"].Trim();
            string content = context.Server.HtmlEncode(context.Request.Params["content1"].Trim());
            Model.application_form model = new Model.application_form();
            model.fm_sid = fmsid;
            model.af_name = flow_name;
            model.rf_sid = int.Parse(rfsid);
            model.remark = remark;
            model.rfs_sid = int.Parse(isval);
            model.applicant = bu.UserName;
            model.af_content = content;
            return new BLL.application_form().insert(model);
            //Model.request_form model = new Model.request_form();
           // model.form_name = formName;
           // model.rft_sid = int.Parse(formType);
           // model.rf_status = int.Parse(isVal);
            //model.remark = remark;
            //model.content_str = content;
            //return new BLL.request_form().Add(model);
        }

        public string Update(HttpContext context)
        {
            string sid = context.Request.Params["sid"].Trim();
            Model.application_form model = new BLL.application_form().GetModel(int.Parse(sid));
            string fmsid = context.Request.Params["fmsid"].Trim();
            string flow_name = context.Request.Params["flow_name"].Trim();
            string rfsid = context.Request.Params["rfsid"].Trim();
            string remark = context.Request.Params["remark"].Trim();
            string isval = context.Request.Params["isval"].Trim();
            string content = context.Server.HtmlEncode(context.Request.Params["content1"].Trim());

            model.fm_sid = fmsid;
            model.af_name = flow_name;
            model.remark = remark;
            model.rfs_sid = int.Parse(isval);
            model.af_content = content;
            return new BLL.application_form().update(model);
        }

        public string Del(HttpContext context)
        {
            string sid = context.Request.Params["sid"].Trim();
            return new BLL.application_form().delete(sid);
        }

        public string RequestFormList(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            DataTable dt = new DataTable();
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "rf_sid,create_date";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 and applicant='" + bu.UserName + "'";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " ";
            }
            string table = "v_Appl_form";
            string show = "*";

            dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        public string WaitMeApprList(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            DataTable dt = new DataTable();
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "rf_sid,create_date";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 and appr_dept='"+bu.DeptID+"' and appr_role='"+bu.ApprRole+"'  ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " ";
            }
            string table = "v_waitMeApprList";
            string show = "*";

            dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        public string Handle(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string afsid = context.Request.Params["afsid"].Trim();
            string node = context.Request.Params["node"].Trim();
            string dept = bu.DeptID.ToString().Trim();
            string role = bu.ApprRole.Trim();
            string approver = bu.UserName.Trim();
            string result = context.Request.Params["result"].Trim();
            string resultStr = context.Request.Params["resultStr"].Trim();
            string remark = context.Request.Params["remark"].Trim();
            return new BLL.application_form().handle(afsid, node, dept, role, approver, result,resultStr, remark);
        }

        public string MyApprList(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            DataTable dt = new DataTable();
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "rf_sid,create_date";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 and approver='" + bu.UserName + "' ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " ";
            }
            string table = "v_my_appr_record";
            string show = "*";

            dt = new BLL.BaseUser().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
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