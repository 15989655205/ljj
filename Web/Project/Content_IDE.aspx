<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Content_IDE.aspx.cs" Inherits="Maticsoft.Web.Project.Content_IDE" %>
<%--<%@ Register TagPrefix="pc_IDE" TagName="PC_IDE" Src="../Controls/Project/ContentConstruction_IDE.ascx" %>--%>
<%@ Register TagPrefix="pc_IDE" TagName="PC_IDE" Src="../Controls/Project/Content_IDE.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../js/themes/default/datagrid2.css" rel="stylesheet" type="text/css" />
    <script src="../js/easyui/jquery.datagrid_1.js" type="text/javascript"></script>
    <link href="../js/jquery.jqGrid-4.5.2/css/jquery-ui-custom.css" rel="stylesheet" type="text/css" />
    <link href="../js/jquery.jqGrid-4.5.2/css/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.jqGrid-4.5.2/js/jquery.jqGrid.min.js" type="text/javascript"></script>
    <%--<script src="../js/jquery.jqGrid-4.5.2/js/jquery.jqGrid.src_1.js" type="text/javascript"></script>--%>
    <script src="../js/jquery.jqGrid-4.5.2/js/i18n/grid.locale-cn.js" type="text/javascript"></script>
    <script src="../js/jq.common.js" type="text/javascript"></script>
    <script type="text/javascript">
        var editIndex = undefined;
        var editColumn = undefined;
        var columns = "<%=column %>";
        var frozencolumns = "<%=frozencolumns %>";
        var pssid = "<%=pssid %>";
        var colNames = "<%=colNames %>";
        var colModel = "<%=colModel %>";
        var groupHeaders1 = "<%=groupHeaders1 %>";
        var groupHeaders2 = "<%=groupHeaders2 %>";
        var sDateStr = "<%=sDateStr %>";
        var eDateStr = "<%=eDateStr %>";
        $(function () {
            
            InitEasyuiGird_frozen();
            //InitJQGird();
        });

//        $(window).resize(function () {
//            $(window).unbind("onresize");
//            $("#tt").setGridHeight($(window).height() - 190);
//            $(window).bind("onresize", this);
        //        }); 

