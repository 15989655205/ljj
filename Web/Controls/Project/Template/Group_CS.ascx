<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Group_CS.ascx.cs" Inherits="Maticsoft.Web.Controls.Project.Template.Group_CS" %>

<script type="text/javascript">
    var group_editIndex = undefined;
    var group_isEdit = false;
    var group_pssid;
    var oldRows;
    $(function () {
    });

    function group_Left() {
        $('#group_left').tree({
            url: '../../Ashx/ProjectStage.ashx?action=groupModelList',
            onClick: function (node) {
                //alert(node.text);  // alert node text property when clicked
                var row = $('#group_tt').datagrid('getRows');
                var ishave = false;
                for (var i = 0; i < row.length; i++) {
                    if (row[i].group_name == node.text) {
                        ishave = true;
                        break;
                    }
                }
                if (!ishave) {
                    if (!group_isEdit) {
                        group_btnSave();
                        group_isEdit = true;
                    }
                    $('#group_tt').datagrid('appendRow', { ps_sid: group_pssid, group_name: node.text, remark: '', sequence: $('#group_tt').datagrid('getRows').length, sid: 0 });
                }
            }

        });
    }

    function group_Grid(row) {
        $('#group_tt').datagrid({
            url: '../../Ashx/ProjectStage.ashx', //请求数据的页面
            queryParams: { "action": "group_list", "ssid": row.sid },
            idField: 'sid',
            fit: true,
            striped: true, //True 奇偶行使用不同背景色
            singleSelect: true,
            remoteSort: false,
            fitColumns: true,
            rownumbers: true,
            columns: [[

					{ field: 'group_name', title: '小组名称', width: 100, sortable: true , editor: "text" }
					, { field: 'remark', title: '备注', width: 200, sortable: true, editor: "text" }
                    , { field: 'sid', title: '编号', editor: "text", hidden: true }
                    , { field: 'sequence', title: '排序', hidden: true }
				]],
            toolbar: "#group_menu",
            onLoadSuccess: function (data) {

            },
            onClickRow: function (index, rowData) {
                if (!group_isEdit) {
                    group_isEdit = true;
                    group_btnSave();
                }
                group_EditRow(index);

            },
            onRowContextMenu: function (e, rowIndex, rowData) {
                e.preventDefault();
                var selected = $("#group_tt").datagrid('getRows'); //获取所有行集合对象
                var idValue = selected[rowIndex].sid;
                $(this).datagrid('selectRecord', idValue);  //通过获取到的id的值做参数选中一行
                $('#group_mm').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });
            }
        });
    }

    function group_endEditing() {
        if (group_editIndex == undefined) { return true }
        if ($('#group_tt').datagrid('validateRow', group_editIndex)) {
            //var ed = $('#tt').datagrid('getEditor', { index: group_editIndex, field: 'RoleName' });
            //var productname = $(ed.target).combobox('getText');
            //$('#tt').datagrid('getRows')[group_editIndex]['productname'] = productname;
            $('#group_tt').datagrid('endEdit', group_editIndex);
            group_editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function group_EditRow(index) {
        if (group_editIndex != index) {
            if (group_endEditing()) {
                $('#group_tt').datagrid('selectRow', index).datagrid('beginEdit', index);
                var editor = $('#group_tt').datagrid('getEditor', { index: index, field: 'group_name' });
                $(editor.target).attr('disabled', true);
                group_editIndex = index;
            } else {
                $('#group_tt').datagrid('selectRow', group_editIndex);
            }
        }
    }

    function group_EditGrid(row) {
        var index = $('#group_tt').datagrid('getRowIndex', row);
        $('#group_tt').datagrid('beginEdit', index);
        var editors = $('#group_tt').datagrid('getEditors', index);
        group_editIndex = index;
    }

    function group_openDialog(index, title) {
        var lock = true;
        var rows = $('#tt').datagrid('getRows');
        var row = rows[index];
        if (art.dialog.list['group_dialog'] == null) {
            art.dialog({
                content: document.getElementById('group_edit'),
                id: 'group_dialog',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                lock: lock,
                init: function () {
                    group_pssid = row.sid
                    group_Grid(row);
                    group_Left();
                    group_btnCancel();
                },
                close: function () {
                    group_endEditing();
                    var changerows = $('#group_tt').datagrid('getChanges');
                    if (changerows.length > 0) {
                        if (confirm("内容有更改，您确认不保存直接关闭吗?")) {
                            group_isEdit = false;
                            //group_Grid(row)
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
            art.dialog.list['group_dialog'].content(document.getElementById('group_edit'));
        }
    }

    //快速搜索
    function group_qsearch(v) {
        $('#group_tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#group_tt').datagrid('load');
    }

    function group_btnSave() {
        //$('#group_add').linkbutton("disable");
        //$('#group_update').linkbutton("disable");
        //$('#group_del').linkbutton("disable");
        $('#group_save').linkbutton("enable");
        $('#group_cancel').linkbutton("enable");
    }

    function group_btnCancel() {
        //$('#group_add').linkbutton("enable");
        //$('#group_update').linkbutton("enable");
        //$('#group_del').linkbutton("enable");
        $('#group_save').linkbutton("disable");
        $('#group_cancel').linkbutton("disable");
    }

    function group_add() {
        if (!group_isEdit) {
            group_btnSave();
            group_isEdit = true;
        }
        if (group_endEditing()) {
            $('#group_tt').datagrid('appendRow', { ps_sid: group_pssid, sequence: $('#group_tt').datagrid('getRows').length, sid: 0 }); //, { status: 'P' });
            group_editIndex = $('#group_tt').datagrid('getRows').length - 1;
            $('#group_tt').datagrid('selectRow', group_editIndex).datagrid('beginEdit', group_editIndex);
        }
    }

    function group_insert() {
        //alert();
        if (!group_isEdit) {
            group_btnSave();
            group_isEdit = true;
        }
        var FocusRow = $('#group_tt').datagrid('getSelected');
        var curIndex = $('#group_tt').datagrid('getRowIndex', FocusRow);
        //alert(curIndex);
        if (group_endEditing()) {
            //alert($('#group_tt').datagrid('getRows').length - curIndex);
            for (var i = (curIndex + 1); i < ($('#group_tt').datagrid('getRows').length); i++) {
                //alert(i);
                //$('#group_tt').datagrid('beginEdit', i);
                $('#group_tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i + 1 }
                });
                //                //$('#group_tt').datagrid('endEdit', i);
            }
            //$('#group_tt').datagrid('selectRow', curIndex + 1).datagrid('beginEdit', curIndex + 1);
            //            $('#group_tt').datagrid('updateRow', {
            //                index: curIndex + 1,
            //                row: { group_name: 'test', sequence: curIndex + 2 }
            //            });
            //$('#group_tt').datagrid('selectRow', curIndex + 1).datagrid('endEdit', curIndex + 1);

            $('#group_tt').datagrid('insertRow', { index: curIndex + 1, row: { ps_sid: group_pssid, sequence: curIndex + 1, sid: 0} });  //, { status: 'P' });

            group_editIndex = curIndex + 1;  //$('#group_tt').datagrid('getRows').length - 1;
            $('#group_tt').datagrid('selectRow', group_editIndex).datagrid('beginEdit', group_editIndex);
        }
    }

    function group_update() {
        group_btnSave();
        group_isEdit = true;
    }

    function group_del() {
        if (!group_isEdit) {
            group_btnSave();
        }
        if (group_editIndex == undefined) { return }
        var row = $('#group_tt').datagrid('getSelected');
        //alert(row.sid);
        if (row.sid != null || row.sid == 0) {
            //alert();
            $.ajax({
                type: "POST",
                async: false,
                url: '../../Ashx/ProjectStage.ashx',
                data: {
                    'action': 'group_del_check',
                    'sid': row.sid
                },
                success: function (data) {
                    if (data == "1") {
                        $.messager.show({ title: '提示', msg: "已经有项目内容调用，不能删除！" });
                        return;
                    }
                    else {
                        for (var i = (group_editIndex + 1); i < ($('#group_tt').datagrid('getRows').length); i++) {
                            //alert(i);
                            //$('#group_tt').datagrid('beginEdit', i);
                            $('#group_tt').datagrid('updateRow', {
                                index: i,
                                row: { sequence: i - 1 }
                            });
                            //$('#group_tt').datagrid('endEdit', i);
                        }

                        $('#group_tt').datagrid('cancelEdit', group_editIndex).datagrid('deleteRow', group_editIndex);

                        group_editIndex = undefined;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    return;
                }
            });
        } else {

            for (var i = (group_editIndex + 1); i < ($('#group_tt').datagrid('getRows').length); i++) {
                //alert(i);
                //$('#group_tt').datagrid('beginEdit', i);
                $('#group_tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i - 1 }
                });
                //$('#group_tt').datagrid('endEdit', i);
            }

            $('#group_tt').datagrid('cancelEdit', group_editIndex).datagrid('deleteRow', group_editIndex);

            group_editIndex = undefined;
        }
    }

    function group_MoveRow(fx) {
        var gd = $('#group_tt');
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
        var RowTemp = { group_name: "", remark: "", sequence: "", sid: "" };
        RowTemp.group_name = gdData.rows[iMovedRowIndex].group_name;
        RowTemp.remark = gdData.rows[iMovedRowIndex].remark;
        RowTemp.sequence = gdData.rows[iMovedRowIndex].sequence;
        RowTemp.sid = gdData.rows[iMovedRowIndex].sid;

        gdData.rows[iMovedRowIndex].group_name = gdData.rows[iCurRowIndex].group_name;
        gdData.rows[iMovedRowIndex].remark = gdData.rows[iCurRowIndex].remark;
        //gdData.rows[iMovedRowIndex].sequence = gdData.rows[iCurRowIndex].sequence;
        gdData.rows[iMovedRowIndex].sid = gdData.rows[iCurRowIndex].sid;

        //gdData.rows[iMovedRowIndex].sequence = gdData.rows[iCurRowIndex].sequence;
        //gdData.rows[iCurRowIndex].sid = RowTemp.sid;
        var edt = gd.datagrid("getEditors", iCurRowIndex);
        edt[0].target.val(RowTemp.group_name);
        edt[1].target.val(RowTemp.remark);
        edt[2].target.val(RowTemp.sid);
        //edt[3].target.val(RowTemp.sid);

        gd.datagrid('endEdit', iCurRowIndex);
        gd.datagrid('unselectRow', iCurRowIndex);
        gd.datagrid('selectRow', iMovedRowIndex);
        gd.datagrid('beginEdit', iMovedRowIndex);
        var editor = $('#group_tt').datagrid('getEditor', { index: iMovedRowIndex, field: 'group_name' });
        $(editor.target).attr('disabled', true);
        group_editIndex = iMovedRowIndex;
        gd = null;
    }

    function group_save() {

        group_isEdit = false;

        if (group_endEditing()) {
            var rows = $('#group_tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].group_name.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "小组名称不能为空" });
                    group_EditGrid(rows[i]);
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].group_name == rows[j].group_name) {
                            $.messager.show({ title: '错误提示', msg: "小组名称不能重复" });
                            group_EditRow(j);
                            return false;
                        }
                    }
                }
            }

            var allRows = $('#group_tt').datagrid('getRows');
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allstr = "";

            allstr = JSON.stringify(allRows);
            var delrows = $('#group_tt').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delrows);
            var updaterows = $('#group_tt').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updaterows);
            var addrows = $('#group_tt').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addrows);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../../Ashx/ProjectStage.ashx',
                data: {
                    'action': 'group_edit',
                    'allstr': allstr,
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        $('#group_tt').datagrid("reload");
                        group_btnCancel();
                        $.messager.show({ title: '提示', msg: "编辑成功！" });
                    }
                    else {
                        $.messager.show({ title: '错误提示', msg: (data == "success" ? "保存成功" : data) });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                }
            });
        }
    }

    function group_cancel() {
        group_btnCancel();
        group_isEdit = false;
        $('#group_tt').datagrid('rejectChanges');
        group_editIndex = undefined;
    }
</script>
<div style="width:600px; height:400px;">
 <div id="group_menu" style="padding:2px;border:1px solid #ddd; background-color:#F4F4F4">		
		<%--<a href="#" id="group_update" style="display:none;" onclick="group_update()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-edit'">修改</a>--%>
		<a href="#" id="group_del" onclick="group_del()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'">删除</a>
        <a href="#" id="group_up" onclick="group_MoveRow(-1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-up'">上移</a>
        <a href="#" id="group_down" onclick="group_MoveRow(1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-down'">下移</a>
		<a href="#" id="group_save" onclick="group_save()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="#" id="group_cancel" onclick="group_cancel()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-undo'">取消</a>
	</div>


    <div id="group_mm" class="easyui-menu" style="width:120px;">
    <div onclick="group_insert()" data-options="iconCls:'icon-add'">插入行</div>
</div>

<div id="group_cc" class="easyui-layout" fit="true">   
    <div data-options="region:'west',title:''" style="width:180px;"><ul id="group_left" style="height:300px;"></ul></div>  
    <div data-options="region:'center',title:''" style="" ><table id="group_tt"></table></div>  
</div>  



</div>
