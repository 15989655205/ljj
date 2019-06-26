<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true"
    CodeBehind="BatchTrack.aspx.cs" Inherits="Maticsoft.Web.Project.BatchTrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="../css/preview.css" rel="stylesheet" type="text/css" />
    <script src="../js/preview1.js" type="text/javascript"></script>
    <script type="text/javascript">
        var columns = "<%=column %>";
        var frozencolumns = "<%=frozencolumns %>";
        var sDateStr = "<%=sDateStr %>";
        var eDateStr = "<%=eDateStr %>";
        var pssid = "<%=pssid %>";

        var editIndex = undefined;
        var editColumn = undefined;

        $(function () {
            getProcessCate();
            InitGird();
            InitProductGird();
        });

        function getProcessCate() {
            $("#ProcessCategory").combobox({
                url: '../ashx/ProjectTemplateTrack.ashx?action=ProcessCategoryClassCombo',
                valueField: 'sid',
                textField: 'category',
                onLoadSuccess: function () {
                }
            });
        }

        //初始化表格
        function InitGird() {
            grid = $('#tt').datagrid({
                fit: true,
                singleSelect: true, //单选
                //rowspan:false,
                //fitColumns: true, //列自适应
                rownumbers: true,
                url: '../Ashx/Project.ashx', //请求数据的页面
                queryParams: { "action": "content_common_item", "pssid": "<%=pssid %>" },
                idField: 'rowid', //标识字段,主键
                frozenColumns: eval('(' + frozencolumns + ')'),
                columns: eval('(' + columns + ')'),
                toolbar: "#toolbar",
                onLoadSuccess: function (data) {
                    if (data.rows.length > 0) { mergeCellsByField('tt', 'stage_name,group_name,contentName'); }
                },
                onClickCell: function (index, field, value) {
                    if (endEditing()) {
                        $('#tt').datagrid('editdgCell', { index: index, field: field });
                        var ed = $('#tt').datagrid('getEditor', { index: index, field: field });
                        if (ed != null) {
                            if (field.indexOf('flow_') >= 0 || field.indexOf('impAbbr_') >= 0) {
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

                //组长审核
                if (editColumn == "v1") {
                    var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'v1' });
                    var header = $(ed.target).combobox('getText');
                    $('#tt').datagrid('getRows')[editIndex]['header'] = header;
                }

                //总审
                if (editColumn == "v2") {
                    ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'v2' });
                    header = $(ed.target).combobox('getText');
                    $('#tt').datagrid('getRows')[editIndex]['finaler'] = header;
                }

                //工作人员
                if (editColumn.indexOf("imp_") >= 0) {
                    ed = $('#tt').datagrid('getEditor', { index: editIndex, field: editColumn });
                    header = $(ed.target).combobox('getText');
                    if (header == "请选择")
                        header = "";
                    $('#tt').datagrid('getRows')[editIndex]['Abbr_' + editColumn] = header;
                }

                $('#tt').datagrid('endEdit', editIndex);
                editIndex = undefined;
                editColumn = undefined;
                mergeCellsByField('tt', 'stage_name,group_name,contentName');
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

        function ProcessCate() {
            art.dialog({
                content: document.getElementById('ProcessCategory_div'),
                lock: true,
                title: '加工类别',
                button:
                [{
                    name: '确认',
                    callback: function () {
                        if ($('#tt').datagrid('getRows').length > 0) {
                            $.messager.confirm('提示', '如果你要更改加工类别已设置好的数据将会丢失，你确认要更改加工类别吗？', function (r) {
                                if (r) {
                                    ChangeProcessCategory();
                                }
                            });
                        }
                        else {
                            ChangeProcessCategory();
                        }
                    }
                },
                {
                    name: '关闭'
                }]
            });
        }

        function ChangeProcessCategory() {
            $.ajax({
                type: "POST",
                async: false,
                url: '../Ashx/ProjectProduct.ashx',
                data: {
                    'action': 'ChangeProcessCategory',
                    'pssid': '<%=pssid %>',
                    'csid': $('#ProcessCategory').combobox("getValue")
                },
                success: function (data) {
                    if (data == "success") {
                        $('#tt').datagrid("reload");
                    }
                    else {
                        $.messager.show({ title: '提示', msg: data });
                        return;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    return;
                }
            });
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



        var ptt_editIndex = undefined;
        //初始化表格
        function InitProductGird() {
            $('#ptt').datagrid({
                fit: true,
                singleSelect: true, //单选
                //rowspan:false,
                //fitColumns: true, //列自适应
                rownumbers: true,
                url: '../Ashx/ProjectProduct.ashx', //请求数据的页面
                queryParams: { "action": "PPBatchList", "pssid": "<%=pssid %>" },
                idField: 'rowid', //标识字段,主键
                rowStyler: function (index, row) {
                    return 'height:50px;';
                },
                columns: [[
             { title: '图纸编号', field: 'number', width: 100, rowspan: 2, halign: 'center', align: 'center',
                 formatter: function (value, rowData, rowIndex) {
                     return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                 },
                 editor: 'text'
             },
             { title: '细目', colspan: 4 },
             { title: '应用空间', field: 'useSpace', width: 150, rowspan: 2, halign: 'center', align: 'center',
                 formatter: function (value, rowData, rowIndex) {
                     return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                 },
                 editor: 'text'
             },
             { title: '应用部位', field: 'usePart', width: 150, rowspan: 2, halign: 'center', align: 'center',
                 formatter: function (value, rowData, rowIndex) {
                     return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                 },
                 editor: 'text'
             },
             { title: '单位', field: 'unit', width: 60, rowspan: 2, halign: 'center', align: 'center',
                 formatter: function (value, rowData, rowIndex) {
                     return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                 },
                 editor: 'text'
             },
             { title: '数量', field: 'amount', width: 60, rowspan: 2, halign: 'center', align: 'center',
                 formatter: function (value, rowData, rowIndex) {
                     return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                 },
                 editor: { type: 'numberbox', options: { precision: 2} }
             },
             { title: '成品', field: 'EndProduct', width: 120, rowspan: 2, halign: 'center', align: 'center',
                 formatter: function (value, rowData, rowIndex) {
                     return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                 },
                 editor: 'text'
             },
             { title: '备注', field: 'remark', width: 200, rowspan: 2, halign: 'center', align: 'center',
                 formatter: function (value, rowData, rowIndex) {
                     return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                 },
                 editor: 'text'
             }
            ],
            [
            { title: '名称', field: 'productName', width: 100, halign: 'center', align: 'center',
                formatter: function (value, rowData, rowIndex) {
                    return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                }
            },
            { title: '图片', field: 'productPic', width: 80, halign: 'center', align: 'center',
                formatter: function (value, rowData, rowIndex) {
                    if (value != '') {
                        return "<a path='/ProductPic/" + value + "' class='preview'><img alt='' height='45px' src='/ProductPic/" + value + "'></a>";
                    }
                }
            },
            { title: '图纸规格', field: 'productSize', width: 100, halign: 'center', align: 'center',
                formatter: function (value, rowData, rowIndex) {
                    return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                }
            },
                        { title: '漆面颜色 ', field: 'paintColor', width: 100, halign: 'center', align: 'center',
                            formatter: function (value, rowData, rowIndex) {
                                return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                            },
                            editor: 'text'
                        }
            ]],
                toolbar: "#productToolbar",
                onLoadSuccess: function (data) {
                    //if (data.rows.length > 0) { mergeCellsByField('tt', 'stage_name,group_name,contentName'); }
                },
                onClickCell: function (index, field, value) {
                },
                onClickRow: function (index, rowData) {
                    ptt_EditRow(index);
                }
            });
        }

        function ptt_endEditing() {
            if (ptt_editIndex == undefined) { return true }
            if ($('#ptt').datagrid('validateRow', ptt_editIndex)) {
                $('#ptt').datagrid('endEdit', ptt_editIndex);
                ptt_editIndex = undefined;
                return true;
            } else {
                return false;
            }
        }

        function ptt_EditRow(index) {
            if (ptt_editIndex != index) {
                if (ptt_endEditing()) {
                    $('#ptt').datagrid('selectRow', index).datagrid('beginEdit', index);
                    ptt_editIndex = index;
                } else {
                    $('#ptt').datagrid('selectRow', ptt_editIndex);
                }
            }
        }

        function ptt_EditGrid(row) {
            var index = $('#ptt').datagrid('getRowIndex', row);
            $('#ptt').datagrid('beginEdit', index);
            var editors = $('#ptt').datagrid('getEditors', index);
            ptt_editIndex = index;
        }

        function addProduct() {
            art.dialog.data('id', '');
            art.dialog.data('name', '');
            art.dialog.data('image', '');
            art.dialog.data('size', '');

            var ids = "";
            var rows = $('#ptt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                ids += rows[i].ProductID + ",";

            }
            if (ids.length > 0) {
                ids = ids.substr(0, ids.length - 1);
            }
            SelectWindow_add("/windows/ProjectProductBatch.aspx?productID=" + ids);
        }

        function delProduct() {
            if (ptt_editIndex == undefined) { return }
            $('#ptt').datagrid('cancelEdit', ptt_editIndex).datagrid('deleteRow', ptt_editIndex);
            ptt_editIndex = undefined;
        }

        function SelectWindow_add(url) {
            art.dialog.open(url,
            { title: '选择', width: 700, height: 460,
                close: function () {
                    //alert(art.dialog.data('id'));
                    if (art.dialog.data('id') != undefined && art.dialog.data('id') != '') {
                        var id = art.dialog.data('id').split('|');
                        var name = art.dialog.data('name').split('|');
                        var image = art.dialog.data('image').split('|');
                        var size = art.dialog.data('size').split('|');

                        for (var i = 0; i < id.length; i++) {
                            if (id[i] != '') {
                                $('#ptt').datagrid('appendRow', {
                                    //parent: node.id,  // the node has a 'id' value that defined through 'idField' property{
                                    ProductID: id[i],
                                    number: '',
                                    useSpace: '',
                                    usePart: '',
                                    paintColor:'',
                                    unit: '',
                                    amount: '',
                                    EndProduct: '',
                                    remark: '',
                                    productPic: image[i],
                                    productName: name[i],
                                    productSize: size[i]

                                });
                            }
                        }
                        //$('#ptt').datagrid('reload');
                    }
                }
            }, false);
        }

        function saveProduct() {
            if (ptt_endEditing()) {
                //$('#dg').datagrid('acceptChanges');
                var rows = $('#ptt').datagrid('getRows');
                for (var i = 0; i < rows.length; i++) {
                    if (rows[i].amount.length <= 0) {
                        //alert('数量不能为空！');
                        $.messager.show({ title: '错误提示', msg: "数量不能为空！" });
                        ptt_EditGrid(rows[i]);
                        return false;
                    }
                    //                if (rows[i].amount.length <= 0) {
                    //                    $.messager.show({ title: '错误提示', msg: "数量不能为空！" });
                    //                    ptt_EditGrid(rows[i]);
                    //                    return false;
                    //                }

                }

                var delstr = "";
                var updatestr = "";
                var addstr = "";
                var delrows = $('#ptt').datagrid('getChanges', 'deleted');
                delstr = JSON.stringify(delrows);
                var updaterows = $('#ptt').datagrid('getChanges', 'updated');
                updatestr = JSON.stringify(updaterows);
                var addrows = $('#ptt').datagrid('getChanges', 'inserted');
                addstr = JSON.stringify(addrows);
                $.ajax({
                    type: "POST",
                    timeout: 30000, //超时时间：30秒
                    url: '../Ashx/ProjectProduct.ashx',
                    data: {
                        'action': 'PPEdit',
                        'pssid': '<%=pssid %>',
                        'addstr': addstr,
                        'updatestr': updatestr,
                        'delstr': delstr
                    },
                    success: function (data) {
                        if (data == "success") {
                            $('#ptt').datagrid("reload");
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

        function cancelProduct() {
            $('#ptt').datagrid('rejectChanges');
            ptt_editIndex = undefined;
        }

        function upHide() {
            //$('#tr1').hide();collapse
            if ($("#down").is(":hidden")) {
                $('#down').show();
                $('#cc').layout('panel', 'north').panel('restore');
            } else {
                $('#cc').layout('collapse', 'north');
            }
        }

        function downHide() {
            //$('#tr1').hide();collapse
            $('#cc').layout('panel', 'north').panel('maximize');
            $('#down').hide();
        }

        function restore() {
            $('#cc').layout('panel', 'north').panel('restore');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="cc" class="easyui-layout" fit="true" border="false" style="overflow-y: hidden"
        scroll="no">
        <div region="north" title="<%=pname %>>><%=stageName %>" data-options="collapsible:false"
            border="false" split="false" style="height: 300px;">
            <div id="cc1" class="easyui-layout" fit="true" border="false" style="overflow-y: hidden"
                scroll="no">
                <div region="center" title="" border="false" split="false">
                    <table id="ptt">
                    </table>
                </div>
                <div region="south" title="" border="false" split="false">
                    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                        <tr>
                            <td align="left" colspan="2" style="height: 25px; background-color: #e1f5fc;">
                                <strong>工作细目</strong>
                                <%-- <div style="float:right"><a id="A1" href="#" onclick="trHide()" class="easyui-linkbutton" data-options="iconCls:'icon-print'">隐藏</a> </div>--%>
                                <%--<a id="A3" href="#" onclick="restore()" style="cursor:pointer;">
                       <div style="float:left;width:16px;height:16px;background: url('../js/themes/metro/images/panel_tools.png') no-repeat -16px -16px;"></div>
                       </a>--%>
                                <div style="float: right; margin-right: 10px;">
                                    <a id="A1" href="#" onclick="upHide()" style="cursor: pointer;">
                                        <div style="float: left; width: 16px; height: 16px; background: url('../js/themes/metro/images/layout_arrows.png') no-repeat -16px -16px;">
                                        </div>
                                    </a>
                                </div>
                                <div id="down" style="float: right; margin-right: 10px;">
                                    <a id="A2" href="#" onclick="downHide()" style="cursor: pointer;">
                                        <div style="float: left; width: 16px; height: 16px; background: url('../js/themes/metro/images/layout_arrows.png') no-repeat -16px 0px;">
                                        </div>
                                    </a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div region="center" title="" border="false">
            <div class="easyui-panel" data-options="fit:true,border:false">
                <table id="tt">
                </table>
            </div>
        </div>
    </div>
    <input type="hidden" id="hpssid" name="hpssid" value="<%=pssid %>" />
    <div id="toolbar" style="display: none;">
        <a href="#" id="A8" class="easyui-linkbutton" plain="true" onclick="ProcessCate()"
            iconcls="icon-edit">
            <%=showContent %></a> <a href="#" id="tab_a_01" class="easyui-linkbutton" plain="true"
                onclick="add()" iconcls="icon-add">添加<%=showItem%></a> <a href="#" id="A3" class="easyui-linkbutton"
                    plain="true" onclick="Item_del()" iconcls="icon-remove">删除<%=showItem%></a>
        <a href="#" id="A4" class="easyui-linkbutton" plain="true" onclick="MoveRow(-1)"
            iconcls="icon-up">上移</a> <a href="#" id="A5" class="easyui-linkbutton" plain="true"
                onclick="MoveRow(1)" iconcls="icon-down">下移</a> <a href="#" id="A6" class="easyui-linkbutton"
                    plain="true" onclick="save()" iconcls="icon-save">保存</a> <a href="#" id="A7" class="easyui-linkbutton"
                        plain="true" onclick=" cancel();" iconcls="icon-undo">撤销</a>
    </div>
    <div id="productToolbar" style="display: none;">
        <a href="#" id="A9" class="easyui-linkbutton" plain="true" onclick="addProduct()"
            iconcls="icon-add">添加产品</a> <a href="#" id="A10" class="easyui-linkbutton" plain="true"
                onclick="delProduct()" iconcls="icon-remove">删除</a> <a href="#" id="A13" class="easyui-linkbutton"
                    plain="true" onclick="saveProduct();" iconcls="icon-save">保存</a> <a href="#" id="A14"
                        class="easyui-linkbutton" plain="true" onclick=" cancelProduct();" iconcls="icon-undo">
                        撤销</a>
    </div>
    <div id="ProcessCategory_div">
        <input id="ProcessCategory" />
    </div>
</asp:Content>
