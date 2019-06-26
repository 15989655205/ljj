using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:BaseUser
	/// </summary>
	public partial class BaseUser
	{
		public BaseUser()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BaseUser");
			strSql.Append(" where UserName=@UserName ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)			};
			parameters[0].Value = UserName;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public bool Exists(string UserName,string UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(1) from BaseUser ");
            strSql.Append(" where UserName=@UserName and UserID!=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@UserID", SqlDbType.BigInt)};
            parameters[0].Value = UserName;
            parameters[1].Value = UserID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Maticsoft.Model.BaseUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BaseUser(");
			strSql.Append("DeptID,Roles,UserName,Pwd,Name,Tel,WorkID,CreatedDate,CreatedGuy)");
			strSql.Append(" values (");
			strSql.Append("@DeptID,@Roles,@UserName,@Pwd,@Name,@Tel,@WorkID,@CreatedDate,@CreatedGuy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@Roles", SqlDbType.NVarChar,100),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Pwd", SqlDbType.NVarChar,100),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkID", SqlDbType.NVarChar,50),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedGuy", SqlDbType.Int,4)};
			parameters[0].Value = model.DeptID;
			parameters[1].Value = model.Roles;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Pwd;
			parameters[4].Value = model.Name;
			parameters[5].Value = model.Tel;
			parameters[6].Value = model.WorkID;
			parameters[7].Value = model.CreatedDate;
			parameters[8].Value = model.CreatedGuy;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}

        public bool Insert(Maticsoft.Model.BaseUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BaseUser(");
            strSql.Append("DeptID,Roles,UserName,Pwd,Name,Tel,WorkID)");
            strSql.Append(" values (");
            strSql.Append("@DeptID,@Roles,@UserName,@Pwd,@Name,@Tel,@WorkID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@Roles", SqlDbType.NVarChar,100),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Pwd", SqlDbType.NVarChar,100),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkID", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.DeptID;
            parameters[1].Value = model.Roles;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.Pwd;
            parameters[4].Value = model.Name;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.WorkID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Maticsoft.Model.BaseUser model)
		{
           
			StringBuilder strSql=new StringBuilder();
			strSql.Append(" update BaseUser set ");			
			strSql.Append(" Roles=@Roles, ");
			strSql.Append(" Pwd=@Pwd, ");
            strSql.Append(" UserName=@UserName, ");
            strSql.Append(" Permissions=@Permissions ");
			strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Roles", SqlDbType.NVarChar,100),
					new SqlParameter("@Pwd", SqlDbType.NVarChar,100),					
					new SqlParameter("@UserID", SqlDbType.BigInt,8),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Permissions", SqlDbType.Int)
                                        };
			parameters[0].Value = model.Roles;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.UserID;
			parameters[3].Value = model.UserName;
            parameters[4].Value = model.Permissions;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);			
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdatePwd(Maticsoft.Model.BaseUser model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update BaseUser set ");           
            strSql.Append(" Pwd=@Pwd, ");           
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters =
            {
			    new SqlParameter("@Pwd", SqlDbType.NVarChar,100),
				new SqlParameter("@UserName", SqlDbType.NVarChar,100)
            };
            parameters[1].Value = model.Pwd;
            parameters[2].Value = model.UserID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseUser ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)
			};
			parameters[0].Value = UserID;

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
		public bool Delete(string UserName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseUser ");
			strSql.Append(" where UserName=@UserName ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100)			};
			parameters[0].Value = UserName;

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
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseUser ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
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

        public string Deletes(string UserIDlist)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from BaseUser ");
                strSql.Append(" where UserID in (" + UserIDlist + ")  ");
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
                if (rows > 0)
                {
                    return "success";
                }
                else
                {
                    return "删除失败！";
                }
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.BaseUser GetModel(long UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 UserID,DeptID,Roles,UserName,Pwd,Name,Tel,WorkID,CreatedDate,CreatedGuy,ApprRole,Permissions,Value0 from BaseUser ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)
			};
			parameters[0].Value = UserID;

			Maticsoft.Model.BaseUser model=new Maticsoft.Model.BaseUser();
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
        public Maticsoft.Model.BaseUser GetModel(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,DeptID,Roles,UserName,Pwd,Name,Tel,WorkID,CreatedDate,CreatedGuy,ApprRole,Permissions,Value0 from BaseUser ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = UserName;

            Maticsoft.Model.BaseUser model = new Maticsoft.Model.BaseUser();
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
		public Maticsoft.Model.BaseUser DataRowToModel(DataRow row)
		{
			Maticsoft.Model.BaseUser model=new Maticsoft.Model.BaseUser();
			if (row != null)
			{
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(row["UserID"].ToString());
				}
				if(row["DeptID"]!=null && row["DeptID"].ToString()!="")
				{
					model.DeptID=int.Parse(row["DeptID"].ToString());
				}
				if(row["Roles"]!=null)
				{
					model.Roles=row["Roles"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Pwd"]!=null)
				{
					model.Pwd=row["Pwd"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Tel"]!=null)
				{
					model.Tel=row["Tel"].ToString();
				}
				if(row["WorkID"]!=null)
				{
					model.WorkID=row["WorkID"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["CreatedGuy"]!=null && row["CreatedGuy"].ToString()!="")
				{
					model.CreatedGuy=int.Parse(row["CreatedGuy"].ToString());
				}
                if (row["ApprRole"] != null && row["ApprRole"].ToString() != "")
                {
                    model.ApprRole = row["ApprRole"].ToString();
                }
                if (row["Permissions"] != null && row["Permissions"].ToString() != "")
                {
                    model.Permissions = int.Parse(row["Permissions"].ToString());
                }
                if (row["Value0"]!=null&&row["Value0"].ToString()!="")
                {
                    model.Value0 = row["Value0"].ToString();
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
			strSql.Append("select UserID,DeptID,Roles,UserName,Pwd,Name,Tel,WorkID,CreatedDate,CreatedGuy ");
			strSql.Append(" FROM BaseUser ");
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
			strSql.Append(" UserID,DeptID,Roles,UserName,Pwd,Name,Tel,WorkID,CreatedDate,CreatedGuy ");
			strSql.Append(" FROM BaseUser ");
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
			strSql.Append("select count(1) FROM BaseUser ");
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
				strSql.Append("order by T.UserID desc");
			}
			strSql.Append(")AS Row, T.*  from BaseUser T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}


        public bool GetUserDownloadFlag(long userid)
        {
            return DbHelperSQL.Exists(" select * from BaseUser where Value1=1 and UserID=" + userid);
        }
        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, out int rcount)
        {
            //SqlParameter[] parameters = {
            //        new SqlParameter("@ActionType", SqlDbType.NVarChar,20),
            //        new SqlParameter("@PageSize",SqlDbType.Int),
            //        new SqlParameter("@PageIndex",SqlDbType.Int),
            //        new SqlParameter("@Where",SqlDbType.NVarChar),
            //        new SqlParameter("@RecordCount",SqlDbType.BigInt),
            //        new SqlParameter("@Error",SqlDbType.NVarChar,200),
            //        new SqlParameter("@RoleIDS",SqlDbType.NVarChar,50)
            //                            };
            //parameters[0].Value = "Query1";
            //parameters[1].Value = PageSize;
            //parameters[2].Value = PageIndex;
            //parameters[3].Value = strWhere;
            //parameters[4].Value = ParameterDirection.Output;
            //parameters[5].Value = ParameterDirection.Output;
            //parameters[6].Value = ParameterDirection.Output;
            //rcount = 0;
            //return DbHelperSQL.RunProcedure("Sp_BaseUser", parameters, "ds");
            return DbHelperSQL.ProcPage("Sp_BaseUser", "Query1", PageIndex, PageSize, strWhere, out rcount);
        }

        public DataSet GetList(string tableName, string orderFile, string showField, int page, int rows, out int count, string orderType, string where)
        {
            return DbHelperSQL.GetList_ProcPage(tableName, orderFile, showField, page, rows, out count, orderType, where);
        }

        public DataSet RunUSerProc(string type,string uid,string pid,string roler,string uname,string pwd,string pwd1,int PageSize, int PageIndex, string strWhere,string tel,string wid,out int rcount,out string error,out string rids)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ActionType", SqlDbType.NVarChar,20),
                    new SqlParameter("@UserID", SqlDbType.NVarChar, 200),
                    new SqlParameter("@DeptID", SqlDbType.Int),
                    new SqlParameter("@Roles", SqlDbType.NVarChar,100),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@Name", SqlDbType.NVarChar,10),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar,100),
                    new SqlParameter("@Pwd1", SqlDbType.NVarChar,100),
                    new SqlParameter("@PageSize",SqlDbType.Int),
                    new SqlParameter("@PageIndex",SqlDbType.Int),
                    new SqlParameter("@Where",SqlDbType.NVarChar),
                    new SqlParameter("@Tel",SqlDbType.NVarChar,50),
                    new SqlParameter("@WorkID",SqlDbType.NVarChar,50),
                    new SqlParameter("@RecordCount",SqlDbType.BigInt),
                    new SqlParameter("@Error",SqlDbType.NVarChar,200),
                    new SqlParameter("@RoleIDS",SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = type;
            parameters[1].Value = uid;
            parameters[2].Value = pid;
            parameters[3].Value = roler;
            parameters[4].Value = uname;
            parameters[5].Value = pwd;
            parameters[6].Value = pwd1;
            parameters[7].Value = PageSize;
            parameters[8].Value = PageIndex;
            parameters[9].Value = strWhere;
            parameters[10].Value = tel;
            parameters[11].Value = wid;
            parameters[12].Value = ParameterDirection.Output;
            parameters[13].Value = ParameterDirection.Output;
            parameters[14].Value = ParameterDirection.Output;
            
            DataSet ds= DbHelperSQL.RunProcedure("Sp_BaseUser", parameters, "ds");

            if (parameters[12].Value != System.DBNull.Value)
            {
                //执行转换跟下面的代码
                rcount = Convert.ToInt32(parameters[7].Value);
            }
            else
                rcount = 0;
            error = parameters[13].Value.ToString().Trim();
            rids = parameters[14].Value.ToString().Trim();
            return ds;
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

