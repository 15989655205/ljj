using System;
namespace Maticsoft.Model
{
	/// <summary>
    /// Employees:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Employees
	{
        public Employees()
		{}
		#region Model
		private long _userid;
		private int? _deptid;
		private string _roles;
		private string _username;
		private string _pwd;
		private string _name;
		private string _tel;
		private string _workid;
		private DateTime? _createddate;
		private int? _createdguy;
		private string _apprrole;
		private string _idcard;
		private string _nation;
		private DateTime? _dataofbirth;
		private int? _sex;
		private string _nativeplace;
		private string _regdresd;
		private string _address;
		private int? _maritalstatus;
		private int? _politicsstatus;
		private int? _bloodtype;
		private int? _education;
		private DateTime? _graduationdate;
		private DateTime? _entrydate;
		private int? _degree;
		private string _major;
		private string _email;
		private string _emcontact;
		private string _emcontacttel;
		private DateTime? _positivedates;
		private int? _stateemployees;
		private int? _approleid;
		private int? _permissions;
		private string _photo;
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
        private DateTime _createdate;
        private string _updateuser;
        private DateTime _updatedate;
		/// <summary>
		/// 
		/// </summary>
		public long UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Roles
		{
			set{ _roles=value;}
			get{return _roles;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkID
		{
			set{ _workid=value;}
			get{return _workid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedDate
		{
			set{ _createddate=value;}
			get{return _createddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreatedGuy
		{
			set{ _createdguy=value;}
			get{return _createdguy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApprRole
		{
			set{ _apprrole=value;}
			get{return _apprrole;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IDCard
		{
			set{ _idcard=value;}
			get{return _idcard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Nation
		{
			set{ _nation=value;}
			get{return _nation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Dataofbirth
		{
			set{ _dataofbirth=value;}
			get{return _dataofbirth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Nativeplace
		{
			set{ _nativeplace=value;}
			get{return _nativeplace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegdResd
		{
			set{ _regdresd=value;}
			get{return _regdresd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Maritalstatus
		{
			set{ _maritalstatus=value;}
			get{return _maritalstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Politicsstatus
		{
			set{ _politicsstatus=value;}
			get{return _politicsstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Bloodtype
		{
			set{ _bloodtype=value;}
			get{return _bloodtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Education
		{
			set{ _education=value;}
			get{return _education;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GraduationDate
		{
			set{ _graduationdate=value;}
			get{return _graduationdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EntryDate
		{
			set{ _entrydate=value;}
			get{return _entrydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Degree
		{
			set{ _degree=value;}
			get{return _degree;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Major
		{
			set{ _major=value;}
			get{return _major;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmContact
		{
			set{ _emcontact=value;}
			get{return _emcontact;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmContactTel
		{
			set{ _emcontacttel=value;}
			get{return _emcontacttel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Positivedates
		{
			set{ _positivedates=value;}
			get{return _positivedates;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StateEmployees
		{
			set{ _stateemployees=value;}
			get{return _stateemployees;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AppRoleID
		{
			set{ _approleid=value;}
			get{return _approleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Permissions
		{
			set{ _permissions=value;}
			get{return _permissions;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Photo
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value0
		{
			set{ _value0=value;}
			get{return _value0;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value1
		{
			set{ _value1=value;}
			get{return _value1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value2
		{
			set{ _value2=value;}
			get{return _value2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value3
		{
			set{ _value3=value;}
			get{return _value3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value4
		{
			set{ _value4=value;}
			get{return _value4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value5
		{
			set{ _value5=value;}
			get{return _value5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value6
		{
			set{ _value6=value;}
			get{return _value6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value7
		{
			set{ _value7=value;}
			get{return _value7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value8
		{
			set{ _value8=value;}
			get{return _value8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value9
		{
			set{ _value9=value;}
			get{return _value9;}
		}
        public string CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateUser
        {
            get { return _updateuser; }
            set { _updateuser = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateDate
        {
            get { return _updatedate; }
            set { _updatedate = value; }
        }
		#endregion Model

	}
}

