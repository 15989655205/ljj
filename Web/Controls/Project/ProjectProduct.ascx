<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectProduct.ascx.cs"
    Inherits="Maticsoft.Web.Controls.Project.ProjectProduct" %>
<%--弹出窗-单个跟踪计划信息--%>



<script type="text/javascript">
    var type;
    var row;
    $(function () {

        //细目
        $('#cc').combobox({
            url: '../Ashx/ProjectProduct.ashx?action=loadPro',
            valueField: 'ID',
            textField: 'pName'

        });



        $('#EndProduct').combobox({
            url: '../Ashx/ProjectTemplateTrack.ashx?action=ProcessCategoryClassCombo',
            valueField: 'sid',
            textField: 'category'
        });





        $('#ds').datagrid({
            width: 800

                 , loadMsg: "正在努力加载中..."
                , pageSize: 20
                , pageList: [10, 20, 30, 40, 50, 100]

                , fitColumns: true
                , remoteSort: true
                , pagination: true
                , rownumbers: true
                , singleSelect: true
            , url: '../../Ashx/ProjectProduct.ashx?action=loadPro&pssid=' + pssid + '',
            columns: [[
        { field: 'productName', title: '产品名称', width: 100 },
        { field: 'productPic', title: '图片', width: 100,
            formatter: function (value, rowData, rowIndex) {
                if (value != '') {
                    return "<a path='/ProductPic/" + value + "' class='preview'><img alt='' height='45px' src='/ProductPic/" + value + "'></a>";
                }
            }
        },
        { field: 'productSize', title: '规格', width: 100 },
        { field: 'paintColor', title: '漆面颜色', width: 100 },
        { field: 'useSpace', title: '应用空间', width: 100 },
        { field: 'unit', title: '单位', width: 100 },
        { field: 'amount', title: '数量', width: 100 }

    ]]
        });
    });

