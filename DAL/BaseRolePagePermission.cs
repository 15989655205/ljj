using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:BaseRolePagePermission
	/// </summary>
	public partial class BaseRolePagePermission
	{
		public BaseRolePagePermission()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RoleID", "BaseRolePagePermission"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RoleID,int MenuID,int PageID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BaseRolePagePermission");
			strSql.Append(" where RoleID=@RoleID and MenuID=@MenuID and PageID=@PageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@MenuID", SqlDbType.Int,4),
					new SqlParameter("@PageID", SqlDbType.Int,4)			};
			parameters[0].Value = RoleID;
			parameters[1].Value = MenuID;
			parameters[2].Value = PageID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.BaseRolePagePermission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BaseRolePagePermission(");
			strSql.Append("RoleID,MenuID,PageID,Cmds)");
			strSql.Append(" values (");
			strSql.Append("@RoleID,@MenuID,@PageID,@Cmds)");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@MenuID", SqlDbType.Int,4),
					new SqlParameter("@PageID", SqlDbType.Int,4),
					new SqlParameter("@Cmds", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.RoleID;
			parameters[1].Value = model.MenuID;
			parameters[2].Value = model.PageID;
			parameters[3].Value = model.Cmds;

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
		public bool Update(Maticsoft.Model.BaseRolePagePermission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BaseRolePagePermission set ");
			strSql.Append("Cmds=@Cmds");
			strSql.Append(" where RoleID=@RoleID and MenuID=@MenuID and PageID=@PageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Cmds", SqlDbType.NVarChar,100),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@MenuID", SqlDbType.Int,4),
					new SqlParameter("@PageID", SqlDbType.Int,4)};
			parameters[0].Value = model.Cmds;
			parameters[1].Value = model.RoleID;
			parameters[2].Value = model.MenuID;
			parameters[3].Value = model.PageID;

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
		public bool Delete(int RoleID,int MenuID,int PageID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseRolePagePermission ");
			strSql.Append(" where RoleID=@RoleID and MenuID=@MenuID and PageID=@PageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@MenuID", SqlDbType.Int,4),
					new SqlParameter("@PageID", SqlDbType.Int,4)			};
			parameters[0].Value = RoleID;
			parameters[1].Value = MenuID;
			parameters[2].Value = PageID;

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
		public Maticsoft.Model.BaseRolePagePermission GetModel(int RoleID,int MenuID,int PageID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoleID,MenuID,PageID,Cmds from BaseRolePagePermission ");
			strSql.Append(" where RoleID=@RoleID and MenuID=@MenuID and PageID=@PageID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@MenuID", SqlDbType.Int,4),
					new SqlParameter("@PageID", SqlDbType.Int,4)			};
			parameters[0].Value = RoleID;
			parameters[1].Value = MenuID;
			parameters[2].Value = PageID;

			Maticsoft.Model.BaseRolePagePermission model=new Maticsoft.Model.BaseRolePagePermission();
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
		public Maticsoft.Model.BaseRolePagePermission DataRowToModel(DataRow row)
		{
			Maticsoft.Model.BaseRolePagePermission model=new Maticsoft.Model.BaseRolePagePermission();
			if (row != null)
			{
				if(row["RoleID"]!=null && row["RoleID"].ToString()!="")
				{
					model.RoleID=int.Parse(row["RoleID"].ToString());
				}
				if(row["MenuID"]!=null && row["MenuID"].ToString()!="")
				{
					model.MenuID=int.Parse(row["MenuID"].ToString());
				}
				if(row["PageID"]!=null && row["PageID"].ToString()!="")
				{
					model.PageID=int.Parse(row["PageID"].ToString());
				}
				if(row["Cmds"]!=null)
				{
					model.Cmds=row["Cmds"].ToString();
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
			strSql.Append("select RoleID,MenuID,PageID,Cmds ");
			strSql.Append(" FROM BaseRolePagePermission ");
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
			strSql.Append(" RoleID,MenuID,PageID,Cmds ");
			strSql.Append(" FROM BaseRolePagePermission ");
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
			strSql.Append("select count(1) FROM BaseRolePagePermission ");
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
				strSql.Append("order by T.PageID desc");
			}
			strSql.Append(")AS Row, T.*  from BaseRolePagePermission T ");
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
			parameters[0].Value = "BaseRolePagePermission";
			parameters[1].Value = "PageID";
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
        public bool exists(string  RoleID, int MenuID, int PageID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BaseRolePagePermission");
            strSql.Append(" where RoleID in (select * from dbo.getTable(@RoleID,',')) and MenuID=@MenuID and PageID=@PageID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.NVarChar,100),
					new SqlParameter("@MenuID", SqlDbType.Int,4),
					new SqlParameter("@PageID", SqlDbType.Int,4)			};
            parameters[0].Value = RoleID;
            parameters[1].Value = MenuID;
            parameters[2].Value = PageID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		#endregion  ExtensionMethod
	}
}

