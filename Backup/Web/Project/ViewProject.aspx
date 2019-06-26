<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ViewProject.aspx.cs" Inherits="Maticsoft.Web.Project.ViewProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../js/themes/default/datagrid2.css" rel="stylesheet" type="text/css" />
<link href="../css/preview.css" rel="stylesheet" type="text/css" />
<script src="../js/preview1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        //InitGird();   
        getWorker();
    });
    var work = 2;
    //window.onload = InitGird;

    //初始化表格
    function InitGird() {
        $('#tt').datagrid({
            fit: true,
            singleSelect: true, //单选
            //dataType:'json',
            //fitColumns: true, //列自适应
            url: '../Ashx/Project.ashx', //请求数据的页面
            queryParams: { 'action': 'content_view_item', 'pssid': '<%=pssid %>', 'isConstruction': '<%=isConstruction %>' },
            idField: 'sid', //标识字段,主键
            //columns: eval('(' + columns + ')'),
            onLoadSuccess: function (data) {
               // alert(data);
                //if (data.rows.length > 0) {
                    //调用mergeCellsByField()合并单元格
                   /// mergeCellsByField("tt", "stage_name,group_name,contentName");
                //}
            },
            onClickCell: function (rowIndex, field, value) {
            },
            onClickRow: function (rowIndex, rowData) {
            }
        })
    }

    function hackHeight(listId) {
        $(listId + '_frozen tr').slice(1).each(function () {

            var rowId = $(this).attr('id');

            var frozenTdHeight = parseFloat($('td:first', this).height());
            var normalHeight = parseFloat($(listId + ' #' + $(this).attr('id')).find('td:first').height());

            // 如果冻结的列高度小于未冻结列的高度则hack之
            if (frozenTdHeight < normalHeight) {

                $('td', this).each(function () {

                    /*
                    浏览器差异高度hack
                    */
                    var space = 0; // opera默认使用0就可以
                    if (browser.isChrome()) {
                        space = 0.6;
                    } else if (browser.isIE()) {
                        space = -0.2;
                    } else if (browser.isMozila()) {
                        space = 0.5;
                    }

                    if (!$(this).attr('style') || $(this).attr('style').indexOf('height:') == -1) {
                        $(this).attr('style', $(this).attr('style') + ";height:" + (normalHeight + space) + "px !important");
                    }
                });
            }
        });
    }

    function trHide() {
        //$('#tr1').hide();collapse
        $('#cc').layout('collapse', 'north');
    }

    function getWorker() {
        $('#workerID').combobox({
            url: '../Ashx/Common.ashx?type=work_users&pssid=<%=pssid %>',
            valueField: 'UserName',
            textField: 'Name',
            multiple: true,
            editable: false
        });
    }

    function Search() {
        $('#tt').datagrid('options').queryParams = {'action': 'content_view_item', 'pssid': '<%=pssid %>','isConstruction': '<%=isConstruction %>','type':'<%=type %>' , "worker": $('#workerID').combobox('getValues').join("','")};
        $('#tt').datagrid('load');
    }

    function print() {
        if ("<%=type %>" == "me") {
            window.open("PrintProject.aspx?ps_sid=<%=pssid %>&type=<%=type %>");
        } else {
            window.open("PrintProject.aspx?ps_sid=<%=pssid %>&type=<%=type %>&worker=" + $('#workerID').combobox('getValues').join("','"));
        }
        
    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="cc" class="easyui-layout" fit="true" border="false" style="overflow-y: hidden"  scroll="no">
<div region="north" title="" border="false" split="false">
<input type="hidden" id="hsid" name="hsid" value="" />
<input type="hidden" id="haction" name="haction" value="" />
<input type="hidden" id="hpsid" name="hpsid" value="" />
<input type="hidden" id="hpssid" name="hpssid" value="<%=pssid %>" />
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr id="tr1">
                <td align="right" colspan="4" style="height: 25px; background-color: #e1f5fc; text-align: center; font-size:larger">
                    <strong>深圳梓人环境设计有限公司 设计部 项目进度计划监督表(<%=stageName%>)</strong>
                    <div style="float:right">
                    <%--<a id="btn" href="PrintProject.aspx?ps_sid=<%=pssid %>&type=<%=type %>" target="_blank" class="easyui-linkbutton" data-options="iconCls:'icon-print'">打印</a> --%>
                    <a id="btn" href="#" onclick="print();" class="easyui-linkbutton" data-options="iconCls:'icon-print'">打印</a> 
                    </div>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px; background-color: #e1f5fc;">
                    <strong>一、项目基本情况 Ⅰ. Project Basic Info</strong>
                </td>
            </tr>
             <tr>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                项目名称 Project name：<%=pModel==null?"":pModel.project_name %>
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                项目编号 Project code：<%=pModel==null?"":pModel.project_code %>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                制作人 Prepared by：<%=pModel==null?"":pModel.prepared_by %>
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                进度监督人 Reviewed by：<%=pModel==null?"":pModel.reviewed_by %>
                </td>
            </tr>
            <tr>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                项目负责人 Project manager：<%=pModel==null?"":pModel.project_manager %>
                </td>
                <td style="background-color: #ffffff; height: 25px; padding-left: 5px;">
                制作日期 Date：<%=pModel==null?"":pModel.creation_date %>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px; background-color: #e1f5fc;">
                    <strong>二、项目进度表 Ⅱ. Project Schedule</strong>
                   <%-- <div style="float:right"><a id="A1" href="#" onclick="trHide()" class="easyui-linkbutton" data-options="iconCls:'icon-print'">隐藏</a> </div>--%>
                   <div style="float:right; margin-right:10px;"><a id="A1" href="#" onclick="trHide()" style="cursor:pointer;"><div style="float:left;width:16px;height:16px;background: url('../js/themes/metro/images/layout_arrows.png') no-repeat -16px -16px;"></div>收起</a></div>
                </td>
            </tr>
         </table>
    </div>   
     <div region="center" title="" border="false">  
     <div class="easyui-panel" data-options="fit:true,border:false">

     <%--<div style="height:25px;line-height:25px; background-color: #e1f5fc;"><strong>二、项目进度表 Ⅱ. Project Schedule</strong>
     <div style="float:right; margin-right:10px;"><a id="A1" href="#" onclick="trHide()" style="cursor:pointer">收起</a></div>
     </div>--%>
       <table id="tt" class="easyui-datagrid"  data-options="url:'../Ashx/Project.ashx',queryParams: { 'action': 'content_view_item', 'pssid': '<%=pssid %>','isConstruction': '<%=isConstruction %>','type':'<%=type %>' },singleSelect:true,fit:true,toolbar:'#toolbar',onLoadSuccess: function (data) {if (data.rows.length > 0) {  if ($('a.preview').length) {var img = preloadIm();imagePreview(img);                    } if('<%=isConstruction %>'=='3') mergeCellsByField('tt', 'number,productName,productPic,Specifications,paintColor,useSpace,spaceCount,install,usePart,unit,amount,paintPaletteNumber,ppiRemark,stage_name,group_name,contentName'); else if('<%=isConstruction %>'=='4') mergeCellsByFieldGroupList('tt', 'stage_name,group_name,contentName','number,productName,productPic,Specifications,paintColor,useSpace,spaceCount,install,usePart,unit,amount,paintPaletteNumber,ppiRemark|productID');  else mergeCellsByField('tt', 'stage_name,group_name,contentName');}},idField: 'sid'">
          <%--<table id="tt">--%>
                    <%=trStr %>
          </table>
          </div>
    </div>
 </div>
 <div id="toolbar" style="display:none;">
 <%if (type != "me")
   { %>
 <div style="float:left;"><a href="#" id="workerIDTitle" class="easyui-linkbutton" plain="true">工作人员：</a></div>
                    <div>
                        <input id="workerID" style="width:300px;"/>&nbsp;&nbsp;<a id="search" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-search'" onclick="Search();">查询</a>
                    </div>
                    <%} %>
 </div>
</asp:Content>

