<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Maticsoft.Web.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table id="tt"></table>

    <script type="text/javascript">
        $(function () {
            alert();
            $('#tt').datagrid({
                url: 'Ashx/UserList.ashx?action=list', //请求数据的页面
                sortName: 'UserName',
                sortOrder: 'desc',
                idField: 'UserID',
                pageSize: 30,
                frozenColumns: [[
	                { field: 'ck', checkbox: true }
                //,{ title: 'ID', field: 'ID', width: 80, sortable: true }
				]],
                columns: [[
					{ field: 'UserID', title: '用户ID', width: 150 },
					{ field: 'DeptName', title: '所属部门', width: 150, sortable: true },
					{ field: 'RoleName', title: '角色', width: 150, sortable: true },
					{ field: 'UserName', title: '用户帐号', width: 150, sortable: true },
					{ field: 'Name', title: '用户姓名', width: 150, sortable: true },
					{ field: 'Tel', title: '联系电话', width: 150, sortable: true },
					{ field: 'WorkID', title: '工号', width: 150, sortable: true }
				]],
                fit: true,
                pagination: true,
                rownumbers: true,
                fitColumns: true,
                singleSelect: false,
                toolbar: [{
                    text: '新增',
                    iconCls: 'icon-add',
                    handler: add
                }, '-', {
                    text: '修改',
                    iconCls: 'icon-edit',
                    handler: edit
                }, '-', {
                    text: '删除',
                    iconCls: 'icon-remove',
                    handler: del
                }, '-', {
                    text: '查找',
                    iconCls: 'icon-search',
                    handler: OpensearchWin
                }, '-', {
                    text: '所有',
                    iconCls: 'icon-search',
                    handler: showAll
                }],
                onHeaderContextMenu: function (e, field) {
                    e.preventDefault();
                    if (!$('#tmenu').length) {
                        createColumnMenu();
                    }
                    $('#tmenu').menu('show', {
                        left: e.pageX,
                        top: e.pageY
                    });
                }
            });
            //$('body').layout();
        });
        var cmenu;
        function createColumnMenu() {
            cmenu = $('<div/>').appendTo('body');
            cmenu.menu({
                onClick: function (item) {
                    if (item.iconCls == 'icon-ok') {
                        $('#tt').datagrid('hideColumn', item.name);
                        cmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-empty'
                        });
                    } else {
                        $('#tt').datagrid('showColumn', item.name);
                        cmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-ok'
                        });
                    }
                }
            });
            var fields = $('#tt').datagrid('getColumnFields');
            for (var i = 0; i < fields.length; i++) {
                var field = fields[i];
                var col = $('#tt').datagrid('getColumnOption', field);
                cmenu.menu('appendItem', {
                    text: col.title,
                    name: field,
                    iconCls: 'icon-ok'
                });
            }
        }
</script>
</asp:Content>
