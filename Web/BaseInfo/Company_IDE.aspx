<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Company_IDE.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Company_IDE" %>
<%@ Register Src="../Controls/BaseInfo/Company_IDE.ascx" TagName="Company" TagPrefix="company" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <company:Company ID="company_ide" runat="server"></company:Company>
</asp:Content>
