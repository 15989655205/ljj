using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// Project_Space:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Project_Space
    {
        public Project_Space()
        { }
        #region Model
        private int _sid;
        private string _name;
        private string _p_sid;
        private string _show_column;
        private int? _sequence = 0;
        private int? _parentid;
        private int? _ischild = 1;
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
        private int? _status = 1;
        private string _create_person;
        private DateTime? _create_date = DateTime.Now;
        private string _update_person;
        private DateTime? _update_date;

        private string ps1name="";
        private string ps2name="";
        private int ps1isChild;
        private int ps2isChild;
        private int ps2sid;
        private int ps1sid;

        public int Ps1sid
        {
            get { return ps1sid; }
            set { ps1sid = value; }
        }

        public int Ps2sid
        {
            get { return ps2sid; }
            set { ps2sid = value; }
        }

        public int Ps1isChild
        {
            get { return ps1isChild; }
            set { ps1isChild = value; }
        }


        public int Ps2isChild
        {
            get { return ps2isChild; }
            set { ps2isChild = value; }
        }

        public string Ps1name
        {
            get { return ps1name; }
            set { ps1name = value; }
        }

        public string Ps2name
        {
            get { return ps2name; }
            set { ps2name = value; }
        }
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
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string p_sid
        {
            set { _p_sid = value; }
            get { return _p_sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string show_column
        {
            set { _show_column = value; }
            get { return _show_column; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sequence
        {
            set { _sequence = value; }
            get { return _sequence; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? parentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isChild
        {
            set { _ischild = value; }
            get { return _ischild; }
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
        public string v1
        {
            set { _v1 = value; }
            get { return _v1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v2
        {
            set { _v2 = value; }
            get { return _v2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v3
        {
            set { _v3 = value; }
            get { return _v3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v4
        {
            set { _v4 = value; }
            get { return _v4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v5
        {
            set { _v5 = value; }
            get { return _v5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v6
        {
            set { _v6 = value; }
            get { return _v6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v7
        {
            set { _v7 = value; }
            get { return _v7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v8
        {
            set { _v8 = value; }
            get { return _v8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v9
        {
            set { _v9 = value; }
            get { return _v9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v10
        {
            set { _v10 = value; }
            get { return _v10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? n1
        {
            set { _n1 = value; }
            get { return _n1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? n2
        {
            set { _n2 = value; }
            get { return _n2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? n3
        {
            set { _n3 = value; }
            get { return _n3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string show
        {
            set { _show = value; }
            get { return _show; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string show_name
        {
            set { _show_name = value; }
            get { return _show_name; }
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

