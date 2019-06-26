using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:BasePage
	/// </summary>
	public partial class BasePage
	{
		public BasePage()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.BasePage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BasePage(");
			strSql.Append("PageID,PageName,Note,Cmds,ParentPageID)");
			strSql.Append(" values (");
			strSql.Append("@PageID,@PageName,@Note,@Cmds,@ParentPageID)");
			SqlParameter[] parameters = {
					new SqlParameter("@PageID", SqlDbType.Int,4),
					new SqlParameter("@PageName", SqlDbType.NVarChar,80),
					new SqlParameter("@Note", SqlDbType.NVarChar,200),
					new SqlParameter("@Cmds", SqlDbType.NVarChar,100),
					new SqlParameter("@ParentPageID", SqlDbType.Int,4)};
			parameters[0].Value = model.PageID;
			parameters[1].Value = model.PageName;
			parameters[2].Value = model.Note;
			parameters[3].Value = model.Cmds;
			parameters[4].Value = model.ParentPageID;

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
		public bool Update(Maticsoft.Model.BasePage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BasePage set ");
			strSql.Append("PageID=@PageID,");
			strSql.Append("PageName=@PageName,");
			strSql.Append("Note=@Note,");
			strSql.Append("Cmds=@Cmds,");
			strSql.Append("ParentPageID=@ParentPageID");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@PageID", SqlDbType.Int,4),
					new SqlParameter("@PageName", SqlDbType.NVarChar,80),
					new SqlParameter("@Note", SqlDbType.NVarChar,200),
					new SqlParameter("@Cmds", SqlDbType.NVarChar,100),
					new SqlParameter("@ParentPageID", SqlDbType.Int,4)};
			parameters[0].Value = model.PageID;
			parameters[1].Value = model.PageName;
			parameters[2].Value = model.Note;
			parameters[3].Value = model.Cmds;
			parameters[4].Value = model.ParentPageID;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BasePage ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		public Maticsoft.Model.BasePage GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PageID,PageName,Note,Cmds,ParentPageID from BasePage ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.BasePage model=new Maticsoft.Model.BasePage();
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
		public Maticsoft.Model.BasePage DataRowToModel(DataRow row)
		{
			Maticsoft.Model.BasePage model=new Maticsoft.Model.BasePage();
			if (row != null)
			{
				if(row["PageID"]!=null && row["PageID"].ToString()!="")
				{
					model.PageID=int.Parse(row["PageID"].ToString());
				}
				if(row["PageName"]!=null)
				{
					model.PageName=row["PageName"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["Cmds"]!=null)
				{
					model.Cmds=row["Cmds"].ToString();
				}
				if(row["ParentPageID"]!=null && row["ParentPageID"].ToString()!="")
				{
					model.ParentPageID=int.Parse(row["ParentPageID"].ToString());
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
			strSql.Append("select PageID,PageName,Note,Cmds,ParentPageID ");
			strSql.Append(" FROM BasePage ");
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
			strSql.Append(" PageID,PageName,Note,Cmds,ParentPageID ");
			strSql.Append(" FROM BasePage ");
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
			strSql.Append("select count(1) FROM BasePage ");
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
				strSql.Append("order by T.MenuID desc");
			}
			strSql.Append(")AS Row, T.*  from BasePage T ");
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
			parameters[0].Value = "BasePage";
			parameters[1].Value = "MenuID";
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

