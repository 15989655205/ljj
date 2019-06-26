using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// v_ProjectMaterialA:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_ProjectMaterialA
    {
        public v_ProjectMaterialA()
        { }
        #region Model
        private int _sid;
        private string _drawingnumber;
        private float? _amount;
        private string _color;
        private string _size;
        private string _brand;
        private string _remark;
        private int? _projectspaceid;
        private int? _locationid;
        private string _astatus;
        private int? _submit;
        private string _submitperson;
        private DateTime? _submitdate;
        private int? _audit;
        private string _auditor;
        private DateTime? _auditdate;
        private int? _checking;
        private string _checkperson;
        private DateTime? _checkdate;
        private string _create_person;
        private DateTime? _create_date;
        private string _update_person;
        private DateTime? _update_date;
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
        private string _location;
        private long? _typeid;
        private string _manufacturer;
        /// <summary>
        /// 
        /// </summary>
        public int sid
        {
            set { _sid = value; }
            get { return _sid; }
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
        public float? Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string colorName
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        public int? locationID
        {
            set { _locationid = value; }
            get { return _locationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AStatus
        {
            set { _astatus = value; }
            get { return _astatus; }
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
        public string location
        {
            set { _location = value; }
            get { return _location; }
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
        public string Manufacturer
        {
            set { _manufacturer = value; }
            get { return _manufacturer; }
        }
        #endregion Model

    }
}
