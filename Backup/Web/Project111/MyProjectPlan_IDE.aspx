<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="MyProjectPlan_IDE.aspx.cs"
    Inherits="Maticsoft.Web.Project111.MyProjectPlan_IDE" %>
<%@ Register TagPrefix="review_ide" TagName="Review_ide" Src="../Controls/Project/Review_IDE.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
        /*{ title: '审核结果', field: 'review_status', width: 100,
        formatter: function (value, row, index) {
        var str = '';
        switch (value) {
        case "1": str += "<img  width='16px' height='16px' src='../Images/point/bullet_green.png'/>"; break;
        case "2": str += "<img width='16px' height='16px' src='../Images/point/bullet_yellow.png' />"; break;
        case "3": str += "<img width='16px' height='16px' src='../Images/point/bullet_orange.png' />"; break;
        case "4": str += "<img width='16px' height='16px' src='../Images/point/bullet_red.png' />"; break;
        default: break;
        }
        return str;
        }
        },
        { title: '审核状态', field: 'review_results', width: 100,
        formatter: function (value, row, index) {
        var str = '';
        switch (value) {
        case "0": str += "未通过"; break;
        case "1": str += "已通过"; break;
        default: str += "未审核"; break;
        }
        return str;
        }
        },*/
        
        var si_sid = '<%=dt.Rows[0]["detail_id"].ToString()%>';

        $(function () {
            $('#sub_tt').datagrid({
                url: '../Ashx/MyProjectPlan.ashx',
                loadMsg: '正在努力加载中...',
                queryParams: { "action": "sub_list", "si_sid": si_sid },
                fit: true,
                fitColumns: true,
                singleSelect: true,
                //rownumbers: true,
                toolbar: "#tab_toolbar",
                idField: 'sid',
                columns: [[
                    { title: '', field: 'sid', width: 20, align: 'center', formatter: function (value, row, index) { return index + 1; } },
                    { title: '提交说明', field: 'sumbit_content', width: 100 },
                    { title: '附件', field: 'sumbit_filename', width: 100,
                        formatter: function (value, row, index) {
                            if (value != "") {
                                return value.replaceAll(new RegExp(' : ', 'g'), '<br/>');
                            }
                            else {
                                return "";
                            }
                        }
                    },
                    { title: '提交人', field: 'sumbit_user', width: 100 },
                    { title: '提交时间', field: 'sumbit_date', width: 100 },
                    { title: '修改人', field: 'update_person', width: 100 },
                    { title: '修改时间', field: 'update_date', width: 100 },
                    { title: '审核结果', field: 'review_results', width: 100,
                        formatter: function (value, row, rowIndex) {
                            var str = "";
                            if (row.review_status2 == '1') {
                                switch (row.review_results2) {
                                    case "0": str = "<img src='../Images/point/bullet_error.png'/>"; break;
                                    case "1": str = "<img src='../Images/point/bullet_green.png'/>"; break;
                                    case "2": str = "<img src='../Images/point/bullet_yellow.png'/>"; break;
                                    case "3": str = "<img src='../Images/point/bullet_orange.png'/>"; break;
                                    case "4": str = "<img src='../Images/point/bullet_red.png'/>"; break;
                                    default: break;
                                }
                            }
                            else if (row.review_status1 == '1') {
                                switch (row.review_results1) {
                                    case "0": str = "复审未通过"; break;
                                    case "1": str = "复审通过"; break;
                                    default: break;
                                }
                            }
                            else if (row.review_status == '1') {
                                switch (row.review_results) {
                                    case "0": str = "初审未通过"; break;
                                    case "1": str = "初审通过"; break;
                                    default: break;
                                }
                            }
                            return str;
                        },
                        styler: function (value, row, index) {
                            var str = "";
                            if (row.review_status2 == '1') {
                                switch (row.review_results2) {
                                    case "0": str = ""; break;
                                    case "1": str = ""; break;
                                    case "2": str = ""; break;
                                    case "3": str = ""; break;
                                    case "4": str = ""; break;
                                    default: break;
                                }
                            }
                            else if (row.review_status1 == '1') {
                                switch (row.review_results1) {
                                    case "0": str = "color:red;"; break;
                                    case "1": str = "color:green;"; break;
                                    default: break;
                                }
                            }
                            else if (row.review_status == '1') {
                                switch (row.review_results) {
                                    case "0": str = "color:red;"; break;
                                    case "1": str = "color:green;"; break;
                                    default: break;
                                }
                            }
                            return str;
                        }
                    },
                    { title: '审核说明', field: 'review_content', width: 100 },
                    { title: '审核附件', field: 'review_file', width: 100,
                        formatter: function (value, row, rowIndex) {
                            var str = "";
                            if (row.review_status2 == '1') {
                                if (row.review_filename1 != "") {
                                    var fids = row.review_file2.split(",")
                                    var fnames = row.review_filename2.split(":")
                                    var fnames = row.review_filepath2.split("|")
                                    for (var i = 0; i < fnames.length; i++) {
                                        // str += "<a href='#' onclick=\"download('"++"')\""
                                    }
                                }
                            }
                            else if (row.review_status1 == '1') {

                            }
                            else if (row.review_status == '1') {

                            }
                            return str;
                        }
                    },
                    { title: '审核人', field: 'reviewer', width: 100 },
                    { title: '审核时间', field: 'review_date', width: 100 },
                    { title: '记录', field: 'view', width: 30, align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a href="#" onclick="review_record(\'' + rowData.sid + '\');"><img src="../images/CRF.jpg" /></a>';
                        }
                    }
				]]
            });
            set_record_tt();
        });

        function review_record(id) {
            if (art.dialog.get('record_dialog') != null) {
                art.dialog.get('record_dialog').close();
            }            
            art.dialog({
                content: document.getElementById('record'),
                id: 'record_dialog',
                title: "审核记录",
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                width: 500,
                height:300,
                lock: false,
                init: function () {                    
                    $('#record_tt').datagrid('options').url = '../Ashx/MyProjectPlan.ashx';
                    $('#record_tt').datagrid('options').queryParams = { "action": "record_list", "pr_sid": id };
                    $('#record_tt').datagrid('reload');
                },
                button: [{ name: '关闭'}]
            });
        }

        function set_record_tt() {
            $("#record_tt").datagrid({
                url: "",
                //queryParams: { "action": "record_list", "psi_sid": sid },
                idField: "sid",
                fit: true,
                fitColumns: true,
                singleSelect: true,
                columns: [[
					{ title: "审核级别", field: "reviewed", width: 100 },
                    { title: "审核说明", field: "review_content", width: 100 },
                    { title: "审核附件", field: "review_file_name", width: 100 },
                    { title: "审核结果", field: "review_results", width: 100 },
                    { title: "审核人", field: "reviewer", width: 100 },
                    { title: "审核时间", field: "review_date", width: 100 }
				]]               
            });
        }

        

        function add() {
            var rows = $('#sub_tt').datagrid('getRows');
            if (rows.length > 0) {
                var msg = "";
                if (rows.length >= 4) {
                    //$.messager.show({ title: '系统提示', msg: '提交不能超过4次。' });
                    //return;
                    msg += '提交不能超过4次。<br/>';
                }
                if (rows[0].review_results == "") {
                    //$.messager.show({ title: '系统提示', msg: '请等上次提交审核之后再操作。' });
                    //return;
                    msg += '请等上次提交审核之后再操作。<br/>'; 
                }
                if (rows[0].review_results == 1) {
                    //$.messager.show({ title: '系统提示', msg: '已通过审核，无需再次提交。' });
                    //return;
                    msg += '已通过审核，无需再次提交。<br/>';
                }
                if (msg != "") {
                    $.messager.show({ title: '系统提示', msg: msg });
                    return;
                }
            }
            if (art.dialog.get('review_dialog') != null) {
                art.dialog.get('review_dialog').close();
            }
            openDialog("add", "", "新增");
        }

        function edit() {
            var rows = $('#sub_tt').datagrid('getRows');
            if (rows.length > 0) {                
                if (rows[0].review_results != "") {
                    $.messager.show({ title: '系统提示', msg: '已被审核，不能修改。' });
                    return;
                }                
            }
            var row = whether('修改')
            if (row != null) {
                openDialog("edit", row, "修改");
            }
        }

        function view() {
            var row = whether('查看')
            if (row != null) {
                openDialog("view", row, "查看");
            }
        }

        //是否可以复制、编辑、查看
        function whether(value) {
            var row = $('#sub_tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '系统提示', msg: '请选择您要“' + value + '”的数据。' });
            }
            else if (art.dialog.get('review_dialog') != null) {
                art.dialog.get('review_dialog').close();
            }
            return row;
        }

        function del() {
            var row = $('#sub_tt').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: '系统提示', msg: '请选择您要“删除”的数据。' });
                return;
            }
            if (row.review_results != "") {
                $.messager.show({ title: '系统提示', msg: '已被审核，不能删除。' });
                return;
            }
            $.messager.confirm('系统提示', '确认删除？', function (r) {
                if (r) {                    
                    $.post('../Ashx/MyProjectPlan.ashx', { "action": "del", "sid": row.sid }, function (data) {
                        if (data == "ok") {
                            $("#sub_tt").datagrid("reload");
                            $.messager.show({ title: '系统提示', msg: '删除成功。' });
                        }
                        else {
                            $.messager.show({ title: '系统提示', msg: data });
                        }
                    });
                }
            });
        }

    </script>

    <style type="text/css">
        .TDtitle{height:25px;text-align:right;background-color:#e1f5fc;}
        .TDinput{width: 35%;height:25px;text-align:left;background-color: #ffffff;}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height:400px;height:100%;width:100%;">
        <div id="tab_toolbar" style="padding: 0 2px;height:auto">

            <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                <tr><td colspan="4" style="background-color:#e1f5fc;height:25px;text-align:center;"><strong>计划基本属性</strong></td></tr>
                <tr>
                    <td class="TDtitle">项目名称：</td><td class="TDinput"><%=dt.Rows[0]["project_code"].ToString()%></td>
                    <td class="TDtitle">项目编号：</td><td class="TDinput"><%=dt.Rows[0]["project_name"].ToString()%></td>
                </tr>
                <tr>
                    <td class="TDtitle">阶&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;段：</td> <td class="TDinput"><%=dt.Rows[0]["stage_name"].ToString()%></td>
                    <td class="TDtitle">小&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;组：</td><td class="TDinput"><%=dt.Rows[0]["group_name"].ToString()%></td>
                </tr>
                <tr>
                    <td class="TDtitle">工作内容：</td><td class="TDinput"><%=dt.Rows[0]["jobduties_name"].ToString()%></td>
                    <td class="TDtitle">工作种类：</td><td class="TDinput"><%=dt.Rows[0]["implement_name"].ToString()%></td>
                </tr>
                <tr>
                    <td class="TDtitle">细&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;目：</td><td class="TDinput"><%=dt.Rows[0]["detail_name"].ToString()%></td>
                    <td class="TDtitle">同&nbsp;&nbsp;组&nbsp;&nbsp;人：</td><td class="TDinput"><%=dt.Rows[0]["names"].ToString()%></td>
                </tr>
                <tr>
                    <td class="TDtitle">开始日期：</td><td class="TDinput"><%=dt.Rows[0]["begin_date"].ToString()%></td>
                    <td class="TDtitle">结束日期：</td><td class="TDinput"><%=dt.Rows[0]["end_date"].ToString()%></td>
                </tr>
                <tr><td colspan="4" style="background-color:#e1f5fc;height:25px;text-align:center;"><strong>提交记录</strong></td></tr>
            </table>

            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="padding-left: 2px; padding-top:4px; padding-bottom:2px; vertical-align:middle;">
                        <div style="float:left"><a href="#" class="easyui-linkbutton" plain="true" iconCls="icon-file" onclick="add();">新增</a></div>
                        <div style="float:left"><a href="#" class="easyui-linkbutton" plain="true" iconCls="icon-edit" onclick="edit();">修改</a></div>
                        <div style="float:left"><a href="#" class="easyui-linkbutton" plain="true" iconCls="icon-edit" onclick="view();">查看</a></div>
                        <div style="float:left"><a href="#" class="easyui-linkbutton" plain="true" iconCls="icon-no" onclick="del();">删除</a></div>
                    </td>
                </tr>
            </table>
        </div>

        <table id="sub_tt"></table>
    </div>

    <div id="detail" style="display:none"><review_ide:Review_ide runat="server"/></div>

    <div id="record"><table id="record_tt"></table></div>

</asp:Content>