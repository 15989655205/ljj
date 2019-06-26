<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaseDepartment.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.BaseDepartment" %>

<!--控件加载事件-->
<script type="text/javascript">   
    var sumbitUrl = "";  
    var loadflag = true;
</script>

<!--控件弹出事件-->
<script type="text/javascript">
    function openDialog(type, row, title) {
        if (loadflag) {
            $("#txtParentDeptID").combotree({ url: "../Ashx/BaseDictionaryDetail.ashx?type=dept" });
            loadflag = false;
        }
        switch (type) {
            case "add": sumbitUrl = "../Ashx/BaseDepartment.ashx?action=add"; ClearControl(); break;
            case "copy": sumbitUrl = "../Ashx/BaseDepartment.ashx?action=add"; showData(row); break;
            case "edit": sumbitUrl = "../Ashx/BaseDepartment.ashx?action=edit"; showData(row); break;
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

<!--清空表单-->
<script type="text/javascript">
    function ClearControl() {
        $("#txtDeptName").val("");
        $("#txtParentDeptID").combotree("setValue", "");
        $("#txtRemark").val("");
    }
</script>

<!--复制、编辑、查看表单赋值-->
<script type="text/javascript">
    function showData(row) {        
        $("#hdID").val(row.DeptID);
        $("#txtDeptName").val(row.DeptName);
        $("#txtParentDeptID").combotree("setValue", row.ParentDeptID != 0 ? row.ParentDeptID : "");
        $("#txtRemark").val(row.Remark);
    }
</script>

<!--表单是否只读-->
<script type="text/javascript">
    function ControlReadonly(flag) {
        document.getElementById("txtDeptName").readOnly =
        document.getElementById("txtRemark").readOnly = flag;
        $("#txtParentDeptID").combotree(flag ? "disable" : "enable");
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
    }
</script>

<!--表单数据合法验证-->
<script type="text/javascript">
    function setValidate() {
        $('#txtDeptName').validatebox({ required: true });
    }
</script>

<!--保存按钮事件-->
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
                    $("#tt").treegrid("options").url = "../Ashx/BaseDepartment.ashx?action=list";
                    $("#tt").treegrid("reload");
                    $.messager.show({ title: "系统提示", msg: "保存成功。" });
                    art.dialog.list["dialog"].close();
                }
                else {
                    $.messager.show({ title: "系统提示", msg: data });
                    ButtonLock(false);
                }
            }
        });
    }
</script>

<!--css-->
<style type="text/css">
    .txt{width:300px;}
</style>

<!--html-->
<form action="" id="ff" method="post">
    <input id="hdID" name="hdID" type="hidden"/>
    <table class="table">
        <tr>
            <td class="titleTD">部门名称：</td>
            <td class="inputTD"><input type="text" id="txtDeptName" name="txtDeptName" class="txt"/></td>            
        </tr>
        <tr>
            <td class="titleTD">所属部门：</td>
            <td class="inputTD"><input id="txtParentDeptID" name="txtParentDeptID" class="txt"/></td>           
        </tr>
        <tr>
            <td class="titleTD">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="inputTD"><textarea id="txtRemark" name="txtRemark" rows="4" cols="" class="txt"></textarea></td>
        </tr>
	</table>
</form>
