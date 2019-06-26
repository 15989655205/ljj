using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web.Compilation;

namespace Maticsoft.DBUtility
{
    public class WCDataProvider
    {
        /// <summary>
        /// 初始化(从配置文件读取连接字符串)
        /// </summary>
        public WCDataProvider()
        {
            this.SqlConnectionString = PubConstant.ConnectionString;
        }

        /// <summary>
        /// 初始化（自定义链接字符串）
        /// </summary>
        public WCDataProvider(string sqlConnectionString)
        {
            this.SqlConnectionString = sqlConnectionString;
        }

        /// <summary>
        /// SQL查询语句
        /// </summary>
        public string SqlConnectionString { get; set; }

        /// <summary>
        /// 获取数据表
        /// </summary>
        public WCDataQuery Execute(WCDataQuery sqlQuery)
        {
            DataTable dt = new DataTable(sqlQuery.TableName);
            SqlDataAdapter sqlDataAdapter = null;
            SqlConnection con = null;
            try
            {
                //更新语句
                if (sqlQuery.IsUpdate)
                {
                    con = new SqlConnection(this.SqlConnectionString);
                    SqlCommand com = new SqlCommand(sqlQuery.Sql, con);
                    con.Open();
                    if (com.ExecuteNonQuery() > 0)
                    {
                        sqlQuery.ExecuteState = true;
                        com.Dispose();
                    }
                }
                else
                {
                    //普通查询
                    if (sqlQuery.Paging == null)
                    {
                        sqlDataAdapter = new SqlDataAdapter(sqlQuery.Sql, this.SqlConnectionString);
                        if (sqlQuery.ContainsSchema)
                            sqlDataAdapter.FillSchema(dt, SchemaType.Source);
                        sqlDataAdapter.Fill(dt);
                        sqlQuery.ExecuteState = true;
                        sqlQuery.DataTable = dt;
                    }
                    else//分页查询
                    {
                        //组装SQL语句，该语句只支持SQL2005及以上版本
                        string sql = "SELECT {0} FROM {1} {2} {3}";
                        string sql1 = "SELECT COUNT(*) as RecordCount FROM {0} {1}";
                        string where = "";
                        if (sqlQuery.Where != null && sqlQuery.Where.Trim().Length > 0)
                            where = " WHERE " + sqlQuery.Where;
                        Int64 fromRowIndex = sqlQuery.Paging.PageIndex * sqlQuery.Paging.PageSize - sqlQuery.Paging.PageSize + 1;
                        Int64 toRowIndex = sqlQuery.Paging.PageIndex * sqlQuery.Paging.PageSize;
                        sql = "SELECT * FROM (SELECT {0}, row_number() OVER (ORDER BY {1}) AS OrderIndex FROM {2} {3}) AS T WHERE T.OrderIndex BETWEEN {4} AND {5}";
                        sql = string.Format(sql, sqlQuery.Fields, sqlQuery.OrderBy, sqlQuery.TableName, where, fromRowIndex, toRowIndex);
                        sql1 = string.Format(sql1, sqlQuery.TableName, where);

                        //获取记录总条数
                        sqlDataAdapter = new SqlDataAdapter(sql1, this.SqlConnectionString);
                        DataTable dt1 = new DataTable();
                        sqlDataAdapter.Fill(dt1);
                        sqlQuery.Paging.RecordCount = Convert.ToInt64(dt1.Rows[0]["RecordCount"]);
                        //获取分页数据
                        sqlDataAdapter = new SqlDataAdapter(sql, this.SqlConnectionString);
                        if (sqlQuery.ContainsSchema)
                            sqlDataAdapter.FillSchema(dt, SchemaType.Source);
                        sqlDataAdapter.Fill(dt);
                        sqlQuery.ExecuteState = true;
                        sqlQuery.DataTable = dt;
                        if (dt.Columns.Contains("OrderIndex"))
                            dt.Columns.Remove("OrderIndex");
                    }
                }
            }
            catch (System.Exception ex)
            {
                sqlQuery.ExecuteState = false;
                sqlQuery.ErrorMessage = ex.Message;
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
                dt.Dispose();
                if (sqlDataAdapter != null)
                    sqlDataAdapter.Dispose();
            }
            return sqlQuery;
        }

        /// <summary>
        /// 批量更新，支持SQL语句,DataTable类型
        /// </summary>
        //public WCDataUpdate Execute(WCDataUpdate sqlDataUpdate)
        //{
        //    SqlTransaction sqlTransaction = null;
        //    SqlConnection sqlConnection = new SqlConnection(this.SqlConnectionString);
        //    try
        //    {
        //        sqlConnection.Open();
        //        if (sqlDataUpdate.UseTransaction)
        //            sqlTransaction = sqlConnection.BeginTransaction();

        //    }
        //    catch (Exception ex)
        //    {
        //        sqlDataUpdate.ErrorMessage = "[CONNECT ERROR] " + ex.Message;
        //        sqlDataUpdate.ExecuteState = false;
        //        return sqlDataUpdate;
        //    }

        //    try
        //    {

