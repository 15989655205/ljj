﻿/**  版本信息模板在安装目录下，可自行修改。
* Project_Template_Type.cs
*
* 功 能： N/A
* 类 名： Project_Template_Type
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-9-11 17:42:35   N/A    初版
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
	/// Project_Template_Type:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Project_Template_Type
	{
		public Project_Template_Type()
		{}
		#region Model
		private int _sid;
		private int? _value;
		private string _name;
		private int? _sequence;
		private string _remark;
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
		public int? value
		{
			set{ _value=value;}
			get{return _value;}
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
		public int? sequence
		{
			set{ _sequence=value;}
			get{return _sequence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

