<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ViewA.aspx.cs" Inherits="Maticsoft.Web.Project.Material.ViewA" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="/Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        LoadTable();
        GetProjectCombo();
        GetSpaceCombo();
        GetPlaceCombo();
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
                $('#tt').datagrid('options').queryParams = { "projectID":$('#project').combobox('getValue'),"spaceID": newValue };
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
                $('#tt').datagrid('options').queryParams = {"projectID":$('#project').combobox('getValue'),"spaceID": $('#space').combobox('getValue'), "placeID": newValue };
                $('#tt').datagrid('load');
            }
        });
    }

    function LoadTable() {
        $("#tt").datagrid({
            url: "/Ashx/ProjectMaterial.ashx?action=MaterialAListView"
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
                    { title: '空间', field: 'space', width: 150, halign: 'center' },
                    { title: '部位', field: 'place', width: 80, halign: 'center' },

                    { title: '位置', field: 'locationID', width: 80, halign: 'center', editor: { type: 'combobox',
                        options: { url: '/Ashx/Common.ashx?type=getDic&catg=14',
                            valueField: 'Value',
                            textField: 'Text',
                            required: true,
                            panelHeight: 'auto',
                            editable: false,
                            onChange: function (newValue, oldValue) {
                                try {
                                    var row = $('#tt').datagrid('getSelected');
                                    var thised = $('#tt').datagrid('getEditor', { index: editIndex, field: 'locationID' });
                                    var oldText = $(thised.target).combobox('getText');
                                    var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'productID' });
                                    var product = $(ed.target).val();

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
                                            'placeID': row.projectSpaceID,
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
                    },
                        formatter: function (value, row, index) {
                            return row.location;
                            //return row.node_type_name;
                        }
                    },
                    { title: '图纸编号', field: 'DrawingNumber', width: 80, halign: 'center', align: 'center',},
                    { title: '编号', field: 'productCode', width: 80, halign: 'center', align: 'center' },
                    { title: '内容', field: 'productName', width: 80, halign: 'center', align: 'center' }
                ]]
                , columns: [
                    [
                    { title: '尺寸', field: 'Size', width: 80, halign: 'center', align: 'center'},
                    { title: '单位', field: 'UnitName', width: 80, halign: 'center', align: 'center'},
                    { title: '数量', field: 'Amount', width: 80, halign: 'center', align: 'center'},
                    { title: '颜色 ', field: 'Color', width: 80, halign: 'center', align: 'center'},
                    { title: '质地 ', field: 'Quality', width: 80, halign: 'center', align: 'center'},
                    { title: '品牌', field: 'Brand', width: 100, halign: 'center'},
                    { title: '阻燃性', field: 'NFK', width: 100, halign: 'center'}, 
                    { title: '备注', field: 'remark', width: 100, halign: 'center'}, 
                    { title: '状态', field: 'AStatus', halign: 'center', width: 100 },
                    { title: '提交人', field: 'SubmitPerson', halign: 'center', width: 100 },
                    { title: '提交时间', field: 'SubmitDate', halign: 'center', width: 100 },
                    { title: '审核人', field: 'Auditor', halign: 'center', width: 100 },
                    { title: '审核时间', field: 'AuditDate', halign: 'center', width: 100 },
                    { title: '校核人', field: 'CheckPerson', halign: 'center', width: 100 },
                    { title: '校核时间', field: 'CheckDate', halign: 'center', width: 100 },
                    { title: '创建人', field: 'create_person', halign: 'center', width: 100 },
                    { title: '创建时间', field: 'create_date', halign: 'center', width: 100 },
                    { title: '修改人', field: 'update_person', halign: 'center', width: 100 },
                    { title: '修改时间', field: 'update_date', halign: 'center', width: 100 }
                    ]
                ],
            onLoadSuccess: function (data) {
                mergeCellsByFieldGroup('tt', 'space,place,locationID,AStatus|place,SubmitPerson|place,SubmitDate|place,Auditor|place,AuditDate|place,CheckPerson|place,CheckDate|place');
            },
            onClickRow: function (index, rowData) {
            }
                , onClickCell: function (rowIndex, field, value) { $("#tt").datagrid("clearSelections"); }

        });
    }

    function print() {
        window.open("PrintA.aspx?projectID="+$('#project').combobox("getValue")+"&spaceID="+$('#space').combobox("getValue")+"&placeID="+$('#place').combobox("getValue"));
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