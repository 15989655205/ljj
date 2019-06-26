<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Form_IDE.aspx.cs" Inherits="Maticsoft.Web.Flow.Form_IDE" %>
<%@ Register Src="../Controls/Flow/Form_IDE.ascx" TagName="Form_ide" TagPrefix="form_ide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form_ide:Form_ide ID="company_ide" runat="server"></form_ide:Form_ide>
</asp:Content>
