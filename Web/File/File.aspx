<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="File.aspx.cs" Inherits="Maticsoft.Web.File.File" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="file_ide" TagName="File_ide" Src="../Controls/File/File_IDE.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../uploadify/jquery.uploadify.min2.js" type="text/javascript"></script>

    <script type="text/javascript">

        $(function () {            
            $('#tt').datagrid({
                url: '../Ashx/File.ashx',
                queryParams: { "action": "listbyuser" },
                loadMsg: '正在努力加载中...',
                idField: 'ID',
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                fitColumns: true,
                pagination: true,
                remoteSort: true,
                rownumbers: true,
                singleSelect: false,
                frozenColumns: [[
                    { field: 'ckb', checkbox: true, width: 10 },                   
                ]],
                columns: [[
                     { title: '文件名', field: 'file_name', width: 100, sortable: true },
                    { title: '类型', field: 'type', width: 100, sortable: true, align: 'center' },
                    { title: '文件夹', field: 'cate_idName', width: 100, sortable: true },
                    { title: '上传时间', field: 'up_date', width: 100, sortable: true, align: 'center' },
                    { title: '修改时间', field: 'updata_datetiem', width: 100, sortable: true, align: 'center' },
                    { title: '备注', field: 'Remark', width: 100, sortable: true,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '加密状态', field: 'pwdflag', width: 100, sortable: true, align: 'center',
                        formatter: function (value, row, index) { return value == 1 ? "已加密" : "未加密"; }
                    },
                    { title: '下载', field: 'count', width: 100, sortable: true, align: 'center' }
                    ,
                    { title: '预览', field: 'view', sortable: true, width: 60,
                        formatter: function (value, rowData, rowIndex) {
                            return '' +
                                '<a href="#" style="text-decoration:none;" onclick="viewdownload(' + rowIndex + ');">' +
                                '预览' +
                                '</a>';
                        }
                    }
				]],
                onClickCell: function (rowIndex, field, value) { $('#tt').datagrid('clearSelections'); },
                onHeaderContextMenu: function (e, field) {
                    e.preventDefault();
                    if (!cmenu) { createColumnMenu(); }
                    cmenu.menu('show', { left: e.pageX, top: e.pageY });
                },
                toolbar: "#tab_toolbar"
            });
        });

        var cmenu;
        function createColumnMenu() {
            cmenu = $('<div/>').appendTo('body');
            cmenu.menu({
                onClick: function (item) {
                    if (item.iconCls == 'icon-ok') {
                        $('#tt').datagrid('hideColumn', item.name);
                        cmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-empty'
                        });
                    } else {
                        $('#tt').datagrid('showColumn', item.name);
                        cmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-ok'
                        });
                    }
                }
            });
            var fields = $('#tt').datagrid('getColumnFields');
            for (var i = 0; i < fields.length; i++) {
                var field = fields[i];
                var col = $('#tt').datagrid('getColumnOption', field);
                cmenu.menu('appendItem', {
                    text: col.title,
                    name: field,
                    iconCls: 'icon-ok'
                });
            }
        }

        function viewdownload(rowIndex) {
            action = 2;
            var row = $("#tt").datagrid("getRows")[rowIndex];
            if (row.pwdflag == 1 && userDownloadFlag != "ok") {
                $("#txtpwd").val('');
                art.dialog({
                    content: document.getElementById('pwd'),
                    id: 'pwd_dialog',
                    title: '文件预览',
                    lock: true,
                    padding: '0px 0px 0px 0px',
                    background: '#c3c3c3',
                    button: [
                        { name: '确定', callback: function () { pwdchecking(row); }, focus: true },
                        { name: '关闭' }
                    ]
                });
            }
            else {
                downloadclick(row);
            }
        }

        function pwdchecking(row) {
            var pwd = $("#txtpwd").val();
            art.dialog.get('pwd_dialog').close();
            if (row.pwd == pwd) {
                downloadclick(row);
            }
            else {
                $.messager.show({ title: '系统提示', msg: '密码不正确。' });
            }
        }

        function downloadclick(row) {
            openView(row.file_name, row.Path, row.ID);
            $('#tt').datagrid('reload');
        }

        function openView(fileName, Path, ID) {
            $.ajax({
                type: "Post",
                async: false,
                url: "/Ashx/File.ashx?action=fileDownloadCount&fid=" + ID,
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

        //高级查询
        function asearch() {
        }

        //快速搜索
        function qsearch(v) {
            $('#tt').datagrid('options').queryParams = { "action": "listbyuser", "key": v };
            $('#tt').datagrid('load');
        }

        //添加新记录
        function addfile() {
            //parent.addTab_Ext('文件上传', "/File/FileUpload.aspx", "", false); 
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
                        formData: { 'action': 'upload', 'folderid': rowData.ID, 'folderpath': rowData.folder_path },
                        buttonImage: '/uploadify/selectfiles.png',
                        removeCompleted: true,
                        auto: true,
                        onUploadComplete: function (file) { $("#tt").datagrid("reload"); }
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


        //编辑事件
        function editfile() {
            var row = whether('编辑');
            if (row != null) {
                openDialog("edit", row, "编辑");
            }
        }

        //查看事件
        function viewfile() {
            var row = whether('查看');
            if (row != null) {
                openDialog("view", row, "查看");
            }
        }

        //是否可以复制、编辑、查看
        function whether(value) {
            var row = $('#tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '系统提示', msg: '请选择您要“' + value + '”的数据。' });
                return null;
            }
            if (art.dialog.get('file_dialog') != null) {
                art.dialog.get('file_dialog').close();
            }
            return row;
        }

        //批量删除
        function delfile() {
            var selected = "";
            $($('#tt').datagrid('getSelections')).each(function () {
                selected += "'" + this.ID + "',";
            });
            selected = selected.substr(0, selected.length - 1);
            if (selected == "") {
                $.messager.show({ title: '系统提示', msg: '请选择您要“删除”的数据。' });
                return;
            }
            $.messager.confirm('系统提示', '确认删除？', function (r) {
                if (r) {
                    $.post('../Ashx/File.ashx', { "action": "dels", "cbx_select": selected }, function (data) {
                        if (data == "success") {
                            $("#tt").datagrid("reload");
                            $.messager.show({ title: '系统提示', msg: "删除成功。" });
                        }
                        else {
                            $.messager.show({ title: '系统提示', msg: (data=="success"?"保存成功":data) });
                        }
                    });
                }
            });
        }
    </script>

    <style type="text/css">
        #uploadify-queue{width:460px;height:190px;overflow:auto;}      
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <toolbar:ToolBar runat="server" id="toolbar1" PageID="1511"/>

    <table id="tt"></table>

    <div id="detail" style="display:none;">
        <file_ide:File_ide runat="server"/>
    </div>

    <div id="fileupload" style="display:none;"></div>
    <div id="pwd" style="display:none;">
        请输入下载密码：<br/>
        <input type="password" id="txtpwd" name="txtpwd"/>
    </div>
</asp:Content>
