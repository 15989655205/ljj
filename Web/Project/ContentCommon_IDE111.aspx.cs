using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project
{
    public partial class ContentCommon_IDE111 : System.Web.UI.Page
    {
        protected string sid = "", pssid = "", pname = "", pcode = "", stageName = "", column = "", frozencolumns="",psid = "", sDateStr = "", eDateStr = "";
        protected string showContent = "", showItem = "", isConstruction = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pssid = Request.Params["ps_sid"] == null ? "" : Request.Params["ps_sid"].Trim();
                DataTable dt = new DataTable();
                DataSet ds = new BLL.Common().GetList("select project.sid as psid, project_name,project_code,stage_name,Convert(varchar(10),begin_date,120) begin_date,Convert(varchar(10),end_date,120) end_date,project_stage.is_system,project.v1,dbo.getUserNames_fu(project.v1) as v1Users,project.v2,dbo.getUserNames_fu(project.v2) as v2Users from project_stage left outer join project on project_stage.p_sid=project.sid where project_stage.sid='" + pssid + "'");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt.Rows.Count > 0)
                {
                    isConstruction = dt.Rows[0]["is_system"].ToString().Trim();
                    stageName = dt.Rows[0]["stage_name"].ToString().Trim();
                    pname = dt.Rows[0]["project_name"].ToString().Trim();
                    psid = dt.Rows[0]["psid"].ToString().Trim();

                    //动态添加实施列
                    //主管审核人
                    string dnyV1 = "";
                    string[] v1UserArr = dt.Rows[0]["v1Users"].ToString().Trim().Split(',');
                    string[] v1UidArr = dt.Rows[0]["v1"].ToString().Trim().Split(',');
                    for (int j = 0; j < v1UserArr.Length; j++)
                    {
                        if (v1UidArr[j].Trim() != "")
                        {
                            dnyV1 += ",{title: '" + v1UserArr[j].ToString().Trim() + "',field:'v1_" + v1UidArr[j] + "',width:60, halign:'center', align:'center',editor:'text'}";
                        }
                        else
                        {
                            dnyV1 += ",{title: '" + v1UserArr[j].ToString().Trim() + "',field:'v1_" + v1UidArr[j] + "',width:60, halign:'center', align:'center',editor:{type:'diseditText'}}";
                        }
                        //dnyV1 += ",{title: '" + v1UserArr[j].ToString().Trim() + "',field:'v1_" + v1UidArr[j] + "',width:60, halign:'center', align:'center',formatter: function(value,row,index){},editor:'text'}";
                    }
                    if (v1UserArr.Length == 0)
                    {
                        dnyV1 = ",{title: '',field:'v1_',width:60, halign:'center', align:'center'}";
                    }

                    //总审人
                    string dnyV2 = "";
                    string[] v2UserArr = dt.Rows[0]["v2USers"].ToString().Trim().Split(',');
                    string[] v2UidArr = dt.Rows[0]["v2"].ToString().Trim().Split(',');
                    for (int j = 0; j < v2UserArr.Length; j++)
                    {
                        if (v2UidArr[j].Trim() != "")
                        {
                            dnyV2 += ",{title: '" + v2UserArr[j].ToString().Trim() + "',field:'v2_" + v2UidArr[j] + "',width:60, halign:'center', align:'center',editor:'text'}";
                        }
                        else
                        {
                            dnyV2 += ",{title: '" + v2UserArr[j].ToString().Trim() + "',field:'v2_" + v2UidArr[j] + "',width:60, halign:'center', align:'center',editor:{type:'diseditText'}}";
                        }
                    }
                    if (v2UserArr.Length == 0)
                    {
                        dnyV2 = ",{title: '',field:'v2_',width:60, halign:'center', align:'center'}";
                    }

                    //工作种类及人员
                    string dynImp = "", dynImpUser = "", dynDay = "", dynWeek = "";
                    DataTable impDT = new DataTable();
                    DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + pssid + "' order by sequence");
                    if (impDS.Tables.Count > 0)
                    {
                        impDT = impDS.Tables[0];

                        for (int i = 0; i < impDT.Rows.Count; i++)
                        {
                            string[] dynImpUserArr = impDT.Rows[i]["impUsers"].ToString().Trim().Split(',');
                            string[] dynImpUidArr = impDT.Rows[i]["implementers_sid"].ToString().Trim().Split(',');
                            dynImp += ",{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:2,colspan:" + (dynImpUserArr.Length > 0 ? dynImpUserArr.Length : 1) + "}";
                            for (int j = 0; j < dynImpUserArr.Length; j++)
                            {
                                if (dynImpUserArr[j].Trim() != "")
                                {
                                    dynImpUser += ",{title: '" + dynImpUserArr[j].ToString().Trim() + "',field:'impAbbr_" + impDT.Rows[i]["sid"].ToString().Trim() + "_" + dynImpUidArr[j] + "',width:80, halign:'center', align:'center',editor:'text'}";
                                }
                                else
                                {
                                    dynImpUser += ",{title: '" + dynImpUserArr[j].ToString().Trim() + "',field:'impAbbr_" + impDT.Rows[i]["sid"].ToString().Trim() + "_" + dynImpUidArr[j] + "',width:80, halign:'center', align:'center',editor:{type:'diseditText'}}";
                                }
                            }
                            if (dynImpUserArr.Length == 0)
                            {
                                dynImpUser = ",{title: '',field:'imp_',width:80, halign:'center', align:'center'}";
                            }
                        }
                    }
                    else
                    {
                        dynImp = ",{title:'',rowspan:2}";
                        dynImpUser = ",{title: '',field:'imp_',width:80, halign:'center', align:'center'}";
                    }

                    //工作日历
                    string cols = "1";
                    string monthstr = "";
                    string tmp = dt.Rows[0]["begin_date"].ToString().Trim();
                    if (dt.Rows[0]["begin_date"].ToString().Trim() != "" && dt.Rows[0]["end_date"].ToString().Trim() != "" && dt.Rows[0]["begin_date"] != null && dt.Rows[0]["end_date"] != null)
                    {
                        sDateStr = dt.Rows[0]["begin_date"].ToString().Trim();
                        eDateStr = dt.Rows[0]["end_date"].ToString().Trim();
                        DateTime sDate = DateTime.Parse(dt.Rows[0]["begin_date"].ToString().Trim());
                        DateTime eDate = DateTime.Parse(dt.Rows[0]["end_date"].ToString().Trim());
                        TimeSpan ts = eDate.AddDays(1).Subtract(sDate);

                        if (sDate.Month == eDate.Month)
                        {
                            monthstr = sDate.Month.ToString() + "月";
                        }
                        else
                        {
                            monthstr = sDate.Month.ToString() + "-" + eDate.Month.ToString() + "月";
                        }
                        cols = ts.Days.ToString();
                        for (int i = 0; i < ts.Days; i++)
                        {
                            dynDay += ",{title: '" + sDate.AddDays(i).Day.ToString() + "'}";
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
                            dynWeek += ",{title:'" + w + "',field:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==null);return;var font='';if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "'].length>3)font='font-size:8px;';if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==1){return 'background-color:yellow;'+font}else if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==2){return 'background-color:green;'+font}else{return ''}},editor:'text'}";
                        }
                    }
                    else
                    {
                        monthstr = "";
                        dynDay = ",{title: '',rowspan:1}";
                        dynWeek = ",{title: '',field:'w'}";
                    }

                    int work_width = 200;
                    int showCount = 15;
                    if (int.Parse(cols) * 30 > 200)
                    {
                        work_width = int.Parse(cols) * 30;
                        if (work_width > 200)
                        {
                            showCount = showCount + ((work_width - 200) * 3 / 30);
                        }
                    }
                    //string calendarStr = "";
                    string showGroup = "true";
                    string showWorkTitle = "";
                    switch (isConstruction)
                    {
                        case "1":
                            showContent = "空间";
                            showItem = "图纸及索引号";
                            string flow = "";
                            DataTable tmpDT = new DataTable();
                            DataSet tmpDS = new BLL.project_work_flow().GetList(" s_sid='" + pssid + "'");
                            if (tmpDS.Tables.Count > 0)
                            {
                                tmpDT = tmpDS.Tables[0];
                            }
                            for (int i = 0; i < tmpDT.Rows.Count; i++)
                            {
                                flow += (i + 1).ToString() + "." + tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
                            }

                            string workTitle = monthstr + "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))";
                            showWorkTitle = "";
                            for (int i = 0; i < workTitle.Length; i++)
                            {
                                showWorkTitle += workTitle[i];
                                if ((i + 1) % showCount == 0)
                                {
                                    showWorkTitle += "<br/>";
                                }
                            }
                            break;
                        case "0":
                            showContent = "工作内容";
                            showItem = "细目";
                            showGroup = "false";
                            showWorkTitle = monthstr + "(黄色色块代表完成这项工作所需要的完成时间,<br/>计划表中实际完成时间将用绿色色块做标记)";
                            break;
                        case "2":
                            showContent = "货物类别";
                            showItem = "工作细目";
                            showWorkTitle = monthstr ;
                            break;
                        default:
                            break;
                    }

                    frozencolumns += "[[";
                    frozencolumns += "{ title: '小组', field: 'group_name', width: 60, rowspan:3, halign: 'center', align: 'center',hidden:" + showGroup + ",editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '" + showContent + "', field: 'contentName', width: 200, rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';},editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '" + showItem + "', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';},editor:'text'}";
                    frozencolumns += "]]";
                    column += "[[";
                    column += "{ title: '月'}";
                    column += ",{ title: '" + showWorkTitle + "',colspan:" + cols + "}";
                    column += dynImp;
                    column += ",{ title: '主管审核', rowspan:2,colspan:"+(v1UidArr.Length>0?v1UidArr.Length:1)+", halign: 'center', align: 'center'}";
                    column += ",{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    column += ",{ title: '解决的办法', field: 'solution', width: 60, rowspan:3, halign:'center', align:'center',editor:{type:'diseditText'}}";
                    column += ",{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3, halign:'center', align:'center',editor:{type:'diseditText'}}";
                    column += ",{ title: '总审', rowspan:2,colspan:" + (v2UidArr.Length > 0 ? v2UidArr.Length : 1) + ", halign: 'center', align: 'center'}";
                    column += ",{ title: '备注', field: 'remark', width: 60, rowspan:3,halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                    column += "],";
                    column += "[";
                    column += "{ title: '日'}";
                    column += dynDay;
                    column += "],[";
                    column += "{ title: '星期', field: 'week',width:40,halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';},editor:{type:'diseditText'}}";
                    column += dynWeek;
                    column += dynImpUser;
                    column += dnyV1;
                    column += dnyV2;
                    column += "]]";
                }
            }
        }
    }
}