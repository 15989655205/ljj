using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:v_ProjectMaterialAToB
    /// </summary>
    public partial class v_ProjectMaterialAToB
    {
        public v_ProjectMaterialAToB()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UnitName, string Unit, decimal Amount, string Color, string Size, string Brand, int projectSpaceID, int Submit, string SubmitPerson, DateTime SubmitDate, int Audit, string Auditor, DateTime AuditDate, int Checking, string CheckPerson, DateTime CheckDate, int placeID, int spaceID, int projectID, long productID, string place, string space, string projectName, string productCode, string productName, string Quality, string NFK, long TypeID, string productTYpeName, int productTypeRootID, string ProductTypeRoot, string supplierID, string supplierCode, string supplierName, string supplierMobile, string colorB, string brandB, string remarkB, string Manufacturer)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_ProjectMaterialAToB");
            strSql.Append(" where UnitName=@UnitName and Unit=@Unit and Amount=@Amount and Color=@Color and Size=@Size and Brand=@Brand and projectSpaceID=@projectSpaceID and Submit=@Submit and SubmitPerson=@SubmitPerson and SubmitDate=@SubmitDate and Audit=@Audit and Auditor=@Auditor and AuditDate=@AuditDate and Checking=@Checking and CheckPerson=@CheckPerson and CheckDate=@CheckDate and placeID=@placeID and spaceID=@spaceID and projectID=@projectID and productID=@productID and place=@place and space=@space and projectName=@projectName and productCode=@productCode and productName=@productName and Quality=@Quality and NFK=@NFK and TypeID=@TypeID and productTYpeName=@productTYpeName and productTypeRootID=@productTypeRootID and ProductTypeRoot=@ProductTypeRoot and supplierID=@supplierID and supplierCode=@supplierCode and supplierName=@supplierName and supplierMobile=@supplierMobile and colorB=@colorB and brandB=@brandB and remarkB=@remarkB and Manufacturer=@Manufacturer ");
            SqlParameter[] parameters = {
					new SqlParameter("@UnitName", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Amount", SqlDbType.Decimal,17),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@projectSpaceID", SqlDbType.Int,4),
					new SqlParameter("@Submit", SqlDbType.Int,4),
					new SqlParameter("@SubmitPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@Auditor", SqlDbType.NVarChar,50),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@Checking", SqlDbType.Int,4),
					new SqlParameter("@CheckPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@placeID", SqlDbType.Int,4),
					new SqlParameter("@spaceID", SqlDbType.Int,4),
					new SqlParameter("@projectID", SqlDbType.Int,4),
					new SqlParameter("@productID", SqlDbType.BigInt,8),
					new SqlParameter("@place", SqlDbType.NVarChar,100),
					new SqlParameter("@space", SqlDbType.NVarChar,100),
					new SqlParameter("@projectName", SqlDbType.NVarChar,100),
					new SqlParameter("@productCode", SqlDbType.NVarChar,50),
					new SqlParameter("@productName", SqlDbType.NVarChar,50),
					new SqlParameter("@Quality", SqlDbType.NVarChar,50),
					new SqlParameter("@NFK", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeID", SqlDbType.BigInt,8),
					new SqlParameter("@productTYpeName", SqlDbType.NVarChar,50),
					new SqlParameter("@productTypeRootID", SqlDbType.Int,4),
					new SqlParameter("@ProductTypeRoot", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierID", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierCode", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierName", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierMobile", SqlDbType.NVarChar,50),
					new SqlParameter("@colorB", SqlDbType.NVarChar,50),
					new SqlParameter("@brandB", SqlDbType.NVarChar,50),
					new SqlParameter("@remarkB", SqlDbType.NVarChar,-1),
					new SqlParameter("@Manufacturer", SqlDbType.NVarChar,50)			};
            parameters[0].Value = UnitName;
            parameters[1].Value = Unit;
            parameters[2].Value = Amount;
            parameters[3].Value = Color;
            parameters[4].Value = Size;
            parameters[5].Value = Brand;
            parameters[6].Value = projectSpaceID;
            parameters[7].Value = Submit;
            parameters[8].Value = SubmitPerson;
            parameters[9].Value = SubmitDate;
            parameters[10].Value = Audit;
            parameters[11].Value = Auditor;
            parameters[12].Value = AuditDate;
            parameters[13].Value = Checking;
            parameters[14].Value = CheckPerson;
            parameters[15].Value = CheckDate;
            parameters[16].Value = placeID;
            parameters[17].Value = spaceID;
            parameters[18].Value = projectID;
            parameters[19].Value = productID;
            parameters[20].Value = place;
            parameters[21].Value = space;
            parameters[22].Value = projectName;
            parameters[23].Value = productCode;
            parameters[24].Value = productName;
            parameters[25].Value = Quality;
            parameters[26].Value = NFK;
            parameters[27].Value = TypeID;
            parameters[28].Value = productTYpeName;
            parameters[29].Value = productTypeRootID;
            parameters[30].Value = ProductTypeRoot;
            parameters[31].Value = supplierID;
            parameters[32].Value = supplierCode;
            parameters[33].Value = supplierName;
            parameters[34].Value = supplierMobile;
            parameters[35].Value = colorB;
            parameters[36].Value = brandB;
            parameters[37].Value = remarkB;
            parameters[38].Value = Manufacturer;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.v_ProjectMaterialAToB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into v_ProjectMaterialAToB(");
            strSql.Append("UnitName,Unit,Amount,Color,Size,Brand,projectSpaceID,Submit,SubmitPerson,SubmitDate,Audit,Auditor,AuditDate,Checking,CheckPerson,CheckDate,placeID,spaceID,projectID,productID,place,space,projectName,productCode,productName,Quality,NFK,TypeID,productTYpeName,productTypeRootID,ProductTypeRoot,supplierID,supplierCode,supplierName,supplierMobile,colorB,brandB,remarkB,Manufacturer)");
            strSql.Append(" values (");
            strSql.Append("@UnitName,@Unit,@Amount,@Color,@Size,@Brand,@projectSpaceID,@Submit,@SubmitPerson,@SubmitDate,@Audit,@Auditor,@AuditDate,@Checking,@CheckPerson,@CheckDate,@placeID,@spaceID,@projectID,@productID,@place,@space,@projectName,@productCode,@productName,@Quality,@NFK,@TypeID,@productTYpeName,@productTypeRootID,@ProductTypeRoot,@supplierID,@supplierCode,@supplierName,@supplierMobile,@colorB,@brandB,@remarkB,@Manufacturer)");
            SqlParameter[] parameters = {
					new SqlParameter("@UnitName", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Amount", SqlDbType.Decimal,17),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@projectSpaceID", SqlDbType.Int,4),
					new SqlParameter("@Submit", SqlDbType.Int,4),
					new SqlParameter("@SubmitPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@Auditor", SqlDbType.NVarChar,50),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@Checking", SqlDbType.Int,4),
					new SqlParameter("@CheckPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@placeID", SqlDbType.Int,4),
					new SqlParameter("@spaceID", SqlDbType.Int,4),
					new SqlParameter("@projectID", SqlDbType.Int,4),
					new SqlParameter("@productID", SqlDbType.BigInt,8),
					new SqlParameter("@place", SqlDbType.NVarChar,100),
					new SqlParameter("@space", SqlDbType.NVarChar,100),
					new SqlParameter("@projectName", SqlDbType.NVarChar,100),
					new SqlParameter("@productCode", SqlDbType.NVarChar,50),
					new SqlParameter("@productName", SqlDbType.NVarChar,50),
					new SqlParameter("@Quality", SqlDbType.NVarChar,50),
					new SqlParameter("@NFK", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeID", SqlDbType.BigInt,8),
					new SqlParameter("@productTYpeName", SqlDbType.NVarChar,50),
					new SqlParameter("@productTypeRootID", SqlDbType.Int,4),
					new SqlParameter("@ProductTypeRoot", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierID", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierCode", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierName", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierMobile", SqlDbType.NVarChar,50),
					new SqlParameter("@colorB", SqlDbType.NVarChar,50),
					new SqlParameter("@brandB", SqlDbType.NVarChar,50),
					new SqlParameter("@remarkB", SqlDbType.NVarChar,-1),
					new SqlParameter("@Manufacturer", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UnitName;
            parameters[1].Value = model.Unit;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.Color;
            parameters[4].Value = model.Size;
            parameters[5].Value = model.Brand;
            parameters[6].Value = model.projectSpaceID;
            parameters[7].Value = model.Submit;
            parameters[8].Value = model.SubmitPerson;
            parameters[9].Value = model.SubmitDate;
            parameters[10].Value = model.Audit;
            parameters[11].Value = model.Auditor;
            parameters[12].Value = model.AuditDate;
            parameters[13].Value = model.Checking;
            parameters[14].Value = model.CheckPerson;
            parameters[15].Value = model.CheckDate;
            parameters[16].Value = model.placeID;
            parameters[17].Value = model.spaceID;
            parameters[18].Value = model.projectID;
            parameters[19].Value = model.productID;
            parameters[20].Value = model.place;
            parameters[21].Value = model.space;
            parameters[22].Value = model.projectName;
            parameters[23].Value = model.productCode;
            parameters[24].Value = model.productName;
            parameters[25].Value = model.Quality;
            parameters[26].Value = model.NFK;
            parameters[27].Value = model.TypeID;
            parameters[28].Value = model.productTYpeName;
            parameters[29].Value = model.productTypeRootID;
            parameters[30].Value = model.ProductTypeRoot;
            parameters[31].Value = model.supplierID;
            parameters[32].Value = model.supplierCode;
            parameters[33].Value = model.supplierName;
            parameters[34].Value = model.supplierMobile;
            parameters[35].Value = model.colorB;
            parameters[36].Value = model.brandB;
            parameters[37].Value = model.remarkB;
            parameters[38].Value = model.Manufacturer;

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
        public bool Update(Maticsoft.Model.v_ProjectMaterialAToB model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_ProjectMaterialAToB set ");
            strSql.Append("UnitName=@UnitName,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("Amount=@Amount,");
            strSql.Append("Color=@Color,");
            strSql.Append("Size=@Size,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("projectSpaceID=@projectSpaceID,");
            strSql.Append("Submit=@Submit,");
            strSql.Append("SubmitPerson=@SubmitPerson,");
            strSql.Append("SubmitDate=@SubmitDate,");
            strSql.Append("Audit=@Audit,");
            strSql.Append("Auditor=@Auditor,");
            strSql.Append("AuditDate=@AuditDate,");
            strSql.Append("Checking=@Checking,");
            strSql.Append("CheckPerson=@CheckPerson,");
            strSql.Append("CheckDate=@CheckDate,");
            strSql.Append("placeID=@placeID,");
            strSql.Append("spaceID=@spaceID,");
            strSql.Append("projectID=@projectID,");
            strSql.Append("productID=@productID,");
            strSql.Append("place=@place,");
            strSql.Append("space=@space,");
            strSql.Append("projectName=@projectName,");
            strSql.Append("productCode=@productCode,");
            strSql.Append("productName=@productName,");
            strSql.Append("Quality=@Quality,");
            strSql.Append("NFK=@NFK,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("productTYpeName=@productTYpeName,");
            strSql.Append("productTypeRootID=@productTypeRootID,");
            strSql.Append("ProductTypeRoot=@ProductTypeRoot,");
            strSql.Append("supplierID=@supplierID,");
            strSql.Append("supplierCode=@supplierCode,");
            strSql.Append("supplierName=@supplierName,");
            strSql.Append("supplierMobile=@supplierMobile,");
            strSql.Append("colorB=@colorB,");
            strSql.Append("brandB=@brandB,");
            strSql.Append("remarkB=@remarkB,");
            strSql.Append("Manufacturer=@Manufacturer");
            strSql.Append(" where UnitName=@UnitName and Unit=@Unit and Amount=@Amount and Color=@Color and Size=@Size and Brand=@Brand and projectSpaceID=@projectSpaceID and Submit=@Submit and SubmitPerson=@SubmitPerson and SubmitDate=@SubmitDate and Audit=@Audit and Auditor=@Auditor and AuditDate=@AuditDate and Checking=@Checking and CheckPerson=@CheckPerson and CheckDate=@CheckDate and placeID=@placeID and spaceID=@spaceID and projectID=@projectID and productID=@productID and place=@place and space=@space and projectName=@projectName and productCode=@productCode and productName=@productName and Quality=@Quality and NFK=@NFK and TypeID=@TypeID and productTYpeName=@productTYpeName and productTypeRootID=@productTypeRootID and ProductTypeRoot=@ProductTypeRoot and supplierID=@supplierID and supplierCode=@supplierCode and supplierName=@supplierName and supplierMobile=@supplierMobile and colorB=@colorB and brandB=@brandB and remarkB=@remarkB and Manufacturer=@Manufacturer ");
            SqlParameter[] parameters = {
					new SqlParameter("@UnitName", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Amount", SqlDbType.Decimal,17),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@projectSpaceID", SqlDbType.Int,4),
					new SqlParameter("@Submit", SqlDbType.Int,4),
					new SqlParameter("@SubmitPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@Auditor", SqlDbType.NVarChar,50),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@Checking", SqlDbType.Int,4),
					new SqlParameter("@CheckPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@placeID", SqlDbType.Int,4),
					new SqlParameter("@spaceID", SqlDbType.Int,4),
					new SqlParameter("@projectID", SqlDbType.Int,4),
					new SqlParameter("@productID", SqlDbType.BigInt,8),
					new SqlParameter("@place", SqlDbType.NVarChar,100),
					new SqlParameter("@space", SqlDbType.NVarChar,100),
					new SqlParameter("@projectName", SqlDbType.NVarChar,100),
					new SqlParameter("@productCode", SqlDbType.NVarChar,50),
					new SqlParameter("@productName", SqlDbType.NVarChar,50),
					new SqlParameter("@Quality", SqlDbType.NVarChar,50),
					new SqlParameter("@NFK", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeID", SqlDbType.BigInt,8),
					new SqlParameter("@productTYpeName", SqlDbType.NVarChar,50),
					new SqlParameter("@productTypeRootID", SqlDbType.Int,4),
					new SqlParameter("@ProductTypeRoot", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierID", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierCode", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierName", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierMobile", SqlDbType.NVarChar,50),
					new SqlParameter("@colorB", SqlDbType.NVarChar,50),
					new SqlParameter("@brandB", SqlDbType.NVarChar,50),
					new SqlParameter("@remarkB", SqlDbType.NVarChar,-1),
					new SqlParameter("@Manufacturer", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UnitName;
            parameters[1].Value = model.Unit;
            parameters[2].Value = model.Amount;
            parameters[3].Value = model.Color;
            parameters[4].Value = model.Size;
            parameters[5].Value = model.Brand;
            parameters[6].Value = model.projectSpaceID;
            parameters[7].Value = model.Submit;
            parameters[8].Value = model.SubmitPerson;
            parameters[9].Value = model.SubmitDate;
            parameters[10].Value = model.Audit;
            parameters[11].Value = model.Auditor;
            parameters[12].Value = model.AuditDate;
            parameters[13].Value = model.Checking;
            parameters[14].Value = model.CheckPerson;
            parameters[15].Value = model.CheckDate;
            parameters[16].Value = model.placeID;
            parameters[17].Value = model.spaceID;
            parameters[18].Value = model.projectID;
            parameters[19].Value = model.productID;
            parameters[20].Value = model.place;
            parameters[21].Value = model.space;
            parameters[22].Value = model.projectName;
            parameters[23].Value = model.productCode;
            parameters[24].Value = model.productName;
            parameters[25].Value = model.Quality;
            parameters[26].Value = model.NFK;
            parameters[27].Value = model.TypeID;
            parameters[28].Value = model.productTYpeName;
            parameters[29].Value = model.productTypeRootID;
            parameters[30].Value = model.ProductTypeRoot;
            parameters[31].Value = model.supplierID;
            parameters[32].Value = model.supplierCode;
            parameters[33].Value = model.supplierName;
            parameters[34].Value = model.supplierMobile;
            parameters[35].Value = model.colorB;
            parameters[36].Value = model.brandB;
            parameters[37].Value = model.remarkB;
            parameters[38].Value = model.Manufacturer;

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
        public bool Delete(string UnitName, string Unit, decimal Amount, string Color, string Size, string Brand, int projectSpaceID, int Submit, string SubmitPerson, DateTime SubmitDate, int Audit, string Auditor, DateTime AuditDate, int Checking, string CheckPerson, DateTime CheckDate, int placeID, int spaceID, int projectID, long productID, string place, string space, string projectName, string productCode, string productName, string Quality, string NFK, long TypeID, string productTYpeName, int productTypeRootID, string ProductTypeRoot, string supplierID, string supplierCode, string supplierName, string supplierMobile, string colorB, string brandB, string remarkB, string Manufacturer)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_ProjectMaterialAToB ");
            strSql.Append(" where UnitName=@UnitName and Unit=@Unit and Amount=@Amount and Color=@Color and Size=@Size and Brand=@Brand and projectSpaceID=@projectSpaceID and Submit=@Submit and SubmitPerson=@SubmitPerson and SubmitDate=@SubmitDate and Audit=@Audit and Auditor=@Auditor and AuditDate=@AuditDate and Checking=@Checking and CheckPerson=@CheckPerson and CheckDate=@CheckDate and placeID=@placeID and spaceID=@spaceID and projectID=@projectID and productID=@productID and place=@place and space=@space and projectName=@projectName and productCode=@productCode and productName=@productName and Quality=@Quality and NFK=@NFK and TypeID=@TypeID and productTYpeName=@productTYpeName and productTypeRootID=@productTypeRootID and ProductTypeRoot=@ProductTypeRoot and supplierID=@supplierID and supplierCode=@supplierCode and supplierName=@supplierName and supplierMobile=@supplierMobile and colorB=@colorB and brandB=@brandB and remarkB=@remarkB and Manufacturer=@Manufacturer ");
            SqlParameter[] parameters = {
					new SqlParameter("@UnitName", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Amount", SqlDbType.Decimal,17),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@projectSpaceID", SqlDbType.Int,4),
					new SqlParameter("@Submit", SqlDbType.Int,4),
					new SqlParameter("@SubmitPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@Auditor", SqlDbType.NVarChar,50),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@Checking", SqlDbType.Int,4),
					new SqlParameter("@CheckPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@placeID", SqlDbType.Int,4),
					new SqlParameter("@spaceID", SqlDbType.Int,4),
					new SqlParameter("@projectID", SqlDbType.Int,4),
					new SqlParameter("@productID", SqlDbType.BigInt,8),
					new SqlParameter("@place", SqlDbType.NVarChar,100),
					new SqlParameter("@space", SqlDbType.NVarChar,100),
					new SqlParameter("@projectName", SqlDbType.NVarChar,100),
					new SqlParameter("@productCode", SqlDbType.NVarChar,50),
					new SqlParameter("@productName", SqlDbType.NVarChar,50),
					new SqlParameter("@Quality", SqlDbType.NVarChar,50),
					new SqlParameter("@NFK", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeID", SqlDbType.BigInt,8),
					new SqlParameter("@productTYpeName", SqlDbType.NVarChar,50),
					new SqlParameter("@productTypeRootID", SqlDbType.Int,4),
					new SqlParameter("@ProductTypeRoot", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierID", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierCode", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierName", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierMobile", SqlDbType.NVarChar,50),
					new SqlParameter("@colorB", SqlDbType.NVarChar,50),
					new SqlParameter("@brandB", SqlDbType.NVarChar,50),
					new SqlParameter("@remarkB", SqlDbType.NVarChar,-1),
					new SqlParameter("@Manufacturer", SqlDbType.NVarChar,50)			};
            parameters[0].Value = UnitName;
            parameters[1].Value = Unit;
            parameters[2].Value = Amount;
            parameters[3].Value = Color;
            parameters[4].Value = Size;
            parameters[5].Value = Brand;
            parameters[6].Value = projectSpaceID;
            parameters[7].Value = Submit;
            parameters[8].Value = SubmitPerson;
            parameters[9].Value = SubmitDate;
            parameters[10].Value = Audit;
            parameters[11].Value = Auditor;
            parameters[12].Value = AuditDate;
            parameters[13].Value = Checking;
            parameters[14].Value = CheckPerson;
            parameters[15].Value = CheckDate;
            parameters[16].Value = placeID;
            parameters[17].Value = spaceID;
            parameters[18].Value = projectID;
            parameters[19].Value = productID;
            parameters[20].Value = place;
            parameters[21].Value = space;
            parameters[22].Value = projectName;
            parameters[23].Value = productCode;
            parameters[24].Value = productName;
            parameters[25].Value = Quality;
            parameters[26].Value = NFK;
            parameters[27].Value = TypeID;
            parameters[28].Value = productTYpeName;
            parameters[29].Value = productTypeRootID;
            parameters[30].Value = ProductTypeRoot;
            parameters[31].Value = supplierID;
            parameters[32].Value = supplierCode;
            parameters[33].Value = supplierName;
            parameters[34].Value = supplierMobile;
            parameters[35].Value = colorB;
            parameters[36].Value = brandB;
            parameters[37].Value = remarkB;
            parameters[38].Value = Manufacturer;

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
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.v_ProjectMaterialAToB GetModel(string UnitName, string Unit, decimal Amount, string Color, string Size, string Brand, int projectSpaceID, int Submit, string SubmitPerson, DateTime SubmitDate, int Audit, string Auditor, DateTime AuditDate, int Checking, string CheckPerson, DateTime CheckDate, int placeID, int spaceID, int projectID, long productID, string place, string space, string projectName, string productCode, string productName, string Quality, string NFK, long TypeID, string productTYpeName, int productTypeRootID, string ProductTypeRoot, string supplierID, string supplierCode, string supplierName, string supplierMobile, string colorB, string brandB, string remarkB, string Manufacturer)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UnitName,Unit,Amount,Color,Size,Brand,projectSpaceID,Submit,SubmitPerson,SubmitDate,Audit,Auditor,AuditDate,Checking,CheckPerson,CheckDate,placeID,spaceID,projectID,productID,place,space,projectName,productCode,productName,Quality,NFK,TypeID,productTYpeName,productTypeRootID,ProductTypeRoot,supplierID,supplierCode,supplierName,supplierMobile,colorB,brandB,remarkB,Manufacturer from v_ProjectMaterialAToB ");
            strSql.Append(" where UnitName=@UnitName and Unit=@Unit and Amount=@Amount and Color=@Color and Size=@Size and Brand=@Brand and projectSpaceID=@projectSpaceID and Submit=@Submit and SubmitPerson=@SubmitPerson and SubmitDate=@SubmitDate and Audit=@Audit and Auditor=@Auditor and AuditDate=@AuditDate and Checking=@Checking and CheckPerson=@CheckPerson and CheckDate=@CheckDate and placeID=@placeID and spaceID=@spaceID and projectID=@projectID and productID=@productID and place=@place and space=@space and projectName=@projectName and productCode=@productCode and productName=@productName and Quality=@Quality and NFK=@NFK and TypeID=@TypeID and productTYpeName=@productTYpeName and productTypeRootID=@productTypeRootID and ProductTypeRoot=@ProductTypeRoot and supplierID=@supplierID and supplierCode=@supplierCode and supplierName=@supplierName and supplierMobile=@supplierMobile and colorB=@colorB and brandB=@brandB and remarkB=@remarkB and Manufacturer=@Manufacturer ");
            SqlParameter[] parameters = {
					new SqlParameter("@UnitName", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Amount", SqlDbType.Decimal,17),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@projectSpaceID", SqlDbType.Int,4),
					new SqlParameter("@Submit", SqlDbType.Int,4),
					new SqlParameter("@SubmitPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@Auditor", SqlDbType.NVarChar,50),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@Checking", SqlDbType.Int,4),
					new SqlParameter("@CheckPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
					new SqlParameter("@placeID", SqlDbType.Int,4),
					new SqlParameter("@spaceID", SqlDbType.Int,4),
					new SqlParameter("@projectID", SqlDbType.Int,4),
					new SqlParameter("@productID", SqlDbType.BigInt,8),
					new SqlParameter("@place", SqlDbType.NVarChar,100),
					new SqlParameter("@space", SqlDbType.NVarChar,100),
					new SqlParameter("@projectName", SqlDbType.NVarChar,100),
					new SqlParameter("@productCode", SqlDbType.NVarChar,50),
					new SqlParameter("@productName", SqlDbType.NVarChar,50),
					new SqlParameter("@Quality", SqlDbType.NVarChar,50),
					new SqlParameter("@NFK", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeID", SqlDbType.BigInt,8),
					new SqlParameter("@productTYpeName", SqlDbType.NVarChar,50),
					new SqlParameter("@productTypeRootID", SqlDbType.Int,4),
					new SqlParameter("@ProductTypeRoot", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierID", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierCode", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierName", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierMobile", SqlDbType.NVarChar,50),
					new SqlParameter("@colorB", SqlDbType.NVarChar,50),
					new SqlParameter("@brandB", SqlDbType.NVarChar,50),
					new SqlParameter("@remarkB", SqlDbType.NVarChar,-1),
					new SqlParameter("@Manufacturer", SqlDbType.NVarChar,50)			};
            parameters[0].Value = UnitName;
            parameters[1].Value = Unit;
            parameters[2].Value = Amount;
            parameters[3].Value = Color;
            parameters[4].Value = Size;
            parameters[5].Value = Brand;
            parameters[6].Value = projectSpaceID;
            parameters[7].Value = Submit;
            parameters[8].Value = SubmitPerson;
            parameters[9].Value = SubmitDate;
            parameters[10].Value = Audit;
            parameters[11].Value = Auditor;
            parameters[12].Value = AuditDate;
            parameters[13].Value = Checking;
            parameters[14].Value = CheckPerson;
            parameters[15].Value = CheckDate;
            parameters[16].Value = placeID;
            parameters[17].Value = spaceID;
            parameters[18].Value = projectID;
            parameters[19].Value = productID;
            parameters[20].Value = place;
            parameters[21].Value = space;
            parameters[22].Value = projectName;
            parameters[23].Value = productCode;
            parameters[24].Value = productName;
            parameters[25].Value = Quality;
            parameters[26].Value = NFK;
            parameters[27].Value = TypeID;
            parameters[28].Value = productTYpeName;
            parameters[29].Value = productTypeRootID;
            parameters[30].Value = ProductTypeRoot;
            parameters[31].Value = supplierID;
            parameters[32].Value = supplierCode;
            parameters[33].Value = supplierName;
            parameters[34].Value = supplierMobile;
            parameters[35].Value = colorB;
            parameters[36].Value = brandB;
            parameters[37].Value = remarkB;
            parameters[38].Value = Manufacturer;

            Maticsoft.Model.v_ProjectMaterialAToB model = new Maticsoft.Model.v_ProjectMaterialAToB();
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
        public Maticsoft.Model.v_ProjectMaterialAToB DataRowToModel(DataRow row)
        {
            Maticsoft.Model.v_ProjectMaterialAToB model = new Maticsoft.Model.v_ProjectMaterialAToB();
            if (row != null)
            {
                if (row["UnitName"] != null)
                {
                    model.UnitName = row["UnitName"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["Color"] != null)
                {
                    model.Color = row["Color"].ToString();
                }
                if (row["Size"] != null)
                {
                    model.Size = row["Size"].ToString();
                }
                if (row["Brand"] != null)
                {
                    model.Brand = row["Brand"].ToString();
                }
                if (row["projectSpaceID"] != null && row["projectSpaceID"].ToString() != "")
                {
                    model.projectSpaceID = int.Parse(row["projectSpaceID"].ToString());
                }
                if (row["Submit"] != null && row["Submit"].ToString() != "")
                {
                    model.Submit = int.Parse(row["Submit"].ToString());
                }
                if (row["SubmitPerson"] != null)
                {
                    model.SubmitPerson = row["SubmitPerson"].ToString();
                }
                if (row["SubmitDate"] != null && row["SubmitDate"].ToString() != "")
                {
                    model.SubmitDate = DateTime.Parse(row["SubmitDate"].ToString());
                }
                if (row["Audit"] != null && row["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(row["Audit"].ToString());
                }
                if (row["Auditor"] != null)
                {
                    model.Auditor = row["Auditor"].ToString();
                }
                if (row["AuditDate"] != null && row["AuditDate"].ToString() != "")
                {
                    model.AuditDate = DateTime.Parse(row["AuditDate"].ToString());
                }
                if (row["Checking"] != null && row["Checking"].ToString() != "")
                {
                    model.Checking = int.Parse(row["Checking"].ToString());
                }
                if (row["CheckPerson"] != null)
                {
                    model.CheckPerson = row["CheckPerson"].ToString();
                }
                if (row["CheckDate"] != null && row["CheckDate"].ToString() != "")
                {
                    model.CheckDate = DateTime.Parse(row["CheckDate"].ToString());
                }
                if (row["placeID"] != null && row["placeID"].ToString() != "")
                {
                    model.placeID = int.Parse(row["placeID"].ToString());
                }
                if (row["spaceID"] != null && row["spaceID"].ToString() != "")
                {
                    model.spaceID = int.Parse(row["spaceID"].ToString());
                }
                if (row["projectID"] != null && row["projectID"].ToString() != "")
                {
                    model.projectID = int.Parse(row["projectID"].ToString());
                }
                if (row["productID"] != null && row["productID"].ToString() != "")
                {
                    model.productID = long.Parse(row["productID"].ToString());
                }
                if (row["place"] != null)
                {
                    model.place = row["place"].ToString();
                }
                if (row["space"] != null)
                {
                    model.space = row["space"].ToString();
                }
                if (row["projectName"] != null)
                {
                    model.projectName = row["projectName"].ToString();
                }
                if (row["productCode"] != null)
                {
                    model.productCode = row["productCode"].ToString();
                }
                if (row["productName"] != null)
                {
                    model.productName = row["productName"].ToString();
                }
                if (row["Quality"] != null)
                {
                    model.Quality = row["Quality"].ToString();
                }
                if (row["NFK"] != null)
                {
                    model.NFK = row["NFK"].ToString();
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = long.Parse(row["TypeID"].ToString());
                }
                if (row["productTYpeName"] != null)
                {
                    model.productTYpeName = row["productTYpeName"].ToString();
                }
                if (row["productTypeRootID"] != null && row["productTypeRootID"].ToString() != "")
                {
                    model.productTypeRootID = int.Parse(row["productTypeRootID"].ToString());
                }
                if (row["ProductTypeRoot"] != null)
                {
                    model.ProductTypeRoot = row["ProductTypeRoot"].ToString();
                }
                if (row["supplierID"] != null)
                {
                    model.supplierID = row["supplierID"].ToString();
                }
                if (row["supplierCode"] != null)
                {
                    model.supplierCode = row["supplierCode"].ToString();
                }
                if (row["supplierName"] != null)
                {
                    model.supplierName = row["supplierName"].ToString();
                }
                if (row["supplierMobile"] != null)
                {
                    model.supplierMobile = row["supplierMobile"].ToString();
                }
                if (row["colorB"] != null)
                {
                    model.colorB = row["colorB"].ToString();
                }
                if (row["brandB"] != null)
                {
                    model.brandB = row["brandB"].ToString();
                }
                if (row["remarkB"] != null)
                {
                    model.remarkB = row["remarkB"].ToString();
                }
                if (row["Manufacturer"] != null)
                {
                    model.Manufacturer = row["Manufacturer"].ToString();
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
            strSql.Append("select UnitName,Unit,Amount,Color,Size,Brand,projectSpaceID,Submit,SubmitPerson,SubmitDate,Audit,Auditor,AuditDate,Checking,CheckPerson,CheckDate,placeID,spaceID,projectID,productID,place,space,projectName,productCode,productName,Quality,NFK,TypeID,productTYpeName,productTypeRootID,ProductTypeRoot,supplierID,supplierCode,supplierName,supplierMobile,colorB,brandB,remarkB,Manufacturer ");
            strSql.Append(" FROM v_ProjectMaterialAToB ");
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
            strSql.Append(" UnitName,Unit,Amount,Color,Size,Brand,projectSpaceID,Submit,SubmitPerson,SubmitDate,Audit,Auditor,AuditDate,Checking,CheckPerson,CheckDate,placeID,spaceID,projectID,productID,place,space,projectName,productCode,productName,Quality,NFK,TypeID,productTYpeName,productTypeRootID,ProductTypeRoot,supplierID,supplierCode,supplierName,supplierMobile,colorB,brandB,remarkB,Manufacturer ");
            strSql.Append(" FROM v_ProjectMaterialAToB ");
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
            strSql.Append("select count(1) FROM v_ProjectMaterialAToB ");
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
                strSql.Append("order by T.Manufacturer desc");
            }
            strSql.Append(")AS Row, T.*  from v_ProjectMaterialAToB T ");
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
            parameters[0].Value = "v_ProjectMaterialAToB";
            parameters[1].Value = "Manufacturer";
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
