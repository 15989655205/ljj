<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProjectPlanAppr.aspx.cs" Inherits="Maticsoft.Web.Project111.ProjectPlanAppr" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="psr_IDE" TagName="PSR_IDE" Src="../Controls/Project/ProjectSubmitRecord.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../js/themes/default/datagrid1.css" rel="stylesheet" type="text/css" />
    <script src="../js/datagrid-groupview.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('#ipt_search').searchbox({ menu: "#search_menu", searcher: function (value, name) { qsearch(value, name); } });
            $('#tt').datagrid({
                url: '../Ashx/ProjectAppr.ashx', //请求数据的页面
                queryParams: { "action": "list" },
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
                frozenColumns: [[
                //{ title: '编号', field: 'detail_id', width: 50, sortable: true, halign: 'center', align: 'center', styler: function (data) { return ""; }  },
                //{ title: '工作种类', field: 'implement_name', width: 80, sortable: true, halign: 'center', align: 'center' },
                //{ title: '完成质量', field: 'review_status', width: 80, sortable: true, halign: 'center', align: 'center',
                //    formatter: function (value, rowData, rowIndex) {
                //        switch (value) {
                //            case "0": return "未审批"; break;
                //            case "1": return "<img width='16px' height='16px' src='../Images/point/bullet_green.png'/>"; break;
                //            case "2": return "<img width='16px' height='16px' src='../Images/point/bullet_yellow.png'/>"; break;
                //            case "3": return "<img width='16px' height='16px' src='../Images/point/bullet_orange.png'/>"; break;
                //            case "4": return "<img width='16px' height='16px' src='../Images/point/bullet_red.png'/>"; break;
                //            default: return "未提交"; break;
                //        }
                //    },
                //    styler: function (value, row, index) {
                //        switch (value) {
                //            case "0": return 'background-color:red;'; break;
                //            case "1": return ""; break;
                //            case "2": return ""; break;
                //            case "3": return ""; break;
                //            case "4": return ""; break;
                //            default: return 'background-color:lightgray;'; break;
                //        }
                //    }
                //},
                ]],
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
                    { title: '审批结果', field: 'orderby', width: 80, sortable: true, align: 'center',
                        formatter: function (value, row, index) {
                            switch (row.type) {
                                case "1":
                                    switch (row.review_status) {
                                        case "-1": return "未提交";2
                                        case "0": return "待审批";0
                                        case "1":
                                            switch (row.review_results) {
                                                case "0": return "未通过";1
                                                case "1": return "已通过";3
                                            }
                                        default: return "";
                                    }
                                case "2":
                                    switch (row.review_results) {
                                        case "-2": return "未提交";
                                        case "-1": return "待审批";
                                        case "0": return "未通过";
                                        case "1": return "已通过";
                                        default: return "";
                                    }
                                case "3":
                                    switch (row.review_results) {
                                        case "-2": return "未提交";
                                        case "-1": return "待审批";
                                        case "0": return "<img src='../Images/point/bullet_error.png'/>";
                                        case "1": return "<img src='../Images/point/bullet_green.png'/>";
                                        case "2": return "<img src='../Images/point/bullet_yellow.png'/>";
                                        case "3": return "<img src='../Images/point/bullet_orange.png'/>";
                                        case "4": return "<img src='../Images/point/bullet_red.png'/>";
                                        default: return "";
                                    }
                                default: break;
                            }
                        },
                        styler: function (value, row, index) {
                            //switch (value) {
                            //    case "0": return 'color:red;'; break;
                            //    case "1": return 'color:green;'; break;
                            //    default: return 'color:blue;'; break;
                            //}
                            switch (row.type) {
                                case "1":
                                    switch (row.review_status) {
                                        case "-1": return "";
                                        case "0": return "color:blue;";
                                        case "1":
                                            switch (value) {
                                                case "0": return "color:red;";
                                                case "1": return "color:green;";
                                            }
                                        default: return "";
                                    }
                                case "2":
                                    switch (value) {
                                        case "-2": return "";
                                        case "-1": return "color:blue;";
                                        case "0": return "color:red;";
                                        case "1": return "color:green;";
                                        default: return "";
                                    }
                                case "3":
                                    switch (value) {
                                        case "-2": return "";
                                        case "-1": return "color:blue;";
                                        case "0": return "";
                                        case "1": return "";
                                        case "2": return "";
                                        case "3": return "";
                                        case "4": return "";
                                        default: return "";
                                    }
                                default: return "";
                            }
                        }
                    },
                    { title: '提交人', field: 'sumbit_user', width: 60, sortable: true, align: 'center' },
                    { title: '提交日期', field: 'sumbit_date', width: 100, sortable: true, align: 'center'//,
                        //formatter: function (value, rowData, rowIndex) {
                        //    return value.Format("yyyy-MM-dd");
                        //},
                        //styler: function (value, row, index) {
                        //    if (row.review_status == '0') {
                        //        return 'background-color:red;';
                        //    }
                        //}
                    },
                    { title: '最近审批人', field: 'recently_approver', width: 100, sortable: true, align: 'center' },
                    { title: '最近审批日期', field: 'recently_date', width: 100, sortable: true, align: 'center'//,
                        //formatter: function (value, rowData, rowIndex) {
                        //return value.Format("yyyy-MM-dd");
                        //},
                        //styler: function (value, row, index) {
                        //if (row.review_status == '0') {
                        //return 'background-color:red;';
                        //}
                        //}
                    },
                    { title: '记录', field: 'view', width: 30, align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a href="#" onclick="submit_record(\'' + rowIndex + '\');"><img src="../images/CRF.jpg" /></a>';
                        }
                    }
				]]//,
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
            $('#tt').datagrid('options').queryParams = { "action": "downloadlist", "key": v };
            $('#tt').datagrid('load');
        }

        function sh() {
            var row = $('#tt').datagrid('getSelected');
            //alert(row.review_status);
            if (row.review_status == 0) {
                url = "/Project/ProjectPlanAppr_IDE.aspx?type=sh&review=" + row.type + "&sid=" + row.detail_id;
                var showname = row.project_name;
                if (showname.length > 3) {
                    showname = showname.substring(0, 3) + '...';
                }
                parent.addTab_Ext('项目审批【' + showname + '】', url, "", true);
            }
            else if (row.review_status == -1) {
                $.messager.show({ title: '提示', msg: "此项目内容没提交不能审批！" });
                return false;
            } else {

                $.messager.show({ title: '提示', msg: "此项目内容已审批过不能再审批,您可以弃审！" });
                return false;
            }
        }

        function qs() {
            var row = $('#tt').datagrid('getSelected');
            //alert(row.review_status);
            if (row.review_status == 0) {
                $.messager.show({ title: '提示', msg: "此项目内容还没审批过！" });
                return false;
            }
            else if (row.review_status == -1) {
                $.messager.show({ title: '提示', msg: "此项目内容没提交不能操作弃审！" });
                return false;
            }
            else {
                url = "/Project/ProjectPlanAppr_IDE.aspx?type=qs&review=" + row.type + "&sid=" + row.detail_id;
                var showname = row.project_name;
                if (showname.length > 3) {
                    showname = showname.substring(0, 3) + '...';
                }
                parent.addTab_Ext('项目审批【' + showname + '】', url, "", true);
            }
        }

        function submit_record(index) {
            if (art.dialog.get('record_dialog') != null) {
                art.dialog.get('record_dialog').close();
            }
            record_openDialog(index, "提交记录");
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tt"></table>
    <div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar runat="server" ></toolbar:ToolBar>
    </div>

    <div id="record_edit" style="display:none; height:0;">
        <psr_IDE:PSR_IDE ID="record_ide1" runat="server"></psr_IDE:PSR_IDE>
    </div>
</asp:Content>