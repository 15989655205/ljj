using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Maticsoft.BLL
{
    public class Common
    {
        private readonly Maticsoft.DAL.Common dal = new Maticsoft.DAL.Common();
        public Common()
		{}

        public DataSet GetList(string tableName, string orderFile, string showField, int page, int rows, out int count, string orderType, string where)
        {
            return dal.GetList(tableName, orderFile, showField, page, rows, out count, orderType, where);
        }

        public DataSet GetList(string sql)
        {
            return dal.GetList(sql);
        }
    }
}
