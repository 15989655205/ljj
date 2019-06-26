using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// Project_Product_Material_B:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Project_Product_Material_B
    {
        public Project_Product_Material_B()
        { }
        #region Model
        private int _id;
        private int? _projectid;
        private int? _spaceid;
        private long? _productid;
        private string _filenumber;
        private string _drawingnumber;
        private decimal? _amount;
        private string _acolor;
        private string _asize;
        private string _abrand;
        private string _color;
        private string _size;
        private string _brand;
        private string _supplierid;
        private int? _sumbit;
        private string _submitperson;
        private DateTime? _submitdate;
        private int? _audit;
        private string _auditperson;
        private DateTime? _auditdate;
        private int? _checking;
        private string _checkperson;
        private DateTime? _checkdate;
        private int? _sequence = 0;
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
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        public long? ProductID
        {
            set { _productid = value; }
            get { return _productid; }
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
        public string supplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
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
        public int? sequence
        {
            set { _sequence = value; }
            get { return _sequence; }
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
