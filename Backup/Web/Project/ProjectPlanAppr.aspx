<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProjectPlanAppr.aspx.cs" Inherits="Maticsoft.Web.Project.ProjectPlanAppr" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="psr_IDE" TagName="PSR_IDE" Src="../Controls/Project/ProjectSubmitRecord.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../js/themes/default/datagrid1.css" rel="stylesheet" type="text/css" />
    <script src="../js/datagrid-groupview.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('#tt').datagrid({
                url: '../Ashx/ProjectAppr.ashx',
                queryParams: { "action": "list","type":"<%=type %>" },
                loadMsg: '正在努力加载中...',
                idField: 'detail_id',
                toolbar: "#tab_toolbar",
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                fitColumns: true,
                pagination: true,
                //rownumbers: true,
                singleSelect: true,
                remoteSort: true,
                frozenColumns: [[]],
                columns: [[
                    { title: '项目编号', field: 'project_code', width: 100, sortable: true, align: 'center',
                        styler: function (data) { return ""; }
                    },
                    { title: '项目名称', field: 'project_name', width: 100, sortable: true, align: 'center',
                        styler: function (data) { return ""; }
                    },
                    { title: '阶段', field: 'stage_name', width: 100, sortable: true, align: 'center',
                        styler: function (data) { return ""; }
                    },
                    { title: '小组', field: 'group_name', width: 100, sortable: true, align: 'center',
                        styler: function (data) { return ""; }
                    },
                    { title: '工作内容', field: 'jobduties_name', width: 100, sortable: true,
                        styler: function (data) { return ""; }
                    },
                    { title: '细目', field: 'detail_name', width: 100, sortable: true },
                    { title: '负责人', field: 'names', width: 100, sortable: true, align: 'center' },
                    { title: '开始日期', field: 'begin_date', width: 100, sortable: true, align: 'center' },
                    { title: '结束日期', field: 'end_date', width: 100, sortable: true, align: 'center' },
                    { title: '主管审批', field: 'review_results', width: 80, sortable: true, align: 'center',
                        formatter: function (value, row, index) {
                            switch (row.review_results) {
                                case "-1":
                                    switch (row.review_status) {
                                        case "-1": return "未提交";
                                        case "0": return row.type == "1" ? "待审批" : "未审批";
                                    }
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
                    { title: '总审', field: 'orderby', width: 80, sortable: true, align: 'center',
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
                    { title: '提交人', field: 'sumbit_user', width: 60, sortable: true, align: 'center' },
                    { title: '提交日期', field: 'sumbit_date', width: 100, sortable: true, align: 'center' },
                    { title: '最近审批人', field: 'recently_approver', width: 100, sortable: true, align: 'center' },
                    { title: '最近审批日期', field: 'recently_date', width: 100, sortable: true, align: 'center' },
                    { title: '记录', field: 'view', width: 30, align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return "<a href='#' onclick=\"submit_record('" + rowData.detail_id + "');\"><img src='../images/CRF.jpg'/></a>";
                        }
                    }
				]],
                    onLoadSuccess: function (data) {
                        if (data.rows.length > 0) { mergeCellsByField('tt', 'project_code,project_name,stage_name,group_name,jobduties_name'); }
                    }
                //,
                //groupField: 'project_name',
                //view: groupview,
                //groupFormatter: function (value, rows) {
                //    return value + ' - ' + rows.length + ' Item(s)';
                //},
                //rowStyler: function (index, row) { if (row.review_status == '0') { return ''; } },
                //onLoadSuccess: function (data) {
                //if (data.rows.length > 0) { mergeCellsByField('tt', 'project_code,project_name,stage_name,group_name,jobduties_name'); }
                //}
            });
        });

        //快速搜索
        function qsearch(v) {
            $('#tt').datagrid('options').queryParams = { "action": "list", "key": v };
            $('#tt').datagrid('load');
        }

        function sh() {
            var row = $('#tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '系统提示', msg: "请先选择您要“审批”的记录。" });
                return;
            }
            if (row.review_status == "-1") {
                    $.messager.show({ title: '系统提示', msg: "您选择的记录未提交。" });
                    return;
                }
                if (row.type == "1") {
                    if (row.v1 != "<%=bu.UserName %>") {
                        $.messager.show({ title: '系统提示', msg: "目前是组长审核，你没有权限进行审核。" });
                        return;
                    }
                    if (row.review_results != "-1") {
                        $.messager.show({ title: '系统提示', msg: "已审批记录不能再审批，您可以弃审。" });
                        return;
                    }
                }
                if (row.type == "2") {
                    if (row.v2 != "<%=bu.UserName %>") {
                        $.messager.show({ title: '系统提示', msg: "目前是总审，你没有权限进行审核。" });
                        return;
                    }        
                if (row.review_results == "-1") {
                    $.messager.show({ title: '系统提示', msg: "[主管审核]“未审批”的记录不能[总审]。" });
                    return;
                }
                if (row.review_results == "0") {
                    $.messager.show({ title: '系统提示', msg: "[主管审核]“未完成”的记录不能[总审]。" });
                    return;
                }
                if (row.review_status != "0") {
                    $.messager.show({ title: '系统提示', msg: "已审批记录不能再审批，您可以弃审。" });
                    return;
                }
            }
            url = "/Project/ProjectPlanAppr_IDE.aspx?type=" + row.type + "&sid=" + row.detail_id;
            var showname = row.project_name;
            showname = showname.length > 3 ? showname.substring(0, 3) + '...' : showname;
            parent.addTab_Ext('项目审批【' + showname + '】', url, "", true);
        }

        function qs() {
            var row = $('#tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '系统提示', msg: "请先选择您要“审批”的记录。" });
                return;
            }
            if (row.review_status == "-1") {
                $.messager.show({ title: '系统提示', msg: "您选择的记录未提交。" });
                return;
            }
            if (row.type == "1") {               
                if (row.review_results == "-1") {
                    $.messager.show({ title: '系统提示', msg: "待审批记录不能弃审，您可以先审批。" });
                    return;
                }
            }
            if (row.type == "2") {
                if (row.review_results == "-1") {
                    $.messager.show({ title: '系统提示', msg: "[主管审核]“未审批”的记录不能[总审]。" });
                    return;
                }
                if (row.review_results == "0") {
                    $.messager.show({ title: '系统提示', msg: "[主管审核]“未完成”的记录不能[总审]。" });
                    return;
                }
                if (row.review_status == "0") {
                    $.messager.show({ title: '系统提示', msg: "待审批记录不能弃审，您可以先审批。" });
                    return;
                }
            }
            url = "/Project/ProjectPlanAppr_IDE.aspx?type=" + row.type + "&sid=" + row.detail_id;
            var showname = row.project_name;
            if (showname.length > 3) {
                showname = showname.substring(0, 3) + '...';
            }
            parent.addTab_Ext('项目审批【' + showname + '】', url, "", true);
        }

        function submit_record(psi_sid) {
            if (art.dialog.get('record_dialog') != null) {
                art.dialog.get('record_dialog').close();
            }
            record_openDialog(psi_sid);
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <toolbar:ToolBar runat="server"/>

    <table id="tt"></table>
    
    <div id="record_edit" style="display:none;">
        <psr_IDE:PSR_IDE ID="record_ide1" runat="server"/>
    </div>    
</asp:Content>