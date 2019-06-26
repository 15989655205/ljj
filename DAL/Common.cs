using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL
{
    public class Common
    {
        public Common()
		{}

        public DataSet GetList(string tableName, string orderFile, string showField, int page, int rows, out int count, string orderType, string where)
        {
            return DbHelperSQL.GetList_ProcPage(tableName, orderFile, showField, page, rows, out count, orderType, where);
        }

        public DataSet GetList(string sql)
        {
            return DbHelperSQL.Query(sql);
        }
    }
}
