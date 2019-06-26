<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintB.aspx.cs" Inherits="Maticsoft.Web.Project.Material.PrintB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <style type="text/css" media="print">  
.noprint{display : none }  
* {
    padding:0px;
    margin:0px;
}

</style>
    <link href="/css/print.css" rel="stylesheet" type="text/css"/>
    <script src="/js/jquery.min.js" type="text/javascript"></script>
    <script src="/js/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="/js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="/js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/js/outlook2.js" type="text/javascript"></script>
</head>
<body>
    <div id="h" align="center" class="noprint">
    <input onclick="javascript:window.print();" type="button" value="打印" />
    <%--<input onclick="javascript:window.close();" type="button" value="关闭" />--%>
    <input onclick="javascript:window.open('','_self','');window.close();" type="button" value="关闭" />
</div>

 

<%--<input id="btnPrint" type="button" value="打印预览" onclick=preview(1) />  --%>
    <table class="printtableA" cellpadding="0" cellspacing="0" style="width:420mm;height:100%;" >
            <tr class="tr">
                <td colspan="2" style="height: 25px; "  class="td">
                    项目名称:<%=pname%>
                </td>
            </tr>
            <tr class="tr">
                <td align="left" colspan="2" style="height: 25px;  "  class="td">
                    档案编号:<%=fileNo%>
                </td>
            </tr>
             <tr class="tr">
                <td align="left" colspan="2" style="height: 25px;  "  class="td">
                    <div style="float:left;" >材料类别:<%=productType%></div>
                    <div style="float:right; font-size:larger"><strong>材料装饰分类汇总表B</strong></div>
                </td>
            </tr>
            <tr class="tr">
                <td align="left"  colspan="2" style="height:100%; ">
                <%=trStr.Trim() %>
                </td>
            </tr>
         </table>
</body>
</html>
