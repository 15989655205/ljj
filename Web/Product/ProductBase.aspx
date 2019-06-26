<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true" CodeBehind="ProductBase.aspx.cs" Inherits="Maticsoft.Web.Product.ProductBase" %>
<%@ Register TagPrefix="toolbar" TagName="ToolBar" Src="../Controls/Toolbar.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/preview.css" rel="stylesheet" type="text/css" />
    <script src="../js/preview1.js" type="text/javascript"></script>
<%-- <link href="../js/themes/default/datagrid1.css" rel="stylesheet" type="text/css" />--%>
<script type="text/javascript">

    $(function () {
        LoadTable();
    })
    </script>

    <!--表格加载-->
    <script type="text/javascript">
        function LoadTable() {
            $("#tt").datagrid({
                url: "../Ashx/Product.ashx?action=plist"
                //, queryParams: { "action": "list" }
                , loadMsg: "正在努力加载中..."
                , toolbar: "#tab_toolbar"
                , idField: "ID"
                //, treeField: "Code"
                , pageSize: 10
                , pageList: [10, 20, 30, 40, 50, 100]
                , fit: true
                , nowrap: false
                //, fitColumns: true
                //, autoRowHeight: false
                //,RowHeight:50,
                , remoteSort: true
                , pagination: true
                , rownumbers: true
                , singleSelect: false
                , rowStyler: function (index, row) {
                    return 'height:50px;';
                }
                , frozenColumns: [
                    [
                        { field: "ckb", checkbox: true, width: 5, rowspan: "1" }
                        , { title: "分类", field: "ptName", width: 80, sortable: true, rowspan: "1", halign: "center"
//                        , formatter: function (value, rowData, rowIndex) {
//                            return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
//                        }
                        }
                        , { title: "系列", field: "psName", width: 80, sortable: true, rowspan: "1", halign: "center"
//                        , formatter: function (value, rowData, rowIndex) {
//                            return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
//                        }
                        }
                        , { title: "编码", field: "Code", width: 120, sortable: true, rowspan: "1", halign: "center"
//                        , formatter: function (value, rowData, rowIndex) {
//                            return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
//                        }
                        }
                        , { title: "名称", field: "Name", width: 100, sortable: true, rowspan: "1", halign: "center"
//                        , formatter: function (value, rowData, rowIndex) {
//                            return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
//                        }
                        }
                        , { title: "图片", field: "Image", width: 100, sortable: true, rowspan: "1", halign: "center",align:"center"
                        , formatter: function (value, rowData, rowIndex) {
                            if (value != '') {
                                return "<a path='/ProductPic/" + value + "' class='preview'><img alt='' height='45px' src='/ProductPic/" + value + "'></a>";
                            }
                        }
                        }
                    ]
                ]
                , columns: [
                    [
                     { title: "颜色", field: "Image1", width: 100, sortable: true, rowspan: "1", halign: "center", align: "center", hidden: true
                        , formatter: function (value, rowData, rowIndex) {
                            if (value != '') {
                                return "<a path='/ProductPic/" + value + "' class='preview'><img alt='' height='45px' src='/ProductPic/" + value + "'></a>";
                            }
                        }
                        },
                          { title: "颜色名称", field: "ColorName", width: 60, sortable: true, rowspan: "1", halign: "center"
//                          , formatter: function (value, rowData, rowIndex) {
//                              return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
//                          }
                          }
                        , { title: "形状", field: "Shape", width: 60, sortable: true, rowspan: "1", halign: "center", hidden: true
//                        , formatter: function (value, rowData, rowIndex) {
//                            return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
//                        }
                        }
//                        , { title: "图片", field: "Image1", width: 100, sortable: true, rowspan: "1", halign: "center",hidden:true }
                       
                        , { title: "促销价", field: "BarginPrice", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "标准进价", field: "StandardPrice", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "参考售价", field: "ReferencePrice", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "标准售价", field: "PriceTag", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "最低售价", field: "MinPrice", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "利润", field: "Profit", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "库存上限", field: "MaxStock", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",hidden:true
                        }
                        , { title: "库存下限", field: "MinStock", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center", hidden: true
                        }
                        , { title: "库存商品", field: "StockProduct", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center", hidden: true
                        }
                        , { title: "商品采购", field: "ProductPurchase", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "销售成本", field: "SellingCost", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "销售费用", field: "SellingPrice", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "销售收入", field: "SellingProfit", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "参考售价A", field: "ReferencePriceA", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "参考售价B", field: "ReferencePriceB", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "参考售价C", field: "ReferencePriceC", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "参考售价D", field: "ReferencePriceD", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "参考售价E", field: "ReferencePriceE", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "参考售价F", field: "ReferencePriceF", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "销售奖励", field: "SellingAward", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center",
                            formatter: function (value, row, index) { return fMoney(value); }
                        }
                        , { title: "销售提成率", field: "SellingRoyaltyRate", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center"
                        }
                         , { title: "风格", field: "Style", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "材质", field: "Texture", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "规格", field: "Standard", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "包装件数", field: "PackCount", width: 60, sortable: true, rowspan: "1", align: "right", halign: "center" }
                         , { title: "单位", field: "bddCaption", width: 40, sortable: true, rowspan: "1", halign: "center"
                             //                        , formatter: function (value, rowData, rowIndex) {
                             //                            return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
                             //                        }
                         }
                        , { title: "厂家", field: "sFullName", width: 100, sortable: true, rowspan: "1", halign: "center"
                            //                        , formatter: function (value, rowData, rowIndex) {
                            //                            return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
                            //                        }
                        }
                        , { title: "计价方式", field: "ppmNamme", width: 80, sortable: true, rowspan: "1", halign: "center"
                            //                        , formatter: function (value, rowData, rowIndex) {
                            //                            return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
                            //                        }
                        }
                        , { title: "预设仓库", field: "PreinstallStock", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "预设仓区", field: "PreinstallStockArea", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "预设仓位", field: "PreinstallStockSite", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "体积单位", field: "BulkUnit", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "单位体积", field: "UnitBulk", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "重量单位", field: "WeightUnit", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "单位重量", field: "UnitWeight", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "创建人", field: "CreateUser", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "创建日期", field: "CreateDate", width: 80, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "修改人", field: "UpdateUser", width: 60, sortable: true, rowspan: "1", halign: "center" }
                        , { title: "修改日期", field: "UpdateDate", width: 80, sortable: true, rowspan: "1", halign: "center" }
			            , { title: "备注", field: "Remark", width: 150, sortable: true, rowspan: "1", halign: "center"
				            , formatter: function (value, rowData, rowIndex) {
				                return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
				            }
			            }

		            ]
                ],
                onLoadSuccess: function (data) {
                    //delete $(this).datagrid('options').queryParams['id'];
                    if (data.rows.length > 0) { mergeCellsByField('tt', 'ptName,psName,Code,Name,Image'); }
                    if ($('a.preview').length) {
                        var img = preloadIm();
                        imagePreview(img);
                    }
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
                        $('#tt').datagrid('hideColumn', item.name);
                        cmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-empty'
                        });
                    } else {
                        $('#tt').datagrid('showColumn', item.name);
                        cmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-ok'
                        });
                    }
                }
            });
            var fields = $('#tt').datagrid('getColumnFields');
            for (var i = 0; i < fields.length; i++) {
                var field = fields[i];
                var col = $('#tt').datagrid('getColumnOption', field);
                cmenu.menu('appendItem', { text: col.title, name: field, iconCls: 'icon-ok' });
            }
        }

        //新增
        function add() {
          
//            art.dialog({
//                content: '<iframe id="frame" src="/BaseInfo/Product_IDE.aspx?action=add" width="700" height="460" frameBorder=0 scrolling="auto" marginheight="1" marginwidth="1" framespacing="0"/>',
//                padding: 0,
//                title: "增加",
//                lock: true
            //            });

            url = "/BaseInfo/Product_IDE.aspx?action=add";
            parent.addTab('新增产品', url);

            
        }

        //快速搜索
        function qsearch(v) {
            $("#tt").datagrid("options").queryParams = { "action": "list", "key": v };
            $("#tt").datagrid("load");
        }


        //编辑
        function edit() {
            var row = whether("编辑");
                   
//            art.dialog({
//                content: '<iframe src="/BaseInfo/Product_IDE.aspx?action=edit&id=' + row.ProductID + '" width="700" height="460" frameBorder=0 scrolling="auto" marginheight="1" marginwidth="1" framespacing="0"/>',
//                padding: 0,
//                title: "编辑",
//                lock: true
            //            });
            var name = row.Name;
                 url = '/BaseInfo/Product_IDE.aspx?action=edit&id=' + row.ProductID ;
                 parent.addTab('编辑产品' + name, url);
        }

        function view() {
            var row = whether("查看");

//            art.dialog({
//                content: '<iframe src="/BaseInfo/Product_IDE.aspx?action=view&id=' + row.ProductID + '" width="700" height="460" frameBorder=0 scrolling="auto" marginheight="1" marginwidth="1" framespacing="0"/>',
//                padding: 0,
//                title: "查看",
//                lock: true
//            });

            url = "/BaseInfo/Product_IDE.aspx?action=view&id=" + row.ProductID ;
            parent.addTab('查看产品' + name, url);
        }

        function bom() {
            var row = $("#tt").datagrid("getSelected");
            if (row == null) {
                $.messager.show({ title: "系统提示", msg: "请选择要操作的数据。" });
                return;
            }
//            else {
//                var level = $("#tt").datagrid("getLevel", row.ID);
//                if (level == 1) {
//                    $.messager.show({ title: "系统提示", msg: "必须选择产品细目，如果没有产品细目请先填加。" });
//                    return;
//                }
//            }
            url = "/Product/Product_Bom.aspx?id=" + row.ID;
            var productname = row.Name;
            if (productname.length > 5) {
                productname = productname.substring(0, 5) + '...';
            }
            var colorname = row.ColorName;
            if (colorname.length > 3) {
                colorname = colorname.substring(0, 3) + '...';
            }
            parent.addTab(productname + '-' + colorname + '【BOM】', url, "", true);
        }

        function del() {
            var selected = "";
            $($("#tt").datagrid("getSelections")).each(function () { selected += "'" + this.ID + "',"; });
            selected = selected.substr(0, selected.length - 1);
            if (selected == null || selected == "") {
                $.messager.show({ title: "提示", msg: "请选择你要删除的数据! " });
                return;
            }
            $.messager.confirm("提示", "确认删除?", function (r) {
                if (r) {
                    $.post("../Ashx/Product.ashx", { "action": "dels", "cbx_select": selected }, function (data) {
                        if (data == "ok") {
                            $("#tt").datagrid("reload");
                            $.messager.show({ title: "提示", msg: "删除成功。" });
                        }
                        else {
                            $.messager.show({ title: "提示", msg: data });
                        }
                    });
                }
            });
        }

        //是否可以复制、编辑、查看
        function whether(value) {
            //var row = $("#tt").datagrid("getSelected");
            var row = $("#tt").datagrid("getSelected");
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

    <script type="text/javascript">
        $(function () {
            $("#t").datagrid({
                url: "../Ashx/Product_ColorType.ashx"
                , queryParams: { "action": "list" }
                , loadMsg: "正在努力加载中..."
                //, toolbar: '#tab_toolbar'

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
                    { title: "颜色图片", field: "Image", width: 150, halign: "center", rowspan: "1",
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
                , onDblClickRow: function (rowIndex, rowData) {
                    //GetColorID();
                    //$("#color").datagrid("appendRow", rowData);




                }
            });
        });


        function GetColorID() {
            var row = $("#color").datagrid("getRows");
            for (var i = 0; i < row.length; i++) {
                if (row != undefined) {
                    alert(row[i].ID);
                }
            }


        }
</script>

</asp:Content>
