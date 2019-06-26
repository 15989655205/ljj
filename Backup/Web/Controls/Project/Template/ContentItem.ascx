<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentItem.ascx.cs" Inherits="Maticsoft.Web.Controls.Project.Template.ContentItem" %>
<script type="text/javascript">
    var item_action = "";
    var item_editType = "";

    $(function () {
        getItemForward();
    });

    function item_openDialog(type, pssid, row, title) {
        var lock = true;
        $('#item_pssid').val(pssid);
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
                    item_editType = type;
                    var sid = "";
                    var pcsid = "";
                    if (row != null) {
                        pcsid = row.csid;
                        sid = row.sid;
                        $('#item_pcsid').val(pcsid);
                        //$('#item_sid').val(sid);
                    }
                    project_content(pssid, true, pcsid);
                   
                    switch (type) {
                        case "add":
                            item_action = "pro_item_add";
                            //$('#imp_select_content').attr('disabled', false);
                            //document.getElementById("selectitem_tr").style.display = "none";
                            var csid = "";
                            //alert(row);
                            //                            if (row != null) {
                            //                                csid = row.csid;
                            //                                sid = row.sid;
                            //                                $('#item_pcsid').val(pcsid);
                            //                                $('#item_sid').val(sid);
                            //                            }
                            //project_content(pssid, true, csid);
                            sid = "";
                            //project_content(pssid, true, pcsid);
                            break;
                        case "alter":
                            item_action = "pro_item_edit";
                            //document.getElementById("selectContent_tr").style.display = "";
                            //$('#imp_select_content').attr('disabled', true);
                            //sid = row.sid;
                            //pcsid = row.csid;
                            //$('#item_pcsid').val(pcsid);
                            //project_content(pssid);
                            //project_content(pssid, true, pcsid);
                            Init_item(row);
                            $('#item_sid').val(sid);
                            break;
                        default:
                            break;
                    }
                    //$('#c_pssid').val(pssid);
                    $("#forwarditem").combobox('reload', '../../Ashx/ProjectStage.ashx?action=getStageContentItem&sid=' + sid + '&pssid=' + pssid + '&pcsid=' + pcsid);
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
		                    name: '关闭'
		                }]
            });
        }
        else {
            art.dialog.list['pc_dialog'].content(document.getElementById('pc_edit'));
        }
    }

    function project_content(pssid,flag,csid) {
        $('#pcontent').combobox({
            url: '../../Ashx/projectStage.ashx?action=project_content_combo&ps_sid=' + pssid,
            valueField: 'sid',
            textField: 'name',
            //panelHeight: "auto",
            required: true,
            missingMessage: '必选项',
            editable: false,
            onLoadSuccess: function () {
                if (flag) {
                    $('#pcontent').combobox('setValue',csid);
                }
            },
            onChange: function (newValue, oldValue) {
                $("#forwarditem").combobox('reload', '../../Ashx/ProjectStage.ashx?action=getStageContentItem&sid=' + $('#item_sid').val() + '&pssid=' + $('#item_pssid').val() + '&pcsid=' + newValue);
            },
            onHidePanel: function () {
            }
        });
    }

    function getItemForward() {
        $("#forwarditem").combobox({
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
//                    try {
//                        var rows = $('#tt').datagrid('getRows');
//                        var row = rows[pIndex];
//                        $(this).combobox('setValue', row.contentSequence);
//                    }
//                    catch (e) {
//                    }
                }
            }
        });
    }

    function Init_item(row) {
        //alert(row.group_sid);
        $("#item_remark").val(row.remark);
        $("#pcontent").combobox("setValue", row.parent_sid);
        $("#forwarditem").combobox("setValue", row.itemSequence);
        //Global_pgroup = row.group_sid;
        $("#item_name").val(row.itemName);
    }

    function item_save() {
//        $.messager.progress({ text: "" });
//        $('#item_ff').form({
//            url: '../../Ashx/projectStage.ashx?action=' + item_action,
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
//                        art.dialog.list['item_dialog'].close();
//                    }
//                    else {
//                        $("#forwarditem").combobox('reload', '../../Ashx/ProjectStage.ashx?action=getStageContentItem&sid=&pssid=' + $('#item_pssid').val() + '&pcsid=' + $('#pcontent').combobox('getValue'));
//                        $('#item_name').val('');
//                    }
//                }
//                else {
//                    $.messager.show({ title: '错误提示', msg: data });
//                }
//                $.messager.progress('close');
//            }
//        });
//        // submit the form   
        //        $('#item_ff').submit();

        var isValid = $("#item_ff").form('validate');
        if (!isValid) {
            return false;
        }
        $.messager.progress({ text: "" });
       
        $.ajax({
            type: "POST",
            timeout: 30000, //超时时间：30秒
            url: '../../Ashx/projectStage.ashx?action=' + item_action,
            data: {
                'item_sid': $('#item_sid').val(),
                'pcontent': $('#pcontent').combobox("getValue"),
                'forwarditem': $('#forwarditem').combobox("getValue"),
                'item_name': $('#item_name').val(),
                'item_remark': $('#item_remark').val(),
                'item_pssid': $('#item_pssid').val()
            },
            success: function (data) {
                if (data == "success") {
                    $('#tt').datagrid("reload");
                    if (item_editType == "alter") {
                        art.dialog.list['item_dialog'].close();
                    }
                    $("#item_name").val('');
                    //$("#forwardContent").combobox('reload', '../../Ashx/ProjectStage.ashx?action=getStageContent&sid=' + sid + '&pssid=' + pssid);
                    $("#forwarditem").combobox('reload', '../../Ashx/ProjectStage.ashx?action=getStageContentItem&sid=' + $('#item_sid').val() + '&pssid=' + $('#item_pssid').val() + '&pcsid=' + $('#item_pcsid').val());
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
    <form id="item_ff" action="" class="" method="post">
    <input type="hidden" id="item_sid" name="item_sid" value="" />
    <input type="hidden" id="item_pssid" name="item_pssid" value="" />
    <input type="hidden" id="item_pcsid" name="item_pcsid" value="" />
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
<%--       <tr id="selectContent_tr" style="display:none;">
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                选择要修改内容：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="selectContent" name="selectContent" value="" style="width: 200px" />*
            </td>
       </tr>--%>
       <tr>
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                所属<%=showContent %>：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="pcontent" name="pcontent" value="" style="width: 200px" />*
            </td>
       </tr>
       <tr>
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                前一<%=showItem %>：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="forwarditem" name="forwarditem" value="" style="width: 200px" />*
            </td>
        </tr>
       
        <tr>
            <td align="right" style="width: 120px; background-color: #e1f5fc; height: 25px;">
                <%=showItem %>：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <%--<input type="text" id="pw_name" name="pw_name" value="" style="width: 200px" />--%>
                <textarea id="item_name" name="item_name" rows="3" cols="10" class="easyui-validatebox" data-options="required:true,missingMessage:'必填'"  style="width: 95%;"></textarea>*
            </td>
        </tr>
       
        <tr>
            <td align="right" style="background-color: #e1f5fc; height: 25px;">
                备注：
            </td>
            <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <textarea id="item_remark" name="item_remark" rows="3" cols="10" class="validate[maxSize[100]] "
                    style="width: 95%;"></textarea>
            </td>
        </tr>
    </table>
    </form>
</div>
