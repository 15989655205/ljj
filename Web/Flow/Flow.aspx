<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Flow.aspx.cs" Inherits="Maticsoft.Web.Flow.Flow" %>
<%@ Register Src="../Controls/Flow/Flow_IDE.ascx" TagName="Flow" TagPrefix="flow" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/datagrid-detailview.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    var isload = false;
    $(function () {
        if (!isload) {
            //                $('#mp').panel({
            //                    fit: true
            //                });
            //$('#cc').layout('panel', 'south').panel('resize', { height: (document.body.clientHeight / 3) });
            //$('#cc').layout('resize');

            //InitMainControl();
            InitGrid();
            isload = true;

        }
    });
//    $(function () {
//        InitGrid();
//    });

    function InitGrid() {

        $('#tt').datagrid({
            url: '../Ashx/Flow.ashx', //请求数据的页面
            queryParams: { "action": "list" },
            sortName: 'type_name',
            sortOrder: 'asc',
            idField: 'sid',
            toolbar: "#tab_toolbar",
            pageSize: 20,
            pageList: [10, 20, 30, 40, 50, 100],
            fit: true,
            striped: true, //True 奇偶行使用不同背景色
            pagination: true,
            rownumbers: true,
            singleSelect: true,
            remoteSort: false,
            fitColumns: true,
            columns: [[
                    { field: 'ckb', checkbox: true,hidden:true },
					{ field: 'sid', title: '编号', width: 60, sortable: true, hidden: true, halign: 'center' },
                    { field: 'type_name', title: '表单类型', width: 200, sortable: true, halign: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
					{ field: 'flow_name', title: '流程名称', width: 200, sortable: true, halign: 'center',
					    formatter: function (value, rowData, rowIndex) {
					        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
					    }
					},
					{ field: 'form_name', title: '适用表单', width: 150, sortable: true, halign: 'center',
					    formatter: function (value, rowData, rowIndex) {
					        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
					    }
					},
					{ field: 'DeptName', title: '适用部门', width: 300, sortable: true, halign: 'center',
					    formatter: function (value, rowData, rowIndex) {
					        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
					    }
					},
					{ field: 'RoleName', title: '适用职位', width: 300, sortable: true, halign: 'center',
					    formatter: function (value, rowData, rowIndex) {
					        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
					    }
					},
					{ field: 'flow_status', title: '状态', width: 60, sortable: true, halign: 'center', align: "center",
					    formatter: function (value, row, index) {
					        if (value == 1) {
					            return "有效";
					        } else {
					            return "无效";
					        }
					    }
					},
					{ field: 'remark', title: '备注', width: 200, sortable: true, halign: 'center' }
				]],
            view: detailview,
            detailFormatter: function (index, row) {
                return '<div style="padding:2px"><table id="ddv-' + index +
'"></table></div>';
            },
            onExpandRow: function (index, row) {
                $('#ddv-' + index).datagrid({
                    url: '../Ashx/Flow.ashx',
                    queryParams: { "action": "sub_list", "sid": row.sid },
                    fitColumns: true,
                    singleSelect: true,
                    sortOrder: 'asc',
                    idField: 'node_no',
                    height: 'auto',
                    columns: [[
							{ field: 'sid', title: 'sid', width: 100, hidden: true },
							{ field: 'node_no', title: '审批节点', width: 50, halign: 'center' },
							{ field: 'node_name', title: '节点名称', width: 100, halign: 'center' },
							{ field: 'node_type_name', title: '节点类型', width: 100, halign: 'center', align: 'center' },
							{ field: 'appr_dept_type', title: '类型', width: 100, halign: 'center', align: 'center'
                            ,
							    formatter: function (value, rowData, rowIndex) {
							        if (value == "0" || value == "跨部门") {
							            return "跨部门";
							        } else {
							            return "同部门";
							        }
							    }
							},
							{ field: 'DeptName', title: '部门', width: 100, halign: 'center', align: 'center',
							    formatter: function (value, rowData, rowIndex) {
							        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
							    }
							},
							{ field: 'RoleName', title: '级别', width: 100, halign: 'center', align: 'center',
							    formatter: function (value, rowData, rowIndex) {
							        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
							    }
							},
							{ field: 'appr_count', title: '方式', width: 100, halign: 'center',
							    formatter: function (value, rowData, rowIndex) {
							        if (value == 0) {
							            return "必须所有人员通过";
							        } else {
							            return "只要一人办理";
							        }
							    }
							},
							{ field: 'appr_time', title: '时间', width: 60, halign: 'center', align: 'center' },
                            { field: 'remark', title: '备注', width: 100, halign: 'center' }

						]],
                    onResize: function () {
                        $('#tt').datagrid('fixDetailRowHeight', index);
                    },
                    onLoadSuccess: function () {
                        setTimeout(function () {
                            $('#tt').datagrid('fixDetailRowHeight', index);
                        }, 0);
                    }
                });
                $('#tt').datagrid('fixDetailRowHeight', index);
            },
            onClickCell: function (rowIndex, field, value) {
                if (field != "ckb") {
                    $('#tt').datagrid('clearSelections');
                }
                if (rowIndex >= 0) {

                    switch (field) {
                        case "edit":
                            break;
                        case "copy":
                            break;
                        case "view":
                            break;
                        default:
                            if (art.dialog.get('flow_ide') != null) {
                                Show(rowIndex);
                            }
                            break;
                    }
                }
            }
        });
    }

    //快速搜索
    function qsearch(v) {
        $('#tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#tt').datagrid('load');
    }

    function add() {
        if (art.dialog.get('flow_ide') != null) {
            art.dialog.get('flow_ide').close();
        }
        openDialog("add", "", "新增审核流程");
    }

    function copy() {
        var row = $('#tt').datagrid('getSelected');
        if (row != null) {
            if (art.dialog.get('flow_ide') != null) {
                art.dialog.get('flow_ide').close();
            }
            var index = $('#tt').datagrid('getRowIndex', row);
            openDialog("copy", index, "新增审核流程");
        }
    }

    //编辑事件
    function edit() {
        var row = $('#tt').datagrid('getSelected');
        if (row != null) {
            if (art.dialog.get('flow_ide') != null) {
                art.dialog.get('flow_ide').close();
            }
            var index = $('#tt').datagrid('getRowIndex', row);
            openDialog("edit", index, '修改审核流程');
        }
    }

//    function del() {
//        if (editIndex == undefined) { return }
//        $('#tt').datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);
//        editIndex = undefined;

//    }

    //批量删除
    function del() {
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                var selected = "";
                $($('#tt').datagrid('getSelections')).each(function () {
                    selected += "'" + this.sid + "',";
                });
                selected = selected.substr(0, selected.length - 1);
                if (selected == "") {
                    $.messager.alert('提示', '请选择要删除的数据！', 'info');
                    return;
                }

                $.post('../Ashx/Flow.ashx', { "action": "dels", "cbx_select": selected }, function (data) {
                    if (data == "success") {
                        $("#tt").datagrid("reload");
                    }
                    else {
                        $.messager.show({ title: '提示', msg: (data=="success"?"保存成功":data) });
                    }
                });
            }
        });
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
                                    $.messager.show({ title: '错误提示', msg: (data=="success"?"保存成功":data) });
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

<%--    <div id="cc" class="easyui-layout" fit="true" border="false">
        <div region="south" title="Detail" border="false" split="true">
            <table id="t_sub">
            </table>
        </div>
        <div region="center" title="" border="false">--%>
<table id="tt"></table>
<div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" Addshow="0" Editshow="0" Delshow="0"  Copyshow="0" QSearchshow="0" Exportshow="1" Printshow="1" ASearchshow="1" runat="server" ></toolbar:ToolBar>
    </div>

    <div id="edit" style="display:none;">
        <flow:Flow ID="flow_ide" runat="server"></flow:Flow>
    </div>
<%--       </div>
    </div>--%>
</asp:Content>



