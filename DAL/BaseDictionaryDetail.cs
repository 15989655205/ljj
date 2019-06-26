using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:BaseDictionaryDetail
	/// </summary>
	public partial class BaseDictionaryDetail
	{
		public BaseDictionaryDetail()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CatgID", "BaseDictionaryDetail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CatgID,string Value)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BaseDictionaryDetail");
			strSql.Append(" where CatgID=@CatgID and Value=@Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@CatgID", SqlDbType.Int,4),
					new SqlParameter("@Value", SqlDbType.NVarChar,50)			};
			parameters[0].Value = CatgID;
			parameters[1].Value = Value;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.BaseDictionaryDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BaseDictionaryDetail(");
			strSql.Append("Idx,CatgID,ParentCatgID,Caption,Value,Value1,Value2,Value3)");
			strSql.Append(" values (");
			strSql.Append("@Idx,@CatgID,@ParentCatgID,@Caption,@Value,@Value1,@Value2,@Value3)");
			SqlParameter[] parameters = {
					new SqlParameter("@Idx", SqlDbType.Int,4),
					new SqlParameter("@CatgID", SqlDbType.Int,4),
					new SqlParameter("@ParentCatgID", SqlDbType.Int,4),
					new SqlParameter("@Caption", SqlDbType.NVarChar,50),
					new SqlParameter("@Value", SqlDbType.NVarChar,50),
					new SqlParameter("@Value1", SqlDbType.NVarChar,50),
					new SqlParameter("@Value2", SqlDbType.NVarChar,50),
					new SqlParameter("@Value3", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Idx;
			parameters[1].Value = model.CatgID;
			parameters[2].Value = model.ParentCatgID;
			parameters[3].Value = model.Caption;
			parameters[4].Value = model.Value;
			parameters[5].Value = model.Value1;
			parameters[6].Value = model.Value2;
			parameters[7].Value = model.Value3;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.BaseDictionaryDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BaseDictionaryDetail set ");
			strSql.Append("Idx=@Idx,");
			strSql.Append("ParentCatgID=@ParentCatgID,");
			strSql.Append("Caption=@Caption,");
			strSql.Append("Value1=@Value1,");
			strSql.Append("Value2=@Value2,");
			strSql.Append("Value3=@Value3");
			strSql.Append(" where CatgID=@CatgID and Value=@Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@Idx", SqlDbType.Int,4),
					new SqlParameter("@ParentCatgID", SqlDbType.Int,4),
					new SqlParameter("@Caption", SqlDbType.NVarChar,50),
					new SqlParameter("@Value1", SqlDbType.NVarChar,50),
					new SqlParameter("@Value2", SqlDbType.NVarChar,50),
					new SqlParameter("@Value3", SqlDbType.NVarChar,50),
					new SqlParameter("@CatgID", SqlDbType.Int,4),
					new SqlParameter("@Value", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Idx;
			parameters[1].Value = model.ParentCatgID;
			parameters[2].Value = model.Caption;
			parameters[3].Value = model.Value1;
			parameters[4].Value = model.Value2;
			parameters[5].Value = model.Value3;
			parameters[6].Value = model.CatgID;
			parameters[7].Value = model.Value;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int CatgID,string Value)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseDictionaryDetail ");
			strSql.Append(" where CatgID=@CatgID and Value=@Value ");
			SqlParameter[] parameters = {
					new SqlParameter("@CatgID", SqlDbType.Int,4),
					new SqlParameter("@Value", SqlDbType.NVarChar,50)			};
			parameters[0].Value = CatgID;
			parameters[1].Value = Value;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public Maticsoft.Model.BaseDictionaryDetail GetModel(int CatgID, string caption)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Idx,CatgID,ParentCatgID,Caption,Value,Value1,Value2,Value3 from BaseDictionaryDetail ");
            strSql.Append(" where CatgID=@CatgID and Caption=@caption ");
			SqlParameter[] parameters = {
					new SqlParameter("@CatgID", SqlDbType.Int,4),
					new SqlParameter("@caption", SqlDbType.NVarChar,50)			};
			parameters[0].Value = CatgID;
            parameters[1].Value = caption;

			Maticsoft.Model.BaseDictionaryDetail model=new Maticsoft.Model.BaseDictionaryDetail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Maticsoft.Model.BaseDictionaryDetail DataRowToModel(DataRow row)
		{
			Maticsoft.Model.BaseDictionaryDetail model=new Maticsoft.Model.BaseDictionaryDetail();
			if (row != null)
			{
				if(row["Idx"]!=null && row["Idx"].ToString()!="")
				{
					model.Idx=int.Parse(row["Idx"].ToString());
				}
				if(row["CatgID"]!=null && row["CatgID"].ToString()!="")
				{
					model.CatgID=int.Parse(row["CatgID"].ToString());
				}
				if(row["ParentCatgID"]!=null && row["ParentCatgID"].ToString()!="")
				{
					model.ParentCatgID=int.Parse(row["ParentCatgID"].ToString());
				}
				if(row["Caption"]!=null)
				{
					model.Caption=row["Caption"].ToString();
				}
				if(row["Value"]!=null)
				{
					model.Value=row["Value"].ToString();
				}
				if(row["Value1"]!=null)
				{
					model.Value1=row["Value1"].ToString();
				}
				if(row["Value2"]!=null)
				{
					model.Value2=row["Value2"].ToString();
				}
				if(row["Value3"]!=null)
				{
					model.Value3=row["Value3"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  Caption,Value from BaseDictionaryDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Idx,CatgID,ParentCatgID,Caption,Value,Value1,Value2,Value3 ");
			strSql.Append(" FROM BaseDictionaryDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得某状态数据列表
        /// </summary>
        public DataSet GetList(int CatgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Caption text,Value value");
            strSql.Append(" FROM BaseDictionaryDetail ");
            strSql.Append(" where CatgID=" + CatgID);
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BaseDictionaryDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Value desc");
			}
			strSql.Append(")AS Row, T.*  from BaseDictionaryDetail T ");
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
			parameters[0].Value = "BaseDictionaryDetail";
			parameters[1].Value = "Value";
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

