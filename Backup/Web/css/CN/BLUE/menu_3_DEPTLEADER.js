    var SubImg = '/htoa/image/comm/BLUE/menu/menu_arrow_close.gif';
    var SubImgOpen = '/htoa/image/comm/BLUE/menu/menu_arrow_open.gif';


function writeMenu(menuFlg) {
    if (menuFlg == false) return;
document.write('<ul id=MenuUl name=oa>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC20001 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC20001.gif"> 个人办公</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC20001d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20002 onclick=subMenuClick(this);><img id=MEMU_FUNC20002_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 短消息</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20002d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20003 onclick=\'actionPage("actOasp3101", "发送短消息", "desktop");\' class=level3Head>发送短消息</li>');
document.write('					<li  id=MEMU_FUNC20004 onclick=\'actionPage("Oasp3102", "已发短消息", "desktop");\' class=level33>已发短消息</li>');
document.write('					<li  id=MEMU_FUNC20005 onclick=\'actionPage("Oasp3103", "已收短消息", "desktop");\' class=level33>已收短消息</li>');
document.write('					<li  id=MEMU_FUNC20006 onclick=\'actionPage("actOasp0402_1", "短消息收藏", "desktop");\' class=level33>短消息收藏</li>');
document.write('					<li  id=MEMU_FUNC200070 onclick=\'actionPage("Oasp3106", "消息草稿箱", "desktop");\' class=level32>消息草稿箱</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20009 onclick=subMenuClick(this);><img id=MEMU_FUNC20009_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 文件传送</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20009d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20010 onclick=\'actionPage("actOasp3001", "发送文件", "desktop");\' class=level3Head>发送文件</li>');
document.write('					<li  id=MEMU_FUNC20011 onclick=\'actionPage("Oasp3002", "已发文件", "desktop");\' class=level33>已发文件</li>');
document.write('					<li  id=MEMU_FUNC20012 onclick=\'actionPage("Oasp3003", "已收文件", "desktop");\' class=level33>已收文件</li>');
document.write('					<li  id=MEMU_FUNC20013 onclick=\'actionPage("actOasp0402_6", "文件收藏", "desktop");\' class=level33>文件收藏</li>');
document.write('					<li  id=MEMU_FUNC200071 onclick=\'actionPage("Oasp3006", "文件草稿箱", "desktop");\' class=level32>文件草稿箱</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20051 onclick=\'actionPage("Oasp3301", "个人文件柜", "desktop");\'><img id=MEMU_FUNC20051_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 个人文件柜</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2006000 onclick=subMenuClick(this);><img id=MEMU_FUNC2006000_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 我的审批</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC2006000d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20060 onclick=\'actionPage("Oasp9005", "我的申请", "desktop");\' class=level3Head>我的申请</li>');
document.write('					<li  id=MEMU_FUNC200937002 onclick=\'actionPage("Oasp9006", "待我审批", "desktop");\' class=level33>待我审批</li>');
document.write('					<li  id=MEMU_FUNC200937003 onclick=\'actionPage("Oasp9007", "经我审批", "desktop");\' class=level33>经我审批</li>');
document.write('					<li  id=MEMU_FUNC200937004 onclick=\'actionPage("Oasp9014", "待我阅读", "desktop");\' class=level32>待我阅读</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20206 onclick=subMenuClick(this);><img id=MEMU_FUNC20206_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 个人邮件</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20206d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20207 onclick=\'actionPage("actOasp0805_22", "个人邮件箱", "desktop");\' class=level3Head>个人邮件箱</li>');
document.write('					<li  id=MEMU_FUNC20208 onclick=\'actionPage("actOasp0804_2", "发邮件", "desktop");\' class=level33>发邮件</li>');
document.write('					<li  id=MEMU_FUNC20209 onclick=\'actionPage("actOasp0805_2", "收邮件", "desktop");\' class=level33>收邮件</li>');
document.write('					<li  id=MEMU_FUNC20210 onclick=\'actionPage("actOasp0807_2", "个人邮件箱管理", "desktop");\' class=level33>个人邮件箱管理</li>');
document.write('					<li  id=MEMU_FUNC20212 onclick=\'actionPage("Oasp0801", "个人邮件账号", "desktop");\' class=level33>个人邮件账号</li>');
document.write('					<li  id=MEMU_FUNC20213 onclick=\'actionPage("actOasp0810_2", "个人邮件签名", "desktop");\' class=level32>个人邮件签名</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20025 onclick=subMenuClick(this);><img id=MEMU_FUNC20025_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 通讯录</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20025d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20026 onclick=\'actionPage("actOasp0303_2", "公司通讯录", "desktop");\' class=level3Head>公司通讯录</li>');
document.write('					<li  id=MEMU_FUNC20027 onclick=\'actionPage("actOasp0303_1", "个人通讯录", "desktop");\' class=level33>个人通讯录</li>');
document.write('					<li  id=MEMU_FUNC20028 onclick=\'actionPage("actOasp0303_0", "公共通讯录", "desktop");\' class=level32>公共通讯录</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20076 onclick=subMenuClick(this);><img id=MEMU_FUNC20076_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 实用工具</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20076d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20076001 onclick=\'actionPage("actOasp2108Link", "公司网站", "desktop");\' class=level3Head>公司网站</li>');
document.write('					<li  id=MEMU_FUNC20008 onclick=\'actionPage("actOasp2102Link", "火车时刻", "desktop");\' class=level33>火车时刻</li>');
document.write('					<li  id=MEMU_FUNC20014 onclick=\'actionPage("actOasp2103Link", "飞机航班", "desktop");\' class=level33>飞机航班</li>');
document.write('					<li  id=MEMU_FUNC20015 onclick=\'actionPage("actOasp2104Link", "邮编/区号", "desktop");\' class=level33>邮编/区号</li>');
document.write('					<li  id=MEMU_FUNC20018 onclick=\'actionPage("actOasp2105Link", "国际时间", "desktop");\' class=level32>国际时间</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('		</ul>');
document.write('	</li>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC220000 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC220000.gif"> 日程计划</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC220000d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20090 onclick=subMenuClick(this);><img id=MEMU_FUNC20090_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 工作日程</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20090d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20023 onclick=\'actionPage("actOasp1001", "我的工作日程", "desktop");\' class=level3Head>我的工作日程</li>');
document.write('					<li  id=MEMU_FUNC20058 onclick=\'actionPage("actOasp1004", "他人工作日程", "desktop");\' class=level33>他人工作日程</li>');
document.write('					<li  id=MEMU_FUNC20091 onclick=\'actionPage("Oasp1011", "周期日程浏览", "desktop");\' class=level32>周期日程浏览</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20022 onclick=\'actionPage("Oasp1401", "工作日记", "desktop");\'><img id=MEMU_FUNC20022_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 工作日记</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20024 onclick=\'actionPage("Oasp2501", "工作计划", "desktop");\'><img id=MEMU_FUNC20024_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 工作计划</div>');
document.write('		</ul>');
document.write('	</li>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC20029 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC20029.gif"> 信息发布</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC20029d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20046 onclick=subMenuClick(this);><img id=MEMU_FUNC20046_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 新闻</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20046d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20049 onclick=\'actionPage("Oasp2903", "已收新闻", "desktop");\' class=level3Head>已收新闻</li>');
document.write('					<li  id=MEMU_FUNC20050 onclick=\'actionPage("actOasp0402_3", "新闻收藏", "desktop");\' class=level32>新闻收藏</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC200052 onclick=subMenuClick(this);><img id=MEMU_FUNC200052_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 图片新闻</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC200052d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20005203 onclick=\'actionPage("Oasp5203", "已收新闻", "desktop");\' class=level3Head>已收新闻</li>');
document.write('					<li  id=MEMU_FUNC20005206 onclick=\'actionPage("actOasp0402_9", "新闻收藏", "desktop");\' class=level32>新闻收藏</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20038 onclick=subMenuClick(this);><img id=MEMU_FUNC20038_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 公告</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20038d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20041 onclick=\'actionPage("Oasp2803", "已收公告", "desktop");\' class=level3Head>已收公告</li>');
document.write('					<li  id=MEMU_FUNC20042 onclick=\'actionPage("actOasp0402_4", "公告收藏", "desktop");\' class=level32>公告收藏</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20030 onclick=subMenuClick(this);><img id=MEMU_FUNC20030_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 通知</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20030d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20033 onclick=\'actionPage("Oasp0201", "已收通知", "desktop");\' class=level3Head>已收通知</li>');
document.write('					<li  id=MEMU_FUNC20034 onclick=\'actionPage("actOasp0402_2", "通知收藏", "desktop");\' class=level32>通知收藏</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20043001 onclick=subMenuClick(this);><img id=MEMU_FUNC20043001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 部门主页</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20043001d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20043002 onclick=\'actionPage("Oasp4301", "部门主页浏览", "desktop");\' class=level3Head>部门主页浏览</li>');
document.write('					<li  id=MEMU_FUNC20043003 onclick=\'actionPage("Oasp4312", "部门主页维护", "desktop");\' class=level32>部门主页维护</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20055 onclick=\'actionPage("Oasp2401", "大事记", "desktop");\'><img id=MEMU_FUNC20055_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 大事记</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20062000 onclick=subMenuClick(this);><img id=MEMU_FUNC20062000_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 公司相册</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20062000d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC200620001 onclick=\'actionPage("Oasp6207", "相册浏览", "desktop");\' class=level32>相册浏览</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('		</ul>');
document.write('	</li>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC51000 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC51000.gif"> 任务管理</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC51000d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC5100001 onclick=\'actionPage("Oasp5164", "我的全部任务", "desktop");\'><img id=MEMU_FUNC5100001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 我的全部任务</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC5100002 onclick=\'actionPage("actOasp5162_1", "我分配的任务", "desktop");\'><img id=MEMU_FUNC5100002_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 我分配的任务</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC5100003 onclick=\'actionPage("actOasp5162_2", "我执行的任务", "desktop");\'><img id=MEMU_FUNC5100003_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 我执行的任务</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC5100004 onclick=\'actionPage("Oasp5173", "我参阅的任务", "desktop");\'><img id=MEMU_FUNC5100004_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 我参阅的任务</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC5100005 onclick=\'actionPage("Oasp5163", "下级任务", "desktop");\'><img id=MEMU_FUNC5100005_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 下级任务</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC5100006 onclick=\'actionPage("Oasp5152", "新建任务", "desktop");\'><img id=MEMU_FUNC5100006_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 新建任务</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC5100007 onclick=\'actionPage("Oasp5175", "新建简单任务", "desktop");\'><img id=MEMU_FUNC5100007_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 新建简单任务</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC5100009 onclick=subMenuClick(this);><img id=MEMU_FUNC5100009_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 任务日志</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC5100009d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC510000901 onclick=\'actionPage("Oasp5167", "我的任务日志", "desktop");\' class=level3Head>我的任务日志</li>');
document.write('					<li  id=MEMU_FUNC510000902 onclick=\'actionPage("actOasp5167_1", "下级任务日志", "desktop");\' class=level32>下级任务日志</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC5100010 onclick=subMenuClick(this);><img id=MEMU_FUNC5100010_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 绩效统计</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC5100010d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC510001002 onclick=\'actionPage("REPORT_TASK_DEPT_QUERY", "各部门任务查询", "desktop");\' class=level3Head>各部门任务查询</li>');
document.write('					<li  id=MEMU_FUNC510001003 onclick=\'actionPage("REPORT_TASK_DEPT_MARK", "各部门任务绩效", "desktop");\' class=level33>各部门任务绩效</li>');
document.write('					<li  id=MEMU_FUNC510001004 onclick=\'actionPage("REPORT_TASK_DEPT_MONTH", "各部门本月报表", "desktop");\' class=level33>各部门本月报表</li>');
document.write('					<li  id=MEMU_FUNC510001005 onclick=\'actionPage("REPORT_TASK_DEPT_PLAN", "部门下月计划", "desktop");\' class=level33>部门下月计划</li>');
document.write('					<li  id=MEMU_FUNC510001006 onclick=\'actionPage("REPORT_TASK_USER_MONTH", "本人本月报表", "desktop");\' class=level33>本人本月报表</li>');
document.write('					<li  id=MEMU_FUNC510001007 onclick=\'actionPage("REPORT_TASK_USER_PLAN", "本人下月计划", "desktop");\' class=level32>本人下月计划</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('		</ul>');
document.write('	</li>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC20057 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC20057.gif"> 审批流转</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC20057d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20059 onclick=\'actionPage("Oasp9002", "起草申请", "desktop");\'><img id=MEMU_FUNC20059_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 起草申请</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009005001 onclick=\'actionPage("actOasp9005_1", "我的申请", "desktop");\'><img id=MEMU_FUNC2009005001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 我的申请</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009006001 onclick=\'actionPage("actOasp9006_1", "待我审批", "desktop");\'><img id=MEMU_FUNC2009006001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 待我审批</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009007001 onclick=\'actionPage("actOasp9007_1", "经我审批", "desktop");\'><img id=MEMU_FUNC2009007001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 经我审批</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009014001 onclick=\'actionPage("actOasp9014_1", "待我阅读", "desktop");\'><img id=MEMU_FUNC2009014001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 待我阅读</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009401000 onclick=\'actionPage("actOasp9401_0", "审批数据查询", "desktop");\'><img id=MEMU_FUNC2009401000_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 审批数据查询</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009407000 onclick=\'actionPage("actOasp9407", "审批报表查询", "desktop");\'><img id=MEMU_FUNC2009407000_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 审批报表查询</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009028001 onclick=\'actionPage("Oasp9028", "代理申请", "desktop");\'><img id=MEMU_FUNC2009028001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 代理申请</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20941000 onclick=\'actionPage("Oasp9120", "审批委托设置", "desktop");\'><img id=MEMU_FUNC20941000_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 审批委托设置</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20941001 onclick=\'actionPage("Oasp9122", "申请代理设置", "desktop");\'><img id=MEMU_FUNC20941001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 申请代理设置</div>');
document.write('		</ul>');
document.write('	</li>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC20088 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC20088.gif"> 公文发文</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC20088d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20089 onclick=\'actionPage("Oasp9610", "发文拟稿", "desktop");\'><img id=MEMU_FUNC20089_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 发文拟稿</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009004002 onclick=\'actionPage("Oasp9651", "代理发文", "desktop");\'><img id=MEMU_FUNC2009004002_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 代理发文</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009005002 onclick=\'actionPage("actOasp9005_2", "我的申请", "desktop");\'><img id=MEMU_FUNC2009005002_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 我的申请</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009006002 onclick=\'actionPage("actOasp9006_2", "待我审批", "desktop");\'><img id=MEMU_FUNC2009006002_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 待我审批</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009007002 onclick=\'actionPage("actOasp9007_2", "经我审批", "desktop");\'><img id=MEMU_FUNC2009007002_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 经我审批</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009014002 onclick=\'actionPage("actOasp9014_2", "待我阅读", "desktop");\'><img id=MEMU_FUNC2009014002_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 待我阅读</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009636 onclick=\'actionPage("actOasp9636_2", "挂网文件", "desktop");\'><img id=MEMU_FUNC2009636_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 挂网文件</div>');
document.write('		</ul>');
document.write('	</li>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC55000 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC55000.gif"> 公文收文</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC55000d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC55001 onclick=\'actionPage("Oasp9710", "收文登记", "desktop");\'><img id=MEMU_FUNC55001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 收文登记</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC55003 onclick=\'actionPage("Oasp9740", "代理收文", "desktop");\'><img id=MEMU_FUNC55003_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 代理收文</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009005003 onclick=\'actionPage("actOasp9005_3", "我的申请", "desktop");\'><img id=MEMU_FUNC2009005003_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 我的申请</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009006003 onclick=\'actionPage("actOasp9006_3", "待我审批", "desktop");\'><img id=MEMU_FUNC2009006003_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 待我审批</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009007003 onclick=\'actionPage("actOasp9007_3", "经我审批", "desktop");\'><img id=MEMU_FUNC2009007003_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 经我审批</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2009014003 onclick=\'actionPage("actOasp9014_3", "待我阅读", "desktop");\'><img id=MEMU_FUNC2009014003_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 待我阅读</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC55011 onclick=\'actionPage("actOasp9636_3", "挂网文件", "desktop");\'><img id=MEMU_FUNC55011_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 挂网文件</div>');
document.write('		</ul>');
document.write('	</li>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC20064 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC20064.gif"> 网上交流</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC20064d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20065 onclick=\'actionPage("Oasp0601", "论坛", "desktop");\'><img id=MEMU_FUNC20065_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 论坛</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20066 onclick=\'actionPage("Oasp0701", "投票", "desktop");\'><img id=MEMU_FUNC20066_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 投票</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC200610 onclick=\'actionPage("Oasp2330", "视频会议", "desktop");\'><img id=MEMU_FUNC200610_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 视频会议</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20045001 onclick=subMenuClick(this);><img id=MEMU_FUNC20045001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 领导信箱</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20045001d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC20045002 onclick=\'actionPage("actOasp4501_0", "提交信件", "desktop");\' class=level32>提交信件</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('		</ul>');
document.write('	</li>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC235000 onclick=\'actionPage("Oasp3501", "报表中心", "desktop");\'><img class=Icon src="/htoa/image/comm/menu_ico/FUNC235000.gif"> 报表中心</div>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC20400 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC20082.gif"> 文档中心</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC20400d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20056 onclick=\'actionPage("Oasp0501", "知识管理", "desktop");\'><img id=MEMU_FUNC20056_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 知识管理</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20007 onclick=\'actionPage("Oasp2001", "下载中心", "desktop");\'><img id=MEMU_FUNC20007_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 下载中心</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20069 onclick=\'actionPage("Oasp2701", "规章制度", "desktop");\'><img id=MEMU_FUNC20069_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 规章制度</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20054 onclick=\'actionPage("Oasp2601", "电子期刊", "desktop");\'><img id=MEMU_FUNC20054_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 电子期刊</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC249000 onclick=\'actionPage("Oasp4915", "网络硬盘", "desktop");\'><img id=MEMU_FUNC249000_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 网络硬盘</div>');
document.write('		</ul>');
document.write('	</li>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC21900 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC21900.gif"> 会议管理</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC21900d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20071 onclick=subMenuClick(this);><img id=MEMU_FUNC20071_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 我的会议</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC20071d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC2007101 onclick=\'actionPage("Oasp1904", "会议发起", "desktop");\' class=level3Head>会议发起</li>');
document.write('					<li  id=MEMU_FUNC2007103 onclick=\'actionPage("actOasp1903_1", "待开会议", "desktop");\' class=level33>待开会议</li>');
document.write('					<li  id=MEMU_FUNC2007104 onclick=\'actionPage("actOasp1903_2", "已开会议", "desktop");\' class=level33>已开会议</li>');
document.write('					<li  id=MEMU_FUNC20071ZHH05 onclick=\'actionPage("Oasp1929", "我的预定", "desktop");\' class=level33>我的预定</li>');
document.write('					<li  id=MEMU_FUNC20071HQ06 onclick=\'actionPage("actOasp1925_MY", "我的发起", "desktop");\' class=level32>我的发起</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2007106 onclick=\'actionPage("Oasp1907", "会议纪要", "desktop");\'><img id=MEMU_FUNC2007106_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 会议纪要</div>');
document.write('		</ul>');
document.write('	</li>');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC20077 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC20077.gif"> 个人设置</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC20077d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20078 onclick=\'actionPage("actOasp1205", "个人信息", "desktop");\'><img id=MEMU_FUNC20078_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 个人信息</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20079 onclick=\'actionPage("actOasp1206", "密码修改", "desktop");\'><img id=MEMU_FUNC20079_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 密码修改</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20080 onclick=\'actionPage("Oasp1207", "桌面设置", "desktop");\'><img id=MEMU_FUNC20080_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 桌面设置</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2002336 onclick=\'actionPage("Oasp2336", "天气预报设置", "desktop");\'><img id=MEMU_FUNC2002336_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 天气预报设置</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC212190 onclick=\'actionPage("Oasp1219", "快捷方式", "desktop");\'><img id=MEMU_FUNC212190_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 快捷方式</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20045 onclick=\'actionPage("Oasp1213", "个人网址收藏", "desktop");\'><img id=MEMU_FUNC20045_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 个人网址收藏</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC20052 onclick=\'actionPage("actOasp1211_1", "个人通讯组", "desktop");\'><img id=MEMU_FUNC20052_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 个人通讯组</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2007701 onclick=\'actionPage("Oasp9109", "快速意见设置", "desktop");\'><img id=MEMU_FUNC2007701_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 快速意见设置</div>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC2002328 onclick=\'actionPage("Oasp2328", "个人安全日志", "desktop");\'><img id=MEMU_FUNC2002328_img src="/htoa/image/comm/BLUE/menu/menu_arrow_single.gif"> 个人安全日志</div>');
document.write('		</ul>');
document.write('	</li>');
document.write('</ul>');
document.write('<ul id=MenuUl name=hr style="display:none">');
document.write('	<li class=level1><div class=level1Style id=MEMU_FUNC200969 onclick=menuClick(this);><img class=Icon src="/htoa/image/comm/menu_ico/FUNC254001.gif"> 部门工作</div>');
document.write('		<ul class=MenuLevel2 id=MEMU_FUNC200969d style="DISPLAY: none">');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC200969001 onclick=subMenuClick(this);><img id=MEMU_FUNC200969001_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 员工考勤</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC200969001d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC200969002 onclick=\'actionPage("actOasp5359", "考勤结果汇总表", "desktop");\' class=level3Head>考勤结果汇总表</li>');
document.write('					<li  id=MEMU_FUNC200969003 onclick=\'actionPage("Oasp5380_2", "考勤记录报表", "desktop");\' class=level33>考勤记录报表</li>');
document.write('					<li  id=MEMU_FUNC200969004 onclick=\'actionPage("Oasp5339_2", "考勤异常报表", "desktop");\' class=level33>考勤异常报表</li>');
document.write('					<li  id=MEMU_FUNC200969005 onclick=\'actionPage("Oasp5338_2", "员工加班报告", "desktop");\' class=level33>员工加班报告</li>');
document.write('					<li  id=MEMU_FUNC200969006 onclick=\'actionPage("Oasp5364_2", "员工年假报告", "desktop");\' class=level32>员工年假报告</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('			<li class=level2><div class=level2Style id=MEMU_FUNC200969011 onclick=subMenuClick(this);><img id=MEMU_FUNC200969011_img src="/htoa/image/comm/BLUE/menu/menu_arrow_close.gif"> 报表分析</div>');
document.write('				<ul class=MenuLevel2 id=MEMU_FUNC200969011d style="DISPLAY: none">');
document.write('					<li  id=MEMU_FUNC200969012 onclick=\'actionPage("actOasp5360", "员工结构总揽", "desktop");\' class=level3Head>员工结构总揽</li>');
document.write('					<li  id=MEMU_FUNC200969013 onclick=\'actionPage("actOasp5441_1", "部门员工报表", "desktop");\' class=level33>部门员工报表</li>');
document.write('					<li  id=MEMU_FUNC200969014 onclick=\'actionPage("actOasp5441_2", "岗位员工报表", "desktop");\' class=level32>岗位员工报表</li>');
document.write('				</ul>');
document.write('			</li>');
document.write('		</ul>');
document.write('	</li>');
document.write('</ul>');
}