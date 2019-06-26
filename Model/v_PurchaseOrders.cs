using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// v_PurchaseOrders:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_PurchaseOrders
    {
        public v_PurchaseOrders()
        { }
        #region Model
        private int _id;
        private string _code;
        private string _buyer;
        private DateTime? _deliverydate;
        private int? _projectid;
        private string _currency;
        private decimal? _exchangerate;
        private decimal? _discountrate;
        private decimal? _taxrate;
        private string _payterm;
        private string _accountsmode;
        private decimal? _deposit;
        private decimal? _otherfees;
        private DateTime? _plansfactorydate;
        private DateTime? _factorydate;
        private string _transport;
        private string _deliveryaddress;
        private string _remark;
        private string _projectname;
        private string _suppliername;
        private string _linkman;
        private string _mobile;
        private string _principal;
        private string _curstatus;
        private string _curstatusno;
        private string _submitperson;
        private DateTime? _submitdate;
        private string _auditor;
        private DateTime? _auditdate;
        private string _creater;
        private DateTime? _create_date;
        private string _updater;
        private DateTime? _update_date;
        /// <summary>
        /// 
        /// </summary>
        public int ID
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
        public string Buyer
        {
            set { _buyer = value; }
            get { return _buyer; }
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
        public int? ProjectID
        {
            set { _projectid = value; }
            get { return _projectid; }
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
        public decimal? DiscountRate
        {
            set { _discountrate = value; }
            get { return _discountrate; }
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
        public string PayTerm
        {
            set { _payterm = value; }
            get { return _payterm; }
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
        public decimal? Deposit
        {
            set { _deposit = value; }
            get { return _deposit; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectName
        {
            set { _projectname = value; }
            get { return _projectname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SupplierName
        {
            set { _suppliername = value; }
            get { return _suppliername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Principal
        {
            set { _principal = value; }
            get { return _principal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string curStatus
        {
            set { _curstatus = value; }
            get { return _curstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string curStatusNo
        {
            set { _curstatusno = value; }
            get { return _curstatusno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubmitPerson
        {
            set { _submitperson = value; }
            get { return _submitperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SubmitDate
        {
            set { _submitdate = value; }
            get { return _submitdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Auditor
        {
            set { _auditor = value; }
            get { return _auditor; }
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
        public string creater
        {
            set { _creater = value; }
            get { return _creater; }
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
        public string updater
        {
            set { _updater = value; }
            get { return _updater; }
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
