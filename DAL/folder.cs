using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:folder
	/// </summary>
	public partial class folder
	{
		public folder()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "folder"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int result= DbHelperSQL.RunProcedure("folder_Exists",parameters,out rowsAffected);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.folder model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@folder_name", SqlDbType.NVarChar,255),
					new SqlParameter("@dowm_permission", SqlDbType.NVarChar,-1),
					new SqlParameter("@up_permission", SqlDbType.NVarChar,-1),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@folder_path", SqlDbType.NVarChar,255),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@folder_level", SqlDbType.Int,4),
					new SqlParameter("@value1", SqlDbType.NVarChar,255),
					new SqlParameter("@value2", SqlDbType.NVarChar,255),
					new SqlParameter("@value3", SqlDbType.NVarChar,255)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.folder_name;
			parameters[2].Value = model.dowm_permission;
			parameters[3].Value = model.up_permission;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.folder_path;
			parameters[6].Value = model.create_date;
			parameters[7].Value = model.create_person;
			parameters[8].Value = model.update_person;
			parameters[9].Value = model.update_date;
			parameters[10].Value = model.folder_level;
			parameters[11].Value = model.value1;
			parameters[12].Value = model.value2;
			parameters[13].Value = model.value3;

			DbHelperSQL.RunProcedure("folder_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.folder model)
		{
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@folder_name", SqlDbType.NVarChar,255),
					new SqlParameter("@dowm_permission", SqlDbType.NVarChar,-1),
					new SqlParameter("@up_permission", SqlDbType.NVarChar,-1),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@folder_path", SqlDbType.NVarChar,255),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@folder_level", SqlDbType.Int,4),
					new SqlParameter("@value1", SqlDbType.NVarChar,255),
					new SqlParameter("@value2", SqlDbType.NVarChar,255),
					new SqlParameter("@value3", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.folder_name;
			parameters[2].Value = model.dowm_permission;
			parameters[3].Value = model.up_permission;
			parameters[4].Value = model.remark;
			parameters[5].Value = model.folder_path;
			parameters[6].Value = model.create_date;
			parameters[7].Value = model.create_person;
			parameters[8].Value = model.update_person;
			parameters[9].Value = model.update_date;
			parameters[10].Value = model.folder_level;
			parameters[11].Value = model.value1;
			parameters[12].Value = model.value2;
			parameters[13].Value = model.value3;

			DbHelperSQL.RunProcedure("folder_Update",parameters,out rowsAffected);
			if (rowsAffected > 0)
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
			int rowsAffected=0;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			DbHelperSQL.RunProcedure("folder_Delete",parameters,out rowsAffected);
			if (rowsAffected > 0)
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
			strSql.Append("delete from folder ");
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
		public Maticsoft.Model.folder GetModel(int ID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.folder model=new Maticsoft.Model.folder();
			DataSet ds= DbHelperSQL.RunProcedure("folder_GetModel",parameters,"ds");
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
        /// 得到上传下载权限列表
        /// </summary>
        public DataSet GetUpDowmPer(string ActionType,string key)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ActionType", SqlDbType.NVarChar,20),
                    new SqlParameter("@folder_id",SqlDbType.Int)
			};
            parameters[0].Value = ActionType;
            parameters[1].Value = key;
            Maticsoft.Model.folder model = new Maticsoft.Model.folder();
            DataSet ds = DbHelperSQL.RunProcedure("pro_folder", parameters, "ds");
            return ds;
        }

        

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.folder DataRowToModel(DataRow row)
		{
			Maticsoft.Model.folder model=new Maticsoft.Model.folder();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["folder_name"]!=null)
				{
					model.folder_name=row["folder_name"].ToString();
				}
				if(row["dowm_permission"]!=null)
				{
					model.dowm_permission=row["dowm_permission"].ToString();
				}
				if(row["up_permission"]!=null)
				{
					model.up_permission=row["up_permission"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["folder_path"]!=null)
				{
					model.folder_path=row["folder_path"].ToString();
				}
				if(row["create_date"]!=null && row["create_date"].ToString()!="")
				{
					model.create_date=DateTime.Parse(row["create_date"].ToString());
				}
				if(row["create_person"]!=null)
				{
					model.create_person=row["create_person"].ToString();
				}
				if(row["update_person"]!=null)
				{
					model.update_person=row["update_person"].ToString();
				}
				if(row["update_date"]!=null && row["update_date"].ToString()!="")
				{
					model.update_date=DateTime.Parse(row["update_date"].ToString());
				}
				if(row["folder_level"]!=null && row["folder_level"].ToString()!="")
				{
					model.folder_level=int.Parse(row["folder_level"].ToString());
				}
				if(row["value1"]!=null)
				{
					model.value1=row["value1"].ToString();
				}
				if(row["value2"]!=null)
				{
					model.value2=row["value2"].ToString();
				}
				if(row["value3"]!=null)
				{
					model.value3=row["value3"].ToString();
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
			strSql.Append("select ID,folder_name,dowm_permission,up_permission,remark,folder_path,create_date,create_person,update_person,update_date,folder_level,value1,value2,value3 ");
			strSql.Append(" FROM folder ");
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
			strSql.Append(" ID,folder_name,dowm_permission,up_permission,remark,folder_path,create_date,create_person,update_person,update_date,folder_level,value1,value2,value3 ");
			strSql.Append(" FROM folder ");
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
			strSql.Append("select count(1) FROM folder ");
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
			strSql.Append(")AS Row, T.*  from folder T ");
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
			parameters[0].Value = "folder";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

