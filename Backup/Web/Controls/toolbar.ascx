<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="toolbar.ascx.cs" Inherits="Maticsoft.Web.Controls.toolbar" %>

<div id="tab_toolbar" style="padding: 0 2px;height:auto">
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>  
            <td style="padding-left: 2px; padding-top:4px; padding-bottom:2px; vertical-align:middle; ">

                <div id="tab_div_01" style="float:left; display:none">
                    <a href="#" id="tab_a_01" class="easyui-linkbutton" plain="true" onclick="add()" iconCls="icon-add">新增</a>
                </div>

                <div id="tab_div_02" style="float:left; display:none">
                    <a href="#" id="tab_a_02" class="easyui-linkbutton" plain="true" onclick="copy()" iconCls="icon-copy">复制</a>
                </div>

                <div id="tab_div_03" style="float:left; display:none">
                    <a href="#" id="tab_a_03" class="easyui-linkbutton" plain="true" onclick="edit()" iconCls="icon-edit">编辑</a>
                </div>
                
                <div id="tab_div_04" style="float:left; display:none">
                    <a href="#" id="tab_a_04" class="easyui-linkbutton" plain="true" onclick="view()" iconCls="icon-view">查看</a>
                </div>

                <div id="tab_div_07" style="float:left; display:none">
                   <a href="#" id="tab_a_07" class="easyui-linkbutton" plain="true" onclick="del()" iconCls="icon-remove">删除</a>
                </div>

                <div id="tab_div_20" style="float:left; display:none">
                    <a href="#" id="tab_a_20" class="easyui-linkbutton" plain="true" onclick="MoveRow(-1)" iconCls="icon-up">上移</a>
                </div>

                <div id="tab_div_21" style="float:left; display:none">
                    <a href="#" id="tab_a_21" class="easyui-linkbutton" plain="true" onclick="MoveRow(1)" iconCls="icon-down">下移</a>
                </div>
                
                <div id="tab_div_19" style="float:left; display:none">
                    <div style="float:left;"><a href="#" id="tab_a_19" class="easyui-linkbutton" plain="true" iconCls="icon-user">角色：</a></div>
                    <div style="float:left;"><input id="tab_input_19"/></div>
                </div>
                
                <div id="tab_div_06" style="float:left; display:none">
                    <a href="#" id="tab_a_06" class="easyui-linkbutton" plain="true" onclick="save()" iconCls="icon-save">保存</a>
                </div>

                 <div id="tab_div_05" style="float:left; display:none">
                    <a href="#" id="tab_a_05" class="easyui-linkbutton" plain="true" onclick="cancel()" iconCls="icon-undo">取消</a>
                </div>  
                
                <div id="tab_div_23" style="float:left; display:none">
                    <a href="#" id="tab_a_23" class="easyui-linkbutton" plain="true" onclick="bom()" iconCls="icon-y">BOM</a>
                </div>               

                <div id="tab_div_08" style="float:left; display:none">
                   <a href="#" id="tab_a_08" class="easyui-linkbutton" plain="true" onclick="input()" iconCls="icon-excel">导入</a>
                </div>

                <div id="tab_div_09" style="float:left; display:none">
                   <a href="#" id="tab_a_09" class="easyui-linkbutton" plain="true" onclick="output()" iconCls="icon-excel">导出</a>
                </div>
                 <div id="tab_div_24" style="float:left; display:none">
                   <a href="#" id="tab_a_24" class="easyui-linkbutton" plain="true" onclick="Sumbit()" iconCls="icon-sh">提交</a>
                </div>

                <div id="tab_div_25" style="float:left; display:none">
                   <a href="#" id="tab_a_25" class="easyui-linkbutton" plain="true" onclick="CancelSumbit()" iconCls="icon-sh">撤销提交</a>
                </div>
                <div id="tab_div_10" style="float:left; display:none">
                   <a href="#" id="tab_a_10" class="easyui-linkbutton" plain="true" onclick="sh()" iconCls="icon-sh">审批</a>
                </div>

                <div id="tab_div_11" style="float:left; display:none">
                   <a href="#" id="tab_a_11" class="easyui-linkbutton" plain="true" onclick="qs()" iconCls="icon-sh">撤销审批</a>
                </div>
                <div id="tab_div_26" style="float:left; display:none">
                   <a href="#" id="tab_a_26" class="easyui-linkbutton" plain="true" onclick="Check()" iconCls="icon-sh">校核</a>
                </div>

                <div id="tab_div_27" style="float:left; display:none">
                   <a href="#" id="tab_a_27" class="easyui-linkbutton" plain="true" onclick="CancelCheck()" iconCls="icon-sh">撤销校核</a>
                </div>
                <div id="tab_div_12" style="float:left; display:none">
                   <a href="#" id="tab_a_12" class="easyui-linkbutton" plain="true" onclick="print()" iconCls="icon-print">打印</a>
                </div>

                <div id="tab_div_15" style="float:left; display:none">
                    <a href="#" id="tab_a_15" class="easyui-linkbutton" plain="true" iconCls="icon-file" onclick="addfile();">上传文件</a>
                </div>

                <div id="tab_div_16" style="float:left; display:none">
                    <a href="#" id="tab_a_16" class="easyui-linkbutton" plain="true" iconCls="icon-edit" onclick="editfile();">编辑属性</a>
                </div>

                <div id="tab_div_17" style="float:left; display:none">
                    <a href="#" id="tab_a_17" class="easyui-linkbutton" plain="true" iconCls="icon-view" onclick="viewfile();" >查看属性</a>
                </div>

                <div id="tab_div_18" style="float:left; display:none">
                    <a href="#" id="tab_a_18" class="easyui-linkbutton" plain="true" iconCls="icon-no" onclick="delfile();">删除文件</a>
                </div>

                <div id="tab_div_13" style="float:left; display:none">
                   <a href="#" id="tab_a_13" class="easyui-linkbutton" plain="true" onclick="asearch()" iconCls="icon-find">高级查询</a>
                </div>
                <div id="tab_div_22" style="float:left; display:none">
                    <div style="float:left;"><a href="#" id="tab_a_22" class="easyui-linkbutton" plain="true">分类模板名称：</a></div>
                    <div>
                        <input id="tab_input_22" />
                    </div>
                </div>
                <div id="tab_div_14" style="float:left; display:none">
                    <div style="float:left;"><a href="#" id="tab_a_14" class="easyui-linkbutton" plain="true" iconCls="icon-find">快速查询：</a></div>
                    <div style="float:left;"><input id="tab_input_14" /></div>
                </div>
                

            </td>
        </tr>
    </table>
