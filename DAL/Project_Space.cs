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
    /// 数据访问类:Project_Space
    /// </summary>
    public partial class Project_Space
    {
        public Project_Space()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Project_Space");
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
        public int Add(Maticsoft.Model.Project_Space model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Project_Space(");
            strSql.Append("name,p_sid,show_column,sequence,parentID,isChild,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date)");
            strSql.Append(" values (");
            strSql.Append("@name,@p_sid,@show_column,@sequence,@parentID,@isChild,@remark,@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@n1,@n2,@n3,@show,@show_name,@status,@create_person,@create_date,@update_person,@update_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@p_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@show_column", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4),
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@isChild", SqlDbType.Int,4),
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
					new SqlParameter("@n1", SqlDbType.Int,4),
					new SqlParameter("@n2", SqlDbType.Int,4),
					new SqlParameter("@n3", SqlDbType.Int,4),
					new SqlParameter("@show", SqlDbType.NVarChar,100),
					new SqlParameter("@show_name", SqlDbType.NVarChar,500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.p_sid;
            parameters[2].Value = model.show_column;
            parameters[3].Value = model.sequence;
            parameters[4].Value = model.parentID;
            parameters[5].Value = model.isChild;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.v1;
            parameters[8].Value = model.v2;
            parameters[9].Value = model.v3;
            parameters[10].Value = model.v4;
            parameters[11].Value = model.v5;
            parameters[12].Value = model.v6;
            parameters[13].Value = model.v7;
            parameters[14].Value = model.v8;
            parameters[15].Value = model.v9;
            parameters[16].Value = model.v10;
            parameters[17].Value = model.n1;
            parameters[18].Value = model.n2;
            parameters[19].Value = model.n3;
            parameters[20].Value = model.show;
            parameters[21].Value = model.show_name;
            parameters[22].Value = model.status;
            parameters[23].Value = model.create_person;
            parameters[24].Value = model.create_date;
            parameters[25].Value = model.update_person;
            parameters[26].Value = model.update_date;

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
        public bool Update(Maticsoft.Model.Project_Space model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Project_Space set ");
            strSql.Append("name=@name,");
            strSql.Append("p_sid=@p_sid,");
            strSql.Append("show_column=@show_column,");
            strSql.Append("sequence=@sequence,");
            strSql.Append("parentID=@parentID,");
            strSql.Append("isChild=@isChild,");
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
            strSql.Append("n1=@n1,");
            strSql.Append("n2=@n2,");
            strSql.Append("n3=@n3,");
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
					new SqlParameter("@p_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@show_column", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4),
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@isChild", SqlDbType.Int,4),
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
					new SqlParameter("@n1", SqlDbType.Int,4),
					new SqlParameter("@n2", SqlDbType.Int,4),
					new SqlParameter("@n3", SqlDbType.Int,4),
					new SqlParameter("@show", SqlDbType.NVarChar,100),
					new SqlParameter("@show_name", SqlDbType.NVarChar,500),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.p_sid;
            parameters[2].Value = model.show_column;
            parameters[3].Value = model.sequence;
            parameters[4].Value = model.parentID;
            parameters[5].Value = model.isChild;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.v1;
            parameters[8].Value = model.v2;
            parameters[9].Value = model.v3;
            parameters[10].Value = model.v4;
            parameters[11].Value = model.v5;
            parameters[12].Value = model.v6;
            parameters[13].Value = model.v7;
            parameters[14].Value = model.v8;
            parameters[15].Value = model.v9;
            parameters[16].Value = model.v10;
            parameters[17].Value = model.n1;
            parameters[18].Value = model.n2;
            parameters[19].Value = model.n3;
            parameters[20].Value = model.show;
            parameters[21].Value = model.show_name;
            parameters[22].Value = model.status;
            parameters[23].Value = model.create_person;
            parameters[24].Value = model.create_date;
            parameters[25].Value = model.update_person;
            parameters[26].Value = model.update_date;
            parameters[27].Value = model.sid;

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
            strSql.Append("delete from Project_Space ");
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
            strSql.Append("delete from Project_Space ");
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
        public Maticsoft.Model.Project_Space GetModel(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sid,name,p_sid,show_column,sequence,parentID,isChild,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date from Project_Space ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

            Maticsoft.Model.Project_Space model = new Maticsoft.Model.Project_Space();
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
        public Maticsoft.Model.Project_Space DataRowToModel(DataRow row)
        {
            Maticsoft.Model.Project_Space model = new Maticsoft.Model.Project_Space();
            if (row != null)
            {
                if (row["sid"] != null && row["sid"].ToString() != "")
                {
                    model.sid = int.Parse(row["sid"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["p_sid"] != null)
                {
                    model.p_sid = row["p_sid"].ToString();
                }
                if (row["show_column"] != null)
                {
                    model.show_column = row["show_column"].ToString();
                }
                if (row["sequence"] != null && row["sequence"].ToString() != "")
                {
                    model.sequence = int.Parse(row["sequence"].ToString());
                }
                if (row["parentID"] != null && row["parentID"].ToString() != "")
                {
                    model.parentID = int.Parse(row["parentID"].ToString());
                }
                if (row["isChild"] != null && row["isChild"].ToString() != "")
                {
                    model.isChild = int.Parse(row["isChild"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["v1"] != null)
                {
                    model.v1 = row["v1"].ToString();
                }
                if (row["v2"] != null)
                {
                    model.v2 = row["v2"].ToString();
                }
                if (row["v3"] != null)
                {
                    model.v3 = row["v3"].ToString();
                }
                if (row["v4"] != null)
                {
                    model.v4 = row["v4"].ToString();
                }
                if (row["v5"] != null)
                {
                    model.v5 = row["v5"].ToString();
                }
                if (row["v6"] != null)
                {
                    model.v6 = row["v6"].ToString();
                }
                if (row["v7"] != null)
                {
                    model.v7 = row["v7"].ToString();
                }
                if (row["v8"] != null)
                {
                    model.v8 = row["v8"].ToString();
                }
                if (row["v9"] != null)
                {
                    model.v9 = row["v9"].ToString();
                }
                if (row["v10"] != null)
                {
                    model.v10 = row["v10"].ToString();
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
                if (row["show"] != null)
                {
                    model.show = row["show"].ToString();
                }
                if (row["show_name"] != null)
                {
                    model.show_name = row["show_name"].ToString();
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
            strSql.Append("select ps1.sid,ps1.name ps1name,ps2.parentID,ps2.name ps2name,ps2.sequence,ps2.remark,ps1.isChild ps1isChild,ps2.isChild ps2isChild,ps1.sid  ps1sid,ps2.sid  ps2sid  from Project_Space ps1"
+"	left join Project_Space ps2 on ps2.parentID=ps1.sid"
+"	left join	project p on ps1.p_sid=p.sid  "

 +"");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere + " order by ps1.sid,ps2.sequence  ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  DISTINCT name from Project_Space ");
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
            strSql.Append(" sid,name,p_sid,show_column,sequence,parentID,isChild,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM Project_Space ");
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
            strSql.Append("select count(1) FROM Project_Space ");
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
            strSql.Append(")AS Row, T.*  from Project_Space T ");
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
            parameters[0].Value = "Project_Space";
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="insertList"></param>
        /// <param name="updateList"></param>
        /// <param name="delList"></param>
        /// <param name="psid">项目ID project</param>
        /// <returns></returns>
        public string Edit(List<Model.Project_Space> insertList, List<Model.Project_Space> updateList, List<Model.Project_Space> delList, List<Model.Project_Space> allList, int psid)
        {

                
            try
            {
                ArrayList al = new ArrayList();
                StringBuilder sbSql = new StringBuilder();
                //删除
                for (int i = 0; i < delList.Count; i++)
                {
                    sbSql = new StringBuilder();
                    Model.Project_Space model = delList[i];
                    sbSql.Append("delete from Project_Space where sid=" + model.Ps2sid + ";");
                    al.Add(sbSql.ToString());
                }

                //修改
                int sequence = 0;
                for (int i = 0; i < allList.Count; i++)
                {
                    sbSql = new StringBuilder();
                    Model.Project_Space model = allList[i];

                    if (allList[i].Ps1name != "")
                    {
                        if (allList[i].Ps1isChild == 0)
                        {
                       

                            sbSql.Append("update Project_Space set name = '" + model.Ps1name.Trim() + "',sequence='" + 0 + "'");
                            sbSql.Append(" where sid = '" + model.Ps1sid + "'");
                            al.Add(sbSql.ToString());
                        }
                    }
                    if (allList[i].Ps1name != "")
                    {
                        if (i > 1)
                        {
                            if (allList[i].Ps1name != allList[i - 1].Ps1name)
                            {
                                sequence = 1;
                                model.sequence = sequence;
                                sbSql.Append("update Project_Space set name = '" + model.Ps2name.Trim() + "',sequence='" + model.sequence + "'");
                                sbSql.Append(" where sid = '" + model.Ps2sid.ToString().Trim() + "'");
                                al.Add(sbSql.ToString());
                            }
                            else
                            {
                                sequence += 1;
                                model.sequence = sequence;
                                sbSql.Append("update Project_Space set name = '" + model.Ps2name.Trim() + "',sequence='" + model.sequence + "'");
                                sbSql.Append(" where sid = '" + model.Ps2sid.ToString().Trim() + "'");
                                al.Add(sbSql.ToString());
                            }
                        }
                        else
                        {

                                sequence += 1;
                                model.sequence = sequence;
                                sbSql.Append("update Project_Space set name = '" + model.Ps2name.Trim() + "',sequence='" + model.sequence + "'");
                                sbSql.Append(" where sid = '" + model.Ps2sid.ToString().Trim() + "'");
                                al.Add(sbSql.ToString());
                            
                        }
                    }
                }

                ArrayList ar = new ArrayList();
                int n = 0;
                int num = 1; //计数器


                //添加
                int getID=0;
                for (int i = 0; i < insertList.Count; i++)
                {
                    Model.Project_Space model = insertList[i];

                    //判断空间名字是否已经存在，true为不存在,否则不插入根节点
                    //Ps1name为根节点，Ps2name为子节点
                    if (insertList[i].Ps1name != "" && Get(insertList[i], out getID) == true)
                    {
                        //添加父类数据
                        sbSql = new StringBuilder();
                        sbSql.Append("insert into Project_Space(name,p_sid,sequence,parentID,isChild");
                        sbSql.Append(")values(");
                        sbSql.Append("'" + model.Ps1name.Trim() + "','" + psid + "',0,'" + model.parentID + "',0");
                        sbSql.Append(");select @@IDENTITY ");
                        ar.Add(DbHelperSQL.GetSingle(sbSql.ToString()));
                    }

                    if (model.Ps2name != "" && Get(insertList[i], out getID) == true)
                    {
                        //添加子类数据
                        sbSql = new StringBuilder();
                        sbSql.Append("insert into Project_Space(name,p_sid,sequence,parentID,isChild");
                        sbSql.Append(")values(");
                        sbSql.Append("'" + model.Ps2name.Trim() + "','" + psid + "'," + 0+ ",'" +ar[i] + "',1");
                        sbSql.Append(")");
                        al.Add(sbSql.ToString());
                    }
                    else
                    {
                            //添加子类数据
                            sbSql = new StringBuilder();
                            sbSql.Append("insert into Project_Space(name,p_sid,sequence,parentID,isChild");
                            sbSql.Append(")values(");
                            sbSql.Append("'" + model.Ps2name + "','" + psid + "'," + num++ + ",'" + getID + "',1");
                            sbSql.Append(")");
                            al.Add(sbSql.ToString());
                        
                    }
                }

                DbHelperSQL.ExecuteSqlTran(al);

                return "success";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        //判断根节点是否相同，相同返回false，否则为true，带出相同的根节点ID
        public bool Get(Model.Project_Space  model, out int getID)
        {
                 int sid=0;
                string getName = "select * from Project_Space  where isChild=0";
                DataSet ds= DbHelperSQL.Query(getName);
                bool isExist=true;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["name"].ToString() == Convert.ToString(model.Ps1name))
                    {
                        isExist = false;
                        sid =Convert.ToInt32( ds.Tables[0].Rows[i]["sid"]);
                        
                        break;
                    }
                }

                  getID = sid;
                return isExist;
        }

        #endregion  ExtensionMethod
    }
}

