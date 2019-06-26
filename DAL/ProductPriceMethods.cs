using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:ProductPriceMethods
    /// </summary>
    public partial class ProductPriceMethods
    {
        public ProductPriceMethods()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductPriceMethods");
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
        public long Add(Maticsoft.Model.ProductPriceMethods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductPriceMethods(");
            strSql.Append("Code,Name,Value1,Value2,Value3,v1,v2,v3,Status,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@Code,@Name,@Value1,@Value2,@Value3,@v1,@v2,@v3,@Status,@Remark,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NChar,10),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Value1", SqlDbType.NVarChar,100),
					new SqlParameter("@Value2", SqlDbType.NVarChar,50),
					new SqlParameter("@Value3", SqlDbType.NVarChar,50),
					new SqlParameter("@v1", SqlDbType.Int,4),
					new SqlParameter("@v2", SqlDbType.Int,4),
					new SqlParameter("@v3", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateUser", SqlDbType.NChar,10),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.NChar,10),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Value1;
            parameters[3].Value = model.Value2;
            parameters[4].Value = model.Value3;
            parameters[5].Value = model.v1;
            parameters[6].Value = model.v2;
            parameters[7].Value = model.v3;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.CreateUser;
            parameters[11].Value = model.CreateDate;
            parameters[12].Value = model.UpdateUser;
            parameters[13].Value = model.UpdateDate;

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
        public bool Update(Maticsoft.Model.ProductPriceMethods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductPriceMethods set ");
            strSql.Append("Code=@Code,");
            strSql.Append("Name=@Name,");
            strSql.Append("Value1=@Value1,");
            strSql.Append("Value2=@Value2,");
            strSql.Append("Value3=@Value3,");
            strSql.Append("v1=@v1,");
            strSql.Append("v2=@v2,");
            strSql.Append("v3=@v3,");
            strSql.Append("Status=@Status,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NChar,10),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Value1", SqlDbType.NVarChar,100),
					new SqlParameter("@Value2", SqlDbType.NVarChar,50),
					new SqlParameter("@Value3", SqlDbType.NVarChar,50),
					new SqlParameter("@v1", SqlDbType.Int,4),
					new SqlParameter("@v2", SqlDbType.Int,4),
					new SqlParameter("@v3", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateUser", SqlDbType.NChar,10),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.NChar,10),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Value1;
            parameters[3].Value = model.Value2;
            parameters[4].Value = model.Value3;
            parameters[5].Value = model.v1;
            parameters[6].Value = model.v2;
            parameters[7].Value = model.v3;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.CreateUser;
            parameters[11].Value = model.CreateDate;
            parameters[12].Value = model.UpdateUser;
            parameters[13].Value = model.UpdateDate;
            parameters[14].Value = model.ID;

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
            strSql.Append("delete from ProductPriceMethods ");
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
            strSql.Append("delete from ProductPriceMethods ");
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
        public Maticsoft.Model.ProductPriceMethods GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Code,Name,Value1,Value2,Value3,v1,v2,v3,Status,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate from ProductPriceMethods ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.ProductPriceMethods model = new Maticsoft.Model.ProductPriceMethods();
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
        public Maticsoft.Model.ProductPriceMethods DataRowToModel(DataRow row)
        {
            Maticsoft.Model.ProductPriceMethods model = new Maticsoft.Model.ProductPriceMethods();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Value1"] != null)
                {
                    model.Value1 = row["Value1"].ToString();
                }
                if (row["Value2"] != null)
                {
                    model.Value2 = row["Value2"].ToString();
                }
                if (row["Value3"] != null)
                {
                    model.Value3 = row["Value3"].ToString();
                }
                if (row["v1"] != null && row["v1"].ToString() != "")
                {
                    model.v1 = int.Parse(row["v1"].ToString());
                }
                if (row["v2"] != null && row["v2"].ToString() != "")
                {
                    model.v2 = int.Parse(row["v2"].ToString());
                }
                if (row["v3"] != null && row["v3"].ToString() != "")
                {
                    model.v3 = int.Parse(row["v3"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreateUser"] != null)
                {
                    model.CreateUser = row["CreateUser"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["UpdateUser"] != null)
                {
                    model.UpdateUser = row["UpdateUser"].ToString();
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
            strSql.Append("select ID,Code,Name,Value1,Value2,Value3,v1,v2,v3,Status,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM ProductPriceMethods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int  CateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Code,Name,Value1,Value2,Value3,v1,v2,v3,Status,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM ProductPriceMethods ");
            strSql.Append(" where CateID= "+CateID+" ");
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
            strSql.Append(" ID,Code,Name,Value1,Value2,Value3,v1,v2,v3,Status,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM ProductPriceMethods ");
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
            strSql.Append("select count(1) FROM ProductPriceMethods ");
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
            strSql.Append(")AS Row, T.*  from ProductPriceMethods T ");
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
            parameters[0].Value = "ProductPriceMethods";
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

        #endregion  ExtensionMethod
    }
}

