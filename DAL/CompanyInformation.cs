using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:CompanyInformation
    /// </summary>
    public partial class CompanyInformation
    {
        public CompanyInformation()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "CompanyInformation");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CompanyInformation");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsToNumber(string Number)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CompanyInformation");
            strSql.Append(" where Number=@Number");
            SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = Number;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.CompanyInformation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CompanyInformation(");
            strSql.Append("Number,Abbreviation,FullName,Address,EnAddress,Head,FixedPhone,MobilePhone,Fax,ZipCode,CorpId,OpeningBank,Account,CustomsCode,LegalRepresentative,Remark,Status,EticPrice,PackPrice,EnAbbreviation,EnFullName,Value,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@Number,@Abbreviation,@FullName,@Address,@EnAddress,@Head,@FixedPhone,@MobilePhone,@Fax,@ZipCode,@CorpId,@OpeningBank,@Account,@CustomsCode,@LegalRepresentative,@Remark,@Status,@EticPrice,@PackPrice,@EnAbbreviation,@EnFullName,@Value,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
            strSql.Append(";select @@IDENTITY");
            
            SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Abbreviation", SqlDbType.NVarChar,50),
					new SqlParameter("@FullName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@EnAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@Head", SqlDbType.NVarChar,50),
					new SqlParameter("@FixedPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@ZipCode", SqlDbType.NVarChar,50),
					new SqlParameter("@CorpId", SqlDbType.NVarChar,50),
					new SqlParameter("@OpeningBank", SqlDbType.NVarChar,50),
					new SqlParameter("@Account", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomsCode", SqlDbType.NVarChar,50),
					new SqlParameter("@LegalRepresentative", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@EticPrice", SqlDbType.Decimal,9),
					new SqlParameter("@PackPrice", SqlDbType.Decimal,9),
					new SqlParameter("@EnAbbreviation", SqlDbType.NVarChar,50),
					new SqlParameter("@EnFullName", SqlDbType.NVarChar,50),
					new SqlParameter("@Value", SqlDbType.NVarChar),
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
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@UpdateUser", SqlDbType.NVarChar),
                    new SqlParameter("@UpdateDate", SqlDbType.DateTime)
                                        
                                        };
            parameters[0].Value = model.Number;
            parameters[1].Value = model.Abbreviation;
            parameters[2].Value = model.FullName;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.EnAddress;
            parameters[5].Value = model.Head;
            parameters[6].Value = model.FixedPhone;
            parameters[7].Value = model.MobilePhone;
            parameters[8].Value = model.Fax;
            parameters[9].Value = model.ZipCode;
            parameters[10].Value = model.CorpId;
            parameters[11].Value = model.OpeningBank;
            parameters[12].Value = model.Account;
            parameters[13].Value = model.CustomsCode;
            parameters[14].Value = model.LegalRepresentative;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.Status;
            parameters[17].Value = model.EticPrice;
            parameters[18].Value = model.PackPrice;
            parameters[19].Value = model.EnAbbreviation;
            parameters[20].Value = model.EnFullName;
            parameters[21].Value = model.Value;
            parameters[22].Value = model.Value1;
            parameters[23].Value = model.Value2;
            parameters[24].Value = model.Value3;
            parameters[25].Value = model.Value4;
            parameters[26].Value = model.Value5;
            parameters[27].Value = model.Value6;
            parameters[28].Value = model.Value7;
            parameters[29].Value = model.Value8;
            parameters[30].Value = model.Value9;
            parameters[31].Value = model.CreateUser;
            parameters[32].Value = model.CreateDate;
            parameters[33].Value = System.DBNull.Value;
            parameters[34].Value = System.DBNull.Value;

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
        public bool Update(Maticsoft.Model.CompanyInformation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CompanyInformation set ");
            strSql.Append("Number=@Number,");
            strSql.Append("Abbreviation=@Abbreviation,");
            strSql.Append("FullName=@FullName,");
            strSql.Append("Address=@Address,");
            strSql.Append("EnAddress=@EnAddress,");
            strSql.Append("Head=@Head,");
            strSql.Append("FixedPhone=@FixedPhone,");
            strSql.Append("MobilePhone=@MobilePhone,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("ZipCode=@ZipCode,");
            strSql.Append("CorpId=@CorpId,");
            strSql.Append("OpeningBank=@OpeningBank,");
            strSql.Append("Account=@Account,");
            strSql.Append("CustomsCode=@CustomsCode,");
            strSql.Append("LegalRepresentative=@LegalRepresentative,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("Status=@Status,");
            strSql.Append("EticPrice=@EticPrice,");
            strSql.Append("PackPrice=@PackPrice,");
            strSql.Append("EnAbbreviation=@EnAbbreviation,");
            strSql.Append("EnFullName=@EnFullName,");
            strSql.Append("Value=@Value,");
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
					new SqlParameter("@Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Abbreviation", SqlDbType.NVarChar,50),
					new SqlParameter("@FullName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@EnAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@Head", SqlDbType.NVarChar,50),
					new SqlParameter("@FixedPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@MobilePhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@ZipCode", SqlDbType.NVarChar,50),
					new SqlParameter("@CorpId", SqlDbType.NVarChar,50),
					new SqlParameter("@OpeningBank", SqlDbType.NVarChar,50),
					new SqlParameter("@Account", SqlDbType.NVarChar,50),
					new SqlParameter("@CustomsCode", SqlDbType.NVarChar,50),
					new SqlParameter("@LegalRepresentative", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@EticPrice", SqlDbType.Decimal,9),
					new SqlParameter("@PackPrice", SqlDbType.Decimal,9),
					new SqlParameter("@EnAbbreviation", SqlDbType.NVarChar,50),
					new SqlParameter("@EnFullName", SqlDbType.NVarChar,50),
					new SqlParameter("@Value", SqlDbType.NVarChar),
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
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Number;
            parameters[1].Value = model.Abbreviation;
            parameters[2].Value = model.FullName;
            parameters[3].Value = model.Address;
            parameters[4].Value = model.EnAddress;
            parameters[5].Value = model.Head;
            parameters[6].Value = model.FixedPhone;
            parameters[7].Value = model.MobilePhone;
            parameters[8].Value = model.Fax;
            parameters[9].Value = model.ZipCode;
            parameters[10].Value = model.CorpId;
            parameters[11].Value = model.OpeningBank;
            parameters[12].Value = model.Account;
            parameters[13].Value = model.CustomsCode;
            parameters[14].Value = model.LegalRepresentative;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.Status;
            parameters[17].Value = model.EticPrice;
            parameters[18].Value = model.PackPrice;
            parameters[19].Value = model.EnAbbreviation;
            parameters[20].Value = model.EnFullName;
            parameters[21].Value = model.Value;
            parameters[22].Value = model.Value1;
            parameters[23].Value = model.Value2;
            parameters[24].Value = model.Value3;
            parameters[25].Value = model.Value4;
            parameters[26].Value = model.Value5;
            parameters[27].Value = model.Value6;
            parameters[28].Value = model.Value7;
            parameters[29].Value = model.Value8;
            parameters[30].Value = model.Value9;
            parameters[31].Value = model.UpdateUser;
            parameters[32].Value = model.UpdateDate;
            parameters[33].Value = model.ID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CompanyInformation ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CompanyInformation ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public Maticsoft.Model.CompanyInformation GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Number,Abbreviation,FullName,Address,EnAddress,Head,FixedPhone,MobilePhone,Fax,ZipCode,CorpId,OpeningBank,Account,CustomsCode,LegalRepresentative,Remark,Status,EticPrice,PackPrice,EnAbbreviation,EnFullName,Value,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from CompanyInformation ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.CompanyInformation model = new Maticsoft.Model.CompanyInformation();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Number"] != null && ds.Tables[0].Rows[0]["Number"].ToString() != "")
                {
                    model.Number = ds.Tables[0].Rows[0]["Number"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Abbreviation"] != null && ds.Tables[0].Rows[0]["Abbreviation"].ToString() != "")
                {
                    model.Abbreviation = ds.Tables[0].Rows[0]["Abbreviation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FullName"] != null && ds.Tables[0].Rows[0]["FullName"].ToString() != "")
                {
                    model.FullName = ds.Tables[0].Rows[0]["FullName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EnAddress"] != null && ds.Tables[0].Rows[0]["EnAddress"].ToString() != "")
                {
                    model.EnAddress = ds.Tables[0].Rows[0]["EnAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Head"] != null && ds.Tables[0].Rows[0]["Head"].ToString() != "")
                {
                    model.Head = ds.Tables[0].Rows[0]["Head"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FixedPhone"] != null && ds.Tables[0].Rows[0]["FixedPhone"].ToString() != "")
                {
                    model.FixedPhone = ds.Tables[0].Rows[0]["FixedPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MobilePhone"] != null && ds.Tables[0].Rows[0]["MobilePhone"].ToString() != "")
                {
                    model.MobilePhone = ds.Tables[0].Rows[0]["MobilePhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Fax"] != null && ds.Tables[0].Rows[0]["Fax"].ToString() != "")
                {
                    model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ZipCode"] != null && ds.Tables[0].Rows[0]["ZipCode"].ToString() != "")
                {
                    model.ZipCode = ds.Tables[0].Rows[0]["ZipCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CorpId"] != null && ds.Tables[0].Rows[0]["CorpId"].ToString() != "")
                {
                    model.CorpId = ds.Tables[0].Rows[0]["CorpId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OpeningBank"] != null && ds.Tables[0].Rows[0]["OpeningBank"].ToString() != "")
                {
                    model.OpeningBank = ds.Tables[0].Rows[0]["OpeningBank"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Account"] != null && ds.Tables[0].Rows[0]["Account"].ToString() != "")
                {
                    model.Account = ds.Tables[0].Rows[0]["Account"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CustomsCode"] != null && ds.Tables[0].Rows[0]["CustomsCode"].ToString() != "")
                {
                    model.CustomsCode = ds.Tables[0].Rows[0]["CustomsCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LegalRepresentative"] != null && ds.Tables[0].Rows[0]["LegalRepresentative"].ToString() != "")
                {
                    model.LegalRepresentative = ds.Tables[0].Rows[0]["LegalRepresentative"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Status"] != null && ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EticPrice"] != null && ds.Tables[0].Rows[0]["EticPrice"].ToString() != "")
                {
                    model.EticPrice = decimal.Parse(ds.Tables[0].Rows[0]["EticPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PackPrice"] != null && ds.Tables[0].Rows[0]["PackPrice"].ToString() != "")
                {
                    model.PackPrice = decimal.Parse(ds.Tables[0].Rows[0]["PackPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EnAbbreviation"] != null && ds.Tables[0].Rows[0]["EnAbbreviation"].ToString() != "")
                {
                    model.EnAbbreviation = ds.Tables[0].Rows[0]["EnAbbreviation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EnFullName"] != null && ds.Tables[0].Rows[0]["EnFullName"].ToString() != "")
                {
                    model.EnFullName = ds.Tables[0].Rows[0]["EnFullName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Value"] != null && ds.Tables[0].Rows[0]["Value"].ToString() != "")
                {
                    model.Value = ds.Tables[0].Rows[0]["Value"].ToString();
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Number,Abbreviation,FullName,Address,EnAddress,Head,FixedPhone,MobilePhone,Fax,ZipCode,CorpId,OpeningBank,Account,CustomsCode,LegalRepresentative,Remark,Status,EticPrice,PackPrice,EnAbbreviation,EnFullName,Value,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate");
            strSql.Append(" FROM CompanyInformation ");
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
            strSql.Append(" ID,Number,Abbreviation,FullName,Address,EnAddress,Head,FixedPhone,MobilePhone,Fax,ZipCode,CorpId,OpeningBank,Account,CustomsCode,LegalRepresentative,Remark,Status,EticPrice,PackPrice,EnAbbreviation,EnFullName,Value,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM CompanyInformation ");
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
            strSql.Append("select count(1) FROM CompanyInformation ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from CompanyInformation T ");
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
            parameters[0].Value = "CompanyInformation";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        #region  ExtensionMethod

        public DataSet GetList(string tableName, string orderFile, string showField, int page, int rows, out int count, string orderType, string where)
        {
            return DbHelperSQL.GetList_ProcPage(tableName, orderFile, showField, page, rows, out count, orderType, where);
        }

        #endregion  ExtensionMethod
    }
}

