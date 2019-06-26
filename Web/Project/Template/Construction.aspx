<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Construction.aspx.cs" Inherits="Maticsoft.Web.Project.Template.Construction" %>
<%@ Register TagPrefix="pc_IDE" TagName="PC_IDE" Src="../../Controls/Project/Template/Content_IDE.ascx" %>
<%@ Register TagPrefix="item_IDE" TagName="Item_IDE" Src="../../Controls/Project/Template/ContentItem.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../js/themes/default/datagrid1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var columns = "<%=column %>";
        $(function () {
            InitGird();
        });

        //初始化表格
        function InitGird() {
            grid = $('#tt').datagrid({
                title: "<%=stageName %>-工作内容模板",
                fit: true,
                singleSelect: true, //单选
                fitColumns: true, //列自适应
                url: '../../Ashx/ProjectStage.ashx', //请求数据的页面
                queryParams: { "action": "content_list", "pssid": "<%=pssid %>" },
                idField: 'rowid', //标识字段,主键

                columns: eval('(' + columns + ')'),
                toolbar: "#menu",
                //                [{
                //                    iconCls: 'icon-add',
                //                    text: '添加工作内容',
                //                    handler: function () {
                //                        addContent();
                //                    }
                //                }, {
                //                    iconCls: 'icon-add',
                //                    text: '添加细目',
                //                    handler: function () {
                //                        add();
                //                    }
                //                }, '-', {
                //                    iconCls: 'icon-edit',
                //                    text: '修改工作内容',
                //                    handler: function () {
                //                        edit();
                //                    }
                //                }, {
                //                    iconCls: 'icon-edit',
                //                    text: '修改细目',
                //                    handler: function () {
                //                        edit();
                //                    }
                //                }, '-', {
                //                    iconCls: 'icon-remove',
                //                    text: '删除',
                //                    handler: function () {
                //                        del();
                //                    }
                //                }],
                onLoadSuccess: function (data) {
                    if (data.rows.length > 0) { mergeCellsByField('tt', 'stage_name,group_name,contentName'); }
                },
                onClickRow: function (row) {
                },
                onRowContextMenu: function (e, rowIndex, rowData) {
                    e.preventDefault();
                    var selected = $("#tt").datagrid('getRows'); //获取所有行集合对象
                    var idValue = selected[rowIndex].sid;
                    $(this).datagrid('selectRecord', idValue);  //通过获取到的id的值做参数选中一行
                    $('#content_mm').menu('show', {
                        left: e.pageX,
                        top: e.pageY
                    });
                }
            });
        }

        function addContent() {
            var row = $('#tt').datagrid('getSelected');
            if (art.dialog.get('pc_dialog') != null) {
                art.dialog.get('pc_dialog').close();
            }
            pc_openDialog("add", "<%=pssid %>", row, "工作内容");
        }

        function editContent() {
            var row = $('#tt').datagrid('getSelected');
            if (row != null) {
                if (art.dialog.get('pc_dialog') != null) {
                    art.dialog.get('pc_dialog').close();
                }
                pc_openDialog("alter", "<%=pssid %>", row, "修改工作内容");
            } else {
                $.messager.show({ title: '提示', msg: "请选择要修改内容" });
            }
        }

        //删除
        function delContent() {
            var row = $('#tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '提示', msg: "请选择要删除数据" });
                return false;
            }
            if (row.parent_sid != "") {
                if (!confirm('工作内容里有细目，如果执行删除细目也会同时删除\n是否继续执行删除？')) {
                    return false;
                }
            }
            // $.messager.confirm('提示', '工作内容里有细目，如果执行删除细目也会同时删除。是否继续执行删除？', function (r) {
            //    if (r) {
            $.messager.confirm('提示', '确认删除？', function (r) {
                if (r) {
                    $.post('../../Ashx/ProjectStage.ashx', { "action": "content_del", "sid": row.csid }, function (data) {
                        if (data == "success") {
                            $("#tt").datagrid("reload");
                        }
                        else {
                            $.messager.show({ title: '提示', msg: data });
                        }
                    });
                }
            });
            //    }
            //});
        }


        function addItem() {
            var row = $('#tt').datagrid('getSelected');
            if (art.dialog.get('item_dialog') != null) {
                art.dialog.get('item_dialog').close();
            }
            item_openDialog("add", "<%=pssid %>", row, "细目");
        }

        function editItem() {
            var row = $('#tt').datagrid('getSelected');
            if (row != null) {
                if (art.dialog.get('item_dialog') != null) {
                    art.dialog.get('item_dialog').close();
                }
                item_openDialog("alter", "<%=pssid %>", row, "修改细目");
            } else {
                $.messager.show({ title: '提示', msg: "请选择要修改内容" });
            }
        }

        function delItem() {
            var row = $('#tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '提示', msg: "请选择要删除数据" });
                return false;
            }
            $.messager.confirm('提示', '确认删除？', function (r) {
                if (r) {
                    $.post('../../Ashx/ProjectStage.ashx', { "action": "item_del", "sid": row.sid }, function (data) {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="hidden" id="hpssid" name="hpssid" value="<%=pssid %>" />
    <table id="tt">
    </table>
    <div id="pc_edit" style="display: none;">
        <pc_IDE:PC_IDE ID="pc_ide1" runat="server"></pc_IDE:PC_IDE>
    </div>

    <div id="item_edit" style="display: none;">
        <item_IDE:Item_IDE ID="pc_ide2" runat="server"></item_IDE:Item_IDE>
    </div>

    <div id="menu">
        <a href="javascript:void(0)" id="add" class="easyui-menubutton" data-options="menu:'#mm_add',iconCls:'icon-add'">
            添加</a>
        <a href="javascript:void(0)" id="edit" class="easyui-menubutton" data-options="menu:'#mm_edit',iconCls:'icon-edit'">
            修改</a>
        <a href="javascript:void(0)" id="del" class="easyui-menubutton" data-options="menu:'#mm_del',iconCls:'icon-remove'">
            删除</a>
        <div id="mm_add" style="width: 150px;">
            <div data-options="" onclick="addContent();">
                添加工作内容</div>
            <div class="menu-sep"></div>
            <div data-options="" onclick="addItem();">
                添加细目</div>
        </div>
        <div id="mm_edit" style="width: 150px;">
            <div data-options="iconCls:'icon-undo'" onclick="editContent();">
                修改工作内容</div>
            <div class="menu-sep"></div>
            <div data-options="iconCls:'icon-redo'" onclick="editItem();">
                修改细目</div>
        </div>
        <div id="mm_del" style="width: 150px;">
            <div data-options="iconCls:'icon-undo'" onclick="delContent();">
                删除工作内容</div>
            <div class="menu-sep"></div>
            <div data-options="iconCls:'icon-redo'" onclick="delItem();">
                删除细目</div>
        </div>
    </div>

    <div id="group_mm" class="easyui-menu" style="width: 120px;">
        <div onclick="" data-options="iconCls:'icon-add'">
            添加工作内容</div>
        <div onclick="" data-options="iconCls:'icon-add'">
            添加细目</div>
        <div onclick="" data-options="iconCls:'icon-add'">
            修改</div>
    </div>
</asp:Content>

