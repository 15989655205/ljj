<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="Maticsoft.Web.Flow.Leave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="margin-left:10px; margin-right:10px;">
<div class="oaTopDiv" style="width:98%; background-color:White;">
<div style="height:10px"></div>
    <div class="section-header">
        <div class="title">
           <img src="../Images/8.png" alt="" />
           <%string tmpTitle = "";
             switch (type)
             {
                 case "add":
                     tmpTitle = "起草申请";
                     break;
                 case "update":
                     tmpTitle = "修改申请";
                     break;
                 case "approve":
                     tmpTitle = "审批假期申请";
                     break;
                 case "view":
                     tmpTitle = "查看申请";
                     break;
                 default:
                     break;
             } %>
            <%=tmpTitle%>
        </div>
        <div class="options">
            <input type="button" id="btnSaveButton" value="保存"
                class="adminButtonBlue" onclick="save();" <%if(!isSave) {%> disabled="disabled"
                <%} %> />
        </div>
    </div>
</div>
<div style="height:50px;"></div>

<div style="">
<form id="ff" method="post" action="" >
<input type="hidden" id="hfFormSID" name="hfFormSID" value="" />

 <%if (type == "add" || type == "update" )
   { %>
    <table class="oa_Tab_Status">
        <tr>
            <td class="oaTitle">
                是否即时生效
            </td>
            <td class="oaData">
                <input type="checkbox" id="chkStatus" name="chkStatus" />
            </td>
            <td class="oaTitle">
            </td>
            <td class="oaData">
            </td>
        </tr>
    </table>
    <%} %>
    <center>
    <table class="oa_Flow_Tab" style=" width:800px;">
        <tr>
            <td style="width:15%">
                工号
            </td>
            <td style="width:35%">
            </td>
            <td style="width:15%">
                职位
            </td>
            <td style="width:35%">
            </td>      
        </tr>
        <tr>
            <td >
                申请人
            </td>
            <td >
                <input type="hidden" id="hfUID" name="hfUID" value='' />
            </td>
            <td >
                申请时间
            </td>
            <td >
                   
            </td>
        </tr>
        <tr>
            <td >
               假期类型
            </td>
            <td >
                <input type="text" id="txtDept" name="txtDept" readonly="readonly" onkeydown="stopBackspace();" value="" />
            </td>
            <td >
                
            </td>
            <td >
                   
            </td>
        </tr>
        <tr>
            <td >
                开始时间
            </td>
            <td >
            </td>
            <td >
                结束时间
            </td>
            <td >
                   
            </td>
        </tr>
        <tr>
            <td >
                合计
            </td>
            <td  >
            </td>
            <td >
                
            </td>
            <td >
                   
            </td>
        </tr>
        <tr>
            <td >
                事由
            </td>
            <td colspan="3">
                <textarea id="txtRequirement" name="txtRequirement" rows="5" cols="10" class="validate[maxSize[100]] " style="width:98%;"
                    onkeyup="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    onkeydown="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    onpropertychange="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    oninput="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"></textarea>
            </td>
        </tr>
    </table>
    </center>
    <br/>

    <table class="oa_Flow_Appr_Table">
        <tr>
            <th>
                节点
            </th>
            <th>
                类型
            </th>
            <th>
                
            </th>
            <th>
                
            </th>
            <th>
                
            </th>
            <th>
                
            </th>
            <th>
                
            </th>
        </tr>
        <%for (int i = 0; i < 4; i++)
          {
        %>
        <tr>
            <td <%if(i%2!=0){ %>class="diTD" <%} %>>
                
            </td>
            <td <%if(i%2!=0){ %>class="diTD" <%} %>>
                
            </td>
            <td <%if(i%2!=0){ %>class="diTD" <%} %>>
               
            </td>
            <td <%if(i%2!=0){ %>class="diTD" <%} %>>
                
            </td>
            <td <%if(i%2!=0){ %>class="diTD" <%} %>>
                
            </td>
            <td <%if(i%2!=0){ %>class="diTD" <%} %>>
                <a class="a_black" title=""><span style="width:160px;" class="mlength"></span></a>
            </td>
            <td <%if(i%2!=0){ %>class="diTD" <%} %>>
                
            </td>
        </tr>
        <%
        } %>
    </table>

    <br />

   <%if (type == "approve" || type == "check" || type == "handle")
     { %>
     <table class="oa_Flow_Tab">
     <tr>
      <td colspan="2">
      <strong></strong> 
      </td>
     </tr>
      <tr>
                <td class="adminTitle">
                    
                </td>
                <td class="adminData">
                    <div id="rbApprove"></div>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                   
                </td>
                <td class="inputTD">
                        <textarea id="txtApproveDescription" name="txtApproveDescription" rows="3" cols="50"  class="validate[maxSize[250]] " style="width:98%;"
                    onkeyup="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    onkeydown="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    onpropertychange="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    oninput="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';" ></textarea>
                </td>
            </tr>
     </table>
   <%} %>
    </form>
</div>
</div>
</asp:Content>
