<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Approve_role.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.Approve_role" %>

<!--控件加载事件-->
<script type="text/javascript">
    var sumbitUrl = "";
    var loadflag = true;
    var name = "";
</script>

<!--控件弹出事件-->
<script type="text/javascript">
    function openDialog(type, row, title) {
        if (loadflag) {
            $("#txtrole_level").numberspinner({ min: 1, max: 100, required: true, increment: 1 });
            loadflag = false;
        }
        switch (type) {
            case "add": sumbitUrl = "../Ashx/Approve_role.ashx?action=add"; ClearControl(); break;
            case "copy": sumbitUrl = "../Ashx/Approve_role.ashx?action=add"; showData(row); break;
            case "edit": sumbitUrl = "../Ashx/Approve_role.ashx?action=edit"; showData(row); break;
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
                resize: false,
                esc: false,
                lock: type != "view",
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
        $("#txtrole_name").val(name = "");
        $("#txtrole_level").numberspinner("setValue", "");
        $("#txtremark").val("");
    }
</script>

<!--复制、编辑、查看表单赋值-->
<script type="text/javascript">
    function showData(row, type) {
        name = type == "copy" ? "" : row.role_name;
        $("#hdID").val(row.sid);
        $("#txtrole_name").val(row.role_name);
        $("#txtrole_level").numberspinner("setValue", row.role_level);
        $("#txtremark").val(row.remark);
    }
</script>

<!--表单是否只读-->
<script type="text/javascript">
    function ControlReadonly(flag) {
        document.getElementById("txtrole_name").readOnly =
        document.getElementById("txtremark").readOnly = flag;
        $("#txtrole_level").numberspinner(flag ? "disable" : "enable");
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
    }
</script>

<!--表单数据合法验证-->
<script type="text/javascript">   
    function setValidate() {
        $("#txtrole_name").validatebox({ required: true, validType: "role_name" });
        $("#txtrole_level").validatebox({ required: true });
    }
    $.extend($.fn.validatebox.defaults.rules, {
        role_name: {
            message: "*级别名称已存在"
            , validator: function (value) {
                var flag = true;
                if (value != "" && value != Number) {
                    $.ajax({
                        type: "POST"
                        , timeout: 6000
                        , async: false
                        , url: "../Ashx/Approve_role.ashx"
                        , data: { "action": "checkRn", "value": value }
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
                    art.dialog.list["dialog"].close();
                    $.messager.show({ title: "提示", msg: "保存成功。" });
                }
                else {
                    $.messager.show({ title: "提示", msg: data });
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
            <td class="titleTD">级别名称：</td>
            <td class="inputTD"><input type="text" id="txtrole_name" name="txtrole_name" class="txt"/></td>
        </tr>
        <tr>
            <td class="titleTD">级别等级：</td>
            <td class="inputTD"><input id="txtrole_level" name="txtrole_level" class="txt"/></td>
        </tr>
        <tr>
            <td class="titleTD">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="inputTD"><textarea id="txtremark" name="txtremark" rows="4" cols="" class="txt"></textarea></td>
        </tr>
	</table>
</form>