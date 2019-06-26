/**  版本信息模板在安装目录下，可自行修改。
* request_form_type.cs
*
* 功 能： N/A
* 类 名： request_form_type
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-7-17 17:33:27   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections;
using System.Collections.Generic;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:request_form_type
	/// </summary>
	public partial class request_form_type
	{
		public request_form_type()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sid", "request_form_type"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from request_form_type");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.request_form_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into request_form_type(");
			strSql.Append("type_name,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date)");
			strSql.Append(" values (");
			strSql.Append("@type_name,@remark,@value1,@value2,@value3,@value4,@value5,@value6,@status,@create_person,@create_date,@update_person,@update_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@type_name", SqlDbType.NVarChar,10),
					new SqlParameter("@remark", SqlDbType.Text),
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
			parameters[0].Value = model.type_name;
			parameters[1].Value = model.remark;
			parameters[2].Value = model.value1;
			parameters[3].Value = model.value2;
			parameters[4].Value = model.value3;
			parameters[5].Value = model.value4;
			parameters[6].Value = model.value5;
			parameters[7].Value = model.value6;
			parameters[8].Value = model.status;
			parameters[9].Value = model.create_person;
			parameters[10].Value = model.create_date;
			parameters[11].Value = model.update_person;
			parameters[12].Value = model.update_date;

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
		public bool Update(Maticsoft.Model.request_form_type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update request_form_type set ");
			strSql.Append("type_name=@type_name,");
			strSql.Append("remark=@remark,");
			strSql.Append("value1=@value1,");
			strSql.Append("value2=@value2,");
			strSql.Append("value3=@value3,");
			strSql.Append("value4=@value4,");
			strSql.Append("value5=@value5,");
			strSql.Append("value6=@value6,");
			strSql.Append("status=@status,");
			strSql.Append("create_person=@create_person,");
			strSql.Append("create_date=@create_date,");
			strSql.Append("update_person=@update_person,");
			strSql.Append("update_date=@update_date");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@type_name", SqlDbType.NVarChar,10),
					new SqlParameter("@remark", SqlDbType.Text),
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
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.Int,4)};
			parameters[0].Value = model.type_name;
			parameters[1].Value = model.remark;
			parameters[2].Value = model.value1;
			parameters[3].Value = model.value2;
			parameters[4].Value = model.value3;
			parameters[5].Value = model.value4;
			parameters[6].Value = model.value5;
			parameters[7].Value = model.value6;
			parameters[8].Value = model.status;
			parameters[9].Value = model.create_person;
			parameters[10].Value = model.create_date;
			parameters[11].Value = model.update_person;
			parameters[12].Value = model.update_date;
			parameters[13].Value = model.sid;

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
			strSql.Append("delete from request_form_type ");
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
			strSql.Append("delete from request_form_type ");
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
		public Maticsoft.Model.request_form_type GetModel(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sid,type_name,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date from request_form_type ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			Maticsoft.Model.request_form_type model=new Maticsoft.Model.request_form_type();
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
		public Maticsoft.Model.request_form_type DataRowToModel(DataRow row)
		{
			Maticsoft.Model.request_form_type model=new Maticsoft.Model.request_form_type();
			if (row != null)
			{
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["type_name"]!=null)
				{
					model.type_name=row["type_name"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
				if(row["value4"]!=null)
				{
					model.value4=row["value4"].ToString();
				}
				if(row["value5"]!=null)
				{
					model.value5=row["value5"].ToString();
				}
				if(row["value6"]!=null)
				{
					model.value6=row["value6"].ToString();
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["create_person"]!=null)
				{
					model.create_person=row["create_person"].ToString();
				}
				if(row["create_date"]!=null && row["create_date"].ToString()!="")
				{
					model.create_date=DateTime.Parse(row["create_date"].ToString());
				}
				if(row["update_person"]!=null)
				{
					model.update_person=row["update_person"].ToString();
				}
				if(row["update_date"]!=null && row["update_date"].ToString()!="")
				{
					model.update_date=DateTime.Parse(row["update_date"].ToString());
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
			strSql.Append("select sid,type_name,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM request_form_type ");
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
			strSql.Append(" sid,type_name,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM request_form_type ");
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
			strSql.Append("select count(1) FROM request_form_type ");
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
			strSql.Append(")AS Row, T.*  from request_form_type T ");
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
			parameters[0].Value = "request_form_type";
			parameters[1].Value = "sid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        #region fu20130713
        public bool Edit(List<Model.request_form_type> insertList, List<Model.request_form_type> updateList, List<Model.request_form_type> delList)
        {
            ArrayList al = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            //删除
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.request_form_type model = delList[i];
                sbSql.Append("delete from request_form_type where sid=" + model.sid);
                al.Add(sbSql.ToString());
            }
            //修改
            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.request_form_type model = updateList[i];
                sbSql.Append("update request_form_type set type_name = '" + model.type_name.Trim() + "',");
                sbSql.Append("status = '" + model.status.ToString().Trim() + "'");
                sbSql.Append(" where sid = '" + model.sid.ToString().Trim() + "'");
                al.Add(sbSql.ToString());
            }
            //添加
            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.request_form_type model = insertList[i];
                sbSql.Append("insert into request_form_type(type_name, status");
                sbSql.Append(")values(");
                sbSql.Append("'" + model.type_name.Trim() + "','" + model.status.ToString().Trim() + "'");
                sbSql.Append(")");
                al.Add(sbSql.ToString());
            }

            DbHelperSQL.ExecuteSqlTran(al);

            return true;
        }
        #endregion
		#endregion  ExtensionMethod
	}
}

