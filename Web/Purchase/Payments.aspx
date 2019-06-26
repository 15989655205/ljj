<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="Maticsoft.Web.Purchase.Payments" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="/Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/com-datagrid.js" type="text/javascript"></script>
    <script type="text/javascript">
        var frozencolumns = [[]];
        var columns = [[
         { field: "ckb", checkbox: true, width: 5 },
         { title: '状态', field: 'curStatus', width: 80, halign: 'center' },
         { title: '流水号', field: 'Code', width: 80, halign: 'center' },
         { title: '厂家', field: 'SupplierName', width: 80, halign: 'center' },
         { title: '经手人', field: 'Buyer', width: 80, halign: 'center' },
         { title: '货币', field: 'Currency', width: 80, halign: 'center' },
         { title: '汇率', field: 'ExchangeRate', width: 80, halign: 'center' },
         { title: '金额', field: 'Deposit', width: 80, halign: 'center' },
         { title: '结算方式', field: 'AccountsMode', width: 80, halign: 'center' },
         { title: '合同号', field: 'Contract', width: 80, halign: 'center', editor: 'text' },
         { title: '合同总金额', field: 'ContractTotal', width: 80, halign: 'center' },
         { title: '已付总金额', field: 'ContractPaid', width: 80, halign: 'center' },
         { title: '已冲金额', field: 'Paid', width: 80, halign: 'center' },
         { title: '备注', field: 'remark', width: 80, halign: 'center', editor: "text" },
         { title: '提交人', field: 'SubmitPerson', halign: 'center', width: 100 },
         { title: '提交时间', field: 'SubmitDate', halign: 'center', width: 100 },
         { title: '审核人', field: 'Auditor', halign: 'center', width: 100 },
         { title: '审核时间', field: 'AuditDate', halign: 'center', width: 100 },
         { title: '修改人', field: 'updater', halign: 'center', width: 100 },
         { title: '修改时间', field: 'update_date', halign: 'center', width: 100 }
         ]];
        var datagridURL = "/Ashx/Pruchase.ashx?action=CheckoutList";

        function GetProjectCombo() {
            $('#project').combobox({
                url: '/Ashx/Common.ashx?type=getProject',
                valueField: 'sid',
                textField: 'name',
                editable: false,
                onChange: function (newValue, oldValue) {
                    $('#tt').datagrid('options').queryParams = { "projectID": newValue, "status": $('#status').combobox('getValue') };
                    $('#tt').datagrid('load');
                }
            });
        }

        $(function () {
            GetProjectCombo();
            LoadTable('tt', datagridURL, frozencolumns, columns, 'toolbar', 'ID');
        });

        function CustomEditRow(index, data) {
            if (data.Submit == 1) {
                //$.messager.show({ title: '错误提示', msg: '此项已提交不能编辑' });
            }
            else {
                EditRow(index);
            }
        }

        function save() {
            GridSave("/Ashx/Pruchase.ashx", "CheckoutSave");
        }

        function EndEdit() {
            var rows = $("#tt").datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $("#tt").datagrid('endEdit', i);
            }
        }


        function Sumbit() {
            var selected = "";

            var rows = $('#tt').datagrid('getSelections');
            if (rows.length <= 0) {
                $.messager.show({ title: "系统提示", msg: "请选择您要“提交”的数据。" });
                return;
            }
            var index;
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].curStatusNo == 2) {
                    selected += "" + rows[i].ID + ",";
                    if (rows[i].ExpectedPrice.length <= 0) {
                        $.messager.show({ title: '错误提示', msg: "预计价格不能为空" });
                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
                        EditRow(index);
                        return false;
                    }
                    if (rows[i].Discount.length <= 0) {
                        $.messager.show({ title: '错误提示', msg: "折率不能为空" });
                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
                        EditRow(index);
                        return false;
                    }
                    if (rows[i].PlansPurchaseDate.length <= 0) {
                        $.messager.show({ title: '错误提示', msg: "计划采购日期不能为空" });
                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
                        EditRow(index);
                        return false;
                    }
                    if (rows[i].PlansFactoryDate.length <= 0) {
                        $.messager.show({ title: '错误提示', msg: "计划出厂日期不能为空" });
                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
                        EditRow(index);
                        return false;
                    }
                    if (rows[i].ExpectedArrivalDate.length <= 0) {
                        $.messager.show({ title: '错误提示', msg: "预计到货日期不能为空" });
                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
                        EditRow(index);
                        return false;
                    }
                    if (rows[i].spID.length <= 0) {
                        $.messager.show({ title: '错误提示', msg: "计划供应商不能为空" });
                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
                        EditRow(index);
                        return false;
                    }
                }
            }

            selected = selected.substr(0, selected.length - 1);
            //$.messager.confirm("系统提示", "确认提交？", function (r) {
            //    if (r) {
            if (selected.length > 0) {
                $.post("/Ashx/Pruchase.ashx", { "action": "CheckoutSubmit", "selects": selected }, function (data) {
                    $("#tt").datagrid("reload");
                    $.messager.show({ title: "系统提示", msg: data });
                });
            }
            //    }
            // });
        }

        function CancelSumbit() {
            var selected = "";
            var rows = $('#tt').datagrid('getSelections');
            if (rows.length <= 0) {
                $.messager.show({ title: "系统提示", msg: "请选择您要“撤销提交”的数据。" });
                return;
            }
            var index;
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].curStatusNo == 3) {
                    selected += "" + rows[i].ID + ",";
                }
            }
            selected = selected.substr(0, selected.length - 1);


            $.ajax({
                type: 'post',
                url: '/Ashx/Pruchase.ashx',
                data: {
                    'action': 'CheckoutCancelSubmit',
                    'selects': selected
                },
                success: function (res) {
                    $.messager.show({ title: '提示', msg: res });
                    $('#tt').datagrid("reload");
                }
            });
        }

        function GridReload(val) {
            $('#tt').datagrid('options').queryParams = { "projectID": $('#project').combobox('getValue'), "status": val };
            $('#tt').datagrid('load');
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
                    完成状态：
                </td>
                <td style="color: blue; padding-right: 20px;">
                <select id="status" class="easyui-combobox" name="status" style="width:150px;" data-options="editable:false,onChange: function (newValue, oldValue) {GridReload(newValue);}"> 
                <option value="0">所有</option>   
    <option value="1">未提交</option>   
    <option value="2">未审核</option> 
    <option value="3">不通过</option>  
    <option value="4">完成</option>     
</select>  


                </td>
            </tr>
        </table>
        <toolbar:ToolBar runat="server" ID="toolbar1" />
    </div>
</asp:Content>

