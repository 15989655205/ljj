using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// BaseUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BaseUser
	{
		public BaseUser()
		{}
		#region Model
		private long _userid;
		private int _deptid;
		private string _roles;
		private string _username;
		private string _pwd;
		private string _name;
		private string _tel;
		private string _workid;
		private DateTime? _createddate;
		private int? _createdguy;
        private string _ApprRole = "";
        private int? _permissions;
        private string _Value0 ;

        /// <summary>
        /// 
        /// </summary>
        public int? Permissions
        {
            set { _permissions = value; }
            get { return _permissions; }
        }
		/// <summary>
		/// 
		/// </summary>
		public long UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Roles
		{
			set{ _roles=value;}
			get{return _roles;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
        public string Value0
        {
            set { _Value0 = value; }
            get { return _Value0; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
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
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkID
		{
			set{ _workid=value;}
			get{return _workid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedDate
		{
			set{ _createddate=value;}
			get{return _createddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreatedGuy
		{
			set{ _createdguy=value;}
			get{return _createdguy;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string ApprRole
        {
            set { _ApprRole = value; }
            get { return _ApprRole; }
        }
		#endregion Model

	}
}

