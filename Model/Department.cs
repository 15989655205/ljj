using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Department:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Department
	{
		public Department()
		{}
		#region Model
		private int _departmentid;
		private string _departmentno;
		private string _departmentname;
		private string _departmentremark;
		private string _remark;
		private DateTime? _createddate;
		private int? _createdguy;
		private DateTime? _updateddate;
		private int? _status;
		private DateTime? _checkdate;
		private string _departmentgroup;
		/// <summary>
		/// 
		/// </summary>
		public int DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentNo
		{
			set{ _departmentno=value;}
			get{return _departmentno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentName
		{
			set{ _departmentname=value;}
			get{return _departmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentRemark
		{
			set{ _departmentremark=value;}
			get{return _departmentremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
		public DateTime? UpdatedDate
		{
			set{ _updateddate=value;}
			get{return _updateddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CheckDate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartmentGroup
		{
			set{ _departmentgroup=value;}
			get{return _departmentgroup;}
		}
		#endregion Model

	}
}

