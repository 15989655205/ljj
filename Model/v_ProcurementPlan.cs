using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// v_ProcurementPlan:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_ProcurementPlan
    {
        public v_ProcurementPlan()
        { }
        #region Model
        private long _id;
        private int? _item;
        private string _odd;
        private int? _plantypeid;
        private string _plantypename;
        private string _colorname;
        private string _size;
        private decimal? _planamount;
        private decimal? _expectedprice;
        private decimal? _summoney;
        private decimal? _discount;
        private DateTime? _planspurchasedate;
        private DateTime? _plansfactorydate;
        private DateTime? _expectedarrivaldate;
        private string _planssupplier;
        private string _remark;
        private string _code;
        private string _name;
        private string _image;
        private string _colorcode;
        private string _unitname;
        private long? _spid;
        private string _suppliername;
        private string _fullname;
        private string _curstatus;
        private int? _submit;
        private int? _audit;
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
        public string PlanTypeName
        {
            set { _plantypename = value; }
            get { return _plantypename; }
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
        public decimal? ExpectedPrice
        {
            set { _expectedprice = value; }
            get { return _expectedprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sumMoney
        {
            set { _summoney = value; }
            get { return _summoney; }
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string image
        {
            set { _image = value; }
            get { return _image; }
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
        public string unitName
        {
            set { _unitname = value; }
            get { return _unitname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? spID
        {
            set { _spid = value; }
            get { return _spid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string supplierName
        {
            set { _suppliername = value; }
            get { return _suppliername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FullName
        {
            set { _fullname = value; }
            get { return _fullname; }
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
        public int? Submit
        {
            set { _submit = value; }
            get { return _submit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Audit
        {
            set { _audit = value; }
            get { return _audit; }
        }
        #endregion Model

    }
}
