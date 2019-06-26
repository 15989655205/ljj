<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProductType.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.ProductType" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="pt" TagName="PT" Src="../Controls/BaseInfo/ProductType.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            $("#tt").treegrid({
                url: "../Ashx/ProductType.ashx",
                queryParams: { "action": "list" },
                loadMsg: "正在努力加载中...",
                idField: "ID",
                treeField: "CodeName",
                toolbar: "#tab_toolbar",
                fit: true,
                fitColumns: true,
                rownumbers: true,
                singleSelect: false,
                frozenColumns: [[
                    { field: "ckb", checkbox: true, width: 10 },
                    { title: "(编码)名称", field: "CodeName", width: 200 }
                ]],
                columns: [[
					{ title: "创建人", field: "CreatedUser", width: 30 },
                    { title: "创建日期", field: "CreatedDate", width: 30 },
                    { title: "修改人", field: "UpdatedUser", width: 30 },
                    { title: "修改日期", field: "UpdatedDate", width: 30 },
					{ title: "备注", field: "Remark", width: 200,
					    formatter: function (value, rowData, rowIndex) {
					        return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
					    }
					}
		        ]],
                onClickCell: function (field, row) { $("#tt").treegrid("clearSelections"); },
                onHeaderContextMenu: function (e, field) {
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

            var index = $("#tt").treegrid("getSelected");
            if (index == null) {
                $.messager.show({ title: "提示", msg: "请选择您要“" + value + "”的数据。" });
                return null;
            }               
            return index;
        }
   
        //删除
        function del() {
            var selected = "";
            $($("#tt").treegrid("getSelections")).each(function () { selected += "'" + this.ID + "',"; });
            selected = selected.substr(0, selected.length - 1);
            if (selected == null || selected == "") {
                $.messager.show({ title: "提示", msg: "请选择您要“删除”的数据！" });
                return;
            }
            $.messager.confirm("提示", "确认删除？", function (r) {
                if (r) {
                    $.post("../Ashx/ProductType.ashx", { "action": "dels", "cbx_select": selected }, function (data) {
                        $("#tt").treegrid("options").url = "../Ashx/ProductType.ashx?action=list";
                        $("#tt").treegrid("reload");
                        $.messager.show({ title: "提示", msg: data });
                    });
                }
            });
        }

        //高级查询
        function asearch() { }

        //快速搜索
        function qsearch(v) {
            //$("#tt").treegrid("options").queryParams = { "action": "list", "key": v };
            //$("#tt").treegrid("load");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <toolbar:ToolBar runat="server" ID="toolbar1"/>    
    <table id="tt"></table>
    <div id="detail" style="display:none"><pt:PT runat="server"/></div>
</asp:Content>