/**  版本信息模板在安装目录下，可自行修改。
* project_review_record.cs
*
* 功 能： N/A
* 类 名： project_review_record
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-8-14 18:29:29   N/A    初版
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
	/// project_review_record:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class project_review_record
	{
		public project_review_record()
		{}
		#region Model
		private int _sid;
		private string _pr_sid;
		private string _pwi_sid;
		private string _si_sid;
		private string _sumbit_content;
		private string _sumbit_file;
		private DateTime? _sumbit_date;
		private string _sumbit_user;
		private string _audit_results;
		private string _reviewed;
		private int? _review_status;
		private string _review_content;
		private string _reviewer;
		private DateTime? _review_date;
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
		public string pr_sid
		{
			set{ _pr_sid=value;}
			get{return _pr_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pwi_sid
		{
			set{ _pwi_sid=value;}
			get{return _pwi_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string si_sid
		{
			set{ _si_sid=value;}
			get{return _si_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sumbit_content
		{
			set{ _sumbit_content=value;}
			get{return _sumbit_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sumbit_file
		{
			set{ _sumbit_file=value;}
			get{return _sumbit_file;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? sumbit_date
		{
			set{ _sumbit_date=value;}
			get{return _sumbit_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sumbit_user
		{
			set{ _sumbit_user=value;}
			get{return _sumbit_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string audit_results
		{
			set{ _audit_results=value;}
			get{return _audit_results;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reviewed
		{
			set{ _reviewed=value;}
			get{return _reviewed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? review_status
		{
			set{ _review_status=value;}
			get{return _review_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string review_content
		{
			set{ _review_content=value;}
			get{return _review_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reviewer
		{
			set{ _reviewer=value;}
			get{return _reviewer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? review_date
		{
			set{ _review_date=value;}
			get{return _review_date;}
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

