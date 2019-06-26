using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections;
using System.Collections.Generic;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:ProductUnit
    /// </summary>
    public partial class ProductUnit
    {
        public ProductUnit()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductUnit");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(Maticsoft.Model.ProductUnit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductUnit(");
            strSql.Append("UnitName,Status,CreateUser,CreateDate,UpdateUser,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@UnitName,@Status,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UnitName", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreateUser", SqlDbType.BigInt,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.BigInt,8),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.UnitName;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.CreateUser;
            parameters[3].Value = model.CreateDate;
            parameters[4].Value = model.UpdateUser;
            parameters[5].Value = model.UpdateDate;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.ProductUnit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductUnit set ");
            strSql.Append("UnitName=@UnitName,");
            strSql.Append("Status=@Status,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UnitName", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreateUser", SqlDbType.BigInt,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.BigInt,8),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.UnitName;
            parameters[1].Value = model.Status;
            parameters[2].Value = model.CreateUser;
            parameters[3].Value = model.CreateDate;
            parameters[4].Value = model.UpdateUser;
            parameters[5].Value = model.UpdateDate;
            parameters[6].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductUnit ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductUnit ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.ProductUnit GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UnitName,Status,CreateUser,CreateDate,UpdateUser,UpdateDate from ProductUnit ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.ProductUnit model = new Maticsoft.Model.ProductUnit();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.ProductUnit DataRowToModel(DataRow row)
        {
            Maticsoft.Model.ProductUnit model = new Maticsoft.Model.ProductUnit();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["UnitName"] != null)
                {
                    model.UnitName = row["UnitName"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["CreateUser"] != null && row["CreateUser"].ToString() != "")
                {
                    model.CreateUser = long.Parse(row["CreateUser"].ToString());
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["UpdateUser"] != null && row["UpdateUser"].ToString() != "")
                {
                    model.UpdateUser = long.Parse(row["UpdateUser"].ToString());
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UnitName,b1.UserName,p.CreateDate,b2.UserName,p.UpdateDate from ProductUnit p"
+"	left join BaseUser b1 on b1.UserID = p.CreateUser"
+"	left join BaseUser b2 on b2.UserID = p.UpdateUser");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,UnitName,Status,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM ProductUnit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM ProductUnit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from ProductUnit T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "ProductUnit";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        public bool Edit(List<Model.ProductUnit> insertList, List<Model.ProductUnit> updateList, List<Model.ProductUnit> delList,long id)
        {
            ArrayList arr = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductUnit model = delList[i];
                sbSql.Append("delete from ProductUnit where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }

            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductUnit model = updateList[i];
                sbSql.Append("update ProductUnit set UnitName='" + model.UnitName + "'");
                sbSql.Append(",UpdateUser='" + id + "',UpdateDate=getdate()");
                sbSql.Append(" where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }

            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductUnit model = insertList[i];
                sbSql.Append("insert into ProductUnit(UnitName,CreateUser,CreateDate) ");
                sbSql.Append("  values  ( ");
                sbSql.Append("'" + model.UnitName + "','" + id + "',getdate()");
                sbSql.Append(" ) ");
                arr.Add(sbSql.ToString());
            }
            DbHelperSQL.ExecuteSqlTran(arr);
            return true;
        }

        #endregion  ExtensionMethod
    }
}

