using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// request_form:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class request_form
    {
        public request_form()
        { }
        #region Model
        private int _sid;
        private string _form_name = "";
        private int? _rft_sid;
        private string _url = "";
        private int? _rf_status;
        private string _content_str = "";
        private string _remark = "";
        private string _value1 = "";
        private string _value2 = "";
        private string _value3 = "";
        private string _value4 = "";
        private string _value5 = "";
        private string _value6 = "";
        private int? _status = 1;
        private string _create_person = "";
        private DateTime? _create_date;
        private string _update_person="";
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
        public string form_name
        {
            set { _form_name = value; }
            get { return _form_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? rft_sid
        {
            set { _rft_sid = value; }
            get { return _rft_sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? rf_status
        {
            set { _rf_status = value; }
            get { return _rf_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string content_str
        {
            set { _content_str = value; }
            get { return _content_str; }
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

