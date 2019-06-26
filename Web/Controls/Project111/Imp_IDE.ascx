<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Imp_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.Project111.Imp_IDE" %>
<script type="text/javascript">
    var imp_editIndex = undefined;
    var imp_isEdit = false;
    var imp_pssid;
    var oldRows;
    $(function () {
        
    });

    function imp_Left() {
        $('#imp_left_tt').datagrid({
            url: '../Ashx/Project.ashx?action=impList',
            idField: 'id',
            nowrap: false,
            fitColumns: true,
            striped: true, //True 奇偶行使用不同背景色
            singleSelect: true,
            toolbar: '#imp_Left_menu',
            columns: [[
					{ field: 'implement_name', title: '工作类型名称', width: 80 },
					{ field: 'impUserNames', title: '人员', width: 200 }
                    , { field: 'implementers', title: '简称', width: 200, hidden: true }
				]],
            onClickRow: function (rowIndex, rowData) {
                var row = $('#imp_tt').datagrid('getRows');
                var ishave = false;
                for (var i = 0; i < row.length; i++) {
                    if (row[i].implement_name == rowData.implement_name) {
                        ishave = true;
                        break;
                    }
                }
                if (!ishave) {
                    if (!imp_isEdit) {
                        imp_btnSave();
                        imp_isEdit = true;
                    }
                    $('#imp_tt').datagrid('appendRow', { s_sid: imp_pssid, implement_name: rowData.implement_name, impUserNames: rowData.impUserNames, implementers: rowData.implementers, implementers_sid: rowData.implementers_sid, remark: '', sequence: $('#imp_tt').datagrid('getRows').length, sid: 0 });
                }
            }

        });
    }

    function doSearch(value, name) {
        $('#imp_left_tt').datagrid('options').queryParams = { "key": value };
        $('#imp_left_tt').datagrid('load');
    }

    function imp_Grid(row) {
        $('#imp_tt').datagrid({
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { "action": "imp_list", "ssid": row.sid },
            idField: 'sid',
            fitColumns: true,
            striped: true, //True 奇偶行使用不同背景色
            singleSelect: true,
            rownumbers: true,
            columns: [[
					{ field: 'implement_name', title: '工作类型名称', width: 200, editor: "text" }
					, { field: 'impUserNames', title: '人员', width: 300, editor: "onclick_text" }
					,{ field: 'implementers', title: '简称', width: 200, editor: "text" }
					,{ field: 'remark', title: '备注', width: 200, editor: "text" }
                    ,{ field: 'sid', title: '编号', editor: "text", hidden: true }
                    , { field: 'implementers_sid', title: '', editor: "text", hidden: true }
				]],
            toolbar: "#imp_menu",
            onLoadSuccess: function (data) {

            },
            onClickRow: function (index, rowData) {
                if (!imp_isEdit) {
                    imp_isEdit = true;
                    imp_btnSave();
                }
                imp_EditRow(index);
                //imp_push_json($('#imp_uid').combobox('getData'), rowData.implementers_sid, rowData.impUserNames);
            },
            onRowContextMenu: function (e, rowIndex, rowData) {
                e.preventDefault();
                var selected = $("#imp_tt").datagrid('getRows'); //获取所有行集合对象
                var idValue = selected[rowIndex].sid;
                $(this).datagrid('selectRecord', idValue);  //通过获取到的id的值做参数选中一行
                $('#imp_mm').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });
            }
        });
    }

    function imp_endEditing() {
        if (imp_editIndex == undefined) { return true }
        if ($('#imp_tt').datagrid('validateRow', imp_editIndex)) {
            //var ed = $('#tt').datagrid('getEditor', { index: imp_editIndex, field: 'RoleName' });
            //var productname = $(ed.target).combobox('getText');
            //$('#tt').datagrid('getRows')[imp_editIndex]['productname'] = productname;
            $('#imp_tt').datagrid('endEdit', imp_editIndex);
            imp_editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function imp_EditRow(index) {
        if (imp_editIndex != index) {
            if (imp_endEditing()) {
                $('#imp_tt').datagrid('selectRow', index).datagrid('beginEdit', index);
                imp_editIndex = index;
            } else {
                $('#imp_tt').datagrid('selectRow', imp_editIndex);
            }
        }
    }

    function imp_EditGrid(row) {
        var index = $('#imp_tt').datagrid('getRowIndex', row);
        $('#imp_tt').datagrid('beginEdit', index);
        var editors = $('#imp_tt').datagrid('getEditors', index);
        imp_editIndex = index;
    }

    function imp_openDialog(index, title) {
        var lock = true;
        var rows = $('#sub_tt').datagrid('getRows');
        var row = rows[index];
        if (art.dialog.list['imp_dialog'] == null) {
            art.dialog({
                content: document.getElementById('imp_edit'),
                id: 'imp_dialog',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                lock: lock,
                init: function () {
                    imp_pssid = row.sid
                    imp_Grid(row);
                    imp_Left();
                    imp_btnCancel();
                },
                close: function () {
                    imp_endEditing();
                    var changerows = $('#imp_tt').datagrid('getChanges');
                    if (changerows.length > 0) {
                        //                        $.messager.confirm('确认', '内容有更改，您确认不保存直接关闭吗?', function (r) {
                        //                            if (r) {
                        //                                // exit action;
                        //                                art.dialog.list['imp_dialog'].hide();
                        //                            }
                        //                            else {
                        //                                //return false;
                        //                            }
                        //                        });
                        //                        art.dialog.confirm('内容有更改，您确认不保存直接关闭吗？', function () {
                        //                            //art.dialog.tips('执行确定操作');
                        //                            art.dialog.list['imp_dialog'].hide();
                        //                        }, function () {
                        //                            //return false;
                        //                            //art.dialog.tips('执行取消操作');
                        //                        });
                        if (confirm("内容有更改，您确认不保存直接关闭吗?")) {
                            imp_isEdit = false;
                            //imp_Grid(row)
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
            art.dialog.list['imp_dialog'].content(document.getElementById('imp_edit'));
        }
    }

    //快速搜索
    function imp_qsearch(v) {
        $('#imp_tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#imp_tt').datagrid('load');
    }

    function openSelectWin() {
        //jQuery.facybox({ div: '#imp_box' });
        
        $('#imp_box').modal({ zIndex: 9001, maxHeight: 160, maxWidth: 300, minHeight: 160, minWidth: 300 });
        //imp_user("-1");
        imp_dept_tree();
    }

    function imp_dept_tree() {
        $('#imp_dept').combotree({
            url: '../Ashx/Common.ashx?type=dept_tree_open',
            valueField: 'id',
            textField: 'text',
            editable: false,
            onLoadSuccess: function (node, data) {
                $('#imp_dept').combotree('tree').tree('collapseAll');
                imp_user();
            },
            onChange: function (newValue, oldValue) {
                $.post("../Ashx/Common.ashx", { type: "dept_users", deptid: newValue }, function (data) {
                    imp_push(data);
                });
            }
        });
    }

    function imp_push(data) {
        //alert(data);
        var array = JSON.parse(data);
        var rows = $('#imp_uid').combobox('getValues');
        var textArr = $('#imp_uid').combobox('getText').split(',');
        for (var i = 0; i < rows.length; i++) {
            var ishave = false;
            for (var j = 0; j < array.length; j++) {

                if (array[j].UserName == rows[i]) {
                    ishave = true;
                    break;
                }
            }
            if (!ishave) {
                array.push({ "UserName": rows[i], "Name": textArr[i] });
            }
        }
        $('#imp_uid').combobox('loadData', array);
    }

    function imp_push_json(array, data, text) {
        if (data != "" && data != null) {
            var rows = data.split(',');
            var textArr = text.split(',');
            for (var i = 0; i < rows.length; i++) {
                var ishave = false;
                for (var j = 0; j < array.length; j++) {

                    if (array[j].UserName == rows[i] || array[j].UserName == "") {
                        ishave = true;
                        break;
                    }
                }
                if (!ishave) {
                    array.push({ "UserName": rows[i], "Name": textArr[i] });
                }
            }
            $('#imp_uid').combobox('loadData', array);
            $('#imp_uid').combobox('setValues', rows);
        }
    }

    function imp_user() {//sid) {
        var myload = false;
        $('#imp_uid').combobox({
            //url: '../Ashx/Common.ashx?type=dept_users&deptid=' + sid,
            url: '',
            valueField: 'UserName',
            textField: 'Name',
            multiple: true,
            editable: false,
            onLoadSuccess: function () {
                if (!myload) {
                    myload = true;
                    var row = $('#imp_tt').datagrid('getSelected');
                    imp_push_json($('#imp_uid').combobox('getData'), row.implementers_sid, row.impUserNames);
                }
            },
            onChange: function (newValue, oldValue) {
                //$.messager.show({title:'',msg:newValue+":"+oldValue});
                //$('#imp_un').val($('#imp_uid').combobox('getText'));
            },
            onHidePanel: function () {
                var text = $('#imp_uid').combobox('getText');
                var showtext = "";
                var arr = text.split(',');
                for (var i = 0; i < arr.length; i++) {
                    if (arr[i].length > 0) {
                        showtext += arr[i].substr(0, 1) + ",";
                    }
                }
                if (showtext.length > 0) {
                    showtext = showtext.substring(0, showtext.length - 1);
                }
                $('#imp_un').val(showtext);
            }
        });
    }

    function setSelectUser() {
        var row = $('#imp_tt').datagrid('getSelected');
        if (row.sid == null || row.sid == 0) {
            var edt = $('#imp_tt').datagrid('getEditors', imp_editIndex);
            edt[1].target.val($('#imp_uid').combobox('getText'));
            edt[2].target.val($('#imp_un').val());
            edt[5].target.val($('#imp_uid').combobox('getValues'));
            $.modal.close();
        }
        else {
            $.ajax({
                type: "POST",
                url: '../Ashx/project.ashx',
                data: {
                    'action': 'imp_userUpdate_check',
                    'cusers': $('#imp_uid').combobox('getValues').join(','),
                    'sid': row.sid
                    
                },
                success: function (data) {
                    if (data == "") {
                        var edt = $('#imp_tt').datagrid('getEditors', imp_editIndex);
                        edt[1].target.val($('#imp_uid').combobox('getText'));
                        edt[2].target.val($('#imp_un').val());
                        edt[5].target.val($('#imp_uid').combobox('getValues'));
                        $.modal.close();
                    }
                    else {
                        $.messager.show({ title: '提示', msg: "“"+data+"”已经有项目内容调用，不能删除！" });
                        return;
                    }
                }
            });
        }
    }

    function imp_btnSave() {
        //$('#imp_add').linkbutton("disable");
        //$('#imp_update').linkbutton("disable");
        //$('#imp_del').linkbutton("disable");
        $('#imp_save').linkbutton("enable");
        $('#imp_cancel').linkbutton("enable");
    }

    function imp_btnCancel() {
        //$('#imp_add').linkbutton("enable");
        //$('#imp_update').linkbutton("enable");
        //$('#imp_del').linkbutton("enable");
        $('#imp_save').linkbutton("disable");
        $('#imp_cancel').linkbutton("disable");
    }

    function imp_add() {
        if (!imp_isEdit) {
            imp_btnSave();
            imp_isEdit = true;
        }
        if (imp_endEditing()) {
            $('#imp_tt').datagrid('appendRow', { s_sid: imp_pssid, sequence: $('#imp_tt').datagrid('getRows').length ,sid:0}); //, { status: 'P' });
            imp_editIndex = $('#imp_tt').datagrid('getRows').length - 1;
            $('#imp_tt').datagrid('selectRow', imp_editIndex).datagrid('beginEdit', imp_editIndex);
        }
    }

    function imp_insert() {
        if (!imp_isEdit) {
            imp_btnSave();
            imp_isEdit = true;
        }
        var FocusRow = $('#imp_tt').datagrid('getSelected');
        var curIndex = $('#imp_tt').datagrid('getRowIndex', FocusRow);
        if (imp_endEditing()) {
            for (var i = (curIndex + 1); i < ($('#imp_tt').datagrid('getRows').length); i++) {
                $('#imp_tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i + 1 }
                });
            }

            $('#imp_tt').datagrid('insertRow', { index: curIndex + 1, row: { s_sid: imp_pssid, sequence: curIndex + 1, sid: 0} });  //, { status: 'P' });

            imp_editIndex = curIndex + 1;  //$('#imp_tt').datagrid('getRows').length - 1;
            $('#imp_tt').datagrid('selectRow', imp_editIndex).datagrid('beginEdit', imp_editIndex);
        }
    }

    function imp_update() {
        imp_btnSave();
        imp_isEdit = true;
    }

    function imp_del() {
        if (!imp_isEdit) {
            imp_btnSave();
        }
        if (imp_editIndex == undefined) { return }
        var row = $('#imp_tt').datagrid('getSelected');
        //alert(row.sid);
        if (row.sid != null && row.sid != 0) {
            //alert();
            $.ajax({
                type: "POST",
                async: false,
                url: '../Ashx/project.ashx',
                data: {
                    'action': 'imp_del_check',
                    'sid': row.sid
                },
                success: function (data) {
                    if (data == "1") {
                        $.messager.show({ title: '提示', msg: "已经有项目内容调用，不能删除！" });
                        return;
                    }
                    else {
                        for (var i = (imp_editIndex + 1); i < ($('#imp_tt').datagrid('getRows').length); i++) {
                            //alert(i);
                            //$('#imp_tt').datagrid('beginEdit', i);
                            $('#imp_tt').datagrid('updateRow', {
                                index: i,
                                row: { sequence: i - 1 }
                            });
                            //$('#imp_tt').datagrid('endEdit', i);
                        }

                        $('#imp_tt').datagrid('cancelEdit', imp_editIndex).datagrid('deleteRow', imp_editIndex);

                        imp_editIndex = undefined;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    return;
                }
            });
        } else {

            for (var i = (imp_editIndex + 1); i < ($('#imp_tt').datagrid('getRows').length); i++) {
                //alert(i);
                //$('#imp_tt').datagrid('beginEdit', i);
                $('#imp_tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i - 1 }
                });
                //$('#imp_tt').datagrid('endEdit', i);
            }

            $('#imp_tt').datagrid('cancelEdit', imp_editIndex).datagrid('deleteRow', imp_editIndex);

            imp_editIndex = undefined;
        }
    }

    function imp_MoveRow(fx) {
        var gd = $('#imp_tt');
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
        var RowTemp = { implement_name: "", impUserNames: "", implementers: "", remark: ""};
        RowTemp.implement_name = gdData.rows[iMovedRowIndex].implement_name;
        RowTemp.impUserNames = gdData.rows[iMovedRowIndex].impUserNames;
        RowTemp.implementers = gdData.rows[iMovedRowIndex].implementers;
        RowTemp.implementers_sid = gdData.rows[iMovedRowIndex].implementers_sid;
        RowTemp.remark = gdData.rows[iMovedRowIndex].remark;
        RowTemp.sequence = gdData.rows[iMovedRowIndex].sequence;
        RowTemp.sid = gdData.rows[iMovedRowIndex].sid;
        gdData.rows[iMovedRowIndex].implement_name = gdData.rows[iCurRowIndex].implement_name;
        gdData.rows[iMovedRowIndex].impUserNames = gdData.rows[iCurRowIndex].impUserNames;
        gdData.rows[iMovedRowIndex].implementers = gdData.rows[iCurRowIndex].implementers;
        gdData.rows[iMovedRowIndex].implementers_sid = gdData.rows[iCurRowIndex].implementers_sid;
        gdData.rows[iMovedRowIndex].remark = gdData.rows[iCurRowIndex].remark;
        gdData.rows[iMovedRowIndex].sid = gdData.rows[iCurRowIndex].sid;

//        gdData.rows[iCurRowIndex].implement_name = RowTemp.implement_name
//        gdData.rows[iCurRowIndex].impUserNames = RowTemp.impUserNames
//        gdData.rows[iCurRowIndex].implementers = RowTemp.implementers
//        gdData.rows[iCurRowIndex].implementers_sid = RowTemp.implementers_sid
//        gdData.rows[iCurRowIndex].remark = RowTemp.remark
//        gdData.rows[iCurRowIndex].sid = RowTemp.sid

        var edt = gd.datagrid("getEditors", iCurRowIndex);
        edt[0].target.val(RowTemp.implement_name);
        edt[1].target.val(RowTemp.impUserNames);
        edt[2].target.val(RowTemp.implementers);
        edt[3].target.val(RowTemp.remark);
        edt[4].target.val(RowTemp.sid);
        edt[5].target.val(RowTemp.implementers_sid);

        gd.datagrid('endEdit', iCurRowIndex);
        gd.datagrid('unselectRow', iCurRowIndex);
        gd.datagrid('selectRow', iMovedRowIndex);
        gd.datagrid('beginEdit', iMovedRowIndex);
        imp_editIndex = iMovedRowIndex;
        gd = null;
    }

    function imp_save() {

        imp_isEdit = false;

        if (imp_endEditing()) {
            var rows = $('#imp_tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].implement_name.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "工作名称不能为空" });
                    imp_EditGrid(rows[i]);
                    return false;
                }
                if (rows[i].impUserNames.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "工作人员不能为空" });
                    imp_EditGrid(rows[i]);
                    return false;
                }
                if (rows[i].implementers.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "人员简称不能为空" });
                    imp_EditGrid(rows[i]);
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].implement_name == rows[j].implement_name) {
                            $.messager.show({ title: '错误提示', msg: "工作名称不能重复" });
                            imp_EditRow(j);
                            return false;
                        }
                    }
                }
            }

            var allRows = $('#imp_tt').datagrid('getRows');
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allstr = "";

            allstr = JSON.stringify(allRows);
            var delrows = $('#imp_tt').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delrows);
            var updaterows = $('#imp_tt').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updaterows);
            var addrows = $('#imp_tt').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addrows);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../Ashx/project.ashx',
                data: {
                    'action': 'imp_edit',
                    'allstr': allstr,
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        $('#imp_tt').datagrid("reload");
                        imp_btnCancel();
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

    function imp_cancel() {
        imp_btnCancel();
        imp_isEdit = false;
        $('#imp_tt').datagrid('rejectChanges');
        imp_editIndex = undefined;
    }
</script>
<div style="width:800px; height:400px;">
 <div id="imp_menu" style="padding:2px;border:1px solid #ddd; background-color:#F4F4F4">
		<a href="#" id="imp_add" onclick="imp_add()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'">新增</a>
		<a href="#" id="imp_update" style="display:none;" onclick="imp_update()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-edit'">修改</a>
		<a href="#" id="imp_del" onclick="imp_del()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'">删除</a>
        <a href="#" id="imp_up" onclick="imp_MoveRow(-1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-up'">上移</a>
        <a href="#" id="imp_down" onclick="imp_MoveRow(1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-down'">下移</a>
		<a href="#" id="imp_save" onclick="imp_save()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="#" id="imp_cancel" onclick="imp_cancel()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-undo'">取消</a>
	</div>

     <div id="imp_Left_menu" style="padding:2px;border:1px solid #ddd; background-color:#F4F4F4">
     <input class="easyui-searchbox" data-options="prompt:'请输入搜索内容',searcher:doSearch" style="width:200px"></input>
	</div>


    <div id="imp_mm" class="easyui-menu" style="width:120px;">
    <div onclick="imp_insert()" data-options="iconCls:'icon-add'">插入行</div>
    </div>

<div id="imp_cc" class="easyui-layout" fit="true">   
    <div data-options="region:'west',title:''" style="width:250px;"><table id="imp_left_tt"></table></div>  
    <div data-options="region:'center',title:''" style="" ><table id="imp_tt"></table></div>  
</div>  

<div id="imp_box" style="z-index:9999">
<div style="padding:5px">部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门：<input type="text" id="imp_dept" name="imp_dept" value="" style="width:200px; z-index:99999"/><br /></div>
<div style="padding:5px">人&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;员：<input type="text" id="imp_uid" name="imp_uid" value="" style="width:200px"/><br /></div>
<div style="padding:5px">人员简称：<input type="text" id="imp_un" name="imp_un" value="" style="width:200px"/><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;简称顺序必须与上面人员相同</div>
<div style="padding:5px; text-align:center">
<%--<a href="#" id="imp_select_bt" onclick="" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-save'">确定</a>--%>
<button id="imp_select_bt" onclick="setSelectUser();">确定</button>
</div>
</div>


</div>