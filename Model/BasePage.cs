using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// BasePage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BasePage
	{
		public BasePage()
		{}
		#region Model
		private int _pageid;
		private string _pagename;
		private string _note;
		private string _cmds;
		private int? _parentpageid;
		/// <summary>
		/// 
		/// </summary>
		public int PageID
		{
			set{ _pageid=value;}
			get{return _pageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PageName
		{
			set{ _pagename=value;}
			get{return _pagename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Cmds
		{
			set{ _cmds=value;}
			get{return _cmds;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentPageID
		{
			set{ _parentpageid=value;}
			get{return _parentpageid;}
		}
		#endregion Model

	}
}

