using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// v_ProductColorShip:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_ProductColorShip
    {
        public v_ProductColorShip()
        { }
        #region Model
        private long _id;
        private string _codename;
        private string _code;
        private string _ptname;
        private long? _ptid;
        private string _psname;
        private long? _psid;
        private string _ppmnamme;
        private long? _ppmid;
        private string _bddcaption;
        private string _bddvalue;
        private string _sfullname;
        private long? _supplierid;
        private long _productid;
        private long _colorid;
        private string _enabled;
        private string _install;
        private long? _parentid;
        private string _barcode;
        private string _name;
        private string _specifications;
        private string _attribute;
        private decimal? _barginpriceout;
        private decimal? _standardpricein;
        private decimal? _referencepriceout;
        private decimal? _tagprice;
        private decimal? _minpriceout;
        private decimal? _profit;
        private decimal? _maxstock;
        private decimal? _minstock;
        private int? _stockproductcount;
        private int? _productpurchasecount;
        private decimal? _sellingcost;
        private decimal? _sellingprice;
        private decimal? _sellingprofit;
        private decimal? _referencepricea;
        private decimal? _referencepriceb;
        private decimal? _referencepricec;
        private decimal? _referencepriced;
        private decimal? _referencepricee;
        private decimal? _referencepricef;
        private decimal? _sellingaward;
        private decimal? _sellingroyaltyrate;
        private string _preinstallstock;
        private string _preinstallstockarea;
        private string _preinstallstocksite;
        private string _bulkunit;
        private string _unitbulk;
        private string _weightunit;
        private string _unitweight;
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
        private string _colorname;
        private string _colorcode;
        private string _image;
        private string _image1;
        private string _style;
        private string _texture;
        private string _standard;
        private string _shape;
        private string _remark;
        private string _createuser;
        private DateTime? _createdate;
        private string _updateuser;
        private DateTime? _updatedate;
        private string _value0;
        private string _value1;
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
        public string CodeName
        {
            set { _codename = value; }
            get { return _codename; }
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
        public string ptName
        {
            set { _ptname = value; }
            get { return _ptname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ptID
        {
            set { _ptid = value; }
            get { return _ptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string psName
        {
            set { _psname = value; }
            get { return _psname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? psID
        {
            set { _psid = value; }
            get { return _psid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ppmNamme
        {
            set { _ppmnamme = value; }
            get { return _ppmnamme; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ppmID
        {
            set { _ppmid = value; }
            get { return _ppmid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bddCaption
        {
            set { _bddcaption = value; }
            get { return _bddcaption; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bddValue
        {
            set { _bddvalue = value; }
            get { return _bddvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sFullName
        {
            set { _sfullname = value; }
            get { return _sfullname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? supplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long ColorID
        {
            set { _colorid = value; }
            get { return _colorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Enabled
        {
            set { _enabled = value; }
            get { return _enabled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Install
        {
            set { _install = value; }
            get { return _install; }
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
        public string Specifications
        {
            set { _specifications = value; }
            get { return _specifications; }
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
        public decimal? BarginPriceOut
        {
            set { _barginpriceout = value; }
            get { return _barginpriceout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? StandardPriceIn
        {
            set { _standardpricein = value; }
            get { return _standardpricein; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferencePriceOut
        {
            set { _referencepriceout = value; }
            get { return _referencepriceout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TagPrice
        {
            set { _tagprice = value; }
            get { return _tagprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinPriceOut
        {
            set { _minpriceout = value; }
            get { return _minpriceout; }
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
        public int? StockProductCount
        {
            set { _stockproductcount = value; }
            get { return _stockproductcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductPurchaseCount
        {
            set { _productpurchasecount = value; }
            get { return _productpurchasecount; }
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
        public decimal? SellingAward
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
        public string ColorName
        {
            set { _colorname = value; }
            get { return _colorname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ColorCode
        {
            set { _colorcode = value; }
            get { return _colorcode; }
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
        public string Image1
        {
            set { _image1 = value; }
            get { return _image1; }
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
        #endregion Model

    }
}

