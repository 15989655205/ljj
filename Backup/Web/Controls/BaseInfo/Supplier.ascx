<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Supplier.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.Supplier" %>

<script type="text/javascript">
    var sumbitUrl = "";  
    var loadflag = true;
</script>

<script type="text/javascript">
    function openDialog(type, row, title) {
        if (loadflag) {
            $("#TypeID").combobox({
                url: "../Ashx/SupplierType.ashx?action=combobox"
                , valueField: "value"
                , textField: "text"
                , required: true
                , onSelect: function (data) {
                    ST_Code = data.text.substr(1, 2);
                    $("#ST_Code").val(ST_Code);
                    Code = $("#hdCode").val();
                    document.getElementById("lblCode").innerHTML = Code == "" ? ST_Code + "??" : Code.substr(0, 2) == ST_Code ? Code : ST_Code + "??";
                }
            });
            loadflag = false;
        }
        switch (type) {
            case "add": sumbitUrl = "../Ashx/Supplier.ashx?action=add"; ClearControl(); break;
            case "copy": sumbitUrl = "../Ashx/Supplier.ashx?action=add"; showData(row); break;
            case "edit": sumbitUrl = "../Ashx/Supplier.ashx?action=edit"; showData(row); break;
            case "view": showData(row); break;
            default: break;
        }
        if (art.dialog.list["dialog"] == null) {
            art.dialog({
                content: document.getElementById("detail"),
                id: "dialog",
                title: title,
                lock: type != "view",
                padding: "0px 0px 0px 0px",
                background: "#c3c3c3",
                init: function () { },
                //close: function () { ControlReadonly(false); },
                button: [
                    { name: "保存", callback: function () { save(); return false; }, focus: true },
                    { name: "关闭" }
                ]
            });
        }
        setValidate();
        ControlReadonly(type == "view");
        if (type == "edit" || type == "view") {
            document.getElementById("lblCode").innerHTML = row.Code;
            $("#hdCode").val(row.Code);
        }
        else {
            $("#hdCode").val("");
            document.getElementById("lblCode").innerHTML = type == "copy" ? row.ST_Code + "??" : "????";
        }
    }
</script>

<script type="text/javascript">
    function ClearControl() {
        $("#TypeID").combobox("setValue", "");
        $("#ST_Code").val("");
        $("#Abbreviation").val("");
        $("#FullName").val("");
        $("#EnAbbreviation").val("");
        $("#EnFullName").val("");
        $("#Address").val("");
        $("#EnAddress").val("");
        $("#Margin").val("");
        $("#TaxRate").val("");
        $("#TypeCode").val("");
        $("#ZipCode").val("");
        $("#Currency").val("");
        $("#PaymentTerms").val("");
        $("#Principal").val("");
        $("#Linkman").val("");
        $("#Buyer").val("");
        $("#PurchasingCycle").val("");
        $("#PurchasingCycleTable").val("");
        $("#PurchasingGoodsCycle").val("");
        $("#PaymentMethod").val("");
        $("#DepositBank").val("");
        $("#BankAccount").val("");
        $("#PSubject").val("");
        $("#TSubject").val("");
        $("#POSubject").val("");
        $("#TCProject").val("");
        $("#PCProject").val("");
        $("#Remark").val("");
        $("#LandTransportation").val("");
        $("#SeaTransportation").val("");
        $("#AirTransportation").val("");
        $("#OtherTransportation").val("");
    }
</script>

<script type="text/javascript">
    function showData(row) {
        $("#TypeID").combobox("setValue", row.TypeID);
        $("#hdID").val(row.ID);
        $("#ST_Code").val(row.ST_Code);
        $("#Abbreviation").val(row.Abbreviation);
        $("#FullName").val(row.FullName);
        $("#EnAbbreviation").val(row.EnAbbreviation);
        $("#EnFullName").val(row.EnFullName);
        $("#Address").val(row.Address);
        $("#EnAddress").val(row.EnAddress);
        $("#Margin").val(row.Margin);
        $("#TaxRate").val(row.TaxRate);
        $("#TypeCode").val(row.TypeCode);
        $("#ZipCode").val(row.ZipCode);
        $("#Currency").val(row.Currency);
        $("#PaymentTerms").val(row.PaymentTerms);
        $("#Principal").val(row.Principal);
        $("#Linkman").val(row.Linkman);
        $("#Buyer").val(row.Buyer);
        $("#PurchasingCycle").val(row.PurchasingCycle);
        $("#PurchasingCycleTable").val(row.PurchasingCycleTable);
        $("#PurchasingGoodsCycle").val(row.PurchasingGoodsCycle);
        $("#PaymentMethod").val(row.PaymentMethod);
        $("#DepositBank").val(row.DepositBank);
        $("#BankAccount").val(row.BankAccount);
        $("#PSubject").val(row.PSubject);
        $("#TSubject").val(row.TSubject);
        $("#POSubject").val(row.POSubject);
        $("#TCProject").val(row.TCProject);
        $("#PCProject").val(row.PCProject);
        $("#Remark").val(row.Remark);
        $("#LandTransportation").val(row.LandTransportation);
        $("#SeaTransportation").val(row.SeaTransportation);
        $("#AirTransportation").val(row.AirTransportation);
        $("#OtherTransportation").val(row.OtherTransportation);
    }
