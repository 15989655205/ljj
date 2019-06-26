<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectContent_IDE.ascx.cs"
    Inherits="Maticsoft.Web.Controls.Project.ProjectContent_IDE" %>
<script type="text/javascript">
var action="";
var Global_pgroup = "";
var golde_row=[];
function pc_openDialog(type, pssid, row, title) {

    var lock = true;
    if (art.dialog.list['pc_dialog'] == null) {
        art.dialog({
            content: document.getElementById('pc_edit'),
            id: 'pc_dialog',
            title: title,
            padding: '0px 0px 0px 0px',
            background: '#c3c3c3',
            resize: false,
            esc: false,
            lock: lock,
            init: function () {
                golde_row = row;
                switch (type) {
                    case "add":
                        action = "pro_content_add";
                        $('#imp_select_content').attr('disabled', false);
                        project_group(pssid);
                        project_implement(pssid);
                        project_content(pssid);
                        project_implement_user('', '');
                        imp_dept_tree();
                        imp_user("-1");
                        showSelect(1);
                        $("#imp_select_content").val(1);
                        break;
                    case "alter":
                        action = "pro_content_edit";
                        $('#imp_select_content').attr('disabled', true);
                        project_group(pssid);
                        project_implement(pssid);
                        project_content(pssid);
                        project_implement_user('', '');
                        imp_dept_tree();
                        if (row.parent_sid == 0) {
                            imp_user("-1");
                        }
                        Init_alter(row);
                        break;
                    default:
                        break;
                }
                $('#pc_hsid').val(pssid);
            },
            close: function () {
            },
            button: [{
                name: '保存',
                callback: function () {
                    switch (type) {
                        case "add":
                            pc_save();
                            return false;
                            break;
                        case "alter":
                            pc_alter(row);
                            return false;
                            break;
                        default:
                            break;
                    }
                },
                focus: true
            },
		                {
		                    name: '关闭'
		                }]
        });
    }
    else {
        art.dialog.list['pc_dialog'].content(document.getElementById('pc_edit'));
    }
}

    function project_group(sid) {
        $('#pgroup').combobox({
            url: '../Ashx/project.ashx?action=project_group_combo&ps_sid=' + sid,
            valueField: 'sid',
            textField: 'group_name',
            panelHeight: "auto",
            async: false,
            editable: false,
            onChange: function (newValue, oldValue) {
            },
            onHidePanel: function () {
            }
        });
    }

    function project_implement(sid) {
        $('#p_imp').combobox({
            url: '../Ashx/project.ashx?action=project_implement_combo&ps_sid=' + sid,
            valueField: 'sid',
            textField: 'implement_name',
            panelHeight: "auto",
            editable: false,
            async: false,
            onChange: function (newValue, oldValue) {
                $.ajax({
                    url: "../Ashx/project.ashx?action=get_imp_user&sid=" + newValue,
                    success: function (data) {
                        project_implement_user(data, newValue);
                    }
                });
            },
            onHidePanel: function () {
            }
        });
    }

    function project_implement_user(sid, pisid) {
        $('#p_imp_user').combobox({
            url: '../Ashx/project.ashx?action=project_implement_user_combo&usersid=' + sid + "&pi_sid=" + pisid,
            valueField: 'username',
            textField: 'name',
            multiple: true,
            async: false,
            panelHeight: "auto",
            editable: false,
            onChange: function (newValue, oldValue) {
            },
            onHidePanel: function () {
            }
        });
    }

    function project_content(pssid) {
        $('#pw_content').combobox({
            url: '../Ashx/project.ashx?action=project_content_combo&ps_sid=' + pssid,
            valueField: 'sid',
            textField: 'name',
//            panelHeight: "auto",
            async: false,
            editable: false,

            onChange: function (newValue, oldValue) {
                $.ajax({
                    url: "../Ashx/project.ashx?action=get_content_group&sid=" + newValue,
                    success: function (data) {
                        //project_implement_user(data, newValue);
                        $('#pgroup').combobox('setValue', data);
                    }
                });
            },
            onHidePanel: function () {
            }
        });
    }

    function showSelect(flag) {
        if (flag == 1) {
            $('#begin_date').attr('disabled', true);
            $('#end_date').attr('disabled', true);
            $('#pw_content').combobox('disable');
            $('#pgroup').combobox('enable');
            $('#p_imp').combobox('disable');
            $('#p_imp_user').combobox('disable');
            $('#bt_add').attr('disabled', true);
            $('#imp_dept').combobox('disable');
            $('#imp_uid').combobox('disable');
        }
        else {

            $('#begin_date').attr('disabled', false);
            $('#end_date').attr('disabled', false);
            $('#pw_content').combobox('enable');
            $('#pgroup').combobox('disable');
            $('#p_imp').combobox('enable');
            $('#p_imp_user').combobox('enable');
            $('#bt_add').attr('disabled', false);
            $('#imp_dept').combobox('enable');
            $('#imp_uid').combobox('enable');
        }
    }

    function selectType() {

        showSelect($('#imp_select_content').val());
    }

    function addUser() {
        if ($('#p_imp').combobox('getValue').length <= 0 || $('#p_imp_user').combobox('getValues').length <= 0) {
            $.messager.show({ title: '错误提示', msg: '必须选择工作种类或者工作人员' });
            return false;
        }
        var arrun = $('#p_imp_user').combobox('getText').split(',');
        var uname = "";
        var un = "";
        for (var n = 0; n < arrun.length; n++) {
            uname += arrun[n].split('-')[0] + ",";
            un += arrun[n].split('-')[1] + ",";
        }
        uname = uname.substring(0, uname.length - 1);
        un = un.substring(0, un.length - 1);
        var imp = $('#p_imp').combobox('getValue');
        var rows = $('#imp_user_tt').datagrid('getRows');
        var add = true;
        for (var i = 0; i < rows.length; i++) {
            if (rows[i].imp_sid == imp) {

                $('#imp_user_tt').datagrid('updateRow', {
                    index: i,
                    row: {
                        implementer_sid: $('#p_imp_user').combobox('getValues').join(','),
                        wusers: uname,
                        implementer: un
                    }
                });
                add = false;
                break;
            }
        }
        if (add) {
            $('#imp_user_tt').datagrid('appendRow', {
                imp_sid: $('#p_imp').combobox('getValue'),
                wtype: $('#p_imp').combobox('getText'),
                implementer_sid: $('#p_imp_user').combobox('getValues').join(','),
                wusers: uname,
                implementer: un
            });
        }
    }

    function Del(index) {
        $('#imp_user_tt').datagrid('deleteRow', index);
    }

    function pc_save() {
        var delstr = "";
        var updatestr = "";
        var addstr = "";
        var delrows = $('#imp_user_tt').datagrid('getChanges', 'deleted');
        delstr = JSON.stringify(delrows);
        var updaterows = $('#imp_user_tt').datagrid('getChanges', 'updated');
        updatestr = JSON.stringify(updaterows);
        var addrows = $('#imp_user_tt').datagrid('getChanges', 'inserted');
        addstr = JSON.stringify(addrows);

        if ($('#pw_name').val().length <= 0) {
            $.messager.show({ title: '错误提示', msg: '名称不能为空' });
            return false;
        }

        if ($('#imp_select_content').val() == 1) {
            if ($('#pgroup').combobox('getValue').length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须选择小组' });
                return false;
            }
        } else {
            
            if ($('#pw_content').combobox('getValue').length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须所属工作内容' });
                return false;
            }
            if ($('#begin_date').val().length <= 0) {
                $.messager.show({ title: '错误提示', msg: '开始时间不能为空' });
                return false;
            }
            if ($('#end_date').val().length <= 0) {
                $.messager.show({ title: '错误提示', msg: '结束时间不能为空' });
                return false;
            }
            if(comptime($('#begin_date').val(),$('#end_date').val())==1)
            {
                 $.messager.show({ title: '错误提示', msg: '开始时间必须小于等于结束时间' });
                return false;
            }
            var b = true;
            var m = '';
            $.ajax({
                type: "POST",
                timeout: 6000,
                async: false,
                url: "../Ashx/project.ashx",
                data: {
                    'action': "checkTime",
                    'pc_hsid': $("#pc_hsid").val(),
                    'begin_date': $('#begin_date').val(),
                    'end_date': $('#end_date').val()

                },
                success: function (data) {
                    if (data != "") {
                        
                        m = data;
                        b = false;

                    }
                }

            })
            if (!b) {
                $.messager.show({ title: '错误提示', msg: m });
                return false;
             }
            if ($('#imp_user_tt').datagrid('getRows').length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须选择负责人员' });
                return false;
            }
            if ($('#imp_uid').combobox('getValues').length<=0) {
                $.messager.show({ title: '错误提示', msg: '必须选择审核人员' });
                return false;
            }

        }

        $.ajax({
            type: "POST",
            timeout: 6000,
            async: false,
            url: "../Ashx/project.ashx",
            data: {
                'action': action,
                'sid': $('#pc_sid').val(),
                'ssid': $('#pc_hsid').val(),
                'imp_content': $('#imp_select_content').val(),
                'name': $('#pw_name').val(),
                'pgroup': $('#pgroup').combobox('getValue'),
                'pw_content': $('#pw_content').combobox('getValue'),
                'begin_date': $('#begin_date').val(),
                'end_date': $('#end_date').val(),
                'pc_remark': $('#pc_remark').val(),
                'addstr': addstr,
                'updatestr': updatestr,
                'delstr': delstr,
                'v1': $('#imp_uid').combobox('getValues').join(',')
            },
            success: function (data) {
                //alert("Data Loaded: " + data);
                //$('#tt').treegrid("reload");
                //            $('#tt').treegrid("options").url = '../Ashx/Project.ashx';
                //            $('#tt').treegrid("options").queryParams = { "action": "content_list", "pssid": pssid };
                //            $('#tt').treegrid('reload');
                //            InitGird();

                $.messager.show({ title: '提示', msg: (data=="success"?"保存成功":data) });
                if (data == "success") {
                    InitGird();
                    var pw_content_val;
                    pw_content_val = $("#pw_content").combobox("getValue");
                    project_content($('#pc_hsid').val());
                    $("#pw_content").combobox("setValue", pw_content_val);
                    //                project_content($('#pc_hsid').val());
                    showSelect($("#imp_select_content").val());
                }
            }
        });
    }
    //create by zxf
    function pc_alter(row) {
        var delstr = "";
        var updatestr = "";
        var addstr = "";
        var delrows = $('#imp_user_tt').datagrid('getChanges', 'deleted');
        delstr = JSON.stringify(delrows);
        var updaterows = $('#imp_user_tt').datagrid('getChanges', 'updated');
        updatestr = JSON.stringify(updaterows);
        var addrows = $('#imp_user_tt').datagrid('getRows');
        addstr = JSON.stringify(addrows);
        
        if ($('#pw_name').val().length <= 0) {
            $.messager.show({ title: '错误提示', msg: '名称不能为空' });
            return false;
        }

        if ($('#imp_select_content').val() == 1) {
            if ($('#pgroup').combobox('getValue').length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须选择小组' });
                return false;
            }
            if ($("#pgroup").combobox("getValue") != Global_pgroup) {
                if (!confirm("修改小组，将会改变其细目的小组，是否继续保持")) {
                    return false;
                }

            }
            
        } else {
            if ($('#pw_content').combobox('getValue').length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须所属工作内容' });
                return false;
            }
            if ($('#begin_date').val().length <= 0) {
                $.messager.show({ title: '错误提示', msg: '开始时间不能为空' });
                return false;
            }
            if ($('#end_date').val().length <= 0) {
                $.messager.show({ title: '错误提示', msg: '结束时间不能为空' });
                return false;
            }
            if (comptime($('#begin_date').val(), $('#end_date').val()) == 1) {
                $.messager.show({ title: '错误提示', msg: '开始时间必须小于等于结束时间' });
                return false;
            }
            var b = true;
            var m = '';
            $.ajax({
                type: "POST",
                timeout: 6000,
                async: false,
                url: "../Ashx/project.ashx",
                data: {
                    'action': "checkTime",
                    'pc_hsid': $("#pc_hsid").val(),
                    'begin_date': $('#begin_date').val(),
                    'end_date': $('#end_date').val()

                },
                success: function (data) {
                    if (data != "") {

                        m = data;
                        b = false;

                    }
                }

            })
            if (!b) {
                $.messager.show({ title: '错误提示', msg: m });
                return false;
            }
            if ($('#imp_user_tt').datagrid('getRows').length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须选择负责人员' });
                return false;
            }
        }
        $.ajax({
            type: "POST",
            timeout: 6000,
            async: false,
            url: "../Ashx/project.ashx",
            data: {
                'action': action,
                'sid': golde_row.sid,
                'ssid': $('#pc_hsid').val(),
                'imp_content': $('#imp_select_content').val(),
                'name': $('#pw_name').val(),
                'pgroup': $('#pgroup').combobox('getValue'),
                'pw_content': $('#pw_content').combobox('getValue'),
                'begin_date': $('#begin_date').val(),
                'end_date': $('#end_date').val(),
                'pc_remark': $('#pc_remark').val(),
                'addstr': addstr,
                'v1': $('#imp_uid').combobox('getValues').join(',')
            },
            success: function (data) {
                $.messager.show({ title: '提示', msg: (data=="success"?"保存成功":data) });
                if (data == "success") {
//                    alert(row.sid);
//                    $('#tt').treegrid('reload', row.sid);
                                        InitGird();
                    //                    alert(index);

                    //                    var pw_content_val;
                    //                    pw_content_val = $("#pw_content").combobox("getValue");
                    //                    project_content($('#pc_hsid').val());
                    //                    $("#pw_content").combobox("setValue", pw_content_val);
                    //                project_content($('#pc_hsid').val());
                    //                    showSelect($("#imp_select_content").val());
                }
            }
        });

    }
    function imp_dept_tree() {
        $('#imp_dept').combotree({
            url: '../Ashx/Common.ashx?type=dept_tree_open',
            valueField: 'id',
            textField: 'text',
            editable: false,
            onLoadSuccess: function (node, data) {
                $('#imp_dept').combotree('tree').tree('collapseAll');
            },
            onChange: function (newValue, oldValue) {
                //$('#imp_uid').combobox('reload', '../Ashx/Common.ashx?type=dept_users&deptid=' + newValue);
                $.post("../Ashx/Common.ashx", { type: "dept_users", deptid: newValue }, function (data) {
                    imp_push(data);
                });
            }
        });
    }

    function imp_push(data) {
        var array = JSON.parse(data);
        var rows = $('#imp_uid').combobox('getValues');
        var textArr = $('#imp_uid').combobox('getText').split(',');
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
        $('#imp_uid').combobox('loadData', array);
    }

    function imp_push_json(array,data, text) {
        var rows = data.split(',');
        var textArr = text.split(',');
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

        $('#imp_uid').combobox('loadData', array);
        $('#imp_uid').combobox('setValues', rows);
    }

    function imp_user(sid) {
        $('#imp_uid').combobox({
            url: '../Ashx/Common.ashx?type=dept_users&deptid=' + sid,
            valueField: 'UserName',
            textField: 'Name',
            //async: false,
            multiple: true,
            editable: false,
            onChange: function (newValue, oldValue) {
                //$.messager.show({title:'',msg:newValue+":"+oldValue});
                //$('#imp_un').val($('#imp_uid').combobox('getText'));
            },
            onLoadSuccess:function(data){
            },
            onHidePanel: function () {
                var text = $('#imp_uid').combobox('getText');
                var showtext = "";
                var arr = text.split(',');
                for (var i = 0; i < arr.length; i++) {
                    if (arr[i].length > 0) {
                        showtext += arr[i].substr(0, 1) + ",";
                    }
                }
                if (showtext.length > 0) {
                    showtext = showtext.substring(0, showtext.length - 1);
                }
                $('#imp_un').val(showtext);
            }
        });
    }
    function Init_alter(row) {
        $("#pc_remark").val(row.remark);
        $("#pgroup").combobox("setValue", row.group_sid);
        Global_pgroup=row.group_sid;
        $("#pw_name").val(row.name);
        if (row.parent_sid == 0) {
//            alert(row.parent_sid);
            $("#imp_select_content").val(1);
            showSelect(1);
            $('#imp_user_tt').datagrid('loadData', { total: 0, rows: [] });


           
        }
        else {
            $("#imp_select_content").val(2);
            $("#begin_date").val(row.begin_date.Format("yyyy-MM-dd"));
            $("#end_date").val(row.end_date.Format("yyyy-MM-dd"));
            showSelect(2);
            edit_addUser(row.sid);
            edit_auditUser(row.sid);
            $("#pw_content").combobox("setValue", row.parent_sid);
        }
    }
    function edit_auditUser(sid) {
        $.ajax({
            type: "POST",
            timeout: 6000,
            async: false,
            url: "../Ashx/project.ashx",
            data: {
                'action': 'getAuditUser',
                'sid': sid
            },
            success: function (data) {
                //                alert(data);
                
//                        $('#imp_dept').combobox('enable');
//                        $('#imp_uid').combobox('enable');
                   
                
                imp_push_json($('#imp_uid').combobox('getData'), data.split('|')[0], data.split('|')[1]);
                //imp_push_json(data.split('|')[0], data.split('|')[1]);
            }
        })
    }
    function edit_addUser(sid) {
        $('#imp_user_tt').datagrid('options').url = '../Ashx/project.ashx';
        $('#imp_user_tt').datagrid('options').queryParams = { 'action': 'get_imp_all_user', 'sid': sid };
        $('#imp_user_tt').datagrid('reload');
    }

