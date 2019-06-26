<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="MyApprForm.aspx.cs" Inherits="Maticsoft.Web.Flow.MyApprForm" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/test_zxf.js" type="text/javascript"></script>
   <script src="../js/datagrid-groupview.js" type="text/javascript"></script>
   <script src="../js/datagrid-detailview.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            InitGrid_zxf();
        });
        var qs = false;

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
                queryParams: { "action": "myAppr" },
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
                    { title: '申请人', field: 'Name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '申请部门', field: 'applDept', width: 80, sortable: true, halign: 'center', align: 'center'
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
                    { title: '状态', field: 'formStatus', width: 60, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                //                    { title: '当前审批节点', field: 'curr_node_no', width: 80, sortable: true, halign: 'center', align: 'center'
                //                        ,
                //                        formatter: function (value, rowData, rowIndex) {
                //                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                //                        }
                //                    },
{title: '当前办理节点', field: 'curr_node_name', width: 80, sortable: true, halign: 'center', align: 'center'
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
                    { title: '最近办理人', field: 'rec_approver', width: 80, sortable: true, halign: 'center', align: 'center'
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
                    },
                    { title: '我办理时间', field: 'appr_datetime', width: 100, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd hh:mm");
                        }
                    },
                    { title: '我办理结果', field: 'appr_status_str', width: 60, sortable: true, halign: 'center', align: 'center' },
                    { title: '查看记录', field: 'viewRecord', width: 60, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a style="color:red" href="javascript:;" onclick="Show(\'' + rowData.sid + '\');"><img src="../js/themes/icons/clipped_id.png" /></a>';
                        }
                    }
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
        function qs1() {
            var row = $('#tt').datagrid('getSelected');
            if (row != null) {
                if ((row.curr_node_no == row.mynode && row.rf_status > 0) || (row.curr_node_no == row.myNextNode && row.rf_status == 0)) {
                    url = "/Flow/HandleRequestForm.aspx?type=qs&sid=" + row.sid + "&rfsid=" + row.rf_sid + "&ntsid=" + row.node_type + "&currNode=" + row.mynode + "&rfar_sid=" + row.recordsid;
                    parent.addTab_Ext('申请单_' + row.sid + '【' + row.NodeType + '】', url, "", true);
                }
                else {
                    $.messager.show({ title: '提示', msg: "下一阶段的审批已经进行，您不能弃审！" });
                }
            }
            else {
                $.messager.show({ title: '提示', msg: "请选择要操作行数据" });
            }
        }

        //编辑事件
        function qsfun(sid, rf_sid, node_type, curr_node_no, mynode, myNextNode, rf_status, recordsid, NodeType) {
            //var row = $('#tt').datagrid('getSelected');
            //if (row != null) {
            if ((curr_node_no == mynode && rf_status > 0) || (curr_node_no == myNextNode && rf_status == 0)) {
                url = "/Flow/HandleRequestForm.aspx?type=qs&sid=" + sid + "&rfsid=" + rf_sid + "&ntsid=" + node_type + "&currNode=" + mynode + "&rfar_sid=" + recordsid;
                parent.addTab_Ext('申请单_' + sid + '【' + NodeType + '】', url, "", true);
            }
            else {
                $.messager.show({ title: '提示', msg: "下一阶段的审批已经进行，您不能弃审！" });
            }
            //}
            //else {
            //    $.messager.show({ title: '提示', msg: "请选择要操作行数据" });
            //}
        }

        //查看
        function Show(sid) {
            window.open('ShowApprRecord.aspx?af_sid=' + sid);
        }

        //查看
        function view(sid,rf_sid) {
                url = "/Flow/MyWork_IDE.aspx?action=view&sid=" + sid + "&rfsid=" + rf_sid;
                parent.addTab_Ext('申请单_' + sid + '【查看】', url, "", true);
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
                queryParams: { "action": "myApprList" },
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
                        queryParams: { "action": "myApprList_detail", "rf_sid": row.rf_sid, "approver": row.approver, "key": $(".searchbox-text").val() },
                        //                        fitColumns: true,
                        singleSelect: true,
                        sortName: 'rf_sid,create_date',
                        sortOrder: 'desc',
                                                fitColumns: true, //列自适应
                        remoteSort: true,
                        height: 'auto',
                        columns: [[
                            { field: 'view', title: '查看', width: 30, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                                return '<a style="color:red" href="javascript:;" onclick="view(\'' + rowData.sid + '\',\'' + rowData.rf_sid + '\');"><img src="../js/themes/icons/27.png" /></a>'
                            }
                            },
                    
                    { title: '查看记录', field: 'viewRecord', width: 60, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a style="color:red" href="javascript:;" onclick="Show(\'' + rowData.sid + '\');"><img src="../js/themes/icons/clipped_id.png" /></a>';
                        }
                    },
                            { field: 'edit', title: '弃审', width: 30, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                                return '<a style="color:red" href="javascript:;" onclick="qsfun(\'' + rowData.sid + '\',\'' + rowData.rf_sid + '\',\'' + rowData.node_type + '\',\'' + rowData.curr_node_no + '\',\'' + rowData.mynode + '\',\'' + rowData.myNextNode + '\',\'' + rowData.rf_status + '\',\'' + rowData.recordsid + '\',\'' + rowData.NodeType + '\');"><img src="../js/themes/icons/pencil.png" /></a>'
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
                    { title: '申请人', field: 'Name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '申请部门', field: 'applDept', width: 80, sortable: true, halign: 'center', align: 'center'
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
                    { title: '状态', field: 'formStatus', width: 60, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                        //                    { title: '当前审批节点', field: 'curr_node_no', width: 80, sortable: true, halign: 'center', align: 'center'
                        //                        ,
                        //                        formatter: function (value, rowData, rowIndex) {
                        //                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        //                        }
                        //                    },
{title: '当前办理节点', field: 'curr_node_name', width: 80, sortable: true, halign: 'center', align: 'center'
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
                    { title: '最近办理人', field: 'rec_approver', width: 80, sortable: true, halign: 'center', align: 'center'
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
                    },
                    { title: '我办理时间', field: 'appr_datetime', width: 100, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd hh:mm");
                        }
                    },
                    { title: '我办理结果', field: 'appr_status_str', width: 60, sortable: true, halign: 'center', align: 'center' }
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
        function qsearch() { qs = true; $("#tt").datagrid("reload"); }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="tt"></table>
<div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" QSshow="0" Addshow="2" Viewshow="2" Copyshow="2" Delshow="2" Editshow="2" QSearchshow="0" Exportshow="1" Printshow="1" ASearchshow="1" runat="server" ></toolbar:ToolBar>
    </div>
</asp:Content>
