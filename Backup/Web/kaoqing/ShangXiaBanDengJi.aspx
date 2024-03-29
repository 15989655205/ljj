﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShangXiaBanDengJi.aspx.cs" Inherits="Maticsoft.Web.kaoqing.ShangXiaBanDengJi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
    <title>深度历险协同办公服务平台</title>
     <link href="../css/kaoqin.css" type="text/css" rel="STYLESHEET">

    <script language="javascript">
        function PrintTable() {
            document.getElementById("PrintHide").style.visibility = "hidden"
            print();
            document.getElementById("PrintHide").style.visibility = "visible"
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0" runat="server">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../images/BanKuaiJianTou.gif" />
                    上下班登记
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2" style="background-color: #ffffff">
                </td>
            </tr>
        </table>
        <table id="DJTable" runat="server" style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" style="width: 170px; background-color: #e1f5fc; height: 25px;">
                    <asp:Label ID="Label1" runat="server" Text="第一次登记："></asp:Label>
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                    &nbsp; &nbsp; &nbsp;登记类型：<asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="上班登记"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;规定时间：<asp:Label ID="Label3" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; 登记时间：<asp:Label ID="Label4"
                        runat="server" ForeColor="Blue">未登记</asp:Label>
                    <asp:Button ID="Button1" runat="server" CommandName="DengJiTime1" OnClick="Button1_Click"
                        Text="上班登记" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    <asp:Label ID="Label5" runat="server" Text="第二次登记："></asp:Label>
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    &nbsp; &nbsp; &nbsp;登记类型：<asp:Label ID="Label6" runat="server" ForeColor="Navy" Text="下班登记"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;规定时间：<asp:Label ID="Label7" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; 登记时间：<asp:Label ID="Label8"
                        runat="server" ForeColor="Blue">未登记</asp:Label>
                    <asp:Button ID="Button2" runat="server" CommandName="DengJiTime2" OnClick="Button1_Click"
                        Text="下班登记" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    <asp:Label ID="Label9" runat="server" Text="第三次登记："></asp:Label>
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    &nbsp; &nbsp; &nbsp;登记类型：<asp:Label ID="Label10" runat="server" ForeColor="Blue"
                        Text="上班登记"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;规定时间：<asp:Label ID="Label11" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; 登记时间：<asp:Label ID="Label12"
                        runat="server" ForeColor="Blue">未登记</asp:Label>
                    <asp:Button ID="Button3" runat="server" CommandName="DengJiTime3" OnClick="Button1_Click"
                        Text="上班登记" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    <asp:Label ID="Label13" runat="server" Text="第四次登记："></asp:Label>
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    &nbsp; &nbsp; &nbsp;登记类型：<asp:Label ID="Label14" runat="server" ForeColor="Navy"
                        Text="下班登记"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;规定时间：<asp:Label ID="Label15" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; 登记时间：<asp:Label ID="Label16"
                        runat="server" ForeColor="Blue">未登记</asp:Label>
                    <asp:Button ID="Button4" runat="server" CommandName="DengJiTime4" OnClick="Button1_Click"
                        Text="下班登记" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    <asp:Label ID="Label17" runat="server" Text="第五次登记："></asp:Label>
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    &nbsp; &nbsp; &nbsp;登记类型：<asp:Label ID="Label18" runat="server" ForeColor="Blue"
                        Text="上班登记"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;规定时间：<asp:Label ID="Label19" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; 登记时间：<asp:Label ID="Label20"
                        runat="server" ForeColor="Blue">未登记</asp:Label>
                    <asp:Button ID="Button5" runat="server" CommandName="DengJiTime5" OnClick="Button1_Click"
                        Text="上班登记" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    <asp:Label ID="Label21" runat="server" Text="第六次登记："></asp:Label>
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    &nbsp; &nbsp; &nbsp;登记类型：<asp:Label ID="Label22" runat="server" ForeColor="Navy"
                        Text="下班登记"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;规定时间：<asp:Label ID="Label23" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; 登记时间：<asp:Label ID="Label24"
                        runat="server" ForeColor="Blue">未登记</asp:Label>
                    <asp:Button ID="Button6" runat="server" CommandName="DengJiTime6" OnClick="Button1_Click"
                        Text="下班登记" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
