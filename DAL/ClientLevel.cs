using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:ClientLevel
	/// </summary>
	public partial class ClientLevel
	{
		public ClientLevel()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ClientLevel");
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
		public long Add(Maticsoft.Model.ClientLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ClientLevel(");
			strSql.Append("Code,Name,ReferencePrice,Percentage,Remark,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate)");
			strSql.Append(" values (");
			strSql.Append("@Code,@Name,@ReferencePrice,@Percentage,@Remark,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@CreateUser,@CreateDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@ReferencePrice", SqlDbType.Int,4),
					new SqlParameter("@Percentage", SqlDbType.Float,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
					new SqlParameter("@Value1", SqlDbType.NVarChar),
					new SqlParameter("@Value2", SqlDbType.NVarChar),
					new SqlParameter("@Value3", SqlDbType.NVarChar),
					new SqlParameter("@Value4", SqlDbType.NVarChar),
					new SqlParameter("@Value5", SqlDbType.NVarChar),
					new SqlParameter("@Value6", SqlDbType.NVarChar),
					new SqlParameter("@Value7", SqlDbType.NVarChar),
					new SqlParameter("@Value8", SqlDbType.NVarChar),
					new SqlParameter("@Value9", SqlDbType.NVarChar),
					new SqlParameter("@CreateUser", SqlDbType.BigInt,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.ReferencePrice;
			parameters[3].Value = model.Percentage;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.Value1;
			parameters[6].Value = model.Value2;
			parameters[7].Value = model.Value3;
			parameters[8].Value = model.Value4;
			parameters[9].Value = model.Value5;
			parameters[10].Value = model.Value6;
			parameters[11].Value = model.Value7;
			parameters[12].Value = model.Value8;
			parameters[13].Value = model.Value9;
			parameters[14].Value = model.CreateUser;
			parameters[15].Value = model.CreateDate;		

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
		public bool Update(Maticsoft.Model.ClientLevel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ClientLevel set ");			
			strSql.Append("Name=@Name,");
			strSql.Append("ReferencePrice=@ReferencePrice,");
			strSql.Append("Percentage=@Percentage,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("Value1=@Value1,");
			strSql.Append("Value2=@Value2,");
			strSql.Append("Value3=@Value3,");
			strSql.Append("Value4=@Value4,");
			strSql.Append("Value5=@Value5,");
			strSql.Append("Value6=@Value6,");
			strSql.Append("Value7=@Value7,");
			strSql.Append("Value8=@Value8,");
			strSql.Append("Value9=@Value9,");			
			strSql.Append("UpdateUser=@UpdateUser,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {					
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@ReferencePrice", SqlDbType.Int,4),
					new SqlParameter("@Percentage", SqlDbType.Float,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
					new SqlParameter("@Value1", SqlDbType.NVarChar),
					new SqlParameter("@Value2", SqlDbType.NVarChar),
					new SqlParameter("@Value3", SqlDbType.NVarChar),
					new SqlParameter("@Value4", SqlDbType.NVarChar),
					new SqlParameter("@Value5", SqlDbType.NVarChar),
					new SqlParameter("@Value6", SqlDbType.NVarChar),
					new SqlParameter("@Value7", SqlDbType.NVarChar),
					new SqlParameter("@Value8", SqlDbType.NVarChar),
					new SqlParameter("@Value9", SqlDbType.NVarChar),				
					new SqlParameter("@UpdateUser", SqlDbType.BigInt,8),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            int i = 0;
			parameters[i++].Value = model.Name;
            parameters[i++].Value = model.ReferencePrice;
            parameters[i++].Value = model.Percentage;
            parameters[i++].Value = model.Remark;
            parameters[i++].Value = model.Value1;
            parameters[i++].Value = model.Value2;
            parameters[i++].Value = model.Value3;
            parameters[i++].Value = model.Value4;
            parameters[i++].Value = model.Value5;
            parameters[i++].Value = model.Value6;
            parameters[i++].Value = model.Value7;
            parameters[i++].Value = model.Value8;
            parameters[i++].Value = model.Value9;
            parameters[i++].Value = model.UpdateUser;
            parameters[i++].Value = model.UpdateDate;
            parameters[i++].Value = model.ID;

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
			strSql.Append("delete from ClientLevel ");
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
			strSql.Append("delete from ClientLevel ");
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
		public Maticsoft.Model.ClientLevel GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Code,Name,ReferencePrice,Percentage,Remark,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from ClientLevel ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.ClientLevel model=new Maticsoft.Model.ClientLevel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Code"]!=null && ds.Tables[0].Rows[0]["Code"].ToString()!="")
				{
					model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReferencePrice"]!=null && ds.Tables[0].Rows[0]["ReferencePrice"].ToString()!="")
				{
					model.ReferencePrice=int.Parse(ds.Tables[0].Rows[0]["ReferencePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Percentage"]!=null && ds.Tables[0].Rows[0]["Percentage"].ToString()!="")
				{
					model.Percentage=decimal.Parse(ds.Tables[0].Rows[0]["Percentage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
					model.CreateUser=long.Parse(ds.Tables[0].Rows[0]["CreateUser"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateDate"]!=null && ds.Tables[0].Rows[0]["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdateUser"]!=null && ds.Tables[0].Rows[0]["UpdateUser"].ToString()!="")
				{
					model.UpdateUser=long.Parse(ds.Tables[0].Rows[0]["UpdateUser"].ToString());
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Code,Name,ReferencePrice,Percentage,Remark,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
			strSql.Append(" FROM ClientLevel ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        public DataSet GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID value, Name text from ClientLevel order by Code");            
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
			strSql.Append(" ID,Code,Name,ReferencePrice,Percentage,Remark,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
			strSql.Append(" FROM ClientLevel ");
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
			strSql.Append("select count(1) FROM ClientLevel ");
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
			strSql.Append(")AS Row, T.*  from ClientLevel T ");
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
			parameters[0].Value = "ClientLevel";
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

