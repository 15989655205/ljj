<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="FormDesign.aspx.cs" Inherits="Maticsoft.Web.Flow.FormDesign" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    $(function () {
        InitGrid();
    });

 function InitGrid() {
     $('#tt').datagrid({
         url: '../Ashx/RequestForm.ashx', //请求数据的页面
         queryParams: { "action": "list" },
         sortName: 'type_name',
         sortOrder: 'asc',
         idField: 'sid',
         toolbar: "#tab_toolbar",
         pageSize: 20,
         pageList: [10, 20, 30, 40, 50, 100],
         fit: true,
         striped: true, //True 奇偶行使用不同背景色
         pagination: true,
         rownumbers: true,
         singleSelect: false,
         remoteSort: false,
         columns: [[
            { field: 'ckb', checkbox: true },
					{ field: 'sid', title: '编号', width: 100, sortable: true, hidden: true },
                    { field: 'type_name', title: '表单类型', width: 200, halign: 'center' },
					{ field: 'form_name', title: '表单名称', width: 200, halign: 'center' },
					
					{ field: 'rf_status', title: '表单状态', width: 200, sortable: true, halign: 'center',
					    formatter: function (value, row, index) {
					        if (value == 1) {
					            return "生效";
					        } else {
					            return "无效";
					        }
					    }
					},
                    { field: 'create_date', title: '创建时间', width: 200, halign: 'center' },
                    { field: 'remark', title: '备注', width: 200, halign: 'center' }
				]],
         onClickCell: function (rowIndex, field, value) {
             if (field != "ckb") {
                 $('#tt').datagrid('clearSelections');
             }
//             if (art.dialog.get('user_dialog') != null) {
//                 Show(rowIndex);
//             }
         }
     });
    }

    //快速搜索
    function qsearch(v) {
        $('#tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#tt').datagrid('load');
    }

    function add() {
        url = "/Flow/Form_IDE.aspx?action=add";
        parent.addTab_Ext('表单【新增】', url, "", false);
    }

    function copy() {
        var row = $('#tt').datagrid('getSelected');
        url = "/Flow/Form_IDE.aspx?action=copy&sid=" + row.sid;
        parent.addTab_Ext('表单【新增】', url, "", true);
    }

    //编辑事件
    function edit() {
        var row = $('#tt').datagrid('getSelected');
        url = "/Flow/Form_IDE.aspx?action=update&sid=" + row.sid;
        parent.addTab_Ext('表单【修改】', url, "", true);
    }

    //查看事件
    function view() {
        var row = $('#tt').datagrid('getSelected');
        url = "/Flow/Form_IDE.aspx?action=view&sid=" + row.sid;
        parent.addTab_Ext('表单【查看】', url, "", true);
    }

    //批量删除
    function del() {
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                var selected = "";
                $($('#tt').datagrid('getSelections')).each(function () {
                    selected += "" + this.sid + ",";
                });
                selected = selected.substr(0, selected.length - 1);
                if (selected == "") {
                    $.messager.alert('提示', '请选择要删除的数据！', 'info');
                    return;
                }

                $.post('../Ashx/RequestForm.ashx', { "action": "dels", "cbx_select": selected }, function (data) {
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
    <table id="tt"></table>
<div id="toolbarDIV" style="height:0px;" >
    <toolbar:ToolBar ID="toolbar1" Addshow="0" Copyshow="0" Delshow="0" Editshow="0" QSearchshow="0" Exportshow="1" Printshow="1" ASearchshow="1" runat="server" ></toolbar:ToolBar>
    </div>
</asp:Content>
