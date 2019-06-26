<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="CheckDetail.aspx.cs" Inherits="Maticsoft.Web.kaoqing.CheckDetail" %>
<%@ Register TagName="ToolBar" TagPrefix="tool" Src="~/Controls/toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    var isload = true;
    $(function () {
        if (isload) {
            $("#tt").datagrid({
                url: '../Ashx/kaoqin.ashx',
                queryParams: { 'action': 'AllCheck' },
//                pageSize: 20,
//                pageList: [10, 20, 30, 40, 50, 100],
//                pagination: true,
                rownumbers: true,
//                sortName: 'UserName',
//                sortOrder: 'desc',
                idField: 'UserID',
                toolbar: "#tab_toolbar",
                striped: true, //True 奇偶行使用不同背景色
                frozenColumns: [[
                    { field: 'WorkID', title: '工号', width: 100 },
                    { field: 'Name', title: '姓名', width: 200 },
                    { field: 'T', title: '考勤日期', width: 200 },

                ]],
                columns: [[
                    { field: 'DengJiTime1', title: '第一次登记（上班）', styler: cellStyler, width: 200 },
                    { field: 'DengJiTime2', title: '第二次登记（下上班）', styler: cellStyler, width: 200 },
                    { field: 'DengJiTime3', title: '第三次登记（上班）', styler: cellStyler, width: 200 },
                    { field: 'DengJiTime4', title: '第四次登记（下班）', styler: cellStyler, width: 200 },
                ]]

            });
        };
         isload=false;
        $('#startTime').datebox({
            formatter: function (date) { return date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate(); },
            parser: function (date) { return new Date(Date.parse(date.replace(/-/g, "/"))); }
        });
        $('#endTime').datebox({
            formatter: function (date) { return date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate(); },
            parser: function (date) { return new Date(Date.parse(date.replace(/-/g, "/"))); }
        });
    });
    function btn_search() {
        var start = $("#startTime").datebox("getValue");
        var end = $("#endTime").datebox("getValue");
        var userName = $("#SUName").val();
        var workID = $("#SWID").val();
//        $("#tt").datagrid("clear");
        $("#tt").datagrid("options").queryParams = { "action": "s_AllCheck", "startTime": start, "endTime": end,"userName":userName,"workID":workID };
        $("#tt").datagrid("reload");
    };
    function cellStyler(value, row, index) {
        if (value.indexOf("迟到") >= 0 || value.indexOf("早退") >= 0 || value.indexOf("未登记") >= 0) {
            return 'background-color:#ffee00;color:red;';
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="toolbarDIV" style="height:0px">
    <div id="st" style="padding:5px;height:auto">
         姓名：<input type="text" id="SUName" />
         工号：<input type="text" id="SWID" />
        日期：<input id="startTime" class="easyui-datebox" style="width:80px"/>
			至: <input id="endTime" class="easyui-datebox" style="width:80px"/>
            <a href="#" class="easyui-linkbutton" iconCls="icon-search" onclick="btn_search();return false;">查询</a>
    </div>
    <table id="tt"></table>
</div>
</asp:Content>
