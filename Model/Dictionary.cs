using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Dictionary:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dictionary
	{
		public Dictionary()
		{}
		#region Model
		private int? _idx;
		private int _catgid;
		private string _caption;
		private string _note;
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
		public string Caption
		{
			set{ _caption=value;}
			get{return _caption;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		#endregion Model

	}
}

