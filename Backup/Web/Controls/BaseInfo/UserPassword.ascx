<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserPassword.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.UserPassword" %>
    <!--修改密码窗口-->
    <script type="text/javascript">
        var userName = "<%=userName %>";
        var userID = "<%=userID %>";
        var dlg = art.dialog;
        $(function () {
            $("#lblUserName").text(userName);
            $('#password_win').window({
                title: '密码',
                width: 400,
                modal: true,
                shadow: true,
                closed: true,
                height: 300,
                resizable: false,
                minimizable: false,
                collapsible: false,
                maximizable: false
            });

            $('#btnEp').click(function () {
                serverLogin();
            })

            $('#btnCancel').click(function () { closePwd(); })
        });

        //修改密码
        function serverLogin() {
            var $newpass = $('#txtNewPass');
            var $rePass = $('#txtRePass');
            if ($newpass.val() == '') {
                $.messager.show({ title: '系统提示', msg: '请输入密码！' });
                return false;
            }
            if ($rePass.val() == '') {
                $.messager.show({ title: '系统提示', msg: '请再一次输入密码！' });
                return false;
            }

            if ($newpass.val() != $rePass.val()) {
                $.messager.show({ title: '系统提示', msg: '两次密码不一至！请重新输入' });
                return false;
            }
            $.ajax({
                type: "POST",
                timeout: 6000,
                async: false,
                url: "/Ashx/UserList.ashx",
                data: {
                    'action': 'checkPWD',
                    'userID': userID,
                    'userName': userName,
                    'pwd': $("#AlterPwd").val()
                },
                success: function (data) {
                    if (data == "success") {

                        $.post('/Ashx/UserList.ashx?action=password&uid=' + userID + '&newpass=' + $newpass.val(), function (msg) {
                            $.messager.show({ title: '系统提示', msg: '恭喜，密码修改成功！' });
                            $("#AlterPwd").val('');
                            $newpass.val('');
                            $rePass.val('');
                            $('#password_win').window('close');
                        })
                    }
                    else {
                        $.messager.show({ title: '系统提示', msg: '输入密码错误！' });
                        return false;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                    return false;
                }
            })
            

            

        }
        
        function closePwd() {
            $('#password_win').window('close');
        }
    </script>
    <div id="password_win">
        <div class="easyui-layout" fit="true">
            <div region="center" border="false" style="padding: 10px; background: #fff; border: 1px solid #ccc;">
            <input id="uid" name="uid" type="hidden">
                <table cellpadding=3>
                <tr>
                    <td>用户名：</td>
                    <td><label id="lblUserName"></label></td>
                </tr>
                <tr>
                    <td>密码：</td>
                        <td><input id="AlterPwd" type="password"  /></td>
                </tr>
                    <tr>
                        <td>新密码：</td>
                        <td><input id="txtNewPass" type="password"  /></td>
                    </tr>
                    <tr>
                        <td>确认密码：</td>
                        <td><input id="txtRePass" type="password"  /></td>
                    </tr>
                </table>
            </div>
            <div region="south" border="false" style="text-align: right; height: 30px; line-height: 30px;">
                <a id="btnEp" class="easyui-linkbutton" icon="icon-ok" href="javascript:void(0)"  >
                    确定</a> <a id="btnCancel" class="easyui-linkbutton" icon="icon-cancel" href="javascript:void(0)">取消</a>
            </div>
        </div>
    </div>