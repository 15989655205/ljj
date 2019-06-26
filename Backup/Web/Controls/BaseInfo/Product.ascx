<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Product.ascx.cs" Inherits="Maticsoft.Web.Controls.BaseInfo.Product" %>
<!--控件加载事件-->
<script type="text/javascript">
    var WrokID;
    var sumbitUrl = "";
    var loadflag = true;
    var UN;
    var ABBR;
    var group_editIndex = undefined;
    var group_isEdit = false;
    var group_pssid;
    var oldRows;
    var getRow;
</script>
<!--弹出表单-->
<script type="text/javascript">
    function openDialog(type, row, title) {
        getRow = row;
        if (loadflag) { setControls(); loadflag = false; }
        switch (type) {
            case "add": sumbitUrl = "../Ashx/Product.ashx?action=add"; ClearControl(); break;
            case "copy": sumbitUrl = "../Ashx/Product.ashx?action=copy"; showData(row, type); break;
            case "edit": sumbitUrl = "../Ashx/Product.ashx?action=edit"; showData(row, type); Show(row, type); break;
            case "view": showData(row); Show(row ,type); break;
            default: break;
        }
        if (art.dialog.list["dialog"] == null) {
            art.dialog({
                content: document.getElementById("detail"),
                id: "dialog",
                title: title,
                lock: type != "view",
                padding: "0px 0px 0px 0px",
                background: "#c3c3c3",
                close: function () { },
                button: [
                    { name: "保存", callback: function () { save(); return false; }, focus: true },
                    { name: "关闭" }
                ]
            });
        }

        ControlReadonly(type == "view");
        
    }
</script>
<!--控件初始化-->
<script type="text/javascript">

    function setControls() {

        $("#ValuationMethods").combobox({ url: "../Ashx/ProductDetail.ashx?type=ValuationMethods", valueField: "value", textField: "text", required: true });
        $("#Unit").combobox({ url: "../Ashx/ProductDetail.ashx?type=Unit", valueField: "value", textField: "text", required: true });
        $("#SeriesID").combobox({ url: "../Ashx/ProductDetail.ashx?type=SeriesID", valueField: "value", textField: "text", required: true });
        $("#Manufacturer").combobox({ url: "../Ashx/ProductDetail.ashx?type=Manufacturer", valueField: "value", textField: "text", required: true });
        $("#TypeID").combotree({ url: "../Ashx/ProductDetail.ashx?type=TypeID", required: true });
        //        $("#txtEducation").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=education", valueField: "value", textField: "text" });
        //        $("#txtDegree").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=degree", valueField: "value", textField: "text" });
        //        $("#txtStateEmployees").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=stateEmployees", valueField: "value", textField: "text", required: true });

        //        $("#txtAppRoleID").combobox({ url: "../Ashx/BaseDictionaryDetail.ashx?type=approle", valueField: "value", textField: "text", required: true });

        //        $("#txtDeptID").combotree({ url: "../Ashx/BaseDictionaryDetail.ashx?type=dept", required: true });
    }
