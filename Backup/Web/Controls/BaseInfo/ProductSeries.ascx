<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSeries.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.ProductSeries" %>

<script type="text/javascript">
    var sumbitUrl = ""; 
    var loadflag = true;
</script>

<script type="text/javascript">

    function openDialog(type, row, title) {
        switch (type) {
            case "add": sumbitUrl = "../Ashx/ProductSeries.ashx?action=add"; ClearControl(); break;
            case "copy": sumbitUrl = "../Ashx/ProductSeries.ashx?action=add"; showData(row); break;
            case "edit": sumbitUrl = "../Ashx/ProductSeries.ashx?action=edit"; showData(row); break;
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
        if (type == "edit" || type == "view") {
            document.getElementById("lblCode").innerHTML = row.Code;
            $("#hdCode").val(row.Code);
        }
        else {
            $("#hdCode").val("");
            document.getElementById("lblCode").innerHTML = "??";
        }
    }
</script>

<script type="text/javascript">
    function ClearControl() {       
        $("#txtName").val("")
        $("#txtRemark").val("");
    }
</script>

<script type="text/javascript">
    function showData(row) {
        $("#hdID").val(row.ID);
        $("#txtName").val(row.Name);
        $("#txtRemark").val(row.Remark);        
    }
</script>

<script type="text/javascript">
    function ControlReadonly(flag) {
        //document.getElementById("txtCode").readOnly =
        document.getElementById("txtName").readOnly =
        document.getElementById("txtRemark").readOnly = flag;      
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
    }
</script>

<script type="text/javascript">
    function setValidate() {
        $('#txtName').validatebox({ required: true });
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

<style type="text/css">
    .txt{width:300px;}
</style>

<form action="" id="ff" method="post">
    <input id="hdID" name="hdID" type="hidden"/>
    <input id="hdCode" name="hdCode" type="hidden"/>
    <table class="table">
        <tr>
            <td class="titleTD">编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
            <td class="inputTD"><label id="lblCode"/></td>
        </tr>
        <tr>
            <td class="titleTD">名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;称：</td>
            <td class="inputTD"><input type="text" id="txtName" name="txtName" class="txt"/></td>           
        </tr>
        <tr>
            <td class="titleTD">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="inputTD"><textarea id="txtRemark" name="txtRemark" rows="4" cols="" class="txt"></textarea></td>
        </tr>
	</table>
</form>