</script>

<script type="text/javascript">
    function ControlReadonly(flag) {
        document.getElementById("Abbreviation").readOnly =
        document.getElementById("FullName").readOnly =
        document.getElementById("EnAbbreviation").readOnly =
        document.getElementById("EnFullName").readOnly =
        document.getElementById("Address").readOnly =
        document.getElementById("EnAddress").readOnly =
        document.getElementById("Margin").readOnly =
        document.getElementById("TaxRate").readOnly =
        document.getElementById("TypeCode").readOnly =
        document.getElementById("ZipCode").readOnly =
        document.getElementById("Currency").readOnly =
        document.getElementById("PaymentTerms").readOnly =
        document.getElementById("Principal").readOnly =
        document.getElementById("Linkman").readOnly =
        document.getElementById("Buyer").readOnly =
        document.getElementById("PurchasingCycle").readOnly =
        document.getElementById("PurchasingCycleTable").readOnly =
        document.getElementById("PurchasingGoodsCycle").readOnly =
        document.getElementById("PaymentMethod").readOnly =
        document.getElementById("DepositBank").readOnly =
        document.getElementById("BankAccount").readOnly =
        document.getElementById("PSubject").readOnly =
        document.getElementById("TSubject").readOnly =
        document.getElementById("POSubject").readOnly =
        document.getElementById("TCProject").readOnly =
        document.getElementById("LandTransportation").readOnly =
        document.getElementById("SeaTransportation").readOnly =
        document.getElementById("AirTransportation").readOnly =
        document.getElementById("OtherTransportation").readOnly =
        document.getElementById("Remark").readOnly = flag;
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
    }
</script>

<!--表单数据合法验证-->
<script type="text/javascript">
    function setValidate() {      
        $('#Abbreviation').validatebox({ required: true });
        $('#FullName').validatebox({ required: true });
    }    
</script>

<script type="text/javascript">
    function ButtonLock(flag) {
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag }, { name: "关闭", disabled: flag });
    }
    function save() {
        ButtonLock(true);
        if (!$("#ff").form("validate")) {
            $.messager.show({ title: "提示", msg: "验证未通过。" });
            ButtonLock(false);
            return;
        }
        $("#ff").form("submit", {
            url: sumbitUrl,
            //onSubmit: function () { /*做某些检查,返回 false 来阻止提交*/ },
            success: function (data) {
                if (data == "ok") {
                    $("#tt").datagrid("reload");
                    $.messager.show({ title: "系统提示", msg: "保存成功。" });
                    art.dialog.list["dialog"].close();
                }
                else {
                    $.messager.show({ title: "系统提示", msg:  data });
                    ButtonLock(false);
                }
            }
        });
    }
</script>

<style type="text/css">
    .txt{width:300px;}
</style>

