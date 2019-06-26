using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;
using Maticsoft.DBUtility;


namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ProjectView 的摘要说明
    /// </summary>
    public class ProjectView : IHttpHandler, IReadOnlySessionState
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
                case "view_user_project":
                    reValue = ViewUserProject(context);
                    break;
                case "getProject":
                    reValue = GetProject(context);
                    break;
                case "projectStat":
                    reValue = ProjectStat(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string ViewUserProject(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList(" select a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_fu(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate from project_specific_item a left outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on a.s_sid=c.sid left outer join project_group d on a.group_sid=d.sid where a.ischild=1 and a.s_sid=" + context.Request.Params["pssid"].Trim() + " order by a.s_sid asc, a.group_sid asc, a.parent_sid asc  ");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                DateTime sDate = DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString().Trim());
                DateTime eDate = DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString().Trim());
                TimeSpan ts = eDate.AddDays(1).Subtract(sDate);
                for (int i = 0; i < ts.Days; i++)
                {
                    DataColumn datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = sDate.AddDays(i).ToString("yyyy-MM-dd");
                    //该列得默认值
                    datetimeColumn.DefaultValue = "0";



                    dt.Columns.Add(datetimeColumn);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime mysDate = DateTime.Parse(dt.Rows[i]["begin_date"].ToString().Trim());
                    DateTime myeDate = DateTime.Parse(dt.Rows[i]["end_date"].ToString().Trim());
                    TimeSpan myts = myeDate.AddDays(1).Subtract(mysDate);
                    for (int j = 0; j < myts.Days; j++)
                    {
                        if (dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")].ToString().Trim() == "0")
                        {
                            dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "1";
                        }
                    }


                }


                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + context.Request.Params["pssid"].Trim() + "'");
                if (impDS.Tables.Count > 0)
                {
                    impDT = impDS.Tables[0];
                }
                for (int i = 0; i < impDT.Rows.Count; i++)
                {
                    DataColumn datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "imp" + impDT.Rows[i]["sid"].ToString().Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable impworkDT = new DataTable();
                        impDS = new BLL.project_work_implement().GetList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                dt.Rows[j]["imp" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["implementer"].ToString().Trim();
                            }
                        }
                    }

                    string[] submitDate = dt.Rows[i]["submitDate"].ToString().Trim().Split(',');
                    for (int j = 0; j < submitDate.Length; j++)
                    {
                        try
                        {
                            for (int n = 0; n < ts.Days; n++)
                            {
                                if (sDate.AddDays(n).Date == DateTime.Parse(submitDate[j].Trim()).Date)
                                {
                                    dt.Rows[i][sDate.AddDays(n).ToString("yyyy-MM-dd")] = "2";
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }

            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string GetProject(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select sid,project_name from project");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        private string ProjectStat(HttpContext context)
        {
            string table = "  v_project_stat_one ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : " sid ";
            string show = " * ";
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "asc";
            string projectCode = context.Request.Form["projectCode"] != null ? context.Request.Form["projectCode"].Trim() : "";
            string projectName = context.Request.Form["projectName"] != null ? context.Request.Form["projectName"].Trim() : "";
            string stage = context.Request.Form["stage"] != null ? context.Request.Form["stage"].Trim() : "";
            string workuser = context.Request.Form["workuser"] != null ? context.Request.Form["workuser"].Trim() : "";
            string isExtended = context.Request.Form["isExtended"] != null ? context.Request.Form["isExtended"].Trim() : "";
            string startDate = context.Request.Form["startDate"] != null ? context.Request.Form["startDate"].Trim() : "";
            string endDate = context.Request.Form["endDate"] != null ? context.Request.Form["endDate"].Trim() : "";
            string isSumbit = context.Request.Form["isSumbit"] != null ? context.Request.Form["isSumbit"].Trim() : "";
            string result = context.Request.Form["result"] != null ? context.Request.Form["result"].Trim() : "";
            string status = context.Request.Form["status"] != null ? context.Request.Form["status"].Trim() : "";
            string projectStatus = context.Request.Form["projectStatus"] != null ? context.Request.Form["projectStatus"].Trim() : "";
            //string where = " ','+vname+',' like '%," + bu.UserName + ",%' ";
            string where = " 1=1 ";
            if (!string.IsNullOrEmpty(projectCode))
            {
                projectCode = projectCode.Replace("'", "''");
                where +=
                    " and project_code like '%" + projectCode + "%' ";
                    //"     or project_name like '%" + key + "%' " +
                    //"     or stage_name like '%" + key + "%' " +
                    //"     or group_name like '%" + key + "%' " +
                    //"     or jobduties_name like '%" + key + "%' " +
                    //"     or detail_name like '%" + key + "%' " +
                    //"     or begin_date like '%" + key + "%' " +
                    //"     or end_date like '%" + key + "%' " +
                    //"     or names like '%" + key + "%' " +
                    //"     or recently_approver like '%" + key + "%' " +
                    //"     or recently_date like '%" + key + "%' " +
                    //"     or sumbit_user like '%" + key + "%' " +
                    //"     or sumbit_date like '%" + key + "%' " +
                    //" )  ";
            }
            if (!string.IsNullOrEmpty(projectName))
            {
                projectName = projectName.Replace("'", "''");
                where += " and project_name like '%" + projectName + "%' ";
            }
            if (!string.IsNullOrEmpty(stage))
            {
                stage = stage.Replace("'", "''");
                where += " and ssid in (" + stage + ") ";
            }
            if (!string.IsNullOrEmpty(workuser))
            {
                stage = stage.Replace(",", "','");
                where += " and workuid in('" + workuser + "') ";
            }
            if (!string.IsNullOrEmpty(isExtended))
            {
                if (isExtended == "0")
                    where += " and isExt=0";
                //where += " and (sumbit_date<= end_date and end_date>=getdate())";
                else if (isExtended == "1")
                    //where += " and (sumbit_date> end_date or end_date<getdate())";
                    where += " and isExt=1";
            }
            //if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            //{
            //    where += " and begin_date >='"+startDate+"' and end_date <='"+endDate+"'";
            //}
            if (!string.IsNullOrEmpty(startDate))
            {
                where += " and begin_date >='" + startDate + "' ";
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                where += " and end_date <='" + endDate + "' ";
            }
            if (!string.IsNullOrEmpty(isSumbit))
            {
                if (isSumbit == "0")
                    where += " and (sumbit_date is null)";
                else if (isExtended == "1")
                    where += " and (sumbit_date is not null)";
            }
            if (!string.IsNullOrEmpty(result))
            {
                where += " and review_results='" + result + "'";
            }
            if (!string.IsNullOrEmpty(status))
            {
                where += " and review_status='" + status + "'";
            }
            if (!string.IsNullOrEmpty(projectStatus))
            {
                switch (projectStatus)
                {
                    case "0":
                        where += " and (begin_date >getdate() or begin_date ='1900-01-01' or begin_date is null)";
                        break;
                    case "1":
                        where += " and (begin_date <=getdate() and begin_date !='1900-01-01')";
                        break;
                    case "2":
                        where += " and begin_date <=getdate() and end_date>=getdate()";
                        break;
                    case "3":
                        where += " and end_date <getdate()";
                        break;
                    default: break;
                }
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            string reval= DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            DataSet statDs = new BLL.Common().GetList("select (select count(1) from v_project_stat_one where sumbit_date is not null and " + where + ") tj,(select count(1) from v_project_stat_one where sumbit_date is  null  and " + where + ") ntj,(select count(1) from v_project_stat_one where isExt=1  and " + where + ") pover,(select count(1) from v_project_stat_one where review_results=1 and " + where + ") finish,(select count(1) from v_project_stat_one where review_results=0 and " + where + ") unfinish,(select count(1) from v_project_stat_one where review_status=1 and " + where + ") y,(select count(1) from v_project_stat_one where review_status=2 and " + where + ") l,(select count(1) from v_project_stat_one where review_status=3 and " + where + ") c,(select count(1) from v_project_stat_one where review_status=5 and " + where + ") f");
            DataTable statDt = new DataTable();
            string tj = "";
            string ntj = "";
            string pover = "";
            string finish = "";
            string unfinish = "";
            string y = "";
            string l = "";
            string c = "";
            string f = "";
            if (statDs.Tables.Count > 0)
            {
                statDt = statDs.Tables[0];
                tj = statDt.Rows[0]["tj"].ToString().Trim();
                ntj = statDt.Rows[0]["ntj"].ToString().Trim();
                pover = statDt.Rows[0]["pover"].ToString().Trim();
                finish = statDt.Rows[0]["finish"].ToString().Trim();
                unfinish = statDt.Rows[0]["unfinish"].ToString().Trim();
                y = statDt.Rows[0]["y"].ToString().Trim();
                l = statDt.Rows[0]["l"].ToString().Trim();
                c = statDt.Rows[0]["c"].ToString().Trim();
                f = statDt.Rows[0]["f"].ToString().Trim();
            }
            reval = reval.Remove(reval.Length - 1);
            return reval + ",\"footer\":[{\"project_code\":\"细目数量:" + total + "\",\"project_name\":\"已提交数量:" + tj + "\",\"stage_name\":\"未提交数量:" + ntj + "\",\"group_name\":\"超期数量:" + pover + "\",\"jobduties_name\":\"完成数量:" + finish + "\",\"detail_name\":\"未完成数量:" + unfinish + "\"},{\"project_code\":\"优:" + y + "\",\"project_name\":\"良:" + l + "\",\"stage_name\":\"差:" + c + "\",\"group_name\":\"不及格:" + f + "\",\"jobduties_name\":\"\",\"detail_name\":\"\"}]}";
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