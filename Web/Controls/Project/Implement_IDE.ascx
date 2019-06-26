<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Implement_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.Project.Implement_IDE" %>
<script type="text/javascript">
    var imp_action = "";
    $(function () {


    });

    function imp_Grid(row) {
        $('#imp_tt').datagrid({
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { "action": "imp_list", "ssid": row.sid },
            idField: 'sid',
            fitColumns: true,
            striped: true, //True 奇偶行使用不同背景色
            singleSelect: true,
            columns: [[
					{ field: 'implement_name', title: '工作类型名称', width: 200 },
					{ field: 'impUserNames', title: '人员', width: 300 },
					{ field: 'implementers', title: '简称', width: 200 },
					{ field: 'remark', title: '备注', width: 200 }
				]],
            onClickRow: function (rowIndex, rowData) {
                $('#imp_name').attr("value", rowData.implement_name);
                $('#imp_remark').attr("value", rowData.remark);
                $('#imp_un').attr("value", rowData.implementers);
                $('#imp_sid').val(rowData.sid);
                //alert($('#imp_uid').combobox('getData'));
                imp_push_json($('#imp_uid').combobox('getData'), rowData.implementers_sid, rowData.impUserNames);
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
        //alert(data);
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

    function imp_push_json(array,data,text) {
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
            multiple: true,
            editable: false,
            onChange: function (newValue, oldValue) {
                //$.messager.show({title:'',msg:newValue+":"+oldValue});
                //$('#imp_un').val($('#imp_uid').combobox('getText'));
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
                    showtext=showtext.substring(0, showtext.length - 1);
                }
                $('#imp_un').val(showtext);
            }
        });
    }

    function imp_openDialog(index, title) {
        var lock = true;
        if (art.dialog.list['imp_dialog'] == null) {
            art.dialog({
                content: document.getElementById('imp_edit'),
                id: 'imp_dialog',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                lock: lock,
                init: function () {
                    var rows = $('#sub_tt').datagrid('getRows');
                    var row = rows[index];
                    $('#imp_hsid').val(row.sid);
                    imp_Grid(row);
                    imp_user("-1");
                    imp_dept_tree();
                    btnCancel();
                    InitCortrol();
                },
                close: function () {
                    imp_action = "";
                }
            });
        }
        else {
            art.dialog.list['imp_dialog'].content(document.getElementById('imp_edit'));
        }
    }

    function InitCortrol() {
        $('#imp_name').attr("value", "");
        $('#imp_remark').attr("value", "");
        $('#imp_un').attr("value", "");
    }

    //快速搜索
    function imp_qsearch(v) {
        $('#imp_tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#imp_tt').datagrid('load');
    }

    function btnSave() {
        $('#imp_add').linkbutton("disable");
        $('#imp_update').linkbutton("disable");
        //$('#imp_del').linkbutton("disable");
        $('#imp_save').linkbutton("enable");
        $('#imp_cancel').linkbutton("enable");
        $('#imp_name').attr("disabled", false);
        $('#imp_remark').attr("disabled", false);
        $('#imp_un').attr("disabled", false);
        $('#imp_dept').combotree("enable");
        $('#imp_uid').combobox("enable");        
    }

    function btnCancel() {
        $('#imp_add').linkbutton("enable");
        $('#imp_update').linkbutton("enable");
        //$('#imp_del').linkbutton("enable");
        $('#imp_save').linkbutton("disable");
        $('#imp_cancel').linkbutton("disable");
        $('#imp_name').attr("disabled", true);
        $('#imp_remark').attr("disabled", true);
        $('#imp_un').attr("disabled", true);
        $('#imp_dept').combotree("disable");
        $('#imp_uid').combobox("disable");        
    }

    function imp_add() {
        imp_action = "imp_add";
        btnSave();
    }

    function imp_update() {
        imp_action = "imp_update";
        btnSave();
    }

    function imp_del() {
        //imp_action = "imp_del";
        //btnSave();

        var selected = "";
        $($('#imp_tt').datagrid('getSelections')).each(function () {
            selected += "'" + this.sid + "',";
        });
        selected = selected.substr(0, selected.length - 1);
        if (selected == "") {
            //$.messager.alert('提示', '请选择要删除的数据！', 'info');
            $.messager.show({ title: '提示', msg: '请选择要删除的数据！' });
            return;
        }
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                $.post('../Ashx/Project.ashx', { "action": "imp_del", "imp_cbx_select": selected }, function (data) {
                    if (data == "success") {
                        $('#imp_tt').datagrid("reload");
                    }
                    else {
                        $.messager.show({ title: '提示', msg: (data=="success"?"保存成功":data) });
                    }
                });
            }
        });
    }

    function imp_save() {
        //btnCancel();

        $('#imp_ff').form('submit', {
            url: '../Ashx/project.ashx?action=' + imp_action,
            onSubmit: function () {
                // 做某些检查   
                // 返回 false 来阻止提交   
                if ($('#imp_name').val().length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "工作类型名称不能为空" });
                }
                if ($('#imp_uid').combobox("getValues").length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "必须要选择人员" });
                }
                if ($('#imp_uid').combobox("getText").split(',').length != $('#imp_un').val().split(',').length) {
                    $.messager.show({ title: '错误提示', msg: "选择人员数与简称人数必须相同！" });
                }
            },
            success: function (data) {
                if (data == "success") {
                    $('#imp_tt').datagrid("reload");
                    //imp_action = "";
                    //art.dialog.list['imp_dialog'].close();
                }
                else {
                    $.messager.show({ title: '错误提示', msg: (data=="success"?"保存成功":data) });
                }
            }
        });
    }    

    function imp_cancel() {
        btnCancel();
    }
</script>
<div style="width:700px; height:500px;">
 <div style="padding:2px;border:1px solid #ddd; background-color:#F4F4F4">
		<a href="#" id="imp_add" onclick="imp_add()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'">新增</a>
		<a href="#" id="imp_update" onclick="imp_update()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-edit'">修改</a>
		<a href="#" id="imp_del" onclick="imp_del()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'">删除</a>
		<a href="#" id="imp_save" onclick="imp_save()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="#" id="imp_cancel" onclick="imp_cancel()" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-undo'">取消</a>
	</div>


<form id="imp_ff" action="" class="" method="post">
<input type="hidden" id="imp_sid" name="imp_sid" value="" />
<input type="hidden" id="imp_hsid" name="imp_hsid" value="" />
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    工作类型名称：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="imp_name" name="imp_name" value="" style="width:400px"/>*
                </td>
                </tr>
                <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    部门：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="imp_dept" name="imp_dept" value="" style="width:400px"/>
                </td>
            </tr>
                <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    人员：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="imp_uid" name="imp_uid" value="" style="width:400px"/>*
                </td>
            </tr>
            <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    人员简称：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="imp_un" name="imp_un" value="" style="width:400px"/>简称顺序必须与上面人员相同
                </td>
            </tr>
            <tr>
                <td align="right" style="background-color: #e1f5fc; height: 25px;">
                    备注(Remark)：
                </td>
                <td colspan="1" style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <textarea id="imp_remark" name="imp_remark" rows="3" cols="10" class="validate[maxSize[100]] " style="width:95%;"></textarea>
                </td>
            </tr>
       </table>
    </form>
<table id="imp_tt"></table>
</div>