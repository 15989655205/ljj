<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="KaoQinRdlc.aspx.cs" Inherits="Maticsoft.Web.kaoqing.KaoQinRdlc" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
function btn_search() {
        $("#search").click();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
<div style="display:none">
    <asp:Button ID="search" runat="server" onclick="search_Click" ClientIDMode="Static" />
</div>
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
        </asp:ScriptManager>
        <div id="toolbarDIV" style="height:0px">
    <%--<tool:ToolBar ID="tool"  Exportshow="1" Printshow="1" ASearchshow="1" runat="server" />--%>
    <div id="st" style="padding:5px;height:auto">
         姓名：<input type="text" id="SUName" runat="server" />
         工号：<input type="text" id="SWID" runat="server" />
        日期：<input id="startTime" runat="server" class="easyui-datebox" style="width:80px"/>
			至: <input id="endTime" runat="server" class="easyui-datebox" style="width:80px"/>

         状态：<select runat="server" id="select_status"  style="width: 70px">
                <option value=""> </option>
                <option value="1">正常</option>
                <option value="2">迟到</option>
                <option value="3">早退</option>
                <option value="4">未登记</option>
            </select>
            <a href="#" class="easyui-linkbutton" iconCls="icon-search" onclick="btn_search();return false;">查询</a>
    </div>
    
        <div style="height:400px;word-break:break-all;">
    </div> </div>
</form>
</asp:Content>
