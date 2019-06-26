<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="PurchasePlan.aspx.cs" Inherits="Maticsoft.Web.Purchase.PurchasePlan" %>
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
         var datagridURL = "/Ashx/Pruchase.ashx?action=PlanList";

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

//        function Verification() {
//            var rows = $('#tt').datagrid('getSelections');
//            var index;
//            for (var i = 0; i < rows.length; i++) {
//                if (rows[i].Submit == 0) {
//                    if (rows[i].ExpectedPrice.length <= 0) {
//                        $.messager.show({ title: '错误提示', msg: "预计价格不能为空" });
//                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
//                        EditRow(index);
//                        return false;
//                    }
//                    if (rows[i].Discount.length <= 0) {
//                        $.messager.show({ title: '错误提示', msg: "折率不能为空" });
//                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
//                        EditRow(index);
//                        return false;
//                    }
//                    if (rows[i].PlansPurchaseDate.length <= 0) {
//                        $.messager.show({ title: '错误提示', msg: "计划采购日期不能为空" });
//                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
//                        EditRow(index);
//                        return false;
//                    }
//                    if (rows[i].PlansFactoryDate.length <= 0) {
//                        $.messager.show({ title: '错误提示', msg: "计划出厂日期不能为空" });
//                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
//                        EditRow(index);
//                        return false;
//                    }
//                    if (rows[i].ExpectedArrivalDate.length <= 0) {
//                        $.messager.show({ title: '错误提示', msg: "预计到货日期不能为空" });
//                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
//                        EditRow(index);
//                        return false;
//                    }
//                    if (rows[i].spID.length <= 0) {
//                        $.messager.show({ title: '错误提示', msg: "计划供应商不能为空" });
//                        index = $('#tt').datagrid('getRowIndex', rows[i].ID);
//                        EditRow(index);
//                        return false;
//                    }
//                }
//            }
//        }

        function save() {
            GridSave("/Ashx/Pruchase.ashx", "PlanSave");
        }

        function EndEdit() {
            var rows = $("#tt").datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $("#tt").datagrid('endEdit', i);
            }
        }


        function Sumbit() {
           // EndEdit();
            //            var rows = $("#tt").datagrid("getSelected");
            //            var placeID = row.projectSpaceID;
            //            var sid = row.sid;
            //            //alert(placeID);

            //            $.ajax({
            //                type: 'post',
            //                url: '/Ashx/Pruchase.ashx',
            //                data: {
            //                    'action': 'PlanSubmit',
            //                    'placeID': placeID,
            //                    'sid': sid
            //                },
            //                success: function (res) {
            //                    $.messager.show({ title: '提示', msg: res });
            //                    $('#tt').datagrid("reload");
            //                }
            //            });

            var selected = "";
            //$($("#tt").datagrid("getSelections")).each(function () { selected += "'" + this.ID + "',"; });
            //selected = selected.substr(0, selected.length - 1);
            //if (selected == null || selected == "") {
            //    $.messager.show({ title: "系统提示", msg: "请选择您要“提交”的数据。" });
            //    return;
            // }

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
                $.post("/Ashx/Pruchase.ashx", { "action": "PlanSubmit", "selects": selected }, function (data) {
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
                    'action': 'PlanCancelSubmit',
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
    <option value="1">资料未完善</option>   
    <option value="2">未提交</option>   
    <option value="3">未审核</option> 
    <option value="4">不通过</option>  
    <option value="5">完成</option>     
</select>  


                </td>
            </tr>
        </table>
        <toolbar:ToolBar runat="server" ID="toolbar1" />
    </div>
</asp:Content>
