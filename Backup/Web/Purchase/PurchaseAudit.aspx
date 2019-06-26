<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="PurchaseAudit.aspx.cs" Inherits="Maticsoft.Web.Purchase.PurchaseAudit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/com-datagrid.js" type="text/javascript"></script>
    <script type="text/javascript">
        var frozencolumns = [[]];
        var columns = [[
        { title: '状态', field: 'curStatus', width: 80, halign: 'center' },
         { title: '流水号', field: 'Code', width: 80, halign: 'center' },
         { title: '厂家', field: 'SupplierName', width: 80, halign: 'center' },
         { title: '厂家经手人', field: 'LinkMan', width: 80, halign: 'center' },
         { title: '厂家电话', field: 'Mobile', width: 80, halign: 'center' },
         { title: '帐务归属', field: 'Principal', width: 80, halign: 'center' },
         { title: '采购员', field: 'Buyer', width: 80, halign: 'center' },
         { title: '送货日期', field: 'DeliveryDate', width: 80, halign: 'center' },
         { title: '货币', field: 'Currency', width: 80, halign: 'center' },
         { title: '汇率', field: 'ExchangeRate', width: 80, halign: 'center' },
         { title: '付款条件', field: 'PayTerm', width: 80, halign: 'center' },
         { title: '折率', field: 'DiscountRate', width: 80, halign: 'center' },
         { title: '降价', field: 'a', width: 80, halign: 'center' },
         { title: '订金', field: 'Deposit', width: 80, halign: 'center' },
         { title: '结算方式', field: 'AccountsMode', width: 80, halign: 'center' },
         { title: '税率', field: 'TaxRate', width: 80, halign: 'center' },
         { title: '运杂费', field: 'OtherFees', width: 80, halign: 'center' },
         { title: '计划出厂日期', field: 'PlansFactoryDate', width: 80, halign: 'center' },
         { title: '实际出厂日期', field: 'FactoryDate', width: 80, halign: 'center' },
         { title: '合计', field: 'b', width: 80, halign: 'center' },
         { title: '备注', field: 'remark', width: 80, halign: 'center', editor: "text" },
         { title: '提交人', field: 'SubmitPerson', halign: 'center', width: 100 },
         { title: '提交时间', field: 'SubmitDate', halign: 'center', width: 100 },
         { title: '审核人', field: 'Auditor', halign: 'center', width: 100 },
         { title: '审核时间', field: 'AuditDate', halign: 'center', width: 100 },
         { title: '修改人', field: 'updater', halign: 'center', width: 100 },
         { title: '修改时间', field: 'update_date', halign: 'center', width: 100 }
         ]];
        var datagridURL = "/Ashx/Pruchase.ashx?action=PruchaseAuditList";
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

        function CustomEditRow(index, data) {
            if (data.Submit == 1) {
                //$.messager.show({ title: '错误提示', msg: '此项已提交不能编辑' });
            }
            else {
                EditRow(index);
            }
        }

        //审核
        function sh() {
            var row = $('#tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '提示', msg: '请选择操作项' });
                return;
            }
            url = "/Purchase/PurchaseItem.aspx?action=audit&sid=" + row.ID;
            parent.addTab_Ext('进货单' + row.Code + '【审核】', url, "", true);
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
            }
            else {
                $('#sh').linkbutton('disable');
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
        <a href="#" id="sh" class="easyui-linkbutton" plain="true" onclick="sh()" iconCls="icon-sh">审批</a>
        <a href="#" id="view" class="easyui-linkbutton" plain="true" onclick="view()" iconCls="icon-view">查看</a>
    </div>
</asp:Content>
