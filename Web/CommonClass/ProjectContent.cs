using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Maticsoft.Web.CommonClass
{
    public class ProjectContent
    {
        public static void GetProjectContent(string pssid, ref string isConstruction, out string stageName, out string pname, out string psid, out string sDateStr, out string eDateStr, out string showContent, out string showItem, out string frozencolumns, out string column)
        {

            stageName = "";
            pname = "";
            psid = "";
            sDateStr = "";
            eDateStr = "";
            showContent = "";
            showItem = "";
            frozencolumns = "";
            column = "";
            DataSet ds;
            DataTable dt = new DataTable();
            ds = new BLL.Common().GetList("select project.sid as psid, project_name,project_code,stage_name,Convert(varchar(10),begin_date,120) begin_date,Convert(varchar(10),end_date,120) end_date,project_stage.is_system,project.v1,dbo.getUserNames_fu(project.v1) as v1Users,project.v2,dbo.getUserNames_fu(project.v2) as v2Users from project_stage left outer join project on project_stage.p_sid=project.sid where project_stage.sid='" + pssid + "'");


            string user = "";
            DataTable userdt = new BLL.Common().GetList("select UserName,Name from baseuser where Permissions=1 order by name ").Tables[0];
            DataRow newdr = userdt.NewRow();
            newdr["UserName"] = "";
            newdr["Name"] = "请选择";
            userdt.Rows.InsertAt(newdr, 0);
            user = DBUtility.JsonHelper.DataTable2Json_Combo(userdt).Replace('\"', '\'');

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
                dnyV1 = ",{title: '',field:'v1',width:80, halign:'center', align:'center',formatter:function(value,row){return row.header;},editor:{type:'combobox', options: { data: " + user + ", valueField: 'UserName', editable: false, textField: 'Name',required: true, missingMessage: '必填'}}}";

                //总审人
                string dnyV2 = "";
                dnyV2 = ",{title: '',field:'v2',width:80, halign:'center', align:'center',formatter:function(value,row){return row.finaler;},editor:{type:'combobox', options: { data: " + user + ", valueField: 'UserName', editable: false, textField: 'Name',required: true, missingMessage: '必填'}}}";

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

                        dynImpUser += ",{title: '" + impDT.Rows[i]["impUsers"].ToString().Trim() + "',field:'imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:80, halign:'center', align:'center',formatter:function(value,row){return row.Abbr_imp_" + impDT.Rows[i]["sid"].ToString().Trim() + ";},editor:{type:'combobox', options: { data: " + user + ", valueField: 'UserName', editable: false, textField: 'Name'}}}";
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
                        dynWeek += ",{title:'" + w + "',field:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==null)return '';var font='';if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "'].length>3)font='font-size:8px;';if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==1){return 'background-color:yellow;'+font}else if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==2){return 'background-color:green;'+font}else{return ''}},editor:'text'}";
                    }
                }
                else
                {
                    monthstr = "";
                    dynDay = ",{title: '',rowspan:1}";
                    dynWeek = ",{title: '',field:'w'}";
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
                //string calendarStr = "";
                string showGroup = "true";
                string showWorkTitle = "";
                string widthContent = "200";
                string widthItem = "200";
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
                        workTitle = monthstr + "(黄色色块代表完成这项工作所需要的完成时间,计划表中实际完成时间将用绿色色块做标记)";
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

                        showContent = "货物类别";
                        showItem = "工作细目";
                        showWorkTitle = monthstr;
                        break;

                    case "3":
                        showContent = "商品类别";
                        showItem = "细目";
                        workTitle = "智创产品逐个跟踪+" + pname;
                        for (int i = 0; i < workTitle.Length; i++)
                        {
                            showWorkTitle += workTitle[i];
                            if ((i + 1) % showCount == 0)
                            {
                                showWorkTitle += "<br/>";
                            }
                        }
                        break;

                    case "4":
                        showContent = "加工类别";
                        showItem = "工作细目";
                        workTitle = monthstr + "(进程计划)";
                        for (int i = 0; i < workTitle.Length; i++)
                        {
                            showWorkTitle += workTitle[i];
                            if ((i + 1) % showCount == 0)
                            {
                                showWorkTitle += "<br/>";
                            }
                        }
                        widthContent = "80";
                        break;

                    default:
                        break;
                }

                if (isConstruction != "3")
                {
                    frozencolumns += "[[";
                    frozencolumns += "{ title: '小组', field: 'group_name', width: 60, rowspan:3, halign: 'center', align: 'center',hidden:" + showGroup + ",editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '" + showContent + "', field: 'contentName', width: " + widthContent + ", rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';},editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '" + showItem + "', field: 'itemName', width: " + widthItem + ",rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';},editor:'text'}";
                    frozencolumns += "]]";
                    column += "[[";
                    column += "{ title: '月'}";
                    column += ",{ title: '" + showWorkTitle + "',colspan:" + cols + "}";
                    column += dynImp;
                    //column += ",{ title: '组长审核', rowspan:2,colspan:"+(v1UidArr.Length>0?v1UidArr.Length:1)+", halign: 'center', align: 'center'}";
                    column += ",{ title: '组长审核', rowspan:2,colspan:1, halign: 'center', align: 'center'}";
                    column += ",{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    column += ",{ title: '解决的办法', field: 'solution', width: 60, rowspan:3, halign:'center', align:'center',editor:{type:'diseditText'}}";
                    column += ",{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3, halign:'center', align:'center',editor:{type:'diseditText'}}";
                    //column += ",{ title: '总审', rowspan:2,colspan:" + (v2UidArr.Length > 0 ? v2UidArr.Length : 1) + ", halign: 'center', align: 'center'}";
                    column += ",{ title: '总审', rowspan:2,colspan:1, halign: 'center', align: 'center'}";
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
                else
                {
                    frozencolumns += "[[";
                    frozencolumns += "{ title: '编号', field: 'number', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '细目', rowspan:1, colspan:3, halign: 'center', align: 'center'}";
                    frozencolumns += ",{ title: '漆面颜色', field: 'paintColor', width: 100, rowspan:3, halign: 'center', align: 'center',editor:{type:'text'}}";
                    frozencolumns += ",{ title: '应用空间', field: 'useSpace', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '应用数量', field: 'spaceCount', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '安装位置', field: 'install', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '应用部位', field: 'usePart', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '单位', field: 'unit', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '数量', field: 'amount', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '油漆色板编号', field: 'paintPaletteNumber', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '加工类别', field: 'contentName', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '备注', field: 'remark', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'text'}}";
                    frozencolumns += ",{ title: '工作明细', field: 'itemName', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'text'}}";
                    frozencolumns += "]";
                    frozencolumns += ",[";
                    frozencolumns += "{ title: '项目产品名称', field: 'productName', width: 100,  rowspan:2, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    frozencolumns += ",{ title: '图片', field: 'productPic', width: 100, rowspan:2,halign: 'center', align: 'center',"
                    + "formatter: function (value, rowData, rowIndex) {"
                                + "if (value != '') {"
                                   + " return  \\\"<a path='../ProductPic/\\\" + value + \\\"' class='preview'><img alt='' height='45px' src='/ProductPic/\\\" + value + \\\"'></a>\\\";"
                                + "}"
                            + "}}";
                    frozencolumns += ",{ title: '规格', field: 'Specifications', width: 60, rowspan:2,halign: 'center', align: 'center',editor:{type:'diseditText'}}";



                    frozencolumns += "]]";
                    column += "[[";
                    column += "{ title: '月'}";
                    column += ",{ title: '" + showWorkTitle + "',colspan:" + cols + "}";
                    column += dynImp;
                    //column += ",{ title: '组长审核', rowspan:2,colspan:"+(v1UidArr.Length>0?v1UidArr.Length:1)+", halign: 'center', align: 'center'}";
                    column += ",{ title: '组长审核', rowspan:2,colspan:1, halign: 'center', align: 'center'}";
                    column += ",{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
                    column += ",{ title: '解决的办法', field: 'solution', width: 60, rowspan:3, halign:'center', align:'center',editor:{type:'diseditText'}}";
                    column += ",{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3, halign:'center', align:'center',editor:{type:'diseditText'}}";
                    //column += ",{ title: '总审', rowspan:2,colspan:" + (v2UidArr.Length > 0 ? v2UidArr.Length : 1) + ", halign: 'center', align: 'center'}";
                    column += ",{ title: '总审', rowspan:2,colspan:1, halign: 'center', align: 'center'}";
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

        //    public static string GetProjectContentView(string pssid, ref string isConstruction, out string stageName, out string pname, out string psid, out string sDateStr, out string eDateStr, out string showContent, out string showItem, out string frozencolumns, out string column,out string pcode,)
        //    {

        //        stageName = "";
        //        pname = "";
        //        psid = "";
        //        sDateStr = "";
        //        eDateStr = "";
        //        showContent = "";
        //        showItem = "";
        //        frozencolumns = "";
        //        column = "";
        //        //DataSet ds;
        //        //DataTable dt = new DataTable();
        //        //ds = new BLL.Common().GetList("select project.sid as psid, project_name,project_code,stage_name,Convert(varchar(10),begin_date,120) begin_date,Convert(varchar(10),end_date,120) end_date,project_stage.is_system,project.v1,dbo.getUserNames_fu(project.v1) as v1Users,project.v2,dbo.getUserNames_fu(project.v2) as v2Users from project_stage left outer join project on project_stage.p_sid=project.sid where project_stage.sid='" + pssid + "'");

        //        DataTable dt = new DataTable();
        //            DataSet ds = new BLL.Common().GetList("select project.sid as psid, project_name,project_code,stage_name,begin_date,end_date,project_stage.is_system from project_stage left outer join project on project_stage.p_sid=project.sid where project_stage.sid='" + pssid + "'");
        //            if (ds.Tables.Count > 0)
        //            {
        //                dt = ds.Tables[0];
        //            }
        //            if (dt.Rows.Count > 0)
        //            {
        //                isConstruction = dt.Rows[0]["is_system"].ToString().Trim();
        //                pname = dt.Rows[0]["project_name"].ToString().Trim();
        //                pcode = dt.Rows[0]["project_code"].ToString().Trim();
        //                stageName = dt.Rows[0]["stage_name"].ToString().Trim();

        //                pModel = new BLL.project().GetModel(int.Parse(dt.Rows[0]["psid"].ToString().Trim()));

        //                string str0="", str1 = "", str2 = "", str3 = "", str4 = "";
        //                DataTable impDT = new DataTable();
        //                DataSet impDS = new BLL.Common().GetList("select * from project_implement where s_sid='" + pssid + "' order by sequence asc");

        //                if (impDS.Tables.Count > 0)
        //                {
        //                    impDT = impDS.Tables[0];

        //                    for (int i = 0; i < impDT.Rows.Count; i++)
        //                    {

        //                        str0 += "<th >" + new BLL.Common().GetList("select dbo.get_SNs_zxf('" + impDT.Rows[i]["v1"].ToString().Trim() + "')").Tables[0].Rows[0][0].ToString() + "</th>";
        //                        if (isConstruction == "1")
        //                        {
        //                            str1 += "<th  colspan='1'>" + impDT.Rows[i]["implement_name"].ToString().Trim() + "</th>";
        //                        }
        //                        else
        //                        {
        //                            str1 += "<th  colspan='1' rowspan='2' >" + impDT.Rows[i]["implement_name"].ToString().Trim() + "</th>";
        //                        }
        //                        //str1 += "{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:2},";
        //                        //str1 += "<th  colspan='1' rowspan='2' ></th>";
        //                        //str2 += "<th data-options=\"field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:100, halign:'center', align:'center'\" >" + new BLL.Common().GetList("select dbo.getUserAbbr_fu('"+impDT.Rows[i]["implementers_sid"].ToString().Trim()+"')").Tables[0].Rows[0][0] + "</th>";
        //                        str2 += "<th data-options=\"field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:100, halign:'center', align:'center'\" >" + new BLL.Common().GetList("select dbo.getUserName_fu('" + impDT.Rows[i]["implementers_sid"].ToString().Trim() + "')").Tables[0].Rows[0][0] + "</th>";
        //                        //str2 += "<th data-options=\"field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:100, halign:'center', align:'center'\" >" + impDT.Rows[i]["implementers"].ToString().Trim() + "</th>";
        //                        //str2 += "{field:'imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',title:'" + impDT.Rows[i]["implementers"].ToString().Trim() + "',width:100, halign:'center', align:'center'},";
        //                    }
        //                }
        //                else
        //                {
        //                    str0 += "<th ></th>";
        //                    if (isConstruction == "1")
        //                    {
        //                        str1 += "<th colspan='1'></th>";
        //                    }
        //                    else
        //                    {
        //                        str1 += "<th colspan='1' rowspan='2'></th>";
        //                    }
        //                    str2 += "<th data-options=\"field:''\"></th>";
        //                }
        //                string monthstr = "";
        //                string cols="1";
        //                if (dt.Rows[0]["begin_date"].ToString().Trim() != "" && dt.Rows[0]["end_date"].ToString().Trim() != "" && dt.Rows[0]["begin_date"] != null && dt.Rows[0]["end_date"] != null)
        //                {
        //                    DateTime sDate = DateTime.Parse(dt.Rows[0]["begin_date"].ToString().Trim());
        //                    DateTime eDate = DateTime.Parse(dt.Rows[0]["end_date"].ToString().Trim());
        //                    TimeSpan ts = eDate.AddDays(1).Subtract(sDate);

        //                    if (sDate.Month == eDate.Month)
        //                    {
        //                        monthstr = sDate.Month.ToString() + "月";
        //                    }
        //                    else
        //                    {
        //                        monthstr = sDate.Month.ToString() + "-" + eDate.Month.ToString() + "月";
        //                    }
        //                    cols = ts.Days.ToString();
        //                    //string widthstr = (int.Parse(cols) * 30).ToString();
        //                    for (int i = 0; i < ts.Days; i++)
        //                    {
        //                        str3 += "<th colspan='1' >" + sDate.AddDays(i).Day.ToString() + "</th>";
        //                        //str3 += "{title:'" + sDate.AddDays(i).Day.ToString() + "'},";
        //                        string w = "";
        //                        switch (sDate.AddDays(i).DayOfWeek)
        //                        {
        //                            case DayOfWeek.Sunday:
        //                                w = "日";
        //                                break;
        //                            case DayOfWeek.Monday:
        //                                w = "一";
        //                                break;
        //                            case DayOfWeek.Tuesday:
        //                                w = "二";
        //                                break;
        //                            case DayOfWeek.Wednesday:
        //                                w = "三";
        //                                break;
        //                            case DayOfWeek.Thursday:
        //                                w = "四";
        //                                break;
        //                            case DayOfWeek.Friday:
        //                                w = "五";
        //                                break;
        //                            case DayOfWeek.Saturday:
        //                                w = "六";
        //                                break;
        //                        }
        //                        //str4 += "<th data-options=\"field:'" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){if(value==1){return 'background-color:yellow;'}else{return ''};},formatter: function(value,row,index){return '';}\" style='white-space:pre-wrap; word-wrap:break-word;'>" + w + "</th>";
        //                        str4 += "<th data-options=\"field:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){var font='';if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "'].length>3){font='font-size:8px;';}if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==1){return 'background-color:yellow;'+font}else if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==2){return 'background-color:green;'+font}else{return ''}}\" style='white-space:pre-wrap; word-wrap:break-word;'>" + w + "</th>";
        //                    }
        //                }
        //                else
        //                {
        //                    monthstr = "";
        //                    str3 = "<th data-options=\"title: '',rowspan:1\"}/>";

        //                    str4 = "<th data-options=\"title:'',field:'w',width:300\"}/>";
        //                }
        //                int work_width = 200;
        //                int showCount = 15;
        //                if (int.Parse(cols) * 30 > 200)
        //                {
        //                    work_width = int.Parse(cols) * 30;
        //                    if (work_width > 200)
        //                    {
        //                        showCount = showCount + ((work_width - 200) * 3 / 30);
        //                    }
        //                }


        //        string user = "";
        //        DataTable userdt = new BLL.Common().GetList("select UserName,Name from baseuser where Permissions=1 order by name ").Tables[0];
        //        DataRow newdr = userdt.NewRow();
        //        newdr["UserName"] = "";
        //        newdr["Name"] = "请选择";
        //        userdt.Rows.InsertAt(newdr, 0);
        //        user = DBUtility.JsonHelper.DataTable2Json_Combo(userdt).Replace('\"', '\'');

        //        if (ds.Tables.Count > 0)
        //        {
        //            dt = ds.Tables[0];
        //        }
        //        if (dt.Rows.Count > 0)
        //        {
        //            isConstruction = dt.Rows[0]["is_system"].ToString().Trim();
        //            stageName = dt.Rows[0]["stage_name"].ToString().Trim();
        //            pname = dt.Rows[0]["project_name"].ToString().Trim();
        //            psid = dt.Rows[0]["psid"].ToString().Trim();

        //            //动态添加实施列
        //            //主管审核人
        //            string dnyV1 = "";
        //            dnyV1 = ",{title: '',field:'v1',width:80, halign:'center', align:'center',formatter:function(value,row){return row.header;},editor:{type:'combobox', options: { data: " + user + ", valueField: 'UserName', editable: false, textField: 'Name',required: true, missingMessage: '必填'}}}";

        //            //总审人
        //            string dnyV2 = "";
        //            dnyV2 = ",{title: '',field:'v2',width:80, halign:'center', align:'center',formatter:function(value,row){return row.finaler;},editor:{type:'combobox', options: { data: " + user + ", valueField: 'UserName', editable: false, textField: 'Name',required: true, missingMessage: '必填'}}}";

        //            //工作种类及人员
        //            string dynImp = "", dynImpUser = "", dynDay = "", dynWeek = "";
        //            DataTable impDT = new DataTable();
        //            DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + pssid + "' order by sequence");
        //            if (impDS.Tables.Count > 0)
        //            {
        //                impDT = impDS.Tables[0];

        //                for (int i = 0; i < impDT.Rows.Count; i++)
        //                {
        //                    string[] dynImpUserArr = impDT.Rows[i]["impUsers"].ToString().Trim().Split(',');
        //                    string[] dynImpUidArr = impDT.Rows[i]["implementers_sid"].ToString().Trim().Split(',');
        //                    dynImp += ",{title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',rowspan:2,colspan:" + (dynImpUserArr.Length > 0 ? dynImpUserArr.Length : 1) + "}";

        //                    dynImpUser += ",{title: '" + impDT.Rows[i]["impUsers"].ToString().Trim() + "',field:'imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "',width:80, halign:'center', align:'center',formatter:function(value,row){return row.Abbr_imp_" + impDT.Rows[i]["sid"].ToString().Trim() + ";},editor:{type:'combobox', options: { data: " + user + ", valueField: 'UserName', editable: false, textField: 'Name'}}}";
        //                }
        //            }
        //            else
        //            {
        //                dynImp = ",{title:'',rowspan:2}";
        //                dynImpUser = ",{title: '',field:'imp_',width:80, halign:'center', align:'center'}";
        //            }

        //            //工作日历
        //            string cols = "1";
        //            string monthstr = "";
        //            string tmp = dt.Rows[0]["begin_date"].ToString().Trim();
        //            if (dt.Rows[0]["begin_date"].ToString().Trim() != "" && dt.Rows[0]["end_date"].ToString().Trim() != "" && dt.Rows[0]["begin_date"] != null && dt.Rows[0]["end_date"] != null)
        //            {
        //                sDateStr = dt.Rows[0]["begin_date"].ToString().Trim();
        //                eDateStr = dt.Rows[0]["end_date"].ToString().Trim();
        //                DateTime sDate = DateTime.Parse(dt.Rows[0]["begin_date"].ToString().Trim());
        //                DateTime eDate = DateTime.Parse(dt.Rows[0]["end_date"].ToString().Trim());
        //                TimeSpan ts = eDate.AddDays(1).Subtract(sDate);

        //                if (sDate.Month == eDate.Month)
        //                {
        //                    monthstr = sDate.Month.ToString() + "月";
        //                }
        //                else
        //                {
        //                    monthstr = sDate.Month.ToString() + "-" + eDate.Month.ToString() + "月";
        //                }
        //                cols = ts.Days.ToString();
        //                for (int i = 0; i < ts.Days; i++)
        //                {
        //                    dynDay += ",{title: '" + sDate.AddDays(i).Day.ToString() + "'}";
        //                    string w = "";
        //                    switch (sDate.AddDays(i).DayOfWeek)
        //                    {
        //                        case DayOfWeek.Sunday:
        //                            w = "日";
        //                            break;
        //                        case DayOfWeek.Monday:
        //                            w = "一";
        //                            break;
        //                        case DayOfWeek.Tuesday:
        //                            w = "二";
        //                            break;
        //                        case DayOfWeek.Wednesday:
        //                            w = "三";
        //                            break;
        //                        case DayOfWeek.Thursday:
        //                            w = "四";
        //                            break;
        //                        case DayOfWeek.Friday:
        //                            w = "五";
        //                            break;
        //                        case DayOfWeek.Saturday:
        //                            w = "六";
        //                            break;
        //                    }
        //                    dynWeek += ",{title:'" + w + "',field:'flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "',width:30,halign:'center',align:'center',styler: function(value,row,index){if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==null)return '';var font='';if(row['flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "'].length>3)font='font-size:8px;';if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==1){return 'background-color:yellow;'+font}else if(row['" + sDate.AddDays(i).ToString("yyyy-MM-dd") + "']==2){return 'background-color:green;'+font}else{return ''}},editor:'text'}";
        //                }
        //            }
        //            else
        //            {
        //                monthstr = "";
        //                dynDay = ",{title: '',rowspan:1}";
        //                dynWeek = ",{title: '',field:'w'}";
        //            }

        //            int work_width = 200;
        //            int showCount = 15;
        //            if (int.Parse(cols) * 30 > 200)
        //            {
        //                work_width = int.Parse(cols) * 30;
        //                if (work_width > 200)
        //                {
        //                    showCount = showCount + ((work_width - 200) * 3 / 30);
        //                }
        //            }
        //            //string calendarStr = "";
        //            string showGroup = "true";
        //            string showWorkTitle = "";
        //            string widthContent = "200";
        //            string widthItem = "200";
        //            switch (isConstruction)
        //            {
        //                case "1":
        //                    showContent = "空间";
        //                    showItem = "图纸及索引号";
        //                    string flow = "";
        //                    DataTable tmpDT = new DataTable();
        //                    DataSet tmpDS = new BLL.project_work_flow().GetList(" s_sid='" + pssid + "'");
        //                    if (tmpDS.Tables.Count > 0)
        //                    {
        //                        tmpDT = tmpDS.Tables[0];
        //                    }
        //                    for (int i = 0; i < tmpDT.Rows.Count; i++)
        //                    {
        //                        flow += (i + 1).ToString() + "." + tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
        //                    }

        //                    string workTitle = monthstr + "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))";
        //                    showWorkTitle = "";
        //                    for (int i = 0; i < workTitle.Length; i++)
        //                    {
        //                        showWorkTitle += workTitle[i];
        //                        if ((i + 1) % showCount == 0)
        //                        {
        //                            showWorkTitle += "<br/>";
        //                        }
        //                    }
        //                    break;
        //                case "0":
        //                    showContent = "工作内容";
        //                    showItem = "细目";
        //                    showGroup = "false";
        //                    showWorkTitle = monthstr + "(黄色色块代表完成这项工作所需要的完成时间,<br/>计划表中实际完成时间将用绿色色块做标记)";
        //                    break;
        //                case "2":

        //                    showContent = "货物类别";
        //                    showItem = "工作细目";
        //                    showWorkTitle = monthstr;
        //                    break;

        //                case "3":
        //                    showContent = "商品类别";
        //                    showItem = "细目";
        //                    showWorkTitle = "智创产品逐个跟踪+" + pname;
        //                    break;

        //                case "4":
        //                    showContent = "加工类别";
        //                    showItem = "工作细目";
        //                    showWorkTitle = monthstr + "(进程计划)";
        //                    widthContent = "80";
        //                    break;

        //                default:
        //                    break;
        //            }

        //            if (isConstruction != "3")
        //            {
        //                frozencolumns += "[[";
        //                frozencolumns += "{ title: '小组', field: 'group_name', width: 60, rowspan:3, halign: 'center', align: 'center',hidden:" + showGroup + ",editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '" + showContent + "', field: 'contentName', width: " + widthContent + ", rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';},editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '" + showItem + "', field: 'itemName', width: " + widthItem + ",rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';},editor:'text'}";
        //                frozencolumns += "]]";
        //                column += "[[";
        //                column += "{ title: '月'}";
        //                column += ",{ title: '" + showWorkTitle + "',colspan:" + cols + "}";
        //                column += dynImp;
        //                //column += ",{ title: '组长审核', rowspan:2,colspan:"+(v1UidArr.Length>0?v1UidArr.Length:1)+", halign: 'center', align: 'center'}";
        //                column += ",{ title: '组长审核', rowspan:2,colspan:1, halign: 'center', align: 'center'}";
        //                column += ",{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                column += ",{ title: '解决的办法', field: 'solution', width: 60, rowspan:3, halign:'center', align:'center',editor:{type:'diseditText'}}";
        //                column += ",{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3, halign:'center', align:'center',editor:{type:'diseditText'}}";
        //                //column += ",{ title: '总审', rowspan:2,colspan:" + (v2UidArr.Length > 0 ? v2UidArr.Length : 1) + ", halign: 'center', align: 'center'}";
        //                column += ",{ title: '总审', rowspan:2,colspan:1, halign: 'center', align: 'center'}";
        //                column += ",{ title: '备注', field: 'remark', width: 60, rowspan:3,halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
        //                column += "],";
        //                column += "[";
        //                column += "{ title: '日'}";
        //                column += dynDay;
        //                column += "],[";
        //                column += "{ title: '星期', field: 'week',width:40,halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';},editor:{type:'diseditText'}}";
        //                column += dynWeek;
        //                column += dynImpUser;
        //                column += dnyV1;
        //                column += dnyV2;
        //                column += "]]";
        //            }
        //            else
        //            {
        //                frozencolumns += "[[";
        //                frozencolumns += "{ title: '编号', field: 'number', width: 60, rowspan:4, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '细目',  colspan:3, halign: 'center', align: 'center'}";
        //                frozencolumns += "]";
        //                frozencolumns += ",[";
        //                frozencolumns += "{ title: '项目产品名称', field: 'productName', width: 100,  rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '图片', field: 'productPic', width: 100, rowspan:3,halign: 'center', align: 'center',"
        //                + "formatter: function (value, rowData, rowIndex) {"
        //                            + "if (value != '') {"
        //                               + " return  \\\"<a path='../ProductPic/\\\" + value + \\\"' class='preview'><img alt='' height='45px' src='/ProductPic/\\\" + value + \\\"'></a>\\\";"
        //                            + "}"
        //                        + "}}";
        //                frozencolumns += ",{ title: '规格', field: 'Specifications', width: 60, rowspan:3,halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '漆面颜色', field: 'paintColor', width: 100, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '应用空间', field: 'useSpace', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '应用数量', field: 'spaceCount', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '安装位置', field: 'install', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '应用部位', field: 'usePart', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '单位', field: 'unit', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '数量', field: 'amount', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '油漆色板编号', field: 'paintPaletteNumber', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '加工类别', field: 'EndProduct', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '备注', field: 'remark', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += ",{ title: '工作明细', field: 'contentName', width: 60, rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                frozencolumns += "]]";
        //                column += "[[";
        //                column += "{ title: '月'}";
        //                column += ",{ title: '" + showWorkTitle + "',colspan:" + cols + "}";
        //                column += dynImp;
        //                //column += ",{ title: '组长审核', rowspan:2,colspan:"+(v1UidArr.Length>0?v1UidArr.Length:1)+", halign: 'center', align: 'center'}";
        //                column += ",{ title: '组长审核', rowspan:2,colspan:1, halign: 'center', align: 'center'}";
        //                column += ",{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, halign: 'center', align: 'center',editor:{type:'diseditText'}}";
        //                column += ",{ title: '解决的办法', field: 'solution', width: 60, rowspan:3, halign:'center', align:'center',editor:{type:'diseditText'}}";
        //                column += ",{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3, halign:'center', align:'center',editor:{type:'diseditText'}}";
        //                //column += ",{ title: '总审', rowspan:2,colspan:" + (v2UidArr.Length > 0 ? v2UidArr.Length : 1) + ", halign: 'center', align: 'center'}";
        //                column += ",{ title: '总审', rowspan:2,colspan:1, halign: 'center', align: 'center'}";
        //                column += ",{ title: '备注', field: 'remark', width: 60, rowspan:3,halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
        //                column += "],";
        //                column += "[";
        //                column += "{ title: '日'}";
        //                column += dynDay;
        //                column += "],[";
        //                column += "{ title: '星期', field: 'week',width:40,halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';},editor:{type:'diseditText'}}";
        //                column += dynWeek;
        //                column += dynImpUser;
        //                column += dnyV1;
        //                column += dnyV2;
        //                column += "]]";
        //            }
        //        }
        //    }
        //}

    }
}