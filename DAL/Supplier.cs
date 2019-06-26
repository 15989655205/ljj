using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Supplier
	/// </summary>
	public partial class Supplier
	{
		public Supplier()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Supplier");
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
		public long Add(Maticsoft.Model.Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Supplier(");
			strSql.Append("TypeID,Code,Enabled,Abbreviation,FullName,EnAbbreviation,EnFullName,Address,EnAddress,Margin,TaxRate,TypeCode,Currency,ZipCode,PaymentTerms,Principal,Linkman,Buyer,PurchasingCycle,PurchasingCycleTable,PurchasingGoodsCycle,PaymentMethod,LandTransportation,SeaTransportation,AirTransportation,OtherTransportation,DepositBank,BankAccount,PSubject,POSubject,TSubject,PCProject,TCProject,Fixed,Fax,Mobile,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate)");
			strSql.Append(" values (");
			strSql.Append("@TypeID,@Code,@Enabled,@Abbreviation,@FullName,@EnAbbreviation,@EnFullName,@Address,@EnAddress,@Margin,@TaxRate,@TypeCode,@Currency,@ZipCode,@PaymentTerms,@Principal,@Linkman,@Buyer,@PurchasingCycle,@PurchasingCycleTable,@PurchasingGoodsCycle,@PaymentMethod,@LandTransportation,@SeaTransportation,@AirTransportation,@OtherTransportation,@DepositBank,@BankAccount,@PSubject,@POSubject,@TSubject,@PCProject,@TCProject,@Fixed,@Fax,@Mobile,@Status,@Remark,@Value0,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
					new SqlParameter("@Abbreviation", SqlDbType.NVarChar,50),
					new SqlParameter("@FullName", SqlDbType.NVarChar,50),
					new SqlParameter("@EnAbbreviation", SqlDbType.NVarChar,50),
					new SqlParameter("@EnFullName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@EnAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@Margin", SqlDbType.Money,8),
					new SqlParameter("@TaxRate", SqlDbType.Float,8),
					new SqlParameter("@TypeCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency", SqlDbType.NVarChar,50),
					new SqlParameter("@ZipCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PaymentTerms", SqlDbType.NVarChar,50),
					new SqlParameter("@Principal", SqlDbType.NVarChar,50),
					new SqlParameter("@Linkman", SqlDbType.NVarChar,50),
					new SqlParameter("@Buyer", SqlDbType.NVarChar,50),
					new SqlParameter("@PurchasingCycle", SqlDbType.NVarChar,50),
					new SqlParameter("@PurchasingCycleTable", SqlDbType.NVarChar,50),
					new SqlParameter("@PurchasingGoodsCycle", SqlDbType.NVarChar,50),
					new SqlParameter("@PaymentMethod", SqlDbType.NVarChar,50),
					new SqlParameter("@LandTransportation", SqlDbType.NVarChar,50),
					new SqlParameter("@SeaTransportation", SqlDbType.NVarChar,50),
					new SqlParameter("@AirTransportation", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherTransportation", SqlDbType.NVarChar,50),
					new SqlParameter("@DepositBank", SqlDbType.NVarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.NVarChar,50),
					new SqlParameter("@PSubject", SqlDbType.NVarChar,50),
					new SqlParameter("@POSubject", SqlDbType.NVarChar,50),
					new SqlParameter("@TSubject", SqlDbType.NVarChar,50),
					new SqlParameter("@PCProject", SqlDbType.NVarChar,50),
					new SqlParameter("@TCProject", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixed", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
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
			parameters[0].Value = model.TypeID;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Enabled;
			parameters[3].Value = model.Abbreviation;
			parameters[4].Value = model.FullName;
			parameters[5].Value = model.EnAbbreviation;
			parameters[6].Value = model.EnFullName;
			parameters[7].Value = model.Address;
			parameters[8].Value = model.EnAddress;
			parameters[9].Value = model.Margin;
			parameters[10].Value = model.TaxRate;
			parameters[11].Value = model.TypeCode;
			parameters[12].Value = model.Currency;
			parameters[13].Value = model.ZipCode;
			parameters[14].Value = model.PaymentTerms;
			parameters[15].Value = model.Principal;
			parameters[16].Value = model.Linkman;
			parameters[17].Value = model.Buyer;
			parameters[18].Value = model.PurchasingCycle;
			parameters[19].Value = model.PurchasingCycleTable;
			parameters[20].Value = model.PurchasingGoodsCycle;
			parameters[21].Value = model.PaymentMethod;
			parameters[22].Value = model.LandTransportation;
			parameters[23].Value = model.SeaTransportation;
			parameters[24].Value = model.AirTransportation;
			parameters[25].Value = model.OtherTransportation;
			parameters[26].Value = model.DepositBank;
			parameters[27].Value = model.BankAccount;
			parameters[28].Value = model.PSubject;
			parameters[29].Value = model.POSubject;
			parameters[30].Value = model.TSubject;
			parameters[31].Value = model.PCProject;
			parameters[32].Value = model.TCProject;
			parameters[33].Value = model.Fixed;
			parameters[34].Value = model.Fax;
			parameters[35].Value = model.Mobile;
			parameters[36].Value = model.Status;
			parameters[37].Value = model.Remark;
			parameters[38].Value = model.Value0;
			parameters[39].Value = model.Value1;
			parameters[40].Value = model.Value2;
			parameters[41].Value = model.Value3;
			parameters[42].Value = model.Value4;
			parameters[43].Value = model.Value5;
			parameters[44].Value = model.Value6;
			parameters[45].Value = model.Value7;
			parameters[46].Value = model.Value8;
			parameters[47].Value = model.Value9;
			parameters[48].Value = model.CreateUser;
			parameters[49].Value = model.CreateDate;
			parameters[50].Value = model.UpdateUser;
			parameters[51].Value = model.UpdateDate;

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
		public bool Update(Maticsoft.Model.Supplier model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Supplier set ");
			strSql.Append("TypeID=@TypeID,");
			strSql.Append("Code=@Code,");
			strSql.Append("Enabled=@Enabled,");
			strSql.Append("Abbreviation=@Abbreviation,");
			strSql.Append("FullName=@FullName,");
			strSql.Append("EnAbbreviation=@EnAbbreviation,");
			strSql.Append("EnFullName=@EnFullName,");
			strSql.Append("Address=@Address,");
			strSql.Append("EnAddress=@EnAddress,");
			strSql.Append("Margin=@Margin,");
			strSql.Append("TaxRate=@TaxRate,");
			strSql.Append("TypeCode=@TypeCode,");
			strSql.Append("Currency=@Currency,");
			strSql.Append("ZipCode=@ZipCode,");
			strSql.Append("PaymentTerms=@PaymentTerms,");
			strSql.Append("Principal=@Principal,");
			strSql.Append("Linkman=@Linkman,");
			strSql.Append("Buyer=@Buyer,");
			strSql.Append("PurchasingCycle=@PurchasingCycle,");
			strSql.Append("PurchasingCycleTable=@PurchasingCycleTable,");
			strSql.Append("PurchasingGoodsCycle=@PurchasingGoodsCycle,");
			strSql.Append("PaymentMethod=@PaymentMethod,");
			strSql.Append("LandTransportation=@LandTransportation,");
			strSql.Append("SeaTransportation=@SeaTransportation,");
			strSql.Append("AirTransportation=@AirTransportation,");
			strSql.Append("OtherTransportation=@OtherTransportation,");
			strSql.Append("DepositBank=@DepositBank,");
			strSql.Append("BankAccount=@BankAccount,");
			strSql.Append("PSubject=@PSubject,");
			strSql.Append("POSubject=@POSubject,");
			strSql.Append("TSubject=@TSubject,");
			strSql.Append("PCProject=@PCProject,");
			strSql.Append("TCProject=@TCProject,");
			strSql.Append("Fixed=@Fixed,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("Mobile=@Mobile,");
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
			strSql.Append("UpdateUser=@UpdateUser,");
			strSql.Append("UpdateDate=@UpdateDate");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
					new SqlParameter("@Abbreviation", SqlDbType.NVarChar,50),
					new SqlParameter("@FullName", SqlDbType.NVarChar,50),
					new SqlParameter("@EnAbbreviation", SqlDbType.NVarChar,50),
					new SqlParameter("@EnFullName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@EnAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@Margin", SqlDbType.Money,8),
					new SqlParameter("@TaxRate", SqlDbType.Float,8),
					new SqlParameter("@TypeCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Currency", SqlDbType.NVarChar,50),
					new SqlParameter("@ZipCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PaymentTerms", SqlDbType.NVarChar,50),
					new SqlParameter("@Principal", SqlDbType.NVarChar,50),
					new SqlParameter("@Linkman", SqlDbType.NVarChar,50),
					new SqlParameter("@Buyer", SqlDbType.NVarChar,50),
					new SqlParameter("@PurchasingCycle", SqlDbType.NVarChar,50),
					new SqlParameter("@PurchasingCycleTable", SqlDbType.NVarChar,50),
					new SqlParameter("@PurchasingGoodsCycle", SqlDbType.NVarChar,50),
					new SqlParameter("@PaymentMethod", SqlDbType.NVarChar,50),
					new SqlParameter("@LandTransportation", SqlDbType.NVarChar,50),
					new SqlParameter("@SeaTransportation", SqlDbType.NVarChar,50),
					new SqlParameter("@AirTransportation", SqlDbType.NVarChar,50),
					new SqlParameter("@OtherTransportation", SqlDbType.NVarChar,50),
					new SqlParameter("@DepositBank", SqlDbType.NVarChar,50),
					new SqlParameter("@BankAccount", SqlDbType.NVarChar,50),
					new SqlParameter("@PSubject", SqlDbType.NVarChar,50),
					new SqlParameter("@POSubject", SqlDbType.NVarChar,50),
					new SqlParameter("@TSubject", SqlDbType.NVarChar,50),
					new SqlParameter("@PCProject", SqlDbType.NVarChar,50),
					new SqlParameter("@TCProject", SqlDbType.NVarChar,50),
					new SqlParameter("@Fixed", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
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
					new SqlParameter("@UpdateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.TypeID;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Enabled;
			parameters[3].Value = model.Abbreviation;
			parameters[4].Value = model.FullName;
			parameters[5].Value = model.EnAbbreviation;
			parameters[6].Value = model.EnFullName;
			parameters[7].Value = model.Address;
			parameters[8].Value = model.EnAddress;
			parameters[9].Value = model.Margin;
			parameters[10].Value = model.TaxRate;
			parameters[11].Value = model.TypeCode;
			parameters[12].Value = model.Currency;
			parameters[13].Value = model.ZipCode;
			parameters[14].Value = model.PaymentTerms;
			parameters[15].Value = model.Principal;
			parameters[16].Value = model.Linkman;
			parameters[17].Value = model.Buyer;
			parameters[18].Value = model.PurchasingCycle;
			parameters[19].Value = model.PurchasingCycleTable;
			parameters[20].Value = model.PurchasingGoodsCycle;
			parameters[21].Value = model.PaymentMethod;
			parameters[22].Value = model.LandTransportation;
			parameters[23].Value = model.SeaTransportation;
			parameters[24].Value = model.AirTransportation;
			parameters[25].Value = model.OtherTransportation;
			parameters[26].Value = model.DepositBank;
			parameters[27].Value = model.BankAccount;
			parameters[28].Value = model.PSubject;
			parameters[29].Value = model.POSubject;
			parameters[30].Value = model.TSubject;
			parameters[31].Value = model.PCProject;
			parameters[32].Value = model.TCProject;
			parameters[33].Value = model.Fixed;
			parameters[34].Value = model.Fax;
			parameters[35].Value = model.Mobile;
			parameters[36].Value = model.Status;
			parameters[37].Value = model.Remark;
			parameters[38].Value = model.Value0;
			parameters[39].Value = model.Value1;
			parameters[40].Value = model.Value2;
			parameters[41].Value = model.Value3;
			parameters[42].Value = model.Value4;
			parameters[43].Value = model.Value5;
			parameters[44].Value = model.Value6;
			parameters[45].Value = model.Value7;
			parameters[46].Value = model.Value8;
			parameters[47].Value = model.Value9;
			parameters[48].Value = model.UpdateUser;
			parameters[49].Value = model.UpdateDate;
			parameters[50].Value = model.ID;

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
			strSql.Append("delete from Supplier ");
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
			strSql.Append("delete from Supplier ");
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
		public Maticsoft.Model.Supplier GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,TypeID,Code,Enabled,Abbreviation,FullName,EnAbbreviation,EnFullName,Address,EnAddress,Margin,TaxRate,TypeCode,Currency,ZipCode,PaymentTerms,Principal,Linkman,Buyer,PurchasingCycle,PurchasingCycleTable,PurchasingGoodsCycle,PaymentMethod,LandTransportation,SeaTransportation,AirTransportation,OtherTransportation,DepositBank,BankAccount,PSubject,POSubject,TSubject,PCProject,TCProject,Fixed,Fax,Mobile,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from Supplier ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.Supplier model=new Maticsoft.Model.Supplier();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TypeID"]!=null && ds.Tables[0].Rows[0]["TypeID"].ToString()!="")
				{
					model.TypeID=ds.Tables[0].Rows[0]["TypeID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Code"]!=null && ds.Tables[0].Rows[0]["Code"].ToString()!="")
				{
					model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
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
				if(ds.Tables[0].Rows[0]["Abbreviation"]!=null && ds.Tables[0].Rows[0]["Abbreviation"].ToString()!="")
				{
					model.Abbreviation=ds.Tables[0].Rows[0]["Abbreviation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FullName"]!=null && ds.Tables[0].Rows[0]["FullName"].ToString()!="")
				{
					model.FullName=ds.Tables[0].Rows[0]["FullName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EnAbbreviation"]!=null && ds.Tables[0].Rows[0]["EnAbbreviation"].ToString()!="")
				{
					model.EnAbbreviation=ds.Tables[0].Rows[0]["EnAbbreviation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EnFullName"]!=null && ds.Tables[0].Rows[0]["EnFullName"].ToString()!="")
				{
					model.EnFullName=ds.Tables[0].Rows[0]["EnFullName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address"]!=null && ds.Tables[0].Rows[0]["Address"].ToString()!="")
				{
					model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EnAddress"]!=null && ds.Tables[0].Rows[0]["EnAddress"].ToString()!="")
				{
					model.EnAddress=ds.Tables[0].Rows[0]["EnAddress"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Margin"]!=null && ds.Tables[0].Rows[0]["Margin"].ToString()!="")
				{
					model.Margin=decimal.Parse(ds.Tables[0].Rows[0]["Margin"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TaxRate"]!=null && ds.Tables[0].Rows[0]["TaxRate"].ToString()!="")
				{
					model.TaxRate=decimal.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TypeCode"]!=null && ds.Tables[0].Rows[0]["TypeCode"].ToString()!="")
				{
					model.TypeCode=ds.Tables[0].Rows[0]["TypeCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Currency"]!=null && ds.Tables[0].Rows[0]["Currency"].ToString()!="")
				{
					model.Currency=ds.Tables[0].Rows[0]["Currency"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ZipCode"]!=null && ds.Tables[0].Rows[0]["ZipCode"].ToString()!="")
				{
					model.ZipCode=ds.Tables[0].Rows[0]["ZipCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PaymentTerms"]!=null && ds.Tables[0].Rows[0]["PaymentTerms"].ToString()!="")
				{
					model.PaymentTerms=ds.Tables[0].Rows[0]["PaymentTerms"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Principal"]!=null && ds.Tables[0].Rows[0]["Principal"].ToString()!="")
				{
					model.Principal=ds.Tables[0].Rows[0]["Principal"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Linkman"]!=null && ds.Tables[0].Rows[0]["Linkman"].ToString()!="")
				{
					model.Linkman=ds.Tables[0].Rows[0]["Linkman"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Buyer"]!=null && ds.Tables[0].Rows[0]["Buyer"].ToString()!="")
				{
					model.Buyer=ds.Tables[0].Rows[0]["Buyer"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PurchasingCycle"]!=null && ds.Tables[0].Rows[0]["PurchasingCycle"].ToString()!="")
				{
					model.PurchasingCycle=ds.Tables[0].Rows[0]["PurchasingCycle"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PurchasingCycleTable"]!=null && ds.Tables[0].Rows[0]["PurchasingCycleTable"].ToString()!="")
				{
					model.PurchasingCycleTable=ds.Tables[0].Rows[0]["PurchasingCycleTable"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PurchasingGoodsCycle"]!=null && ds.Tables[0].Rows[0]["PurchasingGoodsCycle"].ToString()!="")
				{
					model.PurchasingGoodsCycle=ds.Tables[0].Rows[0]["PurchasingGoodsCycle"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PaymentMethod"]!=null && ds.Tables[0].Rows[0]["PaymentMethod"].ToString()!="")
				{
					model.PaymentMethod=ds.Tables[0].Rows[0]["PaymentMethod"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LandTransportation"]!=null && ds.Tables[0].Rows[0]["LandTransportation"].ToString()!="")
				{
					model.LandTransportation=ds.Tables[0].Rows[0]["LandTransportation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SeaTransportation"]!=null && ds.Tables[0].Rows[0]["SeaTransportation"].ToString()!="")
				{
					model.SeaTransportation=ds.Tables[0].Rows[0]["SeaTransportation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AirTransportation"]!=null && ds.Tables[0].Rows[0]["AirTransportation"].ToString()!="")
				{
					model.AirTransportation=ds.Tables[0].Rows[0]["AirTransportation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OtherTransportation"]!=null && ds.Tables[0].Rows[0]["OtherTransportation"].ToString()!="")
				{
					model.OtherTransportation=ds.Tables[0].Rows[0]["OtherTransportation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DepositBank"]!=null && ds.Tables[0].Rows[0]["DepositBank"].ToString()!="")
				{
					model.DepositBank=ds.Tables[0].Rows[0]["DepositBank"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankAccount"]!=null && ds.Tables[0].Rows[0]["BankAccount"].ToString()!="")
				{
					model.BankAccount=ds.Tables[0].Rows[0]["BankAccount"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PSubject"]!=null && ds.Tables[0].Rows[0]["PSubject"].ToString()!="")
				{
					model.PSubject=ds.Tables[0].Rows[0]["PSubject"].ToString();
				}
				if(ds.Tables[0].Rows[0]["POSubject"]!=null && ds.Tables[0].Rows[0]["POSubject"].ToString()!="")
				{
					model.POSubject=ds.Tables[0].Rows[0]["POSubject"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TSubject"]!=null && ds.Tables[0].Rows[0]["TSubject"].ToString()!="")
				{
					model.TSubject=ds.Tables[0].Rows[0]["TSubject"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PCProject"]!=null && ds.Tables[0].Rows[0]["PCProject"].ToString()!="")
				{
					model.PCProject=ds.Tables[0].Rows[0]["PCProject"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TCProject"]!=null && ds.Tables[0].Rows[0]["TCProject"].ToString()!="")
				{
					model.TCProject=ds.Tables[0].Rows[0]["TCProject"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Fixed"]!=null && ds.Tables[0].Rows[0]["Fixed"].ToString()!="")
				{
					model.Fixed=ds.Tables[0].Rows[0]["Fixed"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Fax"]!=null && ds.Tables[0].Rows[0]["Fax"].ToString()!="")
				{
					model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Mobile"]!=null && ds.Tables[0].Rows[0]["Mobile"].ToString()!="")
				{
					model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
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
        public Maticsoft.Model.Supplier GetModel(string  name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,TypeID,Code,Enabled,Abbreviation,FullName,EnAbbreviation,EnFullName,Address,EnAddress,Margin,TaxRate,TypeCode,Currency,ZipCode,PaymentTerms,Principal,Linkman,Buyer,PurchasingCycle,PurchasingCycleTable,PurchasingGoodsCycle,PaymentMethod,LandTransportation,SeaTransportation,AirTransportation,OtherTransportation,DepositBank,BankAccount,PSubject,POSubject,TSubject,PCProject,TCProject,Fixed,Fax,Mobile,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from Supplier ");
            strSql.Append(" where FullName=@name");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.BigInt)
			};
            parameters[0].Value = name;

            Maticsoft.Model.Supplier model = new Maticsoft.Model.Supplier();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeID"] != null && ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = ds.Tables[0].Rows[0]["TypeID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Code"] != null && ds.Tables[0].Rows[0]["Code"].ToString() != "")
                {
                    model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
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
                if (ds.Tables[0].Rows[0]["Abbreviation"] != null && ds.Tables[0].Rows[0]["Abbreviation"].ToString() != "")
                {
                    model.Abbreviation = ds.Tables[0].Rows[0]["Abbreviation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FullName"] != null && ds.Tables[0].Rows[0]["FullName"].ToString() != "")
                {
                    model.FullName = ds.Tables[0].Rows[0]["FullName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EnAbbreviation"] != null && ds.Tables[0].Rows[0]["EnAbbreviation"].ToString() != "")
                {
                    model.EnAbbreviation = ds.Tables[0].Rows[0]["EnAbbreviation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EnFullName"] != null && ds.Tables[0].Rows[0]["EnFullName"].ToString() != "")
                {
                    model.EnFullName = ds.Tables[0].Rows[0]["EnFullName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EnAddress"] != null && ds.Tables[0].Rows[0]["EnAddress"].ToString() != "")
                {
                    model.EnAddress = ds.Tables[0].Rows[0]["EnAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Margin"] != null && ds.Tables[0].Rows[0]["Margin"].ToString() != "")
                {
                    model.Margin = decimal.Parse(ds.Tables[0].Rows[0]["Margin"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TaxRate"] != null && ds.Tables[0].Rows[0]["TaxRate"].ToString() != "")
                {
                    model.TaxRate = decimal.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeCode"] != null && ds.Tables[0].Rows[0]["TypeCode"].ToString() != "")
                {
                    model.TypeCode = ds.Tables[0].Rows[0]["TypeCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Currency"] != null && ds.Tables[0].Rows[0]["Currency"].ToString() != "")
                {
                    model.Currency = ds.Tables[0].Rows[0]["Currency"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZipCode"] != null && ds.Tables[0].Rows[0]["ZipCode"].ToString() != "")
                {
                    model.ZipCode = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PaymentTerms"] != null && ds.Tables[0].Rows[0]["PaymentTerms"].ToString() != "")
                {
                    model.PaymentTerms = ds.Tables[0].Rows[0]["PaymentTerms"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Principal"] != null && ds.Tables[0].Rows[0]["Principal"].ToString() != "")
                {
                    model.Principal = ds.Tables[0].Rows[0]["Principal"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Linkman"] != null && ds.Tables[0].Rows[0]["Linkman"].ToString() != "")
                {
                    model.Linkman = ds.Tables[0].Rows[0]["Linkman"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Buyer"] != null && ds.Tables[0].Rows[0]["Buyer"].ToString() != "")
                {
                    model.Buyer = ds.Tables[0].Rows[0]["Buyer"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PurchasingCycle"] != null && ds.Tables[0].Rows[0]["PurchasingCycle"].ToString() != "")
                {
                    model.PurchasingCycle = ds.Tables[0].Rows[0]["PurchasingCycle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PurchasingCycleTable"] != null && ds.Tables[0].Rows[0]["PurchasingCycleTable"].ToString() != "")
                {
                    model.PurchasingCycleTable = ds.Tables[0].Rows[0]["PurchasingCycleTable"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PurchasingGoodsCycle"] != null && ds.Tables[0].Rows[0]["PurchasingGoodsCycle"].ToString() != "")
                {
                    model.PurchasingGoodsCycle = ds.Tables[0].Rows[0]["PurchasingGoodsCycle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PaymentMethod"] != null && ds.Tables[0].Rows[0]["PaymentMethod"].ToString() != "")
                {
                    model.PaymentMethod = ds.Tables[0].Rows[0]["PaymentMethod"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LandTransportation"] != null && ds.Tables[0].Rows[0]["LandTransportation"].ToString() != "")
                {
                    model.LandTransportation = ds.Tables[0].Rows[0]["LandTransportation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["SeaTransportation"] != null && ds.Tables[0].Rows[0]["SeaTransportation"].ToString() != "")
                {
                    model.SeaTransportation = ds.Tables[0].Rows[0]["SeaTransportation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AirTransportation"] != null && ds.Tables[0].Rows[0]["AirTransportation"].ToString() != "")
                {
                    model.AirTransportation = ds.Tables[0].Rows[0]["AirTransportation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OtherTransportation"] != null && ds.Tables[0].Rows[0]["OtherTransportation"].ToString() != "")
                {
                    model.OtherTransportation = ds.Tables[0].Rows[0]["OtherTransportation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DepositBank"] != null && ds.Tables[0].Rows[0]["DepositBank"].ToString() != "")
                {
                    model.DepositBank = ds.Tables[0].Rows[0]["DepositBank"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BankAccount"] != null && ds.Tables[0].Rows[0]["BankAccount"].ToString() != "")
                {
                    model.BankAccount = ds.Tables[0].Rows[0]["BankAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PSubject"] != null && ds.Tables[0].Rows[0]["PSubject"].ToString() != "")
                {
                    model.PSubject = ds.Tables[0].Rows[0]["PSubject"].ToString();
                }
                if (ds.Tables[0].Rows[0]["POSubject"] != null && ds.Tables[0].Rows[0]["POSubject"].ToString() != "")
                {
                    model.POSubject = ds.Tables[0].Rows[0]["POSubject"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TSubject"] != null && ds.Tables[0].Rows[0]["TSubject"].ToString() != "")
                {
                    model.TSubject = ds.Tables[0].Rows[0]["TSubject"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PCProject"] != null && ds.Tables[0].Rows[0]["PCProject"].ToString() != "")
                {
                    model.PCProject = ds.Tables[0].Rows[0]["PCProject"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TCProject"] != null && ds.Tables[0].Rows[0]["TCProject"].ToString() != "")
                {
                    model.TCProject = ds.Tables[0].Rows[0]["TCProject"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Fixed"] != null && ds.Tables[0].Rows[0]["Fixed"].ToString() != "")
                {
                    model.Fixed = ds.Tables[0].Rows[0]["Fixed"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Fax"] != null && ds.Tables[0].Rows[0]["Fax"].ToString() != "")
                {
                    model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Mobile"] != null && ds.Tables[0].Rows[0]["Mobile"].ToString() != "")
                {
                    model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
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
			strSql.Append("select ID,TypeID,Code,Enabled,Abbreviation,FullName,EnAbbreviation,EnFullName,Address,EnAddress,Margin,TaxRate,TypeCode,Currency,ZipCode,PaymentTerms,Principal,Linkman,Buyer,PurchasingCycle,PurchasingCycleTable,PurchasingGoodsCycle,PaymentMethod,LandTransportation,SeaTransportation,AirTransportation,OtherTransportation,DepositBank,BankAccount,PSubject,POSubject,TSubject,PCProject,TCProject,Fixed,Fax,Mobile,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
			strSql.Append(" FROM Supplier ");
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
			strSql.Append(" ID,TypeID,Code,Enabled,Abbreviation,FullName,EnAbbreviation,EnFullName,Address,EnAddress,Margin,TaxRate,TypeCode,Currency,ZipCode,PaymentTerms,Principal,Linkman,Buyer,PurchasingCycle,PurchasingCycleTable,PurchasingGoodsCycle,PaymentMethod,LandTransportation,SeaTransportation,AirTransportation,OtherTransportation,DepositBank,BankAccount,PSubject,POSubject,TSubject,PCProject,TCProject,Fixed,Fax,Mobile,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
			strSql.Append(" FROM Supplier ");
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
			strSql.Append("select count(1) FROM Supplier ");
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
			strSql.Append(")AS Row, T.*  from Supplier T ");
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
			parameters[0].Value = "Supplier";
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

