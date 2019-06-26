using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:notice
	/// </summary>
	public partial class notice
	{
		public notice()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "notice"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from notice");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into notice(");
			strSql.Append("title,summary,intro,notice_content,CreateUserID,CreateTime,UpdateUserID,UpdateTime,url,show,status,v1,v2,v3,v4)");
			strSql.Append(" values (");
			strSql.Append("@title,@summary,@intro,@notice_content,@CreateUserID,@CreateTime,@UpdateUserID,@UpdateTime,@url,@show,@status,@v1,@v2,@v3,@v4)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar),
					new SqlParameter("@summary", SqlDbType.NVarChar),
					new SqlParameter("@intro", SqlDbType.NVarChar),
					new SqlParameter("@notice_content", SqlDbType.NVarChar),
					new SqlParameter("@CreateUserID", SqlDbType.BigInt,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@url", SqlDbType.NVarChar,400),
					new SqlParameter("@show", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@v1", SqlDbType.NVarChar,500),
					new SqlParameter("@v2", SqlDbType.NVarChar,500),
					new SqlParameter("@v3", SqlDbType.NVarChar,500),
					new SqlParameter("@v4", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.summary;
			parameters[2].Value = model.intro;
			parameters[3].Value = model.notice_content;
			parameters[4].Value = model.CreateUserID;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.UpdateUserID;
			parameters[7].Value = model.UpdateTime;
			parameters[8].Value = model.url;
			parameters[9].Value = model.show;
			parameters[10].Value = model.status;
			parameters[11].Value = model.v1;
			parameters[12].Value = model.v2;
			parameters[13].Value = model.v3;
			parameters[14].Value = model.v4;

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
		public bool Update(Maticsoft.Model.notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update notice set ");
			strSql.Append("title=@title,");
			strSql.Append("summary=@summary,");
			strSql.Append("intro=@intro,");
			strSql.Append("notice_content=@notice_content,");
            strSql.Append("UpdateUserID=@UpdateUserID,");
            strSql.Append("UpdateTime=@UpdateTime,");			
			strSql.Append("url=@url,");
			strSql.Append("show=@show,");
			strSql.Append("status=@status,");
			strSql.Append("v1=@v1,");
			strSql.Append("v2=@v2,");
			strSql.Append("v3=@v3,");
			strSql.Append("v4=@v4");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar),
					new SqlParameter("@summary", SqlDbType.NVarChar),
					new SqlParameter("@intro", SqlDbType.NVarChar),
					new SqlParameter("@notice_content", SqlDbType.NVarChar),
					new SqlParameter("@UpdateUserID", SqlDbType.BigInt,8),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),				
					new SqlParameter("@url", SqlDbType.NVarChar,400),
					new SqlParameter("@show", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@v1", SqlDbType.NVarChar,500),
					new SqlParameter("@v2", SqlDbType.NVarChar,500),
					new SqlParameter("@v3", SqlDbType.NVarChar,500),
					new SqlParameter("@v4", SqlDbType.NVarChar,500),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.summary;
			parameters[2].Value = model.intro;
			parameters[3].Value = model.notice_content;
            parameters[4].Value = model.UpdateUserID;
            parameters[5].Value = model.UpdateTime;		
			parameters[6].Value = model.url;
			parameters[7].Value = model.show;
			parameters[8].Value = model.status;
			parameters[9].Value = model.v1;
			parameters[10].Value = model.v2;
			parameters[11].Value = model.v3;
			parameters[12].Value = model.v4;
			parameters[13].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from notice ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from notice ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public Maticsoft.Model.notice GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,summary,intro,notice_content,CreateUserID,CreateTime,UpdateUserID,UpdateTime,url,show,status,v1,v2,v3,v4 from notice ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Maticsoft.Model.notice model=new Maticsoft.Model.notice();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["title"]!=null && ds.Tables[0].Rows[0]["title"].ToString()!="")
				{
					model.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["summary"]!=null && ds.Tables[0].Rows[0]["summary"].ToString()!="")
				{
					model.summary=ds.Tables[0].Rows[0]["summary"].ToString();
				}
				if(ds.Tables[0].Rows[0]["intro"]!=null && ds.Tables[0].Rows[0]["intro"].ToString()!="")
				{
					model.intro=ds.Tables[0].Rows[0]["intro"].ToString();
				}
				if(ds.Tables[0].Rows[0]["notice_content"]!=null && ds.Tables[0].Rows[0]["notice_content"].ToString()!="")
				{
					model.notice_content=ds.Tables[0].Rows[0]["notice_content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreateUserID"]!=null && ds.Tables[0].Rows[0]["CreateUserID"].ToString()!="")
				{
					model.CreateUserID=long.Parse(ds.Tables[0].Rows[0]["CreateUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateTime"]!=null && ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdateUserID"]!=null && ds.Tables[0].Rows[0]["UpdateUserID"].ToString()!="")
				{
					model.UpdateUserID=long.Parse(ds.Tables[0].Rows[0]["UpdateUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdateTime"]!=null && ds.Tables[0].Rows[0]["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["url"]!=null && ds.Tables[0].Rows[0]["url"].ToString()!="")
				{
					model.url=ds.Tables[0].Rows[0]["url"].ToString();
				}
				if(ds.Tables[0].Rows[0]["show"]!=null && ds.Tables[0].Rows[0]["show"].ToString()!="")
				{
					model.show=int.Parse(ds.Tables[0].Rows[0]["show"].ToString());
				}
				if(ds.Tables[0].Rows[0]["status"]!=null && ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["v1"]!=null && ds.Tables[0].Rows[0]["v1"].ToString()!="")
				{
					model.v1=ds.Tables[0].Rows[0]["v1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["v2"]!=null && ds.Tables[0].Rows[0]["v2"].ToString()!="")
				{
					model.v2=ds.Tables[0].Rows[0]["v2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["v3"]!=null && ds.Tables[0].Rows[0]["v3"].ToString()!="")
				{
					model.v3=ds.Tables[0].Rows[0]["v3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["v4"]!=null && ds.Tables[0].Rows[0]["v4"].ToString()!="")
				{
					model.v4=ds.Tables[0].Rows[0]["v4"].ToString();
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
			strSql.Append("select id,title,summary,intro,notice_content,CreateUserID,CreateTime,UpdateUserID,UpdateTime,url,show,status,v1,v2,v3,v4,"+
            "dbo.getUserName(CreateUserID)create_name, convert(nvarchar,CreateTime,120)create_date, dbo.getUserName(UpdateUserID)update_name, convert(nvarchar,UpdateTime,120)update_date");
			strSql.Append(" FROM notice ");
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
			strSql.Append(" id,title,summary,intro,notice_content,CreateUserID,CreateTime,UpdateUserID,UpdateTime,url,show,status,v1,v2,v3,v4 ");
			strSql.Append(" FROM notice ");
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
			strSql.Append("select count(1) FROM notice ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from notice T ");
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
			parameters[0].Value = "notice";
			parameters[1].Value = "id";
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

