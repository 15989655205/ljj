<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Product_ColorType.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Product_ColorType" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../css/preview.css" rel="stylesheet" type="text/css" />
    <script src="../js/preview.js" type="text/javascript"></script>

    <link href="../css/Uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../js/uploadify/jquery.uploadify.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var editIndex = undefined;
        var productColorID="";
        $(function () {
          

            $('#uploadify').uploadify({
                'debug': 'false',                         //是否调试
                //'buttonClass': 'uploadify-button',           //按钮的样式
                //'buttonCursor':'hand',                 //按钮的Cursor
                'fileTypeDesc': 'Web Files',             //允许文件的描述
                'fileTypeExts': '*.*',  //文件的种类（必须和fileTypeDesc一起使用）*.mp3;*.lrc
                 'multi': false,    //设置是否允许一次选择多个文件，true为允许，false不允许
                'uploader': './Ashx/UploadHandler.ashx',    //处理的后台程序
                'swf': '../js/uploadify/uploadify.swf',          //引入swf文件
                'cancelImg': '../Images/Uploadify/uploadify-cancel.png', //退出的图片
                'auto': false,                          //是否自动上传
                'buttonText': '选择文件',                  //按钮的文本               
                'fileSizeLimit': '0',
                'method': 'post',                      //上传文件的大小               
                'formData': { 'ID': '' },
                'onSelect': function (file) {                  //选择完成后的回调函数                   
                    //alert(file.name);
                },
                'onUploadStart': function (file) {


                    $("#uploadify").uploadify("settings", "formData", { 'ID': productColorID });

                },
                'onUploadComplete': function (file) {       //上传完成的回调事件
                    //alert('上传成功');
                },
                'onUploadSuccess': function (file, response) {			//上传成功的回调事件
                    //                    var type = response.split('-')[0];
                    //                    if (type == "Lrc") {
                    //                        alert("LRC文件");
                    //                    } else if (type == "Song") {
                    //                        $('#fileName').html(response.split('-')[1]);
                    //                    }
                }

            });

            $("#tt").datagrid({
                url: "../Ashx/Product_ColorType.ashx"
                , queryParams: { "action": "list" }
                , loadMsg: "正在努力加载中..."
                , toolbar: '#tab_toolbar'

                , pageSize: 20
                , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
                , fitColumns: true
                , remoteSort: true
                , pagination: true
                , rownumbers: true
                , singleSelect: true
                                , rowStyler: function (index, row) {
                                    return 'height:50px;';
                                }
                , frozenColumns: [[


                 { field: "ckb", checkbox: true, width: 10, rowspan: "1" },

                ]],
                columns: [[

                    { title: "(编码)名称", field: "Code", width: 150, editor: "text" },
                    { title: "颜色名字", field: "Name", width: 150, editor: "text" },
                    { title: "英文名字", field: "Value0", width: 150, editor: "text" },
                    { title: "中文名字", field: "Value1", width: 150, editor: "text" },
                    { title: "颜色图片", field: "Image1", width: 150, halign: "center", rowspan: "1",
                        formatter: function (value, rowData, rowIndex) {
                            if (value != '') {
                                return "<a path='/ProductPic/" + value + "' class='preview'><img alt='' height='45px' src='/ProductPic/" + value + "'></a>";
                            }
                        }
                    },
					{ title: "创建人", field: "CreateUser", width: 150 },
                    { title: "创建日期", field: "CreateDate", width: 200 },
                    { title: "修改人", field: "UpdateUser", width: 150 },
                    { title: "修改日期", field: "UpdateDate", width: 200 },
					{ title: "备注", field: "Remark", width: 150,
					    formatter: function (value, rowData, rowIndex) {
					        return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
					    }
					}
		        ]]
                , onClickRow: function (rowIndex, rowData) {

                    productColorID = $("#tt").datagrid("getSelected").ID;
                    // alert(productColorID);
                    
                    if (rowIndex != editIndex) {
                        End(editIndex);
                    }
                    $('#tt').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
                    editIndex = rowIndex;


                },
                onLoadSuccess: function (data) {
                    //delete $(this).datagrid('options').queryParams['id'];

                    if ($('a.preview').length) {
                        var img = preloadIm();
                        imagePreview(img);
                    }
                }
            });
        });


        function End(index) {
            $("#tt").datagrid('endEdit', index);
        }

        function EndEdit() {
            var rows = $("#tt").datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $("#tt").datagrid('endEdit', i);
            }
        }

        function add() {
            $("#tt").datagrid("insertRow", { index: 0, row: {} });
            editIndex = $('#tt').datagrid('getRows').length;
            $('#tt').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
        }

        function del() {
            var row = $('#tt').datagrid('getSelected');
            if (row == undefined) {
                $.messager.show({ title: "提示", msg: "请选择行" });
            }
            else {
                var rowIndex = $('#tt').datagrid('getRowIndex', row);
                //alert(rowIndex);
                $('#tt').datagrid('deleteRow', rowIndex);
            }
        }

        function save() {
            var ID;
            EndEdit();

            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allstr = "";

            //            var allRows = $('#tt').datagrid('getRows');
            //            allstr = JSON.stringify(allRows);
            //             alert(allstr.length);
            var delRows = $('#tt').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delRows);
            alert(delstr);
            var updateRows = $('#tt').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updateRows);
            //alert(updatestr);
            //alert(updateRows);
            var addRows = $('#tt').datagrid('getChanges', 'inserted');
            addstr = JSON.stringify(addRows);
            alert(addstr);
            $.ajax({
                type: "POST",
                //timeout: 30000,
                url: '../Ashx/Product_ColorType.ashx',
                data: {
                    'action': 'group_edit',
                    'allstr': addstr,
                    'addstr': addstr,
                    'updatestr': updatestr,
                    'ParentID': ID,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        $("#color").datagrid('reload');

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

        function ShowWindow() {
            $("#dd").show();
        }

    </script>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<toolbar:ToolBar runat="server" ID="toolbar1"/>


    <table id="tt"></table>
    <div id="detail" style="display:none"></div>

    <script type="text/javascript">



        function addfile() {
            var row = $("#tt").datagrid("getSelected");
            if (row != null) {
                $('#win').show();
                $('#win').window({
                    title: "文件上传",
                    collapsible: false,
                    minimizable: false,
                    maximizable: false,
                    width: 400,
                    height: 200,
                    modal: true,
                    inline: false,
                    shadow: true
                });
            }
            else {
                $.messager.show({ title: "warn", msg: "请选择行！" });
            }
        }

            </script>
       <div id="win" style="display:none; ">
       <p>&nbsp;</p>
        <p><input  type="file" name="uploadify" id="uploadify" /> &nbsp;</p>
               <a href="javascript:$('#uploadify').uploadify('settings','uploader','/Ashx/UploadHandler.ashx');$('#uploadify').uploadify('upload','*')"   class="easyui-linkbutton" data-options="iconCls:'icon-file',plain:true">确认上传</a> 
        
        
    <div id="fileName"></div>
            </div> 


</asp:Content>
