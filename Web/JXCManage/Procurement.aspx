<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Procurement.aspx.cs" Inherits="Maticsoft.Web.JXCManage.Procurement" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    $(function () {
        LoadTable();
    });


    
</script>
          <toolbar:ToolBar runat="server" ID="toolbar1"/>
          <table id="dg"></table>
          <script type="text/javascript">
              var row;
              function LoadTable() {
               
                  $('#dg').datagrid({
                      url: '../Ashx/Procurement.ashx?action=list',
                      loadMsg: "正在努力加载中..."
                , toolbar: "#tab_toolbar"
                , idField: "ID"
                , pageSize: 10
                , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
                , nowrap: false
                , remoteSort: true
                , pagination: true
                , rownumbers: true
                , singleSelect: true,
                      columns: [[
        { field: 'Odd', title: '单号', width: 150 },
        { field: 'OrderDate', title: '订货日期', width: 150 },
        { field: 'Buyer', title: '采购员', width: 150 },
        { field: 'Supplier', title: '供应商', width: 150 },
        { field: 'SupplierHandled', title: '供应商经手人', width: 150 },
        { field: 'DeliveryDate', title: '送货日期', width: 150 },
        { field: 'Currency', title: '货币', width: 150 },
        { field: 'ExchangeRate', title: '汇率', width: 150 },
        { field: 'PriceReduction', title: '降价', width: 150 },
        { field: 'PayTerm', title: '付款条件，付款期', width: 150 },
        { field: 'DiscountRate', title: '折率', width: 150 },
        { field: 'Deposit', title: '订金', width: 150 },
        { field: 'AccountsMode', title: '结算方式', width: 150 },
        { field: 'TaxRate', title: '税率', width: 150 },
        { field: 'OtherFees', title: '运杂费', width: 150 },
        { field: 'PlansFactoryDate', title: '计划出厂日期', width: 150 },
        { field: 'FactoryDate', title: '实际出厂日期', width: 150 },
        { field: 'Transport', title: '运输方式', width: 150 },
        { field: 'DeliveryAddress', title: '送货地址', width: 150 },
        { field: 'state', title: '状态', width: 150 },
        { field: 'Directions', title: '说明', width: 150 },
        { field: 'remark', title: '备注', width: 150 },
        { field: 'status', title: '数据状态', width: 150 },
        { field: 'create_user', title: '创建人', width: 150 },
        { field: 'create_date', title: '创建日期', width: 150 },
        { field: 'update_user', title: '更新人', width: 150 },
        { field: 'update_date', title: '更新日期', width: 150 }

    ]],
                      onClickRow: function (rowIndex, rowData) {
                          row = $("#dg").datagrid("getSelected");
                      }
                  });
              }



              function add() {     
                      url = "/JXCManage/JXC_Detail.aspx?action=add";
                      parent.addTab('采购详细', url);
              }

              function edit() {
                  if (row != null) {
                      url = "/JXCManage/JXC_Detail.aspx?action=edit&id=" + row.ID + "";
                      parent.addTab('采购详细' + row.Odd, url);
                  }
                  else {
                      $.messager.show({title:"warn",msg:"请选择需要编辑的行!"});
                  }
              }
          </script>

          <div style=" width:500px;"> </div>
</asp:Content>
