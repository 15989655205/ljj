<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProjectPlanAppr_IDE.aspx.cs" Inherits="Maticsoft.Web.Project111.ProjectPlanAppr_IDE" %>
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

        var type = '<%=Request.Params["review"]%>';
        var sid = '<%=dt.Rows[0]["review_id"].ToString()%>';   
        function save() {
            //var val = $('input:radio[name="results"]:checked').val();
            //if (val == null) {
            //    $.messager.show({ title: '错误提示', msg: "请选择审批结果！" });
            //    return false;
            //}

            //val = $('input:radio[name="status"]:checked').val();
            //if (val == null) {
            //    $.messager.show({ title: '错误提示', msg: "请选择完成质量！" });
            //    return false;
            //}            
            var str = "";
            switch (type) {
                case "1":
                    if ($('input:radio[name="review_results"]:checked').val() == null) {
                        $.messager.show({ title: '系统提示', msg: '请先选择【初审结果】。' });
                        return;
                    }
                    str += $('#review_content').val() + '~';
                    str += $('#hdreview_file').val() + '~';
                    str += $('input:radio[name="review_results"]:checked').val();
                    break;
                case "2":
                    if ($('input:radio[name="review_results1"]:checked').val() == null) {
                        $.messager.show({ title: '系统提示', msg: '请先选择【复审结果】。' });
                        return;
                    }
                    str += $('#review_content1').val() + '~';
                    str += $('#hdreview_file1').val() + '~';
                    str += $('input:radio[name="review_results1"]:checked').val();
                    break;
                case "3":
                    if ($('input:radio[name="review_results2"]:checked').val() == null) {
                        $.messager.show({ title: '系统提示', msg: '请先选择【终审结果】。' });
                        return;
                    }
                    str += $('#review_content2').val() + '~';
                    str += $('#hdreview_file2').val() + '~';
                    str += $('input:radio[name="review_results2"]:checked').val();                   
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
                            var f = data.split('|');
                            var hd;
                            var fl;
                            var fu;
                            switch(type){
                                case'1':hd='#hdreview_file';fl='review_file_list_sub_'+f[0];fu='#review_file_list';break;
                                case'2':hd='#hdreview_file1';fl='review_file_list1_sub_'+f[0];fu='#review_file_list1';break;
                                case'3':hd='#hdreview_file2';fl='review_file_list2_sub_'+f[0];fu='#review_file_list2';break;
                            }
                            $(hd).val($(hd).val() + f[0] + ",");
                            var li = '' +
                                '<li id="' + fl + '">' +
                                '   <img src="../uploadify/attach.png"/>' +
                                '   <a href="#" title="点击下载" style="text-decoration:none;"' +
                                '       onclick="downloadfile(\'' + file.name + '\',\'' + f[0] + '\',\'' + f[1] + '\');">' +
                                '       <font color="blue">' + file.name + '</font>' +
                                '   </a>' +
                                '   &nbsp;&nbsp;&nbsp;&nbsp;' +
                                '   <a href="#" onclick="deletefile(\'' + fl + '\',\'' + f[0] + '\',\'' + rowData.folder_path + '/' + f[1] + '\');">' +
                                '       <img src="../uploadify/del.png"/>' +
                                '   </a>' +
                                '</li>';
                            $(li).appendTo($(fu));
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
                button: [{ name: '取消'}]
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
                        //$('#sub_tt').datagrid("reload");
                        $("#" + liid).remove();
                    }
                    else {
                        $.messager.show({ title: '系统提示', msg: '附件删除失败。' });
                    }
                }
            });
        }

        function download(file) {
            $("#ctl00_ContentPlaceHolder1_hdfile").val(file);
            $("#ctl00_ContentPlaceHolder1_btnDownload").click();
        }

        function showmsg() {
            $.messager.show({ title: '系统提示', msg: '文件不存在。' });
        }
              
        window.onresize=function(){          
           document.getElementById('div_down').style.height=document.body.clientHeight-document.getElementById('div_top').clientHeight;          
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <div id="div_top" style="width:100%;">
        <table id="PrintHide" style="width:100%;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif"/></td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <%--<img id="show" src="../images/Button/t.jpg" alt="" runat="server" onclick="ShowAppr()" style="cursor:pointer;"/>
                    <img id="split" runat="server" alt="" src="../images/Button/JianGe.jpg" />&nbsp;--%>
                    <img id="submit" src="../images/Button/Submit.jpg" alt="" runat="server" onclick="save();" style="cursor:pointer;"/>&nbsp;&nbsp;
                </td>
            </tr>
            <tr><td height="3px" colspan="2" style="background-color: #ffffff"></td></tr>
        </table>
    </div>
    <div id="div_down" style="width:100%;margin-top:0px;margin-bottom:0px;overflow:auto;">
        <table style="width:100%;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr><td colspan="4" style="background-color:#e1f5fc;height:25px;text-align:center;"><strong>计划基本属性</strong></td></tr>
            <tr>
                <td class="TDtitle">项目名称：</td><td class="TDinput"><%=dt.Rows[0]["project_code"].ToString()%></td>
                <td class="TDtitle">项目编号：</td><td class="TDinput"><%=dt.Rows[0]["project_name"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">阶&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;段：</td><td class="TDinput"><%=dt.Rows[0]["stage_name"].ToString()%></td>
                <td class="TDtitle">小&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;组：</td><td class="TDinput"><%=dt.Rows[0]["group_name"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">工作内容：</td><td class="TDinput"><%=dt.Rows[0]["jobduties_name"].ToString()%></td>
                <td class="TDtitle">细&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;目：</td><td class="TDinput"><%=dt.Rows[0]["detail_name"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">负&nbsp;&nbsp;责&nbsp;&nbsp;人：</td><td class="TDinput1" colspan="3"><%=dt.Rows[0]["names"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">开始日期：</td><td class="TDinput"><%=dt.Rows[0]["begin_date"].ToString()%></td>
                <td class="TDtitle">结束日期：</td><td class="TDinput"><%=dt.Rows[0]["end_date"].ToString()%></td>
            </tr>

            <tr><td colspan="4" style="background-color:#e1f5fc;height:25px;text-align:center;"><strong>项目审批</strong></td></tr>
            <tr>
                <td class="TDtitle">提&nbsp;&nbsp;交&nbsp;&nbsp;人：</td><td class="TDinput"><%=dt.Rows[0]["sumbit_user"].ToString()%></td>
                <td class="TDtitle">提交时间：</td><td class="TDinput"><%=dt.Rows[0]["sumbit_date"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">提交内容：</td><td class="TDinput1" colspan="3"><%=dt.Rows[0]["sumbit_content"].ToString()%></td>
            </tr>
            <tr>
                <td class="TDtitle">提交附件：</td><td class="TDinput1" colspan="3"><%=accessory%></td>
            </tr>
            <tr>
                <td class="TDtitle">初审意见：</td>
                <td class="TDinput" colspan="3"><%=review_content%></td>
            </tr>
            <tr>
                <td class="TDtitle"><%=Request.Params["review"] == "1" ? "<a href='#' onclick=\"addfile()\">初审附件：</a>" : "初审附件："%></a></td>
                <td class="TDinput" colspan="3">                    
                    <div id="review_file_list"><%=review_accessory%></div>
                </td>
            </tr>
            <tr>
                <td class="TDtitle">初审结果：</td>
                <td class="TDinput" colspan="3"><%=status%></td>
            </tr>
            <%=string.Format(review1, review_content1, review_accessory1, status1)%>
            <%=string.Format(review2, review_content2, review_accessory2)%>
        </table>
    </div>
   
        <%--<table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="padding-left: 2px; padding-top:4px; padding-bottom:2px; vertical-align:middle;">
                </td>
            </tr>
        </table>--%>

    <div id="fileupload" style="display:none;"></div>

    <form runat="server" style="display:none;">
        <asp:HiddenField runat="server" ID="hdfile"/>
        <input type="hidden" id="hdreview_file" value=","/>
        <input type="hidden" id="hdreview_file1" value=","/>
        <input type="hidden" id="hdreview_file2" value=","/>
        <asp:HiddenField runat="server" ID="hdreview_file"/>
        <asp:HiddenField runat="server" ID="hdreview_file1"/>
        <asp:HiddenField runat="server" ID="hdreview_file2"/>
        <asp:Button runat="server" ID="btnDownload" onclick="btnDownload_Click" />
    </form>
</asp:Content>
