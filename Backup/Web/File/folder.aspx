<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="folder.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.folder" %>
<%@ Register TagName="ToolBar" TagPrefix="tool" Src="~/Controls/toolbar.ascx" %>
<%@ Register TagName="CopyFolder" TagPrefix="copyfolder" Src="~/Controls/File/CopyFolder.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    var isLoad = true;
    $(function () {
        $("#tt").treegrid({
            iconCls: 'icon-ok',
            url: '../Ashx/Folder.ashx?action=list',
            //queryParams: { "action": "list" },
            idField: 'ID',
            treeField: 'folder_name',
            toolbar: '#tab_toolbar',
            //            fit:true,
            //            fit:true,
            //lines:true,
            pageSize: 5,
            pageList: [5,10, 20, 30, 40, 50, 100],
            pagination: true,
            fitColumns: true,
            fit: true,

            //            singleSelect: false,

            //            checkbox: true,
            //            lines: true,
            //            onlyLeafCheck: true,
            //            animate: true,
            //            cascadeCheck:true,  //普通级联（不包括未加载的子节点）
            //            deepCascadeCheck:true, //深度级联（包括未加载的子节点）
            //collapsible: true, 

            frozenColumns: [[
            //            { field: "ckb", checkbox: true, width: 10 },
            //            {field: 'ckb', title: '选择', width: 10, formatter: function (value, rowData, rowIndex) { if (rowData.ftype == 2) return '<input type="checkbox" id="' + rowData.ID + '" name="' + rowData.ID + '"/>'; else return ''; } },
                           // {field: 'folder_name', title: '文件夹名称', width: 300, formatter: function (value, rowData, rowIndex) { if (rowData.ftype == 2) return  '<input type="checkbox" id="' + rowData.ID + '" name="' + rowData.ID + '"/>'+value; else return value; } }
//            {field: 'ckb', title: '选择', width: 30, formatter: function (value, rowData, rowIndex) { if (rowData.ftype == 2) return '<input type="checkbox" id="' + rowData.ID + '" name="' + rowData.ID + '"/>'; else return ''; } },
{ field: 'folder_name', title: '文件夹名称', width: 300 }
                ]],
            columns: [[
            //                { field: 'folder_name', title: '文件夹名称', width: 100 },

                {field: 'create_person', title: '创建人', width: 100 },
                { field: 'create_date', title: '创建时间', width: 100 },
                { field: 'update_person', title: '修改人', width: 100 },
                { field: 'update_date', title: '修改时间', width: 100 },
                { field: 'remark', title: '备注', width: 200 }
            ]]
            ,
            onLoadSuccess: function (row, data) {
                delete $(this).treegrid('options').queryParams['id'];
                if (isLoad) {
                    isLoad = false;
                    //$("#tt").treegrid("collapseAll");
                }
            },
            onClickRow: function (row) {
                //                //级联选择  
                //                $(this).treegrid('cascadeCheck', {
                //                    id: row.ID, //节点ID  
                //                    deepCascade: true //深度级联  
                //                });
            },
            onClickCell: function (field, row) {
                //if (field != 'ckb') { $("#tt").treegrid("clearSelections"); } 
            }
        });
        folderParent();
        //jQuery("#ff").validationEngine({ showOnMouseOver: false, promptPosition: 'topLeft', autoHidePrompt: true, autoHideDelay: 2000 });
    });
    //添加新记录
    function add() {
        url = "/File/Folder_IDE.aspx?action=add";
        parent.addTab_Ext('新建文件夹', url, "", false);
    };
    function copy() {
        var row = $('#tt').treegrid('getSelected');
        if (row != null) {
            if (row.ftype == 1) {
                if (art.dialog.get('copy_folder_dialog') != null) {
                    art.dialog.get('copy_folder_dialog').close();
                }
                //var index = $('#tt').treegrid('getRowIndex', row);
                openDialog("copy", row, "复制文件夹");
            }
            else
                $.messager.show({ title: '错误提示', msg: '只能复制文件夹' });
        }
        else {
            $.messager.show({ title: '错误提示', msg: '请选择要复制的文件夹' });
        }
    }
    function edit() {
        var row = $("#tt").treegrid("getSelected");
        if (row == null) {

            $.messager.alert('提示！', '未选中文件夹', 'warning');


        }
        else {
            if (row.ftype == 1) {
                url = "/File/Folder_IDE.aspx?action=edit&id=" + row.ID;
                var folder_name = row.folder_name;
                //            alert(folder_name.length);
                if (folder_name.length > 4) {
                    folder_name = folder_name.substring(0, 3) + '...';
                }
                parent.addTab_Ext("修改文件夹【" + folder_name + "】", url, "", false);
            }
            else
                $.messager.show({ title: '错误提示', msg: '只能编辑文件夹' });
        }
    };
    function del() {
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                var row = $("#tt").treegrid("getSelected");
                if (row == null) {
                    $.messager.alert('提示！', '未选中文件夹', 'warning');
                }
                else {
                    var p = $("#tt").treegrid("getParent",row.ID);
                    var pid = p.ID;
                    $.ajax({
                        tpye: 'POST',
                        url: '../Ashx/Folder.ashx',
                        timeout: 8000,
                        data:
                {
                    'action': 'del',
                    'ID': row.ID,
                    'ftype': row.ftype
                },
                        success: function (data) {
                            if (data == "success") {

                                $("#tt").treegrid('options').url = '../Ashx/Folder.ashx?action=list';
                                //                        $("#tt").treegrid('options').queryParams = { "action": "list" };
                                $("#tt").treegrid('reload', pid);
                                $.messager.show({ title: '提示', msg: "删除成功！" });
                            }
                            else {
                                $.messager.show({ title: '错误提示', msg: (data == "success" ? "保存成功" : data) });

                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                        }
                    })

                }
            }
        });

    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="toolbarDIV" style="height:0px">
    <tool:ToolBar ID="tool" PageID="1513" runat="server" />
    
</div><table id="tt"></table>

<div id="detail" >
<copyfolder:CopyFolder ID="copyfolder" runat="server" />
</div>
</asp:Content>
