<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="RequestFormFlowList.aspx.cs" Inherits="Maticsoft.Web.Flow.RequestFormFlowList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="../js/datagrid-detailview.js" type="text/javascript"></script>
<script type="text/javascript">
 
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="margin-left:10px; margin-right:10px; margin-top:5px;">
<table class="oa_Flow_Tab">
      <tr>
      <td  class="adminTitle" style="width:10%; text-align:center;">
      选择
      </td>
      <td style="width:10%; text-align:center;" class="adminTitle">
      查看流程
      </td>
                <td style="text-align:center;" class="adminTitle">
                    流程名称
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    备注
                </td>
            </tr>
            <%for (int i = 0; i < dt.Rows.Count; i++)
              { %>
            <tr>
            <td style="text-align:center;" >
      <a href="<%=url %>?flow_sid=<%=dt.Rows[i]["sid"].ToString().Trim() %>&rf_sid=<%=rfsid %>">选择</a>
      </td>
      <td style="text-align:center;" >
      <a href="#" onclick="window.open ('ShowFlowNode.aspx?flow_sid=<%=dt.Rows[i]["sid"].ToString().Trim() %>') ">查看</a>
      </td>
                <td >
                   <%= dt.Rows[i]["flow_name"].ToString().Trim() %>
                </td>
                <td >
                   <%= dt.Rows[i]["remark"].ToString().Trim() %>
                </td>
            </tr>
            <%} %>
     </table>
 </div>
</asp:Content>
