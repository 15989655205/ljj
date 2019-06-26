using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// BaseDictionaryDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BaseDictionaryDetail
	{
		public BaseDictionaryDetail()
		{}
		#region Model
		private int? _idx;
		private int _catgid;
		private int? _parentcatgid;
		private string _caption;
		private string _value;
		private string _value1;
		private string _value2;
		private string _value3;
		/// <summary>
		/// 
		/// </summary>
		public int? Idx
		{
			set{ _idx=value;}
			get{return _idx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CatgID
		{
			set{ _catgid=value;}
			get{return _catgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentCatgID
		{
			set{ _parentcatgid=value;}
			get{return _parentcatgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Caption
		{
			set{ _caption=value;}
			get{return _caption;}
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
		#endregion Model

	}
}

