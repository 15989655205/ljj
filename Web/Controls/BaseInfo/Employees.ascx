<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Employees.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.Employees" %>

<!--控件加载事件-->
<script type="text/javascript">
    var WrokID;  
    var sumbitUrl = "";    
    var loadflag = true;
    var UN;
    var ABBR;
</script>

<!--弹出表单-->
<script type="text/javascript">
    function openDialog(type, row, title) {
        if (loadflag) { setControls(); loadflag = false; }
        switch (type) {
            case "add": sumbitUrl = "../Ashx/Employees.ashx?action=add"; ClearControl(); break;
            case "copy": sumbitUrl = "../Ashx/Employees.ashx?action=copy"; showData(row, type); break;
            case "edit": sumbitUrl = "../Ashx/Employees.ashx?action=edit"; showData(row, type); break;
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
        $("#hdID").val("");
        $("#hdPwd").val("");
        $("#txtUserName").val(UN = "");
        $("#txtAbbr").val(ABBR = "");
        $("#txtWorkID").val(WrokID = "");
        $("#txtAbbr").val("");
        $("#txtName").val("");
        $("#txtIDCard").val("");
        $("#txtNativeplace").val("");
        $("#txtRegdResd").val("");
        $("#txtAddress").val("");
        $("#txtNation").val("");
        $("#txtMajor").val("");
        $("#txtTel").val("");
        $("#txtEmail").val("");
        $("#txtEmContact").val("");
        $("#txtEmContactTel").val("");
        $("#txtRemark").val("");
        document.getElementById("cbPermissions").checked = false;
        document.getElementById("Checkbox2").checked = false;
        document.getElementById("Checkbox3").checked = false;
        document.getElementById("txtUserName").disabled = true;
        $("#txtDataofbirth").datebox("setValue", "");
        $("#txtGraduationDate").datebox("setValue", "");
        $("#txtEntryDate").datebox("setValue", "");
        $("#txtPositivedates").datebox("setValue", "");
        $("#txtSex").combobox("setValue", "");
        $("#txtBloodtype").combobox("setValue", "");
        $("#txtPoliticsstatus").combobox("setValue", "");
        $("#txtMaritalstatus").combobox("setValue", "");
        $("#txtEducation").combobox("setValue", "");
        $("#txtDegree").combobox("setValue", "");
        $("#txtStateEmployees").combobox("setValue", "");
        $("#txtAppRoleID").combobox("setValue", "");
        $("#txtDeptID").combotree("setValue", "");
    }
</script>

<!--复制、编辑、查看重置表单-->
<script type="text/javascript">
    function showData(row,type) {
        $("#hdID").val(row.UserID);
        $("#hdPwd").val(row.Pwd);
        $("#txtUserName").val(row.UserName);
        $("#txtAbbr").val(row.Value2);
        $("#txtWorkID").val(row.WorkID);
        if (type == "copy") {
            WrokID = UN = ABBR = "";
        }
        else {
            WrokID = row.WorkID;
            UN = row.UserName;
            ABBR = row.Value2;
        }
        $("#txtName").val(row.Name);
        $("#txtIDCard").val(row.IDCard);
        $("#txtNativeplace").val(row.Nativeplace);
        $("#txtRegdResd").val(row.RegdResd);
        $("#txtAddress").val(row.Address);
        $("#txtNation").val(row.Nation);
        $("#txtMajor").val(row.Major);
        $("#txtTel").val(row.Tel);
        $("#txtEmail").val(row.Email);
        $("#txtEmContact").val(row.EmContact);
        $("#txtEmContactTel").val(row.EmContactTel);
        $("#txtRemark").val(row.Remark);
        document.getElementById("cbPermissions").checked = row.Permissions == 1;
        document.getElementById("Checkbox2").checked = row.Value0 == 1;
        document.getElementById("Checkbox3").checked = row.Value1 == 1;        
        document.getElementById("txtUserName").disabled = row.Permissions == 0;
        $("#txtDataofbirth").datebox("setValue", row.Dataofbirth);
        $("#txtGraduationDate").datebox("setValue", row.GraduationDate);
        $("#txtEntryDate").datebox("setValue", row.EntryDate);
        $("#txtPositivedates").datebox("setValue", row.Positivedates);
        $("#txtSex").combobox("setValue", row.Sex);
        $("#txtBloodtype").combobox("setValue", row.Bloodtype);
        $("#txtPoliticsstatus").combobox("setValue", row.Politicsstatus);
        $("#txtMaritalstatus").combobox("setValue", row.Maritalstatus);
        $("#txtEducation").combobox("setValue", row.Education);
        $("#txtDegree").combobox("setValue", row.Degree);
        $("#txtStateEmployees").combobox("setValue", row.StateEmployees);
        $("#txtAppRoleID").combobox("setValue", row.AppRoleID);
        $("#txtDeptID").combotree("setValue", row.DeptID);
        //document.getElementById("txtWorkID").readOnly = true;
    }
</script>

<!--是否可编辑表单-->
<script type="text/javascript">
    function ControlReadonly(flag) {
        document.getElementById("cbPermissions").disabled =
        document.getElementById("Checkbox2").disabled =
        document.getElementById("Checkbox3").disabled =
        document.getElementById("txtUserName").readOnly =
        document.getElementById("txtAbbr").readOnly =
        document.getElementById("txtWorkID").readOnly =
        document.getElementById("txtName").readOnly =
        document.getElementById("txtIDCard").readOnly =
        document.getElementById("txtNativeplace").readOnly =
        document.getElementById("txtRegdResd").readOnly =
        document.getElementById("txtAddress").readOnly =
        document.getElementById("txtNation").readOnly =
        document.getElementById("txtMajor").readOnly =
        document.getElementById("txtTel").readOnly =
        document.getElementById("txtEmail").readOnly =
        document.getElementById("txtEmContact").readOnly =
        document.getElementById("txtEmContactTel").readOnly =
        document.getElementById("txtRemark").readOnly = flag;
        var able = flag ? "disable" : "enable";
        $("#txtDataofbirth").datebox(able);
        $("#txtGraduationDate").datebox(able);
        $("#txtEntryDate").datebox(able);
        $("#txtPositivedates").datebox(able);
        $("#txtSex").combobox(able);
        $("#txtBloodtype").combobox(able);
        $("#txtPoliticsstatus").combobox(able);
        $("#txtMaritalstatus").combobox(able);
        $("#txtEducation").combobox(able);
        $("#txtDegree").combobox(able);
        $("#txtStateEmployees").combobox(able);
        $("#txtAppRoleID").combobox(able);
        $("#txtDeptID").combotree(able);
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
    }
</script>

<!--设置验证-->
<script type="text/javascript">
    function setValidate() {
        $("#txtEmail").validatebox({ required: true, validType: "email" });
        $("#txtWorkID").validatebox({ required: true, validType: "GongHao" });
        $("#txtUserName").validatebox({ required: true, validType: "UserName" });
        $("#txtName").validatebox({ required: true });
        $("#txtAbbr").validatebox({ required: true, validType: "Abbr" });
    }
    $.extend($.fn.validatebox.defaults.rules, {
        GongHao: {
            message: "*工号已存在"
            , validator: function (value, param) {
                var flag = true;
                if (value != "" && value != WrokID) {
                    $.ajax({
                        type: "POST",
                        timeout: 6000,
                        async: false,
                        url: "../Ashx/UserList.ashx",
                        data: { "action": "checkWorkID", "WorkID": value },
                        success: function (data) { flag = data == "success"; }
                    });
                }
                return flag;
            }
        }
        , UserName: {
            message: "*用户名已存在"
            , validator: function (value, param) {
                var flag = true;
                if (value != "" && value != UN) {
                    $.ajax({
                        type: "POST",
                        timeout: 6000,
                        async: false,
                        url: "../Ashx/Employees.ashx",
                        data: { "action": "checkUserName", "UserName": value },
                        success: function (data) { flag = data == "success"; }
                    });
                }
                return flag;
            }
        }
        , Abbr: {
            message: "*简称已存在"
            , validator: function (value, param) {
                var flag = true;
                if (value != "" && value != ABBR) {
                    $.ajax({
                        type: "POST",
                        timeout: 6000,
                        async: false,
                        url: "../Ashx/Employees.ashx",
                        data: {
                            "action": "checkAbbr",
                            "Abbr": value
                        },
                        success: function (data) { flag = data == "success"; }
                    });
                }
                return flag;
            }
        }
    });
    $.extend($.fn.validatebox.methods, {
        remove: function (jq, newposition) {
            return jq.each(function () { $(this).removeClass("validatebox-text validatebox-invalid").unbind("focus.validatebox").unbind("blur.validatebox"); });
        },
        reduce: function (jq, newposition) {
            return jq.each(function () { $(this).addClass("validatebox-text").validatebox($(this).data().validatebox.options); });
        }
    }); 
</script>

<!--表单保存事件-->
<script type="text/javascript">

    function ButtonLock(flag) {
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag }, { name: "关闭", disabled: flag });
    }

    function save() {
        ButtonLock(true);
        if (!$("#ff").form("validate")) {
            $.messager.show({ title: "提示", msg: "验证未通过。" });
            ButtonLock(false);
        }
        else {
            if (!$("#cbPermissions").is(":checked")) {
                $("#txtUserName").removeAttr("disabled");
            }
            $("#ff").form("submit", {
                url: sumbitUrl,
                onSubmit: function () { /*做某些检查,返回 false 来阻止提交*/ },
                success: function (data) {
                    if (!$("#cbPermissions").is(":checked")) {
                        $("#txtUserName").attr("disabled", "disabled");
                    }
                    if (data == "ok") {
                        $("#tt").datagrid("reload");
                        art.dialog.list["dialog"].close();
                        $.messager.show({ title: "提示", msg: "保存成功。" });
                    }
                    else {
                        if (!$("#cbPermissions").is(":checked")) {
                            $("#txtUserName").attr("disabled", "disabled");
                        }
                        ButtonLock(false);
                        $.messager.show({ title: "提示", msg: (data=="success"?"保存成功":data) });
                    }
                }
            });
        }
    }
