<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Work_flow.aspx.cs" Inherits="Maticsoft.Web.Project.Template.Work_flow" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="~/Controls/toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    var flow_editIndex = undefined;
    var flow_isEdit = false;
    var flow_pssid;
    var oldRows;
    $(function () {
        $('#tt').datagrid({
            url: '../../Ashx/Model_zxf.ashx',
            queryParams: { 'action': 'allWorkFlow' },
            fit: true,
            fitColumns: true,
            idField: 'id',

            striped: true,
            singleSelect: true,
            remoteSort: false,
            toolbar: "#tab_toolbar",
            rownumbers: true,
            singleSelect: true,
            remoteSort: false,
            columns: [[
                { field: 'work_flow_name', title: '名称', editor: "text", width: 100 },
                { field: 'remark', title: '备注', editor: "text", width: 300 },
                { field: 'id', title: '编号', editor: "text" ,hidden:true},
                { field: 'SN', title: '排序', hidden: true },
                 { field: 'create_person', title: '创建人', width: 100, sortable: true },
                    { field: 'create_date', title: '创建时间', width: 100, sortable: true },
                    { field: 'update_person', title: '变更人', width: 100, sortable: true },
                    { field: 'update_date', title: '变更时间', width: 100, sortable: true }
            ]],
            onClickRow: function (index, rowData) {
                if (!flow_isEdit) {
                    flow_isEdit = true;
                    flow_btnSave();
                }
                flow_EditRow(index);

            },
            onRowContextMenu: function (e, rowIndex, rowData) {
                e.preventDefault();
                var selected = $("#tt").datagrid('getRows'); //获取所有行集合对象
                var idValue = selected[rowIndex].id;
                $(this).datagrid('selectRecord', idValue);  //通过获取到的id的值做参数选中一行
                $('#flow_mm').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });
            }
        })
    })
    function flow_endEditing() {
        if (flow_editIndex == undefined) { return true }
        if ($('#tt').datagrid('validateRow', flow_editIndex)) {
            //var ed = $('#tt').datagrid('getEditor', { index: flow_editIndex, field: 'RoleName' });
            //var productname = $(ed.target).combobox('getText');
            //$('#tt').datagrid('getRows')[flow_editIndex]['productname'] = productname;
            $('#tt').datagrid('endEdit', flow_editIndex);
            flow_editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function flow_EditRow(index) {
        if (flow_editIndex != index) {
            if (flow_endEditing()) {
                $('#tt').datagrid('selectRow', index).datagrid('beginEdit', index);
                flow_editIndex = index;
            } else {
                $('#tt').datagrid('selectRow', flow_editIndex);
            }
        }
    }

    function flow_EditGrid(row) {
        var index = $('#tt').datagrid('getRowIndex', row);
        $('#tt').datagrid('beginEdit', index);
        var editors = $('#tt').datagrid('getEditors', index);
        flow_editIndex = index;
    }
    //快速搜索
    function flow_qsearch(v) {
        $('#tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#tt').datagrid('load');
    }

    function flow_btnSave() {
        //$('#flow_add').linkbutton("disable");
        //$('#flow_update').linkbutton("disable");
        //$('#flow_del').linkbutton("disable");
        $('#flow_save').linkbutton("enable");
        $('#flow_cancel').linkbutton("enable");
    }

    function flow_btnCancel() {
        //$('#flow_add').linkbutton("enable");
        //$('#flow_update').linkbutton("enable");
        //$('#flow_del').linkbutton("enable");
        $('#flow_save').linkbutton("disable");
        $('#flow_cancel').linkbutton("disable");
    }

    function add() {
        if (!flow_isEdit) {
            flow_btnSave();
            flow_isEdit = true;
        }
        if (flow_endEditing()) {
            $('#tt').datagrid('appendRow', {  SN: $('#tt').datagrid('getRows').length ,id:0}); //, { status: 'P' });
            flow_editIndex = $('#tt').datagrid('getRows').length - 1;
            $('#tt').datagrid('selectRow', flow_editIndex).datagrid('beginEdit', flow_editIndex);
        }
    }

    function flow_insert() {
        //alert();
        if (!flow_isEdit) {
            flow_btnSave();
            flow_isEdit = true;
        }
        var FocusRow = $('#tt').datagrid('getSelected');
        var curIndex = $('#tt').datagrid('getRowIndex', FocusRow);
        //alert(curIndex);
        if (flow_endEditing()) {
            //alert($('#tt').datagrid('getRows').length - curIndex);
            for (var i = (curIndex + 1); i < ($('#tt').datagrid('getRows').length); i++) {
                //alert(i);
                //$('#tt').datagrid('beginEdit', i);
                $('#tt').datagrid('updateRow', {
                    index: i,
                    row: { SN: i + 1 }
                });
                //                //$('#tt').datagrid('endEdit', i);
            }
            //$('#tt').datagrid('selectRow', curIndex + 1).datagrid('beginEdit', curIndex + 1);
            //            $('#tt').datagrid('updateRow', {
            //                index: curIndex + 1,
            //                row: { flow_name: 'test', sequence: curIndex + 2 }
            //            });
            //$('#tt').datagrid('selectRow', curIndex + 1).datagrid('endEdit', curIndex + 1);

            $('#tt').datagrid('insertRow', { index: curIndex + 1, row: {  SN: curIndex + 1,id:0} });  //, { status: 'P' });

            flow_editIndex = curIndex + 1;  //$('#tt').datagrid('getRows').length - 1;
            $('#tt').datagrid('selectRow', flow_editIndex).datagrid('beginEdit', flow_editIndex);
        }
    }

    function flow_update() {
        flow_btnSave();
        flow_isEdit = true;
    }

    function del() {
        if (!flow_isEdit) {
            flow_btnSave();
        }
        if (flow_editIndex == undefined) { return }
        var row = $('#tt').datagrid('getSelected');
        //alert(row.sid);
        if (row.sid != null || row.sid == 0) {
            //alert();
            $.ajax({
                type: "POST",
                async: false,
                url: '../../Ashx/ProjectStage.ashx',
                data: {
                    'action': 'flow_del_check',
                    'sid': row.sid
                },
                success: function (data) {
                    if (data == "1") {
                        $.messager.show({ title: '提示', msg: "已经有项目内容调用，不能删除！" });
                        return;
                    }
                    else {
                        for (var i = (flow_editIndex + 1); i < ($('#tt').datagrid('getRows').length); i++) {
                            //alert(i);
                            //$('#tt').datagrid('beginEdit', i);
                            $('#tt').datagrid('updateRow', {
                                index: i,
                                row: { sequence: i - 1 }
                            });
                            //$('#tt').datagrid('endEdit', i);
                        }

                        $('#tt').datagrid('cancelEdit', flow_editIndex).datagrid('deleteRow', flow_editIndex);

                        flow_editIndex = undefined;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    return;
                }
            });
        } else {

            for (var i = (flow_editIndex + 1); i < ($('#tt').datagrid('getRows').length); i++) {
                //alert(i);
                //$('#tt').datagrid('beginEdit', i);
                $('#tt').datagrid('updateRow', {
                    index: i,
                    row: { SN: i - 1 }
                });
                //$('#tt').datagrid('endEdit', i);
            }

            $('#tt').datagrid('cancelEdit', flow_editIndex).datagrid('deleteRow', flow_editIndex);

            flow_editIndex = undefined;
        }
    }

    function MoveRow(fx) {
        var gd = $('#tt');
        var gdData = gd.datagrid("getData");
        if (gdData.rows.length < 2) return;
        var iMovedRowIndex = -1;
        var FocusRow = gd.datagrid('getSelected');
        if (!FocusRow) {
            alert("没有行被选中,无法执行移动操作");
            return;
        }
        var iCurRowIndex = gd.datagrid('getRowIndex', FocusRow);
        iMovedRowIndex = iCurRowIndex + fx;
        if (iCurRowIndex === 0 && fx === -1) return; //iMovedRowIndex = gdData.rows.length - 1;
        if (iCurRowIndex === gdData.rows.length - 1 && fx === 1) return; //iMovedRowIndex = 0;
        var RowTemp = { work_flow_name: "", remark: "", id: "" };
        RowTemp.work_flow_name = gdData.rows[iMovedRowIndex].work_flow_name;
        RowTemp.remark = gdData.rows[iMovedRowIndex].remark;
//        RowTemp.SN = gdData.rows[iMovedRowIndex].SN;
        RowTemp.id = gdData.rows[iMovedRowIndex].id;

        gdData.rows[iMovedRowIndex].work_flow_name = gdData.rows[iCurRowIndex].work_flow_name;
        gdData.rows[iMovedRowIndex].remark = gdData.rows[iCurRowIndex].remark;
//        gdData.rows[iMovedRowIndex].SN = gdData.rows[iCurRowIndex].SN;
        gdData.rows[iMovedRowIndex].id = gdData.rows[iCurRowIndex].id;

        //gdData.rows[iMovedRowIndex].sequence = gdData.rows[iCurRowIndex].sequence;
        //gdData.rows[iCurRowIndex].sid = RowTemp.sid;
        var edt = gd.datagrid("getEditors", iCurRowIndex);
        edt[0].target.val(RowTemp.work_flow_name);
        edt[1].target.val(RowTemp.remark);
//        edt[2].target.val(RowTemp.SN);
        edt[2].target.val(RowTemp.id);

        gd.datagrid('endEdit', iCurRowIndex);
        gd.datagrid('unselectRow', iCurRowIndex);
        gd.datagrid('selectRow', iMovedRowIndex);
        gd.datagrid('beginEdit', iMovedRowIndex);
        flow_editIndex = iMovedRowIndex;
        gd = null;
    }

    function save() {

        flow_isEdit = false;

        if (flow_endEditing()) {
            var rows = $('#tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].work_flow_name.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "工作流程名称不能为空" });
                    flow_EditGrid(rows[i]);
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].work_flow_name == rows[j].work_flow_name) {
                            $.messager.show({ title: '错误提示', msg: "工作流程名称不能重复" });
                            flow_EditRow(j);
                            return false;
                        }
                    }
                }
            }

            var allRows = $('#tt').datagrid('getRows');
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allstr = "";

            allstr = JSON.stringify(allRows);
            var delrows = $('#tt').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delrows);
            var updaterows = $('#tt').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updaterows);
            var addrows = $('#tt').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addrows);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../../Ashx/Model_zxf.ashx',
                data: {
                    'action': 'flow_edit',
                    'allstr': allstr,
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        $('#tt').datagrid("reload");
                        flow_btnCancel();
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
        flow_btnCancel();
        flow_isEdit = false;
        $('#tt').datagrid('rejectChanges');
        flow_editIndex = undefined;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<toolbar:ToolBar ID="toolbar" runat="server"/>
<table id="tt"></table>
 <div id="flow_mm" class="easyui-menu" style="width:120px;">
    <div onclick="flow_insert()" data-options="iconCls:'icon-add'">插入行</div>
</div>
</asp:Content>