</script>
<!--把值赋予表单-->
<script type="text/javascript">
    function showData(row, type) {
        $("#ID").val(row.ID);
        $("#lblCode").val(row.CodeName);
        $("#BarCode").val(row.BarCode);
        $("#Name").val(row.Name);
        $("#Specifications").val(row.Specifications);
        $("#ValuationMethods").combobox("setValue", row.ppmID).val();   //计价方式
       
        $("#Unit").combobox("setValue", row.bddValue); //单位
        $("#TypeID").combotree("setValue", row.ptID);        //----所属分类
        $("#SeriesID").combobox("setValue", row.psID);  //系列
        $("#Attribute").val(row.Attribute);
        $("#Manufacturer").combobox("setValue", row.sID); //厂家
        $("#BarginPrice").val(row.BarginPrice);
        $("#StandardPrice").val(row.StandardPrice);
        $("#MaxStock").val(row.MaxStock);
        $("#MinStock").val(row.MinStock);
        $("#ReferencePrice").val(row.ReferencePrice);
        $("#Profit").val(row.Profit);
        $("#Shape").val(row.Shape);

        $("#Texture").val(row.Texture);
        $("#Style").val(row.Style);
        $("#Standard").val(row.Standard);
        $("#StockProduct").val(row.StockProduct);
        $("#ProductPurchase").val(row.ProductPurchase);
        $("#SellingCost").val(row.SellingCost);
        $("#SellingPrice").val(row.SellingPrice);
        $("#SellingProfit").val(row.SellingProfit);
        $("#ReferencePriceA").val(row.ReferencePriceA);
        $("#ReferencePriceB").val(row.ReferencePriceB);
        $("#ReferencePriceC").val(row.ReferencePriceC);
        $("#ReferencePriceD").val(row.ReferencePriceD);
        $("#ReferencePriceE").val(row.ReferencePriceE);
        $("#ReferencePriceF").val(row.ReferencePriceF);
        $("#SellingAward").val(row.SellingAward);
        $("#SellingRoyaltyRate").val(row.SellingRoyaltyRate);
        $("#PreinstallStock").val(row.PreinstallStock);
        $("#PreinstallStockArea").val(row.PreinstallStockArea);
        $("#BulkUnit").val(row.BulkUnit);
        $("#UnitBulk").val(row.UnitBulk);
        $("#PreinstallStockSite").val(row.PreinstallStockSite);
        $("#WeightUnit").val(row.WeightUnit);
        $("#UnitWeight").val(row.UnitWeight);
        $("#PackCount").val(row.PackCount);
        $("#SellingLandTransportation").val(row.SellingLandTransportation);
        $("#SellingSeaTransportation").val(row.SellingSeaTransportation);
        $("#SellingAirTransportation").val(row.SellingAirTransportation);
        $("#SellingOtherTransportation").val(row.SellingOtherTransportation);
        $("#DayLandTransportation").val(row.DayLandTransportation);
        $("#DaySeaTransportation").val(row.DaySeaTransportation);
        $("#DayAirTransportation").val(row.DayAirTransportation);
        $("#DayOtherTransportation").val(row.DayOtherTransportation);
        $("#Long").val(row.Long);
        $("#Width").val(row.Width);
        $("#Height").val(row.Height);
        
        //document.getElementById("Height").readOnly = true;
    }
</script>
<!--是否可编辑表单-->
<script type="text/javascript">
    function ControlReadonly(flag) {
        document.getElementById("ID").disabled =
        document.getElementById("lblCode").disabled =
        document.getElementById("BarCode").disabled =
        document.getElementById("Name").readOnly =
        document.getElementById("Specifications").readOnly =
        document.getElementById("Attribute").readOnly =
        document.getElementById("BarginPrice").readOnly =
        document.getElementById("StandardPrice").readOnly =
        document.getElementById("MaxStock").readOnly =
        document.getElementById("MinStock").readOnly =
        document.getElementById("ReferencePrice").readOnly =
        document.getElementById("Profit").readOnly =
        document.getElementById("Shape").readOnly =
        document.getElementById("Texture").readOnly =
        document.getElementById("Style").readOnly =
        document.getElementById("Standard").readOnly =
        document.getElementById("StockProduct").readOnly =
        document.getElementById("ProductPurchase").readOnly =
        document.getElementById("SellingCost").readOnly =
        document.getElementById("SellingPrice").readOnly =
        document.getElementById("SellingProfit").readOnly =
        document.getElementById("ReferencePriceA").readOnly =
        document.getElementById("ReferencePriceB").readOnly =
        document.getElementById("ReferencePriceC").readOnly =
        document.getElementById("ReferencePriceD").readOnly =
        document.getElementById("ReferencePriceE").readOnly =
        document.getElementById("ReferencePriceF").readOnly =
        document.getElementById("SellingAward").readOnly =
        document.getElementById("SellingRoyaltyRate").readOnly =
        document.getElementById("PreinstallStock").readOnly =
        document.getElementById("PreinstallStockArea").readOnly =
        document.getElementById("BulkUnit").readOnly =
        document.getElementById("UnitBulk").readOnly =
        document.getElementById("PackCount").readOnly =
        document.getElementById("SellingLandTransportation").readOnly =
        document.getElementById("SellingSeaTransportation").readOnly =
        document.getElementById("SellingAirTransportation").readOnly =
        document.getElementById("SellingOtherTransportation").readOnly =
        document.getElementById("DayLandTransportation").readOnly =
        document.getElementById("DaySeaTransportation").readOnly =
        document.getElementById("DayAirTransportation").readOnly =
        document.getElementById("DayOtherTransportation").readOnly =
        document.getElementById("Long").readOnly =
        document.getElementById("Width").readOnly =
        document.getElementById("Height").readOnly = flag;
        
        var able = flag ? "disable" : "enable";
        $("#ValuationMethods").combotree(able);
        $("#Unit").combobox(able);
        $("#TypeID").combotree(able);
        $("#SeriesID").combobox(able);
        $("#Manufacturer").combobox(able);
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
    }
