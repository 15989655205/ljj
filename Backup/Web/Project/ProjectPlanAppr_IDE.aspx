<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProjectPlanAppr_IDE.aspx.cs" Inherits="Maticsoft.Web.Project.ProjectPlanAppr_IDE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../uploadify/jquery.uploadify.min2.js" type="text/javascript"></script>

    <style type="text/css">
        .TDtitle{height:25px;text-align:right;background-color:#e1f5fc;}
        .TDinput{width: 35%;height:25px;text-align:left;background-color: #ffffff;}
        .TDinput1{height:25px;text-align:left;background-color: #ffffff;}
        #uploadify-queue{width:460px;height:190px;overflow:auto;}
    </style>

    <script type="text/javascript">

        $(function () {<%=jsStr%>});

        var type = '<%=Request.Params["type"]%>';
        var sid = '<%=dt.Rows[0]["review_id"].ToString()%>';

        function save() {
            var str = "";
            switch (type) {
                case "1":
                    if ($('input:radio[name="review_results"]:checked').val() == null) {
                        $.messager.show({ title: '系统提示', msg: '请先选择【主管审核结果】。' });
                        return;
                    }                  
                    str =" "+
                        $("#review_content").val() + "~"+
                        $("#ctl00_ContentPlaceHolder1_hdfileid").val() + "~"+
                        $("input:radio[name='review_results']:checked").val()+"~"+
                        $("#reason").val() + "~"+
                        $("#solution").val() + "~"+
                        $("#result").val();
                    break;
                case "2":
                    if ($('input:radio[name="review_status"]:checked').val() == null) {
                        $.messager.show({ title: '系统提示', msg: '请先选择【总审结果】。' });
                        return;
                    }
                    str = " "+
                        $('#review_content1').val() + '~'+
                        $('#ctl00_ContentPlaceHolder1_hdfileid1').val() + '~'+
                        $('input:radio[name="review_status"]:checked').val();
                    break;
                default: break;
            }
            //OpenLoading("Processing,please wait...");
            $.post(
                "../Ashx/ProjectAppr.ashx",
                { 'action': 'appr', 'type': type, 'sid': sid, 'str': str },
                function (data) {
                    if (data == "success") {
                        //CloseLoading();
                        $.messager.show({ title: '提示', msg: "保存成功！" });
                        var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
                        parent.Tab_OC("项目审批", title, "Project/ProjectPlanAppr.aspx", "", true);
                    }
                    else {
                        $.messager.show({ title: '系统提示', msg: data });
                        //CloseLoading();
                    }
                }
            );           
        }

        function addfile() {           
            document.getElementById("fileupload").innerHTML = "" +
                "<table class='table' style='width:480px;height:240px'>" +
                "   <tr>" +
                "       <td>上传目录：</td>" +
                "       <td><input id='cc' name='cc'/></td>  " +
                "   </tr>" +
                "   <tr><td colspan='2' style='width:100%;height:100%;'><div id='upload'></div></td></tr>" +
                "</table>";
            $('#cc').combogrid({
                url: '../Ashx/File.ashx?action=folder_uploade',
                panelWidth: 399,
                width:399,
                idField: 'ID',
                textField: 'folder_name',
                fitColumns: true,
                columns: [[
				    { title: '目录名', field: 'folder_name', width: 100 },
                    { title: '完整目录', field: 'folderpath', width: 200 },
			    ]],
                onClickRow: function (index, rowData) {
                    document.getElementById("upload").innerHTML = "<input type='file' id='uploadify' name='uploadify'/>";
                    $("#uploadify").uploadify({
                        height: 23,
                        width: 67,
                        swf: '/uploadify/uploadify.swf',
                        uploader: '/Ashx/FileUpload.ashx',
                        formData: { 'action': 'review', 'folderid': rowData.ID, 'folderpath': rowData.folder_path },
                        buttonImage: '/uploadify/selectfiles.png',
                        removeCompleted: true,
                        auto: true,
                        onUploadSuccess: function (file, data, flag) {
                            var f = data.split('|');var hdid;var hdfile;var fli;var ful;        
                            switch(type){
                                case"1":
                                    hdid="#ctl00_ContentPlaceHolder1_hdfileid";
                                    hdfile='#ctl00_ContentPlaceHolder1_hdreview_file';
                                    ful='#review_file_list';
                                    fli='review_file_list_sub_'+f[0];
                                    break;
                                case"2":
                                    hdid="#ctl00_ContentPlaceHolder1_hdfileid1";
                                    hdfile='#ctl00_ContentPlaceHolder1_hdreview_file1';
                                    ful='#review_file_list1';
                                    fli='review_file_list1_sub_'+f[0];
                                    break;                               
                            }                            
                            var li = '' +
                                '<li id="' + fli + '">' +
                                '   <img src="../uploadify/attach.png"/>' +
                                '   <a href="#" title="点击下载" style="text-decoration:none;"' +
                                '       onclick="downloadfile(\'' + file.name + '\',\'' + f[0] + '\',\'' + f[1] + '\');">' +
                                '       <font color="blue">' + file.name + '</font>' +
                                //'   </a>&nbsp;&nbsp;<a href="#" class="a" onclick="openView(\'/FileUpload' + f[0] + '\',\'' +f[1]+ '\')" >预览</a>&nbsp;&nbsp;<a href="#" class="a" style="cursor:pointer;" onclick="download(\'' + file.name + '|' + f[0] + '|' + f[1] + '\');">下载</a>' +
                                '   </a>&nbsp;&nbsp;<a href="#" class="a" onclick="openView(\'' + file.name + '\',\'' + f[0] + '\',\'' + f[1] + '\')" >预览</a>&nbsp;&nbsp;<a href="#" class="a" style="cursor:pointer;" onclick="download(\'' + file.name + '|' + f[0] + '|' + f[1] + '\');">下载</a>' +
                                '   &nbsp;&nbsp;&nbsp;&nbsp;' +
                                '   <a href="#" onclick="deletefile(\'' + fli + '\',\'' + f[0] + '\',\'' + rowData.folder_path + '/' + f[1] + '\');">' +
                                '       <img src="../uploadify/del.png"/>' +
                                '   </a>' +
                                '</li>';                           
                            $(li).appendTo($(ful));
                            $(hdid).val($(hdid).val() + f[0] + ",");
                            $(hdfile).val($(hdfile).val() + li);
                        }
                    });
                }
            });
            art.dialog({
                content: document.getElementById('fileupload'),
                id: 'file_dialog',
                title: '上传文件',
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                lock: true,
                close: function () { },
                button: [{ name: '关闭'}]
            });
        }

        function deletefile(liid, fileid, filepath) {
            $.ajax({
                type: "POST",
                timeout: -1,
                url: "/Ashx/File.ashx",
                data: { 'action': 'del', 'fileid': fileid, 'filepath': filepath },
                success: function (data) {
                    if (data == "success") {                        
                        $("#" + liid).remove();
                        var hdfile;var ful
                        switch(type){
                            case"1":
                                hdfile='#ctl00_ContentPlaceHolder1_hdreview_file';
                                ful=document.getElementById("review_file_list").innerHTML;
                                break;
                            case"2":
                                hdfile='#ctl00_ContentPlaceHolder1_hdreview_file1';
                                ful=document.getElementById("review_file_list1").innerHTML;
                                break;
                            default:break;
                        }
                        $(hdfile).val(ful);
                    }
                    else {
                        $.messager.show({ title: '系统提示', msg: '附件删除失败。' });
                    }
                }
            });
        }

//        function openView(url,ID) {
//            var nw = window.open(url, "big", "top=0, left=0, toolbar=no, menubar=yes, scrollbars=yes, resizable=yes,location=no, status=no,channelmode = yes");
//            $("#ctl00_ContentPlaceHolder1_hdfid").val(ID);
//            $("#ctl00_ContentPlaceHolder1_btnViewDownload").click();
//             try {
//                nw.document.title = "预览";
//            }
//            catch (e) {
//            }
//        }

        function openView(fileName, Path, ID) {
            $.ajax({
                type: "Post",
                async: false,
                url: "/Ashx/File.ashx?action=fileDownloadCount&fid=" + ID,
                data: "",
                success: function (res) {
                    if (res == 1) {
                        openViewShow('/FileUpload' + Path);
                    }
                }
            });
        }

        function openViewShow(url) {
            var nw = window.open(url, "big", "top=0, left=0, toolbar=no, menubar=yes, scrollbars=yes, resizable=yes,location=no, status=no,channelmode = yes");
            try {
                nw.document.title = "预览";
                nw.focus();
            }
            catch (e) {
            }
        }
        function download(file) {
            $("#ctl00_ContentPlaceHolder1_hdfile").val(file);
            $("#ctl00_ContentPlaceHolder1_btnDownload").click();
        }

        function showmsg() {
            $.messager.show({ title: '系统提示', msg: '文件不存在。' });
        }
              
        window.onload=window.onresize=function(){          
           document.getElementById('div_down').style.height=document.body.clientHeight-document.getElementById('div_top').clientHeight;          
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div id="div_top" style="width:100%;">
        <table id="PrintHide" style="width:100%;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img alt="" src="../images/BanKuaiJianTou.gif"/></td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <%--<img id="show" src="../images/Button/t.jpg" alt="" runat="server" onclick="ShowAppr()" style="cursor:pointer;"/>
                    <img id="split" runat="server" alt="" src="../images/Button/JianGe.jpg" />&nbsp;--%>
                    <img id="submit" src="../images/Button/Submit.jpg" alt="" runat="server" onclick="save();" style="cursor:pointer;"/>&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr><td height="3px" colspan="2" style="background-color: #ffffff"></td></tr>
        </table>
    </div>
    <div id="div_down" style="width:100%;margin-top:0px;margin-bottom:0px;overflow:auto;">
        <table style="width:100%;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr><td colspan="4" style="background-color:#e1f5fc;height:25px;text-align:center;"><strong>计划基本属性</strong></td></tr>
            <tr>
                <td class="TDtitle">项目名称：</td>
                <td class="TDinput"><%=dt.Rows[0]["project_code"].ToString()%></td>
                <td class="TDtitle">项目编号：</td>
                <td class="TDinput"><%=dt.Rows[0]["project_name"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">阶&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;段：</td>
                <td class="TDinput"><%=dt.Rows[0]["stage_name"].ToString()%></td>
                <td class="TDtitle">小&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;组：</td>
                <td class="TDinput"><%=dt.Rows[0]["group_name"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">工作内容：</td>
                <td class="TDinput"><%=dt.Rows[0]["jobduties_name"].ToString()%></td>
                <td class="TDtitle">细&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;目：</td>
                <td class="TDinput"><%=dt.Rows[0]["detail_name"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">负&nbsp;&nbsp;责&nbsp;&nbsp;人：</td>
                <td class="TDinput1" colspan="3"><%=dt.Rows[0]["names"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">开始日期：</td>
                <td class="TDinput"><%=dt.Rows[0]["begin_date"].ToString()%></td>
                <td class="TDtitle">结束日期：</td>
                <td class="TDinput"><%=dt.Rows[0]["end_date"].ToString()%></td>
            </tr>

            <tr><td colspan="4" style="background-color:#e1f5fc;height:25px;text-align:center;"><strong>项目审批</strong></td></tr>
            <tr>
                <td class="TDtitle">提&nbsp;&nbsp;交&nbsp;&nbsp;人：</td>
                <td class="TDinput"><%=dt.Rows[0]["sumbit_user"].ToString()%></td>
                <td class="TDtitle">提交时间：</td>
                <td class="TDinput"><%=dt.Rows[0]["sumbit_date"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">提交内容：</td>
                <td class="TDinput1" colspan="3"><%=dt.Rows[0]["sumbit_content"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">提交附件：</td>
                <td class="TDinput1" colspan="3"><ul id='sumbit_file_list' style='margin:0;paddin:0;margin-left:-28px'><%=accessory%></ul></td>
            </tr>
            <tr>
                <td class="TDtitle">主管审核意见：</td>
                <td class="TDinput" colspan="3"><%=review_content%></td>
            </tr>
            <tr>
                <td class="TDtitle">
                    <%=Request.Params["type"] == "1" 
                        ? "<a href='#' style='text-decoration:none;color:blue;' onclick=\"addfile()\"><img style='vertical-align:middle' src='../js/themes/icons/attach.png'/>主管审核附件：</a>"
                        : "主管审核附件："%>
                </td>
                <td class="TDinput" colspan="3"><ul id='review_file_list' style='margin:0;paddin:0;margin-left:-28px'><%=review_accessory%></ul></td>
            </tr>
            <tr>
                <td class="TDtitle">主管审核结果：</td>
                <td class="TDinput" colspan="3"><%=status%></td>
            </tr>
            <tr>
                <td class="TDtitle">未完成的原因：</td>
                <td class="TDinput" colspan="3"><%=reason%></td>
            </tr>
            <tr>
                <td class="TDtitle">解决的办法：</td>
                <td class="TDinput" colspan="3"><%=solution%></td>
            </tr>
            <tr>
                <td class="TDtitle">解决的结果：</td>
                <td class="TDinput" colspan="3"><%=result%></td>
            </tr>
            <%=review1%>      
        </table>
    </div>
   

    <div id="fileupload" style="display:none;"></div>

    <form runat="server" style="display:none;">
        <asp:HiddenField runat="server" ID="hdfile"/>
        <asp:HiddenField runat="server" ID="hdfileid"/>
        <asp:HiddenField runat="server" ID="hdfileid1"/>
        <asp:HiddenField runat="server" ID="hdreview_file"/>
        <asp:HiddenField runat="server" ID="hdreview_file1"/>
        <asp:Button runat="server" ID="btnDownload" onclick="btnDownload_Click"/>
        <asp:HiddenField ID="hdfid" runat="server"/>
        <asp:Button ID="btnViewDownload" runat="server" Text="Button" onclick="Button2_Click" />  
    </form>
</asp:Content>
