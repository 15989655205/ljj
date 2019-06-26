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
	/// 数据访问类:ProductItem
	/// </summary>
	public partial class ProductPriceColorShip
	{
        public ProductPriceColorShip()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductItem");
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
        public long Add(Maticsoft.Model.ProductPriceColorShip model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProductItem(");
			strSql.Append("ProductID,ColorID,Attribute,BarginPriceOut,ReferencePriceOut,StandardPriceIn,MinPriceOut,Profit,TagPrice,Image,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,StockProductCount,ProductPurchaseCount,SellingCost,ProcessCost,TransCost,SellingPrice,SellingProfit,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate,Status)");
			strSql.Append(" values (");
			strSql.Append("@ProductID,@ColorID,@Attribute,@BarginPriceOut,@ReferencePriceOut,@StandardPriceIn,@MinPriceOut,@Profit,@TagPrice,@Image,@ReferencePriceA,@ReferencePriceB,@ReferencePriceC,@ReferencePriceD,@ReferencePriceE,@ReferencePriceF,@SellingAward,@SellingRoyaltyRate,@StockProductCount,@ProductPurchaseCount,@SellingCost,@ProcessCost,@TransCost,@SellingPrice,@SellingProfit,@Remark,@CreateUser,@CreateDate,@UpdateUser,@UpdateDate,@Status)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.BigInt,8),
					new SqlParameter("@ColorID", SqlDbType.BigInt,8),
					new SqlParameter("@Attribute", SqlDbType.Char,1),
					new SqlParameter("@BarginPriceOut", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceOut", SqlDbType.Money,8),
					new SqlParameter("@StandardPriceIn", SqlDbType.Money,8),
					new SqlParameter("@MinPriceOut", SqlDbType.Money,8),
					new SqlParameter("@Profit", SqlDbType.Money,8),
					new SqlParameter("@TagPrice", SqlDbType.Money,8),
					new SqlParameter("@Image", SqlDbType.NVarChar,-1),
					new SqlParameter("@ReferencePriceA", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceB", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceC", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceD", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceE", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceF", SqlDbType.Money,8),
					new SqlParameter("@SellingAward", SqlDbType.Money,8),
					new SqlParameter("@SellingRoyaltyRate", SqlDbType.Float,8),
					new SqlParameter("@StockProductCount", SqlDbType.Int,4),
					new SqlParameter("@ProductPurchaseCount", SqlDbType.Int,4),
					new SqlParameter("@SellingCost", SqlDbType.Money,8),
					new SqlParameter("@ProcessCost", SqlDbType.Money,8),
					new SqlParameter("@TransCost", SqlDbType.Money,8),
					new SqlParameter("@SellingPrice", SqlDbType.Money,8),
					new SqlParameter("@SellingProfit", SqlDbType.Money,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateUser", SqlDbType.BigInt,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.BigInt,8),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Char,2)};
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.ColorID;
			parameters[2].Value = model.Attribute;
			parameters[3].Value = model.BarginPriceOut;
			parameters[4].Value = model.ReferencePriceOut;
			parameters[5].Value = model.StandardPriceIn;
			parameters[6].Value = model.MinPriceOut;
			parameters[7].Value = model.Profit;
			parameters[8].Value = model.TagPrice;
			parameters[9].Value = model.Image;
			parameters[10].Value = model.ReferencePriceA;
			parameters[11].Value = model.ReferencePriceB;
			parameters[12].Value = model.ReferencePriceC;
			parameters[13].Value = model.ReferencePriceD;
			parameters[14].Value = model.ReferencePriceE;
			parameters[15].Value = model.ReferencePriceF;
			parameters[16].Value = model.SellingAward;
			parameters[17].Value = model.SellingRoyaltyRate;
			parameters[18].Value = model.StockProductCount;
			parameters[19].Value = model.ProductPurchaseCount;
			parameters[20].Value = model.SellingCost;
			parameters[21].Value = model.ProcessCost;
			parameters[22].Value = model.TransCost;
			parameters[23].Value = model.SellingPrice;
			parameters[24].Value = model.SellingProfit;
			parameters[25].Value = model.Remark;
			parameters[26].Value = model.CreateUser;
			parameters[27].Value = model.CreateDate;
			parameters[28].Value = model.UpdateUser;
			parameters[29].Value = model.UpdateDate;
			parameters[30].Value = model.Status;

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
        public bool Update(Maticsoft.Model.ProductPriceColorShip model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductItem set ");
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("ColorID=@ColorID,");
			strSql.Append("Attribute=@Attribute,");
			strSql.Append("BarginPriceOut=@BarginPriceOut,");
			strSql.Append("ReferencePriceOut=@ReferencePriceOut,");
			strSql.Append("StandardPriceIn=@StandardPriceIn,");
			strSql.Append("MinPriceOut=@MinPriceOut,");
			strSql.Append("Profit=@Profit,");
			strSql.Append("TagPrice=@TagPrice,");
			strSql.Append("Image=@Image,");
			strSql.Append("ReferencePriceA=@ReferencePriceA,");
			strSql.Append("ReferencePriceB=@ReferencePriceB,");
			strSql.Append("ReferencePriceC=@ReferencePriceC,");
			strSql.Append("ReferencePriceD=@ReferencePriceD,");
			strSql.Append("ReferencePriceE=@ReferencePriceE,");
			strSql.Append("ReferencePriceF=@ReferencePriceF,");
			strSql.Append("SellingAward=@SellingAward,");
			strSql.Append("SellingRoyaltyRate=@SellingRoyaltyRate,");
			strSql.Append("StockProductCount=@StockProductCount,");
			strSql.Append("ProductPurchaseCount=@ProductPurchaseCount,");
			strSql.Append("SellingCost=@SellingCost,");
			strSql.Append("ProcessCost=@ProcessCost,");
			strSql.Append("TransCost=@TransCost,");
			strSql.Append("SellingPrice=@SellingPrice,");
			strSql.Append("SellingProfit=@SellingProfit,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("UpdateUser=@UpdateUser,");
			strSql.Append("UpdateDate=@UpdateDate,");
			strSql.Append("Status=@Status");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductID", SqlDbType.BigInt,8),
					new SqlParameter("@ColorID", SqlDbType.BigInt,8),
					new SqlParameter("@Attribute", SqlDbType.Char,1),
					new SqlParameter("@BarginPriceOut", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceOut", SqlDbType.Money,8),
					new SqlParameter("@StandardPriceIn", SqlDbType.Money,8),
					new SqlParameter("@MinPriceOut", SqlDbType.Money,8),
					new SqlParameter("@Profit", SqlDbType.Money,8),
					new SqlParameter("@TagPrice", SqlDbType.Money,8),
					new SqlParameter("@Image", SqlDbType.NVarChar,-1),
					new SqlParameter("@ReferencePriceA", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceB", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceC", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceD", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceE", SqlDbType.Money,8),
					new SqlParameter("@ReferencePriceF", SqlDbType.Money,8),
					new SqlParameter("@SellingAward", SqlDbType.Money,8),
					new SqlParameter("@SellingRoyaltyRate", SqlDbType.Float,8),
					new SqlParameter("@StockProductCount", SqlDbType.Int,4),
					new SqlParameter("@ProductPurchaseCount", SqlDbType.Int,4),
					new SqlParameter("@SellingCost", SqlDbType.Money,8),
					new SqlParameter("@ProcessCost", SqlDbType.Money,8),
					new SqlParameter("@TransCost", SqlDbType.Money,8),
					new SqlParameter("@SellingPrice", SqlDbType.Money,8),
					new SqlParameter("@SellingProfit", SqlDbType.Money,8),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateUser", SqlDbType.BigInt,8),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UpdateUser", SqlDbType.BigInt,8),
					new SqlParameter("@UpdateDate", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.Char,2),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.ColorID;
			parameters[2].Value = model.Attribute;
			parameters[3].Value = model.BarginPriceOut;
			parameters[4].Value = model.ReferencePriceOut;
			parameters[5].Value = model.StandardPriceIn;
			parameters[6].Value = model.MinPriceOut;
			parameters[7].Value = model.Profit;
			parameters[8].Value = model.TagPrice;
			parameters[9].Value = model.Image;
			parameters[10].Value = model.ReferencePriceA;
			parameters[11].Value = model.ReferencePriceB;
			parameters[12].Value = model.ReferencePriceC;
			parameters[13].Value = model.ReferencePriceD;
			parameters[14].Value = model.ReferencePriceE;
			parameters[15].Value = model.ReferencePriceF;
			parameters[16].Value = model.SellingAward;
			parameters[17].Value = model.SellingRoyaltyRate;
			parameters[18].Value = model.StockProductCount;
			parameters[19].Value = model.ProductPurchaseCount;
			parameters[20].Value = model.SellingCost;
			parameters[21].Value = model.ProcessCost;
			parameters[22].Value = model.TransCost;
			parameters[23].Value = model.SellingPrice;
			parameters[24].Value = model.SellingProfit;
			parameters[25].Value = model.Remark;
			parameters[26].Value = model.CreateUser;
			parameters[27].Value = model.CreateDate;
			parameters[28].Value = model.UpdateUser;
			parameters[29].Value = model.UpdateDate;
			parameters[30].Value = model.Status;
			parameters[31].Value = model.ID;

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
			strSql.Append("delete from ProductItem ");
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
			strSql.Append("delete from ProductItem ");
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
        public Maticsoft.Model.ProductPriceColorShip GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ProductID,ColorID,Attribute,BarginPriceOut,ReferencePriceOut,StandardPriceIn,MinPriceOut,Profit,TagPrice,Image,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,StockProductCount,ProductPurchaseCount,SellingCost,ProcessCost,TransCost,SellingPrice,SellingProfit,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate,Status from ProductItem ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)
			};
			parameters[0].Value = ID;

            Maticsoft.Model.ProductPriceColorShip model = new Maticsoft.Model.ProductPriceColorShip();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public Maticsoft.Model.ProductPriceColorShip DataRowToModel(DataRow row)
		{
            Maticsoft.Model.ProductPriceColorShip model = new Maticsoft.Model.ProductPriceColorShip();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
				if(row["ProductID"]!=null && row["ProductID"].ToString()!="")
				{
					model.ProductID=long.Parse(row["ProductID"].ToString());
				}
				if(row["ColorID"]!=null && row["ColorID"].ToString()!="")
				{
					model.ColorID=long.Parse(row["ColorID"].ToString());
				}
				if(row["Attribute"]!=null)
				{
					model.Attribute=row["Attribute"].ToString();
				}
				if(row["BarginPriceOut"]!=null && row["BarginPriceOut"].ToString()!="")
				{
					model.BarginPriceOut=decimal.Parse(row["BarginPriceOut"].ToString());
				}
				if(row["ReferencePriceOut"]!=null && row["ReferencePriceOut"].ToString()!="")
				{
					model.ReferencePriceOut=decimal.Parse(row["ReferencePriceOut"].ToString());
				}
				if(row["StandardPriceIn"]!=null && row["StandardPriceIn"].ToString()!="")
				{
					model.StandardPriceIn=decimal.Parse(row["StandardPriceIn"].ToString());
				}
				if(row["MinPriceOut"]!=null && row["MinPriceOut"].ToString()!="")
				{
					model.MinPriceOut=decimal.Parse(row["MinPriceOut"].ToString());
				}
				if(row["Profit"]!=null && row["Profit"].ToString()!="")
				{
					model.Profit=decimal.Parse(row["Profit"].ToString());
				}
				if(row["TagPrice"]!=null && row["TagPrice"].ToString()!="")
				{
					model.TagPrice=decimal.Parse(row["TagPrice"].ToString());
				}
				if(row["Image"]!=null)
				{
					model.Image=row["Image"].ToString();
				}
				if(row["ReferencePriceA"]!=null && row["ReferencePriceA"].ToString()!="")
				{
					model.ReferencePriceA=decimal.Parse(row["ReferencePriceA"].ToString());
				}
				if(row["ReferencePriceB"]!=null && row["ReferencePriceB"].ToString()!="")
				{
					model.ReferencePriceB=decimal.Parse(row["ReferencePriceB"].ToString());
				}
				if(row["ReferencePriceC"]!=null && row["ReferencePriceC"].ToString()!="")
				{
					model.ReferencePriceC=decimal.Parse(row["ReferencePriceC"].ToString());
				}
				if(row["ReferencePriceD"]!=null && row["ReferencePriceD"].ToString()!="")
				{
					model.ReferencePriceD=decimal.Parse(row["ReferencePriceD"].ToString());
				}
				if(row["ReferencePriceE"]!=null && row["ReferencePriceE"].ToString()!="")
				{
					model.ReferencePriceE=decimal.Parse(row["ReferencePriceE"].ToString());
				}
				if(row["ReferencePriceF"]!=null && row["ReferencePriceF"].ToString()!="")
				{
					model.ReferencePriceF=decimal.Parse(row["ReferencePriceF"].ToString());
				}
				if(row["SellingAward"]!=null && row["SellingAward"].ToString()!="")
				{
					model.SellingAward=decimal.Parse(row["SellingAward"].ToString());
				}
				if(row["SellingRoyaltyRate"]!=null && row["SellingRoyaltyRate"].ToString()!="")
				{
					model.SellingRoyaltyRate=decimal.Parse(row["SellingRoyaltyRate"].ToString());
				}
				if(row["StockProductCount"]!=null && row["StockProductCount"].ToString()!="")
				{
					model.StockProductCount=int.Parse(row["StockProductCount"].ToString());
				}
				if(row["ProductPurchaseCount"]!=null && row["ProductPurchaseCount"].ToString()!="")
				{
					model.ProductPurchaseCount=int.Parse(row["ProductPurchaseCount"].ToString());
				}
				if(row["SellingCost"]!=null && row["SellingCost"].ToString()!="")
				{
					model.SellingCost=decimal.Parse(row["SellingCost"].ToString());
				}
				if(row["ProcessCost"]!=null && row["ProcessCost"].ToString()!="")
				{
					model.ProcessCost=decimal.Parse(row["ProcessCost"].ToString());
				}
				if(row["TransCost"]!=null && row["TransCost"].ToString()!="")
				{
					model.TransCost=decimal.Parse(row["TransCost"].ToString());
				}
				if(row["SellingPrice"]!=null && row["SellingPrice"].ToString()!="")
				{
					model.SellingPrice=decimal.Parse(row["SellingPrice"].ToString());
				}
				if(row["SellingProfit"]!=null && row["SellingProfit"].ToString()!="")
				{
					model.SellingProfit=decimal.Parse(row["SellingProfit"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["CreateUser"]!=null && row["CreateUser"].ToString()!="")
				{
					//model.CreateUser=long.Parse(row["CreateUser"].ToString());
                    model.CreateUser = row["CreateUser"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["UpdateUser"]!=null && row["UpdateUser"].ToString()!="")
				{
					//model.UpdateUser=long.Parse(row["UpdateUser"].ToString());
                    model.UpdateUser = row["UpdateUser"].ToString();
				}
				if(row["UpdateDate"]!=null && row["UpdateDate"].ToString()!="")
				{
					model.UpdateDate=DateTime.Parse(row["UpdateDate"].ToString());
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ProductID,ColorID,Attribute,BarginPriceOut,ReferencePriceOut,StandardPriceIn,MinPriceOut,Profit,TagPrice,Image,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,StockProductCount,ProductPurchaseCount,SellingCost,ProcessCost,TransCost,SellingPrice,SellingProfit,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate,Status ");
			strSql.Append(" FROM ProductItem ");
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
			strSql.Append(" ID,ProductID,ColorID,Attribute,BarginPriceOut,ReferencePriceOut,StandardPriceIn,MinPriceOut,Profit,TagPrice,Image,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF,SellingAward,SellingRoyaltyRate,StockProductCount,ProductPurchaseCount,SellingCost,ProcessCost,TransCost,SellingPrice,SellingProfit,Remark,CreateUser,CreateDate,UpdateUser,UpdateDate,Status ");
			strSql.Append(" FROM ProductItem ");
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
			strSql.Append("select count(1) FROM ProductItem ");
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
			strSql.Append(")AS Row, T.*  from ProductItem T ");
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
			parameters[0].Value = "ProductItem";
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
        /// 
        /// </summary>
        /// <param name="insertList"></param>
        /// <param name="updateList"></param>
        /// <param name="delList"></param>
        /// <param name="sequenceList"></param>
        /// <param name="UserID">用户ID</param>
        /// <param name="id">ProductID</param>
        /// <returns></returns>
        public bool Edit(List<Model.ProductPriceColorShip> insertList, List<Model.ProductPriceColorShip> updateList, List<Model.v_ProductColorShip> delList, List<Model.ProductPriceColorShip> sequenceList, long UserID, long id)
        {
            ArrayList arr = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.v_ProductColorShip model = delList[i];
                sbSql.Append("delete from ProductItem where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }

            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductPriceColorShip model = updateList[i];
                sbSql.Append("update ProductItem set ProductID='" + id + "',Corlor='" + model.Corlor + "',Code='" + model.Code + "',Size='" + model.Size + "',Quality='" + model.Quality + "'");
                sbSql.Append(",Brand='" + model.Brand + "',NFK='" + model.NFK + "',Attribute='" + model.Attribute + "',BarginPriceOut='" + model.BarginPriceOut + "',ReferencePriceOut='" + model.ReferencePriceOut + "'");
                sbSql.Append(",StandardPriceIn='" + model.StandardPriceIn + "',MinPriceOut='" + model.MinPriceOut + "',Profit='" + model.Profit + "',TagPrice='" + model.TagPrice + "',MaxStock='" + model.MaxStock + "'");
                sbSql.Append(",MinStock='" + model.MinStock + "',ReferencePriceA='" + model.ReferencePriceA + "',ReferencePriceB='" + model.ReferencePriceB + "',ReferencePriceC='" + model.ReferencePriceC + "',ReferencePriceD='" + model.ReferencePriceD + "'");
                sbSql.Append(",ReferencePriceE='" + model.ReferencePriceE + "',ReferencePriceF='" + model.ReferencePriceF + "',value0='" + model.value0 + "',value1='" + model.value1 + "'");
                sbSql.Append(" where ID=" + model.ID);
                arr.Add(sbSql.ToString());
            }

            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProductPriceColorShip model = insertList[i];
                //sbSql.Append("insert into ProductColor  (ParentID,Code,Name,Enabled,Status,Remark,Value0,Value1,Value2,Value3,Value4,Value5,Value6,Value7,Value8,Value9,CreateUser,CreateDate,UpdateUser,UpdateDate) ");
                sbSql.Append("insert into ProductItem  (ProductID,ColorID,Corlor,Size,MaxStock,MinStock,Brand,ReferencePriceOut,StandardPriceIn,ReferencePriceA,ReferencePriceB,ReferencePriceC,ReferencePriceD,ReferencePriceE,ReferencePriceF) ");
                sbSql.Append("  values  ( ");
                sbSql.Append("'" + id + "',0,'" + model.Corlor + "','" + model.Size + "','" + model.MaxStock + "','" + model.MinStock + "','" + model.Brand + "','" + model.ReferencePriceOut + "','" + model.StandardPriceIn + "','" + model.ReferencePriceA + "','" + model.ReferencePriceB + "','" + model.ReferencePriceC + "','" + model.ReferencePriceD + "','" + model.ReferencePriceE + "','" + model.ReferencePriceF + "'");
                sbSql.Append(" ) ");
                arr.Add(sbSql.ToString());
            }
            DbHelperSQL.ExecuteSqlTran(arr);
            return true;
        }

		#endregion  ExtensionMethod
	}
}

