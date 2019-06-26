<%@ Page Title="" Language="C#" MasterPageFile="~/easyui.Master" AutoEventWireup="true"
    CodeBehind="Product_IDE.aspx.cs" Inherits="Maticsoft.Web.BaseInfo.Product_IDE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../js/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../js/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../js/swfupload/fileprogress.js"></script>
    <script type="text/javascript" src="../js/swfupload/filegroupprogress.js"></script>
    <script type="text/javascript" src="../js/swfupload/handlers.js"></script>
    <style type="text/css">
        .style1
        {
            text-align: left;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        //获取当前url参数
        function getParameter(paraStr, url) {
            var result = "";
            //获取URL中全部参数列表数据
            var str = "&" + url.split("?")[1];
            var paraName = paraStr + "=";
            //判断要获取的参数是否存在
            if (str.indexOf("&" + paraName) != -1) {
                //如果要获取的参数到结尾是否还包含“&”
                if (str.substring(str.indexOf(paraName), str.length).indexOf("&") != -1) {
                    //得到要获取的参数到结尾的字符串
                    var TmpStr = str.substring(str.indexOf(paraName), str.length);
                    //截取从参数开始到最近的“&”出现位置间的字符
                    result = TmpStr.substr(TmpStr.indexOf(paraName), TmpStr.indexOf("&") - TmpStr.indexOf(paraName));
                }
                else {
                    result = str.substring(str.indexOf(paraName), str.length);
                }
            }
            else {
                result = "无此参数";
            }
            return (result.replace("&", ""));
        }
        var actionType;
        var ID;
        var show = getParameter("action", window.location.href);
        var action = show.split("=")[1]; //获取参数值
    </script>
    <script type="text/javascript">

        $(function () {

            //验证初始化
            jQuery("#ff").validationEngine({ showOnMouseOver: false, promptPosition: 'topLeft', autoHidePrompt: true, autoHideDelay: 2000 });
            
            getSeriesData();
            getValuationMethodsData();
            getUnitData();
            getManufacturerData();
            getTypetree();
            // alert(action);
            if (action != "add") {
                GetDetail();
            }
            //alert(actionType);
            //alert(ID);

            //            if (action != "add") {

            //            }

            GetPicName();
            ControlReadonly(action == "view");
            Check();
        });

        //首先定义全局js变量
        var strVoucherGroupSelect = "";

        //在js中写好获取服务端数据的代码
        function genVoucherGroupSelect(rowID) {
            return $(strVoucherGroupSelect).attr("id", "sl_" + rowID).parent().html();    //返回增加ID后的下拉框完整html
        }

        //需要动态增加select的时候，可以这样写
        //$("#divID").append(genVoucherGroupSelect(rowID) );

        //给select增加点击事件，在第四步后增加
        //    $("#sl_0" + rowID).bind("onchange", function(){
        //          alert("你点击了下拉框");
        //    })




        function Check() {
            if (action == "view") {
                $("#isView").hide();
            }
        }

        function GetDetail() {


            var show2 = getParameter("id", window.location.href);

            var id = show2.split("=")[1]; //获取参数值
            ID = id;
            // alert(ID);
            actionType = action;

            $.ajax({
                type: "Post",
                // url:"/Ashx/Product.ashx?action=detail",
                url: "/BaseInfo/Product_IDE.aspx/QueryList",
                dataType: "json",
                contentType: 'application/json',
                data: '{"action": "' + action + '","id":" ' + id + '"}',
                success: function (res) {
                    var obj = eval(res.d)
                    $(obj).each(function (index) {
                        var val = obj[index];

                        //alert(val.ptID + " " + val.ppmID + " " + val.ptID);
                        $("#lbID").val(val.ID);

                        $("#Code").val(val.CodeName);
                        $("#BarCode").val(val.BarCode);
                        $("#Name").val(val.Name);
                        $("#Specifications").val(val.Specifications);
                        // $("#ValuationMethods").combobox("setValue", val.ppmID);   //计价方式
                        $("#ValuationMethods").val(val.ppmID);
                        // $("#Unit").combobox("setValue", val.bddValue); //单位
                        $("#Unit").val(val.bddValue);
                        $("#TypeID").combotree("setValue", val.ptID);        //----所属分类
                        // alert(val.Install);
                        if (val.Enabled == "是") {
                            document.getElementById("Enabled").checked = true;
                        }
                        else {
                            document.getElementById("Enabled").checked = false;
                        }
                        $("#TypeID").combotree("setValue", val.ptID);        //----所属分类
                        if (val.Install == "是") {
                            document.getElementById("Install").checked = true;
                        }
                        else {
                            document.getElementById("Install").checked = false;
                        }
                        //$("#TypeID").val( val.ptID);
                        //$("#SeriesID").combobox("setValue", val.psID);  //系列
                        $("#SeriesID").val(val.psID);
                        $("#Attribute").val(val.Attribute);
                        // $("#Manufacturer").combobox("setValue", val.sID); //厂家
                        $("#Manufacturer").val(val.sID);
                        //                        $("#BarginPrice").val(val.BarginPrice);
                        //                        $("#StandardPrice").val(val.StandardPrice);
                        //                        $("#MaxStock").val(val.MaxStock);
                        //                        $("#MinStock").val(val.MinStock);
                        //                        $("#ReferencePrice").val(val.ReferencePrice);
                        //                        $("#Profit").val(val.Profit);
                        //                        //$("#Shape").val(val.Shape);

                        //                        // $("#Texture").val(val.Texture);
                        //                        $("#Style").val(val.Style);
                        //                        //$("#Standard").val(val.Standard);
                        //                        $("#StockProduct").val(val.StockProduct);
                        //                        $("#ProductPurchase").val(val.ProductPurchase);
                        //                        $("#SellingCost").val(val.SellingCost);
                        //                        $("#SellingPrice").val(val.SellingPrice);
                        //                        $("#SellingProfit").val(val.SellingProfit);
                        //                        $("#ReferencePriceA").text(val.ReferencePriceA);
                        //                        $("#ReferencePriceB").val(val.ReferencePriceB);
                        //                        $("#ReferencePriceC").val(val.ReferencePriceC);
                        //                        $("#ReferencePriceD").val(val.ReferencePriceD);
                        //                        $("#ReferencePriceE").val(val.ReferencePriceE);
                        //                        $("#ReferencePriceF").val(val.ReferencePriceF);
                        //                        $("#SellingAward").val(val.SellingAward);
                        //                        $("#SellingRoyaltyRate").val(val.SellingRoyaltyRate);
                        //                        $("#PreinstallStock").val(val.PreinstallStock);
                        //                        $("#PreinstallStockArea").val(val.PreinstallStockArea);
                        $("#BulkUnit").val(val.BulkUnit);
                        $("#Bulk").val(val.UnitBulk);
                        $("#PreinstallStockSite").val(val.PreinstallStockSite);
                        $("#WeightUnit").val(val.WeightUnit);
                        $("#UnitWeight").val(val.UnitWeight);
                        $("#PackCount").val(val.PackCount);
                        $("#Quality").val(val.Quality);
                        $("#Brand").val(val.Brand);
                        $("#NFK").val(val.NFK);
                        $("#ProductKey").val(val.ProductKey);
                        //                        $("#SellingLandTransportation").val(val.SellingLandTransportation);
                        //                        $("#SellingSeaTransportation").val(val.SellingSeaTransportation);
                        //                        //$("#SellingAirTransportation").val(val.SellingAirTransportation);
                        //                        $("#SellingOtherTransportation").val(val.SellingOtherTransportation);
                        //                        $("#DayLandTransportation").val(val.DayLandTransportation);
                        //                        $("#DaySeaTransportation").val(val.DaySeaTransportation);
                        //                        //$("#DayAirTransportation").val(val.DayAirTransportation);
                        //                        $("#DayOtherTransportation").val(val.DayOtherTransportation);
                        //                        $("#Long").val(val.Long);
                        //                        $("#Width").val(val.Width);
                        //                        $("#Height").val(val.Height);
                    });

                }
            });



        }



        function getSeriesData() {
            $.ajax({
                type: "Post",
                url: "/Ashx/Common.ashx?type=product_Series",
                dataType: "json",
                data: "",
                //cache: true,
                success: function (res) {
                    var str = $("#SeriesID");
                    var option = "";
                    for (var j = 0; j < res.length; j++) {
                        if (j == 0) {
                            option += "<option value=\"\">请选择</option>";
                        }
                        option += "<option value=\"" + res[j].ID + "\">" + res[j].Name + "</option>";
                    }
                    $(str).html(option);
                    //strVoucherGroupSelect = $(str).html(option).parent().html();
                }
            });
        }

        function getValuationMethodsData() {
            $.ajax({
                type: "Post",
                url: "/Ashx/Common.ashx?type=product_ValuationMethods",
                dataType: "json",
                data: "",
                cache: true,
                success: function (res) {
                    var str = $("#ValuationMethods");
                    var option = "";
                    for (var j = 0; j < res.length; j++) {
                        if (j == 0) {
                            option += "<option value=\"\">请选择</option>";
                        }
                        option += "<option value=\"" + res[j].ID + "\">" + res[j].Name + "</option>";
                    }
                    $(str).html(option);
                }
            });
        }

        function getUnitData() {
            $.ajax({
                type: "Post",
                url: "/Ashx/Common.ashx?type=product_Unit",
                dataType: "json",
                data: "",
                cache: true,
                success: function (res) {
                    var str = $("#Unit");
                    var option = "";
                    for (var j = 0; j < res.length; j++) {
                        if (j == 0) {
                            option += "<option value=\"\">请选择</option>";
                        }
                        option += "<option value=\"" + res[j].ID + "\">" + res[j].Name + "</option>";
                    }
                    $(str).html(option);
                }
            });
        }

        function getManufacturerData() {
            $.ajax({
                type: "Post",
                url: "/Ashx/Common.ashx?type=product_Manufacturer",
                dataType: "json",
                data: "",
                cache: true,
                success: function (res) {
                    var str = $("#Manufacturer");
                    var option = "";
                    for (var j = 0; j < res.length; j++) {
                        if (j == 0) {
                            option += "<option value=\"\">请选择</option>";
                        }
                        option += "<option value=\"" + res[j].ID + "\">" + res[j].Name + "</option>";
                    }
                    $(str).html(option);
                }
            });
        }

        function getTypetree() {
            $('#TypeID').combotree({
                url: '../Ashx/Common.ashx?type=productType',
                valueField: 'id',
                textField: 'text',
                width: 150,
                required: true,
                editable: false,
                onLoadSuccess: function (node, data) {
                    $('#TypeID').combotree('tree').tree('collapseAll');
                }
            });
        }

        function formatMoney(ctrl) {
            //var c = getCursortPosition(ctrl);
            //alert(c);
            $(ctrl).val(formatCurrency($(ctrl).val()));
            //setCaretPosition(ctrl, c);
        }

        function ControlReadonly(flag) {

            // document.getElementById("ID").disabled =
            //document.getElementById("lblCode").disabled =
            document.getElementById("BarCode").disabled =
        document.getElementById("Name").readOnly =
        document.getElementById("Specifications").readOnly =
        document.getElementById("Attribute").readOnly =
            //        document.getElementById("BarginPrice").readOnly =
            //        document.getElementById("StandardPrice").readOnly =
            //        document.getElementById("MaxStock").readOnly =
            //        document.getElementById("MinStock").readOnly =
            //        document.getElementById("ReferencePrice").readOnly =
            //        document.getElementById("Profit").readOnly =
            //            //        document.getElementById("Shape").readOnly =
            //            //        document.getElementById("Texture").readOnly =
            //            //        document.getElementById("Style").readOnly =
            //            //       document.getElementById("Standard").readOnly =
            //         document.getElementById("StockProduct").readOnly =
            //        document.getElementById("ProductPurchase").readOnly =
            //        document.getElementById("SellingCost").readOnly =
            //        document.getElementById("SellingPrice").readOnly =
            //        document.getElementById("SellingProfit").readOnly =
            //        document.getElementById("ReferencePriceA").readOnly =
            //        document.getElementById("ReferencePriceB").readOnly =
            //        document.getElementById("ReferencePriceC").readOnly =
            //        document.getElementById("ReferencePriceD").readOnly =
            //        document.getElementById("ReferencePriceE").readOnly =
            //        document.getElementById("ReferencePriceF").readOnly =
            //        document.getElementById("SellingAward").readOnly =
            //        document.getElementById("SellingRoyaltyRate").readOnly =
            document.getElementById("PreinstallStock").readOnly =
        document.getElementById("PreinstallStockSite").readOnly =
        document.getElementById("PreinstallStockArea").readOnly =
        document.getElementById("BulkUnit").readOnly =
        document.getElementById("Bulk").readOnly =
        document.getElementById("WeightUnit").readOnly =
            document.getElementById("Weight").readOnly =
        document.getElementById("PackCount").readOnly = flag;
            //        document.getElementById("SellingLandTransportation").readOnly =
            //        document.getElementById("SellingSeaTransportation").readOnly =
            //            //        document.getElementById("SellingAirTransportation").readOnly =
            //        document.getElementById("SellingOtherTransportation").readOnly =
            //        document.getElementById("DayLandTransportation").readOnly =
            //        document.getElementById("DaySeaTransportation").readOnly =
            //            //        document.getElementById("DayAirTransportation").readOnly =
            //        document.getElementById("DayOtherTransportation").readOnly =
            //        document.getElementById("Long").readOnly =
            //        document.getElementById("Width").readOnly =
            //            //document.getElementById("Enabled").readOnly=
            //         
            //        document.getElementById("Height").readOnly = flag;

            if (action == "view") {
                //            $("#ValuationMethods").combotree(able);
                $("#Unit").attr("disabled", "disabled");
                //$("#Unit").combobox(able);
                $("#ValuationMethods").attr("disabled", "disabled");
                //            $("#TypeID").combotree(able);
                $("#TypeID").attr("disabled", "disabled");
                $("#SeriesID").attr("disabled", "disabled");
                $("#Manufacturer").attr("disabled", "disabled");


                //            $("#Manufacturer").combobox(able);
                //            $("#save").attr('readOnly', flag);
                //art.dialog.list["dialog"].button({ name: "保存", disabled: flag });
            }
        }

        //保存所有
        function save() {
         EndEdit();
            actionType = action;
            // alert(ID);
            if (action != "view") {

             var num=$("#t").datagrid("getRows");
             if(num>2)
             {
            for(var i=0;i<num.length;i++)
            {
          
                if( $("#t").datagrid("getData").rows[i].Corlor==undefined)
                  {
                 $.messager.show({ title: '提示', msg: '颜色不能为空！' });
                 return;
                }
                
                for(var j=0+i;j<num.length;j++)
                {
            
                    if( $("#t").datagrid("getData").rows[i].Corlor==$("#t").datagrid("getData").rows[j].Corlor)
                    {
                    $.messager.show({ title: '提示', msg: '颜色不能重复！' });
                    return;
                    }
                }
             }
           }
                $("#BarginPrice").keyup(function () {
                    //如果输入非数字，则替换为''，如果输入数字，则在每4位之后添加一个空格分隔
                    this.value = this.value.replace(/[^\d]/g, '').replace(/(\d{4})(?=\d)/g, "$1 ");
                });
                if (jQuery('#ff').validationEngine('validate')) {
                    OpenLoading_me("Processing,please wait...");

                    /*************基本资料***********/
                    var Code = $("#Code").val();  
                    var BarCode = $("#BarCode").val();  //条形码
                    var Name = $("#Name").val(); //商品名称
                    var Specifications = $("#Specifications").val(); //规格型号
                    var ValuationMethods = $("#ValuationMethods").val(); //计费方式
                    //var ValuationMethods = $("#ValuationMethods option:selected").text(); //计费方式
                    //alert(ValuationMethods);
                    var Unit = $("#Unit option:selected").val();  //单位
                    //var t = $('#TypeID').combotree('tree'); //         get the tree object
                    //var TypeID = (t.tree('getSelected')).id; 	// 所属分类get selected node
                    var TypeID = $('#TypeID').combotree("getValue");
                    //alert(TypeID);
                    var SeriesID = $("#SeriesID option:selected").val(); //系列
                    var Attribute = $("#Attribute").val(); //属性
                    var Manufacturer = $("#Manufacturer option:selected").val(); //厂家
                    if ($("#Enabled").attr("checked") == "checked") {
                        var Enabled = "True";
                    }
                    else {
                        var Enabled = "False";
                    }
                    if ($("#Install").attr("checked") == "checked") {
                        var Install = "True";
                    }
                    else {
                        var Install = "False";
                    }
                    //                    var BarginPrice = $("#BarginPrice").val(); //促销价
                    //                    var StandardPrice = $("#StandardPrice").val(); //标准进价
                    //                    var MaxStock = $("#MaxStock").val(); //库存上限
                    //                    var MinStock = $("#MinStock").val(); //库存下限
                    //                    var ReferencePrice = $("#ReferencePrice").val(); //参考价格
                    //                    var PriceTag = $("#PriceTag").val(); //标价
                    //                    var MinPrice = $("#MinPrice").val(); //最低售价
                    //                    var Profit = $("#Profit").val(); //利润
                    //                    var StockProduct = $("#StockProduct").val(); //库存商品
                    //                    var ProductPurchase = $("#ProductPurchase").val(); //商品采购
                    //                    var SellingCost = $("#SellingCost").val(); //销售成本
                    //                    var SellingPrice = $("#SellingPrice").val()//销售费用
                    //                    var SellingProfit = $("#SellingProfit").val(); //销售收入

                    //                    /*************预设资料***********/
                    //                    var ReferencePriceA = $("#ReferencePriceA").val();
                    //                    var ReferencePriceB = $("#ReferencePriceB").val();
                    //                    var ReferencePriceC = $("#ReferencePriceC").val();
                    //                    var ReferencePriceD = $("#ReferencePriceD").val();
                    //                    var ReferencePriceE = $("#ReferencePriceE").val();
                    //                    var ReferencePriceF = $("#ReferencePriceF").val();
                    //                    var SellingAward = $("#SellingAward").val();
                    //                    var SellingRoyaltyRate = $("#SellingRoyaltyRate").val();
                    var PreinstallStock = $("#PreinstallStock").val();
                    var PreinstallStockArea = $("#PreinstallStockArea").val();
                    var BulkUnit = $("#BulkUnit").val();
                    var Bulk = $("#Bulk").val();
                    var PreinstallStockSite = $("#PreinstallStockSite").val();
                    var WeightUnit = $("#WeightUnit").val();
                    var Weight = $("#Weight").val();
                    var PackCount = $("#PackCount").val();
                    var   Quality= $("#Quality").val();
                    var   Brand=  $("#Brand").val();
                    var   NFK= $("#NFK").val();
                    var   ProductKey= $("#ProductKey").val();
                    //                    var SellingLandTransportation = $("#SellingLandTransportation").val();
                    //                    var DayLandTransportation = $("#DayLandTransportation").val();
                    //                    var Long = $("#Long").val();
                    //                    var SellingSeaTransportation = $("#SellingSeaTransportation").val();
                    //                    var DaySeaTransportation = $("#DaySeaTransportation").val();
                    //                    var Width = $("#Width").val();
                    //                    var SellingOtherTransportation = $("#SellingOtherTransportation").val();
                    //                    var DayOtherTransportation = $("#DayOtherTransportation").val();
                    //                    var Height = $("#Height").val();
                    var addstr = "";
                    var delstr = "";
                    var updatestr = "";
                    var addRows = $('#t').datagrid('getChanges', 'inserted');
                    addstr = JSON.stringify(addRows);
                    var delRows = $('#t').datagrid('getChanges', 'deleted');
                    delstr = JSON.stringify(delRows);
                    var updateRows = $('#t').datagrid('getChanges', 'updated');
                    updatestr = JSON.stringify(updateRows);
                    //alert(delstr);

                    var picFile = $("#picFile").val();

                    $.ajax({
                        type: "Post",
                        url: "/Ashx/Product.ashx?action=" + actionType + "&ID=" + <%=ProductID %> + "",
                        data: {
                            /*************基本资料***********/
                            Code:Code,
                            BarCode: BarCode,
                            Name: Name,
                            Specifications: Specifications,
                            ValuationMethods: ValuationMethods,
                            Unit: Unit,
                            TypeID: TypeID,
                            SeriesID: SeriesID,
                            Attribute: Attribute,
                            Enabled: Enabled,
                            Install: Install,
                            Manufacturer: Manufacturer,
                            //                            BarginPrice: BarginPrice,
                            //                            StandardPrice: StandardPrice,
                            //                            MaxStock: MaxStock,
                            //                            MinStock: MinStock,
                            //                            ReferencePrice: ReferencePrice,
                            //                            PriceTag: PriceTag,
                            //                            MinPrice: MinPrice,
                            //                            Profit: Profit,
                            //                            StockProduct: StockProduct,
                            //                            ProductPurchase: ProductPurchase,
                            //                            SellingCost: SellingCost,
                            //                            SellingPrice: SellingPrice,
                            //                            SellingProfit: SellingProfit,
                            //                            /*************预设资料***********/
                            //                            ReferencePriceA: ReferencePriceA,
                            //                            ReferencePriceB: ReferencePriceB,
                            //                            ReferencePriceC: ReferencePriceC,
                            //                            ReferencePriceD: ReferencePriceD,
                            //                            ReferencePriceE: ReferencePriceE,
                            //                            ReferencePriceF: ReferencePriceF,
                            //                            SellingAward: SellingAward,
                            //                            SellingRoyaltyRate: SellingRoyaltyRate,
                            PreinstallStock: PreinstallStock,
                            PreinstallStockArea: PreinstallStockArea,
                            BulkUnit: BulkUnit,
                            Bulk: Bulk,
                            PreinstallStockSite: PreinstallStockSite,
                            WeightUnit: WeightUnit,
                            Weight: Weight,
                            PackCount: PackCount,
                            Quality:Quality,
                            Brand: Brand,
                            NFK:NFK,
                            ProductKey:ProductKey,
                            //                            SellingLandTransportation: SellingLandTransportation,
                            //                            DayLandTransportation: DayLandTransportation,
                            //                            Long: Long,
                            //                            SellingSeaTransportation: SellingSeaTransportation,
                            //                            DaySeaTransportation: DaySeaTransportation,
                            //                            Width: Width,
                            //                            SellingOtherTransportation: SellingOtherTransportation,
                            //                            DayOtherTransportation: DayOtherTransportation,
                            //                            Height: Height,
                            addstr: addstr,
                            picFile: picFile,
                            delstr: delstr,
                            updatestr: updatestr


                        },

                        success: function (res) {
                            //*******
                            if (res == "success") {
                                $.messager.show({ title: "提示", msg: "保存成功。" });
                            }
                            else {
                                $.messager.show({ title: "提示", msg: res });
                            }
                        }
                    });

                }
                else {

                }
                CloseLoading();
            }



        }
    </script>
    <script type="text/javascript">
        var swfu;
        window.onload = function () {

            var settings = {
                flash_url: "../js/swfupload/swfupload.swf",
                upload_url: "../Ashx/Product.ashx?action=upload&lbID=" + ID + "&isAdd=" + action + "",
                file_size_limit: "100 MB",
                file_types: "*.*",
                file_types_description: "All Files",
                file_upload_limit: 0,
                file_queue_limit: 1,
                custom_settings: {

                    progressTarget: "divprogresscontainer",
                    progressGroupTarget: "divprogressGroup",

                    //progress object
                    container_css: "progressobj",
                    icoNormal_css: "IcoNormal",
                    icoWaiting_css: "IcoWaiting",
                    icoUpload_css: "IcoUpload",
                    fname_css: "fle ftt",
                    state_div_css: "statebarSmallDiv",
                    state_bar_css: "statebar",
                    percent_css: "ftt",
                    href_delete_css: "ftt",

                    //sum object
                    /*
                    页面中不应出现以"cnt_"开头声明的元素
                    */
                    s_cnt_progress: "cnt_progress",
                    s_cnt_span_text: "fle",
                    s_cnt_progress_statebar: "cnt_progress_statebar",
                    s_cnt_progress_percent: "cnt_progress_percent",
                    s_cnt_progress_uploaded: "cnt_progress_uploaded",
                    s_cnt_progress_size: "cnt_progress_size"
                },
                debug: false,

                // Button settings
                button_image_url: "../images/7164749.jpg",
                button_width: "75",
                button_height: "29",
                button_placeholder_id: "spanButtonPlaceHolder",
                button_text: '<span>装图片</span>',
                button_text_style: ".theFont { font-size: 12;color:#0068B7; }",
                button_text_left_padding: 14,
                button_text_top_padding: 7,

                // The event handler functions are defined in handlers.js
                file_queued_handler: fileQueued,
                file_queue_error_handler: fileQueueError,
                upload_start_handler: uploadStart,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: uploadSuccess,
                upload_complete_handler: uploadComplete,
                file_dialog_complete_handler: fileDialogComplete
            };
            swfu = new SWFUpload(settings);
        };

        //上传图片后返回  图片名
        function uploadSuccess(file, serverData, responseReceived) {
            if (responseReceived) {
                $("#showIMG").attr("src", "../ProductPic/" + serverData + "");
                $("#picFile").val(serverData);

            }
        }

    </script>
    <script type="text/javascript">
        var editIndex = undefined;





       

        function End(index) {
            $("#color").datagrid('endEdit', index);
        }

        function SaveColor() {
            if (action == "view") {
                $("#saveColor").bind('onclick', 'return false');
            }
            else {
                $("#saveColor").bind('onclick', Group_Save());
            }
        }

        function DeleteColor() {
            if (action == "view") {
                $("#delColor").bind('onclick', 'return false');
            }
            else {
                $("#delColor").bind('onclick', DeleteRow());
            }
        }

        function AddColor() {

            if (action == "view") {

                $("#addColor").bind('onclick', "return false");
            }
            else {

                $("#addColor").bind('onclick', AddRow());
            }
        }

        function EndEdit() {
            var rows = $("#t").datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $("#t").datagrid('endEdit', i);
            }
        }


        function AddRow() {

            $('#t').datagrid('insertRow', { index: 0, row: {} });
            editIndex = $('#color').datagrid('getRows').length;
            //alert(editIndex);
            $('#t').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);

        }

        function DeleteRow() {
            var row = $('#t').datagrid('getSelected');
            var rowIndex = $('#t').datagrid('getRowIndex', row);
            // alert(rowIndex);
            $('#t').datagrid('deleteRow', rowIndex);
        }

        function Group_Save() {

            EndEdit();


            // alert(allRows.length);
            var delstr = "";
            var updatestr = "";
            var addstr = "";
            var allstr = "";
            var num=$("#t").datagrid("getRows");
            if(num>2)
            {
            for(var i=0;i<num.length;i++)
            {
          
                if( $("#t").datagrid("getData").rows[i].Corlor==undefined)
                  {
                 $.messager.show({ title: '提示', msg: '颜色不能为空！' });
                 return;
                }
                
                for(var j=i+1;j<num.length;j++)
                {
            
                    if( $("#t").datagrid("getData").rows[i].Corlor==$("#t").datagrid("getData").rows[j].Corlor)
                    {
                    $.messager.show({ title: '提示', msg: '颜色不能重复！' });
                    return;
                    }
                }
           }
           }
            var allRows = $('#t').datagrid('getRows');
            allstr = JSON.stringify(allRows);
            // alert(allstr.length);
            var delRows = $('#t').datagrid('getChanges', 'deleted');
            delstr = JSON.stringify(delRows);
            //alert(delstr);
            var updateRows = $('#t').datagrid('getChanges', 'updated');
            updatestr = JSON.stringify(updateRows);
            // alert(updatestr);
            var addRows = $('#t').datagrid('getChanges', 'inserted');
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
                    'ParentID': <%=ProductID %>,
                    'delstr': delstr
                },
                success: function (data) {
                    if (data == "success") {
                        $("#t").datagrid('reload');

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



        //加载数据显示图片名字
        function GetPicName() {
            $.ajax({
                url: "../Ashx/Product.ashx?action=GetPicName&lbID=" + ID + "",
                data: { ID: ID },
                success: function (res) {
                    if (res != "") {
                        $("#showIMG").attr("src", "../ProductPic/" + res + "");
                        $("#picFile").val(res);
                    }
                    else {

                        $("#showIMG").attr("src", "../ProductPic/picload.jpg");
                        //   alert(res);
                    }
                }
            });

        }

        //删除图片
        function DelPic() {
            $.ajax({
                url: "../Ashx/Product.ashx?action=DelPic&lbID=" + ID + "",
                data: { ID: ID },
                success: function (res) {
                    if (res == "success") {
                        $("#showIMG").attr("src", "../ProductPic/picload.jpg");
                        $.messager.show({ title: "系统提示", msg: "图片删除成功！" });
                    }
                    else {
                        $.messager.show({ title: "系统提示", msg: "图片删除失败！" });
                    }
                }

            });
        }
         
                     function trHide() {
             $('#cc').layout('collapse', 'north');
            }
    </script>
    <script type="text/javascript">
        var check = true;
        $(function () {

            $("#t").datagrid({
                url: "../Ashx/Product_ColorType.ashx"
                , queryParams: { "action": "list", "ID": '<%=ProductID %>', "type": ''+actionType+'' }
                , loadMsg: "正在努力加载中..."
                , toolbar: '#tb'

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
                //                     { title: "(编码)名称", field: "Code", width: 100, editor: "text" },
                    {title: "颜色名字", field: "Corlor", width: 100, editor: "text", editor:
                    {
                        type: 'combobox',
                        options: {
                            valueField: 'Corlor',
                            textField: 'Corlor',
                            url: '../../Ashx/Product_ColorType.ashx?action=GetColor',
                            required: true
                        }
                    }
                },
                    { title: "尺寸", field: "Size", width: 100, editor: "text" },
                //                    { title: "质地", field: "Quality", width: 100, editor: "text" },
                    {title: "品牌", field: "Brand", width: 100, editor: "text" },
                //                      { title: "阻燃性", field: "NFK", width: 100, editor: "text" },
                    {title: "货存上限", field: "MaxStock", width: 100, editor: "text" },
                    { title: "货存下限", field: "MinStock", width: 100, editor: "text" },
                    { title: "参考价", field: "ReferencePriceOut", width: 100, editor: "text" },
                    { title: "标准价格", field: "StandardPriceIn", width: 100, editor: "text" },

                    { title: "参考价格A", field: "ReferencePriceA", width: 100, editor: "text" },
                    { title: "参考价格B", field: "ReferencePriceB", width: 100, editor: "text" },
                    { title: "参考价格C", field: "ReferencePriceC", width: 100, editor: "text" },
                    { title: "参考价格D", field: "ReferencePriceD", width: 100, editor: "text" },
                    { title: "参考价格E", field: "ReferencePriceE", width: 100, editor: "text" },
                    { title: "参考价格F", field: "ReferencePriceF", width: 100, editor: "text" },
                //                    { title: "备注", field: "Remark", editor: "text",
                //					    formatter: function (value, rowData, rowIndex) {
                //					        return "<a class='a_black' title='" + value + "'><span class='mlength'>" + value + "</span></a>";
                //					    }
                //					}
		        ]]
                , onClickRow: function (rowIndex, rowData) {
                    if (rowIndex != editIndex) {
                        End(editIndex);
                    }
                    $('#t').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
                    editIndex = rowIndex;


                }

            });
        });

        


