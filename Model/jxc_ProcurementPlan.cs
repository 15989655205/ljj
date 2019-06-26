using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// jxc_ProcurementPlan:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class jxc_ProcurementPlan
    {
        public jxc_ProcurementPlan()
        { }
        #region Model
        private long _id;
        private string _odd;
        private DateTime? _orderdate;
        private string _buyer;
        private string _supplier;
        private string _supplierhandled;
        private DateTime? _deliverydate;
        private string _currency;
        private decimal? _exchangerate;
        private decimal? _pricereduction;
        private string _payterm;
        private decimal? _discountrate;
        private decimal? _deposit;
        private string _accountsmode;
        private decimal? _taxrate;
        private decimal? _otherfees;
        private DateTime? _plansfactorydate;
        private DateTime? _factorydate;
        private string _transport;
        private string _deliveryaddress;
        private int? _state;
        private string _directions;
        private DateTime? _auditdate;
        private string _auditguy;
        private string _remark;
        private string _v1;
        private string _v2;
        private string _v3;
        private string _v4;
        private string _v5;
        private string _v6;
        private string _v7;
        private string _v8;
        private string _v9;
        private string _v10;
        private int? _n1;
        private int? _n2;
        private int? _n3;
        private string _show;
        private string _show_name;
        private int? _status = 1;
        private string _create_person;
        private DateTime? _create_date = DateTime.Now;
        private string _update_person;
        private DateTime? _update_date;
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
        public string Odd
        {
            set { _odd = value; }
            get { return _odd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Buyer
        {
            set { _buyer = value; }
            get { return _buyer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Supplier
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SupplierHandled
        {
            set { _supplierhandled = value; }
            get { return _supplierhandled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DeliveryDate
        {
            set { _deliverydate = value; }
            get { return _deliverydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ExchangeRate
        {
            set { _exchangerate = value; }
            get { return _exchangerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PriceReduction
        {
            set { _pricereduction = value; }
            get { return _pricereduction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayTerm
        {
            set { _payterm = value; }
            get { return _payterm; }
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
        public decimal? Deposit
        {
            set { _deposit = value; }
            get { return _deposit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AccountsMode
        {
            set { _accountsmode = value; }
            get { return _accountsmode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TaxRate
        {
            set { _taxrate = value; }
            get { return _taxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OtherFees
        {
            set { _otherfees = value; }
            get { return _otherfees; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PlansFactoryDate
        {
            set { _plansfactorydate = value; }
            get { return _plansfactorydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? FactoryDate
        {
            set { _factorydate = value; }
            get { return _factorydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Transport
        {
            set { _transport = value; }
            get { return _transport; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeliveryAddress
        {
            set { _deliveryaddress = value; }
            get { return _deliveryaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Directions
        {
            set { _directions = value; }
            get { return _directions; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AuditDate
        {
            set { _auditdate = value; }
            get { return _auditdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditGuy
        {
            set { _auditguy = value; }
            get { return _auditguy; }
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
        public string v1
        {
            set { _v1 = value; }
            get { return _v1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v2
        {
            set { _v2 = value; }
            get { return _v2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v3
        {
            set { _v3 = value; }
            get { return _v3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v4
        {
            set { _v4 = value; }
            get { return _v4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v5
        {
            set { _v5 = value; }
            get { return _v5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v6
        {
            set { _v6 = value; }
            get { return _v6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v7
        {
            set { _v7 = value; }
            get { return _v7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v8
        {
            set { _v8 = value; }
            get { return _v8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v9
        {
            set { _v9 = value; }
            get { return _v9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v10
        {
            set { _v10 = value; }
            get { return _v10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? n1
        {
            set { _n1 = value; }
            get { return _n1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? n2
        {
            set { _n2 = value; }
            get { return _n2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? n3
        {
            set { _n3 = value; }
            get { return _n3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string show
        {
            set { _show = value; }
            get { return _show; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string show_name
        {
            set { _show_name = value; }
            get { return _show_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string create_person
        {
            set { _create_person = value; }
            get { return _create_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? create_date
        {
            set { _create_date = value; }
            get { return _create_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string update_person
        {
            set { _update_person = value; }
            get { return _update_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? update_date
        {
            set { _update_date = value; }
            get { return _update_date; }
        }
        #endregion Model

    }
}

