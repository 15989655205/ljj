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
    /// MyProjectPlan 的摘要说明
    /// </summary>
    public class MyProjectPlan : IHttpHandler, IRequiresSessionState
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
                case "add":
                    reValue = Add(context);
                    break;
                case "edit":
                    reValue = Edit(context);
                    break;
                case "del":
                    reValue = Del(context);
                    break;
                case"QueryList1":
                    reValue = QueryList1(context);
                    break;
                case "record_list":
                    reValue =Record_list(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            string type = context.Request.Params["type"] == null ? "" : context.Request.Params["type"].Trim();
            Model.BaseUser bu = context.Session["login"] as Model.BaseUser;
            string table =
                "(select a.project_code, a.project_name, b.stage_name, dbo.getProject_groupName(c.group_sid)group_name, " +
                "     c.name jobduties_name, d.sid detail_id, d.name detail_name, dbo.getAllWorkBySi_id_zxf(d.sid)names, " +
                " 	  convert(nvarchar,d.begin_date,23)begin_date, convert(nvarchar,d.end_date,23)end_date, " +
                " 	  dbo.getpsiStatus(d.sid)psiStatus ,c.sequence" +             
                " from project a " +
                "     join project_stage b on a.sid=b.p_sid " +
                "     join project_specific_item c on b.sid=c.s_sid " +
                " 	  join project_specific_item d on c.sid=d.parent_sid " +
                " 	  join project_work_implement e on d.sid=e.psi_sid and ','+e.implementer_sid+',' like '%," + bu.UserName + ",%' " +
                " group by a.project_code, a.project_name, b.stage_name, c.group_sid, c.name, d.sid, d.name, d.sid, d.begin_date, d.end_date,c.sequence)t ";               
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "asc";
            string sort = context.Request.Form["sort"] != null
                ? context.Request.Form["sort"] : "project_code,project_name,stage_name,group_name,jobduties_name";
                sort+=", case " +
                  "     when psiStatus='0~0' then 0 " +
                  "     when psiStatus='1~5' then 1 " +
                  "     when psiStatus='null' then 2 " +
                  "     when psiStatus='-1~0' then 3 " +
                  "     when psiStatus='1~0' then 4 " +
                  " else 5 end ";
            
            if (sort == "psiStatus")
            {
                sort =
                    " case " +
                    "     when psiStatus='0~0' then 0 " +
                    "     when psiStatus='1~5' then 1 " +
                    "     when psiStatus='null' then 2 " +
                    "     when psiStatus='-1~0' then 3 " +
                    "     when psiStatus='1~0' then 4 " +
                    " else 5 end ";
            }
            sort += ",sequence ";
            string show = " * ";               
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;           
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 and begin_date is not null and begin_date!='1900-01-01'";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                bool flag = true;
                switch (key)
                {
                    case "未完成": key = "0~0"; break;
                    case "完成": key = "1~0"; break;
                    case "未提交": key = "null"; break;
                    case "优": key = "1~1"; break;
                    case "良": key = "1~2"; break;
                    case "差": key = "1~3"; break;
                    case "不及格": key = "1~5"; break;
                    default: flag = false; break;
                }
                where +=
                    " and(project_name like '%" + key + "%' " +
                    "     or project_code like '%" + key + "%' " +
                    "     or stage_name like '%" + key + "%' " +
                    "     or group_name like '%" + key + "%' " +
                    "     or jobduties_name like '%" + key + "%' " +
                    "     or detail_name like '%" + key + "%' " +
                    "     or begin_date like '%" + key + "%' " +
                    "     or end_date like '%" + key + "%' " +
                    "     or names like '%" + key + "%' ";
                where += flag ? " or psiStatus like '%" + key + "%' " : "";
                where += " ) ";
            }
            switch (type)
            {
                case "0":
                    where += " and (psiStatus='0~0' or psiStatus='null')";
                    break;
                default:
                    break;
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string QuerySubList(HttpContext context)
        {
            DataTable dt = new BLL.project_review().GetList1(" si_sid=" + context.Request["si_sid"] + " ").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, 0);
        }

        private string Add(HttpContext context)
        {
            return new BLL.project_review().Add(GetPR(context)) > 0 ? "ok" : "保存失败。";
        }

        private string Edit(HttpContext context)
        {
            return new BLL.project_review().Update(GetPR(context)) ? "ok" : "保存失败。";
        }

        private Model.project_review GetPR(HttpContext context)
        {
            Model.project_review pr = new Model.project_review();
            pr.sumbit_content = context.Request.Form["txtsumbit_content"];
            pr.sumbit_file = context.Request.Form["hdfileid"];
            switch (context.Request["action"])
            {
                case "add":
                    pr.status = 1;
                    pr.si_sid = context.Request.Form["hdsi_sid"];                   
                    pr.sumbit_user = pr.create_person = (context.Session["login"] as Model.BaseUser).UserName.ToString();
                    pr.sumbit_date = pr.create_date = DateTime.Now;
                    pr.review_status = 0;
                    break;
                case "edit":
                    pr.sid = int.Parse(context.Request.Form["hdsid"]);
                    pr.update_person = (context.Session["login"] as Model.BaseUser).UserName.ToString();
                    pr.update_date = DateTime.Now;                   
                    break;
                default: break;
            }
            return pr;
        }

        /// <summary>
        /// 我的项目计划top8
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
            string table =
                "select top 8 * from(select a.sid project_id, project_name, project_code,  " +
                "     b.sid stage_id, stage_name,   " +
                "     c.sid group_id, group_name,   " +
                "     d.sid jobduties_id, d.name jobduties_name,   " +
                "     e.sid detail_id, e.name detail_name, convert(nvarchar(10),e.begin_date,120)begin_date, convert(nvarchar(10),e.end_date,120)end_date, " +
                " 	      dbo.getImplementer_name(e.sid)names, dbo.getImplement(e.sid)implement_name " +
                " from project a  " +
                "     join project_stage b on a.sid=b.p_sid " +
                "     join project_group c on b.sid=c.ps_sid " +
                "     join project_specific_item d on c.sid=d.group_sid and d.parent_sid=0  " +
                "     join project_specific_item e on d.sid=e.parent_sid " +
                "     join project_work_implement g on e.sid=g.psi_sid and ','+g.implementer_sid+',' like '%," + bu.UserName + ",%'"  +
                " GROUP BY a.sid, project_name, project_code, b.sid, stage_name, c.sid, group_name, d.sid, d.name, e.sid, e.name, e.begin_date, e.end_date, e.sid)t where 1=1 order by end_date desc ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : " end_date ";
            string show = " * ";
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 1;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 10;
            int total = 8;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string where = " 1=1 ";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " and(project_name '%" + key + "%' " +
                    "     or project_code like '%" + key + "%' " +
                    "     or stage_name like '%" + key + "%' " +
                    "     or group_name like '%" + key + "%' " +
                    "     or jobduties_name like '%" + key + "%' " +
                    "     or detail_name like '%" + key + "%' " +
                    "     or begin_date like '%" + key + "%' " +
                    "     or end_date like '%" + key + "%' " +
                    "     or names like '%" + key + "%' " +
                    "     or implement_name like '%" + key + "%' " +
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


        private string Record_list(HttpContext context)
        {
            DataTable dt = new BLL.project_review_record().GetList1(" pr_sid='" + context.Request["pr_sid"] + "' ").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, 0);
        }

        private string Del(HttpContext context)
        {
            return new BLL.project_review().Delete(int.Parse(context.Request["sid"])) ? "ok" : "删除失败。";
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