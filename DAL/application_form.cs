/**  版本信息模板在安装目录下，可自行修改。
* application_form.cs
*
* 功 能： N/A
* 类 名： application_form
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-7-29 15:41:01   N/A    初版
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
	/// 数据访问类:application_form
	/// </summary>
	public partial class application_form
	{
		public application_form()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from application_form");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.application_form model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into application_form(");
            strSql.Append("af_name,af_content,applicant,applicant_date,valid,curr_node_no,recently_approver,rf_sid,rfs_sid,fm_sid,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date)");
            strSql.Append(" values (");
            strSql.Append("@af_name,@af_content,@applicant,@applicant_date,@valid,@curr_node_no,@recently_approver,@rf_sid,@rfs_sid,@fm_sid,@remark,@value1,@value2,@value3,@value4,@value5,@value6,@status,@create_person,@create_date,@update_person,@update_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@af_name", SqlDbType.NVarChar,50),
					new SqlParameter("@af_content", SqlDbType.Text),
					new SqlParameter("@applicant", SqlDbType.NVarChar,50),
					new SqlParameter("@applicant_date", SqlDbType.DateTime),
					new SqlParameter("@valid", SqlDbType.Bit,1),
					new SqlParameter("@curr_node_no", SqlDbType.NVarChar,200),
					new SqlParameter("@recently_approver", SqlDbType.NVarChar,50),
					new SqlParameter("@rf_sid", SqlDbType.Int,4),
					new SqlParameter("@rfs_sid", SqlDbType.Int,4),
					new SqlParameter("@fm_sid", SqlDbType.NVarChar,50),
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
            parameters[0].Value = model.af_name;
            parameters[1].Value = model.af_content;
            parameters[2].Value = model.applicant;
            parameters[3].Value = model.applicant_date;
            parameters[4].Value = model.valid;
            parameters[5].Value = model.curr_node_no;
            parameters[6].Value = model.recently_approver;
            parameters[7].Value = model.rf_sid;
            parameters[8].Value = model.rfs_sid;
            parameters[9].Value = model.fm_sid;
            parameters[10].Value = model.remark;
            parameters[11].Value = model.value1;
            parameters[12].Value = model.value2;
            parameters[13].Value = model.value3;
            parameters[14].Value = model.value4;
            parameters[15].Value = model.value5;
            parameters[16].Value = model.value6;
            parameters[17].Value = model.status;
            parameters[18].Value = model.create_person;
            parameters[19].Value = model.create_date;
            parameters[20].Value = model.update_person;
            parameters[21].Value = model.update_date;

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
        public bool Update(Maticsoft.Model.application_form model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update application_form set ");
            strSql.Append("af_name=@af_name,");
            strSql.Append("af_content=@af_content,");
            strSql.Append("applicant=@applicant,");
            strSql.Append("applicant_date=@applicant_date,");
            strSql.Append("valid=@valid,");
            strSql.Append("curr_node_no=@curr_node_no,");
            strSql.Append("recently_approver=@recently_approver,");
            strSql.Append("rf_sid=@rf_sid,");
            strSql.Append("rfs_sid=@rfs_sid,");
            strSql.Append("fm_sid=@fm_sid,");
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
					new SqlParameter("@af_name", SqlDbType.NVarChar,50),
					new SqlParameter("@af_content", SqlDbType.Text),
					new SqlParameter("@applicant", SqlDbType.NVarChar,50),
					new SqlParameter("@applicant_date", SqlDbType.DateTime),
					new SqlParameter("@valid", SqlDbType.Bit,1),
					new SqlParameter("@curr_node_no", SqlDbType.NVarChar,200),
					new SqlParameter("@recently_approver", SqlDbType.NVarChar,50),
					new SqlParameter("@rf_sid", SqlDbType.Int,4),
					new SqlParameter("@rfs_sid", SqlDbType.Int,4),
					new SqlParameter("@fm_sid", SqlDbType.NVarChar,50),
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
            parameters[0].Value = model.af_name;
            parameters[1].Value = model.af_content;
            parameters[2].Value = model.applicant;
            parameters[3].Value = model.applicant_date;
            parameters[4].Value = model.valid;
            parameters[5].Value = model.curr_node_no;
            parameters[6].Value = model.recently_approver;
            parameters[7].Value = model.rf_sid;
            parameters[8].Value = model.rfs_sid;
            parameters[9].Value = model.fm_sid;
            parameters[10].Value = model.remark;
            parameters[11].Value = model.value1;
            parameters[12].Value = model.value2;
            parameters[13].Value = model.value3;
            parameters[14].Value = model.value4;
            parameters[15].Value = model.value5;
            parameters[16].Value = model.value6;
            parameters[17].Value = model.status;
            parameters[18].Value = model.create_person;
            parameters[19].Value = model.create_date;
            parameters[20].Value = model.update_person;
            parameters[21].Value = model.update_date;
            parameters[22].Value = model.sid;

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
            strSql.Append("delete from application_form ");
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
            strSql.Append("delete from application_form ");
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
        public Maticsoft.Model.application_form GetModel(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sid,af_name,af_content,applicant,applicant_date,valid,curr_node_no,recently_approver,rf_sid,rfs_sid,fm_sid,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date from application_form ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

            Maticsoft.Model.application_form model = new Maticsoft.Model.application_form();
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
        public Maticsoft.Model.application_form DataRowToModel(DataRow row)
        {
            Maticsoft.Model.application_form model = new Maticsoft.Model.application_form();
            if (row != null)
            {
                if (row["sid"] != null && row["sid"].ToString() != "")
                {
                    model.sid = int.Parse(row["sid"].ToString());
                }
                if (row["af_name"] != null)
                {
                    model.af_name = row["af_name"].ToString();
                }
                if (row["af_content"] != null)
                {
                    model.af_content = row["af_content"].ToString();
                }
                if (row["applicant"] != null)
                {
                    model.applicant = row["applicant"].ToString();
                }
                if (row["applicant_date"] != null && row["applicant_date"].ToString() != "")
                {
                    model.applicant_date = DateTime.Parse(row["applicant_date"].ToString());
                }
                if (row["valid"] != null && row["valid"].ToString() != "")
                {
                    if ((row["valid"].ToString() == "1") || (row["valid"].ToString().ToLower() == "true"))
                    {
                        model.valid = true;
                    }
                    else
                    {
                        model.valid = false;
                    }
                }
                if (row["curr_node_no"] != null)
                {
                    model.curr_node_no = row["curr_node_no"].ToString();
                }
                if (row["recently_approver"] != null)
                {
                    model.recently_approver = row["recently_approver"].ToString();
                }
                if (row["rf_sid"] != null && row["rf_sid"].ToString() != "")
                {
                    model.rf_sid = int.Parse(row["rf_sid"].ToString());
                }
                if (row["rfs_sid"] != null && row["rfs_sid"].ToString() != "")
                {
                    model.rfs_sid = int.Parse(row["rfs_sid"].ToString());
                }
                if (row["fm_sid"] != null)
                {
                    model.fm_sid = row["fm_sid"].ToString();
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
            strSql.Append("select sid,af_name,af_content,applicant,applicant_date,valid,curr_node_no,recently_approver,rf_sid,rfs_sid,fm_sid,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM application_form ");
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
            strSql.Append(" sid,af_name,af_content,applicant,applicant_date,valid,curr_node_no,recently_approver,rf_sid,rfs_sid,fm_sid,remark,value1,value2,value3,value4,value5,value6,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM application_form ");
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
            strSql.Append("select count(1) FROM application_form ");
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
            strSql.Append(")AS Row, T.*  from application_form T ");
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
            parameters[0].Value = "application_form";
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
        public bool insert(Model.application_form model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ActionType", SqlDbType.NVarChar,20),
                    new SqlParameter("@af_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@af_content", SqlDbType.Text),
                    new SqlParameter("@applicant", SqlDbType.NVarChar,50),
                    new SqlParameter("@rf_sid", SqlDbType.Int,4),
                    new SqlParameter("@rfs_sid", SqlDbType.Int,4),
                    new SqlParameter("@fm_sid", SqlDbType.NVarChar,50),
                    new SqlParameter("@remark", SqlDbType.Text),
                    new SqlParameter("@sid", SqlDbType.Int,4),
                    new SqlParameter("@Error", SqlDbType.NVarChar,200),
                    new SqlParameter("@RecordCount", SqlDbType.Int)};
            parameters[0].Value = "Insert1";
            parameters[1].Value = model.af_name;
            parameters[2].Value = model.af_content;
            parameters[3].Value = model.applicant;
            parameters[4].Value = model.rf_sid;
            parameters[5].Value = model.rfs_sid;
            parameters[6].Value = model.fm_sid;
            parameters[7].Value = model.remark;
            parameters[8].Value = model.sid;
            parameters[9].Direction = ParameterDirection.Output;
            parameters[10].Direction = ParameterDirection.Output;
            DataSet ds= DbHelperSQL.RunProcedure("Proc_Application", parameters, "");
            return true;
        }

        public bool update(Model.application_form model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ActionType", SqlDbType.NVarChar,20),
                    new SqlParameter("@af_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@af_content", SqlDbType.Text),
                    new SqlParameter("@applicant", SqlDbType.NVarChar,50),
                    new SqlParameter("@rf_sid", SqlDbType.Int,4),
                    new SqlParameter("@rfs_sid", SqlDbType.Int,4),
                    new SqlParameter("@fm_sid", SqlDbType.NVarChar,50),
                    new SqlParameter("@remark", SqlDbType.Text),
                    new SqlParameter("@sid", SqlDbType.Int,4),
                    new SqlParameter("@Error", SqlDbType.NVarChar,200),
                    new SqlParameter("@RecordCount", SqlDbType.Int)};
            parameters[0].Value = "Update1";
            parameters[1].Value = model.af_name;
            parameters[2].Value = model.af_content;
            parameters[3].Value = model.applicant;
            parameters[4].Value = model.rf_sid;
            parameters[5].Value = model.rfs_sid;
            parameters[6].Value = model.fm_sid;
            parameters[7].Value = model.remark;
            parameters[8].Value = model.sid;
            parameters[9].Direction = ParameterDirection.Output;
            parameters[10].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Application", parameters, "");
            return true;
        }

        public bool delete(string sid)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ActionType", SqlDbType.NVarChar,20),
                    new SqlParameter("@sid", SqlDbType.Int,4),
                    new SqlParameter("@Error", SqlDbType.NVarChar,200),
                    new SqlParameter("@RecordCount", SqlDbType.Int)};
            parameters[0].Value = "Delete1";
            parameters[1].Value = sid;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Application", parameters, "");
            return true;
        }

        public bool handle(string afsid, string node, string dept, string role, string approver, string result, string resultStr, string remark)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ActionType", SqlDbType.NVarChar,20),
                    new SqlParameter("@af_sid", SqlDbType.Int,4),
            new SqlParameter("@node", SqlDbType.NVarChar,50),
            new SqlParameter("@uid", SqlDbType.NVarChar,50),
            new SqlParameter("@dept", SqlDbType.NVarChar,50),
            new SqlParameter("@role", SqlDbType.NVarChar,50),
            new SqlParameter("@approver", SqlDbType.NVarChar,50),
            new SqlParameter("@result", SqlDbType.Int,4),
            new SqlParameter("@resultStr", SqlDbType.NVarChar,50),
            new SqlParameter("@remark", SqlDbType.NVarChar,500),
                    new SqlParameter("@Error", SqlDbType.NVarChar,200)};
            parameters[0].Value = "Handle";
            parameters[1].Value = afsid;
            parameters[2].Value = node;
            parameters[3].Value = approver;
            parameters[4].Value = dept;
            parameters[5].Value = role;
            parameters[6].Value = approver;
            parameters[7].Value = result;
            parameters[8].Value = resultStr;
            parameters[9].Value = remark;
            parameters[10].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("Proc_HandleRequestForm", parameters, "");
            return true;
        }
		#endregion  ExtensionMethod
	}
}