<form action="" id="ff" method="post">
    <input type="hidden" id="hdID" name="hdID"/>
    <input type="hidden" id="hdCode" name="hdCode"/>
    <input type="hidden" id="ST_Code" name="ST_Code"/>
    <table class="table">
        <tr>
            <td class="titleTD">编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
            <td class="inputTD"><label id="lblCode"/></td>        
            <td class="titleTD">类&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：</td>
            <td class="inputTD"><input type="text" id="TypeID" name="TypeID" class="oaInput"/></td>
            <td class="titleTD" colspan="2"><input type="checkbox" id="Enabled" name="Enabled"/><label for="Enabled">停用</label></td>
            <%--<td class="inputTD" ></td>--%>
        </tr>
        <tr>               
            <td class="titleTD">简&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;称：</td>
            <td class="inputTD"><input type="text" id="Abbreviation" name="Abbreviation" class="oaInput"/></td>
            <td class="titleTD">全&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;称：</td>
            <td class="inputTD"><input type="text" id="FullName" name="FullName" class="oaInput"/></td>
            <td class="titleTD">地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址：</td>
            <td class="inputTD"><input type="text" id="Address" name="Address" class="oaInput"/></td>
        </tr>
        <tr>
            <td class="titleTD">英文简称：</td>
            <td class="inputTD"><input type="text" id="EnAbbreviation" name="EnAbbreviation" class="oaInput"/></td>        
            <td class="titleTD">英&nbsp;&nbsp;文&nbsp;&nbsp;&nbsp;&nbsp;全&nbsp;&nbsp;称：</td>
            <td class="inputTD"><input type="text" id="EnFullName" name="EnFullName" class="oaInput"/></td>
            <td class="titleTD">英&nbsp;&nbsp;文&nbsp;&nbsp;&nbsp;&nbsp;地&nbsp;&nbsp;址：</td>
            <td class="inputTD"><input type="text" id="EnAddress" name="EnAddress" class="oaInput"/></td>   
            
        </tr>
        <tr>
            <td class="titleTD">开户银行：</td>
            <td class="inputTD"><input type="text" id="DepositBank" name="DepositBank" class="oaInput"/></td>        
            <td class="titleTD">银&nbsp;&nbsp;行&nbsp;&nbsp;&nbsp;&nbsp;账&nbsp;&nbsp;号：</td>
            <td class="inputTD"><input type="text" id="BankAccount" name="BankAccount" class="oaInput"/></td>
            <td class="titleTD">邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;编：</td>
            <td class="inputTD"><input type="text" id="ZipCode" name="ZipCode" class="oaInput"/></td>
        </tr>        
        <tr>
            <td class="titleTD">货&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;币：</td>
            <td class="inputTD"><input type="text" id="Currency" name="Currency" class="oaInput"/></td>
            <td class="titleTD">保&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;证&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;金：</td>
            <td class="inputTD"><input type="text" id="Margin" name="Margin" class="oaInput"/></td>
            <td class="titleTD">税&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;率：</td>
            <td class="inputTD"><input type="text" id="TaxRate" name="TaxRate" class="oaInput"/></td>
        </tr>
        <tr>
            <td class="titleTD">分类编码：</td>
            <td class="inputTD"><input type="text" id="TypeCode" name="TypeCode" class="oaInput"/></td>
            <td class="titleTD">付&nbsp;&nbsp;款&nbsp;&nbsp;&nbsp;&nbsp;条&nbsp;&nbsp;件：</td>
            <td class="inputTD"><input type="text" id="PaymentTerms" name="PaymentTerms" class="oaInput"/></td>
            <td class="titleTD">结&nbsp;&nbsp;算&nbsp;&nbsp;&nbsp;&nbsp;方&nbsp;&nbsp;式：</td>
            <td class="inputTD"><input type="text" id="PaymentMethod" name="PaymentMethod" class="oaInput"/></td>            
        </tr>
        <tr>
            <td class="titleTD">负&nbsp;&nbsp;责&nbsp;&nbsp;人：</td>
            <td class="inputTD"><input type="text" id="Principal" name="Principal" class="oaInput"/></td>
            <td class="titleTD">联&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;系&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;人：</td>
            <td class="inputTD"><input type="text" id="Linkman" name="Linkman" class="oaInput"/></td>
            <td class="titleTD">采&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;购&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;员：</td>
            <td class="inputTD"><input type="text" id="Buyer" name="Buyer" class="oaInput"/></td> 
        </tr>
        <tr>                   
            <td class="titleTD">采购周期：</td>
            <td class="inputTD"><input type="text" id="PurchasingCycle" name="PurchasingCycle" class="oaInput"/></td>
            <td class="titleTD">周&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;期&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;表：</td>
            <td class="inputTD"><input type="text" id="PurchasingCycleTable" name="PurchasingCycleTable" class="oaInput"/></td>
            <td class="titleTD">到&nbsp;&nbsp;货&nbsp;&nbsp;&nbsp;&nbsp;周&nbsp;&nbsp;期：</td>
            <td class="inputTD"><input type="text" id="PurchasingGoodsCycle" name="PurchasingGoodsCycle" class="oaInput"/></td> 
        </tr>
        <tr>
            <td class="titleTD" rowspan="3">到货差异：<br/>(单位：天)</td>
            <td class="inputTD" rowspan="3">
                陆运<input type="text" id="LandTransportation" name="LandTransportation" class="oaInput" style="width:30px"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                海运<input type="text" id="SeaTransportation" name="SeaTransportation" class="oaInput" style="width:30px"/>
                <br/><br/>
                空运<input type="text" id="AirTransportation" name="AirTransportation" class="oaInput" style="width:30px"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                其他<input type="text" id="OtherTransportation" name="OtherTransportation" class="oaInput" style="width:30px"/>
            </td>
            <td class="titleTD">预&nbsp;&nbsp;付&nbsp;&nbsp;&nbsp;&nbsp;科&nbsp;&nbsp;目：</td>
            <td class="inputTD"><input type="text" id="PSubject" name="PSubject" class="oaInput"/></td>
            <td class="titleTD">预付现金项目：</td>
            <td class="inputTD"><input type="text" id="PCProject" name="PCProject" class="oaInput"/></td>
        </tr>
        <tr>           
            <td class="titleTD">应&nbsp;&nbsp;付&nbsp;&nbsp;&nbsp;&nbsp;科&nbsp;&nbsp;目：</td>
            <td class="inputTD"><input type="text" id="TSubject" name="TSubject" class="oaInput"/></td>
            <td class="titleTD">应付现金项目：</td>
            <td class="inputTD"><input type="text" id="TCProject" name="TCProject" class="oaInput"/></td>            
        </tr>
        <tr>
            <td class="titleTD">预付对方科目：</td>
            <td class="inputTD"><input type="text" id="POSubject" name="POSubject" class="oaInput"/></td>
            <td class="titleTD" colspan="2"></td>                  
        </tr>        
        <tr>
            <td class="titleTD">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="inputTD" colspan="5">
                <div style="margin-right:6px">
                    <textarea id="Remark" name="Remark" rows="3" cols="" class="textarea" style="width:100%"></textarea>
                </div>
            </td>            
        </tr>
	</table>
</form>