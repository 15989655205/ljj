<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientLevel.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.ClientLevel" %>

<script type="text/javascript">
    var sumbitUrl = "";
    var loadflag = true;
</script>

<script type="text/javascript">
    function openDialog(type, row, title) {
        if (loadflag) {
            $("#ReferencePrice").combobox({
                url: "../Ashx/BaseDictionaryDetail.ashx?type=price"
                , valueField: "value"
                , textField: "text"
                , required: true
            });
            loadflag = false;
        }
        switch (type) {
            case "add": sumbitUrl = "../Ashx/ClientLevel.ashx?action=add"; ClearControl(); break;
            case "copy": sumbitUrl = "../Ashx/ClientLevel.ashx?action=add"; showData(row, type); break;
            case "edit": sumbitUrl = "../Ashx/ClientLevel.ashx?action=update"; showData(row, type); break;
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
        document.getElementById("lblCode").innerHTML = "???";
        $("#Code").val("");
        $("#Name").val("");
        $("#ReferencePrice").combobox("setValue", "");
        $("#Percentage").val("");
        $("#Remark").val("");
    }
</script>

<script type="text/javascript">
    function showData(row, type) {
        $("#ID").val(row.ID);
        document.getElementById("lblCode").innerHTML = type == "copy" ? "???" : row.Code;
        $("#Code").val(row.Code);
        $("#Name").val(row.Name);
        $("#Percentage").val(row.Percentage);
        $("#ReferencePrice").combobox("setValue", row.ReferencePrice != 0 ? row.ReferencePrice : "");
        $("#Remark").val(row.Remark);
    }
</script>

<script type="text/javascript">
    function ControlReadonly(flag) {
        //document.getElementById("Code").readOnly =
        document.getElementById("Name").readOnly =
        document.getElementById("Percentage").readOnly =
        document.getElementById("Remark").readOnly = flag;
        $("#ReferencePrice").combobox(flag ? "disable" : "enable");
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
    }
</script>
    
<!--表单数据合法验证-->
<script type="text/javascript">
    function setValidate() {
        $("#Name").validatebox({ required: true });        
        $("#Percentage").validatebox({ required: true, validType: "Percentage" });
    }
    $.extend($.fn.validatebox.defaults.rules, {
        Percentage: {
            message: "*不是有效的折率"
            , validator: function (value) {
                var re = /^[0-9]*.?[0-9]*$/;
                if (re.test(value)) {
                    return value > 0 && value <= 1;
                }
                else {
                    return false;
                }
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
    <input type="hidden" id="Code" name="Code"/>
    <table class="table">
        <tr>
            <td class="titleTD">编码：</td>
            <td class="inputTD"><label id="lblCode"></label><%--<input type="text" id="Code" name="Code" class=""/>--%></td>
            <td class="titleTD">名称：</td>
            <td class="inputTD"><input type="text" id="Name" name="Name" class=""/></td>           
        </tr>
        <tr>
            <td class="titleTD">售价：</td>
            <td class="inputTD"><input id="ReferencePrice" name="ReferencePrice" class=""/></td>
            <td class="titleTD">折率：</td>
            <td class="inputTD"><input type="text" id="Percentage" name="Percentage" class=""/></td>           
        </tr>
        <tr>
            <td class="titleTD">备注：</td>
            <td class="inputTD" colspan="3"><textarea id="Remark" name="Remark" rows="4" cols="" style="width:360px" class=""></textarea></td>
        </tr>
	</table>
</form>