using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:v_ProductColorShip
    /// </summary>
    public partial class v_ProductColorShip
    {
        public v_ProductColorShip()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_ProductColorShip");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.v_ProductColorShip model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into v_ProductColorShip(");
            strSql.Append("ID,CodeName,Code,ptName,ptID,psName,psID,ppmNamme,ppmID,bddCaption,bddValue,sFullName,supplierID,ProductID,ColorID,Enabled,Install,ParentID,BarCode,Name,Specifications,Attribute,BarginPriceOut,StandardPriceIn,ReferencePriceOut,TagPrice,MinPriceOut,Profit,MaxStock,MinStock,StockProductCount,ProductPurchaseCount,SellingCost,SellingPrice,SellingProfit,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,PreinstallStock,PreinstallStockArea,PreinstallStockSite,BulkUnit,UnitBulk,WeightUnit,UnitWeight,PackCount,SellingLandTransportation,SellingSeaTransportation,SellingAirTransportation,SellingOtherTransportation,DayLandTransportation,DaySeaTransportation,DayAirTransportation,DayOtherTransportation,Long,Width,Height,ColorName,ColorCode,Image,Image1,Style,Texture,Standard,Shape,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate)");
            strSql.Append(" values (");
            strSql.Append("@ID,@CodeName,@Code,@ptName,@ptID,@psName,@psID,@ppmNamme,@ppmID,@bddCaption,@bddValue,@sFullName,@supplierID,@ProductID,@ColorID,@Enabled,@Install,@ParentID,@BarCode,@Name,@Specifications,@Attribute,@BarginPriceOut,@StandardPriceIn,@ReferencePriceOut,@TagPrice,@MinPriceOut,@Profit,@MaxStock,@MinStock,@StockProductCount,@ProductPurchaseCount,@SellingCost,@SellingPrice,@SellingProfit,@ReferencePriceA,@ReferencePriceB,@ReferencePriceC,@ReferencePriceD,@ReferencePriceE,@ReferencePriceF,@SellingAward,@SellingRoyaltyRate,@PreinstallStock,@PreinstallStockArea,@PreinstallStockSite,@BulkUnit,@UnitBulk,@WeightUnit,@UnitWeight,@PackCount,@SellingLandTransportation,@SellingSeaTransportation,@SellingAirTransportation,@SellingOtherTransportation,@DayLandTransportation,@DaySeaTransportation,@DayAirTransportation,@DayOtherTransportation,@Long,@Width,@Height,@ColorName,@ColorCode,@Image,@Image1,@Style,@Texture,@Standard,@Shape,@Remark,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8),
					new SqlParameter("@CodeName", SqlDbType.NVarChar,102),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@ptName", SqlDbType.NVarChar,50),
					new SqlParameter("@ptID", SqlDbType.BigInt,8),
					new SqlParameter("@psName", SqlDbType.NVarChar,50),
					new SqlParameter("@psID", SqlDbType.BigInt,8),
					new SqlParameter("@ppmNamme", SqlDbType.NVarChar,50),
					new SqlParameter("@ppmID", SqlDbType.BigInt,8),
					new SqlParameter("@bddCaption", SqlDbType.NVarChar,50),
					new SqlParameter("@bddValue", SqlDbType.NVarChar,50),
					new SqlParameter("@sFullName", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierID", SqlDbType.BigInt,8),
					new SqlParameter("@ProductID", SqlDbType.BigInt,8),
					new SqlParameter("@ColorID", SqlDbType.BigInt,8),
					new SqlParameter("@Enabled", SqlDbType.VarChar,2),
					new SqlParameter("@Install", SqlDbType.VarChar,2),
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@BarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Specifications", SqlDbType.NVarChar,50),
					new SqlParameter("@Attribute", SqlDbType.NVarChar,50),
					new SqlParameter("@BarginPriceOut", SqlDbType.Money,8),
					new SqlParameter("@StandardPriceIn", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceOut", SqlDbType.Money,8),
					new SqlParameter("@TagPrice", SqlDbType.Money,8),
					new SqlParameter("@MinPriceOut", SqlDbType.Money,8),
					new SqlParameter("@Profit", SqlDbType.Money,8),
					new SqlParameter("@MaxStock", SqlDbType.Float,8),
					new SqlParameter("@MinStock", SqlDbType.Float,8),
					new SqlParameter("@StockProductCount", SqlDbType.Int,4),
					new SqlParameter("@ProductPurchaseCount", SqlDbType.Int,4),
					new SqlParameter("@SellingCost", SqlDbType.Money,8),
					new SqlParameter("@SellingPrice", SqlDbType.Money,8),
					new SqlParameter("@SellingProfit", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceA", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceB", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceC", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceD", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceE", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceF", SqlDbType.Money,8),
					new SqlParameter("@SellingAward", SqlDbType.Money,8),
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
					new SqlParameter("@ColorName", SqlDbType.NVarChar,50),
					new SqlParameter("@ColorCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Image", SqlDbType.NVarChar,-1),
					new SqlParameter("@Image1", SqlDbType.NVarChar,200),
					new SqlParameter("@Style", SqlDbType.NVarChar,50),
					new SqlParameter("@Texture", SqlDbType.NVarChar,50),
					new SqlParameter("@Standard", SqlDbType.NVarChar,50),
					new SqlParameter("@Shape", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.NVarChar,100),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.CodeName;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.ptName;
            parameters[4].Value = model.ptID;
            parameters[5].Value = model.psName;
            parameters[6].Value = model.psID;
            parameters[7].Value = model.ppmNamme;
            parameters[8].Value = model.ppmID;
            parameters[9].Value = model.bddCaption;
            parameters[10].Value = model.bddValue;
            parameters[11].Value = model.sFullName;
            parameters[12].Value = model.supplierID;
            parameters[13].Value = model.ProductID;
            parameters[14].Value = model.ColorID;
            parameters[15].Value = model.Enabled;
            parameters[16].Value = model.Install;
            parameters[17].Value = model.ParentID;
            parameters[18].Value = model.BarCode;
            parameters[19].Value = model.Name;
            parameters[20].Value = model.Specifications;
            parameters[21].Value = model.Attribute;
            parameters[22].Value = model.BarginPriceOut;
            parameters[23].Value = model.StandardPriceIn;
            parameters[24].Value = model.ReferencePriceOut;
            parameters[25].Value = model.TagPrice;
            parameters[26].Value = model.MinPriceOut;
            parameters[27].Value = model.Profit;
            parameters[28].Value = model.MaxStock;
            parameters[29].Value = model.MinStock;
            parameters[30].Value = model.StockProductCount;
            parameters[31].Value = model.ProductPurchaseCount;
            parameters[32].Value = model.SellingCost;
            parameters[33].Value = model.SellingPrice;
            parameters[34].Value = model.SellingProfit;
            parameters[35].Value = model.ReferencePriceA;
            parameters[36].Value = model.ReferencePriceB;
            parameters[37].Value = model.ReferencePriceC;
            parameters[38].Value = model.ReferencePriceD;
            parameters[39].Value = model.ReferencePriceE;
            parameters[40].Value = model.ReferencePriceF;
            parameters[41].Value = model.SellingAward;
            parameters[42].Value = model.SellingRoyaltyRate;
            parameters[43].Value = model.PreinstallStock;
            parameters[44].Value = model.PreinstallStockArea;
            parameters[45].Value = model.PreinstallStockSite;
            parameters[46].Value = model.BulkUnit;
            parameters[47].Value = model.UnitBulk;
            parameters[48].Value = model.WeightUnit;
            parameters[49].Value = model.UnitWeight;
            parameters[50].Value = model.PackCount;
            parameters[51].Value = model.SellingLandTransportation;
            parameters[52].Value = model.SellingSeaTransportation;
            parameters[53].Value = model.SellingAirTransportation;
            parameters[54].Value = model.SellingOtherTransportation;
            parameters[55].Value = model.DayLandTransportation;
            parameters[56].Value = model.DaySeaTransportation;
            parameters[57].Value = model.DayAirTransportation;
            parameters[58].Value = model.DayOtherTransportation;
            parameters[59].Value = model.Long;
            parameters[60].Value = model.Width;
            parameters[61].Value = model.Height;
            parameters[62].Value = model.ColorName;
            parameters[63].Value = model.ColorCode;
            parameters[64].Value = model.Image;
            parameters[65].Value = model.Image1;
            parameters[66].Value = model.Style;
            parameters[67].Value = model.Texture;
            parameters[68].Value = model.Standard;
            parameters[69].Value = model.Shape;
            parameters[70].Value = model.Remark;
            parameters[71].Value = model.CreateUser;
            parameters[72].Value = model.CreateDate;
            parameters[73].Value = model.UpdateUser;
            parameters[74].Value = model.UpdateDate;

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
        public bool Update(Maticsoft.Model.v_ProductColorShip model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_ProductColorShip set ");
            strSql.Append("ID=@ID,");
            strSql.Append("CodeName=@CodeName,");
            strSql.Append("Code=@Code,");
            strSql.Append("ptName=@ptName,");
            strSql.Append("ptID=@ptID,");
            strSql.Append("psName=@psName,");
            strSql.Append("psID=@psID,");
            strSql.Append("ppmNamme=@ppmNamme,");
            strSql.Append("ppmID=@ppmID,");
            strSql.Append("bddCaption=@bddCaption,");
            strSql.Append("bddValue=@bddValue,");
            strSql.Append("sFullName=@sFullName,");
            strSql.Append("supplierID=@supplierID,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("ColorID=@ColorID,");
            strSql.Append("Enabled=@Enabled,");
            strSql.Append("Install=@Install,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("BarCode=@BarCode,");
            strSql.Append("Name=@Name,");
            strSql.Append("Specifications=@Specifications,");
            strSql.Append("Attribute=@Attribute,");
            strSql.Append("BarginPriceOut=@BarginPriceOut,");
            strSql.Append("StandardPriceIn=@StandardPriceIn,");
            strSql.Append("ReferencePriceOut=@ReferencePriceOut,");
            strSql.Append("TagPrice=@TagPrice,");
            strSql.Append("MinPriceOut=@MinPriceOut,");
            strSql.Append("Profit=@Profit,");
            strSql.Append("MaxStock=@MaxStock,");
            strSql.Append("MinStock=@MinStock,");
            strSql.Append("StockProductCount=@StockProductCount,");
            strSql.Append("ProductPurchaseCount=@ProductPurchaseCount,");
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
            strSql.Append("ColorName=@ColorName,");
            strSql.Append("ColorCode=@ColorCode,");
            strSql.Append("Image=@Image,");
            strSql.Append("Image1=@Image1,");
            strSql.Append("Style=@Style,");
            strSql.Append("Texture=@Texture,");
            strSql.Append("Standard=@Standard,");
            strSql.Append("Shape=@Shape,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("UpdateUser=@UpdateUser,");
            strSql.Append("UpdateDate=@UpdateDate");
            strSql.Append(" where ID=@ID and CodeName=@CodeName and Code=@Code and ptName=@ptName and ptID=@ptID and psName=@psName and psID=@psID and ppmNamme=@ppmNamme and ppmID=@ppmID and bddCaption=@bddCaption and bddValue=@bddValue and sFullName=@sFullName and supplierID=@supplierID and ProductID=@ProductID and ColorID=@ColorID and Enabled=@Enabled and Install=@Install and ParentID=@ParentID and BarCode=@BarCode and Name=@Name and Specifications=@Specifications and Attribute=@Attribute and BarginPriceOut=@BarginPriceOut and StandardPriceIn=@StandardPriceIn and ReferencePriceOut=@ReferencePriceOut and TagPrice=@TagPrice and MinPriceOut=@MinPriceOut and Profit=@Profit and MaxStock=@MaxStock and MinStock=@MinStock and StockProductCount=@StockProductCount and ProductPurchaseCount=@ProductPurchaseCount and SellingCost=@SellingCost and SellingPrice=@SellingPrice and SellingProfit=@SellingProfit and ReferencePriceA=@ReferencePriceA and ReferencePriceB=@ReferencePriceB and ReferencePriceC=@ReferencePriceC and ReferencePriceD=@ReferencePriceD and ReferencePriceE=@ReferencePriceE and ReferencePriceF=@ReferencePriceF and SellingAward=@SellingAward and SellingRoyaltyRate=@SellingRoyaltyRate and PreinstallStock=@PreinstallStock and PreinstallStockArea=@PreinstallStockArea and PreinstallStockSite=@PreinstallStockSite and BulkUnit=@BulkUnit and UnitBulk=@UnitBulk and WeightUnit=@WeightUnit and UnitWeight=@UnitWeight and PackCount=@PackCount and SellingLandTransportation=@SellingLandTransportation and SellingSeaTransportation=@SellingSeaTransportation and SellingAirTransportation=@SellingAirTransportation and SellingOtherTransportation=@SellingOtherTransportation and DayLandTransportation=@DayLandTransportation and DaySeaTransportation=@DaySeaTransportation and DayAirTransportation=@DayAirTransportation and DayOtherTransportation=@DayOtherTransportation and Long=@Long and Width=@Width and Height=@Height and ColorName=@ColorName and ColorCode=@ColorCode and Image=@Image and Image1=@Image1 and Style=@Style and Texture=@Texture and Standard=@Standard and Shape=@Shape and Remark=@Remark and CreateUser=@CreateUser and CreateDate=@CreateDate and UpdateUser=@UpdateUser and UpdateDate=@UpdateDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8),
					new SqlParameter("@CodeName", SqlDbType.NVarChar,102),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@ptName", SqlDbType.NVarChar,50),
					new SqlParameter("@ptID", SqlDbType.BigInt,8),
					new SqlParameter("@psName", SqlDbType.NVarChar,50),
					new SqlParameter("@psID", SqlDbType.BigInt,8),
					new SqlParameter("@ppmNamme", SqlDbType.NVarChar,50),
					new SqlParameter("@ppmID", SqlDbType.BigInt,8),
					new SqlParameter("@bddCaption", SqlDbType.NVarChar,50),
					new SqlParameter("@bddValue", SqlDbType.NVarChar,50),
					new SqlParameter("@sFullName", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierID", SqlDbType.BigInt,8),
					new SqlParameter("@ProductID", SqlDbType.BigInt,8),
					new SqlParameter("@ColorID", SqlDbType.BigInt,8),
					new SqlParameter("@Enabled", SqlDbType.VarChar,2),
					new SqlParameter("@Install", SqlDbType.VarChar,2),
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@BarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Specifications", SqlDbType.NVarChar,50),
					new SqlParameter("@Attribute", SqlDbType.NVarChar,50),
					new SqlParameter("@BarginPriceOut", SqlDbType.Money,8),
					new SqlParameter("@StandardPriceIn", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceOut", SqlDbType.Money,8),
					new SqlParameter("@TagPrice", SqlDbType.Money,8),
					new SqlParameter("@MinPriceOut", SqlDbType.Money,8),
					new SqlParameter("@Profit", SqlDbType.Money,8),
					new SqlParameter("@MaxStock", SqlDbType.Float,8),
					new SqlParameter("@MinStock", SqlDbType.Float,8),
					new SqlParameter("@StockProductCount", SqlDbType.Int,4),
					new SqlParameter("@ProductPurchaseCount", SqlDbType.Int,4),
					new SqlParameter("@SellingCost", SqlDbType.Money,8),
					new SqlParameter("@SellingPrice", SqlDbType.Money,8),
					new SqlParameter("@SellingProfit", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceA", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceB", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceC", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceD", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceE", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceF", SqlDbType.Money,8),
					new SqlParameter("@SellingAward", SqlDbType.Money,8),
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
					new SqlParameter("@ColorName", SqlDbType.NVarChar,50),
					new SqlParameter("@ColorCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Image", SqlDbType.NVarChar,-1),
					new SqlParameter("@Image1", SqlDbType.NVarChar,200),
					new SqlParameter("@Style", SqlDbType.NVarChar,50),
					new SqlParameter("@Texture", SqlDbType.NVarChar,50),
					new SqlParameter("@Standard", SqlDbType.NVarChar,50),
					new SqlParameter("@Shape", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.NVarChar,100),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.CodeName;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.ptName;
            parameters[4].Value = model.ptID;
            parameters[5].Value = model.psName;
            parameters[6].Value = model.psID;
            parameters[7].Value = model.ppmNamme;
            parameters[8].Value = model.ppmID;
            parameters[9].Value = model.bddCaption;
            parameters[10].Value = model.bddValue;
            parameters[11].Value = model.sFullName;
            parameters[12].Value = model.supplierID;
            parameters[13].Value = model.ProductID;
            parameters[14].Value = model.ColorID;
            parameters[15].Value = model.Enabled;
            parameters[16].Value = model.Install;
            parameters[17].Value = model.ParentID;
            parameters[18].Value = model.BarCode;
            parameters[19].Value = model.Name;
            parameters[20].Value = model.Specifications;
            parameters[21].Value = model.Attribute;
            parameters[22].Value = model.BarginPriceOut;
            parameters[23].Value = model.StandardPriceIn;
            parameters[24].Value = model.ReferencePriceOut;
            parameters[25].Value = model.TagPrice;
            parameters[26].Value = model.MinPriceOut;
            parameters[27].Value = model.Profit;
            parameters[28].Value = model.MaxStock;
            parameters[29].Value = model.MinStock;
            parameters[30].Value = model.StockProductCount;
            parameters[31].Value = model.ProductPurchaseCount;
            parameters[32].Value = model.SellingCost;
            parameters[33].Value = model.SellingPrice;
            parameters[34].Value = model.SellingProfit;
            parameters[35].Value = model.ReferencePriceA;
            parameters[36].Value = model.ReferencePriceB;
            parameters[37].Value = model.ReferencePriceC;
            parameters[38].Value = model.ReferencePriceD;
            parameters[39].Value = model.ReferencePriceE;
            parameters[40].Value = model.ReferencePriceF;
            parameters[41].Value = model.SellingAward;
            parameters[42].Value = model.SellingRoyaltyRate;
            parameters[43].Value = model.PreinstallStock;
            parameters[44].Value = model.PreinstallStockArea;
            parameters[45].Value = model.PreinstallStockSite;
            parameters[46].Value = model.BulkUnit;
            parameters[47].Value = model.UnitBulk;
            parameters[48].Value = model.WeightUnit;
            parameters[49].Value = model.UnitWeight;
            parameters[50].Value = model.PackCount;
            parameters[51].Value = model.SellingLandTransportation;
            parameters[52].Value = model.SellingSeaTransportation;
            parameters[53].Value = model.SellingAirTransportation;
            parameters[54].Value = model.SellingOtherTransportation;
            parameters[55].Value = model.DayLandTransportation;
            parameters[56].Value = model.DaySeaTransportation;
            parameters[57].Value = model.DayAirTransportation;
            parameters[58].Value = model.DayOtherTransportation;
            parameters[59].Value = model.Long;
            parameters[60].Value = model.Width;
            parameters[61].Value = model.Height;
            parameters[62].Value = model.ColorName;
            parameters[63].Value = model.ColorCode;
            parameters[64].Value = model.Image;
            parameters[65].Value = model.Image1;
            parameters[66].Value = model.Style;
            parameters[67].Value = model.Texture;
            parameters[68].Value = model.Standard;
            parameters[69].Value = model.Shape;
            parameters[70].Value = model.Remark;
            parameters[71].Value = model.CreateUser;
            parameters[72].Value = model.CreateDate;
            parameters[73].Value = model.UpdateUser;
            parameters[74].Value = model.UpdateDate;

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
        public bool Delete(long ID, string CodeName, string Code, string ptName, long ptID, string psName, long psID, string ppmNamme, long ppmID, string bddCaption, string bddValue, string sFullName, long supplierID, long ProductID, long ColorID, string Enabled, string Install, long ParentID, string BarCode, string Name, string Specifications, string Attribute, decimal BarginPriceOut, decimal StandardPriceIn, decimal ReferencePriceOut, decimal TagPrice, decimal MinPriceOut, decimal Profit, decimal MaxStock, decimal MinStock, int StockProductCount, int ProductPurchaseCount, decimal SellingCost, decimal SellingPrice, decimal SellingProfit, decimal ReferencePriceA, decimal ReferencePriceB, decimal ReferencePriceC, decimal ReferencePriceD, decimal ReferencePriceE, decimal ReferencePriceF, decimal SellingAward, decimal SellingRoyaltyRate, string PreinstallStock, string PreinstallStockArea, string PreinstallStockSite, string BulkUnit, string UnitBulk, string WeightUnit, string UnitWeight, decimal PackCount, decimal SellingLandTransportation, decimal SellingSeaTransportation, decimal SellingAirTransportation, decimal SellingOtherTransportation, decimal DayLandTransportation, decimal DaySeaTransportation, decimal DayAirTransportation, decimal DayOtherTransportation, decimal Long, decimal Width, decimal Height, string ColorName, string ColorCode, string Image, string Image1, string Style, string Texture, string Standard, string Shape, string Remark, string CreateUser, DateTime CreateDate, string UpdateUser, DateTime UpdateDate)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_ProductColorShip ");
            strSql.Append(" where ID=@ID and CodeName=@CodeName and Code=@Code and ptName=@ptName and ptID=@ptID and psName=@psName and psID=@psID and ppmNamme=@ppmNamme and ppmID=@ppmID and bddCaption=@bddCaption and bddValue=@bddValue and sFullName=@sFullName and supplierID=@supplierID and ProductID=@ProductID and ColorID=@ColorID and Enabled=@Enabled and Install=@Install and ParentID=@ParentID and BarCode=@BarCode and Name=@Name and Specifications=@Specifications and Attribute=@Attribute and BarginPriceOut=@BarginPriceOut and StandardPriceIn=@StandardPriceIn and ReferencePriceOut=@ReferencePriceOut and TagPrice=@TagPrice and MinPriceOut=@MinPriceOut and Profit=@Profit and MaxStock=@MaxStock and MinStock=@MinStock and StockProductCount=@StockProductCount and ProductPurchaseCount=@ProductPurchaseCount and SellingCost=@SellingCost and SellingPrice=@SellingPrice and SellingProfit=@SellingProfit and ReferencePriceA=@ReferencePriceA and ReferencePriceB=@ReferencePriceB and ReferencePriceC=@ReferencePriceC and ReferencePriceD=@ReferencePriceD and ReferencePriceE=@ReferencePriceE and ReferencePriceF=@ReferencePriceF and SellingAward=@SellingAward and SellingRoyaltyRate=@SellingRoyaltyRate and PreinstallStock=@PreinstallStock and PreinstallStockArea=@PreinstallStockArea and PreinstallStockSite=@PreinstallStockSite and BulkUnit=@BulkUnit and UnitBulk=@UnitBulk and WeightUnit=@WeightUnit and UnitWeight=@UnitWeight and PackCount=@PackCount and SellingLandTransportation=@SellingLandTransportation and SellingSeaTransportation=@SellingSeaTransportation and SellingAirTransportation=@SellingAirTransportation and SellingOtherTransportation=@SellingOtherTransportation and DayLandTransportation=@DayLandTransportation and DaySeaTransportation=@DaySeaTransportation and DayAirTransportation=@DayAirTransportation and DayOtherTransportation=@DayOtherTransportation and Long=@Long and Width=@Width and Height=@Height and ColorName=@ColorName and ColorCode=@ColorCode and Image=@Image and Image1=@Image1 and Style=@Style and Texture=@Texture and Standard=@Standard and Shape=@Shape and Remark=@Remark and CreateUser=@CreateUser and CreateDate=@CreateDate and UpdateUser=@UpdateUser and UpdateDate=@UpdateDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8),
					new SqlParameter("@CodeName", SqlDbType.NVarChar,102),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@ptName", SqlDbType.NVarChar,50),
					new SqlParameter("@ptID", SqlDbType.BigInt,8),
					new SqlParameter("@psName", SqlDbType.NVarChar,50),
					new SqlParameter("@psID", SqlDbType.BigInt,8),
					new SqlParameter("@ppmNamme", SqlDbType.NVarChar,50),
					new SqlParameter("@ppmID", SqlDbType.BigInt,8),
					new SqlParameter("@bddCaption", SqlDbType.NVarChar,50),
					new SqlParameter("@bddValue", SqlDbType.NVarChar,50),
					new SqlParameter("@sFullName", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierID", SqlDbType.BigInt,8),
					new SqlParameter("@ProductID", SqlDbType.BigInt,8),
					new SqlParameter("@ColorID", SqlDbType.BigInt,8),
					new SqlParameter("@Enabled", SqlDbType.VarChar,2),
					new SqlParameter("@Install", SqlDbType.VarChar,2),
					new SqlParameter("@ParentID", SqlDbType.BigInt,8),
					new SqlParameter("@BarCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Specifications", SqlDbType.NVarChar,50),
					new SqlParameter("@Attribute", SqlDbType.NVarChar,50),
					new SqlParameter("@BarginPriceOut", SqlDbType.Money,8),
					new SqlParameter("@StandardPriceIn", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceOut", SqlDbType.Money,8),
					new SqlParameter("@TagPrice", SqlDbType.Money,8),
					new SqlParameter("@MinPriceOut", SqlDbType.Money,8),
					new SqlParameter("@Profit", SqlDbType.Money,8),
					new SqlParameter("@MaxStock", SqlDbType.Float,8),
					new SqlParameter("@MinStock", SqlDbType.Float,8),
					new SqlParameter("@StockProductCount", SqlDbType.Int,4),
					new SqlParameter("@ProductPurchaseCount", SqlDbType.Int,4),
					new SqlParameter("@SellingCost", SqlDbType.Money,8),
					new SqlParameter("@SellingPrice", SqlDbType.Money,8),
					new SqlParameter("@SellingProfit", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceA", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceB", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceC", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceD", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceE", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceF", SqlDbType.Money,8),
					new SqlParameter("@SellingAward", SqlDbType.Money,8),
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
					new SqlParameter("@ColorName", SqlDbType.NVarChar,50),
					new SqlParameter("@ColorCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Image", SqlDbType.NVarChar,-1),
					new SqlParameter("@Image1", SqlDbType.NVarChar,200),
					new SqlParameter("@Style", SqlDbType.NVarChar,50),
					new SqlParameter("@Texture", SqlDbType.NVarChar,50),
					new SqlParameter("@Standard", SqlDbType.NVarChar,50),
					new SqlParameter("@Shape", SqlDbType.NVarChar,50),
					new SqlParameter("@Remark", SqlDbType.NVarChar,-1),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,100),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.NVarChar,100),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime)			};
            parameters[0].Value = ID;
            parameters[1].Value = CodeName;
            parameters[2].Value = Code;
            parameters[3].Value = ptName;
            parameters[4].Value = ptID;
            parameters[5].Value = psName;
            parameters[6].Value = psID;
            parameters[7].Value = ppmNamme;
            parameters[8].Value = ppmID;
            parameters[9].Value = bddCaption;
            parameters[10].Value = bddValue;
            parameters[11].Value = sFullName;
            parameters[12].Value = supplierID;
            parameters[13].Value = ProductID;
            parameters[14].Value = ColorID;
            parameters[15].Value = Enabled;
            parameters[16].Value = Install;
            parameters[17].Value = ParentID;
            parameters[18].Value = BarCode;
            parameters[19].Value = Name;
            parameters[20].Value = Specifications;
            parameters[21].Value = Attribute;
            parameters[22].Value = BarginPriceOut;
            parameters[23].Value = StandardPriceIn;
            parameters[24].Value = ReferencePriceOut;
            parameters[25].Value = TagPrice;
            parameters[26].Value = MinPriceOut;
            parameters[27].Value = Profit;
            parameters[28].Value = MaxStock;
            parameters[29].Value = MinStock;
            parameters[30].Value = StockProductCount;
            parameters[31].Value = ProductPurchaseCount;
            parameters[32].Value = SellingCost;
            parameters[33].Value = SellingPrice;
            parameters[34].Value = SellingProfit;
            parameters[35].Value = ReferencePriceA;
            parameters[36].Value = ReferencePriceB;
            parameters[37].Value = ReferencePriceC;
            parameters[38].Value = ReferencePriceD;
            parameters[39].Value = ReferencePriceE;
            parameters[40].Value = ReferencePriceF;
            parameters[41].Value = SellingAward;
            parameters[42].Value = SellingRoyaltyRate;
            parameters[43].Value = PreinstallStock;
            parameters[44].Value = PreinstallStockArea;
            parameters[45].Value = PreinstallStockSite;
            parameters[46].Value = BulkUnit;
            parameters[47].Value = UnitBulk;
            parameters[48].Value = WeightUnit;
            parameters[49].Value = UnitWeight;
            parameters[50].Value = PackCount;
            parameters[51].Value = SellingLandTransportation;
            parameters[52].Value = SellingSeaTransportation;
            parameters[53].Value = SellingAirTransportation;
            parameters[54].Value = SellingOtherTransportation;
            parameters[55].Value = DayLandTransportation;
            parameters[56].Value = DaySeaTransportation;
            parameters[57].Value = DayAirTransportation;
            parameters[58].Value = DayOtherTransportation;
            parameters[59].Value = Long;
            parameters[60].Value = Width;
            parameters[61].Value = Height;
            parameters[62].Value = ColorName;
            parameters[63].Value = ColorCode;
            parameters[64].Value = Image;
            parameters[65].Value = Image1;
            parameters[66].Value = Style;
            parameters[67].Value = Texture;
            parameters[68].Value = Standard;
            parameters[69].Value = Shape;
            parameters[70].Value = Remark;
            parameters[71].Value = CreateUser;
            parameters[72].Value = CreateDate;
            parameters[73].Value = UpdateUser;
            parameters[74].Value = UpdateDate;

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
        public Maticsoft.Model.v_ProductColorShip GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,CodeName,Code,ptName,ptID,psName,psID,ppmNamme,ppmID,bddCaption,bddValue,sFullName,supplierID,ProductID,ColorID,Enabled,Install,ParentID,BarCode,Name,Specifications,Attribute,BarginPriceOut,StandardPriceIn,ReferencePriceOut,TagPrice,MinPriceOut,Profit,MaxStock,MinStock,StockProductCount,ProductPurchaseCount,SellingCost,SellingPrice,SellingProfit,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,PreinstallStock,PreinstallStockArea,PreinstallStockSite,BulkUnit,UnitBulk,WeightUnit,UnitWeight,PackCount,SellingLandTransportation,SellingSeaTransportation,SellingAirTransportation,SellingOtherTransportation,DayLandTransportation,DaySeaTransportation,DayAirTransportation,DayOtherTransportation,Long,Width,Height,ColorName,ColorCode,Image,Image1,Style,Texture,Standard,Shape,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate from v_ProductColorShip ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
            parameters[0].Value = ID;
           
            Maticsoft.Model.v_ProductColorShip model = new Maticsoft.Model.v_ProductColorShip();
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
        public Maticsoft.Model.v_ProductColorShip DataRowToModel(DataRow row)
        {
            Maticsoft.Model.v_ProductColorShip model = new Maticsoft.Model.v_ProductColorShip();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = long.Parse(row["ID"].ToString());
                }
                if (row["CodeName"] != null)
                {
                    model.CodeName = row["CodeName"].ToString();
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["ptName"] != null)
                {
                    model.ptName = row["ptName"].ToString();
                }
                if (row["ptID"] != null && row["ptID"].ToString() != "")
                {
                    model.ptID = long.Parse(row["ptID"].ToString());
                }
                if (row["psName"] != null)
                {
                    model.psName = row["psName"].ToString();
                }
                if (row["psID"] != null && row["psID"].ToString() != "")
                {
                    model.psID = long.Parse(row["psID"].ToString());
                }
                if (row["ppmNamme"] != null)
                {
                    model.ppmNamme = row["ppmNamme"].ToString();
                }
                if (row["ppmID"] != null && row["ppmID"].ToString() != "")
                {
                    model.ppmID = long.Parse(row["ppmID"].ToString());
                }
                if (row["bddCaption"] != null)
                {
                    model.bddCaption = row["bddCaption"].ToString();
                }
                if (row["bddValue"] != null)
                {
                    model.bddValue = row["bddValue"].ToString();
                }
                if (row["sFullName"] != null)
                {
                    model.sFullName = row["sFullName"].ToString();
                }
                if (row["supplierID"] != null && row["supplierID"].ToString() != "")
                {
                    model.supplierID = long.Parse(row["supplierID"].ToString());
                }
                if (row["ProductID"] != null && row["ProductID"].ToString() != "")
                {
                    model.ProductID = long.Parse(row["ProductID"].ToString());
                }
                if (row["ColorID"] != null && row["ColorID"].ToString() != "")
                {
                    model.ColorID = long.Parse(row["ColorID"].ToString());
                }
                if (row["Enabled"] != null)
                {
                    model.Enabled = row["Enabled"].ToString();
                }
                if (row["Install"] != null)
                {
                    model.Install = row["Install"].ToString();
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = long.Parse(row["ParentID"].ToString());
                }
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Specifications"] != null)
                {
                    model.Specifications = row["Specifications"].ToString();
                }
                if (row["Attribute"] != null)
                {
                    model.Attribute = row["Attribute"].ToString();
                }
                if (row["BarginPriceOut"] != null && row["BarginPriceOut"].ToString() != "")
                {
                    model.BarginPriceOut = decimal.Parse(row["BarginPriceOut"].ToString());
                }
                if (row["StandardPriceIn"] != null && row["StandardPriceIn"].ToString() != "")
                {
                    model.StandardPriceIn = decimal.Parse(row["StandardPriceIn"].ToString());
                }
                if (row["ReferencePriceOut"] != null && row["ReferencePriceOut"].ToString() != "")
                {
                    model.ReferencePriceOut = decimal.Parse(row["ReferencePriceOut"].ToString());
                }
                if (row["TagPrice"] != null && row["TagPrice"].ToString() != "")
                {
                    model.TagPrice = decimal.Parse(row["TagPrice"].ToString());
                }
                if (row["MinPriceOut"] != null && row["MinPriceOut"].ToString() != "")
                {
                    model.MinPriceOut = decimal.Parse(row["MinPriceOut"].ToString());
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
                if (row["StockProductCount"] != null && row["StockProductCount"].ToString() != "")
                {
                    model.StockProductCount = int.Parse(row["StockProductCount"].ToString());
                }
                if (row["ProductPurchaseCount"] != null && row["ProductPurchaseCount"].ToString() != "")
                {
                    model.ProductPurchaseCount = int.Parse(row["ProductPurchaseCount"].ToString());
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
                if (row["SellingAward"] != null && row["SellingAward"].ToString() != "")
                {
                    model.SellingAward = decimal.Parse(row["SellingAward"].ToString());
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
                if (row["ColorName"] != null)
                {
                    model.ColorName = row["ColorName"].ToString();
                }
                if (row["ColorCode"] != null)
                {
                    model.ColorCode = row["ColorCode"].ToString();
                }
                if (row["Image"] != null)
                {
                    model.Image = row["Image"].ToString();
                }
                if (row["Image1"] != null)
                {
                    model.Image1 = row["Image1"].ToString();
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
            strSql.Append("select ID,CodeName,Code,ptName,ptID,psName,psID,ppmNamme,ppmID,bddCaption,bddValue,sFullName,supplierID,ProductID,ColorID,Enabled,Install,ParentID,BarCode,Name,Specifications,Attribute,BarginPriceOut,StandardPriceIn,ReferencePriceOut,TagPrice,MinPriceOut,Profit,MaxStock,MinStock,StockProductCount,ProductPurchaseCount,SellingCost,SellingPrice,SellingProfit,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,PreinstallStock,PreinstallStockArea,PreinstallStockSite,BulkUnit,UnitBulk,WeightUnit,UnitWeight,PackCount,SellingLandTransportation,SellingSeaTransportation,SellingAirTransportation,SellingOtherTransportation,DayLandTransportation,DaySeaTransportation,DayAirTransportation,DayOtherTransportation,Long,Width,Height,ColorName,ColorCode,Image,Image1,Style,Texture,Standard,Shape,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM v_ProductColorShip ");
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
            strSql.Append(" ID,CodeName,Code,ptName,ptID,psName,psID,ppmNamme,ppmID,bddCaption,bddValue,sFullName,supplierID,ProductID,ColorID,Enabled,Install,ParentID,BarCode,Name,Specifications,Attribute,BarginPriceOut,StandardPriceIn,ReferencePriceOut,TagPrice,MinPriceOut,Profit,MaxStock,MinStock,StockProductCount,ProductPurchaseCount,SellingCost,SellingPrice,SellingProfit,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,PreinstallStock,PreinstallStockArea,PreinstallStockSite,BulkUnit,UnitBulk,WeightUnit,UnitWeight,PackCount,SellingLandTransportation,SellingSeaTransportation,SellingAirTransportation,SellingOtherTransportation,DayLandTransportation,DaySeaTransportation,DayAirTransportation,DayOtherTransportation,Long,Width,Height,ColorName,ColorCode,Image,Image1,Style,Texture,Standard,Shape,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate ");
            strSql.Append(" FROM v_ProductColorShip ");
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
            strSql.Append("select count(1) FROM v_ProductColorShip ");
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
                strSql.Append("order by T.UpdateDate desc");
            }
            strSql.Append(")AS Row, T.*  from v_ProductColorShip T ");
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
            parameters[0].Value = "v_ProductColorShip";
            parameters[1].Value = "UpdateDate";
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