</script>
<!--表单保存事件-->
<script type="text/javascript">

    function ButtonLock(flag) {
        art.dialog.list["dialog"].button({ name: "保存", disabled: flag }, { name: "关闭", disabled: flag });
    }

    function save() {
        $("#BarginPrice").keyup(function () {
            //如果输入非数字，则替换为''，如果输入数字，则在每4位之后添加一个空格分隔
            this.value = this.value.replace(/[^\d]/g, '').replace(/(\d{4})(?=\d)/g, "$1 ");
        });
        if (jQuery('#ff').validationEngine('validate')) {
            OpenLoading_me("Processing,please wait...");

            /*************基本资料***********/
            var ID = $("#ID").val();
            var BarCode = $("#BarCode").val();  //条形码
            var Name = $("#Name").val(); //商品名称
            var Specifications = $("#Specifications").val(); //规格型号
            var ValuationMethods = $("#ValuationMethods").combobox("getValue"); //计费方式
            //var ValuationMethods = $("#ValuationMethods option:selected").text(); //计费方式
            //alert(ValuationMethods);
            //var Unit = $("#Unit option:selected").val();  //单位
            var Unit = $("#Unit").combobox("getValue");
            //var t = $('#TypeID').combotree('tree'); //         get the tree object
            //var TypeID = (t.tree('getSelected')).id; 	// 所属分类get selected node
            var TypeID = $('#TypeID').combotree("getValue");
            //alert(TypeID);
            var SeriesID = $("#SeriesID").combobox("getValue"); //系列
            var Attribute = $("#Attribute").val(); //属性
            var Manufacturer = $("#Manufacturer").combobox("getValue"); //厂家
            var BarginPrice = $("#BarginPrice").val(); //促销价
            var StandardPrice = $("#StandardPrice").val(); //标准进价
            var MaxStock = $("#MaxStock").val(); //库存上限
            var MinStock = $("#MinStock").val(); //库存下限
            var ReferencePrice = $("#ReferencePrice").val(); //参考价格
            var PriceTag = $("#PriceTag").val(); //标价
            var MinPrice = $("#MinPrice").val(); //最低售价
            var Profit = $("#Profit").val(); //利润
            var StockProduct = $("#StockProduct").val(); //库存商品
            var ProductPurchase = $("#ProductPurchase").val(); //商品采购
            var SellingCost = $("#SellingCost").val(); //销售成本
            var SellingPrice = $("#SellingPrice").val()//销售费用
            var SellingProfit = $("#SellingProfit").val(); //销售收入

            /*************预设资料***********/
            var ReferencePriceA = $("#ReferencePriceA").val();
            var ReferencePriceB = $("#ReferencePriceB").val();
            var ReferencePriceC = $("#ReferencePriceC").val();
            var ReferencePriceD = $("#ReferencePriceD").val();
            var ReferencePriceE = $("#ReferencePriceE").val();
            var ReferencePriceF = $("#ReferencePriceF").val();
            var SellingAward = $("#SellingAward").val();
            var SellingRoyaltyRate = $("#SellingRoyaltyRate").val();
            var PreinstallStock = $("#PreinstallStock").val();
            var PreinstallStockArea = $("#PreinstallStockArea").val();
            var BulkUnit = $("#BulkUnit").val();
            var Bulk = $("#Bulk").val();
            var PreinstallStockSite = $("#PreinstallStockSite").val();
            var WeightUnit = $("#WeightUnit").val();
            var Weight = $("#Weight").val();
            var PackCount = $("#PackCount").val();
            var SellingLandTransportation = $("#SellingLandTransportation").val();
            var DayLandTransportation = $("#DayLandTransportation").val();
            var Long = $("#Long").val();
            var SellingSeaTransportation = $("#SellingSeaTransportation").val();
            var DaySeaTransportation = $("#DaySeaTransportation").val();
            var Width = $("#Width").val();
            var SellingOtherTransportation = $("#SellingOtherTransportation").val();
            var DayOtherTransportation = $("#DayOtherTransportation").val();
            var Height = $("#Height").val();


            $.ajax({
                type: "Post",
                url: "/Ashx/Product.ashx?action=edit",
                data: {
                    /*************基本资料***********/
                    ID: ID,
                    BarCode: BarCode,
                    Name: Name,
                    Specifications: Specifications,
                    ValuationMethods: ValuationMethods,
                    Unit: Unit,
                    TypeID: TypeID,
                    SeriesID: SeriesID,
                    Attribute: Attribute,
                    Manufacturer: Manufacturer,
                    BarginPrice: BarginPrice,
                    StandardPrice: StandardPrice,
                    MaxStock: MaxStock,
                    MinStock: MinStock,
                    ReferencePrice: ReferencePrice,
                    PriceTag: PriceTag,
                    MinPrice: MinPrice,
                    Profit: Profit,
                    StockProduct: StockProduct,
                    ProductPurchase: ProductPurchase,
                    SellingCost: SellingCost,
                    SellingPrice: SellingPrice,
                    SellingProfit: SellingProfit,
                    /*************预设资料***********/
                    ReferencePriceA: ReferencePriceA,
                    ReferencePriceB: ReferencePriceB,
                    ReferencePriceC: ReferencePriceC,
                    ReferencePriceD: ReferencePriceD,
                    ReferencePriceE: ReferencePriceE,
                    ReferencePriceF: ReferencePriceF,
                    SellingAward: SellingAward,
                    SellingRoyaltyRate: SellingRoyaltyRate,
                    PreinstallStock: PreinstallStock,
                    PreinstallStockArea: PreinstallStockArea,
                    BulkUnit: BulkUnit,
                    Bulk: Bulk,
                    PreinstallStockSite: PreinstallStockSite,
                    WeightUnit: WeightUnit,
                    Weight: Weight,
                    PackCount: PackCount,
                    SellingLandTransportation: SellingLandTransportation,
                    DayLandTransportation: DayLandTransportation,
                    Long: Long,
                    SellingSeaTransportation: SellingSeaTransportation,
                    DaySeaTransportation: DaySeaTransportation,
                    Width: Width,
                    SellingOtherTransportation: SellingOtherTransportation,
                    DayOtherTransportation: DayOtherTransportation,
                    Height: Height

                },

                success: function (res) {
                    //*******

                    if (res == "success") {

                        $("#tt").datagrid("reload");
                        art.dialog.list["dialog"].close();
                        $.messager.show({ title: "提示", msg: "保存成功。" });
                    }
                    else {
                        ButtonLock(false);
                        $.messager.show({ title: "提示", msg: (res == "success" ? "保存成功" : res) });

                    }
                }
            });

        }
        else {

        }
        CloseLoading();
    }

    //    function save() {
    //        
    //            $("#ff").form("submit", {
    //                url: sumbitUrl,
    //                onSubmit: function () { /*做某些检查,返回 false 来阻止提交*/ },
    //                success: function (data) {
    //                    if (data == "success") {
    //                        $.messager.show({ title: "提示", msg: "保存成功。" });
    //                        //$("#tt").datagrid("reload");
    //                        art.dialog.list["dialog"].close();
    //                       
    //                    }
    //                    else {
    //                          $.messager.show({ title: "提示", msg: "保存失败。" });
    //                        }
    //                        
    //                    }
    //                }
    //           );
    //        }
    
