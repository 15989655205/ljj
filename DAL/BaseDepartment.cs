using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:BaseDepartment
	/// </summary>
	public partial class BaseDepartment
	{
		public BaseDepartment()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DeptID", "BaseDepartment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DeptID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BaseDepartment");
			strSql.Append(" where DeptID=@DeptID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4)			};
			parameters[0].Value = DeptID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.BaseDepartment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BaseDepartment(");
			strSql.Append("ParentDeptID,DeptName,CreatedDate,CreatedGuy,UpdatedDate,UpdatedGuy,Remark,DeptIDs,Value1,Value2,Value3,Value4,Value5)");
			strSql.Append(" values (");
			strSql.Append("@ParentDeptID,@DeptName,@CreatedDate,@CreatedGuy,@UpdatedDate,@UpdatedGuy,@Remark,@DeptIDs,@Value1,@Value2,@Value3,@Value4,@Value5)");
			SqlParameter[] parameters = {					
					new SqlParameter("@ParentDeptID", SqlDbType.Int,4),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,100),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedGuy", SqlDbType.Int,4),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedGuy", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
					new SqlParameter("@DeptIDs", SqlDbType.NVarChar),
					new SqlParameter("@Value1", SqlDbType.NVarChar),
					new SqlParameter("@Value2", SqlDbType.NVarChar),
					new SqlParameter("@Value3", SqlDbType.NVarChar),
					new SqlParameter("@Value4", SqlDbType.NVarChar),
					new SqlParameter("@Value5", SqlDbType.NVarChar)};			
			parameters[0].Value = model.ParentDeptID;
			parameters[1].Value = model.DeptName;
			parameters[2].Value = model.CreatedDate;
			parameters[3].Value = model.CreatedGuy;
			parameters[4].Value = model.UpdatedDate;
			parameters[5].Value = model.UpdatedGuy;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.DeptIDs;
			parameters[8].Value = model.Value1;
			parameters[9].Value = model.Value2;
			parameters[10].Value = model.Value3;
			parameters[11].Value = model.Value4;
			parameters[12].Value = model.Value5;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.BaseDepartment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BaseDepartment set ");
			strSql.Append("ParentDeptID=@ParentDeptID,");
			strSql.Append("DeptName=@DeptName,");			
			strSql.Append("UpdatedDate=@UpdatedDate,");
			strSql.Append("UpdatedGuy=@UpdatedGuy,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("DeptIDs=@DeptIDs,");
			strSql.Append("Value1=@Value1,");
			strSql.Append("Value2=@Value2,");
			strSql.Append("Value3=@Value3,");
			strSql.Append("Value4=@Value4,");
			strSql.Append("Value5=@Value5");
			strSql.Append(" where DeptID=@DeptID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ParentDeptID", SqlDbType.Int,4),
					new SqlParameter("@DeptName", SqlDbType.NVarChar,100),					
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@UpdatedGuy", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
					new SqlParameter("@DeptIDs", SqlDbType.NVarChar),
					new SqlParameter("@Value1", SqlDbType.NVarChar),
					new SqlParameter("@Value2", SqlDbType.NVarChar),
					new SqlParameter("@Value3", SqlDbType.NVarChar),
					new SqlParameter("@Value4", SqlDbType.NVarChar),
					new SqlParameter("@Value5", SqlDbType.NVarChar),
					new SqlParameter("@DeptID", SqlDbType.Int,4)};
			parameters[0].Value = model.ParentDeptID;
			parameters[1].Value = model.DeptName;		
			parameters[2].Value = model.UpdatedDate;
			parameters[3].Value = model.UpdatedGuy;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.DeptIDs;
			parameters[6].Value = model.Value1;
			parameters[7].Value = model.Value2;
			parameters[8].Value = model.Value3;
			parameters[9].Value = model.Value4;
			parameters[10].Value = model.Value5;
			parameters[11].Value = model.DeptID;

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
		public bool Delete(int DeptID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseDepartment ");
			strSql.Append(" where DeptID=@DeptID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4)			};
			parameters[0].Value = DeptID;

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
		public bool DeleteList(string DeptIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append(" DELETE FROM BaseDepartment ");
			strSql.Append(" WHERE DeptID IN("+DeptIDlist + ") ");
            strSql.Append("     AND DeptID NOT IN(SELECT DeptID FROM BaseUser WHERE DeptID IS NOT NULL ");
            strSql.Append("         UNION ");
            strSql.Append("         SELECT ParentDeptID FROM BaseDepartment WHERE ParentDeptID IS NOT NULL ");
            strSql.Append("     )");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
            return DeptIDlist.Split(',').Length == rows;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.BaseDepartment GetModel(int DeptID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DeptID,ParentDeptID,DeptName,CreatedDate,CreatedGuy,UpdatedDate,UpdatedGuy,Remark,DeptIDs,Value1,Value2,Value3,Value4,Value5 from BaseDepartment ");
			strSql.Append(" where DeptID=@DeptID ");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4)			};
			parameters[0].Value = DeptID;

			Maticsoft.Model.BaseDepartment model=new Maticsoft.Model.BaseDepartment();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["DeptID"]!=null && ds.Tables[0].Rows[0]["DeptID"].ToString()!="")
				{
					model.DeptID=int.Parse(ds.Tables[0].Rows[0]["DeptID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ParentDeptID"]!=null && ds.Tables[0].Rows[0]["ParentDeptID"].ToString()!="")
				{
					model.ParentDeptID=int.Parse(ds.Tables[0].Rows[0]["ParentDeptID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DeptName"]!=null && ds.Tables[0].Rows[0]["DeptName"].ToString()!="")
				{
					model.DeptName=ds.Tables[0].Rows[0]["DeptName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedDate"]!=null && ds.Tables[0].Rows[0]["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedGuy"]!=null && ds.Tables[0].Rows[0]["CreatedGuy"].ToString()!="")
				{
					model.CreatedGuy=int.Parse(ds.Tables[0].Rows[0]["CreatedGuy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedDate"]!=null && ds.Tables[0].Rows[0]["UpdatedDate"].ToString()!="")
				{
					model.UpdatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdatedGuy"]!=null && ds.Tables[0].Rows[0]["UpdatedGuy"].ToString()!="")
				{
					model.UpdatedGuy=int.Parse(ds.Tables[0].Rows[0]["UpdatedGuy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DeptIDs"]!=null && ds.Tables[0].Rows[0]["DeptIDs"].ToString()!="")
				{
					model.DeptIDs=ds.Tables[0].Rows[0]["DeptIDs"].ToString();
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
			strSql.Append("select DeptID,ParentDeptID,DeptName,CreatedDate,CreatedGuy,UpdatedDate,UpdatedGuy,Remark,DeptIDs,Value1,Value2,Value3,Value4,Value5 ");
			strSql.Append(" FROM BaseDepartment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string value, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT " + value + " ");
            strSql.Append(" FROM BaseDepartment ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
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
			strSql.Append(" DeptID,ParentDeptID,DeptName,CreatedDate,CreatedGuy,UpdatedDate,UpdatedGuy,Remark,DeptIDs,Value1,Value2,Value3,Value4,Value5 ");
			strSql.Append(" FROM BaseDepartment ");
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
			strSql.Append("select count(1) FROM BaseDepartment ");
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
				strSql.Append("order by T.DeptID desc");
			}
			strSql.Append(")AS Row, T.*  from BaseDepartment T ");
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
			parameters[0].Value = "BaseDepartment";
			parameters[1].Value = "DeptID";
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