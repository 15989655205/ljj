<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectSubmitRecord.ascx.cs" Inherits="Maticsoft.Web.Controls.Project.ProjectSubmitRecord" %>
    <script src="../js/datagrid-detailview.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () { record_Grid(""); });

    function record_Grid(url) {
        $('#record_tt').datagrid({
            //url: '../Ashx/ProjectAppr.ashx',
            url: url,
            //queryParams: { "action": "record_list", "psi_sid": sid },
            idField: 'sid',
            fit: true,
            singleSelect: true,
            //fitColumns: true,
            columns: [[
			    { title: '提交人', field: 'sumbit_user', width: 60, align: 'center' },
                { title: '提交时间', field: 'sumbit_date', width: 130, align: 'center' },
                { title: '审批结果', field: 'si_sid', width: 60, align: 'center',
                    formatter: function (value, row, index) {
                        switch (row.review_results) {
                            case "-1":
                                switch (row.review_status) {
                                    case "-1": return "未提交";
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
                                    case "-1": return "未提交";
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
                { field: 'lastreviewer', title: '最近审批人', width: 80, align: 'center' },
                { field: 'lastreview_date', title: '最近审批时间', width: 130, align: 'center' }
			]],
            view: detailview,
            detailFormatter: function (index, row) { return '<div style="padding:2px"><table id="ddv-' + index + '"></table></div>'; },
            onExpandRow: function (index, row) {
                $('#ddv-' + index).datagrid({
                    url: '../Ashx/ProjectAppr.ashx',
                    queryParams: { "action": "sub_list", "sid": row.sid },
                    //fitColumns: true,
                    singleSelect: true,
                    nowrap: false,
                    idField: 'sid',
                    height: "auto",
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
					]],
                    onResize: function () {
                        $('#record_tt').datagrid('fixDetailRowHeight', index);
                    },
                    onLoadSuccess: function () {
                        setTimeout(function () { $('#record_tt').datagrid('fixDetailRowHeight', index); }, 0);
                    }
                });
                $('#record_tt').datagrid('fixDetailRowHeight', index);
            }
        });
    }

    function record_openDialog(psi_sid) {       
        if (art.dialog.list['record_dialog'] == null) {
            art.dialog({
                content: document.getElementById('record_edit'),
                id: 'record_dialog',
                title: "提交记录",
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                lock: false,
                init: function () {
                    $('#record_tt').datagrid('options').url = '../Ashx/ProjectAppr.ashx';
                    $('#record_tt').datagrid('options').queryParams = { "action": "record_list", "psi_sid": psi_sid };
                    $('#record_tt').datagrid('reload');
                }
            });
        }
        else {
            art.dialog.list['record_dialog'].content(document.getElementById('record_edit'));
        }
    }

</script>

<div style="width:509px;height:320px;"><table id="record_tt"></table></div>