<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintProjectStat.aspx.cs" Inherits="Maticsoft.Web.Project.PrintProjectStat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <style type="text/css" media="print">  
.noprint{display : none }  
</style>
    <link href="../css/default.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../js/outlook2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <div id="h" align="center" class="noprint">
    <input onclick="javascript:window.print();" type="button" value="打印" />
    <input onclick="javascript:window.close();" type="button" value="关闭" />
</div>
<%--<table style="width:420mm " border="0" class="printtable" cellpadding="0" cellspacing="0">
            <tr >
<td align="left"  colspan="2" style="height: 25px; background-color: #ffffff;">--%>
<div><span>信息</span></div>
<div>
<%=Str %></div>
<div  style=" margin-top:5px;"><span>统计</span></div>
<div>
<%=statStr %></div>

                <%=trStr.Trim() %>
<%--                </td>
            </tr>
         </table>--%>
    </form>
</body>
</html>
