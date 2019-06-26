/**  版本信息模板在安装目录下，可自行修改。
* project_processing_category_model.cs
*
* 功 能： N/A
* 类 名： project_processing_category_model
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-9-24 15:03:39   N/A    初版
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
	/// project_processing_category_model:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class project_processing_category_model
	{
		public project_processing_category_model()
		{}
		#region Model
        private int _sid;

        public int sid
        {
            get { return _sid; }
            set { _sid = value; }
        }
        private string _category;

        public string  category
        {
            get { return _category; }
            set { _category = value; }
        }
        private int? _type;

        public int? type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _remark = "";

        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        private string _v1;

        public string v1
        {
            get { return _v1; }
            set { _v1 = value; }
        }
        private string _v2;

        public string v2
        {
            get { return _v2; }
            set { _v2 = value; }
        }
        private string _v3;

        public string v3
        {
            get { return _v3; }
            set { _v3 = value; }
        }
        private string _v4;

        public string v4
        {
            get { return _v4; }
            set { _v4 = value; }
        }
        private string _v5;

        public string v5
        {
            get { return _v5; }
            set { _v5 = value; }
        }
        private string _v6;

        public string v6
        {
            get { return _v6; }
            set { _v6 = value; }
        }
        private string _v7;

        public string v7
        {
            get { return _v7; }
            set { _v7 = value; }
        }
        private string _v8;

        public string v8
        {
            get { return _v8; }
            set { _v8 = value; }
        }
        private string _v9;

        public string v9
        {
            get { return _v9; }
            set { _v9 = value; }
        }
        private string _v10;

        public string v10
        {
            get { return _v10; }
            set { _v10 = value; }
        }
        private int? _n1;

        public int? n1
        {
            get { return _n1; }
            set { _n1 = value; }
        }
        private int? _n2;

        public int? n2
        {
            get { return _n2; }
            set { _n2 = value; }
        }
        private int? _n3;

        public int? n3
        {
            get { return _n3; }
            set { _n3 = value; }
        }
        private string _show;

        public string show
        {
            get { return _show; }
            set { _show = value; }
        }
        private string _show_name;

        public string show_name
        {
            get { return _show_name; }
            set { _show_name = value; }
        }
        private int? _status = 1;

        public int? status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _create_person;

        public string create_person
        {
            get { return _create_person; }
            set { _create_person = value; }
        }
        private DateTime? _create_date = DateTime.Now;

        public DateTime? create_date
        {
            get { return _create_date; }
            set { _create_date = value; }
        }
        private string _update_person;

        public string update_person
        {
            get { return _update_person; }
            set { _update_person = value; }
        }
        private string _update_date;

        public string update_date
        {
            get { return _update_date; }
            set { _update_date = value; }
        }
        private int _idx ;

        public int idx
        {
            get { return _idx; }
            set { _idx = value; }
        }
        private int _catgID;

        public int catgID
        {
            get { return _catgID; }
            set { _catgID = value; }
        }
        private int _parentCatgID;

        public int parentCatgID
        {
            get { return _parentCatgID; }
            set { _parentCatgID = value; }
        }
        private string _caption;

        public string caption
        {
            get { return _caption; }
            set { _caption = value; }
        }
        private string _value;

        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
        private string _value1;

        public string value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        private string _value2;

        public string value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        private string _value3;

        public string value3
        {
            get { return _value3; }
            set { _value3 = value; }
        }


     


		#endregion Model

	}
}

