using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Collections;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:File
	/// </summary>
	public partial class File
	{
		public File()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "[File]"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [File]");
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
		public int Add(Maticsoft.Model.File model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [File](");
			strSql.Append("file_name,type,pwd,pwdflag,up_person,up_date,updata_person,updata_datetiem,cate_id,flieGuid,withoutID,activate,Remark,value,value1,value2,value3,value4,value5,value6,value7,value8,value9)");
			strSql.Append(" values (");
			strSql.Append("@file_name,@type,@pwd,@pwdflag,@up_person,@up_date,@updata_person,@updata_datetiem,@cate_id,@flieGuid,@withoutID,@activate,@Remark,@value,@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8,@value9)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@file_name", SqlDbType.NVarChar,255),
					new SqlParameter("@type", SqlDbType.NVarChar,50),
					new SqlParameter("@pwd", SqlDbType.NVarChar,255),
					new SqlParameter("@pwdflag", SqlDbType.Int,4),
					new SqlParameter("@up_person", SqlDbType.Int,4),
					new SqlParameter("@up_date", SqlDbType.DateTime),
					new SqlParameter("@updata_person", SqlDbType.Int,4),
					new SqlParameter("@updata_datetiem", SqlDbType.DateTime),
					new SqlParameter("@cate_id", SqlDbType.Int,4),
					new SqlParameter("@flieGuid", SqlDbType.NVarChar),
					new SqlParameter("@withoutID", SqlDbType.Int,4),
					new SqlParameter("@activate", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
					new SqlParameter("@value", SqlDbType.NVarChar),
					new SqlParameter("@value1", SqlDbType.NVarChar),
					new SqlParameter("@value2", SqlDbType.NVarChar),
					new SqlParameter("@value3", SqlDbType.NVarChar),
					new SqlParameter("@value4", SqlDbType.NVarChar),
					new SqlParameter("@value5", SqlDbType.NVarChar),
					new SqlParameter("@value6", SqlDbType.NVarChar),
					new SqlParameter("@value7", SqlDbType.NVarChar),
					new SqlParameter("@value8", SqlDbType.NVarChar),
					new SqlParameter("@value9", SqlDbType.NVarChar)};
			parameters[0].Value = model.file_name;
			parameters[1].Value = model.type;
			parameters[2].Value = model.pwd;
			parameters[3].Value = model.pwdflag;
			parameters[4].Value = model.up_person;
			parameters[5].Value = model.up_date;
			parameters[6].Value = model.updata_person;
			parameters[7].Value = model.updata_datetiem;
			parameters[8].Value = model.cate_id;
			parameters[9].Value = model.flieGuid;
			parameters[10].Value = model.withoutID;
			parameters[11].Value = model.activate;
			parameters[12].Value = model.Remark;
			parameters[13].Value = model.value;
			parameters[14].Value = model.value1;
			parameters[15].Value = model.value2;
			parameters[16].Value = model.value3;
			parameters[17].Value = model.value4;
			parameters[18].Value = model.value5;
			parameters[19].Value = model.value6;
			parameters[20].Value = model.value7;
			parameters[21].Value = model.value8;
			parameters[22].Value = model.value9;

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
		public bool Update(Maticsoft.Model.File model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [File] set ");
			strSql.Append("file_name=@file_name,");			
			strSql.Append("pwd=@pwd,");
			strSql.Append("pwdflag=@pwdflag,");			
			strSql.Append("updata_person=@updata_person,");
			strSql.Append("updata_datetiem=@updata_datetiem,");	
			strSql.Append("Remark=@Remark,");
			strSql.Append("value=@value,");
			strSql.Append("value1=@value1,");
			strSql.Append("value2=@value2,");
			strSql.Append("value3=@value3,");
			strSql.Append("value4=@value4,");
			strSql.Append("value5=@value5,");
			strSql.Append("value6=@value6,");
			strSql.Append("value7=@value7,");
			strSql.Append("value8=@value8,");
			strSql.Append("value9=@value9");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@file_name", SqlDbType.NVarChar,255),					
					new SqlParameter("@pwd", SqlDbType.NVarChar,255),
					new SqlParameter("@pwdflag", SqlDbType.Int,4),
					new SqlParameter("@updata_person", SqlDbType.Int,4),
					new SqlParameter("@updata_datetiem", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
					new SqlParameter("@value", SqlDbType.NVarChar),
					new SqlParameter("@value1", SqlDbType.NVarChar),
					new SqlParameter("@value2", SqlDbType.NVarChar),
					new SqlParameter("@value3", SqlDbType.NVarChar),
					new SqlParameter("@value4", SqlDbType.NVarChar),
					new SqlParameter("@value5", SqlDbType.NVarChar),
					new SqlParameter("@value6", SqlDbType.NVarChar),
					new SqlParameter("@value7", SqlDbType.NVarChar),
					new SqlParameter("@value8", SqlDbType.NVarChar),
					new SqlParameter("@value9", SqlDbType.NVarChar),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.file_name;	
			parameters[1].Value = model.pwd;
			parameters[2].Value = model.pwdflag;
	    	parameters[3].Value = model.updata_person;
			parameters[4].Value = model.updata_datetiem;		
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.value;
			parameters[7].Value = model.value1;
			parameters[8].Value = model.value2;
			parameters[9].Value = model.value3;
			parameters[10].Value = model.value4;
			parameters[11].Value = model.value5;
			parameters[12].Value = model.value6;
			parameters[13].Value = model.value7;
			parameters[14].Value = model.value8;
			parameters[15].Value = model.value9;
			parameters[16].Value = model.ID;

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
		/// 提交数据
		/// </summary>
        public bool Update(List<Model.File> model)
        {
            ArrayList al = new ArrayList();
            foreach (Model.File file in model)
            {
                string SQLString = " UPDATE [File] SET file_name='{0}', pwd='{1}', pwdflag={2}, Remark='{3}', activate=1 WHERE ID={4} ";
                SQLString = string.Format(SQLString, file.file_name.Replace("'", "''"), file.pwd.Replace("'", "''"), file.pwdflag, file.Remark.Replace("'", "''"), file.ID);
                al.Add(SQLString);
            }
            DbHelperSQL.ExecuteSqlTran(al);
            return true;
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [File] ");
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
		public bool DeleteList(string IDlist)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from [File] ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
		}

        public DataSet GetDeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT dbo.getFolderPath(cate_id)+'/'+flieGuid FROM [File] ");
            strSql.Append(" WHERE ID IN(" + IDlist + ") ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetDownloadList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT dbo.getFolderPath(cate_id)+'/'+flieGuid path, file_name+type name  FROM [File] ");
            strSql.Append(" WHERE ID IN(" + IDlist + ") ");
            return DbHelperSQL.Query(strSql.ToString());
        }



		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.File GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,file_name,type,pwd,pwdflag,up_person,up_date,updata_person,updata_datetiem,cate_id,flieGuid,withoutID,activate,Remark,value,value1,value2,value3,value4,value5,value6,value7,value8,value9 from [File] ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.File model=new Maticsoft.Model.File();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["file_name"]!=null && ds.Tables[0].Rows[0]["file_name"].ToString()!="")
				{
					model.file_name=ds.Tables[0].Rows[0]["file_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["type"]!=null && ds.Tables[0].Rows[0]["type"].ToString()!="")
				{
					model.type=ds.Tables[0].Rows[0]["type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pwd"]!=null && ds.Tables[0].Rows[0]["pwd"].ToString()!="")
				{
					model.pwd=ds.Tables[0].Rows[0]["pwd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pwdflag"]!=null && ds.Tables[0].Rows[0]["pwdflag"].ToString()!="")
				{
					model.pwdflag=int.Parse(ds.Tables[0].Rows[0]["pwdflag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["up_person"]!=null && ds.Tables[0].Rows[0]["up_person"].ToString()!="")
				{
					model.up_person=int.Parse(ds.Tables[0].Rows[0]["up_person"].ToString());
				}
				if(ds.Tables[0].Rows[0]["up_date"]!=null && ds.Tables[0].Rows[0]["up_date"].ToString()!="")
				{
					model.up_date=DateTime.Parse(ds.Tables[0].Rows[0]["up_date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["updata_person"]!=null && ds.Tables[0].Rows[0]["updata_person"].ToString()!="")
				{
					model.updata_person=int.Parse(ds.Tables[0].Rows[0]["updata_person"].ToString());
				}
				if(ds.Tables[0].Rows[0]["updata_datetiem"]!=null && ds.Tables[0].Rows[0]["updata_datetiem"].ToString()!="")
				{
					model.updata_datetiem=DateTime.Parse(ds.Tables[0].Rows[0]["updata_datetiem"].ToString());
				}
				if(ds.Tables[0].Rows[0]["cate_id"]!=null && ds.Tables[0].Rows[0]["cate_id"].ToString()!="")
				{
					model.cate_id=int.Parse(ds.Tables[0].Rows[0]["cate_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["flieGuid"]!=null && ds.Tables[0].Rows[0]["flieGuid"].ToString()!="")
				{
					model.flieGuid=ds.Tables[0].Rows[0]["flieGuid"].ToString();
				}
				if(ds.Tables[0].Rows[0]["withoutID"]!=null && ds.Tables[0].Rows[0]["withoutID"].ToString()!="")
				{
					model.withoutID=int.Parse(ds.Tables[0].Rows[0]["withoutID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["activate"]!=null && ds.Tables[0].Rows[0]["activate"].ToString()!="")
				{
					model.activate=int.Parse(ds.Tables[0].Rows[0]["activate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["value"]!=null && ds.Tables[0].Rows[0]["value"].ToString()!="")
				{
					model.value=ds.Tables[0].Rows[0]["value"].ToString();
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
				if(ds.Tables[0].Rows[0]["value7"]!=null && ds.Tables[0].Rows[0]["value7"].ToString()!="")
				{
					model.value7=ds.Tables[0].Rows[0]["value7"].ToString();
				}
				if(ds.Tables[0].Rows[0]["value8"]!=null && ds.Tables[0].Rows[0]["value8"].ToString()!="")
				{
					model.value8=ds.Tables[0].Rows[0]["value8"].ToString();
				}
				if(ds.Tables[0].Rows[0]["value9"]!=null && ds.Tables[0].Rows[0]["value9"].ToString()!="")
				{
					model.value9=ds.Tables[0].Rows[0]["value9"].ToString();
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
            strSql.Append("select ID,file_name,type,pwd, pwdflag, up_person, up_date, updata_person, updata_datetiem, cate_id,dbo.getFolderName(cate_id)cate_idName, flieGuid, withoutID, activate,Remark,value,value1,value2,value3,value4,value5,value6,value7,value8,value9 ");
			strSql.Append(" FROM [File] ");
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
			strSql.Append(" ID,file_name,type,pwd,pwdflag,up_person,up_date,updata_person,updata_datetiem,cate_id,flieGuid,withoutID,activate,Remark,value,value1,value2,value3,value4,value5,value6,value7,value8,value9 ");
			strSql.Append(" FROM [File] ");
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
			strSql.Append("select count(1) FROM [File] ");
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
			strSql.Append(")AS Row, T.*  from [File] T ");
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
			parameters[0].Value = "[File]";
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

