using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Collections;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:Product
    /// </summary>
    public partial class Product
    {
        public Product()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Product");
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
        public long Add(Maticsoft.Model.Product model, List<Model.ProductPriceColorShip> insertList, string picFile)
        {
            ArrayList arr = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("declare @c nvarchar(400); declare @m int; set @c=''; with #tmp   as( select   *   from   ProductType where   id=@TypeID union   all select   a.*   from   ProductType a,   #tmp   b  where   a.id   =   b.parentid ) select @c=rtrim(@c)+rtrim(Code) from #tmp order by [level] select @c=rtrim(@c)+'.'+rtrim(Code) from Supplier where id=@Manufacturer select @c=rtrim(@c)+'.'+rtrim(Code) from ProductSeries where id=@SeriesID select @m=max(substring(Code,len(Code)-2,3))+1 from Product where substring(Code,len(Code)-4,2)=(select top 1 Code from ProductSeries where id=@SeriesID) IF @m IS NULL SET @c=@c++'001' ELSE IF @m<10 SET @c=@c+'00'+CONVERT(VARCHAR(1),@m) ELSE IF @m<100	SET @c=@c+'0'+CONVERT(VARCHAR(2),@m) ELSE SET @c=@c+CONVERT(VARCHAR(3),@m)");
            //DataTable dt1 = DbHelperSQL.Query("with #tmp   as( select   *   from   ProductType where   id="+model.TypeID+" union   all select   a.*   from   ProductType a,   #tmp   b  where   a.id   =   b.parentid ); select Code from #tmp order by [level];").Tables[0];
            //for (int i = 0; i < dt1.Rows.Count; i++)
            //{
            //    model.Code += dt1.Rows[i]["Code"];
            //}
            //model.Code += "." + DbHelperSQL.GetSingle("select Code from Supplier from id=" + model.Manufacturer);

            strSql.Append("insert into Product(");
            strSql.Append("ParentID,TypeID,SeriesID,Code,BarCode,Name,Enabled,Install,Specifications,ValuationMethods,Unit,Attribute,Manufacturer,BarginPrice,StandardPrice,ReferencePrice,PriceTag,MinPrice,Profit,MaxStock,MinStock,StockProduct,ProductPurchase,SellingCost,SellingPrice,SellingProfit,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,PreinstallStock,PreinstallStockArea,PreinstallStockSite,BulkUnit,UnitBulk,WeightUnit,UnitWeight,PackCount,SellingLandTransportation,SellingSeaTransportation,SellingAirTransportation,SellingOtherTransportation,DayLandTransportation,DaySeaTransportation,DayAirTransportation,DayOtherTransportation,Long,Width,Height,Color,Image,Style,Texture,Standard,Shape,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@ParentID,@TypeID,@SeriesID,@c,@BarCode,@Name,@Enabled,@Install,@Specifications,@ValuationMethods,@Unit,@Attribute,@Manufacturer,@BarginPrice,@StandardPrice,@ReferencePrice,@PriceTag,@MinPrice,@Profit,@MaxStock,@MinStock,@StockProduct,@ProductPurchase,@SellingCost,@SellingPrice,@SellingProfit,@ReferencePriceA,@ReferencePriceB,@ReferencePriceC,@ReferencePriceD,@ReferencePriceE,@ReferencePriceF,@SellingAward,@SellingRoyaltyRate,@PreinstallStock,@PreinstallStockArea,@PreinstallStockSite,@BulkUnit,@UnitBulk,@WeightUnit,@UnitWeight,@PackCount,@SellingLandTransportation,@SellingSeaTransportation,@SellingAirTransportation,@SellingOtherTransportation,@DayLandTransportation,@DaySeaTransportation,@DayAirTransportation,@DayOtherTransportation,@Long,@Width,@Height,@Color,@Image,@Style,@Texture,@Standard,@Shape,@Remark,@Value0,@Value1,@Value2,@Value3,@Value4,@Value5,@Value6,@Value7,@Value8,@Value9,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
            strSql.Append(";select @@IDENTITY");
          
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@TypeID", SqlDbType.BigInt,8),
					new SqlParameter("@SeriesID", SqlDbType.BigInt,8),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@BarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
					new SqlParameter("@Install", SqlDbType.Bit,1),
					new SqlParameter("@Specifications", SqlDbType.NVarChar,50),
					new SqlParameter("@ValuationMethods", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Attribute", SqlDbType.NVarChar,50),
					new SqlParameter("@Manufacturer", SqlDbType.NVarChar,50),
					new SqlParameter("@BarginPrice", SqlDbType.Money,8),
					new SqlParameter("@StandardPrice", SqlDbType.Money,8),
					new SqlParameter("@ReferencePrice", SqlDbType.Money,8),
					new SqlParameter("@PriceTag", SqlDbType.Money,8),
					new SqlParameter("@MinPrice", SqlDbType.Money,8),
					new SqlParameter("@Profit", SqlDbType.Money,8),
					new SqlParameter("@MaxStock", SqlDbType.Float,8),
					new SqlParameter("@MinStock", SqlDbType.Float,8),
					new SqlParameter("@StockProduct", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductPurchase", SqlDbType.NVarChar,50),
					new SqlParameter("@SellingCost", SqlDbType.Money,8),
					new SqlParameter("@SellingPrice", SqlDbType.Money,8),
					new SqlParameter("@SellingProfit", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceA", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceB", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceC", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceD", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceE", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceF", SqlDbType.Money,8),
					new SqlParameter("@SellingAward", SqlDbType.NVarChar,50),
					new SqlParameter("@SellingRoyaltyRate", SqlDbType.Float,8),
					new SqlParameter("@PreinstallStock", SqlDbType.NVarChar,50),
					new SqlParameter("@PreinstallStockArea", SqlDbType.NVarChar,50),
					new SqlParameter("@PreinstallStockSite", SqlDbType.NVarChar,50),
					new SqlParameter("@BulkUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitBulk", SqlDbType.NVarChar,50),
					new SqlParameter("@WeightUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitWeight", SqlDbType.NVarChar,50),
					new SqlParameter("@PackCount", SqlDbType.Float,8),
					new SqlParameter("@SellingLandTransportation", SqlDbType.Float,8),
					new SqlParameter("@SellingSeaTransportation", SqlDbType.Float,8),
					new SqlParameter("@SellingAirTransportation", SqlDbType.Float,8),
					new SqlParameter("@SellingOtherTransportation", SqlDbType.Float,8),
					new SqlParameter("@DayLandTransportation", SqlDbType.Float,8),
					new SqlParameter("@DaySeaTransportation", SqlDbType.Float,8),
					new SqlParameter("@DayAirTransportation", SqlDbType.Float,8),
					new SqlParameter("@DayOtherTransportation", SqlDbType.Float,8),
					new SqlParameter("@Long", SqlDbType.Float,8),
					new SqlParameter("@Width", SqlDbType.Float,8),
					new SqlParameter("@Height", SqlDbType.Float,8),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Image", SqlDbType.NVarChar,-1),
					new SqlParameter("@Style", SqlDbType.NVarChar,50),
					new SqlParameter("@Texture", SqlDbType.NVarChar,50),
					new SqlParameter("@Standard", SqlDbType.NVarChar,50),
					new SqlParameter("@Shape", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value0", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value1", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value2", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value3", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value4", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value5", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value6", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value7", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value8", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value9", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.TypeID;
            parameters[2].Value = model.SeriesID;
            parameters[3].Value = model.Code;
            parameters[4].Value = model.BarCode;
            parameters[5].Value = model.Name;
            parameters[6].Value = model.Enabled;
            parameters[7].Value = model.Install;
            parameters[8].Value = model.Specifications;
            parameters[9].Value = model.ValuationMethods;
            parameters[10].Value = model.Unit;
            parameters[11].Value = model.Attribute;
            parameters[12].Value = model.Manufacturer;
            parameters[13].Value = model.BarginPrice;
            parameters[14].Value = model.StandardPrice;
            parameters[15].Value = model.ReferencePrice;
            parameters[16].Value = model.PriceTag;
            parameters[17].Value = model.MinPrice;
            parameters[18].Value = model.Profit;
            parameters[19].Value = model.MaxStock;
            parameters[20].Value = model.MinStock;
            parameters[21].Value = model.StockProduct;
            parameters[22].Value = model.ProductPurchase;
            parameters[23].Value = model.SellingCost;
            parameters[24].Value = model.SellingPrice;
            parameters[25].Value = model.SellingProfit;
            parameters[26].Value = model.ReferencePriceA;
            parameters[27].Value = model.ReferencePriceB;
            parameters[28].Value = model.ReferencePriceC;
            parameters[29].Value = model.ReferencePriceD;
            parameters[30].Value = model.ReferencePriceE;
            parameters[31].Value = model.ReferencePriceF;
            parameters[32].Value = model.SellingAward;
            parameters[33].Value = model.SellingRoyaltyRate;
            parameters[34].Value = model.PreinstallStock;
            parameters[35].Value = model.PreinstallStockArea;
            parameters[36].Value = model.PreinstallStockSite;
            parameters[37].Value = model.BulkUnit;
            parameters[38].Value = model.UnitBulk;
            parameters[39].Value = model.WeightUnit;
            parameters[40].Value = model.UnitWeight;
            parameters[41].Value = model.PackCount;
            parameters[42].Value = model.SellingLandTransportation;
            parameters[43].Value = model.SellingSeaTransportation;
            parameters[44].Value = model.SellingAirTransportation;
            parameters[45].Value = model.SellingOtherTransportation;
            parameters[46].Value = model.DayLandTransportation;
            parameters[47].Value = model.DaySeaTransportation;
            parameters[48].Value = model.DayAirTransportation;
            parameters[49].Value = model.DayOtherTransportation;
            parameters[50].Value = model.Long;
            parameters[51].Value = model.Width;
            parameters[52].Value = model.Height;
            parameters[53].Value = model.Color;
            parameters[54].Value = model.Image;
            parameters[55].Value = model.Style;
            parameters[56].Value = model.Texture;
            parameters[57].Value = model.Standard;
            parameters[58].Value = model.Shape;
            parameters[59].Value = model.Remark;
            parameters[60].Value = model.Value0;
            parameters[61].Value = model.Value1;
            parameters[62].Value = model.Value2;
            parameters[63].Value = model.Value3;
            parameters[64].Value = model.Value4;
            parameters[65].Value = model.Value5;
            parameters[66].Value = model.Value6;
            parameters[67].Value = model.Value7;
            parameters[68].Value = model.Value8;
            parameters[69].Value = model.Value9;
            parameters[70].Value = model.CreateUser;
            parameters[71].Value = model.CreateDate;
            parameters[72].Value = DBNull.Value;
            parameters[73].Value = DBNull.Value;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);


            for (int i = 0; i < insertList.Count; i++)
            {
                strSql = new StringBuilder();
                Model.ProductPriceColorShip modelPro = insertList[i];
                //strSql.Append("insert into ProductColor  (ParentID,Code,Name,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate) ");
                strSql.Append("insert into ProductItem  (ProductID,Corlor,Size,Brand,MaxStock,MinStock,ReferencePriceOut,StandardPriceIn,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF) ");
                strSql.Append("  values  ( ");
                strSql.Append("'" + obj + "','" + modelPro.Corlor + "','" + modelPro.Size + "','" + model.Brand + "','" + modelPro.MaxStock + "','" + modelPro.MinStock + "','" + modelPro.ReferencePriceOut + "','" + modelPro.StandardPriceIn + "','" + modelPro.ReferencePriceA + "','" + modelPro.ReferencePriceB + "','" + modelPro.ReferencePriceC + "','" + modelPro.ReferencePriceD + "','" + modelPro.ReferencePriceE + "','" + modelPro.ReferencePriceF + "'");
                strSql.Append(" ) ");
                arr.Add(strSql.ToString());
            }
            strSql = new StringBuilder();
            strSql.Append("update Product set Image='"+picFile+"' where ID="+obj+" ");
            arr.Add(strSql);
            DbHelperSQL.ExecuteSqlTran(arr);
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
        public int Update(Maticsoft.Model.Product model, List<Model.ProductPriceColorShip> delList, List<Model.ProductPriceColorShip> insertList, List<Model.ProductPriceColorShip> updateList, string picFile, string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Product set ");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("SeriesID=@SeriesID,");
            strSql.Append("ProductKey=@ProductKey,");
            strSql.Append("BarCode=@BarCode,");
            strSql.Append("Name=@Name,");
            strSql.Append("Enabled=@Enabled,");
            strSql.Append("Install=@Install,");
            strSql.Append("Specifications=@Specifications,");
            strSql.Append("ValuationMethods=@ValuationMethods,");
            strSql.Append("Unit=@Unit,");
            strSql.Append("Attribute=@Attribute,");
            strSql.Append("Manufacturer=@Manufacturer,");
            strSql.Append("BarginPrice=@BarginPrice,");
            strSql.Append("StandardPrice=@StandardPrice,");
            strSql.Append("ReferencePrice=@ReferencePrice,");
            strSql.Append("PriceTag=@PriceTag,");
            strSql.Append("MinPrice=@MinPrice,");
            strSql.Append("Profit=@Profit,");
            strSql.Append("MaxStock=@MaxStock,");
            strSql.Append("MinStock=@MinStock,");
            strSql.Append("StockProduct=@StockProduct,");
            strSql.Append("ProductPurchase=@ProductPurchase,");
            strSql.Append("SellingCost=@SellingCost,");
            strSql.Append("SellingPrice=@SellingPrice,");
            strSql.Append("SellingProfit=@SellingProfit,");
            strSql.Append("ReferencePriceA=@ReferencePriceA,");
            strSql.Append("ReferencePriceB=@ReferencePriceB,");
            strSql.Append("ReferencePriceC=@ReferencePriceC,");
            strSql.Append("ReferencePriceD=@ReferencePriceD,");
            strSql.Append("ReferencePriceE=@ReferencePriceE,");
            strSql.Append("ReferencePriceF=@ReferencePriceF,");
            strSql.Append("SellingAward=@SellingAward,");
            strSql.Append("SellingRoyaltyRate=@SellingRoyaltyRate,");
            strSql.Append("PreinstallStock=@PreinstallStock,");
            strSql.Append("PreinstallStockArea=@PreinstallStockArea,");
            strSql.Append("PreinstallStockSite=@PreinstallStockSite,");
            strSql.Append("BulkUnit=@BulkUnit,");
            strSql.Append("UnitBulk=@UnitBulk,");
            strSql.Append("WeightUnit=@WeightUnit,");
            strSql.Append("UnitWeight=@UnitWeight,");
            strSql.Append("PackCount=@PackCount,");
            strSql.Append("SellingLandTransportation=@SellingLandTransportation,");
            strSql.Append("SellingSeaTransportation=@SellingSeaTransportation,");
            strSql.Append("SellingAirTransportation=@SellingAirTransportation,");
            strSql.Append("SellingOtherTransportation=@SellingOtherTransportation,");
            strSql.Append("DayLandTransportation=@DayLandTransportation,");
            strSql.Append("DaySeaTransportation=@DaySeaTransportation,");
            strSql.Append("DayAirTransportation=@DayAirTransportation,");
            strSql.Append("DayOtherTransportation=@DayOtherTransportation,");
            strSql.Append("Long=@Long,");
            strSql.Append("Width=@Width,");
            strSql.Append("Height=@Height,");
            strSql.Append("Color=@Color,");
            strSql.Append("Image=@Image,");
            strSql.Append("Style=@Style,");
            strSql.Append("Texture=@Texture,");
            strSql.Append("Standard=@Standard,");
            strSql.Append("Shape=@Shape,");
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
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@TypeID", SqlDbType.BigInt,8),
					new SqlParameter("@SeriesID", SqlDbType.BigInt,8),

                    
					new SqlParameter("@BarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Enabled", SqlDbType.Bit,1),
					new SqlParameter("@Install", SqlDbType.Bit,1),
					new SqlParameter("@Specifications", SqlDbType.NVarChar,50),
					new SqlParameter("@ValuationMethods", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Attribute", SqlDbType.NVarChar,50),
					new SqlParameter("@Manufacturer", SqlDbType.NVarChar,50),
					new SqlParameter("@BarginPrice", SqlDbType.Money,8),
					new SqlParameter("@StandardPrice", SqlDbType.Money,8),
					new SqlParameter("@ReferencePrice", SqlDbType.Money,8),
					new SqlParameter("@PriceTag", SqlDbType.Money,8),
					new SqlParameter("@MinPrice", SqlDbType.Money,8),
					new SqlParameter("@Profit", SqlDbType.Money,8),
					new SqlParameter("@MaxStock", SqlDbType.Float,8),
					new SqlParameter("@MinStock", SqlDbType.Float,8),
					new SqlParameter("@StockProduct", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductPurchase", SqlDbType.NVarChar,50),
					new SqlParameter("@SellingCost", SqlDbType.Money,8),
					new SqlParameter("@SellingPrice", SqlDbType.Money,8),
					new SqlParameter("@SellingProfit", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceA", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceB", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceC", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceD", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceE", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceF", SqlDbType.Money,8),
					new SqlParameter("@SellingAward", SqlDbType.NVarChar,50),
					new SqlParameter("@SellingRoyaltyRate", SqlDbType.Float,8),
					new SqlParameter("@PreinstallStock", SqlDbType.NVarChar,50),
					new SqlParameter("@PreinstallStockArea", SqlDbType.NVarChar,50),
					new SqlParameter("@PreinstallStockSite", SqlDbType.NVarChar,50),
					new SqlParameter("@BulkUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitBulk", SqlDbType.NVarChar,50),
					new SqlParameter("@WeightUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@UnitWeight", SqlDbType.NVarChar,50),
					new SqlParameter("@PackCount", SqlDbType.Float,8),
					new SqlParameter("@SellingLandTransportation", SqlDbType.Float,8),
					new SqlParameter("@SellingSeaTransportation", SqlDbType.Float,8),
					new SqlParameter("@SellingAirTransportation", SqlDbType.Float,8),
					new SqlParameter("@SellingOtherTransportation", SqlDbType.Float,8),
					new SqlParameter("@DayLandTransportation", SqlDbType.Float,8),
					new SqlParameter("@DaySeaTransportation", SqlDbType.Float,8),
					new SqlParameter("@DayAirTransportation", SqlDbType.Float,8),
					new SqlParameter("@DayOtherTransportation", SqlDbType.Float,8),
					new SqlParameter("@Long", SqlDbType.Float,8),
					new SqlParameter("@Width", SqlDbType.Float,8),
					new SqlParameter("@Height", SqlDbType.Float,8),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Image", SqlDbType.NVarChar,-1),
					new SqlParameter("@Style", SqlDbType.NVarChar,50),
					new SqlParameter("@Texture", SqlDbType.NVarChar,50),
					new SqlParameter("@Standard", SqlDbType.NVarChar,50),
					new SqlParameter("@Shape", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value0", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value1", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value2", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value3", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value4", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value5", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value6", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value7", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value8", SqlDbType.NVarChar,-1),
					new SqlParameter("@Value9", SqlDbType.NVarChar,-1),
					new SqlParameter("@UpdateUser", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.BigInt,8),
                    new SqlParameter("@ProductKey",SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.TypeID;
            parameters[2].Value = model.SeriesID;
            parameters[3].Value = model.BarCode;
            parameters[4].Value = model.Name;
            parameters[5].Value = Convert.ToInt32(model.Enabled);
            parameters[6].Value = Convert.ToInt32( model.Install);
            parameters[7].Value = model.Specifications;
            parameters[8].Value = model.ValuationMethods;
            parameters[9].Value = model.Unit;
            parameters[10].Value = model.Attribute;
            parameters[11].Value = model.Manufacturer;
            parameters[12].Value = model.BarginPrice;
            parameters[13].Value = model.StandardPrice;
            parameters[14].Value = model.ReferencePrice;
            parameters[15].Value = model.PriceTag;
            parameters[16].Value = model.MinPrice;
            parameters[17].Value = model.Profit;
            parameters[18].Value = model.MaxStock;
            parameters[19].Value = model.MinStock;
            parameters[20].Value = model.StockProduct;
            parameters[21].Value = model.ProductPurchase;
            parameters[22].Value = model.SellingCost;
            parameters[23].Value = model.SellingPrice;
            parameters[24].Value = model.SellingProfit;
            parameters[25].Value = model.ReferencePriceA;
            parameters[26].Value = model.ReferencePriceB;
            parameters[27].Value = model.ReferencePriceC;
            parameters[28].Value = model.ReferencePriceD;
            parameters[29].Value = model.ReferencePriceE;
            parameters[30].Value = model.ReferencePriceF;
            parameters[31].Value = model.SellingAward;
            parameters[32].Value = model.SellingRoyaltyRate;
            parameters[33].Value = model.PreinstallStock;
            parameters[34].Value = model.PreinstallStockArea;
            parameters[35].Value = model.PreinstallStockSite;
            parameters[36].Value = model.BulkUnit;
            parameters[37].Value = model.UnitBulk;
            parameters[38].Value = model.WeightUnit;
            parameters[39].Value = model.UnitWeight;
            parameters[40].Value = model.PackCount;
            parameters[41].Value = model.SellingLandTransportation;
            parameters[42].Value = model.SellingSeaTransportation;
            parameters[43].Value = model.SellingAirTransportation;
            parameters[44].Value = model.SellingOtherTransportation;
            parameters[45].Value = model.DayLandTransportation;
            parameters[46].Value = model.DaySeaTransportation;
            parameters[47].Value = model.DayAirTransportation;
            parameters[48].Value = model.DayOtherTransportation;
            parameters[49].Value = model.Long;
            parameters[50].Value = model.Width;
            parameters[51].Value = model.Height;
            parameters[52].Value = model.Color;
            parameters[53].Value = model.Image;
            parameters[54].Value = model.Style;
            parameters[55].Value = model.Texture;
            parameters[56].Value = model.Standard;
            parameters[57].Value = model.Shape;
            parameters[58].Value = model.Remark;
            parameters[59].Value = model.Value0;
            parameters[60].Value = model.Value1;
            parameters[61].Value = model.Value2;
            parameters[62].Value = model.Value3;
            parameters[63].Value = model.Value4;
            parameters[64].Value = model.Value5;
            parameters[65].Value = model.Value6;
            parameters[66].Value = model.Value7;
            parameters[67].Value = model.Value8;
            parameters[68].Value = model.Value9;
            parameters[69].Value = model.UpdateUser;
            parameters[70].Value = DateTime.Now.ToString();
            parameters[71].Value = id;
            parameters[72].Value = model.ProductKey;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            ArrayList arr = new ArrayList();

            for (int i = 0; i < delList.Count; i++)
            {
                strSql = new StringBuilder();
                Model.ProductPriceColorShip modelPro = delList[i];
                strSql.Append("delete  from ProductItem where ID="+model.ID+"");
                  arr.Add(strSql.ToString());
            }
            for (int i = 0; i < updateList.Count; i++)
            {
                strSql = new StringBuilder();
                Model.ProductPriceColorShip modelPro = updateList[i];
                strSql.Append("update ProductItem set ProductID='" + id + "',Corlor='" + modelPro.Corlor + "',Code='" + modelPro.Code + "',Size='" + modelPro.Size + "',Quality='" + modelPro.Quality + "'");
                strSql.Append(",Brand='" + modelPro.Brand + "',NFK='" + modelPro.NFK + "',Attribute='" + modelPro.Attribute + "',BarginPriceOut='" + modelPro.BarginPriceOut + "',ReferencePriceOut='" + modelPro.ReferencePriceOut + "'");
                strSql.Append(",StandardPriceIn='" + modelPro.StandardPriceIn + "',MinPriceOut='" + modelPro.MinPriceOut + "',Profit='" + modelPro.Profit + "',TagPrice='" + modelPro.TagPrice + "',MaxStock='" + modelPro.MaxStock + "'");
                strSql.Append(",MinStock='" + modelPro.MinStock + "',ReferencePriceA='" + modelPro.ReferencePriceA + "',ReferencePriceB='" + modelPro.ReferencePriceB + "',ReferencePriceC='" + modelPro.ReferencePriceC + "',ReferencePriceD='" + modelPro.ReferencePriceD + "'");
                strSql.Append(",ReferencePriceE='" + modelPro.ReferencePriceE + "',ReferencePriceF='" + modelPro.ReferencePriceF + "',value0='" + modelPro.value0 + "',value1='" + modelPro.value1 + "'");
                strSql.Append(" where ID=" + modelPro.ID);
                arr.Add(strSql.ToString());
            }

            for (int i = 0; i < insertList.Count; i++)
            {
                strSql = new StringBuilder();
                Model.ProductPriceColorShip modelPro = insertList[i];
                //strSql.Append("insert into ProductColor  (ParentID,Code,Name,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate) ");
                strSql.Append("insert into ProductItem  (ProductID,Corlor,Size,Brand,MaxStock,MinStock,ReferencePriceOut,StandardPriceIn,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF) ");
                strSql.Append("  values  ( ");
                strSql.Append("'" + id + "','" + modelPro.Corlor + "','" + modelPro.Size + "','" + model.Brand + "','" + modelPro.MaxStock + "','" + modelPro.MinStock + "','" + modelPro.ReferencePriceOut + "','" + modelPro.StandardPriceIn + "','" + modelPro.ReferencePriceA + "','" + modelPro.ReferencePriceB + "','" + modelPro.ReferencePriceC + "','" + modelPro.ReferencePriceD + "','" + modelPro.ReferencePriceE + "','" + modelPro.ReferencePriceF + "'");
                strSql.Append(" ) ");
                arr.Add(strSql.ToString());
            }
            strSql = new StringBuilder();
            strSql.Append("update Product set Image='" + picFile + "' where ID=" + id + " ");
            arr.Add(strSql);
            if (arr.Count > 0)
            {
                DbHelperSQL.ExecuteSqlTran(arr);
            }
            return rows;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Product ");
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
            strSql.Append("delete from Product ");
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
        public Maticsoft.Model.Product GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ParentID,TypeID,SeriesID,Code,BarCode,Name,Enabled,Install,Specifications,ValuationMethods,Unit,Attribute,Manufacturer,BarginPrice,StandardPrice,ReferencePrice,PriceTag,MinPrice,Profit,MaxStock,MinStock,StockProduct,ProductPurchase,SellingCost,SellingPrice,SellingProfit,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,PreinstallStock,PreinstallStockArea,PreinstallStockSite,BulkUnit,UnitBulk,WeightUnit,UnitWeight,PackCount,SellingLandTransportation,SellingSeaTransportation,SellingAirTransportation,SellingOtherTransportation,DayLandTransportation,DaySeaTransportation,DayAirTransportation,DayOtherTransportation,Long,Width,Height,Color,Image,Style,Texture,Standard,Shape,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from Product ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.Product model = new Maticsoft.Model.Product();
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
        public Maticsoft.Model.Product GetModel(string Name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ParentID,TypeID,SeriesID,Code,BarCode,Name,Enabled,Install,Specifications,ValuationMethods,Unit,Attribute,Manufacturer,BarginPrice,StandardPrice,ReferencePrice,PriceTag,MinPrice,Profit,MaxStock,MinStock,StockProduct,ProductPurchase,SellingCost,SellingPrice,SellingProfit,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,PreinstallStock,PreinstallStockArea,PreinstallStockSite,BulkUnit,UnitBulk,WeightUnit,UnitWeight,PackCount,SellingLandTransportation,SellingSeaTransportation,SellingAirTransportation,SellingOtherTransportation,DayLandTransportation,DaySeaTransportation,DayAirTransportation,DayOtherTransportation,Long,Width,Height,Color,Image,Style,Texture,Standard,Shape,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate from Product ");
            strSql.Append(" where Name=@Name");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar)
			};
            parameters[0].Value = Name;

            Maticsoft.Model.Product model = new Maticsoft.Model.Product();
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
        public Maticsoft.Model.Product DataRowToModel(DataRow row)
        {
            Maticsoft.Model.Product model = new Maticsoft.Model.Product();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(row["ParentID"].ToString());
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = long.Parse(row["TypeID"].ToString());
                }
                if (row["SeriesID"] != null && row["SeriesID"].ToString() != "")
                {
                    model.SeriesID = long.Parse(row["SeriesID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Enabled"] != null && row["Enabled"].ToString() != "")
                {
                    if ((row["Enabled"].ToString() == "1") || (row["Enabled"].ToString().ToLower() == "true"))
                    {
                        model.Enabled = true;
                    }
                    else
                    {
                        model.Enabled = false;
                    }
                }
                if (row["Install"] != null && row["Install"].ToString() != "")
                {
                    if ((row["Install"].ToString() == "1") || (row["Install"].ToString().ToLower() == "true"))
                    {
                        model.Install = true;
                    }
                    else
                    {
                        model.Install = false;
                    }
                }
                if (row["Specifications"] != null)
                {
                    model.Specifications = row["Specifications"].ToString();
                }
                if (row["ValuationMethods"] != null)
                {
                    model.ValuationMethods = row["ValuationMethods"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
                }
                if (row["Attribute"] != null)
                {
                    model.Attribute = row["Attribute"].ToString();
                }
                if (row["Manufacturer"] != null)
                {
                    model.Manufacturer = row["Manufacturer"].ToString();
                }
                if (row["BarginPrice"] != null && row["BarginPrice"].ToString() != "")
                {
                    model.BarginPrice = decimal.Parse(row["BarginPrice"].ToString());
                }
                if (row["StandardPrice"] != null && row["StandardPrice"].ToString() != "")
                {
                    model.StandardPrice = decimal.Parse(row["StandardPrice"].ToString());
                }
                if (row["ReferencePrice"] != null && row["ReferencePrice"].ToString() != "")
                {
                    model.ReferencePrice = decimal.Parse(row["ReferencePrice"].ToString());
                }
                if (row["PriceTag"] != null && row["PriceTag"].ToString() != "")
                {
                    model.PriceTag = decimal.Parse(row["PriceTag"].ToString());
                }
                if (row["MinPrice"] != null && row["MinPrice"].ToString() != "")
                {
                    model.MinPrice = decimal.Parse(row["MinPrice"].ToString());
                }
                if (row["Profit"] != null && row["Profit"].ToString() != "")
                {
                    model.Profit = decimal.Parse(row["Profit"].ToString());
                }
                if (row["MaxStock"] != null && row["MaxStock"].ToString() != "")
                {
                    model.MaxStock = decimal.Parse(row["MaxStock"].ToString());
                }
                if (row["MinStock"] != null && row["MinStock"].ToString() != "")
                {
                    model.MinStock = decimal.Parse(row["MinStock"].ToString());
                }
                if (row["StockProduct"] != null)
                {
                    model.StockProduct = row["StockProduct"].ToString();
                }
                if (row["ProductPurchase"] != null)
                {
                    model.ProductPurchase = row["ProductPurchase"].ToString();
                }
                if (row["SellingCost"] != null && row["SellingCost"].ToString() != "")
                {
                    model.SellingCost = decimal.Parse(row["SellingCost"].ToString());
                }
                if (row["SellingPrice"] != null && row["SellingPrice"].ToString() != "")
                {
                    model.SellingPrice = decimal.Parse(row["SellingPrice"].ToString());
                }
                if (row["SellingProfit"] != null && row["SellingProfit"].ToString() != "")
                {
                    model.SellingProfit = decimal.Parse(row["SellingProfit"].ToString());
                }
                if (row["ReferencePriceA"] != null && row["ReferencePriceA"].ToString() != "")
                {
                    model.ReferencePriceA = decimal.Parse(row["ReferencePriceA"].ToString());
                }
                if (row["ReferencePriceB"] != null && row["ReferencePriceB"].ToString() != "")
                {
                    model.ReferencePriceB = decimal.Parse(row["ReferencePriceB"].ToString());
                }
                if (row["ReferencePriceC"] != null && row["ReferencePriceC"].ToString() != "")
                {
                    model.ReferencePriceC = decimal.Parse(row["ReferencePriceC"].ToString());
                }
                if (row["ReferencePriceD"] != null && row["ReferencePriceD"].ToString() != "")
                {
                    model.ReferencePriceD = decimal.Parse(row["ReferencePriceD"].ToString());
                }
                if (row["ReferencePriceE"] != null && row["ReferencePriceE"].ToString() != "")
                {
                    model.ReferencePriceE = decimal.Parse(row["ReferencePriceE"].ToString());
                }
                if (row["ReferencePriceF"] != null && row["ReferencePriceF"].ToString() != "")
                {
                    model.ReferencePriceF = decimal.Parse(row["ReferencePriceF"].ToString());
                }
                if (row["SellingAward"] != null)
                {
                    model.SellingAward = row["SellingAward"].ToString();
                }
                if (row["SellingRoyaltyRate"] != null && row["SellingRoyaltyRate"].ToString() != "")
                {
                    model.SellingRoyaltyRate = decimal.Parse(row["SellingRoyaltyRate"].ToString());
                }
                if (row["PreinstallStock"] != null)
                {
                    model.PreinstallStock = row["PreinstallStock"].ToString();
                }
                if (row["PreinstallStockArea"] != null)
                {
                    model.PreinstallStockArea = row["PreinstallStockArea"].ToString();
                }
                if (row["PreinstallStockSite"] != null)
                {
                    model.PreinstallStockSite = row["PreinstallStockSite"].ToString();
                }
                if (row["BulkUnit"] != null)
                {
                    model.BulkUnit = row["BulkUnit"].ToString();
                }
                if (row["UnitBulk"] != null)
                {
                    model.UnitBulk = row["UnitBulk"].ToString();
                }
                if (row["WeightUnit"] != null)
                {
                    model.WeightUnit = row["WeightUnit"].ToString();
                }
                if (row["UnitWeight"] != null)
                {
                    model.UnitWeight = row["UnitWeight"].ToString();
                }
                if (row["PackCount"] != null && row["PackCount"].ToString() != "")
                {
                    model.PackCount = decimal.Parse(row["PackCount"].ToString());
                }
                if (row["SellingLandTransportation"] != null && row["SellingLandTransportation"].ToString() != "")
                {
                    model.SellingLandTransportation = decimal.Parse(row["SellingLandTransportation"].ToString());
                }
                if (row["SellingSeaTransportation"] != null && row["SellingSeaTransportation"].ToString() != "")
                {
                    model.SellingSeaTransportation = decimal.Parse(row["SellingSeaTransportation"].ToString());
                }
                if (row["SellingAirTransportation"] != null && row["SellingAirTransportation"].ToString() != "")
                {
                    model.SellingAirTransportation = decimal.Parse(row["SellingAirTransportation"].ToString());
                }
                if (row["SellingOtherTransportation"] != null && row["SellingOtherTransportation"].ToString() != "")
                {
                    model.SellingOtherTransportation = decimal.Parse(row["SellingOtherTransportation"].ToString());
                }
                if (row["DayLandTransportation"] != null && row["DayLandTransportation"].ToString() != "")
                {
                    model.DayLandTransportation = decimal.Parse(row["DayLandTransportation"].ToString());
                }
                if (row["DaySeaTransportation"] != null && row["DaySeaTransportation"].ToString() != "")
                {
                    model.DaySeaTransportation = decimal.Parse(row["DaySeaTransportation"].ToString());
                }
                if (row["DayAirTransportation"] != null && row["DayAirTransportation"].ToString() != "")
                {
                    model.DayAirTransportation = decimal.Parse(row["DayAirTransportation"].ToString());
                }
                if (row["DayOtherTransportation"] != null && row["DayOtherTransportation"].ToString() != "")
                {
                    model.DayOtherTransportation = decimal.Parse(row["DayOtherTransportation"].ToString());
                }
                if (row["Long"] != null && row["Long"].ToString() != "")
                {
                    model.Long = decimal.Parse(row["Long"].ToString());
                }
                if (row["Width"] != null && row["Width"].ToString() != "")
                {
                    model.Width = decimal.Parse(row["Width"].ToString());
                }
                if (row["Height"] != null && row["Height"].ToString() != "")
                {
                    model.Height = decimal.Parse(row["Height"].ToString());
                }
                if (row["Color"] != null)
                {
                    model.Color = row["Color"].ToString();
                }
                if (row["Image"] != null)
                {
                    model.Image = row["Image"].ToString();
                }
                if (row["Style"] != null)
                {
                    model.Style = row["Style"].ToString();
                }
                if (row["Texture"] != null)
                {
                    model.Texture = row["Texture"].ToString();
                }
                if (row["Standard"] != null)
                {
                    model.Standard = row["Standard"].ToString();
                }
                if (row["Shape"] != null)
                {
                    model.Shape = row["Shape"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Value0"] != null)
                {
                    model.Value0 = row["Value0"].ToString();
                }
                if (row["Value1"] != null)
                {
                    model.Value1 = row["Value1"].ToString();
                }
                if (row["Value2"] != null)
                {
                    model.Value2 = row["Value2"].ToString();
                }
                if (row["Value3"] != null)
                {
                    model.Value3 = row["Value3"].ToString();
                }
                if (row["Value4"] != null)
                {
                    model.Value4 = row["Value4"].ToString();
                }
                if (row["Value5"] != null)
                {
                    model.Value5 = row["Value5"].ToString();
                }
                if (row["Value6"] != null)
                {
                    model.Value6 = row["Value6"].ToString();
                }
                if (row["Value7"] != null)
                {
                    model.Value7 = row["Value7"].ToString();
                }
                if (row["Value8"] != null)
                {
                    model.Value8 = row["Value8"].ToString();
                }
                if (row["Value9"] != null)
                {
                    model.Value9 = row["Value9"].ToString();
                }
                if (row["CreateUser"] != null)
                {
                    model.CreateUser = row["CreateUser"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["UpdateUser"] != null)
                {
                    model.UpdateUser = row["UpdateUser"].ToString();
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
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
            strSql.Append("select ID,ParentID,TypeID,SeriesID,Code,BarCode,Name,Enabled,Install,Specifications,ValuationMethods,Unit,Attribute,Manufacturer,BarginPrice,StandardPrice,ReferencePrice,PriceTag,MinPrice,Profit,MaxStock,MinStock,StockProduct,ProductPurchase,SellingCost,SellingPrice,SellingProfit,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,PreinstallStock,PreinstallStockArea,PreinstallStockSite,BulkUnit,UnitBulk,WeightUnit,UnitWeight,PackCount,SellingLandTransportation,SellingSeaTransportation,SellingAirTransportation,SellingOtherTransportation,DayLandTransportation,DaySeaTransportation,DayAirTransportation,DayOtherTransportation,Long,Width,Height,Color,Image,Style,Texture,Standard,Shape,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM Product ");
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
            strSql.Append(" ID,ParentID,TypeID,SeriesID,Code,BarCode,Name,Enabled,Install,Specifications,ValuationMethods,Unit,Attribute,Manufacturer,BarginPrice,StandardPrice,ReferencePrice,PriceTag,MinPrice,Profit,MaxStock,MinStock,StockProduct,ProductPurchase,SellingCost,SellingPrice,SellingProfit,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,PreinstallStock,PreinstallStockArea,PreinstallStockSite,BulkUnit,UnitBulk,WeightUnit,UnitWeight,PackCount,SellingLandTransportation,SellingSeaTransportation,SellingAirTransportation,SellingOtherTransportation,DayLandTransportation,DaySeaTransportation,DayAirTransportation,DayOtherTransportation,Long,Width,Height,Color,Image,Style,Texture,Standard,Shape,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM Product ");
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
            strSql.Append("select count(1) FROM Product ");
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
            strSql.Append(")AS Row, T.*  from Product T ");
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
            parameters[0].Value = "Product";
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
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Product");
            strSql.Append(where);

            return DbHelperSQL.Exists(strSql.ToString());
        }

        public DataSet GetDS(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Product where ID="+id+"");
            

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetDataSetByProc(long ID)
        { 
            DataSet ds=new DataSet();
            SqlParameter recordCount = new SqlParameter();
            recordCount.ParameterName = "@RecordCount";
            recordCount.Direction = ParameterDirection.Output;
            recordCount.Size = 100;
            SqlParameter[] paras= {
            new SqlParameter("@ID",ID),
            new SqlParameter("@ActionType","Query3"),
            recordCount
            };

            

           ds= DbHelperSQL.RunProcedure("Sp_Product", paras, "Product");
           return ds;
        }

        public DataSet UpdateImageByProc(Model.Product model)
        {
            SqlParameter recordCount = new SqlParameter();
            recordCount.ParameterName = "@RecordCount";
            recordCount.Direction = ParameterDirection.Output;
            recordCount.Size = 100;
            SqlParameter[] paras = {
            new SqlParameter("@ID",SqlDbType.BigInt),
            new SqlParameter("@Image",SqlDbType.NVarChar),
            new SqlParameter("@ActionType",SqlDbType.NVarChar),
            new SqlParameter("@UpdateUsee",SqlDbType.NVarChar),
            new SqlParameter("@UpdateDate",SqlDbType.NVarChar),
            recordCount
                                       };
            paras[0].Value = model.ID;
            paras[1].Value = model.Image;
            paras[2].Value = "Update2";
            paras[3].Value = model.UpdateUser;
            paras[4].Value =model.UpdateDate;
            DataSet ds = new DataSet();
            ds = DbHelperSQL.RunProcedure("Sp_Product", paras, "Product");
            return ds;
        }

        public string BomSave(List<Model.ProductShip> list,string pid)
        {
            try
            {
                ArrayList al = new ArrayList();
                StringBuilder sbSql = new StringBuilder();

                string ids = "";
                for (int i = 0; i < list.Count; i++)
                {
                    sbSql = new StringBuilder();
                    Model.ProductShip model = list[i];

                    sbSql.Append("IF NOT EXISTS(SELECT * FROM ProductShip WHERE ID=" + model.ID + ") ");
                    sbSql.Append("insert into ProductShip (CID,PID,Amount) values  (" + model.CID + "," + model.PID + "," + model.Amount + ") ");
                    sbSql.Append("ELSE ");
                    sbSql.Append("update ProductShip set Amount=" + model.Amount + " where ID=" + model.ID);
                    al.Add(sbSql.ToString());
                    ids += model.ID + ",";
                }
                if (ids.Length > 0)
                {
                    ids = ids.Substring(0, ids.Length - 1);
                }
                al.Insert(0, "delete from ProductShip where ID not in (" + ids + ") and PID="+pid+";");

                DbHelperSQL.ExecuteSqlTran(al);

                return "success";
            }
            catch(Exception exc)
            {
                return exc.Message;
            }
        }
        
        #endregion  ExtensionMethod
    }
}

