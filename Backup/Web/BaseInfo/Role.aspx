<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Role" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    var editIndex = undefined;

    $(function () {
        //alert();
        $('#tt').datagrid({
            url: '../Ashx/Role.ashx', //请求数据的页面
            queryParams: { "action": "list" },
            sortName: 'RoleID',
            sortOrder: 'asc',
            idField: 'RoleID',
            toolbar: "#tab_toolbar",
            pageSize: 20,
            pageList: [10, 20, 30, 40, 50, 100],
            fit: true,
            striped: true, //True 奇偶行使用不同背景色
            pagination: true,
            rownumbers: true,
            //fitColumns: true,
            singleSelect: true,
            remoteSort: true,
            columns: [[
            { title: '删除', field: 'del', width: 50, align: 'center', hidden: true,
                formatter: function (value, rowData, rowIndex) {
                    return '<a style="color:red" href="javascript:;" onclick="Show(\'' + rowIndex + '\');"><img src="../js/themes/icons/cancel.png" /></a>';
                }
            },
					{ field: 'RoleID', title: '用户ID', width: 100, sortable: true },
					{ field: 'RoleName', title: '角色', width: 300, sortable: true, editor: "text" },
					{ field: 'Note', title: '备注', width: 200, sortable: true, editor: "text" }
				]],
            onClickRow: function (index, rowData) {
                EditRow(index);
            }
        });
    });

    function endEditing() {
        if (editIndex == undefined) { return true }
        if ($('#tt').datagrid('validateRow', editIndex)) {
            //var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'RoleName' });
            //var productname = $(ed.target).combobox('getText');
            //$('#tt').datagrid('getRows')[editIndex]['productname'] = productname;
            $('#tt').datagrid('endEdit', editIndex);
            editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function EditRow(index) {
        if (editIndex != index) {
            if (endEditing()) {
                $('#tt').datagrid('selectRow', index).datagrid('beginEdit', index);
                editIndex = index;
            } else {
                $('#tt').datagrid('selectRow', editIndex);
            }
        }
    }

    function EditGrid(row) {
        var index = $('#tt').datagrid('getRowIndex', row);
        $('#tt').datagrid('beginEdit', index);
        var editors = $('#tt').datagrid('getEditors', index);
        editIndex = index;
    }



    //快速搜索
    function qsearch(v) {
        $('#tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#tt').datagrid('load');
    }

    function add() {
        if (endEditing()) {
            $('#tt').datagrid('appendRow', {}); //, { status: 'P' });
            editIndex = $('#tt').datagrid('getRows').length - 1;
            $('#tt').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
        }
    }

    function del() {
        if (editIndex == undefined) { return }
        $('#tt').datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);
        editIndex = undefined;

    }

    function save() {
        if (endEditing()) {
            //$('#dg').datagrid('acceptChanges');
            var rows = $('#tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].RoleName.length <= 0) {
                    alert('角色不能为空');
                    //ShowButton();
                    EditGrid(rows[i]);
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].RoleName == rows[j].RoleName) {
                            alert('角色名称出现重复');
                            EditRow(j);
                            return false;
                        }
                    }
                }
            }

            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var delrows = $('#tt').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delrows);
            var updaterows = $('#tt').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updaterows);
            var addrows = $('#tt').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addrows);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../Ashx/Role.ashx',
                data: {
                    'action': 'edit',
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        $('#tt').datagrid("reload");
                        $.messager.show({ title: '提示', msg: "编辑成功！"});
                    }
                    else {
                        $.messager.show({ title: '错误提示', msg: (data=="success"?"保存成功":data) });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                }
            });
        }
    }

    function cancel() {
        $('#tt').datagrid('rejectChanges');
        editIndex = undefined;
    }
</script>
<table id="tt"></table>
<div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" Addshow="0" Delshow="0" Saveshow="0" Cancelshow="0" QSearchshow="0" Exportshow="1" Printshow="1" ASearchshow="1" runat="server" ></toolbar:ToolBar>
    </div>
</asp:Content>
