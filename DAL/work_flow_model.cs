using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;//Please add references
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:work_flow_model
    /// </summary>
    public partial class work_flow_model
    {
        public work_flow_model()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.work_flow_model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into work_flow_model(");
            strSql.Append("work_flow_name,remark,SN,Status,value1,value2,value3,value4,value5,n1,n2,n3,n4,create_person,create_date,update_person,update_date)");
            strSql.Append(" values (");
            strSql.Append("@work_flow_name,@remark,@SN,@Status,@value1,@value2,@value3,@value4,@value5,@n1,@n2,@n3,@n4,@create_person,@create_date,@update_person,@update_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@work_flow_name", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@SN", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@value1", SqlDbType.NVarChar,50),
					new SqlParameter("@value2", SqlDbType.NVarChar,50),
					new SqlParameter("@value3", SqlDbType.NVarChar,50),
					new SqlParameter("@value4", SqlDbType.NVarChar,50),
					new SqlParameter("@value5", SqlDbType.NVarChar,50),
					new SqlParameter("@n1", SqlDbType.Int,4),
					new SqlParameter("@n2", SqlDbType.Int,4),
					new SqlParameter("@n3", SqlDbType.Int,4),
					new SqlParameter("@n4", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,1),
					new SqlParameter("@update_date", SqlDbType.DateTime)};
            parameters[0].Value = model.work_flow_name;
            parameters[1].Value = model.remark;
            parameters[2].Value = model.SN;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.value1;
            parameters[5].Value = model.value2;
            parameters[6].Value = model.value3;
            parameters[7].Value = model.value4;
            parameters[8].Value = model.value5;
            parameters[9].Value = model.n1;
            parameters[10].Value = model.n2;
            parameters[11].Value = model.n3;
            parameters[12].Value = model.n4;
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
        public bool Update(Maticsoft.Model.work_flow_model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update work_flow_model set ");
            strSql.Append("work_flow_name=@work_flow_name,");
            strSql.Append("remark=@remark,");
            strSql.Append("SN=@SN,");
            strSql.Append("Status=@Status,");
            strSql.Append("value1=@value1,");
            strSql.Append("value2=@value2,");
            strSql.Append("value3=@value3,");
            strSql.Append("value4=@value4,");
            strSql.Append("value5=@value5,");
            strSql.Append("n1=@n1,");
            strSql.Append("n2=@n2,");
            strSql.Append("n3=@n3,");
            strSql.Append("n4=@n4,");
            strSql.Append("create_person=@create_person,");
            strSql.Append("create_date=@create_date,");
            strSql.Append("update_person=@update_person,");
            strSql.Append("update_date=@update_date");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@work_flow_name", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@SN", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@value1", SqlDbType.NVarChar,50),
					new SqlParameter("@value2", SqlDbType.NVarChar,50),
					new SqlParameter("@value3", SqlDbType.NVarChar,50),
					new SqlParameter("@value4", SqlDbType.NVarChar,50),
					new SqlParameter("@value5", SqlDbType.NVarChar,50),
					new SqlParameter("@n1", SqlDbType.Int,4),
					new SqlParameter("@n2", SqlDbType.Int,4),
					new SqlParameter("@n3", SqlDbType.Int,4),
					new SqlParameter("@n4", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,1),
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.work_flow_name;
            parameters[1].Value = model.remark;
            parameters[2].Value = model.SN;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.value1;
            parameters[5].Value = model.value2;
            parameters[6].Value = model.value3;
            parameters[7].Value = model.value4;
            parameters[8].Value = model.value5;
            parameters[9].Value = model.n1;
            parameters[10].Value = model.n2;
            parameters[11].Value = model.n3;
            parameters[12].Value = model.n4;
            parameters[13].Value = model.create_person;
            parameters[14].Value = model.create_date;
            parameters[15].Value = model.update_person;
            parameters[16].Value = model.update_date;
            parameters[17].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from work_flow_model ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from work_flow_model ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Maticsoft.Model.work_flow_model GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,work_flow_name,remark,SN,Status,value1,value2,value3,value4,value5,n1,n2,n3,n4,create_person,create_date,update_person,update_date from work_flow_model ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Maticsoft.Model.work_flow_model model = new Maticsoft.Model.work_flow_model();
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
        public Maticsoft.Model.work_flow_model DataRowToModel(DataRow row)
        {
            Maticsoft.Model.work_flow_model model = new Maticsoft.Model.work_flow_model();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["work_flow_name"] != null)
                {
                    model.work_flow_name = row["work_flow_name"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["SN"] != null && row["SN"].ToString() != "")
                {
                    model.SN = int.Parse(row["SN"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
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
                if (row["n1"] != null && row["n1"].ToString() != "")
                {
                    model.n1 = int.Parse(row["n1"].ToString());
                }
                if (row["n2"] != null && row["n2"].ToString() != "")
                {
                    model.n2 = int.Parse(row["n2"].ToString());
                }
                if (row["n3"] != null && row["n3"].ToString() != "")
                {
                    model.n3 = int.Parse(row["n3"].ToString());
                }
                if (row["n4"] != null && row["n4"].ToString() != "")
                {
                    model.n4 = int.Parse(row["n4"].ToString());
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
            strSql.Append("select id,work_flow_name,remark,SN,Status,value1,value2,value3,value4,value5,n1,n2,n3,n4,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM work_flow_model ");
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
            strSql.Append(" id,work_flow_name,remark,SN,Status,value1,value2,value3,value4,value5,n1,n2,n3,n4,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM work_flow_model ");
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
            strSql.Append("select count(1) FROM work_flow_model ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from work_flow_model T ");
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
            parameters[0].Value = "work_flow_model";
            parameters[1].Value = "id";
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

        public bool Edit(List<Model.work_flow_model> insertList, List<Model.work_flow_model> updateList, List<Model.work_flow_model> delList, List<Model.work_flow_model> sequenceList)
        {
            ArrayList al = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            //删除
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.work_flow_model model = delList[i];
                sbSql.Append("delete from work_flow_model where id=" + model.id);
                al.Add(sbSql.ToString());
            }
            //修改
            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.work_flow_model model = updateList[i];
                sbSql.Append("update work_flow_model set work_flow_name = '" + model.work_flow_name.Trim() + "',");
                sbSql.Append("remark = '" + model.remark.Trim() + "',");
                sbSql.Append("SN='" + model.SN.ToString().Trim() + "'");
                sbSql.Append(" where id = '" + model.id.ToString().Trim() + "'");
                al.Add(sbSql.ToString());
            }
            //添加
            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.work_flow_model model = insertList[i];
                sbSql.Append("insert into work_flow_model(work_flow_name, remark,SN,create_person,create_date");
                sbSql.Append(")values(");
                sbSql.Append("'" + model.work_flow_name.Trim() + "','" + model.remark.Trim()+"','"+model.SN + "','"+model.create_person+"','"+model.create_date+"'");
                sbSql.Append(")");
                al.Add(sbSql.ToString());
            }
            //排序
            for (int i = 0; i < sequenceList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.work_flow_model model = sequenceList[i];
                if (model.id != null && model.id.ToString().Trim() != "0" && model.id.ToString().Trim() != "")
                {
                    sbSql.Append("update work_flow_model set SN = " + model.SN.ToString().Trim());
                    sbSql.Append(" where id = " + model.id.ToString().Trim() + "");
                    al.Add(sbSql.ToString());
                }
            }

            DbHelperSQL.ExecuteSqlTran(al);

            return true;
        }

        #region  ExtensionMethod
        public bool Edit(List<Model.work_flow_model> insertList, List<Model.work_flow_model> updateList, List<Model.work_flow_model> delList,List<Model.work_flow_model> SN, string uid)
        {
            ArrayList al = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            //删除
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.work_flow_model model = delList[i];
                sbSql.Append("delete from work_flow_model where id=" + model.id);
                al.Add(sbSql.ToString());
            }
            //修改
            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.work_flow_model model = updateList[i];
                sbSql.Append("update work_flow_model set work_flow_name = '" + model.work_flow_name.Trim() + "',");
                sbSql.Append("remark = '" + model.remark.Trim() + "',");
                sbSql.Append("SN='" + model.SN.ToString().Trim() + "',");
                sbSql.Append("update_person = '" + uid + "',");
                sbSql.Append("update_date = getdate()  ");
                sbSql.Append(" where id = '" + model.id.ToString().Trim() + "'");
                al.Add(sbSql.ToString());
            }
            //添加
            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.work_flow_model model = insertList[i];
                sbSql.Append("insert into work_flow_model(work_flow_name, remark,SN,create_person,create_date");
                sbSql.Append(")values(");
                sbSql.Append("'" + model.work_flow_name.Trim() + "','" + model.remark.Trim() + "','" + model.SN + "','" + uid + "',getdate()");
                sbSql.Append(")");
                al.Add(sbSql.ToString());
            }

            for (int i = 0; i < SN.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.work_flow_model model = SN[i];
                if (model.id != null && model.id.ToString().Trim() != "0" && model.id.ToString().Trim() != "")
                {
                    sbSql.Append("update work_flow_model set SN = " + model.SN.ToString().Trim());
                    //sbSql.Append("");
                    sbSql.Append(" where id = " + model.id.ToString().Trim() + "");
                    al.Add(sbSql.ToString());
                }
            }

            DbHelperSQL.ExecuteSqlTran(al);

            return true;
        }
        #endregion
    }
}
