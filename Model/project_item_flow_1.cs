using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// project_item_flow_1:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class project_item_flow_1
    {
        public project_item_flow_1()
        { }
        #region Model
        private int _sid;
        private DateTime? _pif_time;
        private int? _psi_sid;
        private string _wf_text;
        private string _v1;
        private string _v2;
        private int? _n1;
        private int? _n2;
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
        public DateTime? pif_time
        {
            set { _pif_time = value; }
            get { return _pif_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? psi_sid
        {
            set { _psi_sid = value; }
            get { return _psi_sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wf_text
        {
            set { _wf_text = value; }
            get { return _wf_text; }
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
        #endregion Model

    }
}

