<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Maticsoft.Web.windows.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    $(function () {
        LoadTable();
    });
    function LoadTable() {
        $("#tt").datagrid({
            url: "../Ashx/windows.ashx"
                , queryParams: { "action": "product", "id": "<%=id %>", "child": "<%=childs %>" }
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
                    { field: 'ID', title: 'ID', width: 100, hidden: true },
                    { title: '编号', field: 'ProductKey', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '名称', field: 'Name', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '图片', field: 'Image', width: 80, sortable: true, halign: 'center', align: 'center',
                        formatter: function (value, rowData, rowIndex) {
                            if (value != '') {
                                return "<a path='/ProductPic/" + value + "' class='preview'><img alt='' height='45px' src='/ProductPic/" + value + "'></a>";
                            }
                        }
                    },
                    { title: '质地', field: 'Quality', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '阻燃性', field: 'NFK', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '分类', field: 'ptName', width: 100, sortable: true, halign: 'center' },
                    { title: '系列 ', field: 'psName', width: 80, sortable: true, halign: 'center', align: 'center' },
                    { title: '厂家 ', field: 'sFullName', width: 80, sortable: true, halign: 'center', align: 'center' }
                    ]],
            onDblClickRow: function (rowIndex, rowData) {
                art.dialog.data('id', rowData.ID); // 存储数据
                art.dialog.data('key', rowData.ProductKey);
                art.dialog.data('name', rowData.Name);
                art.dialog.data('image', rowData.Image);
                art.dialog.data('quality', rowData.Quality);
                art.dialog.data('nfk', rowData.NFK);
                art.dialog.data('unit', rowData.UnitName);
                art.dialog.close();
            }
        });
    }

    function winclose() {
        var rows = $("#tt").datagrid('getSelections');
        var id = "", key = "", name = "", image = "", quality = "", nfk = "",unit="";
        for (var i = 0; i < rows.length; i++) {
            id += rows[i].ID + ",";
            key += rows[i].ProductKey + "|";
            name += rows[i].Name + "|";
            image += rows[i].Image + "|";
            quality += rows[i].Quality + "|";
            nfk += rows[i].NFK + "|";
            unit += rows[i].UnitName + "|";
        }
        if (rows.length > 0) {
            id = id.substr(0, id.length - 1);
            key = key.substr(0, key.length - 1);
            name = name.substr(0, name.length - 1);
            image = image.substr(0, image.length - 1);
            quality = quality.substr(0, quality.length - 1);
            nfk = nfk.substr(0, nfk.length - 1);
            unit = nfk.substr(0, unit.length - 1);
        }
        art.dialog.data('id', id); // 存储数据
        art.dialog.data('key', key);
        art.dialog.data('name', name);
        art.dialog.data('image', image);
        art.dialog.data('quality', quality);
        art.dialog.data('nfk', nfk);
        art.dialog.data('unit', unit);
        art.dialog.close();
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table id="tt"></table>

<div id="tb" style="padding:5px;height:auto">
		<div style="margin-bottom:5px">
			<a href="#" class="easyui-linkbutton" iconCls="icon-save" plain="true" onclick="winclose();">确认</a>
		</div>
		<div style="vertical-align:middle;  padding-bottom:5px;">
			查找:<input id="ss" class="easyui-searchbox" style="width:300px"  
        data-options="prompt:'Please Input Value'"></input>  

		</div>
	</div>

</asp:Content>
