<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="MyProjectPlan.aspx.cs"
    Inherits="Maticsoft.Web.Project.MyProjectPlan" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../js/datagrid-detailview.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

        $(function () {
            $('#tt').datagrid({
                url: '../Ashx/MyProjectPlan.ashx', //请求数据的页面
                queryParams: { "action": "list","type":"<%=type %>" },
                loadMsg: '正在努力加载中...',
                idField: 'detail_id',
                toolbar: '#tab_toolbar',
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                nowrap: false,
                fitColumns: true,
                pagination: true,
                //rownumbers: true,
                singleSelect: true,
                remoteSort: true,
                columns: [[
                    { title: '', field: 'pos', width: 20, sortable: true, align: 'center' },
                    { title: '项目编号', field: 'project_code', width: 50, sortable: true, align: 'center' },
                    { title: '项目名称', field: 'project_name', width: 50, sortable: true, align: 'center' },
                    { title: '阶段', field: 'stage_name', width: 50, sortable: true, align: 'center' },
                    { title: '小组', field: 'group_name', width: 50, sortable: true, align: 'center' },
                    { title: '工作内容', field: 'jobduties_name', width: 100, sortable: true, align: 'center' },
                    { title: '细目', field: 'detail_name', width: 100, sortable: true, align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a href="#" style="text-decoration:none;" onclick="detail(' + rowIndex + ');">' + value + '</a>';
                        }
                    },
                    { title: '状态', field: 'psiStatus', width: 50, sortable: true, align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            switch (value) {
                                case "null": return "未提交";
                                case "-1~0": return "已提交";
                                case "0~0": return "未完成";
                                case "1~0": return "已完成";
                                default:
                                    switch (value.split("~")[1]) {
                                        case "1": return "<img src='../Images/point/bullet_green.png'/>";
                                        case "2": return "<img src='../Images/point/bullet_yellow.png'/>";
                                        case "3": return "<img src='../Images/point/bullet_orange.png'/>";
                                        case "4": return "<img src='../Images/point/bullet_red.png'/>";
                                        case "5": return "<img src='../Images/point/bullet_error.png'/>";
                                        default: break;
                                    }
                            }
                        },
                        styler: function (value, rowData, index) {
                            switch (value) {
                                case "": return "";
                                case "-1~0": return "color:blue;";
                                case "0~0": return "color:red;";
                                case "1~0": return "color:green;";
                                default:
                                    switch (value.split("~")[1]) {
                                        case "1": return "";
                                        case "2": return "";
                                        case "3": return "";
                                        case "4": return "";
                                        case "5": return "";
                                        default: break;
                                    }
                            }
                        }
                    },
                    { title: '工作种类(负责人)', field: 'names', width: 100, sortable: true, align: 'center' },
                    { title: '开始日期', field: 'begin_date', width: 60, sortable: true, align: 'center' },
                    { title: '结束日期', field: 'end_date', width: 60, sortable: true, align: 'center' }
				]],
                onLoadSuccess: function (data) {
                    if (data.rows.length > 0) { mergeCellsByField('tt', 'project_code,project_name,stage_name,jobduties_name'); }
                }
            });
        });       
          
        //快速搜索
        function qsearch(v) {
            $('#tt' ).datagrid('options').queryParams = { "action": "list","key": v };
            $('#tt').datagrid('load');
        }

        function detail(index) {
            var row = $("#tt").datagrid("getRows")[index];
            parent.addTab_Ext('我的项目计划【提交】', "/Project/MyProjectPlan_IDE.aspx?si_sid=" + row.detail_id, "", false);
        }
    </script>

    <style type="text/css">
       a{color:blue}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <toolbar:ToolBar runat="server"/>
    
    <table id="tt"></table>

</asp:Content>