<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Client.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.Client" %>

<script type="text/javascript">
    var sumbitUrl = "";
    var loadflag = true;
</script>

<script type="text/javascript">
    function openDialog(type, row, title) {
        if (loadflag) {
            $("#ReconciliationDate").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
            $("#SetupDate").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
            $("#BeginDate").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
            $("#EndDate").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
            $("#CLevel").combobox({
                url: "../Ashx/ClientLevel.ashx?action=cb"
                , valueField: "value"
                , textField: "text"
                , required: true
            });
            $("#Type").combobox({
                url: "../Ashx/BaseDictionaryDetail.ashx?type=ctype"
                , valueField: "value"
                , textField: "text"
                , required: true
            });
            loadflag = false;
        }
        switch (type) {
            case "add": sumbitUrl = "../Ashx/Client.ashx?action=add"; ClearControl(); break;
            case "copy": sumbitUrl = "../Ashx/Client.ashx?action=add"; showData(row, type); break;
            case "edit": sumbitUrl = "../Ashx/Client.ashx?action=update"; showData(row, type); break;
            case "view": showData(row, type); break;
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
                close: function () { },
                button: [
                    { name: "保存", callback: function () { save(); return false; }, focus: true },
                    { name: "关闭" }
                ]
            });
        }
        setValidate();
        ControlReadonly(type == "view");
    }
</script>

<script type="text/javascript">
    function ClearControl() {
        //document.getElementById("lblCode").innerHTML = "???";
        $("#Code").val("");
        $("#Name").val("");
        $("#Area").val("");
        $("#Head").val("");
        $("#Phone").val("");
        $("#Tel").val("");
        $("#Fax").val("");
        $("#Email").val("");
        $("#Address").val("");
        $("#Currency").val("");
        $("#Parities").val("");
        $("#BusinessLicense").val("");
        $("#Industry").val("");
        $("#Remark").val("");
        document.getElementById("Supplier0").checked = true;
        $("#CLevel").combobox("setValue", "");
        $("#Type").combobox("setValue", "");
        $("#SetupDate").datebox("setValue", "");
        $("#ReconciliationDate").datebox("setValue", "");
        $("#BeginDate").datebox("setValue", "");
        $("#EndDate").datebox("setValue", "");
    }
</script>

<script type="text/javascript">
    function showData(row, type) {
        $("#ID").val(row.ID);
        //document.getElementById("lblCode").innerHTML = type == "copy" ? "???" : row.Code;
        $("#Code").val(row.Code);
        $("#Name").val(row.Name);
        $("#Area").val(row.Area);
        $("#Head").val(row.Head);
        $("#Phone").val(row.Phone);
        $("#Tel").val(row.Tel);
        $("#Fax").val(row.Fax);
        $("#Email").val(row.Email);
        $("#Address").val(row.Address);
        $("#Currency").val(row.Currency);
        $("#Parities").val(row.Parities);
        $("#BusinessLicense").val(row.BusinessLicense);
        $("#Industry").val(row.Industry);
        $("#Remark").val(row.Remark);
        document.getElementById("Supplier0").checked = row.Supplier == "0";
        document.getElementById("Supplier1").checked = row.Supplier == "1";
        $("#CLevel").combobox("setValue", row.CLevel);
        $("#Type").combobox("setValue", row.Type);
        $("#SetupDate").datebox("setValue", row.SetupDate);
        $("#ReconciliationDate").datebox("setValue", row.ReconciliationDate);
        $("#BeginDate").datebox("setValue", row.BeginDate);
        $("#EndDate").datebox("setValue", row.EndDate);
    }
</script>

<script type="text/javascript">
    function ControlReadonly(flag) {
        document.getElementById("Code").readOnly =
        document.getElementById("Name").readOnly =
        //document.getElementById("CLevel").readOnly =
        //document.getElementById("Type").readOnly =
        document.getElementById("Area").readOnly =
        document.getElementById("Head").readOnly =
        document.getElementById("Phone").readOnly =
        document.getElementById("Tel").readOnly =
        document.getElementById("Fax").readOnly =
        document.getElementById("Email").readOnly =
        document.getElementById("Address").readOnly =
        document.getElementById("Currency").readOnly =
        document.getElementById("Parities").readOnly =
        document.getElementById("BusinessLicense").readOnly =      
        document.getElementById("Supplier0").disabled =
        document.getElementById("Supplier1").disabled =      
        document.getElementById("Industry").readOnly =
        document.getElementById("Remark").readOnly = flag;
        var able = flag ? "disable" : "enable";
        $("#BeginDate").datebox(able);
        $("#EndDate").datebox(able);
        $("#ReconciliationDate").datebox(able);
        $("#SetupDate").datebox(able);
        $("#CLevel").combobox(able);
        $("#Type").combobox(able);        
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
    }
</script>
    
