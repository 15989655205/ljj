/**  版本信息模板在安装目录下，可自行修改。
* Project_Template_Type.cs
*
* 功 能： N/A
* 类 名： Project_Template_Type
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-9-11 17:42:35   N/A    初版
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
using System.Collections.Generic;
using System.Collections;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Project_Template_Type
	/// </summary>
	public partial class Project_Template_Type
	{
		public Project_Template_Type()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sid", "Project_Template_Type"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Project_Template_Type");
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
		public int Add(Maticsoft.Model.Project_Template_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Project_Template_Type(");
			strSql.Append("value,name,sequence,remark)");
			strSql.Append(" values (");
			strSql.Append("@value,@name,@sequence,@remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@value", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.value;
			parameters[1].Value = model.name;
			parameters[2].Value = model.sequence;
			parameters[3].Value = model.remark;

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
		public bool Update(Maticsoft.Model.Project_Template_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Project_Template_Type set ");
			strSql.Append("value=@value,");
			strSql.Append("name=@name,");
			strSql.Append("sequence=@sequence,");
			strSql.Append("remark=@remark");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@value", SqlDbType.Int,4),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@sid", SqlDbType.Int,4)};
			parameters[0].Value = model.value;
			parameters[1].Value = model.name;
			parameters[2].Value = model.sequence;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.sid;

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
			strSql.Append("delete from Project_Template_Type ");
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
			strSql.Append("delete from Project_Template_Type ");
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
		public Maticsoft.Model.Project_Template_Type GetModel(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sid,value,name,sequence,remark from Project_Template_Type ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			Maticsoft.Model.Project_Template_Type model=new Maticsoft.Model.Project_Template_Type();
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
		public Maticsoft.Model.Project_Template_Type DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Project_Template_Type model=new Maticsoft.Model.Project_Template_Type();
			if (row != null)
			{
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["value"]!=null && row["value"].ToString()!="")
				{
					model.value=int.Parse(row["value"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["sequence"]!=null && row["sequence"].ToString()!="")
				{
					model.sequence=int.Parse(row["sequence"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			strSql.Append("select sid,value,name,sequence,remark ");
			strSql.Append(" FROM Project_Template_Type ");
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
			strSql.Append(" sid,value,name,sequence,remark ");
			strSql.Append(" FROM Project_Template_Type ");
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
			strSql.Append("select count(1) FROM Project_Template_Type ");
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
			strSql.Append(")AS Row, T.*  from Project_Template_Type T ");
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
			parameters[0].Value = "Project_Template_Type";
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
        public bool Edit(List<Model.Project_Template_Type> insertList, List<Model.Project_Template_Type> updateList, List<Model.Project_Template_Type> delList)
        {
            ArrayList al = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            //删除
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.Project_Template_Type model = delList[i];
                sbSql.Append("delete from Project_Template_Type where sid=" + model.sid);
                al.Add(sbSql.ToString());
            }
            //修改
            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.Project_Template_Type model = updateList[i];
                sbSql.Append("update Project_Template_Type set name = '" + model.name.Trim() + "',");
                sbSql.Append("remark = '" + model.remark.Trim() + "'");
                sbSql.Append(" where sid = '" + model.sid.ToString().Trim() + "'");
                al.Add(sbSql.ToString());
            }
            //添加
            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.Project_Template_Type model = insertList[i];
                sbSql.Append("insert into Project_Template_Type(name, remark");
                sbSql.Append(")values(");
                sbSql.Append("'" + model.name.Trim() + "','" + model.remark.Trim() + "'");
                sbSql.Append(")");
                al.Add(sbSql.ToString());
            }

            DbHelperSQL.ExecuteSqlTran(al);

            return true;
        }
		#endregion  ExtensionMethod
	}
}

