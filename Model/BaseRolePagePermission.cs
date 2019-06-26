using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// BaseRolePagePermission:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BaseRolePagePermission
	{
		public BaseRolePagePermission()
		{}
		#region Model
		private int _roleid;
		private int _menuid;
		private int _pageid;
		private string _cmds;
		/// <summary>
		/// 
		/// </summary>
		public int RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
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
		public int PageID
		{
			set{ _pageid=value;}
			get{return _pageid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Cmds
		{
			set{ _cmds=value;}
			get{return _cmds;}
		}
		#endregion Model

	}
}

