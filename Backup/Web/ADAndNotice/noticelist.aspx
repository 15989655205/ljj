<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="noticelist.aspx.cs" Inherits="Maticsoft.Web.ADAndNotice.noticelist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>深圳梓人环境设计管理系统</title>    
    <link href="/js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $('#tab_input_14').searchbox({ menu: "#search_menu", searcher: function (value, name) { qsearch(value, name); } });
            $('#tt').datagrid({
                url: '../Ashx/notice.ashx',
                queryParams: { "action": "list" },
                loadMsg: '正在努力加载中...',
                idField: 'id',
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                toolbar: "#div_top",
                fit: true,
                fitColumns: true,
                pagination: true,
                remoteSort: true,
                rownumbers: true,
                singleSelect: true,
                columns: [[
                    { title: '标题', field: 'title', width: 100, sortable: true,
                        formatter: function (value, row, rowIndex) {
                            return "<a href='#' onclick='view(" + rowIndex + ");'>" + value + "</a>";
                        }
                    },
                    { title: '概要', field: 'summary', width: 100, sortable: true },
                    { title: '创建人', field: 'create_name', width: 100, sortable: true },
                    { title: '创建时间', field: 'create_date', width: 100, sortable: true },
                    { title: '修改人', field: 'update_name', width: 100, sortable: true },
                    { title: '修改时间', field: 'update_date', width: 100, sortable: true }
		        ]]
            });
        });

        //快速搜索
        function qsearch(v) {
            $('#tt').datagrid('options').queryParams = { "action": "list", "key": v };
            $('#tt').datagrid('reload');
        }

        //查看
        function view(index) {          
            var row = $('#tt').datagrid('getRows')[index];
            window.open("/ADAndNotice/noticeview.aspx?id=" + row.id, row.title);
        }
    </script>

</head>    
<body style="margin:0;padding:0;">
    <noscript>
        <div style=" position:absolute; z-index:100000; height:2046px;top:0px;left:0px; width:100%; background:white; text-align:center;">
            <img src="../images/noscript.gif" alt='抱歉，请开启浏览器脚本支持！'/>
        </div>
    </noscript>
    <div id="div_top">
        <div style="height:50px;background:url(../images/logo_bj.jpg);line-height:50px;">
            <img alt="" src="../images/logo.jpg" style="float:left;"/>        
            <div style="float:right; ">
                <a href="/login.aspx" class="easyui-linkbutton" data-options="plain:true" style="color:White;" onclick="" >返回登录</a>
                <a href="#" class="easyui-linkbutton" data-options="plain:true"></a>        
            </div>
        </div>
        <div class="easyui-tabs" border="false" >
            <div title="公告浏览">
            </div>
        </div>
        <div id="tab_toolbar" style="padding: 0 2px;height:auto">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>  
                    <td style="padding-left: 2px; padding-top:4px; padding-bottom:2px; vertical-align:middle; ">
                        <div id="tab_div_14" style="float:left;>
                            <div style="float:left;"><a href="#" id="tab_a_14" class="easyui-linkbutton" plain="true" iconCls="icon-find">快速查询：</a></div>
                            <div style="float:left;"><input id="tab_input_14" /></div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <table id="tt"></table>  
</body>
</html>
