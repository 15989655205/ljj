<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Project_IDE.aspx.cs" Inherits="Maticsoft.Web.Project111.Project_IDE" %>
<%@ Register TagPrefix="stage_IDE" TagName="Stage_IDE" Src="../Controls/Project/Stage_IDE.ascx" %>
<%@ Register TagPrefix="imp_IDE" TagName="Imp_IDE" Src="../Controls/Project/Imp_IDE.ascx" %>
<%@ Register TagPrefix="group_IDE" TagName="Group_IDE" Src="../Controls/Project/Group_IDE.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/datagrid-detailview.js" type="text/javascript"></script>
    <link href="../js/SimpleModel/basic.css" rel="stylesheet" type="text/css" />
    <script src="../js/SimpleModel/jquery.simplemodal.1.4.4.min.js" type="text/javascript"></script>
    <script src="../js/easyui/jquery.combo.js" type="text/javascript"></script>
<script type="text/javascript">
    var submitURL = "";
    $(function () {
        switch ("<%=type %>") {
            case "add":
                submitURL = "../Ashx/Project.ashx?action=add";
                break;
            case "update":
                submitURL = "../Ashx/Project.ashx?action=update";
                InitSubGrid("<%=sid %>");
                break;
        }
        project_dept_tree();
    });

    function InitSubGrid(psid) {
        $('#sub_tt').datagrid({
            fit: true,
            nowrap: false, //是否换行，True 就会把数据显示在一行里
            singleSelect: false, //单选
            collapsible: false, //可折叠
            remoteSort: false, //定义是否从服务器给数据排序
            fitColumns: true, //列自适应
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { "action": "sub_list", "psid": psid },
            idField: 'sid', //标识字段,主键

            columns: [[
            //                    { field: 'ckb', checkbox: true },
                    {title: '系统编号', field: 'sid', width: 60, sortable: true, halign: 'center', align: 'center', hidden: true
                        ,
                    formatter: function (value, rowData, rowIndex) {
                        return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
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
                    },
                    { title: '小组', field: 'group', width: 80, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a style="color:red" href="javascript:;" onclick="Group(\'' + rowIndex + '\');"><img src="../images/user_group.gif" /></a>';
                        }
                    },
                    { title: '工作种类及人员', field: 'wordtype', width: 80, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a style="color:red" href="javascript:;" onclick="Implement(\'' + rowIndex + '\');"><img src="../images/comm.gif" /></a>';
                        }
                    },
                    
                    { title: '工作内容', field: 'work', width: 80, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a style="color:red" href="javascript:;" onclick="Content(\'' + rowData.sid + '\');"><img src="../images/edit.gif" /></a>';
                        }
                    }
                    ]],
            toolbar: [{
                iconCls: 'icon-add',
                text: '添加',
                handler: function () {
                    if (art.dialog.get('stage_dialog') != null) {
                        art.dialog.get('stage_dialog').close();
                    }
                    openDialog("add", "", "新增阶段");
                }
            }, '-', {
                iconCls: 'icon-edit',
                text: '修改',
                handler: function () {
                    var row = $('#sub_tt').datagrid('getSelected');
                    if (row!=null) {
                        var index = $('#sub_tt').datagrid('getRowIndex', row);
                        if (art.dialog.get('stage_dialog') != null) {
                            art.dialog.get('stage_dialog').close();
                        }
                        openDialog("edit", index, '修改阶段信息');
                    }
                    else {
                        $.messager.show({ title: '提示', msg: '请先选择修改内容' });
                    }
                }
            }, '-', {
                iconCls: 'icon-remove',
                text: '删除',
                handler: function () {
                    $.messager.confirm('提示', '确认删除？', function (r) {
                        if (r) {
                            var selected = $('#sub_tt').datagrid('getSelected');
                            if (selected == "") {
                                $.messager.alert('提示', '请选择要删除的数据！', 'info');
                                return;
                            }

                            $.post('../Ashx/Project.ashx', { "action": "stage_del", "cbx_select": selected.sid }, function (data) {
                                //                    alert(data);
                                if (data == "success") {
                                    $("#sub_tt").datagrid("reload");
                                    $.messager.show({ title: '提示', msg: '删除成功！' });
                                }
                                else {
                                    $.messager.show({ title: '提示', msg: data });
                                }
                            });
                        }
                    });
                }
            }],
            //            view: detailview,
            //            detailFormatter: function (index, row) {
            //                return '<div style="padding:2px"><table id="ddv-' + index +'"></table><table id="work-' + index +'"></table></div>';
            //            },
            //            onExpandRow: function (index, row) {
            //                $('#ddv-' + index).datagrid({
            //                    url: '../Ashx/Project.ashx',
            //                    queryParams: { "action": "implement_list", "ssid": row.sid },
            //                    fitColumns: true,
            //                    singleSelect: true,
            //                    sortOrder: 'asc',
            //                    idField: 'sid',
            //                    height: 'auto',
            //                    columns: [[
            //							{ field: 'sid', title: 'sid', width: 100, hidden: true },
            //							{ field: 'implement_name', title: '工作种类', width: 50, halign: 'center' },
            //							{ field: 'implementers', title: '工作人员', width: 100, halign: 'center' }
            //						]],
            //                    onResize: function () {
            //                        $('#sub_tt').datagrid('fixDetailRowHeight', index);
            //                    },
            //                    onLoadSuccess: function () {
            //                        setTimeout(function () {
            //                            $('#sub_tt').datagrid('fixDetailRowHeight', index);
            //                        }, 0);
            //                    }
            //                });

            //                $('#work-' + index).datagrid({
            //                    url: '../Ashx/Project.ashx',
            //                    queryParams: { "action": "implement_list", "ssid": row.sid },
            //                    fitColumns: true,
            //                    singleSelect: true,
            //                    sortOrder: 'asc',
            //                    idField: 'sid',
            //                    height: 'auto',
            //                    columns: [[
            //							{ field: 'sid', title: 'sid', width: 100, hidden: true },
            //							{ field: 'implement_name', title: '工作种类', width: 50, halign: 'center' },
            //							{ field: 'implementers', title: '工作人员', width: 100, halign: 'center' }
            //						]],
            //                    onResize: function () {
            //                        $('#sub_tt').datagrid('fixDetailRowHeight', index);
            //                    },
            //                    onLoadSuccess: function () {
            //                        setTimeout(function () {
            //                            $('#sub_tt').datagrid('fixDetailRowHeight', index);
            //                        }, 0);
            //                    }
            //                });
            //                $('#sub_tt').datagrid('fixDetailRowHeight', index);
            //            },
            onLoadSuccess: function (data) {
            },
            onClickCell: function (rowIndex, field, value) {
                if (field != "ckb") {
                    $('#sub_tt').datagrid('clearSelections');
                }
            },
            onClickRow: function (rowIndex, rowData) {
                if (rowIndex >= 0) {
                }
            }
        });
    }

    function project_dept_tree() {
        $('#project_dept').combotree({
            url: '../Ashx/Common.ashx?type=dept_tree_open',
            valueField: 'id',
            textField: 'text',
            editable: false,
            onLoadSuccess: function (node, data) {
                $('#project_dept').combotree('tree').tree('collapseAll');
                project_group_appr();
                project_trial_appr();
                project_qs_appr();
            },
            onChange: function (newValue, oldValue) {
                $.post("../Ashx/Common.ashx", { type: "dept_users", deptid: newValue }, function (data) {
                    project_push(data);
                    project_trial_push(data)
                    project_sq_push(data)
                });
            }
        });
    }

    function project_push(data) {
        //alert(data);
        var array = JSON.parse(data);
        //小组审核
        var rows = $('#group_appr').combobox('getValues');
        var textArr = $('#group_appr').combobox('getText').split(',');
        for (var i = 0; i < rows.length; i++) {
            var ishave = false;
            for (var j = 0; j < array.length; j++) {

                if (array[j].UserName == rows[i]) {
                    ishave = true;
                    break;
                }
            }
            if (!ishave) {
                array.push({ "UserName": rows[i], "Name": textArr[i] });
            }
        }
        $('#group_appr').combobox('loadData', array);
    }

    function project_trial_push(data) {
        //初审
        var trial_array = JSON.parse(data);
        rows = $('#trial_appr').combobox('getValues');
        textArr = $('#trial_appr').combobox('getText').split(',');
        for (var i = 0; i < rows.length; i++) {
            var ishave = false;
            for (var j = 0; j < trial_array.length; j++) {

                if (trial_array[j].UserName == rows[i]) {
                    ishave = true;
                    break;
                }
            }
            if (!ishave) {
                trial_array.push({ "UserName": rows[i], "Name": textArr[i] });
            }
        }
        $('#trial_appr').combobox('loadData', trial_array);
    }

    function project_sq_push(data) {
        //质量监督
        var qs_array = JSON.parse(data);
        rows = $('#qs_appr').combobox('getValues');
        textArr = $('#qs_appr').combobox('getText').split(',');
        for (var i = 0; i < rows.length; i++) {
            var ishave = false;
            for (var j = 0; j < qs_array.length; j++) {

                if (array[j].UserName == rows[i]) {
                    qs_array = true;
                    break;
                }
            }
            if (!ishave) {
                qs_array.push({ "UserName": rows[i], "Name": textArr[i] });
            }
        }
        $('#qs_appr').combobox('loadData', qs_array);
    }

    function project_push_json_group(array, data, text) {
        if (data != "" && data != null) {
            var rows = data.split(',');
            var textArr = text.split(',');
            for (var i = 0; i < rows.length; i++) {
                var ishave = false;
                for (var j = 0; j < array.length; j++) {

                    if (array[j].UserName == rows[i] || array[j].UserName == "") {
                        ishave = true;
                        break;
                    }
                }
                if (!ishave) {
                    array.push({ "UserName": rows[i], "Name": textArr[i] });
                }
            }
            $('#group_appr').combobox('loadData', array);
            $('#group_appr').combobox('setValues', rows);
        }
    }

    function project_push_json_trial(array, data, text) {
        if (data != "" && data != null) {
            var rows = data.split(',');
            var textArr = text.split(',');
            for (var i = 0; i < rows.length; i++) {
                var ishave = false;
                for (var j = 0; j < array.length; j++) {

                    if (array[j].UserName == rows[i] || array[j].UserName == "") {
                        ishave = true;
                        break;
                    }
                }
                if (!ishave) {
                    array.push({ "UserName": rows[i], "Name": textArr[i] });
                }
            }
            $('#trial_appr').combobox('loadData', array);
            $('#trial_appr').combobox('setValues', rows);
        }
    }

    function project_push_json_qs(array, data, text) {
        if (data != "" && data != null) {
            var rows = data.split(',');
            var textArr = text.split(',');
            for (var i = 0; i < rows.length; i++) {
                var ishave = false;
                for (var j = 0; j < array.length; j++) {

                    if (array[j].UserName == rows[i] || array[j].UserName == "") {
                        ishave = true;
                        break;
                    }
                }
                if (!ishave) {
                    array.push({ "UserName": rows[i], "Name": textArr[i] });
                }
            }
            $('#qs_appr').combobox('loadData', array);
            $('#qs_appr').combobox('setValues', rows);
        }
    }

    function project_group_appr() {//sid) {
        var myload = false;
        $('#group_appr').combobox({
            //url: '../Ashx/Common.ashx?type=dept_users&deptid=' + sid,
            url: '',
            valueField: 'UserName',
            textField: 'Name',
            required: true,
            multiple: true,
            editable: false,
            onLoadSuccess: function () {
                if (!myload) {
                    myload = true;
                    //var row = $('#project_tt').datagrid('getSelected');
                    project_push_json_group($('#group_appr').combobox('getData'), "<%=model.v1 %>", "<%=v1 %>");
                }
            },
            onChange: function (newValue, oldValue) {
            },
            onHidePanel: function () {
            }
        });
    }

    function project_trial_appr() {//sid) {
        var myload = false;
        $('#trial_appr').combobox({
            //url: '../Ashx/Common.ashx?type=dept_users&deptid=' + sid,
            url: '',
            valueField: 'UserName',
            textField: 'Name',
            required: true,
            multiple: true,
            editable: false,
            onLoadSuccess: function () {
                if (!myload) {
                    myload = true;
                    //var row = $('#project_tt').datagrid('getSelected');
                    //project_push_json($('#project_uid').combobox('getData'), row.implementers_sid, row.impUserNames);
                    project_push_json_trial($('#group_appr').combobox('getData'), "<%=model.v2 %>", "<%=v2 %>");
                }
            },
            onChange: function (newValue, oldValue) {
            },
            onHidePanel: function () {
            }
        });
    }

    function project_qs_appr() {//sid) {
        var myload = false;
        $('#qs_appr').combobox({
            //url: '../Ashx/Common.ashx?type=dept_users&deptid=' + sid,
            url: '',
            valueField: 'UserName',
            textField: 'Name',
            required: true,
            multiple: true,
            editable: false,
            onLoadSuccess: function () {
                if (!myload) {
                    myload = true;
                    //var row = $('#project_tt').datagrid('getSelected');
                    //project_push_json($('#project_uid').combobox('getData'), row.implementers_sid, row.impUserNames);
                    project_push_json_qs($('#group_appr').combobox('getData'), "<%=model.v3 %>", "<%=v3 %>");
                }
            },
            onChange: function (newValue, oldValue) {
            },
            onHidePanel: function () {
            }
        });
    }

    function Implement(index) {
        if (art.dialog.get('imp_dialog') != null) {
            art.dialog.get('imp_dialog').close();
        }
        imp_openDialog(index, "阶段工作种类管理");
        //$('#imp_edit').modal();
    }

    function Group(index) {
        if (art.dialog.get('group_dialog') != null) {
            art.dialog.get('group_dialog').close();
        }
        group_openDialog(index, "小组管理");
    }

    function Content(sid) {
        url = "/Project/ProjectContent_IDE.aspx?ps_sid=" + sid ;
        parent.addTab_Ext('项目内容', url, "", true);
    }

    function save() {
        $('#ff').form({
            url: submitURL,
            onSubmit: function () {
                // do some check   
                // return false to prevent submit;  
                var isValid = $(this).form('validate');
//                if (!isValid) {
//                    $.messager.progress('close'); // hide progress bar while the form is invalid
//                }
                return isValid; 
            },
            success: function (data) {
                var arr = data.split('|');
                if (arr[0] == "success") {
                    switch ("<%=type %>") {
                        case "add":
                            $.messager.show({ title: '提示', msg: "添加成功！" });
                            $('#hsid').val(arr[1]);
                            InitSubGrid($('#hsid').val());
                            break;
                        case "update":
                            $.messager.show({ title: '提示', msg: "修改成功！" });
                            break;
                    }

                    try {
                        var tab = parent.$('#tabs').tabs('getTab', '项目设置');
                        parent.$('#tabs').tabs('update', {
                            tab: tab,
                            options: {}
                        });
                    }
                    catch (e) {
                        //alert(e.Message);
                    }
                }
                else {
                    $.messager.show({ title: '错误提示', msg: arr[0] });
                }
            }
        });
        // submit the form   
        $('#ff').submit();

    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
<%--<div style="width:98%; background-color:White;">--%>
        <table id="PrintHide" style="width: 100%; position:absolute; background-color:White;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img alt="" src="../images/BanKuaiJianTou.gif" />
                   <%-- <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;工作流程&nbsp;>>&nbsp;添加新工作--%>
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <img id="submit" src="../images/Button/Submit.jpg" alt="" runat="server" onclick="save();" style="cursor:pointer;"/>&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2" style="background-color: #ffffff">
                </td>
            </tr>
        </table>
<%--  </div>--%>
<div style="height:35px;"></div>
<form id="ff" action="" class="" method="post">
<input type="hidden" id="hsid" name="hsid" value="<%=sid %>" />
<input type="hidden" id="haction" name="haction" value="<%=type %>" />
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" colspan="6" style="height: 25px; background-color: #e1f5fc; text-align: center">
                    <strong>项目基本属性</strong>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 200px; background-color: #e1f5fc; height: 25px;">
                    项目名称(Project name)：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="project_name" name="project_name" value="<%=model==null?"":model.project_name %>" style="width:80%" class="easyui-validatebox" data-options="required:true,missingMessage:'必填'"/>
                </td>
                 <td align="right" style="width: 200px; background-color: #e1f5fc; height: 25px;">
                    项目编号(Project code)：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="project_code" name="project_code" value="<%=model==null?"":model.project_code %>" style="width:80%"/>
                </td>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    制作日期(Date)：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="creation_date" name="creation_date" value="<%=model==null?DateTime.Now.ToShortDateString().Trim():model.creation_date %>" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" style="width:80%"/>
                </td>
            </tr>
            <tr>
                <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    制作人(Prepared by)：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="prepared_by" name="prepared_by" value="<%=model==null?"":model.prepared_by %>" style="width:80%"/>
                </td>
                 <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    进度监督人(Reviewed by)：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="reviewed_by" name="reviewed_by" value="<%=model==null?"":model.reviewed_by %>" style="width:80%"/>
                </td>
                 <td align="right" style="background-color: #e1f5fc; height: 25px;">
                    项目负责人(Project manaager)：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="project_manager" name="project_manager" value="<%=model==null?"":model.project_manager %>" style="width:80%"/>
                </td>
            </tr>
            <tr>
               <td align="right"  style=" background-color: #e1f5fc; height: 25px;">
                    审核人部门选择：
               </td>
               <td colspan="5" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
               <input id="project_dept" name="project_dept" type="text" style="width:200px"/>
               </td>
            </tr>
             <tr>
               <td align="right"  style=" background-color: #e1f5fc; height: 25px;">
                    小组审核人：
               </td>
               <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
               <input id="group_appr" name="group_appr" type="text" style="width:200px"/>
               </td>
               <td align="right"  style=" background-color: #e1f5fc; height: 25px;">
                    初审人：
               </td>
               <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
               <input id="trial_appr" name="trial_appr" type="text" style="width:200px"/>
               </td>
               <td align="right"  style=" background-color: #e1f5fc; height: 25px;">
                    质量监督人：
               </td>
               <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
               <input id="qs_appr" name="qs_appr" type="text" style="width:200px"/>
               </td>
            </tr>
            <tr>
                <td align="right" style="background-color: #e1f5fc; height: 25px;">
                    备注(Remark)：
                </td>
                <td colspan="5" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <textarea id="remark" name="remark" rows="3" cols="10" class="validate[maxSize[100]] " style="width:95%;"
                    onkeyup="this.style.height = (this.scrollHeight-8<=50?50:this.scrollHeight-4) + 'px';"
                    onkeydown="this.style.height = (this.scrollHeight-8<=50?50:this.scrollHeight-4) + 'px';"
                    onpropertychange="this.style.height = (this.scrollHeight-8<=50?50:this.scrollHeight-4) + 'px';"
                    oninput="this.style.height = (this.scrollHeight-8<=50?50:this.scrollHeight-4) + 'px';"><%=model==null?"":model.remark %></textarea>
                </td>
            </tr>
       
   <%--    阶段信息--%>
            <tr>
                <td align="right" colspan="6" style="height: 25px; background-color: #e1f5fc; text-align: center">
                    <strong>项目进度</strong>
                </td>
            </tr>
       </table>
       <table id="sub_tt"></table>
    </form>
    </div>

      <div id="Edit" style="display:none;">
        <stage_IDE:Stage_IDE ID="stage_ide" runat="server"></stage_IDE:Stage_IDE>
    </div>

     <div id="imp_edit" style="display:none;">
        <imp_IDE:Imp_IDE ID="imp_ide1" runat="server"></imp_IDE:Imp_IDE>
    </div>

    <div id="group_edit" style="display:none;">
        <group_IDE:Group_IDE ID="group_ide1" runat="server"></group_IDE:Group_IDE>
    </div>
    <script type="text/javascript">
</script>
</asp:Content>
