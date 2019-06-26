using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using Maticsoft.DBUtility;


namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ApplicationForm_zxf 的摘要说明
    /// </summary>
    public class ApplicationForm_zxf : IHttpHandler, IReadOnlySessionState
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
                case "myAppr":
                    reValue = MyApprList(context);
                    break;
                case"myAppr_detail":
                    reValue = myAppr_detail(context);
                    break;
                case "myApprList":
                    reValue = ApprListMe(context);
                    break;
                case "myApprList_detail":
                    reValue = myApprList_detail(context);
                    break;
                case"waitMeAppr":
                    reValue = waitMeAppr(context);
                    break;
                case"waitMeAppr_detail":
                    reValue=waitMeAppr_detail(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }
        private string waitMeAppr_detail(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string where = " where appr_dept=" + bu.DeptID + " and appr_role='" + bu.ApprRole + "' and rf_sid=" + context.Request["rf_sid"]+" and '"+bu.UserName+"' not in (select * from dbo.getTable(recorders,','))";
            string key = context.Request["key"];
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " and ( af_name like '%" + key + "%'" +
                    " or apply_name like '%" + key + "%'" +
                    " or CONVERT(varchar(16), applicant_date, 20) like '%" + key + "%'" +
                    " or status_name like '%" + key + "%'" +
                    " or curr_node_name like '%" + key + "%'" +
                    " or next_node_name like '%" + key + "%'" +
                    " or recent_appr like '%" + key + "%'" +
                    " or CONVERT(varchar(16), recently_appr_date, 20) like '%" + key + "%' ) ";
            }
            DataTable dt = new BLL.Common().GetList("select * from dbo.v_waitMeApprList "+ where  + " order by rf_sid,create_date desc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }
        private string waitMeAppr(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            DataTable dt = new DataTable();
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "rf_sid,create_date";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 and appr_dept='" + bu.DeptID + "' and appr_role='" + bu.ApprRole + "'  ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " ";
            }
            string table = "(select distinct  b.rf_sid,b.appr_dept,b.appr_role,b.form_name,b.form_name+'-'+cast((select count(*) from dbo.v_waitMeApprList as a where a.rf_sid=b.rf_sid and appr_dept='" + bu.DeptID + "' and appr_role='" + bu.ApprRole + "' ) as nvarchar(400))+' Item(s)' as name from v_waitMeApprList as b) as dt";
            string show = "*";

            dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string myAppr_detail(HttpContext context)
        {
            string where = " where rf_sid=" + context.Request["rf_sid"] + " and applicant='" + context.Request["applicant"] + "' ";
            string key = context.Request["key"];
            if (key!=""&&!string.IsNullOrEmpty(key))
            {
                where += " and ( af_name like '%" + key + "%'" +
                    " or apply_name like '%" + key + "%'" +
                    " or CONVERT(varchar(16), applicant_date, 20) like '%" + key + "%'" +
                    " or status_name like '%" + key + "%'" +
                    " or curr_node_name like '%" + key + "%'" +
                    " or next_node_name like '%" + key + "%'" +
                    " or appr_name like '%" + key + "%'" +
                    " or CONVERT(varchar(16), recently_appr_date, 20) like '%" + key + "%' ) ";
            }
            DataTable dt = new BLL.Common().GetList("select * from dbo.v_Appl_form "+where+" order by rf_sid,create_date desc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string MyApprList(HttpContext context)
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
            string table = "(select distinct b.rf_sid,b.applicant,b.form_name,b.form_name+'-'+cast((select count(*) from dbo.v_Appl_form as a where a.rf_sid=b.rf_sid and a.applicant=b.applicant) as nvarchar(400))+' Item(s)' as name from v_Appl_form as b) as dt";
            string show = "*";

            dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string ApprListMe(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            DataTable dt = new DataTable();
            //int total = 0;
            //int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            //int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "rf_sid,create_date";
            //string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string where = " 1=1 and approver='" + bu.UserName + "' ";
            //if (key != "" && !string.IsNullOrEmpty(key))
            //{
            //    where += " ";
            //}
            //string table = "(select distinct b.rf_sid,b.approver,b.form_name,b.form_name+'-'+cast((select count(*) from dbo.v_my_appr_record as a where a.rf_sid=b.rf_sid and a.approver=b.approver) as nvarchar(400))+' Item(s)' as name from v_my_appr_record as b) as dt";
            //string show = "*";
            string sql = " select * from (select distinct b.rf_sid,b.form_name,b.approver,b.form_name+'-'+cast((select count(*) from dbo.v_my_appr_record as a where a.rf_sid=b.rf_sid and a.approver=b.approver) as nvarchar(400))+' Item(s)' as name from v_my_appr_record as b) as dt where approver='" + bu.UserName + "'";

            //dt = new BLL.BaseUser().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            dt = new BLL.Common().GetList(sql).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string myApprList_detail(HttpContext context)
        {
            string where = "where rf_sid=" + context.Request["rf_sid"] + " and approver='" + context.Request["approver"] + "' ";
            string key = context.Request["key"];
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " and ( af_name like '%" + key + "%'" +
                    " or Name like '%" + key + "%'" +
                    " or applDept like '%" + key + "%'" +
                    " or CONVERT(varchar(16), applicant_date, 20) like '%" + key + "%'" +
                    " or formStatus like '%" + key + "%'" +
                    " or curr_node_name like '%" + key + "%'" +
                    " or next_node_name like '%" + key + "%'" +
                    " or rec_approver like '%" + key + "%'" +
                    " or CONVERT(varchar(16), recently_appr_date, 20) like '%" + key + "%'" +
                    " or CONVERT(varchar(16), appr_datetime, 20)  like '%" + key + "%'" +
                    " or appr_status_str like '%" + key + "%'" +
                    " ) ";
            }
            DataTable dt = new BLL.Common().GetList("select * from dbo.v_my_appr_record " +where  + " order by rf_sid,create_date desc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
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

        