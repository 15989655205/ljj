<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="AllAD.aspx.cs" Inherits="Maticsoft.Web.ADAndNotice.AllAD" %>
<%@ Register TagName="img_ide" TagPrefix="img_IDE" Src="~/Controls/ADandNotice/AD_IDE.ascx"%>
<%@ Register TagName="ToolBar" TagPrefix="toolbar" Src="~/Controls/toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    var action;
    $(function () {
        $("#tt").datagrid({
            url: "../Ashx/ad.ashx",
            queryParams: { "action": "getAllAD" },
            loadMsg: '正在努力加载中...',
            idField: 'id',
            pageSize: 10,
            pageList: [10, 20, 30, 40, 50, 100],
            pagination: true,
            //            pagination: true,
            sortName: 'CreateTime',
            sortOrder: 'asc',
            rownumbers: true,
            singleSelect: true,
            toolbar: "#tab_toolbar",
            striped: true, //True 奇偶行使用不同背景色
            frozenColumns: [[
            { field: "img_name", title: "图片名称", width: 100 },
            { field: "title", title: "标题", width: 100 },

        ]],
            columns: [[
            { field: "v1", title: "图片", width: 100 },
            { field: "notice_title", title: "公告标题", width: 100 },
            { field: "CreateUser", title: "创建人", width: 100 },
            { field: "CreateTime", title: "创建时间", width: 100 },
            { field: "UpdateUser", title: "修改人", width: 100 },
            { field: "UpdateTime", title: "修改时间", width: 100 },
            { field: "showname", title: "是否显示", width: 100 },
            { field: "noticeid", title: "公告id", width: 100, hidden: true },
            { field: "v1_1", title: '图片路径', width: 100, hidden: true }


        ]]

        });

    });
</script>
<style type="text/css">
    .img_size
    {
        width:20px;
        height:20px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="toolbarDIV" style="height:0px">
 <toolbar:ToolBar ID="tool" runat="server" />
<table id="tt"></table>

<%--<div id="st" style="padding:5px;height:auto">
   
   <div style="float:left"><a href="#" onclick="add()" id="a_add" class="easyui-linkbutton" data-options="plain:true,iconCls: 'icon-add'">新增</a></div>
   <div style="float:left"><a href="#" onclick="edit();return false;" id="a_edit" class="easyui-linkbutton" data-options="plain:true,iconCls: 'icon-edit'">编辑</a></div>                
   <div style="float:left"><a href="#" onclick="view();return false;" id="a_view" class="easyui-linkbutton" data-options="plain:true,iconCls: 'icon-view'">查看</a></div>
   <div style="float:left"><a href="#" onclick="del();return false;" id="a_del" class="easyui-linkbutton" data-options="plain:true,iconCls: 'icon-remove'">删除</a></div>
</div>--%>
</div>
<div style="display:none">
    <img_IDE:img_ide runat="server" ID="img_IDE_img"/>
</div>
<div style="display:none">
    <div ><img id="big_img" alt=""/></div>
</div>

<script type="text/javascript">
    function add() {
        action = "add_img";
        $("#ckb").removeAttr("checked");
        $("#img_name").val("");
        $("#title").val("");
        $("#img_id").val("");
        $("#img_win").window("open");
    }
    function edit() {
        action = "edit_img";
        var row = $("#tt").datagrid("getSelected");
        if (row==null) {
            alert("请选择一行！");
        }
        else {
            ff.reset();
            $("#img_name").val(row.img_name);
            $("#title").val(row.title);
            $("#img_id").val(row.id);
            $("#img_load").val(row.v1_1);
//            $("#uploadify").val("");
            if (row.showname=='是') {
                $("#ckb").attr("checked", "true");
            }
            else {
                $("#ckb").removeAttr("checked");
            }
            $("#img_win").window("open");
        }

    }
    function view() {
        var row = $("#tt").datagrid("getSelected");
        if (row == null) {
            alert("请选择一行！");
        }
        else {
            $("#big_img").attr("src", row.v1_1);
            $('#big_img').window({
                title: '图片',
                height: $("#big_img").height(),
                width: $("#big_img").width(),
                modal: true,
                shadow: true,
                closed: true,
                resizable: false,
                minimizable: false,
                collapsible: false,
                maximizable: false
            });
            $("#big_img").window("open");
            
        }
    }
    function del() {
        var row = $("#tt").datagrid("getSelected");
        if (row == null) {
            alert("请选择一行！");
        }
        else {
            $.messager.confirm('提示', '确认删除？', function (r) {
                if (r) {

                    $.ajax({
                        type: "POST",
                        timeout: 6000,
                        url: "../Ashx/ad.ashx",
                        data: {
                            'action': 'del',
                            'id': row.id,
                            'v1': row.v1_1
                        },
                        success: function (data) {
                            if (data == "success") {
                                $.messager.show({ title: '提示', msg: "删除成功！" });
                                $("#tt").datagrid("reload");


                            }
                            else {
                                $.messager.show({ title: '错误提示', msg: (data=="success"?"保存成功":data) });
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                        }
                    })
                }
            })

        }
    }
</script>
</asp:Content>
