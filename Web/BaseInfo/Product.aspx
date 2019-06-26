<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Product" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<%@ Register TagPrefix="product" TagName="Product" Src="../Controls/BaseInfo/Product.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/datagrid-detailview.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            LoadTable();
        })
    </script>

    <!--表格加载-->
    <script type="text/javascript">
        function LoadTable() {
            $("#tt").treegrid({
                url: "../Ashx/Product.ashx?action=list"
                //, queryParams: { "action": "list" }
                , loadMsg: "正在努力加载中..."
                , toolbar: "#tab_toolbar"
                , idField: "ID"
                , treeField: "Code"
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
                        , { title: "(编码)名称", field: "Code", width: 200, sortable: true, rowspan: "2" }
                    ]
                ]
                , columns: [
                    [
                        { title: "分类", field: "ptName", width: 100, sortable: true, rowspan: "2",halign:"center" }
                        , { title: "系列", field: "psName", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "条形码", field: "BarCode", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "名称", field: "Name", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "启用、停用", field: "Enabled", width: 100, sortable: true, rowspan: "2", halign: "center",
                            
                            formatter: function (value, rowIndex, rowData) {
                                //alert(fMoney(value));
                                return Convert(value);
                            }
                         }
                        , { title: "是否安装", field: "Install", width: 100, sortable: true, rowspan: "2", halign: "center" ,
                            formatter: function (value, rowIndex, rowData) {
                                //alert(fMoney(value));
                                return Convert2(value);
                            }
                        }
                        , { title: "型号", field: "Specifications", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "计价方式", field: "ppmNamme", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "单位", field: "bddCaption", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "商品属性", field: "Attribute", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "厂家", field: "sFullName", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "促销价", field: "BarginPrice", width: 100, sortable: true, rowspan: "2",align:"right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "标准进价", field: "StandardPrice", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "参考售价", field: "ReferencePrice", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "标准售价", field: "PriceTag", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "最低售价", field: "MinPrice", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "利润", field: "Profit", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "库存上限", field: "MaxStock", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center"
                        }
                        , { title: "库存下限", field: "MinStock", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center" 
                        }
                        , { title: "库存商品", field: "StockProduct", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center"
                        }
                        , { title: "商品采购", field: "ProductPurchase", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "销售成本", field: "SellingCost", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "销售费用", field: "SellingPrice", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "销售收入", field: "SellingProfit", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "参考售价A", field: "ReferencePriceA", width: 100, sortable: true, rowspan: "2", align: "right",halign:"center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "参考售价B", field: "ReferencePriceB", width: 100, sortable: true, rowspan: "2", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "参考售价C", field: "ReferencePriceC", width: 100, sortable: true, rowspan: "2", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "参考售价D", field: "ReferencePriceD", width: 100, sortable: true, rowspan: "2", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "参考售价E", field: "ReferencePriceE", width: 100, sortable: true, rowspan: "2", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "参考售价F", field: "ReferencePriceF", width: 100, sortable: true, rowspan: "2", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "销售奖励", field: "SellingAward", width: 100, sortable: true, rowspan: "2", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); } 
                        }
                        , { title: "销售提成率", field: "SellingRoyaltyRate", width: 100, sortable: true, rowspan: "2", align: "right", halign: "center"
                        }
                        , { title: "预设仓库", field: "PreinstallStock", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "预设仓区", field: "PreinstallStockArea", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "预设仓位", field: "PreinstallStockSite", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "体积单位", field: "BulkUnit", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "单位体积", field: "UnitBulk", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "重量单位", field: "WeightUnit", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "单位重量", field: "UnitWeight", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "包装件数", field: "PackCount", width: 100, sortable: true, rowspan: "2", align: "right", halign: "center"
                        }
                        , { title: "采购提前期", field: "", width: 100, sortable: true, colspan: "4", halign: "center" }
                        , { title: "运输时间", field: "", width: 100, sortable: true, colspan: "4", halign: "center" }
                        , { title: "尺寸", field: "", width: 100, sortable: true, colspan: "3", halign: "center" }
                        , { title: "颜色", field: "ColorName", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "图片", field: "Image", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "风格", field: "Style", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "材质", field: "Texture", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "规格", field: "Standard", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "形状", field: "Shape", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "创建人", field: "CreateUser", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "创建日期", field: "CreateDate", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "修改人", field: "UpdateUser", width: 100, sortable: true, rowspan: "2", halign: "center" }
                        , { title: "修改日期", field: "UpdateDate", width: 100, sortable: true, rowspan: "2", halign: "center" }
			            , { title: "备注", field: "Remark", width: 350, sortable: true, rowspan: "2", halign: "center"
				            , formatter: function (value, rowData, rowIndex) {
				                return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
				            }
			            }

		            ]
                    , [
                        { title: "陆运", field: "SellingLandTransportation", width: 100, sortable: true, halign: "center" }
                        , { title: "海运", field: "SellingSeaTransportation", width: 100, sortable: true, halign: "center" }
                        , { title: "空运", field: "SellingAirTransportation", width: 100, sortable: true, halign: "center" }
                        , { title: "其他", field: "SellingOtherTransportation", width: 100, sortable: true, halign: "center" }

                        , { title: "陆运", field: "DayLandTransportation", width: 100, sortable: true, halign: "center" }
                        , { title: "海运", field: "DaySeaTransportation", width: 100, sortable: true, halign: "center" }
                        , { title: "空运", field: "DayAirTransportation", width: 100, sortable: true, halign: "center" }
                        , { title: "其他", field: "DayOtherTransportation", width: 100, sortable: true, halign: "center" }

                        , { title: "长", field: "Long", width: 100, sortable: true, halign: "center" }
                        , { title: "宽", field: "Width", width: 100, sortable: true, halign: "center" }
                        , { title: "高", field: "Height", width: 100, sortable: true, halign: "center" }
                    ]
                ],
                onLoadSuccess: function() {
        delete $(this).treegrid('options').queryParams['id'];
    }

                , onClickCell: function (rowIndex, field, value) { $("#tt").datagrid("clearSelections"); }
//                , onHeaderContextMenu: function (e, field) {
//                    e.preventDefault();
//                    if (!cmenu) { createColumnMenu(); }
//                    cmenu.menu("show", { left: e.pageX, top: e.pageY });
				        //                }

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

        //新增
        function add() {
            //art.dialog.open('/BaseInfo/Product_IDE.aspx?action=add', { title: '添加', width: 700, height: 460, lock: true });
            art.dialog({
                content: '<iframe id="frame" src="/BaseInfo/Product_IDE.aspx?action=add" width="700" height="460" frameBorder=0 scrolling="auto" marginheight="1" marginwidth="1" framespacing="0"/>',
                padding: 0,
                title:"增加",
                lock: true
            });

            //            art.dialog({
            //                content: '/BaseInfo/Product_IDE.aspx?action=add',
            //            });
        }

        //快速搜索
        function qsearch(v) {
            $("#tt").datagrid("options").queryParams = { "action": "list", "key": v };
            $("#tt").datagrid("load");
        }


        //编辑
        function edit() {
            var row = whether("编辑")
//            if (row != null) {
//                openDialog("edit", row, "编辑");

//                        }
            art.dialog({
                content: '<iframe src="/BaseInfo/Product_IDE.aspx?action=edit&id=' + row.ID + '" width="700" height="460" frameBorder=0 scrolling="auto" marginheight="1" marginwidth="1" framespacing="0"/>',
                padding: 0,
                title: "编辑",
                lock: true
            });
        }

        function view() {
            var row = whether("查看")
//            if (row != null) {
//                openDialog("view", row, "查看");

//            }

            art.dialog({
                content: '<iframe src="/BaseInfo/Product_IDE.aspx?action=view&id=' + row.ID + '" width="700" height="460" frameBorder=0 scrolling="auto" marginheight="1" marginwidth="1" framespacing="0"/>',
                padding: 0,
                title: "查看",
                lock: true
            });
        }

        function bom() {
            var row = $("#tt").treegrid("getSelected");
            if (row == null) {
                $.messager.show({ title: "系统提示", msg: "请选择要操作的数据。" });
                return;
            }
            else {
                var level = $("#tt").treegrid("getLevel", row.ID);
                if (level == 1) {
                    $.messager.show({ title: "系统提示", msg: "必须选择产品细目，如果没有产品细目请先填加。" });
                    return;
                }
            }
            url = "/BaseInfo/Product_Bom.aspx?id=" + row.ID;
            var showname = row.Name;
            if (showname.length > 5) {
                showname = showname.substring(0, 5) + '...';
            }
            parent.addTab(showname + '【BOM】', url, "", true);
        }

        function del() {
             var selected="";
             $($("#tt").datagrid("getSelections")).each(function () { selected += "'" + this.ID + "',"; });
            selected=selected.substr(0,selected.length-1);
            if(selected==null||selected==""){
              $.messager.show({title:"提示",msg:"请选择你要删除的数据! "});
              return;
            }
            $.messager.confirm("提示","确认删除?",function(r){
              if(r){
                    $.post("../Ashx/Product.ashx",{"action":"dels","cbx_select":selected},function(data){
                     if(data=="ok")
                     {
                       $("#tt").datagrid("reload");
                       $.messager.show({title:"提示",msg:"删除成功。"});
                     }
                     else{
                        $.messager.show({title:"提示",msg:data});
                     }
                    });
              }
            });
        }

        //是否可以复制、编辑、查看
        function whether(value) {
            //var row = $("#tt").datagrid("getSelected");
            var row = $("#tt").treegrid("getSelected");
            if (row == null) {
                $.messager.show({ title: "系统提示", msg: "请选择您要“" + value + "”的数据。" });
            }

            return row;
        }


    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<toolbar:ToolBar runat="server" ID="toolbar1"/>
    <table id="tt"></table>
     <div id="detail" style="width:850px; display:none;" >
        <product:Product ID="product2"  runat="server"/>
    </div>
</asp:Content>
