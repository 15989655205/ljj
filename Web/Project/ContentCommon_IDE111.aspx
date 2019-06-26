<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ContentCommon_IDE111.aspx.cs" Inherits="Maticsoft.Web.Project.ContentCommon_IDE111" %>
<%@ Register TagPrefix="pc_IDE" TagName="PC_IDE" Src="../Controls/Project/Content_IDE.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../js/themes/default/datagrid2.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    var columns = "<%=column %>";
    var frozencolumns = "<%=frozencolumns %>";
    var sDateStr = "<%=sDateStr %>";
    var eDateStr = "<%=eDateStr %>";
    var pssid = "<%=pssid %>";

    var editIndex = undefined;
    var editColumn = undefined;

    $(function () {
        InitGird();
    });

    //初始化表格
    function InitGird() {
        grid = $('#tt').datagrid({
            title: "<%=pname %>>><%=stageName %>",
            fit: true,
            singleSelect: true, //单选
            //rowspan:false,
            //fitColumns: true, //列自适应
            rownumbers:true,
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { "action": "content_common_item", "pssid": "<%=pssid %>" },
            idField: 'rowid', //标识字段,主键
            frozenColumns: eval('(' + frozencolumns + ')'),
            columns: eval('(' + columns + ')'),
            toolbar: "#toolbar",
            onLoadSuccess: function (data) {
                //if (data.rows.length > 0) { mergeCellsByField('tt', 'stage_name,group_name,contentName'); }
            },
            onClickCell: function (index, field, value) {
                if (endEditing()) {
                    $('#tt').datagrid('editdgCell', { index: index, field: field });
                    var ed = $('#tt').datagrid('getEditor', { index: index, field: field });
                    if (ed != null) {
                        //                        if (field.indexOf('imp_') >= 0) {

                        //                            if (value != "") {
                        //                            }
                        //                            else {
                        //                                $(ed.target).combobox('clear');
                        //                            }
                        //                        }
                        //                        else {
                        if (field.indexOf('flow_') >= 0 || field.indexOf('impAbbr_') >= 0 || field.indexOf('v1_') >= 0 || field.indexOf('v2_') >= 0) {
                            //alert($(ed.target).val());
                            if ($(ed.target).val() == "") {
                                if ($(ed.target).attr("disabled") != "disabled") {
                                    $(ed.target).val("✓");
                                }
                            }
                            else {
                                $(ed.target).val("");
                            }
                        }
                        if ($(ed.target).attr("disabled") != "disabled") {
                            $(ed.target).focus();
                            $(ed.target).select();
                        }
                        //                        }
                        editIndex = index;
                        editColumn = field;
                    }
                }
            },
            onClickRow: function (row) {
            }
        });
    }

    $.extend($.fn.datagrid.methods, {
        editdgCell: function (jq, param) {
            return jq.each(function () {
                var opts = $(this).datagrid('options');
                var fields = $(this).datagrid('getColumnFields', true).concat($(this).datagrid('getColumnFields'));
                for (var i = 0; i < fields.length; i++) {
                    var col = $(this).datagrid('getColumnOption', fields[i]);
                    col.editor1 = col.editor;
                    if (fields[i] != param.field) {
                        col.editor = null;
                    }
                }
                $(this).datagrid('beginEdit', param.index);
                for (var i = 0; i < fields.length; i++) {
                    var col = $(this).datagrid('getColumnOption', fields[i]);
                    col.editor = col.editor1;
                }
            });
        }
    });

    function MoveRow(fx) {
        if (endEditing()) {
            var gd = $('#tt');
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
            if (gdData.rows[iMovedRowIndex].contentName != gdData.rows[iCurRowIndex].contentName) {
                $.messager.show({ title: '提示', msg: "不能跨空间移动图纸及索引" });
                return;
            }
            var RowTemp = gdData.rows[iMovedRowIndex]; //gd.datagrid('getRows')[iMovedRowIndex]; //{ group_name: "", remark: "", sequence: "", sid: "" };updateRow
            var tmpStr = JSON.stringify(RowTemp);
            //alert(tmpStr);
            gd.datagrid('updateRow', { index: iMovedRowIndex, row: gdData.rows[iCurRowIndex] });
            //gdData.rows[iMovedRowIndex]=gdData.rows[iCurRowIndex];
            //alert(tmpStr);
            var RowChange = JSON.parse(tmpStr);
            gd.datagrid('updateRow', { index: iCurRowIndex, row: RowChange });
            gd.datagrid('selectRow', iMovedRowIndex);
            gd = null;
        }
    }

    function endEditing_cell() {
        if (editIndex == undefined) { return true }
        if ($('#tt').datagrid('validateRow', editIndex)) {

            $('#tt').datagrid('endEdit', editIndex);
            editIndex = undefined;
            editColumn = undefined;
            return true;
        } else {
            return false;
        }
    }

    function endEditing() {
        if (editIndex == undefined) { return true }
        if ($('#tt').datagrid('validateRow', editIndex)) {
            $('#tt').datagrid('endEdit', editIndex);
            editIndex = undefined;
            editColumn = undefined;
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
        var index = row.sid;  //$('#tt').treegrid('getRowIndex', row);
        $('#tt').datagrid('beginEdit', index);
        var editors = $('#tt').datagrid('getEditors', index);
        editIndex = index;
    }

    function addContent() {
        var row = $('#tt').datagrid('getSelected');
        if (art.dialog.get('pc_dialog') != null) {
            art.dialog.get('pc_dialog').close();
        }
        content_action = "pro_content_add";
        content_editType = "add";
        pc_openDialog("add", "<%=pssid %>", row, "<%=showContent %>", "<%=isConstruction %>");
    }

    function editContent() {
        var row = $('#tt').datagrid('getSelected');
        if (row != null) {
            if (art.dialog.get('pc_dialog') != null) {
                art.dialog.get('pc_dialog').close();
            }
            content_action = "pro_content_edit";
            content_editType = "alter";
            pc_openDialog("alter", "<%=pssid %>", row, "修改<%=showContent %>", "<%=isConstruction %>");
        } else {
            $.messager.show({ title: '提示', msg: "请选择要修改<%=showContent %>" });
        }
    }

    //删除
    function delContent() {
        var row = $('#tt').datagrid('getSelected');
        if (row == null) {
            $.messager.show({ title: '提示', msg: "请选择要删除数据" });
            return false;
        }
        if (row.parent_sid != "") {
            if (!confirm('<%=showContent %>里有<%=showItem %>，如果执行删除<%=showItem %>也会同时删除\n是否继续执行删除？')) {
                return false;
            }
        }
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                $.post('../../Ashx/Project.ashx', { "action": "content_del", "sid": row.csid }, function (data) {
                    if (data == "success") {
                        $("#tt").datagrid("clearSelections");
                        $("#tt").datagrid("reload");
                    }
                    else {
                        $.messager.show({ title: '提示', msg: (data == "success" ? "保存成功" : data) });
                    }
                });
            }
        });
    }


    function addItem() {
        var row = $('#tt').datagrid('getSelected');
        if (art.dialog.get('item_dialog') != null) {
            art.dialog.get('item_dialog').close();
        }
        if ("<%=isConstruction %>" != 1) {
            item_openDialog("add", "<%=pssid %>", row, "<%=showItem %>", "<%=psid %>");
        }
        else {
            citem_openDialog("add", "<%=pssid %>", row, "<%=showItem %>", "<%=psid %>");
        }
    }

    function editItem() {
        var row = $('#tt').datagrid('getSelected');
        if (row != null) {
            if (row.sid == "") {
                $.messager.show({ title: '提示', msg: "选择要修改<%=showItem %>没有内容<br/>请先添加<%=showItem %>" });
                return;
            }
            if (art.dialog.get('item_dialog') != null) {
                art.dialog.get('item_dialog').close();
            }
            if ("<%=isConstruction %>" != 1) {
                item_openDialog("alter", "<%=pssid %>", row, "修改<%=showItem %>", "<%=psid %>");
            }
            else {
                citem_openDialog("alter", "<%=pssid %>", row, "修改<%=showItem %>", "<%=psid %>");
            }
        } else {
            $.messager.show({ title: '提示', msg: "请选择要修改<%=showItem %>" });
        }
    }

    function delItem() {
        var row = $('#tt').datagrid('getSelected');
        if (row == null) {
            $.messager.show({ title: '提示', msg: "请选择要删除数据" });
            return false;
        }
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                $.post('../../Ashx/Project.ashx', { "action": "item_del", "sid": row.sid }, function (data) {
                    if (data == "success") {
                        $("#tt").datagrid("reload");
                    }
                    else {
                        $.messager.show({ title: '提示', msg: (data == "success" ? "保存成功" : data) });
                    }
                });
            }
        });
    }

    function MoveRow(fx) {
        if (endEditing()) {
            var gd = $('#tt');
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
            if (gdData.rows[iMovedRowIndex].contentName != gdData.rows[iCurRowIndex].contentName) {
                $.messager.show({ title: '提示', msg: "不能跨<%=showContent %>移动<%=showItem%>" });
                return;
            }
            var RowTemp = gdData.rows[iMovedRowIndex]; //gd.datagrid('getRows')[iMovedRowIndex]; //{ group_name: "", remark: "", sequence: "", sid: "" };updateRow
            var tmpStr = JSON.stringify(RowTemp);
            //alert(tmpStr);
            gd.datagrid('updateRow', { index: iMovedRowIndex, row: gdData.rows[iCurRowIndex] });
            //gdData.rows[iMovedRowIndex]=gdData.rows[iCurRowIndex];
            //alert(tmpStr);
            var RowChange = JSON.parse(tmpStr);
            gd.datagrid('updateRow', { index: iCurRowIndex, row: RowChange });
            gd.datagrid('selectRow', iMovedRowIndex);
            gd = null;
        }
    }

    function add() {
        var row = $('#tt').datagrid('getSelected');
        var index = $('#tt').datagrid('getRowIndex', row);
        if (row != null) {
            if (endEditing()) {
                //$('#tt').datagrid('appendRow', { contentName: row.contentName });
                $('#tt').datagrid('insertRow', { index: index + 1, row: {
                    contentName: row.contentName, sid: '', remark: '', csid: row.csid, itemSequence: row.itemSequence + 1
                }
                });
                //editIndex = $('#tt').datagrid('getRows').length - 1;
                editIndex = index + 1;
                $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "itemName" });
                editColumn = "itemName";
            }
        } else {
            $.messager.show({ title: '提示', msg: "请选择要添加<%=showItem%>的<%=showContent %>" });
        }
    }

    function Item_del() {
        var row = $('#tt').datagrid('getSelected');
        var index = $('#tt').datagrid('getRowIndex', row);
        if (row.sid != null || row.sid == 0 || row.sid == "") {
            $.ajax({
                type: "POST",
                async: false,
                url: '../Ashx/ProjectConstruction.ashx',
                data: {
                    'action': 'item_del_check',
                    'sid': row.sid
                },
                success: function (data) {
                    if (data == "0") {
                        $('#tt').datagrid('deleteRow', index);
                        editIndex = undefined;
                    }
                    else {
                        $.messager.show({ title: '提示', msg: "<%=showItem%>已正在使用，不能删除！" });
                        return;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    return;
                }
            });
        } else {
            $('#tt').datagrid('deleteRow', index);
            editIndex = undefined;
        }
    }

    function cancel() {
        $('#tt').datagrid('rejectChanges');
        editIndex = undefined;
        editColumn = undefined;
    }

    function save() {
        if (endEditing()) {
            //$('#dg').datagrid('acceptChanges');
            var rows = $('#tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].itemName.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: '<%=showItem%>必填项！' });
                    editIndex = i;
                    $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "itemName" });
                    editColumn = "itemName";
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].contentName == rows[j].contentName && rows[i].itemName == rows[j].itemName) {
                            $.messager.show({ title: '错误提示', msg: '<%=showContent %>“' + rows[i].contentName + '”的<%=showItem%>出现重复' });
                            //EditRow(j);
                            editIndex = j;
                            $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "itemName" });
                            editColumn = "itemName";
                            return false;
                        }
                    }
                }
            }
            var allstr = "";
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allrows = $('#tt').datagrid('getRows');
            allstr = JSON.stringify(allrows);
