<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Notice_IDE.aspx.cs" Inherits="Maticsoft.Web.ADAndNotice.Notice_IDE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
   <script src="/ueditor/ueditor.all.js" type="text/javascript"></script>
   <script src="/ueditor/ueditor.config.js" type="text/javascript"></script>
   <link href="/ueditor/themes/default/css/ueditor.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var sumbitUrl = "/Ashx/notice.ashx";
        var type = "<%=type%>";
        var editor;
        $(function () {});

        function save() {
            if ($("#txttitle").val().replaceAll(' ', '') == '') {
                $.messager.show({ title: '系统提示', msg: '【标题】不能为空。' });
                return;
            }
            //            if (!jQuery('#ff').validationEngine('validate')) {
            //                ButtonLock(false);
            //                return;
            //            }
            var id = $("#sid").val();
            var title = $("#txttitle").val();
            var summary = $("#txtsummary").val();
            var intro = $("#txtintro").val();
            var notice_content = editor.getContent();
            $.ajax({
                type: "POST",
                timeout: -1,
                url: sumbitUrl,
                data: { 'action': type, 'id': id, 'title': title, 'summary': summary, 'intro': intro, 'notice_content': notice_content },
                success: function (data) {
                    if (data == "ok") {
                        var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
                        parent.Tab_OC("公告设置", title, "/ADAndNotice/AllNotice.aspx", "", true);
                    }
                    else {
                        $.messager.show({ title: '系统提示', msg: (data=="success"?"保存成功":data) });
                    }
                }
            });
        }

        $(function () {
            document.getElementById("edui1").style.cssText += ";width:100%;";
            document.getElementById("edui1_iframeholder").style.cssText += ";width:100%;";
            var height = document.body.clientHeight - $("#div_top").height() - 10;
            $("#div_tt").height(height);
            height = height - 11 - $("#tt_tr_1").height() - $("#tt_tr_2").height() - $("#tt_tr_3").height() - $("#edui1_toolbarbox").height() - $("#edui1_bottombar").height();
            $("#edui1_iframeholder").height(height > 300 ? height : 300);
        })
        window.onresize = function () {
            var height = document.body.clientHeight - $("#div_top").height() - 10;
            $("#div_tt").height(height);
        }
    </script>

    <style type="text/css">
        .TDtitle{height:25px;text-align:right;background-color:#e1f5fc;}
        .TDinput{height:25px;text-align:left;background-color: #ffffff;}
        .txt{margin-left:0px;margin-right:3px;}
        .txt input{width:100%;border:0px;}
        .txt textarea{width:100%;border:0px;}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="ff" runat="server" action="">
        <input id="sid" name="sid" type="hidden" value="<%=dt.Rows[0]["id"].ToString()%>"/>       
        <div id="div_top" style="">
            <div style="height:10px"></div>
            <div class="section-header">
                <div class="title">&nbsp;&nbsp;<img src="../../Images/8.png" alt="" /></div>
                <div class="options"><input type="button" id="btnSaveButton" value="保存" class="adminButtonBlue" onclick="save();"/>&nbsp;&nbsp;&nbsp;&nbsp;</div>
            </div>
        </div>
        <div id="div_tt" style="overflow:auto;margin-bottom:0px;margin-left:1px;margin-right:1px;">
            <table style="margin-left:0px;margin-right:1px;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                <tr id="tt_tr_1">
                    <td id="tt_tr_1_1" class="TDtitle">标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题：</td>
                    <td id="tt_tr_1_2" class="TDinput">
                        <div class="txt"><input type="text" id="txttitle" name="txttitle" value="<%=dt.Rows[0]["title"].ToString()%>"/></div>
                    </td>
                </tr>
                <tr id="tt_tr_2">
                    <td class="TDtitle">概&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;要：</td>
                    <td class="TDinput"><div class="txt"><input type="text" id="txtsummary" name="txtsummary" value="<%=dt.Rows[0]["summary"].ToString()%>"/></div></td>
                </tr>               
                <tr id="tt_tr_3">
                    <td class="TDtitle">简&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;介：</td>
                    <td class="TDinput"><div class="txt"><textarea id="txtintro" name="txtintro" cols="" rows="3"><%=dt.Rows[0]["intro"].ToString()%></textarea></div></td>
                </tr>
                <tr>
                    <td style="text-align:right;background-color:#e1f5fc;">正&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;文：</td>
                    <td id="editor_td" style="text-align:left; height: 25px;background-color: #ffffff;">                   
                        <textarea id="notice_content" name="notice_content" rows="" cols="">
                            <%=dt.Rows[0]["notice_content"].ToString()%>
                        </textarea>
                        <script type="text/javascript">
                            var editor = new baidu.editor.ui.Editor({
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
                                emotionLocalization: true
                                , autoHeightEnabled: false
                                , scaleEnabled: true
                                , elementPathEnabled: false                              
                            });
                            editor.render('notice_content');                                
                        </script>                       
                    </td>
                </tr>
            </table>
        </div>        
    </form>
</asp:Content>
