<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintProject.aspx.cs" Inherits="Maticsoft.Web.Project111.PrintProject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
   <style type="text/css" media=print>  
.noprint{display : none }  
</style>
    <link href="../css/default.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
  
        <input id="btnPrint" type="button" value="打印" class="noprint" onclick="javascript:window.print();" />  
 
<div>
<%--<input id="btnPrint" type="button" value="打印预览" onclick=preview(1) />  --%>
    <table style="width:420mm " border="0" class="printtable" cellpadding="0" cellspacing="0">
            <tr>
                <td align="right" colspan="2" style="height: 25px; text-align: center; font-size:larger;background-color: #ffffff;">
                    <strong>深圳梓人环境设计有限公司 设计部 项目进度计划监督表(<%=stageName%>)</strong>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px; background-color: #ffffff;">
                    <strong>一、项目基本情况 Ⅰ. Project Basic Info</strong>
                </td>
            </tr>
             <tr>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                项目名称 Project name：<%=pModel==null?"":pModel.project_name %>
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                项目编号 Project code：<%=pModel==null?"":pModel.project_code %>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                制作人 Prepared by：<%=pModel==null?"":pModel.prepared_by %>
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                进度监督人 Reviewed by：<%=pModel==null?"":pModel.reviewed_by %>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                项目负责人 Project manager：<%=pModel==null?"":pModel.project_manager %>
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                制作日期 Date：<%=pModel==null?"":pModel.creation_date %>
                </td>
            </tr>
            <tr>
                <td align="left"  colspan="2" style="height: 25px; background-color: #ffffff;">
                    <strong>二、项目进度表 Ⅱ. Project Schedule</strong>
                </td>
            </tr>
            <tr>
                <td align="left"  colspan="2" style="height: 25px; background-color: #ffffff;">
                <%=trStr %>
                </td>
            </tr>
         </table>
    </div>
    </form>
</body>
</html>
