<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Review_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.Project111.Review_IDE" %>

<link href="/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
<script src="/uploadify/jquery.uploadify.min2.js" type="text/javascript"></script>

<script type="text/javascript">
    var dlg = art.dialog;
    var sumbitUrl = "";
    var isload = true;
    var loadflag = true;

    $(function () {
        if (isload) {
            jQuery("#ff").validationEngine({ showOnMouseOver: false, promptPosition: 'topLeft', autoHidePrompt: true, autoHideDelay: 2000 });           
            isload = false;
        }
    });

    function combogridload() {
        document.getElementById('div_cc').innerHTML = '<input id="cc" name="cc"/>';
        $('#cc').combogrid({
            url: '../Ashx/File.ashx?action=folder_uploade',
            panelWidth: 500,
            idField: 'ID',
            textField: 'folder_name',
            fitColumns: true,
            columns: [[
				{ title: '目录名', field: 'folder_name', width: 100 },
                { title: '完整目录', field: 'folderpath', width: 200 },
			]],
            onClickRow: function (rowIndex, rowData) {
                document.getElementById('fileupload').innerHTML = '<input type="file" id="uploadify" name="uploadify"/>';
                $("#uploadify").uploadify({
                    swf: '/uploadify/uploadify.swf',
                    uploader: '/Ashx/FileUpload.ashx',
                    formData: { 'action': 'review', 'folderid': rowData.ID, 'folderpath': rowData.folder_path },
                    buttonImage: '/uploadify/selectfiles.png',
                    height: 23,
                    width: 67,
                    auto: true,
                    removeCompleted: true,
                    onUploadSuccess: function (file, data, flag) {
                        var f = data.split('|');
                        var name = file.name.length > 12 ? file.name.substr(0, 11) + '…' : file.name; 
                        $('#hdfileid').val($('#hdfileid').val() + f[0] + ",");
                        var li = '' +
                            '<li id="filelist_sub' + f[0] + '">' +
                            '   <img src="../uploadify/attach.png"/>' +
                            '   <a href="#" title="' + file.name + '" style="text-decoration:none;"' +
                            '       onclick="downloadfile(\'' + file.name + '\',\'' + f[0] + '\',\'' + f[1] + '\');">' +
                            '       <font color="blue">' + name + '</font>' +
                            '   </a>' +
                            '   &nbsp;&nbsp;&nbsp;&nbsp;' +
                            '   <a href="#" onclick="deletefile(\'filelist_sub' + f[0] + '\',\'' + f[0] + '\',\'' + rowData.folder_path + '/' + f[1] + '\');">' +
                            '       <img src="../uploadify/del.png"/>' +
                            '   </a>' +
                            '</li>';
                        $(li).appendTo($("#filelist"));
                    }
                });
            }
        });
    }
    
    function openDialog(type, row, title) {
        combogridload();
        $('#hdsi_sid').val(si_sid);
        document.getElementById('files').innerHTML = '<ul id="filelist" style="margin-top:0px;"></ul>';
        document.getElementById('fileupload').innerHTML = '';
        switch (type) {
            case "add":
                sumbitUrl = "../Ashx/MyProjectPlan.ashx?action=add";
                ClearControl();
                break;
            case "edit":
                sumbitUrl = "../Ashx/MyProjectPlan.ashx?action=edit";
                showData(row,"edit");
                break;
            case "view":
                showData(row,"view");
                break;
        }
        if (art.dialog.list['review_dialog'] == null) {
            art.dialog({
                content: document.getElementById('detail'),
                id: 'review_dialog',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                lock: type != "view",
                init: function () { },
                close: function () { },
                button: [
                    { name: '保存', callback: function () { save(); return false; }, focus: true },
                    { name: '关闭' }
                ]
            });
        }
        ControlReadonly(type == "view");
    }

    function ClearControl() {
        $('#hdsid').val('');
        $('#hdfileid').val(',');
        $('#txtsumbit_content').val('');
    }

    function showData(row,type) {
        $('#hdsid').val(row.sid);
        $('#hdfileid').val(row.sumbit_file);
        $('#txtsumbit_content').val(row.sumbit_content);

        if (row.sumbit_filename != "") {
            var liname = row.sumbit_filename.split(' : ');
            var liid = row.sumbit_file.split(',');
            var lipath = row.sumbit_filepath.split(' | ');
            for (var i = 0; i < liname.length; i++) {
                var name = liname[i].length > 12 ? liname[i].substr(0, 11) + '…' : liname[i]; 
                var li = '' +
                    '<li id="filelist_sub' + liid[i + 1] + '">' +
                    '   <img src="../uploadify/attach.png"/>' +
                    '   <a href="#" title="' + liname[i] + '" style="text-decoration:none;"' +
                    '       onclick="downloadfile(\'' + liname[i] + '\',\'' + liid[i + 1] + '\',\'' + lipath[i] + '\');">' +
                    '       ' + name +
                    '   </a>';
                if (type == "edit") {
                    li = li +
                        '   &nbsp;&nbsp;&nbsp;&nbsp;' +
                        '   <a href="#" onclick="deletefile(\'filelist_sub' + liid[i + 1] + '\',\'' + liid[i + 1] + '\',\'' + lipath[i] + '\');">' +
                        '       <img src="../uploadify/del.png"/>' +
                        '   </a>';
                }
                li = li + '</li>';
                $(li).appendTo($("#filelist"));
            }
        }
    }
    function downloadfile(filename, fileid, filepath) {
        
    }

    function deletefile(liid, fileid, filepath) {
        $.ajax({
            type: "POST",
            timeout: -1,
            url: "/Ashx/File.ashx",
            data: { 'action': 'del', 'fileid': fileid, 'filepath': filepath },
            success: function (data) {
                if (data == "success") {
                    $('#sub_tt').datagrid("reload");
                    $("#" + liid).remove();
                }
                else {
                    $.messager.show({ title: '系统提示', msg: '附件删除失败。' });
                }
            }
        }); 
    }

    function ControlReadonly(flag) {
        document.getElementById("txtsumbit_content").readOnly = flag
        $('#cc').combogrid(flag ? 'disable' : 'enable');
        art.dialog.list['review_dialog'].button({ name: '保存', disabled: flag });
    }

    function ButtonLock(flag) {
        art.dialog.list['review_dialog'].button({ name: '保存', disabled: flag }, { name: '关闭', disabled: flag });
    }

    function save() {
        ButtonLock(true);

        if ($("#txtsumbit_content").val().replaceAll(' ', '') == '') {
            ButtonLock(false);
            $.messager.show({ title: '系统提示', msg: '【提交说明】不能为空。' });
            return;
        }

        if (!jQuery('#ff').validationEngine('validate')) {
            ButtonLock(false);
            return;
        }

        $('#ff').form('submit', {
            url: sumbitUrl,
            onSubmit: function () { /*做某些检查,返回 false 来阻止提交*/ },
            success: function (data) {
                if (data == "ok") {
                    $('#sub_tt').datagrid("reload");
                    art.dialog.list['review_dialog'].close();
                    $.messager.show({ title: '系统提示', msg: '保存成功。' });
                }
                else {
                    $.messager.show({ title: '系统提示', msg: data });
                    ButtonLock(false);
                }
            }
        });
    }

</script>

 <style type="text/css">
    #uploadify-queue{width:235px;height:150px;overflow:auto;}
    .li li {line-height: 30px;}
    .li li:hover{color:red}
</style>
<%--no-repeat scroll 0px 16px transparent padding-left: 15px;--%>
<form action="" id="ff" method="post">
    <input type="hidden" id="hdsid" name="hdsid"/>
    <input type="hidden" id="hdfileid" name="hdfileid" value=","/>
    <input type="hidden" id="hdsi_sid" name="hdsi_sid"/>
    <table class="table">
        <tr>
            <td class="titleTD">提交说明：</td>
            <td class="inputTD" colspan="2"><textarea id="txtsumbit_content" name="txtsumbit_content" rows="4" cols="" style="width:480px;"></textarea></td>
        </tr>
        <tr>
            <td class="titleTD" rowspan="2">附&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;件：</td>
            <td class="inputTD" colspan="2">附件上传目录<div id="div_cc"></div></td>
        </tr>
        <tr>
            <td><div id="fileupload"></div></td>
            <td><div id="files" class="li" style=" width:240px;height:200px;overflow:auto;"></div></td>
        </tr>
    </table>
</form>