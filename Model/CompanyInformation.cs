using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// CompanyInformation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CompanyInformation
	{
		public CompanyInformation()
		{}
		#region Model
		private int _id;
		private string _number;
		private string _abbreviation;
		private string _fullname;
		private string _address;
		private string _enaddress;
		private string _head;
		private string _fixedphone;
		private string _mobilephone;
		private string _fax;
		private string _zipcode;
		private string _corpid;
		private string _openingbank;
		private string _account;
		private string _customscode;
		private string _legalrepresentative;
		private string _remark;
		private int? _status;
		private decimal? _eticprice;
		private decimal? _packprice;
		private string _enabbreviation;
		private string _enfullname;
		private string _value;
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
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Abbreviation
		{
			set{ _abbreviation=value;}
			get{return _abbreviation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FullName
		{
			set{ _fullname=value;}
			get{return _fullname;}
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
		public string EnAddress
		{
			set{ _enaddress=value;}
			get{return _enaddress;}
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
		public string FixedPhone
		{
			set{ _fixedphone=value;}
			get{return _fixedphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MobilePhone
		{
			set{ _mobilephone=value;}
			get{return _mobilephone;}
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
		public string ZipCode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CorpId
		{
			set{ _corpid=value;}
			get{return _corpid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OpeningBank
		{
			set{ _openingbank=value;}
			get{return _openingbank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Account
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomsCode
		{
			set{ _customscode=value;}
			get{return _customscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LegalRepresentative
		{
			set{ _legalrepresentative=value;}
			get{return _legalrepresentative;}
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
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? EticPrice
		{
			set{ _eticprice=value;}
			get{return _eticprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PackPrice
		{
			set{ _packprice=value;}
			get{return _packprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EnAbbreviation
		{
			set{ _enabbreviation=value;}
			get{return _enabbreviation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EnFullName
		{
			set{ _enfullname=value;}
			get{return _enfullname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value
		{
			set{ _value=value;}
			get{return _value;}
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

