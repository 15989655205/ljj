using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;
using System.Collections;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:jxc_PurchaseOrders
    /// </summary>
    public partial class jxc_PurchaseOrders
    {
        public jxc_PurchaseOrders()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from jxc_PurchaseOrders");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.jxc_PurchaseOrders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into jxc_PurchaseOrders(");
            strSql.Append("Code,Odd,OrderDate,Buyer,ProjectID,SpaceID,Supplier,SupplierHandled,DeliveryDate,Currency,ExchangeRate,PriceReduction,PayTerm,DiscountRate,Deposit,AccountsMode,TaxRate,OtherFees,PlansFactoryDate,FactoryDate,Transport,DeliveryAddress,state,Directions,Submit,SubmitGuy,SubmitDate,Audit,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date)");
            strSql.Append(" values (");
            strSql.Append("@Code,@Odd,@OrderDate,@Buyer,@ProjectID,@SpaceID,@Supplier,@SupplierHandled,@DeliveryDate,@Currency,@ExchangeRate,@PriceReduction,@PayTerm,@DiscountRate,@Deposit,@AccountsMode,@TaxRate,@OtherFees,@PlansFactoryDate,@FactoryDate,@Transport,@DeliveryAddress,@state,@Directions,@Submit,@SubmitGuy,@SubmitDate,@Audit,@AuditDate,@AuditGuy,@remark,@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@n1,@n2,@n3,@show,@show_name,@status,@create_person,@create_date,@update_person,@update_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Odd", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@Buyer", SqlDbType.NVarChar,50),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@SpaceID", SqlDbType.Int,4),
					new SqlParameter("@Supplier", SqlDbType.NVarChar,50),
					new SqlParameter("@SupplierHandled", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@Currency", SqlDbType.NVarChar,50),
					new SqlParameter("@ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@PriceReduction", SqlDbType.Decimal,9),
					new SqlParameter("@PayTerm", SqlDbType.NVarChar,50),
					new SqlParameter("@DiscountRate", SqlDbType.Decimal,9),
					new SqlParameter("@Deposit", SqlDbType.Decimal,9),
					new SqlParameter("@AccountsMode", SqlDbType.NVarChar,50),
					new SqlParameter("@TaxRate", SqlDbType.Decimal,9),
					new SqlParameter("@OtherFees", SqlDbType.Decimal,9),
					new SqlParameter("@PlansFactoryDate", SqlDbType.DateTime),
					new SqlParameter("@FactoryDate", SqlDbType.DateTime),
					new SqlParameter("@Transport", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@Directions", SqlDbType.NVarChar,200),
					new SqlParameter("@Submit", SqlDbType.Int,4),
					new SqlParameter("@SubmitGuy", SqlDbType.VarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@AuditGuy", SqlDbType.VarChar,50),
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
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Odd;
            parameters[2].Value = model.OrderDate;
            parameters[3].Value = model.Buyer;
            parameters[4].Value = model.ProjectID;
            parameters[5].Value = model.SpaceID;
            parameters[6].Value = model.Supplier;
            parameters[7].Value = model.SupplierHandled;
            parameters[8].Value = model.DeliveryDate;
            parameters[9].Value = model.Currency;
            parameters[10].Value = model.ExchangeRate;
            parameters[11].Value = model.PriceReduction;
            parameters[12].Value = model.PayTerm;
            parameters[13].Value = model.DiscountRate;
            parameters[14].Value = model.Deposit;
            parameters[15].Value = model.AccountsMode;
            parameters[16].Value = model.TaxRate;
            parameters[17].Value = model.OtherFees;
            parameters[18].Value = model.PlansFactoryDate;
            parameters[19].Value = model.FactoryDate;
            parameters[20].Value = model.Transport;
            parameters[21].Value = model.DeliveryAddress;
            parameters[22].Value = model.state;
            parameters[23].Value = model.Directions;
            parameters[24].Value = model.Submit;
            parameters[25].Value = model.SubmitGuy;
            parameters[26].Value = model.SubmitDate;
            parameters[27].Value = model.Audit;
            parameters[28].Value = model.AuditDate;
            parameters[29].Value = model.AuditGuy;
            parameters[30].Value = model.remark;
            parameters[31].Value = model.v1;
            parameters[32].Value = model.v2;
            parameters[33].Value = model.v3;
            parameters[34].Value = model.v4;
            parameters[35].Value = model.v5;
            parameters[36].Value = model.v6;
            parameters[37].Value = model.v7;
            parameters[38].Value = model.v8;
            parameters[39].Value = model.v9;
            parameters[40].Value = model.v10;
            parameters[41].Value = model.n1;
            parameters[42].Value = model.n2;
            parameters[43].Value = model.n3;
            parameters[44].Value = model.show;
            parameters[45].Value = model.show_name;
            parameters[46].Value = model.status;
            parameters[47].Value = model.create_person;
            parameters[48].Value = model.create_date;
            parameters[49].Value = model.update_person;
            parameters[50].Value = model.update_date;

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
        public bool Update(Maticsoft.Model.jxc_PurchaseOrders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update jxc_PurchaseOrders set ");
            strSql.Append("Code=@Code,");
            strSql.Append("Odd=@Odd,");
            strSql.Append("OrderDate=@OrderDate,");
            strSql.Append("Buyer=@Buyer,");
            strSql.Append("ProjectID=@ProjectID,");
            strSql.Append("SpaceID=@SpaceID,");
            strSql.Append("Supplier=@Supplier,");
            strSql.Append("SupplierHandled=@SupplierHandled,");
            strSql.Append("DeliveryDate=@DeliveryDate,");
            strSql.Append("Currency=@Currency,");
            strSql.Append("ExchangeRate=@ExchangeRate,");
            strSql.Append("PriceReduction=@PriceReduction,");
            strSql.Append("PayTerm=@PayTerm,");
            strSql.Append("DiscountRate=@DiscountRate,");
            strSql.Append("Deposit=@Deposit,");
            strSql.Append("AccountsMode=@AccountsMode,");
            strSql.Append("TaxRate=@TaxRate,");
            strSql.Append("OtherFees=@OtherFees,");
            strSql.Append("PlansFactoryDate=@PlansFactoryDate,");
            strSql.Append("FactoryDate=@FactoryDate,");
            strSql.Append("Transport=@Transport,");
            strSql.Append("DeliveryAddress=@DeliveryAddress,");
            strSql.Append("state=@state,");
            strSql.Append("Directions=@Directions,");
            strSql.Append("Submit=@Submit,");
            strSql.Append("SubmitGuy=@SubmitGuy,");
            strSql.Append("SubmitDate=@SubmitDate,");
            strSql.Append("Audit=@Audit,");
            strSql.Append("AuditDate=@AuditDate,");
            strSql.Append("AuditGuy=@AuditGuy,");
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
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.VarChar,50),
					new SqlParameter("@Odd", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderDate", SqlDbType.DateTime),
					new SqlParameter("@Buyer", SqlDbType.NVarChar,50),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@SpaceID", SqlDbType.Int,4),
					new SqlParameter("@Supplier", SqlDbType.NVarChar,50),
					new SqlParameter("@SupplierHandled", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@Currency", SqlDbType.NVarChar,50),
					new SqlParameter("@ExchangeRate", SqlDbType.Decimal,9),
					new SqlParameter("@PriceReduction", SqlDbType.Decimal,9),
					new SqlParameter("@PayTerm", SqlDbType.NVarChar,50),
					new SqlParameter("@DiscountRate", SqlDbType.Decimal,9),
					new SqlParameter("@Deposit", SqlDbType.Decimal,9),
					new SqlParameter("@AccountsMode", SqlDbType.NVarChar,50),
					new SqlParameter("@TaxRate", SqlDbType.Decimal,9),
					new SqlParameter("@OtherFees", SqlDbType.Decimal,9),
					new SqlParameter("@PlansFactoryDate", SqlDbType.DateTime),
					new SqlParameter("@FactoryDate", SqlDbType.DateTime),
					new SqlParameter("@Transport", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryAddress", SqlDbType.NVarChar,200),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@Directions", SqlDbType.NVarChar,200),
					new SqlParameter("@Submit", SqlDbType.Int,4),
					new SqlParameter("@SubmitGuy", SqlDbType.VarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@AuditGuy", SqlDbType.VarChar,50),
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
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Odd;
            parameters[2].Value = model.OrderDate;
            parameters[3].Value = model.Buyer;
            parameters[4].Value = model.ProjectID;
            parameters[5].Value = model.SpaceID;
            parameters[6].Value = model.Supplier;
            parameters[7].Value = model.SupplierHandled;
            parameters[8].Value = model.DeliveryDate;
            parameters[9].Value = model.Currency;
            parameters[10].Value = model.ExchangeRate;
            parameters[11].Value = model.PriceReduction;
            parameters[12].Value = model.PayTerm;
            parameters[13].Value = model.DiscountRate;
            parameters[14].Value = model.Deposit;
            parameters[15].Value = model.AccountsMode;
            parameters[16].Value = model.TaxRate;
            parameters[17].Value = model.OtherFees;
            parameters[18].Value = model.PlansFactoryDate;
            parameters[19].Value = model.FactoryDate;
            parameters[20].Value = model.Transport;
            parameters[21].Value = model.DeliveryAddress;
            parameters[22].Value = model.state;
            parameters[23].Value = model.Directions;
            parameters[24].Value = model.Submit;
            parameters[25].Value = model.SubmitGuy;
            parameters[26].Value = model.SubmitDate;
            parameters[27].Value = model.Audit;
            parameters[28].Value = model.AuditDate;
            parameters[29].Value = model.AuditGuy;
            parameters[30].Value = model.remark;
            parameters[31].Value = model.v1;
            parameters[32].Value = model.v2;
            parameters[33].Value = model.v3;
            parameters[34].Value = model.v4;
            parameters[35].Value = model.v5;
            parameters[36].Value = model.v6;
            parameters[37].Value = model.v7;
            parameters[38].Value = model.v8;
            parameters[39].Value = model.v9;
            parameters[40].Value = model.v10;
            parameters[41].Value = model.n1;
            parameters[42].Value = model.n2;
            parameters[43].Value = model.n3;
            parameters[44].Value = model.show;
            parameters[45].Value = model.show_name;
            parameters[46].Value = model.status;
            parameters[47].Value = model.create_person;
            parameters[48].Value = model.create_date;
            parameters[49].Value = model.update_person;
            parameters[50].Value = model.update_date;
            parameters[51].Value = model.ID;

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
            strSql.Append("delete from jxc_PurchaseOrders ");
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
            strSql.Append("delete from jxc_PurchaseOrders ");
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
        public Maticsoft.Model.jxc_PurchaseOrders GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Code,Odd,OrderDate,Buyer,ProjectID,SpaceID,Supplier,SupplierHandled,DeliveryDate,Currency,ExchangeRate,PriceReduction,PayTerm,DiscountRate,Deposit,AccountsMode,TaxRate,OtherFees,PlansFactoryDate,FactoryDate,Transport,DeliveryAddress,state,Directions,Submit,SubmitGuy,SubmitDate,Audit,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date from jxc_PurchaseOrders ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.jxc_PurchaseOrders model = new Maticsoft.Model.jxc_PurchaseOrders();
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
        public Maticsoft.Model.jxc_PurchaseOrders DataRowToModel(DataRow row)
        {
            Maticsoft.Model.jxc_PurchaseOrders model = new Maticsoft.Model.jxc_PurchaseOrders();
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
                if (row["Odd"] != null)
                {
                    model.Odd = row["Odd"].ToString();
                }
                if (row["OrderDate"] != null && row["OrderDate"].ToString() != "")
                {
                    model.OrderDate = DateTime.Parse(row["OrderDate"].ToString());
                }
                if (row["Buyer"] != null)
                {
                    model.Buyer = row["Buyer"].ToString();
                }
                if (row["ProjectID"] != null && row["ProjectID"].ToString() != "")
                {
                    model.ProjectID = int.Parse(row["ProjectID"].ToString());
                }
                if (row["SpaceID"] != null && row["SpaceID"].ToString() != "")
                {
                    model.SpaceID = int.Parse(row["SpaceID"].ToString());
                }
                if (row["Supplier"] != null)
                {
                    model.Supplier = row["Supplier"].ToString();
                }
                if (row["SupplierHandled"] != null)
                {
                    model.SupplierHandled = row["SupplierHandled"].ToString();
                }
                if (row["DeliveryDate"] != null && row["DeliveryDate"].ToString() != "")
                {
                    model.DeliveryDate = DateTime.Parse(row["DeliveryDate"].ToString());
                }
                if (row["Currency"] != null)
                {
                    model.Currency = row["Currency"].ToString();
                }
                if (row["ExchangeRate"] != null && row["ExchangeRate"].ToString() != "")
                {
                    model.ExchangeRate = decimal.Parse(row["ExchangeRate"].ToString());
                }
                if (row["PriceReduction"] != null && row["PriceReduction"].ToString() != "")
                {
                    model.PriceReduction = decimal.Parse(row["PriceReduction"].ToString());
                }
                if (row["PayTerm"] != null)
                {
                    model.PayTerm = row["PayTerm"].ToString();
                }
                if (row["DiscountRate"] != null && row["DiscountRate"].ToString() != "")
                {
                    model.DiscountRate = decimal.Parse(row["DiscountRate"].ToString());
                }
                if (row["Deposit"] != null && row["Deposit"].ToString() != "")
                {
                    model.Deposit = decimal.Parse(row["Deposit"].ToString());
                }
                if (row["AccountsMode"] != null)
                {
                    model.AccountsMode = row["AccountsMode"].ToString();
                }
                if (row["TaxRate"] != null && row["TaxRate"].ToString() != "")
                {
                    model.TaxRate = decimal.Parse(row["TaxRate"].ToString());
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
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
                }
                if (row["Directions"] != null)
                {
                    model.Directions = row["Directions"].ToString();
                }
                if (row["Submit"] != null && row["Submit"].ToString() != "")
                {
                    model.Submit = int.Parse(row["Submit"].ToString());
                }
                if (row["SubmitGuy"] != null)
                {
                    model.SubmitGuy = row["SubmitGuy"].ToString();
                }
                if (row["SubmitDate"] != null && row["SubmitDate"].ToString() != "")
                {
                    model.SubmitDate = DateTime.Parse(row["SubmitDate"].ToString());
                }
                if (row["Audit"] != null && row["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(row["Audit"].ToString());
                }
                if (row["AuditDate"] != null && row["AuditDate"].ToString() != "")
                {
                    model.AuditDate = DateTime.Parse(row["AuditDate"].ToString());
                }
                if (row["AuditGuy"] != null)
                {
                    model.AuditGuy = row["AuditGuy"].ToString();
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
            strSql.Append("select ID,Code,Odd,OrderDate,Buyer,ProjectID,SpaceID,Supplier,SupplierHandled,DeliveryDate,Currency,ExchangeRate,PriceReduction,PayTerm,DiscountRate,Deposit,AccountsMode,TaxRate,OtherFees,PlansFactoryDate,FactoryDate,Transport,DeliveryAddress,state,Directions,Submit,SubmitGuy,SubmitDate,Audit,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM jxc_PurchaseOrders ");
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
            strSql.Append(" ID,Code,Odd,OrderDate,Buyer,ProjectID,SpaceID,Supplier,SupplierHandled,DeliveryDate,Currency,ExchangeRate,PriceReduction,PayTerm,DiscountRate,Deposit,AccountsMode,TaxRate,OtherFees,PlansFactoryDate,FactoryDate,Transport,DeliveryAddress,state,Directions,Submit,SubmitGuy,SubmitDate,Audit,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM jxc_PurchaseOrders ");
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
            strSql.Append("select count(1) FROM jxc_PurchaseOrders ");
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
            strSql.Append(")AS Row, T.*  from jxc_PurchaseOrders T ");
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
            parameters[0].Value = "jxc_PurchaseOrders";
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


        public bool Edit(List<Model.v_jxc_PurchaseOrdersItems> insertList, List<Model.v_jxc_PurchaseOrdersItems> updateList, List<Model.v_jxc_PurchaseOrdersItems> delList, long userId, long sid, decimal Deposit, decimal OtherFees, string Transport, string DeliveryAddress, string remark, DateTime FactoryDate)
        {
            ArrayList arr = new ArrayList();
            StringBuilder sbSql = new StringBuilder();

            sbSql.Append("update jxc_PurchaseOrders set Deposit=" + Deposit + ",OtherFees=" + OtherFees + ",Transport='" + Transport + "',DeliveryAddress='" + DeliveryAddress + "',remark='" + remark + "',FactoryDate='"+FactoryDate+"'  where ID=" + sid + "");
            arr.Add(sbSql);
            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.v_jxc_PurchaseOrdersItems model = updateList[i];
                sbSql.Append("update jxc_PurchaseOrdersItems set PriceExcl='" + model.PriceExcl + "',TaxPrice='" + model.TaxPrice + "',DiscountRate='" + model.DiscountRate + "'");
                sbSql.Append(",OrderingProductDescription='" + model.OrderingProductDescription + "',update_date=getdate(),update_person='" + userId + "',remark='" + model.remark + "'");
                sbSql.Append(" where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }


            DbHelperSQL.ExecuteSqlTran(arr);
            return true;
        }

        #endregion  ExtensionMethod
    }
}
