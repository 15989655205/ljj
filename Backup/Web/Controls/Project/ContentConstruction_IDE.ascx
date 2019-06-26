<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentConstruction_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.Project.ContentConstruction_IDE" %>
<script type="text/javascript">
    var content_action = "";
    var Global_pgroup = "";
    var golde_row = [];
    var content_editType = "";
    var showType = "";
    var content_url = "";

    $(function () {
        getContentForward();
        //getContent();
    });

    function pc_openDialog(type, pssid, row, title, flag) {
        showType = flag;
        var lock = true;
        $('#c_pssid').val(pssid);
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
                    //golde_row = row;
                    if (flag == 1) {
                        $('#tr_group').hide();
                    }
                    content_editType = type;
                    var sid = "";

                    switch (type) {
                        case "add":
                            content_action = "pro_content_add";
                            //$('#imp_select_content').attr('disabled', false);
                            content_url = "../Ashx/ProjectContent.ashx?action=pro_content_add";
                            document.getElementById("selectContent_tr").style.display = "none";
                            project_group(pssid);
                            $("#pw_name").val('');
                            break;
                        case "alter":
                            content_action = "pro_content_edit";
                            content_url = "../Ashx/ProjectContent.ashx?action=pro_content_edit";
                            //document.getElementById("selectContent_tr").style.display = "";
                            //$('#imp_select_content').attr('disabled', true);
                            //alert($(row.csid).val());
                            //alert(row.csid);
                            sid = $(row.csid).val();
                            project_group(pssid);
                            Init_alter(row);
                            $('#pc_sid').val(sid);
                            break;
                        default:
                            break;
                    }
                    //$('#c_pssid').val(pssid);
                    $("#forwardContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageContent&sid=' + sid + '&pssid=' + pssid);
                    //$("#selectContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageAllContent&pssid=' + pssid);
                },
                close: function () {
                },
                button: [{
                    name: '保存',
                    callback: function () {
                        switch (type) {
                            case "add":
                                pc_save(content_action);
                                return false;
                                break;
                            case "alter":
                                pc_save(content_action);
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
		                    name: '关闭'
		                }]
            });
        }
        else {
            art.dialog.list['pc_dialog'].content(document.getElementById('pc_edit'));
        }
    }

    function project_group(sid) {
        var bool = false;
        if (showType == 1) {
            bool = false;
        } else {
            bool = true;
        }
        $('#pgroup').combobox({
            url: '../Ashx/ProjectContent.ashx?action=project_group_combo&ps_sid=' + sid,
            valueField: 'sid',
            textField: 'group_name',
            panelHeight: "auto",
            required: bool,
            missingMessage: '必选项',
            editable: false,
            onChange: function (newValue, oldValue) {
            },
            onHidePanel: function () {
            }
        });
    }

    function getContentForward() {
        $("#forwardContent").combobox({
            //url: '../ashx/project.ashx?action=getStage',
            url: '',
            valueField: 'rowid',
            textField: 'name',
            onLoadSuccess: function () {
                if (content_editType == "add") {
                    var data = $(this).combobox('getData');
                    if (data.length > 0) {
                        $(this).combobox('setValue', data[data.length - 1].rowid);
                    }
                }
                else {
                    try {
                        var rows = $('#tt').datagrid('getRows');
                        var row = rows[pIndex];
                        //var id = $("#tt").jqGrid('getGridParam', 'selrow');
                        //var row = jQuery('#tt').jqGrid('getRowData', id);
                        $(this).combobox('setValue', row.contentSequence);
                    }
                    catch (e) {
                    }
                }
            }
        });
    }

    function getContent() {
        $("#selectContent").combobox({
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

    function Init_alter(row) {
        //alert(row.group_sid);
        //$("#pc_remark").val(row.cremark);
        //$("#pgroup").combobox("setValue", row.group_sid);
        $("#forwardContent").combobox("setValue", row.contentSequence);
        //$("#selectContent").combobox("setValue", row.csid);
        //Global_pgroup = row.group_sid;
        $("#pw_name").val(row.contentName);
    }

    function pc_save(myaction) {
        //alert(content_action);
        var isValid = $("#pc_ff").form('validate');
        if (!isValid) {
            return false;
        }
        $.messager.progress({ text: "" });
//        $('#pc_ff').form({
//            url: content_url, //'../Ashx/ProjectContent.ashx?action=' + myaction + "&t=" + new Date().getTime(),
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
//                    if (content_editType == "alter") {
//                        art.dialog.list['pc_dialog'].close();
//                    }
//                    $("#pw_name").val('');
//                }
//                else {
//                    $.messager.show({ title: '错误提示', msg: data });
//                }
//                $.messager.progress('close');
//            }
//        });
//        // submit the form   
        //        $('#pc_ff').submit();
        $.ajax({
            type: "POST",
            timeout: 30000, //超时时间：30秒
            url: content_url,
            data: {
                'forwardContent': $('#forwardContent').combobox("getValue"),
                'pgroup': $('#pgroup').combobox("getValue"),
                "c_pssid": $('#c_pssid').val(),
                'pw_name': $('#pw_name').val(),
                'pc_remark': $('#pc_remark').val(),
                'pc_sid': $('#pc_sid').val()
            },
            success: function (data) {
                if (data == "success") {
                    $('#tt').datagrid("reload");
                    //jQuery("#tt").setGridParam({ url: Url }).trigger("reloadGrid");
                    //jQuery("#tt").setGridParam().trigger("reloadGrid");
                    if (content_editType == "alter") {
                        art.dialog.list['pc_dialog'].close();
                    }
                    $("#pw_name").val('');
                    var sid = $('#pc_sid').val();
                    var pssid = $('#c_pssid').val();
                    $("#forwardContent").combobox('reload', '../Ashx/ProjectContent.ashx?action=getStageContent&sid=' + sid + '&pssid=' + pssid);
                }
                else {
                    $.messager.show({ title: '错误提示', msg: (data=="success"?"保存成功":data) });
                }
                $.messager.progress('close');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
            }
        });

    }
</script>
<div style="width: 400px; height: 200px">
    <form id="pc_ff" action="" class="" method="post">
    <input type="hidden" id="pc_sid" name="pc_sid" value="" />
    <input type="hidden" id="c_pssid" name="c_pssid" value="" />
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
       <tr id="selectContent_tr" style="display:none;">
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                选择要修改<%=showContent %>：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="selectContent" name="selectContent" value="" style="width: 200px" />*
            </td>
       </tr>
       <tr>
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                前一<%=showContent %>：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="forwardContent" name="forwardContent" value="" style="width: 200px" />*
            </td>
        </tr>
        <tr id="tr_group">
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                小组：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="pgroup" name="pgroup" value="" style="width: 200px" />*
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                <%=showContent %>：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <%--<input type="text" id="pw_name" name="pw_name" value="" style="width: 200px" />--%>
                <textarea id="pw_name" name="pw_name" rows="3" cols="10" class="easyui-validatebox" data-options="required:true,missingMessage:'必填'"  style="width: 95%;"></textarea>*
            </td>
        </tr>
       
        <tr>
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                备注：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <textarea id="pc_remark" name="pc_remark" rows="3" cols="10" class="validate[maxSize[100]] "
                    style="width: 95%;"></textarea>
            </td>
        </tr>
    </table>
    </form>
</div>
