<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="TemplateType.aspx.cs" Inherits="Maticsoft.Web.Project.Template.TemplateType" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="~/Controls/toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    var editIndex = undefined;

    $(function () {
        //alert();
        $('#tt').datagrid({
            url: '../../Ashx/ProjectTemplate.ashx', //请求数据的页面
            queryParams: { "action": "AllTemplateType" },
            idField: 'sid',
            toolbar: "#tab_toolbar",
            fit: true,
            fitColumns: true,
            striped: true, //True 奇偶行使用不同背景色
            rownumbers: true,
            singleSelect: true,
            columns: [[
            { title: '删除', field: 'del', width: 50, align: 'center', hidden: true,
                formatter: function (value, rowData, rowIndex) {
                    return '<a style="color:red" href="javascript:;" onclick="Show(\'' + rowIndex + '\');"><img src="../js/themes/icons/cancel.png" /></a>';
                }
            },
					{ field: 'name', title: '类型名称', width: 100, sortable: true, editor: "text" },
					{ field: 'remark', title: '备注', width: 300, sortable: true, editor: "text" },
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
            var rows = $('#tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].name.length <= 0) {
                    alert('类型名称不能为空！');
                    EditGrid(rows[i]);
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].name == rows[j].group_name) {
                            alert('类型名称出现重复');
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
                url: '../../Ashx/ProjectTemplate.ashx',
                data: {
                    'action': 'TemplateEdit',
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        $('#tt').datagrid("reload");
                        $.messager.show({ title: '提示', msg: "编辑成功！" });
                    }
                    else {
                        $.messager.show({ title: '错误提示', msg: data });
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
    <toolbar:ToolBar ID="toolbar1" runat="server" ></toolbar:ToolBar>
    </div>
</asp:Content>
