<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="Maticsoft.Web.Project111.ProjectList" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    var isload = false;
    $(function () {
        if (!isload) {
            InitGrid();
            isload = true;
        }
    });

    //初始化表格
    function InitGrid() {
        $('#tt').datagrid({
            fit: true,
            nowrap: false, //是否换行，True 就会把数据显示在一行里
            singleSelect: false, //单选
            collapsible: false, //可折叠
            toolbar: "#tab_toolbar",
            pagination: true, //是否开启分页
            pageNumber: 1, //默认索引页
            pageSize: 20, //默认一页数据条数
            pageList: [10, 20, 30, 40, 50, 100],
            remoteSort: true, //定义是否从服务器给数据排序
            sortName: 'sid',
            sortOrder: 'desc',
            fitColumns: true, //列自适应
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { "action": "list" },
            //sortOrder: 'desc', //排序类型

            idField: 'sid', //标识字段,主键

            columns: [[
//                    { field: 'ckb', checkbox: false },
                    { title: '系统编号', field: 'sid', width: 60, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '项目名称', field: 'project_name', width: 100, sortable: true, halign: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '项目编号', field: 'project_code', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '制作人', field: 'prepared_by', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                            //return '<img src="../Images/point/bullet_green.png"/>';
                        }
                    },
                    { title: '进度监督人', field: 'reviewed_by', width: 100, sortable: true, halign: 'center', align: 'center' },
                    { title: '项目负责人', field: 'project_manager', width: 60, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '制作时间', field: 'creation_date', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },

                    { title: '创建时间', field: 'create_date', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd hh:mm");
                        }
                    }
                    ]],
            onLoadSuccess: function (data) {
            },
            onHeaderContextMenu: function (e, field) {
                e.preventDefault();
                if (!$('#tmenu').length) {
                    createColumnMenu();
                }
                $('#tmenu').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });
            },
            onClickCell: function (rowIndex, field, value) {
                if (field != "ckb") {
                    $('#tt').datagrid('clearSelections');
                }
            },
            onClickRow: function (rowIndex, rowData) {
                if (rowIndex >= 0) {
                }
            }
        });
    }

    //快速搜索
    function qsearch(v) {
        $('#tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#tt').datagrid('load');
    }

    function add() {
        url = "/Project/Project_IDE.aspx?action=add";
        parent.addTab('项目【新增】', url, "", true);
    }

    function edit() {
        var row = $('#tt').datagrid('getSelected');
        var project_name = row.project_name;
        if (project_name.length>4) {
            project_name = project_name.substring(0, 3) + '...';
        }
        url = "/Project/Project_IDE.aspx?action=update&sid=" + row.sid;
        parent.addTab('项目:'+project_name+'【修改】', url, "", true);
    }

    //批量删除
    function del() {
        
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                var selected = $('#tt').datagrid('getSelected');
                if (selected == "") {
                    $.messager.alert('提示', '请选择要删除的数据！', 'info');
                    return;
                }

                $.post('../Ashx/Project.ashx', { "action": "dels", "cbx_select": selected.sid }, function (data) {
//                    alert(data);
                    if (data == "success") {
                        $("#tt").datagrid("reload");
                        $.messager.show({ title: '提示', msg: '删除成功！' });
                    }
                    else {
                        $.messager.show({ title: '提示', msg: data });
                    }
                });
            }
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="tt"></table>
<div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" PageID="161611" runat="server" ></toolbar:ToolBar>
    </div>
</asp:Content>
