using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:BaseMenu
	/// </summary>
	public partial class BaseMenu
	{
		public BaseMenu()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MenuID", "BaseMenu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MenuID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BaseMenu");
			strSql.Append(" where MenuID=@MenuID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4)			};
			parameters[0].Value = MenuID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.BaseMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BaseMenu(");
			strSql.Append("MenuID,ParentMenuID,PageID,MenuName,LinkUrl,Target,Value1,Value2,Value3,IDX,IsMenu)");
			strSql.Append(" values (");
			strSql.Append("@MenuID,@ParentMenuID,@PageID,@MenuName,@LinkUrl,@Target,@Value1,@Value2,@Value3,@IDX,@IsMenu)");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4),
					new SqlParameter("@ParentMenuID", SqlDbType.Int,4),
					new SqlParameter("@PageID", SqlDbType.Int,4),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@Target", SqlDbType.NVarChar,50),
					new SqlParameter("@Value1", SqlDbType.NVarChar,200),
					new SqlParameter("@Value2", SqlDbType.NVarChar,50),
					new SqlParameter("@Value3", SqlDbType.NVarChar,200),
					new SqlParameter("@IDX", SqlDbType.Int,4),
					new SqlParameter("@IsMenu", SqlDbType.Bit,1)};
			parameters[0].Value = model.MenuID;
			parameters[1].Value = model.ParentMenuID;
			parameters[2].Value = model.PageID;
			parameters[3].Value = model.MenuName;
			parameters[4].Value = model.LinkUrl;
			parameters[5].Value = model.Target;
			parameters[6].Value = model.Value1;
			parameters[7].Value = model.Value2;
			parameters[8].Value = model.Value3;
			parameters[9].Value = model.IDX;
			parameters[10].Value = model.IsMenu;

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
		public bool Update(Maticsoft.Model.BaseMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BaseMenu set ");
			strSql.Append("ParentMenuID=@ParentMenuID,");
			strSql.Append("PageID=@PageID,");
			strSql.Append("MenuName=@MenuName,");
			strSql.Append("LinkUrl=@LinkUrl,");
			strSql.Append("Target=@Target,");
			strSql.Append("Value1=@Value1,");
			strSql.Append("Value2=@Value2,");
			strSql.Append("Value3=@Value3,");
			strSql.Append("IDX=@IDX,");
			strSql.Append("IsMenu=@IsMenu");
			strSql.Append(" where MenuID=@MenuID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentMenuID", SqlDbType.Int,4),
					new SqlParameter("@PageID", SqlDbType.Int,4),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@Target", SqlDbType.NVarChar,50),
					new SqlParameter("@Value1", SqlDbType.NVarChar,200),
					new SqlParameter("@Value2", SqlDbType.NVarChar,50),
					new SqlParameter("@Value3", SqlDbType.NVarChar,200),
					new SqlParameter("@IDX", SqlDbType.Int,4),
					new SqlParameter("@IsMenu", SqlDbType.Bit,1),
					new SqlParameter("@MenuID", SqlDbType.Int,4)};
			parameters[0].Value = model.ParentMenuID;
			parameters[1].Value = model.PageID;
			parameters[2].Value = model.MenuName;
			parameters[3].Value = model.LinkUrl;
			parameters[4].Value = model.Target;
			parameters[5].Value = model.Value1;
			parameters[6].Value = model.Value2;
			parameters[7].Value = model.Value3;
			parameters[8].Value = model.IDX;
			parameters[9].Value = model.IsMenu;
			parameters[10].Value = model.MenuID;

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
		public bool Delete(int MenuID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseMenu ");
			strSql.Append(" where MenuID=@MenuID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4)			};
			parameters[0].Value = MenuID;

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
		public bool DeleteList(string MenuIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseMenu ");
			strSql.Append(" where MenuID in ("+MenuIDlist + ")  ");
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
		public Maticsoft.Model.BaseMenu GetModel(int MenuID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MenuID,ParentMenuID,PageID,MenuName,LinkUrl,Target,Value1,Value2,Value3,IDX,IsMenu from BaseMenu ");
			strSql.Append(" where MenuID=@MenuID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuID", SqlDbType.Int,4)			};
			parameters[0].Value = MenuID;

			Maticsoft.Model.BaseMenu model=new Maticsoft.Model.BaseMenu();
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
		public Maticsoft.Model.BaseMenu DataRowToModel(DataRow row)
		{
			Maticsoft.Model.BaseMenu model=new Maticsoft.Model.BaseMenu();
			if (row != null)
			{
				if(row["MenuID"]!=null && row["MenuID"].ToString()!="")
				{
					model.MenuID=int.Parse(row["MenuID"].ToString());
				}
				if(row["ParentMenuID"]!=null && row["ParentMenuID"].ToString()!="")
				{
					model.ParentMenuID=int.Parse(row["ParentMenuID"].ToString());
				}
				if(row["PageID"]!=null && row["PageID"].ToString()!="")
				{
					model.PageID=int.Parse(row["PageID"].ToString());
				}
				if(row["MenuName"]!=null)
				{
					model.MenuName=row["MenuName"].ToString();
				}
				if(row["LinkUrl"]!=null)
				{
					model.LinkUrl=row["LinkUrl"].ToString();
				}
				if(row["Target"]!=null)
				{
					model.Target=row["Target"].ToString();
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
				if(row["IDX"]!=null && row["IDX"].ToString()!="")
				{
					model.IDX=int.Parse(row["IDX"].ToString());
				}
				if(row["IsMenu"]!=null && row["IsMenu"].ToString()!="")
				{
					if((row["IsMenu"].ToString()=="1")||(row["IsMenu"].ToString().ToLower()=="true"))
					{
						model.IsMenu=true;
					}
					else
					{
						model.IsMenu=false;
					}
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
			strSql.Append("select MenuID,ParentMenuID,PageID,MenuName,LinkUrl,Target,Value1,Value2,Value3,IDX,IsMenu ");
			strSql.Append(" FROM BaseMenu ");
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
			strSql.Append(" MenuID,ParentMenuID,PageID,MenuName,LinkUrl,Target,Value1,Value2,Value3,IDX,IsMenu ");
			strSql.Append(" FROM BaseMenu ");
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
			strSql.Append("select count(1) FROM BaseMenu ");
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
			strSql.Append(")AS Row, T.*  from BaseMenu T ");
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
			parameters[0].Value = "BaseMenu";
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

