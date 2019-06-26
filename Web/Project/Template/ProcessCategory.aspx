<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProcessCategory.aspx.cs" Inherits="Maticsoft.Web.Project.Template.ProcessCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    var editIndex = undefined;
    var work_editIndex = undefined;
    var ppcsid = undefined;

    $(function () {
        //document.getElementById('pc_east').style.width = 500; //(document.getElementById('pc_cc').style.width - 200); 
        $('#pc_cc').layout('panel', 'east').panel('resize', { width: (parseInt(document.getElementById('pc_cc').style.width) - 300) });
        $('#pc_cc').layout('resize');

        CategoryGrid();
        InitWorkBreakdownGrid();
    });

    function CategoryGrid() {
        $('#tt').datagrid({
            url: '../../Ashx/ProjectTemplateTrack.ashx', //请求数据的页面
            queryParams: { "action": "ProcessCategoryList" },
           // idField: 'sid',
            //toolbar: "#tab_toolbar",
            fit: true,
            fitColumns: true,
            striped: true, //True 奇偶行使用不同背景色
            rownumbers: true,
            singleSelect: true,
            remoteSort: false,
            columns: [[
					{ field: 'category', title: '货物类别', width: 500, sortable: true, editor: "text" },
					{ field: 'Caption', title: '工作类别', width: 250, sortable: true,

					    editor:
                    {
                        type: 'combobox',
                        options: {
                            valueField: 'Value',
                            textField: 'Caption',
                            url: '../../Ashx/ProjectTemplateTrack.ashx?action=WorkType',
                            required: true
                        }
                    }
					},

				]],
            toolbar: [{
                iconCls: 'icon-add',
                text: '新增',
                handler: function () { add() }
            }, {
                iconCls: 'icon-remove',
                text: '删除',
                handler: function () { del() }
            }, '-', {
                iconCls: 'icon-save',
                text: '保存',
                handler: function () { save() }
            }, {
                iconCls: 'icon-undo',
                text: '撤消',
                handler: function () { cancel() }
            }
                ],
            onClickRow: function (index, rowData) {
                EditRow(index);
                ShowWorkBreakdown(rowData.sid);
                ppcsid = rowData.sid;
            }
        });
    }

    function InitWorkBreakdownGrid() {
        $('#work_tt').datagrid({
            url: '../../Ashx/ProjectTemplateTrack.ashx', //请求数据的页面
            queryParams: { "action": "WorkBreakdowList", ppcsid: "0" },
            idField: 'sid',
            //toolbar: "#tab_toolbar",
            fit: true,
            fitColumns: true,
            striped: true, //True 奇偶行使用不同背景色
            rownumbers: true,
            singleSelect: true,
            remoteSort: false,
            columns: [[
					{ field: 'work_breakdown', title: '工作细目', width: 300, sortable: true, editor: "text" },
					{ field: 'remark', title: '备注', width: 300, sortable: true, editor: "text" },
                    { field: 'create_person', title: '创建人', width: 100, sortable: true },
                    { field: 'create_date', title: '创建时间', width: 100, sortable: true },
                    { field: 'update_person', title: '变更人', width: 100, sortable: true },
                    { field: 'update_date', title: '变更时间', width: 100, sortable: true },
                    { field: 'sid', title: '编号', editor: "text", hidden: true }

				]],
            toolbar: [{
                iconCls: 'icon-add',
                text: '新增',
                handler: function () { work_add() }
            }, {
                iconCls: 'icon-remove',
                text: '删除',
                handler: function () { work_del() }
            }, '-', {
                iconCls: 'icon-up',
                text: '上移',
                handler: function () { work_MoveRow(-1) }
            }, {
                iconCls: 'icon-down',
                text: '下移',
                handler: function () { work_MoveRow(1) }
            }, '-', {
                iconCls: 'icon-save',
                text: '保存',
                handler: function () { work_save() }
            }, {
                iconCls: 'icon-undo',
                text: '撤消',
                handler: function () { work_cancel() }
            }
                ],
            onClickRow: function (index, rowData) {
                work_EditRow(index);
            }
        });
    }

    function ShowWorkBreakdown(ppcsid) {
        $('#work_tt').datagrid('options').queryParams = { "action": "WorkBreakdowList", ppcsid: ppcsid };
        $('#work_tt').datagrid('load');
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

    function add() {

        $('#tt').datagrid('insertRow', { index: 0, row: {} });
        editIndex = $('#tt').datagrid('getRows').length;
        //alert(editIndex);
        $('#tt').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
       
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
                if (rows[i].category.length <= 0||rows[i].Caption.length <= 0) {
                    alert('货物类别和工作类别不能为空！');
                    //ShowButton();
                    EditGrid(rows[i]);
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].category == rows[j].category) {
                            $.messager.show({ title: '提示', msg: '类别名称出现重复'});
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
            //alert(delstr);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../../Ashx/ProjectTemplateTrack.ashx',
                data: {
                    'action': 'ProcessCategoryEdit',
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


    function work_endEditing() {
        if (work_editIndex == undefined) { return true }
        if ($('#work_tt').datagrid('validateRow', work_editIndex)) {
            $('#work_tt').datagrid('endEdit', work_editIndex);
            work_editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function work_EditRow(index) {
        if (work_editIndex != index) {
            if (work_endEditing()) {
                $('#work_tt').datagrid('selectRow', index).datagrid('beginEdit', index);
                work_editIndex = index;
            } else {
                $('#work_tt').datagrid('selectRow', work_editIndex);
            }
        }
    }

    function work_EditGrid(row) {
        var index = $('#tt').datagrid('getRowIndex', row);
        $('#tt').datagrid('beginEdit', index);
        var editors = $('#tt').datagrid('getEditors', index);
        work_editIndex = index;
    }

    function work_MoveRow(fx) {
        if (work_endEditing()) {
            var gd = $('#work_tt');
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
//            var RowTemp = { work_breakdown: "", remark: "", sid: "" };
//            RowTemp.work_breakdown = gdData.rows[iMovedRowIndex].work_breakdown;
//            RowTemp.remark = gdData.rows[iMovedRowIndex].remark;
//            RowTemp.sid = gdData.rows[iMovedRowIndex].sid;
//            gdData.rows[iMovedRowIndex].work_breakdown = gdData.rows[iCurRowIndex].work_breakdown;
//            gdData.rows[iMovedRowIndex].remark = gdData.rows[iCurRowIndex].remark;
//            gdData.rows[iMovedRowIndex].sid = gdData.rows[iCurRowIndex].sid;

//            var edt = gd.datagrid("getEditors", iCurRowIndex);
//            edt[0].target.val(RowTemp.work_breakdown);
//            edt[1].target.val(RowTemp.remark);
//            edt[2].target.val(RowTemp.sid);

//            gd.datagrid('endEdit', iCurRowIndex);
//            gd.datagrid('unselectRow', iCurRowIndex);
//            gd.datagrid('selectRow', iMovedRowIndex);
//            gd.datagrid('beginEdit', iMovedRowIndex);
//            work_editIndex = iMovedRowIndex;
            //            gd = null;

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

    function work_add() {
        if (ppcsid != undefined) {
            if (work_endEditing()) {
                $('#work_tt').datagrid('appendRow', { ppcm_sid: ppcsid, sid: 0, sequence: $('#work_tt').datagrid('getRows').length }); //, { status: 'P' });
                work_editIndex = $('#work_tt').datagrid('getRows').length - 1;
                $('#work_tt').datagrid('selectRow', work_editIndex).datagrid('beginEdit', work_editIndex);
            }
        } else {
            $.messager.show({ title: '提示', msg: "请选择加工类别" });
        }
    }

    function work_del() {
        if (work_editIndex == undefined) { return }
        $('#work_tt').datagrid('cancelEdit', work_editIndex).datagrid('deleteRow', work_editIndex);
        work_editIndex = undefined;

    }

    function work_save() {
        if (work_endEditing()) {
            var rows = $('#work_tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].work_breakdown.length <= 0) {
                    alert('类别名称不能为空！');
                    //ShowButton();
                    work_EditGrid(rows[i]);
                    return false;
                }
                if (i < rows.length - 1) {
                    for (var j = i + 1; j < rows.length; j++) {
                        if (rows[i].work_breakdown == rows[j].work_breakdown) {
                            $.messager.show({ title: '提示', msg: '类别名称出现重复' });
                            work_EditRow(j);
                            return false;
                        }
                    }
                }
            }

            var allstr = "";
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allrows = $('#work_tt').datagrid('getRows');
            allstr = JSON.stringify(allrows);
            var delrows = $('#work_tt').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delrows);
            var updaterows = $('#work_tt').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updaterows);
            var addrows = $('#work_tt').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addrows);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../../Ashx/ProjectTemplateTrack.ashx',
                data: {
                    'action': 'WorkBreakdownEdit',
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr,
                    'allstr':allstr
                },
                success: function (data) {
                    if (data == "success") {
                        $('#work_tt').datagrid("reload");
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

    function work_cancel() {
        $('#work_tt').datagrid('rejectChanges');
        work_editIndex = undefined;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="pc_cc" class="easyui-layout" fit="true">   
    <div id="pc_east" data-options="region:'east',iconCls:'',title:'工作细目',split:true" >
    <table id="work_tt"></table>
    </div>   
    <div data-options="region:'center',title:'货物类别'" >
    <div style="  padding-bottom:2px; padding-top:2px;">
 <span> &nbsp; &nbsp;类别选择：</span> <input id="cbx" style=" width:150px;" name="dept" value="" >  
 </div>
<script type="text/javascript">

    $('#cbx').combobox({
        url: '../../Ashx/ProjectTemplateTrack.ashx?action=WorkType',
        valueField: 'Value',
        textField: 'Caption',
        onLoadSuccess: function () {
            $('#cbx').combobox('setValue', '请选择');
        },
        onSelect: function (record) {

            if (record.Value != "5") {
                $('#tt').datagrid("options").queryParams = { "action": "ReloadTableByType", "id": record.Value };
            }
            else {

                CategoryGrid();
            }
            $("#tt").datagrid("reload");

        }
    });




</script>
 


    <table id="tt"></table>
    <p>&nbsp;</p>
    </div>  
</div>  

</asp:Content>
