using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project111
{
    public partial class ViewProject : System.Web.UI.Page
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
                        //str1 += "{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:2},";
                        //str1 += "<th  colspan='1' rowspan='2' ></th>";
                        str2 += "<th data-options=\"field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:100, halign:'center', align:'center'\" >" + impDT.Rows[i]["implementers"].ToString().Trim() + "</th>";
                        //str2 += "{field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',title:'" + impDT.Rows[i]["implementers"].ToString().Trim() + "',width:100, halign:'center', align:'center'},";
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
                    //string widthstr = (int.Parse(cols) * 30).ToString();
                    for (int i = 0; i < ts.Days; i++)
                    {
                        str3 += "<th colspan='1' >" + sDate.AddDays(i).Day.ToString() + "</th>";
                        //str3 += "{title:'" + sDate.AddDays(i).Day.ToString() + "'},";
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
                        //str4 += "<th data-options=\"field:'" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){if(value==1){return 'background-color:yellow;'}else{return ''};},formatter: function(value,row,index){return '';}\" style='white-space:pre-wrap; word-wrap:break-word;'>" + w + "</th>";
                        str4 += "<th data-options=\"field:'" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){if(value==1){return 'background-color:yellow;'}else if(value==2){return 'background-color:green;'}else{return ''};},formatter: function(value,row,index){return '';}\" style='white-space:pre-wrap; word-wrap:break-word;'>" + w + "</th>";
                        //str4 += "{field:'" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',title:'" + w + "',width:30,halign:'center',align:'center',styler: function(value,row,index){if(value==1){return 'background-color:yellow;'}else{return ''};},formatter: function(value,row,index){return '';}},";
                    }
                    //trStr += "<thead>";
                    trStr += "<thead data-options='frozen:true'>";
                    trStr += "<tr>";
                    trStr += "<th data-options=\"field:'stage_name',width:50, halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:white;white-space:pre-wrap; word-wrap:break-word;';}\" rowspan='3'>阶段</th>";
                    trStr += "<th data-options=\"field:'group_name',width:50, halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:white;white-space:pre-wrap; word-wrap:break-word;';}\" rowspan='3'>小组</th>";

                    //trStr += "<th data-options=\"field:'contentName',width:150, halign: 'center', styler: function(value,row,index){return 'background-color:white;white-space:pre-wrap; word-wrap:break-word;';},formatter: function (value, rowData, rowIndex) {return '<span style=\'white-space:pre-wrap; word-wrap:break-word;\'>' + value + '</span>';}\" rowspan='3' >工作内容</th>";
                    trStr += "<th data-options=\"field:'contentName',width:150, halign: 'center', styler: function(value,row,index){return 'background-color:white;white-space:pre-wrap; word-wrap:break-word;';}\" rowspan='3' >工作内容</th>";

                    trStr += "<th data-options='field:\"itemName\",width:150, halign: \"center\" ,formatter: function (value, rowData, rowIndex) {var str=\"<a class=\\\"a_black\\\" title=\\\"\" + value + \"\\\"><span class=\\\"mlength\\\">\" + value + \"</span></a>\";return str;}' rowspan='3'>细目</th>";

                    trStr += "</tr>";
                    trStr += "</thead>";

                    trStr += "<thead>";
                    trStr += "<tr>";
                    trStr += "<th colspan='1'>月</th>";
                    trStr += "<th colspan='" + cols + "'>" + monthstr + "(黄色色块代表完成这项工作所需要的完成时间，<br/>计划表中实际完成时间将用绿色色块做标记)</th>";
                    trStr += str1;
                    //trStr += "<th data-options=\"field:'reviews',width:150, halign: 'center',formatter: function (value, rowData, rowIndex) {var arr=value.split(',');var str='';for(var i=0;i<arr.length;i++){switch (arr[i]) {case 0:break;case 1:str+='<img src=\"../Images/point/bullet_green.png\" />';break;case 2:str+='<img src=\"../Images/point/bullet_yellow.png\" />';break;case 3:str+='<img src=\"../Images/point/bullet_orange.png\" />';break;case 4:str+='<img src=\"../Images/point/bullet_red.png\" />';break;default:break;}}return str;}\" rowspan='3'>完成情况(按照公司设计质量标准评定:绿，黄，橙，红。四种工作完成状况)</th>";
                    //trStr += "<th data-options='field:\"reviews\",width:150, halign: \"center\",formatter: function (value, rowData, rowIndex) {var arr=value.split(\",\");var str=\"\";for(var i=0;i<arr.length;i++){switch (arr[i]) {case \"0\":break;case \"1\":str+=\"<div style=\\\"float:left\\\"><img src=\\\"../Images/point/bullet_green.png\\\"/></div>\";break;case \"2\":str+=\"<div style=\\\"float:left\\\"><img src=\\\"../Images/point/bullet_yellow.png\\\" /></div>\";break;case \"3\":str+=\"<div style=\\\"float:left\\\"><img src=\\\"../Images/point/bullet_orange.png\\\" /></div>\";break;case \"4\":str+=\"<div style=\\\"float:left\\\"><img src=\\\"../Images/point/bullet_red.png\\\" /></div>\";break;default:break;}} return str;}' rowspan='3'>完成情况(按照公司设计质量标准评定:绿，黄，橙，红。四种工作完成状况)</th>";
                    trStr += "<th data-options='field:\"reviews\",width:150, halign: \"center\",formatter: function (value, rowData, rowIndex) {var arr=value.split(\",\");var str=\"\";for(var i=0;i<arr.length;i++){switch (arr[i]) {case \"0\":break;case \"1\":str+=\"<img  width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_green.png\\\"/>&nbsp;\";break;case \"2\":str+=\"<img width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_yellow.png\\\" />&nbsp;\";break;case \"3\":str+=\"<img width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_orange.png\\\" />&nbsp;\";break;case \"4\":str+=\"<img width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_red.png\\\" />&nbsp;\";break;default:break;}} return str;}' rowspan='3'>完成情况(按照公司设计质量标准评定:绿，黄，橙，红。四种工作完成状况)</th>";
                    trStr += "<th data-options=\"field:'wtype7',width:150, halign: 'center', align: 'center'\" rowspan='3'>未完成的原因</th>";
                    trStr += "<th data-options=\"field:'wtype8',width:150, halign: 'center', align: 'center'\" rowspan='3'>解决的办法</th>";
                    trStr += "<th data-options=\"field:'wtype9',width:150, halign: 'center', align: 'center'\" rowspan='3'>备注</th>";
                    trStr += "</tr>";

                    trStr += "<tr>";
                    trStr += "<th colspan='1'>日</th>";
                    trStr += str3;
                    trStr += "</tr>";

                    trStr += "<tr>";
                    trStr += "<th data-options=\"field:'wtype11',width:35, halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';}\">星期</th>";
                    trStr += str4;
                    trStr += str2;
                    trStr += "</tr>";
                    trStr += "</thead>";

                    //tr.Text = trStr;

                    //trStr += "[[";
                    //trStr += "{field:'stage_name',title:'阶段',width:50, halign: 'center', align: 'center',rowspan:3,styler: function(value,row,index){return 'background-color:white;';}},";
                    //trStr += "{field:'group_name',title:'小组',width:50, halign: 'center', align: 'center',rowspan:3,styler: function(value,row,index){return 'background-color:white;';}},";
                    //trStr += "{field:'contentName',title:'工作内容',width:150,  halign: 'center',rowspan:3,styler: function(value,row,index){return 'background-color:white;';},formatter: function (value, rowData, rowIndex) {return '<a>' + value + '</a>';}},";
                    //trStr += "{field:'itemName',title:'细目',width:150, halign: 'center',rowspan:3},";
                    //trStr += "{field:'m',title:'月'},";
                    //trStr += "{title:'" + monthstr + "(黄色色块代表完成这项工作所需要的完成时间，<br/>计划表中实际完成时间将用绿色色块做标记)',colspan:" + cols + "},";
                    //trStr += "{field:'wtype6',title:'完成情况(按照公司设计质量标准评定:绿，黄，橙，红。四种工作完成状况)',width:150, halign: 'center',rowspan:3},";
                    //trStr += "{field:'wtype7',title:'未完成的原因',width:150,  halign: 'center',rowspan:3},";
                    //trStr += "{field:'wtype8',title:'解决的办法',width:150,  halign: 'center',rowspan:3},";
                    //trStr += "{field:'wtype9',title:'备注',width:150,  halign: 'center',rowspan:3}";
                    //trStr += "],[";
                    //trStr += "{field:'d',title:'日'},";
                    //trStr += str3.Substring(0, str3.Length - 1);
                    
                    //trStr += "],[";
                    //trStr += "{field:'wtype11',title:'星期',width:35, halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';}},";
                    //trStr += str4;
                    //trStr += str2.Substring(0, str2.Length - 1);
                    //trStr += "]]";
                }
            }
        }
    }
}