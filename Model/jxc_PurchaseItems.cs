using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// aaaaa:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class jxc_PurchaseItems
    {
        public jxc_PurchaseItems()
        { }
        #region Model
        private long _id;
        private string _productcode;
        private string _productname;
        private string _manufacturer;
        private string _pccode;
        private string _pcname;
        private string _unitname;
        private decimal? _amount;
        private decimal? _priceexcl;
        private decimal? _taxprice;
        private decimal? _discountrate;
        private decimal? _beforediscountprice;
        private decimal? _notaxprice;
        private decimal? _taxallprice;
        private string _remark;
        private string _code;
        private string _orderingproductdescription;
        private decimal? _receivedamount;
        private string _odd;
        private int? _purchaseitem;
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
        public string productCode
        {
            set { _productcode = value; }
            get { return _productcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productName
        {
            set { _productname = value; }
            get { return _productname; }
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
        public string pcCode
        {
            set { _pccode = value; }
            get { return _pccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pcName
        {
            set { _pcname = value; }
            get { return _pcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UnitName
        {
            set { _unitname = value; }
            get { return _unitname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PriceExcl
        {
            set { _priceexcl = value; }
            get { return _priceexcl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TaxPrice
        {
            set { _taxprice = value; }
            get { return _taxprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DiscountRate
        {
            set { _discountrate = value; }
            get { return _discountrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BeforeDiscountPrice
        {
            set { _beforediscountprice = value; }
            get { return _beforediscountprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? NoTaxPrice
        {
            set { _notaxprice = value; }
            get { return _notaxprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TaxAllPrice
        {
            set { _taxallprice = value; }
            get { return _taxallprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        public string OrderingProductDescription
        {
            set { _orderingproductdescription = value; }
            get { return _orderingproductdescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReceivedAmount
        {
            set { _receivedamount = value; }
            get { return _receivedamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Odd
        {
            set { _odd = value; }
            get { return _odd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PurchaseItem
        {
            set { _purchaseitem = value; }
            get { return _purchaseitem; }
        }
        #endregion Model

    }
}

