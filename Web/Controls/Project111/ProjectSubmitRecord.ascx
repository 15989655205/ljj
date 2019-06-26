<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectSubmitRecord.ascx.cs" Inherits="Maticsoft.Web.Controls.Project111.ProjectSubmitRecord" %>
    <script src="../js/datagrid-detailview.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        record_Grid("");
    });

    function record_Grid(url) {
        $('#record_tt').datagrid({
            //url: '../Ashx/ProjectAppr.ashx', //请求数据的页面
            url: url, //请求数据的页面
            //queryParams: { "action": "record_list", "psi_sid": sid },
            idField: 'sid',
            fit: true,
            striped: true, //True 奇偶行使用不同背景色
            singleSelect: true,
            remoteSort: false,
            fitColumns: true,
            columns: [[
					{ field: 'suser', title: '提交人', halign: 'center', align: 'center', width: 100 }
					, { field: 'sumbit_date', title: '提交时间', halign: 'center', align: 'center', width: 120,
					    formatter: function (value, rowData, rowIndex) {
					        return value.Format("yyyy-MM-dd");
					    }
					}
                    , { field: 'review_results', title: '审批结果', width: 60, formatter: function (value, rowData, rowIndex) {
                        
                        switch (value) {
                            case "1":
                                return "通过";
                                break;
                            case "0":
                                return "不通过";
                                break;
                            default:
                                return "未审批";
                                break;
                        }
                    }
                    }
                    , { field: 'review_status', title: '完成质量', width: 60, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                        switch (value) {
                            case "1":
                                return "<img  width='16px' height='16px' src='../Images/point/bullet_green.png'/>";
                                break;
                            case "2":
                                return "<img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/>";
                                break;
                            case "3":
                                return "<img  width='16px' height='16px' src='../Images/point/bullet_orange.png'/>";
                                break;
                            case "4":
                                return "<img  width='16px' height='16px' src='../Images/point/bullet_red.png'/>";
                                break;
                            default:
                                return "";
                                break;
                        }
                    }
                    }
                    , { field: 'rev', title: '最近审批人', halign: 'center', align: 'center', width: 100 }
                    , { field: 'review_date', title: '最近审批时间', width: 120, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            return value.Format("yyyy-MM-dd");
                        }
                    }
				]],
            view: detailview,
            detailFormatter: function (index, row) {
                return '<div style="padding:2px"><table id="ddv-' + index +
'"></table></div>';
            },
            onExpandRow: function (index, row) {
                $('#ddv-' + index).datagrid({
                    url: '../Ashx/ProjectAppr.ashx',
                    queryParams: { "action": "sub_list", "sid": row.sid },
                    fitColumns: true,
                    singleSelect: true,
                    sortOrder: 'asc',
                    idField: 'sid',
                    height: 'auto',
                    columns: [[
							{ field: 'sid', title: 'sid', width: 100, hidden: true },
                            { field: 'review_results', title: '审批结果', width: 100, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                                //alert(value);
                                switch (value) {
                                    case "1":
                                        return "通过";
                                        break;
                                    case "0":
                                        return "不通过";
                                        break;
                                    default:
                                        return "未审批";
                                        break;
                                }
                            }
                            },
							{ field: 'review_status', title: '完成质量', width: 100, halign: 'center', align: 'center'
                            , formatter: function (value, rowData, rowIndex) {
                                switch (value) {
                                    case "1":
                                        return "<img  width='16px' height='16px' src='../Images/point/bullet_green.png'/>";
                                        break;
                                    case "2":
                                        return "<img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/>";
                                        break;
                                    case "3":
                                        return "<img  width='16px' height='16px' src='../Images/point/bullet_orange.png'/>";
                                        break;
                                    case "4":
                                        return "<img  width='16px' height='16px' src='../Images/point/bullet_red.png'/>";
                                        break;
                                    default:
                                        return "";
                                        break;
                                }
                            }
							},
                            { field: 'review_content', title: '审批意见', width: 100, halign: 'center', align: 'center' },
                            { field: 'rev', title: '审批人', width: 100, halign: 'center', align: 'center' },
                            { field: 'review_date', title: '审批时间', width: 100, halign: 'center', align: 'center',
                                formatter: function (value, rowData, rowIndex) {
                                    return value.Format("yyyy-MM-dd");
                                }
                            }
						]],
                    onResize: function () {
                        $('#record_tt').datagrid('fixDetailRowHeight', index);
                    },
                    onLoadSuccess: function () {
                        setTimeout(function () {
                            $('#record_tt').datagrid('fixDetailRowHeight', index);
                        }, 0);
                    }
                });
                $('#record_tt').datagrid('fixDetailRowHeight', index);
            }
        });
    }

    function record_openDialog(index, title) {
        var lock = true;
        var rows = $('#tt').datagrid('getRows');
        var row = rows[index];
        if (art.dialog.list['record_dialog'] == null) {
            art.dialog({
                content: document.getElementById('record_edit'),
                id: 'record_dialog',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                lock: lock,
                init: function () {
                    //record_Grid(row.detail_id);
                    $('#record_tt').datagrid('options').url = '../Ashx/ProjectAppr.ashx'; 
                    $('#record_tt').datagrid('options').queryParams= { "action": "record_list", "psi_sid": row.detail_id };
                    $('#record_tt').datagrid('reload');
                },
                close: function () {
                }
            });
        }
        else {
            art.dialog.list['record_dialog'].content(document.getElementById('record_edit'));
        }
    }

    //快速搜索
    function record_qsearch(v) {
        $('#record_tt').datagrid('options').queryParams = { "action": "list", "key": v };
        $('#record_tt').datagrid('load');
    }

</script>
<div style="width:600px; height:400px;">
<table id="record_tt"></table>
</div>