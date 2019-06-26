using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// approve_role:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class approve_role
	{
		public approve_role()
		{}
		#region Model
		private int _sid;
		private string _role_name;
		private int? _role_level;
		private string _role_post="";
		private int? _role_status=1;
		private string _remark;
		private string _value1;
		private string _value2;
		private string _value3;
		private string _value4;
		private string _value5;
		private string _value6;
		private int? _status=0;
		private string _create_person;
		private DateTime? _create_date;
		private string _update_person;
		private DateTime? _update_date;
		/// <summary>
		/// 
		/// </summary>
		public int sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string role_name
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? role_level
		{
			set{ _role_level=value;}
			get{return _role_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string role_post
		{
			set{ _role_post=value;}
			get{return _role_post;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? role_status
		{
			set{ _role_status=value;}
			get{return _role_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string value1
		{
			set{ _value1=value;}
			get{return _value1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string value2
		{
			set{ _value2=value;}
			get{return _value2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string value3
		{
			set{ _value3=value;}
			get{return _value3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string value4
		{
			set{ _value4=value;}
			get{return _value4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string value5
		{
			set{ _value5=value;}
			get{return _value5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string value6
		{
			set{ _value6=value;}
			get{return _value6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string create_person
		{
			set{ _create_person=value;}
			get{return _create_person;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? create_date
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string update_person
		{
			set{ _update_person=value;}
			get{return _update_person;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? update_date
		{
			set{ _update_date=value;}
			get{return _update_date;}
		}
		#endregion Model

	}
}

