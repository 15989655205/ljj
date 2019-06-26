<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="DownloadList.aspx.cs" Inherits="Maticsoft.Web.File.DownloadList" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/datagrid-detailview.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#ipt_search').searchbox({ menu: "#search_menu", searcher: function (value, name) { qsearch(value, name); } });
            $('#tt').datagrid({
                url: '../Ashx/File.ashx', //请求数据的页面
                queryParams: { "action": "downloadlist" },
                loadMsg: '正在努力加载中...',
                idField: 'ID',
                toolbar: "#tab_toolbar",
                pageSize: 20,
                pageList: [10, 20, 30, 40, 50, 100],
                fit: true,
                fitColumns: true,
                pagination: true,
                rownumbers: true,
                singleSelect: true,
                remoteSort: false,
                columns: [[
                    { title: '文件名', field: 'file_name', width: 100, sortable: true },
                    { title: '类型', field: 'type', width: 100, sortable: true },
                    { title: '上传人', field: 'UserName', width: 100, sortable: true },
                    { title: '上传时间', field: 'up_date', width: 100, sortable: true },
                    { title: '目录', field: 'path', width: 100, sortable: true },
                    { title: '下载次数', field: 'count', width: 100, sortable: true },
                    { title: '预览', field: 'view', sortable: true, width: 60,
                        formatter: function (value, rowData, rowIndex) {
                            return '' +
                                '<a href="#" style="text-decoration:none;" onclick="openView(\'' + rowData.file_name + '\',\'' + rowData.filePath + '\',\'' + rowData.ID + '\');">' +
                                '预览' +
                                '</a>';
                        }
                    }
				]],
                view: detailview,
                detailFormatter: function (index, row) { return '<div style="padding:2px"><table id="ddv-' + index + '"></table></div>'; },
                onExpandRow: function (index, row) {
                    $('#ddv-' + index).datagrid({
                        url: '../Ashx/File.ashx',
                        loadMsg: '正在努力加载中...',
                        queryParams: { "action": "sub_downloadlist", "fileid": row.ID },
                        fitColumns: true,
                        pageSize: 10,
                        pageList: [10, 20, 30, 40, 50, 100],
                        singleSelect: true,
                        pagination: true,
                        rownumbers: true,
                        remoteSort: false,
                        idField: 'WorkID',
                        columns: [[
                             { title: '工号', field: 'WorkID', width: 100, sortable: true },
                             { title: '姓名', field: 'Name', width: 100, sortable: true },
                             { title: '部门', field: 'DeptName', width: 100, sortable: true },
                             { title: '级别', field: 'AppRole', width: 100, sortable: true },
                             { title: '下载时间', field: 'dowm_date', width: 100, sortable: true }
                             
						]],
                        onResize: function () {
                            $('#tt').datagrid('fixDetailRowHeight', index);
                        },
                        onLoadSuccess: function () {
                            setTimeout(function () {
                                $('#tt').datagrid('fixDetailRowHeight', index);
                            }, 0);
                        }
                    });
                    $('#tt').datagrid('fixDetailRowHeight', index);
                }
            });
        });

        function openView(fileName, Path, ID) {

            $.ajax({
                type: "Post",
                url: "/Ashx/File.ashx?action=fileDownloadCount&fid=" + ID,
                async: false,
                success: function (res) {
                    if (res == 1) {
                        openViewShow('/FileUpload' + Path);
                        $('#tt').datagrid('reload');
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
            $('#tt').datagrid('options').queryParams = { "action": "downloadlist", "key": v };
            $('#tt').datagrid('load');
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <toolbar:ToolBar runat="server" id="toolbar1" PageID="1512"/>
    <table id="tt"></table>
</asp:Content>
