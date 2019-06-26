<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CopyFolder.ascx.cs" Inherits="Maticsoft.Web.Controls.File.CopyFolder" %>
<script type="text/javascript">
    function openDialog(type, row, title) {
        //alert(index);
        //var rows = $('#tt').datagrid('getRows');
        //var row = rows[index];
        $('#copyid').val(row.ID);
        $('#showCopy').val(row.folder_path );
        var sid = row.folder_level;
//        if (sid == 0) {
//            //sid = row.ID;
//        }
        //folderParent(sid);
        $('#parent_ct').combotree('setValue', sid);
        var tree = $('#parent_ct').combotree("tree");
        var node = tree.tree('find', $('#copyid').val());
        if(node!=null)
            tree.tree("remove", node.target);
        switch (type) {
            case "copy":
                sumbitUrl = "../Ashx/Folder.ashx?action=copy";
                break;
        }
        if (art.dialog.list['copy_folder_dialog'] == null) {
            art.dialog({
                content: document.getElementById('detail'),
                id: 'copy_folder_dialog',
                title: title,
                lock: type != "view",
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                button: [
                    { name: '保存', callback: function () { save(); return false; }, focus: true },
                    { name: '关闭', callback: function () { $("#parent_ct").combotree("reload", "../Ashx/Folder.ashx?action=get_comboxtree"); } }
                ]
            });
        }
    }

    function folderParent() {
        $("#parent_ct").combotree({
            url: '../Ashx/Folder.ashx?action=get_comboxtree',
            required: true,
            onLoadSuccess: function (row, data) {
                                $("#parent_ct").combotree('tree').tree('collapseAll');
                //                $('#parent_ct').combotree('setValue', id);
                ////                var t = $('#parent_ct').combotree('tree');
                ////                var node = t.tree('find', id);
                ////                t.tree("select", node.target);


            }
//            ,
//            onChange: function () {
//                //$('#parentPath').val($(this).combotree('getText'));
//            }
        });
    }

    function save() {
        if ($('#ff').form('validate')) {
            OpenLoading_me("Processing,please wait...");
            //OpenLoading("Processing,please wait...");
            $.ajax({
                //cache: true,
                type: "POST",
                url: '../Ashx/Folder.ashx?action=copyFolder',
                data: $('#ff').serialize(), // 你的formid
                //async: false,
                error: function (request) {
                    //alert("Connection error");
                    CloseLoading();
                },
                success: function (data) {
                    if (data == "success") {
                        $('#tt').treegrid('reload',0);
                        $("#parent_ct").combotree("reload");
                        
                        $("#folderName").val("");
                        $.messager.show({ title: '提示', msg: "保存成功！" });
                        art.dialog.list["copy_folder_dialog"].close();
                    }
                    else
                        $.messager.show({ title: '提示', msg: data });
                    //alert(data);
                    //$("#commonLayout_appcreshi").parent().html(data);
                    CloseLoading();
                }
//                ,
//                error: function (XMLHttpRequest, textStatus, errorThrown) {
//                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
//                    CloseLoading();
//                }
            });
            
        }
    }
</script>
<form action="" id="ff">
<input type="hidden" id="copyid" name="copyid" />
<input type="hidden" id="parentPath" name="parentPath" />
<table class="table">
        <tr>
            <td class="titleTD">复制对象：</td>
            <td class="inputTD"><input id="showCopy" name="showCopy" readonly="readonly" style="width:400px;"/></td>           
        </tr>
        <tr>
            <td class="titleTD">父&nbsp;&nbsp;目&nbsp;&nbsp;录：</td>
            <td class="inputTD"><input type="text" id="parent_ct" name="parent_ct" style="width:400px;"  /></td>            
        </tr>
        <tr>
            <td class="titleTD">文件夹名称：</td>
            <td class="inputTD"><input type="text" id="folderName" name="folderName" style="width:400px;" class="easyui-validatebox" data-options="required:true"/></td>           
        </tr>
	</table>
</form>