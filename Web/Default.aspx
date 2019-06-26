<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Maticsoft.Web.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="User" TagName="UserPWD" Src="~/Controls/BaseInfo/UserPassword.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>深圳梓人环境设计管理系统</title>
    
    <link href="js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="js/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <link href="/js/artDialog/skins/blue.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/js/artDialog/artDialog.source.js" type="text/javascript"></script>
    <script src="/js/artDialog/plugins/iframeTools.js" type="text/javascript"></script>
    <script src="js/jquery.ztree.core-3.5.js" type="text/javascript"></script>
    <script src="js/outlook2.js" type="text/javascript"></script>
    <script type="text/javascript">
        var menu = <%=menu %>;
        var zTreeObj;
        var demoIframe;
        var DJStatu=<%=value0 %>
        

	setting = {
	    view: {
	        dblClickExpand: false,
	        //showLine: true,
	        selectedMulti: false
	    },
	    data: {
	        simpleData: {
	            enable: true,
	            idKey: "id",
	            pIdKey: "pId",
	            rootPId: ""
	        }
	    },
	    callback: {
	        beforeClick: function (treeId, treeNode) {
	            var zTree = $.fn.zTree.getZTreeObj("tree");
	            if (treeNode.isParent) {
	                zTree.expandNode(treeNode);
	                return false;
	            } 
                else {
	                //demoIframe.attr("src", treeNode.file + ".html");
                    //addTab(treeNode.name,treeNode.file);
                    addTab_Ext(treeNode.name,treeNode.file,true);
	                return true;
	            }
	        }
	    }
	};

    function mainpage() {
            $('#mainpage').panel({
                fit: true,
                border: false,
                top: 0,
                left: 0,
                // content: '/OA/MainPage.aspx'
                content: '<iframe src="Desktop.aspx" width="100%" height="100%" frameborder=0></iframe>'
            });
       }

	$(document).ready(function () {
	    zTreeObj = $.fn.zTree.init($("#tree"), setting, menu);
        mainpage();
        if(DJStatu=="1")
        {
            $("#DJ").css("display","none");
        }
        
	});
    function DJ()
    {
        url='/kaoqing/ShangXiabanDengJi.aspx';
        addTab('个人考勤',url);
    };
    function AlterPWD()
    {
        $("#password_win").window("open");
    }
    function checkTime(i)
    {
        if (i<10) 
            {i="0" + i}
        return i
    }

    var regEx = new RegExp("\\-","gi");
    var datestr='<%=DateTime.Now.ToString() %>'.replace(regEx,"/");
    var date=new Date(datestr);
    </script>
    
    
    <style type="text/css">
        #mylink a:hover{color:Black;}
    </style>
</head>
   <body class="easyui-layout" style="overflow-y: hidden"  scroll="no" onload="setInterval(nowtime,1000)">
<noscript>
<div style=" position:absolute; z-index:100000; height:2046px;top:0px;left:0px; width:100%; background:white; text-align:center;">
    <img src="../images/noscript.gif" alt='抱歉，请开启脚本支持！' />
</div></noscript>
    <div region="north" split="false" border="false" style="overflow: hidden; height: 50px;
        background: url(images/logo_bj.jpg) #7f99be repeat-x center 50%;
        line-height: 50px;color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <div style="float:left;"><img alt="" border="0" src="images/logo.jpg" /></div>
        
        <div id="mylink" style="float:right; padding-right:20px; vertical-align:middle;" class="head">
        <div style="float:left">
        <script language="JavaScript">
            today = date; //new Date('<%=DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") %>');
            function initArray() {
                this.length = initArray.arguments.length
                for (var i = 0; i < this.length; i++)
                    this[i + 1] = initArray.arguments[i]
            }
            var d = new initArray(
     "星期日",
     "星期一",
     "星期二",
     "星期三",
     "星期四",
     "星期五",
     "星期六");
            document.write(
     ' <span id="t2" style=" color:White;">',
     (today.getYear() < 1900) ? (1900 + today.getYear()) : today.getYear(), "年",
     today.getMonth() + 1, "月",
     today.getDate(), "日   ",
     d[today.getDay() + 1],
     ""); 
                                </script>