</script>
<form action="" id="ff" method="post">
<input id="ID" name="ID" type="hidden" />
<input id="Code" name="Code" type="hidden" />
<div id="t" class="easyui-tabs">
    <div title="基本资料">
        <table class="table">
            <tr>
                <td class="titleTD">
                    编码：
                </td>
                <td class="inputTD">
                    <label id="lblCode" />
                </td>
                <td class="titleTD">
                    条形码：
                </td>
                <td class="inputTD">
                    <input type="text" id="BarCode" name="BarCode" class="oaInput" />
                </td>
                <td class="titleTD" colspan="2">
                    <input type="checkbox" id="Enabled" name="Enabled" /><label for="Enabled">停用</label>
                    <input type="checkbox" id="Install" name="Install" /><label for="Install">要安装</label>
                </td>
                <%--<td class="inputTD"><textarea id="txtRemark" name="txtRemark" rows="4" cols="" class="textarea"></textarea></td>--%>
            </tr>
            <tr>
                <td class="titleTD">
                    名称：
                </td>
                <td class="inputTD">
                    <input type="text" id="Name" name="Name" class="oaInput" />
                </td>
                <td class="titleTD">
                    型号：
                </td>
                <td class="inputTD">
                    <input type="text" id="Specifications" name="Specifications" class="oaInput" />
                </td>
                <td class="titleTD">
                    计价方式：
                </td>
                <td class="inputTD">
                    <input type="text" id="ValuationMethods" name="ValuationMethods" class="oaInput" />
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    单位：
                </td>
                <td class="inputTD">
                    <input type="text" id="Unit" name="Unit" class="oaInput" />
                </td>
                <td class="titleTD">
                    所属分类：
                </td>
                <td class="inputTD">
                    <input type="text" id="TypeID" name="TypeID" class="oaInput" />
                </td>
                <td class="titleTD">
                    系列：
                </td>
                <td class="inputTD">
                    <input type="text" id="SeriesID" name="SeriesID" class="oaInput" />
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    商品属性：
                </td>
                <td class="inputTD">
                    <input type="text" id="Attribute" name="Attribute" class="oaInput" />
                </td>
                <td class="titleTD">
                    厂家：
                </td>
                <td class="inputTD">
                    <input type="text" id="Manufacturer" name="Manufacturer" class="oaInput" />
                </td>
                <td class="titleTD">
                    促销价：
                </td>
                <td class="inputTD">
                    <input type="text" id="BarginPrice" name="BarginPrice" class="oaInput" />
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    标准进价：
                </td>
                <td class="inputTD">
                    <input type="text" id="StandardPrice" name="StandardPrice" class="oaInput" />
                </td>
                <td class="titleTD">
                    库存上限：
                </td>
                <td class="inputTD">
                    <input type="text" id="MaxStock" name="MaxStock" class="oaInput" />
                </td>
                <td class="titleTD">
                    库存下限：
                </td>
                <td class="inputTD">
                    <input type="text" id="MinStock" name="MinStock" class="oaInput" />
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    参考售价：
                </td>
                <td class="inputTD">
                    <input type="text" id="ReferencePrice" name="ReferencePrice" class="oaInput" />
                </td>
                <td class="titleTD">
                    利润：
                </td>
                <td class="inputTD">
                    <input type="text" id="Profit" name="Profit" class="oaInput" />
                </td>
                <td class="titleTD">
                    形状：
                </td>
                <td class="inputTD">
                    <input type="text" id="Shape" name="Shape" class="oaInput" />
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    材质：
                </td>
                <td class="inputTD">
                    <input type="text" id="Texture" name="Texture" class="oaInput" />
                </td>
                <td class="titleTD">
                    风格：
                </td>
                <td class="inputTD">
                    <input type="text" id="Style" name="Style" class="oaInput" />
                </td>
                <td class="titleTD">
                    规格：
                </td>
                <td class="inputTD">
                    <input type="text" id="Standard" name="Standard" class="oaInput" />
                </td>
            </tr>
        </table>
        <fieldset class="test">
            <legend>会计科目</legend>
            <table class="table">
                <tr>
                    <td class="titleTD">
                        库存商品：
                    </td>
                    <td class="inputTD">
                        <input type="text" id="StockProduct" name="StockProduct" class="oaInput" />
                    </td>
                    <td class="titleTD">
                        商品采购：
                    </td>
                    <td class="inputTD">
                        <input type="text" id="ProductPurchase" name="ProductPurchase" class="oaInput" />
                    </td>
                    <td class="titleTD">
                        销售成本：
                    </td>
                    <td class="inputTD">
                        <input type="text" id="SellingCost" name="SellingCost" class="oaInput" />
                    </td>
                </tr>
                <tr>
                    <td class="titleTD">
                        销售费用：
                    </td>
                    <td class="inputTD">
                        <input type="text" id="SellingPrice" name="SellingPrice" class="oaInput" />
                    </td>
                    <td class="titleTD">
                        销售收入：
                    </td>
                    <td class="inputTD">
                        <input type="text" id="SellingProfit" name="SellingProfit" class="oaInput" />
                    </td>
                    <td class="titleTD">
                        &nbsp;
                    </td>
                    <td class="inputTD">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div title="预设资料">
        <table class="table">
            <tr>
                <td class="titleTD">
                    参考售价A：
                </td>
                <td class="inputTD">
                    <input type="text" id="ReferencePriceA" name="ReferencePriceA" class="oaInput" />
                </td>
                <td class="titleTD">
                    参考售价B：
                </td>
                <td class="inputTD">
                    <input type="text" id="ReferencePriceB" name="ReferencePriceB" class="oaInput" />
                </td>
                <td class="titleTD">
                    参考售价C：
                </td>
                <td class="inputTD">
                    <input type="text" id="ReferencePriceC" name="ReferencePriceC" class="oaInput" />
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    参考售价D：
                </td>
                <td class="inputTD">
                    <input type="text" id="ReferencePriceD" name="ReferencePriceD" class="oaInput" />
                </td>
                <td class="titleTD">
                    参考售价E：
                </td>
                <td class="inputTD">
                    <input type="text" id="ReferencePriceE" name="ReferencePriceE" class="oaInput" />
                </td>
                <td class="titleTD">
                    参考售价F：
                </td>
                <td class="inputTD">
                    <input type="text" id="ReferencePriceF" name="ReferencePriceF" class="oaInput" />
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    销售奖励：
                </td>
                <td class="inputTD">
                    <input type="text" id="SellingAward" name="SellingAward" class="oaInput" />
                </td>
                <td class="titleTD">
                    销售提成率：
                </td>
                <td class="inputTD">
                    <input type="text" id="SellingRoyaltyRate" name="SellingRoyaltyRate" class="oaInput" />
                </td>
                <td class="titleTD">
                    预设仓库：
                </td>
                <td class="inputTD">
                    <input type="text" id="PreinstallStock" name="PreinstallStock" class="oaInput" />
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    预设仓区：
                </td>
                <td class="inputTD">
                    <input type="text" id="PreinstallStockArea" name="PreinstallStockArea" class="oaInput" />
                </td>
                <td class="titleTD">
                    体积单位：
                </td>
                <td class="inputTD">
                    <input type="text" id="BulkUnit" name="BulkUnit" class="oaInput" />
                </td>
                <td class="titleTD">
                    单位体积：
                </td>
                <td class="inputTD">
                    <input type="text" id="UnitBulk" name="UnitBulk" class="oaInput" />
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    预设仓位：
                </td>
                <td class="inputTD">
                    <input type="text" id="PreinstallStockSite" name="PreinstallStockSite" class="oaInput" />
                </td>
                <td class="titleTD">
                    重量单位：
                </td>
                <td class="inputTD">
                    <input type="text" id="WeightUnit" name="WeightUnit" class="oaInput" />
                </td>
                <td class="titleTD">
                    单位重量：
                </td>
                <td class="inputTD">
                    <input type="text" id="UnitWeight" name="UnitWeight" class="oaInput" />
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    包装件数：
                </td>
                <td class="inputTD">
                    <input type="text" id="PackCount" name="PackCount" class="oaInput" />
                </td>
                <td class="titleTD">
                    采购总体前期：
                </td>
                <td class="inputTD">
                    陆运<input type="text" id="SellingLandTransportation" name="SellingLandTransportation"
                        class="oaInput" style="width: 30px" />天 海运<input type="text" id="SellingSeaTransportation"
                            name="SellingSeaTransportation" class="oaInput" style="width: 30px" />天
                    <br />
                    空运<input type="text" id="SellingAirTransportation" name="SellingAirTransportation"
                        class="oaInput" style="width: 30px" />天 其他<input type="text" id="SellingOtherTransportation"
                            name="SellingOtherTransportation" class="oaInput" style="width: 30px" />天
                </td>
                <td class="titleTD">
                    运输时间：
                </td>
                <td class="inputTD">
                    陆运<input type="text" id="DayLandTransportation" name="DayLandTransportation" class="oaInput"
                        style="width: 30px" />天 海运<input type="text" id="DaySeaTransportation" name="DaySeaTransportation"
                            class="oaInput" style="width: 30px" />天
                    <br />
                    空运<input type="text" id="DayAirTransportation" name="DayAirTransportation" class="oaInput"
                        style="width: 30px" />天 其他<input type="text" id="DayOtherTransportation" name="DayOtherTransportation"
                            class="oaInput" style="width: 30px" />天
                </td>
            </tr>
            <tr>
                <td class="titleTD">
                    长：
                </td>
                <td class="inputTD">
                    <input type="text" id="Long" name="Long" class="oaInput" />米
                </td>
                <td class="titleTD">
                    宽：
                </td>
                <td class="inputTD">
                    <input type="text" id="Width" name="Width" class="oaInput" />米
                </td>
                <td class="titleTD">
                    高：
                </td>
                <td class="inputTD">
                    <input type="text" id="Height" name="Height" class="oaInput" />米
                </td>
            </tr>
        </table>
    </div>
    <div title="商品颜色" style="padding-top: 10px; padding-left: 10px; padding-right: 10px;
            background-color: #F4F4F4;">
            <div>
                <div id="tb">
                    <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-edit',plain:true"
                        onclick="AddRow()">增加</a> 
                        <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-help',plain:true"  onclick="DeleteRow()">
                            删除</a>
                             <a href="#" class="easyui-linkbutton" data-options="iconCls:'icon-edit',plain:true"
                                onclick="Group_Save()">保存</a>
                </div>
                <table id="color">
                </table>
                <script type="text/javascript">

                  
                    var editIndex = undefined;
                    function Show(row,type) {
                        $('#color').datagrid({
                            url: '../Ashx/Product.ashx',
                            queryParams: { "action": "list_Color", "ParentID": row.ID },
                            idField: "ID",
                            singleSelect: true
                        , columns: [[
        { field: 'Code', title: '颜色编码', width: 100, editor: "text" },
        { field: 'Name', title: '颜色名称', width: 100, editor: "text" },
        { field: 'ReferencePriceOut', title: '参考价格', width: 100, editor: "text",
            formatter: function (value, rowIndex, rowData) {
                //alert(fMoney(value));
                return fMoney(value);
            }
        },
        { field: 'StandardPriceIn', title: '成本价', width: 100, editor: "text",
            formatter: function (value, rowIndex, rowData) {
                //alert(fMoney(value));
                return fMoney(value);
            }
           
        },

        { field: 'TagPrice', title: '标价', width: 100, editor: "text",
            formatter: function (value, rowIndex, rowData) {
                //alert(fMoney(value));
                return fMoney(value);
            }
        },
        { field: 'ReferencePriceA', title: '参考价格A', width: 100, editor: "text",
            formatter: function (value, rowIndex, rowData) {
                //alert(fMoney(value));
                return fMoney(value);
            }
        },
        { field: 'ReferencePriceB', title: '参考价格B', width: 100, editor: "text",
            formatter: function (value, rowIndex, rowData) {
                //alert(fMoney(value));
                return fMoney(value);
            }
        },
        { field: 'ReferencePriceC', title: '参考价格C', width: 100, editor: "text",
            formatter: function (value, rowIndex, rowData) {
                //alert(fMoney(value));
                return fMoney(value);
            }
        },
        { field: 'ReferencePriceD', title: '参考价格D', width: 100, editor: "text",
            formatter: function (value, rowIndex, rowData) {
                //alert(fMoney(value));
                return fMoney(value);
            }
        },
        { field: 'ReferencePriceE', title: '参考价格E', width: 100, editor: "text",
            formatter: function (value, rowIndex, rowData) {
                //alert(fMoney(value));
                return fMoney(value);
            }
        },
        { field: 'ReferencePriceF', title: '参考价格F', width: 100, editor: "text",
            formatter: function (value, rowIndex, rowData) {
                //alert(fMoney(value));
                return fMoney(value);
            }
        }
    ]],

                            toolbar: '#tb',
                            onClickRow: function (rowIndex, rowData) {
                                //  group_EditRow(rowIndex);
                                // $('#color').datagrid('beginEdit', rowIndex);
                                //$('#color').datagrid('getEditor', rowIndex);
                                if (type != "view") {
                                    EndEdit();
                                    if (rowIndex != editIndex) {
                                        $('#color').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
                                        editIndex = rowIndex;


                                    }
                                    else {
                                        $('#color').datagrid('selectRow', rowIndex).datagrid('beginEdit', editIndex);
                                    }
                                }

                            }

                        });

                        
                       
                    }

