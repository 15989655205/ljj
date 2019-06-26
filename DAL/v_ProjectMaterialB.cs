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
    /// 数据访问类:v_ProjectMaterialB
    /// </summary>
    public partial class v_ProjectMaterialB
    {
        public v_ProjectMaterialB()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ppmiSid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_ProjectMaterialB");
            strSql.Append(" where ppmiSid=@ppmiSid ");
            SqlParameter[] parameters = {
					new SqlParameter("@ppmiSid", SqlDbType.Int,4)			};
            parameters[0].Value = ppmiSid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        //public bool Add(Maticsoft.Model.v_ProjectMaterialB model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into v_ProjectMaterialB(");
        //    strSql.Append("FileNumber,ProductItem,ppmiBrand,manufacturerPhone,ppmiRemark,Name,ptID,spID,productName,project_name,manufacturerNumber,ProjectID,psName,productID,ppmiSid)");
        //    strSql.Append(" values (");
        //    strSql.Append("@FileNumber,@ProductItem,@ppmiBrand,@manufacturerPhone,@ppmiRemark,@Name,@ptID,@spID,@productName,@project_name,@manufacturerNumber,@ProjectID,@psName,@productID,@ppmiSid)");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@FileNumber", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ProductItem", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ppmiBrand", SqlDbType.NVarChar,50),
        //            new SqlParameter("@manufacturerPhone", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ppmiRemark", SqlDbType.Text),
        //            new SqlParameter("@Name", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ptID", SqlDbType.BigInt,8),
        //            new SqlParameter("@spID", SqlDbType.BigInt,8),
        //            new SqlParameter("@productName", SqlDbType.NVarChar,50),
        //            new SqlParameter("@project_name", SqlDbType.NVarChar,100),
        //            new SqlParameter("@manufacturerNumber", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ProjectID", SqlDbType.Int,4),
        //            new SqlParameter("@psName", SqlDbType.NVarChar,100),
        //            new SqlParameter("@productID", SqlDbType.BigInt,8),
        //            new SqlParameter("@ppmiSid", SqlDbType.Int,4)};
        //    parameters[0].Value = model.FileNumber;
        //    parameters[1].Value = model.ProductItem;
        //    parameters[2].Value = model.ppmiBrand;
        //    parameters[3].Value = model.manufacturerPhone;
        //    parameters[4].Value = model.ppmiRemark;
        //    parameters[5].Value = model.Name;
        //    parameters[6].Value = model.ptID;
        //    parameters[7].Value = model.spID;
        //    parameters[8].Value = model.productName;
        //    parameters[9].Value = model.project_name;
        //    parameters[10].Value = model.manufacturerNumber;
        //    parameters[11].Value = model.ProjectID;
        //    parameters[12].Value = model.psName;
        //    parameters[13].Value = model.productID;
        //    parameters[14].Value = model.ppmiSid;

        //    int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        //public bool Update(Maticsoft.Model.v_ProjectMaterialB model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update v_ProjectMaterialB set ");
        //    strSql.Append("FileNumber=@FileNumber,");
        //    strSql.Append("ProductItem=@ProductItem,");
        //    strSql.Append("ppmiBrand=@ppmiBrand,");
        //    strSql.Append("manufacturerPhone=@manufacturerPhone,");
        //    strSql.Append("ppmiRemark=@ppmiRemark,");
        //    strSql.Append("Name=@Name,");
        //    strSql.Append("ptID=@ptID,");
        //    strSql.Append("spID=@spID,");
        //    strSql.Append("productName=@productName,");
        //    strSql.Append("project_name=@project_name,");
        //    strSql.Append("manufacturerNumber=@manufacturerNumber,");
        //    strSql.Append("ProjectID=@ProjectID,");
        //    strSql.Append("psName=@psName,");
        //    strSql.Append("productID=@productID,");
        //    strSql.Append("ppmiSid=@ppmiSid");
        //    strSql.Append(" where ppmiSid=@ppmiSid ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@FileNumber", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ProductItem", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ppmiBrand", SqlDbType.NVarChar,50),
        //            new SqlParameter("@manufacturerPhone", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ppmiRemark", SqlDbType.Text),
        //            new SqlParameter("@Name", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ptID", SqlDbType.BigInt,8),
        //            new SqlParameter("@spID", SqlDbType.BigInt,8),
        //            new SqlParameter("@productName", SqlDbType.NVarChar,50),
        //            new SqlParameter("@project_name", SqlDbType.NVarChar,100),
        //            new SqlParameter("@manufacturerNumber", SqlDbType.NVarChar,50),
        //            new SqlParameter("@ProjectID", SqlDbType.Int,4),
        //            new SqlParameter("@psName", SqlDbType.NVarChar,100),
        //            new SqlParameter("@productID", SqlDbType.BigInt,8),
        //            new SqlParameter("@ppmiSid", SqlDbType.Int,4)};
        //    parameters[0].Value = model.FileNumber;
        //    parameters[1].Value = model.ProductItem;
        //    parameters[2].Value = model.ppmiBrand;
        //    parameters[3].Value = model.manufacturerPhone;
        //    parameters[4].Value = model.ppmiRemark;
        //    parameters[5].Value = model.Name;
        //    parameters[6].Value = model.ptID;
        //    parameters[7].Value = model.spID;
        //    parameters[8].Value = model.productName;
        //    parameters[9].Value = model.project_name;
        //    parameters[10].Value = model.manufacturerNumber;
        //    parameters[11].Value = model.ProjectID;
        //    parameters[12].Value = model.psName;
        //    parameters[13].Value = model.productID;
        //    parameters[14].Value = model.ppmiSid;

        //    int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ppmiSid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_ProjectMaterialB ");
            strSql.Append(" where ppmiSid=@ppmiSid ");
            SqlParameter[] parameters = {
					new SqlParameter("@ppmiSid", SqlDbType.Int,4)			};
            parameters[0].Value = ppmiSid;

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
        public bool DeleteList(string ppmiSidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_ProjectMaterialB ");
            strSql.Append(" where ppmiSid in (" + ppmiSidlist + ")  ");
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
        ///// </summary>
        //public Maticsoft.Model.v_ProjectMaterialB GetModel(int ppmiSid)
        //{

        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select  top 1 FileNumber,ProductItem,ppmiBrand,manufacturerPhone,ppmiRemark,Name,ptID,spID,productName,project_name,manufacturerNumber,ProjectID,psName,productID,ppmiSid from v_ProjectMaterialB ");
        //    strSql.Append(" where ppmiSid=@ppmiSid ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@ppmiSid", SqlDbType.Int,4)			};
        //    parameters[0].Value = ppmiSid;

        //    Maticsoft.Model.v_ProjectMaterialB model = new Maticsoft.Model.v_ProjectMaterialB();
        //    DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        return DataRowToModel(ds.Tables[0].Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        //public Maticsoft.Model.v_ProjectMaterialB DataRowToModel(DataRow row)
        //{
        //    Maticsoft.Model.v_ProjectMaterialB model = new Maticsoft.Model.v_ProjectMaterialB();
        //    if (row != null)
        //    {
        //        if (row["FileNumber"] != null)
        //        {
        //            model.FileNumber = row["FileNumber"].ToString();
        //        }
        //        if (row["ProductItem"] != null)
        //        {
        //            model.ProductItem = row["ProductItem"].ToString();
        //        }
        //        if (row["ppmiBrand"] != null)
        //        {
        //            model.ppmiBrand = row["ppmiBrand"].ToString();
        //        }
        //        if (row["manufacturerPhone"] != null)
        //        {
        //            model.manufacturerPhone = row["manufacturerPhone"].ToString();
        //        }
        //        if (row["ppmiRemark"] != null)
        //        {
        //            model.ppmiRemark = row["ppmiRemark"].ToString();
        //        }
        //        if (row["Name"] != null)
        //        {
        //            model.Name = row["Name"].ToString();
        //        }
        //        if (row["ptID"] != null && row["ptID"].ToString() != "")
        //        {
        //            model.ptID = long.Parse(row["ptID"].ToString());
        //        }
        //        if (row["spID"] != null && row["spID"].ToString() != "")
        //        {
        //            model.spID = long.Parse(row["spID"].ToString());
        //        }
        //        if (row["productName"] != null)
        //        {
        //            model.productName = row["productName"].ToString();
        //        }
        //        if (row["project_name"] != null)
        //        {
        //            model.project_name = row["project_name"].ToString();
        //        }
        //        if (row["manufacturerNumber"] != null)
        //        {
        //            model.manufacturerNumber = row["manufacturerNumber"].ToString();
        //        }
        //        if (row["ProjectID"] != null && row["ProjectID"].ToString() != "")
        //        {
        //            model.ProjectID = int.Parse(row["ProjectID"].ToString());
        //        }
        //        if (row["psName"] != null)
        //        {
        //            model.psName = row["psName"].ToString();
        //        }
        //        if (row["productID"] != null && row["productID"].ToString() != "")
        //        {
        //            model.productID = long.Parse(row["productID"].ToString());
        //        }
        //        if (row["ppmiSid"] != null && row["ppmiSid"].ToString() != "")
        //        {
        //            model.ppmiSid = int.Parse(row["ppmiSid"].ToString());
        //        }
        //    }
        //    return model;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FileNumber,ProductItem,ppmiBrand,manufacturerPhone,ppmiRemark,Name,ptID,spID,productName,project_name,manufacturerNumber,ProjectID,psName,productID,ppmiSid ");
            strSql.Append(" FROM v_ProjectMaterialB ");
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
            strSql.Append(" FileNumber,ProductItem,ppmiBrand,manufacturerPhone,ppmiRemark,Name,ptID,spID,productName,project_name,manufacturerNumber,ProjectID,psName,productID,ppmiSid ");
            strSql.Append(" FROM v_ProjectMaterialB ");
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
            strSql.Append("select count(1) FROM v_ProjectMaterialB ");
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
                strSql.Append("order by T.ppmiSid desc");
            }
            strSql.Append(")AS Row, T.*  from v_ProjectMaterialB T ");
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
            parameters[0].Value = "v_ProjectMaterialB";
            parameters[1].Value = "ppmiSid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        //public bool Edit( List<Model.v_ProjectMaterialB> updateList)
        //{
        //    ArrayList arr = new ArrayList();
        //    StringBuilder sbSql = new StringBuilder();

        //    for (int i = 0; i < updateList.Count; i++)
        //    {
        //        sbSql = new StringBuilder();
        //        Model.v_ProjectMaterialB model = updateList[i];
        //        sbSql.Append("update Project_Product_Material_B_Item set SupplierID='" + model.manufacturerNumber + "',manufacturerPhone='" + model.manufacturerPhone + "',brand='" + model.ppmiBrand + "'");

        //        sbSql.Append("  where   sid="+model.ppmiSid+" ");
        //        arr.Add(sbSql.ToString());
        //    }

  
        //    DbHelperSQL.ExecuteSqlTran(arr);
        //    return true;
        //}

        #endregion  ExtensionMethod
    }
}

