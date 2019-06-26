using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// jxc_ProcurementPlanNew:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class jxc_ProcurementPlanNew
    {
        public jxc_ProcurementPlanNew()
        { }
        #region Model
        private long _id;
        private int? _item;
        private string _odd;
        private int? _plantypeid;
        private int? _projectid;
        private int? _spaceid;
        private long _productid;
        private long? _colorid;
        private string _colorname;
        private string _size;
        private decimal? _planamount;
        private decimal? _purchasedamount;
        private decimal? _expectedprice;
        private decimal? _discount = 1M;
        private DateTime? _planspurchasedate;
        private DateTime? _plansfactorydate;
        private DateTime? _expectedarrivaldate;
        private string _planssupplier;
        private string _supplier;
        private string _productodd;
        private int? _orderitem;
        private int? _state;
        private string _directions;
        private int? _submit;
        private string _submitguy;
        private DateTime? _submitdate;
        private int? _audit;
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
        public int? Item
        {
            set { _item = value; }
            get { return _item; }
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
        public int? PlanTypeID
        {
            set { _plantypeid = value; }
            get { return _plantypeid; }
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
        public int? SpaceID
        {
            set { _spaceid = value; }
            get { return _spaceid; }
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
        public long? ColorID
        {
            set { _colorid = value; }
            get { return _colorid; }
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
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PlanAmount
        {
            set { _planamount = value; }
            get { return _planamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PurchasedAmount
        {
            set { _purchasedamount = value; }
            get { return _purchasedamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ExpectedPrice
        {
            set { _expectedprice = value; }
            get { return _expectedprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PlansPurchaseDate
        {
            set { _planspurchasedate = value; }
            get { return _planspurchasedate; }
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
        public DateTime? ExpectedArrivalDate
        {
            set { _expectedarrivaldate = value; }
            get { return _expectedarrivaldate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlansSupplier
        {
            set { _planssupplier = value; }
            get { return _planssupplier; }
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
        public string ProductOdd
        {
            set { _productodd = value; }
            get { return _productodd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OrderItem
        {
            set { _orderitem = value; }
            get { return _orderitem; }
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
        public int? Submit
        {
            set { _submit = value; }
            get { return _submit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubmitGuy
        {
            set { _submitguy = value; }
            get { return _submitguy; }
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
        public int? Audit
        {
            set { _audit = value; }
            get { return _audit; }
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
