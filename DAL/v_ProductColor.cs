using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:v_ProductColor
    /// </summary>
    public partial class v_ProductColor
    {
        public v_ProductColor()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID, long pid, string ColorCode, string ColorName, decimal CBarginPriceOut, decimal CStandardPriceIn, decimal CTagPrice, decimal CReferencePriceA, decimal CReferencePriceB, decimal CReferencePriceC, decimal CReferencePriceD, decimal CReferencePriceE, decimal CReferencePriceF, string member, string PCode, string PName, long SeriesID, long TypeID, string Manufacturer)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_ProductColor");
            strSql.Append(" where ID=@ID and pid=@pid and ColorCode=@ColorCode and ColorName=@ColorName and CBarginPriceOut=@CBarginPriceOut and CStandardPriceIn=@CStandardPriceIn and CTagPrice=@CTagPrice and CReferencePriceA=@CReferencePriceA and CReferencePriceB=@CReferencePriceB and CReferencePriceC=@CReferencePriceC and CReferencePriceD=@CReferencePriceD and CReferencePriceE=@CReferencePriceE and CReferencePriceF=@CReferencePriceF and member=@member and PCode=@PCode and PName=@PName and SeriesID=@SeriesID and TypeID=@TypeID and Manufacturer=@Manufacturer ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8),
					new SqlParameter("@pid", SqlDbType.BigInt,8),
					new SqlParameter("@ColorCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ColorName", SqlDbType.NVarChar,50),
					new SqlParameter("@CBarginPriceOut", SqlDbType.Money,8),
					new SqlParameter("@CStandardPriceIn", SqlDbType.Money,8),
					new SqlParameter("@CTagPrice", SqlDbType.Money,8),
					new SqlParameter("@CReferencePriceA", SqlDbType.Money,8),
					new SqlParameter("@CReferencePriceB", SqlDbType.Money,8),
					new SqlParameter("@CReferencePriceC", SqlDbType.Money,8),
					new SqlParameter("@CReferencePriceD", SqlDbType.Money,8),
					new SqlParameter("@CReferencePriceE", SqlDbType.Money,8),
					new SqlParameter("@CReferencePriceF", SqlDbType.Money,8),
					new SqlParameter("@member", SqlDbType.NVarChar,-1),
					new SqlParameter("@PCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PName", SqlDbType.NVarChar,50),
					new SqlParameter("@SeriesID", SqlDbType.BigInt,8),
					new SqlParameter("@TypeID", SqlDbType.BigInt,8),
					new SqlParameter("@Manufacturer", SqlDbType.NVarChar,50)			};
            parameters[0].Value = ID;
            parameters[1].Value = pid;
            parameters[2].Value = ColorCode;
            parameters[3].Value = ColorName;
            parameters[4].Value = CBarginPriceOut;
            parameters[5].Value = CStandardPriceIn;
            parameters[6].Value = CTagPrice;
            parameters[7].Value = CReferencePriceA;
            parameters[8].Value = CReferencePriceB;
            parameters[9].Value = CReferencePriceC;
            parameters[10].Value = CReferencePriceD;
            parameters[11].Value = CReferencePriceE;
            parameters[12].Value = CReferencePriceF;
            parameters[13].Value = member;
            parameters[14].Value = PCode;
            parameters[15].Value = PName;
            parameters[16].Value = SeriesID;
            parameters[17].Value = TypeID;
            parameters[18].Value = Manufacturer;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.v_ProductColor GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,pid,ColorCode,ColorName,CBarginPriceOut,CStandardPriceIn,CTagPrice,CReferencePriceA,CReferencePriceB,CReferencePriceC,CReferencePriceD,CReferencePriceE,CReferencePriceF,member,PCode,PName,SeriesID,TypeID,Manufacturer from v_ProductColor ");
            strSql.Append(" where ID=@ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)			};
            parameters[0].Value = ID;

            Maticsoft.Model.v_ProductColor model = new Maticsoft.Model.v_ProductColor();
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
        public Maticsoft.Model.v_ProductColor DataRowToModel(DataRow row)
        {
            Maticsoft.Model.v_ProductColor model = new Maticsoft.Model.v_ProductColor();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["pid"] != null && row["pid"].ToString() != "")
                {
                    model.pid = long.Parse(row["pid"].ToString());
                }
                if (row["ColorCode"] != null)
                {
                    model.ColorCode = row["ColorCode"].ToString();
                }
                if (row["ColorName"] != null)
                {
                    model.ColorName = row["ColorName"].ToString();
                }
                if (row["CBarginPriceOut"] != null && row["CBarginPriceOut"].ToString() != "")
                {
                    model.CBarginPriceOut = decimal.Parse(row["CBarginPriceOut"].ToString());
                }
                if (row["CStandardPriceIn"] != null && row["CStandardPriceIn"].ToString() != "")
                {
                    model.CStandardPriceIn = decimal.Parse(row["CStandardPriceIn"].ToString());
                }
                if (row["CTagPrice"] != null && row["CTagPrice"].ToString() != "")
                {
                    model.CTagPrice = decimal.Parse(row["CTagPrice"].ToString());
                }
                if (row["CReferencePriceA"] != null && row["CReferencePriceA"].ToString() != "")
                {
                    model.CReferencePriceA = decimal.Parse(row["CReferencePriceA"].ToString());
                }
                if (row["CReferencePriceB"] != null && row["CReferencePriceB"].ToString() != "")
                {
                    model.CReferencePriceB = decimal.Parse(row["CReferencePriceB"].ToString());
                }
                if (row["CReferencePriceC"] != null && row["CReferencePriceC"].ToString() != "")
                {
                    model.CReferencePriceC = decimal.Parse(row["CReferencePriceC"].ToString());
                }
                if (row["CReferencePriceD"] != null && row["CReferencePriceD"].ToString() != "")
                {
                    model.CReferencePriceD = decimal.Parse(row["CReferencePriceD"].ToString());
                }
                if (row["CReferencePriceE"] != null && row["CReferencePriceE"].ToString() != "")
                {
                    model.CReferencePriceE = decimal.Parse(row["CReferencePriceE"].ToString());
                }
                if (row["CReferencePriceF"] != null && row["CReferencePriceF"].ToString() != "")
                {
                    model.CReferencePriceF = decimal.Parse(row["CReferencePriceF"].ToString());
                }
                if (row["member"] != null)
                {
                    model.member = row["member"].ToString();
                }
                if (row["PCode"] != null)
                {
                    model.PCode = row["PCode"].ToString();
                }
                if (row["PName"] != null)
                {
                    model.PName = row["PName"].ToString();
                }
                if (row["SeriesID"] != null && row["SeriesID"].ToString() != "")
                {
                    model.SeriesID = long.Parse(row["SeriesID"].ToString());
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = long.Parse(row["TypeID"].ToString());
                }
                if (row["Manufacturer"] != null)
                {
                    model.Manufacturer = row["Manufacturer"].ToString();
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
            strSql.Append("select ID,pid,ColorCode,ColorName,CBarginPriceOut,CStandardPriceIn,CTagPrice,CReferencePriceA,CReferencePriceB,CReferencePriceC,CReferencePriceD,CReferencePriceE,CReferencePriceF,member,PCode,PName,SeriesID,TypeID,Manufacturer ");
            strSql.Append(" FROM v_ProductColor ");
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
            strSql.Append(" ID,pid,ColorCode,ColorName,CBarginPriceOut,CStandardPriceIn,CTagPrice,CReferencePriceA,CReferencePriceB,CReferencePriceC,CReferencePriceD,CReferencePriceE,CReferencePriceF,member,PCode,PName,SeriesID,TypeID,Manufacturer ");
            strSql.Append(" FROM v_ProductColor ");
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
            strSql.Append("select count(1) FROM v_ProductColor ");
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
                strSql.Append("order by T.Manufacturer desc");
            }
            strSql.Append(")AS Row, T.*  from v_ProductColor T ");
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
            parameters[0].Value = "v_ProductColor";
            parameters[1].Value = "Manufacturer";
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
