<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="MyProjectPlan.aspx.cs"
    Inherits="Maticsoft.Web.Project111.MyProjectPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="../js/datagrid-detailview.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

        $(function () {
            $('#tt').datagrid({
                url: '../Ashx/MyProjectPlan.ashx', //请求数据的页面
                queryParams: { "action": "list" },
                loadMsg: '正在努力加载中...',
                idField: 'work_id',
                toolbar: '#tab_toolbar',
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                //fitColumns: true,
                pagination: true,
                rownumbers: true,
                singleSelect: true,
                remoteSort: true,
                frozenColumns: [[
                    { title: '项目编号', field: 'project_code', width: 100, sortable: true },
                    { title: '项目名称', field: 'project_name', width: 100, sortable: true }
				]],
                columns: [[
                    { title: '阶段', field: 'stage_name', width: 100, sortable: true },
                    { title: '小组', field: 'group_name', width: 100, sortable: true },
                    { title: '工作内容', field: 'jobduties_name', width: 300, sortable: true },
                    { title: '细目', field: 'detail_name', width: 300, sortable: true,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a href="#" style="text-decoration:none;" onclick="detail(' + rowIndex + ');">' + value + '</a>';
                        }
                    },
                    { title: '状态', field: 'orderby', width: 100, sortable: true,
                        formatter: function (value, rowData, rowIndex) {
                            var str = "未提交";
                            if (rowData.psiStatus != "") {
                                var v = rowData.psiStatus.split('|');
                                var vvv = new Array();
                                vvv[0] = v[0].split('~');
                                vvv[1] = v[1].split('~');
                                vvv[2] = v[2].split('~');
                                if (vvv[2][1] == '1') {
                                    switch (vvv[2][0]) {
                                        case "0": str = "<img src='../Images/point/bullet_error.png'/>"; break;
                                        case "1": str = "<img src='../Images/point/bullet_green.png'/>"; break;
                                        case "2": str = "<img src='../Images/point/bullet_yellow.png'/>"; break;
                                        case "3": str = "<img src='../Images/point/bullet_orange.png'/>"; break;
                                        case "4": str = "<img src='../Images/point/bullet_red.png'/>"; break;
                                        default: break;
                                    }
                                }
                                else if (vvv[1][1] == '1') {
                                    switch (vvv[1][0]) {
                                        case "0": str = "复审未通过"; break;
                                        case "1": str = "复审通过"; break;
                                        default: break;
                                    }
                                }
                                else if (vvv[0][1] == '1') {
                                    switch (vvv[0][0]) {
                                        case "0": str = "初审未通过"; break;
                                        case "1": str = "初审通过"; break;
                                        default: break;
                                    }
                                }
                                else if (vvv[0][1] == '0') {
                                    str = "已提交";
                                }
                            }
                            return str;
                        },
                        styler: function (value, rowData, index) {
                            var str = "";
                            if (rowData.psiStatus != "") {
                                var v = rowData.psiStatus.split('|');
                                var vvv = new Array();
                                vvv[0] = v[0].split('~');
                                vvv[1] = v[1].split('~');
                                vvv[2] = v[2].split('~');
                                if (vvv[2][1] == '1') {
                                    switch (vvv[2][0]) {
                                        case "0": str = ""; break;
                                        case "1": str = ""; break;
                                        case "2": str = ""; break;
                                        case "3": str = ""; break;
                                        case "4": str = ""; break;
                                        default: break;
                                    }
                                }
                                else if (vvv[1][1] == '1') {
                                    switch (vvv[1][0]) {
                                        case "0": str = "color:red;"; break;
                                        case "1": str = "color:green;"; break;
                                        default: break;
                                    }
                                }
                                else if (vvv[0][1] == '1') {
                                    switch (vvv[0][0]) {
                                        case "0": str = "color:red;"; break;
                                        case "1": str = "color:green;"; break;
                                        default: break;
                                    }
                                }
                                else if (vvv[0][1] == '0') {
                                    str = "color:blue;";
                                }
                            }
                            return str;
                        }
                    },
                    { title: '工作种类', field: 'implement_name', width: 300, sortable: true },
                    { title: '同组人', field: 'names', width: 300, sortable: true },
                    { title: '开始日期', field: 'begin_date', width: 150, sortable: true, align: 'center' },
                    { title: '结束日期', field: 'end_date', width: 150, sortable: true, align: 'center' }
				]],
                onLoadSuccess: function (data) {
                    if (data.rows.length > 0) { mergeCellsByField('tt', 'project_code,project_name,stage_name,group_name,jobduties_name'); }
                    $('#tt').datagrid('clearSelections');
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

    <table id="tt"></table>

</asp:Content>