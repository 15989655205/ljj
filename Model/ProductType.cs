using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ProductType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductType
	{
		public ProductType()
		{}
		#region Model
		private long _id;
		private long? _parentid;
		private string _code;
		private string _name;
		private int? _level;
		private bool _enabled;
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
		public long? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		public int? Level
		{
			set{ _level=value;}
			get{return _level;}
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

