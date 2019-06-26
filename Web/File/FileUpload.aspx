<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="Maticsoft.Web.File.FileUpload" %>
<%--<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../uploadify/jquery.uploadify.min2.js" type="text/javascript"></script>
        
    <script type="text/javascript">

        var rowData = null;

        $(function () {
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
                onClickRow: function (index, row) { rowData = row; }
            });
            $('#ipt_search').searchbox({ menu: "#search_menu", searcher: function (value, name) { qsearch(value, name); } });
            getFiles();
        });

        function Show() {
            if (rowData != null) {
                document.getElementById("file").innerHTML = "<input type='file' id='uploadify' name='uploadify'/>";
                InitUpload();
                art.dialog({
                    content: document.getElementById('file'),
                    id: 'file_dialog',
                    title: '上传文件',
                    padding: '0px 0px 0px 0px',
                    background: '#c3c3c3',
                    lock: true,
                    close: function () { ClearQueue(); },
                    button: [
                        { name: '上传', callback: function () { Upload(); return false; }, focus: true },
                        { name: '取消', callback: function () { } }
                    ]
                });
            }
            else {
                $.messager.show({ title: '系统提示', msg: '请先选择【上传目录】。' });
            }
        }
                
        function Upload() {
            ButtonLock(true);
            $('#uploadify').uploadify('upload', '*')
            ButtonLock(false);
        }

        function ClearQueue() {
            ButtonLock(false);
        }
        

        function ButtonLock(flag) {
            art.dialog.list['file_dialog'].button({ name: '上传', disabled: flag }, { name: '取消', disabled: flag });
        }

        function InitUpload() {
            $("#uploadify").uploadify({
                height: 23,
                width: 67,
                swf: '/uploadify/uploadify.swf',
                uploader: '/Ashx/FileUpload.ashx',
                formData: { 'action': 'upload', 'folderid': rowData.ID, 'folderpath': rowData.folderpath.replace(' | ', '/') },
                buttonImage: '/uploadify/selectfiles.png',
                removeCompleted: true,
                auto: false,
                onUploadComplete: function (file) { $("#tt").datagrid("reload"); }             
            });
        }

        function qsearch(v) {
            $('#tt').datagrid('options').queryParams = { "action": "activate", "key": v };
            $('#tt').datagrid('load');
        }

        function getFiles() {
            $('#tt').datagrid({
                url: '../Ashx/File.ashx',
                queryParams: { "action": "activate" },
                loadMsg: '正在努力加载中...',
                idField: 'ID',
                fit: true,
                fitColumns: true,
                pagination: true,
                remoteSort: true,
                singleSelect: false,
                toolbar: "#tab_toolbar",
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                columns: [[
                    { field: 'ckb', checkbox: true },
                    { title: '标题', field: 'file_name', width: 100, sortable: true, editor: 'text' },
                    { title: '是否加密', field: 'pwdflag', width: 100, sortable: true, align: 'center', editor: { type: 'checkbox', options: { on: '1', off: '0'} },
                        formatter: function (value, row, index) {
                            return row.pwdflag == '1' ? '是' : "否";
                        }
                    },
                    { title: '密码', field: 'pwd', width: 100, sortable: true, editor: 'password',
                        formatter: function (value, row, index) {
                            if (row.pwdflag == '1') {
                                var pwdstr = "";
                                if (pwdlenth != null) {
                                    for (var i = 0; i < pwdlenth; i++) {
                                        pwdstr += "●";
                                    }
                                }
                                return pwdstr;
                            }
                            else {
                                return "";
                            }
                        }
                    },
                    { title: '备注', field: 'Remark', width: 100, sortable: true, editor: 'textarea',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '类型', field: 'type', width: 100, sortable: true, align: 'center' },
                    { title: '文件夹', field: 'cate_idName', width: 100, sortable: true },
                    { title: '上传时间', field: 'up_date', width: 100, sortable: true, align: 'center' }
                ]],
                onClickCell: function (rowIndex, field, value) {
                    $('#tt').datagrid('clearSelections');
                    if (editIndex != rowIndex && editIndex != null) {
                        var pwdc = $('#tt').datagrid('getEditor', { index: editIndex, field: 'pwd' });
                        pwdlenth = $(pwdc.target).val().length;
                        $('#tt').datagrid('getRows')[editIndex]['pwd'] = $(pwdc.target).val();
                        $('#tt').datagrid('endEdit', editIndex);
                        editIndex = null;
                    }
                },
                onDblClickRow: function (rowIndex, rowData) {
                    if (editIndex != rowIndex && editIndex != null) {
                        var pwdc = $('#tt').datagrid('getEditor', { index: editIndex, field: 'pwd' });
                        pwdlenth = $(pwdc.target).val().length;
                        $('#tt').datagrid('getRows')[editIndex]['pwd'] = $(pwdc.target).val();
                        $('#tt').datagrid('endEdit', editIndex);
                        editIndex = null;
                    }
                    $('#tt').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
                    $($('#tt').datagrid('getEditor', { index: rowIndex, field: 'pwd' }).target).val(rowData.pwd)
                    //$($('#tt').datagrid('getEditor', { index: rowIndex, field: 'pwdflag' }).target).val(rowData.pwd)
                    editIndex = rowIndex;
                }
            });
        }
        var pwdlenth = null;
        var editIndex = null;

        var viewfolderid = null;
        function View() {
            if ($('#cc').combogrid('getValue') != "") {
                showView();
                if ($('#cc').combogrid('getValue') != viewfolderid) {
                    showPanel();
                    getfolder_permission("sctt", "dept_users");
                    getfolder_permission("xztt", "dowm_dept_users");
                    viewfolderid = $('#cc').combogrid('getValue');
                }
            }
            else {
                $.messager.show({ title: '系统提示', msg: '请先选择【上传目录】。' });
            }
        }

        function showPanel() {
            $('#scdiv').panel({ title: "上传权限", iconCls: "icon-up", width: 400, height: 300 });
            $('#xzdiv').panel({ title: "下载权限", iconCls: "icon-down", width: 400, height: 300 });
        }

        function showView() {
            art.dialog({
                content: document.getElementById('view'),
                id: 'view_dialog',
                title: '目录权限',
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                close: function () { },
                button: [{ name: '关闭', callback: function () { } }]
            });
        }

        function getfolder_permission(table, action) {
            $('#' + table + '').datagrid({
                url: '../Ashx/Folder.ashx',
                queryParams: { "action": action, 'folder_id': $('#cc').combogrid('getValue') },
                loadMsg: '正在努力加载中...',
                idField: 'ID',
                fit: true,
                //fitColumns: true,
                //remoteSort: true,
                rownumbers: true,
                singleSelect: true,
                frozenColumns: [[
                    { title: '工号', field: 'WorkID', width: 75 }
                ]],
                columns: [[
                    { title: '姓名', field: 'Name', width: 75 },
                    { title: '性别', field: 'Caption', width: 100 },
                    { title: '部门', field: 'DeptName', width: 100 },
                    { title: '级别', field: 'RolesName', width: 100 }                    
                ]]
            });
        }

        function Save() {
            fileString = JSON.stringify($('#tt').datagrid("getRows"))
            $.ajax({
                type: 'POST',
                url: '../Ashx/File.ashx',
                data: {
                    'action': 'edit',
                    'filestring': fileString
                },
                success: function (data) {
                    if (data == "success") {
                        $('#tt').datagrid("reload");
                        $.messager.show({ title: '系统提示', msg: "编辑成功！" });
                    }
                    else {
                        $.messager.show({ title: '系统提示', msg: data });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '系统提示', msg: XMLHttpRequest.status });
                }
            });
        }
        

        

        function Delete() {
            $.messager.confirm('提示', '确认删除？', function (r) {
                if (r) {
                    var selected = "";
                    $($('#tt').datagrid('getSelections')).each(function () {
                        selected += "'" + this.ID + "',";
                    });
                    selected = selected.substr(0, selected.length - 1);
                    if (selected == "") {
                        $.messager.show('提示', '请选择您要“删除”的数据。');
                        return;
                    }

                    $.post('../Ashx/File.ashx', { "action": "dels", "cbx_select": selected }, function (data) {
                        if (data == "success") {
                            $("#tt").datagrid("reload");
                        }
                        else {
                            $.messager.show({ title: '提示', msg: data });
                        }
                    });
                }
            });
        }
    </script>
    
    <style type="text/css">
        #uploadify-queue{width:480px;height:240px;overflow:auto;}      
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="tab_toolbar" style="padding: 0 2px;height:auto">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="padding-left: 2px; padding-top:4px; padding-bottom:2px; vertical-align:middle;">
                    <div style="float:left"><a href="#" class="easyui-linkbutton" iconCls="icon-folder" plain="true">上传目录：</a><input id="cc" name="cc"/></div>
                    <div style="float:left"><a href="#" class="easyui-linkbutton" iconCls="icon-gantt" plain="true" onclick="View();">目录权限</a></div>
                    <div style="float:left"><a href="#" class="easyui-linkbutton" iconCls="icon-file" plain="true" onclick="Show();">上传文件</a></div>
                    <div style="float:left"><a href="#" class="easyui-linkbutton" iconCls="icon-ok" plain="true" onclick="Save();">提交文件</a></div>
                    <div style="float:left"><a href="#" class="easyui-linkbutton" iconCls="icon-no" plain="true" onclick="Delete();">删除文件</a></div>
                    <div id="div_qsearch" style="float:left"><a href="#" class="easyui-linkbutton" iconCls="icon-find" plain="true">快速查询：</a></div>
                    <div style="float:left"><input id="ipt_search" name="ipt_search"/></div>
                 </td>
            </tr>
        </table>
    </div>

    <table id="tt"></table>

  <div id="file" style="display:none; width:400px;height:300px;">
    
    </div>
   
    <div id="view" style="display:none">
        <table>
            <tr>
                <td><div id="scdiv"><table id="sctt"></table></div></td>
                <td><div id="xzdiv"><table id="xztt"></table></div></td>
            </tr>
        </table>
    </div>   
</asp:Content>
