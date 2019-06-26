<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="MyCheck.aspx.cs" Inherits="Maticsoft.Web.kaoqing.MyCheck" %>
<%@ Register TagName="ToolBar" TagPrefix="tool" Src="~/Controls/toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    var isload = true;
    var start = '';
    var end = '';
    $(function () {
        if (isload) {
            $("#tt").datagrid({
                url: '../Ashx/kaoqin.ashx',
                queryParams: { 'action': 'myCheck' },
                pagination: true,
                rownumbers: true,
                sortName: 'KaoQinRiQi',
                sortOrder: 'desc',
                idField: 'KaoQinRiQi',
                toolbar: "#st",
                striped: true, //True 奇偶行使用不同背景色
                frozenColumns: [[
                    { field: 'T', title: '考勤日期', width: 200 },

                ]],
                columns: [[
                    { field: 'DengJiTime1', title: '第一次登记（上班）',styler:cellStyler, width: 200 },
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
         start = $("#startTime").datebox("getValue");
         end = $("#endTime").datebox("getValue");
//        $("#tt").datagrid("clear");
        $("#tt").datagrid("options").queryParams = {"action":"s_myCheck","startTime":start,"endTime":end};
        $("#tt").datagrid("reload");
    };
    function cellStyler(value, row, index) {
        if (value.indexOf("迟到") >= 0 || value.indexOf("早退") >= 0 || value.indexOf("未登记") >= 0) {
            return 'background-color:#ffee00;color:red;';
        }
    }
    function btn_Table() {
//        var start = $("#startTime").datebox("getValue");
//        var end = $("#endTime").datebox("getValue");
        parent.addTab_Ext('我的考勤统计', '/kaoqing/MyKaoQinRdlc.aspx?STime=' + start + '&ETime=' + end, "", false);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="toolbarDIV" style="height:0px">
    <%--<tool:ToolBar ID="tool"  Exportshow="1" Printshow="1" ASearchshow="1" runat="server" />--%>
    <div id="st" style="padding:5px;height:auto">
        日期：<input id="startTime" class="easyui-datebox" style="width:80px"/>
			至: <input id="endTime" class="easyui-datebox" style="width:80px"/>
            <a href="#" class="easyui-linkbutton" iconCls="icon-search" onclick="btn_search();return false;">查询</a>
            <a href="#" class="easyui-linkbutton" iconCls="icon-search" onclick="btn_Table();return false;">报表</a>
    </div>

    <table id="tt"></table>
</div>
</asp:Content>
