/**  版本信息模板在安装目录下，可自行修改。
* flow_master.cs
*
* 功 能： N/A
* 类 名： flow_master
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-7-17 17:33:26   N/A    初版
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
	/// 数据访问类:flow_master
	/// </summary>
	public partial class flow_master
	{
		public flow_master()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("sid", "flow_master"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from flow_master");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists_where(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from flow_master ");
            strSql.Append(where);
            //SqlParameter[] parameters = {
            //        new SqlParameter("@sid", SqlDbType.Int,4)
            //};
           //parameters[0].Value = where;

            return DbHelperSQL.Exists(strSql.ToString());
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.flow_master model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into flow_master(");
			strSql.Append("flow_name,rf_sid,dept_sid,post_sid,flow_status,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date)");
			strSql.Append(" values (");
			strSql.Append("@flow_name,@rf_sid,@dept_sid,@post_sid,@flow_status,@remark,@value1,@value2,@value3,@value4,@value5,@value6,@status,@create_person,@create_date,@update_person,@update_date)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@flow_name", SqlDbType.NVarChar,10),
					new SqlParameter("@rf_sid", SqlDbType.Int,4),
					new SqlParameter("@dept_sid", SqlDbType.NVarChar,500),
					new SqlParameter("@post_sid", SqlDbType.NVarChar,500),
					new SqlParameter("@flow_status", SqlDbType.Int,4),
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
			parameters[0].Value = model.flow_name;
			parameters[1].Value = model.rf_sid;
			parameters[2].Value = model.dept_sid;
			parameters[3].Value = model.post_sid;
			parameters[4].Value = model.flow_status;
			parameters[5].Value = model.remark;
			parameters[6].Value = model.value1;
			parameters[7].Value = model.value2;
			parameters[8].Value = model.value3;
			parameters[9].Value = model.value4;
			parameters[10].Value = model.value5;
			parameters[11].Value = model.value6;
			parameters[12].Value = model.status;
			parameters[13].Value = model.create_person;
			parameters[14].Value = model.create_date;
			parameters[15].Value = model.update_person;
			parameters[16].Value = model.update_date;

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
		public bool Update(Maticsoft.Model.flow_master model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update flow_master set ");
			strSql.Append("flow_name=@flow_name,");
			strSql.Append("rf_sid=@rf_sid,");
			strSql.Append("dept_sid=@dept_sid,");
			strSql.Append("post_sid=@post_sid,");
			strSql.Append("flow_status=@flow_status,");
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
					new SqlParameter("@flow_name", SqlDbType.NVarChar,10),
					new SqlParameter("@rf_sid", SqlDbType.Int,4),
					new SqlParameter("@dept_sid", SqlDbType.NVarChar,500),
					new SqlParameter("@post_sid", SqlDbType.NVarChar,500),
					new SqlParameter("@flow_status", SqlDbType.Int,4),
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
			parameters[0].Value = model.flow_name;
			parameters[1].Value = model.rf_sid;
			parameters[2].Value = model.dept_sid;
			parameters[3].Value = model.post_sid;
			parameters[4].Value = model.flow_status;
			parameters[5].Value = model.remark;
			parameters[6].Value = model.value1;
			parameters[7].Value = model.value2;
			parameters[8].Value = model.value3;
			parameters[9].Value = model.value4;
			parameters[10].Value = model.value5;
			parameters[11].Value = model.value6;
			parameters[12].Value = model.status;
			parameters[13].Value = model.create_person;
			parameters[14].Value = model.create_date;
			parameters[15].Value = model.update_person;
			parameters[16].Value = model.update_date;
			parameters[17].Value = model.sid;

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
			strSql.Append("delete from flow_master ");
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
			strSql.Append("delete from flow_master ");
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
		public Maticsoft.Model.flow_master GetModel(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sid,flow_name,rf_sid,dept_sid,post_sid,flow_status,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date from flow_master ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			Maticsoft.Model.flow_master model=new Maticsoft.Model.flow_master();
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
		public Maticsoft.Model.flow_master DataRowToModel(DataRow row)
		{
			Maticsoft.Model.flow_master model=new Maticsoft.Model.flow_master();
			if (row != null)
			{
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["flow_name"]!=null)
				{
					model.flow_name=row["flow_name"].ToString();
				}
				if(row["rf_sid"]!=null && row["rf_sid"].ToString()!="")
				{
					model.rf_sid=int.Parse(row["rf_sid"].ToString());
				}
				if(row["dept_sid"]!=null)
				{
					model.dept_sid=row["dept_sid"].ToString();
				}
				if(row["post_sid"]!=null)
				{
					model.post_sid=row["post_sid"].ToString();
				}
				if(row["flow_status"]!=null && row["flow_status"].ToString()!="")
				{
					model.flow_status=int.Parse(row["flow_status"].ToString());
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
			strSql.Append("select sid,flow_name,rf_sid,dept_sid,post_sid,flow_status,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM flow_master ");
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
			strSql.Append(" sid,flow_name,rf_sid,dept_sid,post_sid,flow_status,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM flow_master ");
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
			strSql.Append("select count(1) FROM flow_master ");
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
			strSql.Append(")AS Row, T.*  from flow_master T ");
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
			parameters[0].Value = "flow_master";
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
        public bool InsertFlow(Model.flow_master oaFlowMasterInfo, List<Model.flow_node> insertList)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("insert into flow_master(flow_name,rf_sid,dept_sid,post_sid,flow_status,remark,");
            sbSql.Append("create_person, create_date,dept,post,form");
            sbSql.Append(")values(");
            sbSql.Append("'" + oaFlowMasterInfo.flow_name + "'," + oaFlowMasterInfo.rf_sid + ",");
            sbSql.Append("'" + oaFlowMasterInfo.dept_sid + "','" + oaFlowMasterInfo.post_sid + "',");
            sbSql.Append("" + oaFlowMasterInfo.flow_status + ",'" + oaFlowMasterInfo.remark + "',");
            sbSql.Append("'" + oaFlowMasterInfo.create_person + "',getdate(),");
            sbSql.Append("'" + oaFlowMasterInfo.dept + "','" + oaFlowMasterInfo.post + "','" + oaFlowMasterInfo.form + "'");
            sbSql.Append(")");

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    //主表
                    cmd.CommandText = sbSql.ToString();
                    cmd.ExecuteNonQuery();
                    //获取ID
                    cmd.CommandText = "select SCOPE_IDENTITY()";
                    string strMID = cmd.ExecuteScalar().ToString();
                    //从表

                    //添加
                    for (int i = 0; i < insertList.Count; i++)
                    {
                        sbSql = new StringBuilder();
                        //DataRow dr = dtDetail.Rows[i];
                        //if (dr.RowState == DataRowState.Deleted) continue;
                        Model.flow_node model = insertList[i];
                        sbSql.Append("insert into flow_node(flow_sid, node_no, node_type, node_name,  appr_dept,");
                        sbSql.Append("dept,role,");
                        sbSql.Append("appr_dept_type,appr_role,appr_count,appr_time,create_person, create_date");
                        sbSql.Append(")values(");
                        sbSql.Append("'" + strMID + "'," + model.node_no.ToString() + ",");
                        sbSql.Append("" + model.node_type.ToString() + ",'" + model.node_name.ToString() + "',");
                        sbSql.Append("'" + model.appr_dept.ToString() + "',");
                        sbSql.Append("'" + model.dept.ToString() + "',");
                        sbSql.Append("'" + model.role.ToString() + "',");
                        sbSql.Append("" + model.appr_dept_type.ToString() + ",'" + model.appr_role.ToString() + "',");
                        sbSql.Append("" + model.appr_count.ToString() + ",'" + model.appr_time.ToString() + "',");
                        sbSql.Append("'" + oaFlowMasterInfo.create_person + "',getdate()");
                        sbSql.Append(")");
                        cmd.CommandText = sbSql.ToString();
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }

            return true;

        }

        public bool UpdateFlow(Model.flow_master oaFlowMasterInfo, List<Model.flow_node> insertList, List<Model.flow_node> updateList, List<Model.flow_node> delList)
        {
            try
            {
                ArrayList al = new ArrayList();

                //主表
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("update flow_master set ");
                sbSql.Append("flow_name='" + oaFlowMasterInfo.flow_name + "',");
                sbSql.Append("rf_sid=" + oaFlowMasterInfo.rf_sid + ",");
                sbSql.Append("dept_sid='" + oaFlowMasterInfo.dept_sid + "',");
                sbSql.Append("post_sid='" + oaFlowMasterInfo.post_sid + "',");
                sbSql.Append("dept='" + oaFlowMasterInfo.dept + "',");
                sbSql.Append("post='" + oaFlowMasterInfo.post + "',");
                sbSql.Append("form='" + oaFlowMasterInfo.form + "',");
                sbSql.Append("flow_status=" + oaFlowMasterInfo.flow_status + ",");
                sbSql.Append("remark='" + oaFlowMasterInfo.remark + "',");
                sbSql.Append("update_person = '',");
                sbSql.Append("update_date = getdate()");
                sbSql.Append(" where sid = '" + oaFlowMasterInfo.sid + "'");

                al.Add(sbSql.ToString());

                //从表
                //删除
                for (int i = 0; i < delList.Count; i++)
                {
                    sbSql = new StringBuilder();
                    Model.flow_node model = delList[i];
                    sbSql.Append("delete from flow_node where sid=" + model.sid);
                    al.Add(sbSql.ToString());
                }
                //修改
                for (int i = 0; i < updateList.Count; i++)
                {
                    sbSql = new StringBuilder();
                    //DataRow dr = dtDetail.Rows[i];
                    //if (dr.RowState == DataRowState.Deleted) continue;
                    Model.flow_node model = updateList[i];
                    sbSql.Append("update flow_node set node_no = '" + model.node_no.ToString() + "',");
                    sbSql.Append("flow_sid = " + model.flow_sid.ToString() + ",");
                    sbSql.Append("node_type = '" + model.node_type + "',");
                    sbSql.Append("node_name = '" + model.node_name + "',");
                    sbSql.Append("appr_dept = '" + model.appr_dept.ToString() + "',");
                    sbSql.Append("appr_dept_type = '" + model.appr_dept_type.ToString() + "',");
                    sbSql.Append("appr_role = '" + model.appr_role.ToString() + "',");
                    sbSql.Append("dept = '" + model.dept.ToString() + "',");
                    sbSql.Append("role = '" + model.role.ToString() + "',");
                    sbSql.Append("appr_count = '" + model.appr_count.ToString() + "',");
                    sbSql.Append("appr_time = '" + model.appr_time.ToString() + "',");
                    sbSql.Append("update_person = '',");
                    sbSql.Append("update_date = getdate()");
                    sbSql.Append(" where sid = '" + model.sid.ToString() + "'");
                    al.Add(sbSql.ToString());
                }
                //添加
                for (int i = 0; i < insertList.Count; i++)
                {
                    sbSql = new StringBuilder();
                    //DataRow dr = dtDetail.Rows[i];
                    //if (dr.RowState == DataRowState.Deleted) continue;
                    Model.flow_node model = insertList[i];
                    sbSql.Append("insert into flow_node(flow_sid, node_no, node_type, node_name,  appr_dept,");
                    sbSql.Append("dept,role,");
                    sbSql.Append("appr_dept_type,appr_role,appr_count,appr_time,create_person, create_date");
                    sbSql.Append(")values(");
                    sbSql.Append("'" + oaFlowMasterInfo.sid + "'," + model.node_no.ToString() + ",");
                    sbSql.Append("" + model.node_type.ToString() + ",'" + model.node_name.ToString() + "',");
                    sbSql.Append("'" + model.appr_dept.ToString() + "',");
                    sbSql.Append("'" + model.dept.ToString() + "',");
                    sbSql.Append("'" + model.role.ToString() + "',");
                    sbSql.Append("" + model.appr_dept_type.ToString() + ",'" + model.appr_role.ToString() + "',");
                    sbSql.Append("" + model.appr_count.ToString() + ",'" + model.appr_time.ToString() + "',");
                    sbSql.Append("'" + oaFlowMasterInfo.create_person + "',getdate()");
                    sbSql.Append(")");
                    al.Add(sbSql.ToString());
                }

                DbHelperSQL.ExecuteSqlTran(al);
                return true;
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public bool DeleteFlow(string SID)
        {
            string strSql = "delete from flow_node where flow_sid in (" + SID + "); delete from flow_master where sid in (" + SID + ")";

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
		#endregion  ExtensionMethod
	}
}