</script>

<!--控件初始化-->
<script type="text/javascript">
    function setControls() {
        $("#txtDataofbirth").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
        $("#txtGraduationDate").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
        $("#txtEntryDate").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });
        $("#txtPositivedates").datebox({ formatter: function (date) { return date.format("yyyy-MM-dd"); } });

        $("#txtSex").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=sex", valueField: "value", textField: "text" });
        $("#txtBloodtype").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=bloodtype", valueField: "value", textField: "text" });
        $("#txtPoliticsstatus").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=politicsstatus", valueField: "value", textField: "text" });
        $("#txtMaritalstatus").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=maritalstatus", valueField: "value", textField: "text" });
        $("#txtEducation").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=education", valueField: "value", textField: "text" });
        $("#txtDegree").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=degree", valueField: "value", textField: "text" });
        $("#txtStateEmployees").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=stateEmployees", valueField: "value", textField: "text", required: true });

        $("#txtAppRoleID").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=approle", valueField: "value", textField: "text", required: true });

        $("#txtDeptID").combotree({ url: "../Ashx/BaseDictionaryDetail.ashx?type=dept", required: true });
    }

    function username() {
        document.getElementById("txtUserName").disabled = !document.getElementById("cbPermissions").checked;
//        if (!document.getElementById("cbPermissions").checked) {
//            $("#txtUserName").val("");
//           
        //        }
        var value = $("#txtUserName").val();
        if ($("#cbPermissions").is(":checked")) {            
            $("#txtUserName").validatebox("reduce");
        }
        else {
            $("#txtUserName").validatebox("remove"); ;
        }
    }
    

