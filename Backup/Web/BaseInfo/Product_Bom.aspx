<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Product_Bom.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Product_Bom" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../js/datagrid-detailview.js" type="text/javascript"></script>
  <script type="text/javascript">
      var editIndex = undefined;
      $(function () {
          LoadTable();
      });
      function LoadTable() {
          $("#tt").treegrid({
              url: "../Ashx/ProductBom.ashx"
                , queryParams: { "action": "list", "pid": "<%=id %>" }
                , loadMsg: "正在加载中..."
                , toolbar: "#toolbar"
                , idField: "ID"
              , treeField: "Name"
               // , pageSize: 20
               // , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
              , fitColumns: true
              //  , remoteSort: true
              //  , pagination: true
                , rownumbers: true
                , singleSelect: true
                , columns: [
                    [

                    //{ title: '名称', field: 'Name', width: 80, sortable: true, halign: 'center', align: 'center', editor: { type: "window_text", options: { url: '/windows/ProductColor.aspx'} }},
                    { title: '名称', field: 'Name', width: 80, sortable: true, halign: 'center', align: 'center'},
                    { title: '颜色编号', field: 'ColorCode', width: 80, sortable: true, halign: 'center', align: 'center'
                    },
                    { title: '颜色名称', field: 'ColorName', width: 80, sortable: true, halign: 'center', align: 'center'
                    },
                    { title: '数量', field: 'Amount', width: 80, sortable: true, halign: 'center', align: 'center', editor: "numberbox"
                    },
                    { title: '分类', field: 'ptName', width: 100, sortable: true, halign: 'center', },
                    { title: '系列 ', field: 'psName', width: 80, sortable: true, halign: 'center', align: 'center'
                    },
                    { title: '厂家 ', field: 'sFullName', width: 80, sortable: true, halign: 'center', align: 'center'
                    },
                    { field: 'ID', title: 'ID', width: 100, hidden: true }
                    ]
                ],
              onClickRow: function (row) {
                  //EditRow(row.ID);
              }
                , onClickCell: function (rowIndex, field, value) { $("#tt").datagrid("clearSelections"); }
                , onHeaderContextMenu: function (e, field) {
                }
          });
      }

      function endEditing() {
          if (editIndex == undefined) { return true }
          if ($('#tt').treegrid('validateRow', editIndex)) {
             // var ed = $('#tt').datagrid('getEditor', { index: editIndex });
              $('#tt').treegrid('endEdit', editIndex);

              editIndex = undefined;
              return true;
          } else {
              return false;
          }
      }

      function EditRow(index) {
          if (editIndex != index) {
              if (endEditing()) {
                  $('#tt').treegrid('select', index).treegrid('beginEdit', index);
//                  var edt = $('#tt').datagrid('getEditors', index);
//                  edt[1].target.attr('disabled', true);
//                  edt[2].target.attr('disabled', true);
//                  edt[4].target.attr('disabled', true);
//                  edt[5].target.attr('disabled', true);
//                  edt[6].target.attr('disabled', true);
                  editIndex = index;
              } else {
                  $('#tt').treegrid('select', editIndex);
              }
          }
      }

      function EditGrid(row) {
          var node = $('#tt').treegrid('getSelected');
          $('#tt').treegrid('beginEdit', node.ID);
          //var editors = $('#tt').treegrid('getEditors', node.ID);
          editIndex = node.ID;
      }

      function SelectWindow(url) {
          art.dialog.open(url,
    { title: '选择', width: 700, height: 460,
        close: function () {
            var id = art.dialog.data('id');
            var name = art.dialog.data('name');
            var colorcode = art.dialog.data('colorcode');
            var colorname = art.dialog.data('colorname');
            var row = $('#tt').datagrid('getSelected');
            if (row.ID == null || row.ID == 0) {
                //var index = $('#tt').datagrid('getRowIndex', row);
                var edt = $('#tt').datagrid('getEditors', editIndex);
                edt[7].target.val(id);
                edt[0].target.val(name);
                edt[1].target.val(colorcode);
                edt[2].target.val(colorname);
                //                $('#tt').datagrid('updateRow', {
                //                    index: index,
                //                    row: {
                //                        ID: id,
                //                        Name: name,
                //                        ColorCode: colorcode,
                //                        ColorName: colorname
                //                    }
                //                });
                //                editIndex = undefined;
                //                EditRow(index);
            }
        }
    }, false);
          //          art.dialog({
          //              content: '<iframe src="' + url + '" width="700" height="460" frameBorder=0 scrolling="auto" marginheight="1" marginwidth="1" framespacing="0"/>',
          //              padding: 0,
          //              title: "选择",
          //              lock: true,
          //              close: function () {
          //                  var id = art.dialog.data('id');
          //                  var name = art.dialog.data('name');
          //                  var colorcode = art.dialog.data('colorcode');
          //                  var colorname = art.dialog.data('colorname');
          //                  var row = $('#tt').datagrid('getSelected');
          //                  if (row.sid == null || row.sid == 0) {
          //                      //var edt = $('#tt').datagrid('getEditors', imp_editIndex);
          //                      //                      edt[1].target.val($('#uid').combobox('getText'));
          //                      //                      edt[2].target.val($('#un').val());
          //                      //                      edt[5].target.val($('#uid').combobox('getValues'));
          //                      var index = $('#tt').datagrid('getRowIndex',row);
          //                      $('#tt').datagrid('updateRow', {
          //                          index: index,
          //                          row: {
          //                              ID: id,
          //                              Name:name,
          //                              ColorCode: colorcode,
          //                              ColorName:colorname
          //                          }
          //                      });
          //}
          //              }
          //          });
}

       function SelectWindow_add(url) {
           art.dialog.open(url,
            { title: '选择', width: 700, height: 460,
                close: function () {
                    var id = art.dialog.data('id');
                    var name = art.dialog.data('name');
                    var colorcode = art.dialog.data('colorcode');
                    var colorname = art.dialog.data('colorname');

                    $('#tt').treegrid('append', {
                        //parent: node.id,  // the node has a 'id' value that defined through 'idField' property
                        data: [{
                            ID: id,
                            Name: name,
                            ColorCode: colorcode,
                            ColorName: colorname
                        }]
                    });
                    EditRow(id);
                    $('#tt').treegrid('reload', id);
                }
            }, false);
      }

      function add() {
         // if (endEditing()) {
           //   $('#tt').treegrid('append', {}); //, { status: 'P' });
              //editIndex = $('#tt').treegrid('getRows').length - 1;getSelected
              
             // $('#tt').treegrid('selectRow', editIndex).treegrid('beginEdit', editIndex);
         // }
         SelectWindow_add("/windows/ProductColor.aspx");
      }

      function edit(){
      var node = $('#tt').treegrid('getSelected');     
       EditRow(node.ID);
      }

      function del(){
      var node = $('#tt').treegrid('getSelected');     
      $('#tt').treegrid('remove',node.ID);
      }

      function save(){
      }
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="tt"></table>

<div id="toolbar">
<table style="margin:5px; width:100%;">
<tr>
<td style="width:10%;">产品编号：</td>
<td style="width:15%;"><%=model.PCode %></td>
<td style="width:10%;">产品名称：</td>
<td style="width:15%;"><%=model.PName %></td>
<td style="width:10%;"></td>
<td style="width:15%;"></td>
<td style="width:10%;"></td>
<td style="width:15%;"></td>
</tr>
<tr>
<td >颜色编号：</td>
<td ><%=model.ColorCode %></td>
<td >颜色名称：</td>
<td ><%=model.ColorName %></td>
<td ></td>
<td ></td>
<td ></td>
<td ></td>
</tr>
</table>
<toolbar:ToolBar runat="server" ID="toolbar1"/>
</div>
</asp:Content>
