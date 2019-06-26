<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Stage_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.Project111.Stage_IDE" %>
<script type="text/javascript">
    var dlg = art.dialog;
    var lastIndex;
    var sbUrl = "";
    var editType = "";
    var pIndex;
    var isload = true;
    $(function () {
        if (isload) {
            //验证初始化
            //jQuery("#stage_ff").validationEngine({ showOnMouseOver: false, promptPosition: 'topLeft', autoHidePrompt: true, autoHideDelay: 2000 });
            //$("#ff").validationEngine();
            InitCortrol()
            getForward();
            isload = false;
        }
    });

    function InitCortrol() {
        //$('#txtBeginDate').datebox({});
        //$('#txtEndDate').datebox({});
    }

    function openDialog(type, index, title) {
        var lock = false;
        //resize();
        pIndex = index;
        editType = type;
        switch (type) {
            case "add":
                sbUrl = "../Ashx/project.ashx?action=stage_add";
                lock = true;
                ClearControl();
                break;
            case "edit":
                sbUrl = "../Ashx/project.ashx?action=stage_edit";
                lock = true;
                showData(index);
                break;
        }
        if (art.dialog.list['stage_dialog'] == null) {
            art.dialog({
                content: document.getElementById('Edit'),
                id: 'stage_dialog',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                //width: 400,
                //height: 200,
                lock: lock,
                init: function () {
                    var sid = "";
                    if (index != "") {
                        var rows = $('#sub_tt').datagrid('getRows');
                        var row = rows[index];
                        sid = row.sid;
                    }
                    $("#forwardStage").combobox('reload', '../Ashx/Project.ashx?action=getStage&sid=' + sid + '&p_sid=' + $('#hsid').val());
                },
                close: function () {
                }
                ,
                button: [{
                    name: '保存',
                    callback: function () {
                        stage_save();
                        return false;
                    },
                    focus: true
                },
		                {
		                    name: '关闭'
		                }]
            });

        }
        else {
            art.dialog.list['stage_dialog'].content(document.getElementById('Edit'));
        }
        if (type == 'view') {
            art.dialog.list['stage_dialog'].button({ name: '保存', disabled: true });
        }
        //art.dialog.list['stage_dialog'].size(200, 200);

//        if (editType == "add") {
//            var data = $('#forwardStage').combobox('getData');
//            if (data.length > 0) {
//                $('#forwardStage').combobox('setValue', data[data.length - 1].rowid);
//            }
//        }
//        else {
//            var rows = $('#sub_tt').datagrid('getRows');
//            var row = rows[pIndex];
//            $('#forwardStage').combobox('setValue', row.sequence);
//        }
    }

    function getForward() {
        $("#forwardStage").combobox({
            //url: '../ashx/project.ashx?action=getStage',
            url: '',
            valueField: 'rowid',
            textField: 'stage_name',
            onLoadSuccess: function () {
                if (editType == "add") {
                    var data = $(this).combobox('getData');
                    if (data.length > 0) {
                        $(this).combobox('setValue', data[data.length - 1].rowid);
                    }
                }
                else {
                    try {
                        var rows = $('#sub_tt').datagrid('getRows');
                        var row = rows[pIndex];
                        $(this).combobox('setValue', row.sequence);
                    }
                    catch (e) {
                    }
                }
            }
        });
    }

    function showData(index) {
        var rows = $('#sub_tt').datagrid('getRows');
        var row = rows[index];
        $('#txtStageName').val(row.stage_name);
        $('#pssid').val(row.sid);
        //alert(row.begin_date);
        //alert(row.end_date);
        $('#txtBeginDate').val(row.begin_date.Format("yyyy-MM-dd"));
        $('#txtEndDate').val(row.end_date.Format("yyyy-MM-dd"));
        
    }

    function ClearControl() {
        $('#txtStageName').val('');
        //$('#txtBeginDate').val(new Date());
        //$('#txtEndDate').val(new Date());
    }

    function myformatter(date) {
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
    }
    function myparser(s) {
        if (!s) return new Date();
        var ss = (s.split('-'));
        var y = parseInt(ss[0], 10);
        var m = parseInt(ss[1], 10);
        var d = parseInt(ss[2], 10);
        if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
            return new Date(y, m - 1, d);
        } else {
            return new Date();
        }
    }


    function UnlockButton() {
        art.dialog.list['stage_dialog'].button(
            {
                name: '保存',
                disabled: false
            },
            {
                name: '关闭',
                disabled: false
            });
    }

    function LockButton() {
        art.dialog.list['stage_dialog'].button(
            {
                name: '保存',
                disabled: true
            },
            {
                name: '关闭',
                disabled: true
            });
    }

    function stage_save() {
        $('#psid').val($('#hsid').val());
        LockButton();

        $('#stage_ff').form('submit', {
            url: sbUrl,
            onSubmit: function () {
                // 做某些检查   
                // 返回 false 来阻止提交   
                var isValid = $(this).form('validate');
                if (!isValid) {
                    UnlockButton(); // hide progress bar while the form is invalid
                }
                return isValid;
            },
            success: function (data) {
                if (data == "success") {
                    $('#sub_tt').datagrid("reload");
                    art.dialog.list['stage_dialog'].close();
                }
                else {
                    $.messager.show({ title: '错误提示', msg: data });
                    UnlockButton();
                }
            }
        });
    }
    </script>

<div style="width:400px; height:190px;">
 <form id="stage_ff" method="post" action="" >
    <input id="pssid" name="pssid" type="hidden" />
    <input id="psid" name="psid" type="hidden" />
    <input id="txtStageSID" name="txtStageSID" type="hidden" />
    <table class="table">
	
	<tr>
	<td height="25" width="25%" align="right">
		阶段名称：</td>
	<td height="25" width="*" align="left">
    <input id="txtStageName" name="txtStageName" type="text" class="easyui-validatebox" data-options="required:true,missingMessage:'必填'"/>
	</td></tr>
    <tr>
	<td height="25" width="25%" align="right">
		前一阶段：</td>
	<td height="25" width="*" align="left">
    <input id="forwardStage" name="forwardStage" type="text" />
	</td></tr>
	<tr>
	<td height="25" align="right">
		开始日期
	：</td>
	<td height="25" width="*" align="left">
    <input id="txtBeginDate" name="txtBeginDate" type="text" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"/>
	</td></tr>
    <tr>
	<td height="25" align="right">
		结束日期
	：</td>
	<td height="25" width="*" align="left">
    <input id="txtEndDate" name="txtEndDate" type="text" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"/>
	</td></tr>
    <tr>
	<td height="25" align="right">
		备注
	：</td>
	<td height="25" width="*" align="left">
    <textarea id="stage_remark" name="stage_remark" cols="30" rows="3"></textarea>
	</td></tr>
	
</table>
</form>
</div>