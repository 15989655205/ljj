<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="MyWork_IDE.aspx.cs" Inherits="Maticsoft.Web.Flow.MyWork_IDE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript" src="/JS/calendar.js"></script>
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
    <asp:HiddenField ID="hsid" runat="server" />
    <asp:HiddenField ID="haction" runat="server"/>
    <asp:HiddenField ID="hrfsid" runat="server"/>  
        <div id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
<%--            <tr style="background-image: url(../images/bg_header.gif); background-repeat: repeat-x;
                height: 47px;">
                <td colspan="2">
                    <span style="float: left; background-image: url(../images/main_hl2.gif); width: 15px;
                        background-repeat: no-repeat; height: 47px"></span><span style="padding-right: 10px;
                            padding-left: 10px; float: left; background-image: url(../images/main_hb.gif);
                            padding-bottom: 10px; color: white; padding-top: 10px; background-repeat: repeat-x;
                            height: 47px; text-align: center;">添加新工作</span><span style="float: left; background-image: url(../images/main_hr.gif);
                                width: 60px; background-repeat: no-repeat; height: 47px"></span>
                </td>
            </tr>--%>
                <div style="height:10px"></div>
                <div valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../images/BanKuaiJianTou.gif" />
                   <%-- <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;工作流程&nbsp;>>&nbsp;添加新工作--%>
               
                    <img id="show" src="../images/Button/t.jpg" alt="" runat="server" onclick="ShowAppr()" style="cursor:pointer;"/>
                    <img id="split" runat="server" alt="" src="../images/Button/JianGe.jpg" />
                    <div style=" float:right">
                    <img id="submit" src="../images/Button/Submit.jpg" alt="" runat="server" onclick="save();" style="cursor:pointer;"/>&nbsp;&nbsp;</div>
                    <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"/>--%>
                    <%--<img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;--%>
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
                <td align="right" style="width: 170px; background-color: #e1f5fc; height: 25px;">
                    即时生效：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                    <asp:CheckBox ID="isVal" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    选择处理流程：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:DropDownList ID="flow_ddl" runat="server" Width="350px" 
                        AutoPostBack="True" onselectedindexchanged="flow_ddl_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; background-color: #e1f5fc; height: 25px;">
                    工作名称：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                    <asp:TextBox ID="flow_name" runat="server" Width="350px" ></asp:TextBox> &nbsp;<span style="color: red">*</span>
                </td>
            </tr>
             <tr>
                <td align="right" style="width: 170px; background-color: #e1f5fc;border-bottom: #000000 1px solid; height: 25px;">
                    备注：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;border-bottom: #000000 1px solid;">
                    <asp:TextBox ID="remark" runat="server" Width="90%" Rows="2" TextMode="MultiLine"></asp:TextBox> &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                    padding-left: 5px; border-left: #000000 1px solid; border-bottom: #000000 1px solid;
                    height: 25px; background-color: #ffffff">
                    <div>
                    <asp:Label ID="Label1" runat="server"></asp:Label><asp:TextBox ID="content_str" runat="server"
                        Style="display: none"></asp:TextBox>
                    </div>
                </td>
            </tr>
           
            <%--<tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    附件：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                    &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                        ImageAlign="AbsMiddle" ImageUrl="../images/Button/DelFile.jpg"  />
                    &nbsp; &nbsp;
                    <asp:ImageButton ID="ImageButton5" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                        ImageUrl="~/images/Button/ReadFile.gif"  />
                    &nbsp; &nbsp;&nbsp;
                    <asp:ImageButton ID="ImageButton6" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                        ImageUrl="~/images/Button/EditFile.gif"  />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    上传附件：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="303px" />
                    <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                        ImageUrl="../images/Button/UpLoad.jpg"/>
                </td>
            </tr>--%>
            <tr>
                <td align="right" colspan="2" style="height: 25px; background-color: #e1f5fc; text-align: center">
                    <strong>工作流程</strong>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-left: 5px;background-color: #ffffff">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
           <%-- <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    下一节点选择：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Width="350px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    条件跳转选择：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="根据条件字段自动决定下一节点" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    节点审批模式：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" Width="28px" Style="display: none"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    经办人列表：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    审批人选择：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="TextBox5" runat="server" Width="349px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=ERPUser&LieName=UserName&Condition='+document.getElementById('TextBox2').value+'&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('TextBox5').value=wName;}"
                        src="../images/Button/search.gif" /><asp:CheckBox ID="CHKSMS" runat="server" Checked="True" /><img
                            src="../images/TreeImages/@sms.gif" />短消息<asp:CheckBox ID="CHKMOB" runat="server" /><img
                                src="../images/TreeImages/mobile_sms.gif" />短信
                </td>
            </tr>--%>
        </table> 
        </div>
    <script type="text/javascript">
        $(function () {
            //Load_Do();
        });
        function Load_Do() {
            setTimeout("Load_Do()", 0);
            var content = document.getElementById("<%=Label1.ClientID %>").innerHTML
            document.getElementById("<%=content_str.ClientID%>").value = content;
        }

        function ShowAppr() {
            var sid = $('#<%=hsid.ClientID %>').val();
            window.open('ShowApprRecord.aspx?af_sid=' + sid);
        }

        function save() {
            $("#<%=Label1.ClientID %> input").each(function () {
//                var idobj = $(this).attr("id")
//                var dd = $(this).val();
//                $(this).val(dd);
//                //alert(idobj+":"+dd);
//                //document.getElementById(idobj).setAttribute("value", dd);

                var idobj = $(this).attr("name")
                var dd = $(this).val();
                $(this).val(dd);
                //alert(idobj+":"+dd);
                //document.getElementById(idobj).setAttribute("value", dd);
                document.getElementsByName(idobj)[0].setAttribute("value", dd);
                //$(this).html(dd);
                //document.getElementById(idobj).innerTEXT = dd;
            });
            $("#<%=Label1.ClientID %> textarea").each(function () {
                //var idobj = $(this).attr("id")
                var dd = $(this).val();
                $(this).html(dd);
                //document.getElementById(idobj).innerHTML =dd;
            });
//            alert($("#<%=Label1.ClientID %>").html()); 
//            return;
            if ($('#<%=flow_name.ClientID%>').val().length <= 0) {
                $.messager.show({ title: '错误提示', msg: "工作名称不能为空！" });
                return false;
            }
            OpenLoading("Processing,please wait...");
            sumbitData();
        }

        function sumbitData() {
            //alert($("#<%=Label1.ClientID %>").html());
            //return;
            // alert($("#<%=flow_ddl.ClientID%> option:selected").text());
            //return false;
            $.post(
            "../Ashx/ApplicationForm.ashx",
            {
                "action": $("#<%=haction.ClientID%>").val(),
                "isval": $("#<%=isVal.ClientID%>").is(":checked")? "2" : "1",
                "sid": $("#<%=hsid.ClientID%>").val(),
                "fmsid": $("#<%=flow_ddl.ClientID%>").val(),
                "flow_name": $("#<%=flow_name.ClientID%>").val(),
                "rfsid": $("#<%=hrfsid.ClientID%>").val(),
                "remark": $("#<%=remark.ClientID%>").val(),
                //"content1": navigator.userAgent.indexOf("MSIE") > 0 ? $("#<%=Label1.ClientID %>").html() : document.getElementById("<%=Label1.ClientID %>").innerHTML
                //"content1": $("#<%=Label1.ClientID %>").html()//document.getElementById("<%=Label1.ClientID %>").value//innerHTML
                "content1": document.getElementById("<%=Label1.ClientID %>").innerHTML
                //"content1": $("#<%=content_str.ClientID%>").val()//document.getElementById("content1").value
            },
            function (data) {
                if (data == "success") {
                    CloseLoading();
                    $.messager.show({ title: '提示', msg: "保存成功！" });
                    var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
                    parent.Tab_OC("我的申请单", title, "Flow/MyRequestForm.aspx", "", true);
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
