using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// v_ProjectMaterialB:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_ProjectMaterialB
    {
        public v_ProjectMaterialB()
        { }
        #region Model
        private int _id;
        private string _filenumber;
        private string _name;
        private long? _ptid;
        private long? _spid;
        private string _project_name;
        private string _manufacturernumber;
        private int? _projectid;
        private long? _productid;
        private string _drawingnumber;
        private decimal? _amount;
        private string _acolor;
        private string _asize;
        private string _abrand;
        private string _colorID;
        private string _colorName;
        private string _size;
        private string _brand;
        private int? _sumbit;
        private string _submitperson;
        private DateTime? _submitdate;
        private int? _audit;
        private string _auditperson;
        private DateTime? _auditdate;
        private int? _checking;
        private string _checkperson;
        private DateTime? _checkdate;
        private string _remark;
        private string _productcode;
        private string _productname;
        private string _quality;
        private string _nfk;
        private long? _typeid;
        private string _producttypename;
        private int? _producttyperootid;
        private string _producttyperoot;
        private string _manufacturer;
        private string _suppliercode;
        private string _suppliermobile;
        private string _suppliername;
        private string _image;
        private string _address;
        private string _linkman;
        private string _place;
        private string _space;
        private string _colorCode;

        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }


        public string ColorID
        {
            get { return _colorID; }
            set { _colorID = value; }
        }
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
        public string FileNumber
        {
            set { _filenumber = value; }
            get { return _filenumber; }
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
        public long? ptID
        {
            set { _ptid = value; }
            get { return _ptid; }
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
        public string project_name
        {
            set { _project_name = value; }
            get { return _project_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manufacturerNumber
        {
            set { _manufacturernumber = value; }
            get { return _manufacturernumber; }
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
        public long? productID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DrawingNumber
        {
            set { _drawingnumber = value; }
            get { return _drawingnumber; }
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
        public string AColor
        {
            set { _acolor = value; }
            get { return _acolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ASize
        {
            set { _asize = value; }
            get { return _asize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ABrand
        {
            set { _abrand = value; }
            get { return _abrand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Color
        {
            set { _colorName = value; }
            get { return _colorName; }
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
        public int? Sumbit
        {
            set { _sumbit = value; }
            get { return _sumbit; }
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
        public string AuditPerson
        {
            set { _auditperson = value; }
            get { return _auditperson; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        public string productTypeName
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
        public string Manufacturer
        {
            set { _manufacturer = value; }
            get { return _manufacturer; }
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
        public string supplierMobile
        {
            set { _suppliermobile = value; }
            get { return _suppliermobile; }
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
        public string Image
        {
            set { _image = value; }
            get { return _image; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Linkman
        {
            set { _linkman = value; }
            get { return _linkman; }
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
        #endregion Model
        //#region Model
        //private string _filenumber;
        //private string _productitem;
        //private string _ppmibrand;
        //private string _manufacturerphone;
        //private string _ppmiremark;
        //private string _name;
        //private long? _ptid;
        //private long? _spid;
        //private string _productname;
        //private string _project_name;
        //private string _manufacturernumber;
        //private int? _projectid;
        //private string _psname;
        //private long? _productid;
        //private int? _ppmisid;
        //private int typeID;

        //public int TypeID
        //{
        //    get { return typeID; }
        //    set { typeID = value; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string FileNumber
        //{
        //    set { _filenumber = value; }
        //    get { return _filenumber; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string ProductItem
        //{
        //    set { _productitem = value; }
        //    get { return _productitem; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string ppmiBrand
        //{
        //    set { _ppmibrand = value; }
        //    get { return _ppmibrand; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string manufacturerPhone
        //{
        //    set { _manufacturerphone = value; }
        //    get { return _manufacturerphone; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string ppmiRemark
        //{
        //    set { _ppmiremark = value; }
        //    get { return _ppmiremark; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string Name
        //{
        //    set { _name = value; }
        //    get { return _name; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public long? ptID
        //{
        //    set { _ptid = value; }
        //    get { return _ptid; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public long? spID
        //{
        //    set { _spid = value; }
        //    get { return _spid; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string productName
        //{
        //    set { _productname = value; }
        //    get { return _productname; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string project_name
        //{
        //    set { _project_name = value; }
        //    get { return _project_name; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string manufacturerNumber
        //{
        //    set { _manufacturernumber = value; }
        //    get { return _manufacturernumber; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public int? ProjectID
        //{
        //    set { _projectid = value; }
        //    get { return _projectid; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string psName
        //{
        //    set { _psname = value; }
        //    get { return _psname; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public long? productID
        //{
        //    set { _productid = value; }
        //    get { return _productid; }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public int? ppmiSid
        //{
        //    set { _ppmisid = value; }
        //    get { return _ppmisid; }
        //}
        //#endregion Model

    }
}

