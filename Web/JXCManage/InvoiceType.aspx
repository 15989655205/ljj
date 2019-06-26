<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="InvoiceType.aspx.cs" Inherits="Maticsoft.Web.JXCManage.InvoiceType" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript">
    $(function () {
        LoadTable();
    });


    
</script>
          <toolbar:ToolBar runat="server" ID="toolbar1"/>
          <table id="dg"></table>
          <script type="text/javascript">
              function LoadTable() {
                  var editIndex;
                  $('#dg').datagrid({
                      url: '../Ashx/StockMessage.ashx?action=list4',
                      loadMsg: "正在努力加载中..."
                , toolbar: "#tab_toolbar"
                , idField: "ID"
                , pageSize: 10
                , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
                , nowrap: false
                , remoteSort: true
                , pagination: true
                , rownumbers: true
                , singleSelect: true,
                      columns: [[
        { field: 'Name', title: '发票类型', width: 150, editor: "text" },
        { field: 'Directions', title: '说明', width: 150, editor: "text" },
        { field: 'remark', title: '备注', width: 150, editor: "text" },
        { field: 'create_person', title: '创建人', width: 150 },
        { field: 'create_date', title: '创建日期', width: 150 },
        { field: 'update_person', title: '更新人', width: 150 },
        { field: 'update_date', title: '更新日期', width: 150 }

    ]],
                      onClickRow: function (rowIndex, rowData) {

                          if (rowIndex != editIndex) {
                              End(editIndex);
                          }
                          $('#dg').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
                          editIndex = rowIndex;
                      }
                  });
              }

              function End(index) {
                  $("#dg").datagrid('endEdit', index);
              }

              function EndEdit() {
                  var rows = $("#dg").datagrid('getRows');
                  for (var i = 0; i < rows.length; i++) {
                      $("#dg").datagrid('endEdit', i);
                  }
              }

              function add() {
                  EndEdit();
                  $('#dg').datagrid('insertRow', { index: 0, row: {} }).datagrid("beginEdit", 0);


              }

              function del() {
                  var row = $('#dg').datagrid('getSelected');
                  if (row == null) {
                      $.messager.show({ title: "warn", msg: "请选择要删除的行！" });

                  }
                  var rowIndex = $('#dg').datagrid('getRowIndex', row);
                  // alert(rowIndex);
                  $('#dg').datagrid('deleteRow', rowIndex);
              }




              function save() {

                  EndEdit();


                  // alert(allRows.length);
                  var delstr = "";
                  var updatestr = "";
                  var addstr = "";
                  var allstr = "";

                  var allRows = $('#dg').datagrid('getRows');
                  allstr = JSON.stringify(allRows);
                  // alert(allstr.length);
                  var delRows = $('#dg').datagrid('getChanges', 'deleted');
                  delstr = JSON.stringify(delRows);
                  //alert(delstr);
                  var updateRows = $('#dg').datagrid('getChanges', 'updated');
                  updatestr = JSON.stringify(updateRows);
                  //alert(updatestr);
                  var addRows = $('#dg').datagrid('getChanges', 'inserted');
                  addstr = JSON.stringify(addRows);

                  $.ajax({
                      type: "POST",
                      //timeout: 30000,
                      url: '../Ashx/StockMessage.ashx',
                      data: {
                          'action': 'save4',
                          'allstr': addstr,
                          'addstr': addstr,
                          'updatestr': updatestr,
                          'delstr': delstr
                      },
                      success: function (data) {
                          if (data == "success") {
                              $("#dg").datagrid('reload');

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

          <div style=" width:500px;"> </div>
</asp:Content>