//        $(window).bind('resize', function () {
//            //$("#tt").setGridWidth($(window).width() * 0.75);
//            $("#tt").setGridHeight($(window).height() * 0.68);
        //        });

        var t = document.documentElement.clientWidth;
        window.onresize = function () {
            if (t != document.documentElement.clientWidth) {
                t = document.documentElement.clientWidth;
                doResize();
            }
        }

        function doResize() {
            var ss = getPageSize();
            //$("#tt").jqGrid('setGridWidth', ss.WinW - 10).jqGrid('setGridHeight', ss.WinH - 100);
            $("#tt").jqGrid('setGridWidth', ss.WinW - 10).jqGrid('setGridHeight', ss.WinH - 120);
        }

        function getPageSize() {
            var winW, winH;
            if (window.innerHeight) {// all except IE 
                winW = window.innerWidth;
                winH = window.innerHeight;
            } else if (document.documentElement && document.documentElement.clientHeight) {// IE 6 Strict Mode 
                winW = document.documentElement.clientWidth;
                winH = document.documentElement.clientHeight;
            } else if (document.body) { // other 
                winW = document.body.clientWidth;
                winH = document.body.clientHeight;
            }  // for small pages with total size less then the viewport  
            return { WinW: winW, WinH: winH };
        }

        function test() {
            alert();
        }

        var lastsel;
        function InitJQGird() {
            jQuery("#tt").jqGrid({
                url: '../Ashx/Project.ashx?action=construction_item&pssid=<%=pssid %>',
                datatype: "json",
                colNames: eval('(' + colNames + ')'), //['Inv No', 'Date', 'Client', 'Amount', 'Tax', 'Total', 'Notes'],
                colModel: eval('(' + colModel + ')'),
                viewrecords: true,
                //width: window.screen.availWidth - 20,
                //shrinkToFit: true,  
                //height: 300,
                //width: 700,
                //autowidth: true,
                //fit:true,
                //toolbar: [true, "top"],
                rowNum: -1,
                editurl: '../Ashx/ProjectConstruction.ashx?action=edit',
                jsonReader: {
                    repeatitems: false
                },
                shrinkToFit: false,
                caption: "<%=pname %>>><%=stageName %>",
                gridComplete: function () {
                    //②在gridComplete调用合并方法
                    var gridName = "tt";
                    Merger(gridName, 'contentName');
                },
                onSelectRow: function (id) {
                    var row = jQuery('#tt').jqGrid('getRowData', lastsel);
                    //alert(row.sid);
                    saveparameters = {
                        "successfunc": function (response) {
                            //var data = eval(xhr.responseText);   // nothing happens
                            //alert(JSON.stringify(response));
                            alert(response.responseText);
//                            if (data.result == "success") {
//                                jQuery("#" + tableId).jqGrid('delRowData', rowId);
//                            }
                        }, //null,//function (data) { alert(data); },
                        "url": null,
                        "extraparam": { 'psi_sid': $(row.sid).val(), 'cid': $(row.csid).val() },
                        //"aftersavefunc": null,
                        "errorfunc": null,
                        //"afterrestorefunc": null,
                        //"restoreAfterError": true,
                        "mtype": "POST"
                    }
                    editparameters = {
                        "keys": true,
                        "oneditfunc": null,
                        "successfunc": null,
                        "url": null,
                        "extraparam": { 'psi_sid': row.sid, 'cid': row.csid },
                        "aftersavefunc": null,
                        "errorfunc": null,
                        "afterrestorefunc": null,
                        "restoreAfterError": true,
                        "mtype": "POST"
                    }
                    if (id) {
                        jQuery('#tt').jqGrid('saveRow', lastsel, saveparameters);
                        //jQuery('#tt').saveRow(lastsel, false, 'clientArray');
                        jQuery('#tt').jqGrid('editRow', id, true, saveparameters);
                        //jQuery('#tt').editRow(id);
                        lastsel = id;
                    }
                }

            });

            //多重表头
            //顶级表头
            jQuery("#tt").jqGrid('setGroupHeaders', {
                useColSpanStyle: true, //没有表头的列是否与表头列位置的空单元格合并
                groupHeaders: eval('(' + groupHeaders1 + ')')
            });
            //二级表头
            jQuery("#tt").jqGrid('setGroupHeaders', {
                useColSpanStyle: false, //没有表头的列是否与表头列位置的空单元格合并
                groupHeaders: eval('(' + groupHeaders2 + ')')
            });

            jQuery("#tt").jqGrid('setFrozenColumns');

            //            jQuery("#tt").jqGrid('navGrid', '#menu', { edit: false, add: true, del: false });

            doResize();
        }

        //公共调用方法
        function Merger(gridName, CellName) {
            //得到显示到界面的id集合
            var mya = $("#" + gridName + "").getDataIDs();
            //当前显示多少条
            var length = mya.length;
            for (var i = 0; i < length; i++) {
                //从上到下获取一条信息
                var before = $("#" + gridName + "").jqGrid('getRowData', mya[i]);
                //定义合并行数
                var rowSpanTaxCount = 1;
                for (j = i + 1; j <= length; j++) {
                    //和上边的信息对比 如果值一样就合并行数+1 然后设置rowspan 让当前单元格隐藏
                    var end = $("#" + gridName + "").jqGrid('getRowData', mya[j]);
                    if (before[CellName] == end[CellName]) {
                        rowSpanTaxCount++;
                        $("#" + gridName + "").setCell(mya[j], CellName, '', { display: 'none' });
                    } else {
                        rowSpanTaxCount = 1;
                        break;
                    }
                    $("#" + CellName + "" + mya[i] + "").attr("rowspan", rowSpanTaxCount);
                }
            }
        }

        //初始化表格
        function InitEasyuiGird() {
            //alert(eval("("+ columns+")");
            grid = $('#tt').datagrid({
                title: "<%=pname %>>><%=stageName %>",
                fit: true,
                singleSelect: true, //单选
                //rowspan:false,
                //fitColumns: true, //列自适应
                url: '../Ashx/Project.ashx', //请求数据的页面
                queryParams: { "action": "content_item", "pssid": "<%=pssid %>" },
                idField: 'rowid', //标识字段,主键

                columns:   columns ,
                toolbar: "#menu",
                onLoadSuccess: function (data) {
                    if (data.rows.length > 0) { mergeCellsByField('tt', 'stage_name,group_name,contentName'); }
                },
                onClickRow: function (row) {
                }
//                ,
//                onRowContextMenu: function (e, rowIndex, rowData) {
//                    e.preventDefault();
//                    var selected = $("#tt").datagrid('getRows'); //获取所有行集合对象
//                    var idValue = selected[rowIndex].sid;
//                    $(this).datagrid('selectRecord', idValue);  //通过获取到的id的值做参数选中一行
//                    $('#content_mm').menu('show', {
//                        left: e.pageX,
//                        top: e.pageY
//                    });
//                }
            });
        }

        //初始化表格
        function InitEasyuiGird_frozen() {
            grid = $('#tt').datagrid({
                title: "<%=pname %>>><%=stageName %>",
                fit: true,
                singleSelect: true, //单选
                //rowspan:false,
                //fitColumns: true, //列自适应
                url: '../Ashx/Project.ashx', //请求数据的页面
                queryParams: { "action": "construction_item_gridedit", "pssid": "<%=pssid %>" },
                idField: 'rowid', //标识字段,主键
                frozenColumns: eval('(' + frozencolumns + ')'),
                columns: eval('(' + columns + ')'),
                toolbar: "#toolbar",
                //                toolbar: [{
                //                    iconCls: 'icon-add',
                //                    text: '添加空间',
                //                    handler: function () {
                //                        var row = $('#tt').datagrid('getSelected');
                //                        if (art.dialog.get('pc_dialog') != null) {
                //                            art.dialog.get('pc_dialog').close();
                //                        }
                //                        content_action = "pro_content_add";
                //                        content_editType = "add";
                //                        pc_openDialog("add", "<%=pssid %>", row, "<%=showContent %>", "<%=isConstruction %>");
                //                    }
                //                }, {
                //                    iconCls: 'icon-edit',
                //                    text: '修改空间',
                //                    handler: function () {
                //                        var row = $('#tt').datagrid('getSelected');
                //                        if (row != null) {
                //                            if (art.dialog.get('pc_dialog') != null) {
                //                                art.dialog.get('pc_dialog').close();
                //                            }
                //                            content_action = "pro_content_edit";
                //                            content_editType = "alter";
                //                            pc_openDialog("alter", "<%=pssid %>", row, "修改<%=showContent %>", "<%=isConstruction %>");
                //                        } else {
                //                            $.messager.show({ title: '提示', msg: "请选择要修改<%=showContent %>" });
                //                        }
                //                    }
                //                }, {
                //                    iconCls: 'icon-remove',
                //                    text: '删除空间',
                //                    handler: function () {
                //                        delContent();
                //                    }
                //                }, '-', {
                //                    iconCls: 'icon-add',
                //                    text: '添加图纸及索引',
                //                    handler: function () {
                //                        add();
                //                    }
                //                }, {
                //                    iconCls: 'icon-remove',
                //                    text: '删除图纸及索引',
                //                    handler: function () {
                //                        Item_del();
                //                    }
                //                }, {
                //                    iconCls: 'icon-up',
                //                    text: '上移',
                //                    handler: function () {
                //                        MoveRow(-1);
                //                    }
                //                }, {
                //                    iconCls: 'icon-down',
                //                    text: '下移',
                //                    handler: function () {
                //                        MoveRow(1);
                //                    }
                //                }, {
                //                    iconCls: 'icon-save',
                //                    text: '保存图纸及索引',
                //                    handler: function () {
                //                        save();
                //                    }
                //                }, {
                //                    iconCls: 'icon-undo',
                //                    text: '撤消',
                //                    handler: function () {
                //                        cancel();
                //                    }
                //                }],
                onLoadSuccess: function (data) {
                    //if (data.rows.length > 0) { mergeCellsByField('tt', 'stage_name,group_name,contentName'); }
                },
                onClickCell: function (index, field, value) {
                    //EditCell(row.sid, field);
                    //                    var flag = true
                    //                    if (index != editIndex) {
                    //                        flag = endEditing();
                    //                    }
                    //                    if (flag) {
                    if (endEditing()) {
                        $('#tt').datagrid('editdgCell', { index: index, field: field });
                        var ed = $('#tt').datagrid('getEditor', { index: index, field: field });
                        if (ed != null) {
                            if (field.indexOf('imp_') >= 0) {

                                if (value != "") {
                                    //$(ed.target).combobox('setValues', value.split(','));
                                }
                                else {
                                    $(ed.target).combobox('clear');
                                }
                            }
                            else {
                                if (field.indexOf('flow_') >= 0) {
                                    if ($(ed.target).val() == "") {
                                        $(ed.target).val("✓");
                                    }
                                }
                                if ($(ed.target).attr("disabled") != "disabled") {
                                    $(ed.target).focus();
                                    $(ed.target).select();
                                }
                            }
                            editIndex = index;
                            //var ed = $('#dg').datagrid('getEditor', { index: 1, field: 'birthday' });
                            editColumn = field;
                        }
                    }
                    //                    }
                    //                    else {
                    //                        //$('#tt').datagrid('selectRow', editIndex)
                    //                    }
                },
                onClickRow: function (rowIndex, rowData) {
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
                //                return jq.each(function () {
                //                    var dg = $(this);
                //                    var opts = $(this).datagrid('options');
                //                    var fields = $(this).datagrid('getColumnFields', true).concat($(this).datagrid('getColumnFields'));
                //                    for (var i = 0; i < fields.length; i++) {
                //                        var col = $(this).datagrid('getColumnOption', fields[i]);
                //                        col.editor1 = col.editor;
                //                        if (fields[i] != param.field) {
                //                            col.editor = null;
                //                        }
                //                    }
                ////                    $(this).datagrid('beginEdit', param.index);
                ////                    var ed = $(this).datagrid('getEditor', param);
                ////                    $(ed.target).focus().bind('keydown', function (e) {
                ////                        if (e.keyCode == 13) {
                ////                            dg.datagrid('endEdit', param.index);
                ////                        }
                ////                    });
                //                    for (var i = 0; i < fields.length; i++) {
                //                        var col = $(this).datagrid('getColumnOption', fields[i]);
                //                        col.editor = col.editor1;
                //                    }
                //                });
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
                if (editColumn.indexOf('imp_') >= 0) {
                    var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: editColumn });
                    var v = $(ed.target).combobox('getText');
                    var arr = editColumn.split('_');
                    $('#tt').datagrid('getRows')[editIndex]['impAbbr_' + arr[1]] = v;
                    //$('#tt').datagrid('getRows')[editIndex]['imp_' + arr[1]] = $(ed.target).combobox('getValues').join(',');
                }
                if (editColumn == "v1") {
                    var v1 = $('#tt').datagrid('getEditor', { index: editIndex, field: "v1" });
                    var v1str = $(v1.target).combobox('getText');
                    $('#tt').datagrid('getRows')[editIndex]['header'] = v1str;
                } else if (editColumn == "v2") {
                    var v2 = $('#tt').datagrid('getEditor', { index: editIndex, field: "v2" });
                    var v2str = $(v2.target).combobox('getText');
                    $('#tt').datagrid('getRows')[editIndex]['finaler'] = v2str;
                } else if (editColumn == "itemName") {
                    var ed_itemName = $('#tt').datagrid('getEditor', { index: editIndex, field: "itemName" });
                    var itemName_str = $(ed_itemName.target).val();
                    $('#tt').datagrid('getRows')[editIndex]['itemName'] = itemName_str;
                }

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
                if (editColumn.indexOf('imp_') >= 0) {
                    var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: editColumn });
                    var v = $(ed.target).combobox('getText');
                    var arr = editColumn.split('_');
                    $('#tt').datagrid('getRows')[editIndex]['impAbbr_' + arr[1]] = v;
                    //$('#tt').datagrid('getRows')[editIndex]['imp_' + arr[1]] = $(ed.target).combobox('getValues').join(',');
                }
                if (editColumn == "v1") {
                    var v1 = $('#tt').datagrid('getEditor', { index: editIndex, field: "v1" });
                    var v1str = $(v1.target).combobox('getText');
                    $('#tt').datagrid('getRows')[editIndex]['header'] = v1str;
                } else if (editColumn == "v2") {
                    var v2 = $('#tt').datagrid('getEditor', { index: editIndex, field: "v2" });
                    var v2str = $(v2.target).combobox('getText');
                    $('#tt').datagrid('getRows')[editIndex]['finaler'] = v2str;
                } else if (editColumn == "itemName") {
                    var ed_itemName = $('#tt').datagrid('getEditor', { index: editIndex, field: "itemName" });
                    var itemName_str = $(ed_itemName.target).val();
                    $('#tt').datagrid('getRows')[editIndex]['itemName'] = itemName_str;
                }
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
            $('#tt').treegrid('beginEdit', index);
            var editors = $('#tt').treegrid('getEditors', index);
            editIndex = index;
        }

        function addContent_jqgrid() {
            var id = $("#tt").jqGrid('getGridParam', 'selrow');
            var row = jQuery('#tt').jqGrid('getRowData', id);
            if (art.dialog.get('pc_dialog') != null) {
                art.dialog.get('pc_dialog').close();
            }
            content_action = "pro_content_add";
            content_editType = "add";
            pc_openDialog("add", "<%=pssid %>", row, "<%=showContent %>", "<%=isConstruction %>");
        }

        function editContent_jqgrid() {
            var id = $("#tt").jqGrid('getGridParam', 'selrow');
            var row = jQuery('#tt').jqGrid('getRowData', id);
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

        function add() {
            var row = $('#tt').datagrid('getSelected');
            var index = $('#tt').datagrid('getRowIndex',row);
            if (row != null) {
                if (endEditing()) {
                    //$('#tt').datagrid('appendRow', { contentName: row.contentName });
                    $('#tt').datagrid('insertRow', { index: index+1, row: {
                        contentName: row.contentName, sid: '', remark: '', csid: row.csid, itemSequence: row.itemSequence+1
                    }
                    });
                    //editIndex = $('#tt').datagrid('getRows').length - 1;
                    editIndex = index + 1;
                    $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "itemName" });
                    editColumn = "itemName";
                }
            } else {
                $.messager.show({ title: '提示', msg: "请选择要添加图纸及索引的空间" });
            }
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

