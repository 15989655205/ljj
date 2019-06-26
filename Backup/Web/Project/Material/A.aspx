<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true"
    CodeBehind="A.aspx.cs" Inherits="Maticsoft.Web.Project.Material.A" %>

<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="/Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var editIndex = undefined;
        var spaceData = undefined;
        $(function () {
            GetProjectCombo();
            GetSpaceCombo();
            GetPlaceCombo();
            LoadTable();
        });
        function GetProjectCombo() {
            $('#project').combobox({
                url: '/Ashx/Common.ashx?type=getProject',
                valueField: 'sid',
                textField: 'name',
                editable: false,
                onChange: function (newValue, oldValue) {
                    GetSpaceCombo(newValue);
                    GetPlaceCombo();
                    $('#tt').datagrid('options').queryParams = { "projectID": newValue };
                    $('#tt').datagrid('load');
                    //                var thised = $('#tt').datagrid('getEditor', { index: editIndex, field: 'spaceID' });
                    //                $(thised.target).combobox('reload', '/Ashx/Common.ashx?type=getSpace&pid=' + newValue);
                    $.getJSON('/Ashx/Common.ashx?type=getSpace&pid=' + newValue, function (data) {
                        spaceData = data;
                    });
                }
            });
        }

        function GetSpaceCombo(val) {
            $('#space').combobox({
                url: '/Ashx/Common.ashx?type=getSpace&pid=' + val,
                valueField: 'sid',
                textField: 'name',
                editable: false,
                onChange: function (newValue, oldValue) {
                    GetPlaceCombo(newValue);
                    $('#tt').datagrid('options').queryParams = { "projectID": $('#project').combobox('getValue'), "spaceID": newValue };
                    $('#tt').datagrid('load');
                }
            });
        }

        function GetPlaceCombo(val) {
            $('#place').combobox({
                url: '/Ashx/Common.ashx?type=getPlace&pid=' + val,
                valueField: 'sid',
                textField: 'name',
                editable: false,
                onChange: function (newValue, oldValue) {
                    //LoadTable(newValue);
                    $('#tt').datagrid('options').queryParams = { "projectID": $('#project').combobox('getValue'), "placeID": newValue };
                    $('#tt').datagrid('load');
                }
            });
        }

        function LoadTable() {
            $("#tt").datagrid({
                url: "/Ashx/ProjectMaterial.ashx?action=MaterialAList"
                //, queryParams: { "action": "MaterialAList" }
                , loadMsg: "正在加载中..."
                , toolbar: "#toolbar"
                , idField: "sid"
                , fit: true
                //, fitColumns: true
              , striped: true
                , rownumbers: true
                , singleSelect: true
                 , pageSize: 20
           , pageList: [10, 20, 30, 40, 50, 100]
                // , remoteSort: true
                , pagination: true
                , rowStyler: function (index, row) {
                }
                , frozenColumns: [[
                { field: "ckb", checkbox: true, width: 5 },
                    { title: '空间', field: 'spaceID', width: 150, halign: 'center', editor: { type: 'combobox',
                        options: {
                            valueField: 'sid',
                            textField: 'name',
                            //required: true,
                            //missingMessage: '不能为空！',
                            //invalidMessage: '不能为空！',
                            //panelHeight: 'auto',
                            editable: false
                            , onLoadSuccess: function () {
                                var row = $('#tt').datagrid('getSelected');
                                if (row.sid != 0) {
                                    $(this).combobox('disable');
                                }
                                // alert($(this).combobox('getData')); 
                            }
                            , onChange: function (newValue, oldValue) {
                                try {
                                    var thised = $('#tt').datagrid('getEditor', { index: editIndex, field: 'projectSpaceID' });
                                    $(thised.target).combobox('clear');
                                    $(thised.target).combobox('reload', '/Ashx/Common.ashx?type=getPlace&pid=' + newValue);

                                }
                                catch (e) {
                                }
                            }
                        }
                    },
                        formatter: function (value, row, index) {
                            return row.space;
                        }
                    },
                    { title: '部位', field: 'projectSpaceID', width: 80, halign: 'center', editor: { type: 'combobox',
                        options: {
                            valueField: 'sid',
                            textField: 'name',
                            editable: false
                            , onLoadSuccess: function () {
                                var row = $('#tt').datagrid('getSelected');
                                if (row.sid != 0) {
                                    $(this).combobox('disable');
                                }
                            }
                            , onSelect: function (record) {
                                try {
                                    var rows = $('#tt').datagrid('getRows');
                                    for (var i = 0; i < rows.length; i++) {
                                        if (rows[i].Submit == 1 && rows[i].projectSpaceID == record.sid && rows[i].sid != 0) {
                                            $.messager.show({ title: '错误提示', msg: '此部位已提交不能操作' });
                                            $(this).combobox('reset');
                                        }
                                    }
                                }
                                catch (e) {
                                }
                            }
                        }
                    },
                        formatter: function (value, row, index) {
                            return row.place;
                        }
                    },

                    { title: '位置', field: 'locationID', width: 80, halign: 'center', editor: { type: 'combobox',
                        options: { url: '/Ashx/Common.ashx?type=getDic&catg=14',
                            valueField: 'Value',
                            textField: 'Text',
                            //required: true,
                            missingMessage: '不能为空！',
                            invalidMessage: '不能为空！',
                            panelHeight: 'auto',
                            editable: false
                            , onLoadSuccess: function () {
                                //                                var rows = $("#tt").datagrid('getRows');                                
                                //                                    for (var i = 0; i < rows.length; i++) {
                                //                                        if (rows[i].AStatus != "未提交") {
                                //                                            
                                //                                        }
                                //                                    }
                                var row = $('#tt').datagrid('getSelected');
                                if (row.sid != 0) {
                                    $(this).combobox('disable');
                                }

                            }
                            , onChange: function (newValue, oldValue) {
                                try {
                                    var row = $('#tt').datagrid('getSelected');
                                    var thised = $('#tt').datagrid('getEditor', { index: editIndex, field: 'locationID' });
                                    var oldText = $(thised.target).combobox('getText');
                                    var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'productID' });
                                    var product = $(ed.target).val();
                                    var ed_place = $('#tt').datagrid('getEditor', { index: editIndex, field: 'projectSpaceID' });

                                    if (product == "" || product == undefined) {
                                        return;
                                    }
                                    $.ajax({
                                        type: 'post',
                                        url: '/Ashx/ProjectMaterial.ashx',
                                        timeout: 3000,
                                        data: {
                                            'action': 'isExistProduct',
                                            'productID': product,
                                            'placeID': $(ed_place.target).combobox('getValue'), //row.projectSpaceID,
                                            'locationID': newValue
                                        },
                                        async: false,
                                        success: function (data) {
                                            if (data != 'success') {
                                                $.messager.show({ title: '错误提示', msg: '此部位已选用了该材料' });
                                                $(thised.target).combobox('setValue', oldValue);
                                                $(thised.target).combobox('setText', oldText);
                                            }
                                        },
                                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                                            $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                                        }

                                    })
                                }
                                catch (e) {
                                }
                            }
                        }
                    }
                    ,
                        formatter: function (value, row, index) {
                            return row.location;
                        }
                    },
                    { title: '图纸编号', field: 'DrawingNumber', width: 80, halign: 'center', align: 'center', editor: "text" },
                    { title: '编号', field: 'productCode', width: 80, halign: 'center', align: 'center', editor: "diseditText" },
                    { title: '内容', field: 'productName', width: 80, halign: 'center', align: 'center', editor: { type: 'window_text', required: true, options: { url: '/windows/Product.aspx'}} }
                ]]
                , columns: [
                    [

                    { title: '尺寸', field: 'Size', width: 80, halign: 'center', align: 'center', editor: "text" },
                    { title: '单位', field: 'UnitName', width: 80, halign: 'center', align: 'center', editor: "diseditText" },
                    { title: '数量', field: 'Amount', width: 80, halign: 'center', align: 'center', editor: { type: "numberbox", options: { min: 0, precision: 4}} },
                    { field: 'ColorCode', title: '颜色编号', width: 100, editor: "text",hidden:true },
                    { field: 'colorName', title: '颜色', width: 100, editor:
                    {
                       type: 'combobox',
                        options: {
                            valueField: 'colorName',
                         textField: 'colorName',
                           url: '/Ashx/ProjectMaterial.ashx?action=GetColor',
                           onSelect: function (record) {


                }
            }
        },
            formatter: function (value, row, index) {
                return row.colorName;
            }
        },
                    { title: '质地 ', field: 'Quality', width: 80, halign: 'center', align: 'center', editor: "diseditText"
                    },
                    { title: '品牌', field: 'Brand', width: 100, halign: 'center', editor: "text" }
                    ,
                    { title: '阻燃性', field: 'NFK', width: 100, halign: 'center', editor: "diseditText" }
                    , { title: '备注', field: 'remark', width: 100, halign: 'center', editor: "text" }
                    , { title: '状态', field: 'AStatus', halign: 'center', width: 100 }
                     ,
                    { title: '提交人', field: 'SubmitPerson', halign: 'center', width: 100 }
                     ,
                    { title: '提交时间', field: 'SubmitDate', halign: 'center', width: 100 }
                     ,
                    { title: '审核人', field: 'Auditor', halign: 'center', width: 100 }
                     ,
                    { title: '审核时间', field: 'AuditDate', halign: 'center', width: 100 }
                     ,
                    { title: '校核人', field: 'CheckPerson', width: 100 }
                     ,
                    { title: '校核时间', field: 'CheckDate', width: 100 }
                     ,
                    { title: '创建人', field: 'create_person', halign: 'center', width: 100 }
                     ,
                    { title: '创建时间', field: 'create_date', halign: 'center', width: 100 }
                     ,
                    { title: '修改人', field: 'update_person', halign: 'center', width: 100 }
                     ,
                    { title: '修改时间', field: 'update_date', halign: 'center', width: 100 }
                     ,
                    { title: 'sid', field: 'sid', width: 100, editor: "text", hidden: true }
                    ,
                    { title: 'location', field: 'location', width: 100, editor: "text", hidden: true }
                    ,
                    { title: 'space', field: 'space', width: 100, editor: "text", hidden: true }
                    ,
                    { title: 'place', field: 'place', width: 100, editor: "text", hidden: true }
                    ,
                    { title: 'productID', field: 'productID', width: 100, editor: "text", hidden: true }
                    ]
                ],
                onLoadSuccess: function (data) {
                    mergeCellsByFieldGroup('tt', 'spaceID,projectSpaceID,locationID,AStatus|place,SubmitPerson|place,SubmitDate|place,Auditor|place,AuditDate|place,CheckPerson|place,CheckDate|place');
                    //                var rows = $("#tt").datagrid('getRows');
                    //                for (var i = 0; i < rows.length; i++) {
                    //                    if (rows[i].AStatus == "未提交" || rows[i].AStatus == "审核未通过") {
                    //                        var getIndex = $("#tt").datagrid('getRowIndex', rows[i]);
                    //                        $('#tt').datagrid('beginEdit', getIndex);
                    //                    }
                    //                }
                },
                onClickRow: function (index, rowData) {
                    if (rowData.Submit == 1) {
                        $.messager.show({ title: '错误提示', msg: '此部位已提交不能操作' });
                        return;
                    }
                    EditRow(index);
                    // EndEdit(index);
                }
                , onClickCell: function (rowIndex, field, value) { $("#tt").datagrid("clearSelections"); }

            });
        }



        function endEditing() {

            if (editIndex == undefined) { return true }
            if ($('#tt').datagrid('validateRow', editIndex)) {
                //var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'locationID' });
                //var location = $(ed.target).combobox('getText');
                var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'locationID' });
                var location = $(ed.target).combobox('getText');
                var locationed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'location' });
                $(locationed.target).val(location);

                var edspaceID = $('#tt').datagrid('getEditor', { index: editIndex, field: 'spaceID' });
                var space = $(edspaceID.target).combobox('getText');
                var edSpace = $('#tt').datagrid('getEditor', { index: editIndex, field: 'space' });
                $(edSpace.target).val(space);
                //                $('#tt').datagrid('updateRow', {
                //                    index: editIndex,
                //                    row: {
                //                        space: space
                //                    }
                //                });
                var edplaceID = $('#tt').datagrid('getEditor', { index: editIndex, field: 'projectSpaceID' });
                var place = $(edplaceID.target).combobox('getText');
                var edPlace = $('#tt').datagrid('getEditor', { index: editIndex, field: 'place' });
                $(edPlace.target).val(place);
                //                $('#tt').datagrid('updateRow', {
                //                    index: editIndex,
                //                    row: {
                //                    location:location,
                //                        space: space,
                //                        place: place
                //                    }
                //                });
                //var edspace = $('#tt').datagrid('getEditor', { index: editIndex, field: 'space' });
                //$(edspace.target).val(space);
                //$('#tt').datagrid('getRows')[editIndex]['location'] = location;


                $('#tt').datagrid('endEdit', editIndex);
                mergeCellsByFieldGroupCondition('tt', 'spaceID,projectSpaceID,locationID,AStatus|place,SubmitPerson|place,SubmitDate|place,Auditor|place,AuditDate|place,CheckPerson|place,CheckDate|place', 'sid:0');
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
                    //edt[0].target.attr('disabled', true);
                    editIndex = index;
                    var ed = $('#tt').datagrid('getEditor', { index: index, field: 'spaceID' });
                    $(ed.target).combobox('loadData', spaceData);
                    var thised = $('#tt').datagrid('getEditor', { index: index, field: 'projectSpaceID' });
                    $(thised.target).combobox('reload', '/Ashx/Common.ashx?type=getPlace&pid=' + $(ed.target).combobox('getValue'));
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

        function SelectWindow(url) {
            var row = $('#tt').datagrid('getSelected');
            var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'locationID' });
            var location = $(ed.target).combobox('getValue');
            var edPlace = $('#tt').datagrid('getEditor', { index: editIndex, field: 'projectSpaceID' });
            var place = $(edPlace.target).combobox('getValue');
            if (location == "" || location == undefined) {
                $.messager.show({ title: '错误提示', msg: '请选择要操作位置。' });
                return;
            }
            art.dialog.open(url,
       { title: '选择', width: 700, height: 460,
           close: function () {
               var id = art.dialog.data('id');
               var key = art.dialog.data('key');
               var name = art.dialog.data('name');
               var quality = art.dialog.data('quality');
               var nfk = art.dialog.data('nfk');
               var unit = art.dialog.data('unit');
               //               $.ajax({
               //                   type: 'post',
               //                   url: '/Ashx/ProjectMaterial.ashx',
               //                   timeout: 3000,
               //                   data: {
               //                       'action': 'isExistProduct',
               //                       'productID': id,
               //                       'placeID': place,
               //                       'locationID': location
               //                   },
               //                   async: false,
               //                   success: function (data) {
               //                       //                       if (data != 'success') {
               //                       //                           $.messager.show({ title: '错误提示', msg: '此部位已选用了该材料，无需再选择' });
               //                       //                       }
               //                       //                       else {
               //                       //                           var edt = $('#tt').datagrid('getEditors', editIndex);
               //                       //                           edt[5].target.val(name);
               //                       //                           edt[4].target.val(key);
               //                       //                           edt[8].target.val(quality);
               //                       //                           edt[10].target.val(nfk);
               //                       //                           edt[14].target.val(id);
               //                       //                       }
               //                       var idArr = id.split(',');
               //                       var keyArr = key.split('|');
               //                       var nameArr = name.split('|');
               //                       var qualityArr = quality.split('|');
               //                       var nfkArr = nfk.split('|');
               //                       var dataArr = data.split('|');
               //                       var existName = "";
               //                       var index = 0;

               //                       var edt = $('#tt').datagrid('getEditors', editIndex);
               //                       for (var a = 0; a < idArr.length; a++) {
               //                           var exist = false;
               //                           for (var b = 0; b < dataArr.length; b++) {
               //                               var productArr = dataArr[b].split(":");
               //                               if (idArr[a] == productArr[0]) {
               //                                   existName += "[" + productArr[1] + "]";
               //                                   exist = true;
               //                                   break;
               //                               }
               //                           }
               //                           if (!exist) {
               //                               if (index == 0) {
               //                                   edt[5].target.val(nameArr[a]);
               //                                   edt[4].target.val(keyArr[a]);
               //                                   edt[8].target.val(qualityArr[a]);
               //                                   edt[10].target.val(nfkArr[a]);
               //                                   edt[14].target.val(idArr[a]);
               //                               }
               //                               else {
               //                                   $('#tt').datagrid('insertRow', {
               //                                       index: index + editIndex, // 索引从0开始
               //                                       row: {
               //                                           sid: '0',
               //                                           spaceID: $(edt[0].target).combobox('getValue'),
               //                                           projectSpaceID: $(edt[1].target).combobox('getValue'),
               //                                           locationID: $(edt[2].target).combobox('getValue'),
               //                                           productCode: keyArr[a],
               //                                           productName: nameArr[a],
               //                                           Quality: qualityArr[a],
               //                                           NFK: nfkArr[a],
               //                                           location: $(edt[2].target).combobox('getText'),
               //                                           space: $(edt[0].target).combobox('getText'),
               //                                           place: $(edt[1].target).combobox('getText'),
               //                                           productID: idArr[a]
               //                                       }
               //                                   });

               //                               }
               //                               index += 1;
               //                           }
               //                       }
               //                       if (existName != '') {
               //                           $.messager.show({ title: '错误提示', msg: existName + '已被此部位选用，无需再选择' });
               //                       }
               //                   },
               //                   error: function (XMLHttpRequest, textStatus, errorThrown) {
               //                       $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
               //                   }

               //               })

               var idArr = id.split(',');
               var keyArr = key.split('|');
               var nameArr = name.split('|');
               var qualityArr = quality.split('|');
               var nfkArr = nfk.split('|');
               var unit = unit.split('|');
               var index = 0;

               var edt = $('#tt').datagrid('getEditors', editIndex);
               for (var a = 0; a < idArr.length; a++) {
                   if (index == 0) {
                       edt[5].target.val(nameArr[a]);
                       edt[4].target.val(keyArr[a]);
                       edt[7].target.val(unit[a]);
                       edt[10].target.val(qualityArr[a]);
                       edt[12].target.val(nfkArr[a]);
                       edt[18].target.val(idArr[a]);
                   }
                   else {
                       $('#tt').datagrid('insertRow', {
                           index: index + editIndex, // 索引从0开始
                           row: {
                               sid: '0',
                               spaceID: $(edt[0].target).combobox('getValue'),
                               projectSpaceID: $(edt[1].target).combobox('getValue'),
                               locationID: $(edt[2].target).combobox('getValue'),
                               productCode: keyArr[a],
                               productName: nameArr[a],
                               Quality: qualityArr[a],
                               NFK: nfkArr[a],
                               Unit: unit[a],
                               location: $(edt[2].target).combobox('getText'),
                               space: $(edt[0].target).combobox('getText'),
                               place: $(edt[1].target).combobox('getText'),
                               productID: idArr[a]
                           }
                       });

                   }
                   index += 1;
               }
           }
       }, false);
        }

        function add() {
            if ($('#project').combobox('getValue') == undefined || $('#project').combobox('getValue') == "") {
                $.messager.show({ title: '错误提示', msg: "请先选择项目" });
                return false;
            }
            if (endEditing()) {
                var rows = $("#tt").datagrid('getRows');
                //           for (var i = 0; i < rows.length; i++) {
                //               //var getIndex = $("#tt").datagrid("getRowIndex", rows[i]);
                //               //var getSelectedRow = $("#tt").datagrid("getSelected").place;

                ////               if (rows[i].AStatus != "未提交" && getSelectedRow == rows[i].place) {

                ////                   $.messager.show({ title: '错误提示', msg: "此部位已被提交无法增加" });
                ////                   return;
                ////               }
                //           }

                //$('#tt').datagrid('insertRow', { index: 0, row: {'sid':'0', 'space': $('#space').combobox('getText'), 'place': $('#place').combobox('getText'), 'projectSpaceID': $('#place').combobox('getValue')} }); //, { status: 'P' });
                $('#tt').datagrid('insertRow', { index: 0, row: { 'sid': '0'} });  //, { status: 'P' });
                editIndex = 0;
                $('#tt').datagrid('selectRow', 0).datagrid('beginEdit', 0);
                var ed = $('#tt').datagrid('getEditor', { index: 0, field: 'spaceID' });
                $(ed.target).combobox('loadData', spaceData);
                //$(ed.target).combobox('reload', '/Ashx/Common.ashx?type=getSpace&pid='+$('#project').combobox('getValue'));
            }
        }

        function del() {
            //mergeCellsByFieldGroup('tt', 'space,place,locationID');getColumnOption
            //var column=$('#tt').datagrid('getColumnOption', 'space');
            // var row
            //$('#tt').datagrid('mergeCells', {index:editIndex,field:'space',colspan:1});
            $('#tt').datagrid('cancelEdit', editIndex).datagrid('deleteRow', editIndex);

            var rows = $('#tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $('#tt').datagrid('refreshRow', i);
            }
            //$('#tt').datagrid('refreshRow');
            //$('#tt').datagrid('refreshRow', editIndex);
            // $('#tt').datagrid('refreshRow', 1);
            mergeCellsByFieldGroupCondition('tt', 'spaceID,projectSpaceID,locationID,AStatus|place,SubmitPerson|place,SubmitDate|place,Auditor|place,AuditDate|place,CheckPerson|place,CheckDate|place', 'sid:0');

            editIndex = undefined;
        }

        function cancel() {
            $('#tt').datagrid('rejectChanges');
            editIndex = undefined;
        }


        function EndEdit(index) {

            //        var rows = $("#tt").datagrid('getRows');
            //        for (var i = 0; i < rows.length; i++) {
            //            if (rows[i].AStatus == "未提交") {
            //                var getIndex = $("#tt").datagrid('getRowIndex', rows[i]);
            //                $('#tt').datagrid('beginEdit', getIndex);   
            //            }  
            //        }
        }

        function EndEditRow() {
            var rows = $("#tt").datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $("#tt").datagrid('endEdit', i);
            }
        }

        function save() {
            //EndEditRow();
            if (endEditing()) {
                var rows = $('#tt').datagrid('getRows');
                for (var i = 0; i < rows.length; i++) {
                    if (rows[i].productName.length <= 0) {
                        $.messager.show({ title: '错误提示', msg: "材料不能为空" });
                        //EditGrid(rows[i]);
                        EditRow(i);
                        return false;
                    }
                    if (rows[i].Amount.length <= 0 || rows[i].Amount <= 0) {
                        $.messager.show({ title: '错误提示', msg: "数量不能为空" });
                        //EditGrid(rows[i]);
                        EditRow(i);
                        return false;
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
                $.ajax({
                    type: "POST",
                    timeout: 30000, //超时时间：30秒
                    url: '/Ashx/ProjectMaterial.ashx',
                    data: {
                        'action': 'ASave',
                        'addstr': addstr,
                        'updatestr': updatestr,
                        'delstr': delstr
                    },
                    success: function (data) {
                        if (data == "success") {
                            $('#tt').datagrid("reload");
                            //$.messager.show({ title: '提示', msg: "编辑成功！" });
                        }
                        $.messager.show({ title: '错误提示', msg: (data == "success" ? "保存成功" : data) });

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    }
                });
            }
        }

        function Sumbit() {
            var row = $("#tt").datagrid("getSelected");
            var placeID = row.projectSpaceID;
            var sid = row.sid;
            //alert(placeID);

            $.ajax({
                type: 'post',
                url: '/Ashx/ProjectMaterial.ashx',
                data: {
                    'action': 'submit',
                    'placeID': placeID,
                    'sid': sid
                },
                success: function (res) {
                    $.messager.show({ title: '提示', msg: res });
                    $('#tt').datagrid("reload");
                }
            });

        }

        function CancelSumbit() {
            var row = $("#tt").datagrid("getSelected");
            var placeID = row.projectSpaceID;
            var sid = row.sid;


            $.ajax({
                type: 'post',
                url: '/Ashx/ProjectMaterial.ashx',
                data: {
                    'action': 'cancelSubmit',
                    'placeID': placeID, // Project_Product_Material_Submit_A
                    'sid': sid  //Project_Product_Material_A
                },
                success: function (res) {
                    $.messager.show({ title: '提示', msg: res });
                    $('#tt').datagrid("reload");
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tt">
    </table>
    <div id="toolbar">
        <table style="margin: 5px;">
            <tr>
                <td style="">
                    项目：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <input id="project" name="project" />
                </td>
                <td style="">
                    空间：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <input id="space" name="space" />
                </td>
                <td style="">
                    部位：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <input id="place" name="place" />
                </td>
            </tr>
        </table>
        <toolbar:ToolBar runat="server" ID="toolbar1" />
    </div>
</asp:Content>
