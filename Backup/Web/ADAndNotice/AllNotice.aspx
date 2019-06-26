<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="AllNotice.aspx.cs" Inherits="Maticsoft.Web.ADAndNotice.AllNotice" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(function () {
            $('#tt').datagrid({
                url: '../Ashx/notice.ashx',
                queryParams: { "action": "list" },
                loadMsg: '正在努力加载中...',
                idField: 'id',
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                fitColumns: true,
                pagination: true,
                remoteSort: true,
                rownumbers: true,
                singleSelect: false,
                frozenColumns: [[
	                    { field: 'ckb', checkbox: true, width: 10 }
				    ]],
                columns: [[
                        { title: '标题', field: 'title', width: 100, sortable: true },
                        { title: '概要', field: 'summary', width: 100, sortable: true },
                        { title: '创建人', field: 'create_name', width: 100, sortable: true },
                        { title: '创建时间', field: 'create_date', width: 100, sortable: true },
                        { title: '修改人', field: 'update_name', width: 100, sortable: true },
                        { title: '修改时间', field: 'update_date', width: 100, sortable: true }
		            ]],
                onClickCell: function (rowIndex, field, value) { $('#tt').datagrid('clearSelections'); },
                onHeaderContextMenu: function (e, field) {
                    e.preventDefault();
                    if (!cmenu) { createColumnMenu(); }
                    cmenu.menu('show', { left: e.pageX, top: e.pageY });
                },
                toolbar: "#tab_toolbar"
            });
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
                cmenu.menu('appendItem', { text: col.title, name: field, iconCls: 'icon-ok' });
            }
        }

        //高级查询
        function asearch() {
        }

        //快速搜索
        function qsearch(v) {
            $('#tt').datagrid('options').queryParams = { "action": "list", "key": v };
            $('#tt').datagrid('load');
        }

        //添加
        function add() {
            parent.addTab_Ext('公告设置【新增】', "/ADAndNotice/Notice_IDE.aspx?type=add", "", false);
        }

        //复制
        function copy() {
            var row = whether('复制')
            if (row != null) {
                parent.addTab_Ext('公告设置【复制】', "/ADAndNotice/Notice_IDE.aspx?type=add&id=" + row.id, "", false);
            }
        }

        //编辑
        function edit() {
            var row = whether('编辑')
            if (row != null) {
                parent.addTab_Ext('公告设置【编辑】', "/ADAndNotice/Notice_IDE.aspx?type=edit&id=" + row.id, "", false);
            }
        }

        //查看
        function view() {
            var row = whether('查看')
            if (row != null) {
                //parent.addTab_Ext('公告设置【编辑】', "/ADAndNotice/Notice_IDE.aspx?type=edit&id=" + row.id, "", false);
                window.open("/ADAndNotice/noticeview.aspx?id=" + row.id, row.title);
            }
        }

        //是否可以复制、编辑、查看
        function whether(value) {
            var row = $('#tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '系统提示', msg: '请选择您要“' + value + '”的数据。' });
                return null;
            }
            if (art.dialog.get('company_dialog') != null) {
                art.dialog.get('company_dialog').close();
            }
            return row;
        }

        function del() {
            var selected = "";
            $($('#tt').datagrid('getSelections')).each(function () {
                selected += "'" + this.id + "',";
            });
            selected = selected.substr(0, selected.length - 1);
            if (selected == null || selected == "") {
                $.messager.show({ title: '系统提示', msg: '请选择您要“删除”的数据！' });
                return;
            }
            $.messager.confirm('系统提示', '确认删除？', function (r) {
                if (r) {
                    $.post('../Ashx/notice.ashx', { "action": "dels", "cbx_select": selected }, function (data) {
                        if (data == "ok") {
                            $("#tt").datagrid("reload");
                            $.messager.show({ title: '系统提示', msg: '删除成功。' });
                        }
                        else {
                            $.messager.show({ title: '系统提示', msg: (data=="success"?"保存成功":data) });
                        }
                    });
                }
            });
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <toolbar:ToolBar runat="server" ID="toolbar1"/>

    <table id="tt"></table>

</asp:Content>
