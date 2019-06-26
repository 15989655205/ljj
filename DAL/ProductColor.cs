using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Collections;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:ProductColor
    /// </summary>
    public partial class ProductColor
    {
        public ProductColor()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ProductColor");
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
        public long Add(Maticsoft.Model.ProductColor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductColor(");
            strSql.Append("ParentID,Code,Name,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@ParentID,@Code,@Name,@Enabled,@Status,@Remark,@Value0,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value0", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value1", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value2", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value3", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value4", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value5", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value6", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value7", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value8", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value9", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Enabled;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.Value0;
            parameters[7].Value = model.Value1;
            parameters[8].Value = model.Value2;
            parameters[9].Value = model.Value3;
            parameters[10].Value = model.Value4;
            parameters[11].Value = model.Value5;
            parameters[12].Value = model.Value6;
            parameters[13].Value = model.Value7;
            parameters[14].Value = model.Value8;
            parameters[15].Value = model.Value9;
            parameters[16].Value = model.CreateUser;
            parameters[17].Value = model.CreateDate;
            parameters[18].Value = model.UpdateUser;
            parameters[19].Value = model.UpdateDate;

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
        public bool Update(Maticsoft.Model.ProductColor model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductColor set ");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Code=@Code,");
            strSql.Append("Name=@Name,");
            strSql.Append("Enabled=@Enabled,");
            strSql.Append("Status=@Status,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Value0=@Value0,");
            strSql.Append("Value1=@Value1,");
            strSql.Append("Value2=@Value2,");
            strSql.Append("Value3=@Value3,");
            strSql.Append("Value4=@Value4,");
            strSql.Append("Value5=@Value5,");
            strSql.Append("Value6=@Value6,");
            strSql.Append("Value7=@Value7,");
            strSql.Append("Value8=@Value8,");
            strSql.Append("Value9=@Value9,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value0", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value1", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value2", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value3", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value4", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value5", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value6", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value7", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value8", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value9", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Enabled;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.Value0;
            parameters[7].Value = model.Value1;
            parameters[8].Value = model.Value2;
            parameters[9].Value = model.Value3;
            parameters[10].Value = model.Value4;
            parameters[11].Value = model.Value5;
            parameters[12].Value = model.Value6;
            parameters[13].Value = model.Value7;
            parameters[14].Value = model.Value8;
            parameters[15].Value = model.Value9;
            parameters[16].Value = model.CreateUser;
            parameters[17].Value = model.CreateDate;
            parameters[18].Value = model.UpdateUser;
            parameters[19].Value = model.UpdateDate;
            parameters[20].Value = model.ID;

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
            strSql.Append("delete from ProductColor ");
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
            strSql.Append("delete from ProductColor ");
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
        public Maticsoft.Model.ProductColor GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ParentID,Code,Name,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from ProductColor ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.ProductColor model = new Maticsoft.Model.ProductColor();
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
        public Maticsoft.Model.ProductColor DataRowToModel(DataRow row)
        {
            Maticsoft.Model.ProductColor model = new Maticsoft.Model.ProductColor();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(row["ParentID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Enabled"] != null && row["Enabled"].ToString() != "")
                {
                    if ((row["Enabled"].ToString() == "1") || (row["Enabled"].ToString().ToLower() == "true"))
                    {
                        model.Enabled = true;
                    }
                    else
                    {
                        model.Enabled = false;
                    }
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Value0"] != null)
                {
                    model.Value0 = row["Value0"].ToString();
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
                if (row["Value4"] != null)
                {
                    model.Value4 = row["Value4"].ToString();
                }
                if (row["Value5"] != null)
                {
                    model.Value5 = row["Value5"].ToString();
                }
                if (row["Value6"] != null)
                {
                    model.Value6 = row["Value6"].ToString();
                }
                if (row["Value7"] != null)
                {
                    model.Value7 = row["Value7"].ToString();
                }
                if (row["Value8"] != null)
                {
                    model.Value8 = row["Value8"].ToString();
                }
                if (row["Value9"] != null)
                {
                    model.Value9 = row["Value9"].ToString();
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
            strSql.Append("select ID ColorID,Name Corlor  ");
            strSql.Append("  FROM ProductColor ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetView(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM v_ProductColorShip ");
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
            strSql.Append(" ID,ParentID,Code,Name,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM ProductColor ");
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
            strSql.Append("select count(1) FROM ProductColor ");
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
            strSql.Append(")AS Row, T.*  from ProductColor T ");
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
            parameters[0].Value = "ProductColor";
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

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsImg(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select value2 from ProductColor");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        public bool Edit(List<Model.ProductColor> insertList, List<Model.ProductColor> updateList, List<Model.ProductColor> delList, List<Model.ProductColor> sequenceList, long UserID,long id)
        {
            ArrayList arr = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductColor model = delList[i];
                sbSql.Append("delete from ProductColor where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }

            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductColor model = updateList[i];
                sbSql.Append("update ProductColor set Code='" + model.Code + "', Name='" + model.Name.Trim() + "',Value0='" + model.Value0 + "',Value1='" + model.Value1 + "',Image='" + model.Image + "',CreateUser='" + model.CreateUser + "',CreateDate='"+model.CreateDate+"',UpdateUser=" + UserID + ",UpdateDate=getdate()");
                sbSql.Append(" where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }

            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductColor model = insertList[i];
                //sbSql.Append("insert into ProductColor  (ParentID,Code,Name,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate) ");
                sbSql.Append("insert into ProductColor  (ParentID,Code,Name,Enabled,Value0,Value1,Image,CreateUser,CreateDate,UpdateUser,UpdateDate) ");
                sbSql.Append("  values  ( ");
                sbSql.Append("'" + id + "','" + model.Code + "','" + model.Name + "','false','" + model.Value0 + "','" + model.Value1 + "','" + model.Image + "','" + UserID + "',getdate(),NULL,NULL");
                sbSql.Append(" ) ");
                arr.Add(sbSql.ToString());
            }
            DbHelperSQL.ExecuteSqlTran(arr);
            return true;
        }



        public DataSet GetDataSetByProc()
        {
            DataSet ds = new DataSet();
            SqlParameter[] paras ={
                               new SqlParameter("@ActionType",SqlDbType.NVarChar),
                               new SqlParameter("@Where",SqlDbType.NVarChar),
                               new SqlParameter("@Sort",SqlDbType.NVarChar),
                               };
            paras[0].Value = "Query4";
             ds=DbHelperSQL.RunProcedure("Sp_Product", paras, "ProductColor");
             return ds;
        }


        public bool EditColor(List<Model.ProductColor> insertList, List<Model.ProductColor> updateList, List<Model.ProductColor> delList,  long UserID)
        {
            ArrayList arr = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductColor model = delList[i];
                sbSql.Append("delete from ProductColor where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }

            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductColor model = updateList[i];
                sbSql.Append("update ProductColor set Code='" + model.Code + "', Name='" + model.Name.Trim() + "',Image='" + model.Image + "',Value0='" + model.Value0 + "',Value1='"+model.Value1+"',UpdateUser=" + UserID + ",UpdateDate=getdate()");
                sbSql.Append(" where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }

            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductColor model = insertList[i];
                //sbSql.Append("insert into ProductColor  (ParentID,Code,Name,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate) ");
                sbSql.Append("insert into ProductColor  (Code,Name,Image,Value0,Value1,CreateUser,CreateDate) ");
                sbSql.Append("  values  ( ");
                sbSql.Append("'" + model.Code + "','" + model.Name + "','" + model.Image + "','" + model.Value0 + "','" + model.Value1 + "','" + model.CreateUser + "',getdate()");
                sbSql.Append(" ) ");
                arr.Add(sbSql.ToString());
            }
            DbHelperSQL.ExecuteSqlTran(arr);
            return true;
        }


        public DataSet UpdateImageByProc(Model.ProductColor model, string type)
        {
            SqlParameter recordCount = new SqlParameter();
            recordCount.ParameterName = "@RecordCount";
            recordCount.Direction = ParameterDirection.Output;
            recordCount.Size = 100;
            SqlParameter[] paras = {
            new SqlParameter("@ID",SqlDbType.BigInt),
            new SqlParameter("@Image",SqlDbType.NVarChar),
            new SqlParameter("@ActionType",SqlDbType.NVarChar),
            recordCount
                                       };
            paras[0].Value = model.ID;
            paras[1].Value = model.Image;
            paras[2].Value = type;

            DataSet ds = new DataSet();
            ds = DbHelperSQL.RunProcedure("Sp_Product", paras, "Product");
            
            return ds;
        }

        public DataSet UpdateImageByProc2(Model.ProductColor model, string type)
        {
            SqlParameter recordCount = new SqlParameter();
            recordCount.ParameterName = "@RecordCount";
            recordCount.Direction = ParameterDirection.Output;
            recordCount.Size = 100;
            SqlParameter[] paras = {
            new SqlParameter("@ID",SqlDbType.BigInt),
            new SqlParameter("@Image",SqlDbType.NVarChar),
            new SqlParameter("@ActionType",SqlDbType.NVarChar),
            new SqlParameter("@UpdateUsee",SqlDbType.NVarChar),
            new SqlParameter("@UpdateDate",SqlDbType.NVarChar),
            recordCount
                                       };
            paras[0].Value = model.ID;
            paras[1].Value = model.Image;
            paras[2].Value = type;
            paras[3].Value = model.UpdateUser;
            paras[4].Value = model.UpdateDate;
            DataSet ds = new DataSet();
            ds = DbHelperSQL.RunProcedure("Sp_Product", paras, "Product");
            return ds;
        }

        #endregion  ExtensionMethod
    }
}

