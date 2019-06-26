<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Supplier" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="s" TagName="S" Src="../Controls/BaseInfo/Supplier.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#tt").datagrid({
                url: "../Ashx/Supplier.ashx"
                , queryParams: { "action": "list" }
                , loadMsg: "正在努力加载中..."
                , toolbar: "#tab_toolbar"
                , idField: "ID"
                , pageSize: 20
                , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
                //, fitColumns: true
                , remoteSort: true
                , pagination: true
                , rownumbers: true
                , singleSelect: false
                , frozenColumns: [[
                    { field: "ckb", checkbox: true, rowspan: "2"}
                    , { title: "编码", field: "Code", width: 50, sortable: true, rowspan: "2", align: "center" }
                    , { title: "简称", field: "Abbreviation", width: 80, sortable: true, rowspan: "2", align: "center" }
                ]]
                , columns: [
                    [
                        { title: "全称", field: "FullName", width: 100, sortable: true, rowspan: "2" }
                        , { title: "英文简称", field: "EnAbbreviation", width: 100, sortable: true, rowspan: "2" }
                        , { title: "英文全称", field: "EnFullName", width: 100, sortable: true, rowspan: "2" }
                        , { title: "地址", field: "Address", width: 100, sortable: true, rowspan: "2" }
                        , { title: "英文地址", field: "EnAddress", width: 100, sortable: true, rowspan: "2" }
                        , { title: "保证金", field: "Margin", width: 100, sortable: true, rowspan: "2" }
                        , { title: "税率", field: "TaxRate", width: 100, sortable: true, rowspan: "2" }
                        , { title: "分类编码", field: "TypeCode", width: 100, sortable: true, rowspan: "2" }
                        , { title: "邮编", field: "ZipCode", width: 100, sortable: true, rowspan: "2" }
                        , { title: "货币", field: "Currency", width: 100, sortable: true, rowspan: "2" }
                        , { title: "付款条件", field: "PaymentTerms", width: 100, sortable: true, rowspan: "2" }
                        , { title: "负责人", field: "Principal", width: 100, sortable: true, rowspan: "2" }
                        , { title: "联系人", field: "Linkman", width: 100, sortable: true, rowspan: "2" }
                        , { title: "采购员", field: "Buyer", width: 100, sortable: true, rowspan: "2" }
                        , { title: "采购周期", field: "PurchasingCycle", width: 100, sortable: true, rowspan: "2" }
                        , { title: "采购周期表", field: "PurchasingCycleTable", width: 100, sortable: true, rowspan: "2" }
                        , { title: "采购到货周期", field: "PurchasingGoodsCycle", width: 100, sortable: true, rowspan: "2" }
                        , { title: "结算方式", field: "PaymentMethod", width: 100, sortable: true, rowspan: "2" }
                        , { title: "采购到货差异天数", field: "", width: 100, sortable: true, colspan: "4" }
                        , { title: "开户银行", field: "DepositBank", width: 100, sortable: true, rowspan: "2" }
                        , { title: "银行账号", field: "BankAccount", width: 100, sortable: true, rowspan: "2" }
                        , { title: "预付科目", field: "PSubject", width: 100, sortable: true, rowspan: "2" }
                        , { title: "应付科目", field: "TSubject", width: 100, sortable: true, rowspan: "2" }
                        , { title: "预付对方科目", field: "POSubject", width: 100, sortable: true, rowspan: "2" }
                        , { title: "应付现金项目", field: "TCProject", width: 100, sortable: true, rowspan: "2" }
                        , { title: "预付现金项目", field: "PCProject", width: 100, sortable: true, rowspan: "2" }
                        , { title: "创建人", field: "CreateUser", width: 100, sortable: true, rowspan: "2" }
                        , { title: "创建日期", field: "CreateDate", width: 100, sortable: true, rowspan: "2" }
                        , { title: "修改人", field: "UpdateUser", width: 100, sortable: true, rowspan: "2" }
                        , { title: "修改日期", field: "UpdateDate", width: 100, sortable: true, rowspan: "2" }
					    , { title: "备注", field: "Remark", width: 100, sortable: true, rowspan: "2"
					        , formatter: function (value, rowData, rowIndex) {
					            return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
					        }
					    }
                    ]
                    , [
                        { title: "陆运", field: "LandTransportation", width: 100, sortable: true }
                        , { title: "海运", field: "SeaTransportation", width: 100, sortable: true }
                        , { title: "空运", field: "AirTransportation", width: 100, sortable: true }
                        , { title: "其他", field: "OtherTransportation", width: 100, sortable: true }
                    ]
		        ]
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
                $.messager.show({ title: "系统提示", msg: "请选择您要“" + value + "”的数据。" });
            }
            return row;
        }

        //删除
        function del() {
            var selected = "";
            $($("#tt").datagrid("getSelections")).each(function () { selected += "'" + this.ID + "',"; });
            selected = selected.substr(0, selected.length - 1);          
            if (selected == null || selected == "") {
                $.messager.show({ title: "系统提示", msg: "请选择您要“删除”的数据。" });
                return;
            }
            $.messager.confirm("系统提示", "确认删除？", function (r) {
                if (r) {
                    $.post("../Ashx/Supplier.ashx", { "action": "dels", "cbx_select": selected }, function (data) {
                        $("#tt").datagrid("reload");
                        $.messager.show({ title: "系统提示", msg: data });
                        //if (data == "ok") {
                        //    $("#tt").datagrid("reload");
                        //    $.messager.show({ title: "系统提示", msg: "删除成功。" });
                        //}
                        //else {
                        //    $.messager.show({ title: "系统提示", msg: data });
                        //}
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
    <div id="detail" style="display:none"><s:S runat="server"/></div>
</asp:Content>