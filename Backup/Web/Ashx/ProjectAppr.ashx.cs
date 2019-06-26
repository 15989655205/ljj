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
    /// ProjectAppr 的摘要说明
    /// </summary>
    public class ProjectAppr : IHttpHandler, IRequiresSessionState
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
            string reValue = string.Empty;
            switch (context.Request["action"])
            {
                case "list":
                    reValue = QueryList(context);
                    break;
                case "sub_list":
                    reValue = QuerySubList(context);
                    break;
                case "appr":
                    reValue = Approve(context);
                    break;
                case "record_list":
                    reValue = RecordList(context);
                    break;
                case"myProjectApprDesk":
                    reValue=QueryList1(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            string type = context.Request.Params["type"] == null ? "" : context.Request.Params["type"].Trim();
            Model.BaseUser bu = context.Session["login"] as Model.BaseUser;
            string table = " v_project_review ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "project_code,project_name, orderby ";            
            string show =" * ";
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "asc";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string where = " ','+vname+',' like '%," + bu.UserName + ",%' ";
            string where = " (v1 ='" + bu.UserName + "' or v2 ='" + bu.UserName + "') ";
            if (!string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " and(project_code like '%" + key + "%' " +
                    "     or project_name like '%" + key + "%' " +
                    "     or stage_name like '%" + key + "%' " +
                    "     or group_name like '%" + key + "%' " +
                    "     or jobduties_name like '%" + key + "%' " +
                    "     or detail_name like '%" + key + "%' " +
                    "     or begin_date like '%" + key + "%' " +
                    "     or end_date like '%" + key + "%' " +
                    "     or names like '%" + key + "%' " +
                    "     or recently_approver like '%" + key + "%' " +
                    "     or recently_date like '%" + key + "%' " +
                    "     or sumbit_user like '%" + key + "%' " +
                    "     or sumbit_date like '%" + key + "%' " + 
                    " )  ";
            }
            switch (type)
            {
                case "0":
                    where += " and ((review_results=-1 and review_status=0 and type='1' and v1='" + bu.UserName + "') or (review_results=1 and review_status=0 and v2='" + bu.UserName + "'))";
                    break;
                default:
                    break;
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);                        
        }

        private string QuerySubList(HttpContext context)
        {
            //string where = " pwi_sid='" + context.Request["pwi_sid"] + "' and si_sid='" + context.Request["si_sid"] + "' ";
            //DataTable dt = new BLL.project_review().GetList(where).Tables[0];
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, 0);           
            DataTable dt = new BLL.project_review_record().GetList1(" pr_sid='" + context.Request["sid"] + "' ").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, 0);
        }

        private string Approve(HttpContext context)
        {
            //Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            //string sid = context.Request.Params["sid"].Trim();
            //string results = context.Request.Params["results"].Trim();
            //string status = context.Request.Params["status"].Trim();
            //string apprContent = context.Request.Params["apprContent"].Trim();
            //return new BLL.project_review().approve(sid, status, results, apprContent, bu.UserName);
            
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Proc_ProjectAppr", WCDataAction.Insert1);
            dsp.InputPars.Add("@sql", context.Request["str"]);
            dsp.InputPars.Add("@type", context.Request["type"]);
            dsp.InputPars.Add("@sid", context.Request["sid"]);
            dsp.InputPars.Add("@reviewer", (context.Session["login"] as Model.BaseUser).UserName);
            if (db.Execute(dsp).ExecuteState)
            {
                return "success";
            }
            else
            {
                return "保存失败。";
            }
        }

        private string RecordList(HttpContext context)
        {
            DataTable dt = new BLL.project_review().GetList1(" si_sid='" + context.Request.Params["psi_sid"] + "' ").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }
        /// <summary>
        /// 未审批项目top8
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string QueryList1(HttpContext context)
        {
            if (context.Session["login"] == null)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('登录信息安全时限过期，请重新登录！');top.location='../Login.aspx'</script>");
            }
            Model.BaseUser bu = context.Session["login"] as Model.BaseUser;
            string where = " 1=1 and (f.sid in (select max(sid) from project_review group by si_sid) or f.sid is null) and ','+e.v1+',' like '%," + bu.UserName + ",%' and review_status=0 ";
            string show =
                " a.sid project_id, project_name, project_code, " +
                " b.sid stage_id, stage_name, " +
                " c.sid group_id, group_name, " +
                " d.sid jobduties_id, d.name jobduties_name, " +
                " e.sid detail_id, e.name detail_name, convert(nvarchar(10),e.begin_date,120)begin_date, convert(nvarchar(10),e.end_date,120)end_date," +
                    "dbo.getProImpAndUser_fu(e.sid) as names,dbo.getUsername_fu(sumbit_user) as sumbit_user,sumbit_date,(case when review_status is null then -1 else review_status end) as review_status,dbo.getUsername_fu(e.recently_approver) as recently_approver,e.recently_date";
            string table ="select top 8 "+show+
                " from project a " +
                " right outer join project_stage b on a.sid=b.p_sid " +
                " right outer join project_group c on b.sid=c.ps_sid " +
                " right outer join project_specific_item d on c.sid=d.group_sid and d.parent_sid=0 " +
                " right outer join project_specific_item e on d.sid=e.parent_sid " +
                " left outer join project_review f on e.sid=f.si_sid where " + where + " order by e.begin_date desc";
            // " left outer join project_implement f on b.sid=f.s_sid " +
            // " left outer  join project_work_implement g on e.sid=g.psi_sid and f.sid=g.imp_sid ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "  ";
            //switch (sort)
            //{
            //    case "jobduties_name": sort = "d.name"; break;
            //    case "detail_name": sort = "e.name"; break;
            //    case "begin_date": sort = "convert(nvarchar(10),e.begin_date,120)"; break;
            //    case "end_date": sort = "convert(nvarchar(10),e.end_date,120)"; break;
            //    case "names": sort = "dbo.getImplementer_name(implementer_sid,'" + bu.UserName + "')"; break;
            //    default: break;
            //}
            sort = "e.begin_date";
            
            //" f.sid implement_id, implement_name, dbo.getImplementer_name(implementer_sid,'')names, " +
            //" g.sid work_id ";
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 1;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 10;
            int total = 8;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "asc";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
           
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " and(project_name '%" + key + "%' " +
                    "     or project_code like '%" + key + "%' " +
                    "     or stage_name like '%" + key + "%' " +
                    "     or d.name like '%" + key + "%' " +
                    "     or e.name like '%" + key + "%' " +
                    "     or convert(nvarchar(10),e.begin_date,120) like '%" + key + "%' " +
                    "     or convert(nvarchar(10),e.end_date,120) like '%" + key + "%' " +
                    "     or implement_name like '%" + key + "%' " +
                    "     or dbo.getImplementer_name(implementer_sid,'') like '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = DbHelperSQL.Query(table).Tables[0];
            //DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            if (dt.Rows.Count>0)
            {
                return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            }
            else
            {
                return "{\"total\":0,\"rows\":[]}";
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