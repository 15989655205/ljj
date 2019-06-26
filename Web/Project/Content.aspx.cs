using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project
{
    public partial class Content : System.Web.UI.Page
    {
        protected string sid = "", pssid = "", pname = "", pcode = "", stageName = "", column = "",psid="",sDateStr="",eDateStr="";
        protected string showContent = "", showItem = "", isConstruction = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pssid = Request.Params["ps_sid"] == null ? "" : Request.Params["ps_sid"].Trim();
                //isConstruction = Request.Params["isConstruction"] == null ? "" : Request.Params["isConstruction"].Trim();
                //stageName = DBUtility.DbHelperSQL.GetSingle("select stage_name from project_stage where sid=" + pssid).ToString().Trim();
                DataTable dt = new DataTable();
                DataSet ds = new BLL.Common().GetList("select project.sid as psid, project_name,project_code,stage_name,Convert(varchar(10),begin_date,120) begin_date,Convert(varchar(10),end_date,120) end_date,project_stage.is_system from project_stage left outer join project on project_stage.p_sid=project.sid where project_stage.sid='" + pssid + "'");
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
                    string dynImp = "",dynImpUser="",dynDay="",dynWeek="";
                    DataTable impDT = new DataTable();
                    DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + pssid + "' order by sequence");
                    if (impDS.Tables.Count > 0)
                    {
                        impDT = impDS.Tables[0];

                        for (int i = 0; i < impDT.Rows.Count; i++)
                        {
                            dynImp += ",{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:2}";

                            dynImpUser += ",{title: '" + impDT.Rows[i]["implementers"].ToString().Trim() + "',field:'impAbbr_" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:80, halign:'center', align:'center'}";
                        }
                    }
                    else
                    {
                        dynImp = ",{title:'',rowspan:2}";
                        dynImpUser = ",{title: '',field:'imp_',width:80, halign:'center', align:'center'}";
                    }

                    string cols = "1";
                    string monthstr = "";
                    string tmp = dt.Rows[0]["begin_date"].ToString().Trim();
                    if (dt.Rows[0]["begin_date"].ToString().Trim() != "" && dt.Rows[0]["end_date"].ToString().Trim() != "" && dt.Rows[0]["begin_date"] != null && dt.Rows[0]["end_date"]!=null)
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
                            dynWeek += ",{title:'" + w + "',field:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){var font='';if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "'].length>3)font='font-size:8px;';if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==1){return 'background-color:yellow;'+font}else if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==2){return 'background-color:green;'+font}else{return ''}}}";
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
                            showCount = showCount + ((work_width - 200)*3 / 30);
                        }
                    }

                    if (isConstruction == "1")
                    {
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
                            flow += (i + 1).ToString() +"."+ tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
                        }

                        string workTitle = monthstr + "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))";
                        string showWorkTitle = "";
                        for (int i = 0; i < workTitle.Length; i++)
                        {
                            showWorkTitle += workTitle[i];
                            if ((i + 1) % showCount == 0)
                            {
                                showWorkTitle += "<br/>";
                            }
                        }

                        column += "[[";
                        column += "{ title: '空间', field: 'contentName', width: 80, rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                        column += ",{ title: '图纸及索引号', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                        column += ",{ title: '月'}";
                        //column += ",{ title: '" + monthstr + "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))',rowspan:1,colspan:" + cols + "}";
                        column += ",{ title: '" + showWorkTitle + "',rowspan:1,colspan:" + cols + "}";
                        column += dynImp;
                        column += ",{ title: '主管审核', field: 'header', width: 60,rowspan:3, halign: 'center', align: 'center'}";
                        column += ",{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, halign: 'center', align: 'center'}";
                        column += ",{ title: '解决的办法', field: 'solution', width: 60, rowspan:3, halign: 'center', align: 'center'}";
                        column += ",{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3, halign: 'center', align: 'center'}";
                        column += ",{ title: '总审', field: 'finaler', width: 60, rowspan:3,halign: 'center', align: 'center'}";
                        column += ",{ title: '备注', field: 'remark', width: 60, rowspan:3,halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                        column += "],";
                        column += "[";
                        column += "{ title: '日'}";
                        column += dynDay;
                        column += "],[";
                        column += "{ title: '星期', field: 'week',width:40,halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';}}";
                        column += dynWeek;
                        column += dynImpUser;
                        column += "]]";
                    }
                    else
                    {
                        showContent = "工作内容";
                        showItem = "细目";
                        column += "[[";
                        column += "{ title: '小组', field: 'group_name', width: 60, rowspan:3, halign: 'center', align: 'center'}";
                        column += ",{ title: '工作内容', field: 'contentName', width: 200, rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                        column += ",{ title: '细目', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                        column += ",{ title: '月'}";
                        column += ",{ title: '" + monthstr + "(黄色色块代表完成这项工作所需要的完成时间,<br/>计划表中实际完成时间将用绿色色块做标记)',colspan:" + cols + "}";
                        column += dynImp;
                        column += ",{ title: '主管审核', field: 'header', width: 60,rowspan:3, halign: 'center', align: 'center'}";
                        column += ",{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, halign: 'center', align: 'center'}";
                        column += ",{ title: '解决的办法', field: 'solution', width: 60, rowspan:3, halign: 'center', align: 'center'}";
                        column += ",{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3, halign: 'center', align: 'center'}";
                        column += ",{ title: '总审', field: 'finaler', width: 60, rowspan:3, halign: 'center', align: 'center'}";
                        column += ",{ title: '备注', field: 'remark', width: 60, rowspan:3,halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                        column += "],";
                        column += "[";
                        column += "{ title: '日'}";
                            column += dynDay;
                        column += "],[";
                        column += "{ title: '星期', field: 'week',width:40,halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';}}";
                        column += dynWeek;
                        column += dynImpUser;
                        column += "]]";
                    }
                }
            }
        }
    }
}