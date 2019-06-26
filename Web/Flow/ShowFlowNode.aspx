<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowFlowNode.aspx.cs" Inherits="Maticsoft.Web.Flow.ShowFlowNode" %>

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
      节点名称
      </td>
                <td style="text-align:center;" class="adminTitle">
                    节点类型
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    类型
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    审核部门
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    审核角色
                </td>
                <td style="text-align:center;"  class="adminTitle">
                    审核方式
                </td>
            </tr>
            <%for (int i = 0; i < dt.Rows.Count; i++)
              { %>
            <tr>
            <td style="text-align:center;" >
      <%= dt.Rows[i]["node_no"].ToString().Trim() %>
      </td>
      <td style="text-align:center;" >
      <%= dt.Rows[i]["node_name"].ToString().Trim() %>
      </td>
                <td >
                   <%= dt.Rows[i]["node_type_name"].ToString().Trim()%>
                </td>
                <td >
                   <%= dt.Rows[i]["appr_dept_type"].ToString().Trim()=="0"?"跨部门":"同部门" %>
                </td>
                <td >
                   <%= dt.Rows[i]["DeptName"].ToString().Trim()%>
                </td>
                <td >
                   <%= dt.Rows[i]["RoleName"].ToString().Trim()%>
                </td>
                <td >
                   <%= dt.Rows[i]["appr_count"].ToString().Trim() == "0" ? "必须所有人员通过" : "只要有一人审批"%>
                </td>
            </tr>
            <%} %>
     </table>
 </div>
    </form>
</body>
</html>
