/**  版本信息模板在安装目录下，可自行修改。
* flow_node.cs
*
* 功 能： N/A
* 类 名： flow_node
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-7-17 17:33:26   N/A    初版
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
    /// flow_node:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class flow_node
    {
        public flow_node()
        { }
        #region Model
        private int _sid;
        private int? _flow_sid=0;
        private int? _node_no=0;
        private int? _node_type=0;
        private string _node_name="";
        private int? _node_status=0;
        private string _appr_dept = "";
        private string _appr_dept_type="";
        private string _appr_role="";
        private int? _appr_count = 0;
        private decimal? _appr_time = 0M;
        private int? _appr_must = 1;
        private string _remark="";
        private string _value1 = "";
        private string _value2 = "";
        private string _value3 = "";
        private string _value4 = "";
        private string _value5 = "";
        private string _value6 = "";
        private int? _status = 0;
        private string _create_person = "";
        private DateTime? _create_date;
        private string _update_person = "";
        private DateTime? _update_date;
        private string _dept="";
        private string _role="";
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
        public int? flow_sid
        {
            set { _flow_sid = value; }
            get { return _flow_sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? node_no
        {
            set { _node_no = value; }
            get { return _node_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? node_type
        {
            set { _node_type = value; }
            get { return _node_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string node_name
        {
            set { _node_name = value; }
            get { return _node_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? node_status
        {
            set { _node_status = value; }
            get { return _node_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_dept
        {
            set { _appr_dept = value; }
            get { return _appr_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_dept_type
        {
            set { _appr_dept_type = value; }
            get { return _appr_dept_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_role
        {
            set { _appr_role = value; }
            get { return _appr_role; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? appr_count
        {
            set { _appr_count = value; }
            get { return _appr_count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? appr_time
        {
            set { _appr_time = value; }
            get { return _appr_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? appr_must
        {
            set { _appr_must = value; }
            get { return _appr_must; }
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
        /// <summary>
        /// 
        /// </summary>
        public string dept
        {
            set { _dept = value; }
            get { return _dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string role
        {
            set { _role = value; }
            get { return _role; }
        }
        #endregion Model

    }
}