</script>
<div style="width: 650px; height: 360px">
    <form id="pc_ff" action="" class="" method="post">
    <input type="hidden" id="pc_sid" name="pc_sid" value="" />
    <input type="hidden" id="pc_hsid" name="pc_hsid" value="" />
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
        <tr>
            <td align="right" style="width: 130px; background-color: #e1f5fc; height: 25px;">
                内容类型：
            </td>
            <td colspan="3" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <select id="imp_select_content" onchange="selectType();" style="width: 200px">
                    <option value="1">工作内容/空间</option>
                    <option value="2">细目/图纸及索引号</option>
                </select>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 130px; background-color: #e1f5fc; height: 25px;">
                名称：
            </td>
            <td colspan="3" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="pw_name" name="pw_name" value="" style="width: 500px" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 130px; background-color: #e1f5fc; height: 25px;">
                所属工作内容：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="pw_content" name="pw_content" value="" style="width: 200px" />
            </td>
            <td align="right" style="width: 130px; background-color: #e1f5fc; height: 25px;">
                小组：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="pgroup" name="pgroup" value="" style="width: 200px" />
            </td>
        </tr>
        <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                开始日期：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="begin_date" name="begin_date" value="" style="width: 200px"
                    onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" />
            </td>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                结束日期：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="end_date" name="end_date" value="" style="width: 200px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    class="Wdate" />
            </td>
        </tr>
        <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                工作类型：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <select id="p_imp" style="width: 200px;">
                </select>
                <table>
                </table>
            </td>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                工作人员：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <select id="p_imp_user" style="width: 150px;">
                </select><input type="button" id="bt_add" onclick="addUser();" value="添加" />
            </td>
        </tr>
        <tr>
            <td align="right" style="background-color: #e1f5fc;"></td>
            <td colspan="3" style="background-color:White; padding-left: 5px;">
                <table id="imp_user_tt" class="easyui-datagrid" style="width:550px; height: 130px;" data-options="url:'',singleSelect:true,width:540">
                    <thead>
                        <tr>
                            <th data-options="field:'del',align:'center',width:50,formatter: function (value, rowData, rowIndex) {return '<a  href=\'#\' onclick=\'Del('+rowIndex+');\'><img src=\'../images/delete.gif\' /></a>';}">
                                删除
                            </th>
                           
                            <th data-options="field:'wtype',width:150">
                                工作类型
                            </th>
                            
                            <th data-options="field:'wusers',width:180">
                                工作人员
                            </th>
                            <th data-options="field:'implementer',width:150">
                                人员简称
                            </th>
                             <th data-options="field:'imp_sid',width:10,hidden:true">
                                工作类型编号
                            </th>
                            <th data-options="field:'implementer_sid',width:10,hidden:true">
                                工作人员编号
                            </th>
                            <th data-options="field:'psi_sid',width:10,hidden:true">
                                细目编号
                            </th>
                        </tr>
                    </thead>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    审核部门：
                </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="imp_dept" name="imp_dept" value="" style="width:200px"/>
            </td>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    审核人员：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="imp_uid" name="imp_uid" value="" style="width:190px"/>*
            </td>
        </tr>
        <tr>
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                备注：
            </td>
            <td colspan="3" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <textarea id="pc_remark" name="pc_remark" rows="3" cols="10" class="validate[maxSize[100]] "
                    style="width: 95%;"></textarea>
            </td>
        </tr>
    </table>
    </form>
</div>
