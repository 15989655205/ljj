using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// folder:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class folder
	{
		public folder()
		{}
		#region Model
		private int _id;
		private string _folder_name;
		private string _dowm_permission;
		private string _up_permission;
		private string _remark;
		private string _folder_path;
		private DateTime? _create_date;
		private string _create_person;
		private string _update_person;
		private DateTime? _update_date;
		private int? _folder_level;
		private string _value1;
		private string _value2;
		private string _value3;
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
		public string folder_name
		{
			set{ _folder_name=value;}
			get{return _folder_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dowm_permission
		{
			set{ _dowm_permission=value;}
			get{return _dowm_permission;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string up_permission
		{
			set{ _up_permission=value;}
			get{return _up_permission;}
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
		public string folder_path
		{
			set{ _folder_path=value;}
			get{return _folder_path;}
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
		public string create_person
		{
			set{ _create_person=value;}
			get{return _create_person;}
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
		/// <summary>
		/// 
		/// </summary>
		public int? folder_level
		{
			set{ _folder_level=value;}
			get{return _folder_level;}
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
		#endregion Model

	}
}

