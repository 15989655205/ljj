using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// BaseDepartment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BaseDepartment
	{
		public BaseDepartment()
		{}
		#region Model
		private int _deptid;
		private int? _parentdeptid;
		private string _deptname;
		private DateTime? _createddate;
		private int? _createdguy;
		private DateTime? _updateddate;
		private int? _updatedguy;
		private string _remark;
		private string _deptids;
		private string _value1;
		private string _value2;
		private string _value3;
		private string _value4;
		private string _value5;
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
		public int? ParentDeptID
		{
			set{ _parentdeptid=value;}
			get{return _parentdeptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptName
		{
			set{ _deptname=value;}
			get{return _deptname;}
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
		public int? UpdatedGuy
		{
			set{ _updatedguy=value;}
			get{return _updatedguy;}
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
		public string DeptIDs
		{
			set{ _deptids=value;}
			get{return _deptids;}
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
		public string Value4
		{
			set{ _value4=value;}
			get{return _value4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value5
		{
			set{ _value5=value;}
			get{return _value5;}
		}
		#endregion Model

	}
}