//        //循环遍历颜色是否已存在
//        function GetColorID(rowData) {

//            var row = $("#t").datagrid("getRows") == undefined ? [] : $("#t").datagrid("getRows");
//            //alert(row);
//            for (var i = 0; i < row.length; i++) {

//                //alert("row=" + row[i].ID);
//                // alert("rowData=" + rowData.ID);
//                if (row[i].ColorID === rowData.ID) {

//                    check = false;
//                    $.messager.show({ title: "warn", msg: "已有颜色，添加失败" });
//                    break;
//                }
//                check = true;
//            }

//        }


        function EndEdit() {
            var rows = $("#t").datagrid('getRows');
            for (var i = 0; i < rows.length; i++) {
                $("#t").datagrid('endEdit', i);
            }
        }
        function End(index) {
            $("#t").datagrid('endEdit', index);
        }
        function addColor() {
            EndEdit();
            $('#t').datagrid('insertRow', { index: 0, row: {} }).datagrid("beginEdit", 0);
        }


        function delColor() {
            var row = $('#t').datagrid('getSelected');
            if (row == null) {
                $.messager.show({ title: "warn", msg: "请选择要删除的行！" });

            }
            var rowIndex = $('#t').datagrid('getRowIndex', row);
            // alert(rowIndex);
            $('#t').datagrid('deleteRow', rowIndex);
        }
    </script>
    <form id="ff" action="" enctype="multipart/form-data">

    <input id="lbID" type="hidden" name="lbID" value="" />
    <input id="EnabledValue" type="hidden" value="" />
    <input id="InstallValue" type="hidden" value="" />
    <%-- 布局--%>
    
    <div id="cc" class="easyui-layout" data-options="fit:true" style="width: 100%; margin-top: 30px; height:640px;overflow-y:hidden; overflow:hidden; overflow: -moz-hidden-unscrollable;">
        <div data-options="region:'north',split:true" style="width: 100%; height: 290px; overflow-y: hidden;
             overflow-x: hidden;">
            <table style="background-color: #F4F4F4; margin: 0 0; padding: 0 0; height: 274px;">
                <tr>
                    <td>
                        <div id="tt" style="padding-left: 10px; padding-right: 10px; width: 773px; ">
                            <table style="width: 717px">
                                <tr>
                                    <td class="style1">
                                        商品编号：
                                    </td>
                                    <td colspan="1" class="style1">
                                        <input id="Code" name="Code" type="text" readonly="readonly" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; 
            background-color: transparent; border-style: ridge;" />
                                    </td>
                                    <td class="style1">
                                        <span style="color: Red;">*</span>单位：
                                    </td>
                                    <td class="style1">
                                    
                                        <select id="Unit" name="Unit" style="width: 130px; " class="validate[required]" />
                                                                        
                                    </td>
                                    <td class="style1">
                                        <input type="checkbox" id="Enabled" name="Enabled" />停用
                                    </td>
                                </tr>
                                <tr>
                                    <td id="code" class="style1">
                                        条形码：
                                    </td>
                                    <td colspan="1" class="style1">
                                        <input id="BarCode" name="BarCode" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; 
            background-color: transparent;" />
                                    </td>
                                    <td class="style1">
                                        <span style="color: Red;">*</span>系列：
                                    </td>
                                    <td class="style1">
                                        <select id="SeriesID" name="SeriesID" style="width: 130px; " class="validate[required]" />
                                    </td>
                                    <td class="style1">
                                        <input type="checkbox" id="Install" name="Install" />要安装
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <span style="color: Red;">*</span>商品名称：
                                    </td>
                                    <td colspan="1" class="style1">
                                        <input id="Name" name="Name" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; 
            background-color: transparent;" class="validate[required]" />
                                    </td>
                                    <td class="style1">
                                        <span style="color: Red;">*</span>厂家：
                                    </td>
                                    <td class="style1">
                                        <select id="Manufacturer" name="Manufacturer" style="width: 130px; " class="validate[required]" />
                                    </td>
                                    <td class="style1">商品属性：</td>
                                    <td class="style1">
                                        <input id="Attribute" name="Attribute" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;background-color: transparent; " /></td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        规格型号：
                                    </td>
                                    <td colspan="1" class="style1">
                                        <input id="Specifications" name="Specifications" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; 
            background-color: transparent;" />
                                    </td>
                                    <td class="style1">
                                        预设仓库：</td>
                                    <td class="style1">
                                        <input id="PreinstallStock" name="PreinstallStock" type="text" class="easyui-validatebox"
                                            data-options="number:true ,validType:'number'" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; background-color: transparent;" /></td>
                                        <td class="style1">预设仓区：
                                    </td><td class="style1">
                                        <input id="PreinstallStockArea" name="PreinstallStockArea" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;   background-color: transparent;" /></td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <span style="color: Red;">*</span>计价方式：
                                    </td>
                                    <td class="style1">
                                        <select id="ValuationMethods" name="ValuationMethods" style="width: 130px; 
            " class="validate[required]" />
                                    </td>
                                    <td class="style1">
                                        体积单位：</td>
                                    <td class="style1">
                                        <input id="BulkUnit" name="BulkUnit" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;  background-color: transparent; " /></td>
                                    <td class="style1">
                                        单位体积：</td>
                                    <td class="style1">
                                        <input id="Bulk" name="Bulk" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;   background-color: transparent;" /></td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <span style="color: Red;">*</span>所属分类：
                                    </td>
                                    <td class="style1">
                                        <input id="TypeID" name="TypeID" type="text" style="width: 130px; " class="validate[required]" />
                                    </td>
                                    <td class="style1">
                                        预设仓位：</td>
                                    <td class="style1">
                                        <input id="PreinstallStockSite" name="PreinstallStockSite" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;   background-color: transparent;" /></td>
                                    <td class="style1">
                                        重量单位：
                                    </td>
                                    <td class="style1">
                                        <input id="WeightUnit" name="WeightUnit" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;  background-color: transparent; " /></td>
                                </tr>
                                <tr>
                                    <td style="width: 11%; " class="style1">
                                        &nbsp;单位重量：
                                    </td>
                                    <td style="width: 22%;" class="style1">
                                        &nbsp;<input id="Weight" name="Weight" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;  background-color: transparent; " /></td>
                                    <td style="width: 11%; " class="style1">
                                        包装件数：</td>
                                    <td style="width: 22%;" class="style1">
                                        <input id="PackCount" name="PackCount" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;   background-color: transparent;" /></td>
                                    <%--<td style="width: 11%;  text-align: right;">
                        促销价：
                    </td>
                    <td style="width: 22%;">
                        <input id="BarginPrice" name="BarginPrice" type="text" class="inputRight" disabled="disabled" onblur="formatMoney($(this));"
                            value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        标准进价：
                    </td>
                    <td>
                        <input id="StandardPrice" name="StandardPrice" type="text" class="inputRight" disabled="disabled" onblur="formatMoney($(this));"
                            value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                    <td style="text-align: right;">
                        库存上限：
                    </td>
                    <td>
                        <input id="MaxStock" name="MaxStock" type="text" class="easyui-validatebox" data-options="number:true ,validType:'number'"
                            style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                    <td style="text-align: right;">
                        库存下限：
                    </td>
                    <td>
                        <input id="MinStock" name="MinStock" type="text" class="easyui-validatebox" data-options="number:true ,validType:'number'"
                            style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        参考售价：
                    </td>
                    <td>
                        <input id="ReferencePrice" name="ReferencePrice" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; "
                            class="inputRight" onblur="formatMoney($(this));" value="0.00" />
                    </td>
                    <td style="text-align: right;">
                        标价：
                    </td>
                    <td>
                        <input id="PriceTag" name="PriceTag" type="text" class="inputRight" onblur="formatMoney($(this));"
                            value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                    <td style="text-align: right;">
                        最低售价：
                    </td>
                    <td>
                        <input id="MinPrice" name="MinPrice" type="text" class="inputRight" onblur="formatMoney($(this));"
                            value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        利润：
                    </td>
                    <td>
                        <input id="Profit" name="Profit" type="text" class="inputRight" onblur="formatMoney($(this));"
                            value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                    <td style="text-align: right;">
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td style="text-align: right;">
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <fieldset class="EditField">
                <legend>会计科目</legend>
                <table>
                    <tr>
                        <td style="width: 11%; text-align: right;">
                            库存商品：
                        </td>
                        <td style="width: 22%;">
                            <input id="StockProduct" name="StockProduct" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                        </td>
                        <td style="width: 11%; text-align: right;">
                            商品采购：
                        </td>
                        <td style="width: 22%;">
                            <input id="ProductPurchase" name="ProductPurchase" type="text" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                        </td>
                        <td style="width: 11%; text-align: right;">
                        </td>
                        <td style="width: 22%;">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            销售成本：
                        </td>
                        <td>
                            <input id="SellingCost" name="SellingCost" type="text" class="inputRight" onblur="formatMoney($(this));"
                                value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                        </td>
                        <td style="text-align: right;">
                            销售费用
                        </td>
                        <td>
                            <input id="SellingPrice" name="SellingPrice" type="text" class="inputRight" onblur="formatMoney($(this));"
                                value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                        </td>
                        <td style="text-align: right;">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            销售收入：
                        </td>
                        <td>
                            <input id="SellingProfit" name="SellingProfit" type="text" class="inputRight" onblur="formatMoney($(this));"
                                value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                        </td>
                        <td style="text-align: right;">
                        </td>
                        <td>
                        </td>
                        <td style="text-align: right;">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>

            <div style="padding-top: 2px; padding-left: 10px; padding-right: 10px;  width:650px;
            background-color: #F4F4F4;">
            <table>
                <tr>
                    <td style="width: 13%; text-align: right;">
                        参考售价A：
                    </td>
                    <td style="width: 20%;">
                        <input id="ReferencePriceA" name="ReferencePriceA" type="text" class="inputRight"
                            onblur="formatMoney($(this));" value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                    <td style="width: 13%; text-align: right;">
                        参考售价B：
                    </td>
                    <td style="width: 20%;">
                        <input id="ReferencePriceB" name="ReferencePriceB" type="text" class="inputRight"
                            onblur="formatMoney($(this));" value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                    <td style="width: 13%; text-align: right;">
                        参考售价C：
                    </td>
                    <td style="width: 20%;">
                        <input id="ReferencePriceC" name="ReferencePriceC" type="text" class="inputRight"
                            onblur="formatMoney($(this));" value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        参考售价D：
                    </td>
                    <td>
                        <input id="ReferencePriceD" name="ReferencePriceD" type="text" class="inputRight"
                            onblur="formatMoney($(this));" value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                    <td style="text-align: right;">
                        参考售价E：
                    </td>
                    <td>
                        <input id="ReferencePriceE" name="ReferencePriceE" type="text" class="inputRight"
                            onblur="formatMoney($(this));" value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                    <td style="text-align: right;">
                        参考售价F：
                    </td>
                    <td>
                        <input id="ReferencePriceF" name="ReferencePriceF" type="text" class="inputRight"
                            onblur="formatMoney($(this));" value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        销售奖励：
                    </td>
                    <td>
                        <input id="SellingAward" name="SellingAward" type="text" class="inputRight" onkeyup="formatMoney($(this));"
                            value="0.00" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " />
                    </td>
                    <td style="text-align: right;">
                        销售提成率：
                    </td>
                    <td>
                        <input id="SellingRoyaltyRate" name="SellingRoyaltyRate" type="text" class="easyui-validatebox"
                            data-options="number:true ,validType:'number'" style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9; " onblur="formatMoney($(this));" />
                    </td>--%>
                                    <td style="width: 11%; " class="style1">
                                        质地：</td>
                                    <td style="width: 22%;" class="style1">
                                        <input id="Quality" name="Quality" type="text" 
                                            style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;   background-color: transparent;" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 11%; " class="style1">
                                        品牌：</td>
                                    <td style="width: 22%;" class="style1">
                                        <input id="Brand" name="Brand" type="text" 
                                            style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;   background-color: transparent;" /></td>
                                    <td style="width: 11%; " class="style1">
                                        阻燃性：</td>
                                    <td style="width: 22%;" class="style1">
                                        <input id="NFK" name="NFK" type="text" 
                                            style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;   background-color: transparent;" /></td>
                                    <td style="width: 11%; " class="style1">
                                        编码名称：</td>
                                    <td style="width: 22%;" class="style1">
                                        <input id="ProductKey" name="ProductKey" type="text" 
                                            style="border:0;width: 130px; border-bottom: 1px solid #C0D9D9;   background-color: transparent;" /></td>
                                </tr>
                                </table>
