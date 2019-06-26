using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// ProductPriceMethods:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProductPriceMethods
    {
        public ProductPriceMethods()
        { }
        #region Model
        private long _id;
        private string _code;
        private string _name;
        private string _value1;
        private string _value2;
        private string _value3;
        private int? _v1;
        private int? _v2;
        private int? _v3;
        private int? _status;
        private string _remark;
        private string _createuser;
        private DateTime? _createdate;
        private string _updateuser;
        private DateTime? _updatedate;
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value1
        {
            set { _value1 = value; }
            get { return _value1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value2
        {
            set { _value2 = value; }
            get { return _value2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value3
        {
            set { _value3 = value; }
            get { return _value3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? v1
        {
            set { _v1 = value; }
            get { return _v1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? v2
        {
            set { _v2 = value; }
            get { return _v2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? v3
        {
            set { _v3 = value; }
            get { return _v3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreateUser
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateUser
        {
            set { _updateuser = value; }
            get { return _updateuser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        #endregion Model

    }
}

