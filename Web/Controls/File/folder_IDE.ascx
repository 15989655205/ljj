<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="folder_IDE.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.AddFileCate" %>
<div style="margin-left:10px;">
<div class="oaTopDiv" style="width:98%; background-color:White; z-index:9999;">
<div style="height:10px"></div>
    <div class="section-header">
        <div class="title">
           <img src="../../Images/8.png" alt="" />
        </div>
        <div class="options">
            <input type="button" id="btnSaveButton" value="保存" class="adminButtonBlue" onclick="save();"  />
        </div>
    </div>
</div>
<div style="height:50px;"></div>
<div style="width: 98% ">
<form id="ff" method="post" action="" >
    <input type="hidden" id="sid" name="sid"  />
    <table class="oa_Flow_Tab" id="uiform">
        <tr>
            <td width="100px" class="titleTD">
             文件夹名称 
            </td>
            <td width="*" class="inputTD" colspan="4">
                <input type="text" id="txtName" name="txtName" validType="folderName" required="true" class="easyui-validatebox"/>
            </td>
        </tr>
        <tr>
            <td  class="titleTD">
             父级文件夹 
            </td>
            <td width="*" class="inputTD" colspan="4">
                <input id="parent_ct" class="easyui-combotree" />
            </td>
        </tr>
        <tr>
            <td class="titleTD">
             上传权限
            </td>
            <td class="inputTD" rowspan="2" style="width:12%;">
                <ul id="up_dept_per" class="easyui_class" style="height:400px; overflow:auto;" ></ul>
            </td>
            <td style="width:35%;">
                <table id="up_user_per" class="easyui_class"></table>
            </td>
            <td style="width:4%; text-align:center">
                    <div style="height:20px"></div>
                    <a href="#" id="btn_up_user" onclick="btn_up_user();return false;" class="easyui-linkbutton" data-options="plain:true" style="background:url('../Images/right.png') no-repeat center center"></a>
                    <div style="height:20px"></div>
                    <a href="#" id="btn_all_up_user" onclick="btn_all_up_user();return false;" class="easyui-linkbutton" data-options="plain:true" style="background:url('../Images/right_1.png') no-repeat center center"></a>
                    <div style="height:20px"></div>
                    <a href="#" id="btn_del_up_user" onclick="btn_del_up_user();return false;" class="easyui-linkbutton" data-options="plain:true" style="background:url('../Images/left.png') no-repeat center center"></a>
                    <div style="height:20px"></div>
                    <a href="#" id="btn_del_up_all" onclick="btn_del_up_all();return false;" class="easyui-linkbutton" data-options="plain:true" style="background:url('../Images/left_1.png') no-repeat center center"></a>
                
            </td>
            <td style="width:35%;"><table id="dept_users"></table></td>
        </tr>
         <tr>
            <td class="titleTD">
             下载权限
            </td>
            <%--<td class="inputTD" style="width:12%;">
                <ul id="dowm_dept_per" class="easyui_class" style="height:200px; overflow:auto"></ul>
            </td>--%>
            <td style="width:35%;">
                <table id="dowm_user_per" class="easyui_class"></table>
            </td>
            <td style="width:4%; text-align:center">
                    <div style="height:20px"></div>
                    <a href="#" id="btn_dowm_user" onclick="btn_dowm_user();return false;" class="easyui-linkbutton" data-options="plain:true" style="background:url('../Images/right.png') no-repeat center center"></a>
                    <div style="height:20px"></div>
                    <a href="#" id="btn_all_dowm_user" onclick="btn_all_dowm_user();return false;" class="easyui-linkbutton" data-options="plain:true" style="background:url('../Images/right_1.png') no-repeat center center"></a>
                    <div style="height:20px"></div>
                    <a href="#" id="btn_del_dowm_user" onclick="btn_del_dowm_user();return false;" class="easyui-linkbutton" data-options="plain:true" style="background:url('../Images/left.png') no-repeat center center"></a>
                    <div style="height:20px"></div>
                    <a href="#" id="btn_del_dowm_all" onclick="btn_del_dowm_all();return false;" class="easyui-linkbutton" data-options="plain:true" style="background:url('../Images/left_1.png') no-repeat center center"></a>
                
            </td>
            <td style="width:35%;"><table id="dowm_dept_users"></table></td>
        </tr>
         <tr>
            <td class="titleTD" >
             备注  
            </td>
            <td class="inputTD" colspan="4">
                <textarea id="txtRemark" name="txtRemark" rows="5" cols="10" class="textarea"
                    onkeyup="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    onkeydown="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    onpropertychange="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"
                    oninput="this.style.height = (this.scrollHeight-8<=100?100:this.scrollHeight-4) + 'px';"></textarea>
            </td>
        </tr>
     </table>
    </form>
 
 </div>
</div>
<script type="text/javascript">
   
</script>