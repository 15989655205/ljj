<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProjectContent_IDE.aspx.cs" Inherits="Maticsoft.Web.Project111.ProjectContent_IDE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/treegrid-groupview.js" type="text/javascript"></script>
<script src="../js/datagrid-detailview.js" type="text/javascript"></script>
<script type="text/javascript">
    var editIndex = undefined;
    var master_isEdit = false;
    var item_editIndex = undefined;
    var item_isEdit = false;
    var item_edit=-1;
    var grid;
    var columns = "<%=column %>";
    $(function () {
        InitGird();
        master_btnCancel();
    });

    //初始化表格
    function InitGird() {
        grid = $('#tt').datagrid({
            fit: true,
            singleSelect: true, //单选
            fitColumns: true, //列自适应
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { "action": "content_master_list", "pssid": "<%=pssid %>" },
            id: 'sid', //标识字段,主键

            //columns: eval('(' + columns + ')'),
            columns: [[
            { title: '小组', field: 'group_sid', width: 60, halign: 'center', align: 'center', editor: { type: 'combobox', options: { valueField: 'sid', textField: 'group_name', data: eval("(<%=groupJson %>)")} },
                formatter: function (value, rowData, rowIndex) {
                    return '<a class="a_black" title="' + value + '"><span class="mlength">' + rowData.group_name + '</span></a>';
                }
            },
                    { title: '工作内容', field: 'name', width: 150, halign: 'center', editor: "text",
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
            //                    { title: '开始日期', field: 'begin_date', width: 100,  halign: 'center', align: 'center', editor: "datebox", hidden: true,
            //                        formatter: function (value, rowData, rowIndex) {
            //                            if (value.Format("yyyy-MM-dd") == "1900-01-01") {
            //                                return "";
            //                            } else {
            //                                return value.Format("yyyy-MM-dd");
            //                            }
            //                        }
            //                    },
            //                    { title: '结束日期', field: 'end_date', width: 100, halign: 'center', align: 'center', editor: "datebox", hidden: true,
            //                        formatter: function (value, rowData, rowIndex) {
            //                            if (value.Format("yyyy-MM-dd") == "1900-01-01") {
            //                                return "";
            //                            } else {
            //                                return value.Format("yyyy-MM-dd");
            //                            }
            //                        }
            //                    },
                    {title: '备注', field: 'remark', width: 100, halign: 'center', editor: "text",
                    formatter: function (value, rowData, rowIndex) {
                        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                    }
                },
                    { title: '', field: 'group_name', width: 100, halign: 'center', editor: "text", hidden: true },
                    { title: '系统编号', field: 'sid', width: 100, halign: 'center', editor: "text", hidden: true }
            //                    ,
            //                    { title: '添加日期', field: 'create_date', width: 100, sortable: true, halign: 'center', align: 'center', hidden: true,
            //                        formatter: function (value, rowData, rowIndex) {
            //                            return value.Format("yyyy-MM-dd");
            //                        }
            //                    }
                    ]],
            view: detailview,
            detailFormatter: function (index, row) {
                return '<div style="padding:2px"><table id="ddv-' + index +
'"></table></div>';
            },
            onExpandRow: function (index, row) {
                $('#ddv-' + index).datagrid({
                    url: '../Ashx/Project.ashx',
                    queryParams: { "action": "content_item_list", "psid": row.sid, "pssid": "<%=pssid %>" },
                    fitColumns: true,
                    singleSelect: true,
                    //nowrap: false,
                    rownumbers: true,
                    //sortOrder: 'asc',
                    idField: 'sid',
                    height: 'auto',
                    columns: eval('(' + columns + ')'),
                    toolbar: [{
                        iconCls: 'icon-add',
                        text: '添加细目',
                        handler: function () { item_add(index, row.sid) }
                    }, {
                        iconCls: 'icon-del',
                        text: '删除细目',
                        handler: function () { alert('help') }
                    }, {
                        iconCls: 'icon-up',
                        text: '上移',
                        handler: function () { alert('help') }
                    }, {
                        iconCls: 'icon-down',
                        text: '下移',
                        handler: function () { alert('help') }
                    }, {
                        iconCls: 'icon-save',
                        text: '保存',
                        handler: function () { item_save(index); }
                    }, {
                        iconCls: 'icon-undo',
                        text: '撤销',
                        handler: function () { item_cancel(index); }
                    }],
                    onResize: function () {
                        $('#tt').datagrid('fixDetailRowHeight', index);
                    },
                    onLoadSuccess: function () {
                        setTimeout(function () {
                            $('#tt').datagrid('fixDetailRowHeight', index);
                        }, 0);
                    },
                    onClickRow: function (rowIndex, rowData) {
                        if (item_edit == -1 || item_edit == index) {
                            item_edit = index;
                            item_EditRow(rowIndex, index);
                        }
                        else {
                            $.messager.show({ title: '提示', msg: "有其它列表在编辑，必须先保存或者撤销编辑。" });
                        }
                    }
                });
                $('#tt').datagrid('fixDetailRowHeight', index);
            },
            toolbar: "#master_menu",
            onLoadSuccess: function (row, data) {

            },
            onClickCell: //onClickCell,
            function (field, row) {
                //onClickCell(row.sid, field);
            },
            onClickRow: function (rowIndex, rowData) {
                if (!master_isEdit) {
                    master_isEdit = true;
                    master_btnSave();
                }
                EditRow(rowIndex);
            },
            onDblClickRow: function (rowIndex, rowData) {
                //EditRow(rowIndex);
            }
        });
    }

    function getData() {
        $.post('../Ashx/Project.ashx', { "action": "content_list", "pssid": "<%=pssid %>" },
        function (data) {
            grid.datagrid({
                columns: [data.columns]
            }).datagrid("loadData", data);
        }, 'json');
    }


    //主表编辑start
    function endEditing() {
        if (editIndex == undefined) { return true }
        if ($('#tt').datagrid('validateRow', editIndex)) {
            var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'group_sid' });
            var groupname = $(ed.target).combobox('getText');
            var ed1 = $('#tt').datagrid('getEditor', { index: editIndex, field: 'group_name' });
            $(ed1.target).val(groupname);
            $('#tt').datagrid('endEdit', editIndex);
            $('#tt').datagrid('collapseRow',editIndex);
            editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function EditRow(index) {
        if (item_edit == -1) {
            if (editIndex != index) {
                if (endEditing()) {
                    $('#tt').datagrid('selectRow', index)
							.datagrid('beginEdit', index);
                    editIndex = index;
                } else {
                    $('#tt').datagrid('selectRow', editIndex);
                }
            }
        }
        else {
            $.messager.show({ title: '提示', msg: "有细目在编辑，必须先保存或者撤销编辑。" });
        }
    }

    function master_EditGrid(row) {
        var index = $('#tt').datagrid('getRowIndex', row);
        $('#tt').datagrid('beginEdit', index);
        var editors = $('#tt').datagrid('getEditors', index);
        editIndex = index;
    }


    function onClickCell(index, field) {
        if (endEditing()) {
            //$('#tt').treegrid('select', index).datagrid('editCell', { index: index, field: field });
            editIndex = index;
        }
    }

    function master_btnSave() {
        $('#master_save').linkbutton("enable");
        $('#master_cancel').linkbutton("enable");
    }

    function master_btnCancel() {
        $('#master_save').linkbutton("disable");
        $('#master_cancel').linkbutton("disable");
    }

    function master_add() {
        if (item_edit == -1) {
            if (!master_isEdit) {
                master_btnSave();
                master_isEdit = true;
            }
            if (endEditing()) {
                $('#tt').datagrid('appendRow', { s_sid: "<%=pssid %>", sequence: $('#tt').datagrid('getRows').length, sid: 0 }); //, { status: 'P' });
                editIndex = $('#tt').datagrid('getRows').length - 1;
                $('#tt').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
            }
        }
        else {
            $.messager.show({ title: '提示', msg: "有细目在编辑，必须先保存或者撤销编辑。" });
        }
    }

    function master_insert() {
        if (!master_isEdit) {
            master_btnSave();
            master_isEdit = true;
        }
        var FocusRow = $('#tt').datagrid('getSelected');
        var curIndex = $('#tt').datagrid('getRowIndex', FocusRow);
        if (endEditing()) {
            for (var i = (curIndex + 1); i < ($('#tt').datagrid('getRows').length); i++) {
                $('#tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i + 1 }
                });
            }
            $('#tt').datagrid('insertRow', { index: curIndex + 1, row: { sequence: curIndex + 1, sid: 0} }); 

            editIndex = curIndex + 1; 
            $('#tt').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
        }
    }

    function MoveRow(fx) {
        var gd = $('#tt');
        gd.datagrid('collapseRow', editIndex);
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
        if (iCurRowIndex === 0 && fx === -1) return;
        if (iCurRowIndex === gdData.rows.length - 1 && fx === 1) return;

        var edt = gd.datagrid("getEditors", iCurRowIndex);

        var RowTemp = { group_sid: "", name: "", remark: "", group_name: "", sid: "", sequence: "" };
        //alert(gdData.rows[iMovedRowIndex].group_sid);
        RowTemp.group_name = gdData.rows[iMovedRowIndex].group_name;
        RowTemp.group_sid = gdData.rows[iMovedRowIndex].group_sid;
        RowTemp.name = gdData.rows[iMovedRowIndex].name;
        RowTemp.remark = gdData.rows[iMovedRowIndex].remark;
        RowTemp.sequence = gdData.rows[iMovedRowIndex].sequence;
        RowTemp.sid = gdData.rows[iMovedRowIndex].sid;
        gd.datagrid('beginEdit', iMovedRowIndex);
        var edt1 = gd.datagrid("getEditors", iMovedRowIndex);
        //        gdData.rows[iMovedRowIndex].group_name = edt[0].target.combobox('getText')//gdData.rows[iCurRowIndex].group_name;
        //        gdData.rows[iMovedRowIndex].group_sid = edt[0].target.combobox('getValue'); //gdData.rows[iCurRowIndex].group_sid;
        //        gdData.rows[iMovedRowIndex].name = edt[1].target.val();  //gdData.rows[iCurRowIndex].name;
        //        gdData.rows[iMovedRowIndex].remark = edt[2].target.val(); //gdData.rows[iCurRowIndex].remark;
        //        gdData.rows[iMovedRowIndex].sid = edt[4].target.val(); //gdData.rows[iCurRowIndex].sid;
        edt1[3].target.val(edt[0].target.combobox('getText')); //gdData.rows[iCurRowIndex].group_name;
        edt1[0].target.combobox('setValue', edt[0].target.combobox('getValue')); //gdData.rows[iCurRowIndex].group_sid;
        edt1[1].target.val(edt[1].target.val());  //gdData.rows[iCurRowIndex].name;
        edt1[2].target.val(edt[2].target.val()); //gdData.rows[iCurRowIndex].remark;
        edt1[4].target.val(edt[4].target.val()); //gdData.rows[iCurRowIndex].sid;
        gd.datagrid('endEdit', iMovedRowIndex);

        //        gdData.rows[iCurRowIndex].group_name = RowTemp.group_name;
        //        gdData.rows[iCurRowIndex].group_sid = RowTemp.group_sid;
        //        gdData.rows[iCurRowIndex].name = RowTemp.name;
        //        gdData.rows[iCurRowIndex].remark = RowTemp.remark;
        //        gdData.rows[iCurRowIndex].sid = RowTemp.sid;


        edt[0].target.combobox('setValue', RowTemp.group_sid);
        edt[1].target.val(RowTemp.name);
        edt[2].target.val(RowTemp.remark);
        edt[3].target.val(RowTemp.group_name);
        edt[4].target.val(RowTemp.sid);

        gd.datagrid('endEdit', iCurRowIndex);
        gd.datagrid('unselectRow', iCurRowIndex);
        gd.datagrid('selectRow', iMovedRowIndex);
        gd.datagrid('beginEdit', iMovedRowIndex);
        editIndex = iMovedRowIndex;
        gd = null;
    }

    function master_cancel() {
        master_btnCancel();
        master_isEdit = false;
        $('#tt').datagrid('rejectChanges');
        editIndex = undefined;
    }

    function master_del() {
        if (!master_isEdit) {
            master_btnSave();
        }
        if (editIndex == undefined) { return }
        var row = $('#tt').datagrid('getSelected');
        if (row.sid != null || row.sid == 0) {
            $.ajax({
                type: "POST",
                async: false,
                url: '../Ashx/project.ashx',
                data: {
                    'action': 'content_del_check',
                    'sid': row.sid
                },
                success: function (data) {
                    if (data == "1") {
                        $.messager.show({ title: '提示', msg: "项目内容有细目，不能删除！<br/>必须先清空所有细目才能删除" });
                        return;
                    }
                    else {
                        for (var i = (editIndex + 1); i < ($('#tt').datagrid('getRows').length); i++) {
                            $('#tt').datagrid('updateRow', {
                                index: i,
                                row: { sequence: i - 1 }
                            });
                        }

                        $('#tt').datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);

                        editIndex = undefined;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    return;
                }
            });
        } else {

            for (var i = (editIndex + 1); i < ($('#tt').datagrid('getRows').length); i++) {
                $('#tt').datagrid('updateRow', {
                    index: i,
                    row: { sequence: i - 1 }
                });
            }
            $('#tt').datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);
            editIndex = undefined;
        }
    }

    function master_save() {
        master_isEdit = false;
        if (endEditing()) {
            var rows = $('#tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].group_sid.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "请选择小组" });
                    aster_EditGrid(rows[i]);
                    return false;
                }
                if (rows[i].name.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "工作内容不能为空" });
                    master_EditGrid(rows[i]);
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].name == rows[j].name) {
                            $.messager.show({ title: '错误提示', msg: "工作内容有重复" });
                            master_EditRow(j);
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
                url: '../Ashx/project.ashx',
                data: {
                    'action': 'content_edit',
                    'allstr': allstr,
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        $('#tt').datagrid("reload");
                        master_btnCancel();
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
    //主表编辑end


    //Item编辑start
    function item_endEditing(curIndex) {
        if (item_edit > -1) {
            var grid = $('#ddv-' + curIndex);
            if (item_editIndex == undefined) { return true }
            if (grid.datagrid('validateRow', item_editIndex)) {
                grid.datagrid('endEdit', item_editIndex);
                item_editIndex = undefined;
                return true;
            } else {
                return false;
            }
        }
    }

    function item_EditRow(index,curIndex) {
        if (item_edit > -1) {
            var grid = $('#ddv-' + curIndex);
            if (item_editIndex != index) {
                if (item_endEditing(curIndex)) {
                    grid.datagrid('selectRow', index).datagrid('beginEdit', index);
                    item_editIndex = index;
                } else {
                    grid.datagrid('selectRow', editIndex);
                }
            }
        }
    }

    function item_EditGrid(row) {
        if (item_edit > -1) {
            var grid = $('#ddv-' + item_edit);
            var index = grid.treegrid('getRowIndex', row);
            grid.datagrid('beginEdit', index);
            var editors = grid.datagrid('getEditors', index);
            item_editIndex = index;
        }
    }

    function item_btnSave() {
        $('#item_save').linkbutton("enable");
        $('#item_cancel').linkbutton("enable");
    }

    function master_btnCancel() {
        $('#item_save').linkbutton("disable");
        $('#item_cancel').linkbutton("disable");
    }

    function item_add(curIndex, pid) {
        if (item_edit == -1) {
            item_edit = curIndex;
        }
        if (item_edit > -1 && curIndex == item_edit) {
            if (!item_isEdit) {
                item_btnSave();
                item_isEdit = true;
            }
            if (item_endEditing(curIndex)) {
                var grid = $('#ddv-' + curIndex);
                var rows= $('#tt').datagrid('getRows');
                grid.datagrid('appendRow', { s_sid: "<%=pssid %>", parent_sid: rows[curIndex].sid, sequence: grid.datagrid('getRows').length, sid: 0, group_sid: rows[curIndex].group_sid }); 
                item_editIndex = grid.datagrid('getRows').length - 1;
                grid.datagrid('selectRow', item_editIndex).datagrid('beginEdit', item_editIndex);
                $('#tt').datagrid('fixDetailRowHeight', curIndex);
            }
        }
        else {
            $.messager.show({ title: '提示', msg: "有其它列表在编辑，必须先保存或者撤销编辑。" });
        }
    }

    function item_cancel(curIndex) {
        //master_btnCancel();
        var grid = $('#ddv-' + curIndex);
        item_isEdit = false;
        item_edit = -1;
        grid.datagrid('rejectChanges');
        item_editIndex = undefined;
    }

    function item_save(curIndex) {
        if (item_endEditing(curIndex)) {
            
            var grid = $('#ddv-' + curIndex);
            var rows = grid.datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                //            if (rows[i].group_sid.length <= 0) {
                //                $.messager.show({ title: '错误提示', msg: "请选择小组" });
                //                aster_EditGrid(rows[i]);
                //                return false;
                //            }
                if (rows[i].name.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "细目内容不能为空" });
                    item_EditGrid(rows[i]);
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].name == rows[j].name) {
                            $.messager.show({ title: '错误提示', msg: "细目内容有重复" });
                            item_EditRow(j);
                            return false;
                        }
                    }
                }
            }

            var allRows = grid.datagrid('getRows');
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allstr = "";

            allstr = JSON.stringify(allRows);
            var delrows = grid.datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delrows);
            var updaterows = grid.datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updaterows);
            var addrows = grid.datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addrows);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../Ashx/project.ashx',
                data: {
                    'action': 'content_item_edit',
                    'allstr': allstr,
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        grid.datagrid("reload");
                        item_isEdit = false;
                        item_edit = -1;
                        //item_btnCancel();
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

    //Item编辑end




    //编辑事件
    function add() {
        var row = $('#tt').datagrid('getSelected');
        if (art.dialog.get('pc_dialog') != null) {
            art.dialog.get('pc_dialog').close();
        }
        pc_openDialog("add", $('#hpssid').val(), row, "工作内容");
    }
    function edit() {
        var row = $('#tt').datagrid('getSelected');
        if (row == null) {
            $.messager.show({ title: '提示', msg: "请选择要编辑数据" });
            return false;
        }
        if (art.dialog.get('pc_dialog') != null) {
            art.dialog.get('pc_dialog').close();
        }
        pc_openDialog("alter", $('#hpssid').val(), row, "工作内容");
    }

    //查看
    function view() {
        if (row == null) {
            $.messager.show({ title: '提示', msg: "请选择要查看数据" });
            return false;
        }
        var row = $('#tt').datagrid('getSelected');
        url = "/Flow/MyWork_IDE.aspx?action=view&sid=" + row.sid + "&rfsid=" + row.rf_sid;
        parent.addTab_Ext('申请单【查看】', url, "", true);
    }

    //删除
    function del() {
        var row = $('#tt').treegrid('getSelected');
        if (row == null) {
            $.messager.show({ title: '提示', msg: "请选择要删除数据" });
            return false;
        }
        if ($("#tt").treegrid("getChildren", row.sid).length > 0) {
            $.messager.confirm('确认', '您要删除工作内容吗？如果确认删除，工作内容对应的细目也同时删除的。', function (r) {
                if (!r) {
                    return false;
                }
                else {
                    del_save(row.sid);
                }
            });
        }
        else {
            del_save(row.sid);
        }
    }

    function del_save(sid) {
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                $.post('../Ashx/Project.ashx', { "action": "pro_content_del", "sid": sid }, function (data) {
                    if (data == "success") {
                        InitGird();
                    }
                    else {
                        $.messager.show({ title: '提示', msg: data });
                    }
                });
            }
        });
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="cc" class="easyui-layout" fit="true" border="false" style="overflow-y: hidden"  scroll="no">
<div region="north" title="" border="false" split="false">
<input type="hidden" id="hsid" name="hsid" value="" />
<input type="hidden" id="haction" name="haction" value="" />
<input type="hidden" id="hpsid" name="hpsid" value="" />
<input type="hidden" id="hpssid" name="hpssid" value="<%=pssid %>" />
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" colspan="4" style="height: 25px; background-color: #e1f5fc; text-align: center">
                    <strong>项目基本属性</strong>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; background-color: #e1f5fc; height: 25px;">
                    项目名称：
                </td>
                <td  style="background-color: #ffffff; height: 25px; padding-left: 5px; width:35%">
                &nbsp;<%=pname %>
                </td>
                 <td align="right" style="width: 15%; background-color: #e1f5fc; height: 25px;">
                    项目编号：
                </td>
                <td width="*" style="background-color: #ffffff; height: 25px; padding-left: 5px;width:35%">
                &nbsp;<%=pcode %>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    阶段：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                &nbsp;<%=stageName %>
                </td>
                 <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                </td>
            </tr>
         </table>
           </div>     
     <div region="center" title="" border="false">  

        <table id="tt"></table>   
    </div>

    <div id="master_menu" style="padding:2px;border:1px solid #ddd; background-color:#F4F4F4">
		<a href="#" id="master_add" onclick="master_add()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'">新增</a>
		<%--<a href="#" id="master_update" style="display:none;" onclick="master_update()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-edit'">修改</a>--%>
		<a href="#" id="master_del" onclick="master_del()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'">删除</a>
        <a href="#" id="master_up" onclick="MoveRow(-1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-up'">上移</a>
        <a href="#" id="master_down" onclick="MoveRow(1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-down'">下移</a>
		<a href="#" id="master_save" onclick="master_save()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'">保存工作内容</a>
        <a href="#" id="master_cancel" onclick="master_cancel()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-undo'">取消</a>
	</div>

   <%-- <div id="item_menu" style="padding:2px;border:1px solid #ddd; background-color:#F4F4F4">
		<a href="#" id="A1" onclick="master_add()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'">新增</a>
		<a href="#" id="A2" onclick="master_del()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'">删除</a>
        <a href="#" id="A3" onclick="MoveRow(-1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-up'">上移</a>
        <a href="#" id="A4" onclick="MoveRow(1)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-down'">下移</a>
		<a href="#" id="A5" onclick="master_save()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="#" id="A6" onclick="master_cancel()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-undo'">取消</a>
	</div>--%>
 </div>

</asp:Content>
