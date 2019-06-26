<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowApprRecord.aspx.cs" Inherits="Maticsoft.Web.Flow.ShowApprRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:10px; margin-right:10px; margin-top:5px;">
<table class="oa_Flow_Tab">
      <tr>
      <td  class="adminTitle" style="width:10%; text-align:center;">
      节点
      </td>
      <td style="width:10%; text-align:center;" class="adminTitle">
      节点类型
      </td>
                <td style="text-align:center;" class="adminTitle">
                    类型
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    审批部门
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    审批角色
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    审批人
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    经办时间
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    审批结果
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    审批意见
                </td>
            </tr>
            <%for (int i = 0; i < dt.Rows.Count; i++)
              { %>
            <tr>
            <td style="text-align:center;" >
      <%= dt.Rows[i]["node_no"].ToString().Trim() %>
      </td>
      <td style="text-align:center;" >
      <%= dt.Rows[i]["node_type_str"].ToString().Trim() %>
      </td>
                <td style="text-align:center;">
                   <%= dt.Rows[i]["appr_dept_type_str"].ToString().Trim()%>
                </td>
                <td style="text-align:center;">
                   <%= dt.Rows[i]["appr_dept_str"].ToString().Trim() %>
                </td>
                <td style="text-align:center;">
                   <%= dt.Rows[i]["appr_role_str"].ToString().Trim()%>
                </td>
                <td style="text-align:center;">
                   <%= dt.Rows[i]["approver_str"].ToString().Trim()%>
                </td>
                <td style="text-align:center;">
                   <%= dt.Rows[i]["appr_datetime"].ToString().Trim()%>
                </td>
                <td style="text-align:center;">
                   <%= dt.Rows[i]["appr_status_str"].ToString().Trim()%>
                </td>
                <td >
                   <%= dt.Rows[i]["description"].ToString().Trim()%>
                </td>
            </tr>
            <%} %>
     </table>
 </div>
    </form>
</body>
</html>
