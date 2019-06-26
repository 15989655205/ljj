<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Product111.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Product111" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript">

        $(function () {
            LoadTable();
        })
    </script>

    <!--表格加载-->
    <script type="text/javascript">
        function LoadTable() {
            $("#tt").treegrid({
                url: "../Ashx/Product.ashx"
                , queryParams: { "action": "list" }
                , loadMsg: "正在努力加载中..."
                , toolbar: "#tab_toolbar"
                , idField: "ID"
                , treeField: "CodeName"
                , pageSize: 20
                , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
                //, fitColumns: true
                , remoteSort: true
                , pagination: true
                , rownumbers: true
                , singleSelect: false
                , frozenColumns: [
                    [
                        { field: "ckb", checkbox: true, width: 5, rowspan: "2" }                       
                        , { title: "(编码)名称", field: "CodeName", width: 100, sortable: true, rowspan: "2" }
                    ]
                ]
                , columns: [
                    [
                        { title: "类别", field: "TypeID", width: 100, sortable: true, rowspan: "2" }
                        , { title: "系列", field: "SeriesID", width: 100, sortable: true, rowspan: "2" }                       
                        , { title: "条形码", field: "BarCode", width: 100, sortable: true, rowspan: "2" }
                        , { title: "名称", field: "Name", width: 100, sortable: true, rowspan: "2" }
                        , { title: "启用、停用", field: "Enabled", width: 100, sortable: true, rowspan: "2" }
                        , { title: "是否安装", field: "Install", width: 100, sortable: true, rowspan: "2" }
                        , { title: "型号", field: "Specifications", width: 100, sortable: true, rowspan: "2" }
                        , { title: "计价方式", field: "ValuationMethods", width: 100, sortable: true, rowspan: "2" }
                        , { title: "单位", field: "Unit", width: 100, sortable: true, rowspan: "2" }
                        , { title: "商品属性", field: "Attribute", width: 100, sortable: true, rowspan: "2" }
                        , { title: "厂家", field: "Manufacturer", width: 100, sortable: true, rowspan: "2" }
                        , { title: "促销价", field: "BarginPrice", width: 100, sortable: true, rowspan: "2" }
                        , { title: "标准进价", field: "StandardPrice", width: 100, sortable: true, rowspan: "2" }
                        , { title: "参考售价", field: "ReferencePrice", width: 100, sortable: true, rowspan: "2" }
                        , { title: "标准售价", field: "PriceTag", width: 100, sortable: true, rowspan: "2" }
                        , { title: "最低售价", field: "MinPrice", width: 100, sortable: true, rowspan: "2" }
                        , { title: "利润", field: "Profit", width: 100, sortable: true, rowspan: "2" }
                        , { title: "库存上限", field: "MaxStock", width: 100, sortable: true, rowspan: "2" }
                        , { title: "库存下限", field: "MinStock", width: 100, sortable: true, rowspan: "2" }
                        , { title: "库存商品", field: "StockProduct", width: 100, sortable: true, rowspan: "2" }
                        , { title: "商品采购", field: "ProductPurchase", width: 100, sortable: true, rowspan: "2" }
                        , { title: "销售成本", field: "SellingCost", width: 100, sortable: true, rowspan: "2" }
                        , { title: "销售费用", field: "SellingPrice", width: 100, sortable: true, rowspan: "2" }
                        , { title: "销售收入", field: "SellingProfit", width: 100, sortable: true, rowspan: "2" }
                        , { title: "参考售价A", field: "ReferencePriceA", width: 100, sortable: true, rowspan: "2" }
                        , { title: "参考售价B", field: "ReferencePriceB", width: 100, sortable: true, rowspan: "2" }
                        , { title: "参考售价C", field: "ReferencePriceC", width: 100, sortable: true, rowspan: "2" }
                        , { title: "参考售价D", field: "ReferencePriceD", width: 100, sortable: true, rowspan: "2" }
                        , { title: "参考售价E", field: "ReferencePriceE", width: 100, sortable: true, rowspan: "2" }
                        , { title: "参考售价F", field: "ReferencePriceF", width: 100, sortable: true, rowspan: "2" }
                        , { title: "销售奖励", field: "SellingAward", width: 100, sortable: true, rowspan: "2" }
                        , { title: "销售提成率", field: "SellingRoyaltyRate", width: 100, sortable: true, rowspan: "2" }
                        , { title: "预设仓库", field: "PreinstallStock", width: 100, sortable: true, rowspan: "2" }
                        , { title: "预设仓区", field: "PreinstallStockArea", width: 100, sortable: true, rowspan: "2" }
                        , { title: "预设仓位", field: "PreinstallStockSite", width: 100, sortable: true, rowspan: "2" }
                        , { title: "体积单位", field: "BulkUnit", width: 100, sortable: true, rowspan: "2" }
                        , { title: "单位体积", field: "UnitBulk", width: 100, sortable: true, rowspan: "2" }
                        , { title: "重量单位", field: "WeightUnit", width: 100, sortable: true, rowspan: "2" }
                        , { title: "单位重量", field: "UnitWeight", width: 100, sortable: true, rowspan: "2" }
                        , { title: "包装件数", field: "PackCount", width: 100, sortable: true, rowspan: "2" }
                        , { title: "采购提前期", field: "", width: 100, sortable: true, colspan: "4" }
                        , { title: "运输时间", field: "", width: 100, sortable: true, colspan: "4" }
                        , { title: "尺寸", field: "", width: 100, sortable: true, colspan: "3" }
                        , { title: "颜色", field: "Color", width: 100, sortable: true, rowspan: "2" }
                        , { title: "图片", field: "Image", width: 100, sortable: true, rowspan: "2" }
                        , { title: "风格", field: "Style", width: 100, sortable: true, rowspan: "2" }
                        , { title: "材质", field: "Texture", width: 100, sortable: true, rowspan: "2" }
                        , { title: "规格", field: "Standard", width: 100, sortable: true, rowspan: "2" }
                        , { title: "形状", field: "Shape", width: 100, sortable: true, rowspan: "2" }
                        , { title: "创建人", field: "CreateUser", width: 100, sortable: true, rowspan: "2" }
                        , { title: "创建日期", field: "CreateDate", width: 100, sortable: true, rowspan: "2" }
                        , { title: "修改人", field: "UpdateUser", width: 100, sortable: true, rowspan: "2" }
                        , { title: "修改日期", field: "UpdateDate", width: 100, sortable: true, rowspan: "2" }
			            , { title: "备注", field: "Remark", width: 350, sortable: true, rowspan: "2"
				            , formatter: function (value, rowData, rowIndex) {
				                return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
				            }
			            }

		            ]
                    , [
                        { title: "陆运", field: "SellingLandTransportation", width: 100, sortable: true }
                        , { title: "海运", field: "SellingSeaTransportation", width: 100, sortable: true }
                        , { title: "空运", field: "SellingAirTransportation", width: 100, sortable: true }
                        , { title: "其他", field: "SellingOtherTransportation", width: 100, sortable: true }

                        , { title: "陆运", field: "DayLandTransportation", width: 100, sortable: true }
                        , { title: "海运", field: "DaySeaTransportation", width: 100, sortable: true }
                        , { title: "空运", field: "DayAirTransportation", width: 100, sortable: true }
                        , { title: "其他", field: "DayOtherTransportation", width: 100, sortable: true }

                        , { title: "长", field: "Long", width: 100, sortable: true }
                        , { title: "宽", field: "Width", width: 100, sortable: true }
                        , { title: "高", field: "Height", width: 100, sortable: true }
                    ]
                ]
                , onClickCell: function (rowIndex, field, value) { $("#tt").datagrid("clearSelections"); }
                , onHeaderContextMenu: function (e, field) {
                    e.preventDefault();
                    if (!cmenu) { createColumnMenu(); }
                    cmenu.menu("show", { left: e.pageX, top: e.pageY });
                }
            });
        }
    </script>

    <!--表格右键-->
    <script type="text/javascript">
        var cmenu;
        function createColumnMenu() {
            cmenu = $('<div/>').appendTo('body');
            cmenu.menu({
                onClick: function (item) {
                    if (item.iconCls == 'icon-ok') {
                        $('#tt').treegrid('hideColumn', item.name);
                        cmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-empty'
                        });
                    } else {
                        $('#tt').treegrid('showColumn', item.name);
                        cmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-ok'
                        });
                    }
                }
            });
            var fields = $('#tt').treegrid('getColumnFields');
            for (var i = 0; i < fields.length; i++) {
                var field = fields[i];
                var col = $('#tt').treegrid('getColumnOption', field);
                cmenu.menu('appendItem', { text: col.title, name: field, iconCls: 'icon-ok' });
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table id="tt"></table>

</asp:Content>
