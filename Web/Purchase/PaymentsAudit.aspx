<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="PaymentsAudit.aspx.cs" Inherits="Maticsoft.Web.Purchase.PaymentsAudit" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="/Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="../js/com-datagrid.js" type="text/javascript"></script>
    <script type="text/javascript">
        var frozencolumns = [[]];
        var columns = [[
         { field: "ckb", checkbox: true, width: 5 },
         { title: '商品编码', field: 'Code', width: 80, halign: 'center' },
         { title: '商品名称', field: 'Name', width: 80, halign: 'center' },
         { title: '商品规格', field: 'Size', width: 80, halign: 'center' },
         { title: '项目', field: 'ProjectName', width: 80, halign: 'center' },
         { title: '应用空间', field: 'usePlace', width: 80, halign: 'center' },
         { title: '颜色编码', field: 'ColorCode', width: 80, halign: 'center' },
         { title: '颜色名称', field: 'ColorName', width: 80, halign: 'center' },
         { title: '单位', field: 'unitName', width: 80, halign: 'center' },
         { title: '计划采购量', field: 'PlanAmount', width: 80, halign: 'center', editor: "diseditText" },
         { title: '完成状态', field: 'curStatus', width: 80, halign: 'center' },
         { title: '预计价格', field: 'ExpectedPrice', width: 80, halign: 'center', editor: { type: "numberbox", options: {
             min: 0,
             precision: 2,
             onChange: function (newValue, oldValue) {
                 //$.messager.show({ title: '错误提示', msg: oldValue });
                 var index = $('#tt').datagrid('getRowIndex', $('#tt').datagrid('getSelected'));
                 var m = $('#tt').datagrid('getEditor', { index: index, field: 'sumMoney' });
                 var discount = $('#tt').datagrid('getEditor', { index: index, field: 'Discount' });
                 var amount = $('#tt').datagrid('getEditor', { index: index, field: 'PlanAmount' });
                 if (m.target != undefined) {
                     $(m.target).val(newValue * $(amount.target).val() * $(discount.target).numberbox('getValue'));
                     //$(m.target).val(1);
                 }
             }
         }
         }
         },
         { title: '折率', field: 'Discount', width: 80, halign: 'center', editor: { type: "numberbox", options: { min: 0, max: 1, precision: 2,
             onChange: function (newValue, oldValue) {
                 var index = $('#tt').datagrid('getRowIndex', $('#tt').datagrid('getSelected'));
                 var m = $('#tt').datagrid('getEditor', { index: index, field: 'sumMoney' });
                 var price = $('#tt').datagrid('getEditor', { index: index, field: 'ExpectedPrice' });
                 var amount = $('#tt').datagrid('getEditor', { index: index, field: 'PlanAmount' });
                 if (m.target != undefined) {
                     $(m.target).val(newValue * $(amount.target).val() * $(price.target).numberbox('getValue'));
                 }
             }
         }
         }
         },
         { title: '金额', field: 'sumMoney', width: 80, halign: 'center', editor: "diseditText" },
         { title: '计划采购日期', field: 'PlansPurchaseDate', width: 80, halign: 'center', editor: { type: 'datebox', options: {
             //required: true,
             formatter: function (date) {
                 var y = date.getFullYear();
                 var m = date.getMonth() + 1;
                 var d = date.getDate();
                 return y + '-' + m + '-' + d;
             }
         }
         }
         },
         { title: '计划出厂日期', field: 'PlansFactoryDate', width: 80, halign: 'center', editor: { type: 'datebox', options: {
             //required: true, 
             formatter: function (date) {
                 var y = date.getFullYear();
                 var m = date.getMonth() + 1;
                 var d = date.getDate();
                 return y + '-' + m + '-' + d;
             },
             onSelect: function (date) {

             }
         }
         }
         },
         { title: '预计到货日期', field: 'ExpectedArrivalDate', width: 80, halign: 'center', editor: { type: 'datebox', options: {
             //required: true, 
             formatter: function (date) {
                 var y = date.getFullYear();
                 var m = date.getMonth() + 1;
                 var d = date.getDate();
                 return y + '-' + m + '-' + d;
             }
         }
         }
         },
         { title: '计划供应商', field: 'PlansSupplier', width: 80, halign: 'center', editor:
                    {
                        type: 'combobox',
                        options: {
                            //required: true,
                            valueField: 'spID',
                            textField: 'name',
                            url: '/Ashx/ProjectMaterial.ashx?action=GetSupplier',
                            //required: true,
                            onSelect: function (record) {
                                //var ed = $('#tt').datagrid('getEditor', { index: editIndex, field: 'supplierID' });
                                //var supplier = $(ed.target).combobox('getText');
                                var suppliered = $('#tt').datagrid('getEditor', { index: editIndex, field: 'supplierName' });
                                $(suppliered.target).val($(this).combobox('getText'));
                            }
                        }
                    }
                    ,
             formatter: function (value, row, index) {
                 return row.supplierName;
             }
         },
         { title: '指定采购产品订单号', field: 'p1', width: 80, halign: 'center', hidden: true },
         { title: '订单项次', field: 'p2', width: 80, halign: 'center', hidden: true },

         { title: '说明', field: 'PlanTypeName', width: 80, halign: 'center' },
         { title: '备注', field: 'remark', width: 80, halign: 'center', editor: "text" },
         { title: 'supplier', field: 'supplierName', width: 100, editor: "text", hidden: true }
          ,
                    { title: '提交人', field: 'SubmitPerson', halign: 'center', width: 100 }
                     ,
                    { title: '提交时间', field: 'SubmitDate', halign: 'center', width: 100 }
                     ,
                    { title: '审核人', field: 'Auditor', halign: 'center', width: 100 }
                     ,
                    { title: '审核时间', field: 'AuditDate', halign: 'center', width: 100 }
        //                     ,
        //                    { title: '创建人', field: 'creater', halign: 'center', width: 100 }
        //                     ,
        //                    { title: '创建时间', field: 'create_date', halign: 'center', width: 100 }
                     ,
                    { title: '修改人', field: 'updater', halign: 'center', width: 100 }
                     ,
                    { title: '修改时间', field: 'update_date', halign: 'center', width: 100 }
         ]];
        var datagridURL = "/Ashx/Pruchase.ashx?action=PlanSHList";

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
            EndEdit();
        });

        function EndEdit() {
            var rows = $("#tt").datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $("#tt").datagrid('endEdit', i);
            }
        }

        function CustomEditRow(index, data) {
            if (data.Submit == 1) {
                //$.messager.show({ title: '错误提示', msg: '此项已提交不能编辑' });
            }
            else {
                EditRow(index);
            }
        }

        function GridReload(val) {
            $('#tt').datagrid('options').queryParams = { "projectID": $('#project').combobox('getValue'), "status": val };
            $('#tt').datagrid('load');
        }


        //审核
        function sh() {
            var selected = "";
            var rows = $("#tt").datagrid("getSelections");

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
                    'action': 'PlanSH',

                    'selects': selected
                },
                success: function (res) {
                    $.messager.show({ title: '提示', msg: res });
                    $('#tt').datagrid("reload");
                }
            });

        }


        //审核不通过
        function PlanSHBtg() {
            var selected = "";
            var rows = $("#tt").datagrid("getSelections");

            for (var i = 0; i < rows.length; i++) {
                if (rows[i].curStatusNo == 4) {
                    selected += "" + rows[i].ID + ",";
                }
            }
            selected = selected.substr(0, selected.length - 1);

            $.ajax({
                type: 'post',
                url: '/Ashx/Pruchase.ashx',
                data: {
                    'action': 'PlanSHBtg',

                    'selects': selected
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
  <toolbar:ToolBar runat="server" ID="toolbar1" />
  <a href="#" id="tab_10" class="easyui-linkbutton" plain="true" onclick="sh()" iconCls="icon-sh">审批</a>
  <a href="#" id="tab_11" class="easyui-linkbutton" plain="true" onclick="PlanSHBtg()" iconCls="icon-sh">审批不通过</a>
  </div>
</asp:Content>
