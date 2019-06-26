<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="FileDownload.aspx.cs" Inherits="Maticsoft.Web.File.FileDownload" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        var userDownloadFlag = "";
        var action;

        $(function () { getFiles(); $.post('../Ashx/Employees.ashx', { "action": "UserDownloadFlag" }, function (data) { userDownloadFlag = data; }); });

        function getFiles() {
            $('#tt').datagrid({
                url: '../Ashx/File.ashx',
                queryParams: { "action": "file_download" },
                loadMsg: '正在努力加载中...',
                idField: 'ID',
                fit: true,
                fitColumns: true,
                pagination: true,
                remoteSort: true,
                rownumbers: true,
                singleSelect: true,
                toolbar: "#tab_toolbar",
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                columns: [[
                    { title: '文件名', field: 'file_name', width: 100, sortable: true },
                    { title: '类型', field: 'type', width: 100, sortable: true, align: 'center' },
                    { title: '文件夹', field: 'cate_idName', width: 100, sortable: true },
                    { title: '上传人', field: 'up_personName', width: 100, sortable: true, align: 'center' },
                    { title: '上传时间', field: 'up_date', width: 100, sortable: true, align: 'center' },
                    { title: '备注', field: 'Remark', width: 100, sortable: true, editor: 'textarea',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '加密状态', field: 'pwdflag', width: 100, sortable: true, align: 'center',
                        formatter: function (value, row, index) { return row.pwdflag == '1' ? '已加密' : "未加密"; }
                    },
                    { title: '下载', field: 'count', sortable: true, width: 60,
                        formatter: function (value, rowData, rowIndex) {
                            return '' +
                                '<a href="#" style="text-decoration:none;" onclick="download(' + rowIndex + ');">' +
                                '   <img src="../uploadify/down.png" style="float:left;"/>' + value +
                                '</a>';
                        }
                    },
                    { title: '预览', field: 'view', sortable: true, width: 60,
                        formatter: function (value, rowData, rowIndex) {
                            return '' +
                                '<a href="#" style="text-decoration:none;" onclick="viewdownload(' + rowIndex + ');">' +
                                '预览' +
                                '</a>';
                        }
                    }
                ]]
            });
        }

        //高级查询
        function asearch() {
        }

        //快速搜索
        function qsearch(v) {
            $('#tt').datagrid('options').queryParams = { "action": "file_download", "key": v };
            $('#tt').datagrid('load');
        }

        function download(rowIndex) {
            action = 1;
            var row = $("#tt").datagrid("getRows")[rowIndex];            
            if (row.pwdflag == 1 && userDownloadFlag != "ok") {
                $("#txtpwd").val('');
                art.dialog({
                    content: document.getElementById('pwd'),
                    id: 'pwd_dialog',
                    title: '文件下载',
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
            if (action == 1) {
                $("#ctl00_ContentPlaceHolder1_hdfile").val(row.file_name + row.type + "|" + row.Path + "|" + row.ID);
                $("#ctl00_ContentPlaceHolder1_btnDownload").click();
                $('#tt').datagrid("reload");
            }
            else {
                openView(row.file_name, row.Path, row.ID);
                $('#tt').datagrid('reload');
            }
        }

        function openView(fileName, Path, ID) {
            $.ajax({
                type: "Post",
                async: false,
                url: "/Ashx/File.ashx?action=fileDownloadCount&fid=" + ID,
                async: false,
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

        function showmsg() {
            //$.messager.show({ title: '系统提示', msg: '文件不存在。' });
            //parent.addTab_Ext('文件下载', "/File/FileDownload.aspx", "", true);
            alert("文件不存在。");
            var title = parent.$('#tabs').tabs("getSelected").panel('options').title;
            parent.Tab_OC("文件下载", title, "/File/FileDownload.aspx", "", true);
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             
    <toolbar:ToolBar runat="server" id="toolbar1" PageID="1510"/>
       
    <table id="tt"></table>

    <div id="pwd" style="display:none;">
        请输入下载密码：<br/>
        <input type="password" id="txtpwd" name="txtpwd"/>
    </div>
    <form runat="server" style="display:none">
        <asp:HiddenField ID="hdfile" runat="server"/>
        <asp:Button ID="btnDownload" runat="server" Text="Button" onclick="Button1_Click" />        
    </form>

</asp:Content>
