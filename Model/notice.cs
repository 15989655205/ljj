using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// notice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class notice
	{
		public notice()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _summary;
		private string _intro;
		private string _notice_content;
		private long? _createuserid;
		private DateTime? _createtime;
		private long? _updateuserid;
		private DateTime? _updatetime;
		private string _url;
		private int? _show;
		private int? _status;
		private string _v1;
		private string _v2;
		private string _v3;
		private string _v4;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string summary
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string notice_content
		{
			set{ _notice_content=value;}
			get{return _notice_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? CreateUserID
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? UpdateUserID
		{
			set{ _updateuserid=value;}
			get{return _updateuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? show
		{
			set{ _show=value;}
			get{return _show;}
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
		public string v1
		{
			set{ _v1=value;}
			get{return _v1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v2
		{
			set{ _v2=value;}
			get{return _v2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v3
		{
			set{ _v3=value;}
			get{return _v3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v4
		{
			set{ _v4=value;}
			get{return _v4;}
		}
		#endregion Model

	}
}