<div style="margin-right: 20px; text-align: right;">

                            </div>
                        </div>
                        <%-- </div>--%>
                    </td>
                    <td>
                        <div style="  margin:0 0; width: 180px;     clear:both; background-color: #F4F4F4; padding-right: 0; padding-top: 0; padding-bottom: 0; ">
                            <div style="">
                                <input type="hidden" id="picFile" value="" />
                                <img id="showIMG" style=" max-height: 220px; max-width:400px;" src="../ProductPic/picload.jpg" alt="图片加载失败或没图片" />
                                                                <div id="isView">
                                    <span id="spanButtonPlaceHolder" ></span>  
                                        
                                      <button id="Button1" type="button" value="" style="width: 75px; height:29px; float:right;  background-image:url(../images/7164749.jpg); border:0 ; margin-left:5px;   "
                                        onclick="DelPic()">
                                        卸图片</button></div>
                                    <div id="divprogresscontainer">
                                    </div>
                                    <div id="divprogressGroup" style="display: none;">
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                    </td>
                </tr>
            </table>
             <div style="  margin-right:10px; position:absolute; bottom:0; width:100%; left:0; text-align:right;"><a id="A1" href="#" onclick="trHide()" style="cursor:pointer;"><div style=" float:right;  width:40px;height:16px;background: url('../js/themes/metro/images/layout_arrows.png') no-repeat -15px -15px;"></div>收起</a></div>
        </div>
        <%--//中间布局--%>
        
        <div id=“cc” data-options="region:'center',border:false" style="background: #eee;">
       <%-- <div class="easyui-panel" data-options="fit:true,border:false">--%>
  <table id="t">
            </table>

             <div style="padding-top: 10px; padding-left: 10px; padding-right: 10px; float: left;
                width: 100%; background-color: #F4F4F4; height: 33px;">
                <div>
                
                    <div id="tb">
                        <a id="addColor" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true"
                            onclick="addColor()">增加</a> <a id="delColor" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-remove',plain:true"
                                onclick="delColor()">删除</a> <a id="saveColor" href="#" class="easyui-linkbutton"
                                    data-options="iconCls:'icon-save',plain:true" onclick="SaveColor()">保存</a>
                    </div>
                    
                </div>

            <%--<div>--%>
                <%--        <div style="text-align: right; vertical-align: middle; padding-top: 15px; padding-right: 10px;">
            <a  id="save" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'"
                onclick="save()">保存</a> <a id="cancel" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'"
                   >取消</a>
                   
        </div>--%>
            </div>
        </div>
  
        <%--</div>--%>
      
          
        
    </div>
    <div style="text-align: right; clear: both; padding-right: 10px; position: absolute;
        top: 0; background-color: #e1e2e3; width: 100%; line-height: 30px; height: 30px;">
        <a id="save" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-save'"
            onclick="save()">保存</a> <a id="cancel" href="#" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'"
                onclick="javascript:window.top.close();">取消</a>
    </div>
    </form>
</asp:Content>
