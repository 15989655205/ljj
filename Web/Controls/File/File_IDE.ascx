<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="File_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.File.File_IDE" %>

<script type="text/javascript">
    var dlg = art.dialog;
    var lastIndex;
    var sumbitUrl = "";
    var editType = "";
    var isload = true;   
</script>

<script type="text/javascript">
    $(function () {
        if (isload) {
            jQuery("#ff").validationEngine({ showOnMouseOver: false, promptPosition: 'topLeft', autoHidePrompt: true, autoHideDelay: 2000 });
            isload = false;
        }
    });
</script>

<script type="text/javascript">

    function openDialog(type, row, title) {
        switch (type) {
            case "edit":
                sumbitUrl = "../Ashx/File.ashx?action=update";
                showData(row);
                break;
            case "view":
                showData(row);
                break;
        }
        if (art.dialog.list['file_dialog'] == null) {
            art.dialog({
                content: document.getElementById('detail'),
                id: 'file_dialog',
                title: title,
                lock: type != "view",
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',                
                button: [
                    { name: '保存', callback: function () { save(); return false; }, focus: true },
                    { name: '关闭' }
                ]
            });
        }
        ControlReadonly(type == "view");
    }

</script>

<script type="text/javascript">

    function showData(row) {
        $('#hdID').val(row.ID);
        $('#txtfile_name').val(row.file_name);
        $('#txtpwd').val(row.pwd);
        $('#txtRemark').val(row.Remark);
        document.getElementById("cbpwdflag").checked = row.pwdflag == 1;
        document.getElementById("txtpwd").readOnly = row.pwdflag == 0;
    }

    function ControlReadonly(flag) {
        document.getElementById("txtfile_name").readOnly =
        document.getElementById("txtRemark").readOnly =
        document.getElementById("cbpwdflag").disabled = flag;
        art.dialog.list['file_dialog'].button({ name: '保存', disabled: flag });
        if (flag) {
            document.getElementById("txtpwd").readOnly = true;
        }
    }

    function ButtonLock(flag) {
        art.dialog.list['file_dialog'].button({ name: '保存', disabled: flag }, { name: '关闭', disabled: flag });
    }

</script>

<script type="text/javascript">

    function save() {
        ButtonLock(true);

        if ($("#txtfile_name").val().replaceAll(' ', '') == '') {
            ButtonLock(false);
            $.messager.show({ title: '系统提示', msg: '【标题】不能为空。' });
            return;
        }

        if (!jQuery('#ff').validationEngine('validate')) {
            ButtonLock(false);
            return false;
        }

        $('#ff').form('submit', {
            url: sumbitUrl,
            onSubmit: function () { /*做某些检查,返回 false 来阻止提交*/ },
            success: function (data) {
                if (data == "success") {
                    $('#tt').datagrid("reload");
                    art.dialog.list['file_dialog'].close();
                }
                else {
                    $.messager.show({ title: '系统提示', msg: (data=="success"?"保存成功":data) });
                    ButtonLock(false);
                }
            }
        });
    }

    function password() {
        document.getElementById("txtpwd").readOnly = !document.getElementById("cbpwdflag").checked;
    }

</script>

<form action="" id="ff" method="post">
    <input id="hdID" name="hdID" type="hidden"/>
    <table class="table">
        <tr>
            <td class="titleTD">文&nbsp;&nbsp;件&nbsp;&nbsp;名：</td>
            <td class="inputTD"><input type="text" id="txtfile_name" name="txtfile_name" class="validate[required] oaInput"/></td>            
        </tr>
        <tr>
            <td class="titleTD">是否加密：</td>
            <td class="inputTD"><input type="checkbox" id="cbpwdflag" name="cbpwdflag" value="1" onclick="password();"/></td>           
        </tr>
        <tr>
            <td class="titleTD">密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
            <td class="inputTD"><input type="password" id="txtpwd" name="txtpwd"/></td>
        </tr>
        <tr>
            <td class="titleTD">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="inputTD"><textarea id="txtRemark" name="txtRemark" rows="4" cols="" class="textarea"></textarea></td>
        </tr>
	</table>
</form>
