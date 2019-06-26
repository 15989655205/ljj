using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// ProductColor:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProductColor
    {
        public ProductColor()
        { }
        #region Model
        private long _id;
        private long? _parentid;
        private string _code;
        private string _name;
        private string _attribute;
        private decimal? _barginpriceout;
        private decimal? _referencepriceout;
        private decimal? _standardpricein;
        private decimal? _minpriceout;
        private decimal? _profit;
        private decimal? _tagprice;
        private string _image;
        private decimal? _referencepricea;
        private decimal? _referencepriceb;
        private decimal? _referencepricec;
        private decimal? _referencepriced;
        private decimal? _referencepricee;
        private decimal? _referencepricef;
        private decimal? _sellingaward;
        private decimal? _sellingroyaltyrate;
        private int? _stockproductcount;
        private int? _productpurchasecount;
        private decimal? _sellingcost;
        private decimal? _processcost;
        private decimal? _transcost;
        private decimal? _sellingprice;
        private decimal? _sellingprofit;
        private string _member;
        private bool _enabled;
        private int? _status;
        private string _remark;
        private string _value0;
        private string _value1;
        private string _value2;
        private string _value3;
        private string _value4;
        private string _value5;
        private string _value6;
        private string _value7;
        private string _value8;
        private string _value9;
        private string _createuser;
        private DateTime? _createdate;
        private string _updateuser;
        private DateTime? _updatedate;
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
        public string Code
        {
            set { _code = value; }
            get { return _code; }
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
        public decimal? ReferencePriceOut
        {
            set { _referencepriceout = value; }
            get { return _referencepriceout; }
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
        public decimal? TagPrice
        {
            set { _tagprice = value; }
            get { return _tagprice; }
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
        public decimal? ProcessCost
        {
            set { _processcost = value; }
            get { return _processcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TransCost
        {
            set { _transcost = value; }
            get { return _transcost; }
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
        public string Member
        {
            set { _member = value; }
            get { return _member; }
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
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
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

