/**  版本信息模板在安装目录下，可自行修改。
* project_specific_item.cs
*
* 功 能： N/A
* 类 名： project_specific_item
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-8-9 17:16:51   N/A    初版
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
	/// project_specific_item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class project_specific_item
	{
		public project_specific_item()
		{}
		#region Model
		private int _sid;
		private string _name;
		private int? _parent_sid=0;
		private string _s_sid;
		private string _show_column;
		private int? _sequence=0;
		private string _parentids;
		private int? _ischild=1;
		private DateTime? _begin_date;
		private DateTime? _end_date;
		private string _i_sid;
		private string _implementers_sid;
		private string _implementers;
		private string _group_sid;
		private string _finish;
		private string _unfinished_reason;
		private string _solution;
		private string _reviewed;
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
        private int? _rowid = 0;
        private int  _pp_sid;


        public int PP_sid
        {
            get { return _pp_sid; }
            set { _pp_sid = value; }
        }

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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? parent_sid
		{
			set{ _parent_sid=value;}
			get{return _parent_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string s_sid
		{
			set{ _s_sid=value;}
			get{return _s_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string show_column
		{
			set{ _show_column=value;}
			get{return _show_column;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sequence
		{
			set{ _sequence=value;}
			get{return _sequence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string parentIDs
		{
			set{ _parentids=value;}
			get{return _parentids;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isChild
		{
			set{ _ischild=value;}
			get{return _ischild;}
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
		public string i_sid
		{
			set{ _i_sid=value;}
			get{return _i_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string implementers_sid
		{
			set{ _implementers_sid=value;}
			get{return _implementers_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string implementers
		{
			set{ _implementers=value;}
			get{return _implementers;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string group_sid
		{
			set{ _group_sid=value;}
			get{return _group_sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string finish
		{
			set{ _finish=value;}
			get{return _finish;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unfinished_reason
		{
			set{ _unfinished_reason=value;}
			get{return _unfinished_reason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string solution
		{
			set{ _solution=value;}
			get{return _solution;}
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

        public int? rowid
        {
            set { _rowid = value; }
            get { return _rowid; }
        }
		#endregion Model

	}
}

