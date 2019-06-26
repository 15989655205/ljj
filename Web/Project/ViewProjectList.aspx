<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ViewProjectList.aspx.cs" Inherits="Maticsoft.Web.Project.ViewProjectList" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/datagrid-detailview.js" type="text/javascript"></script>
<script src="../../js/datagrid-groupview.js" type="text/javascript"></script>
<script type="text/javascript">
    var isload = false;
    $(function () {
        if (!isload) {
            InitGrid();
            isload = true;
            $("#tab_input_22").combobox({
                url: '../Ashx/Project.ashx?action=project_model_class',
                valueField: 'name',
                textField: 'name',
                onLoadSuccess: function () {
                    $('#tab_input_22').combobox('setText', '请选择');
                },
                onChange: function (newValue, oldValue) {
                    if (newValue != oldValue) {
                        $('#tt').datagrid('options').queryParams = { "action": "list", "class": newValue };
                        $('#tt').datagrid('load');
                    }
                }
            })
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
            sortName: 'create_date',
            sortOrder: 'desc',
//            fitColumns: true, //列自适应
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { "action": "list", "type": "<%=type %>" },
            //sortOrder: 'desc', //排序类型

            idField: 'sid', //标识字段,主键

            columns: [[
                    { field: 'ckb', checkbox: true,width: 60, hidden: true },
                    
                    { title: '系统编号', field: 'sid', width: 60, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '分类模板名称', field: 'model_class', width: 80, sortable: true, halign: 'center', align: 'center',hidden:true },
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
                        }
                    },
                    { title: '进度监督人', field: 'reviewed_by', width: 100, sortable: true, halign: 'center', align: 'center' },
                    { title: '项目负责人', field: 'project_manager', width: 60, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '制作时间', field: 'creation_date', width: 150, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '经办人', field: 'createP', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value;
                        }
                    },
                    { title: '创建时间', field: 'create_date', width: 150, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd hh:mm");
                        }
                    },
                    { title: '变更人', field: 'updateP', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value;
                        }
                    },
                    { title: '变更时间', field: 'update_date', width: 150, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            if (value != undefined) {
                                return value.Format("yyyy-MM-dd hh:mm");
                            }
                            else {
                                return "";
                            }
                        }
                    }
                    ]],
                    view: detailview,
                    groupFormatter: function (value, rows) {
                        return value + ' - ' + rows.length + ' Item(s)';
                    },
                    
                    
                    detailFormatter: function (index, row) {
                        return '<div style="padding:2px"><table id="ddv-' + index +
'"></table></div>';
                    },
                    onExpandRow: function (index, row) {
                        $('#ddv-' + index).datagrid({
                            url: '../Ashx/Project.ashx',
                            queryParams: { "action": "sub_list", "psid": row.sid, "type": "<%=type %>" },
                            fitColumns: true,
                            singleSelect: true,
                            sortOrder: 'asc',
                            idField: 'sid',
                            height: 'auto',
                            columns: [[
							{ field: 'sid', title: 'sid', width: 100, hidden: true },
                            { field: 'view', title: '查看', width: 30, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                                return '<a style="color:red" href="javascript:;" onclick="ViewProject(\'' + rowData.sid + '\',\'' + row.project_name + '\',\''+rowData.stage_name+'\');"><img src="../images/3.jpg" /></a>'
                            }
                            },
							{ title: '阶段', field: 'stage_name', width: 100, sortable: true, halign: 'center'
                        ,
							    formatter: function (value, rowData, rowIndex) {
							        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
							    }
							},
                    { title: '开始时间', field: 'begin_date', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd");
                        }
                    },
                    { title: '结束时间', field: 'end_date', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd");
                        }
                    }

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
                    },
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

    function ViewProject(sid,name,stagename) {
        url = "/Project/ViewProject.aspx?ps_sid=" + sid+"&type=<%=type %>";
        var showname = name;
        if (name.length > 5) {
            showname = name.substring(0, 5)+'...';
        }
        if (stagename.length > 3) {
            showname += '-' + stagename.substring(0, 3) + '...';
        }
        if ("<%=type %>" == "me") {
            showname += '(me)';
        }
        parent.addTab(showname, url, "", true);
    }

    function add() {
        url = "/Project/Project_IDE.aspx?action=add";
        parent.addTab('项目【新增】', url, "", true);
    }

    function edit() {
        var row = $('#tt').datagrid('getSelected');
        url = "/Project/Project_IDE.aspx?action=update&sid=" + row.sid;
        parent.addTab('项目【修改】', url, "", true);
    }

    //批量删除
    function del() {
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                var selected = "";
                $($('#tt').datagrid('getSelections')).each(function () {
                    selected += "'" + this.sid + "',";
                });
                selected = selected.substr(0, selected.length - 1);
                if (selected == "") {
                    $.messager.alert('提示', '请选择要删除的数据！', 'info');
                    return;
                }

                $.post('../Ashx/Project.ashx', { "action": "dels", "cbx_select": selected }, function (data) {
                    if (data == "success") {
                        $("#tt").datagrid("reload");
                    }
                    else {
                        $.messager.show({ title: '提示', msg: (data=="success"?"保存成功":data) });
                    }
                });
            }
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="tt" ></table>
<div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" Addshow="2" Editshow="2" Delshow="2"  Copyshow="2" QSearchshow="0" Exportshow="2" Printshow="2" ASearchshow="2" runat="server" ></toolbar:ToolBar>
    </div>
</asp:Content>

