using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// ProductShip:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProductShip
    {
        public ProductShip()
        { }
        #region Model
        private long _id;
        private long? _cid;
        private long? _pid;
        private long? _colorid;
        private string _path;
        private decimal? _amount;
        /// <summary>
        /// 自增关系ID
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 子产品ID
        /// </summary>
        public long? CID
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 父产品ID
        /// </summary>
        public long? PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 颜色ID
        /// </summary>
        public long? ColorID
        {
            set { _colorid = value; }
            get { return _colorid; }
        }
        /// <summary>
        /// 路径：PID1.PID2.PID3.ID
        /// </summary>
        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        #endregion Model

    }
}
