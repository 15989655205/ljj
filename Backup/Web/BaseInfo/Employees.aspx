<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true"
    CodeBehind="Employees.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Employees" %>

<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="employees" TagName="Employees" Src="../Controls/BaseInfo/Employees.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--加载数据-->
    <script type="text/javascript">
        $(function () {
            $("#tt").datagrid({
                url: "../Ashx/Employees.ashx",
                queryParams: { "action": "list" },
                loadMsg: "正在努力加载中...",
                toolbar: "#tab_toolbar",
                idField: "UserID",
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                pagination: true,
                remoteSort: true,
                rownumbers: true,
                singleSelect: false,
                frozenColumns: [[
	                { field: "ckb", checkbox: true, width: 10 },
                    { title: "工号", field: "WorkID", width: 100, sortable: true },
					{ title: "姓名", field: "Name", width: 100, sortable: true },
                    { title: "简称", field: "Value2", width: 80, sortable: true },
                    { title: "账号", field: "UserName", width: 100, sortable: true },
                    { title: "性别", field: "SexName", width: 50, sortable: true }
				]],
                columns: [[
			        { title: "身份证", field: "IDCard", width: 135, sortable: true },
                    { title: "出生日期", field: "Dataofbirth", width: 75, sortable: true },
                    { title: "血型", field: "BloodtypeName", width: 50, sortable: true },
                    { title: "籍贯", field: "Nativeplace", width: 100, sortable: true },
                    { title: "户口地址", field: "RegdResd", width: 200, sortable: true },
                    { title: "居住地址", field: "Address", width: 200, sortable: true },
                    { title: "民族", field: "Nation", width: 50, sortable: true },
                    { title: "政治面貌", field: "PoliticsstatusName", width: 75, sortable: true },
                    { title: "婚姻状况", field: "MaritalstatusName", width: 75, sortable: true },
                    { title: "学历", field: "EducationName", width: 50, sortable: true },
                    { title: "学位", field: "DegreeName", width: 50, sortable: true },
                    { title: "专业", field: "Major", width: 100, sortable: true },
                    { title: "毕业时间", field: "GraduationDate", width: 75, sortable: true },
                    { title: "电话", field: "Tel", width: 100, sortable: true },
                    { title: "邮箱", field: "Email", width: 150, sortable: true },
                    { title: "联系人", field: "EmContact", width: 100, sortable: true },
                    { title: "联系电话", field: "EmContactTel", width: 100, sortable: true },
                    { title: "员工状态", field: "StateEmployeesName", width: 75, sortable: true },
                    { title: "入职日期", field: "EntryDate", width: 75, sortable: true },
                    { title: "转正日期", field: "PositivedatesName", width: 75, sortable: true },
                    { title: "部门", field: "DeptIDName", width: 150, sortable: true },
                    { title: "级别", field: "AppRoleIDName", width: 100, sortable: true },
                    { title: "创建人", field: "CreateUser", width: 100, sortable: true },
                    { title: "创建时间", field: "CreateDate", width: 100, sortable: true },
                    { title: "修改人", field: "UpdateUser", width: 100, sortable: true },
                    { title: "修改时间", field: "UpdateDate", width: 100, sortable: true },
                    { title: "备注", field: "Remark", width: 200, sortable: true,
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

        //批量删除
        function del() {
            var selected = "";
            $($("#tt").datagrid("getSelections")).each(function () { selected += "'" + this.UserID + "',"; });
            selected = selected.substr(0, selected.length - 1);
            if (selected == null || selected == "") {
                $.messager.show({ title: "提示", msg: "请选择您要“删除”的数据！" });
                return;
            }
            $.messager.confirm("提示", "确认删除？", function (r) {
                if (r) {
                    $.post("../Ashx/Employees.ashx", { "action": "dels", "cbx_select": selected }, function (data) {
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
    <toolbar:ToolBar runat="server" ID="toolbar1" PageID="101412" />
    <table id="tt">
    </table>
    <div id="detail" style="display: none">
        <employees:Employees ID="Employees1" runat="server" />
    </div>
</asp:Content>
