using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace Maticsoft.DBUtility
{
    public class WCDataHelper
    {
        /// <summary>
        /// 获取SQLServer映射数据类型
        internal static System.Data.SqlDbType GetFieldDataType(string TypeKey)
        {
            System.Data.SqlDbType type = new SqlDbType(); ;
            switch (TypeKey)
            {
                case "text":
                    type = System.Data.SqlDbType.Text;
                    break;
                case "char":
                    type = System.Data.SqlDbType.Char;
                    break;
                case "varchar":
                    type = System.Data.SqlDbType.VarChar;
                    break;
                case "nchar":
                    type = System.Data.SqlDbType.NChar;
                    break;
                case "ntext":
                    type = System.Data.SqlDbType.NText;
                    break;
                case "nvarchar":
                    type = System.Data.SqlDbType.NVarChar;
                    break;
                case "image":
                    type = System.Data.SqlDbType.Image;
                    break;
                case "binary":
                    type = System.Data.SqlDbType.Binary;
                    break;
                case "timestamp":
                    type = System.Data.SqlDbType.Timestamp;
                    break;
                case "varbinary":
                    type = System.Data.SqlDbType.VarBinary;
                    break;
                case "datetime":
                    type = System.Data.SqlDbType.DateTime;
                    break;
                case "smalldatetime":
                    type = System.Data.SqlDbType.SmallDateTime;
                    break;
                case "bigint":
                    type = System.Data.SqlDbType.BigInt;
                    break;
                case "bit":
                    type = System.Data.SqlDbType.Bit;
                    break;
                case "decimal":
                case "numeric":
                    type = System.Data.SqlDbType.Decimal;
                    break;
                case "float":
                    type = System.Data.SqlDbType.Float;
                    break;
                case "int":
                    type = System.Data.SqlDbType.Int;
                    break;
                case "money":
                    type = System.Data.SqlDbType.Money;
                    break;
                case "real":
                    type = System.Data.SqlDbType.Real;
                    break;
                case "smallint":
                    type = System.Data.SqlDbType.SmallInt;
                    break;
                case "sql_variant":
                    type = System.Data.SqlDbType.Variant;
                    break;
                case "tinyint":
                    type = System.Data.SqlDbType.TinyInt;
                    break;
                case "uniqueidentifie":
                    type = System.Data.SqlDbType.UniqueIdentifier;
                    break;
            }

            return type;
        }

        /// <summary>
        /// 获取数据长度
        /// </summary>
        internal static System.Int32 GetFieldDataSize(SqlDbType DBtype, string size)
        {
            System.Int32 maxLength = Convert.ToInt32(size);
            switch (DBtype)
            {
                case SqlDbType.NVarChar:
                    maxLength = maxLength / 2;
                    break;
                case SqlDbType.Binary:
                    maxLength = 8000;
                    break;
                case SqlDbType.Text:
                case SqlDbType.Image:
                    maxLength = 2147483647;
                    break;
            }
            return maxLength;
        }

        /// <summary>
        /// 获取SQL变量的值
        /// </summary>
        internal static string GetFieldDataValue(string value, string nullValue, string mask)
        {
            if (value == null)
                return nullValue;
            else
            {
                if (mask != null)
                    return mask + " (" + value + ")";
                else
                    return value;
            }
        }

        /// <summary>
        /// 设置存储过程参数
        /// </summary>
        internal static void SetInputParameter(SqlDataAdapter sqlDataAdapter, string key, object value)
        {
            SqlParameter SqlParInput = new SqlParameter(key, value);
            SqlParInput.Direction = ParameterDirection.Input;
            sqlDataAdapter.SelectCommand.Parameters.Add(SqlParInput);
        }

        /// <summary>
        /// 检测是否为空值
        /// </summary>
        internal static bool CheckValue(object value)
        {
            return (value != null && value != System.DBNull.Value && value.ToString().Trim().Length > 0);
        }

        /// <summary>
        /// 检测是否为预定的数据类型
        /// </summary>
        internal static bool CheckType(object value)
        {
            return (value.GetType() == typeof(string) || value.GetType() == typeof(DataTable));
        }

        /// <summary>
        /// 获取表名称
        /// </summary>
        /// <param name="sql">SQL查询语句</param>
        /// <returns>string</returns>
        public static string GetTableName(string sql)
        {
            Match m = Regex.Match(sql, @"[\s]FROM[\s]+([^\s]*)", RegexOptions.IgnoreCase);
            if (!m.Success || m.Groups[1].Value.Trim() == "")
                return Guid.NewGuid().ToString();
            else
                return m.Groups[1].Value.ToUpper().Replace("[", "").Replace("]", "");
        }
    }
}
