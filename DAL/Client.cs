using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Client
	/// </summary>
	public partial class Client
	{
		public Client()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Client");
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
		public long Add(Maticsoft.Model.Client model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Client(");
			strSql.Append("CLevel,Type,Code,Name,Address,Head,Phone,Tel,Fax,Email,BusinessLicense,Currency,Parities,ReconciliationDate,SetupDate,Supplier,BeginDate,EndDate,Enable,Status,Area,Industry,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate)");
			strSql.Append(" values (");
			strSql.Append("@CLevel,@Type,@Code,@Name,@Address,@Head,@Phone,@Tel,@Fax,@Email,@BusinessLicense,@Currency,@Parities,@ReconciliationDate,@SetupDate,@Supplier,@BeginDate,@EndDate,@Enable,@Status,@Area,@Industry,@Remark,@Value0,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@CreateUser,@CreateDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CLevel", SqlDbType.BigInt,8),
					new SqlParameter("@Type", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@Head", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessLicense", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency", SqlDbType.NVarChar,50),
					new SqlParameter("@Parities", SqlDbType.Float,8),
					new SqlParameter("@ReconciliationDate", SqlDbType.DateTime),
					new SqlParameter("@SetupDate", SqlDbType.DateTime),
					new SqlParameter("@Supplier", SqlDbType.Bit,1),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Area", SqlDbType.NVarChar),
					new SqlParameter("@Industry", SqlDbType.NVarChar),
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
					new SqlParameter("@CreateUser", SqlDbType.BigInt,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
			parameters[0].Value = model.CLevel;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Code;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Head;
			parameters[6].Value = model.Phone;
			parameters[7].Value = model.Tel;
			parameters[8].Value = model.Fax;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.BusinessLicense;
			parameters[11].Value = model.Currency;
			parameters[12].Value = model.Parities;
			parameters[13].Value = model.ReconciliationDate;
			parameters[14].Value = model.SetupDate;
			parameters[15].Value = model.Supplier;
			parameters[16].Value = model.BeginDate;
			parameters[17].Value = model.EndDate;
			parameters[18].Value = model.Enable;
			parameters[19].Value = model.Status;
			parameters[20].Value = model.Area;
			parameters[21].Value = model.Industry;
			parameters[22].Value = model.Remark;
			parameters[23].Value = model.Value0;
			parameters[24].Value = model.Value1;
			parameters[25].Value = model.Value2;
			parameters[26].Value = model.Value3;
			parameters[27].Value = model.Value4;
			parameters[28].Value = model.Value5;
			parameters[29].Value = model.Value6;
			parameters[30].Value = model.Value7;
			parameters[31].Value = model.Value8;
			parameters[32].Value = model.Value9;
			parameters[33].Value = model.CreateUser;
			parameters[34].Value = model.CreateDate;

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
		public bool Update(Maticsoft.Model.Client model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Client set ");
			strSql.Append("CLevel=@CLevel,");
			strSql.Append("Type=@Type,");
			strSql.Append("Code=@Code,");
			strSql.Append("Name=@Name,");
			strSql.Append("Address=@Address,");
			strSql.Append("Head=@Head,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("Email=@Email,");
			strSql.Append("BusinessLicense=@BusinessLicense,");
			strSql.Append("Currency=@Currency,");
			strSql.Append("Parities=@Parities,");
			strSql.Append("ReconciliationDate=@ReconciliationDate,");
			strSql.Append("SetupDate=@SetupDate,");
			strSql.Append("Supplier=@Supplier,");
			strSql.Append("BeginDate=@BeginDate,");
			strSql.Append("EndDate=@EndDate,");
			strSql.Append("Enable=@Enable,");
			strSql.Append("Status=@Status,");
			strSql.Append("Area=@Area,");
			strSql.Append("Industry=@Industry,");
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
			strSql.Append("UpdateUser=@UpdateUser,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@CLevel", SqlDbType.BigInt,8),
					new SqlParameter("@Type", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@Head", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@BusinessLicense", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency", SqlDbType.NVarChar,50),
					new SqlParameter("@Parities", SqlDbType.Float,8),
					new SqlParameter("@ReconciliationDate", SqlDbType.DateTime),
					new SqlParameter("@SetupDate", SqlDbType.DateTime),
					new SqlParameter("@Supplier", SqlDbType.Bit,1),
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Area", SqlDbType.NVarChar),
					new SqlParameter("@Industry", SqlDbType.NVarChar),
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
					new SqlParameter("@UpdateUser", SqlDbType.BigInt,8),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.CLevel;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Code;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Head;
			parameters[6].Value = model.Phone;
			parameters[7].Value = model.Tel;
			parameters[8].Value = model.Fax;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.BusinessLicense;
			parameters[11].Value = model.Currency;
			parameters[12].Value = model.Parities;
			parameters[13].Value = model.ReconciliationDate;
			parameters[14].Value = model.SetupDate;
			parameters[15].Value = model.Supplier;
			parameters[16].Value = model.BeginDate;
			parameters[17].Value = model.EndDate;
			parameters[18].Value = model.Enable;
			parameters[19].Value = model.Status;
			parameters[20].Value = model.Area;
			parameters[21].Value = model.Industry;
			parameters[22].Value = model.Remark;
			parameters[23].Value = model.Value0;
			parameters[24].Value = model.Value1;
			parameters[25].Value = model.Value2;
			parameters[26].Value = model.Value3;
			parameters[27].Value = model.Value4;
			parameters[28].Value = model.Value5;
			parameters[29].Value = model.Value6;
			parameters[30].Value = model.Value7;
			parameters[31].Value = model.Value8;
			parameters[32].Value = model.Value9;		
			parameters[33].Value = model.UpdateUser;
			parameters[34].Value = model.UpdateDate;
			parameters[35].Value = model.ID;

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
			strSql.Append("delete from Client ");
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
			strSql.Append("delete from Client ");
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
		public Maticsoft.Model.Client GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CLevel,Type,Code,Name,Address,Head,Phone,Tel,Fax,Email,BusinessLicense,Currency,Parities,ReconciliationDate,SetupDate,Supplier,BeginDate,EndDate,Enable,Status,Area,Industry,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from Client ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.Client model=new Maticsoft.Model.Client();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CLevel"]!=null && ds.Tables[0].Rows[0]["CLevel"].ToString()!="")
				{
					model.CLevel=long.Parse(ds.Tables[0].Rows[0]["CLevel"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type"]!=null && ds.Tables[0].Rows[0]["Type"].ToString()!="")
				{
					model.Type=long.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Code"]!=null && ds.Tables[0].Rows[0]["Code"].ToString()!="")
				{
					model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address"]!=null && ds.Tables[0].Rows[0]["Address"].ToString()!="")
				{
					model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Head"]!=null && ds.Tables[0].Rows[0]["Head"].ToString()!="")
				{
					model.Head=ds.Tables[0].Rows[0]["Head"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Phone"]!=null && ds.Tables[0].Rows[0]["Phone"].ToString()!="")
				{
					model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Tel"]!=null && ds.Tables[0].Rows[0]["Tel"].ToString()!="")
				{
					model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Fax"]!=null && ds.Tables[0].Rows[0]["Fax"].ToString()!="")
				{
					model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BusinessLicense"]!=null && ds.Tables[0].Rows[0]["BusinessLicense"].ToString()!="")
				{
					model.BusinessLicense=ds.Tables[0].Rows[0]["BusinessLicense"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Currency"]!=null && ds.Tables[0].Rows[0]["Currency"].ToString()!="")
				{
					model.Currency=ds.Tables[0].Rows[0]["Currency"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Parities"]!=null && ds.Tables[0].Rows[0]["Parities"].ToString()!="")
				{
					model.Parities=decimal.Parse(ds.Tables[0].Rows[0]["Parities"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReconciliationDate"]!=null && ds.Tables[0].Rows[0]["ReconciliationDate"].ToString()!="")
				{
					model.ReconciliationDate=DateTime.Parse(ds.Tables[0].Rows[0]["ReconciliationDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SetupDate"]!=null && ds.Tables[0].Rows[0]["SetupDate"].ToString()!="")
				{
					model.SetupDate=DateTime.Parse(ds.Tables[0].Rows[0]["SetupDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supplier"]!=null && ds.Tables[0].Rows[0]["Supplier"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Supplier"].ToString()=="1")||(ds.Tables[0].Rows[0]["Supplier"].ToString().ToLower()=="true"))
					{
						model.Supplier=true;
					}
					else
					{
						model.Supplier=false;
					}
				}
				if(ds.Tables[0].Rows[0]["BeginDate"]!=null && ds.Tables[0].Rows[0]["BeginDate"].ToString()!="")
				{
					model.BeginDate=DateTime.Parse(ds.Tables[0].Rows[0]["BeginDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EndDate"]!=null && ds.Tables[0].Rows[0]["EndDate"].ToString()!="")
				{
					model.EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Enable"]!=null && ds.Tables[0].Rows[0]["Enable"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Enable"].ToString()=="1")||(ds.Tables[0].Rows[0]["Enable"].ToString().ToLower()=="true"))
					{
						model.Enable=true;
					}
					else
					{
						model.Enable=false;
					}
				}
				if(ds.Tables[0].Rows[0]["Status"]!=null && ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Area"]!=null && ds.Tables[0].Rows[0]["Area"].ToString()!="")
				{
					model.Area=ds.Tables[0].Rows[0]["Area"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Industry"]!=null && ds.Tables[0].Rows[0]["Industry"].ToString()!="")
				{
					model.Industry=ds.Tables[0].Rows[0]["Industry"].ToString();
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
			strSql.Append("select ID,CLevel,Type,Code,Name,Address,Head,Phone,Tel,Fax,Email,BusinessLicense,Currency,Parities,ReconciliationDate,SetupDate,Supplier,BeginDate,EndDate,Enable,Status,Area,Industry,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
			strSql.Append(" FROM Client ");
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
			strSql.Append(" ID,CLevel,Type,Code,Name,Address,Head,Phone,Tel,Fax,Email,BusinessLicense,Currency,Parities,ReconciliationDate,SetupDate,Supplier,BeginDate,EndDate,Enable,Status,Area,Industry,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
			strSql.Append(" FROM Client ");
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
			strSql.Append("select count(1) FROM Client ");
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
			strSql.Append(")AS Row, T.*  from Client T ");
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
			parameters[0].Value = "Client";
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

