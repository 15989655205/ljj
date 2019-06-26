<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="WaitMeForm.aspx.cs" Inherits="Maticsoft.Web.Flow.WaitMeForm" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="../js/datagrid-groupview.js" type="text/javascript"></script>
      <script src="../js/datagrid-detailview.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
//            InitGird();
            InitGrid_zxf();
        });
       var qs=false;

        //初始化表格
        function InitGird() {
            $('#tt').datagrid({
                fit: true,
                nowrap: false, //是否换行，True 就会把数据显示在一行里
                singleSelect: true, //单选
                collapsible: false, //可折叠
                toolbar: "#tab_toolbar",
                pagination: true, //是否开启分页
                pageNumber: 1, //默认索引页
                pageSize: 20, //默认一页数据条数
                pageList: [10, 20, 30, 40, 50, 100],
                remoteSort: false, //定义是否从服务器给数据排序
                sortName: 'rf_sid,create_date',
                sortOrder: 'desc',
                fitColumns: true, //列自适应
                remoteSort: true,
                url: '../Ashx/ApplicationForm.ashx', //请求数据的页面
                queryParams: { "action": "waitMeAppr" },
                //sortOrder: 'desc', //排序类型

                idField: 'sid', //标识字段,主键

                columns: [[
                    { title: '系统编号', field: 'sid', width: 60, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '申请单名称', field: 'af_name', width: 100, sortable: true, halign: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '申请人', field: 'apply_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '申请部门', field: 'DeptName', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '申请时间', field: 'applicant_date', width: 100, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd hh:mm");
                        }
                    },
                    { title: '状态', field: 'status_name', width: 60, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '当前办理节点', field: 'curr_node_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '下一办理节点', field: 'next_node_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '最近办理人', field: 'recent_appr', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '最近办理时间', field: 'recently_appr_date', width: 100, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd hh:mm");
                        }
                    }
//                    ,
//                    { title: '限定审批时间', field: 'ApprTime', width: 80, sortable: true, halign: 'center', align: 'center'
////                        ,
////                        formatter: function (value, rowData, rowIndex) {
////                            return value.Format("yyyy-MM-dd hh:mm");
////                        }
//                    }
                    ]],
                groupField: 'form_name',
                view: groupview,
                groupFormatter: function (value, rows) {
                    return value + ' - ' + rows.length + ' Item(s)';
                },
                rowStyler: function () {
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
                    //                    if (field != "ckb") {
                    //                        $('#tt').datagrid('clearSelections');
                    //                    }
                },
                onClickRow: function (rowIndex, rowData) {
                    if (rowIndex >= 0) {
                    }
                }
            });
        }

        //编辑事件
        function sh(sid, rf_sid, node_type, curr_node_no, NodeType) {
//            var row = $('#tt').datagrid('getSelected');
            if (sid != null) {
                url = "/Flow/HandleRequestForm.aspx?type=bl&sid=" + sid + "&rfsid=" + rf_sid + "&ntsid=" + node_type + "&currNode=" + curr_node_no;
                parent.addTab_Ext('申请单_' + sid + '【' + NodeType + '】', url, "", true);
            }
            else {
                $.messager.show({ title: '提示', msg: "请选择要操作行数据" });
            }
        }

        //查看
        function view() {
            var row = $('#tt').datagrid('getSelected');
            if (row != null) {
                url = "/Flow/MyWork_IDE.aspx?action=view&sid=" + row.sid + "&rfsid=" + row.rf_sid;
                parent.addTab_Ext('申请单_' + row.sid + '【查看】', url, "", true);
            }
            else {
                $.messager.show({ title: '提示', msg: "请选择要操作行数据" });
            }
        }

        //删除
        function del() {
            var row = $('#tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '提示', msg: "请选择要删除数据" });
                return false;
            }
            if (row.curr_node_no == "") {
                $.messager.confirm('提示', '确认删除？', function (r) {
                    if (r) {
                        $.post('../Ashx/ApplicationForm.ashx', { "action": "del", "sid": row.sid }, function (data) {
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
            else {
                $.messager.show({ title: '提示', msg: "此申请单已进入审批流程不能删除" });
            }
        }
        function InitGrid_zxf() {
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
                sortName: 'rf_sid',
                sortOrder: 'asc',
                //            fitColumns: true, //列自适应
                url: '../Ashx/ApplicationForm_zxf.ashx', //请求数据的页面
                queryParams: { "action": "waitMeAppr" },
                //sortOrder: 'desc', //排序类型
                fitColumns: true,
                idField: 'rf_sid', //标识字段,主键

                columns: [[
                    { field: 'ckb', checkbox: true, width: 60, hidden: true },

                    { title: '表单类型', field: 'name', width: 800, sortable: true
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<span class="mlength" style="color: #416aa3;">' + value + '</span></a>';
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
                        url: '../Ashx/ApplicationForm_zxf.ashx',
                        queryParams: { "action": "waitMeAppr_detail", "rf_sid": row.rf_sid, "key": $(".searchbox-text").val() },
                        //                        fitColumns: true,
                        singleSelect: true,
                        sortName: 'rf_sid,create_date',
                        sortOrder: 'desc',
                        //                        fitColumns: true, //列自适应
                        remoteSort: true,
                        height: 'auto',
                        columns: [[
                        { field: 'sh', title: '审核', width: 30, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                            return '<a style="color:red" href="javascript:;" onclick="sh(\'' + rowData.sid + '\',\'' + rowData.rf_sid + '\',\'' + rowData.node_type + '\',\'' + rowData.curr_node_no + '\',\'' + rowData.NodeType + '\');"><img src="../js/themes/icons/lock.png" /></a>'
                        }
                        },
                            { title: '系统编号', field: 'sid', width: 60, sortable: true, halign: 'center', align: 'center'
                        ,
                                formatter: function (value, rowData, rowIndex) {
                                    return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                                }
                            },
                    { title: '申请单名称', field: 'af_name', width: 300, sortable: true, halign: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '申请人', field: 'apply_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '申请部门', field: 'DeptName', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '申请时间', field: 'applicant_date', width: 120, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd hh:mm");
                        }
                    },
                    { title: '状态', field: 'status_name', width: 60, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '当前办理节点', field: 'curr_node_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '下一办理节点', field: 'next_node_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '最近办理人', field: 'recent_appr', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '最近办理时间', field: 'recently_appr_date', width: 120, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd hh:mm");
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
                    if (qs) {
                        $("#tt").datagrid("expandRow", 0);
                    }
                } //,
                //                onHeaderContextMenu: function (e, field) {
                //                    e.preventDefault();
                //                    if (!$('#tmenu').length) {
                //                        createColumnMenu();
                //                    }
                //                    $('#tmenu').menu('show', {
                //                        left: e.pageX,
                //                        top: e.pageY
                //                    });
                //                },
                //                onClickCell: function (rowIndex, field, value) {
                //                    if (field != "ckb") {
                //                        $('#tt').datagrid('clearSelections');
                //                    }
                //                },
                //                onClickRow: function (rowIndex, rowData) {
                //                    if (rowIndex >= 0) {
                //                    }
                //                }
                
            });
        }
        function qsearch() {qs = true;  $("#tt").datagrid("reload");}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="tt"></table>
<div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" runat="server" PageID="1614"></toolbar:ToolBar>
    </div>
</asp:Content>