//            var delrows = $('#tt').datagrid('getChanges', 'deleted');
//            delstr = JSON.stringify(delrows);
//            var updaterows = $('#tt').datagrid('getChanges', 'updated');
//            updatestr = JSON.stringify(updaterows);
//            var addrows = $('#tt').datagrid('getChanges', 'inserted');
//            addstr = JSON.stringify(addrows);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../../Ashx/ProjectConstruction.ashx',
                data: {
                    'action': 'easyuiGridEdit_common',
                    'pssid': pssid,
                   // 'addstr': addstr,
                   // 'updatestr': updatestr,
                   // 'delstr': delstr,
                    'allstr': allstr
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<input type="hidden" id="hpssid" name="hpssid" value="<%=pssid %>" />
<div id="toolbar" style="display:none;">
        <a href="javascript:void(0)" id="mb" class="easyui-menubutton" data-options="menu:'#mm',iconCls:'icon-edit'"><%=showContent %></a>  
<div id="mm" style="width:150px;">  
    <div data-options="iconCls:'icon-add'" onclick="addContent()">添加<%=showContent %></div>  
    <div data-options="iconCls:'icon-edit'" onclick="editContent()">修改<%=showContent %></div> 
    <div data-options="iconCls:'icon-remove'" onclick="delContent()">删除<%=showContent %></div>   
</div>  
    <a href="#" id="tab_a_01" class="easyui-linkbutton" plain="true" onclick="add()" iconCls="icon-add">添加<%=showItem%></a>
    <a href="#" id="A2" class="easyui-linkbutton" plain="true" onclick="Item_del()" iconCls="icon-remove">删除<%=showItem%></a>
    <a href="#" id="A3" class="easyui-linkbutton" plain="true" onclick="MoveRow(-1)" iconCls="icon-up">上移</a>
    <a href="#" id="A4" class="easyui-linkbutton" plain="true" onclick="MoveRow(1)" iconCls="icon-down">下移</a>
    <a href="#" id="A5" class="easyui-linkbutton" plain="true" onclick="save()" iconCls="icon-save">保存</a>
    <a href="#" id="A6" class="easyui-linkbutton" plain="true" onclick=" cancel();" iconCls="icon-undo">撤销</a>
    </div>

    <table id="tt"></table>

    <div id="pc_edit" style="display: none;">
        <pc_IDE:PC_IDE ID="pc_ide1" runat="server"></pc_IDE:PC_IDE>
    </div>
</asp:Content>
