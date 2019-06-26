using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project
{
    public partial class ViewProject : System.Web.UI.Page
    {
        protected string sid = "", pssid = "", pname = "", pcode = "", stageName = "",isConstruction = "";
        protected Model.project pModel = new Model.project();
        protected string trStr = "";
        protected string type = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                type = Request.Params["type"] == null ? "" : Request.Params["type"].Trim();
                pssid = Request.Params["ps_sid"] == null ? "" : Request.Params["ps_sid"].Trim();
                DataTable dt = new DataTable();
                DataSet ds = new BLL.Common().GetList("select project.sid as psid, project_name,project_code,stage_name,begin_date,end_date,project_stage.is_system from project_stage left outer join project on project_stage.p_sid=project.sid where project_stage.sid='" + pssid + "'");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt.Rows.Count > 0)
                {
                    isConstruction = dt.Rows[0]["is_system"].ToString().Trim();
                    pname = dt.Rows[0]["project_name"].ToString().Trim();
                    pcode = dt.Rows[0]["project_code"].ToString().Trim();
                    stageName = dt.Rows[0]["stage_name"].ToString().Trim();

                    pModel = new BLL.project().GetModel(int.Parse(dt.Rows[0]["psid"].ToString().Trim()));

                    string str0="", str1 = "", str2 = "", str3 = "", str4 = "";
                    DataTable impDT = new DataTable();
                    DataSet impDS = new BLL.Common().GetList("select * from project_implement where s_sid='" + pssid + "' order by sequence asc");
                    
                    if (impDS.Tables.Count > 0)
                    {
                        impDT = impDS.Tables[0];

                        for (int i = 0; i < impDT.Rows.Count; i++)
                        {
                           
                            str0 += "<th >" + new BLL.Common().GetList("select dbo.get_SNs_zxf('" + impDT.Rows[i]["v1"].ToString().Trim() + "')").Tables[0].Rows[0][0].ToString() + "</th>";
                            if (isConstruction == "1")
                            {
                                str1 += "<th  colspan='1'>" + impDT.Rows[i]["implement_name"].ToString().Trim() + "</th>";
                            }
                            else
                            {
                                str1 += "<th  colspan='1' rowspan='2' >" + impDT.Rows[i]["implement_name"].ToString().Trim() + "</th>";
                            }
                            //str1 += "{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:2},";
                            //str1 += "<th  colspan='1' rowspan='2' ></th>";
                            //str2 += "<th data-options=\"field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:100, halign:'center', align:'center'\" >" + new BLL.Common().GetList("select dbo.getUserAbbr_fu('"+impDT.Rows[i]["implementers_sid"].ToString().Trim()+"')").Tables[0].Rows[0][0] + "</th>";
                            str2 += "<th data-options=\"field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:100, halign:'center', align:'center'\" >" + new BLL.Common().GetList("select dbo.getUserName_fu('" + impDT.Rows[i]["implementers_sid"].ToString().Trim() + "')").Tables[0].Rows[0][0] + "</th>";
                            //str2 += "<th data-options=\"field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:100, halign:'center', align:'center'\" >" + impDT.Rows[i]["implementers"].ToString().Trim() + "</th>";
                            //str2 += "{field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',title:'" + impDT.Rows[i]["implementers"].ToString().Trim() + "',width:100, halign:'center', align:'center'},";
                        }
                    }
                    else
                    {
                        str0 += "<th ></th>";
                        if (isConstruction == "1")
                        {
                            str1 += "<th colspan='1'></th>";
                        }
                        else
                        {
                            str1 += "<th colspan='1' rowspan='2'></th>";
                        }
                        str2 += "<th data-options=\"field:''\"></th>";
                    }
                    string monthstr = "";
                    string cols="1";
                    if (dt.Rows[0]["begin_date"].ToString().Trim() != "" && dt.Rows[0]["end_date"].ToString().Trim() != "" && dt.Rows[0]["begin_date"] != null && dt.Rows[0]["end_date"] != null)
                    {
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
                            str4 += "<th data-options=\"field:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){var font='';if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "'].length>3){font='font-size:8px;';}if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==1){return 'background-color:yellow;'+font}else if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==2){return 'background-color:green;'+font}else{return ''}}\" style='white-space:pre-wrap; word-wrap:break-word;'>" + w + "</th>";
                        }
                    }
                    else
                    {
                        monthstr = "";
                        str3 = "<th data-options=\"title: '',rowspan:1\"}/>";

                        str4 = "<th data-options=\"title:'',field:'w',width:300\"}/>";
                    }
                    //int work_width = 200;
                    //int showCount = 15;
                    //if (int.Parse(cols) * 30 > 200)
                    //{
                    //    work_width = int.Parse(cols) * 30;
                    //    if (work_width > 200)
                    //    {
                    //        showCount = showCount + ((work_width - 200) * 3 / 30);
                    //    }
                    //}
                    int work_width = 30;
                    int showCount = 2;
                    if (int.Parse(cols) * 30 > 30)
                    {
                        work_width = int.Parse(cols) * 30;
                        if (work_width > 30)
                        {
                            showCount = showCount + ((work_width - 30) * 2 / 30);
                        }
                    }

                    string content = "";
                    string item = "";
                    bool showContent = true;
                    bool showItem = true;
                    bool showGroup = true;
                    bool showStage = true;
                    string showWorkTitle = "";
                    string widthContent = "200";
                    string widthItem = "200";
                    switch (isConstruction)
                    {
                        case "0":
                            content = "工作内容";
                            item = "细目";
                            string workTitle = monthstr + "(黄色色块代表完成这项工作所需要的完成时间,计划表中实际完成时间将用绿色色块做标记)";
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
                        case "1":
                            content = "空间";
                            item = "图纸及索引号";
                            showGroup = false;
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

                            workTitle = monthstr + "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))";
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
                        case "2":
                            showGroup = false;
                            content = "货物类别";
                            item = "工作细目";
                            showWorkTitle = monthstr;
                            break;

                        case "3":
                            content = "商品类别";
                            item = "细目";
                            workTitle = "智创产品逐个跟踪+" + pname;
                            for (int i = 0; i < workTitle.Length; i++)
                            {
                                showWorkTitle += workTitle[i];
                                if ((i + 1) % showCount == 0)
                                {
                                    showWorkTitle += "<br/>";
                                }
                            }
                            showStage = false; 
                            showGroup = false;
                            showContent = false;
                            widthItem = "100";
                            break;

                        case "4":
                            content = "加工类别";
                            item = "工作细目";
                            workTitle = monthstr + "(进程计划)";
                            for (int i = 0; i < workTitle.Length; i++)
                            {
                                showWorkTitle += workTitle[i];
                                if ((i + 1) % showCount == 0)
                                {
                                    showWorkTitle += "<br/>";
                                }
                            }
                            showStage = false; 
                            showGroup = false;
                            widthContent = "80";
                            widthItem = "100";
                            break;

                        default:
                            break;
                    }

                    trStr += "<thead data-options='frozen:true'>";
                    trStr += "<tr>";
                    if (isConstruction == "3")
                    {
                        trStr += "<th rowspan='3' data-options='field:\"number\",width:60, halign:\"center\", align:\"center\"'>图纸编号 </th>";
                        trStr += "<th rowspan='1' colspan='4' style='width:200px'>细目</th>";

                        trStr += "<th rowspan='3' data-options='field:\"useSpace\",width:60, halign:\"center\", align:\"center\"'>应用空间 </th>";
                        trStr += "<th rowspan='3' data-options='field:\"spaceCount\",width:60, halign:\"center\", align:\"center\"'>应用数量</th>";
                        trStr += "<th rowspan='3' data-options='field:\"install\",width:60, halign:\"center\", align:\"center\"'>安装位置</th>";
                        trStr += "<th rowspan='3' data-options='field:\"usePart\",width:60, halign:\"center\", align:\"center\"'>应用部位</th>";
                        trStr += "<th rowspan='3' data-options='field:\"unit\",width:60, halign:\"center\", align:\"center\"'>单位 </th>";
                        trStr += "<th rowspan='3' data-options='field:\"amount\",width:60, halign:\"center\", align:\"center\"'>数量</th>";
                        trStr += "<th rowspan='3' data-options='field:\"paintPaletteNumber\",width:60, halign:\"center\", align:\"center\"'>油漆色板编号 </th>";

                        trStr += "<th rowspan='3' data-options='field:\"ppiRemark\",width:60, halign:\"center\", align:\"center\"'>备注</th>";
                    }
                    if (isConstruction == "4")
                    {
                        trStr += "<th rowspan='3' data-options='field:\"number\",width:60, halign:\"center\", align:\"center\"'>图纸编号 </th>";
                        trStr += "<th rowspan='1' colspan='4' style='width:200px'>细目</th>";

                        trStr += "<th rowspan='3' data-options='field:\"useSpace\",width:60, halign:\"center\", align:\"center\"'>应用空间 </th>";
                        trStr += "<th rowspan='3' data-options='field:\"usePart\",width:60, halign:\"center\", align:\"center\"'>应用部位</th>";
                        trStr += "<th rowspan='3' data-options='field:\"unit\",width:60, halign:\"center\", align:\"center\"'>单位 </th>";
                        trStr += "<th rowspan='3' data-options='field:\"amount\",width:60, halign:\"center\", align:\"center\"'>数量</th>";
                        trStr += "<th rowspan='3' data-options='field:\"EndProduct\",width:60, halign:\"center\", align:\"center\"'>成品</th>";
                        trStr += "<th rowspan='3' data-options='field:\"ppiRemark\",width:60, halign:\"center\", align:\"center\"'>备注</th>";
                    }
                    if (showGroup)
                    {
                        trStr += "<th data-options=\"field:'group_name',width:50, halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:white;';}\" rowspan='3'>小组</th>";
                    }
                    if (showContent)
                    {
                        trStr += "<th data-options='field:\"contentName\",width:"+widthContent+", halign: \"center\", styler: function(value,row,index){return \"background-color:white;\";},formatter: function (value, rowData, rowIndex) {var str=\"<a class=\\\"a_black\\\" title=\\\"\" + value + \"\\\"><span class=\\\"mlength\\\">\" + value + \"</span></a>\";return str;}' rowspan='3' >" + content + "</th>";
                    }

                    trStr += "<th data-options='field:\"itemName\",width:"+widthItem+", halign: \"center\" ,formatter: function (value, rowData, rowIndex) {var str=\"<a class=\\\"a_black\\\" title=\\\"\" + value + \"\\\"><span class=\\\"mlength\\\">\" + value + \"</span></a>\";return str;}' rowspan='3'>"+item+"</th>";

                    trStr += "</tr>";

                    if (isConstruction == "3")
                    {
                        trStr += "<tr>";
                        trStr += "<th colspan='1' rowspan='2' data-options='field:\"productName\",width:60, halign:\"center\", align:\"center\"'>项目产品名称 </th>";
                        trStr += "<th colspan='1' rowspan='2' data-options='field:\"productPic\",width:45, halign:\"center\", align:\"center\",formatter: function (value, rowData, rowIndex) {if (value != \"\") { return  \"<a path=\\\"/ProductPic/\" + value +\"\\\" class=\\\"preview\\\"><img alt=\\\"\\\" height=\\\"45px\\\" src=\\\"/ProductPic/\" + value + \"\\\"></a>\";}}'>图片 </th>";
                        trStr += "<th colspan='1' rowspan='2' data-options='field:\"Specifications\",width:55, halign:\"center\", align:\"center\"'>图纸规格 </th>";
                        trStr += "<th rowspan='2' data-options='field:\"paintColor\",width:60, halign:\"center\", align:\"center\"'>漆面颜色 </th>";
                        trStr += "</tr>";
                    }
                    if (isConstruction == "4")
                    {
                        trStr += "<tr>";
                        trStr += "<th colspan='1' rowspan='2' data-options='field:\"productName\",width:60, halign:\"center\", align:\"center\"'>项目产品名称 </th>";
                        trStr += "<th colspan='1' rowspan='2' data-options='field:\"productPic\",width:45, halign:\"center\", align:\"center\",formatter: function (value, rowData, rowIndex) {if (value != \"\") { return  \"<a path=\\\"/ProductPic/\" + value +\"\\\" class=\\\"preview\\\"><img alt=\\\"\\\" height=\\\"45px\\\" src=\\\"/ProductPic/\" + value + \"\\\"></a>\";}}'>图片 </th>";
                        trStr += "<th colspan='1' rowspan='2' data-options='field:\"Specifications\",width:55, halign:\"center\", align:\"center\"'>图纸规格 </th>";
                        trStr += "<th rowspan='2' data-options='field:\"paintColor\",width:60, halign:\"center\", align:\"center\"'>漆面颜色 </th>";
                        trStr += "</tr>";
                    }
                    trStr += "</thead>";

                    trStr += "<thead>";
                    trStr += "<tr>";
                    
                    trStr += "<th colspan='1'>月</th>";
                    trStr += "<th colspan='" + cols + "' >" + showWorkTitle + "</th>";
                    trStr += str1;
                    trStr += "<th data-options='field:\"header\",width:150, halign:\"center\", align:\"center\"' rowspan='3'>组长审核人</th>";
                    trStr += "<th data-options='field:\"review_results\",width:150, halign:\"center\", align:\"center\",formatter:function(value,rowData,rowIndex){var str=\"\";var s=rowData[\"reviewer\"]; switch(value){case\"0\":str+=\"<div style=\\\"color:Red;\\\">未完成(\"+s+\")</div>\";break;case\"1\":str+=\"<div style=\\\"color:Green;\\\">完成(\"+s+\")</div>\";break;} return str;}' rowspan='3'>组长审核结果</th>";
                    trStr += "<th data-options=\"field:'unfinished_reason',width:150, halign: 'center', align: 'center'\" rowspan='3'>未完成的原因</th>";
                    trStr += "<th data-options=\"field:'solution',width:150, halign: 'center', align: 'center'\" rowspan='3'>解决的办法</th>";
                    trStr += "<th data-options=\"field:'reviewed',width:150, halign: 'center', align: 'center'\" rowspan='3'>解决的结果</th>";
                    trStr += "<th data-options='field:\"finaler\",width:150, halign:\"center\", align:\"center\"' rowspan='3'>总审人</th>";
                    trStr += "<th data-options='field:\"reviews\",width:150, halign: \"center\",formatter: function (value, rowData, rowIndex) {var arr=value.split(\",\"); var ReviewDates = rowData[\"ReviewDates\"].split(\",\");var str=\"\";for(var i=0;i<arr.length;i++){switch (arr[i]) {case \"0\":break;case \"1\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：优\\\"   width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_green.png\\\"/>&nbsp;\";break;case \"2\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：良\\\" width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_yellow.png\\\" />&nbsp;\";break;case \"3\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：差\\\"  width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_orange.png\\\" />&nbsp;\";break;case \"4\":str+=\"<img title=\"+ReviewDates[i]+\"  width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_red.png\\\" />&nbsp;\";break;case \"5\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：不及格\\\" width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_error.png\\\"/>&nbsp;\";break;default:break;}} return str;}' rowspan='3'>总审结果</th>";
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

                    //if (isConstruction=="1")
                    //{

                    //    string flow = "";
                    //    DataTable tmpDT = new DataTable();
                    //    DataSet tmpDS = new BLL.project_work_flow().GetList(" s_sid='" + pssid + "'");
                    //    if (tmpDS.Tables.Count > 0)
                    //    {
                    //        tmpDT = tmpDS.Tables[0];
                    //    }
                    //    for (int i = 0; i < tmpDT.Rows.Count; i++)
                    //    {
                    //        flow += (i + 1).ToString() + "." + tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
                    //    }

                    //    string workTitle = monthstr + "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))";
                    //    string showWorkTitle = "";
                    //    for (int i = 0; i < workTitle.Length; i++)
                    //    {
                    //        showWorkTitle += workTitle[i];
                    //        if ((i + 1) % showCount == 0)
                    //        {
                    //            showWorkTitle += "<br/>";
                    //        }
                    //    }
                    //    trStr += "<thead data-options='frozen:true'>";
                    //    trStr += "<tr>";
                    //    trStr += "<th data-options='field:\"contentName\",width:150, halign: \"center\", styler: function(value,row,index){return \"background-color:white;\";},formatter: function (value, rowData, rowIndex) {var str=\"<a class=\\\"a_black\\\" title=\\\"\" + value + \"\\\"><span class=\\\"mlength\\\">\" + value + \"</span></a>\";return str;}' rowspan='3' >空间</th>";

                    //    trStr += "<th data-options='field:\"itemName\",width:150, halign: \"center\" ,formatter: function (value, rowData, rowIndex) {var str=\"<a class=\\\"a_black\\\" title=\\\"\" + value + \"\\\"><span class=\\\"mlength\\\">\" + value + \"</span></a>\";return str;}' rowspan='3'>图纸及索引</th>";

                    //    trStr += "</tr>";
                    //    trStr += "</thead>";

                    //    trStr += "<thead>";
                    //    trStr += "<tr>";
                    //    trStr += "<th colspan='1'>月</th>";
                    //    trStr += "<th colspan='" + cols + "'>" + showWorkTitle + "</th>";
                    //    trStr += str1;
                    //    trStr += "<th data-options='field:\"header\",width:150, halign:\"center\", align:\"center\"' rowspan='3'>组长审核人</th>";
                    //    trStr += "<th data-options='field:\"review_results\",width:150, halign:\"center\", align:\"center\",formatter:function(value,rowData,rowIndex){var str=\"\";var s=rowData[\"reviewer\"]; switch(value){case\"0\":str+=\"<div style=\\\"color:Red;\\\">未完成(\"+s+\")</div>\";break;case\"1\":str+=\"<div style=\\\"color:Green;\\\">完成(\"+s+\")</div>\";break;} return str;}' rowspan='3'>组长审核结果</th>";
                    //    trStr += "<th data-options=\"field:'unfinished_reason',width:150, halign: 'center', align: 'center'\" rowspan='3'>未完成的原因</th>";
                    //    trStr += "<th data-options=\"field:'solution',width:150, halign: 'center', align: 'center'\" rowspan='3'>解决的办法</th>";
                    //    trStr += "<th data-options=\"field:'reviewed',width:150, halign: 'center', align: 'center'\" rowspan='3'>解决的结果</th>";
                    //    trStr += "<th data-options='field:\"finaler\",width:150, halign:\"center\", align:\"center\"' rowspan='3'>总审人</th>";
                    //    trStr += "<th data-options='field:\"reviews\",width:150, halign: \"center\",formatter: function (value, rowData, rowIndex) {var arr=value.split(\",\"); var ReviewDates = rowData[\"ReviewDates\"].split(\",\");var str=\"\";for(var i=0;i<arr.length;i++){switch (arr[i]) {case \"0\":break;case \"1\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：优\\\"   width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_green.png\\\"/>&nbsp;\";break;case \"2\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：良\\\" width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_yellow.png\\\" />&nbsp;\";break;case \"3\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：差\\\"  width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_orange.png\\\" />&nbsp;\";break;case \"4\":str+=\"<img title=\"+ReviewDates[i]+\"  width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_red.png\\\" />&nbsp;\";break;case \"5\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：不及格\\\" width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_error.png\\\"/>&nbsp;\";break;default:break;}} return str;}' rowspan='3'>总审结果</th>";
                    //    trStr += "<th data-options=\"field:'wtype9',width:150, halign: 'center', align: 'center'\" rowspan='3'>备注</th>";
                        
                    //    trStr += "</tr>";

                    //    trStr += "<tr>";
                    //    trStr += "<th colspan='1'>日</th>";
                    //    trStr += str3;
                    //    trStr += str0;
                    //    trStr += "</tr>";

                    //    trStr += "<tr>";
                    //    trStr += "<th data-options=\"field:'wtype11',width:35, halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';}\">星期</th>";
                    //    trStr += str4;
                    //    trStr += str2;
                    //    trStr += "</tr>";
                    //    trStr += "</thead>";
                    //}
                    //else
                    //{
                    //    string workTitle = monthstr + "(黄色色块代表完成这项工作所需要的完成时间，计划表中实际完成时间将用绿色色块做标记)";
                    //    string showWorkTitle = "";
                    //    for (int i = 0; i < workTitle.Length; i++)
                    //    {
                    //        showWorkTitle += workTitle[i];
                    //        if ((i + 1) % showCount == 0)
                    //        {
                    //            showWorkTitle += "<br/>";
                    //        }
                    //    }
                    //    trStr += "<thead data-options='frozen:true'>";
                    //    trStr += "<tr>";
                    //    trStr += "<th data-options=\"field:'group_name',width:50, halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:white;';}\" rowspan='3'>小组</th>";

                    //    trStr += "<th data-options='field:\"contentName\",width:150, halign: \"center\", styler: function(value,row,index){return \"background-color:white;\";},formatter: function (value, rowData, rowIndex) {var str=\"<a class=\\\"a_black\\\" title=\\\"\" + value + \"\\\"><span class=\\\"mlength\\\">\" + value + \"</span></a>\";return str;}' rowspan='3' >工作内容</th>";

                    //    trStr += "<th data-options='field:\"itemName\",width:150, halign: \"center\" ,formatter: function (value, rowData, rowIndex) {var str=\"<a class=\\\"a_black\\\" title=\\\"\" + value + \"\\\"><span class=\\\"mlength\\\">\" + value + \"</span></a>\";return str;}' rowspan='3'>细目</th>";

                    //    trStr += "</tr>";
                    //    trStr += "</thead>";

                    //    trStr += "<thead>";
                    //    trStr += "<tr>";
                    //    trStr += "<th colspan='1'>月</th>";
                    //    trStr += "<th colspan='" + cols + "' >" + showWorkTitle + "</th>";
                    //    trStr += str1;
                    //    trStr += "<th data-options='field:\"header\",width:150, halign:\"center\", align:\"center\"' rowspan='3'>组长审核人</th>";
                    //    trStr += "<th data-options='field:\"review_results\",width:150, halign:\"center\", align:\"center\",formatter:function(value,rowData,rowIndex){var str=\"\";var s=rowData[\"reviewer\"]; switch(value){case\"0\":str+=\"<div style=\\\"color:Red;\\\">未完成(\"+s+\")</div>\";break;case\"1\":str+=\"<div style=\\\"color:Green;\\\">完成(\"+s+\")</div>\";break;} return str;}' rowspan='3'>组长审核结果</th>";
                    //    trStr += "<th data-options=\"field:'unfinished_reason',width:150, halign: 'center', align: 'center'\" rowspan='3'>未完成的原因</th>";
                    //    trStr += "<th data-options=\"field:'solution',width:150, halign: 'center', align: 'center'\" rowspan='3'>解决的办法</th>";
                    //    trStr += "<th data-options=\"field:'reviewed',width:150, halign: 'center', align: 'center'\" rowspan='3'>解决的结果</th>";
                    //    trStr += "<th data-options='field:\"finaler\",width:150, halign:\"center\", align:\"center\"' rowspan='3'>总审人</th>";
                    //    trStr += "<th data-options='field:\"reviews\",width:150, halign: \"center\",formatter: function (value, rowData, rowIndex) {var arr=value.split(\",\"); var ReviewDates = rowData[\"ReviewDates\"].split(\",\");var str=\"\";for(var i=0;i<arr.length;i++){switch (arr[i]) {case \"0\":break;case \"1\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：优\\\"   width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_green.png\\\"/>&nbsp;\";break;case \"2\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：良\\\" width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_yellow.png\\\" />&nbsp;\";break;case \"3\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：差\\\"  width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_orange.png\\\" />&nbsp;\";break;case \"4\":str+=\"<img title=\"+ReviewDates[i]+\"  width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_red.png\\\" />&nbsp;\";break;case \"5\":str+=\"<img title=\\\"审核时间：\"+ReviewDates[i]+\" 结果：不及格\\\" width=\\\"16px\\\" height=\\\"16px\\\" src=\\\"../Images/point/bullet_error.png\\\"/>&nbsp;\";break;default:break;}} return str;}' rowspan='3'>总审结果</th>";
                    //    trStr += "<th data-options=\"field:'wtype9',width:150, halign: 'center', align: 'center'\" rowspan='3'>备注</th>";
                       
                    //    trStr += "</tr>";

                    //    trStr += "<tr>";
                    //    trStr += "<th colspan='1'>日</th>";
                    //    trStr += str3;
                    //    trStr += "</tr>";

                    //    trStr += "<tr>";
                    //    trStr += "<th data-options=\"field:'wtype11',width:35, halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';}\">星期</th>";
                    //    trStr += str4;
                    //    trStr += str2;
                    //    trStr += "</tr>";
                    //    trStr += "</thead>";

                    //}
                    
                }
            }
        }
    }
}