<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductType.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.ProductType" %>

<script type="text/javascript">
    var sumbitUrl = "";   
    var loadflag = true;  
</script>

<script type="text/javascript">

    function openDialog(type, row, title) {
        $("#ParentID").combotree({
            url: "../Ashx/ProductType.ashx?action=ComboTree"
            , onSelect: function (data) {
                if (type == "edit") {
                    if ((row.Level == "2" && data.text[3] == ")") || (row.Level == "3" && data.text[2] == ")")) {
                        $.messager.show({ title: "提示", msg: "不能修改分类级别。" });
                        $("#ParentID").combotree("setValue", row.ParentID);
                        return;
                    }
                }
                var Code = $("#Code").val();
                document.getElementById("lblCode").innerHTML = row.ParentID == data.id && type == "edit" ? Code : "??";
                $("#Level").val(data.text[2] == ")" ? "2" : "3");
            }
        });
        switch (type) {
            case "add": sumbitUrl = "../Ashx/ProductType.ashx?action=add"; ClearControl(); break;
            case "copy": sumbitUrl = "../Ashx/ProductType.ashx?action=add"; showData(row); break;
            case "edit": sumbitUrl = "../Ashx/ProductType.ashx?action=edit"; showData(row); break;
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
            $("#Code").val(row.Code);
            $("#OldParentID").val(row.ParentID);
        }
        else {
            $("#Code").val("");
            $("#OldParentID").val("");
            document.getElementById("lblCode").innerHTML = (row.Level == 1 || type == "add") ? "?" : "??";           
        }
    }
</script>

<script type="text/javascript">
    function ClearControl() {
        $("#PT_Code").val("");
        $("#Name").val("");
        $("#ParentID").combotree("setValue", "");
        $("#Remark").val("");
        $("#Level").val("1");
    }
</script>

<script type="text/javascript">
    function showData(row) {
        $("#ID").val(row.ID);
        switch (row.Level) {
            case "1": $("#PT_Code").val(""); break;
            case "2": $("#PT_Code").val(row.CodeName.substr(1, 1)); break;
            case "3": $("#PT_Code").val(row.CodeName.substr(1, 2)); break;
            default: break;
        }
        $("#Name").val(row.Name);
        $("#ParentID").combotree("setValue", row.ParentID != 0 ? row.ParentID : "");
        $("#ParentID").combotree(row.Level == "1" ? "disable" : "enable");
        $("#Remark").val(row.Remark);
        $("#Level").val(row.Level);
    }
</script>

<script type="text/javascript">
    function ControlReadonly(flag) {
        document.getElementById("Name").readOnly =
        document.getElementById("Remark").readOnly = flag;
        $("#ParentID").combotree(flag ? "disable" : "enable");
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
    }
</script>

<!--表单数据合法验证-->
<script type="text/javascript">
    function setValidate() {
        $('#Name').validatebox({ required: true });
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
            onSubmit: function () { /*做某些检查,返回 false 来阻止提交*/ },
            success: function (data) {
                if (data == "ok") {
                    $("#tt").treegrid("options").url = "../Ashx/ProductType.ashx?action=list";
                    $("#tt").treegrid("reload");
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
    <input id="ID" name="ID" type="hidden"/>
    <input id="Code" name="Code" type="hidden"/>
    <input id="Level" name="Level" type="hidden"/>
    <input id="OldParentID" name="OldParentID" type="hidden"/>
    <table class="table">
        <tr>
            <td class="titleTD">编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
            <td class="inputTD"><label id="lblCode"></label></td>            
        </tr>
        <%--<tr>
            <td class="titleTD">分类级别：</td>
            <td class="inputTD">
                <select id="state" class="easyui-combobox" name="state" style="width:200px;">
		            <option value="1">一级分类</option>
		            <option value="2">二级分类</option>
                    <option value="3">三级分类</option>
	            </select>
            </td>            
        </tr>--%>
        <tr>
            <td class="titleTD">类别名称：</td>
            <td class="inputTD"><input type="text" id="Name" name="Name" class="validate[required] oaInput txt"/></td>            
        </tr>
        <tr>
            <td class="titleTD">所属类别：</td>
            <td class="inputTD"><input id="ParentID" name="ParentID" class="oaInput txt"/></td>           
        </tr>
        <tr>
            <td class="titleTD">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="inputTD"><textarea id="Remark" name="Remark" rows="4" cols="" class="textarea txt"></textarea></td>
        </tr>
	</table>
</form>
