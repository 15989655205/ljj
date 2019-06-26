<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="MyRequestForm.aspx.cs" Inherits="Maticsoft.Web.Flow.MyRequestForm" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="../js/datagrid-groupview.js" type="text/javascript"></script>
   <script src="../js/datagrid-detailview.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //            InitGird();
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
                queryParams: { "action": "myApply" },
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
                    { title: '当前节点', field: 'curr_node_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '下一节点', field: 'next_node_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '最近办理人', field: 'appr_name', width: 80, sortable: true, halign: 'center', align: 'center'
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

        function copy(sid, form_name, rf_sid) {
            //parent.addTab('发起【】', '/Flow/MyWork_IDE.aspx?rfsid=&action=add&url=');
        //var row = $('#tt').datagrid('getSelected');
            //if (row != null) {
                url = "/Flow/MyWork_IDE.aspx?action=copy&sid=" + sid + "&rfsid=" + rf_sid;
                parent.addTab('发起【' + form_name + '】', url);
            //}
            //else {
            //    $.messager.show({ title: '提示', msg: "请选择要复制行数据" });
            //}
        }

        //编辑事件
        function edit(sid, curr_node_no, rf_sid) {
//            alert(row.curr_node_no);
            //            var row = $('#tt').datagrid('getSelected');
            if (sid != null) {
                if (curr_node_no == "") {
                    url = "/Flow/MyWork_IDE.aspx?action=update&sid=" + sid + "&rfsid=" + rf_sid;
                    parent.addTab_Ext('申请单_' + sid + '【修改】', url, "", true);
                }
                else {
                    $.messager.show({ title: '提示', msg: "此申请单已进入审批流程不能修改" });
                }
            }
            else {
                $.messager.show({ title: '提示', msg: "请选择要操作行数据" });
            }
        }

        //查看
        function view(sid,rf_sid) {
//            alert(row);
            //            var row = $('#tt').datagrid('getSelected');
            if (sid != null) {
                url = "/Flow/MyWork_IDE.aspx?action=view&sid=" + sid + "&rfsid=" + rf_sid;
                parent.addTab_Ext('申请单_' + sid + '【查看】', url, "", true);
            }
            else {
                $.messager.show({ title: '提示', msg: "请选择要操作行数据" });
            }
        }

        //删除
        function del(sid,curr_node_no) {
            //            var row = $('#tt').datagrid('getSelected');
            if (sid == null) {
                $.messager.show({ title: '提示', msg: "请选择要删除数据" });
                return false;
            }
            if (curr_node_no == "") {
                $.messager.confirm('提示', '确认删除？', function (r) {
                    if (r) {
                        $.post('../Ashx/ApplicationForm.ashx', { "action": "del", "sid": sid }, function (data) {
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
                queryParams: { "action": "myAppr" },
                //sortOrder: 'desc', //排序类型
                fitColumns: true,
                idField: 'rf_sid', //标识字段,主键
                
                columns: [[
                    { field: 'ckb', checkbox: true, width: 60, hidden: true },

                    { title: '表单类型', field: 'name',width:800, sortable: true
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
                        queryParams: { "action": "myAppr_detail", "rf_sid": row.rf_sid, "applicant": row.applicant,"key":$(".searchbox-text").val() },
//                        fitColumns: true,
                        singleSelect: true,
                        sortName: 'rf_sid,create_date',
                        sortOrder: 'desc',
                        fitColumns: true, //列自适应
                        remoteSort: true,
                        height: 'auto',
                        columns: [[
                        { field: 'copy', title: '复制', width: 30, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                            return '<a style="color:red" href="javascript:;" onclick="copy(\'' + rowData.sid + '\',\'' + rowData.form_name + '\',\'' + rowData.rf_sid + '\');"><img src="../js/themes/icons/copy.png" /></a>'
                        }
                        },
                            { field: 'view', title: '查看', width: 30, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                                return '<a style="color:red" href="javascript:;" onclick="view(\'' + rowData.sid + '\',\'' + rowData.rf_sid + '\');"><img src="../js/themes/icons/27.png" /></a>'
                            }
                        },
                            { field: 'edit', title: '编辑', width: 30, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                                return '<a style="color:red" href="javascript:;" onclick="edit(\'' + rowData.sid + '\',\'' + rowData.curr_node_no + '\',\'' + rowData.rf_sid + '\');"><img src="../js/themes/icons/pencil.png" /></a>'
                            }
                        },
                             { field: 'del', title: '删除', width: 30, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                                 return '<a style="color:red" href="javascript:;" onclick="del(\'' + rowData.sid + '\',\'' + rowData.curr_node_no + '\');"><img src="../js/themes/icons/edit_remove.png" /></a>'
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
                    { title: '申请人', field: 'apply_name', width: 100, sortable: true, halign: 'center', align: 'center'
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
                    { title: '状态', field: 'status_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '当前节点', field: 'curr_node_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '下一节点', field: 'next_node_name', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '最近办理人', field: 'appr_name', width: 80, sortable: true, halign: 'center', align: 'center'
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


        function qsearch() {qs = true;  $("#tt").datagrid("reload");
//            var status = $("#datagrid-row-r1-1-0 span").attr("class");
//            if (status == "datagrid-row-expander datagrid-row-expand") {
//               
//            }
//            else {
//                
//                
//                $("#datagrid-row-r1-1-0 span").click();
////                $("#ddv-0").datagrid("reload");
//            }
            
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="tt"></table>
<%--<div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" Addshow="2" Viewshow="0" Copyshow="0" Delshow="0" Editshow="0" QSearchshow="0" Exportshow="1" Printshow="1" ASearchshow="1" runat="server" ></toolbar:ToolBar>
    </div>--%>
    <div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" runat="server" PageID="1613"></toolbar:ToolBar>
    </div>
</asp:Content>
