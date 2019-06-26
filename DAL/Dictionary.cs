using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Dictionary
	/// </summary>
	public partial class Dictionary
	{
		public Dictionary()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CatgID", "Dictionary"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CatgID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Dictionary");
			strSql.Append(" where CatgID=@CatgID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CatgID", SqlDbType.Int,4)			};
			parameters[0].Value = CatgID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Dictionary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Dictionary(");
			strSql.Append("Idx,CatgID,Caption,Note)");
			strSql.Append(" values (");
			strSql.Append("@Idx,@CatgID,@Caption,@Note)");
			SqlParameter[] parameters = {
					new SqlParameter("@Idx", SqlDbType.Int,4),
					new SqlParameter("@CatgID", SqlDbType.Int,4),
					new SqlParameter("@Caption", SqlDbType.NVarChar,50),
					new SqlParameter("@Note", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Idx;
			parameters[1].Value = model.CatgID;
			parameters[2].Value = model.Caption;
			parameters[3].Value = model.Note;

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
		public bool Update(Maticsoft.Model.Dictionary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Dictionary set ");
			strSql.Append("Idx=@Idx,");
			strSql.Append("Caption=@Caption,");
			strSql.Append("Note=@Note");
			strSql.Append(" where CatgID=@CatgID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Idx", SqlDbType.Int,4),
					new SqlParameter("@Caption", SqlDbType.NVarChar,50),
					new SqlParameter("@Note", SqlDbType.NVarChar,50),
					new SqlParameter("@CatgID", SqlDbType.Int,4)};
			parameters[0].Value = model.Idx;
			parameters[1].Value = model.Caption;
			parameters[2].Value = model.Note;
			parameters[3].Value = model.CatgID;

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
		public bool Delete(int CatgID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Dictionary ");
			strSql.Append(" where CatgID=@CatgID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CatgID", SqlDbType.Int,4)			};
			parameters[0].Value = CatgID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string CatgIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Dictionary ");
			strSql.Append(" where CatgID in ("+CatgIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.Dictionary GetModel(int CatgID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Idx,CatgID,Caption,Note from Dictionary ");
			strSql.Append(" where CatgID=@CatgID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CatgID", SqlDbType.Int,4)			};
			parameters[0].Value = CatgID;

			Maticsoft.Model.Dictionary model=new Maticsoft.Model.Dictionary();
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
		public Maticsoft.Model.Dictionary DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Dictionary model=new Maticsoft.Model.Dictionary();
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
				if(row["Caption"]!=null)
				{
					model.Caption=row["Caption"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
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
			strSql.Append("select Idx,CatgID,Caption,Note ");
			strSql.Append(" FROM Dictionary ");
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
			strSql.Append(" Idx,CatgID,Caption,Note ");
			strSql.Append(" FROM Dictionary ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Dictionary ");
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
				strSql.Append("order by T.CatgID desc");
			}
			strSql.Append(")AS Row, T.*  from Dictionary T ");
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
			parameters[0].Value = "Dictionary";
			parameters[1].Value = "CatgID";
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