//                    function group_EditRow(index) {
//                        if (editIndex != index) {
//                            if (group_endEditing()) {
//                                $('#color').datagrid('selectRow', index).datagrid('beginEdit', index);
//                                editIndex = index;
//                            } else {
//                                $('#color').datagrid('selectRow', editIndex);
//                            }
//                        }
//                    }

//                    function group_endEditing() {
//                        if (editIndex == undefined) { return true }
//                        if ($('#color').datagrid('validateRow', editIndex)) {
//                            $('#color').datagrid('endEdit', editIndex);
//                            editIndex = undefined;
//                            return true;
//                        } else {
//                            return false;
//                        }
//                    }

                    function AddRow() {
                        $('#color').datagrid('insertRow', { index: 0, row: {} });
                        editIndex = $('#color').datagrid('getRows').length - 1;
                        $('#color').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
                        // alert(editIndex);
                        EndEdit();
                    }

                    function DeleteRow() {
                        var row = $('#color').datagrid('getSelected');
                        var rowIndex = $('#color').datagrid('getRowIndex', row);
                        // alert(rowIndex);
                        $('#color').datagrid('deleteRow', rowIndex);
                    }


                    function EndEdit() {
                        if ($('#color').datagrid('validateRow',editIndex)) {
                            $("#color").datagrid('endEdit', editIndex);
                            editIndex = undefined;
                        }
                        var rows = $("#color").datagrid('getRows');
                        for (var i = 0; i < rows.length; i++) {
                            $("#color").datagrid('endEdit', i);
                        }
                    }


                    function Group_Save() {

                        EndEdit();
                        var rows = $('#color').datagrid('getRows');
                        for (var i = 0; i < rows.length; i++) {
                           
                                                    if (rows[i].Name.length <= 0) {
                                                        $.messager.show({ title: "错误提示", msg: "颜色名称不能为空" });
                                                        return ;
                                                    }

                                                    for (var j = i+1; j < rows.length; j++) {
                                                        //alert(rows[i].Name);
                                                        //alert(rows[j].Name);
                                                            if (rows[i].Name == rows[j].Name) {
                                                                $.messager.show({ title: "错误提示", msg: "颜色名称不能重复" });
                                                                return ;
                                                            }
                                                        }                                               
                                                }
                        // alert(allRows.length);
                        var delstr = "";
                        var updatestr = "";
                        var addstr = "";
                        var allstr = "";
                        var id = getRow.ID;
                        
                       
                        var allRows = $('#color').datagrid('getRows');
                        allstr = JSON.stringify(allRows);
                        //alert(allstr.length);
                        var delRows = $('#color').datagrid('getChanges', 'deleted');
                        delstr = JSON.stringify(delRows);
                        var updateRows = $('#color').datagrid('getChanges', 'updated');
                        updatestr = JSON.stringify(updateRows);
                        //alert(updatestr);
                        //alert(updateRows);
                        var addRows = $('#color').datagrid('getChanges', 'inserted');
                        addstr = JSON.stringify(addRows);

                        $.ajax({
                            type: "POST",
                            //timeout: 30000,
                            url: '../Ashx/Product.ashx',
                            data: {
                                'action': 'group_edit',
                                'allstr': addstr,
                                'addstr': addstr,
                                'updatestr': updatestr,
                                'ParentID': id,
                                'delstr': delstr
                            },
                            success: function (data) {
                                if (data == "success") {
                                    $("#color").datagrid('reload');
                                    $.messager.show({ title: '提示', msg: '编辑成功！' });
                                    $('#tt').datagrid('reload');
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
            </div>
            <div style="margin-top: 50px; margin-right: 20px; text-align: right;">
                <button id="add" type="button" value="" style="width: 80px" onclick="group_save()">
                    新&nbsp;&nbsp;&nbsp;&nbsp;增</button>
                <br />
                <br />
                <button id="Button1" type="button" value="" style="width: 80px">
                    删&nbsp;&nbsp;&nbsp;&nbsp;除</button>
                <br />
                <br />
                <button id="Button2" type="button" value="" style="width: 80px">
                    历史进价</button>
                <br />
                <br />
                <button id="Button3" type="button" value="" style="width: 80px">
                    历史售价</button>
            </div>
        </div>
        <div title="图片" style="padding-top: 10px; padding-left: 10px; padding-right: 10px;
            background-color: #F4F4F4;">
            <div style="float: left">
                <img id="showIMG" alt="" src="../Images/02.jpg" width="550px" height="350px" />
            </div>
            <div style="margin-top: 50px; margin-right: 20px; text-align: right;">
                <button id="Button4" type="button" value="" style="width: 80px">
                    装图片</button>
                <br />
                <br />
                <br />
                <br />
                <button id="Button5" type="button" value="" style="width: 80px">
                    卸图片</button>
            </div>
        </div>
    </div>
    <div>
        <div style="float: left; margin-left: 50px; margin-top: 5px;">
            <input type="checkbox" id="Checkbox1" name="isInstall" /><span style="color: Red;">
                更新库存的标价和参考价</span><br />
            <input type="checkbox" id="Checkbox2" name="isInstall" checked="checked" /><span
                style="color: Blue;">新增颜色资料加入到历史进价和售价</span>
        </div>
        
    </div>
</form>
