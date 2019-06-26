using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// Product:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Product
    {
        public Product()
        { }
        #region Model
        private long _id;
        private long? _parentid;
        private long? _typeid;
        private long? _seriesid;
        private string _code="";
        private string _barcode = "";
        private string _name = "";
        private bool _enabled;
        private bool _install;
        private string _specifications = "";
        private string _valuationmethods = "";
        private string _unit = "";
        private string _attribute = "";
        private string _manufacturer = "";
        private decimal? _barginprice;
        private decimal? _standardprice;
        private decimal? _referenceprice;
        private decimal? _pricetag;
        private decimal? _minprice;
        private decimal? _profit;
        private decimal? _maxstock;
        private decimal? _minstock;
        private string _stockproduct = "";
        private string _productpurchase = "";
        private decimal? _sellingcost;
        private decimal? _sellingprice;
        private decimal? _sellingprofit;
        private decimal? _referencepricea;
        private decimal? _referencepriceb;
        private decimal? _referencepricec;
        private decimal? _referencepriced;
        private decimal? _referencepricee;
        private decimal? _referencepricef;
        private string _sellingaward = "";
        private decimal? _sellingroyaltyrate;
        private string _preinstallstock = "";
        private string _preinstallstockarea = "";
        private string _preinstallstocksite = "";
        private string _bulkunit = "";
        private string _unitbulk = "";
        private string _weightunit = "";
        private string _unitweight = "";
        private decimal? _packcount;
        private decimal? _sellinglandtransportation;
        private decimal? _sellingseatransportation;
        private decimal? _sellingairtransportation;
        private decimal? _sellingothertransportation;
        private decimal? _daylandtransportation;
        private decimal? _dayseatransportation;
        private decimal? _dayairtransportation;
        private decimal? _dayothertransportation;
        private decimal? _long;
        private decimal? _width;
        private decimal? _height;
        private string _color = "";
        private string _image = "";
        private string _style = "";
        private string _texture = "";
        private string _standard = "";
        private string _shape = "";
        private string _remark = "";
        private string _value0 = "";
        private string _value1 = "";
        private string _value2 = "";
        private string _value3 = "";
        private string _value4 = "";
        private string _value5 = "";
        private string _value6 = "";
        private string _value7 = "";
        private string _value8 = "";
        private string _value9 = "";
        private string _createuser = "";
        private DateTime? _createdate;
        private string _updateuser = "";
        private DateTime? _updatedate;
        private string _productKey;

     
        private string _quality;
        private string _brand;
        private string _NFK;

        public string ProductKey
        {
            get { return _productKey; }
            set { _productKey = value; }
        }
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }


        public string NFK
        {
            get { return _NFK; }
            set { _NFK = value; }
        }


        public string Quality
        {
            get { return _quality; }
            set { _quality = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? SeriesID
        {
            set { _seriesid = value; }
            get { return _seriesid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BarCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Enabled
        {
            set { _enabled = value; }
            get { return _enabled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Install
        {
            set { _install = value; }
            get { return _install; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Specifications
        {
            set { _specifications = value; }
            get { return _specifications; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ValuationMethods
        {
            set { _valuationmethods = value; }
            get { return _valuationmethods; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Attribute
        {
            set { _attribute = value; }
            get { return _attribute; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Manufacturer
        {
            set { _manufacturer = value; }
            get { return _manufacturer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BarginPrice
        {
            set { _barginprice = value; }
            get { return _barginprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? StandardPrice
        {
            set { _standardprice = value; }
            get { return _standardprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferencePrice
        {
            set { _referenceprice = value; }
            get { return _referenceprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PriceTag
        {
            set { _pricetag = value; }
            get { return _pricetag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinPrice
        {
            set { _minprice = value; }
            get { return _minprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Profit
        {
            set { _profit = value; }
            get { return _profit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxStock
        {
            set { _maxstock = value; }
            get { return _maxstock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinStock
        {
            set { _minstock = value; }
            get { return _minstock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StockProduct
        {
            set { _stockproduct = value; }
            get { return _stockproduct; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductPurchase
        {
            set { _productpurchase = value; }
            get { return _productpurchase; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SellingCost
        {
            set { _sellingcost = value; }
            get { return _sellingcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SellingPrice
        {
            set { _sellingprice = value; }
            get { return _sellingprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SellingProfit
        {
            set { _sellingprofit = value; }
            get { return _sellingprofit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferencePriceA
        {
            set { _referencepricea = value; }
            get { return _referencepricea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferencePriceB
        {
            set { _referencepriceb = value; }
            get { return _referencepriceb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferencePriceC
        {
            set { _referencepricec = value; }
            get { return _referencepricec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferencePriceD
        {
            set { _referencepriced = value; }
            get { return _referencepriced; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferencePriceE
        {
            set { _referencepricee = value; }
            get { return _referencepricee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferencePriceF
        {
            set { _referencepricef = value; }
            get { return _referencepricef; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SellingAward
        {
            set { _sellingaward = value; }
            get { return _sellingaward; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SellingRoyaltyRate
        {
            set { _sellingroyaltyrate = value; }
            get { return _sellingroyaltyrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PreinstallStock
        {
            set { _preinstallstock = value; }
            get { return _preinstallstock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PreinstallStockArea
        {
            set { _preinstallstockarea = value; }
            get { return _preinstallstockarea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PreinstallStockSite
        {
            set { _preinstallstocksite = value; }
            get { return _preinstallstocksite; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BulkUnit
        {
            set { _bulkunit = value; }
            get { return _bulkunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UnitBulk
        {
            set { _unitbulk = value; }
            get { return _unitbulk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WeightUnit
        {
            set { _weightunit = value; }
            get { return _weightunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UnitWeight
        {
            set { _unitweight = value; }
            get { return _unitweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PackCount
        {
            set { _packcount = value; }
            get { return _packcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SellingLandTransportation
        {
            set { _sellinglandtransportation = value; }
            get { return _sellinglandtransportation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SellingSeaTransportation
        {
            set { _sellingseatransportation = value; }
            get { return _sellingseatransportation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SellingAirTransportation
        {
            set { _sellingairtransportation = value; }
            get { return _sellingairtransportation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SellingOtherTransportation
        {
            set { _sellingothertransportation = value; }
            get { return _sellingothertransportation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DayLandTransportation
        {
            set { _daylandtransportation = value; }
            get { return _daylandtransportation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DaySeaTransportation
        {
            set { _dayseatransportation = value; }
            get { return _dayseatransportation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DayAirTransportation
        {
            set { _dayairtransportation = value; }
            get { return _dayairtransportation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DayOtherTransportation
        {
            set { _dayothertransportation = value; }
            get { return _dayothertransportation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Long
        {
            set { _long = value; }
            get { return _long; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Color
        {
            set { _color = value; }
            get { return _color; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Image
        {
            set { _image = value; }
            get { return _image; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Style
        {
            set { _style = value; }
            get { return _style; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Texture
        {
            set { _texture = value; }
            get { return _texture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Standard
        {
            set { _standard = value; }
            get { return _standard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shape
        {
            set { _shape = value; }
            get { return _shape; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value0
        {
            set { _value0 = value; }
            get { return _value0; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value1
        {
            set { _value1 = value; }
            get { return _value1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value2
        {
            set { _value2 = value; }
            get { return _value2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value3
        {
            set { _value3 = value; }
            get { return _value3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value4
        {
            set { _value4 = value; }
            get { return _value4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value5
        {
            set { _value5 = value; }
            get { return _value5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value6
        {
            set { _value6 = value; }
            get { return _value6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value7
        {
            set { _value7 = value; }
            get { return _value7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value8
        {
            set { _value8 = value; }
            get { return _value8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value9
        {
            set { _value9 = value; }
            get { return _value9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        #endregion Model

    }
}

