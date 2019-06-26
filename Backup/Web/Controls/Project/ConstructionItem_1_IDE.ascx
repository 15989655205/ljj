<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConstructionItem_1_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.Project.ConstructionItem_1_IDE" %>
<link href="../js/SimpleModel/basic.css" rel="stylesheet" type="text/css" />
<script src="../js/SimpleModel/jquery.simplemodal.1.4.4.min.js" type="text/javascript"></script>
<script src="../js/easyui/jquery.combo.js" type="text/javascript"></script>
<script type="text/javascript">
    var citem_action = "";
    var citem_Global_pgroup = "";
    var citem_golde_row = [];
    var citem_editType = "";
    var citem_showType = "";
    var citem_editIndex = undefined;

    $(function () {
        citem_getContentForward();
    });

    function my97date() {
        WdatePicker({ dateFmt: 'yyyy-MM-dd', minDate: sDateStr, maxDate: eDateStr });
    }

    function citem_openDialog(type, pssid, row, title, psid, flag) {
        citem_showType = flag;
        var lock = true;
        $('#citem_c_pssid').val(pssid);
        if (art.dialog.list['citem_dialog'] == null) {
            art.dialog({
                content: document.getElementById('citem_edit'),
                id: 'citem_dialog',
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
                    citem_editType = type;
                    var sid = "";
                    var pcsid = "";
                    if (row != null) {
                        pcsid = row.csid;
                        $('#citem_pc_sid').val(pcsid);
                    }
                    switch (type) {
                        case "add":
                            citem_action = "pro_contentcitem_add";
                            //$('#imp_select_content').attr('disabled', false);
                            //document.getElementById("selectContent_tr").style.display = "none";
                            citem_project_content(pssid);
                            //citem_project_implement(pssid);
                            //citem_project_implement_user('', '');
                            citem_headappr_user(psid);
                            citem_finalappr_user(psid);
                            break;
                        case "alter":
                            citem_action = "pro_contentcitem_edit";
                            //document.getElementById("selectContent_tr").style.display = "";
                            //$('#imp_select_content').attr('disabled', true);
                            sid = row.sid;
                            citem_project_content(pssid);
                            //citem_project_implement(pssid);
                            //citem_project_implement_user('', '');
                            citem_headappr_user(psid, row.v1);
                            citem_finalappr_user(psid, row.v2);
                            citem_Init_alter(row);
                            $('#citem_sid').val(sid);
                            break;
                        default:
                            break;
                    }
                    //$('#c_pssid').val(pssid);
                    $("#citem_forwardContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageContentItem&sid=' + sid + '&pcsid=' + pcsid + '&pssid=' + pssid);
                    citem_edit_addUser(sid);
                    initFTGrid(pssid, sid);
                    //$("#selectContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageAllContent&pssid=' + pssid);
                },
                close: function () {
                    var rows = $('#citem_imp_user_tt').datagrid('getRows');
                    for (var i = 0; i < rows.length; i++) {
                        var index = $('#citem_imp_user_tt').datagrid('getRowIndex', rows[i]);
                        $('#citem_imp_user_tt').datagrid('deleteRow', index);
                    }
                    $('#citem_begin_date').val('');
                    $('#citem_end_date').val('');
                    $('#citem_pw_name').val('');
                },
                button: [{
                    name: '保存',
                    callback: function () {
                        switch (type) {
                            case "add":
                                citem_save();
                                return false;
                                break;
                            case "alter":
                                citem_save();
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

		                    }
		                }]
            });
        }
        else {
            art.dialog.list['citem_dialog'].content(document.getElementById('citem_edit'));
        }
    }

    function openSelectWin() {
        
        $('#imp_box').modal({ zIndex: 9001, maxHeight: 160, maxWidth: 300, minHeight: 100, minWidth: 300, onShow: function () { citem_project_implement($('#citem_c_pssid').val());
        citem_project_implement_user('', '');} });
    }

    function initFTGrid(pssid, psisid) {
        $('#ft').datagrid({
            title: '工作流程日期设置',
            //fit: true,
            nowrap: false, //是否换行，True 就会把数据显示在一行里
            singleSelect: true, //单选
            collapsible: false, //可折叠
            rownumbers: true,
            //toolbar: "#",
            //title:"工作流程日期设置",
            width: 700,
            fitColumns: true, //列自适应
            //url: '../Ashx/ProjectContent.ashx', //请求数据的页面
            queryParams: { "action": "flow_list", "ps_sid": pssid, "psi_sid": psisid },
            idField: 'rowid', //标识字段,主键
            columns: [[
            { title: '删除', field: 'del', align: 'center', width: 30, hidden: true, formatter: function (value, rowData, rowIndex) { if (rowData.s_sid == "" || rowData.s_sid == undefined) return '<a  href=\'#\' onclick=\'citem_flow_del(' + rowIndex + ');\'><img src=\'../images/0.png\' /></a>'; else return ''; } },
                    { title: '流程名称', field: 'fw_name', width: 100, sortable: true, halign: 'center', editor: "text"
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '简称', field: 'abbr', width: 40, sortable: true, halign: 'center', editor: "text"
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            return '<a class="a_black" title="' + value + '"><span class="mlength">' + value + '</span></a>';
                        }
                    },
                    { title: '开始时间', field: 'begin_time', width: 80, sortable: true, halign: 'center', align: 'center', editor: "date"
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            if (value != '' && value != undefined) {
                                return value.Format("yyyy-MM-dd");
                            }
                            else {
                                return '';
                            }
                        }
                    },
                    { title: '结束时间', field: 'end_time', width: 80, sortable: true, halign: 'center', align: 'center', editor: "date"
                        ,
                        formatter: function (value, rowData, rowIndex) {
                            if (value != '' && value != undefined) {
                                return value.Format("yyyy-MM-dd");
                            }
                            else {
                                return '';
                            }
                        }
                    }
                    ]],
//            toolbar: [{
//                iconCls: 'icon-add',
//                handler: function () { citem_flow_add() }
//            }, {
//                iconCls: 'icon-remove',
//                handler: function () {
//                    var row = $('#ft').datagrid('getSelected');
//                    if (row.s_sid == "" || row.s_sid == undefined) {
//                        var index = $('#ft').datagrid('getRowIndex', row);
//                        citem_flow_del(index)
//                    } else {
//                        $.messager.show({ title: '提示', msg: '项目已设置好的流程在这里不能删除<br/>如果不需要开始时间和结束时间可以不填.' });
//                    }
//                }
//            }, {
//                iconCls: 'icon-undo',
//                handler: function () {
//                    $('#ft').datagrid('rejectChanges');
//                    citem_editIndex = undefined;
//                }
//            }, '-', {
//                text: '工作流程日期设置'
//            }],
            onLoadSuccess: function (data) {
//                var rows = $('#ft').datagrid('getRows');
//                if (rows > 0) {
//                    $('#ft').datagrid('updateRow', {
//                        index: 0,
//                        row: {
//                            begin_time: sDateStr
//                        }
//                    });
//                }

            },
            onClickCell: function (rowIndex, field, value) {
            },
            onClickRow: function (rowIndex, rowData) {
                citem_EditRow(rowIndex, rowData.s_sid);
            }
        });
    }

    function datediff(sDate1, sDate2) {
        var arrDate, objDate1, objDate2, intDays;
        arrDate = sDate1.split("/");
        objDate1 = new Date(arrDate[1] + '/' + arrDate[2] + '/' + arrDate[0]);
        arrDate = sDate2.split("/");
        objDate2 = new Date(arrDate[1] + '/' + arrDate[2] + '/' + arrDate[0]);
        intDays = parseInt(Math.abs(objDate1 - objDate2) / 1000 / 60 / 60 / 24);
        return intDays;
    }

    function fetchData() {
        var s = "";
        s = "[[";
        if ($('#citem_begin_date').val().length > 0 && $('#citem_end_date').val().length > 0) {
            var regEx = new RegExp("\\-", "gi");
            var sdatestr = $('#citem_begin_date').val().replace(regEx, "/");
            var sdate = new Date(sdatestr);
            var edatestr = $('#citem_end_date').val().replace(regEx, "/");
            var edate = new Date(edatestr);
            var day = datediff(sdate, edate);
            for (var i; i < day; i++) {
                s = s + "{field:'" + i + "',title:'" + sdate.setDate(sdate.getDay() + i) + "',width:80},";
            }
            s = s.substr(0, s.length - 1);
        }
        s = s + "]]";
        options = {};
        //options.url = '/app/search.do';
        options.queryParams = {
            //nj: nj,
            //unitType: 1
        };
        options.columns = eval(s);
//        //lu 增加一列 
//        options.columns[0].push(
//        {
//            field: 'desc', title: '查看详情', width: 60,
//            formatter: function (value, rec) {
//                return "<a href=\"javascript:showDescInfo(\'" + rec.serial + "\',\'" + rec.scene_score + "\',\'" + rec.total_score + "\');\">详情</a>";
//            }
//        }
//    );

        $('#ft').datagrid(options);
        $('#ft').datagrid('reload');

    } 

    function citem_endEditing() {
        if (citem_editIndex == undefined) { return true }
        if ($('#ft').datagrid('validateRow', citem_editIndex)) {
            $('#ft').datagrid('endEdit', citem_editIndex);
            citem_editIndex = undefined;
            return true;
        } else {
            return false;
        }
    }

    function citem_EditRow(index, ssid) {
        //alert(ssid);
        if (citem_editIndex != index) {
            if (citem_endEditing()) {
                $('#ft').datagrid('selectRow', index).datagrid('beginEdit', index);
                citem_editIndex = index;
                if (ssid != ""&&ssid!=undefined) {
                    var edt = $('#ft').datagrid('getEditors', citem_editIndex);
                    edt[0].target.attr('disabled', true);
                    edt[1].target.attr('disabled', true);
                }
            } else {
                $('#ft').datagrid('selectRow', citem_editIndex);
            }
        }
    }

    function citem_EditGrid(row) {
        var index = $('#ft').datagrid('getRowIndex', row);
        $('#ft').datagrid('beginEdit', index);
        var editors = $('#ft').datagrid('getEditors', index);
        citem_editIndex = index;
    }

    function citem_flow_add() {
        if (citem_endEditing()) {
            $('#ft').datagrid('appendRow', {SN:0}); //, { status: 'P' });
            citem_editIndex = $('#ft').datagrid('getRows').length - 1;
            $('#ft').datagrid('selectRow', citem_editIndex).datagrid('beginEdit', citem_editIndex);
        }
    }

    function citem_flow_del(index) {
        $('#ft').datagrid('deleteRow', index);
    }

    function citem_project_content(sid) {
        var bool = false;
        if (citem_showType == 1) {
            bool = false;
        } else {
            bool = true;
        }
        $('#citem_Content').combobox({
            url: '../Ashx/ProjectContent.ashx?action=project_content_combo&ps_sid=' + sid,
            valueField: 'sid',
            textField: 'name',
            //panelHeight: "auto",
            required: true,
            missingMessage: '必选项',
            editable: false,
            onChange: function (newValue, oldValue) {
                $('#citem_pc_sid').val(newValue);
                $("#citem_forwardContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageContentItem&sid=' + $('#citem_sid').val() + '&pcsid=' + newValue + '&pssid=' + $('#citem_c_pssid').val());
            },
            onHidePanel: function () {
            },
            onLoadSuccess: function () {
                if (citem_editType == "add") {
                    var row = $("#tt").datagrid("getSelected");
                    if (row != null) {
                        $("#citem_Content").combobox("setValue", row.csid);
                    }
                    else {
                        $("#citem_Content").combobox("setValue", "");
                    }
                }
            }
        });
    }

    function citem_getContentForward() {
        $("#citem_forwardContent").combobox({
            //url: '../ashx/project.ashx?action=getStage',
            url: '',
            valueField: 'rowid',
            textField: 'name',
            onLoadSuccess: function () {
                if (citem_editType == "add") {
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

    function citem_project_implement(sid) {
        $('#citem_p_imp').combobox({
            url: '../Ashx/project.ashx?action=project_implement_combo&ps_sid=' + sid,
            valueField: 'sid',
            textField: 'implement_name',
            panelHeight: "auto",
            editable: false,
            //async: false,
            onChange: function (newValue, oldValue) {
                $.ajax({
                    url: "../Ashx/project.ashx?action=get_imp_user&sid=" + newValue,
                    success: function (data) {
                        citem_project_implement_user(data, newValue);
                    }
                });
            },
            onHidePanel: function () {
            }
        });
    }

    function citem_project_implement_user(sid, pisid) {
        $('#citem_p_imp_user').combobox({
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

    function citem_headappr_user(psid, data) {
        $('#citem_head_appr').combobox({
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
                if (data != null && data != "") {
                    $('#citem_head_appr').combobox('setValues', data.split(','));
                }
            }
        });
    }

    function citem_finalappr_user(psid, data) {
        $('#citem_final_appr').combobox({
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
                    $('#citem_final_appr').combobox('setValues', data.split(','));
                }
            }
        });
    }

    function citem_getContent() {
        $("#citem_selectContent").combobox({
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

    function citem_addUser() {
        if ($('#citem_p_imp').combobox('getValue').length <= 0 || $('#citem_p_imp_user').combobox('getValues').length <= 0) {
            $.messager.show({ title: '错误提示', msg: '必须选择工作种类或者工作人员<br/>没有工作人员必须到项目设置里对应阶段设置相关的工作人员。' });
            return false;
        }
        var arrun = $('#citem_p_imp_user').combobox('getText').split(',');
        var uname = "";
        var un = "";
        for (var n = 0; n < arrun.length; n++) {
            uname += arrun[n].split('-')[0] + ",";
            un += arrun[n].split('-')[1] + ",";
        }
        uname = uname.substring(0, uname.length - 1);
        un = un.substring(0, un.length - 1);
        var imp = $('#citem_p_imp').combobox('getValue');
        var rows = $('#citem_imp_user_tt').datagrid('getRows');
        var add = true;
        for (var i = 0; i < rows.length; i++) {
            if (rows[i].imp_sid == imp) {

                $('#citem_imp_user_tt').datagrid('updateRow', {
                    index: i,
                    row: {
                        implementer_sid: $('#citem_p_imp_user').combobox('getValues').join(','),
                        wusers: uname,
                        implementer: un
                    }
                });
                add = false;
                break;
            }
        }
        if (add) {
            $('#citem_imp_user_tt').datagrid('appendRow', {
                imp_sid: $('#citem_p_imp').combobox('getValue'),
                wtype: $('#citem_p_imp').combobox('getText'),
                implementer_sid: $('#citem_p_imp_user').combobox('getValues').join(','),
                wusers: uname,
                implementer: un
            });
        }
    }

    function citem_Del(index) {
        $('#citem_imp_user_tt').datagrid('deleteRow', index);
    }

    function citem_Init_alter(row) {
        //alert(row.group_sid);
        $("#citem_pc_remark").val(row.remark);
        $("#citem_Content").combobox("setValue", row.csid);
        $("#citem_forwardContent").combobox("setValue", row.itemSequence);
        //Global_pgroup = row.group_sid;
        $("#citem_pw_name").val(row.itemName);

        $("#citem_begin_date").val(row.begin_date.Format("yyyy-MM-dd"));
        $("#citem_end_date").val(row.end_date.Format("yyyy-MM-dd"));
        citem_edit_addUser(row.sid);
        //edit_auditUser(row.sid);
    }
    function citem_edit_addUser(sid) {
        $('#citem_imp_user_tt').datagrid('options').url = '../Ashx/project.ashx';
        $('#citem_imp_user_tt').datagrid('options').queryParams = { 'action': 'get_imp_all_user', 'sid': sid };
        $('#citem_imp_user_tt').datagrid('reload');
    }

    function ChangeSDate() {
        var rows = $('#ft').datagrid('getRows');
        if (rows.length > 0) {
            $('#ft').datagrid('updateRow', {
                index: 0,
                row: {
                    begin_time: $('#citem_begin_date').val()
                }
            });
        }
    }

    function ChangeEDate() {
    }

    function citem_save() {
        if (!citem_endEditing()) {
            //return ;
        }
        //$('#ft').datagrid('endEdit', citem_editIndex);
        //var citem_editIndex = undefined;

        var delstr = "";
        var updatestr = "";
        var addstr = "";
        var delrows = $('#ft').datagrid('getChanges', 'deleted');
        delstr = JSON.stringify(delrows);
        var updaterows = $('#ft').datagrid('getChanges', 'updated');
        updatestr = JSON.stringify(updaterows);
        var addrows = $('#ft').datagrid('getChanges', 'inserted');
        addstr = JSON.stringify(addrows);
        var allstr = "";
        var allrows = $('#citem_imp_user_tt').datagrid('getRows');
        allstr = JSON.stringify(allrows);

        var allstr_ft = "";
        var allrows_ft = $('#ft').datagrid('getRows');
        allstr_ft = JSON.stringify(allrows_ft);

        if ($('#citem_pw_name').val().length <= 0) {
            $.messager.show({ title: '错误提示', msg: '名称不能为空' });
            return false;
        }

        if ($('#citem_Content').combobox('getValue').length <= 0) {
            $.messager.show({ title: '错误提示', msg: '必须所属工作内容' });
            return false;
        }
        if ($('#citem_begin_date').val().length <= 0) {
            $.messager.show({ title: '错误提示', msg: '开始时间不能为空' });
            return false;
        }
        if ($('#citem_end_date').val().length <= 0) {
            $.messager.show({ title: '错误提示', msg: '结束时间不能为空' });
            return false;
        }
        if (comptime($('#citem_begin_date').val(), $('#citem_end_date').val()) == 1) {
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
                'pc_hsid': $("#citem_c_pssid").val(),
                'begin_date': $('#citem_begin_date').val(),
                'end_date': $('#citem_end_date').val()

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
        if ($('#citem_imp_user_tt').datagrid('getRows').length <= 0) {
            $.messager.show({ title: '错误提示', msg: '必须选择负责人员' });
            return false;
        }
        if ($('#citem_head_appr').combobox('getValues').length <= 0) {
            $.messager.show({ title: '错误提示', msg: '必须选择主管审核人员' });
            return false;
        }
        if ($('#citem_final_appr').combobox('getValues').length <= 0) {
            $.messager.show({ title: '错误提示', msg: '必须选择总审人员' });
            return false;
        }
        var rows = $('#ft').datagrid('getRows');
        for (var i = 0; i < rows.length; i++) {
            var sTime = rows[i].begin_time
            var eTime = rows[i].end_time
            if (sTime != "" && eTime != "") {
                if (comptime($('#citem_begin_date').val(), sTime) == 1) {
                    $.messager.show({ title: '错误提示', msg: "<" + rows[i].fw_name + ">开始时间不能小于<" + $('#citem_pw_name').val() + ">的开始时间" });
                    return false;
                }
                if (comptime(sTime, $('#citem_end_date').val()) == 1) {
                    $.messager.show({ title: '错误提示', msg: "<" + rows[i].fw_name + ">开始时间不能大于<" + $('#citem_pw_name').val() + ">的结束时间" });
                    return false;
                }
                if (comptime($('#citem_begin_date').val(), eTime) == 1) {
                    $.messager.show({ title: '错误提示', msg: "<" + rows[i].fw_name + ">结束时间不能小于<" + $('#citem_pw_name').val() + ">的开始时间" });
                    return false;
                }
                if (comptime(eTime, $('#citem_end_date').val()) == 1) {
                    $.messager.show({ title: '错误提示', msg: "<" + rows[i].fw_name + ">结束时间不能大于<" + $('#citem_pw_name').val() + ">的结束时间" });
                    return false;
                }
                if (comptime(sTime, eTime) == 1) {
                    $.messager.show({ title: '错误提示', msg: "<" + rows[i].fw_name + ">开始时间不能大于结束时间" });
                    return false;
                }
            }
        }

        $.messager.progress({ text: "" });
        $.ajax({
            type: "POST",
            timeout: 6000,
            async: false,
            url: "../Ashx/projectContent.ashx",
            data: {
                'action': citem_action,
                'sid': $('#citem_sid').val(),
                'parentsid': $('#citem_pc_sid').val(),
                'ssid': $('#citem_c_pssid').val(),
                'name': $('#citem_pw_name').val(),
                'pw_content': $('#citem_Content').combobox('getValue'),
                'begin_date': $('#citem_begin_date').val(),
                'end_date': $('#citem_end_date').val(),
                'pc_remark': $('#citem_pc_remark').val(),
                'allrows': allstr,
                'allrows_ft':allstr_ft,
                //'addstr': addstr,
                //'updatestr': updatestr,
                //'delstr': delstr,
                'v1': $('#citem_head_appr').combobox('getValues').join(','),
                'v2': $('#citem_final_appr').combobox('getValues').join(','),
                'sequence': $('#citem_forwardContent').combobox('getValues').join(',')
            },
            success: function (data) {
                $.messager.progress('close');
                $('#tt').datagrid("reload");
                $.messager.show({ title: '提示', msg: (data=="success"?"保存成功":data) });
                if (data == "success") {
                    if (citem_editType == "add") {
                        //InitGird();
                        //                            var pw_content_val;
                        //                            pw_content_val = $("#citem_Content").combobox("getValue");
                        //                            project_content($('#citem_pc_sid').val());
                        //                            $("#citem_Content").combobox("setValue", pw_content_val);
                        $("#citem_forwardContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageContentItem&sid=' + $('#citem_sid').val() + '&pcsid=' + $('#citem_pc_sid').val() + '&pssid=' + $('#citem_c_pssid').val());
                        $('#citem_pw_name').val('');
                        //                project_content($('#pc_hsid').val());
                    } else {

                        art.dialog.list['citem_dialog'].close();
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
<div style="width: 700px; height: 360px">
    <form id="citem_pc_ff" action="" class="" method="post">
    <input type="hidden" id="citem_sid" name="citem_sid" value="" />
    <input type="hidden" id="citem_pc_sid" name="citem_pc_sid" value="" />
    <input type="hidden" id="citem_c_pssid" name="citem_c_pssid" value="" />
    <div>
    <div style="float:left; width:300px;">
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
       <tr id="citem_selectContent_tr" style="display:none;">
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                选择要修改<%=showContent %>：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="citem_selectContent" name="citem_selectContent" value="" style="width: 150px" />*
            </td>
       </tr>
       <tr>
       <td align="right" style="width: 140px;background-color: #e1f5fc; height: 25px;">
                所属空间：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="citem_Content" name="citem_Content" value="" style="width: 180px" />
            </td>
       </tr>
       <tr>
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                前一内容：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="citem_forwardContent" name="citem_forwardContent" value="" style="width: 180px" />
            </td>
            
        </tr>
        <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                图纸及索引号：
            </td>
            <td colspan="3" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="citem_pw_name" name="citem_pw_name" value="" class="easyui-validatebox" data-options="required:true,missingMessage:'必填'" style="width: 95%;" />
               <%-- <textarea id="citem_pw_name" name="citem_pw_name" rows="2" cols="10" class="easyui-validatebox" data-options="required:true,missingMessage:'必填'"  style="width: 95%;"></textarea>*--%>
            </td>
        </tr>
<%--        <tr id="tr_group">
            
        </tr>--%>
        
       <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                开始日期：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="citem_begin_date" name="citem_begin_date" value="" style="width: 178px"
                    onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd', minDate: sDateStr, maxDate: $('#citem_end_date').val().length>0?$('#citem_end_date').val():eDateStr ,onpicked:function(){fetchData()}});" class="Wdate"" />
            </td>
        </tr>
        <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                结束日期：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="citem_end_date" name="citem_end_date" value="" style="width: 178px" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd', minDate: $('#citem_begin_date').val().length>0?$('#citem_begin_date').val():sDateStr, maxDate: eDateStr ,onpicked:function(){fetchData()}});"
                    class="Wdate" onchange="ChangeEDate()"/>
            </td>
        </tr>
        
         <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    主管审核人：
                </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="citem_head_appr" name="citem_head_appr" value="" style="width:180px"/>
            </td>
        </tr>
        <tr>
            <td align="right" style=" background-color: #e1f5fc; height: 25px;">
                    总审人：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="citem_final_appr" name="citem_final_appr" value="" style="width:180px"/>
            </td>
        </tr>
        <tr>
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                备注：
            </td>
            <td colspan="1" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <textarea id="citem_pc_remark" name="citem_pc_remark" rows="2" cols="10" class="validate[maxSize[100]] "
                    style="width: 95%;"></textarea>
            </td>
        </tr>
    </table>
    </div>
    <div style="float:left; width:350px;">
     <table id="citem_imp_user_tt" class="easyui-datagrid" style="width:100%; height: 225px;" data-options="title:'工作种类入人员设置',url:'',singleSelect:true,width:400,toolbar: [{
                iconCls: 'icon-add',
                handler: function () { openSelectWin(); }
            }]">
                    <thead>
                        <tr>
                            <th data-options="field:'del',align:'center',width:50,formatter: function (value, rowData, rowIndex) {return '<a  href=\'#\' onclick=\'citem_Del('+rowIndex+');\'><img src=\'../images/0.png\' /></a>';}">
                                删除
                            </th>
                           
                            <th data-options="field:'wtype',width:150">
                                工作类型
                            </th>
                            
                            <th data-options="field:'wusers',width:200">
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
    
    </div>
    </div>
    <div>
   <table id="ft" style="width:100%;" ></table>
    </div>

    <div id="imp_box" style="z-index:9999; display:none ">
<div style="padding:5px">工作类型：<input type="text" id="citem_p_imp" name="citem_p_imp" value="" style="width:200px; z-index:99999"/><br /></div>
<div style="padding:5px">工作人员：<input type="text" id="citem_p_imp_user" name="citem_p_imp_user" value="" style="width:200px"/><br /></div>
<div style="padding:5px; text-align:center">
<button id="imp_select_bt" onclick="citem_addUser();">确定</button>
</div>
</div>
    </form>
</div>
