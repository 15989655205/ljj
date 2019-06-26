<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="User_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.User_IDE" %>


<script type="text/javascript">
    var dlg = art.dialog;
    var sumbitUrl = "";
    var isload = true;
    var loadflag = true;

    $(function () {
        if (isload) {
            jQuery("#ff").validationEngine({ showOnMouseOver: false, promptPosition: 'topLeft', autoHidePrompt: true, autoHideDelay: 2000 }); 
            isload = false;
        }
    });

    function InitControl() {
        $('#txtRoles').combobox({
            url: '../Ashx/Common.ashx?type=role_comb',
            width: 300,
            editable: false,
            valueField: 'RoleID',
            panelHeight: 'auto',
            multiple: true,
            textField: 'RoleName',
            onLoadSuccess: function () { }
        });
    }

    function openDialog(type, row, title) {
        if (loadflag) {
            InitControl();
            loadflag = false;
        }
        switch (type) {
            case "edit":
                sumbitUrl = "../Ashx/UserList.ashx?action=edit";
                break;           
        }
        if (art.dialog.list['user_dialog'] == null) {
            art.dialog({
                content: document.getElementById('Edit'),
                id: 'user_dialog',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                lock: type != 'view',
                init: function () { },
                close: function () { },
                button: [
                    { name: '保存', callback: function () { save(); return false; }, focus: true },
		            { name: '关闭' }
                ]
            });
        }
        showData(row);
        ControlReadonly(type == 'view', row);
    }

    function showData(row) {
        $('#hdUserID').val(row.UserID);
        $('#hdPwd').val(row.Pwd);
        $('#txtUserName').val(row.UserName);

        if (row.Roles != "") {
            $('#txtRoles').combobox('setValues', row.Roles.split(','));
        }
        else {
            $('#txtRoles').combobox('clear');
        }
        document.getElementById("lblDeptName").innerHTML = row.DeptName;
        document.getElementById('lblName').innerHTML = row.Name;
        document.getElementById('lblTel').innerHTML = row.Tel;
        document.getElementById('lblWorkID').innerHTML = row.WorkID;
        document.getElementById('lblAppRoleName').innerHTML = row.AppRoleName;
        document.getElementById("cbPermissions").checked = row.Permissions == 1;
    }

    function ControlReadonly(flag, row) {
        if (flag) {
            document.getElementById("cbPermissions").disabled =
            document.getElementById("txtUserName").readOnly = true;
            $('#txtRoles').combobox('disable');
            art.dialog.list['user_dialog'].button({ name: '保存', disabled: true });
        }
        else {
            document.getElementById("cbPermissions").disabled = false;
            if (row.Permissions == 1) {
                document.getElementById("txtUserName").readOnly = false;
                $('#txtRoles').combobox('enable');
            }
            else {
                document.getElementById("txtUserName").readOnly = true;
                $('#txtRoles').combobox('disable');
            }
        }
    }

    function ButtonLock(flag) {
        art.dialog.list['user_dialog'].button({ name: '保存', disabled: flag }, { name: '关闭', disabled: flag });
    }

    function save() {
        ButtonLock(true);
        if (document.getElementById("cbPermissions").checked) {
            if ($('#txtUserName').val().replaceAll(' ', '') == '') {
                $.messager.show({ title: '系统提示', msg: '【登录账号】不能为空。' });
                ButtonLock(false);
                return;
            }
            if ($('#txtRoles').combobox('getValues') <= 0) {
                $.messager.show({ title: '系统提示', msg: '【角色】不能为空。' });
                ButtonLock(false);
                return;
            }
        }
        if (!$("#cbPermissions").is(":checked")) {
            $('#txtRoles').combobox('enable');
        };
        $('#ff').form('submit', {
        
            url: sumbitUrl,
            onSubmit: function () { /*做某些检查,返回 false 来阻止提交*/ },
            success: function (data) {
                if (data == "ok") {
                    if (!$("#cbPermissions").is(":checked")) {
                        $('#txtRoles').combobox('disable');
                    }
                    $('#tt').datagrid("reload");
                    art.dialog.list['user_dialog'].close();
                    $.messager.show({ title: '系统提示', msg: '保存成功。' });
                }
                else {
                    if (!$("#cbPermissions").is(":checked")) {
                        $('#txtRoles').combobox('disable');
                    }
                    ButtonLock(false)
                    $.messager.show({ title: '系统提示', msg: (data=="success"?"保存成功":data) });
                }
            }
        });
    }

    function ReadOnly() {
        if (document.getElementById("cbPermissions").checked) {
            document.getElementById("txtUserName").readOnly = false;
            $('#txtRoles').combobox('enable');
        }
        else {
            document.getElementById("txtUserName").readOnly = true;
            $('#txtRoles').combobox('disable');          
        }
    }
</script>
  
<form id="ff" method="post" action="" >
    <input type="hidden" id="hdUserID" name="hdUserID"/>
    <input type="hidden" id="hdPwd" name="hdPwd"/>
    <table class="table">
        <tr>
	        <td class="titleTD"></td>
	        <td class="inputTD">
                <input type="checkbox" id="cbPermissions" name="cbPermissions" value="1" onclick="ReadOnly();"/><label for="cbPermissions">激活登录账号</label>
            </td>
        </tr>	
	    <tr>
	        <td class="titleTD">登录帐号：</td>
	        <td class="inputTD"><input type="text" id="txtUserName" name="txtUserName" class="validate[required]"/></td>
        </tr>
	    <tr>
	        <td class="titleTD">角&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;色	：</td>
	        <td class="inputTD"><input type="text" id="txtRoles" name="txtRoles" class="validate[required]"/></td>
        </tr>
        <tr>
	        <td class="titleTD">工&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
    	    <td class="inputTD"><label id="lblWorkID"/></td>
        </tr>
	    <tr>
	        <td class="titleTD">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：</td>
    	    <td class="inputTD"><label id="lblName"/></td>
        </tr>
	    <tr>
	        <td class="titleTD">电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话：</td>
	        <td class="inputTD"><label id="lblTel"/></td>
        </tr>
        <tr>
	        <td class="titleTD">部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门	：</td>
            <td class="inputTD"><label id="lblDeptName"/></td>
        </tr>
        <tr>
	        <td class="titleTD">级&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：</td>
            <td class="inputTD"><label id="lblAppRoleName"/></td>
        </tr>
    </table>
</form>