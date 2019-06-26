using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Employees
	/// </summary>
	public partial class Employees
	{
        public Employees()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BaseUser");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)
			};
			parameters[0].Value = UserID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByUserName(string UserName, long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(1) from BaseUser ");
            strSql.Append(" where UserName=@UserName and UserID!=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
                    new SqlParameter("@UserID", SqlDbType.BigInt)
			};
            parameters[0].Value = UserName;
            parameters[1].Value = UserID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ExistsByWorkID(string WorkID, long UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(1) from BaseUser ");
            strSql.Append(" where WorkID=@WorkID and UserID!=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkID",SqlDbType.NVarChar,50),
                    new SqlParameter("@UserID", SqlDbType.BigInt)
			};
            parameters[0].Value = WorkID;
            parameters[1].Value = UserID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public long Add(Maticsoft.Model.Employees model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BaseUser(");
            strSql.Append("DeptID,Roles,UserName,Pwd,Name,Tel,WorkID,CreatedDate,CreatedGuy,ApprRole,IDCard,Nation,Dataofbirth,Sex,Nativeplace,RegdResd,Address,Maritalstatus,Politicsstatus,Bloodtype,Education,GraduationDate,EntryDate,Degree,Major,Email,EmContact,EmContactTel,Positivedates,StateEmployees,AppRoleID,Permissions,Photo,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate)");
			strSql.Append(" values (");
            strSql.Append("@DeptID,@Roles,@UserName,@Pwd,@Name,@Tel,@WorkID,@CreatedDate,@CreatedGuy,@ApprRole,@IDCard,@Nation,@Dataofbirth,@Sex,@Nativeplace,@RegdResd,@Address,@Maritalstatus,@Politicsstatus,@Bloodtype,@Education,@GraduationDate,@EntryDate,@Degree,@Major,@Email,@EmContact,@EmContactTel,@Positivedates,@StateEmployees,@AppRoleID,@Permissions,@Photo,@Remark,@Value0,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@CreateUser,@CreateDate)");
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
					new SqlParameter("@CreatedGuy", SqlDbType.Int,4),
					new SqlParameter("@ApprRole", SqlDbType.NVarChar,100),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,50),
					new SqlParameter("@Nation", SqlDbType.NVarChar,50),
					new SqlParameter("@Dataofbirth", SqlDbType.DateTime),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Nativeplace", SqlDbType.NVarChar,50),
					new SqlParameter("@RegdResd", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Maritalstatus", SqlDbType.Int,4),
					new SqlParameter("@Politicsstatus", SqlDbType.Int,4),
					new SqlParameter("@Bloodtype", SqlDbType.Int,4),
					new SqlParameter("@Education", SqlDbType.Int,4),
					new SqlParameter("@GraduationDate", SqlDbType.DateTime),
					new SqlParameter("@EntryDate", SqlDbType.DateTime),
					new SqlParameter("@Degree", SqlDbType.Int,4),
					new SqlParameter("@Major", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@EmContact", SqlDbType.NVarChar,50),
					new SqlParameter("@EmContactTel", SqlDbType.NVarChar,50),
					new SqlParameter("@Positivedates", SqlDbType.DateTime),
					new SqlParameter("@StateEmployees", SqlDbType.Int,4),
					new SqlParameter("@AppRoleID", SqlDbType.Int,4),
					new SqlParameter("@Permissions", SqlDbType.Int,4),
					new SqlParameter("@Photo", SqlDbType.NVarChar,100),
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
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime)};
			parameters[0].Value = model.DeptID;
			parameters[1].Value = model.Roles;
			parameters[2].Value = model.UserName;
			parameters[3].Value = DBUtility.WcSecurity.Des.Encrypt("123456");
			parameters[4].Value = model.Name;
			parameters[5].Value = model.Tel;
			parameters[6].Value = model.WorkID;
			parameters[7].Value = model.CreatedDate;
			parameters[8].Value = model.CreatedGuy;
			parameters[9].Value = model.ApprRole;
			parameters[10].Value = model.IDCard;
			parameters[11].Value = model.Nation;
			parameters[12].Value = model.Dataofbirth;
			parameters[13].Value = model.Sex;
			parameters[14].Value = model.Nativeplace;
			parameters[15].Value = model.RegdResd;
			parameters[16].Value = model.Address;
			parameters[17].Value = model.Maritalstatus;
			parameters[18].Value = model.Politicsstatus;
			parameters[19].Value = model.Bloodtype;
			parameters[20].Value = model.Education;
			parameters[21].Value = model.GraduationDate;
			parameters[22].Value = model.EntryDate;
			parameters[23].Value = model.Degree;
			parameters[24].Value = model.Major;
			parameters[25].Value = model.Email;
			parameters[26].Value = model.EmContact;
			parameters[27].Value = model.EmContactTel;
			parameters[28].Value = model.Positivedates;
			parameters[29].Value = model.StateEmployees;
			parameters[30].Value = model.AppRoleID;
			parameters[31].Value = model.Permissions;
			parameters[32].Value = model.Photo;
			parameters[33].Value = model.Remark;
			parameters[34].Value = model.Value0;
			parameters[35].Value = model.Value1;
			parameters[36].Value = model.Value2;
			parameters[37].Value = model.Value3;
			parameters[38].Value = model.Value4;
			parameters[39].Value = model.Value5;
			parameters[40].Value = model.Value6;
			parameters[41].Value = model.Value7;
			parameters[42].Value = model.Value8;
			parameters[43].Value = model.Value9;
            parameters[44].Value = model.CreateUser;
            parameters[45].Value = model.CreateDate;

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
        public bool Update(Maticsoft.Model.Employees model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BaseUser set ");
			strSql.Append("DeptID=@DeptID,");
            //strSql.Append("Roles=@Roles,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Pwd=@Pwd,");
			strSql.Append("Name=@Name,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("WorkID=@WorkID,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("CreatedGuy=@CreatedGuy,");
			strSql.Append("ApprRole=@ApprRole,");
			strSql.Append("IDCard=@IDCard,");
			strSql.Append("Nation=@Nation,");
			strSql.Append("Dataofbirth=@Dataofbirth,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Nativeplace=@Nativeplace,");
			strSql.Append("RegdResd=@RegdResd,");
			strSql.Append("Address=@Address,");
			strSql.Append("Maritalstatus=@Maritalstatus,");
			strSql.Append("Politicsstatus=@Politicsstatus,");
			strSql.Append("Bloodtype=@Bloodtype,");
			strSql.Append("Education=@Education,");
			strSql.Append("GraduationDate=@GraduationDate,");
			strSql.Append("EntryDate=@EntryDate,");
			strSql.Append("Degree=@Degree,");
			strSql.Append("Major=@Major,");
			strSql.Append("Email=@Email,");
			strSql.Append("EmContact=@EmContact,");
			strSql.Append("EmContactTel=@EmContactTel,");
			strSql.Append("Positivedates=@Positivedates,");
			strSql.Append("StateEmployees=@StateEmployees,");
			strSql.Append("AppRoleID=@AppRoleID,");
			strSql.Append("Permissions=@Permissions,");
			strSql.Append("Photo=@Photo,");
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
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4),
                    new SqlParameter("@Roles", SqlDbType.NVarChar,100),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@Pwd", SqlDbType.NVarChar,100),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@WorkID", SqlDbType.NVarChar,50),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@CreatedGuy", SqlDbType.Int,4),
					new SqlParameter("@ApprRole", SqlDbType.NVarChar,100),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,50),
					new SqlParameter("@Nation", SqlDbType.NVarChar,50),
					new SqlParameter("@Dataofbirth", SqlDbType.DateTime),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@Nativeplace", SqlDbType.NVarChar,50),
					new SqlParameter("@RegdResd", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Maritalstatus", SqlDbType.Int,4),
					new SqlParameter("@Politicsstatus", SqlDbType.Int,4),
					new SqlParameter("@Bloodtype", SqlDbType.Int,4),
					new SqlParameter("@Education", SqlDbType.Int,4),
					new SqlParameter("@GraduationDate", SqlDbType.DateTime),
					new SqlParameter("@EntryDate", SqlDbType.DateTime),
					new SqlParameter("@Degree", SqlDbType.Int,4),
					new SqlParameter("@Major", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@EmContact", SqlDbType.NVarChar,50),
					new SqlParameter("@EmContactTel", SqlDbType.NVarChar,50),
					new SqlParameter("@Positivedates", SqlDbType.DateTime),
					new SqlParameter("@StateEmployees", SqlDbType.Int,4),
					new SqlParameter("@AppRoleID", SqlDbType.Int,4),
					new SqlParameter("@Permissions", SqlDbType.Int,4),
					new SqlParameter("@Photo", SqlDbType.NVarChar,100),
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
                    new SqlParameter("@UpdateUser", SqlDbType.NVarChar),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.DeptID;
            parameters[1].Value = model.Roles;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Pwd;
			parameters[4].Value = model.Name;
			parameters[5].Value = model.Tel;
			parameters[6].Value = model.WorkID;
			parameters[7].Value = model.CreatedDate;
			parameters[8].Value = model.CreatedGuy;
			parameters[9].Value = model.ApprRole;
			parameters[10].Value = model.IDCard;
			parameters[11].Value = model.Nation;
			parameters[12].Value = model.Dataofbirth;
			parameters[13].Value = model.Sex;
			parameters[14].Value = model.Nativeplace;
			parameters[15].Value = model.RegdResd;
			parameters[16].Value = model.Address;
			parameters[17].Value = model.Maritalstatus;
			parameters[18].Value = model.Politicsstatus;
			parameters[19].Value = model.Bloodtype;
			parameters[20].Value = model.Education;
			parameters[21].Value = model.GraduationDate;
			parameters[22].Value = model.EntryDate;
			parameters[23].Value = model.Degree;
			parameters[24].Value = model.Major;
			parameters[25].Value = model.Email;
			parameters[26].Value = model.EmContact;
			parameters[27].Value = model.EmContactTel;
			parameters[28].Value = model.Positivedates;
			parameters[29].Value = model.StateEmployees;
			parameters[30].Value = model.AppRoleID;
			parameters[31].Value = model.Permissions;
			parameters[32].Value = model.Photo;
			parameters[33].Value = model.Remark;
			parameters[34].Value = model.Value0;
			parameters[35].Value = model.Value1;
			parameters[36].Value = model.Value2;
			parameters[37].Value = model.Value3;
			parameters[38].Value = model.Value4;
			parameters[39].Value = model.Value5;
			parameters[40].Value = model.Value6;
			parameters[41].Value = model.Value7;
			parameters[42].Value = model.Value8;
			parameters[43].Value = model.Value9;
            parameters[44].Value = model.UpdateUser;
            parameters[45].Value = model.UpdateDate;
			parameters[46].Value = model.UserID;

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


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Maticsoft.Model.Employees GetModel(long UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 UserID,DeptID,Roles,UserName,Pwd,Name,Tel,WorkID,CreatedDate,CreatedGuy,ApprRole,IDCard,Nation,Dataofbirth,Sex,Nativeplace,RegdResd,Address,Maritalstatus,Politicsstatus,Bloodtype,Education,GraduationDate,EntryDate,Degree,Major,Email,EmContact,EmContactTel,Positivedates,StateEmployees,AppRoleID,Permissions,Photo,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from BaseUser ");
			strSql.Append(" where UserID=@UserID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.BigInt)
			};
			parameters[0].Value = UserID;

            Maticsoft.Model.Employees model = new Maticsoft.Model.Employees();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserID"]!=null && ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=long.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DeptID"]!=null && ds.Tables[0].Rows[0]["DeptID"].ToString()!="")
				{
					model.DeptID=int.Parse(ds.Tables[0].Rows[0]["DeptID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Roles"]!=null && ds.Tables[0].Rows[0]["Roles"].ToString()!="")
				{
					model.Roles=ds.Tables[0].Rows[0]["Roles"].ToString();
				}
				if(ds.Tables[0].Rows[0]["UserName"]!=null && ds.Tables[0].Rows[0]["UserName"].ToString()!="")
				{
					model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Pwd"]!=null && ds.Tables[0].Rows[0]["Pwd"].ToString()!="")
				{
					model.Pwd=ds.Tables[0].Rows[0]["Pwd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Tel"]!=null && ds.Tables[0].Rows[0]["Tel"].ToString()!="")
				{
					model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["WorkID"]!=null && ds.Tables[0].Rows[0]["WorkID"].ToString()!="")
				{
					model.WorkID=ds.Tables[0].Rows[0]["WorkID"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedDate"]!=null && ds.Tables[0].Rows[0]["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedGuy"]!=null && ds.Tables[0].Rows[0]["CreatedGuy"].ToString()!="")
				{
					model.CreatedGuy=int.Parse(ds.Tables[0].Rows[0]["CreatedGuy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApprRole"]!=null && ds.Tables[0].Rows[0]["ApprRole"].ToString()!="")
				{
					model.ApprRole=ds.Tables[0].Rows[0]["ApprRole"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IDCard"]!=null && ds.Tables[0].Rows[0]["IDCard"].ToString()!="")
				{
					model.IDCard=ds.Tables[0].Rows[0]["IDCard"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Nation"]!=null && ds.Tables[0].Rows[0]["Nation"].ToString()!="")
				{
					model.Nation=ds.Tables[0].Rows[0]["Nation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Dataofbirth"]!=null && ds.Tables[0].Rows[0]["Dataofbirth"].ToString()!="")
				{
					model.Dataofbirth=DateTime.Parse(ds.Tables[0].Rows[0]["Dataofbirth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sex"]!=null && ds.Tables[0].Rows[0]["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Nativeplace"]!=null && ds.Tables[0].Rows[0]["Nativeplace"].ToString()!="")
				{
					model.Nativeplace=ds.Tables[0].Rows[0]["Nativeplace"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RegdResd"]!=null && ds.Tables[0].Rows[0]["RegdResd"].ToString()!="")
				{
					model.RegdResd=ds.Tables[0].Rows[0]["RegdResd"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address"]!=null && ds.Tables[0].Rows[0]["Address"].ToString()!="")
				{
					model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Maritalstatus"]!=null && ds.Tables[0].Rows[0]["Maritalstatus"].ToString()!="")
				{
					model.Maritalstatus=int.Parse(ds.Tables[0].Rows[0]["Maritalstatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Politicsstatus"]!=null && ds.Tables[0].Rows[0]["Politicsstatus"].ToString()!="")
				{
					model.Politicsstatus=int.Parse(ds.Tables[0].Rows[0]["Politicsstatus"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Bloodtype"]!=null && ds.Tables[0].Rows[0]["Bloodtype"].ToString()!="")
				{
					model.Bloodtype=int.Parse(ds.Tables[0].Rows[0]["Bloodtype"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Education"]!=null && ds.Tables[0].Rows[0]["Education"].ToString()!="")
				{
					model.Education=int.Parse(ds.Tables[0].Rows[0]["Education"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GraduationDate"]!=null && ds.Tables[0].Rows[0]["GraduationDate"].ToString()!="")
				{
					model.GraduationDate=DateTime.Parse(ds.Tables[0].Rows[0]["GraduationDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EntryDate"]!=null && ds.Tables[0].Rows[0]["EntryDate"].ToString()!="")
				{
					model.EntryDate=DateTime.Parse(ds.Tables[0].Rows[0]["EntryDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Degree"]!=null && ds.Tables[0].Rows[0]["Degree"].ToString()!="")
				{
					model.Degree=int.Parse(ds.Tables[0].Rows[0]["Degree"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Major"]!=null && ds.Tables[0].Rows[0]["Major"].ToString()!="")
				{
					model.Major=ds.Tables[0].Rows[0]["Major"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EmContact"]!=null && ds.Tables[0].Rows[0]["EmContact"].ToString()!="")
				{
					model.EmContact=ds.Tables[0].Rows[0]["EmContact"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EmContactTel"]!=null && ds.Tables[0].Rows[0]["EmContactTel"].ToString()!="")
				{
					model.EmContactTel=ds.Tables[0].Rows[0]["EmContactTel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Positivedates"]!=null && ds.Tables[0].Rows[0]["Positivedates"].ToString()!="")
				{
					model.Positivedates=DateTime.Parse(ds.Tables[0].Rows[0]["Positivedates"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StateEmployees"]!=null && ds.Tables[0].Rows[0]["StateEmployees"].ToString()!="")
				{
					model.StateEmployees=int.Parse(ds.Tables[0].Rows[0]["StateEmployees"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AppRoleID"]!=null && ds.Tables[0].Rows[0]["AppRoleID"].ToString()!="")
				{
					model.AppRoleID=int.Parse(ds.Tables[0].Rows[0]["AppRoleID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Permissions"]!=null && ds.Tables[0].Rows[0]["Permissions"].ToString()!="")
				{
					model.Permissions=int.Parse(ds.Tables[0].Rows[0]["Permissions"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Photo"]!=null && ds.Tables[0].Rows[0]["Photo"].ToString()!="")
				{
					model.Photo=ds.Tables[0].Rows[0]["Photo"].ToString();
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

                if (ds.Tables[0].Rows[0]["CreateUser"] != null && ds.Tables[0].Rows[0]["CreateUser"].ToString() != "")
                {
                    model.Value9 = ds.Tables[0].Rows[0]["CreateUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreateDate"] != null && ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.Value9 = ds.Tables[0].Rows[0]["CreateDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UpdateUser"] != null && ds.Tables[0].Rows[0]["UpdateUser"].ToString() != "")
                {
                    model.Value9 = ds.Tables[0].Rows[0]["UpdateUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UpdateDate"] != null && ds.Tables[0].Rows[0]["UpdateDate"].ToString() != "")
                {
                    model.Value9 = ds.Tables[0].Rows[0]["UpdateDate"].ToString();
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
            strSql.Append("select UserID,DeptID,Roles,UserName,Pwd,Name,Tel,WorkID,CreatedDate,CreatedGuy,ApprRole,IDCard,Nation,Dataofbirth,Sex,Nativeplace,RegdResd,Address,Maritalstatus,Politicsstatus,Bloodtype,Education,GraduationDate,EntryDate,Degree,Major,Email,EmContact,EmContactTel,Positivedates,StateEmployees,AppRoleID,Permissions,Photo,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser，CreateDate，UpdateUser，UpdateDate ");
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
            strSql.Append(" UserID,DeptID,Roles,UserName,Pwd,Name,Tel,WorkID,CreatedDate,CreatedGuy,ApprRole,IDCard,Nation,Dataofbirth,Sex,Nativeplace,RegdResd,Address,Maritalstatus,Politicsstatus,Bloodtype,Education,GraduationDate,EntryDate,Degree,Major,Email,EmContact,EmContactTel,Positivedates,StateEmployees,AppRoleID,Permissions,Photo,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9，UpdateDate，CreateDate，UpdateUser，UpdateDate ");
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
			parameters[0].Value = "BaseUser";
			parameters[1].Value = "UserID";
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

