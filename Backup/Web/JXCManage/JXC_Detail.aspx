<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true"
    CodeBehind="JXC_Detail.aspx.cs" Inherits="Maticsoft.Web.JXCManage.JXC_Detail" %>

<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #tb input[type=text]
        {
            width: 160px;
            border: 0px;
            border-bottom: 1px solid #C0D9D9;
            background-color: transparent;
        }
        .style1
        {
            width: 119px;
        }
        .style2
        {
            width: 122px;
        }
        .style3
        {
            width: 101px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
       var action='<%=Action %>';
        $(function () {
     
            setControls();
        });

        //控件初始化
        function setControls() {
            $("#txtOrderDate").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
            $("#txtDeliveryDate").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
            $("#txtPlansFactoryDate").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
            $("#txtFactoryDate").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
        }

        function saveAll() {

            endEdit();
            
            var addStr = "";
            var updateStr = "";
            var delSrt = "";

            var allRows = $("#tt").datagrid("getChanges", "inserted");
            addStr = JSON.stringify(allRows);
            var updateRows = $("#tt").datagrid("getChanges", "updated");
            updateStr = JSON.stringify(updateRows);
            var delRows = $("#tt").datagrid("getChanges", "deleted");
            delSrt = JSON.stringify(delRows);
            
            $.ajax({
                type: "POST",
                url: "../Ashx/JXC_Detail.ashx?action="+action+"&id=<%=PPID %>",
                data: {
                    txtOdd: $("#txtOdd").val(),
                    txtOrderDate:$("#txtOrderDate").datebox('getValue'),
                    txtSupplier:$("#txtSupplier").val(),
                    txtBuyer:$("#txtBuyer").val(),
                    txtSupplierHandled:$("#txtSupplierHandled").val(),
                    txtDeliveryDate:$("#txtDeliveryDate").datebox('getValue'),
                    txtCurrency:$("#txtCurrency").val(),
                    txtExchangeRate:$("#txtExchangeRate").val(),
                    txtPriceReduction:$("#txtPriceReduction").val(),
                    txtPayTerm:$("#txtPayTerm").val(),
                    txtDiscountRate:$("#txtDiscountRate").val(),
                    txtDeposit:$("#txtDeposit").val(),
                    txtAccountsMode:$("#txtAccountsMode").val(),
                    txtTaxRate:$("#txtTaxRate").val(),
                    txtOtherFees:$("#txtOtherFees").val(),
                    txtPlansFactoryDate:$("#txtPlansFactoryDate").datebox('getValue'),
                    txtFactoryDate:$("#txtFactoryDate").datebox('getValue'),
                    txtTransport:$("#txtTransport").val(),
                    txtDeliveryAddress:$("#txtDeliveryAddress").val(),
                    txtDirections:$("#txtDirections").val(),
                    txtRemark:$("#txtRemark").val(),
                    'addstr': addStr,
                    'updatestr': updateStr,
                    'delstr': delSrt
                   
                },
                success: function (res) {
                    if (res == "success！") {
                        $.messager.show({ title: "warn", msg: "保存成功！" });
                    }
                    else {
                        $.messager.show({ title: "warn", msg: "保存失败" + res });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: "提示", msg: XMLHttpRequest.status });
                }

            });
    }
    </script>
    <div style="position: absolute; top: 0; left: 0; z-index: 9999; width: 100%; height: 30px; text-align:right;
        background-color: #e6e7e8;">
        <a id="save" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'"
            onclick="saveAll()">保存</a> <a id="cancel" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'">
                取消</a>
    </div>
    <div id="cc" class="easyui-layout" style="margin-top: 30px; width: 100%; height: 650px;
        overflow: hidden; overflow-y: hidden; overflow-x: hidden;">
        <div data-options="region:'north',title:'采购计划单',split:true" style="width: 100%; height: 289px;
            overflow: hidden; overflow-x: hidden;">
            <h2 style="text-align: center; font-family: @微软雅黑; font-size: 17px; padding-right: 210px;
                margin: 0 0; height: 25px; line-height: 25px; color: #000000">
                进销存采购计划明细-单号(<%=Odd%>)</h2>
            <table id="tb" style="width: 100%; font-family: @微软雅黑; "
                border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="style1">
                        单号:
                    </td>
                    <td>
                        <input id="txtOdd" type="text" value="<%=Odd%>" />
                    </td>
                    <td class="style2">
                        订货日期:
                    </td>
                    <td>
                        <input id="txtOrderDate" type="text" value="<%=OrderDate%>" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        供应商 ：
                    </td>
                    <td>
                        <input id="txtSupplier" type="text" value="<%=Supplier%>" />
                    </td>
                    <td class="style2">
                        采购员 :
                    </td>
                    <td>
                        <input id="txtBuyer" type="text" value="<%=Buyer%>" />
                    </td>
                    <td class="style3">
                        供应商经手人:
                    </td>
                    <td>
                        <input id="txtSupplierHandled" type="text" value="<%=SupplierHandled %>" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        送货日期:
                    </td>
                    <td>
                        <input id="txtDeliveryDate" type="text" value="<%=DeliveryDate%>" />
                    </td>
                    <td class="style2">
                        货币:
                    </td>
                    <td>
                        <input id="txtCurrency" type="text" value="<%=Currency%>" />
                    </td>
                    <td class="style3">
                        汇率:
                    </td>
                    <td>
                        <input id="txtExchangeRate" type="text" value="<%=ExchangeRate%>" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        降价:
                    </td>
                    <td>
                        <input id="txtPriceReduction" type="text" value="<%=PriceReduction%>" />
                    </td>
                    <td class="style2">
                        付款条件，付款期:
                    </td>
                    <td>
                        <input id="txtPayTerm" type="text" value="<%=PayTerm%>" />
                    </td>
                    <td class="style3">
                        折率:
                    </td>
                    <td>
                        <input id="txtDiscountRate" type="text" value="<%=DiscountRate%>" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        订金:
                    </td>
                    <td>
                        <input id="txtDeposit" type="text" value="<%=Deposit%>" />
                    </td>
                    <td class="style2">
                        结算方式:
                    </td>
                    <td>
                        <input id="txtAccountsMode" type="text" value="<%=AccountsMode%>" />
                    </td>
                    <td class="style3">
                        税率:
                    </td>
                    <td>
                        <input id="txtTaxRate" type="text" value="<%=TaxRate%>" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        运杂费:
                    </td>
                    <td>
                        <input id="txtOtherFees" type="text" value="<%=OtherFees%>" />
                    </td>
                    <td class="style2">
                        计划出厂日期:
                    </td>
                    <td>
                        <input id="txtPlansFactoryDate" type="text" value="<%=PlansFactoryDate%>" />
                    </td>
                    <td class="style3">
                        实际出厂日期:
                    </td>
                    <td>
                        <input id="txtFactoryDate" type="text" value="<%=FactoryDate%>" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        运输方式:
                    </td>
                    <td colspan="3">
                        <input id="txtTransport" type="text" value="<%=Transport%>" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        送货地址:
                    </td>
                    <td colspan="3">
                        <input id="txtDeliveryAddress" type="text" value="<%=DeliveryAddress%>" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        说明:
                    </td>
                    <td colspan="3">
                        <input id="txtDirections" type="text" value="<%=Directions%>" />
                    </td>
                </tr>
                <tr>
                    <td>
                        备注:
                    </td>
                    <td>
                        <input id="txtRemark" type="text" value="<%=remark%>" />
                    </td>
                </tr>
            </table>
        </div>
        <div data-options="region:'center'" style="background: #eee; overflow: hidden; overflow-x: hidden;">
            <toolbar:ToolBar runat="server" ID="toolbar1" />
            <table id="tt">
            </table>
        </div>
        <script type="text/javascript">
            var index;

            $('#tt').datagrid({
                title: '采购计划明细',
                url: '../Ashx/JXC_Detail.ashx',
                queryParams: { 'action': 'planDetail', 'id': "<%=PPID %>" },
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
                frozenColumns: [[

        { field: 'Item', title: '项次', width: 80, editor: "text" },
        { field: 'Odd', title: '单号', width: 80, editor: "text" },
       
        { field: 'ptCode', title: '商品编码', width: 80, editor: "text" },
        { field: 'ptName', title: '商品名称', width: 80, editor: "text" },
        { field: 'specifications', title: '规格型号', width: 80, editor: "text" },
        { field: 'pcCode', title: '颜色编码', width: 80, editor: "text" },
        { field: 'pcName', title: '颜色名称', width: 80, editor: "text" }
    ]],
                columns: [[
         { field: 'ptUnit', title: '单位', width: 130, editor: "text" },
        { field: 'PlanAmount', title: '计划采购量', width: 130, editor: "text" },
        { field: 'PurchasedAmount', title: '已采购量', width: 130, editor: "text" },
        { field: 'ExpectedPrice', title: '预计价格', width: 130, editor: "text" },
        { field: 'Discount', title: '折率', width: 130, editor: "text" },
        { field: 'PlansPurchaseDate', title: '计划采购日期', width: 130, editor: "datebox",
            formatter: function (value, rowData, rowIndex) {
                return (value.Format("yyyy-MM-dd"));
            } 
        },
        { field: 'PlansFactoryDate', title: '计划出厂日期', width: 130, editor: "datebox", formatter: function (value, rowData, rowIndex) { return (value.Format("yyyy-MM-dd")); } },
        { field: 'ExpectedArrivalDate', title: '预计到货日期', width: 130, editor: "datebox", formatter: function (value, rowData, rowIndex) { return (value.Format("yyyy-MM-dd")); } },
        { field: 'PlansSupplier', title: '计划供应商', width: 130, editor: "text" },
        { field: 'Supplier', title: '真实供应商', width: 130, editor: "text" },
        { field: 'ProductOdd', title: '指定采购产品订单号', width: 130, editor: "text" },
        { field: 'OrderItem', title: '订单项次', width: 130, editor: "text" },
        { field: 'state', title: '状态', width: 130, editor: "text" },
        { field: 'remark', title: '说明', width: 130, editor: "text" },
        { field: 'create_person', title: '创建人', width: 130 },
        { field: 'create_date', title: '创建时间', width: 130 },
        { field: 'update_person', title: '更新人', width: 130 },
        { field: 'update_date', title: '更新时间', width: 130 },
        { field: '11 ', title: '    ', width: 130 }


    ]],
                onClickRow: function (rowIndex, rowData) {

                    if (index != rowIndex) {
                        $('#tt').datagrid("endEdit", index);
                    }
                    $('#tt').datagrid("selectRow", rowIndex).datagrid("beginEdit", rowIndex);
                    index = rowIndex;

                }

            });

            function add() {
                endEdit();
                $('#tt').datagrid('insertRow', { index: 0, row: {} }).datagrid("beginEdit", 0);
            }

            function del() {
                var row = $('#tt').datagrid('getSelected');
                if (row == null) {
                    $.messager.show({ title: "warn", msg: "请选择要删除的行！" });

                }
                var rowIndex = $('#tt').datagrid('getRowIndex', row);
                // alert(rowIndex);
                $('#tt').datagrid('deleteRow', rowIndex);
            }

            function endEdit() {
                var row = $("#tt").datagrid("getRows");
                for (var i = 0; i < row.length; i++) {
                    $("#tt").datagrid("endEdit", i);
                }
            }

            function save() {
                endEdit();

                var addStr = "";
                var updateStr = "";
                var delSrt = "";

                var allRows = $("#tt").datagrid("getChanges", "inserted");
                addStr = JSON.stringify(allRows);
                var updateRows = $("#tt").datagrid("getChanges", "updated");
                updateStr = JSON.stringify(updateRows);
                var delRows = $("#tt").datagrid("getChanges", "deleted");
                delSrt = JSON.stringify(delRows);

                $.ajax({
                    type: "POST",
                    //timeout: 30000,
                    url: '../Ashx/JXC_Detail.ashx',
                    data: {
                        'action': 'save',
                        'addstr': addStr,
                        'updatestr': updateStr,
                        'delstr': delSrt
                    },
                    success: function (data) {
                        if (data == "success！") {
                            $.messager.show({ title: '提示', msg: '编辑成功！' });
                            $("#tt").datagrid('reload');

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

           
        </script>
    </div>
</asp:Content>
