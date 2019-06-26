<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ViewB.aspx.cs" Inherits="Maticsoft.Web.Project.Material.ViewB" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="/Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        GetProjectCombo();
        Getmaterial();
        LoadTable();
    });
    function GetProjectCombo() {
        $('#project').combobox({
            url: '/Ashx/Common.ashx?type=getProject',
            valueField: 'sid',
            textField: 'name',
            editable: false,
            onChange: function (newValue, oldValue) {
                $('#tt').datagrid('options').queryParams = { "projectID": newValue };
                $('#tt').datagrid('load');
            }
        });
    }

    function Getmaterial() {
        $('#material').combobox({
            url: '/Ashx/ProjectMaterial.ashx?action=GetProductName',
            valueField: 'ptID',
            textField: 'ptName',
            editable: false,
            onChange: function (newValue, oldValue) {
                //LoadTable(newValue);
                $('#tt').datagrid('options').queryParams = { "projectID": $('#project').combobox('getValue'), "ptID": newValue };
                $('#tt').datagrid('load');
            }
        });
    }

    function LoadTable() {
        $("#tt").datagrid({
            url: "/Ashx/ProjectMaterial.ashx?action=MaterialBListView"
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
                { field: 'ProductTypeRoot', title: '材料类别', width: 100 },
            //{ field: 'psName', title: '空间', width: 100 },
            {field: 'FileNumber', title: '档案编号', width: 100 },
//            { field: 'space', title: '空间', width: 100 },
//            { field: 'place', title: '部位', width: 100 },
        { field: 'productName', title: '货品名称', width: 100 }
                ]]
            , columns: [[
        { field: 'printC', title: '打印C表', width: 50 ,
            formatter: function (value, row, index) {
                return '<a href="PrintC.aspx?type=Ptrint_B&projectSpaceID=' + row.projectSpaceID + '&productID=' + row.productID + '&Color=' + row.Color + '&Size=' + row.Size + '&Brand=' + row.Brand + '" target="_blank"><span>打印C表</span></a>';
            } 
        },
        { field: 'ProductItem', title: '货品细目', width: 100 },
        { field: 'productCode', title: '编号', width: 100 },
        { field: 'Size', title: '规格', width: 100 },
        { field: 'usePlace', title: '应用空间', width: 100 },
        { field: 'colorB', title: '颜色', width: 100, editor: "text" },
        { field: 'brandB', title: '品牌', width: 100, editor: "text" },
        { field: 'supplierID', title: '厂商名称', width: 100, editor:
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
        { field: 'remarkB', title: '备注', width: 100, editor: "text" },
        { field: 'UnitName', title: '单位', width: 100 },
        { field: 'Amount', title: '数量', width: 100 },
        { title: 'supplier', field: 'supplierName', width: 100, editor: "text", hidden: true }
    ]],
            onLoadSuccess: function (data) {
                mergeCellsByFieldGroup('tt', 'ProductTypeRoot,FileNumber|ProductTypeRoot');
            },
            onClickRow: function (index, rowData) {
            }
                , onClickCell: function (rowIndex, field, value) { $("#tt").datagrid("clearSelections"); }

        });
    }

    function print() {
        var material = $('#material').combobox("getValue");
        if (material == '' || material==undefined) {
            var row = $("#tt").datagrid('getSelected');
            if (row != null) {
                material = row.productTypeRootID;
            }
            else {
                $.messager.show({ title: "错误提示", msg: "请选择要打印的材料类别！" });
                return;
            }
        }
        window.open("PrintB.aspx?projectID=" + $('#project').combobox("getValue") + "&material=" + material);
        
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
                <input id="project" name="project" value="" /> 
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
</asp:Content>