</div>

<script type="text/javascript">
    var barLoad = false;
    $(function () {
        var value = "<%=jsValue%>";
        if (value != "") {
            var items = value.split('^')
            for (var i = 0; i < items.length; i++) {
                if (items[i] != "") {
                    var item = items[i].split('~');
                    document.getElementById("tab_div_" + item[0]).style.display = "";
                    switch (item[0]) {
                        case "01": break;
                        case "02": break;
                        case "03": break;
                        case "04": break;
                        case "05": break;
                        case "06": break;
                        case "07": break;
                        case "08": break;
                        case "09": break;
                        case "10": break;
                        case "11": break;
                        case "12": break;
                        case "13": break;
                        case "14":
                            $('#tab_input_14').searchbox({ menu: "#search_menu", searcher: function (value, name) { qsearch(value, name); } });
                            break;
                        case "15": break;
                        case "16": break;
                        case "17": break;
                        case "18": break;
                        case "19":
                            $("#tab_input_19").combobox({
                                url: '../Ashx/Common.ashx?type=role_comb',
                                valueField: 'RoleID',
                                textField: 'RoleName',
                                onChange: function (id) {
                                    if (!isNaN(id)) {
                                        $.ajax({
                                            type: "POST",
                                            timeout: 6000,
                                            url: "../Ashx/Permission.ashx",
                                            data: { 'type': 'Role_Page', 'RolseID': id },
                                            success: function (data) { setRolsePage(data); }
                                        })
                                    }
                                }
                            });
                            break;
                        case "20": break;
                        case "22": break;
                        case "24": break;
                        case "25": break;
                        case "26": break;
                        case "27": break;
                        default: break;
                    }
                }
            }
            if (!barLoad) {
                if (function_exists('LoadedBar')) {
                    LoadedBar();
                }
            }
        }
        barLoad = true;
    })

    function function_exists(name){
        return typeof eval('window.' + name) == 'function';
    }
//    function LoadedBar() {
//    };
</script>