<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentItem_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.Project.ContentItem_IDE" %>
<script type="text/javascript">
    var item_action = "";
    var item_Global_pgroup = "";
    var item_golde_row = [];
    var item_editType = "";
    var item_showType = "";

    $(function () {
        item_getContentForward();
    });

    function item_openDialog(type, pssid, row, title, psid, flag) {
        item_showType = flag;
        var lock = true;
        $('#item_c_pssid').val(pssid);
        if (art.dialog.list['item_dialog'] == null) {
            art.dialog({
                content: document.getElementById('item_edit'),
                id: 'item_dialog',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                lock: lock,
                init: function () {
                    //golde_row = row;
                    if (flag == 1) {
                        $('#tr_group').hide();
                    }
                    item_editType = type;
                    var sid = "";
                    var pcsid = "";
                    if (row != null) {
                        pcsid = row.csid;
                        $('#item_pc_sid').val(pcsid);
                    }
                    switch (type) {
                        case "add":
                            item_action = "pro_contentitem_add";
                            //$('#imp_select_content').attr('disabled', false);
                            document.getElementById("selectContent_tr").style.display = "none";
                            item_project_content(pssid);
                            item_project_implement(pssid);
                            item_project_implement_user('', '');
                            item_headappr_user(psid);
                            item_finalappr_user(psid);
                            break;
                        case "alter":
                            item_action = "pro_contentitem_edit";
                            //document.getElementById("selectContent_tr").style.display = "";
                            //$('#imp_select_content').attr('disabled', true);
                            sid = row.sid;
                            item_project_content(pssid);
                            item_project_implement(pssid);
                            item_project_implement_user('', '');
                            item_headappr_user(psid, row.v1);
                            item_finalappr_user(psid, row.v2);
                            item_Init_alter(row);
                            $('#item_sid').val(sid);
                            break;
                        default:
                            break;
                    }
                    //$('#c_pssid').val(pssid);
                    $("#item_forwardContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageContentItem&sid=' + sid + '&pcsid=' + pcsid + '&pssid=' + pssid);
                    item_edit_addUser(sid);
                    //$("#selectContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageAllContent&pssid=' + pssid);
                },
                close: function () {
                },
                button: [{
                    name: '保存',
                    callback: function () {
                        switch (type) {
                            case "add":
                                item_save();
                                return false;
                                break;
                            case "alter":
                                item_save();
                                //pc_alter(row);
                                return false;
                                break;
                            default:
                                break;
                        }
                    },
                    focus: true
                },
		                {
		                    name: '关闭',
		                    callback: function () {
		                        var rows = $('#item_imp_user_tt').datagrid('getRows');
		                        for (var i = 0; i < rows.length; i++) {
		                            var index = $('#item_imp_user_tt').datagrid('getRowIndex', rows[i]);
		                            $('#item_imp_user_tt').datagrid('deleteRow', index);
		                        }
		                    }
		                }]
            });
        }
        else {
            art.dialog.list['item_dialog'].content(document.getElementById('item_edit'));
        }
    }

    function item_project_content(sid) {
        var bool = false;
        if (item_showType == 1) {
            bool = false;
        } else {
            bool = true;
        }
        $('#item_Content').combobox({
            url: '../Ashx/ProjectContent.ashx?action=project_content_combo&ps_sid=' + sid,
            valueField: 'sid',
            textField: 'name',
            //panelHeight: "auto",
            required: true,
            missingMessage: '必选项',
            editable: false,
            onChange: function (newValue, oldValue) {
                $('#item_pc_sid').val(newValue);
                $("#item_forwardContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageContentItem&sid=' + $('#item_sid').val() + '&pcsid=' + newValue + '&pssid=' + $('#item_c_pssid').val());
            },
            onHidePanel: function () {
            },
            onLoadSuccess: function () {
                if (item_editType == "add") {
                    var row = $("#tt").datagrid("getSelected");
                    if (row != null) {
                        $("#item_Content").combobox("setValue", row.csid);
                    }
                }
            }
        });
    }

    function item_getContentForward() {
        $("#item_forwardContent").combobox({
            //url: '../ashx/project.ashx?action=getStage',
            url: '',
            valueField: 'rowid',
            textField: 'name',
            onLoadSuccess: function () {
                if (item_editType == "add") {
                    var data = $(this).combobox('getData');
                    if (data.length > 0) {
                        $(this).combobox('setValue', data[data.length - 1].rowid);
                    }
                }
                else {
                    try {
                        var rows = $('#tt').datagrid('getRows');
                        var row = rows[pIndex];
                        $(this).combobox('setValue', row.contentSequence);
                    }
                    catch (e) {
                    }
                }
            }
        });
    }

    function item_project_implement(sid) {
        $('#item_p_imp').combobox({
            url: '../Ashx/project.ashx?action=project_implement_combo&ps_sid=' + sid,
            valueField: 'sid',
            textField: 'implement_name',
            panelHeight: "auto",
            editable: false,
            //async: false,
            onChange: function (newValue, oldValue) {
                $.post(
                     "../Ashx/project.ashx?action=get_imp_user&sid=" + newValue,
                    function (data) {
                        if (data == null || data == "") {
                            alert("该工作类型未绑定人员！请到项目设置中绑定人员。");
                        }
                        else {

                            item_project_implement_user(data, newValue);
                        }

                    }
                );
            },
            onHidePanel: function () {
            }
        });
    }

    function item_project_implement_user(sid, pisid) {
        $('#item_p_imp_user').combobox({
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

    function item_headappr_user(psid,data) {
        $('#item_head_appr').combobox({
            url: '../Ashx/projectContent.ashx?action=item_headappr_user_combo&psid=' + psid,
            valueField: 'username',
            textField: 'name',
            multiple: true,
            //async: false,
            panelHeight: "auto",
            editable: false,
            onChange: function (newValue, oldValue) {
            },
            onHidePanel: function () {
            },
            onLoadSuccess: function () {
                if (data != null&&data!="") {
                    $('#item_head_appr').combobox('setValues', data.split(','));
                }
            }
        });
    }

    function item_finalappr_user(psid,data) {
        $('#item_final_appr').combobox({
            url: '../Ashx/projectContent.ashx?action=item_finalappr_user_combo&psid=' + psid,
            valueField: 'username',
            textField: 'name',
            multiple: true,
            //async: false,
            panelHeight: "auto",
            editable: false,
            onChange: function (newValue, oldValue) {
            },
            onHidePanel: function () {
            },
            onLoadSuccess: function () {
                if (data != null && data != "") {
                    $('#item_final_appr').combobox('setValues', data.split(','));
                }
            }
        });
    }

    function item_getContent() {
        $("#item_selectContent").combobox({
            url: '',
            valueField: 'sid',
            textField: 'name',
            onLoadSuccess: function () {
            },
            onChange: function (newValue, oldValue) {
                $.getJSON("../ashx/ProjectContent.ashx", { action: "getContentJson", sid: $(this).combobox('getValue') }, function (json) {
                    alert("JSON Data: ");
                });
            }
        });
    }

    function item_addUser() {
        if ($('#item_p_imp').combobox('getValue').length <= 0 || $('#item_p_imp_user').combobox('getValues').length <= 0) {
            $.messager.show({ title: '错误提示', msg: '必须选择工作种类或者工作人员' });
            return false;
        }
        var arrun = $('#item_p_imp_user').combobox('getText').split(',');
        var uname = "";
        var un = "";
        for (var n = 0; n < arrun.length; n++) {
            uname += arrun[n].split('-')[0] + ",";
            un += arrun[n].split('-')[1] + ",";
        }
        uname = uname.substring(0, uname.length - 1);
        un = un.substring(0, un.length - 1);
        var imp = $('#item_p_imp').combobox('getValue');
        var rows = $('#item_imp_user_tt').datagrid('getRows');
        var add = true;
        for (var i = 0; i < rows.length; i++) {
            if (rows[i].imp_sid == imp) {

                $('#item_imp_user_tt').datagrid('updateRow', {
                    index: i,
                    row: {
                        implementer_sid: $('#item_p_imp_user').combobox('getValues').join(','),
                        wusers: uname,
                        implementer: un
                    }
                });
                add = false;
                break;
            }
        }
        if (add) {
            $('#item_imp_user_tt').datagrid('appendRow', {
                imp_sid: $('#item_p_imp').combobox('getValue'),
                wtype: $('#item_p_imp').combobox('getText'),
                implementer_sid: $('#item_p_imp_user').combobox('getValues').join(','),
                wusers: uname,
                implementer: un
            });
        }
    }

    function item_Del(index) {
        $('#item_imp_user_tt').datagrid('deleteRow', index);
    }

    function item_Init_alter(row) {
        //alert(row.group_sid);
        $("#item_pc_remark").val(row.remark);
        $("#item_Content").combobox("setValue", row.csid);
        $("#item_forwardContent").combobox("setValue", row.itemSequence);
        //Global_pgroup = row.group_sid;
        $("#item_pw_name").val(row.itemName);

        $("#item_begin_date").val(row.begin_date.Format("yyyy-MM-dd"));
        $("#item_end_date").val(row.end_date.Format("yyyy-MM-dd"));
        item_edit_addUser(row.sid);
        //edit_auditUser(row.sid);
    }
    function item_edit_addUser(sid) {
        $('#item_imp_user_tt').datagrid('options').url = '../Ashx/project.ashx';
        $('#item_imp_user_tt').datagrid('options').queryParams = { 'action': 'get_imp_all_user', 'sid': sid };
        $('#item_imp_user_tt').datagrid('reload');
    }

    function item_save() {
        //$.messager.progress({ text: "" });
//        $('#item_pc_ff').form({
//            url: '../Ashx/ProjectContent.ashx?action=' + action,
//            onSubmit: function () {
//                var isValid = $(this).form('validate');
//                if (!isValid) {
//                    $.messager.progress('close'); // hide progress bar while the form is invalid
//                }
//                return isValid; // return false will stop the form submission
//            },
//            success: function (data) {
//                if (data == "success") {
//                    $('#tt').datagrid("reload");
//                    if (item_editType == "alter") {
//                        art.dialog.list['pc_dialog'].close();
//                    }
//                }
//                else {
//                    $.messager.show({ title: '错误提示', msg: data });
//                }
//                $.messager.progress('close');
//            }
//        });
//        // submit the form   
        //        $('#item_pc_ff').submit();

        var delstr = "";
        var updatestr = "";
        var addstr = "";
        var delrows = $('#item_imp_user_tt').datagrid('getChanges', 'deleted');
        delstr = JSON.stringify(delrows);
        var updaterows = $('#item_imp_user_tt').datagrid('getChanges', 'updated');
        updatestr = JSON.stringify(updaterows);
        var addrows = $('#item_imp_user_tt').datagrid('getChanges', 'inserted');
        addstr = JSON.stringify(addrows);
        var allstr = "";
        var allrows = $('#item_imp_user_tt').datagrid('getRows');
        allstr = JSON.stringify(allrows);

        if ($('#item_pw_name').val().length <= 0) {
            $.messager.show({ title: '错误提示', msg: '名称不能为空' });
            return false;
        }

        if ($('#item_Content').combobox('getValue').length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须所属工作内容' });
                return false;
            }
            if ($('#item_begin_date').val().length <= 0) {
                $.messager.show({ title: '错误提示', msg: '开始时间不能为空' });
                return false;
            }
            if ($('#item_end_date').val().length <= 0) {
                $.messager.show({ title: '错误提示', msg: '结束时间不能为空' });
                return false;
            }
            if (comptime($('#item_begin_date').val(), $('#item_end_date').val()) == 1) {
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
                    'pc_hsid': $("#item_c_pssid").val(),
                    'begin_date': $('#item_begin_date').val(),
                    'end_date': $('#item_end_date').val()

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
            if ($('#item_imp_user_tt').datagrid('getRows').length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须选择负责人员' });
                return false;
            }
            if ($('#item_head_appr').combobox('getValues').length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须选择主管审核人员' });
                return false;
            }
            if ($('#item_final_appr').combobox('getValues').length <= 0) {
                $.messager.show({ title: '错误提示', msg: '必须选择总审人员' });
                return false;
            } 
            $.messager.progress({ text: "" });
            $.ajax({
                type: "POST",
                timeout: 6000,
                async: false,
                url: "../Ashx/projectContent.ashx",
                data: {
                    'action': item_action,
                    'sid': $('#item_sid').val(),
                    'parentsid': $('#item_pc_sid').val(),
                    'ssid': $('#item_c_pssid').val(),
                    'name': $('#item_pw_name').val(),
                    'pw_content': $('#item_Content').combobox('getValue'),
                    'begin_date': $('#item_begin_date').val(),
                    'end_date': $('#item_end_date').val(),
                    'pc_remark': $('#item_pc_remark').val(),
                    'allrows': allstr,
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr,
                    'v1': $('#item_head_appr').combobox('getValues').join(','),
                    'v2': $('#item_final_appr').combobox('getValues').join(','),
                    'sequence': $('#item_forwardContent').combobox('getValues').join(',')
                },
                success: function (data) {
                    $.messager.progress('close');
                    $('#tt').datagrid("reload");
                    $.messager.show({ title: '提示', msg: (data=="success"?"保存成功":data) });
                    if (data == "success") {
                        if (item_editType == "add") {
                            //InitGird();
                            //                            var pw_content_val;
                            //                            pw_content_val = $("#item_Content").combobox("getValue");
                            //                            project_content($('#item_pc_sid').val());
                            //                            $("#item_Content").combobox("setValue", pw_content_val);
                            $("#item_forwardContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageContentItem&sid=' + $('#item_sid').val() + '&pcsid=' + $('#item_pc_sid').val() + '&pssid=' + $('#item_c_pssid').val());
                            $('#item_pw_name').val('');
                            //                project_content($('#pc_hsid').val());
                        } else {

                            art.dialog.list['item_dialog'].close();
                        }
                    }
                    else {
                    }
                },
                error: function () {
                    $.messager.progress('close');
                }
            });

    }
</script>
<div style="width: 650px; height: 360px">
    <form id="item_pc_ff" action="" class="" method="post">
    <input type="hidden" id="item_sid" name="item_sid" value="" />
    <input type="hidden" id="item_pc_sid" name="item_pc_sid" value="" />
    <input type="hidden" id="item_c_pssid" name="item_c_pssid" value="" />
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
       <tr id="item_selectContent_tr" style="display:none;">
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                选择要修改<%=showContent %>：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="item_selectContent" name="item_selectContent" value="" style="width: 150px" />*
            </td>
       </tr>
       <tr>
       <td align="right" style="width: 120px;background-color: #e1f5fc; height: 25px;">
                所属工作内容：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="item_Content" name="item_Content" value="" style="width: 180px" />
            </td>
            <td align="right" style="width: 120px;background-color: #e1f5fc; height: 25px;">
                前一<%=showContent %>：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="item_forwardContent" name="item_forwardContent" value="" style="width: 180px" />
            </td>
            
        </tr>
<%--        <tr id="tr_group">
            
        </tr>--%>
        <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                <%=showContent %>：
            </td>
            <td colspan="3" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <%--<input type="text" id="pw_name" name="pw_name" value="" style="width: 200px" />--%>
                <textarea id="item_pw_name" name="item_pw_name" rows="2" cols="10" class="easyui-validatebox" data-options="required:true,missingMessage:'必填'"  style="width: 95%;"></textarea>*
            </td>
        </tr>
       <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                开始日期：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="item_begin_date" name="item_begin_date" value="" style="width: 178px"
                    onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" />
            </td>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                结束日期：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="item_end_date" name="item_end_date" value="" style="width: 178px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                    class="Wdate" />
            </td>
        </tr>
        <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                工作类型：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <select id="item_p_imp" style="width: 180px;">
                </select>
                <table>
                </table>
            </td>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                工作人员：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <select id="item_p_imp_user" style="width: 160px;">
                </select><input type="button" id="item_bt_add" onclick="item_addUser();" value="+" />
            </td>
        </tr>
        <tr>
            <td align="right" style="background-color: #e1f5fc;"></td>
            <td colspan="3" style="background-color:White; padding-left: 5px;">
                <table id="item_imp_user_tt" class="easyui-datagrid" style="width:100%; height: 130px;" data-options="url:'',singleSelect:true,width:500">
                    <thead>
                        <tr>
                            <th data-options="field:'del',align:'center',width:50,formatter: function (value, rowData, rowIndex) {return '<a  href=\'#\' onclick=\'item_Del('+rowIndex+');\'><img src=\'../images/0.png\' /></a>';}">
                                删除
                            </th>
                           
                            <th data-options="field:'wtype',width:120">
                                工作类型
                            </th>
                            
                            <th data-options="field:'wusers',width:180">
                                工作人员
                            </th>
                            <th data-options="field:'implementer',width:120">
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
                    主管审核人：
                </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="item_head_appr" name="item_head_appr" value="" style="width:180px"/>
            </td>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    总审人：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="item_final_appr" name="item_final_appr" value="" style="width:180px"/>
            </td>
        </tr>
        <tr>
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                备注：
            </td>
            <td colspan="3" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <textarea id="item_pc_remark" name="item_pc_remark" rows="2" cols="10" class="validate[maxSize[100]] "
                    style="width: 95%;"></textarea>
            </td>
        </tr>
    </table>
    </form>
</div>