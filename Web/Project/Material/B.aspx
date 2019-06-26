<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="B.aspx.cs" Inherits="Maticsoft.Web.Project.Material.B" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="/Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: left;
            height: 25px;
            width: 70px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var editIndex;
        $(function () {

            $('#project_name').combobox({
                url: '/Ashx/ProjectMaterial.ashx?action=GetProjectName',
                valueField: 'sid',
                textField: 'project_name',
                editable: false,
                onChange: function (newValue, oldValue) {
                    //LoadTable(newValue);
                    Getmaterial(newValue);
                    $('#dg').datagrid('options').queryParams = { "projectID": newValue };
                    $('#dg').datagrid('load');
                }
            });

            Getmaterial('');

            $('#dg').datagrid({
                url: '/Ashx/ProjectMaterial.ashx?action=GetPM_B_List'
                             , loadMsg: "正在加载中..."
                , toolbar: "#toolbar"
                , idField: "ID"
                , fit: true
                //, fitColumns: true
              , striped: true
                , rownumbers: true
                // ,checkbox:true
                , singleSelect: false
                , selectOnCheck: true
                , checkOnSelect: true
                 , pageSize: 20
           , pageList: [10, 20, 30, 40, 50, 100]
                // , remoteSort: true
                , pagination: true
                , frozenColumns: [[
                 { field: "ckb", checkbox: true, width: 5 },
                { field: 'ProductTypeRoot', title: '材料类别', width: 100 },
                //{ field: 'psName', title: '空间', width: 100 },
            {field: 'FileNumber', title: '档案编号', width: 100 },
            { field: 'space', title: '空间', width: 100 },
            { field: 'place', title: '部位', width: 100 },
        { field: 'productName', title: '货品名称', width: 100 }
                ]]
            , columns: [[

        { field: 'ProductItem', title: '货品细目', width: 100 },
        { field: 'productCode', title: '编号', width: 100 },
        { field: 'Size', title: '规格', width: 100 },
        { field: 'ColorCode', title: '颜色编号', width: 100, editor: "text" },
        { field: 'colorID', title: '颜色', width: 100, editor:
        {
            type: 'combobox',
            options: {
                valueField: 'colorID',
                textField: 'colorName',
                url: '/Ashx/ProjectMaterial.ashx?action=GetColor',
                onSelect: function (record) {
                    var row = $("#dg").datagrid("getSelected");
                    var index1 = $("#dg").datagrid("getRowIndex", row);
                    var ed = $("#dg").datagrid('getEditor', { index: index1, field: 'ColorCode' });
                    $(ed.target).val(record.Code);

                }
            }
        },
            formatter: function (value, row, index) {
                return row.colorName;
            }
        },
        { field: 'Brand', title: '品牌', width: 100, editor: "text" },
        { field: 'spID', title: '厂商名称', width: 100, editor:
                    {
                        type: 'combobox',
                        options: {
                            valueField: 'spID',
                            textField: 'name',
                            url: '/Ashx/ProjectMaterial.ashx?action=GetSupplier',
                            //required: true,
                            onSelect: function (record) {
                                var row = $("#dg").datagrid("getSelected");
                                var index1 = $("#dg").datagrid("getRowIndex", row);
                                var ed = $("#dg").datagrid('getEditor', { index: index1, field: 'supplierMobile' });

                                $(ed.target).val(record.phone);
                                var edCode = $("#dg").datagrid('getEditor', { index: index1, field: 'supplierCode' });
                                $(edCode.target).val(record.manufacturerNumber);
                            }
                        }
                    }
                    ,
            formatter: function (value, row, index) {
                return row.supplierName;
            }
        },
        { field: 'supplierCode', title: '厂商编号', width: 100, editor: "text" },
        { field: 'supplierMobile', title: '厂商电话', width: 100, editor: "text" },
        { field: 'remark', title: '备注', width: 100, editor: "text" },
        { title: '状态', field: 'Status', halign: 'center', width: 100 },
        { field: 'UnitName', title: '单位', width: 100 },
        { field: 'Amount', title: '数量', width: 100 },
        { title: 'supplier', field: 'supplierName', width: 100, editor: "text", hidden: true }
    ]],
                //                onClickRow: function (rowIndex, rowData) {

                //                    if (rowIndex != editIndex) {
                //                        End(editIndex);
                //                    }
                //                    $('#dg').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
                //                    editIndex = rowIndex;
                //                },
                //                onLoadSuccess: function (data) {
                //                    mergeCellsByFieldGroup('dg', 'productType,FileNumber');
                //                }
                onLoadSuccess: function (data) {
                    mergeCellsByFieldGroup('dg', 'ProductTypeRoot,FileNumber|ProductTypeRoot,space|ProductTypeRoot,place|ProductTypeRoot');
                },
                onClickRow: function (index, rowData) {
                    
                    if (rowData.Submit == 1) {
                        $.messager.show({ title: '错误提示', msg: '此部位已提交不能操作' });
                        return;
                    }
                    EditRow(index);
                }
                , onClickCell: function (rowIndex, field, value) { $("#dg").datagrid("clearSelections"); }
            });
        });

        function EndEdit() {
            var rows = $("#dg").datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $("#dg").datagrid('endEdit', i);
            }
        }

        function endEditing() {
            if (editIndex == undefined) { return true }
            if ($('#dg').datagrid('validateRow', editIndex)) {
                
                var ed = $('#dg').datagrid('getEditor', { index: editIndex, field: 'spID' });
                var supplier = $(ed.target).combobox('getText');
                var suppliered = $('#dg').datagrid('getEditor', { index: editIndex, field: 'supplierName' });
                $(suppliered.target).val(supplier);
                $('#dg').datagrid('endEdit', editIndex); 
                mergeCellsByFieldGroup('dg', 'ProductTypeRoot,FileNumber|ProductTypeRoot,space|ProductTypeRoot,place|ProductTypeRoot');
                editIndex = undefined;
                return true;
            } else {
                return false;
            }
         
        }

        function EditRow(index) {
            if (editIndex != index) {

                if (endEditing()) {
                    $('#dg').datagrid('selectRow', index).datagrid('beginEdit', index);
                    //edt[0].target.attr('disabled', true);
                    editIndex = index;
                } else {
                    $('#dg').datagrid('selectRow', editIndex);
                }
            }
        }

    function GetTableB() {
        $.ajax({
            type: 'post',
            url: '/Ashx/ProjectMaterial.ashx?action=GetB',
            success: function (res) {
                if (res == "success") {
                    $.messager.show({ title: '提示', msg: '生成成功。' });
                    $('#dg').datagrid("reload");
                }
                else {
                    $.messager.show({ title: '提示', msg: '生成失败。' });
                }
            }
        });
    }

    function Getmaterial(pID) {
        $('#material').combobox({
            url: '/Ashx/ProjectMaterial.ashx?action=GetProductName&projectID=' + pID + '',
            valueField: 'ptID',
            textField: 'ptName',
            editable: false,
            onChange: function (newValue, oldValue) {
                //LoadTable(newValue);
                $('#dg').datagrid('options').queryParams = { "projectID": $('#project_name').combobox('getValue'), "ptID": newValue };
                $('#dg').datagrid('load');
            }
        });
    }

    function End(index) {
        $("#dg").datagrid('endEdit', index);
    }

    function EndEdit() {
        var rows = $("#dg").datagrid('getRows');
        for (var i = 0; i < rows.length; i++) {
            $("#dg").datagrid('endEdit', i);
        }
    }

    function add() {
        EndEdit();
        $('#dg').datagrid('insertRow', { index: 0, row: {} }).datagrid("beginEdit", 0);


    }

    function del() {
        var row = $('#dg').datagrid('getSelected');
        if (row == null) {
            $.messager.show({ title: "warn", msg: "请选择要删除的行！" });

        }
        var rowIndex = $('#dg').datagrid('getRowIndex', row);
        // alert(rowIndex);
        $('#dg').datagrid('deleteRow', rowIndex);
    }




    function save() {

        EndEdit();


        // alert(allRows.length);
        var delstr = "";
        var updatestr = "";
        var addstr = "";
        var allstr = "";

        var allRows = $('#dg').datagrid('getRows');
        allstr = JSON.stringify(allRows);
        // alert(allstr.length);
        var delRows = $('#dg').datagrid('getChanges', 'deleted');
        delstr = JSON.stringify(delRows);
        //alert(delstr);
        var updateRows = $('#dg').datagrid('getChanges', 'updated');
        updatestr = JSON.stringify(updateRows);
        //alert(updatestr);
        var addRows = $('#dg').datagrid('getChanges', 'inserted');
        addstr = JSON.stringify(addRows);

        $.ajax({
            type: "POST",
            //timeout: 30000,
            url: '/Ashx/ProjectMaterial.ashx?action=BEdit',
            data: {
                'action': 'BEdit',
                //'addstr': addstr,
                'updatestr': updatestr//,
               // 'delstr': delstr
            },
            success: function (data) {
                if (data == "success") {
                    $("#dg").datagrid('reload');

                    $.messager.show({ title: '提示', msg: '编辑成功！' });

                }
                else {
                    $.messager.show({ title: '提示', msg: '编辑失败！' });
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.messager.show({ title: "提示", msg: XMLHttpRequest.status });
            }
        });

    }


    function Sumbit() {
        var selected = "";
        var rows = $("#dg").datagrid("getSelections");
        for (var i = 0; i < rows.length; i++) {
                selected += "" + rows[i].ID + ",";
        }
        selected = selected.substr(0, selected.length - 1);

        $.ajax({
            type: 'post',
            url: '/Ashx/ProjectMaterial.ashx',
            data: {
                'action': 'submit_B',

                'sid': selected
            },
            success: function (res) {
                $.messager.show({ title: '提示', msg: res });
                $('#dg').datagrid("reload");
            }
        });

    }

    function CancelSumbit() {
        var selected = "";
        var rows = $("#dg").datagrid("getSelections");

        for (var i = 0; i < rows.length; i++) {
                selected += "" + rows[i].ID + ",";
        }
        selected = selected.substr(0, selected.length - 1);
             


        $.ajax({
            type: 'post',
            url: '/Ashx/ProjectMaterial.ashx',
            data: {
                'action': 'cancelSubmit_B',

                'sid': selected  
            },
            success: function (res) {
                $.messager.show({ title: '提示', msg: res });
                $('#dg').datagrid("reload");
            }
        });
    }

</script>


        
<div id="toolbar">

 <%--<a id="getB" href="javascript:void(0)"  class="easyui-linkbutton" plain="true" data-options="iconCls:'icon-add'" onclick="GetTableB()" style="  ">制作B表</a>  
 <a id="A1" href="javascript:void(0)"  class="easyui-linkbutton" plain="true" data-options="iconCls:'icon-save'" onclick="save()" style="  ">保存B表更改</a>  --%>

          <table style="margin: 5px;">
            <tr>
                <td style="">
                    项目：
                </td>
                <td style="color: blue; padding-right: 20px;">
                <input id="project_name" name="project_name" value="" /> 
                </td>
                <td style="">
                    材料类别：
                </td>
                <td style="color: blue; padding-right: 20px;">
                <input id="material" name="material" value="" /> 
                </td>
            </tr>
        </table>
       <toolbar:ToolBar runat="server" ID="toolbar1" />
</div>

        <table id="dg" ></table>  

</asp:Content>
