using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// BaseMenu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BaseMenu
	{
		public BaseMenu()
		{}
		#region Model
		private int _menuid;
		private int? _parentmenuid;
		private int? _pageid;
		private string _menuname;
		private string _linkurl;
		private string _target;
		private string _value1;
		private string _value2;
		private string _value3;
		private int? _idx;
		private bool _ismenu;
		/// <summary>
		/// 
		/// </summary>
		public int MenuID
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentMenuID
		{
			set{ _parentmenuid=value;}
			get{return _parentmenuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PageID
		{
			set{ _pageid=value;}
			get{return _pageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LinkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Target
		{
			set{ _target=value;}
			get{return _target;}
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
		public int? IDX
		{
			set{ _idx=value;}
			get{return _idx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsMenu
		{
			set{ _ismenu=value;}
			get{return _ismenu;}
		}
		#endregion Model

	}
}

