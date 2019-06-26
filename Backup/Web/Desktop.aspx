<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Desktop.aspx.cs" Inherits="Maticsoft.Web.Desktop" %>
<%@ Register TagPrefix="psr_IDE" TagName="PSR_IDE" Src="~/Controls/Project/ProjectSubmitRecord.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="js/themes/default/panel1.css" rel="stylesheet" type="text/css" />
       
    <style type="text/css">
        .div_body{margin-left:0px; margin-right:0px; margin-bottom:10px;border:1px solid #95B8E7;height:200px}
        .div_top{margin-left:0px; margin-right:0px;height:26px;background:url('../Images/disktop_back.jpg');line-height:28px;border-bottom:1px solid #95B8E7;}       
        .div_tt{width:100%; height:172px; margin-left:0px; margin-right:0px;overflow:auto;}
        .tt{width:100%;background:#dddddd;border:0;padding:2;border-spacing:1px;}
        .tt_head{}
        .tt_body{}
        .tt_th{height:25px;background:#f0f0f0;}
        .tt_td{height:25px;text-align:center;background:#ffffff;}
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
        <table style="width:100%">
            <tr>
                <td colspan="2" style="width:100%">
                    <div class="div_body">
                        <div class="div_top"><img alt="" src="../js/themes/icons/JianTou.gif"/><b>项目公告信息(<%=projectNonticeCount %> Item(s))</b></div>
                        <div class="div_tt">
                            <table class="tt">
                                <thead>
                                    <tr>
                                        <th class="tt_th">项目编号</th>
                                        <th class="tt_th">项目名称</th>
                                        <th class="tt_th">阶段</th>
                                        <th class="tt_th">小组</th>
                                        <th class="tt_th">工作内容</th>
                                        <th class="tt_th">细目</th>
                                        <th class="tt_th">工作种类(负责人)</th>
                                        <th class="tt_th">主管审批</th>
                                        <th class="tt_th">总审</th>
                                        <th class="tt_th">审批人</th>
                                        <th class="tt_th">审批时间</th>
                                        <th class="tt_th">备注</th>
                                    </tr>
                                </thead>
                                <tbody><%=projectNotice%></tbody>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr style="width:100%">
                <td style="width:50%">
                    <div class="div_body" style="margin-right:5px;">
                        <div class="div_top">
                            <img alt="" src="../js/themes/icons/JianTou.gif"/><b>我的项目计划(未完成-<%=myProjectPlaneCount %> Item(s))</b>
                            <a href="#" style="text-decoration:none;float:right;" onclick="parent.addTab_Ext('我未完成的项目', '/Project/MyProjectPlan.aspx?type=0', '', true);">
                                更多>>&nbsp;&nbsp;&nbsp;&nbsp;
                            </a>
                        </div>
                        <div class="div_tt">
                            <table class="tt">
                                <thead>
                                    <tr>
                                        <th class="tt_th">项目编号/项目名称/阶段/小组/工作内容/细目</th>
                                        <th class="tt_th">工作种类(负责人)</th>
                                        <th class="tt_th">开始日期</th>
                                        <th class="tt_th">结束日期</th>
                                        <th class="tt_th">状态</th>
                                    </tr>
                                </thead>
                                <tbody><%=myProjectPlane%></tbody>
                            </table>
                        </div>
                    </div>
                </td>
                <td style="width:50%">
                    <div class="div_body" style="margin-left:5px;">
                        <div class="div_top">
                            <img alt="" src="../js/themes/icons/JianTou.gif"/><b>待审批项目计划(<%=projectPlanApprCount %> Item(s))</b>                           
                            <a href="#" style="text-decoration:none;float:right;" onclick="parent.addTab_Ext('我的审批项目', '/Project/ProjectPlanAppr.aspx?type=0', '', true);">
                                更多>>&nbsp;&nbsp;&nbsp;&nbsp;
                            </a>
                        </div>
                        <div class="div_tt">
                            <table class="tt">
                                <thead>
                                    <tr>
                                        <th class="tt_th">项目编号/项目名称/阶段/小组/工作内容/细目</th>
                                        <th class="tt_th">工作种类(负责人)</th>
                                        <th class="tt_th">开始日期</th>
                                        <th class="tt_th">结束日期</th>
                                        <th class="tt_th">提交人</th>
                                        <th class="tt_th">提交时间</th>
                                    </tr>
                                </thead>
                                <tbody><%=projectPlanAppr%></tbody>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr style="width:100%">
                <td style="width:50%">
                    <div class="div_body" style="margin-right:5px;">
                        <div class="div_top">
                            <img alt="" src="../js/themes/icons/JianTou.gif"/><b>待我办理(<%=apprRequestCount %> Item(s))</b>
                            <a href="#" style="text-decoration:none;float:right;"
                                onclick="parent.addTab_Ext('待我办理', '/Flow/WaitMeForm.aspx', '', true);">
                                更多>>&nbsp;&nbsp;&nbsp;&nbsp;
                            </a>
                        </div>
                        <div class="div_tt">
                            <table class="tt">
                                <thead>
                                    <tr>
                                        <th class="tt_th">系统编号</th>
                                        <th class="tt_th">类型</th>
                                        <th class="tt_th">申请单名称</th>
                                        <th class="tt_th">申请人</th>
                                        <th class="tt_th">申请部门</th>
                                        <th class="tt_th">申请时间</th>
                                        <th class="tt_th">状态</th>
                                        <th class="tt_th">当前办理节点</th>
                                        <th class="tt_th">最近办理人</th>
                                        <th class="tt_th">最近办理时间</th>
                                    </tr>
                                </thead>
                                <tbody><%=apprRequest%></tbody>
                            </table>
                        </div>
                    </div>
                </td>
                <td style="width:50%">
                    <%--<div class="div_body" style="margin-left:5px;">
                        <div class="div_top">
                            <img alt="" src="../js/themes/icons/JianTou.gif"/><b>待审批项目计划</b>                           
                            <a href="#" style="text-decoration:none;float:right;"
                                onclick="parent.addTab_Ext('项目审批', '/Project/ProjectPlanAppr.aspx', '', true);">
                                更多>>&nbsp;&nbsp;&nbsp;&nbsp;
                            </a>
                        </div>
                        <div class="div_tt">
                            <table class="tt">
                                <thead>
                                    <tr>
                                        <th class="tt_th">项目编号/项目名称/阶段/小组/工作内容/细目</th>
                                        <th class="tt_th">工作种类(负责人)</th>
                                        <th class="tt_th">开始日期</th>
                                        <th class="tt_th">结束日期</th>
                                        <th class="tt_th">提交人</th>
                                        <th class="tt_th">提交时间</th>
                                    </tr>
                                </thead>
                                <tbody><%=projectPlanAppr%></tbody>
                            </table>
                        </div>
                    </div>--%>
                </td>
            </tr>
        </table>
                
</asp:Content>
