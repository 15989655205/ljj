<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ViewStageList.aspx.cs" Inherits="Maticsoft.Web.Project.Template.ViewStageList" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../../js/datagrid-groupview.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        InitGrid();
        $('#tab_input_22').combobox({
            url: '../../Ashx/ProjectStage.ashx?action=viewSL&type=""',
            valueField: 'value',
            textField: 'text',
            onLoadSuccess: function () {
                $('#tab_input_22').combobox('setText', '请选择');
            },
            onSelect: function (data) {
                $('#tt').datagrid("options").queryParams = { "action": "template_list1", "sid": data.value };
                $('#tt').datagrid("reload");
            }
        });        
    });

    //快速搜索
    function qsearch(v) {
        var sid = $('#tab_input_22').combobox("getValue");
        $('#tt').datagrid('options').queryParams = { "action": "template_list1", "key": v, "sid": sid == "" ? -1 : sid };
        $('#tt').datagrid('reload');
    }

    function InitGrid() {
        $('#tt').datagrid({
            fit: true,
            rownumbers: true, //行号
            nowrap: true, //是否换行，True 就会把数据显示在一行里
            singleSelect: true, //单选
            collapsible: false, //可折叠
            remoteSort: false, //定义是否从服务器给数据排序
            fitColumns: true, //列自适应
            url: '../../Ashx/ProjectStage.ashx', //请求数据的页面
            queryParams: { "action": "template_list1", "sid": -1 },
            idField: 'sid', //标识字段,主键

            columns: [[
                    { title: '系统编号', field: 'sid', width: 60, sortable: true, halign: 'center', align: 'center', hidden: true
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '查看', field: 'view', width: 50, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            if (rowData.is_system == 1) {
                                return '<a style="color:red" href="javascript:;" onclick="Content(\'' + rowData.sid + '\',\'' + rowData.stage_name + '\',1);"><img src="../../images/5.png" /></a>';
                            } else {
                                return '<a style="color:red" href="javascript:;" onclick="Content(\'' + rowData.sid + '\',\'' + rowData.stage_name + '\',0);"><img src="../../images/5.png" /></a>';
                            }
                        }
                    },
                    { title: '阶段', field: 'stage_name', width: 100, sortable: true, halign: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '类型', field: 'is_system', width: 100, sortable: true, halign: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + rowData.stageType + '</span></a>';
                        }
                    },
                    { title: '状态', field: 'status', width: 50, sortable: true, halign: 'center', align: 'center',
                        //                        formatter: function (value, row, index) {
                        //                            return row.node_type_name;
                        //                        }
                        formatter: function (value, rowData, rowIndex) {
                            if (value == 1) {
                                return "可用";
                            } else {
                                return "不可用";
                            }
                            //return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '备注', field: 'remark', width: 200, sortable: true, halign: 'center',
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
                    { title: '创建时间', field: 'create_date', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            if (value != undefined) {
                                return value.Format("yyyy-MM-dd hh:mm");
                            }
                            else {
                                return "";
                            }
                        }
                    },
                    { title: '变更人', field: 'updateP', width: 80, sortable: true, halign: 'center', align: 'center'
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return value;
                        }
                    },
                    { title: '变更时间', field: '1', width: 80, sortable: true, halign: 'center', align: 'center'
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
                    toolbar: "#tab_toolbar",
                    groupFormatter: function (value, rows) {
                        return value + ' - ' + rows.length + ' Item(s)';
                    },
                    groupField: 'ptt_name',
                    view: groupview,
            onLoadSuccess: function (data) {
                //btnCancel();
            },
            onClickCell: function (rowIndex, field, value) {
                if (field != "ckb") {
                    $('#sub_tt').datagrid('clearSelections');
                }
            },
            onClickRow: function (rowIndex, rowData) {
            }
        });
    }

    function Content(sid, name, flag) {
        url = "/Project/Template/Content.aspx?ps_sid=" + sid + "&isConstruction=" + flag+"&isView=1";
        if (name.length > 4) {
            name = name.substring(0, 4) + "...";
        }
        parent.addTab_Ext('查看模板【' + name + '】', url, "", true);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<toolbar:ToolBar runat="server" IDS="22~^14~"/>
 <table id="tt"></table>
</asp:Content>
