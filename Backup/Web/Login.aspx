<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Maticsoft.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>梓人</title>
<style type="text/css">
body{ margin:0px; padding:0px; font-family:"微软雅黑"; font-size:12px; color:#000; background:#E0ECFF;}
form,ul,li,dl,dd,dt,p{ margin:0px; padding:0px; border:0px; text-decoration:none; list-style-type:none;}
a{color:#555; list-style-type:none; text-decoration:none;}
a:hover{color:#F00; list-style-type:none; text-decoration:none;}
img{ border:0px;}
.clear{ clear:both;}

#divcss{width:792px; height:482px; position:absolute;left:50%;margin-left:-396px;top:50%;margin-top:-241px; background:#FFF;}
.top{ width:792px; background:url(images/login_01.jpg); height:205px; position:relative;}
.table{ width:450px; position:absolute; bottom:0px; right:0px;}
.input_width{ width:105px; height:14px;}
.cont{ width:834px; height:216px; position:relative;}
/* 焦点图 */
.focus{width:322px;height:240px;border:1px solid #EEE;position:relative;margin-top:6px;float:left}
.f426x240{width:322px;height:240px;overflow:hidden}
.f426x240 img{width:322px;height:240px}

.rslides{width:100%;position:relative;list-style:none;padding:0}
.rslides_nav{height:81px;width:56px;position:absolute;-webkit-tap-highlight-color:rgba(0,0,0,0);top:50%;left:0;opacity:0.5;text-indent:-9999px;overflow:hidden;text-decoration:none;background:url(images/i.png) no-repeat 0 0px;margin-top:-28px}
.rslides_nav:active{opacity:1.0}
.rslides_nav.next{left:auto;background-position:-56px 0px;right:0}
.rslides_tabs{margin:-20px auto;clear:both;text-align:center; z-index:100; position:absolute; left:120px;}
.rslides_tabs li{display:inline;float:none;_float:left;*float:left;margin-right:5px}
.rslides_tabs a{text-indent:-9999px;overflow:hidden;-webkit-border-radius:0px;-moz-border-radius:0px;border-radius:0px;background:rgba(0,0,0, .2);background:#DDD;display:inline-block;_display:block;*display:block;width:9px;height:9px}
.rslides_tabs .rslides_here a{background:rgba(0,0,0, .6);background:#390}
/* 焦点图 结束*/
.li{ width:453px; height:216px; background:url(images/login_05.jpg) no-repeat; position:relative; float:left; margin-top:5px; margin-left:10px;}
.li ul{ width:451px; border-bottom:1px #e7e7e7 solid; border-left:1px #e7e7e7 solid; border-right:1px #e7e7e7 solid; height:190px; margin-top:53px;}
.li li{ background:url(images/logins_13.jpg) 0 16px no-repeat; float:left; margin-left:20px; padding-left:20px; border-bottom:1px #CCC solid; width:400px; line-height:40px;}
.bottom{ width:100%; height:25px; text-align:center; position:relative; background:url(images/login_18.jpg) repeat-x; margin-top:5px; line-height:25PX;}
a:link {color: black} 
a:visited {color: black}
a:hover {color: black}    
a:active {color: black}  
</style>
    <link href="/js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="/js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="js/lrtk.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
//        $('#win').window({
//            title: "",
//            width: 800,
//            height: 500,
//            draggable: false,
//            resizable: false,
//            closable: false,
//            minimizable: false,
//            maximizable: false,
//            collapsible: false,
//            fit:true,
//            shadow:true,
//            modal: true
        //        });
        $('#win').panel({
            title: "",
            width: 800,
            height: 500,
            draggable: false,
            resizable: false,
            closable: false,
            minimizable: false,
            maximizable: false,
            collapsible: false,
            fit: true,
            shadow: true,
            modal: true
        });
    });

    document.onkeydown = function (e) {
        if (!e) e = window.event; //火狐中是 window.event
        if ((e.keyCode || e.which) == 13) {
            document.getElementById("login").click();  //这里可以使用您自己的js函数
        }
    }

    function Login() {
        if ($('#txtUserName').val() == "") {
            $.messager.show({ title: '系统提示', msg: "登录帐号不能为空" });
            return;
        }
        if ($('#txtPwd').val() == "") {
            $.messager.show({ title: '系统提示', msg: "密码不能为空" });
            return;
        }
        //$.messager.progress({ msg: '登录中...',text:'' });
        //        $.ajax({
        //            url: "Ashx/UserList.ashx",
        //            data: { "action": "login", "user": $('#txtUserName').val(), "pwd": $('#txtPwd').val() },
        //            success: function (data) {
        //                if (data == "success") {
        //                    window.location.href = 'Default.aspx';
        //                }
        //                else {
        //                    //$.messager.show({ title: '错误提示', msg: data });
        //                    $.messager.alert('错误提示', data);
        //                    $.messager.progress('close');
        //                }
        //            },
        //            error: function () {
        //                $.messager.alert('错误提示', "系统出错!");
        //                $.messager.progress('close');
        //            }
        //        });

        $.post('Ashx/UserList.ashx', { "action": "login", "user": $('#txtUserName').val(), "pwd": $('#txtPwd').val() }, function (data) {
            if (data == "success") {
                $.messager.progress({ msg: '登录中...', text: '' });
                window.location.href = 'Default.aspx';
            }
            else {
                //$.messager.alert('错误提示', data);
                //$.messager.progress('close');
                $.messager.show({ title: '系统提示', msg: data });
                              
            }
        });
    }
</script>
</head>

<body>
<div id="win" style="background-color:#E0ECFF;" title="系统登录">  
<div id="divcss">
	<div class="top">
    	<table class="table" width="450" border="0">
          <tr height="34">
            <td align="right">用户名：</td>
            <td><input id="txtUserName" name="txtUserName" type="text"  class="input_width"/></td>
            <td align="right">密码：</td>
            <td><input id="txtPwd" name="txtPwd" type="password"  class="input_width"/></td>
            <td><input id="login" name="login" type="image" src="images/login_04.jpg" onclick="Login()"/></td>
          </tr>
        </table>
    </div>
    <div class="cont">
    	<div class="focus">
            <ul class="rslides f426x240">
            <asp:Repeater ID ="ad_img" runat="server">
                <ItemTemplate>
                    <li><a href="#" target="_blank"><img src='<%#Eval("v1") %>' /></a></li>
                </ItemTemplate>
            </asp:Repeater>
<%--                <li><a href="#" target="_blank"><img src="images/01.jpg" /></a></li>
                <li><a href="#" target="_blank"><img src="images/02.jpg" /></a></li>
                <li><a href="#" target="_blank"><img src="images/03.jpg" /></a></li>
                <li><a href="#" target="_blank"><img src="images/04.jpg" /></a></li>--%>
            </ul>
        </div>
        <div class="li">           
            <a href="/ADAndNotice/noticelist.aspx" style="float:right;"><br/>更多内容…&nbsp;&nbsp;&nbsp;&nbsp;</a>
            <ul>
        	    <%=htmlstring%>                
            </ul>           
        </div>
    </div>
    <div class="clear"></div>
    <div class="bottom">版权所有：深圳梓人环境设计有限公司 | <a href="http://www.dgzc-it.com" style=" cursor:pointer; font:black;" target="_blank">技术支持：东莞智创信息科技有限公司</a></div>
</div>
</div>
<div id="msg"></div>
</body>
</html>