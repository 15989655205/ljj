using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// construct:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class construct
    {
        public construct()
        { }
        #region Model
        private int _id;
        private int? _fw_sid;
        private int? _imp_sid;
        private string _imp_name;
        private DateTime? _begin_time;
        private DateTime? _end_time;
        private int? _sn;
        private string _fw_name;
        private string _value1;
        private string _value2;
        private string _value3;
        private string _value4;
        private int? _n1;
        private int? _n2;
        private int? _n3;
        private int? _n4;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? fw_sid
        {
            set { _fw_sid = value; }
            get { return _fw_sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? imp_sid
        {
            set { _imp_sid = value; }
            get { return _imp_sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string imp_name
        {
            set { _imp_name = value; }
            get { return _imp_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? begin_time
        {
            set { _begin_time = value; }
            get { return _begin_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? end_time
        {
            set { _end_time = value; }
            get { return _end_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SN
        {
            set { _sn = value; }
            get { return _sn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fw_name
        {
            set { _fw_name = value; }
            get { return _fw_name; }
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
        public int? n4
        {
            set { _n4 = value; }
            get { return _n4; }
        }
        #endregion Model

    }
}

