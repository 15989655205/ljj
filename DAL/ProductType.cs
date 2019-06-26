using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:ProductType
	/// </summary>
	public partial class ProductType
	{
		public ProductType()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductType");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Maticsoft.Model.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductType(");
			strSql.Append("ParentID,Code,Name,Level,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate)");
			strSql.Append(" values (");
			strSql.Append("@ParentID,@Code,@Name,@Level,@Enabled,@Status,@Remark,@Value0,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
					new SqlParameter("@Value0", SqlDbType.NVarChar),
					new SqlParameter("@Value1", SqlDbType.NVarChar),
					new SqlParameter("@Value2", SqlDbType.NVarChar),
					new SqlParameter("@Value3", SqlDbType.NVarChar),
					new SqlParameter("@Value4", SqlDbType.NVarChar),
					new SqlParameter("@Value5", SqlDbType.NVarChar),
					new SqlParameter("@Value6", SqlDbType.NVarChar),
					new SqlParameter("@Value7", SqlDbType.NVarChar),
					new SqlParameter("@Value8", SqlDbType.NVarChar),
					new SqlParameter("@Value9", SqlDbType.NVarChar),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Level;
			parameters[4].Value = model.Enabled;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.Value0;
			parameters[8].Value = model.Value1;
			parameters[9].Value = model.Value2;
			parameters[10].Value = model.Value3;
			parameters[11].Value = model.Value4;
			parameters[12].Value = model.Value5;
			parameters[13].Value = model.Value6;
			parameters[14].Value = model.Value7;
			parameters[15].Value = model.Value8;
			parameters[16].Value = model.Value9;
			parameters[17].Value = model.CreateUser;
			parameters[18].Value = model.CreateDate;
			parameters[19].Value = model.UpdateUser;
			parameters[20].Value = model.UpdateDate;

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
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductType set ");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("Code=@Code,");
			strSql.Append("Name=@Name,");
			strSql.Append("Level=@Level,");
			strSql.Append("Enabled=@Enabled,");
			strSql.Append("Status=@Status,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("Value0=@Value0,");
			strSql.Append("Value1=@Value1,");
			strSql.Append("Value2=@Value2,");
			strSql.Append("Value3=@Value3,");
			strSql.Append("Value4=@Value4,");
			strSql.Append("Value5=@Value5,");
			strSql.Append("Value6=@Value6,");
			strSql.Append("Value7=@Value7,");
			strSql.Append("Value8=@Value8,");
			strSql.Append("Value9=@Value9,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateUser=@UpdateUser,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
					new SqlParameter("@Value0", SqlDbType.NVarChar),
					new SqlParameter("@Value1", SqlDbType.NVarChar),
					new SqlParameter("@Value2", SqlDbType.NVarChar),
					new SqlParameter("@Value3", SqlDbType.NVarChar),
					new SqlParameter("@Value4", SqlDbType.NVarChar),
					new SqlParameter("@Value5", SqlDbType.NVarChar),
					new SqlParameter("@Value6", SqlDbType.NVarChar),
					new SqlParameter("@Value7", SqlDbType.NVarChar),
					new SqlParameter("@Value8", SqlDbType.NVarChar),
					new SqlParameter("@Value9", SqlDbType.NVarChar),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.ParentID;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Level;
			parameters[4].Value = model.Enabled;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.Value0;
			parameters[8].Value = model.Value1;
			parameters[9].Value = model.Value2;
			parameters[10].Value = model.Value3;
			parameters[11].Value = model.Value4;
			parameters[12].Value = model.Value5;
			parameters[13].Value = model.Value6;
			parameters[14].Value = model.Value7;
			parameters[15].Value = model.Value8;
			parameters[16].Value = model.Value9;
			parameters[17].Value = model.CreateUser;
			parameters[18].Value = model.CreateDate;
			parameters[19].Value = model.UpdateUser;
			parameters[20].Value = model.UpdateDate;
			parameters[21].Value = model.ID;

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
		public bool Delete(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductType ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductType ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Maticsoft.Model.ProductType GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ParentID,Code,Name,Level,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from ProductType ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.ProductType model=new Maticsoft.Model.ProductType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ParentID"]!=null && ds.Tables[0].Rows[0]["ParentID"].ToString()!="")
				{
					model.ParentID=long.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Code"]!=null && ds.Tables[0].Rows[0]["Code"].ToString()!="")
				{
					model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Level"]!=null && ds.Tables[0].Rows[0]["Level"].ToString()!="")
				{
					model.Level=int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Enabled"]!=null && ds.Tables[0].Rows[0]["Enabled"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Enabled"].ToString()=="1")||(ds.Tables[0].Rows[0]["Enabled"].ToString().ToLower()=="true"))
					{
						model.Enabled=true;
					}
					else
					{
						model.Enabled=false;
					}
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value0"]!=null && ds.Tables[0].Rows[0]["Value0"].ToString()!="")
				{
					model.Value0=ds.Tables[0].Rows[0]["Value0"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value1"]!=null && ds.Tables[0].Rows[0]["Value1"].ToString()!="")
				{
					model.Value1=ds.Tables[0].Rows[0]["Value1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value2"]!=null && ds.Tables[0].Rows[0]["Value2"].ToString()!="")
				{
					model.Value2=ds.Tables[0].Rows[0]["Value2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value3"]!=null && ds.Tables[0].Rows[0]["Value3"].ToString()!="")
				{
					model.Value3=ds.Tables[0].Rows[0]["Value3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value4"]!=null && ds.Tables[0].Rows[0]["Value4"].ToString()!="")
				{
					model.Value4=ds.Tables[0].Rows[0]["Value4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value5"]!=null && ds.Tables[0].Rows[0]["Value5"].ToString()!="")
				{
					model.Value5=ds.Tables[0].Rows[0]["Value5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value6"]!=null && ds.Tables[0].Rows[0]["Value6"].ToString()!="")
				{
					model.Value6=ds.Tables[0].Rows[0]["Value6"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value7"]!=null && ds.Tables[0].Rows[0]["Value7"].ToString()!="")
				{
					model.Value7=ds.Tables[0].Rows[0]["Value7"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value8"]!=null && ds.Tables[0].Rows[0]["Value8"].ToString()!="")
				{
					model.Value8=ds.Tables[0].Rows[0]["Value8"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value9"]!=null && ds.Tables[0].Rows[0]["Value9"].ToString()!="")
				{
					model.Value9=ds.Tables[0].Rows[0]["Value9"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreateUser"]!=null && ds.Tables[0].Rows[0]["CreateUser"].ToString()!="")
				{
					model.CreateUser=ds.Tables[0].Rows[0]["CreateUser"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreateDate"]!=null && ds.Tables[0].Rows[0]["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdateUser"]!=null && ds.Tables[0].Rows[0]["UpdateUser"].ToString()!="")
				{
					model.UpdateUser=ds.Tables[0].Rows[0]["UpdateUser"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UpdateDate"]!=null && ds.Tables[0].Rows[0]["UpdateDate"].ToString()!="")
				{
					model.UpdateDate=DateTime.Parse(ds.Tables[0].Rows[0]["UpdateDate"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.ProductType GetModel(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ParentID,Code,Name,Level,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from ProductType ");
            strSql.Append(" where Name=@name");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar)
			};
            parameters[0].Value = name;

            Maticsoft.Model.ProductType model = new Maticsoft.Model.ProductType();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Code"] != null && ds.Tables[0].Rows[0]["Code"].ToString() != "")
                {
                    model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Level"] != null && ds.Tables[0].Rows[0]["Level"].ToString() != "")
                {
                    model.Level = int.Parse(ds.Tables[0].Rows[0]["Level"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Enabled"] != null && ds.Tables[0].Rows[0]["Enabled"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Enabled"].ToString() == "1") || (ds.Tables[0].Rows[0]["Enabled"].ToString().ToLower() == "true"))
                    {
                        model.Enabled = true;
                    }
                    else
                    {
                        model.Enabled = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value0"] != null && ds.Tables[0].Rows[0]["Value0"].ToString() != "")
                {
                    model.Value0 = ds.Tables[0].Rows[0]["Value0"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value1"] != null && ds.Tables[0].Rows[0]["Value1"].ToString() != "")
                {
                    model.Value1 = ds.Tables[0].Rows[0]["Value1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value2"] != null && ds.Tables[0].Rows[0]["Value2"].ToString() != "")
                {
                    model.Value2 = ds.Tables[0].Rows[0]["Value2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value3"] != null && ds.Tables[0].Rows[0]["Value3"].ToString() != "")
                {
                    model.Value3 = ds.Tables[0].Rows[0]["Value3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value4"] != null && ds.Tables[0].Rows[0]["Value4"].ToString() != "")
                {
                    model.Value4 = ds.Tables[0].Rows[0]["Value4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value5"] != null && ds.Tables[0].Rows[0]["Value5"].ToString() != "")
                {
                    model.Value5 = ds.Tables[0].Rows[0]["Value5"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value6"] != null && ds.Tables[0].Rows[0]["Value6"].ToString() != "")
                {
                    model.Value6 = ds.Tables[0].Rows[0]["Value6"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value7"] != null && ds.Tables[0].Rows[0]["Value7"].ToString() != "")
                {
                    model.Value7 = ds.Tables[0].Rows[0]["Value7"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value8"] != null && ds.Tables[0].Rows[0]["Value8"].ToString() != "")
                {
                    model.Value8 = ds.Tables[0].Rows[0]["Value8"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value9"] != null && ds.Tables[0].Rows[0]["Value9"].ToString() != "")
                {
                    model.Value9 = ds.Tables[0].Rows[0]["Value9"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreateUser"] != null && ds.Tables[0].Rows[0]["CreateUser"].ToString() != "")
                {
                    model.CreateUser = ds.Tables[0].Rows[0]["CreateUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreateDate"] != null && ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateUser"] != null && ds.Tables[0].Rows[0]["UpdateUser"].ToString() != "")
                {
                    model.UpdateUser = ds.Tables[0].Rows[0]["UpdateUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UpdateDate"] != null && ds.Tables[0].Rows[0]["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateDate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append(" select ID, ParentID, Code, Name, '('+Code+')'+Name CodeName, Level, Enabled, Status, Remark, ");
            strSql.Append("     Value0 Value1, Value2, Value3, Value4, Value5, Value6, Value7, Value8, Value9, ");
            strSql.Append("     dbo.getUserName_fu(CreateUser)CreateUser, convert(nvarchar,CreateDate,120)CreateDate, ");
            strSql.Append("     dbo.getUserName_fu(UpdateUser)UpdateUser, convert(nvarchar,UpdateDate,120)UpdateDate ");
			strSql.Append(" from ProductType ");
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
			strSql.Append(" ID,ParentID,Code,Name,Level,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
			strSql.Append(" FROM ProductType ");
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
			strSql.Append("select count(1) FROM ProductType ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductType T ");
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
			parameters[0].Value = "ProductType";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

