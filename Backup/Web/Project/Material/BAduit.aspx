<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="BAduit.aspx.cs" Inherits="Maticsoft.Web.Project.Material.BAduit" %>

<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="/Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  <script type="text/javascript">
    $(function () {
        //LoadTable();
        
        
    });

    function LoadedBar(){
        var where="";
        if(document.getElementById('tab_div_10').style.display!='none'){
            where+="(Submit=1 or Audit=0  or Checking=2 )";
        }
        if(document.getElementById('tab_div_26').style.display!='none'){
            if(where==""){
                where+="(Checking=0  and Audit=1)";
            }
            else{
                where="("+where+" or (Checking=0 and Audit=1) )";
            }
        }
        LoadTable(where);
        GetProjectCombo();
        GetSpaceCombo();
        GetPlaceCombo();
   }

   function selectData(){
   var val=$('#cc').combobox('getValue');

   if(val==1){
        $('#tt').datagrid('options').queryParams = { "projectID": $('#project').combobox('getValue'),"spaceID": $('#space').combobox('getValue'),"placeID": $('#place').combobox('getValue'),"me":"1" };
        $('#tt').datagrid('load');
   }
   else{
   var where="";
        if(document.getElementById('tab_div_10').style.display!='none'){
            where+="(Submit=1 and Audit=0)";
        }
        if(document.getElementById('tab_div_26').style.display!='none'){
            if(where==""){
                where+="(Checking=0 and Audit=2)";
            }
            else{
                where="("+where+" or (Checking=0 and Audit=2) )";
            }
        }
        $('#tt').datagrid('options').queryParams = { "projectID": $('#project').combobox('getValue'),"spaceID": $('#space').combobox('getValue'),"placeID": $('#place').combobox('getValue'),"where":where };
        $('#tt').datagrid('load');
   }
   }

    function GetProjectCombo() {
        $('#project').combobox({
            url: '/Ashx/Common.ashx?type=getProject',
            valueField: 'sid',
            textField: 'name',
            editable: false,
            onChange: function (newValue, oldValue) {
                GetSpaceCombo(newValue);
                GetPlaceCombo();
                try{
                //$('#tt').datagrid('options').queryParams = { "projectID": newValue };
                //$('#tt').datagrid('load');
                selectData();
                }
                catch(e){
                }
            }
        });
    }

    function GetSpaceCombo(val) {
        $('#space').combobox({
            url: '/Ashx/Common.ashx?type=getSpace&pid=' + val,
            valueField: 'sid',
            textField: 'name',
            editable: false,
            onChange: function (newValue, oldValue) {
                GetPlaceCombo(newValue);
                try{
//                $('#tt').datagrid('options').queryParams = { "spaceID": newValue };
//                $('#tt').datagrid('load');
selectData();
                }
                catch(e){
                }
            }
        });
    }

    function GetPlaceCombo(val) {
        $('#place').combobox({
            url: '/Ashx/Common.ashx?type=getPlace&pid=' + val,
            valueField: 'sid',
            textField: 'name',
            editable: false,
            onChange: function (newValue, oldValue) {
                //LoadTable(newValue);
                try{
//                $('#tt').datagrid('options').queryParams = { "placeID": newValue };
//                $('#tt').datagrid('load');
selectData();
                }
                catch(e){
                }
            }
        });
    }

