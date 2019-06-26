using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
   /// <summary>
	/// v_ProjectMaterialAToB:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    [Serializable]
    public partial class v_ProjectMaterialAToB
    {
        public v_ProjectMaterialAToB()
        { }
        #region Model
        private string _unitname;
        private string _unit;
        private decimal? _amount;
        private string _color;
        private string _size;
        private string _brand;
        private int? _projectspaceid;
        private int? _submit;
        private string _submitperson;
        private DateTime? _submitdate;
        private int? _audit;
        private string _auditor;
        private DateTime? _auditdate;
        private int? _checking;
        private string _checkperson;
        private DateTime? _checkdate;
        private int _placeid;
        private int _spaceid;
        private int _projectid;
        private long _productid;
        private string _place;
        private string _space;
        private string _projectname;
        private string _productcode;
        private string _productname;
        private string _quality;
        private string _nfk;
        private long? _typeid;
        private string _producttypename;
        private int? _producttyperootid;
        private string _producttyperoot;
        private string _supplierid;
        private string _suppliercode;
        private string _suppliername;
        private string _suppliermobile;
        private string _colorb;
        private string _brandb;
        private string _remarkb;
        private string _manufacturer;
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
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
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
        public string Color
        {
            set { _color = value; }
            get { return _color; }
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
        public string Brand
        {
            set { _brand = value; }
            get { return _brand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? projectSpaceID
        {
            set { _projectspaceid = value; }
            get { return _projectspaceid; }
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
        public int? Audit
        {
            set { _audit = value; }
            get { return _audit; }
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
        public int? Checking
        {
            set { _checking = value; }
            get { return _checking; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CheckPerson
        {
            set { _checkperson = value; }
            get { return _checkperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CheckDate
        {
            set { _checkdate = value; }
            get { return _checkdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int placeID
        {
            set { _placeid = value; }
            get { return _placeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int spaceID
        {
            set { _spaceid = value; }
            get { return _spaceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int projectID
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long productID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string place
        {
            set { _place = value; }
            get { return _place; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string space
        {
            set { _space = value; }
            get { return _space; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string projectName
        {
            set { _projectname = value; }
            get { return _projectname; }
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
        public string Quality
        {
            set { _quality = value; }
            get { return _quality; }
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
        public string productTYpeName
        {
            set { _producttypename = value; }
            get { return _producttypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? productTypeRootID
        {
            set { _producttyperootid = value; }
            get { return _producttyperootid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductTypeRoot
        {
            set { _producttyperoot = value; }
            get { return _producttyperoot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string supplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string supplierCode
        {
            set { _suppliercode = value; }
            get { return _suppliercode; }
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
        public string supplierMobile
        {
            set { _suppliermobile = value; }
            get { return _suppliermobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string colorB
        {
            set { _colorb = value; }
            get { return _colorb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brandB
        {
            set { _brandb = value; }
            get { return _brandb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remarkB
        {
            set { _remarkb = value; }
            get { return _remarkb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Manufacturer
        {
            set { _manufacturer = value; }
            get { return _manufacturer; }
        }
        #endregion Model
    }
}
