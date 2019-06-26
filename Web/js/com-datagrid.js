var editIndex = undefined;
var grid;
var controlID;
function LoadTable(cid, url, frozencolumns, columns, toobarID, idField,params) {
    grid = $("#" + cid);
    controlID = cid;
    grid.datagrid({
        url: url
        , queryParams: params
                , loadMsg: "正在加载中..."
                , toolbar: "#" + toobarID
                , idField: idField
                , fit: true
        //, fitColumns: true
              , striped: true
                , rownumbers: true
                , singleSelect: false
                 , pageSize: 20
           , pageList: [10, 20, 30, 40, 50, 100]
         , remoteSort: true
                , pagination: true
                , rowStyler: function (index, row) {
                }
        //, frozenColumns: eval('(' + frozencolumns + ')'),
        //columns: eval('(' + columns + ')'),
        , frozenColumns: frozencolumns,
        columns: columns,
        onLoadSuccess: function (data) {
            //mergeCellsByFieldGroup('tt', 'spaceID,projectSpaceID,locationID,AStatus|place,SubmitPerson|place,SubmitDate|place,Auditor|place,AuditDate|place,CheckPerson|place,CheckDate|place');
            if (isExitsFunction('MergeCells')) {
                MergeCells();
            }
        },
        onClickRow: function (index, rowData) {
            if (isExitsFunction('CustomEditRow')) {
                CustomEditRow(index, rowData);
            } else {
                EditRow(index);
            }
        }
        , onClickCell: function (rowIndex, field, value) { grid.datagrid("clearSelections"); }

    });
}

function endEditing() {

    if (editIndex == undefined) { return true }
    if (grid.datagrid('validateRow', editIndex)) {
        grid.datagrid('endEdit', editIndex);
        if (isExitsFunction('MergeCells')) {
            MergeCells();
        }
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}

function EditRow(index) {
    if (editIndex != index) {
        if (endEditing()) {
            grid.datagrid('selectRow', index).datagrid('beginEdit', index);
            editIndex = index;
        } else {
            grid.datagrid('selectRow', editIndex);
        }
    }
}

function EditGrid(row) {
    var index = grid.datagrid('getRowIndex', row);
    grid.datagrid('beginEdit', index);
    var editors = grid.datagrid('getEditors', index);
    editIndex = index;
}

function GridSave(url,action) {
    if (endEditing()) {
//        var rows = $('#tt').datagrid('getRows');
//        for (var i = 0; i < rows.length; i++) {
//            if (rows[i].productName.length <= 0) {
//                $.messager.show({ title: '错误提示', msg: "材料不能为空" });
//                //EditGrid(rows[i]);
//                EditRow(i);
//                return false;
//            }
//            if (rows[i].Amount.length <= 0 || rows[i].Amount <= 0) {
//                $.messager.show({ title: '错误提示', msg: "数量不能为空" });
//                //EditGrid(rows[i]);
//                EditRow(i);
//                return false;
//            }
        //        }
        if (isExitsFunction('Verification')) {
            if (!Verification()) {
                return false;
            }
        } 

        var delstr = "";
        var updatestr = "";
        var addstr = "";
        var delrows = grid.datagrid('getChanges', 'deleted');
        delstr = JSON.stringify(delrows);
        var updaterows = grid.datagrid('getChanges', 'updated');
        updatestr = JSON.stringify(updaterows);
        var addrows = grid.datagrid('getChanges', 'inserted');
        addstr = JSON.stringify(addrows);
        $.ajax({
            type: "POST",
            timeout: 30000, //超时时间：30秒
            url: url,
            data: {
                'action': (action==undefined)?'save':action,
                'addstr': addstr,
                'updatestr': updatestr,
                'delstr': delstr
            },
            success: function (data) {
                if (data == "success") {
                    grid.datagrid("reload");
                }
                $.messager.show({ title: '错误提示', msg: (data == "success" ? "保存成功" : data) });

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
            }
        });
    }
}
