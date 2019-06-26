using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Client:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Client
	{
		public Client()
		{}
		#region Model
		private long _id;
		private long? _clevel;
		private long? _type;
		private string _code;
		private string _name;
		private string _address;
		private string _head;
		private string _phone;
		private string _tel;
		private string _fax;
		private string _email;
		private string _businesslicense;
		private string _currency;
		private decimal? _parities;
		private DateTime? _reconciliationdate;
		private DateTime? _setupdate;
		private bool _supplier;
		private DateTime? _begindate;
		private DateTime? _enddate;
		private bool _enable;
		private int? _status;
		private string _area;
		private string _industry;
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
		private long? _createuser;
		private DateTime? _createdate;
		private long? _updateuser;
		private DateTime? _updatedate;
		/// <summary>
		/// 
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? CLevel
		{
			set{ _clevel=value;}
			get{return _clevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
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
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Head
		{
			set{ _head=value;}
			get{return _head;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
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
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
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
		public string BusinessLicense
		{
			set{ _businesslicense=value;}
			get{return _businesslicense;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Currency
		{
			set{ _currency=value;}
			get{return _currency;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Parities
		{
			set{ _parities=value;}
			get{return _parities;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReconciliationDate
		{
			set{ _reconciliationdate=value;}
			get{return _reconciliationdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SetupDate
		{
			set{ _setupdate=value;}
			get{return _setupdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Supplier
		{
			set{ _supplier=value;}
			get{return _supplier;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BeginDate
		{
			set{ _begindate=value;}
			get{return _begindate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndDate
		{
			set{ _enddate=value;}
			get{return _enddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Industry
		{
			set{ _industry=value;}
			get{return _industry;}
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
		/// <summary>
		/// 
		/// </summary>
		public long? CreateUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? UpdateUser
		{
			set{ _updateuser=value;}
			get{return _updateuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model

	}
}

