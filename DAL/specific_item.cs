/**  版本信息模板在安装目录下，可自行修改。
* specific_item.cs
*
* 功 能： N/A
* 类 名： specific_item
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-8-6 9:19:56   N/A    初版
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
	/// 数据访问类:specific_item
	/// </summary>
	public partial class specific_item
	{
		public specific_item()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sid", "specific_item"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from specific_item");
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
		public int Add(Maticsoft.Model.specific_item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into specific_item(");
			strSql.Append("name,s_sid,show_column,sequence,parentIDs,isChild,begin_date,end_date,i_sid,implementers_sid,implementers,finish,unfinished_reason,solution,reviewed,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,show,show_name,status,create_person,create_date,update_person,update_date)");
			strSql.Append(" values (");
			strSql.Append("@name,@s_sid,@show_column,@sequence,@parentIDs,@isChild,@begin_date,@end_date,@i_sid,@implementers_sid,@implementers,@finish,@unfinished_reason,@solution,@reviewed,@remark,@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@show,@show_name,@status,@create_person,@create_date,@update_person,@update_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@s_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@show_column", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4),
					new SqlParameter("@parentIDs", SqlDbType.NVarChar,200),
					new SqlParameter("@isChild", SqlDbType.Int,4),
					new SqlParameter("@begin_date", SqlDbType.DateTime),
					new SqlParameter("@end_date", SqlDbType.DateTime),
					new SqlParameter("@i_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@implementers_sid", SqlDbType.NVarChar,200),
					new SqlParameter("@implementers", SqlDbType.NVarChar,200),
					new SqlParameter("@finish", SqlDbType.NVarChar,200),
					new SqlParameter("@unfinished_reason", SqlDbType.NVarChar,500),
					new SqlParameter("@solution", SqlDbType.NVarChar,1000),
					new SqlParameter("@reviewed", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@v1", SqlDbType.NVarChar,255),
					new SqlParameter("@v2", SqlDbType.NVarChar,255),
					new SqlParameter("@v3", SqlDbType.NVarChar,255),
					new SqlParameter("@v4", SqlDbType.NVarChar,255),
					new SqlParameter("@v5", SqlDbType.NVarChar,255),
					new SqlParameter("@v6", SqlDbType.NVarChar,255),
					new SqlParameter("@v7", SqlDbType.NVarChar,255),
					new SqlParameter("@v8", SqlDbType.NVarChar,255),
					new SqlParameter("@v9", SqlDbType.NVarChar,255),
					new SqlParameter("@v10", SqlDbType.NVarChar,255),
					new SqlParameter("@show", SqlDbType.NVarChar,100),
					new SqlParameter("@show_name", SqlDbType.NVarChar,500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.s_sid;
			parameters[2].Value = model.show_column;
			parameters[3].Value = model.sequence;
			parameters[4].Value = model.parentIDs;
			parameters[5].Value = model.isChild;
			parameters[6].Value = model.begin_date;
			parameters[7].Value = model.end_date;
			parameters[8].Value = model.i_sid;
			parameters[9].Value = model.implementers_sid;
			parameters[10].Value = model.implementers;
			parameters[11].Value = model.finish;
			parameters[12].Value = model.unfinished_reason;
			parameters[13].Value = model.solution;
			parameters[14].Value = model.reviewed;
			parameters[15].Value = model.remark;
			parameters[16].Value = model.v1;
			parameters[17].Value = model.v2;
			parameters[18].Value = model.v3;
			parameters[19].Value = model.v4;
			parameters[20].Value = model.v5;
			parameters[21].Value = model.v6;
			parameters[22].Value = model.v7;
			parameters[23].Value = model.v8;
			parameters[24].Value = model.v9;
			parameters[25].Value = model.v10;
			parameters[26].Value = model.show;
			parameters[27].Value = model.show_name;
			parameters[28].Value = model.status;
			parameters[29].Value = model.create_person;
			parameters[30].Value = model.create_date;
			parameters[31].Value = model.update_person;
			parameters[32].Value = model.update_date;

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
		public bool Update(Maticsoft.Model.specific_item model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update specific_item set ");
			strSql.Append("name=@name,");
			strSql.Append("s_sid=@s_sid,");
			strSql.Append("show_column=@show_column,");
			strSql.Append("sequence=@sequence,");
			strSql.Append("parentIDs=@parentIDs,");
			strSql.Append("isChild=@isChild,");
			strSql.Append("begin_date=@begin_date,");
			strSql.Append("end_date=@end_date,");
			strSql.Append("i_sid=@i_sid,");
			strSql.Append("implementers_sid=@implementers_sid,");
			strSql.Append("implementers=@implementers,");
			strSql.Append("finish=@finish,");
			strSql.Append("unfinished_reason=@unfinished_reason,");
			strSql.Append("solution=@solution,");
			strSql.Append("reviewed=@reviewed,");
			strSql.Append("remark=@remark,");
			strSql.Append("v1=@v1,");
			strSql.Append("v2=@v2,");
			strSql.Append("v3=@v3,");
			strSql.Append("v4=@v4,");
			strSql.Append("v5=@v5,");
			strSql.Append("v6=@v6,");
			strSql.Append("v7=@v7,");
			strSql.Append("v8=@v8,");
			strSql.Append("v9=@v9,");
			strSql.Append("v10=@v10,");
			strSql.Append("show=@show,");
			strSql.Append("show_name=@show_name,");
			strSql.Append("status=@status,");
			strSql.Append("create_person=@create_person,");
			strSql.Append("create_date=@create_date,");
			strSql.Append("update_person=@update_person,");
			strSql.Append("update_date=@update_date");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@s_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@show_column", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4),
					new SqlParameter("@parentIDs", SqlDbType.NVarChar,200),
					new SqlParameter("@isChild", SqlDbType.Int,4),
					new SqlParameter("@begin_date", SqlDbType.DateTime),
					new SqlParameter("@end_date", SqlDbType.DateTime),
					new SqlParameter("@i_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@implementers_sid", SqlDbType.NVarChar,200),
					new SqlParameter("@implementers", SqlDbType.NVarChar,200),
					new SqlParameter("@finish", SqlDbType.NVarChar,200),
					new SqlParameter("@unfinished_reason", SqlDbType.NVarChar,500),
					new SqlParameter("@solution", SqlDbType.NVarChar,1000),
					new SqlParameter("@reviewed", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@v1", SqlDbType.NVarChar,255),
					new SqlParameter("@v2", SqlDbType.NVarChar,255),
					new SqlParameter("@v3", SqlDbType.NVarChar,255),
					new SqlParameter("@v4", SqlDbType.NVarChar,255),
					new SqlParameter("@v5", SqlDbType.NVarChar,255),
					new SqlParameter("@v6", SqlDbType.NVarChar,255),
					new SqlParameter("@v7", SqlDbType.NVarChar,255),
					new SqlParameter("@v8", SqlDbType.NVarChar,255),
					new SqlParameter("@v9", SqlDbType.NVarChar,255),
					new SqlParameter("@v10", SqlDbType.NVarChar,255),
					new SqlParameter("@show", SqlDbType.NVarChar,100),
					new SqlParameter("@show_name", SqlDbType.NVarChar,500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.s_sid;
			parameters[2].Value = model.show_column;
			parameters[3].Value = model.sequence;
			parameters[4].Value = model.parentIDs;
			parameters[5].Value = model.isChild;
			parameters[6].Value = model.begin_date;
			parameters[7].Value = model.end_date;
			parameters[8].Value = model.i_sid;
			parameters[9].Value = model.implementers_sid;
			parameters[10].Value = model.implementers;
			parameters[11].Value = model.finish;
			parameters[12].Value = model.unfinished_reason;
			parameters[13].Value = model.solution;
			parameters[14].Value = model.reviewed;
			parameters[15].Value = model.remark;
			parameters[16].Value = model.v1;
			parameters[17].Value = model.v2;
			parameters[18].Value = model.v3;
			parameters[19].Value = model.v4;
			parameters[20].Value = model.v5;
			parameters[21].Value = model.v6;
			parameters[22].Value = model.v7;
			parameters[23].Value = model.v8;
			parameters[24].Value = model.v9;
			parameters[25].Value = model.v10;
			parameters[26].Value = model.show;
			parameters[27].Value = model.show_name;
			parameters[28].Value = model.status;
			parameters[29].Value = model.create_person;
			parameters[30].Value = model.create_date;
			parameters[31].Value = model.update_person;
			parameters[32].Value = model.update_date;
			parameters[33].Value = model.sid;

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
			strSql.Append("delete from specific_item ");
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
			strSql.Append("delete from specific_item ");
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
		public Maticsoft.Model.specific_item GetModel(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sid,name,s_sid,show_column,sequence,parentIDs,isChild,begin_date,end_date,i_sid,implementers_sid,implementers,finish,unfinished_reason,solution,reviewed,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,show,show_name,status,create_person,create_date,update_person,update_date from specific_item ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			Maticsoft.Model.specific_item model=new Maticsoft.Model.specific_item();
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
		public Maticsoft.Model.specific_item DataRowToModel(DataRow row)
		{
			Maticsoft.Model.specific_item model=new Maticsoft.Model.specific_item();
			if (row != null)
			{
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["s_sid"]!=null)
				{
					model.s_sid=row["s_sid"].ToString();
				}
				if(row["show_column"]!=null)
				{
					model.show_column=row["show_column"].ToString();
				}
				if(row["sequence"]!=null && row["sequence"].ToString()!="")
				{
					model.sequence=int.Parse(row["sequence"].ToString());
				}
				if(row["parentIDs"]!=null)
				{
					model.parentIDs=row["parentIDs"].ToString();
				}
				if(row["isChild"]!=null && row["isChild"].ToString()!="")
				{
					model.isChild=int.Parse(row["isChild"].ToString());
				}
				if(row["begin_date"]!=null && row["begin_date"].ToString()!="")
				{
					model.begin_date=DateTime.Parse(row["begin_date"].ToString());
				}
				if(row["end_date"]!=null && row["end_date"].ToString()!="")
				{
					model.end_date=DateTime.Parse(row["end_date"].ToString());
				}
				if(row["i_sid"]!=null)
				{
					model.i_sid=row["i_sid"].ToString();
				}
				if(row["implementers_sid"]!=null)
				{
					model.implementers_sid=row["implementers_sid"].ToString();
				}
				if(row["implementers"]!=null)
				{
					model.implementers=row["implementers"].ToString();
				}
				if(row["finish"]!=null)
				{
					model.finish=row["finish"].ToString();
				}
				if(row["unfinished_reason"]!=null)
				{
					model.unfinished_reason=row["unfinished_reason"].ToString();
				}
				if(row["solution"]!=null)
				{
					model.solution=row["solution"].ToString();
				}
				if(row["reviewed"]!=null)
				{
					model.reviewed=row["reviewed"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["v1"]!=null)
				{
					model.v1=row["v1"].ToString();
				}
				if(row["v2"]!=null)
				{
					model.v2=row["v2"].ToString();
				}
				if(row["v3"]!=null)
				{
					model.v3=row["v3"].ToString();
				}
				if(row["v4"]!=null)
				{
					model.v4=row["v4"].ToString();
				}
				if(row["v5"]!=null)
				{
					model.v5=row["v5"].ToString();
				}
				if(row["v6"]!=null)
				{
					model.v6=row["v6"].ToString();
				}
				if(row["v7"]!=null)
				{
					model.v7=row["v7"].ToString();
				}
				if(row["v8"]!=null)
				{
					model.v8=row["v8"].ToString();
				}
				if(row["v9"]!=null)
				{
					model.v9=row["v9"].ToString();
				}
				if(row["v10"]!=null)
				{
					model.v10=row["v10"].ToString();
				}
				if(row["show"]!=null)
				{
					model.show=row["show"].ToString();
				}
				if(row["show_name"]!=null)
				{
					model.show_name=row["show_name"].ToString();
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
			strSql.Append("select sid,name,s_sid,show_column,sequence,parentIDs,isChild,begin_date,end_date,i_sid,implementers_sid,implementers,finish,unfinished_reason,solution,reviewed,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,show,show_name,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM specific_item ");
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
			strSql.Append(" sid,name,s_sid,show_column,sequence,parentIDs,isChild,begin_date,end_date,i_sid,implementers_sid,implementers,finish,unfinished_reason,solution,reviewed,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,show,show_name,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM specific_item ");
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
			strSql.Append("select count(1) FROM specific_item ");
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
			strSql.Append(")AS Row, T.*  from specific_item T ");
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
			parameters[0].Value = "specific_item";
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

