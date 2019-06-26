using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:project_item_flow
    /// </summary>
    public partial class project_item_flow
    {
        public project_item_flow()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from project_item_flow");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.project_item_flow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into project_item_flow(");
            strSql.Append("fw_sid,psi_sid,psi_name,begin_time,end_time,SN,fw_name,value1,value2,value3,value4,n1,n2,n3,n4)");
            strSql.Append(" values (");
            strSql.Append("@fw_sid,@psi_sid,@psi_name,@begin_time,@end_time,@SN,@fw_name,@value1,@value2,@value3,@value4,@n1,@n2,@n3,@n4)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@fw_sid", SqlDbType.Int,4),
					new SqlParameter("@psi_sid", SqlDbType.Int,4),
					new SqlParameter("@psi_name", SqlDbType.NVarChar,400),
					new SqlParameter("@begin_time", SqlDbType.DateTime),
					new SqlParameter("@end_time", SqlDbType.DateTime),
					new SqlParameter("@SN", SqlDbType.Int,4),
					new SqlParameter("@fw_name", SqlDbType.NVarChar,400),
					new SqlParameter("@value1", SqlDbType.NVarChar,400),
					new SqlParameter("@value2", SqlDbType.NVarChar,400),
					new SqlParameter("@value3", SqlDbType.NVarChar,400),
					new SqlParameter("@value4", SqlDbType.NVarChar,400),
					new SqlParameter("@n1", SqlDbType.Int,4),
					new SqlParameter("@n2", SqlDbType.Int,4),
					new SqlParameter("@n3", SqlDbType.Int,4),
					new SqlParameter("@n4", SqlDbType.Int,4)};
            parameters[0].Value = model.fw_sid;
            parameters[1].Value = model.psi_sid;
            parameters[2].Value = model.psi_name;
            parameters[3].Value = model.begin_time;
            parameters[4].Value = model.end_time;
            parameters[5].Value = model.SN;
            parameters[6].Value = model.fw_name;
            parameters[7].Value = model.value1;
            parameters[8].Value = model.value2;
            parameters[9].Value = model.value3;
            parameters[10].Value = model.value4;
            parameters[11].Value = model.n1;
            parameters[12].Value = model.n2;
            parameters[13].Value = model.n3;
            parameters[14].Value = model.n4;

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
        public bool Update(Maticsoft.Model.project_item_flow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update project_item_flow set ");
            strSql.Append("fw_sid=@fw_sid,");
            strSql.Append("psi_sid=@psi_sid,");
            strSql.Append("psi_name=@psi_name,");
            strSql.Append("begin_time=@begin_time,");
            strSql.Append("end_time=@end_time,");
            strSql.Append("SN=@SN,");
            strSql.Append("fw_name=@fw_name,");
            strSql.Append("value1=@value1,");
            strSql.Append("value2=@value2,");
            strSql.Append("value3=@value3,");
            strSql.Append("value4=@value4,");
            strSql.Append("n1=@n1,");
            strSql.Append("n2=@n2,");
            strSql.Append("n3=@n3,");
            strSql.Append("n4=@n4");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@fw_sid", SqlDbType.Int,4),
					new SqlParameter("@psi_sid", SqlDbType.Int,4),
					new SqlParameter("@psi_name", SqlDbType.NVarChar,400),
					new SqlParameter("@begin_time", SqlDbType.DateTime),
					new SqlParameter("@end_time", SqlDbType.DateTime),
					new SqlParameter("@SN", SqlDbType.Int,4),
					new SqlParameter("@fw_name", SqlDbType.NVarChar,400),
					new SqlParameter("@value1", SqlDbType.NVarChar,400),
					new SqlParameter("@value2", SqlDbType.NVarChar,400),
					new SqlParameter("@value3", SqlDbType.NVarChar,400),
					new SqlParameter("@value4", SqlDbType.NVarChar,400),
					new SqlParameter("@n1", SqlDbType.Int,4),
					new SqlParameter("@n2", SqlDbType.Int,4),
					new SqlParameter("@n3", SqlDbType.Int,4),
					new SqlParameter("@n4", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.fw_sid;
            parameters[1].Value = model.psi_sid;
            parameters[2].Value = model.psi_name;
            parameters[3].Value = model.begin_time;
            parameters[4].Value = model.end_time;
            parameters[5].Value = model.SN;
            parameters[6].Value = model.fw_name;
            parameters[7].Value = model.value1;
            parameters[8].Value = model.value2;
            parameters[9].Value = model.value3;
            parameters[10].Value = model.value4;
            parameters[11].Value = model.n1;
            parameters[12].Value = model.n2;
            parameters[13].Value = model.n3;
            parameters[14].Value = model.n4;
            parameters[15].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from project_item_flow ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from project_item_flow ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Maticsoft.Model.project_item_flow GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,fw_sid,psi_sid,psi_name,begin_time,end_time,SN,fw_name,value1,value2,value3,value4,n1,n2,n3,n4 from project_item_flow ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Maticsoft.Model.project_item_flow model = new Maticsoft.Model.project_item_flow();
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
        public Maticsoft.Model.project_item_flow DataRowToModel(DataRow row)
        {
            Maticsoft.Model.project_item_flow model = new Maticsoft.Model.project_item_flow();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["fw_sid"] != null && row["fw_sid"].ToString() != "")
                {
                    model.fw_sid = int.Parse(row["fw_sid"].ToString());
                }
                if (row["psi_sid"] != null && row["psi_sid"].ToString() != "")
                {
                    model.psi_sid = int.Parse(row["psi_sid"].ToString());
                }
                if (row["psi_name"] != null)
                {
                    model.psi_name = row["psi_name"].ToString();
                }
                if (row["begin_time"] != null && row["begin_time"].ToString() != "")
                {
                    model.begin_time = DateTime.Parse(row["begin_time"].ToString());
                }
                if (row["end_time"] != null && row["end_time"].ToString() != "")
                {
                    model.end_time = DateTime.Parse(row["end_time"].ToString());
                }
                if (row["SN"] != null && row["SN"].ToString() != "")
                {
                    model.SN = int.Parse(row["SN"].ToString());
                }
                if (row["fw_name"] != null)
                {
                    model.fw_name = row["fw_name"].ToString();
                }
                if (row["value1"] != null)
                {
                    model.value1 = row["value1"].ToString();
                }
                if (row["value2"] != null)
                {
                    model.value2 = row["value2"].ToString();
                }
                if (row["value3"] != null)
                {
                    model.value3 = row["value3"].ToString();
                }
                if (row["value4"] != null)
                {
                    model.value4 = row["value4"].ToString();
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
                if (row["n4"] != null && row["n4"].ToString() != "")
                {
                    model.n4 = int.Parse(row["n4"].ToString());
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
            strSql.Append("select id,fw_sid,psi_sid,psi_name,begin_time,end_time,SN,fw_name,value1,value2,value3,value4,n1,n2,n3,n4 ");
            strSql.Append(" FROM project_item_flow ");
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
            strSql.Append(" id,fw_sid,psi_sid,psi_name,begin_time,end_time,SN,fw_name,value1,value2,value3,value4,n1,n2,n3,n4 ");
            strSql.Append(" FROM project_item_flow ");
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
            strSql.Append("select count(1) FROM project_item_flow ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from project_item_flow T ");
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
            parameters[0].Value = "project_item_flow";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool exists(string  where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from project_item_flow ");
            strSql.Append(where);

            return DbHelperSQL.Exists(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}

