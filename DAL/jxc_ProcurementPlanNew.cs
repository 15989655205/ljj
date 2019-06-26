using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:jxc_ProcurementPlanNew
    /// </summary>
    public partial class jxc_ProcurementPlanNew
    {
        public jxc_ProcurementPlanNew()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from jxc_ProcurementPlanNew");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(Maticsoft.Model.jxc_ProcurementPlanNew model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into jxc_ProcurementPlanNew(");
            strSql.Append("Item,Odd,PlanTypeID,ProjectID,SpaceID,ProductID,ColorID,ColorName,Size,PlanAmount,PurchasedAmount,ExpectedPrice,Discount,PlansPurchaseDate,PlansFactoryDate,ExpectedArrivalDate,PlansSupplier,Supplier,ProductOdd,OrderItem,state,Directions,Submit,SubmitGuy,SubmitDate,Audit,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date)");
            strSql.Append(" values (");
            strSql.Append("@Item,@Odd,@PlanTypeID,@ProjectID,@SpaceID,@ProductID,@ColorID,@ColorName,@Size,@PlanAmount,@PurchasedAmount,@ExpectedPrice,@Discount,@PlansPurchaseDate,@PlansFactoryDate,@ExpectedArrivalDate,@PlansSupplier,@Supplier,@ProductOdd,@OrderItem,@state,@Directions,@Submit,@SubmitGuy,@SubmitDate,@Audit,@AuditDate,@AuditGuy,@remark,@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@n1,@n2,@n3,@show,@show_name,@status,@create_person,@create_date,@update_person,@update_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Item", SqlDbType.Int,4),
					new SqlParameter("@Odd", SqlDbType.NVarChar,50),
					new SqlParameter("@PlanTypeID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@SpaceID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.BigInt,8),
					new SqlParameter("@ColorID", SqlDbType.BigInt,8),
					new SqlParameter("@ColorName", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@PlanAmount", SqlDbType.Decimal,9),
					new SqlParameter("@PurchasedAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ExpectedPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Discount", SqlDbType.Decimal,9),
					new SqlParameter("@PlansPurchaseDate", SqlDbType.DateTime),
					new SqlParameter("@PlansFactoryDate", SqlDbType.DateTime),
					new SqlParameter("@ExpectedArrivalDate", SqlDbType.DateTime),
					new SqlParameter("@PlansSupplier", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductOdd", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderItem", SqlDbType.Int,4),
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
            parameters[0].Value = model.Item;
            parameters[1].Value = model.Odd;
            parameters[2].Value = model.PlanTypeID;
            parameters[3].Value = model.ProjectID;
            parameters[4].Value = model.SpaceID;
            parameters[5].Value = model.ProductID;
            parameters[6].Value = model.ColorID;
            parameters[7].Value = model.ColorName;
            parameters[8].Value = model.Size;
            parameters[9].Value = model.PlanAmount;
            parameters[10].Value = model.PurchasedAmount;
            parameters[11].Value = model.ExpectedPrice;
            parameters[12].Value = model.Discount;
            parameters[13].Value = model.PlansPurchaseDate;
            parameters[14].Value = model.PlansFactoryDate;
            parameters[15].Value = model.ExpectedArrivalDate;
            parameters[16].Value = model.PlansSupplier;
            parameters[17].Value = model.Supplier;
            parameters[18].Value = model.ProductOdd;
            parameters[19].Value = model.OrderItem;
            parameters[20].Value = model.state;
            parameters[21].Value = model.Directions;
            parameters[22].Value = model.Submit;
            parameters[23].Value = model.SubmitGuy;
            parameters[24].Value = model.SubmitDate;
            parameters[25].Value = model.Audit;
            parameters[26].Value = model.AuditDate;
            parameters[27].Value = model.AuditGuy;
            parameters[28].Value = model.remark;
            parameters[29].Value = model.v1;
            parameters[30].Value = model.v2;
            parameters[31].Value = model.v3;
            parameters[32].Value = model.v4;
            parameters[33].Value = model.v5;
            parameters[34].Value = model.v6;
            parameters[35].Value = model.v7;
            parameters[36].Value = model.v8;
            parameters[37].Value = model.v9;
            parameters[38].Value = model.v10;
            parameters[39].Value = model.n1;
            parameters[40].Value = model.n2;
            parameters[41].Value = model.n3;
            parameters[42].Value = model.show;
            parameters[43].Value = model.show_name;
            parameters[44].Value = model.status;
            parameters[45].Value = model.create_person;
            parameters[46].Value = model.create_date;
            parameters[47].Value = model.update_person;
            parameters[48].Value = model.update_date;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Maticsoft.Model.jxc_ProcurementPlanNew model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update jxc_ProcurementPlanNew set ");
            strSql.Append("Item=@Item,");
            strSql.Append("Odd=@Odd,");
            strSql.Append("PlanTypeID=@PlanTypeID,");
            strSql.Append("ProjectID=@ProjectID,");
            strSql.Append("SpaceID=@SpaceID,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("ColorID=@ColorID,");
            strSql.Append("ColorName=@ColorName,");
            strSql.Append("Size=@Size,");
            strSql.Append("PlanAmount=@PlanAmount,");
            strSql.Append("PurchasedAmount=@PurchasedAmount,");
            strSql.Append("ExpectedPrice=@ExpectedPrice,");
            strSql.Append("Discount=@Discount,");
            strSql.Append("PlansPurchaseDate=@PlansPurchaseDate,");
            strSql.Append("PlansFactoryDate=@PlansFactoryDate,");
            strSql.Append("ExpectedArrivalDate=@ExpectedArrivalDate,");
            strSql.Append("PlansSupplier=@PlansSupplier,");
            strSql.Append("Supplier=@Supplier,");
            strSql.Append("ProductOdd=@ProductOdd,");
            strSql.Append("OrderItem=@OrderItem,");
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
					new SqlParameter("@Item", SqlDbType.Int,4),
					new SqlParameter("@Odd", SqlDbType.NVarChar,50),
					new SqlParameter("@PlanTypeID", SqlDbType.Int,4),
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@SpaceID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.BigInt,8),
					new SqlParameter("@ColorID", SqlDbType.BigInt,8),
					new SqlParameter("@ColorName", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@PlanAmount", SqlDbType.Decimal,9),
					new SqlParameter("@PurchasedAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ExpectedPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Discount", SqlDbType.Decimal,9),
					new SqlParameter("@PlansPurchaseDate", SqlDbType.DateTime),
					new SqlParameter("@PlansFactoryDate", SqlDbType.DateTime),
					new SqlParameter("@ExpectedArrivalDate", SqlDbType.DateTime),
					new SqlParameter("@PlansSupplier", SqlDbType.NVarChar,50),
					new SqlParameter("@Supplier", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductOdd", SqlDbType.NVarChar,50),
					new SqlParameter("@OrderItem", SqlDbType.Int,4),
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
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.Item;
            parameters[1].Value = model.Odd;
            parameters[2].Value = model.PlanTypeID;
            parameters[3].Value = model.ProjectID;
            parameters[4].Value = model.SpaceID;
            parameters[5].Value = model.ProductID;
            parameters[6].Value = model.ColorID;
            parameters[7].Value = model.ColorName;
            parameters[8].Value = model.Size;
            parameters[9].Value = model.PlanAmount;
            parameters[10].Value = model.PurchasedAmount;
            parameters[11].Value = model.ExpectedPrice;
            parameters[12].Value = model.Discount;
            parameters[13].Value = model.PlansPurchaseDate;
            parameters[14].Value = model.PlansFactoryDate;
            parameters[15].Value = model.ExpectedArrivalDate;
            parameters[16].Value = model.PlansSupplier;
            parameters[17].Value = model.Supplier;
            parameters[18].Value = model.ProductOdd;
            parameters[19].Value = model.OrderItem;
            parameters[20].Value = model.state;
            parameters[21].Value = model.Directions;
            parameters[22].Value = model.Submit;
            parameters[23].Value = model.SubmitGuy;
            parameters[24].Value = model.SubmitDate;
            parameters[25].Value = model.Audit;
            parameters[26].Value = model.AuditDate;
            parameters[27].Value = model.AuditGuy;
            parameters[28].Value = model.remark;
            parameters[29].Value = model.v1;
            parameters[30].Value = model.v2;
            parameters[31].Value = model.v3;
            parameters[32].Value = model.v4;
            parameters[33].Value = model.v5;
            parameters[34].Value = model.v6;
            parameters[35].Value = model.v7;
            parameters[36].Value = model.v8;
            parameters[37].Value = model.v9;
            parameters[38].Value = model.v10;
            parameters[39].Value = model.n1;
            parameters[40].Value = model.n2;
            parameters[41].Value = model.n3;
            parameters[42].Value = model.show;
            parameters[43].Value = model.show_name;
            parameters[44].Value = model.status;
            parameters[45].Value = model.create_person;
            parameters[46].Value = model.create_date;
            parameters[47].Value = model.update_person;
            parameters[48].Value = model.update_date;
            parameters[49].Value = model.ID;

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
        public bool Delete(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from jxc_ProcurementPlanNew ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
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
            strSql.Append("delete from jxc_ProcurementPlanNew ");
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
        public Maticsoft.Model.jxc_ProcurementPlanNew GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Item,Odd,PlanTypeID,ProjectID,SpaceID,ProductID,ColorID,ColorName,Size,PlanAmount,PurchasedAmount,ExpectedPrice,Discount,PlansPurchaseDate,PlansFactoryDate,ExpectedArrivalDate,PlansSupplier,Supplier,ProductOdd,OrderItem,state,Directions,Submit,SubmitGuy,SubmitDate,Audit,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date from jxc_ProcurementPlanNew ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.jxc_ProcurementPlanNew model = new Maticsoft.Model.jxc_ProcurementPlanNew();
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
        public Maticsoft.Model.jxc_ProcurementPlanNew DataRowToModel(DataRow row)
        {
            Maticsoft.Model.jxc_ProcurementPlanNew model = new Maticsoft.Model.jxc_ProcurementPlanNew();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["Item"] != null && row["Item"].ToString() != "")
                {
                    model.Item = int.Parse(row["Item"].ToString());
                }
                if (row["Odd"] != null)
                {
                    model.Odd = row["Odd"].ToString();
                }
                if (row["PlanTypeID"] != null && row["PlanTypeID"].ToString() != "")
                {
                    model.PlanTypeID = int.Parse(row["PlanTypeID"].ToString());
                }
                if (row["ProjectID"] != null && row["ProjectID"].ToString() != "")
                {
                    model.ProjectID = int.Parse(row["ProjectID"].ToString());
                }
                if (row["SpaceID"] != null && row["SpaceID"].ToString() != "")
                {
                    model.SpaceID = int.Parse(row["SpaceID"].ToString());
                }
                if (row["ProductID"] != null && row["ProductID"].ToString() != "")
                {
                    model.ProductID = long.Parse(row["ProductID"].ToString());
                }
                if (row["ColorID"] != null && row["ColorID"].ToString() != "")
                {
                    model.ColorID = long.Parse(row["ColorID"].ToString());
                }
                if (row["ColorName"] != null)
                {
                    model.ColorName = row["ColorName"].ToString();
                }
                if (row["Size"] != null)
                {
                    model.Size = row["Size"].ToString();
                }
                if (row["PlanAmount"] != null && row["PlanAmount"].ToString() != "")
                {
                    model.PlanAmount = decimal.Parse(row["PlanAmount"].ToString());
                }
                if (row["PurchasedAmount"] != null && row["PurchasedAmount"].ToString() != "")
                {
                    model.PurchasedAmount = decimal.Parse(row["PurchasedAmount"].ToString());
                }
                if (row["ExpectedPrice"] != null && row["ExpectedPrice"].ToString() != "")
                {
                    model.ExpectedPrice = decimal.Parse(row["ExpectedPrice"].ToString());
                }
                if (row["Discount"] != null && row["Discount"].ToString() != "")
                {
                    model.Discount = decimal.Parse(row["Discount"].ToString());
                }
                if (row["PlansPurchaseDate"] != null && row["PlansPurchaseDate"].ToString() != "")
                {
                    model.PlansPurchaseDate = DateTime.Parse(row["PlansPurchaseDate"].ToString());
                }
                if (row["PlansFactoryDate"] != null && row["PlansFactoryDate"].ToString() != "")
                {
                    model.PlansFactoryDate = DateTime.Parse(row["PlansFactoryDate"].ToString());
                }
                if (row["ExpectedArrivalDate"] != null && row["ExpectedArrivalDate"].ToString() != "")
                {
                    model.ExpectedArrivalDate = DateTime.Parse(row["ExpectedArrivalDate"].ToString());
                }
                if (row["PlansSupplier"] != null)
                {
                    model.PlansSupplier = row["PlansSupplier"].ToString();
                }
                if (row["Supplier"] != null)
                {
                    model.Supplier = row["Supplier"].ToString();
                }
                if (row["ProductOdd"] != null)
                {
                    model.ProductOdd = row["ProductOdd"].ToString();
                }
                if (row["OrderItem"] != null && row["OrderItem"].ToString() != "")
                {
                    model.OrderItem = int.Parse(row["OrderItem"].ToString());
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
            strSql.Append("select ID,Item,Odd,PlanTypeID,ProjectID,SpaceID,ProductID,ColorID,ColorName,Size,PlanAmount,PurchasedAmount,ExpectedPrice,Discount,PlansPurchaseDate,PlansFactoryDate,ExpectedArrivalDate,PlansSupplier,Supplier,ProductOdd,OrderItem,state,Directions,Submit,SubmitGuy,SubmitDate,Audit,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM jxc_ProcurementPlanNew ");
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
            strSql.Append(" ID,Item,Odd,PlanTypeID,ProjectID,SpaceID,ProductID,ColorID,ColorName,Size,PlanAmount,PurchasedAmount,ExpectedPrice,Discount,PlansPurchaseDate,PlansFactoryDate,ExpectedArrivalDate,PlansSupplier,Supplier,ProductOdd,OrderItem,state,Directions,Submit,SubmitGuy,SubmitDate,Audit,AuditDate,AuditGuy,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM jxc_ProcurementPlanNew ");
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
            strSql.Append("select count(1) FROM jxc_ProcurementPlanNew ");
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
            strSql.Append(")AS Row, T.*  from jxc_ProcurementPlanNew T ");
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
            parameters[0].Value = "jxc_ProcurementPlanNew";
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
        public string Save(List<Model.v_ProcurementPlan> updateList, string user)
        {
            try
            {
                ArrayList al = new ArrayList();
                StringBuilder sbSql = new StringBuilder();
                //修改
                for (int i = 0; i < updateList.Count; i++)
                {
                    sbSql = new StringBuilder();
                    Model.v_ProcurementPlan model = updateList[i];
                    sbSql.Append("update jxc_ProcurementPlanNew set ExpectedPrice = '" + model.ExpectedPrice.ToString().Trim() + "',");
                    //sbSql.Append("remark = '" + model.remark.Trim() + "',sequence='"+model.sequence+"'");
                    sbSql.Append("Discount = '" + model.Discount.ToString().Trim() + "',");
                    sbSql.Append("PlansPurchaseDate = '" + model.PlansPurchaseDate.ToString().Trim() + "',");
                    sbSql.Append("PlansFactoryDate = '" + model.PlansFactoryDate.ToString().Trim() + "',");
                    sbSql.Append("ExpectedArrivalDate = '" + model.ExpectedArrivalDate.ToString().Trim() + "',");
                    sbSql.Append("PlansSupplier ='" + model.PlansSupplier.ToString().Trim() + "',");
                    sbSql.Append("update_person = '" + user + "',");
                    sbSql.Append("Update_Date =getdate() ,");
                    sbSql.Append("remark = '" + model.remark.Trim() + "'");
                    sbSql.Append(" where ID=" + model.ID + "");
                    al.Add(sbSql.ToString());
                }

                DbHelperSQL.ExecuteSqlTran(al);

                return "success";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }
        #endregion  ExtensionMethod
    }
}
