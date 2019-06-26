using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// ProductItem:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProductPriceColorShip
    {
        public ProductPriceColorShip()
        { }
        #region Model
        private long _id;
        private string _code=" ";
        private long? _productid;
        private long? _colorid=0;
        private string _corlor = " ";
        private string _size = " ";
        private string _quality = " ";
        private string _brand = " ";
        private string _nfk = " ";
        private string _attribute = "";
        private decimal? _barginpriceout;
        private decimal? _referencepriceout;
        private decimal? _standardpricein;
        private decimal? _minpriceout;
        private decimal? _profit;
        private decimal? _tagprice;
        private string _image = " ";
        private decimal? _maxstock;
        private decimal? _minstock;
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
        private string _status;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ColorID
        {
            set { _colorid = value; }
            get { return _colorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Corlor
        {
            set { _corlor = value; }
            get { return _corlor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Quality
        {
            set { _quality = value; }
            get { return _quality; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Brand
        {
            set { _brand = value; }
            get { return _brand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NFK
        {
            set { _nfk = value; }
            get { return _nfk; }
        }
        /// <summary>
        /// 商品属性:1所有颜色正价2所有颜色特价3部分颜色特价
        /// </summary>
        public string Attribute
        {
            set { _attribute = value; }
            get { return _attribute; }
        }
        /// <summary>
        /// 促销价
        /// </summary>
        public decimal? BarginPriceOut
        {
            set { _barginpriceout = value; }
            get { return _barginpriceout; }
        }
        /// <summary>
        /// 参考售价
        /// </summary>
        public decimal? ReferencePriceOut
        {
            set { _referencepriceout = value; }
            get { return _referencepriceout; }
        }
        /// <summary>
        /// 标准进价
        /// </summary>
        public decimal? StandardPriceIn
        {
            set { _standardpricein = value; }
            get { return _standardpricein; }
        }
        /// <summary>
        /// 最低售价
        /// </summary>
        public decimal? MinPriceOut
        {
            set { _minpriceout = value; }
            get { return _minpriceout; }
        }
        /// <summary>
        /// 利润
        /// </summary>
        public decimal? Profit
        {
            set { _profit = value; }
            get { return _profit; }
        }
        /// <summary>
        /// 标签价格
        /// </summary>
        public decimal? TagPrice
        {
            set { _tagprice = value; }
            get { return _tagprice; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public string Image
        {
            set { _image = value; }
            get { return _image; }
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
        /// 参考价格A
        /// </summary>
        public decimal? ReferencePriceA
        {
            set { _referencepricea = value; }
            get { return _referencepricea; }
        }
        /// <summary>
        /// 参考价格B
        /// </summary>
        public decimal? ReferencePriceB
        {
            set { _referencepriceb = value; }
            get { return _referencepriceb; }
        }
        /// <summary>
        /// 参考价格C
        /// </summary>
        public decimal? ReferencePriceC
        {
            set { _referencepricec = value; }
            get { return _referencepricec; }
        }
        /// <summary>
        /// 参考价格D
        /// </summary>
        public decimal? ReferencePriceD
        {
            set { _referencepriced = value; }
            get { return _referencepriced; }
        }
        /// <summary>
        /// 参考价格E
        /// </summary>
        public decimal? ReferencePriceE
        {
            set { _referencepricee = value; }
            get { return _referencepricee; }
        }
        /// <summary>
        /// 参考价格F
        /// </summary>
        public decimal? ReferencePriceF
        {
            set { _referencepricef = value; }
            get { return _referencepricef; }
        }
        /// <summary>
        /// 销售奖励
        /// </summary>
        public decimal? SellingAward
        {
            set { _sellingaward = value; }
            get { return _sellingaward; }
        }
        /// <summary>
        /// 销售提成
        /// </summary>
        public decimal? SellingRoyaltyRate
        {
            set { _sellingroyaltyrate = value; }
            get { return _sellingroyaltyrate; }
        }
        /// <summary>
        /// 库存商品数量
        /// </summary>
        public int? StockProductCount
        {
            set { _stockproductcount = value; }
            get { return _stockproductcount; }
        }
        /// <summary>
        /// 商品采购数量
        /// </summary>
        public int? ProductPurchaseCount
        {
            set { _productpurchasecount = value; }
            get { return _productpurchasecount; }
        }
        /// <summary>
        /// 销售成本
        /// </summary>
        public decimal? SellingCost
        {
            set { _sellingcost = value; }
            get { return _sellingcost; }
        }
        /// <summary>
        /// 加工费
        /// </summary>
        public decimal? ProcessCost
        {
            set { _processcost = value; }
            get { return _processcost; }
        }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal? TransCost
        {
            set { _transcost = value; }
            get { return _transcost; }
        }
        /// <summary>
        /// 销售费用
        /// </summary>
        public decimal? SellingPrice
        {
            set { _sellingprice = value; }
            get { return _sellingprice; }
        }
        /// <summary>
        /// 销售利润
        /// </summary>
        public decimal? SellingProfit
        {
            set { _sellingprofit = value; }
            get { return _sellingprofit; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        public string value0
        {
            get { return _value0; }
            set { _value0 = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value1
        {
            set { _value1 = value; }
            get { return _value1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value2
        {
            set { _value2 = value; }
            get { return _value2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value3
        {
            set { _value3 = value; }
            get { return _value3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value4
        {
            set { _value4 = value; }
            get { return _value4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value5
        {
            set { _value5 = value; }
            get { return _value5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value6
        {
            set { _value6 = value; }
            get { return _value6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value7
        {
            set { _value7 = value; }
            get { return _value7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value8
        {
            set { _value8 = value; }
            get { return _value8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value9
        {
            set { _value9 = value; }
            get { return _value9; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 状态:OP启用;CA停用;
        /// </summary>
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        #endregion Model

    }
}

