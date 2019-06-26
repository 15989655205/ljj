<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ApproveRole.aspx.cs" Inherits="Maticsoft.Web.Flow.ApproveRole" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    var editIndex = undefined;
    var status_combox = [{ sid: 1, name: "生效" }, { sid: 0, name: "无效"}];
    $(function () {

        InitGrid();
    });

    function InitGrid() {
        $('#tt').datagrid({
            url: '../Ashx/ApproveRole.ashx', //请求数据的页面
            queryParams: { "action": "list" },
            sortName: 'sid',
            sortOrder: 'asc',
            idField: 'sid',
            toolbar: "#tab_toolbar",
            //toolbar:toolbar,
            pageSize: 20,
            pageList: [10, 20, 30, 40, 50, 100],
            fit: true,
            striped: true, //True 奇偶行使用不同背景色
            pagination: true,
            rownumbers: true,
            singleSelect: true,
            remoteSort: false,
            columns: [[
            { field: 'ckb', checkbox: true, hidden: true },
            { title: '删除', field: 'del', width: 50, align: 'center', hidden: true,
                formatter: function (value, rowData, rowIndex) {
                    return '<a style="color:red" href="javascript:;" onclick="Show(\'' + rowIndex + '\');"><img src="../js/themes/icons/cancel.png" /></a>';
                }
            },
					{ field: 'sid', title: '编号', width: 100, sortable: true, hidden: true, halign: 'center' },
					{ field: 'role_name', title: '审批角色名称', width: 200, sortable: true, halign: 'center', editor: { type: 'validatebox', options: { required: true,missingMessage:"必填"}} }, //ditor: "text" },
					{field: 'role_level', title: '等级(值越小权限越大,最高级为1)', width: 300,
					editor: { type: 'numberbox', options: { min: 0, precision: 0, required: true, missingMessage: "必填" }
					}
	},
					{ field: 'role_status', title: '角色状态', width: 200, sortable: true, halign: 'center',
					    editor: { type: 'combobox', options: { data: status_combox, valueField: 'sid', textField: 'name', panelHeight: 'auto', editable: false,required: true,missingMessage:"必选", formatter: function (row) { return '<span class="mlength" style="cursor:pointer">' + row.name + '</span>'; } }
					    },
					    formatter: function (value, row, index) {
					        if (value == 1) {
					            return "生效";
					        } else {
					            return "无效";
					        }
					    }
					}
				]],
            onClickRow: function (index, rowData) {
                EditRow(index);
            }
        });
    }

    function endEditing() {
        if (editIndex == undefined) { return true }
        if ($('#tt').datagrid('validateRow', editIndex)) {
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
            $('#tt').datagrid('appendRow', { role_status: '1' }); //, { status: 'P' });
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
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].role_name == rows[j].role_name) {
                            alert('审批角色名称出现重复');
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
            if (delstr == "[]" && updatestr == "[]" && addstr == "[]") {
                return false;
            } else {
                $.messager.confirm('确认', '是否要保存更改?', function (r) {
                    if (r) {
                        $.ajax({
                            type: "POST",
                            timeout: 30000, //超时时间：30秒
                            url: '../Ashx/ApproveRole.ashx',
                            data: {
                                'action': 'edit',
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
                });
            }
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


