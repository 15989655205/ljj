<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.UserList" %>
<%@ Register Src="../Controls/BaseInfo/User_IDE.ascx" TagName="User" TagPrefix="user" %>
<%@ Register Src="../Controls/BaseInfo/UserPassword.ascx" TagName="Userpass" TagPrefix="userpass" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(function () {
            $('#tt').datagrid({
                url: '../Ashx/UserList.ashx', //请求数据的页面
                queryParams: { "action": "list" },
                idField: 'UserID',
                toolbar: "#tab_toolbar",
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                fitColumns: true,
                pagination: true,
                rownumbers: true,
                singleSelect: false,
                frozenColumns: [[
                    { field: 'ckb', checkbox: true, width: 10 },
                    { title: '工号', field: 'WorkID', width: 100, sortable: true },
                    { title: '姓名', field: 'Name', width: 100, sortable: true }
			    ]],
                columns: [[
                    { title: '登录帐号', field: 'UserName', width: 100, sortable: true },
                    { title: '系统角色', field: 'RoleName', width: 300, sortable: true },
                    { title: '电话', field: 'Tel', width: 200, sortable: true },
				    { title: '部门', field: 'DeptName', width: 150, sortable: true },
                    { title: '级别', field: 'AppRoleName', width: 150, sortable: true },
                    { title: '登录权限', field: 'Permissions', width: 150, sortable: true,
                        formatter: function (value, rowData, rowIndex) { return value == 1 ? "已激活" : "未激活"; }
                    }
			    ]],
                onClickCell: function (rowIndex, field, value) { $('#tt').datagrid('clearSelections'); },
                onHeaderContextMenu: function (e, field) {
                    e.preventDefault();
                    if (!cmenu) { createColumnMenu(); }
                    cmenu.menu('show', { left: e.pageX, top: e.pageY });
                }
            });
        });

        var cmenu;
        function createColumnMenu() {
            cmenu = $('<div/>').appendTo('body');
            cmenu.menu({
                onClick: function (item) {
                    if (item.iconCls == 'icon-ok') {
                        $('#tt').datagrid('hideColumn', item.name);
                        cmenu.menu('setIcon', { target: item.target, iconCls: 'icon-empty' });
                    }
                    else {
                        $('#tt').datagrid('showColumn', item.name);
                        cmenu.menu('setIcon', { target: item.target, iconCls: 'icon-ok' });
                    }
                }
            });
            var fields = $('#tt').datagrid('getColumnFields');
            for (var i = 0; i < fields.length; i++) {
                var field = fields[i];
                var col = $('#tt').datagrid('getColumnOption', field);
                cmenu.menu('appendItem', { text: col.title, name: field, iconCls: 'icon-ok' });
            }
        }

        //快速搜索
        function qsearch(v) {
            $('#tt').datagrid('options').queryParams = { "action": "list", "key": v };
            $('#tt').datagrid('load');
        }
        
        //编辑事件
        function edit() {
            var row = whether('编辑');
            if (row != null) {
                openDialog("edit", row, '编辑');
            } 
        }

        //查看事件
        function view() {
            var row = whether('查看');
            if (row != null) {
                openDialog("view", row, '查看');
            } 
        }

        //修改密码
        function Password(data) {
            $('#uid').val(data);
            $('#password_win').window('open');
        }

        //是否可以复制、编辑、查看
        function whether(value) {
            var row = $('#tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '系统提示', msg: '请选择您要“' + value + '”的数据。' });
                return null;
            }
            if (art.dialog.get('user_dialog') != null) {
                art.dialog.get('user_dialog').close();
            }
            return row;
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <toolbar:ToolBar runat="server" PageID="1811"/>

    <table id="tt"></table>

    <div id="Edit" style="display:none;"><user:User runat="server"/></div>

    <div id="w" style="display:none;"><userpass:Userpass runat="server"/></div>

</asp:Content>
