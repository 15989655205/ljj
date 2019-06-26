<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProductSeries.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.ProductSeries" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="st" TagName="ST" Src="../Controls/BaseInfo/ProductSeries.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#tt").datagrid({
                url: "../Ashx/ProductSeries.ashx"
                , queryParams: { "action": "list" }
                , loadMsg: "正在努力加载中..."
                , toolbar: "#tab_toolbar"
                , idField: "ID"
                , pageSize: 20
                , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
                , fitColumns: true
                , remoteSort: true
                , pagination: true
                , rownumbers: true
                , singleSelect: false
                , frozenColumns: [[]]
                , columns: [[
                    { field: "ckb", checkbox: true, width: 5 }
                    , { title: "编码", field: "Code", width: 10, sortable: true }
                    , { title: "名称", field: "Name", width: 10, sortable: true }
                    , { title: "创建人", field: "CreateUser", width: 10, sortable: true }
                    , { title: "创建日期", field: "CreateDate", width: 10, sortable: true }
                    , { title: "修改人", field: "UpdateUser", width: 10, sortable: true }
                    , { title: "修改日期", field: "UpdateDate", width: 10, sortable: true }
					, { title: "备注", field: "Remark", width: 35, sortable: true
					    , formatter: function (value, rowData, rowIndex) {
					        return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
					    }
					}
		        ]]
                , onClickCell: function (rowIndex, field, value) { $("#tt").datagrid("clearSelections"); }
                , onHeaderContextMenu: function (e, field) {
                    e.preventDefault();
                    if (!cmenu) { createColumnMenu(); }
                    cmenu.menu("show", { left: e.pageX, top: e.pageY });
                }
            });
        });

    </script>

    <script type="text/javascript">
        var cmenu;
        function createColumnMenu() {
            cmenu = $("<div/>").appendTo("body");
            cmenu.menu({
                onClick: function (item) {
                    if (item.iconCls == "icon-ok") {
                        $("#tt").treegrid("hideColumn", item.name);
                        cmenu.menu("setIcon", {
                            target: item.target,
                            iconCls: "icon-empty"
                        });
                    } else {
                        $("#tt").treegrid("showColumn", item.name);
                        cmenu.menu("setIcon", {
                            target: item.target,
                            iconCls: "icon-ok"
                        });
                    }
                }
            });
            var fields = $("#tt").treegrid("getColumnFields");
            for (var i = 0; i < fields.length; i++) {
                var field = fields[i];
                var col = $("#tt").treegrid("getColumnOption", field);
                cmenu.menu("appendItem", { text: col.title, name: field, iconCls: "icon-ok" });
            }
        }
    </script>

    <script type="text/javascript">
        //新增
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

        //删除
        function del() {
            var selected = "";
            $($("#tt").datagrid("getSelections")).each(function () { selected += "'" + this.ID + "',"; });
            selected = selected.substr(0, selected.length - 1);          
            if (selected == null || selected == "") {
                $.messager.show({ title: "提示", msg: "请选择您要“删除”的数据。" });
                return;
            }
            $.messager.confirm("提示", "确认删除？", function (r) {
                if (r) {
                    $.post("../Ashx/ProductSeries.ashx", { "action": "dels", "cbx_select": selected }, function (data) {
                        $("#tt").datagrid("reload");
                        $.messager.show({ title: "提示", msg: data });
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
    <toolbar:ToolBar runat="server" ID="toolbar1"/>    
    <table id="tt"></table>
    <div id="detail" style="display:none"><st:ST runat="server"/></div>
</asp:Content>