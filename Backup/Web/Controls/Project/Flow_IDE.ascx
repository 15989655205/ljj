<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Flow_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.Project.Flow_IDE" %>
<script type="text/javascript">
    var flow_editIndex = undefined;
    var flow_isEdit = false;
    var flow_pssid;
    var flow_p_sid;
    var oldRows;
    $(function () {
    });

    function flow_Left() {
        $('#flow_left').tree({
            url: '../Ashx/ProjectStage.ashx?action=flowModelList',
            onClick: function (node) {
                //alert(node.text);  // alert node text property when clicked
                var row = $('#flow_tt').datagrid('getRows');
                var ishave = false;
                for (var i = 0; i < row.length; i++) {
                    if (row[i].work_flow_name == node.text) {
                        ishave = true;
                        break;
                    }
                }
                if (!ishave) {
                    if (!flow_isEdit) {
                        flow_btnSave();
                        flow_isEdit = true;
                    }
                    $('#flow_tt').datagrid('appendRow', { s_sid: flow_pssid, work_flow_name: node.text, remark: '', sequence: $('#flow_tt').datagrid('getRows').length, sid: 0 });
                }
            }

        });
    }

    function flow_Grid(row) {
        $('#flow_tt').datagrid({
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { "action": "flow_list", "s_sid": row.sid,'p_sid':row.p_sid },
            idField: 'sid',
            fit: true,
            striped: true, //True 奇偶行使用不同背景色
            singleSelect: true,
            remoteSort: false,
            fitColumns: true,
            rownumbers: true,
            columns: [[

					{ field: 'work_flow_name', title: '工作流程名称', width: 100, sortable: true, editor: "text" }
					, { field: 'remark', title: '备注', width: 200, sortable: true, editor: "text" }
                    , { field: 'sid', title: '编号', editor: "text", hidden: true }
                    , { field: 'sequence', title: '排序', hidden: true }
				]],
            toolbar: "#flow_menu",
            onLoadSuccess: function (data) {

            },
            onClickRow: function (index, rowData) {
                if (!flow_isEdit) {
                    flow_isEdit = true;
                    flow_btnSave();
                }
                flow_EditRow(index);

            },
            onRowContextMenu: function (e, rowIndex, rowData) {
                e.preventDefault();
                var selected = $("#flow_tt").datagrid('getRows'); //获取所有行集合对象
                var idValue = selected[rowIndex].sid;
                $(this).datagrid('selectRecord', idValue);  //通过获取到的id的值做参数选中一行
                $('#flow_mm').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });
            }
        });
    }

    function flow_endEditing() {
        if (flow_editIndex == undefined) { return true }
        if ($('#flow_tt').datagrid('validateRow', flow_editIndex)) {
            //var ed = $('#tt').datagrid('getEditor', { index: flow_editIndex, field: 'RoleName' });
            //var productname = $(ed.target).combobox('getText');
            //$('#tt').datagrid('getRows')[flow_editIndex]['productname'] = productname;
            $('#flow_tt').datagrid('endEdit', flow_editIndex);
            flow_editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function flow_EditRow(index) {
        if (flow_editIndex != index) {
            if (flow_endEditing()) {
                $('#flow_tt').datagrid('selectRow', index).datagrid('beginEdit', index);
                var edt = $('#flow_tt').datagrid('getEditors', index);
                edt[0].target.attr('disabled', true);
//                edt[1].target.attr('disabled', true);
                flow_editIndex = index;
            } else {
                $('#flow_tt').datagrid('selectRow', flow_editIndex);
            }
        }
    }

    function flow_EditGrid(row) {
        var index = $('#flow_tt').datagrid('getRowIndex', row);
        $('#flow_tt').datagrid('beginEdit', index);
        var editors = $('#flow_tt').datagrid('getEditors', index);
        flow_editIndex = index;
    }

    function flow_openDialog(index, title) {
        var lock = true;
        var rows = $('#sub_tt').datagrid('getRows');
        var row = rows[index];
        if (art.dialog.list['flow_dialog'] == null) {
            art.dialog({
                content: document.getElementById('flow_edit'),
                id: 'flow_dialog',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                lock: lock,
                init: function () {
                    flow_pssid = row.sid;
                    flow_p_sid=row.p_sid;
                    flow_Grid(row);
                    flow_Left();
                    flow_btnCancel();
                },
                close: function () {
                    flow_endEditing();
                    var changerows = $('#flow_tt').datagrid('getChanges');
                    if (changerows.length > 0) {
                        if (confirm("内容有更改，您确认不保存直接关闭吗?")) {
                            flow_isEdit = false;
                            //flow_Grid(row)
                            return true;
                        } else {
                            return false;
                        }
                    }
                    else {
                        return true;
                    }
                    //return false;
                }
            });
        }
        else {
            art.dialog.list['flow_dialog'].content(document.getElementById('flow_edit'));
        }
    }

    //快速搜索
    function flow_qsearch(v) {
        $('#flow_tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#flow_tt').datagrid('load');
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

    function flow_add() {
        if (!flow_isEdit) {
            flow_btnSave();
            flow_isEdit = true;
        }
        if (flow_endEditing()) {
            $('#flow_tt').datagrid('appendRow', { ps_sid: flow_pssid, sequence: $('#flow_tt').datagrid('getRows').length, sid: 0 }); //, { status: 'P' });
            flow_editIndex = $('#flow_tt').datagrid('getRows').length - 1;
            $('#flow_tt').datagrid('selectRow', flow_editIndex).datagrid('beginEdit', flow_editIndex);
        }
    }

    function flow_insert() {
        //alert();
        if (!flow_isEdit) {
            flow_btnSave();
            flow_isEdit = true;
        }
        var FocusRow = $('#flow_tt').datagrid('getSelected');
        var curIndex = $('#flow_tt').datagrid('getRowIndex', FocusRow);
        //alert(curIndex);
        if (flow_endEditing()) {
            //alert($('#flow_tt').datagrid('getRows').length - curIndex);
            for (var i = (curIndex + 1); i < ($('#flow_tt').datagrid('getRows').length); i++) {
                //alert(i);
                //$('#flow_tt').datagrid('beginEdit', i);
                $('#flow_tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i + 1 }
                });
                //                //$('#flow_tt').datagrid('endEdit', i);
            }
            //$('#flow_tt').datagrid('selectRow', curIndex + 1).datagrid('beginEdit', curIndex + 1);
            //            $('#flow_tt').datagrid('updateRow', {
            //                index: curIndex + 1,
            //                row: { flow_name: 'test', sequence: curIndex + 2 }
            //            });
            //$('#flow_tt').datagrid('selectRow', curIndex + 1).datagrid('endEdit', curIndex + 1);

            $('#flow_tt').datagrid('insertRow', { index: curIndex + 1, row: { ps_sid: flow_pssid, sequence: curIndex + 1, sid: 0} });  //, { status: 'P' });

            flow_editIndex = curIndex + 1;  //$('#flow_tt').datagrid('getRows').length - 1;
            $('#flow_tt').datagrid('selectRow', flow_editIndex).datagrid('beginEdit', flow_editIndex);
        }
    }

    function flow_update() {
        flow_btnSave();
        flow_isEdit = true;
    }

    function flow_del() {
        if (!flow_isEdit) {
            flow_btnSave();
        }
        if (flow_editIndex == undefined) { return }
        var row = $('#flow_tt').datagrid('getSelected');
        //alert(row.sid);
        if (row.sid != null || row.sid == 0) {
            //alert();
            $.ajax({
                type: "POST",
                async: false,
                url: '../Ashx/Project.ashx',
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
                        for (var i = (flow_editIndex + 1); i < ($('#flow_tt').datagrid('getRows').length); i++) {
                            //alert(i);
                            //$('#flow_tt').datagrid('beginEdit', i);
                            $('#flow_tt').datagrid('updateRow', {
                                index: i,
                                row: { sequence: i - 1 }
                            });
                            //$('#flow_tt').datagrid('endEdit', i);
                        }

                        $('#flow_tt').datagrid('cancelEdit', flow_editIndex).datagrid('deleteRow', flow_editIndex);

                        flow_editIndex = undefined;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    return;
                }
            });
        } else {

            for (var i = (flow_editIndex + 1); i < ($('#flow_tt').datagrid('getRows').length); i++) {
                //alert(i);
                //$('#flow_tt').datagrid('beginEdit', i);
                $('#flow_tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i - 1 }
                });
                //$('#flow_tt').datagrid('endEdit', i);
            }

            $('#flow_tt').datagrid('cancelEdit', flow_editIndex).datagrid('deleteRow', flow_editIndex);

            flow_editIndex = undefined;
        }
    }

    function flow_MoveRow(fx) {
        var gd = $('#flow_tt');
        var gdData = gd.datagrid("getData");
        if (gdData.rows.length < 2) return;
        var iMovedRowIndex = -1;
        var FocusRow = gd.datagrid('getSelected');
        if (!FocusRow) {
            alert("没有行被选中,无法执行移动操作");
            return;
        }
        var iCurRowIndex = gd.datagrid('getRowIndex', FocusRow);
        if (!flow_isEdit) {
            flow_isEdit = true;
            flow_btnSave();
        }
        flow_EditRow(iCurRowIndex);
        iMovedRowIndex = iCurRowIndex + fx;
        if (iCurRowIndex === 0 && fx === -1) return; //iMovedRowIndex = gdData.rows.length - 1;
        if (iCurRowIndex === gdData.rows.length - 1 && fx === 1) return; //iMovedRowIndex = 0;
        var RowTemp = { work_flow_name: "", remark: "", sequence: "", sid: "" };
        RowTemp.work_flow_name = gdData.rows[iMovedRowIndex].work_flow_name;
        RowTemp.remark = gdData.rows[iMovedRowIndex].remark;
        RowTemp.sequence = gdData.rows[iMovedRowIndex].sequence;
        RowTemp.sid = gdData.rows[iMovedRowIndex].sid;

        gdData.rows[iMovedRowIndex].work_flow_name = gdData.rows[iCurRowIndex].work_flow_name;
        gdData.rows[iMovedRowIndex].remark = gdData.rows[iCurRowIndex].remark;
        //gdData.rows[iMovedRowIndex].sequence = gdData.rows[iCurRowIndex].sequence;
        gdData.rows[iMovedRowIndex].sid = gdData.rows[iCurRowIndex].sid;

        //gdData.rows[iMovedRowIndex].sequence = gdData.rows[iCurRowIndex].sequence;
        //gdData.rows[iCurRowIndex].sid = RowTemp.sid;
        var edt = gd.datagrid("getEditors", iCurRowIndex);
        edt[0].target.val(RowTemp.work_flow_name);
        
        edt[1].target.val(RowTemp.remark);
        edt[2].target.val(RowTemp.sid);
        //edt[3].target.val(RowTemp.sid);

        gd.datagrid('endEdit', iCurRowIndex);
        gd.datagrid('unselectRow', iCurRowIndex);
        gd.datagrid('selectRow', iMovedRowIndex);
        gd.datagrid('beginEdit', iMovedRowIndex);
        var edt = gd.datagrid("getEditors", iMovedRowIndex);
        edt[0].target.attr('disabled', true);
        flow_editIndex = iMovedRowIndex;
        gd = null;
    }

    function flow_save() {

        flow_isEdit = false;

        if (flow_endEditing()) {
            var rows = $('#flow_tt').datagrid('getRows');
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

            var allRows = $('#flow_tt').datagrid('getRows');
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allstr = "";

            allstr = JSON.stringify(allRows);
           // alert(allstr);
            var delrows = $('#flow_tt').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delrows);
            var updaterows = $('#flow_tt').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updaterows);
            var addrows = $('#flow_tt').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addrows);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../Ashx/Project.ashx',
                data: {
                    'action': 'flow_edit',
                    'allstr': allstr,
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr,
                    's_sid': flow_pssid,
                    'p_sid':flow_p_sid
                },
                success: function (data) {
                    if (data == "success") {
                        $('#flow_tt').datagrid("reload");
                        flow_btnCancel();
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
    }

    function flow_cancel() {
        flow_btnCancel();
        flow_isEdit = false;
        $('#flow_tt').datagrid('rejectChanges');
        flow_editIndex = undefined;
    }
</script>
<div style="width:600px; height:400px;">
 <div id="flow_menu" style="padding:2px;border:1px solid #ddd; background-color:#F4F4F4">
<%--		<a href="#" id="flow_add" onclick="flow_add()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'">新增</a>
--%>		<a href="#" id="flow_update" style="display:none;" onclick="flow_update()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-edit'">修改</a>
		<a href="#" id="flow_del" onclick="flow_del()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'">删除</a>
        <a href="#" id="flow_up" onclick="flow_MoveRow(-1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-up'">上移</a>
        <a href="#" id="flow_down" onclick="flow_MoveRow(1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-down'">下移</a>
		<a href="#" id="flow_save" onclick="flow_save()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="#" id="flow_cancel" onclick="flow_cancel()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-undo'">取消</a>
	</div>


    <div id="flow_mm" class="easyui-menu" style="width:120px;">
    <div onclick="flow_insert()" data-options="iconCls:'icon-add'">插入行</div>
</div>

<div id="flow_cc" class="easyui-layout" fit="true">   
    <div data-options="region:'west',title:''" style="width:180px;"><ul id="flow_left" style="height:300px;"></ul></div>  
    <div data-options="region:'center',title:''" style="" ><table id="flow_tt"></table></div>  
</div>  



</div>