//                artDialog.open("/Project/Content_IDE.aspx?action=alter&pssid=<%=pssid %>&sid=" + row.csid + "&isConstruction=<%=isConstruction %>", {
//                    title: "<%=showContent %>",
//                    width: 400,
//                    height: 200
//                });
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
            // $.messager.confirm('提示', '工作内容里有细目，如果执行删除细目也会同时删除。是否继续执行删除？', function (r) {
            //    if (r) {
            $.messager.confirm('提示', '确认删除？', function (r) {
                if (r) {
                    $.post('../../Ashx/Project.ashx', { "action": "content_del", "sid": row.csid }, function (data) {
                        if (data == "success") {
                            $("#tt").datagrid('clearSelections');
                            $("#tt").datagrid("reload");
                        }
                        else {
                            $.messager.show({ title: '提示', msg: (data == "success" ? "保存成功" : data) });
                        }
                    });
                }
            });
            //    }
            //});
        }

        function addItem_jqgrid() {
            //jQuery("#tt").jqGrid('editRow', "new");
            jQuery("#tt").jqGrid('addRowData', {},'last');
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
                            $.messager.show({ title: '提示', msg: (data=="success"?"保存成功":data) });
                        }
                    });
                }
            });
        }

        function Item_del() {
            var row = $('#tt').datagrid('getSelected');
            var index = $('#tt').datagrid('getRowIndex', row);
            if (row.sid != null || row.sid == 0||row.sid=="") {
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
                            $.messager.show({ title: '提示', msg: "图纸索引已正在使用，不能删除！" });
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
                        $.messager.show({ title: '错误提示', msg: '图纸及索引必填项！' });
                        //ShowButton();
                        //EditGrid(rows[i]);
                        editIndex = i;
                        $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "itemName" });
                        editColumn = "itemName";
                        return false;
                    }
                    if (i < rows.length - 1) {
                        for (var j = i + 1; j < rows.length; j++) {
                            if (rows[i].contentName == rows[j].contentName && rows[i].itemName == rows[j].itemName) {
                                $.messager.show({ title: '错误提示', msg: '空间“' + rows[i].contentName + '”出现图纸及索引出现重复' });
                                //EditRow(j);
                                editIndex = j;
                                $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "itemName" });
                                editColumn = "itemName";
                                return false;
                            }
                        }
                    }
