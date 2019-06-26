/**  版本信息模板在安装目录下，可自行修改。
* application_form.cs
*
* 功 能： N/A
* 类 名： application_form
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-7-29 15:41:01   N/A    初版
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
	/// application_form:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class application_form
	{
		public application_form()
		{}
        #region Model
        private int _sid;
        private string _af_name;
        private string _af_content;
        private string _applicant;
        private DateTime? _applicant_date;
        private bool _valid;
        private string _curr_node_no;
        private string _recently_approver;
        private int? _rf_sid;
        private int? _rfs_sid;
        private string _fm_sid;
        private string _remark;
        private string _value1;
        private string _value2;
        private string _value3;
        private string _value4;
        private string _value5;
        private string _value6;
        private int? _status = 1;
        private string _create_person;
        private DateTime? _create_date;
        private string _update_person;
        private DateTime? _update_date;
        /// <summary>
        /// 
        /// </summary>
        public int sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string af_name
        {
            set { _af_name = value; }
            get { return _af_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string af_content
        {
            set { _af_content = value; }
            get { return _af_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string applicant
        {
            set { _applicant = value; }
            get { return _applicant; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? applicant_date
        {
            set { _applicant_date = value; }
            get { return _applicant_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool valid
        {
            set { _valid = value; }
            get { return _valid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string curr_node_no
        {
            set { _curr_node_no = value; }
            get { return _curr_node_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string recently_approver
        {
            set { _recently_approver = value; }
            get { return _recently_approver; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? rf_sid
        {
            set { _rf_sid = value; }
            get { return _rf_sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? rfs_sid
        {
            set { _rfs_sid = value; }
            get { return _rfs_sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fm_sid
        {
            set { _fm_sid = value; }
            get { return _fm_sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value1
        {
            set { _value1 = value; }
            get { return _value1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value2
        {
            set { _value2 = value; }
            get { return _value2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value3
        {
            set { _value3 = value; }
            get { return _value3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value4
        {
            set { _value4 = value; }
            get { return _value4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value5
        {
            set { _value5 = value; }
            get { return _value5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string value6
        {
            set { _value6 = value; }
            get { return _value6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string create_person
        {
            set { _create_person = value; }
            get { return _create_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? create_date
        {
            set { _create_date = value; }
            get { return _create_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string update_person
        {
            set { _update_person = value; }
            get { return _update_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? update_date
        {
            set { _update_date = value; }
            get { return _update_date; }
        }
        #endregion Model


	}
}

