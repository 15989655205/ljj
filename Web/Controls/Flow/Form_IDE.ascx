<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Form_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.Flow.Form_IDE" %>


   <%-- <script type="text/javascript" language="javascript" src="/JS/calendar.js"></script>--%>
  <%--  <script src="/ckeditor/ckeditor.js" type="text/javascript"></script>--%>
  <script src="/ueditor/ueditor.all.js" type="text/javascript"></script>
   <script src="/ueditor/ueditor.config.js" type="text/javascript"></script>
   <link href="/ueditor/themes/default/css/ueditor.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        var type = "<%=type %>";
        var sumbitURL = "../Ashx/RequestForm.ashx";
        var isload = false;
        var editor=""
        $(function () {
            //            editor = CKEDITOR.replace("content",
            //{ height: 350, toolbar: 'MyToolbar'
            //});
            var Sys = {};
            var ua = navigator.userAgent.toLowerCase();
            if (window.ActiveXObject)
                Sys.ie = ua.match(/msie ([\d.]+)/)[1]
            else if (document.getBoxObjectFor)
                Sys.firefox = ua.match(/firefox\/([\d.]+)/)[1]
            else if (window.MessageEvent && !document.getBoxObjectFor)
                Sys.chrome = ua.match(/chrome\/([\d.]+)/)[1]
            else if (window.opera)
                Sys.opera = ua.match(/opera.([\d.]+)/)[1]
            else if (window.openDatabase)
                Sys.safari = ua.match(/version\/([\d.]+)/)[1];

            if (!window.ActiveXObject) {
                //$('#content1').attr("height",90%);
                document.getElementById("content").style.width = "88%";
                //document.getElementById("content").style.cssText += ";width:100%;"
            }

            $('#form_type').combobox({
                url: '../Ashx/Common.ashx?type=rft_comb',
                valueField: 'sid',
                textField: 'type_name',
                editable: false,
                panelHeight: 'auto',
                onLoadSuccess: function () {
                    $('#form_type').combobox('setValue', '<%=formModel!=null?formModel.rft_sid.ToString():"" %>');
                }
            });
            if ('<%=formModel!=null?formModel.rf_status.ToString():"" %>' == 1) {
                $("#isVal").attr("checked", true);
            }
            else {
                $("#isVal").attr("checked", false);
            }

            //            switch (type) {
            //                case "add":
            //                    sumbitURL = "../Ashx/RequestForm.ashx?action=add";
            //                    break;
            //                case "copy":
            //                    sumbitURL = "../Ashx/RequestForm.ashx?action=add";
            //                    break;
            //                case "update":
            //                    sumbitURL = "../Ashx/RequestForm.ashx?action=update";
            //                    break;
            //            }
        });



    function selectyinzhang(imgidstr)
        {
            
            var wName;
            var RadNum=Math.random();
            //wName=window.showModalDialog('../Main/SelectYinZhang.aspx?Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');            
            if(wName==null||wName=="")
            {}
            else
            {
                //alert(imgidstr);
               // imgidstr.src="http://"+window.location.host+"/UploadFile/"+wName;  
            }
        }
  
  function PrintTable()
    {
        document.getElementById("PrintHide") .style.visibility="hidden"    
        print();
        document.getElementById("PrintHide") .style.visibility="visible"    
    }

    function formset(str) {
        //var oEditor = CKEDITOR.instances.content;
        // Check the active editing mode.
        //if (oEditor.mode != 'wysiwyg') {
        //    return false;
        //}
        //alert( 'You must be in WYSIWYG mode!' );
        var cValue = parseInt(20000 * Math.random());
        //Math.random()

        //常规控件
        if (str == "1") {
            //oEditor.insertHtml('<input id="Text1"  name="' + cValue + '"  type="text"  style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
            ueditor.execCommand('insertHtml', '<input id="' + cValue + '"  name="' + cValue + '"  type="text"  style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
        }

        if (str == "2") {
            try {
                //oEditor.insertHtml('<textarea  id="TextArea1" name="' + cValue + '"   cols="20" rows="2"  style="SCROLLBAR-FACE-COLOR:   #AAAAAA;   SCROLLBAR-HIGHLIGHT-COLOR:   #D8D8D8;  SCROLLBAR-SHADOW-COLOR:   #D8D8D8;   SCROLLBAR-3DLIGHT-COLOR:   #D8D8D8;   SCROLLBAR-ARROW-COLOR:   #D8D8D8;   SCROLLBAR-TRACK-COLOR:   #D8D8D8;   SCROLLBAR-DARKSHADOW-COLOR:   #D8D8D8; border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000 " ></textarea>');
                ueditor.execCommand('insertHtml', '<span style="FONT-SIZE: 0px">.</span><textarea  id="' + cValue + '" name="' + cValue + '"   cols="20" rows="2"  style="SCROLLBAR-FACE-COLOR:   #AAAAAA;   SCROLLBAR-HIGHLIGHT-COLOR:   #D8D8D8;  SCROLLBAR-SHADOW-COLOR:   #D8D8D8;   SCROLLBAR-3DLIGHT-COLOR:   #D8D8D8;   SCROLLBAR-ARROW-COLOR:   #D8D8D8;   SCROLLBAR-TRACK-COLOR:   #D8D8D8;   SCROLLBAR-DARKSHADOW-COLOR:   #D8D8D8; border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000 " ></textarea>');
            } catch (e) {
            }

        }

        if (str == "9") {
            try {
                //oEditor.insertHtml(' <textarea id="txtRemark" name="txtRemark" rows="1" cols="10" class="mytextarea" style="width:98%;height:25;border: 0px solid #000000;overflow:hidden;background-color:#E0ECFF;" onkeyup="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';" onkeydown="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';" onpropertychange="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';" oninput="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';"></textarea>');
                //ueditor.execCommand('insertHtml', '<span style="FONT-SIZE: 0px">.</span><textarea id="txtRemark" name="txtRemark" rows="1" cols="10" class="mytextarea" style="width:98%;height:25;border: 0px solid #000000;overflow:hidden;background-color:#E0ECFF;" onkeyup="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';" onkeydown="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';" onpropertychange="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';" oninput="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';"></textarea>');
                ueditor.execCommand('insertHtml', '<span style="FONT-SIZE: 0px">.</span><textarea id="' + cValue + '" name="' + cValue + '" rows="1" cols="10" class="mytextarea" style="width:98%;height:25;border: 0px solid #000000;overflow:hidden;" onkeyup="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';" onkeydown="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';" onpropertychange="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';" oninput="this.style.height = (this.scrollHeight-8<=25?25:this.scrollHeight-4) + \'px\';"></textarea>');
            } catch (e) {
            }

        }

        if (str == "3") {
            //oEditor.insertHtml('<input id="Checkbox1"  name="' + cValue + '"   type="checkbox"  />');
            ueditor.execCommand('insertHtml', '<input id="' + cValue + '"  name="' + cValue + '"   type="checkbox"  />');
        }

        if (str == "11") {
            //oEditor.insertHtml('<input id="Text1"  name="myfloat"  type="text"/>');
            ueditor.execCommand('insertHtml', '<input id="' + cValue + '"  name="' + cValue + '"  type="text"/>');
        }

        if (str == "12") {
            //oEditor.insertHtml('<input id="Text1"  name="mynum"  type="text"/>');
            //oEditor.insertHtml('<input id="Text1"  name="' + cValue + '"  type="text"  style="IME-MODE: disabled;border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"  onkeypress="var k=event.keyCode; return (k>=48&&k<=57)||k==46" onpaste="return !/\D/.test(clipboardData.getData(\'text\'))"  ondragenter="return false"/>');
            ueditor.execCommand('insertHtml', '<input id="' + cValue + '"  name="' + cValue + '"  type="text"  style="IME-MODE: disabled;border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"  onkeypress="var k=event.keyCode; return (k>=48&&k<=57)||k==46" onpaste="return !/\D/.test(clipboardData.getData(\'text\'))"  ondragenter="return false"/>');
        }

        if (str == "13") {
            var num = Math.random();
            //oEditor.insertHtml('<input id="' + num + '" name="' + cValue + '"  type="text"  onclick="setday(this)" onfocus="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm\'})"  value=""  style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
            //oEditor.insertHtml('<input id="' + num + '" name="' + cValue + '"  type="text" onfocus="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm\'})" class="Wdate"  value=""  style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
            //oEditor.insertHtml('<input id="' + num + '" name="my97date"  type="text" onfocus="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm\'})" class="Wdate" />');
            ueditor.execCommand('insertHtml', '<input id="' + cValue + '" name="' + cValue + '"  type="text" onfocus="WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm\'})" class="Wdate"  value=""  style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
        }

        //<input id="WorkTime" type="text"  onclick="Jscript:var sID ;sID = event.srcElement.id; DateSelect(sID);" />
        if (str == "14") {
            var num = Math.random();
            //oEditor.insertHtml('<img class="HerCss" name="img' + cValue + '" id="img' + cValue + '" onclick="selectyinzhang(img' + cValue + ');"  src="../images/NoYz.gif" />');
             ueditor.execCommand('insertHtml','<img class="HerCss" name="img' + cValue + '" id="img' + cValue + '" onclick="selectyinzhang(img' + cValue + ');"  src="../images/NoYz.gif" />');
        }

        //宏控件




        if (str == "4") {
            //oEditor.insertHtml('<input readonly id="Text2" name="' + cValue + '"  type="text" value="宏控件-用户姓名" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
            ueditor.execCommand('insertHtml', '<input readonly id="' + cValue + '" name="' + cValue + '"  type="text" value="宏控件-用户姓名" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
        }

        if (str == "5") {
            //oEditor.insertHtml('<input readonly id="Text2" name="' + cValue + '"  type="text" value="宏控件-用户部门" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
            ueditor.execCommand('insertHtml', '<input readonly id="' + cValue + '" name="' + cValue + '"  type="text" value="宏控件-用户部门" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
        }

        if (str == "6") {
            //oEditor.insertHtml('<input readonly id="Text2"  name="' + cValue + '"   type="text" value="宏控件-用户角色" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
            ueditor.execCommand('insertHtml', '<input readonly id="' + cValue + '"  name="' + cValue + '"   type="text" value="宏控件-用户角色" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
        }

        if (str == "7") {
            //oEditor.insertHtml('<input readonly id="Text2"  name="' + cValue + '"  type="text" value="宏控件-用户职位" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
            ueditor.execCommand('insertHtml', '<input readonly id="' + cValue + '"  name="' + cValue + '"  type="text" value="宏控件-用户职位" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
        }


        if (str == "8") {
            //oEditor.insertHtml('<input readonly id="Text2"  name="' + cValue + '"  type="text" value="宏控件-当前时间(日期)" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
            ueditor.execCommand('insertHtml', '<input readonly id="' + cValue + '"  name="' + cValue + '"  type="text" value="宏控件-当前时间(日期)" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
        }

    }

    function Insert() {

    }

    </script>

    <script language="javascript" type="text/javascript">
        function settiaojian() {
            var ziduanname = document.getElementById("DropDownList1").value.split('[')[0];
            var ziduanleixing = document.getElementById("DropDownList1").value.split('[')[1];
            if (ziduanleixing == "常规型]") {
                eWebEditor1.insertHTML('<input id="Text3"  name="' + "TIaoJianZiDuan_" + ziduanname + '"  type="text"  style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>');
            }
            else {
                eWebEditor1.insertHTML('<input id="Text3"  name="' + "TIaoJianZiDuan_" + ziduanname + '"  type="text"  style="IME-MODE: disabled;border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"  onkeypress="var k=event.keyCode; return (k>=48&&k<=57)||k==46" onpaste="return !/\D/.test(clipboardData.getData(\'text\'))"  ondragenter="return false"/>');
            }
        }

        $(function () {
            document.getElementById("edui1").style.cssText += ";width:100%;"
            document.getElementById("edui1_iframeholder").style.cssText += ";width:100%;"
            var height = document.body.clientHeight - $("#top").height();
            $("#down").height(height);
            height = height - 10 - $("#tt_tr_1").height() - $("#tt_tr_2").height() - $("#tt_tr_3").height() - $("#tt_tr_4").height();
            $("#tt_tr_5_td_2").height(height);
            height = $("#tt_tr_5").height() - 13 - $("#div_txt").height() - $("#edui1_toolbarbox").height() - $("#edui1_bottombar").height();
            $("#edui1_iframeholder").height(height);
        })
        window.onresize = function () {
            var height = document.body.clientHeight - $("#top").height();
            $("#down").height(height);
        }
    </script>
    <form id="ff" runat="server" action="">
    <input id="action" name="action" type="hidden" value="<%=type=="copy"?"add":type %>" />
    <input id="sid" name="sid" type="hidden" value="<%=sid %>" />
    <div id="top">
        <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
<%--            <tr style="background-image: url(../images/bg_header.gif); background-repeat: repeat-x;
                height: 47px;">
                <td colspan="2">
                    <span style="float: left; background-image: url(../images/main_hl2.gif); width: 15px;
                        background-repeat: no-repeat; height: 47px"></span><span style="padding-right: 10px;
                            padding-left: 10px; float: left; background-image: url(../images/main_hb.gif);
                            padding-bottom: 10px; color: white; padding-top: 10px; background-repeat: repeat-x;
                            height: 47px; text-align: center;">添加表单</span><span style="float: left; background-image: url(../images/main_hr.gif);
                                width: 60px; background-repeat: no-repeat; height: 47px"></span>
                </td>
            </tr>--%>
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../../images/BanKuaiJianTou.gif" />
                    <%--<a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;工作流程&nbsp;>>&nbsp;添加表单--%>
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" Visible="false" />
                        <img src="../../images/Button/Submit.jpg" alt="" onclick="save();" style="cursor:pointer"/>&nbsp;&nbsp;
                  <%--  <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" style="cursor:pointer"/>&nbsp;--%>
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2" style="background-color: #ffffff">
                </td>
            </tr>
        </table>
    </div>
    <div id="down" style="width:100%;overflow:auto">
        <table id="div_tt" style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr id="tt_tr_1">
                <td id="tt_tr_1_1" align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    表单名称：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="TextBox1" runat="server" Width="350px" Visible="false"></asp:TextBox>
                    <input id="form_name" name="form_name" type="text" style=" width:350px;" value="<%=formModel!=null?formModel.form_name:"" %>"/>
                </td>
            </tr>
            <tr id="tt_tr_2">
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc;">
                    表单类别：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="350px" Visible="false">
                    </asp:DropDownList>
                    <input id="form_type" name="form_type" style=" width:356px;"/>
                </td>
            </tr>
            <tr id="tt_tr_3">
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    是否有效：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff;">
                    <input type="checkbox" id="isVal" name="isVal"/><label for="isVal">有效</label><input type="hidden" id="hval" name="hval"/>
                </td>
            </tr>
             <tr id="tt_tr_4">
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">                    
                    <div style="margin-left:0px;margin-right:8px;">
                        <textarea style="width:100%;" id="remark" name="remark" cols="" rows="3"><%=formModel!=null?formModel.remark:""%></textarea>
                    </div>
                </td>
            </tr>
            <%--<tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    使用范围：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="TextBox3" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=ERPUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('TextBox3').value=wName;}"
                        src="../images/Button/search.gif" />
                    <span style="color: dimgray">*允许哪些人使用，空白则允许所有人使用</span>
                </td>
            </tr>--%>
            <%--<tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    条件字段：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="194px">
                    </asp:DropDownList>
                    <input id="Button3" style="width: 69px" type="button" value="插入字段" onclick="settiaojian()" /><asp:Button
                        ID="Button2" runat="server" OnClick="Button2_Click" Text="删除" Width="38px" />字段名：<asp:TextBox
                            ID="TextBox4" runat="server" Width="85px"></asp:TextBox>
                    类型：<asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>[常规型]</asp:ListItem>
                        <asp:ListItem>[数字型]</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加字段" Width="69px" />
                </td>
            </tr>--%>
            <tr id="tt_tr_5">
                <td align="center" valign="top" style="width: 170px; height: 25px; background-color: #e1f5fc">
                    <div id="div_c">
                    <strong>标准控件</strong>
                    <hr />
                    <input id="Button4" onclick="formset(1)" style="width: 150px" type="button" value="插入常规输入框" />
                    <br />
                    <input id="Button14" onclick="formset(12)" style="width: 150px" type="button" value="插入数字输入框" />
                    <br />
                    <%--<input id="Button1" onclick="formset(11)" style="width: 120px" type="button" value="插入浮点数输入框" />
                    <br />--%>
                    <input id="Button5" onclick="formset(2)" style="width: 150px" type="button" value="插入文本框带下划线" /><br />
                    <input id="Button1" onclick="formset(9)" style="width: 150px" type="button" value="插入文本框不带下划线" /><br />
                    <%--<input id="Button2" onclick="Insert()" style="width: 150px" type="button" value="表格所有空白插入框" /><br />--%>
                    <input id="Button15" onclick="formset(13)" style="width: 150px" type="button" value="插入日期选择" /><br />
                    <input id="Button6" onclick="formset(3)" style="width: 150px" type="button" value="插入复选框" /><br />
                    <hr />
                    <strong>宏控件</strong>
                    <hr />
                    <input id="Button7" onclick="formset(4)" style="width: 150px" type="button" value="插入用户姓名"/>
                    <br />
                    <input id="Button8" onclick="formset(5)" style="width: 150px" type="button" value="插入用户部门" />
                    <br />
                    <input id="Button9" onclick="formset(6)" style="width: 150px" type="button" value="插入用户角色" />
                    <br />
                    <input id="Button10" onclick="formset(7)" style="width: 150px" type="button" value="插入用户职位" />
                    <br />
                    <input id="Button11" onclick="formset(8)" style="width: 150px" type="button" value="当前时间(日期)" />
                    <hr />                    
                   <%-- <strong>印章控件</strong>
                    <hr />
                    <input id="Button12" onclick="formset(14)" style="width: 120px" type="button" value="插入印章域" />--%>
                    </div>
                </td>
                <td id="tt_tr_5_td_2" style="text-align:left; background-color: #ffffff">
                <input id="content1" name="content1" type="text" runat="server" style="display: none" />
                <%--<textarea id="content1" name="content1" style="display:none"><%=content%></textarea>--%>
                    <%--<asp:TextBox ID="TxtContent" runat="server" Style="display: none"></asp:TextBox>
                    <iframe frameborder="0" height="350" id="eWebEditor1" scrolling="no" src="../eWebEditor/ewebeditor.htm?id=TxtContent&style=mini"
                        width="99%"></iframe>--%>
                        <%--<iframe frameborder="0" height="350" id="eWebEditor1" src="../eWebEditor/ewebeditor.htm?id=content1&style=mini"
                        width="99%"></iframe>--%>
                        <%--<textarea cols="50" rows="20" id="content" name="content"><%=content %></textarea> --%>                        
                        <textarea id="content" name="content" rows="" cols="" style="height:300px; "><%=content%></textarea>
                        <script type="text/javascript">
                            var ueditor = new baidu.editor.ui.Editor({
                                toolbars: [[
                                    'fullscreen', 'source', '|', 'undo', 'redo',
                                    '|', 'bold', 'italic', 'underline', 'fontborder',
                                    'strikethrough', 'superscript', 'subscript', 'removeformat',
                                    'formatmatch', 'autotypeset', 'blockquote', 'pasteplain', '|',
                                    'forecolor', 'backcolor', 'insertorderedlist', 'insertunorderedlist', 'selectall',
                                    'cleardoc', '|', 'rowspacingtop', 'rowspacingbottom', 'lineheight',
                                    '|', 'customstyle', 'paragraph', 'fontfamily', 'fontsize',
                                    '|', 'directionalityltr', 'directionalityrtl', 'indent', '|',
                                    'justifyleft', 'justifycenter', 'justifyright', 'justifyjustify', '|',
                                    'touppercase', 'tolowercase', '|', 'link', 'unlink',
                                    'anchor', '|', 'imagenone', 'imageleft', 'imageright',
                                    'imagecenter', '|', 'insertimage', 'emotion', 'scrawl',
                                    'insertvideo', 'music', 'attachment', 'pagebreak',
                                    'template', 'background', '|', 'horizontal', 'date',
                                    'time', 'spechars', 'snapscreen', 'wordimage', '|',
                                    'inserttable', 'deletetable', 'insertparagraphbeforetable', 'insertrow', 'deleterow',
                                    'insertcol', 'deletecol', 'mergecells', 'mergeright', 'mergedown',
                                    'splittocells', 'splittorows', 'splittocols', '|', 'print',
                                    'preview', 'searchreplace'
                                ]],
                                emotionLocalization: true,
                                autoHeightEnabled: false,
                                scaleEnabled: false,
                                elementPathEnabled: false
                            });
                            //ueditor.setHeight(300);
                            ueditor.render('content');
                        </script>
                        <div id="div_txt">
                    <span style="color:#ff0000">1.点击左边控件按钮将会把内容插入到编辑器中鼠标的光标所在处，如果鼠标的光标没有在编辑器中将不会插入内容。</span><br/>
                    <span style="color:#ff0000">2.页面中存在重复的字段，系统在流程条件判断中将取页面上第一个控件的值。如果第一个控件没有值，系统默认为未取到值。</span>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>

    <script type="text/javascript">
        function save() {
            if (jQuery('#ff').validationEngine('validate')) {
                OpenLoading("Processing,please wait...");
                sumbitData();
            }
            else {
            }


            //            if (document.getElementById("content").value != "") {
            //                alert(document.getElementById("content").value);
            //            }
            //            else {
            //                alert("空");
            //            }
            //            alert($('#content').val());
        }

        function sumbitData() {
            //window.frames["eWebEditor1"].AttachSubmit();
            if ($("#isVal").is(":checked")) {
                $("#hval").val("1");
            } else {
                $("#hval").val("0");
            }

            //            $.ajax({
            //                url: sumbitURL,
            //                data: {
            //                "action":$("#action").val(),
            //                "sid":$("#sid").val(),
            //                "form_name": $("#form_name").val(),
            //                "form_type": $("#form_type").combobox('getValue'),
            //                "hval": $("#hval").val(),
            //                "remark": $("#remark").val(),
            //                "content1": document.getElementById("content1").value
            //                },
            //                success: function (data) {
            //                }
            //            });

            //            $('#ff').submit(function () {
            //                //ajax异步提交
            //                //   content.replace(/\n/g, "<br>");     
            //                $.ajax({
            //                    type: "post",                     //post提交方式据说默认是get
            //                    url: sumbitURL,  //我的原来的页面是带了一个参数answer.aspx?qid="****";不知道这里是不是正确的
            //                    data: $("#ff").serialize(),   //序列化               
            //                    error: function (request) {      // 设置表单提交出错                 
            //                        alert("表单提交出错，请稍候再试.....");
            //                    },
            //                    success: function (data) {
            //                        alert("成功！");
            //                    }
            //                });
            //                return false;
            //            });  

            //            $('#ff').submit(function ()//提交表单
            //            {
            //                //alert("ddd");
            //                var options = {
            ////                    //target: '#Tip', //后台将把传递过来的值赋给该元素
            //                    url: sumbitURL, //提交给哪个执行
            //                    type: 'POST',
            //                    success: function (data) { alert(data); } //显示操作提示
            //                };
            //                $('#ff').ajaxSubmit(options);
            //                return false; //为了不刷新页面,返回false，反正都已经在后台执行完了，没事！
            //            });
            $.post(
            sumbitURL,
            //$("#ff").serialize(),
            {
            "action": $("#action").val(),
            "sid": $("#sid").val(),
            "form_name": $("#form_name").val(),
            "form_type": $("#form_type").combobox('getValue'),
            "hval": $("#hval").val(),
            "remark": $("#remark").val(),
            "content1": ueditor.getContent()//CKEDITOR.instances.content.getData()$("#<%=content1.ClientID%>").val()//document.getElementById("content1").value
        },
            function (data) {
                if (data == "success") {
                    CloseLoading();
                    $.messager.show({ title: '提示', msg: "保存成功！" });
                    var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
                    parent.Tab_OC("表单设计", title, "Flow/FormDesign.aspx", "", true);
                }
                else {
                    $.messager.show({ title: '错误提示', msg: (data=="success"?"保存成功":data) });
                    CloseLoading();
                }
            });
        //            $('#ff').form('submit', {
        //                url: sumbitURL,
        //                onSubmit: function () {
        //                    var chk = '';
        //                    if ($("#isVal").is(":checked")) {
        //                        chk = '1';
        //                        $("#hval").val("1");
        //                    } else {
        //                        chk = '0';
        //                        $("#hval").val("0");
        //                    }
        //                    // 做某些检查   
        //                    // 返回 false 来阻止提交
        //                    //                jQuery('#ff').validationEngine('validate');
        //                    //                window.setInterval(jQuery('#ff').validationEngine('hide'), 5000); 
        //                },
        //                success: function (data) {
        //                    //var agr1 = data.split("|")[0];
        //                    //var agr2 = data.split("|")[1];
        //                    //$.messager.show({ title: '', msg: agr1 });

        //                    //if (agr1 == "success") {
        //                    if (data == "success") {
        //                        //$("#btnSaveButton").attr('disabled', false);
        //                        CloseLoading();
        //                        $.messager.show({ title: '提示', msg: "保存成功！" });
        //                        var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
        //                        parent.Tab_OC("表单设计", title, "Flow/FormDesign.aspx", "", true);
        //                    }
        //                    else {
        //                        //$("#btnSaveButton").attr('disabled', false);
        //                        $.messager.show({ title: '错误提示', msg: data });
        //                        CloseLoading();
        //                    }
        //                }
        //            });
    }
    </script>