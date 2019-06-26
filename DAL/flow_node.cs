/**  版本信息模板在安装目录下，可自行修改。
* flow_node.cs
*
* 功 能： N/A
* 类 名： flow_node
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
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:flow_node
	/// </summary>
	public partial class flow_node
	{
		public flow_node()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sid", "flow_node"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from flow_node");
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
		public int Add(Maticsoft.Model.flow_node model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into flow_node(");
			strSql.Append("node_no,node_type,node_name,node_status,appr_dept,appr_dept_type,appr_role,appr_count,appr_must,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date)");
			strSql.Append(" values (");
			strSql.Append("@node_no,@node_type,@node_name,@node_status,@appr_dept,@appr_dept_type,@appr_role,@appr_count,@appr_must,@remark,@value1,@value2,@value3,@value4,@value5,@value6,@status,@create_person,@create_date,@update_person,@update_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@node_no", SqlDbType.Int,4),
					new SqlParameter("@node_type", SqlDbType.Int,4),
					new SqlParameter("@node_name", SqlDbType.NVarChar,50),
					new SqlParameter("@node_status", SqlDbType.Int,4),
					new SqlParameter("@appr_dept", SqlDbType.NVarChar,500),
					new SqlParameter("@appr_dept_type", SqlDbType.NVarChar,50),
					new SqlParameter("@appr_role", SqlDbType.NVarChar,500),
					new SqlParameter("@appr_count", SqlDbType.Int,4),
					new SqlParameter("@appr_must", SqlDbType.Int,4),
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
			parameters[0].Value = model.node_no;
			parameters[1].Value = model.node_type;
			parameters[2].Value = model.node_name;
			parameters[3].Value = model.node_status;
			parameters[4].Value = model.appr_dept;
			parameters[5].Value = model.appr_dept_type;
			parameters[6].Value = model.appr_role;
			parameters[7].Value = model.appr_count;
			parameters[8].Value = model.appr_must;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.value1;
			parameters[11].Value = model.value2;
			parameters[12].Value = model.value3;
			parameters[13].Value = model.value4;
			parameters[14].Value = model.value5;
			parameters[15].Value = model.value6;
			parameters[16].Value = model.status;
			parameters[17].Value = model.create_person;
			parameters[18].Value = model.create_date;
			parameters[19].Value = model.update_person;
			parameters[20].Value = model.update_date;

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
		public bool Update(Maticsoft.Model.flow_node model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update flow_node set ");
			strSql.Append("node_no=@node_no,");
			strSql.Append("node_type=@node_type,");
			strSql.Append("node_name=@node_name,");
			strSql.Append("node_status=@node_status,");
			strSql.Append("appr_dept=@appr_dept,");
			strSql.Append("appr_dept_type=@appr_dept_type,");
			strSql.Append("appr_role=@appr_role,");
			strSql.Append("appr_count=@appr_count,");
			strSql.Append("appr_must=@appr_must,");
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
					new SqlParameter("@node_no", SqlDbType.Int,4),
					new SqlParameter("@node_type", SqlDbType.Int,4),
					new SqlParameter("@node_name", SqlDbType.NVarChar,50),
					new SqlParameter("@node_status", SqlDbType.Int,4),
					new SqlParameter("@appr_dept", SqlDbType.NVarChar,500),
					new SqlParameter("@appr_dept_type", SqlDbType.NVarChar,50),
					new SqlParameter("@appr_role", SqlDbType.NVarChar,500),
					new SqlParameter("@appr_count", SqlDbType.Int,4),
					new SqlParameter("@appr_must", SqlDbType.Int,4),
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
			parameters[0].Value = model.node_no;
			parameters[1].Value = model.node_type;
			parameters[2].Value = model.node_name;
			parameters[3].Value = model.node_status;
			parameters[4].Value = model.appr_dept;
			parameters[5].Value = model.appr_dept_type;
			parameters[6].Value = model.appr_role;
			parameters[7].Value = model.appr_count;
			parameters[8].Value = model.appr_must;
			parameters[9].Value = model.remark;
			parameters[10].Value = model.value1;
			parameters[11].Value = model.value2;
			parameters[12].Value = model.value3;
			parameters[13].Value = model.value4;
			parameters[14].Value = model.value5;
			parameters[15].Value = model.value6;
			parameters[16].Value = model.status;
			parameters[17].Value = model.create_person;
			parameters[18].Value = model.create_date;
			parameters[19].Value = model.update_person;
			parameters[20].Value = model.update_date;
			parameters[21].Value = model.sid;

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
			strSql.Append("delete from flow_node ");
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
			strSql.Append("delete from flow_node ");
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
		public Maticsoft.Model.flow_node GetModel(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sid,node_no,node_type,node_name,node_status,appr_dept,appr_dept_type,appr_role,appr_count,appr_must,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date from flow_node ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			Maticsoft.Model.flow_node model=new Maticsoft.Model.flow_node();
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
		public Maticsoft.Model.flow_node DataRowToModel(DataRow row)
		{
			Maticsoft.Model.flow_node model=new Maticsoft.Model.flow_node();
			if (row != null)
			{
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["node_no"]!=null && row["node_no"].ToString()!="")
				{
					model.node_no=int.Parse(row["node_no"].ToString());
				}
				if(row["node_type"]!=null && row["node_type"].ToString()!="")
				{
					model.node_type=int.Parse(row["node_type"].ToString());
				}
				if(row["node_name"]!=null)
				{
					model.node_name=row["node_name"].ToString();
				}
				if(row["node_status"]!=null && row["node_status"].ToString()!="")
				{
					model.node_status=int.Parse(row["node_status"].ToString());
				}
				if(row["appr_dept"]!=null)
				{
					model.appr_dept=row["appr_dept"].ToString();
				}
				if(row["appr_dept_type"]!=null && row["appr_dept_type"].ToString()!="")
				{
					model.appr_dept_type=row["appr_dept_type"].ToString();
				}
				if(row["appr_role"]!=null)
				{
					model.appr_role=row["appr_role"].ToString();
				}
				if(row["appr_count"]!=null && row["appr_count"].ToString()!="")
				{
					model.appr_count=int.Parse(row["appr_count"].ToString());
				}
				if(row["appr_must"]!=null && row["appr_must"].ToString()!="")
				{
					model.appr_must=int.Parse(row["appr_must"].ToString());
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
			strSql.Append("select sid,node_no,node_type,node_name,node_status,appr_dept,appr_dept_type,appr_role,appr_count,appr_must,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM flow_node ");
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
			strSql.Append(" sid,node_no,node_type,node_name,node_status,appr_dept,appr_dept_type,appr_role,appr_count,appr_must,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM flow_node ");
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
			strSql.Append("select count(1) FROM flow_node ");
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
			strSql.Append(")AS Row, T.*  from flow_node T ");
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
			parameters[0].Value = "flow_node";
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

		#endregion  ExtensionMethod
	}
}