&nbsp;<img align="absMiddle" src="../images/time.gif" />
                                <span id="t1" style="color: White;">

                                    <script language="javascript" type="text/javascript">                                        todaytime1 = date; // new Date('<%=DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") %>'); 
                                    t1.innerText = checkTime(todaytime1.getHours()) + '：' + checkTime(todaytime1.getMinutes()) + '：' + checkTime(todaytime1.getSeconds());</script>

                                </span>&nbsp;&nbsp;

                                <script language="javascript" type="text/javascript">
                                    function nowtime() {
//                                        var regEx = new RegExp("\\-", "gi");
//                                        var datestr = '<%=DateTime.Now.ToString() %>'.replace(regEx, "/");
//                                        var date = new Date(datestr);
                                        todaytime = date; //new Date('<%=DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") %>');
                                        todaytime.setSeconds(todaytime.getSeconds() + 1);
                                        t1.innerText =checkTime(todaytime.getHours()) + '：' + checkTime(todaytime.getMinutes()) + '：' + checkTime(todaytime.getSeconds())
                                    }
                                </script>
        </div>

        <div style="float:left; margin-top:15px;"><img border="0" width="20" height="20" src="images/user_group.gif" /></div>&nbsp; 您好， <b><%=buModel.Name %></b>
        <a href="#" id="DJ" style=" color:White;" class="easyui-linkbutton " onclick="DJ()" data-options="plain:true">上下班登记</a>
        <a href="#" id="editpass" style=" color:White; " class="easyui-linkbutton" data-options="plain:true" onclick="AlterPWD()" >修改密码</a>
        <a href="Relogin.aspx" target="_top" style=" color:White;"  class="easyui-linkbutton" data-options="plain:true" onclick="if (!window.confirm('您确认要注消当前登录用户吗？')){return false;}">注销</a>
        <a href="Logout.aspx" id="loginOut" style=" color:White;"  class="easyui-linkbutton" data-options="plain:true" onclick="if (!window.confirm('您确认要退出吗？')){return false;}">安全退出</a></div>
        <span style="padding-left:10px; font-size: 16px; "><%--<img src="images/blocks.gif" width="20" height="20" align="absmiddle" /> 我的帐本--%></span>
    </div>
    <div region="south" split="true" style="height: 30px; background: #D2E0F2; ">
        <div class="footer"></div>
    </div>
    <div region="west" split="true" title="导航菜单" style="width:180px;" id="west">
<%--<div class="easyui-accordion" fit="true" border="false">--%>
		<!--  导航内容 -->
			<%--<ul id="tree" class="ztree" style="width:260px; overflow:auto;"></ul>	--%>
            <div class="zTreeDemoBackground left">
		<ul id="tree" class="ztree"></ul>
	    </div>
			<%--</div>--%>

    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow-y:hidden">
        <div id="tabs" class="easyui-tabs"  fit="true" border="false" >
			<div title="欢迎使用" style="padding:10px;overflow:hidden;" id="home">
            <%if (showMainPage)
              { %>
			<div id="mainpage"></div>
            <%}
              else
              { %>
			<h1>欢迎光临梓人环境管理系统！</h1>
            <%} %>

			</div>
		</div>
    </div>

    <div id="mm" class="easyui-menu" style="width:150px;">
		<div id="mm-tabclose">关闭</div>
		<div id="mm-tabcloseall">全部关闭</div>
		<div id="mm-tabcloseother">除此之外全部关闭</div>
		<div class="menu-sep"></div>
		<div id="mm-tabcloseright">当前页右侧全部关闭</div>
		<div id="mm-tabcloseleft">当前页左侧全部关闭</div>
		<div class="menu-sep"></div>
		<div id="mm-exit">退出</div>
	</div>
    <div id="pwd" style="display:none">
        <User:UserPWD  ID="UserPWD" runat="server"/>
    </div>
</body>
</html>
