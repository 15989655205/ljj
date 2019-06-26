<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderItem.aspx.cs" Inherits="Maticsoft.Web.Purchase.PurchaseOrderItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
input[type=text]
{
    border:0;width: 130px; border-bottom: 1px solid #C0D9D9;  background-color: transparent; 
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="cc" class="easyui-layout" fit="true" border="false" style="overflow-y: hidden"  scroll="no">

<div region="north" title="" border="false" split="false">
        <table id="PrintHide" style="width: 100%; position:absolute; background-color:White;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img alt="" src="../images/BanKuaiJianTou.gif" />
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                <%switch (type)
                  {
                      case "audit":
                   %>
                  <a id="btn" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-ok'" onclick="sh()">通过</a>
                  <a id="A1" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'" onclick="shnp()">不通过</a>
                <%break;
                      case "edit": %>
                    <a href="#" id="submit" class="easyui-linkbutton" plain="true" onclick="save()" iconCls="icon-save">保存</a>
                    &nbsp;&nbsp;
                <%break;
                      default:
                  break;
                  }%>
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2" style="background-color: #ffffff">
                </td>
            </tr>
        </table>
<div style="height:35px;"></div>

<form id="ff" action="" class="" method="post">
<input type="hidden" id="hsid" name="hsid" value="" />
<input type="hidden" id="haction" name="haction" value="" />
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" colspan="6" style="height: 25px; background-color: #e1f5fc; text-align: center">
                    <strong>采购订货单</strong>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 200px; background-color: #e1f5fc; height: 25px;">
                    单号：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="Code" name="Code" value="<%=Code %>" style="width:80%" />
                </td>
                 <td align="right" style="width: 200px; background-color: #e1f5fc; height: 25px;">
                    
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                
                </td>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    日期：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="create_date" name="create_date" value="<%=create_date %>" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" style="width:80%"/>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    厂家：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="Supplier" name="Supplier" value="<%=SupplierName %>" style="width:80%"/>
                </td>
                 <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    采购员：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="Buyer" name="Buyer" value="<%=Buyer %>" style="width:80%"/>
                </td>
                 <td align="right" style="background-color: #e1f5fc; height: 25px;">
                    厂家经手人：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="SupplierName" name="SupplierName" value="<%=LinkMan %>" style="width:80%"/>
                </td>
            </tr>
            <tr>
               <td align="right"  style=" background-color: #e1f5fc; height: 25px;">
                    帐务归属：
               </td>
               <td colspan="1" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
               <input id="Accounts" name="Accounts" type="text" style="width:80%" value="<%=Principal %>"/>
               </td>
                <td align="right" style="background-color: #e1f5fc; height: 25px;">
                    厂家电话：
                </td>
                <td colspan="1" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input id="Mobile" name="Mobile" type="text" style="width:80%" value="<%=Mobile %>"/>
                </td>
                <td align="right" style="background-color: #e1f5fc; height: 25px;">
                    送货日期：
                </td>
                <td colspan="1" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="DeliveryDate" name="DeliveryDate" value="<%=DeliveryDate %>" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" style="width:80%"/>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    货币：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="Currency" name="Currency" value="<%=Currency %>" style="width:80%"/>
                </td>
                 <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    汇率：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="ExchangeRate" name="ExchangeRate" value="<%=ExchangeRate %>" style="width:80%"/>
                </td>
                 <td align="right" style="background-color: #e1f5fc; height: 25px;">
                    降价：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="PriceReduction" name="PriceReduction" value="<%=PriceReduction %>" style="width:80%"/>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    付款条件：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="PayTerm" name="PayTerm" value="<%=PayTerm %>" style="width:80%"/>
                </td>
                 <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    折率：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="DiscountRate" name="DiscountRate" value="<%=DiscountRate %>" style="width:80%"/>
                </td>
                 <td align="right" style="background-color: #e1f5fc; height: 25px;">
                    订金：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="Deposit" name="Deposit" value="<%=Deposit %>" style="width:80%"/>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    结算方式：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="AccountsMode" name="AccountsMode" value="<%=AccountsMode %>" style="width:80%"/>
                </td>
                 <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    税率：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="TaxRate" name="TaxRate" value="<%=TaxRate %>" style="width:80%"/>
                </td>
                 <td align="right" style="background-color: #e1f5fc; height: 25px;">
                    运杂费：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="OtherFees" name="OtherFees" value="<%=OtherFees %>" style="width:80%"/>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    计划出厂日期：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="PlansFactoryDate" name="PlansFactoryDate" value="<%=PlansFactoryDate %>" style="width:80%"/>
                </td>
                 <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    实际出厂日期：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="FactoryDate" name="FactoryDate" value="<%=FactoryDate %>" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"  class="Wdate" style="width:80%"/>
                </td>
                 <td align="right" style="background-color: #e1f5fc; height: 25px;">
                    合计：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="sum" name="sum" value="<%=total %>" style="width:80%"/>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    运输方法：
                </td>
                <td colspan="5" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="Transport" name="Transport" value="<%=Transport %>" style="width:80%"/>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    送货地址：
                </td>
                <td colspan="5" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="DeliveryAddress" name="DeliveryAddress" value="<%=DeliveryAddress %>" style="width:80%"/>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    备注：
                </td>
                <td colspan="5" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="remark" name="remark" value="<%=remark %>" style="width:80%"/>
                </td>
            </tr>
   <%--    阶段信息--%>
            <tr>
                <td align="right" colspan="6" style="height: 25px; background-color: #e1f5fc; text-align: center;">
                    <strong>订货单细目</strong>
                </td>
            </tr>
       </table>
       </form>
     </div> 
     <div region="center" title="" border="false">  
                <table id="t">
            </table>
       </div>
       <div>

       </div>
 </div>
    <script type="text/javascript">
        $(function () {
            var type = '<%=type %>';
            if (type == "view") {
                $("#submit").css("display", "none");
                $("#Deposit").attr("readonly", true);
                $("#OtherFees").attr("readonly", true);
                $("#Transport").attr("readonly", true);
                $("#DeliveryAddress").attr("readonly", true);
                $("#remark").attr("readonly", true);
            }
            $("#Code").attr("readonly", true);
            $("#Supplier").attr("readonly", true);
            $("#Accounts").attr("readonly", true);
            $("#Currency").attr("readonly", true);
            $("#PayTerm").attr("readonly", true);
            $("#AccountsMode").attr("readonly", true);
            $("#PlansFactoryDate").attr("readonly", true);
            $("#Buyer").attr("readonly", true);
            $("#Mobile").attr("readonly", true);
            $("#ExchangeRate").attr("readonly", true);
            $("#DiscountRate").attr("readonly", true);
            $("#TaxRate").attr("readonly", true);
            $("#PriceReduction").attr("readonly", true);
            $("#create_date").attr("readonly", true);
            $("#SupplierName").attr("readonly", true);
            $("#DeliveryDate").attr("readonly", true);
            $("#sum").attr("readonly", true);

            var editIndex = undefined;
            $("#t").datagrid({
                url: "/Ashx/Pruchase.ashx"
                , queryParams: { "action": "PruchaseOrderItemList", "PID": '<%=sid %>' }
                , loadMsg: "正在努力加载中..."
                //, toolbar: '#tb'
                , pageSize: 20
                , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
                , pagination: true
                , rownumbers: true
                , singleSelect: true
                , frozenColumns: [[
                     { title: "商品编码", field: "productCode", width: 120 },
                    { title: "商品名称", field: "productName", width: 120 }
    
                ]],
                columns: [[

                                { title: "规格型号", field: "Manufacturer", width: 120 },
                    { title: "颜色编码", field: "pcCode", width: 120 },
                    { title: "颜色名称", field: "pcName", width: 120 },
                    { title: "仓库", field: "remark1", width: 120 },
                    { title: "数量", field: "Amount", width: 120 },
                    { title: "不含税单价", field: "PriceExcl", width: 120, editor: "text" },
                    { title: "含税单价", field: "TaxPrice", width: 120, editor: "text" },
                    { title: "折率", field: "DiscountRate", width: 120, editor: "text" },
                    { title: "折前金额", field: "BeforeDiscountPrice", width: 120 },
                    { title: "不含税金额", field: "NoTaxPrice", width: 120 },
                    { title: "含税金额", field: "TaxAllPrice", width: 120 },
                    { title: "说明", field: "remark", width: 120, editor: "text" },
                    { title: "供应商产品编码", field: "SupplierProductCode", width: 120, editor: "text" },
                    { title: "订购产品说明", field: "OrderingProductDescription", width: 120, editor: "text" },
                    { title: "已进货量", field: "ReceivedAmount", width: 120 },
                    { title: "采购计划单", field: "Odd", width: 120 },
                    { title: "采购计划项次", field: "remark", width: 120 },
                    { title: "客户订单号", field: "remark", width: 120 },
                    { title: "客户订单项次", field: "remark", width: 120 },
                    { title: "包装数量", field: "remark", width: 120 },
                    { title: "已进货号", field: "remark", width: 120 }
                    ]]
                     , onClickRow: function (rowIndex, rowData) {
                         if (type != "view") {
                             if (rowIndex != editIndex) {
                                 End(editIndex);
                             }
                             $('#t').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
                             editIndex = rowIndex;
                         }
                     }
            });
        });

        function End(index) {
            $("#t").datagrid('endEdit', index);
        }

        function EndEdit() {
            var rows = $("#t").datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $("#t").datagrid('endEdit', i);
            }
        }

        //        function SaveOrderItem() {
        //            $.ajax({
        //                url: '/Ashx/Pruchase.ashx?action=',
        //                type: "post",
        //                data:{
        //  
        //                },
        //                success: function (res) { 
        //                    
        //                }
        //            });
        //        }

        //审核
        function sh() {
            $.ajax({
                type: 'post',
                url: '/Ashx/Pruchase.ashx',
                data: {
                    'action': 'OrderSH',
                    'id': '<%=sid %>'
                },
                success: function (res) {
                    if (res == 'success') {
                        var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
                        parent.Tab_OC("采购订货单审批", title, "Purchase/PurchaseOrderAudit.aspx", "", true);
                    } else {
                        $.messager.show({ title: '提示', msg: res });
                    }
                    //$('#tt').datagrid("reload");

                }
            });
        }


        //审核不通过
        function shnp() {
            $.ajax({
                type: 'post',
                url: '/Ashx/Pruchase.ashx',
                data: {
                    'action': 'OrderSHNP',
                    'id': '<%=sid %>'
                },
                success: function (res) {
                    if (res == 'success') {
                        var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
                        parent.Tab_OC("采购订货单审批", title, "Purchase/PurchaseOrderAudit.aspx", "", true);
                    } else {
                        $.messager.show({ title: '提示', msg: res });
                    }
                }
            });

        }

        function save() {
            EndEdit();
            // alert(allRows.length);
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allstr = "";

            var allRows = $('#t').datagrid('getRows');
            allstr = JSON.stringify(allRows);
            // alert(allstr.length);
            var delRows = $('#t').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delRows);
            //alert(delstr);
            var updateRows = $('#t').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updateRows);
            //alert(updatestr);
            var addRows = $('#t').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addRows);
            //alert(updatestr);
            $.ajax({
                type: "POST",
                //timeout: 30000,
                url: '../Ashx/Pruchase.ashx',
                data: {
                    'action': 'Save',
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr,
                    'sid': '<%=sid %>',
                    "Deposit": $("#Deposit").val(),
                    "OtherFees": $("#OtherFees").val(),
                    "Transport": $("#Transport").val(),
                    "DeliveryAddress": $("#DeliveryAddress").val(),
                    "remark": $("#remark").val(),
                    "FactoryDate": $("#FactoryDate").val()
                },
                success: function (data) {
                    if (data == "success") {
                        $("#t").datagrid('reload');


                        location.reload();
                        //                        $.messager.show({ title: '提示', msg: '编辑成功！' });
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
</asp:Content>
