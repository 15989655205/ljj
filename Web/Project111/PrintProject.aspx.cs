using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace Maticsoft.Web.Project111
{
    public partial class PrintProject : System.Web.UI.Page
    {
        protected string sid = "", pssid = "", pname = "", pcode = "", stageName = "";
        protected Model.project pModel = new Model.project();
        protected string trStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pssid = Request.Params["ps_sid"] == null ? "" : Request.Params["ps_sid"].Trim();
                DataTable dt = new DataTable();
                DataSet ds = new BLL.Common().GetList("select project.sid as psid, project_name,project_code,stage_name,begin_date,end_date from project_stage left outer join project on project_stage.p_sid=project.sid where project_stage.sid='" + pssid + "'");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt.Rows.Count > 0)
                {
                    pname = dt.Rows[0]["project_name"].ToString().Trim();
                    pcode = dt.Rows[0]["project_code"].ToString().Trim();
                    stageName = dt.Rows[0]["stage_name"].ToString().Trim();

                    pModel = new BLL.project().GetModel(int.Parse(dt.Rows[0]["psid"].ToString().Trim()));

                    string str1 = "", str2 = "", str3 = "", str4 = "";
                    DataTable impDT = new DataTable();
                    DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + pssid + "'");
                    if (impDS.Tables.Count > 0)
                    {
                        impDT = impDS.Tables[0];
                    }
                    for (int i = 0; i < impDT.Rows.Count; i++)
                    {
                        str1 += "<th  colspan='1' rowspan='2' >" + impDT.Rows[i]["implement_name"].ToString().Trim() + "</th>";
                        str2 += "<th>" + impDT.Rows[i]["implementers"].ToString().Trim() + "</th>";
                    }

                    DateTime sDate = DateTime.Parse(dt.Rows[0]["begin_date"].ToString().Trim());
                    DateTime eDate = DateTime.Parse(dt.Rows[0]["end_date"].ToString().Trim());
                    TimeSpan ts = eDate.AddDays(1).Subtract(sDate);
                    string monthstr = "";
                    if (sDate.Month == eDate.Month)
                    {
                        monthstr = sDate.Month.ToString() + "月";
                    }
                    else
                    {
                        monthstr = sDate.Month.ToString() + "-" + eDate.Month.ToString() + "月";
                    }
                    string cols = ts.Days.ToString();
                    for (int i = 0; i < ts.Days; i++)
                    {
                        str3 += "<th colspan='1' >" + sDate.AddDays(i).Day.ToString() + "</th>";
                        string w = "";
                        switch (sDate.AddDays(i).DayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                                w = "日";
                                break;
                            case DayOfWeek.Monday:
                                w = "一";
                                break;
                            case DayOfWeek.Tuesday:
                                w = "二";
                                break;
                            case DayOfWeek.Wednesday:
                                w = "三";
                                break;
                            case DayOfWeek.Thursday:
                                w = "四";
                                break;
                            case DayOfWeek.Friday:
                                w = "五";
                                break;
                            case DayOfWeek.Saturday:
                                w = "六";
                                break;
                        }
                        str4 += "<th style='white-space:pre-wrap; word-wrap:break-word;'>" + w + "</th>";
                    }
                    trStr += "<table class='printinnertable' cellpadding='0' cellspacing='0'>";
                    trStr += "<thead>";
                    trStr += "<tr>";
                    trStr += "<th rowspan='3'>阶段</th>";
                    trStr += "<th rowspan='3'>小组</th>";
                    trStr += "<th rowspan='3' >工作内容</th>";

                    trStr += "<th rowspan='3'>细目</th>";

                    trStr += "<th colspan='1'>月</th>";
                    trStr += "<th colspan='" + cols + "'>" + monthstr + "(黄色色块代表完成这项工作所需要的完成时间，计划表中实际完成时间将用绿色色块做标记)</th>";
                    trStr += str1;
                    trStr += "<th width='100px' rowspan='3'>完成情况(按照公司设计质量标准评定:绿，黄，橙，红。四种工作完成状况)</th>";
                    trStr += "<th width='150px' rowspan='3'>未完成的原因</th>";
                    trStr += "<th width='150px' rowspan='3'>解决的办法</th>";
                    trStr += "<th width='150px' rowspan='3'>备注</th>";
                    trStr += "</tr>";

                    trStr += "<tr>";
                    trStr += "<th colspan='1'>日</th>";
                    trStr += str3;
                    trStr += "</tr>";

                    trStr += "<tr>";
                    trStr += "<th >星期</th>";
                    trStr += str4;
                    trStr += str2;
                    trStr += "</tr>";
                    trStr += "</thead>";
                    trStr += ContentViewItem(pssid);
                    trStr += "</table>";
                }
            }
        }

        private string ContentViewItem(string pssid)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList(" select a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,dbo.getProjectReview_fu(a.sid) as reviews,a.unfinished_reason,a.solution,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectSubmitDate_fu(a.sid) as submitDate from project_specific_item a left outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on a.s_sid=c.sid left outer join project_group d on a.group_sid=d.sid where a.ischild=1 and a.s_sid=" + pssid+ " order by a.s_sid asc, a.group_sid asc, a.parent_sid asc  ");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                DateTime sDate = DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString().Trim());
                DateTime eDate = DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString().Trim());
                TimeSpan ts = eDate.AddDays(1).Subtract(sDate);

                DataColumn datetimeColumn1 = new DataColumn();
                //该列的数据类型
                datetimeColumn1.DataType = System.Type.GetType("System.String");
                //该列得名称
                datetimeColumn1.ColumnName = "week";
                //该列得默认值
                datetimeColumn1.DefaultValue = "";
                dt.Columns.Add(datetimeColumn1);

                dt.Columns[datetimeColumn1.ColumnName].SetOrdinal(5);

                //插入周期列
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

                    dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 6);
                }
                //周期列赋值
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

                //插入实施列并赋值
                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + pssid + "'");
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
                    dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 6 + ts.Days);

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
                }
            }

            string reStr = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                reStr += "<tr>";
                //bool group = false, content = false;
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    if (j == 1 )
                    {
                        if (dt.Columns[j].ColumnName == "stage_name" && i == 0)
                        {
                            reStr += "<td rowspan='" + dt.Rows.Count + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (dt.Columns[j].ColumnName == "group_name")
                    {
                        if (i==0)
                        {
                            DataRow[] dr = dt.Select("group_name='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else if (dt.Rows[i][j].ToString().Trim() != dt.Rows[i - 1][j].ToString().Trim())
                        {
                            DataRow[] dr = dt.Select("group_name='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (dt.Columns[j].ColumnName == "contentName")
                    {
                        if (i == 0)
                        {
                            DataRow[] dr = dt.Select("contentName='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else if (dt.Rows[i][j].ToString().Trim() != dt.Rows[i - 1][j].ToString().Trim())
                        {
                            DataRow[] dr = dt.Select("contentName='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (dt.Columns[j].ColumnName == "begin_date")
                    {
                        break;
                    }
                    if (dt.Columns[j].ColumnName == "week")
                    {
                        reStr += "<td style='background-color:lightgray;'></td>";
                        continue;
                    }
                    //if (IsDate(dt.Columns[j].ColumnName))
                    if (dt.Columns[j].ColumnName.Contains('-'))
                    {
                        switch (dt.Rows[i][j].ToString().Trim())
                        {
                            case "0":
                                reStr += "<td></td>";
                                break;
                            case "1":
                                //reStr += "<td style='background-color:yellow;'><img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/></td>";
                                reStr += "<td style='background-color:yellow;'></td>";
                                break;
                            case "2":
                                //reStr += "<td style='background-color:green;'><img  width='16px' height='16px' src='../Images/point/bullet_green.png'/></td>";
                                reStr += "<td style='background-color:green;'></td>";
                                break;
                            default:
                                reStr += "<td></td>";
                                break;
                        }
                        
                    }
                    else if (dt.Columns[j].ColumnName.Trim() == "reviews")
                    {
                        string[] arr = dt.Rows[i][j].ToString().Trim().Split(',');
                        string pointStr = "";
                        for (int n = 0; n < arr.Length; n++)
                        {
                            switch (arr[n].Trim())
                            {
                                case "0":
                                    pointStr += "";
                                    break;
                                case "1":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_green.png'/>&nbsp;";
                                    break;
                                case "2":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/>&nbsp;";
                                    break;
                                case "3":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_orange.png'/>&nbsp;";
                                    break;
                                case "4":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_red.png'/>&nbsp;";
                                    break;
                                default:
                                    break;
                            }
                        }
                        reStr += "<td>"+pointStr+"</td>";
                    }
                    else
                    {
                        reStr += "<td>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                }
                reStr += "</tr>";
            }
            return reStr;
        }

        private bool IsDate(string dateString)
        {
            Match m = Regex.Match(dateString, "/^(d{2}|d{4})-((0([1-9]{1}))|(1[1|2]))-(([0-2]([1-9]{1}))|(3[0|1]))$");
            return m.Success;
        }
    }
}