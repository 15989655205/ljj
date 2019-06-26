using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:File_Dowm_Detail
	/// </summary>
	public partial class File_Dowm_Detail
	{
		public File_Dowm_Detail()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "File_Dowm_Detail"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from File_Dowm_Detail");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.File_Dowm_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into File_Dowm_Detail(");
			strSql.Append("file_id,dowm_person,dowm_date,value1,value2,value3)");
			strSql.Append(" values (");
			strSql.Append("@file_id,@dowm_person,@dowm_date,@value1,@value2,@value3)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@file_id", SqlDbType.Int,4),
					new SqlParameter("@dowm_person", SqlDbType.Int,4),
					new SqlParameter("@dowm_date", SqlDbType.DateTime),
					new SqlParameter("@value1", SqlDbType.NVarChar,255),
					new SqlParameter("@value2", SqlDbType.NVarChar,255),
					new SqlParameter("@value3", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.file_id;
			parameters[1].Value = model.dowm_person;
			parameters[2].Value = model.dowm_date;
			parameters[3].Value = model.value1;
			parameters[4].Value = model.value2;
			parameters[5].Value = model.value3;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Maticsoft.Model.File_Dowm_Detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update File_Dowm_Detail set ");
			strSql.Append("file_id=@file_id,");
			strSql.Append("dowm_person=@dowm_person,");
			strSql.Append("dowm_date=@dowm_date,");
			strSql.Append("value1=@value1,");
			strSql.Append("value2=@value2,");
			strSql.Append("value3=@value3");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@file_id", SqlDbType.Int,4),
					new SqlParameter("@dowm_person", SqlDbType.Int,4),
					new SqlParameter("@dowm_date", SqlDbType.DateTime),
					new SqlParameter("@value1", SqlDbType.NVarChar,255),
					new SqlParameter("@value2", SqlDbType.NVarChar,255),
					new SqlParameter("@value3", SqlDbType.NVarChar,255),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.file_id;
			parameters[1].Value = model.dowm_person;
			parameters[2].Value = model.dowm_date;
			parameters[3].Value = model.value1;
			parameters[4].Value = model.value2;
			parameters[5].Value = model.value3;
			parameters[6].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from File_Dowm_Detail ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from File_Dowm_Detail ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Maticsoft.Model.File_Dowm_Detail GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,file_id,dowm_person,dowm_date,value1,value2,value3 from File_Dowm_Detail ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.File_Dowm_Detail model=new Maticsoft.Model.File_Dowm_Detail();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["file_id"]!=null && ds.Tables[0].Rows[0]["file_id"].ToString()!="")
				{
					model.file_id=int.Parse(ds.Tables[0].Rows[0]["file_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dowm_person"]!=null && ds.Tables[0].Rows[0]["dowm_person"].ToString()!="")
				{
					model.dowm_person=int.Parse(ds.Tables[0].Rows[0]["dowm_person"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dowm_date"]!=null && ds.Tables[0].Rows[0]["dowm_date"].ToString()!="")
				{
					model.dowm_date=DateTime.Parse(ds.Tables[0].Rows[0]["dowm_date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["value1"]!=null && ds.Tables[0].Rows[0]["value1"].ToString()!="")
				{
					model.value1=ds.Tables[0].Rows[0]["value1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["value2"]!=null && ds.Tables[0].Rows[0]["value2"].ToString()!="")
				{
					model.value2=ds.Tables[0].Rows[0]["value2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["value3"]!=null && ds.Tables[0].Rows[0]["value3"].ToString()!="")
				{
					model.value3=ds.Tables[0].Rows[0]["value3"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,file_id,dowm_person,dowm_date,value1,value2,value3 ");
			strSql.Append(" FROM File_Dowm_Detail ");
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
			strSql.Append(" ID,file_id,dowm_person,dowm_date,value1,value2,value3 ");
			strSql.Append(" FROM File_Dowm_Detail ");
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
			strSql.Append("select count(1) FROM File_Dowm_Detail ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from File_Dowm_Detail T ");
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
			parameters[0].Value = "File_Dowm_Detail";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

