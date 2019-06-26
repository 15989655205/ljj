<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true"
    CodeBehind="Space_IDE.aspx.cs" Inherits="Maticsoft.Web.Project.Space_IDE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
$(function(){
    var editIndex;
    $('#t').datagrid({
        url: '../Ashx/Project_Space.ashx?type=GetList&psid=' + <%=psid %> + '',
                toolbar: '#tb',
  
                pageSize: 20
           , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
                , nowrap: false
                , remoteSort: true
                , pagination: true
                , rownumbers: true,
                                singleSelect: true,
        columns: [[
        { field: 'ps1name', title: '空间', width: 200 ,  editor:
                    {
                        type: 'combobox',
                        options: {
                            valueField: 'name',
                            textField: 'name',
                            url: '../../Ashx/Project_Space.ashx?type=GetName',
                            required: true
                        }
                    } },
        { field: 'ps2name', title: '部位', width: 200, editor: "text"  }
        
    ]],
      onLoadSuccess: function (data) {
                    //delete $(this).datagrid('options').queryParams['id'];
                    if (data.rows.length > 0) { mergeCellsByField('t', 'ps1name'); }
                   // Revert();
                    }
        , onClickRow: function (rowIndex, rowData) {
                    if (rowIndex != editIndex) {
                        End(editIndex);
                    }
                    $('#t').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
                    editIndex = rowIndex;
                 

                }
    });  
});

    function AddRow(){
     EndEdit() ;
        $('#t').datagrid('insertRow', { index: 0, row: {} });
            editIndex=0;
            //alert(editIndex);
            $('#t').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
        
         }

               function delRow() {
            var row = $('#t').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: "warn", msg: "请选择要删除的行！" });

            }
            var rowIndex = $('#t').datagrid('getRowIndex', row);
            // alert(rowIndex);
          var rows = $('#t').datagrid('getRows');
                for (var i = 0; i < rows.length; i++) {
                    $('#t').datagrid('refreshRow', i);
                }
              $('#t').datagrid('deleteRow', rowIndex);
              mergeCellsByField('t', 'ps1name'); 
       
        }

          function MoveRowByPart(fx) {
           var gd = $('#t');
                var gdData = gd.datagrid("getData");
                var FocusRow = gd.datagrid('getSelected');
                var FocusRowIndex = gd.datagrid('getRowIndex',FocusRow);
                var arr=new Array();
                var indexArr=new Array();
                for(var i =0;i<gdData.rows.length;i++)
                {
                   
                                if(gdData.rows[FocusRowIndex].ps1name==gdData.rows[FocusRowIndex-1].ps1name)
                                {
                                    arr.push(gdData.rows[FocusRowIndex]);
                                    indexArr.push(FocusRowIndex);
                                    FocusRowIndex++;
                                }
                }
                FocusRowIndex = gd.datagrid('getRowIndex',FocusRow);
                for(var j =0;j<gdData.rows.length;j++)
                {
                    
                                if(gdData.rows[FocusRowIndex].ps1name==gdData.rows[FocusRowIndex-1].ps1name)
                                {
                                   
                                    arr.unshift(gdData.rows[FocusRowIndex-1]);
                                    indexArr.unshift(FocusRowIndex-1);
                                    FocusRowIndex--;
                                }
                }
                
                
                 for(var s=0;s<arr.length;s++)
                {
                    alert(arr[s].ps2name);
                }
               EndEdit();
      
                for(var n=0;n<indexArr.length;n++)
                {
                alert(indexArr[n]);
                    gd.datagrid('deleteRow',indexArr[n]);
                    gd.datagrid('refreshRow',indexArr[n]);
                       
                }
               for(var s=0;s<arr.length;s++)
                {

                   gd.datagrid('insertRow',{index:indexArr[s],row:arr[s]});
                   gd.datagrid('refreshRow',indexArr[n]);
                }

                 
              //   gd.datagrid('updateRow', { index: iMovedRowIndex, row: gdData.rows[iCurRowIndex] });
              //  var RowChange = JSON.parse(tmpStr);
                //gd.datagrid('updateRow', { index: iCurRowIndex, row: RowChange });
                //gd.datagrid('selectRow', iMovedRowIndex);
                gd = null;
          }

       function MoveRow(fx) {
          // EndEdit();
                var gd = $('#t');
                var gdData = gd.datagrid("getData");
                if (gdData.rows.length < 2) return;
                var iMovedRowIndex = -1;
                var FocusRow = gd.datagrid('getSelected');
              
                if (!FocusRow) {
                    //alert("没有行被选中,无法执行移动操作");
                    $.messager.show({ title: '提示', msg: "没有行被选中,无法执行移动操作" });
                    return;
                }
                var iCurRowIndex = gd.datagrid('getRowIndex', FocusRow);
                iMovedRowIndex = iCurRowIndex + fx;
                if (iCurRowIndex === 0 && fx === -1) return; //iMovedRowIndex = gdData.rows.length - 1;
                if (iCurRowIndex === gdData.rows.length - 1 && fx === 1) return; //iMovedRowIndex = 0;
                if (gdData.rows[iMovedRowIndex].ps1name != gdData.rows[iCurRowIndex].ps1name) {
                    $.messager.show({ title: '提示', msg: "不能跨空间移动部位" });
                    return;
                }
                var RowTemp = gdData.rows[iMovedRowIndex]; //gd.datagrid('getRows')[iMovedRowIndex]; //{ group_name: "", remark: "", sequence: "", sid: "" };updateRow
                var tmpStr = JSON.stringify(RowTemp);
//                alert(iMovedRowIndex);
//                alert(iCurRowIndex);

                    //修改值
//                    var ed = $('#t').datagrid('getEditor', {index:iCurRowIndex,field:'sequence'});
//                    alert(ed);
//                    $(ed.target).val(iMovedRowIndex);
                  

                gd.datagrid('updateRow', { index: iMovedRowIndex, row: gdData.rows[iCurRowIndex] });
                //gdData.rows[iMovedRowIndex]=gdData.rows[iCurRowIndex];
                //alert(tmpStr);
                var RowChange = JSON.parse(tmpStr);
                gd.datagrid('updateRow', { index: iCurRowIndex, row: RowChange });
                gd.datagrid('selectRow', iMovedRowIndex);
                gd = null;
            
        }

            function EndEdit() {
            var rows = $("#t").datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $("#t").datagrid('endEdit', i);
            }
           mergeCellsByField('t', 'ps1name'); 
        }
        function End(index) {
            $("#t").datagrid('endEdit', index);
               mergeCellsByField('t', 'ps1name'); 
        }
        function addColor() {
            EndEdit();
            $('#t').datagrid('insertRow', { index: 0, row: {} }).datagrid("beginEdit", 0);
        }

        function SaveRow() {

            EndEdit();


            // alert(allRows.length);
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allstr = "";

            var allRows = $('#t').datagrid('getRows');
            allstr = JSON.stringify(allRows);
            //alert(allstr);
            var delRows = $('#t').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delRows);
            //alert(delstr);
            var updateRows = $('#t').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updateRows);
           // alert(updatestr);
            var addRows = $('#t').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addRows);

            $.ajax({
                type: "POST",
                //timeout: 30000,
                url: '../Ashx/Project_Space.ashx',
                data: {
                    'type': 'saveRow',
                    'allstr': allstr,
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'delstr': delstr,
                    'psid': '<%=psid %>'
                },
                success: function (data) {
                    if (data == "success") {
                        $("#t").datagrid('reload');

                        $.messager.show({ title: '提示', msg: '编辑成功！' });

                    }
                    else {
                        $.messager.show({ title: '提示', msg: '编辑失败！' });
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $.messager.show({ title: "提示", msg: XMLHttpRequest.status });
                }
            });

        }

    </script>
    <table id="t">
    </table>
    <div id="tb">
        <a id="addColor" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true"
            onclick="AddRow()">增加</a> <a id="delColor" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-remove',plain:true"
                onclick="delRow()">删除</a> 
                <a id="A1" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:true"
                onclick="MoveRowByPart(-1)">上移</a>
                <a id="saveColor" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:true"
                onclick="MoveRow(-1)">上移</a> <a id="saveColor" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:true"
                onclick="MoveRow(1)">下移</a> <a id="saveColor" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save',plain:true"
                    onclick="SaveRow()">保存</a>

                  
    </div>
</asp:Content>
