<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProjectContent.aspx.cs" Inherits="Maticsoft.Web.Project111.ProjectContent" %>
<%--<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>--%>
<%@ Register TagPrefix="pc_IDE" TagName="PC_IDE" Src="../Controls/Project/ProjectContent_IDE.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/treegrid-groupview.js" type="text/javascript"></script>
<script type="text/javascript">
    var editIndex = undefined;
    var isEdit = false;
    var grid;
    var columns = "<%=column %>";
    $(function () {
        InitGird();
        //getData();
    });

    //初始化表格
    function InitGird() {
        grid = $('#tt').treegrid({
            fit: true,
            singleSelect: true, //单选
            fitColumns: true, //列自适应
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { "action": "content_list", "pssid": "<%=pssid %>" },
            idField: 'sid', //标识字段,主键
            treeField: 'name',

            columns: eval('(' + columns + ')'),
            toolbar: [{
                iconCls: 'icon-add',
                text: '添加',
                handler: function () {
                    add();
                }
            }, '-', {
                iconCls: 'icon-edit',
                text: '修改',
                handler: function () {
                    edit();
                }
            }, '-', {
                iconCls: 'icon-remove',
                text: '删除',
                handler: function () {
                    del();
                }
            }],
            onLoadSuccess: function (row, data) {
                //                if (action == "pro_content_add") {
                //                }

                //                else if (golde_row.sid != undefined) {
                //                    $("#tt").treegrid("select", golde_row.sid);
                //                }

            },
            onClickCell: //onClickCell,
            function (field, row) {
                onClickCell(row.sid, field);
            },
            onClickRow: function (row) {
                //EditRow(row.sid);
            }
        });
    }

    function getData() {
        $.post('../Ashx/Project.ashx', { "action": "content_list", "pssid": "<%=pssid %>" },
        function (data) {
            grid.datagrid({
                columns: [data.columns]
            }).datagrid("loadData", data);
         }, 'json');
    }

    //初始化表格
    function myInitGird() {
        $('#tt').treegrid({
            fit: true,
            //nowrap: false, //是否换行，True 就会把数据显示在一行里
            singleSelect: true, //单选
            //collapsible: false, //可折叠
            //toolbar: "#tab_toolbar",
            //pagination: true, //是否开启分页
            //pageNumber: 1, //默认索引页
            //pageSize: 20, //默认一页数据条数
            //pageList: [10, 20, 30, 40, 50, 100],
            //remoteSort: false, //定义是否从服务器给数据排序
            //sortName: 'sid',
            //sortOrder: 'desc',
            fitColumns: true, //列自适应
            //remoteSort: true,
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { "action": "content_list", "pssid": "<%=pssid %>" },
            //sortOrder: 'desc', //排序类型

            idField: 'sid', //标识字段,主键
            treeField: 'name',

            columns: [[
            { title: '小组', field: 'group_name', width: 60, sortable: true, halign: 'center', align: 'center', editor: "text",
                formatter: function (value, rowData, rowIndex) {
                    if (rowData.parent_sid == 0) {
                        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                    }
                    else {
                        return '';
                    }
                }
            },
                    { title: '工作内容/细目', field: 'name', width: 150, sortable: true, halign: 'center', editor: "text",
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },

                    { title: '开始日期', field: 'begin_date', width: 100, sortable: true, halign: 'center', align: 'center', editor: "text",
                        formatter: function (value, rowData, rowIndex) {
                            if (value.Format("yyyy-MM-dd") == "1900-01-01") {
                                return "";
                            } else {
                                return value.Format("yyyy-MM-dd");
                            }
                        }
                    },
                    { title: '结束日期', field: 'end_date', width: 100, sortable: true, halign: 'center', align: 'center', editor: "text",
                        formatter: function (value, rowData, rowIndex) {
                            if (value.Format("yyyy-MM-dd") == "1900-01-01") {
                                return "";
                            } else {
                                return value.Format("yyyy-MM-dd");
                            }
                        }
                    }
                    ,
                    { title: '小组审核', field: 'v1', width: 100, sortable: true, halign: 'center', align: 'center', editor: "text",
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + rowData.groupAppr + '"><span class="mlength">' + rowData.groupAppr + '</span></a>';
                        }
                    }
                    ,
                    { title: '初审', field: 'v2', width: 100, sortable: true, halign: 'center', align: 'center', editor: "text",
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + rowData.trialAppr + '"><span class="mlength">' + rowData.trialAppr + '</span></a>';
                        }
                    }
                    ,
                    { title: '质量监督', field: 'v3', width: 100, sortable: true, halign: 'center', align: 'center', editor: "text",
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + rowData.qsAppr + '"><span class="mlength">' + rowData.qsAppr + '</span></a>';
                        }
                    }
                    ,
                    { title: '备注', field: 'remark', width: 100, sortable: true, halign: 'center', editor: "text",
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '添加日期', field: 'create_date', width: 100, sortable: true, halign: 'center', align: 'center', hidden: true,
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd");
                        }
                    },
            //                    { title: '添加人', field: 'create_person', width: 100, sortable: true, halign: 'center', align: 'center',
            //                        formatter: function (value, rowData, rowIndex) {
            //                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
            //                        }
            //                    },
                    {title: '负责人员', field: 'implementer', width: 100, sortable: true, halign: 'center', align: 'center', editor: "text", hidden: true,
                    formatter: function (value, rowData, rowIndex) {
                        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                    }
                }
                    ]],
            toolbar: [{
                iconCls: 'icon-add',
                text: '添加',
                handler: function () {
                    add();
                }
            }, '-', {
                iconCls: 'icon-edit',
                text: '修改',
                handler: function () {
                    edit();
                }
            }, '-', {
                iconCls: 'icon-remove',
                text: '删除',
                handler: function () {
                    del();
                }
            }],
            //            groupField: 'group_name',
            //            view: groupview,
            //            groupFormatter: function (value, rows) {
            //                return value + ' - ' + rows.length + ' Item(s)';
            //            },
            onLoadSuccess: function (row, data) {
                //alert(data);
                //treegridMergeCellsByField("tt", "group_name");
                if (action == "pro_content_add") {
                    //alert(row);
                }

                else if (golde_row.sid != undefined) {
                    $("#tt").treegrid("select", golde_row.sid);
                }
            },
            onClickCell: function (field, row) {
                EditCell(row.sid,field);
            },
            onClickRow: function (row) {
                EditRow(row.sid);
            }
        });
    }

    function endEditing() {
        if (editIndex == undefined) { return true }
        if ($('#tt').treegrid('validateRow', editIndex)) {
            var ed = $('#tt').treegrid('getEditor', { id: editIndex, field: 'v3' });
            var v3 = "abc"; //$(ed.target).combobox('getText');
            $('#tt').treegrid('getSelected').v3 = v3;
            $('#tt').treegrid('endEdit', editIndex);
            editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function EditRow(index) {
        if (editIndex != index) {
            if (endEditing()) {
                $('#tt').treegrid('select', index).treegrid('beginEdit', index);
                var editors = $('#tt').treegrid('getEditors', index);
                var ed = editors[0];
                //alert($('#tt').treegrid('getChildren', index).length);
                if ($('#tt').treegrid('getChildren', index).length == 0) {
                    var row = $('#tt').treegrid('getParent', index);
                    $(ed.target).combobox('setValue', row.group_sid);
                    $(ed.target).combobox('disable');
                }
                editIndex = index;
            } else {
                $('#tt').treegrid('select', editIndex);
            }
            
        }
    }

    function EditGrid(row) {
        var index = row.sid;  //$('#tt').treegrid('getRowIndex', row);
        $('#tt').treegrid('beginEdit', index);
        var editors = $('#tt').treegrid('getEditors', index);
        editIndex = index;
    }

  
    function onClickCell(index, field) {
        if (endEditing()) {
            $('#tt').treegrid('select', index).datagrid('editCell', { index: index, field: field });
            editIndex = index;
        }
    }




    //编辑事件
    function add() {
        var row = $('#tt').datagrid('getSelected');
        if (art.dialog.get('pc_dialog') != null) {
            art.dialog.get('pc_dialog').close();
        }
        pc_openDialog("add", $('#hpssid').val(), row, "工作内容");
    }
    function edit() {
        var row = $('#tt').datagrid('getSelected');
        if (row==null) {
            $.messager.show({ title: '提示', msg: "请选择要编辑数据" });
            return false;
        }
        if (art.dialog.get('pc_dialog') != null) {
            art.dialog.get('pc_dialog').close();
        }
        pc_openDialog("alter", $('#hpssid').val(), row, "工作内容");
    }

    //查看
    function view() {
        if (row == null) {
            $.messager.show({ title: '提示', msg: "请选择要查看数据" });
            return false;
        }
        var row = $('#tt').datagrid('getSelected');
        url = "/Flow/MyWork_IDE.aspx?action=view&sid=" + row.sid + "&rfsid=" + row.rf_sid;
        parent.addTab_Ext('申请单【查看】', url, "", true);
    }

    //删除
    function del() {
        var row = $('#tt').treegrid('getSelected');
        if (row == null) {
            $.messager.show({ title: '提示', msg: "请选择要删除数据" });
            return false;
        }
        if ($("#tt").treegrid("getChildren", row.sid).length > 0) {
            $.messager.confirm('确认', '您要删除工作内容吗？如果确认删除，工作内容对应的细目也同时删除的。', function (r) {
                if (!r) {
                    return false;
                }
                else {
                    del_save(row.sid);
                }
            });
        }
        else {
            del_save(row.sid);
        }
    }

    function del_save(sid) {
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                $.post('../Ashx/Project.ashx', { "action": "pro_content_del", "sid": sid }, function (data) {
                    if (data == "success") {
                        InitGird();
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
<div id="cc" class="easyui-layout" fit="true" border="false" style="overflow-y: hidden"  scroll="no">
<div region="north" title="" border="false" split="false">
<input type="hidden" id="hsid" name="hsid" value="" />
<input type="hidden" id="haction" name="haction" value="" />
<input type="hidden" id="hpsid" name="hpsid" value="" />
<input type="hidden" id="hpssid" name="hpssid" value="<%=pssid %>" />
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" colspan="4" style="height: 25px; background-color: #e1f5fc; text-align: center">
                    <strong>项目基本属性</strong>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; background-color: #e1f5fc; height: 25px;">
                    项目名称：
                </td>
                <td  style="background-color: #ffffff; height: 25px; padding-left: 5px; width:35%">
                &nbsp;<%=pname %>
                </td>
                 <td align="right" style="width: 15%; background-color: #e1f5fc; height: 25px;">
                    项目编号：
                </td>
                <td width="*" style="background-color: #ffffff; height: 25px; padding-left: 5px;width:35%">
                &nbsp;<%=pcode %>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    阶段：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                &nbsp;<%=stageName %>
                </td>
                 <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                </td>
            </tr>
         </table>
           </div>     
     <div region="center" title="" border="false">  

        <table id="tt"></table>   
       
<%--<div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" Addshow="0" Viewshow="2" Copyshow="2" Delshow="0" Editshow="0" QSearchshow="0" Exportshow="2" Printshow="2" ASearchshow="1" runat="server" ></toolbar:ToolBar>
    </div>--%>
    </div>
 </div>

    <div id="pc_edit" style="display:none;">
        <pc_IDE:PC_IDE ID="pc_ide1" runat="server"></pc_IDE:PC_IDE>
    </div>
</asp:Content>
