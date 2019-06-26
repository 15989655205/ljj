<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Stage_IDE_zxf.ascx.cs" Inherits="Maticsoft.Web.Controls.Project.Stage_IDE_zxf" %>
<script type="text/javascript">
    var sbUrl = "";
    var isLoad = false;

    $(function () {
        if (!isLoad) {
            isLoad = true;
            initStage();
            
        }

    });
    function initStage() {
        $("#stage_model_tt").datagrid({
            idField: 'sid',
            rownumbers: true,
            singleSelect: false,
            fit: true,
            striped: true,
            height: 200,
            width: 300,
            fitColumns: true,
            columns: [[
                { field: 'ckb', checkbox: true, width: 10 },
                { field: 'stage_name', title: '阶段名称', width: 200 }
            ]],
            onLoadSuccess: function () {
                $("#stage_model_tt").datagrid("unselectAll");
                var rows = $("#sub_tt").datagrid("getRows");
                var rows1 = $("#stage_model_tt").datagrid("getRows");
                var indexs = '';
                for (var i = 0; i < rows.length; i++) {
                    //                    alert(i);
                    //                    alert('1' + rows[i].stage_name);
                    //                    alert('2'+rows1[i].stage_name);
                    for (var j = rows1.length - 1; j >= 0; j--) {

                        if (rows[i].stage_name == rows1[j].stage_name) {
                            //indexs += $("#stage_model_tt").datagrid("getRowIndex", rows1[j]) + ',';
                            index = $("#stage_model_tt").datagrid("getRowIndex", rows1[j]);
                            $("#stage_model_tt").datagrid("deleteRow", index);
                        }
                    }
                }





                //                if (indexs.length > 0) {
                //                    indexs = indexs.substr(0, indexs.length - 1);
                //                    var index = indexs.split(',');
                //                    index.sort(function (a, b) { return a < b ? 1 : -1 });
                //                    for (var a = 0; a < index.length; a++) {
                //                        $("#stage_model_tt").datagrid("deleteRow", index[a]);
                //                        $(this).datagrid('acceptChanges');
                //                    }
                //                    //$(this).datagrid('acceptChanges');
                //                }

            }


        })
    }
    
    function openDialogAdd(type, index, title) {
        var lock = false;
        //resize();
        pIndex = index;
        editType = type;
        switch (type) {
            case "add":
                sbUrl = "../Ashx/project.ashx?action=stage_add_zxf";
                lock = true;
                break;
        }
        if (art.dialog.list['stage_dialog_add'] == null) {
            art.dialog({
                content: document.getElementById('stage_add'),
                id: 'stage_dialog_add',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                //width: 400,
                //height: 200,
                lock: lock,
                init: function () {

                    $("#template_add").combobox({
                        url: '../Ashx/Project.ashx?action=all_template',
                        valueField: 'sid',
                        textField: 'name',
                        onLoadSuccess: function () {
                            if (isLoad) {
                                $('#stage_model_tt').datagrid('loadData', { total: 0, rows: [] });
                            }

                        },
                        onChange: function () {
                            
                            $("#stage_model_tt").datagrid("options").url = '../Ashx/Project.ashx';
                            $('#stage_model_tt').datagrid('options').queryParams = { "action": "stage_model", "sid": $("#template_add").combobox("getValue") };
                            $('#stage_model_tt').datagrid('load');
                        }
                    })
                },
                close: function () {
                }
                ,
                button: [{
                    name: '确定',
                    callback: function () {
                        stage_save1();
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
            art.dialog.list['stage_dialog_add'].content(document.getElementById('stage_add'));
        }
        if (type == 'view') {
            art.dialog.list['stage_dialog_add'].button({ name: '确定', disabled: true });
        }
    }
    function stage_save1() {
        var rows = $('#stage_model_tt').datagrid('getSelections');
        if (rows.length > 0) {
            var selections = '';
            for (var i = 0; i < rows.length; i++) {
                selections +=  rows[i].sid + ',';
            } 
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: "../Ashx/project.ashx?action=stage_add_zxf",
                data: {
                    's_sid': $('#template_add').combobox('getValue'),
                   'selections':selections,
                   'p_sid': $('#hsid').val()
                },
                success: function (data) {
                    if (data == "success") {
                        $('#sub_tt').datagrid("reload");
                        art.dialog.list['stage_dialog_add'].close();
                    }
                    else {
                        $.messager.show({ title: '错误提示', msg: (data == "success" ? "保存成功" : data) });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                }
            });
        }
    }

 
</script>
<div style="width:300px; height:220px">
    <form id="stage_ff" action="">
        <table>
            <tr style="width:300px">
                <td style="width:100px">分类模板:</td>
                <td style="width:200px">
                    <input id="template_add" name="template" type="text" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width:300px; height:180px">
                    <table id="stage_model_tt" class="easyui_class"></table>
                </td>
            </tr>
        </table>
    </form>
</div>