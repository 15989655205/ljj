<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="PrepaymentsAudit.aspx.cs" Inherits="Maticsoft.Web.Purchase.PrepaymentsAudit" %>
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
         { title: '合同号', field: 'Contract', width: 80, halign: 'center'},
         { title: '合同总金额', field: 'ContractTotal', width: 80, halign: 'center' },
         { title: '已付总金额', field: 'ContractPaid', width: 80, halign: 'center' },
         { title: '已冲金额', field: 'Paid', width: 80, halign: 'center' },
         { title: '备注', field: 'remark', width: 80, halign: 'center'},
         { title: '提交人', field: 'SubmitPerson', halign: 'center', width: 100 },
         { title: '提交时间', field: 'SubmitDate', halign: 'center', width: 100 },
         { title: '审核人', field: 'Auditor', halign: 'center', width: 100 },
         { title: '审核时间', field: 'AuditDate', halign: 'center', width: 100 },
         { title: '修改人', field: 'updater', halign: 'center', width: 100 },
         { title: '修改时间', field: 'update_date', halign: 'center', width: 100 }
         ]];
        var datagridURL = "/Ashx/Pruchase.ashx?action=PrePaymentAuditList";
        var params = { 'status': 2 };

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
            LoadTable('tt', datagridURL, frozencolumns, columns, 'toolbar', 'ID', params);
        });

        //审核
        function sh() {
            var selected = "";
            var rows = $('#tt').datagrid('getSelections');
            if (rows.length <= 0) {
                $.messager.show({ title: "系统提示", msg: "请选择您要“审批”的数据。" });
                return;
            }
            for (var i = 0; i < rows.length; i++) {
                selected += "" + rows[i].ID + ",";
            }
            selected = selected.substr(0, selected.length - 1);
            if (selected.length > 0) {
                $.post("/Ashx/Pruchase.ashx", { "action": "PrePaymentAudit","type":"pass", "selects": selected }, function (data) {
                    $("#tt").datagrid("reload");
                    $.messager.show({ title: "系统提示", msg: data });
                });
            }
        }

        //审核不通过
        function np() {
            var selected = "";
            var rows = $('#tt').datagrid('getSelections');
            if (rows.length <= 0) {
                $.messager.show({ title: "系统提示", msg: "请选择您要“审批”的数据。" });
                return;
            }
            for (var i = 0; i < rows.length; i++) {
                selected += "" + rows[i].ID + ",";
            }
            selected = selected.substr(0, selected.length - 1);
            if (selected.length > 0) {
                $.post("/Ashx/Pruchase.ashx", { "action": "PrePaymentAudit","type":"nopass", "selects": selected }, function (data) {
                    $("#tt").datagrid("reload");
                    $.messager.show({ title: "系统提示", msg: data });
                });
            }
        }

        //查看事件
        function view() {
            var row = $('#tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '提示', msg: '请选择操作项' });
                return;
            }
            url = "/Purchase/PurchaseItem.aspx?action=view&sid=" + row.ID;
            parent.addTab_Ext('进货单' + row.Code + '【查看】', url, "", true);
        }

        function GridReload(val) {
            if (val == 2) {
                $('#sh').linkbutton('enable');
                $('#np').linkbutton('enable');
            }
            else {
                $('#sh').linkbutton('disable');
                $('#np').linkbutton('disable');
            }
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
                    状态：
                </td>
                <td style="color: blue; padding-right: 20px;">
                <select id="status" class="easyui-combobox" name="status" style="width:150px;" data-options="editable:false,onChange: function (newValue, oldValue) {GridReload(newValue);}">  
    <option value="2">未审核</option>   
    <option value="4">经我审核</option>     
</select>  


                </td>
            </tr>
        </table>
        <a href="#" id="sh" class="easyui-linkbutton" plain="true" onclick="sh()" iconCls="icon-ok">审批通过</a>
        <a href="#" id="np" class="easyui-linkbutton" plain="true" onclick="np()" iconCls="icon-cancel">审批不通过</a>
    </div>
</asp:Content>

