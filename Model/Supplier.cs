using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Supplier:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Supplier
	{
		public Supplier()
		{}
		#region Model
		private long _id;
		private string _typeid;
		private string _code;
		private bool _enabled;
		private string _abbreviation;
		private string _fullname;
		private string _enabbreviation;
		private string _enfullname;
		private string _address;
		private string _enaddress;
		private decimal? _margin;
		private decimal? _taxrate;
		private string _typecode;
		private string _currency;
		private string _zipcode;
		private string _paymentterms;
		private string _principal;
		private string _linkman;
		private string _buyer;
		private string _purchasingcycle;
		private string _purchasingcycletable;
		private string _purchasinggoodscycle;
		private string _paymentmethod;
		private string _landtransportation;
		private string _seatransportation;
		private string _airtransportation;
		private string _othertransportation;
		private string _depositbank;
		private string _bankaccount;
		private string _psubject;
		private string _posubject;
		private string _tsubject;
		private string _pcproject;
		private string _tcproject;
		private string _fixed;
		private string _fax;
		private string _mobile;
		private int? _status;
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
		private DateTime? _createdate= DateTime.Now;
		private string _updateuser;
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
		public string TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
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
		public bool Enabled
		{
			set{ _enabled=value;}
			get{return _enabled;}
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
		public decimal? Margin
		{
			set{ _margin=value;}
			get{return _margin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TaxRate
		{
			set{ _taxrate=value;}
			get{return _taxrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeCode
		{
			set{ _typecode=value;}
			get{return _typecode;}
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
		public string ZipCode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PaymentTerms
		{
			set{ _paymentterms=value;}
			get{return _paymentterms;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Principal
		{
			set{ _principal=value;}
			get{return _principal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Linkman
		{
			set{ _linkman=value;}
			get{return _linkman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Buyer
		{
			set{ _buyer=value;}
			get{return _buyer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PurchasingCycle
		{
			set{ _purchasingcycle=value;}
			get{return _purchasingcycle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PurchasingCycleTable
		{
			set{ _purchasingcycletable=value;}
			get{return _purchasingcycletable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PurchasingGoodsCycle
		{
			set{ _purchasinggoodscycle=value;}
			get{return _purchasinggoodscycle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PaymentMethod
		{
			set{ _paymentmethod=value;}
			get{return _paymentmethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LandTransportation
		{
			set{ _landtransportation=value;}
			get{return _landtransportation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SeaTransportation
		{
			set{ _seatransportation=value;}
			get{return _seatransportation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AirTransportation
		{
			set{ _airtransportation=value;}
			get{return _airtransportation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherTransportation
		{
			set{ _othertransportation=value;}
			get{return _othertransportation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepositBank
		{
			set{ _depositbank=value;}
			get{return _depositbank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankAccount
		{
			set{ _bankaccount=value;}
			get{return _bankaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PSubject
		{
			set{ _psubject=value;}
			get{return _psubject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string POSubject
		{
			set{ _posubject=value;}
			get{return _posubject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TSubject
		{
			set{ _tsubject=value;}
			get{return _tsubject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PCProject
		{
			set{ _pcproject=value;}
			get{return _pcproject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TCProject
		{
			set{ _tcproject=value;}
			get{return _tcproject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fixed
		{
			set{ _fixed=value;}
			get{return _fixed;}
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
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
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
		public string CreateUser
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
		public string UpdateUser
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

