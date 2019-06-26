using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.DBUtility
{
    public class WCDataPaging
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public WCDataPaging()
        {
            this.PageIndex = -1;
            this.PageSize = 10;
            this.PageCount = 0;
            this.RecordCount = 0;
        }

        /// <summary>
        /// 当前页面索引
        /// </summary>

        public int PageIndex { get; set; }

        /// <summary>
        /// 当前页面尺码
        /// </summary>

        public int PageSize { get; set; }

        /// <summary>
        /// 分页总数
        /// </summary>

        public Int64 PageCount { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>

        public Int64 RecordCount { get; set; }
    }
}
