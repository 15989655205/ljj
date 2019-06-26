<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="MyProjectPlan_IDE.aspx.cs"
    Inherits="Maticsoft.Web.Project.MyProjectPlan_IDE" %>
<%@ Register TagPrefix="review_ide" TagName="Review_ide" Src="../Controls/Project/Review_IDE.ascx" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">
            
        var si_sid = '<%=dt.Rows[0]["detail_id"].ToString()%>';

        $(function () {
            $('#sub_tt').datagrid({
                url: '../Ashx/MyProjectPlan.ashx',
                loadMsg: '正在努力加载中...',
                queryParams: { "action": "sub_list", "si_sid": si_sid },
                fit: true,
                nowrap: false,
                fitColumns: true,
                singleSelect: true,
                //rownumbers: true,
                toolbar: "#tabtoolbar",
                idField: 'sid',
                columns: [[
                    { title: '', field: 'sid', width: 50, align: 'center', formatter: function (value, row, index) { return index + 1; } },
                    { title: '提交说明', field: 'sumbit_content', width: 200 },
                    { title: '附件', field: 'sumbit_filename', width: 200,
                        formatter: function (value, row, index) {
                            if (value != "") {
                                //return value.replaceAll(new RegExp(' : ', 'g'), '<br/>')+"&nbsp;&nbsp;<a href='/FileUpload"+row.sumbit_filepath+"' target='_blank'>预览</a>";
                                var arr = value.split(':');
                                var arrfid = row.sumbit_file.split(',');
                                var arrfp = row.sumbit_filepath.split('|');
                                var reval = "";
                                for (var i = 0; i < arr.length; i++) {
                                    reval += arr[i] + '&nbsp;&nbsp;<a href="#" class="a" onclick="openView(\'' + arr[i] + '\',\'' + arrfp[i].Trim() + '\',\'' + arrfid[i + 1] + '\')" >预览</a>&nbsp;&nbsp;<a href="#" class="a" style="" onclick="download(\'' + arr[i] + '\',\'' + arrfp[i].Trim() + '\',\'' + arrfid[i + 1].Trim() + '\');">下载</a><br/>';
                                }
                                return reval;
                                //return value.replaceAll(new RegExp(' : ', 'g'), '&nbsp;&nbsp;<a href="/FileUpload'+row.sumbit_filepath+'" target="_blank">预览</a><br/>');
                            }
                            else {
                                return "";
                            }
                        }
                    },
                    { title: '提交人', field: 'sumbit_user', width: 60, align: 'center' },
                    { title: '提交时间', field: 'sumbit_date', width: 130, align: 'center' },
                    { title: '修改人', field: 'update_person', width: 60, align: 'center' },
                    { title: '修改时间', field: 'update_date', width: 130, align: 'center' },
                    { title: '审核结果', field: '审核结果', width: 60, align: 'center',
                        formatter: function (value, row, index) {
                            switch (row.review_results) {
                                case "-1":
                                    switch (row.review_status) {
                                        case "0": return "待审批";
                                    }
                                case "0": return "未完成";
                                case "1":
                                    switch (row.review_status) {
                                        case "0": return "已完成";
                                        case "1": return "<img src='../Images/point/bullet_green.png'/>";
                                        case "2": return "<img src='../Images/point/bullet_yellow.png'/>";
                                        case "3": return "<img src='../Images/point/bullet_orange.png'/>";
                                        case "4": return "<img src='../Images/point/bullet_red.png'/>";
                                        case "5": return "<img src='../Images/point/bullet_error.png'/>";
                                        default: return "";
                                    }
                                default: return "";
                            }
                        },
                        styler: function (value, row, index) {
                            switch (row.review_results) {
                                case "-1":
                                    switch (row.review_status) {
                                        case "0": return "color:blue;";
                                    }
                                case "0": return "color:red;";
                                case "1":
                                    switch (row.review_status) {
                                        case "0": return "color:green;";
                                        case "1": return "";
                                        case "2": return "";
                                        case "3": return "";
                                        case "4": return "";
                                        case "5": return "";
                                        default: return "";
                                    }
                                default: return "";
                            }
                        }
                    },
                    { title: '审核说明', field: '审核说明', width: 200,
                        formatter: function (value, row, rowIndex) {
                            if (row.review_status == "0") {
                                return row.review_content;
                            }
                            else {
                                return row.review_content1;
                            }
                        }
                    },
                    { title: '审核附件', field: '审核附件', width: 200,
                        formatter: function (value, row, rowIndex) {
                            if (row.review_status == "0") {
                                if (row.review_file_name != "") {
                                    //return row.review_file_name.replaceAll(new RegExp(' : ', 'g'), '<br/>');
                                    var arr = row.review_file_name.split(':');
                                    var arrfid = row.review_file_id.split(':');
                                    var arrfp = row.review_file_path.split(':');
                                    var reval = "";
                                    for (var i = 0; i < arr.length; i++) {
                                        reval += arr[i] + '&nbsp;&nbsp;<a href="#" class="a" onclick="openView(\'' + arr[i] + '\',\'' + arrfp[i] + '\',\'' + arrfid[i].replaceAll(new RegExp(',', 'g'), '') + '\')" >预览</a>&nbsp;&nbsp;<a href="#" class="a" style="" onclick="download(\'' + arr[i] + '\',\'' + arrfp[i] + '\',\'' + arrfid[i].replaceAll(new RegExp(',', 'g'), '') + '\');">下载</a><br/>';
                                    }
                                    return reval;
                                }
                                else {
                                    return "";
                                }
                            }
                            else {
                                //return row.review_file_name1.replaceAll(new RegExp(' : ', 'g'), '<br/>');
                                if (row.review_file_name1 != "") {
                                    var arr = row.review_file_name1.split(':');
                                    var arrfid = row.review_file_id1.split(':');
                                    var arrfp = row.review_file_path1.split(':');
                                    var reval = "";
                                    for (var i = 0; i < arr.length; i++) {
                                        reval += arr[i] + '&nbsp;&nbsp;<a href="#" class="a" onclick="openView(\'' + arr[i] + '\',\'' + arrfp[i] + '\',\'' + arrfid[i].replaceAll(new RegExp(',', 'g'), '') + '\')" >预览</a>&nbsp;&nbsp;<a href="#" class="a" style="" onclick="download(\'' + arr[i] + '\',\'' + arrfp[i] + '\',\'' + arrfid[i].replaceAll(new RegExp(',', 'g'), '') + '\');">下载</a><br/>';
                                    }
                                    return reval;
                                }
                                else {
                                    return "";
                                }
                            }
                            //                            var str = "";
                            //                            if (row.review_status2 == '1') {
                            //                                if (row.review_filename1 != "") {
                            //                                    var fids = row.review_file2.split(",")
                            //                                    var fnames = row.review_filename2.split(":")
                            //                                    var fnames = row.review_filepath2.split("|")
                            //                                    for (var i = 0; i < fnames.length; i++) {
                            //                                        // str += "<a href='#' onclick=\"download('"++"')\""
                            //                                    }
                            //                                }
                            //                            }
                            //                            else if (row.review_status1 == '1') {
                            //                            }
                            //                            else if (row.review_status == '1') {
                            //                            }
                            //                            return str;
                        }
                    },
                    { title: '审核人', field: 'lastreviewer', width: 60, align: 'center' },
                    { title: '审核时间', field: 'lastreview_date', width: 130, align: 'center' },
                    { title: '记录', field: 'view', width: 30, align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return '<a href="#" onclick="review_record(\'' + rowData.sid + '\');"><img src="../images/CRF.jpg" /></a>';
                        }
                    }
				]]
            });
            set_record_tt();
        });

        function openView(fileName, Path, ID) {
//            $("#ctl00_ContentPlaceHolder1_hdfile").val(fileName + "|" + Path + "|" + ID);
//            $("#ctl00_ContentPlaceHolder1_btnViewDownload").click();
//            var nw = window.open(url, "big", "top=0, left=0, toolbar=no, menubar=yes, scrollbars=yes, resizable=yes,location=no, status=no,channelmode = yes");
//            try {
//                nw.document.title = "预览";
//            }
//            catch (e) {
            //            }
            //alert();
            $.ajax({
                type: "Post",
                async: false,
                url: "/Ashx/File.ashx?action=fileDownloadCount&fid=" + ID,
                //dataType: "json",
                data: "",
                //cache: true,
                success: function (res) {
                    if (res == 1) {
                        openViewShow('/FileUpload' + Path);
                    }
                    //strVoucherGroupSelect = $(str).html(option).parent().html();
                }
            });
        }

        function openViewShow(url) {
            var nw = window.open(url, "big", "top=0, left=0, toolbar=no, menubar=yes, scrollbars=yes, resizable=yes,location=no, status=no,channelmode = yes");
            try {
                nw.document.title = "预览";
                nw.focus();
            }
            catch (e) {
            }
        }

        function download(fileName, Path, ID) {
            $("#ctl00_ContentPlaceHolder1_hdfile").val(fileName + "|" + Path + "|" + ID);
            $("#ctl00_ContentPlaceHolder1_btnDownload").click();
        }

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
                lock: false,               
                init: function () {
                //set_record_tt(id);
                    $('#record_tt').datagrid('options').url = '../Ashx/MyProjectPlan.ashx';
                    $('#record_tt').datagrid('options').queryParams = { "action": "record_list", "pr_sid": id };
                    $('#record_tt').datagrid('reload');                   
                }
            });
        }

        function set_record_tt() {
            $("#record_tt").datagrid({
                url: "",      
                idField: 'sid',
                fit: true,
                nowrap: false,
                singleSelect: true,                 
                columns: [[
                    { title: "审批类型", field: "reviewed", width: 60, align: "center",
                        formatter: function (value, row, index) {
                            switch (value) {
                                case "1": return "主管审批";
                                case "2": return "总审";
                                default: return "";
                            }
                        }
                    },
                    { title: '审批结果', field: 'review_results', width: 60, align: 'center',
                        formatter: function (value, row, index) {
                            switch (row.review_results) {
                                case "0": return "未完成";
                                case "1":
                                    switch (row.review_status) {
                                        case "0": return "已完成";
                                        case "1": return "<img src='../Images/point/bullet_green.png'/>";
                                        case "2": return "<img src='../Images/point/bullet_yellow.png'/>";
                                        case "3": return "<img src='../Images/point/bullet_orange.png'/>";
                                        case "4": return "<img src='../Images/point/bullet_red.png'/>";
                                        case "5": return "<img src='../Images/point/bullet_error.png'/>";
                                        default: return "";
                                    }
                                default: return "";
                            }
                        },
                        styler: function (value, row, index) {
                            switch (row.review_results) {
                                case "0": return "color:red;";
                                case "1":
                                    switch (row.review_status) {
                                        case "0": return "color:green;";
                                        case "1": return "";
                                        case "2": return "";
                                        case "3": return "";
                                        case "4": return "";
                                        case "5": return "";
                                        default: return "";
                                    }
                                default: return "";
                            }
                        }
                    },
                    { title: '审批意见', field: 'review_content', width: 200, align: 'center' },
                    { title: '未完成原因', field: 'reason', width: 200, align: 'center' },
                    { title: '解决的办法', field: 'solution', width: 200, align: 'center' },
                    { title: '解决的结果', field: 'result', width: 200, align: 'center' },
                    { title: '审批人', field: 'reviewer', width: 60, align: 'center' },
                    { title: '审批时间', field: 'review_date', width: 130, align: 'center' }
			    ]]    
            });
        }

        

        function add() {
            var rows = $('#sub_tt').datagrid('getRows');
            if (rows.length > 0) {
                var msg = "";
                //if (rows.length >= 4) {                    
                //    msg += '提交不能超过4次。<br/>';
                //}
                if (rows[0].review_results == "-1"||(rows[0].review_results=="1"&&rows[0].review_status=="0")) {                   
                    msg += '提交审批完毕之后才能再次提交。<br/>'; 
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
                if (rows[0].review_results != "-1") {
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
        <div id="tabtoolbar" style="padding: 0 2px;height:auto">
            <table style="width:100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
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
                     <td class="TDtitle">细&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;目：</td><td class="TDinput"><%=dt.Rows[0]["detail_name"].ToString()%></td>
                </tr>
                <tr>                   
                    <td class="TDtitle">负&nbsp;&nbsp;责&nbsp;&nbsp;人：</td><td class="TDinput" colspan="3"><%=dt.Rows[0]["names"].ToString()%></td>
                </tr>
                <tr>
                    <td class="TDtitle">开始日期：</td><td class="TDinput"><%=dt.Rows[0]["begin_date"].ToString()%></td>
                    <td class="TDtitle">结束日期：</td><td class="TDinput"><%=dt.Rows[0]["end_date"].ToString()%></td>
                </tr>
                <tr><td colspan="4" style="background-color:#e1f5fc;height:25px;text-align:center;"><strong>提交记录</strong></td></tr>
            </table>
            <toolbar:ToolBar runat="server" IDS="01~^03~^04~^07~"/>
        </div>
        <table id="sub_tt"></table>  
        <div id="detail" style="display:none"><review_ide:Review_ide runat="server"/></div>
        <div id="record" style="display:none;width:480px;height:320px;"><table id="record_tt"></table></div>

        <form id="Form1" runat="server" style="display:none">
        <asp:HiddenField ID="hdfile" runat="server"/>
        <asp:HiddenField ID="hdfid" runat="server"/>
        <asp:Button ID="btnDownload" runat="server" Text="Button" onclick="Button1_Click" /> 
        <asp:Button ID="btnViewDownload" runat="server" Text="Button" onclick="Button2_Click" />           
    </form>
</asp:Content>