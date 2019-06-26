<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="UserDateProject.aspx.cs" Inherits="Maticsoft.Web.Project.UserDateProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../js/themes/default/datagrid1.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    var columns = "<%=trStr %>";
    var data = '<%=data %>';
    $(function () {
        Init();
        GetProject();
        imp_dept_tree();
        imp_user();
        InitGird(data);
    });

    //初始化表格
    function InitGird(mydata) {
        $('#tt').datagrid({
            fit: true,
            singleSelect: true, //单选
            //dataType:'json',
            //fitColumns: true, //列自适应
            idField: 'sid', //标识字段,主键
            columns: eval('(' + columns + ')'),
            onLoadSuccess: function (data) {
                //alert(data);
                if (data.rows.length > 0) {
                //调用mergeCellsByField()合并单元格
                    mergeCellsByField("tt", "name");
                }
            },
            onClickCell: function (rowIndex, field, value) {
            },
            onClickRow: function (rowIndex, rowData) {
            }
        }).datagrid('loadData', eval('(' + mydata + ')'));

    }

    function Init() {
        $('#year').combobox({
            width: 60,
        panelHeight:'auto',
            valueField: 'id',
            textField: 'text',
            data: [{
                id: '2013',
                text: '2013'
            }, {
                id: '2014',
                text: '2014'
            }, {
                id: '2015',
                text: '2015'
            }, {
                id: '2016',
                text: '2016'
            }, {
                id: '2017',
                text: '2017'
            }, {
                id: '2018',
                text: '2018'
            }, {
                id: '2019',
                text: '2019'
            }, {
                id: '2020',
                text: '2020'
            }, {
                id: '2021',
                text: '2021'
            }, {
                id: '2022',
                text: '2022'
            }, {
                id: '2023',
                text: '2023'
            }, {
                id: '2024',
                text: '2024'
            }, {
                id: '2025',
                text: '2025'
            }, {
                id: '2026',
                text: '2026'
            }, {
                id: '2027',
                text: '2027'
            }, {
                id: '2028',
                text: '2029'
            }, {
                id: '2029',
                text: '2029'
            }]
        });
    }

    function GetWeek() {
    }

    function GetProject() {
        $('#<%=project.ClientID %>').combobox({
            url: '../Ashx/projectView.ashx?action=getProject',
            valueField: 'sid',
            textField: 'project_name',
            //panelHeight: "auto",
            //async: false,
            editable: false
        });
    }

    function imp_dept_tree() {
        $('#<%=imp_dept.ClientID %>').combotree({
            url: '../Ashx/Common.ashx?type=dept_tree_open',
            valueField: 'id',
            textField: 'text',
            editable: false,
            onLoadSuccess: function (node, data) {
                $('#<%=imp_dept.ClientID %>').combotree('tree').tree('collapseAll');
                
                $.post("../Ashx/Common.ashx", { type: "dept_users", deptid: $('#<%=imp_dept.ClientID %>').combotree('getValue') }, function (data) {
                    imp_push(data);
                });
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
        var array = JSON.parse(data);
        var rows = [];
        var textArr = [];
        if ($('#<%=hvalue.ClientID %>').val().length > 0) {
            rows = $('#<%=hvalue.ClientID %>').val().split(','); //$('#imp_uid').combobox('getValues');
        }
        if ($('#<%=htxt.ClientID %>').val().length > 0) {
            textArr = $('#<%=htxt.ClientID %>').val().split(','); ; //$('#imp_uid').combobox('getText').split(',');
        }
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

    function imp_user(sid) {
        $('#imp_uid').combobox({
            url: '../Ashx/Common.ashx?type=dept_users&deptid=' + sid,
            valueField: 'UserName',
            textField: 'Name',
            //async: false,
            multiple: true,
            editable: false,
            onChange: function (newValue, oldValue) {
                //$.messager.show({title:'',msg:newValue+":"+oldValue});
                //$('#imp_un').val($('#imp_uid').combobox('getText'));
            },
            onLoadSuccess: function (data) {
                if ($('#<%=hvalue.ClientID %>').val().length > 0) {
                    $('#imp_uid').combobox('setValues', $('#<%=hvalue.ClientID %>').val().split(','))
                }
                //                $.post("../Ashx/Common.ashx", { type: "dept_users", deptid: $('#<%=imp_dept.ClientID %>').combotree('getValue') }, function (data) {
                //                    imp_push(data);
                //                });
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
                    showtext = showtext.substring(0, showtext.length - 1);
                }
                $('#<%=hvalue.ClientID %>').val($('#imp_uid').combobox('getValues'));
                $('#<%=htxt.ClientID %>').val($('#imp_uid').combobox('getText'));
                //$('#imp_un').val(showtext);
            }
        });
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="cc" class="easyui-layout" fit="true" border="false" style="overflow-y: hidden"  scroll="no">
<div region="north" title="" border="false" split="false">
<form id="ff" runat="server">
<div style="padding:10px">
<div>
<%--查询：<select id="year" name="year"></select>年&nbsp;&nbsp;&nbsp;&nbsp;
<select>
<option value="1">1</option>
<option value="2">2</option>
<option value="3">3</option>
<option value="4">4</option>
<option value="5">5</option>
<option value="6">6</option>
<option value="7">7</option>
<option value="8">8</option>
<option value="9">9</option>
<option value="10">10</option>
<option value="10">11</option>
<option value="10">12</option>
</select>月&nbsp;&nbsp;&nbsp;&nbsp;<select></select>周&nbsp;&nbsp;&nbsp;&nbsp;--%>
<asp:HiddenField runat="server" ID="hvalue" />
<asp:HiddenField runat="server" ID="htxt" />
日期范围&nbsp;起<input type="text" id="sDate" name="sDate" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"/>&nbsp;&nbsp;止&nbsp;<input type="text" id="eDate" name="eDate" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"/>&nbsp;&nbsp;项目&nbsp;<input type="text" runat="server" id="project" name="project" value="" style="width:150px"/>&nbsp;&nbsp;部门&nbsp;<input type="text" id="imp_dept" name="imp_dept" runat="server" value="" style="width:150px"/>&nbsp;&nbsp;员工&nbsp;<input type="text" id="imp_uid" name="imp_uid" value="" style="width:190px"/>&nbsp;&nbsp;<asp:Button
    ID="Button1" runat="server" Text="搜索" onclick="Button1_Click" />
</div>

</div>
</form>
</div>     
     <div region="center" title="" border="false">  
     <div class="easyui-panel" data-options="fit:true,border:false">
<%--<table id="tt" class="easyui-datagrid" style="table-layout:fixed"  data-options="url:'../Ashx/Project.ashx',queryParams: { 'action': 'content_view_item', 'pssid': '1' },singleSelect:true,fit:true">--%>
<%--<%=trStr %>--%>
<table id="tt">
</table>
</div>
</div>
</div>

</asp:Content>
