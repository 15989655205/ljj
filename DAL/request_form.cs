/**  版本信息模板在安装目录下，可自行修改。
* request_form.cs
*
* 功 能： N/A
* 类 名： request_form
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
using System.Collections.Generic;
using System.Collections;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:request_form
	/// </summary>
	public partial class request_form
	{
		public request_form()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from request_form");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists_where(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from request_form");
            strSql.Append(where);

            return DbHelperSQL.Exists(strSql.ToString());
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.request_form model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into request_form(");
            strSql.Append("form_name,rft_sid,url,rf_status,content_str,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date)");
            strSql.Append(" values (");
            strSql.Append("@form_name,@rft_sid,@url,@rf_status,@content_str,@remark,@value1,@value2,@value3,@value4,@value5,@value6,@status,@create_person,@create_date,@update_person,@update_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@form_name", SqlDbType.NVarChar,10),
					new SqlParameter("@rft_sid", SqlDbType.Int,4),
					new SqlParameter("@url", SqlDbType.NVarChar,200),
					new SqlParameter("@rf_status", SqlDbType.Int,4),
					new SqlParameter("@content_str", SqlDbType.Text),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@value1", SqlDbType.NVarChar,-1),
					new SqlParameter("@value2", SqlDbType.NVarChar,-1),
					new SqlParameter("@value3", SqlDbType.NVarChar,-1),
					new SqlParameter("@value4", SqlDbType.NVarChar,-1),
					new SqlParameter("@value5", SqlDbType.NVarChar,-1),
					new SqlParameter("@value6", SqlDbType.NVarChar,-1),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime)};
            parameters[0].Value = model.form_name;
            parameters[1].Value = model.rft_sid;
            parameters[2].Value = model.url;
            parameters[3].Value = model.rf_status;
            parameters[4].Value = model.content_str;
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

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Maticsoft.Model.request_form model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update request_form set ");
            strSql.Append("form_name=@form_name,");
            strSql.Append("rft_sid=@rft_sid,");
            strSql.Append("url=@url,");
            strSql.Append("rf_status=@rf_status,");
            strSql.Append("content_str=@content_str,");
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
					new SqlParameter("@form_name", SqlDbType.NVarChar,10),
					new SqlParameter("@rft_sid", SqlDbType.Int,4),
					new SqlParameter("@url", SqlDbType.NVarChar,200),
					new SqlParameter("@rf_status", SqlDbType.Int,4),
					new SqlParameter("@content_str", SqlDbType.Text),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@value1", SqlDbType.NVarChar,-1),
					new SqlParameter("@value2", SqlDbType.NVarChar,-1),
					new SqlParameter("@value3", SqlDbType.NVarChar,-1),
					new SqlParameter("@value4", SqlDbType.NVarChar,-1),
					new SqlParameter("@value5", SqlDbType.NVarChar,-1),
					new SqlParameter("@value6", SqlDbType.NVarChar,-1),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.Int,4)};
            parameters[0].Value = model.form_name;
            parameters[1].Value = model.rft_sid;
            parameters[2].Value = model.url;
            parameters[3].Value = model.rf_status;
            parameters[4].Value = model.content_str;
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

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from request_form ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string sidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from request_form ");
            strSql.Append(" where sid in (" + sidlist + ")  ");
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.request_form GetModel(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sid,form_name,rft_sid,url,rf_status,content_str,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date from request_form ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

            Maticsoft.Model.request_form model = new Maticsoft.Model.request_form();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Maticsoft.Model.request_form DataRowToModel(DataRow row)
        {
            Maticsoft.Model.request_form model = new Maticsoft.Model.request_form();
            if (row != null)
            {
                if (row["sid"] != null && row["sid"].ToString() != "")
                {
                    model.sid = int.Parse(row["sid"].ToString());
                }
                if (row["form_name"] != null)
                {
                    model.form_name = row["form_name"].ToString();
                }
                if (row["rft_sid"] != null && row["rft_sid"].ToString() != "")
                {
                    model.rft_sid = int.Parse(row["rft_sid"].ToString());
                }
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
                if (row["rf_status"] != null && row["rf_status"].ToString() != "")
                {
                    model.rf_status = int.Parse(row["rf_status"].ToString());
                }
                if (row["content_str"] != null)
                {
                    model.content_str = row["content_str"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["value1"] != null)
                {
                    model.value1 = row["value1"].ToString();
                }
                if (row["value2"] != null)
                {
                    model.value2 = row["value2"].ToString();
                }
                if (row["value3"] != null)
                {
                    model.value3 = row["value3"].ToString();
                }
                if (row["value4"] != null)
                {
                    model.value4 = row["value4"].ToString();
                }
                if (row["value5"] != null)
                {
                    model.value5 = row["value5"].ToString();
                }
                if (row["value6"] != null)
                {
                    model.value6 = row["value6"].ToString();
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
                if (row["create_person"] != null)
                {
                    model.create_person = row["create_person"].ToString();
                }
                if (row["create_date"] != null && row["create_date"].ToString() != "")
                {
                    model.create_date = DateTime.Parse(row["create_date"].ToString());
                }
                if (row["update_person"] != null)
                {
                    model.update_person = row["update_person"].ToString();
                }
                if (row["update_date"] != null && row["update_date"].ToString() != "")
                {
                    model.update_date = DateTime.Parse(row["update_date"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sid,form_name,rft_sid,url,rf_status,content_str,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM request_form ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" sid,form_name,rft_sid,url,rf_status,content_str,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM request_form ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM request_form ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.sid desc");
            }
            strSql.Append(")AS Row, T.*  from request_form T ");
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
            parameters[0].Value = "request_form";
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
        public bool Edit(List<Model.request_form> insertList, List<Model.request_form> updateList, List<Model.request_form> delList)
        {
            ArrayList al = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            //删除
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.request_form model = delList[i];
                sbSql.Append("delete from request_form where sid=" + model.sid);
                al.Add(sbSql.ToString());
            }
            //修改
            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.request_form model = updateList[i];
                sbSql.Append("update request_form set form_name = '" + model.form_name.Trim() + "',");
                sbSql.Append("rft_sid = '" + model.rft_sid.ToString().Trim() + "',");
                sbSql.Append("url = '" + model.url.ToString().Trim() + "',");
                sbSql.Append("rf_status = '" + model.rf_status.ToString().Trim() + "'");
                sbSql.Append(" where sid = '" + model.sid.ToString().Trim() + "'");
                al.Add(sbSql.ToString());
            }
            //添加
            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.request_form model = insertList[i];
                sbSql.Append("insert into request_form(form_name, rft_sid,url,rf_status");
                sbSql.Append(")values(");
                sbSql.Append("'" + model.form_name.Trim() + "','" + model.rft_sid.ToString().Trim() + "','" + model.url.ToString().Trim() + "','" + model.rf_status.ToString().Trim() + "'");
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

