<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectTemplateType.ascx.cs" Inherits="Maticsoft.Web.Controls.Project.Template.ProjectTemplateType" %>

<script type="text/javascript">
    var stage_editIndex = undefined;
    var stage_isEdit = false;
    var stage_pssid;
    var oldRows;
    var editType;
    $(function () {
    });

    function stage_Left() {
        $('#stage_Left').tree({
            url: '../../Ashx/ProjectTemplateType.ashx?action=stagelist',
            onClick: function (node) {
                //alert(node.text);  // alert node text property when clicked
                var row = $('#stage_tt').datagrid('getRows');
                var ishave = false;
                for (var i = 0; i < row.length; i++) {
                    if (row[i].stage_name == node.text) {
                        ishave = true;
                        break;
                    }
                }
                if (!ishave) {
                    if (!stage_isEdit) {
                        stage_btnSave();
                        stage_isEdit = true;
                    }
                    $('#stage_tt').datagrid('appendRow', { s_sid: stage_pssid, stage_name: node.text, remark: '', sequence: $('#stage_tt').datagrid('getRows').length, sid: 0 });
                }
            }

        });
    }

    function stage_Grid(sid) {
        $('#stage_tt').datagrid({
            url: '../../Ashx/ProjectTemplateType.ashx',
            queryParams: { "action": "stage_list", "ssid": sid },
            idField: 'sid',
            fit: true,
            striped: true,
            singleSelect: true,
            remoteSort: false,
            fitColumns: true,
            rownumbers: true,
            columns: [[
					  { field: 'stage_name', title: '阶段名称', width: 100, sortable: true, editor: "text" }
					, { field: 'remark', title: '备注', width: 200, sortable: true, editor: "text" }
                    , { field: 'sid', title: '编号', editor: "text", hidden: true }
                    , { field: 'sequence', title: '排序', hidden: true }
				]],
            toolbar: "#stage_menu",
            onLoadSuccess: function (data) {

            },
            onClickRow: function (index, rowData) {
                if (!stage_isEdit) {
                    stage_isEdit = true;
                    stage_btnSave();
                }
                stage_editRow(index);

            },
            onRowContextMenu: function (e, rowIndex, rowData) {
                e.preventDefault();
                var selected = $("#stage_tt").datagrid('getRows'); //获取所有行集合对象
                var idValue = selected[rowIndex].sid;
                $(this).datagrid('selectRecord', idValue);  //通过获取到的id的值做参数选中一行
                $('#stage_mm').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });
            }
        });
    }

    function stage_endEditing() {
        if (stage_editIndex == undefined) { return true }
        if ($('#stage_tt').datagrid('validateRow', stage_editIndex)) {
            //var ed = $('#tt').datagrid('getEditor', { index: stage_editIndex, field: 'RoleName' });
            //var productname = $(ed.target).combobox('getText');
            //$('#tt').datagrid('getRows')[stage_editIndex]['productname'] = productname;
            $('#stage_tt').datagrid('endEdit', stage_editIndex);
            stage_editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function stage_editRow(index) {
        if (stage_editIndex != index) {
            if (stage_endEditing()) {
                $('#stage_tt').datagrid('selectRow', index).datagrid('beginEdit', index);
                var editor = $('#stage_tt').datagrid('getEditor', { index: index, field: 'stage_name' });
                $(editor.target).attr('disabled', true);
                stage_editIndex = index;
            }
            else {
                $('#stage_tt').datagrid('selectRow', stage_editIndex);
            }
        }
    }

    function stage_editGrid(row) {
        var index = $('#stage_tt').datagrid('getRowIndex', row);
        $('#stage_tt').datagrid('beginEdit', index);        
        var editors = $('#stage_tt').datagrid('getEditors', index);
        stage_editIndex = index;
    }

    function stage_openDialog(index, title, type) {
        var lock = true;
        var sid = "-1";
        editType = type;
        if (type != "add") {
            var rows = $('#tt').datagrid('getRows');
            var row = rows[index];
            sid = row.ptt_sid;
            $("#mbName").val(row.ptt_name);
            $("#mbSid").val(type == "copy" ? "" : row.ptt_sid);            
        }
        else {
            $("#mbName").val("");
            $("#mbSid").val("");
        }
        $("#pptt_sid").val(type == "copy" ? row.ptt_sid : 0);
        if (art.dialog.list['stage_dialog'] == null) {
            art.dialog({
                content: document.getElementById('stage_edit'),
                id: 'stage_dialog',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                lock: lock,
                init: function () {
                    stage_pssid = sid
                    stage_Grid(sid);
                    stage_Left();
                    stage_btnCancel();
                },
                close: function () {
                    stage_endEditing();
                    var changerows = $('#stage_tt').datagrid('getChanges');
                    if (changerows.length > 0) {
                        if (confirm("内容有更改，您确认不保存直接关闭吗?")) {
                            stage_isEdit = false;
                            //stage_Grid(row)
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
            art.dialog.list['stage_dialog'].content(document.getElementById('stage_edit'));
        }
    }

    //快速搜索
    function stage_qsearch(v) {
        $('#stage_tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#stage_tt').datagrid('load');
    }

    function stage_btnSave() {
        //$('#stage_add').linkbutton("disable");
        //$('#stage_update').linkbutton("disable");
        //$('#stage_del').linkbutton("disable");
        $('#stage_save').linkbutton("enable");
        $('#stage_cancel').linkbutton("enable");
    }

    function stage_btnCancel() {
        //$('#stage_add').linkbutton("enable");
        //$('#stage_update').linkbutton("enable");
        //$('#stage_del').linkbutton("enable");
        $('#stage_save').linkbutton("disable");
        $('#stage_cancel').linkbutton("disable");
    }

    function stage_add() {
        if (!stage_isEdit) {
            stage_btnSave();
            stage_isEdit = true;
        }
        if (stage_endEditing()) {
            $('#stage_tt').datagrid('appendRow', { ps_sid: stage_pssid, sequence: $('#stage_tt').datagrid('getRows').length, sid: 0 }); //, { status: 'P' });
            stage_editIndex = $('#stage_tt').datagrid('getRows').length - 1;
            $('#stage_tt').datagrid('selectRow', stage_editIndex).datagrid('beginEdit', stage_editIndex);
        }
    }

    function stage_insert() {
        //alert();
        if (!stage_isEdit) {
            stage_btnSave();
            stage_isEdit = true;
        }
        var FocusRow = $('#stage_tt').datagrid('getSelected');
        var curIndex = $('#stage_tt').datagrid('getRowIndex', FocusRow);
        //alert(curIndex);
        if (stage_endEditing()) {
            //alert($('#stage_tt').datagrid('getRows').length - curIndex);
            for (var i = (curIndex + 1); i < ($('#stage_tt').datagrid('getRows').length); i++) {
                //alert(i);
                //$('#stage_tt').datagrid('beginEdit', i);
                $('#stage_tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i + 1 }
                });
                //                //$('#stage_tt').datagrid('endEdit', i);
            }
            //$('#stage_tt').datagrid('selectRow', curIndex + 1).datagrid('beginEdit', curIndex + 1);
            //            $('#stage_tt').datagrid('updateRow', {
            //                index: curIndex + 1,
            //                row: { stage_name: 'test', sequence: curIndex + 2 }
            //            });
            //$('#stage_tt').datagrid('selectRow', curIndex + 1).datagrid('endEdit', curIndex + 1);

            $('#stage_tt').datagrid('insertRow', { index: curIndex + 1, row: { ps_sid: stage_pssid, sequence: curIndex + 1, sid: 0} });  //, { status: 'P' });

            stage_editIndex = curIndex + 1;  //$('#stage_tt').datagrid('getRows').length - 1;
            $('#stage_tt').datagrid('selectRow', stage_editIndex).datagrid('beginEdit', stage_editIndex);
        }
    }

    function stage_update() {
        stage_btnSave();
        stage_isEdit = true;
    }

    function stage_del() {
        if (!stage_isEdit) {
            stage_btnSave();
        }
        if (stage_editIndex == undefined) { return }
        var row = $('#stage_tt').datagrid('getSelected');
        //alert(row.sid);
        if (row.sid != null || row.sid == 0) {
            //alert();
            $.ajax({
                type: "POST",
                async: false,
                url: '../../Ashx/ProjectStage.ashx',
                data: {
                    'action': 'stage_del_check',
                    'sid': row.sid
                },
                success: function (data) {
                    if (data == "1") {
                        $.messager.show({ title: '提示', msg: "已经有项目内容调用，不能删除！" });
                        return;
                    }
                    else {
                        for (var i = (stage_editIndex + 1); i < ($('#stage_tt').datagrid('getRows').length); i++) {
                            //alert(i);
                            //$('#stage_tt').datagrid('beginEdit', i);
                            $('#stage_tt').datagrid('updateRow', {
                                index: i,
                                row: { sequence: i - 1 }
                            });
                            //$('#stage_tt').datagrid('endEdit', i);
                        }

                        $('#stage_tt').datagrid('cancelEdit', stage_editIndex).datagrid('deleteRow', stage_editIndex);

                        stage_editIndex = undefined;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    return;
                }
            });
        } else {

            for (var i = (stage_editIndex + 1); i < ($('#stage_tt').datagrid('getRows').length); i++) {
                //alert(i);
                //$('#stage_tt').datagrid('beginEdit', i);
                $('#stage_tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i - 1 }
                });
                //$('#stage_tt').datagrid('endEdit', i);
            }

            $('#stage_tt').datagrid('cancelEdit', stage_editIndex).datagrid('deleteRow', stage_editIndex);

            stage_editIndex = undefined;
        }
    }

    function stage_MoveRow(fx) {
        var gd = $('#stage_tt');
        var gdData = gd.datagrid("getData");
        if (gdData.rows.length < 2) return;
        var iMovedRowIndex = -1;
        var FocusRow = gd.datagrid('getSelected');
        if (!FocusRow) {
            //alert("没有行被选中,无法执行移动操作");
            $.messager.show({ title: '提示', msg: "没有行被选中,无法执行移动操作" });
            return;
        }
        var iCurRowIndex = gd.datagrid('getRowIndex', FocusRow);
        iMovedRowIndex = iCurRowIndex + fx;
        if (iCurRowIndex === 0 && fx === -1) return; //iMovedRowIndex = gdData.rows.length - 1;
        if (iCurRowIndex === gdData.rows.length - 1 && fx === 1) return; //iMovedRowIndex = 0;
        var RowTemp = { stage_name: "", remark: "", sequence: "", sid: "" };
        RowTemp.stage_name = gdData.rows[iMovedRowIndex].stage_name;
        RowTemp.remark = gdData.rows[iMovedRowIndex].remark;
        RowTemp.sequence = gdData.rows[iMovedRowIndex].sequence;
        RowTemp.sid = gdData.rows[iMovedRowIndex].sid;

        gdData.rows[iMovedRowIndex].stage_name = gdData.rows[iCurRowIndex].stage_name;
        gdData.rows[iMovedRowIndex].remark = gdData.rows[iCurRowIndex].remark;
        //gdData.rows[iMovedRowIndex].sequence = gdData.rows[iCurRowIndex].sequence;
        gdData.rows[iMovedRowIndex].sid = gdData.rows[iCurRowIndex].sid;

        //gdData.rows[iMovedRowIndex].sequence = gdData.rows[iCurRowIndex].sequence;
        //gdData.rows[iCurRowIndex].sid = RowTemp.sid;
        var edt = gd.datagrid("getEditors", iCurRowIndex);
        edt[0].target.val(RowTemp.stage_name);
        edt[1].target.val(RowTemp.remark);
        edt[2].target.val(RowTemp.sid);
        //edt[3].target.val(RowTemp.sid);

        gd.datagrid('endEdit', iCurRowIndex);
        gd.datagrid('unselectRow', iCurRowIndex);
        gd.datagrid('selectRow', iMovedRowIndex);
        gd.datagrid('beginEdit', iMovedRowIndex);
        var editor = $('#stage_tt').datagrid('getEditor', { index: iMovedRowIndex, field: 'stage_name' });
        $(editor.target).attr('disabled', true);
        stage_editIndex = iMovedRowIndex;
        gd = null;
    }

    function stage_save() {
        stage_isEdit = false;
        if (stage_endEditing()) {
            var ptt_name = $("#mbName").val();
            var ptt_sid = $("#mbSid").val();
            var pptt_sid = $("#pptt_sid").val();
            if (ptt_name == "") {
                $('#tt').datagrid("reload");
                $.messager.show({ title: '提示', msg: "模版名称不能为空。" });                
                return;
            }
            var rows = $('#tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (ptt_sid != rows[i].ptt_sid && ptt_name == rows[i].ptt_name) {
                    $('#tt').datagrid("reload");
                    $.messager.show({ title: '提示', msg: "模版【" + ptt_name + "】已存在。" });                    
                    return;
                }
            }
            rows = $('#stage_tt').datagrid('getRows');
            if (rows.length == 0) {
                $('#tt').datagrid("reload");
                $.messager.show({ title: '提示', msg: "请至少选择一个阶段。" });
                return;
            }
            var SQLString = "";
            for (var i = 0; i < rows.length; i++) {
                SQLString += rows[i].sid + "〢" + rows[i].stage_name + "〢" + rows[i].sequence + "〢" + rows[i].remark + "〣";               
            }

            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../../Ashx/ProjectTemplateType.ashx',
                data: {
                    'action': 'stage_edit',
                    "SQLString": SQLString,
                    "ptt_name": ptt_name,
                    "ptt_sid": ptt_sid,
                    "pptt_sid": pptt_sid
                },
                success: function (data) {
                    var d = data.split("~");
                    if (d[0] == "success") {
                        $("#mbSid").val(d[1]);
                        $('#stage_tt').datagrid("options").queryParams = { "action": "stage_list", "ssid": d[1] };
                        $('#stage_tt').datagrid("reload");
                        $('#tt').datagrid("reload");
                        stage_btnCancel();
                        $.messager.show({ title: '提示', msg: "保存成功！" });
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

    function stage_cancel() {
        stage_btnCancel();
        stage_isEdit = false;
        $('#stage_tt').datagrid('rejectChanges');
        stage_editIndex = undefined;
    }
</script>
<div style="width:600px; height:400px;">
    
    
    <div id="stage_menu" style="padding:2px;border:1px solid #ddd; background-color:#F4F4F4">
		<%--<a href="#" id="stage_update" style="display:none;" onclick="stage_update()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-edit'">修改</a>--%>
		<a href="#" id="stage_del" onclick="stage_del()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'">删除</a>
        <a href="#" id="stage_up" onclick="stage_MoveRow(-1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-up'">上移</a>
        <a href="#" id="stage_down" onclick="stage_MoveRow(1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-down'">下移</a>
		<a href="#" id="stage_save" onclick="stage_save()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="#" id="stage_cancel" onclick="stage_cancel()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-undo'">取消</a>
        <div>模版名称：<input type="text" id="mbName"/><input type="hidden" id="mbSid"/><input type="hidden" id="pptt_sid"/></div>
	</div>


    <div id="stage_mm" class="easyui-menu" style="width:120px;">
        <div onclick="stage_insert()" data-options="iconCls:'icon-add'">插入行</div>
    </div>

    <div id="stage_cc" class="easyui-layout" fit="true">
        <div data-options="region:'west',title:''" style="width:180px;"><ul id="stage_Left" style="height:300px;"></ul></div>  
        <div data-options="region:'center',title:''" style="" ><table id="stage_tt"></table></div>  
    </div>
</div>