using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:approve_role
	/// </summary>
	public partial class approve_role
	{
		public approve_role()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sid", "approve_role"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from approve_role");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public bool Exists(string rn)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from approve_role");
            strSql.Append(" where role_name=@role_name");
            SqlParameter[] parameters = 
            {
			    new SqlParameter("@role_name", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = rn;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.approve_role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into approve_role(");
			strSql.Append("role_name,role_level,role_post,role_status,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date)");
			strSql.Append(" values (");
			strSql.Append("@role_name,@role_level,@role_post,@role_status,@remark,@value1,@value2,@value3,@value4,@value5,@value6,@status,@create_person,@create_date,@update_person,@update_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@role_name", SqlDbType.NVarChar,10),
					new SqlParameter("@role_level", SqlDbType.Int,4),
					new SqlParameter("@role_post", SqlDbType.NVarChar,500),
					new SqlParameter("@role_status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar),
					new SqlParameter("@value1", SqlDbType.NVarChar,255),
					new SqlParameter("@value2", SqlDbType.NVarChar,255),
					new SqlParameter("@value3", SqlDbType.NVarChar,255),
					new SqlParameter("@value4", SqlDbType.NVarChar,255),
					new SqlParameter("@value5", SqlDbType.NVarChar,255),
					new SqlParameter("@value6", SqlDbType.NVarChar,255),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime)};
			parameters[0].Value = model.role_name;
			parameters[1].Value = model.role_level;
			parameters[2].Value = model.role_post;
			parameters[3].Value = model.role_status;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.value1;
			parameters[6].Value = model.value2;
			parameters[7].Value = model.value3;
			parameters[8].Value = model.value4;
			parameters[9].Value = model.value5;
			parameters[10].Value = model.value6;
			parameters[11].Value = model.status;
			parameters[12].Value = model.create_person;
			parameters[13].Value = model.create_date;
			parameters[14].Value = model.update_person;
			parameters[15].Value = model.update_date;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return false;
			}
			else
			{
                return true;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.approve_role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update approve_role set ");
			strSql.Append("role_name=@role_name,");
			strSql.Append("role_level=@role_level,");
			strSql.Append("role_post=@role_post,");
			strSql.Append("role_status=@role_status,");
			strSql.Append("remark=@remark,");
			strSql.Append("value1=@value1,");
			strSql.Append("value2=@value2,");
			strSql.Append("value3=@value3,");
			strSql.Append("value4=@value4,");
			strSql.Append("value5=@value5,");
			strSql.Append("value6=@value6,");
			strSql.Append("status=@status,");		
			strSql.Append("update_person=@update_person,");
			strSql.Append("update_date=@update_date");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@role_name", SqlDbType.NVarChar,10),
					new SqlParameter("@role_level", SqlDbType.Int,4),
					new SqlParameter("@role_post", SqlDbType.NVarChar,500),
					new SqlParameter("@role_status", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar),
					new SqlParameter("@value1", SqlDbType.NVarChar,255),
					new SqlParameter("@value2", SqlDbType.NVarChar,255),
					new SqlParameter("@value3", SqlDbType.NVarChar,255),
					new SqlParameter("@value4", SqlDbType.NVarChar,255),
					new SqlParameter("@value5", SqlDbType.NVarChar,255),
					new SqlParameter("@value6", SqlDbType.NVarChar,255),
					new SqlParameter("@status", SqlDbType.Int,4),					
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.Int,4)};
			parameters[0].Value = model.role_name;
			parameters[1].Value = model.role_level;
			parameters[2].Value = model.role_post;
			parameters[3].Value = model.role_status;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.value1;
			parameters[6].Value = model.value2;
			parameters[7].Value = model.value3;
			parameters[8].Value = model.value4;
			parameters[9].Value = model.value5;
			parameters[10].Value = model.value6;
			parameters[11].Value = model.status;		
			parameters[12].Value = model.update_person;
			parameters[13].Value = model.update_date;
			parameters[14].Value = model.sid;

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
		public bool Delete(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from approve_role ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

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
		public bool DeleteList(string sidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from approve_role ");
			strSql.Append(" where sid in ("+sidlist + ")  ");
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
		public Maticsoft.Model.approve_role GetModel(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sid,role_name,role_level,role_post,role_status,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date from approve_role ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			Maticsoft.Model.approve_role model=new Maticsoft.Model.approve_role();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["sid"]!=null && ds.Tables[0].Rows[0]["sid"].ToString()!="")
				{
					model.sid=int.Parse(ds.Tables[0].Rows[0]["sid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["role_name"]!=null && ds.Tables[0].Rows[0]["role_name"].ToString()!="")
				{
					model.role_name=ds.Tables[0].Rows[0]["role_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["role_level"]!=null && ds.Tables[0].Rows[0]["role_level"].ToString()!="")
				{
					model.role_level=int.Parse(ds.Tables[0].Rows[0]["role_level"].ToString());
				}
				if(ds.Tables[0].Rows[0]["role_post"]!=null && ds.Tables[0].Rows[0]["role_post"].ToString()!="")
				{
					model.role_post=ds.Tables[0].Rows[0]["role_post"].ToString();
				}
				if(ds.Tables[0].Rows[0]["role_status"]!=null && ds.Tables[0].Rows[0]["role_status"].ToString()!="")
				{
					model.role_status=int.Parse(ds.Tables[0].Rows[0]["role_status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["remark"]!=null && ds.Tables[0].Rows[0]["remark"].ToString()!="")
				{
					model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
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
				if(ds.Tables[0].Rows[0]["value4"]!=null && ds.Tables[0].Rows[0]["value4"].ToString()!="")
				{
					model.value4=ds.Tables[0].Rows[0]["value4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["value5"]!=null && ds.Tables[0].Rows[0]["value5"].ToString()!="")
				{
					model.value5=ds.Tables[0].Rows[0]["value5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["value6"]!=null && ds.Tables[0].Rows[0]["value6"].ToString()!="")
				{
					model.value6=ds.Tables[0].Rows[0]["value6"].ToString();
				}
				if(ds.Tables[0].Rows[0]["status"]!=null && ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["create_person"]!=null && ds.Tables[0].Rows[0]["create_person"].ToString()!="")
				{
					model.create_person=ds.Tables[0].Rows[0]["create_person"].ToString();
				}
				if(ds.Tables[0].Rows[0]["create_date"]!=null && ds.Tables[0].Rows[0]["create_date"].ToString()!="")
				{
					model.create_date=DateTime.Parse(ds.Tables[0].Rows[0]["create_date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["update_person"]!=null && ds.Tables[0].Rows[0]["update_person"].ToString()!="")
				{
					model.update_person=ds.Tables[0].Rows[0]["update_person"].ToString();
				}
				if(ds.Tables[0].Rows[0]["update_date"]!=null && ds.Tables[0].Rows[0]["update_date"].ToString()!="")
				{
					model.update_date=DateTime.Parse(ds.Tables[0].Rows[0]["update_date"].ToString());
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
			strSql.Append("select sid,role_name,role_level,role_post,role_status,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM approve_role ");
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
			strSql.Append(" sid,role_name,role_level,role_post,role_status,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM approve_role ");
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
			strSql.Append("select count(1) FROM approve_role ");
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
				strSql.Append("order by T.sid desc");
			}
			strSql.Append(")AS Row, T.*  from approve_role T ");
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
			parameters[0].Value = "approve_role";
			parameters[1].Value = "sid";
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