//                    if (rows[i].v1.length <= 0) {
//                        $.messager.show({ title: '错误提示', msg: '必须选择主管审核人！' });
//                        //ShowButton();
//                        //EditGrid(rows[i]);
//                        editIndex = i;
//                        $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "v1" });
//                        editColumn = "v1";
//                        return false;
//                    }
//                    if (rows[i].v2.length <= 0) {
//                        $.messager.show({ title: '错误提示', msg: '必须选择总审人！' });
//                        //ShowButton();
//                        //EditGrid(rows[i]);
//                        editIndex = i;
//                        $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "v2" });
//                        editColumn = "v2";
//                        return false;
//                    }
                }
                var allstr = "";
                var delstr = "";
                var updatestr = "";
                var addstr = "";
                var allrows = $('#tt').datagrid('getRows');
                allstr = JSON.stringify(allrows);
                var delrows = $('#tt').datagrid('getChanges', 'deleted');
                delstr = JSON.stringify(delrows);
                var updaterows = $('#tt').datagrid('getChanges', 'updated');
                updatestr = JSON.stringify(updaterows);
                var addrows = $('#tt').datagrid('getChanges', 'inserted');
                addstr = JSON.stringify(addrows);
                $.ajax({
                    type: "POST",
                    timeout: 30000, //超时时间：30秒
                    url: '../../Ashx/ProjectConstruction.ashx',
                    data: {
                        'action': 'easyuiGridEdit',
                        'pssid':pssid,
                        'addstr': addstr,
                        'updatestr': updatestr,
                        'delstr': delstr,
                        'allstr':allstr
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

        function saveRow(row) {
            //$('#dg').datagrid('acceptChanges');
            var rows = $('#tt').datagrid('getRows');
            if (row.itemName.length <= 0) {
                $.messager.show({ title: '错误提示', msg: '图纸及索引必填项！' });
                //ShowButton();
                //EditGrid(rows[i]);
                $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "itemName" });
                editColumn = "itemName";
                return false;
            }
            if (row.v1.length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须选择主管审核人！' });
                $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "v1" });
                editColumn = "v1";
                return false;
            }
            if (row.v2.length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须选择总审人！' });
                $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "v2" });
                editColumn = "v2";
                return false;
            }
            for (var i = 0; i < rows.length; i++) {
                if (i != editIndex) {
                    if (rows[i].contentName == row.contentName && rows[i].itemName == row.itemName) {
                        $.messager.show({ title: '错误提示', msg: '空间“' + rows[i].contentName + '”出现图纸及索引出现重复' });
                        $('#tt').datagrid('selectRow', editIndex).datagrid('editdgCell', { index: editIndex, field: "itemName" });
                        editColumn = "itemName";
                        return false;
                    }
                }
            }
            var editstr = "";
            var editrow = row
            editstr = JSON.stringify(editrow);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '../../Ashx/ProjectConstruction.ashx',
                data: {
                    'action': 'easyuiGridEdit_row',
                    'editstr': editstr
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<input type="hidden" id="hpssid" name="hpssid" value="<%=pssid %>" />

 <div id="menu" style="display:none;">
        <a href="javascript:void(0)" id="add" class="easyui-menubutton" data-options="iconCls:'icon-add'" onclick="addContent_jqgrid()">
            添加<%=showContent %></a>
        <a href="javascript:void(0)" id="a1" class="easyui-menubutton" data-options="iconCls:'icon-add'" onclick="addItem_jqgrid()">
            添加<%=showItem%></a>
        <a href="javascript:void(0)" id="edit" class="easyui-menubutton" data-options="iconCls:'icon-edit'" onclick="editContent_jqgrid();">
            修改<%=showContent %></a>
        <a href="javascript:void(0)" id="del" class="easyui-menubutton" data-options="menu:'#mm_del',iconCls:'icon-remove'">
            删除</a>
        <div id="mm_del" style="width: 150px;">
            <div data-options="iconCls:''" onclick="delContent();">
                删除<%=showContent %></div>
            <div class="menu-sep"></div>
            <div data-options="iconCls:''" onclick="delItem();">
                删除<%=showItem %></div>
        </div>
    </div>

    <table id="tt">
    </table>
    <div id="pc_edit" style="display: none;">
        <pc_IDE:PC_IDE ID="pc_ide1" runat="server"></pc_IDE:PC_IDE>
    </div>

   

    <div id="group_mm" class="easyui-menu" style="width: 120px;">
        <div onclick="" data-options="iconCls:'icon-add'">
            添加<%=showItem %></div>
        <div onclick="" data-options="iconCls:'icon-add'">
            添加<%=showItem %></div>
        <div onclick="" data-options="iconCls:'icon-add'">
            修改</div>
    </div>


    <div id="toolbar" style="display:none;">
        <a href="javascript:void(0)" id="mb" class="easyui-menubutton" data-options="menu:'#mm',iconCls:'icon-edit'">空间</a>  
<div id="mm" style="width:150px;">  
    <div data-options="iconCls:'icon-add'" onclick="addContent()">添加空间</div>  
    <div data-options="iconCls:'icon-edit'" onclick="editContent()">修改空间</div> 
    <div data-options="iconCls:'icon-remove'" onclick="delContent()">删除空间</div>   
</div>  
    <a href="#" id="tab_a_01" class="easyui-linkbutton" plain="true" onclick="add()" iconCls="icon-add">添加图纸及索引</a>
    <a href="#" id="A2" class="easyui-linkbutton" plain="true" onclick="Item_del()" iconCls="icon-remove">删除图纸及索引</a>
    <a href="#" id="A3" class="easyui-linkbutton" plain="true" onclick="MoveRow(-1)" iconCls="icon-up">上移</a>
    <a href="#" id="A4" class="easyui-linkbutton" plain="true" onclick="MoveRow(1)" iconCls="icon-down">下移</a>
    <a href="#" id="A5" class="easyui-linkbutton" plain="true" onclick="save()" iconCls="icon-save">保存</a>
    <a href="#" id="A6" class="easyui-linkbutton" plain="true" onclick=" cancel();" iconCls="icon-undo">撤销</a>
    </div>
</asp:Content>
