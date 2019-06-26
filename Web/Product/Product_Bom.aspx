<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true"
    CodeBehind="Product_Bom.aspx.cs" Inherits="Maticsoft.Web.Product.Product_Bom" %>

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
              url: "../Ashx/ProductBom.ashx?action=list&pid=<%=id %>"
              , queryParams: {  "id": "<%=id %>" }
              //loader: function () { return eval('({"total": 2, "rows": [{ "ID": "5", "CID": "5", "PID": "1", "ColorID": "", "Path": "", "Amount": "1.0000", "pcid": "1", "Name": "Shop", "Code": "BAA.0301.04003", "ptName": "布帘", "psName": "系列4", "sFullName": "智创信息科技有限公司", "ColorCode": "#Yellow", "ColorName": "黄色", "_parentId": "1", "state": "closed" }, { "ID": "6", "CID": "4", "PID": "1", "ColorID": "", "Path": "", "Amount": "3.0000", "pcid": "1", "Name": "Shop1", "Code": "AAC.0301.01003", "ptName": "棉地毯", "psName": "系列1", "sFullName": "智创信息科技有限公司", "ColorCode": "#Green", "ColorName": "绿色", "_parentId": "1", "state": "closed"}] })'); }
                , loadMsg: "正在加载中..."
                , toolbar: "#toolbar"
                , idField: "ID"
              , treeField: "PCCode"
              // , pageSize: 20
              //, pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
              , fitColumns: true
              ,striped:true
              //  , remoteSort: true
              //  , pagination: true
                , rownumbers: true
                , singleSelect: true
                , rowStyler: function (index, row) {
                    return 'height:50px;';
                }
                , columns: [
                    [

              //{ title: '名称', field: 'Name', width: 80, sortable: true, halign: 'center', align: 'center', editor: { type: "window_text", options: { url: '/windows/ProductColor.aspx'} }},
                    {field: "ckb", checkbox: true, width: 5 },
                    { title: '细目编号', field: 'PCCode', width: 150, sortable: true, halign: 'center' },
                    { title: '产品图片', field: 'Image', width: 80, sortable: true, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value != '') {
                            return "<a path='/ProductPic/" + value + "' class='preview'><img alt='' height='45px' src='/ProductPic/" + value + "'></a>";
                        }
                    } 
                    },
                    { title: '产品颜色', field: 'Image1', width: 80, sortable: true, halign: 'center', align: 'center', formatter: function (value, rowData, rowIndex) {
                        if (value != '') {
                            return "<a path='/ProductPic/" + value + "' class='preview'><img alt='' height='45px' src='/ProductPic/" + value + "'></a>";
                        }
                    } 
                    },
                    { title: '产品编号', field: 'Code', width: 80, sortable: true, halign: 'center' },
                    { title: '产品名称', field: 'Name', width: 80, sortable: true, halign: 'center' },
                    { title: '颜色编号', field: 'ColorCode', width: 80, sortable: true, halign: 'center', align: 'center'
                    },
                    { title: '颜色名称', field: 'ColorName', width: 80, sortable: true, halign: 'center', align: 'center'
                    },
                    { title: '数量', field: 'Amount', width: 80, sortable: true, halign: 'center', align: 'center', editor: { type: "numberbox", options: { required: true,precision:4} }
                    },
                    { title: '分类', field: 'ptName', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '系列 ', field: 'psName', width: 80, sortable: true, halign: 'center', align: 'center'
                    },
                    { title: '厂家 ', field: 'sFullName', width: 80, sortable: true, halign: 'center', align: 'center'
                    },
                    { field: 'ID', title: 'ID', width: 100, hidden: true }
                    ,
                    { field: 'PID', title: 'PID', width: 100, hidden: true }
                    ,
                    { field: 'CID', title: 'CID', width: 100, hidden: true }
                    ]
                ],
              onClickRow: function (row) {
                  EditRow(row.ID);
              }
                , onClickCell: function (rowIndex, field, value) { $("#tt").datagrid("clearSelections"); }

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
          var level = $('#tt').treegrid('getLevel', index);
          if (level == 1) {
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
                    //alert(art.dialog.data('id'));
                    if (art.dialog.data('id') != undefined && art.dialog.data('id') != '') {
                        var id = art.dialog.data('id').split('|');
                        var code = art.dialog.data('code').split('|');
                        var name = art.dialog.data('name').split('|');
                        var colorcode = art.dialog.data('colorcode').split('|');
                        var colorname = art.dialog.data('colorname').split('|');
                        var pccode = art.dialog.data('pccode').split('|');
                        var image = art.dialog.data('image').split('|');
                        var image1 = art.dialog.data('image1').split('|');
                        var ptName = art.dialog.data('ptName').split('|');
                        var psName = art.dialog.data('psName').split('|');
                        var sFullName = art.dialog.data('sFullName').split('|');

                        for (var i = 0; i < id.length; i++) {
                            if (id[i] != '') {
                                $('#tt').treegrid('append', {
                                    //parent: node.id,  // the node has a 'id' value that defined through 'idField' property
                                    data: [{
                                        ID: -id[i],
                                        CID: id[i],
                                        PID: "<%=id %>",
                                        PCCode:pccode[i],
                                        Image:image[i],
                                        Image1: image1[i],
                                        Code:code[i],
                                        Name: name[i],
                                        ColorCode: colorcode[i],
                                        ColorName: colorname[i],
                                        ptName: ptName[i],
                                        psName: psName[i],
                                        sFullName: sFullName[i]
                                    }]
                                });
                            }
                        }
                        EditRow(-id[0]);
                        $('#tt').treegrid('reload', -id[0]);
                    }
                }
            }, false);
       }

      function add() {
         // if (endEditing()) {
           //   $('#tt').treegrid('append', {}); //, { status: 'P' });
              //editIndex = $('#tt').treegrid('getRows').length - 1;getSelected
              
             // $('#tt').treegrid('selectRow', editIndex).treegrid('beginEdit', editIndex);
          // }
          art.dialog.data('id', '');
          art.dialog.data('code', '');
          art.dialog.data('name', '');
          art.dialog.data('colorcode', '');
          art.dialog.data('colorname', '');
          art.dialog.data('pccode', '');
          art.dialog.data('image', '');
          art.dialog.data('image1', '');
          art.dialog.data('ptName', '');
          art.dialog.data('psName', '');
          art.dialog.data('sFullName', '');
          var roots = $('#tt').treegrid('getRoots', '');
          
          var ids = "";
          for (var i = 0; i < roots.length; i++) {
              ids += roots[i].CID + ",";
              
          }
          if (ids.length > 0) {
              ids = ids.substr(0, ids.length - 1);
          }
         SelectWindow_add("/windows/ProductColor.aspx?id=<%=id %>&child="+ids);
      }

      function edit(){
      var node = $('#tt').treegrid('getSelected');     
       EditRow(node.ID);
      }

      function del(){
      var node = $('#tt').treegrid('getSelected');     
      $('#tt').treegrid('remove',node.ID);
      }

      function save() {
          if (endEditing()) {
              var rows = $('#tt').treegrid('getRoots');
              var allstr = "";
              allstr = JSON.stringify(rows);
              $.ajax({
                  type: "POST",
                  timeout: 30000, //超时时间：30秒
                  url: '../Ashx/ProductBom.ashx',
                  data: {
                      'action': 'bomSave',
                      'allstr': allstr,
                      'pid': '<%=id %>'
                  },
                  success: function (data) {
                      if (data == "success") {
                          $('#tt').treegrid("reload");
                          $.messager.show({ title: '提示', msg: "编辑成功！" });
                      }
                      else {
                          $.messager.show({ title: '错误提示', msg: (data == "success" ? "保存成功" : data) });
                      }
                  },
                  error: function (XMLHttpRequest, textStatus, errorThrown) {
                      $.messager.show({ title: '错误提示', msg: XMLHttpRequest.status });
                  }
              });
          }
      }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tt">
    </table>
    <div id="toolbar">
        <table style="margin: 5px;">
            <tr>
                <td style="">
                    产品编号：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <%=model.Code %>
                </td>
                <td style="">
                    产品名称：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <%=model.Name %>
                </td>
                <td style="">
                    分类：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <%=model.ptName %>
                </td>
                <td style="">
                    系列：
                </td>
                <td style="color: blue; padding-right: 20px;">
                    <%=model.psName %>
                </td>
            </tr>
            <tr>
                <td>
                    颜色编号：
                </td>
                <td style="color: blue;">
                    <%=model.ColorCode %>
                </td>
                <td>
                    颜色名称：
                </td>
                <td style="color: blue;">
                    <%=model.ColorName %>
                </td>
                <td>
                </td>
                <td style="color: blue;">
                </td>
                <td>
                </td>
                <td style="color: blue;">
                </td>
            </tr>
        </table>
        <toolbar:ToolBar runat="server" ID="toolbar1" />
    </div>
</asp:Content>
