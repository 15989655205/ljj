<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyInformation.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.CompanyInformation" %>

<!--控件加载事件-->
<script type="text/javascript">
    var sumbitUrl = "";
    var Number = "";
</script>

<!--控件弹出事件-->
<script type="text/javascript">
    function openDialog(type, row, title) {
        switch (type) {
            case "add": sumbitUrl = "../Ashx/Company.ashx?action=add"; ClearControl(); break;
            case "copy": sumbitUrl = "../Ashx/Company.ashx?action=add"; showData(row, type); break;
            case "edit": sumbitUrl = "../Ashx/Company.ashx?action=update"; showData(row, type); break;
            case "view": showData(row); break;
            default: break;
        }
        if (art.dialog.list["dialog"] == null) {
            art.dialog({
                content: document.getElementById("detail"),
                id: "dialog",
                title: title,
                padding: "0px 0px 0px 0px",
                background: "#c3c3c3",
                lock: type != "view",
                //init: function () { },
                //close: function () { },
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

<!--清空表单-->
<script type="text/javascript">
    function ClearControl() {
        Number = "";
        $("#txtNumber").val("");
        $("#txtHead").val("");
        $("#txtAbbreviation").val("");
        $("#txtFullName").val("");
        $("#txtEnAbbreviation").val("");
        $("#txtEnFullName").val("");
        $("#txtAddress").val("");
        $("#txtEnAddress").val("");
        $("#txtFixedPhone").val("");
        $("#txtMobilePhone").val("");
        $("#txtFax").val("");
        $("#txtZipCode").val("");
        $("#txtOpeningBank").val("");
        $("#txtAccount").val("");
        $("#txtCustomsCode").val("");
        $("#txtLegalRepresentative").val("");
        $("#txtRemark").val("");
    }
</script>

<!--复制、编辑、查看表单赋值-->
<script type="text/javascript">
    function showData(row, type) {
        $("#hdID").val(row.ID);
        $("#txtNumber").val(Number = type == "copy" ? "" : row.Number);
        $("#txtHead").val(row.Head);
        $("#txtAbbreviation").val(row.Abbreviation);
        $("#txtFullName").val(row.FullName);
        $("#txtEnAbbreviation").val(row.EnAbbreviation);
        $("#txtEnFullName").val(row.EnFullName);
        $("#txtAddress").val(row.Address);
        $("#txtEnAddress").val(row.EnAddress);
        $("#txtFixedPhone").val(row.FixedPhone);
        $("#txtMobilePhone").val(row.MobilePhone);
        $("#txtFax").val(row.txtFax);
        $("#txtZipCode").val(row.ZipCode);
        $("#txtOpeningBank").val(row.OpeningBank);
        $("#txtAccount").val(row.Account);
        $("#txtCustomsCode").val(row.CustomsCode);
        $("#txtLegalRepresentative").val(row.LegalRepresentative);
        $("#txtRemark").val(row.Remark);
    }
</script>

<!--表单是否只读-->
<script type="text/javascript">
    function ControlReadonly(flag) {
        document.getElementById("txtNumber").readOnly =
        document.getElementById("txtHead").readOnly =
        document.getElementById("txtAbbreviation").readOnly =
        document.getElementById("txtFullName").readOnly =
        document.getElementById("txtEnAbbreviation").readOnly =
        document.getElementById("txtEnFullName").readOnly =
        document.getElementById("txtAddress").readOnly =
        document.getElementById("txtEnAddress").readOnly =
        document.getElementById("txtFixedPhone").readOnly =
        document.getElementById("txtMobilePhone").readOnly =
        document.getElementById("txtFax").readOnly =
        document.getElementById("txtZipCode").readOnly =
        document.getElementById("txtOpeningBank").readOnly =
        document.getElementById("txtAccount").readOnly =
        document.getElementById("txtCustomsCode").readOnly =
        document.getElementById("txtLegalRepresentative").readOnly =
        document.getElementById("txtRemark").readOnly = flag;
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
    }
</script>

<!--表单数据合法验证-->
<script type="text/javascript">
    function setValidate() {
        $('#txtNumber').validatebox({ required: true, validType: "Number" });
        $('#txtHead').validatebox({ required: true });
        $('#txtAbbreviation').validatebox({ required: true });
        $('#txtFullName').validatebox({ required: true });
    }
    $.extend($.fn.validatebox.defaults.rules, {
        Number: {
            message: "*公司编号已存在"
            , validator: function (value) {
                var flag = true;
                if (value != "" && value != Number) {
                    $.ajax({
                        type: "POST"
                        , timeout: 6000
                        , async: false
                        , url: "../Ashx/Company.ashx"
                        , data: { "action": "Number", "value": value }
                        , success: function (data) { flag = data == ""; }
                    });
                }
                return flag;
            }
        }
    });
</script>

<!--保存按钮事件-->
<script type="text/javascript">
    //启用、禁用按钮
    function ButtonLock(flag) { art.dialog.list["dialog"].button({ name: "保存", disabled: flag }, { name: "关闭", disabled: flag }); }

    //保存
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
                if (data == "success") {
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

<!--html-->
<form action="" id="ff" method="post">
    <input id="hdID" name="hdID" type="hidden"/>
    <table class="table">
        <tr>
            <td class="titleTD">公司编号：</td>
            <td class="inputTD"><input type="text" id="txtNumber" name="txtNumber" class=""/></td>
            <td class="titleTD">负&nbsp;&nbsp;责&nbsp;&nbsp;人：</td>
            <td class="inputTD"><input type="text" id="txtHead" name="txtHead" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">公司简称：</td>
            <td class="inputTD"><input type="text" id="txtAbbreviation" name="txtAbbreviation" class=""/></td>
            <td class="titleTD">英文简称：</td>
            <td class="inputTD"><input type="text" id="txtEnAbbreviation" name="txtEnAbbreviation" class=""/></td>
        </tr>
         <tr>
            <td class="titleTD">公司名称：</td>
            <td class="inputTD"><input type="text" id="txtFullName" name="txtFullName" class=""/></td>
            <td class="titleTD">英文名称：</td>
            <td class="inputTD"><input type="text" id="txtEnFullName" name="txtEnFullName" class=""/></td>
        </tr>       
        <tr>
            <td class="titleTD">址&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址：</td>
            <td class="inputTD"><input type="text" id="txtAddress" name="txtAddress" class=""/></td>
            <td class="titleTD">英文地址：</td>
            <td class="inputTD"><input type="text" id="txtEnAddress" name="txtEnAddress" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话：</td>
            <td class="inputTD"><input type="text" id="txtFixedPhone" name="txtFixedPhone" class=""/></td>
            <td class="titleTD">移动电话：</td>
            <td class="inputTD"><input type="text" id="txtMobilePhone" name="txtMobilePhone" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">传&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;真：</td>
            <td class="inputTD"><input type="text" id="txtFax" name="txtFax" class=""/></td>       
            <td class="titleTD">邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;编：</td>
            <td class="inputTD"><input type="text" id="txtZipCode" name="txtZipCode" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">开户银行：</td>
            <td class="inputTD"><input type="text" id="txtOpeningBank" name="txtOpeningBank" class=""/></td>      
            <td class="titleTD">帐&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
            <td class="inputTD"><input type="text" id="txtAccount" name="txtAccount" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">企业代码：</td>
            <td class="inputTD"><input type="text" id="txtCustomsCode" name="txtCustomsCode" class=""/></td>        
            <td class="titleTD">法人代表：</td>
            <td class="inputTD"><input type="text" id="txtLegalRepresentative" name="txtLegalRepresentative" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="inputTD" colspan="3">
                <textarea id="txtRemark" name="txtRemark" rows="3" cols="" style="width:383px" class=""></textarea>
            </td>
        </tr>
	</table>
</form>