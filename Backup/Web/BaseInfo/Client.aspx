<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Client" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="c" TagName="C" Src="../Controls/BaseInfo/Client.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--加载数据-->
    <script type="text/javascript">
        $(function () {
            $("#tt").datagrid({
                url: "../Ashx/Client.ashx",
                queryParams: { "action": "list" },
                loadMsg: "正在努力加载中...",
                toolbar: "#tab_toolbar",
                idField: "ID",
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                //fitColumns: true,
                pagination: true,
                remoteSort: true,
                rownumbers: true,
                singleSelect: false,
                frozenColumns: [[
                    { field: "ckb", checkbox: true, width: 10 },
                    { title: "编码", field: "Code", width: 100, sortable: true },
                    { title: "名称", field: "Name", width: 100, sortable: true }
                ]],
                columns: [[
                    { title: "级别", field: "CLevel", width: 100, sortable: true },
                    { title: "类别", field: "Type", width: 100, sortable: true },
                    { title: "区域", field: "Area", width: 100, sortable: true },
                    { title: "负责人", field: "Head", width: 100, sortable: true },
                    { title: "手机", field: "Phone", width: 100, sortable: true },
                    { title: "电话", field: "Tel", width: 100, sortable: true },
                    { title: "传真", field: "Fax", width: 100, sortable: true },
                    { title: "邮件", field: "Email", width: 100, sortable: true },
                    { title: "地址", field: "Address", width: 100, sortable: true },
                    { title: "币种", field: "Currency", width: 100, sortable: true },
                    { title: "汇率", field: "Parities", width: 100, sortable: true },
                    { title: "营业执照", field: "BusinessLicense", width: 100, sortable: true },
                    { title: "对账日期", field: "ReconciliationDate", width: 100, sortable: true },
                    { title: "成立日期", field: "SetupDate", width: 100, sortable: true },
                    { title: "是否供应商", field: "Supplier", width: 100, sortable: true },
                    { title: "开始来往日期", field: "BeginDate", width: 100, sortable: true },
                    { title: "停止来往日期", field: "EndDate", width: 100, sortable: true },
                    { title: "状态", field: "Status", width: 100, sortable: true },
                    { title: "行业分类", field: "Industry", width: 100, sortable: true },
					{ title: "备注", field: "Remark", width: 550, sortable: true,
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
        //新增
        function add() {
            openDialog("add", "", "新增");
        }

        //复制
        function copy() {
            var row = whether("复制")
            if (row != null) {
                openDialog("copy", row, "复制");
            }
        }

        //编辑
        function edit() {
            var row = whether("编辑");
            if (row != null) {
                openDialog("edit", row, "编辑");
            }
        }

        //查看
        function view() {
            var row = whether("查看");
            if (row != null) {
                openDialog("view", row, "查看");
            }
        }

        //是否可以复制、编辑、查看
        function whether(value) {
            var row = $("#tt").datagrid("getSelected");
            if (row == null) {
                $.messager.show({ title: "系统提示", msg: "请选择您要“" + value + "”的数据。" });
                return null;
            }
            return row;
        }

        //删除
        function del() {
            var selected = "";
            $($("#tt").datagrid("getSelections")).each(function () { selected += "'" + this.ID + "',"; });
            selected = selected.substr(0, selected.length - 1);
            if (selected == null || selected == "") {
                $.messager.show({ title: "提示", msg: "请选择您要“删除”的数据！" });
                return;
            }
            $.messager.confirm("提示", "确认删除？", function (r) {
                if (r) {
                    $.post("../Ashx/Client.ashx", { "action": "dels", "cbx_select": selected }, function (data) {
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
    <toolbar:ToolBar runat="server" id="toolbar1" PageID="101011"/>
    <table id="tt"></table>
    <div id="detail" style="display:none"><c:C runat="server"/></div>
</asp:Content>
