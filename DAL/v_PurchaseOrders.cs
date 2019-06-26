using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:v_PurchaseOrders
    /// </summary>
    public partial class v_PurchaseOrders
    {
        public v_PurchaseOrders()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_PurchaseOrders");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.v_PurchaseOrders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into v_PurchaseOrders(");
            strSql.Append("ID,Code,Buyer,DeliveryDate,ProjectID,Currency,ExchangeRate,DiscountRate,TaxRate,PayTerm,AccountsMode,Deposit,OtherFees,PlansFactoryDate,FactoryDate,Transport,DeliveryAddress,remark,ProjectName,SupplierName,LinkMan,Mobile,Principal,curStatus,curStatusNo,SubmitPerson,SubmitDate,Auditor,AuditDate,creater,create_date,updater,update_date)");
            strSql.Append(" values (");
            strSql.Append("@ID,@Code,@Buyer,@DeliveryDate,@ProjectID,@Currency,@ExchangeRate,@DiscountRate,@TaxRate,@PayTerm,@AccountsMode,@Deposit,@OtherFees,@PlansFactoryDate,@FactoryDate,@Transport,@DeliveryAddress,@remark,@ProjectName,@SupplierName,@LinkMan,@Mobile,@Principal,@curStatus,@curStatusNo,@SubmitPerson,@SubmitDate,@Auditor,@AuditDate,@creater,@create_date,@updater,@update_date)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Buyer", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@Currency", SqlDbType.NVarChar,50),
					new SqlParameter("@ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountRate", SqlDbType.Decimal,9),
					new SqlParameter("@TaxRate", SqlDbType.Decimal,9),
					new SqlParameter("@PayTerm", SqlDbType.NVarChar,50),
					new SqlParameter("@AccountsMode", SqlDbType.NVarChar,50),
					new SqlParameter("@Deposit", SqlDbType.Decimal,9),
					new SqlParameter("@OtherFees", SqlDbType.Decimal,9),
					new SqlParameter("@PlansFactoryDate", SqlDbType.DateTime),
					new SqlParameter("@FactoryDate", SqlDbType.DateTime),
					new SqlParameter("@Transport", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@ProjectName", SqlDbType.NVarChar,50),
					new SqlParameter("@SupplierName", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkMan", SqlDbType.NVarChar,50),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@Principal", SqlDbType.NVarChar,50),
					new SqlParameter("@curStatus", SqlDbType.VarChar,6),
					new SqlParameter("@curStatusNo", SqlDbType.VarChar,1),
					new SqlParameter("@SubmitPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Auditor", SqlDbType.NVarChar,50),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@creater", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@updater", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.Buyer;
            parameters[3].Value = model.DeliveryDate;
            parameters[4].Value = model.ProjectID;
            parameters[5].Value = model.Currency;
            parameters[6].Value = model.ExchangeRate;
            parameters[7].Value = model.DiscountRate;
            parameters[8].Value = model.TaxRate;
            parameters[9].Value = model.PayTerm;
            parameters[10].Value = model.AccountsMode;
            parameters[11].Value = model.Deposit;
            parameters[12].Value = model.OtherFees;
            parameters[13].Value = model.PlansFactoryDate;
            parameters[14].Value = model.FactoryDate;
            parameters[15].Value = model.Transport;
            parameters[16].Value = model.DeliveryAddress;
            parameters[17].Value = model.remark;
            parameters[18].Value = model.ProjectName;
            parameters[19].Value = model.SupplierName;
            parameters[20].Value = model.LinkMan;
            parameters[21].Value = model.Mobile;
            parameters[22].Value = model.Principal;
            parameters[23].Value = model.curStatus;
            parameters[24].Value = model.curStatusNo;
            parameters[25].Value = model.SubmitPerson;
            parameters[26].Value = model.SubmitDate;
            parameters[27].Value = model.Auditor;
            parameters[28].Value = model.AuditDate;
            parameters[29].Value = model.creater;
            parameters[30].Value = model.create_date;
            parameters[31].Value = model.updater;
            parameters[32].Value = model.update_date;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.v_PurchaseOrders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_PurchaseOrders set ");
            strSql.Append("ID=@ID,");
            strSql.Append("Code=@Code,");
            strSql.Append("Buyer=@Buyer,");
            strSql.Append("DeliveryDate=@DeliveryDate,");
            strSql.Append("ProjectID=@ProjectID,");
            strSql.Append("Currency=@Currency,");
            strSql.Append("ExchangeRate=@ExchangeRate,");
            strSql.Append("DiscountRate=@DiscountRate,");
            strSql.Append("TaxRate=@TaxRate,");
            strSql.Append("PayTerm=@PayTerm,");
            strSql.Append("AccountsMode=@AccountsMode,");
            strSql.Append("Deposit=@Deposit,");
            strSql.Append("OtherFees=@OtherFees,");
            strSql.Append("PlansFactoryDate=@PlansFactoryDate,");
            strSql.Append("FactoryDate=@FactoryDate,");
            strSql.Append("Transport=@Transport,");
            strSql.Append("DeliveryAddress=@DeliveryAddress,");
            strSql.Append("remark=@remark,");
            strSql.Append("ProjectName=@ProjectName,");
            strSql.Append("SupplierName=@SupplierName,");
            strSql.Append("LinkMan=@LinkMan,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Principal=@Principal,");
            strSql.Append("curStatus=@curStatus,");
            strSql.Append("curStatusNo=@curStatusNo,");
            strSql.Append("SubmitPerson=@SubmitPerson,");
            strSql.Append("SubmitDate=@SubmitDate,");
            strSql.Append("Auditor=@Auditor,");
            strSql.Append("AuditDate=@AuditDate,");
            strSql.Append("creater=@creater,");
            strSql.Append("create_date=@create_date,");
            strSql.Append("updater=@updater,");
            strSql.Append("update_date=@update_date");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Buyer", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@Currency", SqlDbType.NVarChar,50),
					new SqlParameter("@ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@DiscountRate", SqlDbType.Decimal,9),
					new SqlParameter("@TaxRate", SqlDbType.Decimal,9),
					new SqlParameter("@PayTerm", SqlDbType.NVarChar,50),
					new SqlParameter("@AccountsMode", SqlDbType.NVarChar,50),
					new SqlParameter("@Deposit", SqlDbType.Decimal,9),
					new SqlParameter("@OtherFees", SqlDbType.Decimal,9),
					new SqlParameter("@PlansFactoryDate", SqlDbType.DateTime),
					new SqlParameter("@FactoryDate", SqlDbType.DateTime),
					new SqlParameter("@Transport", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@ProjectName", SqlDbType.NVarChar,50),
					new SqlParameter("@SupplierName", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkMan", SqlDbType.NVarChar,50),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@Principal", SqlDbType.NVarChar,50),
					new SqlParameter("@curStatus", SqlDbType.VarChar,6),
					new SqlParameter("@curStatusNo", SqlDbType.VarChar,1),
					new SqlParameter("@SubmitPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Auditor", SqlDbType.NVarChar,50),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@creater", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@updater", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.Buyer;
            parameters[3].Value = model.DeliveryDate;
            parameters[4].Value = model.ProjectID;
            parameters[5].Value = model.Currency;
            parameters[6].Value = model.ExchangeRate;
            parameters[7].Value = model.DiscountRate;
            parameters[8].Value = model.TaxRate;
            parameters[9].Value = model.PayTerm;
            parameters[10].Value = model.AccountsMode;
            parameters[11].Value = model.Deposit;
            parameters[12].Value = model.OtherFees;
            parameters[13].Value = model.PlansFactoryDate;
            parameters[14].Value = model.FactoryDate;
            parameters[15].Value = model.Transport;
            parameters[16].Value = model.DeliveryAddress;
            parameters[17].Value = model.remark;
            parameters[18].Value = model.ProjectName;
            parameters[19].Value = model.SupplierName;
            parameters[20].Value = model.LinkMan;
            parameters[21].Value = model.Mobile;
            parameters[22].Value = model.Principal;
            parameters[23].Value = model.curStatus;
            parameters[24].Value = model.curStatusNo;
            parameters[25].Value = model.SubmitPerson;
            parameters[26].Value = model.SubmitDate;
            parameters[27].Value = model.Auditor;
            parameters[28].Value = model.AuditDate;
            parameters[29].Value = model.creater;
            parameters[30].Value = model.create_date;
            parameters[31].Value = model.updater;
            parameters[32].Value = model.update_date;

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
            strSql.Append("delete from v_PurchaseOrders ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
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
            strSql.Append("delete from v_PurchaseOrders ");
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
        public Maticsoft.Model.v_PurchaseOrders GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Code,Buyer,DeliveryDate,ProjectID,Currency,ExchangeRate,DiscountRate,TaxRate,PayTerm,AccountsMode,Deposit,OtherFees,PlansFactoryDate,FactoryDate,Transport,DeliveryAddress,remark,ProjectName,SupplierName,LinkMan,Mobile,Principal,curStatus,curStatusNo,SubmitPerson,SubmitDate,Auditor,AuditDate,creater,create_date,updater,update_date from v_PurchaseOrders ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            Maticsoft.Model.v_PurchaseOrders model = new Maticsoft.Model.v_PurchaseOrders();
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
        public Maticsoft.Model.v_PurchaseOrders DataRowToModel(DataRow row)
        {
            Maticsoft.Model.v_PurchaseOrders model = new Maticsoft.Model.v_PurchaseOrders();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Buyer"] != null)
                {
                    model.Buyer = row["Buyer"].ToString();
                }
                if (row["DeliveryDate"] != null && row["DeliveryDate"].ToString() != "")
                {
                    model.DeliveryDate = DateTime.Parse(row["DeliveryDate"].ToString());
                }
                if (row["ProjectID"] != null && row["ProjectID"].ToString() != "")
                {
                    model.ProjectID = int.Parse(row["ProjectID"].ToString());
                }
                if (row["Currency"] != null)
                {
                    model.Currency = row["Currency"].ToString();
                }
                if (row["ExchangeRate"] != null && row["ExchangeRate"].ToString() != "")
                {
                    model.ExchangeRate = decimal.Parse(row["ExchangeRate"].ToString());
                }
                if (row["DiscountRate"] != null && row["DiscountRate"].ToString() != "")
                {
                    model.DiscountRate = decimal.Parse(row["DiscountRate"].ToString());
                }
                if (row["TaxRate"] != null && row["TaxRate"].ToString() != "")
                {
                    model.TaxRate = decimal.Parse(row["TaxRate"].ToString());
                }
                if (row["PayTerm"] != null)
                {
                    model.PayTerm = row["PayTerm"].ToString();
                }
                if (row["AccountsMode"] != null)
                {
                    model.AccountsMode = row["AccountsMode"].ToString();
                }
                if (row["Deposit"] != null && row["Deposit"].ToString() != "")
                {
                    model.Deposit = decimal.Parse(row["Deposit"].ToString());
                }
                if (row["OtherFees"] != null && row["OtherFees"].ToString() != "")
                {
                    model.OtherFees = decimal.Parse(row["OtherFees"].ToString());
                }
                if (row["PlansFactoryDate"] != null && row["PlansFactoryDate"].ToString() != "")
                {
                    model.PlansFactoryDate = DateTime.Parse(row["PlansFactoryDate"].ToString());
                }
                if (row["FactoryDate"] != null && row["FactoryDate"].ToString() != "")
                {
                    model.FactoryDate = DateTime.Parse(row["FactoryDate"].ToString());
                }
                if (row["Transport"] != null)
                {
                    model.Transport = row["Transport"].ToString();
                }
                if (row["DeliveryAddress"] != null)
                {
                    model.DeliveryAddress = row["DeliveryAddress"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["ProjectName"] != null)
                {
                    model.ProjectName = row["ProjectName"].ToString();
                }
                if (row["SupplierName"] != null)
                {
                    model.SupplierName = row["SupplierName"].ToString();
                }
                if (row["LinkMan"] != null)
                {
                    model.LinkMan = row["LinkMan"].ToString();
                }
                if (row["Mobile"] != null)
                {
                    model.Mobile = row["Mobile"].ToString();
                }
                if (row["Principal"] != null)
                {
                    model.Principal = row["Principal"].ToString();
                }
                if (row["curStatus"] != null)
                {
                    model.curStatus = row["curStatus"].ToString();
                }
                if (row["curStatusNo"] != null)
                {
                    model.curStatusNo = row["curStatusNo"].ToString();
                }
                if (row["SubmitPerson"] != null)
                {
                    model.SubmitPerson = row["SubmitPerson"].ToString();
                }
                if (row["SubmitDate"] != null && row["SubmitDate"].ToString() != "")
                {
                    model.SubmitDate = DateTime.Parse(row["SubmitDate"].ToString());
                }
                if (row["Auditor"] != null)
                {
                    model.Auditor = row["Auditor"].ToString();
                }
                if (row["AuditDate"] != null && row["AuditDate"].ToString() != "")
                {
                    model.AuditDate = DateTime.Parse(row["AuditDate"].ToString());
                }
                if (row["creater"] != null)
                {
                    model.creater = row["creater"].ToString();
                }
                if (row["create_date"] != null && row["create_date"].ToString() != "")
                {
                    model.create_date = DateTime.Parse(row["create_date"].ToString());
                }
                if (row["updater"] != null)
                {
                    model.updater = row["updater"].ToString();
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
            strSql.Append("select ID,Code,Buyer,DeliveryDate,ProjectID,Currency,ExchangeRate,DiscountRate,TaxRate,PayTerm,AccountsMode,Deposit,OtherFees,PlansFactoryDate,FactoryDate,Transport,DeliveryAddress,remark,ProjectName,SupplierName,LinkMan,Mobile,Principal,curStatus,curStatusNo,SubmitPerson,SubmitDate,Auditor,AuditDate,creater,create_date,updater,update_date ");
            strSql.Append(" FROM v_PurchaseOrders ");
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
            strSql.Append(" ID,Code,Buyer,DeliveryDate,ProjectID,Currency,ExchangeRate,DiscountRate,TaxRate,PayTerm,AccountsMode,Deposit,OtherFees,PlansFactoryDate,FactoryDate,Transport,DeliveryAddress,remark,ProjectName,SupplierName,LinkMan,Mobile,Principal,curStatus,curStatusNo,SubmitPerson,SubmitDate,Auditor,AuditDate,creater,create_date,updater,update_date ");
            strSql.Append(" FROM v_PurchaseOrders ");
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
            strSql.Append("select count(1) FROM v_PurchaseOrders ");
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
            strSql.Append(")AS Row, T.*  from v_PurchaseOrders T ");
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
            parameters[0].Value = "v_PurchaseOrders";
            parameters[1].Value = "ID";
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
    }
}