//     function GetPlaceCombo(val) {
//        $('#place').combobox({
//            url: '/Ashx/Common.ashx?type=getPlace&pid=' + val,
//            valueField: 'sid',
//            textField: 'name',
//            editable: false,
//            onChange: function (newValue, oldValue) {
//                //LoadTable(newValue);
////                $('#tt').datagrid('options').queryParams = { "placeID": newValue };
////                $('#tt').datagrid('load');
//selectData();
//            }
//        });
//    }

    function LoadTable(where) {
        $("#tt").datagrid({
            url: "/Ashx/ProjectMaterial.ashx?action=MaterialBAduitList"
            , queryParams: { "where": where}
                , loadMsg: "正在加载中..."
                , toolbar: "#toolbar"
                , idField: "ID"

                ,fit:true
                , rownumbers: true
             

                ,selectOnCheck: true
                ,checkOnSelect: true
                 , pageSize: 20
           , pageList: [10, 20, 30, 40, 50, 100]
            // , remoteSort: true
                , pagination: true
                , rowStyler: function (index, row) {
                }
                , frozenColumns: [[
                { field: "ckb", checkbox: true, width: 5 },
                    { title: '空间', field: 'space', width: 150, halign: 'center' },
                    { title: '部位', field: 'place', width: 80, halign: 'center' },
                    { title: '图纸编号', field: 'DrawingNumber', width: 80, halign: 'center', align: 'center',},
                    { title: '编号', field: 'productCode', width: 80, halign: 'center', align: 'center' },
                    { title: '内容', field: 'productName', width: 80, halign: 'center', align: 'center' }
                ]]
                , columns: [
                    [
                    { title: '尺寸', field: 'Size', width: 80, halign: 'center', align: 'center'},
                    { title: '单位', field: 'UnitName', width: 80, halign: 'center', align: 'center'},
                    { title: '数量', field: 'Amount', width: 80, halign: 'center', align: 'center'},
                    { title: '颜色 ', field: 'Color', width: 80, halign: 'center', align: 'center'},
                    { title: '质地 ', field: 'Quality', width: 80, halign: 'center', align: 'center'},
                    { title: '品牌', field: 'Brand', width: 100, halign: 'center'},
                    { title: '阻燃性', field: 'NFK', width: 100, halign: 'center'}, 
                    { title: '备注', field: 'remark', width: 100, halign: 'center'}, 
                    { title: '状态', field: 'Status', halign: 'center', width: 100 },
                    { title: '审核人', field: 'AuditPerson', halign: 'center', width: 100 },
                    { title: '审核时间', field: 'AuditDate', halign: 'center', width: 100 },
                    { title: '校核人', field: 'CheckPerson', halign: 'center', width: 100 },
                    { title: '校核时间', field: 'CheckDate', halign: 'center', width: 100 },
                    { title: '创建人', field: 'create_person', halign: 'center', width: 100 },
                    { title: '创建时间', field: 'create_date', halign: 'center', width: 100 },
                    { title: '修改人', field: 'update_person', halign: 'center', width: 100 },
                    { title: '修改时间', field: 'update_date', halign: 'center', width: 100 }
                    ]
                ],
            onLoadSuccess: function (data) {
                mergeCellsByFieldGroup('tt', 'space,place,locationID,AStatus|place,SubmitPerson|place,SubmitDate|place,Auditor|place,AuditDate|place,CheckPerson|place,CheckDate|place');
            },
            onClickRow: function (index, rowData) {
            }
                , onClickCell: function (rowIndex, field, value) { $("#tt").datagrid("clearSelections"); }

        });
    }

    function save() {
        if (endEditing()) {
            var rows = $('#tt').datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].productName.length <= 0) {
                    $.messager.show({ title: '错误提示', msg: "材料不能为空" });
                    EditGrid(rows[i]);
                    return false;
                }
            }

            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var delrows = $('#tt').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delrows);
            var updaterows = $('#tt').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updaterows);
            var addrows = $('#tt').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addrows);
            $.ajax({
                type: "POST",
                timeout: 30000, //超时时间：30秒
                url: '/Ashx/ProjectMaterial.ashx',
                data: {
                    'action': 'ASave',
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        $('#tt').datagrid("reload");
                        //$.messager.show({ title: '提示', msg: "编辑成功！" });
                    }
                    $.messager.show({ title: '错误提示', msg: (data == "success" ? "保存成功" : data) });

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                }
            });
        }
    }


    function OpenDialog(title,id){
            if (art.dialog.list['aduit_dialog'] == null) {
            art.dialog({
                content: document.getElementById(''+id+''),
                id: ''+id+'',
                title: title,
                padding: '0px 0px 0px 0px',
                background: '#c3c3c3',
                resize: false,
                esc: false,
                lock: true,
               
                close: function () {
                }
            });
        }
       
    }

    //打开审核
    function sh(){
    OpenDialog('审核','aduit_edit');
        
    }

       //审核
    function sh1(){
             var selected = "";
             var rows = $("#tt").datagrid("getSelections");
            
             for (var i = 0; i < rows.length; i++) {
                 if (rows[i].Submit == 1) {
                     selected += "" + rows[i].ID + ",";
                 }
             }
             selected = selected.substr(0, selected.length - 1);

        $.ajax({
            type: 'post',
            url: '/Ashx/ProjectMaterial.ashx',
            data: {
                'action': 'sh_B',
                'sid': selected  
            },
            success: function (res) {
                $.messager.show({ title: '提示', msg: res });
                $('#tt').datagrid("reload");
            }
        });
         
    }

    //审核不通过
    function shRefuse1(){
             var selected = "";
             var rows = $("#tt").datagrid("getSelections");
            
             for (var i = 0; i < rows.length; i++) {
                 if (rows[i].Submit == 1) {
                     selected += "" + rows[i].ID + ",";
                 }
             }
             selected = selected.substr(0, selected.length - 1);
             
        $.ajax({
            type: 'post',
            url: '/Ashx/ProjectMaterial.ashx',
            data: {
                'action': 'RefuseSh_B',
                
                'sid': selected 
            },
            success: function (res) {
                $.messager.show({ title: '提示', msg: res });
                $('#tt').datagrid("reload");
            }
        });
    }
        //撤销审核
    function qs1(){
             var selected = "";
             var rows = $("#tt").datagrid("getSelections");
            
             for (var i = 0; i < rows.length; i++) {
                 if (rows[i].Submit == 1) {
                     selected += "" + rows[i].ID + ",";
                 }
             }
             selected = selected.substr(0, selected.length - 1);

        

        $.ajax({
            type: 'post',
            url: '/Ashx/ProjectMaterial.ashx',
            data: {
                'action': 'cancelSh',
                'sid': selected  
            },
            success: function (res) {
                $.messager.show({ title: '提示', msg: res });
                $('#tt').datagrid("reload");
            }
        });
    }

          //校核
    function Check(){
        OpenDialog('校核','jh');
        
    }

       //校核
    function Check1(){

             var selected = "";
             var rows = $("#tt").datagrid("getSelections");
            
             for (var i = 0; i < rows.length; i++) {
                 if (rows[i].Submit == 1) {
                     selected += "" + rows[i].ID + ",";
                 }
             }
             selected = selected.substr(0, selected.length - 1);


        $.ajax({
            type: 'post',
            url: '/Ashx/ProjectMaterial.ashx',
            data: {
                'action': 'Check_B',
         
                'sid': selected  
            },
            success: function (res) {
                $.messager.show({ title: '提示', msg: res });
                $('#tt').datagrid("reload");
            }
        });
    }


        //校核不通过
    function JHRefuse1(){
             var selected = "";
             var rows = $("#tt").datagrid("getSelections");
            
             for (var i = 0; i < rows.length; i++) {
                 if (rows[i].Submit == 1) {
                     selected += "" + rows[i].ID + ",";
                 }
             }
             selected = selected.substr(0, selected.length - 1);

        

        $.ajax({
            type: 'post',
            url: '/Ashx/ProjectMaterial.ashx',
            data: {
                'action': 'RefuseJH_B',
               
                'sid': selected  
            },
            success: function (res) {
                $.messager.show({ title: '提示', msg: res });
                $('#tt').datagrid("reload");
            }
        });
    }

              //撤销校核
    function CancelCheck1(){
             var selected = "";
             var rows = $("#tt").datagrid("getSelections");
            
             for (var i = 0; i < rows.length; i++) {
                 if (rows[i].Submit == 1) {
                     selected += "" + rows[i].ID + ",";
                 }
             }
             selected = selected.substr(0, selected.length - 1);

        

        $.ajax({
            type: 'post',
            url: '/Ashx/ProjectMaterial.ashx',
            data: {
                'action': 'CancelCheck',
               
                'sid': selected 
            },
            success: function (res) {
                $.messager.show({ title: '提示', msg: res });
                $('#tt').datagrid("reload");
            }
        });
    }
    </script>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table id="tt">
    </table>
    <div id="toolbar">
        <table style="margin: 5px;">
            <tr>
                <td style="">
                    项目：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <input id="project" name="project" />
                </td>
                <td style="">
                    空间：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <input id="space" name="space" />
                </td>
                <td style="">
                    部位：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <input id="place" name="place" />
                </td>
                <td style="">
                    审核状态：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <select id="cc" class="easyui-combobox" name="astatus" style="width: 100px;" data-options="onSelect:function(record){selectData(record.value);}">
                        <option value="0" selected="selected">待审核</option>
                        <option value="1">我审核过的</option>
                    </select>
                </td>
            </tr>
        </table>
        <toolbar:ToolBar runat="server" ID="toolbar1" />
        <div id="aduit_edit" style="display: none">
            <div id="tab_div_10" style="float: left;">
                <a href="#" id="tab_a_10" class="easyui-linkbutton" plain="true" onclick="sh1()"
                    iconcls="icon-sh">审批</a>
            </div>
            <div id="Div1" style="float: left;">
                <a href="#" id="A1" class="easyui-linkbutton" plain="true" onclick="shRefuse1()"
                    iconcls="icon-sh">审批不通过</a>
            </div>
            <div id="cxsh" style="float: left; display: none">
                <a href="#" id="tab_b" class="easyui-linkbutton" plain="true" onclick="qs1()" iconcls="icon-sh">
                    撤销审批</a>
            </div>
        </div>
        <div id="jh" style="display: none">
            <div id="tab_div_26" style="float: left;">
                <a href="#" id="tab_a_26" class="easyui-linkbutton" plain="true" onclick="Check1()"
                    iconcls="icon-sh">校核</a>
            </div>
            <div id="Div2">
                <div id="Div3" style="float: left;">
                    <a href="#" id="A2" class="easyui-linkbutton" plain="true" onclick="JHRefuse1()"
                        iconcls="icon-sh">校核不通过</a>
                </div>
                <div id="cxjh" style="float: left; display: none">
                    <a href="#" id="tab_a" class="easyui-linkbutton" plain="true" onclick="CancelCheck1()"
                        iconcls="icon-sh">撤销校核</a>
                </div>
            </div>
        </div>
</asp:Content>
