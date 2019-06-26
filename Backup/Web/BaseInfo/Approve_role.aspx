<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Approve_role.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Approve_role" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="approve_role" TagName="Approve_role" Src="../Controls/BaseInfo/Approve_role.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--加载数据-->
    <script type="text/javascript">
        $(function () {
            $("#tt").datagrid({
                url: "../Ashx/Approve_role.ashx",
                queryParams: { "action": "list" },
                loadMsg: "正在努力加载中...",
                toolbar: "#tab_toolbar",
                idField: "sid",
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                fitColumns: true,
                remoteSort: true,
                pagination: true,
                rownumbers: true,
                singleSelect: false,
                frozenColumns: [[
                    { field: "ckb", checkbox: true, width: 10 },
                    { title: "级别名称", field: "role_name", width: 150, sortable: true }
                ]],
                columns: [[
					{ title: "级别等级", field: "role_level", width: 40, sortable: true },
                    { title: "创建人", field: "create_personName", width: 30, sortable: true },
                    { title: "创建日期", field: "create_date", width: 40, sortable: true },
                    { title: "修改人", field: "update_personName", width: 30, sortable: true },
                    { title: "修改日期", field: "update_date", width: 40, sortable: true },
					{ title: "备注", field: "remark", width: 200, sortable: true,
					    formatter: function (value, rowData, rowIndex) {
					        return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
					    }
					}
		        ]],
                onClickCell: function (rowIndex, field, value) { $("#tt").datagrid("clearSelections"); },
                onHeaderContextMenu: function (e, field) {
                    e.preventDefault();
                    if (!cmenu) { createColumnMenu(); }
                    cmenu.menu("show", { left: e.pageX, top: e.pageY });
                }
            });
        });
    </script>

    <!--列头右击事件-->
    <script type="text/javascript">
        var cmenu;
        function createColumnMenu() {
            cmenu = $("<div/>").appendTo("body");
            cmenu.menu({
                onClick: function (item) {
                    if (item.iconCls == "icon-ok") {
                        $("#tt").datagrid("hideColumn", item.name);
                        cmenu.menu("setIcon", { target: item.target, iconCls: "icon-empty" });
                    }
                    else {
                        $("#tt").datagrid("showColumn", item.name);
                        cmenu.menu("setIcon", { target: item.target, iconCls: "icon-ok" });
                    }
                }
            });
            var fields = $("#tt").datagrid("getColumnFields");
            for (var i = 0; i < fields.length; i++) {
                var field = fields[i];
                var col = $("#tt").datagrid("getColumnOption", field);
                cmenu.menu("appendItem", { text: col.title, name: field, iconCls: "icon-ok" });
            }
        }
    </script>

    <!--工具按钮事件-->
    <script type="text/javascript">    
        //添加
        function add() {          
            openDialog("add", "", "新增");
        }

        //复制
        function copy() {
            var row = whether("复制");
            if (row != null) {
                openDialog("copy", row, "复制");
            }
        }

        //编辑
        function edit() {
            var row = whether("编辑")
            if (row != null) {
                openDialog("edit", row, "编辑");
            }
        }

        //查看
        function view() {
            var row = whether("查看")
            if (row != null) {
                openDialog("view", row, "查看");
            }
        }

        //是否可以复制、编辑、查看
        function whether(value) {
            var row = $("#tt").datagrid("getSelected");
            if (row == null) {
                $.messager.show({ title: "提示", msg: "请选择您要“" + value + "”的数据。" });
            }           
            return row;
        }
    
        function del() {
            var selected = "";
            $($("#tt").datagrid("getSelections")).each(function () { selected += "'" + this.sid + "',"; });
            selected = selected.substr(0, selected.length - 1);
            if (selected == null || selected == "") {
                $.messager.show({ title: "提示", msg: "请选择您要“删除”的数据。" });
                return;
            }
            $.messager.confirm("提示", "确认删除？", function (r) {
                if (r) {
                    $.post("../Ashx/Approve_role.ashx", { "action": "dels", "cbx_select": selected }, function (data) {
                        if (data == "ok") {
                            $("#tt").datagrid("reload");
                            $.messager.show({ title: "提示", msg: "删除成功。" });
                        }
                        else {
                            $.messager.show({ title: "提示", msg: data });
                        }
                    });
                }
            });
        }

        //高级查询
        function asearch() { }

        //快速搜索
        function qsearch(v) {
            $("#tt").datagrid("options").queryParams = { "action": "list", "key": v };
            $("#tt").datagrid("load");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <toolbar:ToolBar runat="server" ID="toolbar1" PageID="101412"/>
    <table id="tt"></table>
    <div id="detail" style="display:none">
        <approve_role:Approve_role runat="server"/>
    </div>
</asp:Content>
