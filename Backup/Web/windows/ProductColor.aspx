<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProductColor.aspx.cs" Inherits="Maticsoft.Web.windows.ProductColor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        LoadTable();
    });
    function LoadTable() {
        $("#tt").datagrid({
            url: "../Ashx/windows.ashx"
                , queryParams: { "action": "productColor", "id": "<%=id %>", "child": "<%=childs %>" }
                , loadMsg: "正在加载中..."
                , toolbar: "#tb"
                , idField: "ID"
            //, treeField: "CodeName"
                , pageSize: 20
                , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
                , fitColumns: true
                , remoteSort: true
                , pagination: true
                , rownumbers: true
                , singleSelect: false
                 , rowStyler: function (index, row) {
                     return 'height:50px;';
                 }
                , columns: [[
                    { field: "ckb", checkbox: true, width: 5, rowspan: "1" },
                    { field: 'ID', title: 'ID', width: 100,hidden:true },
                    { title: '名称', field: 'Name', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '颜色编号', field: 'ColorCode', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '颜色名称', field: 'ColorName', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '图片', field: 'Image', width: 80, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            if (value != '') {
                                return "<a path='/ProductPic/" + value + "' class='preview'><img alt='' height='45px' src='/ProductPic/" + value + "'></a>";
                            }
                        } 
                    },
                    { title: '数量', field: 'Amount', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '分类', field: 'ptName', width: 100, sortable: true, halign: 'center' },
                    { title: '系列 ', field: 'psName', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '厂家 ', field: 'sFullName', width: 80, sortable: true, halign: 'center', align: 'center' }
                    ]],
            onDblClickRow: function (rowIndex, rowData) {
                art.dialog.data('id', rowData.ID); // 存储数据
                art.dialog.data('code', rowData.Code);
                art.dialog.data('name', rowData.Name);
                art.dialog.data('colorcode', rowData.ColorCode);
                art.dialog.data('colorname', rowData.ColorName);
                art.dialog.data('pccode', rowData.PCCode);
                art.dialog.data('image', rowData.Image);
                art.dialog.data('image1', rowData.Image1);
                art.dialog.data('ptName', rowData.ptName);
                art.dialog.data('psName', rowData.psName);
                art.dialog.data('sFullName', rowData.sFullName);
                art.dialog.close();
            }
        });
    }

    function close1() {
        var rows = $("#tt").datagrid('getSelections');
        var id = "", code = "", name = "", colorcode = "", colorname = "", pccode = "", image = "", image1 = "", ptName = "", psName = "", sFullName="";
        for (var i = 0; i < rows.length; i++) {
            id += rows[i].ID + "|";
            code += rows[i].Code + "|";
            name += rows[i].Name + "|";
            colorcode += rows[i].ColorCode + "|";
            colorname += rows[i].ColorName + "|";
            pccode += rows[i].PCCode + "|";
            image += rows[i].Image + "|";
            image1 += rows[i].Image1 + "|";
            ptName += rows[i].ptName + "|";
            psName += rows[i].psName + "|";
            sFullName += rows[i].sFullName + "|";
        }
        if (rows.length > 0) {
            id = id.substr(0, id.length - 1);
            code = code.substr(0, code.length - 1);
            name = name.substr(0, name.length - 1);
            colorcode = colorcode.substr(0, colorcode.length - 1);
            colorname = colorname.substr(0, colorname.length - 1);
            pccode = pccode.substr(0, pccode.length - 1);
            image = image.substr(0, image.length - 1);
            image1 = image1.substr(0, image1.length - 1);
            ptName = ptName.substr(0, ptName.length - 1);
            psName = psName.substr(0, psName.length - 1);
            sFullName = sFullName.substr(0, sFullName.length - 1);
        }
        art.dialog.data('id', id); // 存储数据
        art.dialog.data('code', code);
        art.dialog.data('name', name);
        art.dialog.data('colorcode', colorcode);
        art.dialog.data('colorname', colorname);
        art.dialog.data('pccode', pccode);
        art.dialog.data('image', image);
        art.dialog.data('image1', image1);
        art.dialog.data('ptName', ptName);
        art.dialog.data('psName', psName);
        art.dialog.data('sFullName', sFullName);
        art.dialog.close();  
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="tt"></table>

<div id="tb" style="padding:5px;height:auto">
		<div style="margin-bottom:5px">
			<a href="#" class="easyui-linkbutton" iconCls="icon-save" plain="true" onclick="close1();">确认</a>
		</div>
		<div style="vertical-align:middle;  padding-bottom:5px;">
			查找:<input id="ss" class="easyui-searchbox" style="width:300px"  
        data-options="prompt:'Please Input Value'"></input>  

		</div>
	</div>

</asp:Content>
