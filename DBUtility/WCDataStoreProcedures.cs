using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Maticsoft.DBUtility
{
    public class WCDataStoreProcedures
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public WCDataStoreProcedures()
        {
            this.DataAction = WCDataAction.None;
            this.InputPars = new SortedList<string, object>();
            this.OutputDataSet = new DataSet();
            this.OutputPars = new SortedList<string, object>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public WCDataStoreProcedures(string spName, WCDataAction action)
        {
            this.InputPars = new SortedList<string, object>();
            this.OutputDataSet = new DataSet();
            this.OutputPars = new SortedList<string, object>();
            this.SpName = spName;
            this.DataAction = action;
        }

        /// <summary>
        /// 執行動作
        /// </summary>
        public WCDataAction DataAction { get; set; }

        /// <summary>
        /// 分頁
        /// </summary>
        public WCDataPaging DataPaging { get; set; }

        /// <summary>
        /// 输入参数
        /// </summary>
        public SortedList<string, object> InputPars
        {
            get;
            set;
        }

        /// <summary>
        /// 输出参数
        /// </summary>
        public SortedList<string, object> OutputPars
        {
            get;
            set;
        }

        /// <summary>
        /// 返回记录集合
        /// </summary>
        public DataSet OutputDataSet
        {
            get;
            set;
        }

        /// <summary>
        /// 存储过程名称
        /// </summary>
        public string SpName { get; set; }

        /// <summary>
        /// 出错信息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 是否执行成功
        /// </summary>
        public bool ExecuteState { get; set; }
    }
}