<!--表单数据合法验证-->
<script type="text/javascript">
    function setValidate() {
        //$("#Name").validatebox({ required: true });
        $("#Parities").validatebox({ validType: "Parities" });
    }
    $.extend($.fn.validatebox.defaults.rules, {
        Parities: {
            message: "*不是有效的汇率"
            , validator: function (value) {
                var re = /^([1-9][0-9]*.[0-9]*)|([0].[0-9]*[1-9])$/;
                return re.test(value)
            }
        }
    });
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
                    $.messager.show({ title: "提示", msg: "保存成功。" });
                    art.dialog.list["dialog"].close();
                }
                else {
                    $.messager.show({ title: "提示", msg: data });
                    ButtonLock(false);
                }
            }
        });
    }
</script>

<form action="" id="ff" method="post">
    <input type="hidden" id="ID" name="ID"/>
    <%--<input type="hidden" id="Code" name="Code"/>--%>
    <table class="table">
        <tr>
            <td class="titleTD">编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
            <td class="inputTD"><%--<label id="lblCode"></label>--%><input type="text" id="Code" name="Code" class=""/></td>
            <td class="titleTD">名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;称：</td>
            <td class="inputTD"><input type="text" id="Name" name="Name" class=""/></td>
            <td class="titleTD">级&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：</td>
            <td class="inputTD"><input type="text" id="CLevel" name="CLevel" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">类&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：</td>
            <td class="inputTD"><input type="text" id="Type" name="Type" class=""/></td>
            <td class="titleTD">区&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;域：</td>
            <td class="inputTD"><input type="text" id="Area" name="Area" class=""/></td> 
            <td class="titleTD">负&nbsp;&nbsp;&nbsp;&nbsp;责&nbsp;&nbsp;&nbsp;&nbsp;人：</td>
            <td class="inputTD"><input type="text" id="Head" name="Head" class=""/></td>          
        </tr>
         <tr>
            <td class="titleTD">手&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;机：</td>
            <td class="inputTD"><input type="text" id="Phone" name="Phone" class=""/></td>
            <td class="titleTD">电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话：</td>
            <td class="inputTD"><input type="text" id="Tel" name="Tel" class=""/></td> 
            <td class="titleTD">传&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;真：</td>
            <td class="inputTD"><input type="text" id="Fax" name="Fax" class=""/></td>          
        </tr>
         <tr>
            <td class="titleTD">邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;件：</td>
            <td class="inputTD"><input type="text" id="Email" name="Email" class=""/></td>
            <td class="titleTD">地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址：</td>
            <td class="inputTD"><input type="text" id="Address" name="Address" class=""/></td>
            <td class="titleTD">行&nbsp;业&nbsp;&nbsp;分&nbsp;类：</td>
            <td class="inputTD"><input type="text" id="Industry" name="Industry" class=""/></td>    
        </tr>
         <tr>
            <td class="titleTD">币&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;种：</td>
            <td class="inputTD"><input type="text" id="Currency" name="Currency" class=""/></td>
            <td class="titleTD">汇&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;率：</td>
            <td class="inputTD"><input type="text" id="Parities" name="Parities" class=""/></td> 
            <td class="titleTD">营&nbsp;业&nbsp;&nbsp;执&nbsp;照：</td>
            <td class="inputTD"><input type="text" id="BusinessLicense" name="BusinessLicense" class=""/></td>          
        </tr>
         <tr>
            <td class="titleTD">对&nbsp;&nbsp;账&nbsp;&nbsp;&nbsp;&nbsp;日&nbsp;&nbsp;期：</td>
            <td class="inputTD"><input type="text" id="ReconciliationDate" name="ReconciliationDate" class=""/></td>
            <td class="titleTD">成&nbsp;&nbsp;立&nbsp;&nbsp;&nbsp;&nbsp;日&nbsp;&nbsp;期：</td>
            <td class="inputTD"><input type="text" id="SetupDate" name="SetupDate" class=""/></td> 
            <td class="titleTD">是否供应商：</td>
            <td class="inputTD">
                <input type="radio" id="Supplier1" name="Supplier" value="1"/><label for="Supplier1">是</label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="radio" id="Supplier0" name="Supplier" value="1"/><label for="Supplier0">否</label>
            </td>
        </tr>
         <tr>
            <td class="titleTD">开始来往日期：</td>
            <td class="inputTD"><input type="text" id="BeginDate" name="BeginDate" class=""/></td>
            <td class="titleTD">停止来往日期：</td>
            <td class="inputTD"><input type="text" id="EndDate" name="EndDate" class=""/></td> 
            <td class="inputTD" colspan="2"></td>
        </tr>         
        <tr>
            <td class="titleTD">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="inputTD" colspan="5"><textarea id="Remark" name="Remark" rows="4" cols="" style="width:655px" class=""></textarea></td>
        </tr>
	</table>
</form>