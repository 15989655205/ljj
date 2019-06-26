using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Maticsoft.DBUtility
{
    public class WCDataQuery
    {
        public WCDataQuery()
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public WCDataQuery(string sql)
        {
            this.m_Sql = sql;
        }

        /// <summary>
        /// 查询语句
        /// </summary>
        string m_Sql, m_TableName;

        /// <summary>
        /// 表名
        /// </summary>

        public string TableName
        {
            get
            {
                if (string.IsNullOrEmpty(m_TableName) && !string.IsNullOrEmpty(m_Sql))
                    m_TableName = WCDataHelper.GetTableName(m_Sql);
                return m_TableName;
            }
            set
            {
                m_TableName = value;
            }
        }

        /// <summary>
        /// 查询字段
        /// </summary>

        public string Fields { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>

        public string OrderBy { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>

        public string Where { get; set; }

        /// <summary>
        /// 数据分页
        /// </summary>

        public WCDataPaging Paging { get; set; }

        /// <summary>
        /// 是否包含数据架构信息
        /// </summary>

        public bool ContainsSchema { get; set; }

        /// <summary>
        /// 完整的Sql查询语句
        /// </summary>

        public string Sql
        {
            get
            {
                if (this.m_Sql == null && this.TableName != null)
                {
                    string sql = null;
                    //不分页查询
                    if (Paging == null)
                    {
                        sql = "SELECT {0} FROM [{1}] {2} {3}";
                        sql = string.Format(sql, WCDataHelper.GetFieldDataValue(this.Fields, "*", null), this.TableName, WCDataHelper.GetFieldDataValue(this.Where, "", "WHERE"), WCDataHelper.GetFieldDataValue(this.OrderBy, "", "ORDER BY"));
                    }
                    else//分页查询
                    {
                        Int64 from = this.Paging.PageIndex * this.Paging.PageSize - this.Paging.PageSize + 1;
                        Int64 to = this.Paging.PageIndex * this.Paging.PageSize;
                        sql = "SELECT * FROM (SELECT {0}, row_number() OVER (ORDER BY {1}) AS OrderIndex FROM {2} {3}) AS T WHERE T.OrderIndex BETWEEN {4} AND {5}";
                        sql = string.Format(sql, WCDataHelper.GetFieldDataValue(this.Fields, "*", null), this.OrderBy, this.TableName, WCDataHelper.GetFieldDataValue(this.Where, "", "WHERE"), from, to);
                    }
                    return sql;
                }
                else
                    return this.m_Sql;
            }
            set { this.m_Sql = value; }
        }

        /// <summary>
        /// 返回结果
        /// </summary>

        public DataTable DataTable { get; set; }

        /// <summary>
        /// 出错信息
        /// </summary>

        public string ErrorMessage { get; set; }

        /// <summary>
        /// 是否执行成功
        /// </summary>

        public bool ExecuteState { get; set; }

        /// <summary>
        /// 是否为更新语句
        /// </summary>
        public bool IsUpdate { get; set; }
    }
}
