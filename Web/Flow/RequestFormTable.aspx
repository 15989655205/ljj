<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true"
    CodeBehind="RequestFormTable.aspx.cs" Inherits="Maticsoft.Web.Flow.RequestFormTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/CN/BLUE/mainWin.css" rel="stylesheet" type="text/css" />
    <link href="../css/comm/BLUE/mainWin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <%for (int i = 0; i < pdt.Rows.Count; i++)
      {
          System.Data.DataTable sdt = comBll.GetList("select * from request_form a where status=1 and (select count(sid) from flow_master where rf_sid=a.sid and dept_sid like '%," + bu.DeptID + ",%' and post_sid like '%," + bu.ApprRole + ",%')>0 and rft_sid=" + pdt.Rows[i]["sid"].ToString().Trim()).Tables[0];//rfBLL.GetList("status=1 and rft_sid="+pdt.Rows[i]["sid"].ToString().Trim()).Tables[0]; 
          if (sdt.Rows.Count > 0)
          {%>
        <div class="ItemBlock_Title1">
            <img alt="" border="0" src="../images/comm/BLUE/item_point.gif" />
            <%= pdt.Rows[i]["type_name"].ToString().Trim()%>
        </div>
        <div class="ItemBlockBorder">
            <div class="ItemBlock" style="padding: 15px;">
               <%for (int j = 0; j < sdt.Rows.Count; j++)
                 { %>
                <div class="DetailBlock">
                    <a href="#" onclick="parent.addTab('发起【<%=sdt.Rows[j]["form_name"].ToString().Trim()%>】','/Flow/MyWork_IDE.aspx?rfsid=<%=sdt.Rows[j]["sid"].ToString()%>&action=add&url=<%=sdt.Rows[j]["url"].ToString() %>')"><img alt="" width="16" height="16" src="/images/comm/FileType/ie.gif" /><span onclick="" style="cursor: hand;"><%= sdt.Rows[j]["form_name"].ToString().Trim()%></span></a>
                </div>
                <%} %>
            </div>
        </div>
        <br />
        <%}
      } %>
    </center>
</asp:Content>
