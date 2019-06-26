<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="HandleRequestForm.aspx.cs" Inherits="Maticsoft.Web.Flow.HandleRequestForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../ueditor/ueditor.parse.js"></script>
    <script type="text/javascript">
        setTimeout(
            function () {
                uParse(
                    'div'
                    , {
                        'highlightJsUrl': '../ueditor/third-party/SyntaxHighlighter/shCore.js'
                        , 'highlightCssUrl': '../ueditor/third-party/SyntaxHighlighter/shCoreDefault.css'
                    }
                )
            }
            , 300
        )

        window.onload = window.onresize = function () {
            $("#down").height(document.body.clientHeight - $("#PrintHide").height());
        }
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <input type="hidden" id="hsid" name="hsid" value="<%=sid %>"/>
    <input type="hidden" id="haction" name="haction" value="<%=action %>"/>
    <input type="hidden" id="hrfsid" name="hrfsid" value="<%=rfsid %>"/>
    <input type="hidden" id="hcnode" name="hcnode" value="<%=currNode %>"/>    
        <div id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
           <div style="height:10px"></div>    
                <div valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img alt="" src="../images/BanKuaiJianTou.gif" />
                   <%-- <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;工作流程&nbsp;>>&nbsp;添加新工作--%>
                   <div style=" float:right">
                    <img id="show" src="../images/Button/t.jpg" alt=""onclick="ShowAppr()" style="cursor:pointer;"/>
                    <img id="split" alt="" src="../images/Button/JianGe.jpg" />&nbsp;
                    <img id="submit" src="../images/Button/Submit.jpg" alt="" onclick="save();" style="cursor:pointer;"/>&nbsp;&nbsp;
                    </div>
                </div>
        </div>
     <div id="down" style="overflow:auto">
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" colspan="2" style="height: 25px; background-color: #e1f5fc; text-align: center">
                    <strong>工作基本属性</strong>
                </td>
            </tr>
            <tr>
                <td align="right" style="width:50px; background-color: #e1f5fc; height: 25px;">工作名称：</td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <%=afModel==null?"":afModel.af_name %>
                </td>
            </tr>
             <tr>
                <td align="right" style="background-color: #e1f5fc;border-bottom: #000000 1px solid; height: 25px;">备注：</td>
                <td style="background-color: #ffffff; height: 25px; border-bottom: #000000 1px solid;padding-left: 5px;">
                <%=afModel==null?"":afModel.remark %>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                    padding-left: 5px; border-left: #000000 1px solid; border-bottom: #000000 1px solid;
                    height: 25px; background-color: #ffffff">
                   <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="height: 25px; background-color: #e1f5fc; text-align: center">
                    <strong>我的<%=nodeType %></strong>
                </td>
            </tr>
             <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;"><%=nodeType %>结果：</td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <select id="result">
                <%for (int i = 0; i < arrStr.Length; i++)
                  { %>
  <option value ="<%=i+1 %>"><%=arrStr[i] %></option>
  <%} %>
</select>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;"><%=nodeType %>意见：</td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <textarea id="remark" name="remark" cols="50" rows="3" style=" width:98%;"></textarea>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="height: 25px; background-color: #e1f5fc; text-align: center">
                    <strong>审批流程</strong>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-left: 5px;background-color: #ffffff">
                    <%=node %>
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        $(function () {
            $('#<%=Label1.ClientID %>').find('input').attr("disabled", "disabled");
            $('#<%=Label1.ClientID %>').find('textarea').attr("disabled", "disabled");
            //$('#<%=Label1.ClientID %>').find('input').attr("editable", false);
            //$('#<%=Label1.ClientID %>').find('textarea').attr("readonly", "readonly");
        });

        function ShowAppr() {
            var sid = $('#hsid').val();
            window.open('ShowApprRecord.aspx?af_sid=' + sid);
        }

        function save() {
            OpenLoading("Processing,please wait...");
            sumbitData();
        }

        function sumbitData() {
            $.post(
            "../Ashx/ApplicationForm.ashx",
            {
                "action": "handle",
                "afsid": $('#hsid').val(),
                "node": $('#hcnode').val(),
                "result": $('#result').val(),
                //"resultStr": $('#result option:selected').text(),
                "resultStr": $("#result").find("option:selected").text(),
                "remark": $('#remark').val()
            },
            function (data) {
                if (data == "success") {
                    CloseLoading();
                    $.messager.show({ title: '提示', msg: "保存成功！" });
                    var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
                    parent.Tab_OC("待我审批/办理", title, ("<%=type %>"=="qs"?"Flow/MyApprForm.aspx":"Flow/WaitMeForm.aspx"), "", true);
                }
                else {
                    $.messager.show({ title: '错误提示', msg: (data=="success"?"保存成功":data) });
                    CloseLoading();
                }
            });
        }
    </script>

    </form>
</asp:Content>
