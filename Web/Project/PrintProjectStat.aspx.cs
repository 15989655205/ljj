using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Project
{
    public partial class PrintProjectStat : System.Web.UI.Page
    {
        protected string trStr = "",statStr="",Str="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string table = " v_project_stat ";
                //string show = " * ";
                string projectCode = Request["projectCode"] != null ? Request["projectCode"].Trim() : "";
                string projectName =  Request["projectName"] != null ?  Request["projectName"].Trim() : "";
                string stage =  Request["stage"] != null ?  Request["stage"].Trim() : "";
                string workuser =  Request["workuser"] != null ?  Request["workuser"].Trim() : "";
                string isExtended =  Request["isExtended"] != null ?  Request["isExtended"].Trim() : "";
                string startDate =  Request["startDate"] != null ?  Request["startDate"].Trim() : "";
                string endDate =  Request["endDate"] != null ?  Request["endDate"].Trim() : "";
                string isSumbit =  Request["isSumbit"] != null ?  Request["isSumbit"].Trim() : "";
                string result =  Request["result"] != null ?  Request["result"].Trim() : "";
                string status =  Request["status"] != null ?  Request["status"].Trim() : "";
                string projectStatus = Request["projectStatus"] != null ? Request["projectStatus"].Trim() : "所有";
                string statgeName = Request["statgeName"] != null ? Request["statgeName"].Trim() : "所有";
                string workuserName = Request["workuserName"] != null ? Request["workuserName"].Trim() : "";
                string flag = Request["flag"] != null ? Request["flag"].Trim() : "";

                Str += "<table class='printtable1' cellpadding='0' cellspacing='0' style='width:100%;'>";
                Str += "<tr>";
                Str += "<td style='width:10%; text-align:right;'>项目编号：</td>";
                Str += "<td style='width:10%;'>" + (projectCode!=""?projectCode:"所有") + "</td>";
                Str += "<td style='width:10%;text-align:right;'>项目名称：</td>";
                Str += "<td style='width:10%;'>" + (projectName != "" ? projectName : "所有") + "</td>";
                Str += "<td style='width:10%;text-align:right;'>阶段：</td>";
                Str += "<td style='width:10%;'>" + (statgeName != "" ? statgeName : "所有") + "</td>";
                Str += "<td style='width:10%;text-align:right;'>工作人员：</td>";
                Str += "<td style='width:10%;'>" + (workuserName != "" ? workuserName : "所有") + "</td>";
                Str += "<td style='width:10%;text-align:right;'>超期否：</td>";
                Str += "<td style='width:10%;'>" + (isExtended == "0" ? "未超期" : isExtended == "1" ? "已超期" : "所有") + "</td>";
                Str += "</tr>";
                Str += "<tr>";
                Str += "<td style='width:10%; text-align:right;'>时间段：</td>";
                Str += "<td>" + startDate+"至"+endDate + "</td>";
                Str += "<td style='width:10%; text-align:right;'>提交情况：</td>";
                Str += "<td>" + (isSumbit == "0" ? "未提交" : isSumbit == "1" ? "已提交" : "所有") + "</td>";
                Str += "<td style='width:10%; text-align:right;'>组长审核结果：</td>";
                Str += "<td>" + (result == "0" ? "未完成" : result == "1" ? "已完成" : "所有") + "</td>";
                Str += "<td style='width:10%; text-align:right;'>总审结果：</td>";
                Str += "<td>" + (status == "1" ? "优" : status == "2" ? "良" : status == "3" ? "差" : status == "5" ? "不及格" : "所有") + "</td>";
                Str += "<td style='width:10%; text-align:right;'>项目情况：</td>";
                Str += "<td>" + (projectStatus == "0" ? "未开始" : projectStatus == "1" ? "已开始" : projectStatus == "2" ? "进行中" : projectStatus == "3" ? "已过结束时间" : "所有") + "</td>";
                Str += "</tr>";
                Str += "</table>";


                //string where = " ','+vname+',' like '%," + bu.UserName + ",%' ";
                string where = " where 1=1 ";
                if (!string.IsNullOrEmpty(projectCode))
                {
                    projectCode = projectCode.Replace("'", "''");
                    where +=
                        " and project_code like '%" + projectCode + "%' ";
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
                    else if (isExtended == "1")
                        where += " and isExt=1";
                }
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
                string showData = "";

                if (flag != "1")
                {
                    DataTable dt = DbHelperSQL.Query("select * from v_project_stat_one " + where + " order by project_code,project_name,stage_name,group_name,jobduties_name,detail_name").Tables[0];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        showData += "<tr>";
                        //for (int j = 0; j < dt.Columns.Count; j++)
                        //{
                        showData += "<td>" + (i + 1).ToString() + "</td>";
                        if (dt.Columns["project_code"].ColumnName == "project_code")
                        {
                            if (i == 0)
                            {
                                DataRow[] dr = dt.Select("project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td style=\"text-align:center\" rowspan='" + tmpCount + "'>" + dt.Rows[i]["project_code"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else if (dt.Rows[i]["project_code"].ToString().Trim() != dt.Rows[i - 1]["project_code"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td style=\"text-align:center\" rowspan='" + tmpCount + "'>" + dt.Rows[i]["project_code"].ToString().Trim() + "</td>";
                                // continue;
                            }
                            else
                            {
                                //continue;
                            }
                        }
                        if (dt.Columns["project_name"].ColumnName == "project_name")
                        {
                            if (i == 0)
                            {
                                DataRow[] dr = dt.Select("project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["project_name"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else if (dt.Rows[i]["project_code"].ToString().Trim() != dt.Rows[i - 1]["project_code"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["project_name"].ToString().Trim() + "</td>";
                            }
                            else if (dt.Rows[i]["project_name"].ToString().Trim() != dt.Rows[i - 1]["project_name"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["project_name"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else
                            {
                                //continue;
                            }
                        }
                        if (dt.Columns["stage_name"].ColumnName == "stage_name")
                        {
                            if (i == 0)
                            {
                                DataRow[] dr = dt.Select("stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["stage_name"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else if (dt.Rows[i]["project_name"].ToString().Trim() != dt.Rows[i - 1]["project_name"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["stage_name"].ToString().Trim() + "</td>";
                            }
                            else if (dt.Rows[i]["stage_name"].ToString().Trim() != dt.Rows[i - 1]["stage_name"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["stage_name"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else
                            {
                                //continue;
                            }
                        }
                        if (dt.Columns["group_name"].ColumnName == "group_name")
                        {
                            if (i == 0)
                            {
                                DataRow[] dr = dt.Select("group_name='" + dt.Rows[i]["group_name"].ToString().Trim() + "' and stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["group_name"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else if (dt.Rows[i]["stage_name"].ToString().Trim() != dt.Rows[i - 1]["stage_name"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("group_name='" + dt.Rows[i]["group_name"].ToString().Trim() + "' and stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["group_name"].ToString().Trim() + "</td>";
                            }
                            else if (dt.Rows[i]["group_name"].ToString().Trim() != dt.Rows[i - 1]["group_name"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("group_name='" + dt.Rows[i]["group_name"].ToString().Trim() + "' and stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["group_name"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else
                            {
                                //continue;
                            }
                        }
                        if (dt.Columns["jobduties_name"].ColumnName == "jobduties_name")
                        {
                            if (i == 0)
                            {
                                DataRow[] dr = dt.Select("jobduties_name='" + dt.Rows[i]["jobduties_name"].ToString().Trim() + "' and group_name='" + dt.Rows[i]["group_name"].ToString().Trim() + "' and stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["jobduties_name"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else if (dt.Rows[i]["group_name"].ToString().Trim() != dt.Rows[i - 1]["group_name"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("jobduties_name='" + dt.Rows[i]["jobduties_name"].ToString().Trim() + "' and group_name='" + dt.Rows[i]["group_name"].ToString().Trim() + "' and stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["jobduties_name"].ToString().Trim() + "</td>";
                            }
                            else if (dt.Rows[i]["jobduties_name"].ToString().Trim() != dt.Rows[i - 1]["jobduties_name"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("jobduties_name='" + dt.Rows[i]["jobduties_name"].ToString().Trim() + "' and group_name='" + dt.Rows[i]["group_name"].ToString().Trim() + "' and stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["jobduties_name"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else
                            {
                                //continue;
                            }
                        }
                        if (dt.Columns["detail_name"].ColumnName == "detail_name")
                        {
                            if (i == 0)
                            {
                                DataRow[] dr = dt.Select("detail_name='" + dt.Rows[i]["detail_name"].ToString().Trim() + "' and jobduties_name='" + dt.Rows[i]["jobduties_name"].ToString().Trim() + "' and group_name='" + dt.Rows[i]["group_name"].ToString().Trim() + "' and stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["detail_name"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else if (dt.Rows[i]["jobduties_name"].ToString().Trim() != dt.Rows[i - 1]["jobduties_name"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("detail_name='" + dt.Rows[i]["detail_name"].ToString().Trim() + "' and jobduties_name='" + dt.Rows[i]["jobduties_name"].ToString().Trim() + "' and group_name='" + dt.Rows[i]["group_name"].ToString().Trim() + "' and stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["detail_name"].ToString().Trim() + "</td>";
                            }
                            else if (dt.Rows[i]["detail_name"].ToString().Trim() != dt.Rows[i - 1]["detail_name"].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("detail_name='" + dt.Rows[i]["detail_name"].ToString().Trim() + "' and jobduties_name='" + dt.Rows[i]["jobduties_name"].ToString().Trim() + "' and group_name='" + dt.Rows[i]["group_name"].ToString().Trim() + "' and stage_name='" + dt.Rows[i]["stage_name"].ToString().Trim() + "' and project_name='" + dt.Rows[i]["project_name"].ToString().Trim() + "' and project_code='" + dt.Rows[i]["project_code"].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                showData += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["detail_name"].ToString().Trim() + "</td>";
                                //continue;
                            }
                            else
                            {
                                //continue;
                            }
                        }
                        //showData += "<td>" + dt.Rows[i]["project_code"].ToString().Trim() + "</td>";
                        //showData += "<td>" + dt.Rows[i]["project_name"].ToString().Trim() + "</td>";
                        //showData += "<td>" + dt.Rows[i]["stage_name"].ToString().Trim() + "</td>";
                        //showData += "<td>" + dt.Rows[i]["group_name"].ToString().Trim() + "</td>";
                        //showData += "<td>" + dt.Rows[i]["jobduties_name"].ToString().Trim() + "</td>";
                        //showData += "<td>" + dt.Rows[i]["detail_name"].ToString().Trim() + "</td>";
                        if (dt.Rows[i]["begin_date"].ToString().Trim() == "1900-01-01")
                            showData += "<td style=\"text-align:center\"></td>";
                        else
                            showData += "<td style=\"text-align:center\">" + dt.Rows[i]["begin_date"].ToString().Trim() + "</td>";
                        if (dt.Rows[i]["end_date"].ToString().Trim() == "1900-01-01")
                            showData += "<td style=\"text-align:center\"></td>";
                        else
                            showData += "<td style=\"text-align:center\">" + dt.Rows[i]["end_date"].ToString().Trim() + "</td>";
                        showData += "<td style=\"text-align:center\">" + dt.Rows[i]["workuser"].ToString().Trim() + "</td>";
                        showData += "<td style=\"text-align:center\">" + dt.Rows[i]["sumbit"].ToString().Trim() + "</td>";
                        showData += "<td style=\"text-align:center\">" + dt.Rows[i]["sumbit_date"].ToString().Trim() + "</td>";
                        if (dt.Rows[i]["isExt"].ToString().Trim() == "1")
                        {
                            showData += "<td style=\"text-align:center\">是</td>";
                        }
                        else
                        {
                            showData += "<td style=\"text-align:center\">否</td>";
                        }
                        //showData += "<td>" + dt.Rows[i]["isExt"].ToString().Trim() + "</td>";
                        showData += "<td style=\"text-align:center\">" + dt.Rows[i]["groupHeader"].ToString().Trim() + "</td>";
                        showData += "<td style=\"text-align:center\">" + dt.Rows[i]["review_date"].ToString().Trim() + "</td>";
                        if (dt.Rows[i]["review_results"].ToString().Trim() == "1")
                        {
                            showData += "<td style=\"text-align:center\">已完成</td>";
                        }
                        else if (dt.Rows[i]["review_results"].ToString().Trim() == "0")
                        {
                            showData += "<td style=\"text-align:center\">未完成</td>";
                        }
                        else
                        {
                            showData += "<td></td>";
                        }
                        //showData += "<td>" + dt.Rows[i]["review_results"].ToString().Trim() + "</td>";
                        showData += "<td>" + dt.Rows[i]["reason"].ToString().Trim() + "</td>";
                        showData += "<td>" + dt.Rows[i]["solution"].ToString().Trim() + "</td>";
                        showData += "<td>" + dt.Rows[i]["result"].ToString().Trim() + "</td>";
                        showData += "<td>" + dt.Rows[i]["review_date1"].ToString().Trim() + "</td>";
                        switch (dt.Rows[i]["review_status"].ToString().Trim())
                        {
                            case "1":
                                showData += "<td style=\"text-align:center\">优</td>";
                                break;
                            case "2":
                                showData += "<td style=\"text-align:center\">良</td>";
                                break;
                            case "3":
                                showData += "<td style=\"text-align:center\">差</td>";
                                break;
                            case "5":
                                showData += "<td style=\"text-align:center\">不及格</td>";
                                break;
                            default:
                                showData += "<td></td>";
                                break;
                        }
                        //showData += "<td>" + dt.Rows[i]["review_status"].ToString().Trim() + "</td>";
                        showData += "<td style=\"text-align:center\">" + dt.Rows[i]["remark"].ToString().Trim() + "</td>";
                        //}
                        showData += "</tr>";
                    }

                    trStr += "<div style=' margin-top:5px;'><span>详细列表</span></div><div>";
                    trStr += "<table class='printtable1' cellpadding='0' cellspacing='0' >";
                    trStr += "<thead>";
                    trStr += "<tr>";
                    trStr += "<th >序号</th>";
                    trStr += "<th >项目编号</th>";
                    trStr += "<th >项目名称</th>";
                    trStr += "<th >阶段</th>";
                    trStr += "<th >小组</th>";
                    trStr += "<th style='width:15%'>工作内容</th>";
                    trStr += "<th style='width:15%'>细目</th>";
                    trStr += "<th >开始时间</th>";
                    trStr += "<th >结束时间</th>";
                    trStr += "<th >工作人员</th>";
                    trStr += "<th >提交情况</th>";
                    trStr += "<th >提交时间</th>";
                    trStr += "<th >是否超期</th>";
                    trStr += "<th >组长</th>";
                    trStr += "<th >组长审核时间</th>";
                    trStr += "<th >组长审核结果</th>";
                    trStr += "<th >未完成的原因</th>";
                    trStr += "<th >解决的办法</th>";
                    trStr += "<th >解决的结果</th>";
                    trStr += "<th >总审时间</th>";
                    trStr += "<th >总审结果</th>";
                    trStr += "<th >备注</th>";
                    trStr += "</tr>";
                    trStr += "</thead>";
                    trStr += showData;
                    trStr += "</table>";
                    trStr += "</div>";
                }

                DataSet statDs = new BLL.Common().GetList("select (select count(1) from v_project_stat_one " + where + " and sumbit_date is not null) tj,(select count(1) from v_project_stat_one " + where + "  and sumbit_date is  null) ntj,(select count(1) from v_project_stat_one " + where + " and isExt=1 ) pover,(select count(1) from v_project_stat_one " + where + " and review_results=1) finish,(select count(1) from v_project_stat_one " + where + " and review_results=0) unfinish,(select count(1) from v_project_stat_one " + where + " and review_status=1) y,(select count(1) from v_project_stat_one " + where + " and review_status=2) l,(select count(1) from v_project_stat_one   " + where + " and review_status=3) c,(select count(1) from v_project_stat_one " + where + " and review_status=5) f,(select count(1) from v_project_stat_one " + where + ") total");
                DataTable statDt = new DataTable();
                string total="";
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
                    total=statDt.Rows[0]["total"].ToString().Trim();
                }

                statStr += "<table class='printtable1' cellpadding='0' cellspacing='0'  style='width:100%;'>";
                statStr += "<thead>";
                statStr += "<tr>";
                statStr += "<th >细目数量</th>";
                statStr += "<th >超期数量</th>";
                statStr += "<th >已提交</th>";
                statStr += "<th >未提交</th>";
                statStr += "<th >已完成</th>";
                statStr += "<th >未完成</th>";
                statStr += "<th >总审（优）</th>";
                statStr += "<th >总审（良）</th>";
                statStr += "<th >总审（差）</th>";
                statStr += "<th >总审（不及格）</th>";
                statStr += "</tr>";
                statStr += "</thead>";
                statStr += "<tr>";
                statStr += "<td style='text-align:center;'>" + total + "</td>";
                statStr += "<td style='text-align:center;'>" + pover + "</td>";
                statStr += "<td style='text-align:center;'>" + tj + "</td>";
                statStr += "<td style='text-align:center;'>" + ntj + "</td>";
                statStr += "<td style='text-align:center;'>" + finish + "</td>";
                statStr += "<td style='text-align:center;'>" + unfinish + "</td>";
                statStr += "<td style='text-align:center;'>" + y + "</td>";
                statStr += "<td style='text-align:center;'>" + l + "</td>";
                statStr += "<td style='text-align:center;'>" + c + "</td>";
                statStr += "<td style='text-align:center;'>" + f + "</td>";
                statStr += "</tr>";
                statStr += "</table>";
            }
        }
    }
}