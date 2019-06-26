/**  版本信息模板在安装目录下，可自行修改。
* project_work_implement.cs
*
* 功 能： N/A
* 类 名： project_work_implement
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-8-9 9:34:30   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// project_work_implement:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class project_work_implement
	{
		public project_work_implement()
		{}
		#region Model
		private int _sid;
		private string _psi_sid;
		private string _imp_sid;
		private string _implementer_sid;
		private string _implementer;
		private DateTime? _begin_date;
		private DateTime? _end_date;
		private string _remark;
		private string _v1;
		private string _v2;
		private string _v3;
		private string _v4;
		private string _v5;
		private string _v6;
		private string _v7;
		private string _v8;
		private string _v9;
		private string _v10;
		private int? _n1;
		private int? _n2;
		private int? _n3;
		private string _show;
		private string _show_name;
		private int? _status=1;
		private string _create_person;
		private DateTime? _create_date= DateTime.Now;
		private string _update_person;
		private DateTime? _update_date;
		/// <summary>
		/// 
		/// </summary>
		public int sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string psi_sid
		{
			set{ _psi_sid=value;}
			get{return _psi_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imp_sid
		{
			set{ _imp_sid=value;}
			get{return _imp_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string implementer_sid
		{
			set{ _implementer_sid=value;}
			get{return _implementer_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string implementer
		{
			set{ _implementer=value;}
			get{return _implementer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? begin_date
		{
			set{ _begin_date=value;}
			get{return _begin_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? end_date
		{
			set{ _end_date=value;}
			get{return _end_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
		/// <summary>
		/// 
		/// </summary>
		public string v5
		{
			set{ _v5=value;}
			get{return _v5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v6
		{
			set{ _v6=value;}
			get{return _v6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v7
		{
			set{ _v7=value;}
			get{return _v7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v8
		{
			set{ _v8=value;}
			get{return _v8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v9
		{
			set{ _v9=value;}
			get{return _v9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string v10
		{
			set{ _v10=value;}
			get{return _v10;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? n1
		{
			set{ _n1=value;}
			get{return _n1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? n2
		{
			set{ _n2=value;}
			get{return _n2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? n3
		{
			set{ _n3=value;}
			get{return _n3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string show
		{
			set{ _show=value;}
			get{return _show;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string show_name
		{
			set{ _show_name=value;}
			get{return _show_name;}
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
		public string create_person
		{
			set{ _create_person=value;}
			get{return _create_person;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? create_date
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string update_person
		{
			set{ _update_person=value;}
			get{return _update_person;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? update_date
		{
			set{ _update_date=value;}
			get{return _update_date;}
		}
		#endregion Model

	}
}