function openDialog(title, row1, type1) {
    type = type1;
    row = row1;
        $('#win').show();
            if (art.dialog.list["dialog"] == null) {
                
                art.dialog({
                    content: document.getElementById("pp"),
                    id: "dialog",
                    title: title,
                    lock: true,
                    
                    padding: "0px 0px 0px 0px",
                    background: "#c3c3c3",
                    close: function () { },
                    button: [
                    { name: "保存", callback: function () { savePP(); return false; }, focus: true },
                    { name: "关闭" }
                ]
                });
            }
            if (type == "edit") {
                Pack(row);
            }
        }

        //填充数据
        function Pack(row) {
            $("#number").val(row.number);
            $("#cc").combobox("setValue", row.productName);
            $("#projectName").val(row.number);
            $("#paintColor").val(row.number);
            $("#useSpace").val(row.number);
            $("#spaceCount").val(row.number);
            $("#install").val(row.number);
            $("#usePart").val(row.number);
            $("#unit").val(row.number);
            $("#amount").val(row.number);
            $("#paintPaletteNumber").val(row.number);
            $("#EndProduct").combobox("setValue", row.EndProduct);  //加工类别
            $("#remark").val(row.number);
            $("#ppiSid").val(row.ppiSid);
            $("#sid").val(row.sid);
            $("#parent_sid").val(row.parent_sid);
            $("#ppSid").val(row.ppSid);
        }


        function savePP() {
            
            var number = $("#number").val();
            var detail = $("#cc").combobox("getValue");
            var projectName = $("#projectName").val();
            var paintColor = $("#paintColor").val();
            var useSpace = $("#useSpace").val();
            var spaceCount = $("#spaceCount").val();
            var install = $("#install").val();
            var usePart = $("#usePart").val();
            var unit = $("#unit").val();
            var amount=$("#amount").val();
            var paintPaletteNumber = $("#paintPaletteNumber").val();
            var EndProduct = $("#EndProduct").combobox("getValue");  //加工类别
            var remark = $("#remark").val();

            var ps_sid = pssid;
            var ppiSid = $("#ppiSid").val();
            var sid = $("#sid").val();
            var parent_sid = $("#parent_sid").val();
            var ppSid = $("#ppSid").val();
     
            if (type == "edit") {
                if ($('#tt').datagrid('getRows').length > 0) {
                    $.messager.confirm('提示', '如果你要更改加工类别已设置好的数据将会丢失，你确认要更改加工类别吗？', function (r) {
                        if (r) {
                            $.ajax({
                                type: 'post',
                                url: '../Ashx/ProjectProduct.ashx?action=' + type + '',
                                data: {
                                    number: number,
                                    projectName: projectName,
                                    detail: detail,
                                    paintColor: paintColor,
                                    useSpace: useSpace,
                                    spaceCount: spaceCount,
                                    install: install,
                                    usePart: usePart,
                                    unit: unit,
                                    amount: amount,
                                    paintPaletteNumber: paintPaletteNumber,
                                    EndProduct: EndProduct,
                                    remark: remark,

                                    ps_sid: ps_sid,
                                    sid: sid,
                                    ppiSid: ppiSid,
                                    parent_sid: parent_sid,
                                    ppSid: ppSid
                                },
                                success: function (res) {
                                    if (res == "success") {
                                        $.messager.show({ title: '提示', msg: "编辑成功！" });
                                        $("#tt").datagrid("reload");
                                    }
                                    else {
                                        $.messager.show({ title: '提示', msg: "编辑失败！"+res });
                                    }
                                }
                            });
                        }
                    });
                }
            }
            else {

                $.ajax({
                    type: 'post',
                    url: '../Ashx/ProjectProduct.ashx?action=' + type + '',
                    data: {
                        number: number,
                        projectName: projectName,
                        detail: detail,
                        paintColor: paintColor,
                        useSpace: useSpace,
                        spaceCount: spaceCount,
                        install: install,
                        usePart: usePart,
                        unit: unit,
                        amount: amount,
                        paintPaletteNumber: paintPaletteNumber,
                        EndProduct: EndProduct,
                        remark: remark,

                        ps_sid: ps_sid,
                        sid: sid,
                        ppiSid: ppiSid,
                        parent_sid: parent_sid,
                        ppSid: ppSid
                    },
                    success: function (res) {
                        if (res == "success") {
                            $.messager.show({ title: '提示', msg: "添加成功！" });
                        }
                        else {
                            $.messager.show({ title: '提示', msg: "添加失败！" + res });
                        }
                    }
                });
            }
        }
     

</script>
<input type="hidden" value="" id="sid" />
        <input type="hidden" value="" id="ppiSid" />
        <input type="hidden" value="" id="parent_sid" />
        <input type="hidden" value="" id="ppSid" />
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    编号：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="number" name="imp_name" value="" style="width:400px"/>*</td>
                </tr>
                <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    细目：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
               <input id="cc" name="d" value="" /> *</td>
            </tr>
                <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    漆面颜色：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="paintColor" name="imp_uid" value="" style="width:400px"/>*</td>
            </tr>
            <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    应用空间：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="useSpace" name="imp_un" value="" style="width:400px"/>*</td>
            </tr>
            <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    应用数量：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="spaceCount" name="imp_un0" value="" style="width:400px"/>*</td>
            </tr>
            <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    安装位置 ：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="install" name="imp_un1" value="" style="width:400px"/>*</td>
            </tr>
            <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    应用部位 ：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="usePart" name="imp_un2" value="" style="width:400px"/>*</td>
            </tr>
            <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                   单位：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="unit" name="imp_un3" value="" style="width:400px"/>*</td>
            </tr>
            <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    数量：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="amount" name="imp_un4" value="" style="width:400px"/>*</td>
            </tr>
            <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                    油漆色板编号：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="paintPaletteNumber" name="imp_un5" value="" style="width:400px"/>*</td>
            </tr>
            <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                   加工类别：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input id="EndProduct" name="dept" value=" "> *</td>
            </tr>
            <tr>
                 <td align="right" style="width: 100px; background-color: #e1f5fc; height: 25px;">
                   备注：
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                <input type="text" id="remark" name="imp_un7" value="" style="width:400px"/></td>
            </tr>

            </table>
    