        //        foreach (object sqlDataObj in sqlDataUpdate.DataObjects)
        //        {
        //            if (sqlDataObj is String)
        //            {
        //                SqlCommand sqlCommand = new SqlCommand(sqlDataObj.ToString(), sqlConnection);
        //                sqlCommand.CommandType = CommandType.Text;
        //                if (sqlDataUpdate.UseTransaction)
        //                    sqlCommand.Transaction = sqlTransaction;
        //                sqlCommand.ExecuteNonQuery();
        //            }
        //            else if (sqlDataObj is DataTable)
        //            {
        //                DataTable dt = sqlDataObj as DataTable;
        //                string sql = "SELECT TOP 0 * FROM [" + dt.TableName + "]";
        //                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
        //                if (sqlDataUpdate.UseTransaction)
        //                    sqlDataAdapter.SelectCommand.Transaction = sqlTransaction;
        //                SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);
        //                builder.ConflictOption = ConflictOption.CompareRowVersion;
        //                builder.SetAllValues = true;
        //                sqlDataAdapter.InsertCommand = builder.GetInsertCommand(true);
        //                sqlDataAdapter.UpdateCommand = builder.GetUpdateCommand(true);
        //                sqlDataAdapter.DeleteCommand = builder.GetDeleteCommand(true);
        //                if (sqlDataUpdate.UseTransaction)
        //                {
        //                    sqlDataAdapter.DeleteCommand.Transaction = sqlTransaction;
        //                    sqlDataAdapter.UpdateCommand.Transaction = sqlTransaction;
        //                    sqlDataAdapter.InsertCommand.Transaction = sqlTransaction;
        //                }
        //                sqlDataAdapter.Update(dt);
        //            }
        //            else if (sqlDataObj is WCDataStoreProcedures)
        //            {
        //                this.Execute((sqlDataObj as WCDataStoreProcedures));
        //            }
        //        }

        //        if (sqlDataUpdate.UseTransaction)
        //            sqlTransaction.Commit();
        //        sqlConnection.Close();
        //        sqlDataUpdate.ExecuteState = true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        sqlDataUpdate.ExecuteState = false;
        //        sqlDataUpdate.ErrorMessage = ex.Message;
        //        if (sqlDataUpdate.UseTransaction && sqlTransaction != null)
        //            sqlTransaction.Rollback();
        //        sqlConnection.Close();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (sqlTransaction != null) sqlTransaction.Dispose();
        //        if (sqlConnection.State == ConnectionState.Open)
        //            sqlConnection.Close();
        //        sqlConnection.Dispose();
        //    }

        //    return sqlDataUpdate;
        //}

        /// <summary>
        /// 执行存储过程
        /// </summary>
        public WCDataStoreProcedures Execute(WCDataStoreProcedures sp)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sp.SpName, this.SqlConnectionString);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            //加入输入参数
            if (sp.InputPars != null)
            {
                for (int i = 0; i <= sp.InputPars.Count - 1; i++)
                {
                    string inKey = sp.InputPars.Keys[i];
                    object inValue = sp.InputPars.Values[i];
                    if (inValue == null || inValue.ToString().Trim().Length == 0) { inValue = System.DBNull.Value; }
                    WCDataHelper.SetInputParameter(sqlDataAdapter, inKey, inValue);
                }
            }
            //加入分页
            if (sp.DataPaging != null)
            {
                WCDataHelper.SetInputParameter(sqlDataAdapter, "@PageIndex", sp.DataPaging.PageIndex);
                WCDataHelper.SetInputParameter(sqlDataAdapter, "@PageSize", sp.DataPaging.PageSize);
            }
            //加入默认动作参数
            if (sp.DataAction != WCDataAction.None && !sp.InputPars.ContainsKey(sp.DataAction.ToString()))
                WCDataHelper.SetInputParameter(sqlDataAdapter, "@ActionType", sp.DataAction.ToString());

            //获取输出参数
            string sql = "SELECT b.name AS column_name,c.name AS data_type, b.length FROM sysobjects a INNER JOIN syscolumns b ON a.id = b.id INNER JOIN systypes c ON b.xusertype = c.xusertype WHERE (a.name = '" + sp.SpName + "') AND (b.isoutparam = 1)";
            WCDataQuery gdc = new WCDataQuery();
            gdc.Sql = sql;
            DataTable dt = new DataTable();
            if (this.Execute(gdc).ExecuteState)
                dt = gdc.DataTable;

            //加入输出参数
            for (int n = 0; n <= dt.Rows.Count - 1; n++)
            {
                SqlParameter SqlParOutput = new SqlParameter();
                SqlParOutput.ParameterName = dt.Rows[n]["column_name"].ToString();
                SqlParOutput.SqlDbType = WCDataHelper.GetFieldDataType(dt.Rows[n]["data_type"].ToString());
                SqlParOutput.Size = WCDataHelper.GetFieldDataSize(SqlParOutput.SqlDbType, dt.Rows[n]["length"].ToString());
                SqlParOutput.Direction = ParameterDirection.Output;
                if (!sp.OutputPars.ContainsKey(dt.Rows[n]["column_name"].ToString()))
                    sp.OutputPars.Add(dt.Rows[n]["column_name"].ToString(), "");
                sqlDataAdapter.SelectCommand.Parameters.Add(SqlParOutput);
                sqlDataAdapter.SelectCommand.CommandTimeout = 180;
            }

            try
            {
                //执行存储过程并获取返回记录和输出参数
                sqlDataAdapter.Fill(sp.OutputDataSet);
                foreach (SqlParameter par1 in sqlDataAdapter.SelectCommand.Parameters)
                {
                    if (par1.Direction == ParameterDirection.Output
                        && par1.Value != System.DBNull.Value)
                    {
                        sp.OutputPars[par1.ParameterName] = par1.Value;
                        if (par1.ParameterName == "@RecordCount" && sp.DataPaging != null)
                            sp.DataPaging.RecordCount = (Int64)par1.Value;
                    }
                }

                sp.ExecuteState = true;
            }
            catch (System.Exception ex)
            {
                sp.ExecuteState = false;
                sp.ErrorMessage = ex.Message;
                throw ex;
            }
            finally
            {
                dt.Dispose();
                sqlDataAdapter.Dispose();
            }

            return sp;
        }
    }
}
