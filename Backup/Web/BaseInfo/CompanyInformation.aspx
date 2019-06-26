<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="CompanyInformation.aspx.cs"
    Inherits="Maticsoft.Web.BaseInfo.CompanyInformation" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="company" TagName="Company" Src="../Controls/BaseInfo/CompanyInformation.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--加载数据-->
    <script type="text/javascript">
        $(function () {
            $("#tt").datagrid({
                url: "../Ashx/Company.ashx",
                queryParams: { "action": "list" },
                loadMsg: "正在努力加载中...",
                toolbar: "#tab_toolbar",
                idField: "ID",
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                pagination: true,
                remoteSort: true,
                rownumbers: true,
                singleSelect: false,
                frozenColumns: [[
	                { field: "ckb", checkbox: true, width: 10 },
                    { title: "编号", field: "Number", width: 100, sortable: true },
					{ title: "公司简称", field: "Abbreviation", width: 100, sortable: true },
				]],
                columns: [[
                    { title: "公司名称", field: "FullName", width: 200, sortable: true },
					{ title: "公司地址", field: "Address", width: 200, sortable: true },
                    { title: "英文简称", field: "EnAbbreviation", width: 100, sortable: true },
                    { title: "英文名称", field: "EnFullName", width: 200, sortable: true },
					{ title: "英文地址", field: "EnAddress", width: 200, sortable: true },
					{ title: "负责人", field: "Head", width: 100, sortable: true },
					{ title: "联系电话", field: "FixedPhone", width: 100, sortable: true },
					{ title: "移动电话", field: "MobilePhone", width: 100, sortable: true },
					{ title: "传真", field: "Fax", width: 100, sortable: true },
					{ title: "邮编", field: "ZipCode", width: 50, sortable: true },
					{ title: "开户银行", field: "OpeningBank", width: 100, sortable: true },
					{ title: "帐号", field: "Account", width: 135, sortable: true },
					{ title: "企业代码", field: "CustomsCode", width: 100, sortable: true },
					{ title: "法人代表", field: "LegalRepresentative", width: 100, sortable: true },
                    { title: "创建人", field: "CreateUser", width: 100, sortable: true },
                    { title: "创建时间", field: "CreateDate", width: 100, sortable: true },
                    { title: "修改人", field: "UpdateUser", width: 100, sortable: true },
                    { title: "修改时间", field: "UpdateDate", width: 100, sortable: true },
					{ title: "备注", field: "Remark", width: 300, sortable: true,
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
            openDialog("add", null, "新增");
        }

        //复制、编辑、查看
        function whether() {
            var row = $("#tt").datagrid("getSelected");
            if (row == null) {
                $.messager.show({ title: "提示", msg: "请选择您要“" + value + "”的数据。" });
                return null;
            }
            return row;
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
                    $.post("../Ashx/Company.ashx", { "action": "dels", "cbx_select": selected }, function (data) {
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
    <toolbar:ToolBar runat="server" id="toolbar1" PageID="101410"/>
    <table id="tt"></table>
    <div id="detail" style="display:none"><company:Company runat="server"/></div>
</asp:Content>
