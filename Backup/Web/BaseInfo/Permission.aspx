<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Permission" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        var cbids = new Array();
        var allrow = null;

        $(function () {
            document.getElementById("div_tt").innerHTML = "<table id='tt'></table>";
            $('#tt').treegrid({
                url: '../Ashx/Permission.ashx',
                queryParams: { "type": "list", "RolseID": "1" },
                loadMsg: '正在努力加载中...',
                idField: 'MenuID',
                treeField: 'MenuName',
                toolbar: "#tab_toolbar",
                fit: true,
                fitColumns: true,
                rownumbers: true,
                singleSelect: true,
                columns: [[
                    { title: '模块名称', field: 'MenuName', width: 100,
                        formatter: function (value, row) {
                            var str = '' +
                                '<input type="checkbox" id="tt_cb_' + row.MenuID + '" value="' + row.MenuID + '" ' +
                                '   onclick="setValues(this,' + row.MenuID + ',' + cbids.length + ')"/>' +
                                '<label for="tt_cb_' + row.MenuID + '">' + value + '</label>';
                            return str;
                        }
                    },
			        { title: '操作权限', field: 'value', width: 400,
			            formatter: function (value, row) {			                
			                var index = cbids.length;
			                cbids[index] = new Array();
			                cbids[index][0] = 'tt_cb_' + row.MenuID;
			                cbids[index][1] = new Array();
			                cbids[index][2] = row.MenuID;
			                cbids[index][3] = row.PageID;
			                cbids[index][4] = '';
			                cbids[index][5] = row.Cmds;
			                var str = "";
			                if (row.Cmds != "") {
			                    var cmds = row.Cmds.split(',');
			                    var pers = row.PerNames.split(',');
			                    for (var i = 0; i < cmds.length; i++) {
			                        cbids[index][1][cbids[index][1].length] = 'tt_cb_' + row.MenuID + '_' + cmds[i];
			                        str += '' +
                                        '<input type="checkbox" id="tt_cb_' + row.MenuID + '_' + cmds[i] + '" value="' + cmds[i] + '"' +
                                        '   onclick="setValue(this,' + row.MenuID + ',' + index + ')"/>' +
			                            '<label for="tt_cb_' + row.MenuID + '_' + cmds[i] + '">' + pers[i] + '</label>&nbsp;&nbsp;&nbsp;&nbsp;';
			                    }
			                }
			                return str;
			            }
			        }
		        ]]
            });
        });

        function setRolsePage(data) {
            for (var i = 0; i < cbids.length; i++) {
                document.getElementById(cbids[i][0]).checked = false;
                cbids[i][4] = "";
                for (var j = 0; j < cbids[i][1].length; j++) {
                    document.getElementById(cbids[i][1][j]).checked = false;
                }
            }
            if (data != "") {
                var pages = data.split('|');
                for (var i = 0; i < pages.length; i++) {
                    var page = pages[i].split('/');
                    try {
                    document.getElementById(page[0]).checked = true;
                    }
                catch (e) {
                    alert(page[0]);
                }
                    for (var j = 0; j < cbids.length; j++) {
                        if (page[0] == cbids[j][0]) {
                            cbids[j][4] = page[1];
                            break;
                        }
                    }
                    if (page[2] != "") {
                        var pers = page[2].split('~');
                        for (var j = 0; j < pers.length; j++) {
                            try {
                                document.getElementById(pers[j]).checked = true;
                            }
                            catch (e) {
                                alert(page[2]);
                            }
                        }
                    }                   
                }
            }            
        }

        function setValues(cb, idField, index) {
            if (cb.checked) {
                for (var i = index-1; i >= 0; i--) {
                    if (cb.id.indexOf(cbids[i][0]) > -1) {                       
                        document.getElementById(cbids[i][0]).checked = true;
                    }
                }
            }

            for (var i = index; i < cbids.length; i++) {
                if (cbids[i][0].indexOf(cb.id) > -1) {
                    document.getElementById(cbids[i][0]).checked = cb.checked;
                    cbids[i][4] = cb.checked ? ',' + cbids[i][5] + ',' : "";
                    for (var j = 0; j < cbids[i][1].length; j++) {
                        document.getElementById(cbids[i][1][j]).checked = cb.checked;
                    }
                }
            }            
        }

        function setValue(cb, idField, index) {           
            if (cb.checked) {
                cbids[index][4] += cbids[index][4] == "" ? ',' + cb.value + ',' : cb.value + ',';
                for (var i = index; i >= 0; i--) {
                    if (cb.id.indexOf(cbids[i][0]) > -1) {                        
                        document.getElementById(cbids[i][0]).checked = true;
                    }
                }
            }
            else {
                cbids[index][4] = cbids[index][4].replace(',' + cb.value + ',', ',');
            }
        }

        function save() {
            var RolseID = $("#tab_input_19").combobox("getValue")
            if (isNaN(RolseID) || RolseID == "") {
                $.messager.show({ title: '系统提示', msg: '请先选择【角色】。' });
                return;
            }
            var SQLString = '';
            for (var i = 0; i < cbids.length; i++) {
                if (document.getElementById(cbids[i][0]).checked) {
                    SQLString += cbids[i][2] + "~" + cbids[i][3] + "~" + cbids[i][4] + "|";
                }
            }

            $.ajax({
                type: "POST",
                timeout: 6000,
                url: "../Ashx/Permission.ashx",
                data: { 'type': 'sub_per', 'SQLString': SQLString, 'RolseID': RolseID },
                success: function (data) {
                    $.messager.show({ title: '系统提示', msg: (data=="success"?"保存成功":data) });
                }
            })
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <toolbar:ToolBar runat="server" id="toolbar1" PageID="1812"/>

    <div id="div_tt" style="width:100%;height:100%"></div>

</asp:Content>
