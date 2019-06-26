<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintC.aspx.cs" Inherits="Maticsoft.Web.Project.Material.PrintC" %>

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
    <table class="printinnertable" cellpadding="0" cellspacing="0" style="width:420mm;height:100%;" >
            <tr>
                <td colspan="6" style="height: 25px; font-size:larger; text-align:center;" >
                    材料C表-<%= productTypeName %>
                </td>
                <td colspan="2" style="height: 25px; font-size:larger;" >
                    PROJECT 项目：<%=projectName %>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="left"  style="height: 25px;  " >
                    SAMPLEPHOTOGRAPH 样品/图片
                </td>
                <td align="left" colspan="2" style="height: 25px;  ">
                    Supplier Contact 供应商：<%=supplierName %>
                </td>
            </tr>
             <tr>
                <td colspan="6" rowspan="15" align="center"  style="">
                    <img style="max-hight:400px; max-width:600px;" src="/ProductPic/<%=productPic %>" />
                </td>
                <td align="left" colspan="2" style="height: 25px;">
                    Contact To 联系人：<%=supplierContact %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Address 地址：<%=supplierAddress %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Telephone Number 电话：<%=supplierMobile %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Description：<%=description %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    品牌：<%=brand %>
                    <br />
                    型号：<%=model %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Measurement 尺寸(mm)：<%=size %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Length 长：<%=length %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Width 宽：<%=width %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Height 高：<%=height %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Thickness 厚：<%=thickness %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Seat-Height 座高：<%=seatHeight %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Seat-Height 座深：<%=seatDeep %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Finish/Sample 饰面/样板：<%=sample %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px;  "  class="">
                    Remarks 备注：<%=remark %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 125px;  "  class="">
                    
                </td>
            </tr>
             <tr class="">
                <td colspan="6" align="center"  style="height: 25px;  " >
                    本规格说明及颜色仅供参考
                </td>
                <td align="center" colspan="1" rowspan="4" style="width:8%;">
                    DRAWING AREA<br />图纸区域
                </td>
                <td align="left" colspan="1" rowspan="4" style="width:24%;">
                   <%=drawingArea %>
                </td>
            </tr>
            <tr class="">
                <td colspan="1"  style="height: 25px; width:16%;" >
                    TAB BY   制表人
                </td>
                <td colspan="1"  style="height: 25px; width:8%;" >
                    <%=tabby %>
                </td>
                <td colspan="1" align="center" rowspan="2"  style="height: 25px; width:8%;" >
                    NAME 名称
                </td>
                <td align="center" colspan="1" rowspan="2" style="width:16%;">
                    <%=productName %>
                </td>
                <td align="center" colspan="1" rowspan="2" style="width:8%;">
                   MATERIAL NO<br />材料编号
                </td>
                <td align="center" colspan="1" rowspan="2" style="width:16%;">
                    <%=materialNo%>
                </td>
            </tr>
            <tr class="">
                <td colspan="1"  style="height: 25px;  " >
                    DRAWING BY   制图人
                </td>
                <td colspan="1"  style="height: 25px;  " >
                    <%=drawingby %>
                </td>
            </tr>
            <tr class="">
                <td colspan="1"  style="height: 25px;  " >
                    SPECIFIED BY   审核人
                </td>
                <td colspan="1"  style="height: 25px;  " >
                    <%=specifiedby %>
                </td>
                <td colspan="1" align="center" rowspan="2"  style="height: 25px;  " >
                    DRAWING NO <br /> 图纸编号
                </td>
                <td align="center" colspan="3" rowspan="2" style="">
                    <%=drawingNo %>
                </td>
            </tr>
            <tr class="">
                <td colspan="1"  style="height: 25px;  " >
                    APPROVED BY   校核人
                </td>
                <td colspan="1"  style="height: 25px;  " >
                    <%=approvedby %>
                </td>
                <td align="center">DATE 日期</td>
                <td><%=date %></td>
            </tr>
         </table>
</body>
</html>
