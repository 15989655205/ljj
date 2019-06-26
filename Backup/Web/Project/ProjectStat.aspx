<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProjectStat.aspx.cs" Inherits="Maticsoft.Web.Project.ProjectStat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/js/print.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        getUsers();
        getStage();
        $('#tt').datagrid({
            url: '../Ashx/ProjectView.ashx',
            queryParams: { "action": "projectStat","projectStatus": $('#projectStatus').val() },
            loadMsg: '正在努力加载中...',
            idField: 'id',
            toolbar: "#toolbar",
            pageSize: 20,
            pageList: [10,15, 20, 30, 40, 50, 100],
            fit: true,
            showFooter: true,
            //fitColumns: true,
            pagination: true,
            rownumbers: true,
            singleSelect: true,
            remoteSort: true,
            frozenColumns: [[
            { title: '项目编号', field: 'project_code', width: 80, sortable: true, align: 'center', halign: 'center',
                styler: function (data) { return ""; }
            },
                    { title: '项目名称', field: 'project_name', width: 100, sortable: true, align: 'center', halign: 'center',
                        styler: function (data) { return ""; },
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '阶段', field: 'stage_name', width: 100, sortable: true, align: 'center', halign: 'center',
                        styler: function (data) { return ""; }
                    },
                    { title: '小组', field: 'group_name', width: 80, sortable: true, align: 'center', halign: 'center'
//                    ,
//                        styler: function (data) { return ""; },
//                        formatter: function (value, rowData, rowIndex) {
//                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
//                        }
                    },
                    { title: '工作内容', field: 'jobduties_name', width: 200, sortable: true, halign: 'center',
                        styler: function (data) { return ""; },
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '细目', field: 'detail_name', width: 200, sortable: true, halign: 'center' }
            ]],
            columns: [[

                    { title: '开始日期', field: 'begin_date', width: 80, sortable: true, align: 'center', halign: 'center',
                        formatter: function (value, row, index) {
                            if (value != "1900-01-01") {
                                return value;
                            }
                            else {
                                return "";
                            }
                        }
                    },
                    { title: '结束日期', field: 'end_date', width: 80, sortable: true, align: 'center', halign: 'center',
                        formatter: function (value, row, index) {
                            if (value != "1900-01-01") {
                                return value;
                            }
                            else {
                                return "";
                            }
                        }
                    },
                    { title: '负责人', field: 'workuser', width: 60, sortable: true, align: 'center', halign: 'center' },
                    { title: '提交情况', field: 'sumbit', width: 60, sortable: true, align: 'center', halign: 'center',
                        styler: function (value, row, index) {
                            switch (value) {
                                case "未提交": return "color:gray;";
                                    //case "已提交": return "color:green;";
                                default: return "";
                            }
                        }
                    },
                    { title: '提交时间', field: 'sumbit_date', width: 120, sortable: true, align: 'center', halign: 'center' },
                    { title: '是否超期', field: 'isExt', width: 60, sortable: true, align: 'center', halign: 'center',
                        formatter: function (value, row, index) {
                            switch (value) {
                                case "0": return "否";
                                case "1": return "是";
                                default: return "";
                            }
                        },
                        styler: function (value, row, index) {
                            switch (value) {
                                case "1": return "color:red;";
                                default: return "";
                            }
                        }
                    },
                    { title: '组长', field: 'groupHeader', width: 60, sortable: true, align: 'center', halign: 'center' },
                    { title: '组长审核时间', field: 'review_date', width: 120, sortable: true, align: 'center', halign: 'center' },
                    { title: '组长审核结果', field: 'review_results', width: 60, sortable: true, align: 'center', halign: 'center',
                        formatter: function (value, row, index) {
                            switch (row.review_results) {
                                //                                case "-1":    
                                //                                    switch (row.review_status) {    
                                //                                        case "-1": return "未提交";    
                                //                                        case "0": return row.type == "1" ? "待审批" : "未审批";    
                                //                                    }    
                                case "0": return "未完成";
                                case "1": return "已完成";
                                default: return "";
                            }
                        },
                        styler: function (value, row, index) {
                            switch (row.review_results) {
                                case "-1":
                                    switch (row.review_status) {
                                        case "-1": return "";
                                        case "0": return row.type == "1" ? "color:blue;" : "color:#72ACE3;";
                                    }
                                case "0": return "color:red;";
                                case "1": return "color:green;";
                                default: return "";
                            }
                        }
                    },
                    { title: '未完成的原因', field: 'reason', width: 120, sortable: true, align: 'left', halign: 'center' },
                    { title: '解决的办法', field: 'solution', width: 120, sortable: true, align: 'left', halign: 'center' },
                    { title: '解决的结果', field: 'result', width: 120, sortable: true, align: 'left', halign: 'center' },
                    { title: '总审时间', field: 'review_date1', width: 120, sortable: true, align: 'center', halign: 'center' },
                    { title: '总审结果', field: 'review_status', width: 60, sortable: true, align: 'center', halign: 'center',
                        formatter: function (value, row, index) {
                            //switch (row.type) {
                            //    case "1": return "";
                            //    case "2":
                            switch (row.review_results) {
                                case "-1": case "0": return "";
                                case "1":
                                    switch (row.review_status) {
                                        case "0": return "待审批";
                                        case "1": return "<img src='../Images/point/bullet_green.png'/>";
                                        case "2": return "<img src='../Images/point/bullet_yellow.png'/>";
                                        case "3": return "<img src='../Images/point/bullet_orange.png'/>";
                                        case "4": return "<img src='../Images/point/bullet_red.png'/>";
                                        case "5": return "<img src='../Images/point/bullet_error.png'/>";
                                        default: return "";
                                    }
                                default: return "";
                            }
                            //     default: break;
                            // }
                        },
                        styler: function (value, row, index) {
                            switch (row.type) {
                                case "1": return "";
                                case "2":
                                    switch (row.review_results) {
                                        case "-1": case "0": return "";
                                        case "1":
                                            switch (row.review_status) {
                                                case "0": return "color:blue;";
                                                case "1": return "";
                                                case "2": return "";
                                                case "3": return "";
                                                case "4": return "";
                                                case "5": return "";
                                                default: return "";
                                            }
                                        default: return "";
                                    }
                                default: break;
                            }
                        }
                    },
                    { title: '备注', field: 'remark', width: 60, sortable: true, align: 'center', halign: 'center' }
				]]
                ,
            onLoadSuccess: function (data) {
                if (data.rows.length > 0) { mergeCellsByField('tt', 'project_code,project_name,stage_name,group_name,jobduties_name,detail_name'); }
            }
        });
    });


    function getUsers() {
        $('#workuser').combobox({
            url: '../Ashx/Common.ashx?type=get_users',
            valueField: 'UserName',
            textField: 'Name',
            multiple: true,
            editable: false
        });
    }

    function getStage() {
        $('#stage').combobox({
            url: '../Ashx/Common.ashx?type=get_stage',
            valueField: 'sid',
            textField: 'stage_name',
            multiple: true,
            editable: false
        });
    }

    function search() {
        $('#tt').datagrid('options').queryParams = { "action": "projectStat", "projectCode": $('#projectCode').val(), "projectName": $('#projectName').val(), "stage": $('#stage').combobox('getValues').join(','), "workuser": $('#workuser').combobox('getValues').join(','), "isExtended": $('#isExtended').val(), "startDate": $('#startDate').val(), "endDate": $('#endDate').val(), "isSumbit": $('#isSumbit').val(), "result": $('#result').val(), "status": $('#status').val(), "projectStatus": $('#projectStatus').val() };
        $('#tt').datagrid('load');
    }

    function print(flag) {
        window.open("PrintProjectStat.aspx?projectCode=" + $('#projectCode').val() + "&projectName=" + $('#projectName').val() + "&stage=" + $('#stage').combobox('getValues').join(',') + "&workuser=" + $('#workuser').combobox('getValues').join(',') + "&isExtended=" + $('#isExtended').val() + "&startDate=" + $('#startDate').val() + "&endDate=" + $('#endDate').val() + "&isSumbit=" + $('#isSumbit').val() + "&result=" + $('#result').val() + "&status=" + $('#status').val() + "&projectStatus=" + $('#projectStatus').val() + "&statgeName=" + $('#stage').combobox('getText') + "&workuserName=" + $('#workuser').combobox('getText') + "&flag=" + flag);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="tt"></table>

<div id="toolbar">
<table>
<tr>
<td style="text-align:right;">项目编号：</td>
<td><input id="projectCode" name="projectCode" /></td>
<td style="text-align:right;">项目名称：</td>
<td><input id="projectName" name="projectName" /></td>
<td style="text-align:right;">阶段：</td>
<td><input id="stage" name="stage" /></td>
<td style="text-align:right;">工作人员：</td>
<td><input id="workuser" name="workuser" /></td>
<td style="text-align:right;">超期否：</td>
<td><select id="isExtended" name="isExtended"><option value="">全部</option><option value="0">否</option><option value="1">是</option></select></td>
<td rowspan="2" align="center"><input type="button" id="Button1" name="" value="查询" onclick="search();"/>&nbsp;&nbsp;&nbsp;&nbsp;<a id='btn' href='#' class='easyui-linkbutton' data-options='iconCls:"icon-print"' onclick="print(0);">打印</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id='A1' href='#' class='easyui-linkbutton' data-options='iconCls:"icon-print"' onclick="print(1);">打印统计</a></td>
</tr>
<tr>
<td style="text-align:right;">时间段：</td>
<td colspan="1"><input id="startDate" name="startDate" style="width:80px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"/>-<input id="endDate" name="endDate" style="width:80px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"/></td>
<td style="text-align:right;">提交情况：</td>
<td><select id="isSumbit" name="isSumbit"><option value="">全部</option><option value="1">已提交</option><option value="0">未提交</option></select></td>
<td style="text-align:right;">组长审核结果：</td>
<td><select id="result" name="result"><option value="">全部</option><option value="1">已完成</option><option value="0">未完成</option></select></td>
<td style="text-align:right;">总审结果：</td>
<td><select id="status" name="status"><option value="">全部</option><option value="1">优</option><option value="2">良</option><option value="3">差</option><option value="5">不及格</option></select></td>
<td style="text-align:right;">项目情况：</td>
<td rowspan="1"><select id="projectStatus" name="projectStatus"><option value="">全部</option><option value="0">未开始</option><option value="1" selected="selected">已开始</option><option value="2">进行中</option><option value="3">已过结束时间</option></select></td>
</tr>
</table>



</div>
</asp:Content>
