<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Flow_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.Flow.Flow_IDE" %>
<form id="ff" action="">
<table style="width:600px;height:360px;">
        <tr>
            <td id="sidlab" style="width:120px" class="adminTitleLeft">
                系统ID
            </td>
            <td id="sidtxt" style="" class="adminData" >
                <input type="text" id="txtsid" name="txtsid" readonly="readonly" disabled="disabled" onkeydown="stopBackspace();" class="Input200"   />
            </td>
            <td style="width:120px" class="adminTitleLeft">
                有效
            </td>
            <td id="typetxt" style="" class="adminData">
                <input type="checkbox" id="chkStatus" name="chkStatus" />
            </td>
        </tr>
        <tr>
            <td class="adminTitleLeft">
                流程名称
            </td>
            <td class="adminData">
                <input type="text" id="txtName" name="txtName" class="easyui-validatebox Input200 " data-options="required:true, missingMessage: '必填'"/>
            </td>
            <td class="adminTitleLeft">
                应用表单
            </td>
            <td class="adminData">
                <input type="text" id="ddlApplyForm" name="ddlApplyForm" class="Input200" />
            </td>
        </tr>
        <tr>
            <td class="adminTitleLeft">
                适用部门
            </td>
            <td class="adminData">
                <input type="text" id="ddlApplyDept" name="ddlApplyDept" class="Input200" />
            </td>
            <td class="adminTitleLeft">
                适用职级
            </td>
            <td class="adminData">
                <input type="text" id="ddlApplyBanding" name="ddlApplyBanding" class="Input200" data-options="required:true, missingMessage: '必填'" />
            </td>
        </tr>
        <tr>
            <td class="adminTitleLeft">
                描述说明
            </td>
            <td class="adminData" colspan="3">
                <textarea id="txtDescription" name="txtDescription" style="border-color: #a4bed4;
                    border-style: solid; border-width: thin;" rows="3" cols="75"></textarea>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="adminTitleLeft">
            </td>
        </tr>
        <tr>
            <td colspan="4">
            <div id="showtoolbar" >
            </div>
                <table id="tt_sub_ide"></table>
            </td>
        </tr>
    </table>
    </form>
    <script type="text/javascript">
        var editIndex = undefined;

        var lastIndex;
        var urlstr = "";
        var sumbitUrl = "";
        //var toolbar_sub = "";
        var nt_comb = [{ "sid": "0", "name": "跨部门" }, { "sid": "1", "name": "同部门"}];
        var apprCount_comb = [{ "sid": 0, "name": "必须所有人员通过" }, { "sid": 1, "name": "只要一人办理"}];
        var ntype_comb = [];
        var dept_comb = [];
        var banding_comb = [];
        var editType = "";
        //var user_combox = "";
        $(function () {
            $.ajax({
                url: '../Ashx/common.ashx?type=nodeType_comb',
                dataType: 'json',
                async: false,
                success: function (data) {
                    if (data != "") {
                        ntype_comb = data;
                    }
                }
            });
            $.ajax({
                url: '../Ashx/common.ashx?type=dept_tree',
                dataType: 'json',
                async: false,
                success: function (data) {
                    if (data != "") {
                        dept_comb = data;
                        //dept_comb = [{ sid: "", text: "全选"}].concat(data);
                    }
                }
            });
            $.ajax({
                url: '../Ashx/common.ashx?type=banding_comb',
                dataType: 'json',
                async: false,
                success: function (data) {
                    if (data != "") {
                        banding_comb = data;
                    }
                }
            });

            InitControl();
        });

        function openDialog(type, index, title) {
            document.getElementById('edit').style.display = "inline";
            var lock = false;
            //ClearMulCombo();
            editType = type;
            switch (type) {
                case "add":
                    //document.getElementById('sidlab').style.display = "none";
                    document.getElementById('txtsid').style.display = "none";
                    //document.getElementById("typetxt").colSpan = 3;
                    lock = true;
                    urlstr = '';
                    //toolbar_sub = "#tab_toolbar_sub";
                    GetDetail_sub();

                    sumbitUrl = "../Ashx/Flow.ashx?action=add";
                    break;
                case "edit":
                    lock = true;
                    document.getElementById('txtsid').style.display = "inline";
                    showData(index);
                    sumbitUrl = "../Ashx/Flow.ashx?action=edit";
                    break;
                case "copy":
                    lock = true;
                    document.getElementById('txtsid').style.display = "none";
                    showData(index);
                    $('#sidtxt').val('');
                    sumbitUrl = "../Ashx/Flow.ashx?action=add";
                    break;
                case "view":
                    lock = false;
                    document.getElementById('txtsid').style.display = "inline";
                    showData(index);

                    break;
            }

            if (art.dialog.list['flow_ide'] == null) {
                art.dialog({
                    content: document.getElementById('edit'),
                    id: 'flow_ide',
                    title: title,
                    padding: '0px 0px 0px 0px',
                    background: '#c3c3c3',
                    resize: false,
                    width: 200,
                    height: 200,
                    lock: lock,
                    init: function () {
                    },
                    close: function () {
                        ClearControl();
                        return true;
                    }
                    ,
                    button: [{
                        name: '保存',
                        callback: function () {
                            save();
                            return false;
                        },
                        focus: true
                    },
		                {
		                    name: '关闭'
		                }]
                }).show();
            }
            else {
                art.dialog.list['flow_ide'].content(document.getElementById('edit'));
            }

            if (type == 'view') {
                art.dialog.list['flow_ide'].button({ name: '保存', disabled: true });
            }
            art.dialog.list['flow_ide'].size(200, 200);
        }

        function showData(index) {
            var rows = $('#tt').datagrid('getRows');
            var row = rows[index];
            $('#txtsid').attr("value", row.sid);
            $('#txtName').val(row.flow_name);
            $('#txtDescription').val(row.remark);
            if (row.flow_status == '1') {
                $('#chkStatus').attr('checked', true);
            }
            else {
                $('#chkStatus').attr('checked', false);
            }
            //FlowType
            $('#ddlApplyForm').combobox('select', row.rf_sid);
            //applybanding
            arrstr = row.post_sid;
            if (arrstr.Trim().length > 0) {
                arrstr = arrstr.CommaTrim();
                arr = arrstr.split(',');
                for (var i = 0; i < arr.length; i++) {
                    $('#ddlApplyBanding').combobox('select', arr[i]);
                    $('#abcomb_' + arr[i]).attr('checked', true);
                }
            }
            //ApplyDept
            var arrstr = row.dept_sid;
            if (arrstr.Trim().length > 2) {
                arrstr = arrstr.CommaTrim();
//                var arr = arrstr.split(',');
//                for (var i = 0; i < arr.length; i++) {
//                    //$('#ddlApplyDept').combotree("tree").tree('check', arr[i]);
//                    $('#ddlApplyDept').combotree("setValue", arr[i])
                //
                //alert(arrstr);
                //arrstr = arrstr.substring(1, arrstr.length - 2);
                //alert(arrstr);
                var arr = arrstr.split(',');
                $('#ddlApplyDept').combotree("setValues", arr)
            }
            //alert($('#ddlApplyDept').combotree("getValues"));
            //urlstr = '../Ashx/Flow.ashx?action=sub_list&sid=' + row.sid;
            GetDetail_sub('../Ashx/Flow.ashx?action=sub_list&sid=' + row.sid);
        }

        function ClearControl() {
            $('#txtName').val('');
            $('#txtDescription').val('');
            $('#chkStatus').attr('checked', false);

            $('#ddlApplyForm').combobox('clear');

            var rows = $('#tt_sub_ide').datagrid('getRows');
            for (var i = rows.length - 1; i >= 0; i--) {
                $('#tt_sub_ide').datagrid('deleteRow', i);
            }
        }

        function ClearMulCombo() {
            //applybanding
            var arrstr = $('#ddlApplyBanding').combobox('getValues');
            if (arrstr.length > 0) {
                for (var i = 0; i < arrstr.length; i++) {
                    $('#abcomb_' + arrstr[i]).attr('checked', false);
                }
            }
            $('#ddlApplyBanding').combobox('clear');

            //ApplyDept
            var arrstr = $('#ddlApplyDept').combobox('getValues');
            if (arrstr.length > 0) {
                for (var i = 0; i < arrstr.length; i++) {
                    $('#adcomb_' + arrstr[i]).attr('checked', false);
                }
            }
            $('#ddlApplyDept').combobox('clear');

        }

        function nc_comboxFormatter(value) {
            for (var i = 0; i < ntype_comb.length; i++) {
                var text = ntype_comb[i].node_type_name;
                if (ntype_comb[i].sid == value) return text;
            }
            return '';
        }

        function nt_comboxFormatter(value) {
            for (var i = 0; i < nt_comb.length; i++) {
                var text = nt_comb[i].name;
                if (nt_comb[i].sid == value) return text;
            }
            return '';
        }

        function ad_comboxFormatter(value) {
            for (var i = 0; i < dept_comb.length; i++) {
                var text = dept_comb[i].DeptName;
                if (dept_comb[i].DeptID == value) return text;
            }
            return '';
        }

        function ar_comboxFormatter(value) {
            for (var i = 0; i < banding_comb.length; i++) {
                var text = banding_comb[i].role_name;
                if (banding_comb[i].sid == value) return text;
            }
            return '';
        }

        function InitControl() {
            $('#ddlApplyForm').combobox({
                url: '../Ashx/common.ashx?type=form_comb',
                width: 202,
                editable: false,
                multiple: false,
                valueField: 'sid',
                textField: 'form_name',
                required: true,
                missingMessage: '必填',
                onLoadSuccess: function () {
                }
            });

            $('#ddlApplyDept').combotree({
                //url: '../Ashx/common.ashx?type=dept_comb',
                data: dept_comb,
                width: 202,
                editable: false,
                multiple: true,
                panelHeight: "auto",
                valueField: 'id',
                textField: 'text',
                required: true,
                missingMessage: '必填',
                onSelect: function (record) {
                    //$('#adcomb_' + record.sid).attr('checked', true);
                    //alert(record.text);
                },
                onUnselect: function (record) {
                    //$('#adcomb_' + record.sid).attr('checked', false);
                },
                onClick: function (node) {
                    // alert node text property when clicked
                },
                onLoadSuccess: function () {

                },
                onCheck: function (node, checked) {
                    //                    if (checked || node.sid == "") {
                    //                        $('#ddlApplyDept').combotree('selectAll');
                    //                    }
                }
            });

            //FillMultipleCombotree('ddlApplyDept', dept_comb, []);
            FillMultipleCombo('ddlApplyBanding', banding_comb, [{ "sid": "", "role_name": "全选"}], 'sid', 'role_name', []);
            //            $('#ddlApplyBanding').combobox({
            //                //url: '../Ashx/common.ashx?type=dept_comb',
            //                data: banding_comb,
            //                width: 202,
            //                editable: false,
            //                multiple: true,
            //                valueField: 'sid',
            //                textField: 'role_name',
            //                onSelect: function (record) {
            //                    $('#abcomb_' + record.sid).attr('checked', true);
            //                },
            //                onUnselect: function (record) {
            //                    $('#abcomb_' + record.sid).attr('checked', false);
            //                },
            //                formatter: function (row) {
            //                    var text=row.role_name;
            //                    return '<div style="float:left"><input id=abcomb_' + row.sid + ' type="checkbox"/></div><span class="mlength" style="cursor:pointer">&nbsp;&nbsp;' + text + '</span>';
            //                },
            //                onLoadSuccess: function () {

            //                }
            //            });
        }

        //加载详细信息
        function GetDetail_sub(url) {
            $('#tt_sub_ide').datagrid({
                //fit: true,
                height: 230,
                width: 795,
                nowrap: true, //是否换行，True 就会把数据显示在一行里
                singleSelect: true, //多选
                striped: true, //True 奇偶行使用不同背景色
                collapsible: false, //可折叠
                rownumbers: true, //行号
                //remoteSort: false, //定义是否从服务器给数据排序
                //fitColumns: true, //列自适应
                url: url, //请求数据的页面
                //sortName: 'node_no',
                //sortOrder: 'asc', //排序类型
                idField: 'sid', //标识字段,主键

                //toolbar: toolbar_sub,

                frozenColumns: [[
                    { title: '', field: 'ckb', width: 30, checkbox: true, halign: 'center', hidden: true, align: 'center' },
                    { title: '序号', field: 'node_no', width: 40, halign: 'center',
                        editor: { type: 'numberbox', options: { min: 1, required: true, missingMessage: "必填"} }
                    },
                     { title: '节点名称', field: 'node_name', width: 100, halign: 'center',
                         editor: { type: 'validatebox', options: { required: true, missingMessage: "必填"} }
                     },
                    { title: '节点类别', field: 'node_type', width: 60, halign: 'center',
                        editor: { type: 'combobox', options: { data: ntype_comb, valueField: 'sid', editable: false, textField: 'node_type_name', panelHeight: "auto", required: true, missingMessage: "必填",
                            formatter: function (row) {
                                var text = row.node_type_name;
                                return '<span class="mlength" style="cursor:pointer">' + text + '</span>';
                            }
                        }
                        }
                        , formatter: function (value, row, index) {
                            for (var i = 0; i < ntype_comb.length; i++) {
                                var text = ntype_comb[i].node_type_name;
                                if (ntype_comb[i].sid == value) return text;
                            }
                            return '';
                            //return row.node_type_name;
                        }

                    },
                    { title: '节点类型', field: 'appr_dept_type', width: 60, halign: 'center',
                        editor: { type: 'combobox', options: { data: nt_comb, valueField: 'sid', editable: false, textField: 'name', panelHeight: "auto", required: true, missingMessage: "必填",
                            formatter: function (row) {
                                var text = row.name;
                                return '<span class="mlength" style="cursor:pointer">' + text + '</span>';
                            }
                            ,
                            onSelect: function (record) {
                                //var editors = $('#tt_sub_ide').datagrid('getEditors', lastIndex);
                                var editors = $('#tt_sub_ide').datagrid('getEditors', editIndex);
                                var dept = editors[4];
                                if (record.sid == '1') {
                                    $(dept.target).combotree('setValues', '');
                                    $(dept.target).combotree('disable');
                                    //$(dept.target).combotree('options').required=false;
                                }
                                else {
                                    $(dept.target).combotree('enable');
                                    //$(dept.target).combotree('options').required = true;
                                }
                            }
                        }
                        }
                        , formatter: function (value, row, index) {
                            for (var i = 0; i < nt_comb.length; i++) {
                                var text = nt_comb[i].name;
                                if (nt_comb[i].sid == value) return text;
                            }
                            return '';
                            //return row.node_type_name;
                        }
                        //, formatter: nt_comboxFormatter
                    }
                ]]
                ,
                columns: [[

                    { title: '部门', field: 'appr_dept', width: 120, halign: 'center',
                        editor: { type: 'combotree', options: { data: dept_comb, multiple: false, editable: false, valueField: 'id', textField: 'text', panelHeight: "auto",
                            formatter: function (row) {
                                var text = row.text;
                                return '<span class="mlength" style="cursor:pointer">' + text + '</span>';
                            }
                        }
                        }
                        , formatter: function (value, row, index) {
                            for (var i = 0; i < dept_comb.length; i++) {
                                var text = dept_comb[i].text;
                                if (dept_comb[i].id == value) return text;
                            }
                            return '';
                        }
                    },
                    { title: '级别', field: 'appr_role', width: 100, halign: 'center',
                        editor: { type: 'combobox', options: { data: banding_comb, valueField: 'sid', editable: false, textField: 'role_name', panelHeight: "auto", required: true, missingMessage: "必填",
                            formatter: function (row) {
                                var text = row.role_name;
                                return '<span class="mlength" style="cursor:pointer">' + text + '</span>';
                            }
                        }
                        }
                         , formatter: function (value, row, index) {
                             for (var i = 0; i < banding_comb.length; i++) {
                                 var text = banding_comb[i].role_name;
                                 if (banding_comb[i].sid == value) return text;
                             }
                             return '';
                         }
                        //formatter: ad_comboxFormatter, 
                    },
                { title: '多人办理方式 ', field: 'appr_count', width: 120, halign: 'center',
                    editor: { type: 'combobox', options: { data: apprCount_comb, valueField: 'sid', editable: false, textField: 'name', panelHeight: "auto", required: true, missingMessage: "必填",
                        formatter: function (row) {
                            var text = row.name;
                            return '<span class="mlength" style="cursor:pointer">' + text + '</span>';
                        }
                    }
                    }, formatter: function (value, row, index) {
                        for (var i = 0; i < apprCount_comb.length; i++) {
                            var text = apprCount_comb[i].name;
                            if (apprCount_comb[i].sid == value) return text;
                        }
                        return '';
                    }
                },
                { title: '时间(小时)', field: 'appr_time', width: 80, halign: 'center', required: true, missingMessage: "必填",
                    editor: { type: 'numberbox', options: {}
                    }
                }
                    ]],
                onBeforeEdit: function (rowIndex, rowData) {
                },
                onAfterEdit: function (rowIndex, rowData, changes) {
                },
                onClickRow: function (rowIndex, record) {
                    //                    if (lastIndex != rowIndex) {
                    //                        $('#tt_sub_ide').datagrid('endEdit', lastIndex);
                    //                    }
                    //                    $('#tt_sub_ide').datagrid('beginEdit', rowIndex);
                    //                    var editors = $('#tt_sub_ide').datagrid('getEditors', rowIndex);
                    //                    $(editors[0].target).focus();
                    //                    $(editors[0].target).focus(function () {
                    //                        this.select();
                    //                    });
                    //                    var dept = editors[4];

                    //                    if (record.node_dept_type == '1') {
                    //                        $(dept.target).combobox('setValue', '');
                    //                        $(dept.target).combobox('disable');
                    //                    }
                    //                    lastIndex = rowIndex;
                    EditRow(rowIndex);
                },
                toolbar: [{
                    id: 'btnadd',
                    text: '添加',
                    iconCls: 'icon-add',
                    handler: function () {
                        //                        $('#tt_sub_ide').datagrid('endEdit', lastIndex);
                        //                        $('#tt_sub_ide').datagrid('appendRow', {
                        //                            node_no: GetMaxID(),appr_time:0
                        //                        });
                        //                        lastIndex = $('#tt_sub_ide').datagrid('getRows').length - 1;
                        //                        $('#tt_sub_ide').datagrid('selectRow', lastIndex);
                        //                        $('#tt_sub_ide').datagrid('beginEdit', lastIndex);
                        //                        var editors = $('#tt_sub_ide').datagrid('getEditors', lastIndex);
                        //                        $(editors[0].target).focus();
                        //                        $(editors[0].target).focus(function () {
                        //                            this.select();
                        //                        });
                        if (endEditing()) {
                            $('#tt_sub_ide').datagrid('appendRow', { node_no: GetMaxID(), appr_time: 0 }); //, { status: 'P' });
                            editIndex = $('#tt_sub_ide').datagrid('getRows').length - 1;
                            $('#tt_sub_ide').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
                        }
                    }

                }, '-', {
                    id: 'btncut',
                    text: '删除',
                    iconCls: 'icon-del',
                    handler: function () {
                        var row = $('#tt_sub_ide').datagrid('getSelected');
                        //                        if (row) {
                        //                            $.messager.confirm('Confirm', 'Are you sure you want to delete “' + row.node_no + '” record?', function (r) {
                        //                                if (r) {
                        //                                    var index = $('#tt_sub_ide').datagrid('getRowIndex', row);
                        //                                    $('#tt_sub_ide').datagrid('deleteRow', index);
                        //                                }
                        //                            });
                        //                        }
                        if (editIndex == undefined) { return }
                        $.messager.confirm('Confirm', '您确定要删除第' + row.node_no + '条记录吗？', function (r) {
                            if (r) {
                                $('#tt_sub_ide').datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);
                                editIndex = undefined;
                            }
                        });
                        //editIndex = undefined;
                    }
                }]
            });
        }

        function endEditing() {
            if (editIndex == undefined) { return true }
            if ($('#tt_sub_ide').datagrid('validateRow', editIndex)) {
                $('#tt_sub_ide').datagrid('endEdit', editIndex);
                editIndex = undefined;
                return true;
            } else {
                return false;
            }
        }

        function EditRow(index) {
            if (editIndex != index) {
                if (endEditing()) {
                    $('#tt_sub_ide').datagrid('selectRow', index).datagrid('beginEdit', index);
                    editIndex = index;
                } else {
                    $('#tt_sub_ide').datagrid('selectRow', editIndex);
                }
            }
        }

        function EditGrid(row) {
            var index = $('#tt_sub_ide').datagrid('getRowIndex', row);
            $('#tt_sub_ide').datagrid('beginEdit', index);
            var editors = $('#tt_sub_ide').datagrid('getEditors', index);
            var dept = editors[6];
            if (row.node_type == '1') {
                $(dept.target).combobox('setValue', '');
                $(dept.target).combobox('disable');
            }
            editIndex = index;
        }

        function add_sub() {
            //            $('#tt_sub_ide').datagrid('endEdit', lastIndex);
            //            $('#tt_sub_ide').datagrid('appendRow', {
            //                node_no: GetMaxID(), node_name_en: 'Aprrover', node_name_cn: '审批人'
            //            });
            //            lastIndex = $('#tt_sub_ide').datagrid('getRows').length - 1;
            //            $('#tt_sub_ide').datagrid('selectRow', lastIndex);
            //            $('#tt_sub_ide').datagrid('beginEdit', lastIndex);
            //            var editors = $('#tt_sub_ide').datagrid('getEditors', lastIndex);
            //            $(editors[0].target).focus();
            //            $(editors[0].target).focus(function () {
            //                this.select();
            //            });
            if (endEditing()) {
                $('#tt_sub_ide').datagrid('appendRow', {}); //, { status: 'P' });
                editIndex = $('#tt').datagrid('getRows').length - 1;
                $('#tt_sub_ide').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
            }
        }

        function del_sub() {
            //            $('#tt_sub_ide').datagrid('endEdit', lastIndex);
            //            var row = $('#tt_sub_ide').datagrid('getSelected');
            //            if (row) {
            //                $.messager.confirm('Confirm', 'Are you sure you want to delete?', function (r) {
            //                    if (r) {
            //                        $($('#tt_sub_ide').datagrid('getSelections')).each(function () {
            //                            var index = $('#tt_sub').datagrid('getRowIndex', this.node_no);
            //                            $('#tt_sub_ide').datagrid('deleteRow', index);
            //                        });
            //                    }
            //                });
            //            }
            if (editIndex == undefined) { return }
            $('#tt_sub_ide').datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);
            editIndex = undefined;
        }

        function GetMaxID() {
            var rows = $('#tt_sub_ide').datagrid('getRows');
            var revalue = 0;
            for (var i = 0; i < rows.length; i++) {
                if (parseInt(rows[i].node_no) > revalue) {
                    revalue = parseInt(rows[i].node_no);
                }
            }
            revalue += 1;
            return revalue;
        }

        //        function EditGrid(row) {
        //            var index = $('#tt_sub_ide').datagrid('getRowIndex', row);
        //            //alert(index);
        //            $('#tt_sub_ide').datagrid('beginEdit', index);
        //            var editors = $('#tt_sub_ide').datagrid('getEditors', index);
        //            var dept = editors[6];
        //            if (row.node_type == '1') {
        //                $(dept.target).combobox('setValue', '');
        //                $(dept.target).combobox('disable');
        //            }
        //            lastIndex = index;
        //        }

        function ShowButton() {
            art.dialog.list['flow_ide'].button(
            {
                name: '保存',
                disabled: false
            },
            {
                name: '关闭',
                disabled: false
            });
        }

        //保存
        function save() {
            if (endEditing()) {
                var isValid = $('#ff').form('validate');
                if (!isValid) {
                    return isValid;
                }

                //$('#tt_sub_ide').datagrid('endEdit', lastIndex);
                art.dialog.list['flow_ide'].button(
            {
                name: '保存',
                disabled: true
            },
            {
                name: '关闭',
                disabled: true
            });
                var rows = $('#tt_sub_ide').datagrid('getRows');
                if (rows.length <= 0) {
                    $.messager.show({
                        title: '错误提示',
                        msg: '流程步骤表为空，必须添加需要经过的办理流程'
                        //timeout: 5000,
                        //showType: 'slide'
                    });

                    ShowButton();
                    return false;
                }
                for (var i = 0; i < rows.length; i++) {
                    //                    if (i < rows.length - 1) {
                    //                        for (var j = i + 1; j < rows.length; j++) {
                    //                            if (rows[i].node_no == rows[j].node_no) {
                    //                                $.messager.show({
                    //                                    title: '错误提示',
                    //                                    msg: ''
                    //                                });
                    //                                ShowButton();
                    //                                EditGrid(rows[j]);

                    //                                return false;
                    //                            }
                    //                        }
                    //                    }
                    //                    if (i == 1) {
                    //                        if (rows[i - 1].node_dept_type == 0 && rows[i - 1].appr_dept.length <= 0) {
                    //                            $.messager.show({
                    //                                title: '错误提示',
                    //                                msg: '跨部门审核审核部门不能为空，必须选择要审核的部门'
                    //                            });
                    //                            ShowButton();
                    //                            return false;
                    //                        }
                    //                    }
                    //if (rows[i].node_dept_type == 0 && rows[i].appr_dept.length <= 0) {
                    if (rows[i].appr_dept_type == 0 && rows[i].appr_dept.length <= 0) {
                        $.messager.show({
                            title: '错误提示',
                            msg: '跨部门办理部门不能为空，必须选择要办理的部门'
                        });
                        ShowButton();
                        return false;
                    }
                    if (rows.length > 1 && i + 1 < rows.length) {
                        if (rows[i].node_no > rows[i + 1].node_no || rows[i + 1].node_no - 1 > rows[i].node_no) {
                            $.messager.show({
                                title: '错误提示',
                                msg: '序号不连续'
                            });
                            ShowButton();
                            return false;
                        }
                    }
                }

                var delstr = "";
                var updatestr = "";
                var addstr = "";
                switch (editType) {
                    case 'copy':
                        var rows = $('#tt_sub_ide').datagrid('getRows');
                        addstr = JSON.stringify(rows);
                        break;
                    case 'add':
                        var rows = $('#tt_sub_ide').datagrid('getRows');
                        addstr = JSON.stringify(rows);
                        break;
                    case 'edit':
                        var delrows = $('#tt_sub_ide').datagrid('getChanges', 'deleted');
                        //alert('changed rows: ' + rows.length + ' lines'+rows[0].productid);
                        delstr = JSON.stringify(delrows);
                        var updaterows = $('#tt_sub_ide').datagrid('getChanges', 'updated');
                        updatestr = JSON.stringify(updaterows);
                        var addrows = $('#tt_sub_ide').datagrid('getChanges', 'inserted');
                        addstr = JSON.stringify(addrows);
                        break;
                    default:
                        ShowButton();
                        return;
                        break;
                }

                var chk = '';
                if ($("#chkStatus").is(":checked")) {
                    chk = '1';
                } else {
                    chk = '0';
                }
                //combobox getValues传值给后台是以数组形式，后台接收方法：１、Request["参数名[]"]，２、在JS里就传值页面把数组拼接，数组.join(',')以逗号相连接
                //var applyform = $('#ddlApplyForm').combobox('getValues');
                $.ajax({
                    type: "POST",
                    //contentType: "application/json",
                    timeout: 30000, //超时时间：30秒
                    //dataType: 'json',
                    url: sumbitUrl,
                    data: {
                        'sid': $('#txtsid').val(),
                        'Name': $('#txtName').val(),
                        'chkStatus': chk,
                        'ApplyForm': $('#ddlApplyForm').combobox('getValues').join(','),
                        'ApplyBanding': $('#ddlApplyBanding').combobox('getValues').join(','),
                        'ApplyDept': ($('#ddlApplyDept').combotree('getValues')).join(','),
                        'Description': $('#txtDescription').val(),
                        'dept': $('#ddlApplyDept').combotree('getText'),
                        'post': $('#ddlApplyBanding').combobox('getText'),
                        'form': $('#ddlApplyForm').combobox('getText'),
                        'addstr': addstr,
                        'updatestr': updatestr,
                        'delstr': delstr
                    },
                    success: function (data) {

                        if (data == "success") {
                            $('#tt').datagrid("reload");
                            art.dialog.list['flow_ide'].close();
                            $.messager.show({ title: '信息', msg: (data=="success"?"保存成功":data) });
                        }
                        else {
                            $.messager.show({ title: '错误提示', msg: (data=="success"?"保存成功":data) });
                            ShowButton();
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        ShowButton();
                        $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    }
                });
            }
        }
</script>