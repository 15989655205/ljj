using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project
{
    public partial class Content_IDE : System.Web.UI.Page
    {
        protected string sid = "", pssid = "", pname = "", pcode = "", stageName = "", column = "", frozencolumns="",columnName = "", psid = "", sDateStr = "", eDateStr = "";
        protected string groupHeaders1="",groupHeaders2="",colModel="",colNames="";
        protected string showContent = "", showItem = "", isConstruction = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pssid = Request.Params["ps_sid"] == null ? "" : Request.Params["ps_sid"].Trim();
                //isConstruction = Request.Params["isConstruction"] == null ? "" : Request.Params["isConstruction"].Trim();
                //stageName = DBUtility.DbHelperSQL.GetSingle("select stage_name from project_stage where sid=" + pssid).ToString().Trim();
                DataTable dt = new DataTable();
                DataSet ds = new BLL.Common().GetList("select project.sid as psid, project_name,project_code,stage_name,Convert(varchar(10),begin_date,120) begin_date,Convert(varchar(10),end_date,120) end_date,project_stage.is_system,project.v1,project.v2,dbo.getUserNames_fu(project.v1) v1User,dbo.getUserNames_fu(project.v2) v2User from project_stage left outer join project on project_stage.p_sid=project.sid where project_stage.sid='" + pssid + "'");
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
                    string v1 = dt.Rows[0]["v1"].ToString().Trim();
                    string v2 = dt.Rows[0]["v2"].ToString().Trim();
                    string v1User = dt.Rows[0]["v1User"].ToString().Trim();
                    string v2User = dt.Rows[0]["v2User"].ToString().Trim();
                    string v1Str = "", v2Str = "";
                    string v1Json = "", v2Json = "";
                    if (v1.Length > 0)
                    {
                        string[] v1Arr = v1.Split(',');
                        string[] v1UserArr = v1User.Split(',');
                        v1Json = "[";
                        for (int n = 0; n < v1Arr.Length; n++)
                        {
                            v1Str += v1Arr[n] + ":" + v1UserArr[n] + ";";
                            v1Json += "{'id':'" + v1Arr[n] + "','text':'" + v1UserArr[n] + "'},";
                        }
                        if (v1Str.Length > 0)
                        {
                            v1Str = v1Str.Substring(0, v1Str.Length - 1);
                        }
                        if (v1Json.Length > 1)
                        {
                            v1Json = v1Json.Substring(0, v1Json.Length - 1);
                        }
                        v1Json += "]";
                    }
                    if (v2.Length > 0)
                    {
                        string[] v2Arr = v2.Split(',');
                        string[] v2UserArr = v2User.Split(',');
                        v2Json = "[";
                        for (int n = 0; n < v2Arr.Length; n++)
                        {
                            v2Str += v2Arr[n] + ":" + v2UserArr[n] + ";";
                            v2Json += "{'id':'" + v2Arr[n] + "','text':'" + v2UserArr[n] + "'},";
                        }
                        if (v2Str.Length > 0)
                        {
                            v2Str = v2Str.Substring(0, v2Str.Length - 1);
                        }
                        if (v2Json.Length > 1)
                        {
                            v2Json = v2Json.Substring(0, v2Json.Length - 1);
                        }
                        v2Json += "]";
                    }
                    EasyuiGrid_Edit(dt,v1Json,v2Json);
                    //EasyuiGrid_Control(dt);
                    //JQGrid(dt, v1Str, v2Str);

                }
            }
        }

        #region jqGrid
        private void JQGrid(DataTable dt,string v1, string v2)
        {
            //动态添加实施列
            string dynImp = "", dynImp2 = "", dynImpUser = "", dynDay = "", dynWeek = "", dynImpName = "", dynWeekName = "", startWeek = "";
            DataTable impDT = new DataTable();
            DataSet impDS = new DAL.project_implement().getList(" s_sid='" + pssid + "' order by sequence");//new BLL.project_implement().GetList(" s_sid='" + pssid + "' order by sequence");
            if (impDS.Tables.Count > 0)
            {
                impDT = impDS.Tables[0];

                for (int i = 0; i < impDT.Rows.Count; i++)
                {
                    dynImpName += ",'" + impDT.Rows[i]["impUserAbbr"].ToString().Trim() + "'";
                    dynImp += ",{startColumnName:'imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "',numberOfColumns:1,titleText:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "'}";
                    dynImp2 += ",{startColumnName:'imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "',numberOfColumns:1,titleText:''}";
                    string impUserTemp = "";
                    if (impDT.Rows[i]["implementers_sid"].ToString().Trim().Length > 0)
                    {
                        string[] impUIDArr = impDT.Rows[i]["implementers_sid"].ToString().Trim().Split(',');
                        string[] impUserNameArr = impDT.Rows[i]["impUserName"].ToString().Trim().Split(',');
                        string[] impUserAbbrArr = impDT.Rows[i]["impUserAbbr"].ToString().Trim().Split(',');
                        for (int n = 0; n < impUIDArr.Length; n++)
                        {
                            impUserTemp += impUIDArr[n] + ":" + impUserAbbrArr[n] + ";";
                        }
                        if (impUserTemp.Length > 0)
                        {
                            impUserTemp = impUserTemp.Substring(0, impUserTemp.Length - 1);
                        }
                    }
                    dynImpUser += ",{name:'imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "',index:'imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:80,  align:'center',editable:true,edittype:'select',editoptions:{value:'" + impUserTemp + "',multiple:true}}";
                }
            }
            else
            {
                dynImpName += ",''";
                dynImp += ",{startColumnName:'imp_',numberOfColumns:1,titleText:''}";
                dynImp2 += ",{startColumnName:'imp_',numberOfColumns:1,titleText:''}";
                dynImpUser = ",{name:'imp_',index:'imp_',width:80, align:'center'}";
            }

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
                    if (i == 0)
                    {
                        startWeek = "flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd");
                    }
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
                    dynDay += ",{startColumnName:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',numberOfColumns:1,titleText:'" + sDate.AddDays(i).Day.ToString() + "'}";
                    dynWeekName += ",'" + w + "'";
                    dynWeek += ",{name:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',index:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:60,align:'center',editable:true}";
                    //dynWeek += ",{title:'" + w + "',field:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){var font='';if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "'].length>3)font='font-size:8px;';if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==1){return 'background-color:yellow;'+font}else if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==2){return 'background-color:green;'+font}else{return ''}}}";
                }
            }
            else
            {
                monthstr = "";
                startWeek = "w";
                dynDay += ",{startColumnName:'w',numberOfColumns:1,titleText:''}";
                dynWeek = ",{name:'w',index:'w',width:100}";
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
                    flow += (i + 1).ToString() + "." + tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
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

                colNames = "['空间','图纸及索引号','星期'" + dynWeekName + dynImpName + ",'主管审核','未完成的原因','解决的办法','解决的结果','总审','备注','细目ID','内容ID','内容排序']";
                colModel += "[";
                colModel += "{ name: 'contentName',index:'contentName', width: 80,cellattr: function (rowId, tv, rawObject, cm, rdata) {return 'id=\\\"contentName' + rowId + '\\\"';}}";
                colModel += ",{name: 'itemName', index:'itemName',width: 200,editable:true}";
                colModel += ",{name: 'week',width:40,align: 'center'}";
                colModel += dynWeek;
                colModel += dynImpUser;
                //column += ",{ title: '" + showWorkTitle + "',rowspan:1,colspan:" + cols + "}";
                //column += dynImp;
                //colModel += ",{name: 'header', index:'header',width: 80,align: 'center',editable:true,editoptions: { dataEvents: [{ type: 'click', data: { i: 7 }, fn: function(e) { alert(e.data.i); } }, { type: 'keypress', fn: function(e) { alert(); } } ] }}";
                colModel += ",{name: 'header', index:'header',width: 80,align: 'center',editable:true,edittype:'select',editoptions:{value:'" + v1 + "'}}";
                colModel += ",{ name: 'unfinished_reason',index: 'unfinished_reason', width: 80,align: 'center'}";
                colModel += ",{ name: 'solution',index: 'solution', width: 80, align: 'center'}";
                colModel += ",{ name: 'reviewed',index: 'reviewed', width: 80, align: 'center'}";
                colModel += ",{ name: 'finaler',index: 'finaler', width: 80, align: 'center',editable:true,edittype:'select',editoptions:{value:'" + v2 + "'}}";
                colModel += ",{ name: 'remark',index: 'remark', width: 200,editable:true}";
                colModel += ",{ name: 'sid',index: 'sid', width: 1,editable:true,hidden:true}";
                colModel += ",{ name: 'csid',index: 'csid', width: 1,editable:true,hidden:true}";
                colModel += ",{ name: 'contentSequence',index: 'contentSequence', width: 1,hidden:true}";
                colModel += "]";

                groupHeaders1 += "[";
                groupHeaders1 += "{startColumnName: 'week', numberOfColumns: 1, titleText: '月'}";
                groupHeaders1 += ",{startColumnName: '" + startWeek + "', numberOfColumns: " + cols + ", titleText: '" + workTitle + "'}";
                groupHeaders1 += dynImp;
                groupHeaders1 += "]";

                groupHeaders2 += "[";
                groupHeaders2 += "{startColumnName: 'week', numberOfColumns: 1, titleText: '日'}";
                groupHeaders2 += dynDay;
                groupHeaders2 += dynImp2;
                groupHeaders2 += "]";
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
        #endregion

        #region easyuiGrid
        private void EasyuiGrid(DataTable dt)
        {

            //动态添加实施列
            string dynImp = "", dynImpUser = "", dynDay = "", dynWeek = "";
            DataTable impDT = new DataTable();
            DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + pssid + "' order by sequence");
            if (impDS.Tables.Count > 0)
            {
                impDT = impDS.Tables[0];

                for (int i = 0; i < impDT.Rows.Count; i++)
                {
                    dynImp += ",{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:2}";

                    dynImpUser += ",{title: '" + impDT.Rows[i]["implementers"].ToString().Trim() + "',field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:80, halign:'center', align:'center'}";
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
                    showCount = showCount + ((work_width - 200) * 3 / 30);
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
                    flow += (i + 1).ToString() + "." + tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
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
                column += ",{ title: '主管审核', field: 'header', width: 60,rowspan:3, halign: 'center', align: 'center',formatter: function (value, rowData, rowIndex) {return '<input id=\\\"head_\\\"/><a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
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
        #endregion 

        #region easyuiGrid_Edit
        private void EasyuiGrid_Edit(DataTable dt,string v1,string v2)
        {

            //动态添加实施列
            string dynImp = "", dynImpUser = "", dynDay = "", dynWeek = "",dynImpFlow="";
            DataTable impDT = new DataTable();
            DataSet impDS = new DAL.project_implement().getList(" s_sid='" + pssid + "' order by sequence");//new BLL.project_implement().GetList(" s_sid='" + pssid + "' order by sequence");
            string user = "";
            DataTable userdt = new BLL.Common().GetList("select UserName,Name from baseuser where Permissions=1 order by name ").Tables[0];
            user = DBUtility.JsonHelper.DataTable2Json_Combo(userdt).Replace('"', '\'');

            if (impDS.Tables.Count > 0)
            {
                impDT = impDS.Tables[0];

                for (int i = 0; i < impDT.Rows.Count; i++)
                {
                    dynImpFlow += ",{title:'" + new BLL.Common().GetList("select dbo.get_SNs_zxf('" + impDT.Rows[i]["v1"].ToString().Trim() + "')").Tables[0].Rows[0][0].ToString() + "'}";
                    if (isConstruction == "1")
                    {
                        dynImp += ",{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:1}";
                    }
                    else
                    {
                        dynImp += ",{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:2}";
                    }
                    //dynImp += ",{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:2}";
                    string json = "[]";
                    DataTable tmpDT1 = new DataTable();
                    DataSet tmpDS1 = new BLL.Common().GetList(" select username, value2 from baseuser where username in (  select * from  dbo.getTable('" + impDT.Rows[i]["implementers_sid"].ToString().Trim() + "',',')) order by name asc");
                    //DataSet tmpDS1 = new BLL.Common().GetList("select UserName,Name from baseuser where Permissions=1 order by name ");
                    if (tmpDS1.Tables.Count > 0)
                    {
                        tmpDT1 = tmpDS1.Tables[0];
                        json = DBUtility.JsonHelper.DataTable2Json_Combo(tmpDT1).Replace('"', '\'');
                    }
                    dynImpUser += ",{title: '" + impDT.Rows[i]["impUserAbbr"].ToString().Trim() + "',field:'imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:80, halign:'center', align:'center', editor: {type:'combobox',options:{valueField:'username',textField:'value2',multiple:true,data:" + json + ",panelHeight:'auto',editable:false,onLoadSuccess:function(){$(this).combobox('showPanel');}}},formatter:function(value, rowData, rowIndex){ return rowData.impAbbr_" + impDT.Rows[i]["sid"].ToString().Trim() + "}}";
                    //dynImpUser += ",{title: '" + impDT.Rows[i]["impUserAbbr"].ToString().Trim() + "',field:'imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:80, halign:'center', align:'center', editor: {type:'combobox',options:{valueField:'username',textField:'value2',multiple:true,data:" + json + ",panelHeight:'auto'}},formatter:function(value, rowData, rowIndex){ var text=''; for (var i = 0; i < " + json + ".length; i++) {if (" + json + "[i].username == value) {if(i!=0){text+=',';}text+=" + json + "[i].value2;}}return text;}}";
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
                    dynWeek += ",{title:'" + w + "',field:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){var font='';if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==null)return'';if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "'].length>3)font='font-size:8px;';if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==1){return 'background-color:yellow;'+font}else if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==2){return 'background-color:green;'+font}else{return ''}},editor:'text'}";
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
                    flow += (i + 1).ToString() + "." + tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
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

                //column += "[[";
                //column += "{ title: '空间', field: 'contentName', width: 80, rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                //column += ",{ title: '图纸及索引号', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                //column += ",{ title: '月'}";
                ////column += ",{ title: '" + monthstr + "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))',rowspan:1,colspan:" + cols + "}";
                frozencolumns += "[[";
                frozencolumns += "{ title: '空间', field: 'contentName', width: 80, rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {if(value==null)return'';return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';},editor:{type:'diseditText'}}";
                //frozencolumns += ",{ title: '图纸及索引号', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<input id=\\\"input_contentName\\\" value=\\\"' + value + '\\\" style=\\\"width:190px;\\\"/>';}}";
                frozencolumns += ",{ title: '图纸及索引号', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {if(value==null)return'';return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';},editor:'text'}";
                frozencolumns += "]]";
                column += "[[";
                column += "{ title: '月'}";
                column += ",{ title: '" + showWorkTitle + "',rowspan:1,colspan:" + cols + "}";
                column += dynImp;
                //column += ",{ title: '主管审核', field: 'v1', width: 60,rowspan:3, halign: 'center', align: 'center',formatter: function (value, rowData, rowIndex) {if(value==null)return'';return '<a class=\\\"a_black\\\" title=\\\"' + rowData.header + '\\\"><span class=\\\"mlength\\\">' + rowData.header + '</span></a>';}, editor: {type:'combobox',options:{valueField:'id',textField:'text',data:" + v1 + ",panelHeight:'auto',multiple: false,editable:false,onLoadSuccess:function(){$(this).combobox('showPanel');}}}}";
                column += ",{ title: '主管审核', field: 'v1', width: 60,rowspan:3, halign: 'center', align: 'center',formatter: function (value, rowData, rowIndex) {if(value==null)return'';return '<a class=\\\"a_black\\\" title=\\\"' + rowData.header + '\\\"><span class=\\\"mlength\\\">' + rowData.header + '</span></a>';}, editor: {type:'combobox',options:{valueField:'id',textField:'text',data:" + user + ",panelHeight:'auto',multiple: false,editable:false,onLoadSuccess:function(){$(this).combobox('showPanel');}}}}";
                column += ",{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, halign: 'center', align: 'center',editor:'diseditText'}";
                column += ",{ title: '解决的办法', field: 'solution', width: 60, rowspan:3, halign: 'center', align: 'center',editor:'diseditText'}";
                column += ",{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3, halign: 'center', align: 'center',editor:'diseditText'}";
                //column += ",{ title: '总审', field: 'v2', width: 60, rowspan:3,halign: 'center', align: 'center',formatter: function (value, rowData, rowIndex) {if(value==null)return'';return '<a class=\\\"a_black\\\" title=\\\"' + rowData.finaler + '\\\"><span class=\\\"mlength\\\">' + rowData.finaler + '</span></a>';}, editor: {type:'combobox',options:{valueField:'id',textField:'text',data:" + v2 + ",panelHeight:'auto',editable:false,onLoadSuccess:function(){$(this).combobox('showPanel');}}}}";
                column += ",{ title: '总审', field: 'v2', width: 60, rowspan:3,halign: 'center', align: 'center',formatter: function (value, rowData, rowIndex) {if(value==null)return'';return '<a class=\\\"a_black\\\" title=\\\"' + rowData.finaler + '\\\"><span class=\\\"mlength\\\">' + rowData.finaler + '</span></a>';}, editor: {type:'combobox',options:{valueField:'id',textField:'text',data:" + user + ",panelHeight:'auto',editable:false,onLoadSuccess:function(){$(this).combobox('showPanel');}}}}";
                column += ",{ title: '备注', field: 'remark', width: 200, rowspan:3,halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {if(value==null)return'';return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                column += "],";
                column += "[";
                column += "{ title: '日'}";
                column += dynDay;
                column += dynImpFlow;
                column += "],[";
                column += "{ title: '星期', field: 'week',width:40,halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';},editor:{type:'diseditText'}}";
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
        #endregion 

        #region easyGrid_control
        private void EasyuiGrid_Control(DataTable dt)
        {

            //动态添加实施列
            string dynImp = "", dynImpUser = "", dynDay = "", dynWeek = "";
            DataTable impDT = new DataTable();
            DataSet impDS = new DAL.project_implement().getList(" s_sid='" + pssid + "' order by sequence");//new BLL.project_implement().GetList(" s_sid='" + pssid + "' order by sequence");
            if (impDS.Tables.Count > 0)
            {
                impDT = impDS.Tables[0];

                for (int i = 0; i < impDT.Rows.Count; i++)
                {
                    dynImp += ",{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:2}";
                    string impUserTemp = "[";
                    if (impDT.Rows[i]["implementers_sid"].ToString().Trim().Length > 0)
                    {
                        string[] impUIDArr = impDT.Rows[i]["implementers_sid"].ToString().Trim().Split(',');
                        string[] impUserNameArr = impDT.Rows[i]["impUserName"].ToString().Trim().Split(',');
                        string[] impUserAbbrArr = impDT.Rows[i]["impUserAbbr"].ToString().Trim().Split(',');
                        for (int n = 0; n < impUIDArr.Length; n++)
                        {
                            impUserTemp += "{\\\"id\\\":\\\"" + impUIDArr[n] + "\\\",\\\"value\\\":\\\"" + impUserAbbrArr[n] + "\\\"},";
                        }
                        if (impUserTemp.Length > 1)
                        {
                            impUserTemp = impUserTemp.Substring(0, impUserTemp.Length - 1);
                        }
                    }
                    impUserTemp += "]";
                    dynImpUser += ",{title: '" + impDT.Rows[i]["implementers"].ToString().Trim() + "',field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:80, halign:'center', align:'center',formatter:function(value,row,index){return '<input name=\\\"input_imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "\\\"  style=\\\"width:70px;\\\"/> <script>$(\\\"input[name=\\\\\\\'input_imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "\\\\\\\']\\\").combobox({data:" + impUserTemp + ",valueField:\\\"id\\\",textField:\\\"value\\\"});<\\/script>'}}";
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
                    dynWeek += ",{title:'" + w + "',field:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:40,halign:'center',align:'center',styler: function(value,row,index){var font='';if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "'].length>3)font='font-size:8px;';if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==1){return 'background-color:yellow;'+font}else if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==2){return 'background-color:green;'+font}else{return ''}},formatter:function(value,row,index){return '<input id=\\\"input_flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "\\\" value=\\\"' + value + '\\\" style=\\\"width:30px;\\\"/>'}}";
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
                    flow += (i + 1).ToString() + "." + tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
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

                frozencolumns += "[[";
                frozencolumns += "{ title: '空间', field: 'contentName', width: 80, rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                frozencolumns += ",{ title: '图纸及索引号', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<input id=\\\"input_contentName\\\" value=\\\"' + value + '\\\" style=\\\"width:190px;\\\"/>';}}";
                frozencolumns += "]]";
                column += "[[";
                column += "{ title: '月'}";
                //column += ",{ title: '" + monthstr + "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))',rowspan:1,colspan:" + cols + "}";
                column += ",{ title: '" + showWorkTitle + "',rowspan:1,colspan:" + cols + "}";
                column += dynImp;
                column += ",{ title: '主管审核', field: 'header', width: 60,rowspan:3, halign: 'center', align: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
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
        #endregion
    }
}