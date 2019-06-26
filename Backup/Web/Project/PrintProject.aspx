<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintProject.aspx.cs" Inherits="Maticsoft.Web.Project.PrintProject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
   <style type="text/css" media="print">  
.noprint{display : none }  
* {
    padding:0px;
    margin:0px;
}
/*html, body {
    width:100%;
    height:100%;
    border:solid 1px black;
}*/
</style>
    <link href="../css/default.css" rel="stylesheet" type="text/css"/>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="../js/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../js/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../js/outlook2.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        _w_table_lefttitle_rowspan("#tbl", 2, 10);
    });
    //函数说明：合并指定表格（表格id为_w_table_id）指定列（行数大于_w_table_mincolnum 小于_w_table_maxcolnum）相同列中的相同文本的相邻单元格
    //          多于一列时，后一列的单元格合并范围不能超过前一列的合并范围。避免出现交错。
    //参数说明：_w_table_id 为需要进行合并单元格的表格id。如在HTMl中指定表格 id="data" ，此参数应为 #data 
    //参数说明：_w_table_mincolnum 为需要进行比较合并的起始列数。为数字，则从最左边第一行为1开始算起。
    //          此参数可以为空，为空则第一列为起始列。
    //          需要注意，如果第一列为序号列，则需要排除此列。
    //参数说明：_w_table_maxcolnum 为需要进行比较合并的最大列数，列数大于这个数值的单元格将不进行比较合并。
    //          为数字，从最左边第一列为1开始算起。
    //          此参数可以为空，为空则同_w_table_mincolnum。
    function _w_table_lefttitle_rowspan(_w_table_id, _w_table_mincolnum, _w_table_maxcolnum) {
        if (_w_table_mincolnum == void 0) { _w_table_mincolnum = 1; }
        if (_w_table_maxcolnum == void 0) { _w_table_maxcolnum = _w_table_mincolnum; }
        if (_w_table_mincolnum > _w_table_maxcolnum) {
            return "";
        } else {
            var _w_table_splitrow = new Array();
            for (iLoop = _w_table_mincolnum; iLoop <= _w_table_maxcolnum; iLoop++) {
                _w_table_onerowspan(iLoop);
            }
        }

        function _w_table_onerowspan(_w_table_colnum) {
            _w_table_firstrow = 0; //前一列合并区块第一行
            _w_table_SpanNum = 0; //合并单元格时的，单元格Span个数
            _w_table_splitNum = 0; //数组的_w_table_splitrow的当前元素下标
            _w_table_Obj = $(_w_table_id + " tr td:nth-child(" + _w_table_colnum + ")");
            _w_table_curcol_rownum = _w_table_Obj.length - 1; //此列最后一行行数
            if (_w_table_splitrow.length == 0) { _w_table_splitrow[0] = _w_table_curcol_rownum; }
            _w_table_lastrow = _w_table_splitrow[0]; //前一列合并区块最后一行
            var _w_table_firsttd;
            var _w_table_currenttd;
            var _w_table_curcol_splitrow = new Array();
            _w_table_Obj.each(function (i) {
                if (i == _w_table_firstrow) {
                    _w_table_firsttd = $(this);
                    _w_table_SpanNum = 1;
                } else {
                    _w_table_currenttd = $(this);
                    if (_w_table_firsttd.text() == _w_table_currenttd.text()) {
                        _w_table_SpanNum++;
                        _w_table_currenttd.hide(); //remove();
                        _w_table_firsttd.attr("rowSpan", _w_table_SpanNum);
                    } else {
                        _w_table_firsttd = $(this);
                        _w_table_SpanNum = 1;
                        setTableRow(i - 1);
                    }
                    if (i == _w_table_lastrow) { setTableRow(i); }
                }
                function setTableRow(_splitrownum) {
                    if (_w_table_lastrow <= _splitrownum && _w_table_splitNum++ < _w_table_splitrow.length) {
                        //_w_table_firstrow=_w_table_lastrow+1;
                        _w_table_lastrow = _w_table_splitrow[_w_table_splitNum];
                    }
                    _w_table_curcol_splitrow[_w_table_curcol_splitrow.length] = _splitrownum;
                    if (i < _w_table_curcol_rownum) { _w_table_firstrow = _splitrownum + 1; }
                }
            });
            _w_table_splitrow = _w_table_curcol_splitrow;
        }
    }
</script>

</head>
<body>
    <form id="form1" runat="server">
  
        <%--<a id="btnPrint" class="easyui-linkbutton" data-options="iconCls:'icon-print'" target="_blank" onclick="javascript:window.print();" /> 打印 </a>--%>
    <div id="h" align="center" class="noprint">
    <input onclick="javascript:window.print();" type="button" value="打印" />
    <%--<input onclick="javascript:window.close();" type="button" value="关闭" />--%>
    <input onclick="javascript:window.open('','_self','');window.close();" type="button" value="关闭" />
</div>

 
<div style="margin:0px; height:100%;">
<%--<input id="btnPrint" type="button" value="打印预览" onclick=preview(1) />  --%>
    <table border="0" class="printtable" cellpadding="0" cellspacing="0" style="width:420mm;height:100%; border-collapse: collapse;border:1px solid #000000;  border:2px solid #000000 !important;   " >
            <tr >
                <td align="right" colspan="2" style="height: 25px; text-align: center; font-size:larger;background-color: #ffffff;"  class="td">
                    <strong>深圳梓人环境设计有限公司 <%if (isConstruction == "2")
                                           { %>采购部<%}
                                           else
                                           { %>设计部<%} %> 项目进度计划监督表(<%=stageName%>)</strong>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px; background-color: #ffffff;"  class="td">
                    <strong>一、项目基本情况 Ⅰ. Project Basic Info</strong>
                </td>
            </tr>
             <tr>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;"  class="td">
                项目名称 Project name：<%=pModel==null?"":pModel.project_name %>
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;"  class="td">
                项目编号 Project code：<%=pModel==null?"":pModel.project_code %>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;"  class="td">
                制作人 Prepared by：<%=pModel==null?"":pModel.prepared_by %>
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;"  class="td">
                进度监督人 Reviewed by：<%=pModel==null?"":pModel.reviewed_by %>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;"  class="td">
                项目负责人 Project manager：<%=pModel==null?"":pModel.project_manager %>
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;"  class="td">
                制作日期 Date：<%=pModel==null?"":pModel.creation_date %>
                </td>
            </tr>
            <tr>
                <td align="left"  colspan="2" style="height: 25px; background-color: #ffffff; border-bottom:0px solid #000000; "  class="td">
                    <strong>二、项目进度表 Ⅱ. Project Schedule</strong>
                </td>
            </tr>
            <tr >
                <td align="left"  colspan="2" style="height:100%;  ">
                <%=trStr.Trim() %>
                </td>
            </tr>
         </table>
    </div>    

    </form>
</body>
</html>
