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
    /// 数据访问类:jxc_Currency
    /// </summary>
    public partial class jxc_Currency
    {
        public jxc_Currency()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from jxc_Currency");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.jxc_Currency model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into jxc_Currency(");
            strSql.Append("Name,Code,ExchangeRate,Directions,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,status,create_person,create_date,update_person,update_date)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Code,@ExchangeRate,@Directions,@AuditDate,@AuditGuy,@remark,@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@n1,@n2,@n3,@status,@create_person,@create_date,@update_person,@update_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@Directions", SqlDbType.NVarChar,200),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@AuditGuy", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@v1", SqlDbType.NVarChar,255),
					new SqlParameter("@v2", SqlDbType.NVarChar,255),
					new SqlParameter("@v3", SqlDbType.NVarChar,255),
					new SqlParameter("@v4", SqlDbType.NVarChar,255),
					new SqlParameter("@v5", SqlDbType.NVarChar,255),
					new SqlParameter("@v6", SqlDbType.NVarChar,255),
					new SqlParameter("@v7", SqlDbType.NVarChar,255),
					new SqlParameter("@v8", SqlDbType.NVarChar,255),
					new SqlParameter("@v9", SqlDbType.NVarChar,255),
					new SqlParameter("@v10", SqlDbType.NVarChar,255),
					new SqlParameter("@n1", SqlDbType.Int,4),
					new SqlParameter("@n2", SqlDbType.Int,4),
					new SqlParameter("@n3", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.ExchangeRate;
            parameters[3].Value = model.Directions;
            parameters[4].Value = model.AuditDate;
            parameters[5].Value = model.AuditGuy;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.v1;
            parameters[8].Value = model.v2;
            parameters[9].Value = model.v3;
            parameters[10].Value = model.v4;
            parameters[11].Value = model.v5;
            parameters[12].Value = model.v6;
            parameters[13].Value = model.v7;
            parameters[14].Value = model.v8;
            parameters[15].Value = model.v9;
            parameters[16].Value = model.v10;
            parameters[17].Value = model.n1;
            parameters[18].Value = model.n2;
            parameters[19].Value = model.n3;
            parameters[20].Value = model.status;
            parameters[21].Value = model.create_person;
            parameters[22].Value = model.create_date;
            parameters[23].Value = model.update_person;
            parameters[24].Value = model.update_date;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.jxc_Currency model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update jxc_Currency set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Code=@Code,");
            strSql.Append("ExchangeRate=@ExchangeRate,");
            strSql.Append("Directions=@Directions,");
            strSql.Append("AuditDate=@AuditDate,");
            strSql.Append("AuditGuy=@AuditGuy,");
            strSql.Append("remark=@remark,");
            strSql.Append("v1=@v1,");
            strSql.Append("v2=@v2,");
            strSql.Append("v3=@v3,");
            strSql.Append("v4=@v4,");
            strSql.Append("v5=@v5,");
            strSql.Append("v6=@v6,");
            strSql.Append("v7=@v7,");
            strSql.Append("v8=@v8,");
            strSql.Append("v9=@v9,");
            strSql.Append("v10=@v10,");
            strSql.Append("n1=@n1,");
            strSql.Append("n2=@n2,");
            strSql.Append("n3=@n3,");
            strSql.Append("status=@status,");
            strSql.Append("create_person=@create_person,");
            strSql.Append("create_date=@create_date,");
            strSql.Append("update_person=@update_person,");
            strSql.Append("update_date=@update_date");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@Directions", SqlDbType.NVarChar,200),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@AuditGuy", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@v1", SqlDbType.NVarChar,255),
					new SqlParameter("@v2", SqlDbType.NVarChar,255),
					new SqlParameter("@v3", SqlDbType.NVarChar,255),
					new SqlParameter("@v4", SqlDbType.NVarChar,255),
					new SqlParameter("@v5", SqlDbType.NVarChar,255),
					new SqlParameter("@v6", SqlDbType.NVarChar,255),
					new SqlParameter("@v7", SqlDbType.NVarChar,255),
					new SqlParameter("@v8", SqlDbType.NVarChar,255),
					new SqlParameter("@v9", SqlDbType.NVarChar,255),
					new SqlParameter("@v10", SqlDbType.NVarChar,255),
					new SqlParameter("@n1", SqlDbType.Int,4),
					new SqlParameter("@n2", SqlDbType.Int,4),
					new SqlParameter("@n3", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.ExchangeRate;
            parameters[3].Value = model.Directions;
            parameters[4].Value = model.AuditDate;
            parameters[5].Value = model.AuditGuy;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.v1;
            parameters[8].Value = model.v2;
            parameters[9].Value = model.v3;
            parameters[10].Value = model.v4;
            parameters[11].Value = model.v5;
            parameters[12].Value = model.v6;
            parameters[13].Value = model.v7;
            parameters[14].Value = model.v8;
            parameters[15].Value = model.v9;
            parameters[16].Value = model.v10;
            parameters[17].Value = model.n1;
            parameters[18].Value = model.n2;
            parameters[19].Value = model.n3;
            parameters[20].Value = model.status;
            parameters[21].Value = model.create_person;
            parameters[22].Value = model.create_date;
            parameters[23].Value = model.update_person;
            parameters[24].Value = model.update_date;
            parameters[25].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from jxc_Currency ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
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
            strSql.Append("delete from jxc_Currency ");
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
        public Maticsoft.Model.jxc_Currency GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Code,ExchangeRate,Directions,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,status,create_person,create_date,update_person,update_date from jxc_Currency ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.jxc_Currency model = new Maticsoft.Model.jxc_Currency();
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
        public Maticsoft.Model.jxc_Currency DataRowToModel(DataRow row)
        {
            Maticsoft.Model.jxc_Currency model = new Maticsoft.Model.jxc_Currency();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["ExchangeRate"] != null && row["ExchangeRate"].ToString() != "")
                {
                    model.ExchangeRate = decimal.Parse(row["ExchangeRate"].ToString());
                }
                if (row["Directions"] != null)
                {
                    model.Directions = row["Directions"].ToString();
                }
                if (row["AuditDate"] != null && row["AuditDate"].ToString() != "")
                {
                    model.AuditDate = DateTime.Parse(row["AuditDate"].ToString());
                }
                if (row["AuditGuy"] != null)
                {
                    model.AuditGuy = row["AuditGuy"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["v1"] != null)
                {
                    model.v1 = row["v1"].ToString();
                }
                if (row["v2"] != null)
                {
                    model.v2 = row["v2"].ToString();
                }
                if (row["v3"] != null)
                {
                    model.v3 = row["v3"].ToString();
                }
                if (row["v4"] != null)
                {
                    model.v4 = row["v4"].ToString();
                }
                if (row["v5"] != null)
                {
                    model.v5 = row["v5"].ToString();
                }
                if (row["v6"] != null)
                {
                    model.v6 = row["v6"].ToString();
                }
                if (row["v7"] != null)
                {
                    model.v7 = row["v7"].ToString();
                }
                if (row["v8"] != null)
                {
                    model.v8 = row["v8"].ToString();
                }
                if (row["v9"] != null)
                {
                    model.v9 = row["v9"].ToString();
                }
                if (row["v10"] != null)
                {
                    model.v10 = row["v10"].ToString();
                }
                if (row["n1"] != null && row["n1"].ToString() != "")
                {
                    model.n1 = int.Parse(row["n1"].ToString());
                }
                if (row["n2"] != null && row["n2"].ToString() != "")
                {
                    model.n2 = int.Parse(row["n2"].ToString());
                }
                if (row["n3"] != null && row["n3"].ToString() != "")
                {
                    model.n3 = int.Parse(row["n3"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
                if (row["create_person"] != null)
                {
                    model.create_person = row["create_person"].ToString();
                }
                if (row["create_date"] != null && row["create_date"].ToString() != "")
                {
                    model.create_date = DateTime.Parse(row["create_date"].ToString());
                }
                if (row["update_person"] != null)
                {
                    model.update_person = row["update_person"].ToString();
                }
                if (row["update_date"] != null && row["update_date"].ToString() != "")
                {
                    model.update_date = DateTime.Parse(row["update_date"].ToString());
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
            strSql.Append("select ID,Name,Code,ExchangeRate,Directions,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM jxc_Currency ");
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
            strSql.Append(" ID,Name,Code,ExchangeRate,Directions,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM jxc_Currency ");
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
            strSql.Append("select count(1) FROM jxc_Currency ");
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
            strSql.Append(")AS Row, T.*  from jxc_Currency T ");
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
            parameters[0].Value = "jxc_Currency";
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

        public bool EditStock(List<Model.jxc_Currency> insertList, List<Model.jxc_Currency> updateList, List<Model.jxc_Currency> delList,long id)
        {
            ArrayList arr = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.jxc_Currency model = delList[i];
                sbSql.Append("delete from jxc_Currency where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }

            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.jxc_Currency model = updateList[i];
                sbSql.Append("update jxc_Currency set Name='" + model.Name + "',Code='" + model.Code + "',ExchangeRate='" + model.ExchangeRate + "'");
                sbSql.Append(",Directions='" + model.Directions + "',remark='" + model.remark + "',update_person='" + id + "',update_date=getdate()");
                sbSql.Append(" where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }

            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.jxc_Currency model = insertList[i];
                sbSql.Append("insert into jxc_Currency(Name,Code,ExchangeRate,Directions,remark,create_person,create_date) ");
                sbSql.Append("  values  ( ");
                sbSql.Append("'" + model.Name + "','" + model.Code + "','" + model.ExchangeRate + "','" + model.Directions + "','" + model.remark + "','" + id + "',getdate()");
                sbSql.Append(" ) ");
                arr.Add(sbSql.ToString());
            }
            DbHelperSQL.ExecuteSqlTran(arr);
            return true;
        }

        #endregion  ExtensionMethod
    }
}