</script>

<!--html-->
<form action="" id="ff" method="post">
    <input id="hdID" name="hdID" type="hidden"/>
    <input id="hdPwd" name="hdPwd" type="hidden"/>
    <table class="table">
        <tr><td class="titleTD"></td>
            <td class="inputTD">
                <input type="checkbox" id="cbPermissions" name="cbPermissions" value="1" onclick="username();"/><label for="cbPermissions">激活登录账号</label>               
            </td>
            <td class="titleTD">账&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
            <td class="inputTD"><input type="text" id="txtUserName" name="txtUserName" class=""/></td>
            <td class="inputTD" colspan="2">
                <input type="checkbox" id="Checkbox2" name="Checkbox2" value="1" /><label for="Checkbox2">免考勤特权</label>
                <input type="checkbox" id="Checkbox3" name="Checkbox3" value="1" /><label for="Checkbox3">下载特权</label>
            </td>
        </tr>
        <tr>
            <td class="titleTD">工&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
            <td class="inputTD"><input type="text" id="txtWorkID" name="txtWorkID" class=""/></td>
            <td class="titleTD">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：</td>
            <td class="inputTD"><input type="text" id="txtName" name="txtName" class=""/></td>
            <td class="titleTD">员工简称：</td>
            <td class="inputTD"><input id="txtAbbr" name="txtAbbr" class="oaInput txt"/></td>
        </tr>
        <tr>
            <td class="titleTD">身&nbsp;&nbsp;份&nbsp;&nbsp;证：</td>
            <td class="inputTD"><input type="text" id="txtIDCard" name="txtIDCard" class=""/></td>
            <td class="titleTD">出生日期：</td>
            <td class="inputTD"><input type="text" id="txtDataofbirth" name="txtDataofbirth" class=""/></td>
            <td class="titleTD">性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：</td>
            <td class="inputTD"><input id="txtSex" name="txtSex" class="oaInput txt"/></td>
        </tr>
        <tr>
            <td class="titleTD">籍&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;贯：</td>
            <td class="inputTD"><input type="text" id="txtNativeplace" name="txtNativeplace" class=""/></td>
            <td class="titleTD">户口地址：</td>
            <td class="inputTD"><input type="text" id="txtRegdResd" name="txtRegdResd" class=""/></td>
            <td class="titleTD">居住地址：</td>
            <td class="inputTD"><input type="text" id="txtAddress" name="txtAddress" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">民&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;族：</td>
            <td class="inputTD"><input type="text" id="txtNation" name="txtNation" class=""/></td>
            <td class="titleTD">政治面貌：</td>
            <td class="inputTD"><input id="txtPoliticsstatus" name="txtPoliticsstatus" class=""/></td>
            <td class="titleTD">婚姻状况：</td>
            <td class="inputTD"><input id="txtMaritalstatus" name="txtMaritalstatus" class=""/></td>
        </tr>        
        <tr>
            <td class="titleTD">学&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;历：</td>
            <td class="inputTD"><input id="txtEducation" name="txtEducation" class=""/></td>
            <td class="titleTD">学&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;位：</td>
            <td class="inputTD"><input id="txtDegree" name="txtDegree" class=""/></td>
            <td class="titleTD">专&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业：</td>
            <td class="inputTD"><input type="text" id="txtMajor" name="txtMajor" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">毕业时间：</td>
            <td class="inputTD"><input type="text" id="txtGraduationDate" name="txtGraduationDate" class=""/></td>
            <td class="titleTD">电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话：</td>
            <td class="inputTD"><input type="text" id="txtTel" name="txtTel" class=""/></td>
            <td class="titleTD">邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;箱：</td>
            <td class="inputTD"><input type="text" id="txtEmail" name="txtEmail" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">联&nbsp;&nbsp;系&nbsp;&nbsp;人：</td>
            <td class="inputTD"><input type="text" id="txtEmContact" name="txtEmContact" class=""/></td>
            <td class="titleTD">联系电话：</td>
            <td class="inputTD"><input type="text" id="txtEmContactTel" name="txtEmContactTel" class=""/></td>
            <td class="titleTD">血&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;型：</td>
            <td class="inputTD"><input id="txtBloodtype" name="txtBloodtype" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">员工状态：</td>
            <td class="inputTD"><input id="txtStateEmployees" name="txtStateEmployees" class=""/></td>
            <td class="titleTD">入职日期：</td>
            <td class="inputTD"><input type="text" id="txtEntryDate" name="txtEntryDate" class=""/></td>
            <td class="titleTD">转正日期：</td>
            <td class="inputTD"><input type="text" id="txtPositivedates" name="txtPositivedates" class=""/></td>
        </tr>
        <tr>
            <td class="titleTD">部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门：</td>
            <td class="inputTD"><input id="txtDeptID" name="txtDeptID" class=""/></td>
            <td class="titleTD">级&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：</td>
            <td class="inputTD"><input id="txtAppRoleID" name="txtAppRoleID" class=""/></td>
            <td class="inputTD" colspan="2"></td>             
        </tr>
        <tr>
            <td class="titleTD">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="inputTD" colspan="5"><textarea id="txtRemark" name="txtRemark" rows="" cols="" style="width:620px"></textarea></td>
        </tr>
	</table>
</form>