using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// File_Dowm_Detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class File_Dowm_Detail
	{
		public File_Dowm_Detail()
		{}
		#region Model
		private int _id;
		private int? _file_id;
		private int? _dowm_person;
		private DateTime? _dowm_date;
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
		public int? file_id
		{
			set{ _file_id=value;}
			get{return _file_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dowm_person
		{
			set{ _dowm_person=value;}
			get{return _dowm_person;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dowm_date
		{
			set{ _dowm_date=value;}
			get{return _dowm_date;}
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

