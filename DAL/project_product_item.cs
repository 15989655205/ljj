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
	/// 数据访问类:project_product_item
	/// </summary>
	public partial class project_product_item
	{
		public project_product_item()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int sid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from project_product_item");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}



        /// <summary>
        /// Add
        /// </summary>
        /// <param name="model"></param>
        /// <param name="detail">细目</param>
        /// <param name="pssid">project_stage_ID</param>
        /// <returns></returns>
        public int Add(Maticsoft.Model.project_product_item model, int detail,int pssid)
		{

              
               StringBuilder strSql = new StringBuilder();
               strSql.Append("insert into project_product_item(");
               strSql.Append("parentID,ProductID,number,name,projectName,pic,size,paintColor,useSpace,spaceCount,install,usePart,unit,amount,paintPaletteNumber,EndProduct,sequence,state,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,create_person,create_date,update_person,update_date)");
               strSql.Append(" values (");
               strSql.Append("@parentID,@ProductID,@number,@name,@projectName,@pic,@size,@paintColor,@useSpace,@spaceCount,@install,@usePart,@unit,@amount,@paintPaletteNumber,@EndProduct,@sequence,@state,@remark,@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@create_person,@create_date,@update_person,@update_date)");
               strSql.Append(";select @@IDENTITY");
               SqlParameter[] parameters = {
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@number", SqlDbType.NVarChar,50),
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@projectName", SqlDbType.NVarChar,50),
					new SqlParameter("@pic", SqlDbType.NVarChar,150),
					new SqlParameter("@size", SqlDbType.NVarChar,150),
					new SqlParameter("@paintColor", SqlDbType.NVarChar,150),
					new SqlParameter("@useSpace", SqlDbType.NVarChar,150),
					new SqlParameter("@spaceCount", SqlDbType.Int,4),
					new SqlParameter("@install", SqlDbType.NVarChar,150),
					new SqlParameter("@usePart", SqlDbType.NVarChar,150),
					new SqlParameter("@unit", SqlDbType.NVarChar,150),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@paintPaletteNumber", SqlDbType.NVarChar,150),
					new SqlParameter("@EndProduct", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@v1", SqlDbType.NVarChar,250),
					new SqlParameter("@v2", SqlDbType.NVarChar,250),
					new SqlParameter("@v3", SqlDbType.NVarChar,250),
					new SqlParameter("@v4", SqlDbType.NVarChar,250),
					new SqlParameter("@v5", SqlDbType.NVarChar,250),
					new SqlParameter("@v6", SqlDbType.NVarChar,250),
					new SqlParameter("@v7", SqlDbType.NVarChar,250),
					new SqlParameter("@v8", SqlDbType.NVarChar,250),
					new SqlParameter("@v9", SqlDbType.NVarChar,250),
					new SqlParameter("@v10", SqlDbType.NVarChar,250),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime)};
               parameters[0].Value = model.parentID;
               parameters[1].Value = model.ProductID;
               parameters[2].Value = model.number;
               parameters[3].Value = model.name;
               parameters[4].Value = model.projectName;
               parameters[5].Value = model.pic;
               parameters[6].Value = model.size;
               parameters[7].Value = model.paintColor;
               parameters[8].Value = model.useSpace;
               parameters[9].Value = model.spaceCount;
               parameters[10].Value = model.install;
               parameters[11].Value = model.usePart;
               parameters[12].Value = model.unit;
               parameters[13].Value = model.amount;
               parameters[14].Value = model.paintPaletteNumber;
               parameters[15].Value = model.EndProduct;
               parameters[16].Value = model.sequence;
               parameters[17].Value = model.state;
               parameters[18].Value = model.remark;
               parameters[19].Value = model.v1;
               parameters[20].Value = model.v2;
               parameters[21].Value = model.v3;
               parameters[22].Value = model.v4;
               parameters[23].Value = model.v5;
               parameters[24].Value = model.v6;
               parameters[25].Value = model.v7;
               parameters[26].Value = model.v8;
               parameters[27].Value = model.v9;
               parameters[28].Value = model.v10;
               parameters[29].Value = model.create_person;
               parameters[30].Value = DateTime.Now;
               parameters[31].Value = model.update_person;
               parameters[32].Value = model.update_date;
               object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
               string addPP = "insert into project_product(ps_sid,ppiID,create_person,create_date)  values (" + pssid + "," + obj + ",'" + model.create_person + "',getdate());select @@IDENTITY ";
               object ppId = DbHelperSQL.GetSingle(addPP);
               ArrayList arr = new ArrayList();
               string update = "update project_product_item set ProductID=" + detail + ",parentID=" + ppId + "   where sid=" + obj + "";
               arr.Add(update);
               string addPsi = "insert into project_specific_item(name,s_sid,isChild,sequence,remark) select category," + pssid + ",0,0,'' from project_processing_category_model where sid=" + model.EndProduct + "";
               arr.Add(addPsi);
               string addPsi2 = "declare @id int"
   + "		set @id=IDENT_CURRENT('project_specific_item');"
   + "		insert into project_specific_item(name,parent_sid,s_sid,isChild,sequence,PP_sid) select work_breakdown,@id," + pssid + ",1,sequence," + ppId + " from project_pc_work_breakdown_model where ppcm_sid=" + model.EndProduct + "";

               arr.Add(addPsi2);

               DbHelperSQL.ExecuteSqlTran(arr);



               return Convert.ToInt32(obj);
       
		}

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="parentID"> ppi.parentID</param>
        /// <param name="detail">细目</param>
        /// <param name="pssid">project_stage 的ID</param>
        /// <returns></returns>
        public bool Update(Maticsoft.Model.project_product_item model, int detail, int pssid, int parentID, int parent_sid, int ppId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update project_product_item set ");
			strSql.Append("parentID=@parentID,");
			strSql.Append("ProductID=@ProductID,");
			strSql.Append("number=@number,");
			strSql.Append("name=@name,");
			strSql.Append("projectName=@projectName,");
			strSql.Append("pic=@pic,");
			strSql.Append("size=@size,");
			strSql.Append("paintColor=@paintColor,");
			strSql.Append("useSpace=@useSpace,");
			strSql.Append("spaceCount=@spaceCount,");
			strSql.Append("install=@install,");
			strSql.Append("usePart=@usePart,");
			strSql.Append("unit=@unit,");
			strSql.Append("amount=@amount,");
			strSql.Append("paintPaletteNumber=@paintPaletteNumber,");
			strSql.Append("EndProduct=@EndProduct,");
			strSql.Append("sequence=@sequence,");
			strSql.Append("state=@state,");
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
			strSql.Append("create_person=@create_person,");
			strSql.Append("create_date=@create_date,");
			strSql.Append("update_person=@update_person,");
			strSql.Append("update_date=@update_date");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@parentID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.Int,4),
					new SqlParameter("@number", SqlDbType.NVarChar,50),
					new SqlParameter("@name", SqlDbType.NVarChar,100),
					new SqlParameter("@projectName", SqlDbType.NVarChar,50),
					new SqlParameter("@pic", SqlDbType.NVarChar,150),
					new SqlParameter("@size", SqlDbType.NVarChar,150),
					new SqlParameter("@paintColor", SqlDbType.NVarChar,150),
					new SqlParameter("@useSpace", SqlDbType.NVarChar,150),
					new SqlParameter("@spaceCount", SqlDbType.Int,4),
					new SqlParameter("@install", SqlDbType.NVarChar,150),
					new SqlParameter("@usePart", SqlDbType.NVarChar,150),
					new SqlParameter("@unit", SqlDbType.NVarChar,150),
					new SqlParameter("@amount", SqlDbType.Int,4),
					new SqlParameter("@paintPaletteNumber", SqlDbType.NVarChar,150),
					new SqlParameter("@EndProduct", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.Text),
					new SqlParameter("@v1", SqlDbType.NVarChar,250),
					new SqlParameter("@v2", SqlDbType.NVarChar,250),
					new SqlParameter("@v3", SqlDbType.NVarChar,250),
					new SqlParameter("@v4", SqlDbType.NVarChar,250),
					new SqlParameter("@v5", SqlDbType.NVarChar,250),
					new SqlParameter("@v6", SqlDbType.NVarChar,250),
					new SqlParameter("@v7", SqlDbType.NVarChar,250),
					new SqlParameter("@v8", SqlDbType.NVarChar,250),
					new SqlParameter("@v9", SqlDbType.NVarChar,250),
					new SqlParameter("@v10", SqlDbType.NVarChar,250),
					new SqlParameter("@create_person", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@update_person", SqlDbType.NVarChar,50),
					new SqlParameter("@update_date", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.Int,4)};
			parameters[0].Value = model.parentID;
			parameters[1].Value =detail;
			parameters[2].Value = model.number;
			parameters[3].Value = model.name;
			parameters[4].Value = model.projectName;
			parameters[5].Value = model.pic;
			parameters[6].Value = model.size;
			parameters[7].Value = model.paintColor;
			parameters[8].Value = model.useSpace;
			parameters[9].Value = model.spaceCount;
			parameters[10].Value = model.install;
			parameters[11].Value = model.usePart;
			parameters[12].Value = model.unit;
			parameters[13].Value = model.amount;
			parameters[14].Value = model.paintPaletteNumber;
			parameters[15].Value = model.EndProduct;
			parameters[16].Value = model.sequence;
			parameters[17].Value = model.state;
			parameters[18].Value = model.remark;
			parameters[19].Value = model.v1;
			parameters[20].Value = model.v2;
			parameters[21].Value = model.v3;
			parameters[22].Value = model.v4;
			parameters[23].Value = model.v5;
			parameters[24].Value = model.v6;
			parameters[25].Value = model.v7;
			parameters[26].Value = model.v8;
			parameters[27].Value = model.v9;
			parameters[28].Value = model.v10;
			parameters[29].Value = model.create_person;
			parameters[30].Value = model.create_date;
			parameters[31].Value = model.update_person;
			parameters[32].Value = model.update_date;
			parameters[33].Value = model.sid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);

            ArrayList arr = new ArrayList();
            arr.Add("delete from project_specific_item  where parent_sid ="+parent_sid+"");
            arr.Add("delete from project_specific_item  where sid =" + parent_sid + "");
            string addPsi = "insert into project_specific_item(name,s_sid,isChild,sequence,remark) select category," + pssid + ",0,0,'' from project_processing_category_model where sid=" + model.EndProduct + "";
            arr.Add(addPsi);
            string addPsi2 = "declare @id int"
+ "		set @id=IDENT_CURRENT('project_specific_item');"
+ "		insert into project_specific_item(name,parent_sid,s_sid,isChild,sequence,PP_sid) select work_breakdown,@id," + pssid + ",1,sequence," + ppId + " from project_pc_work_breakdown_model where ppcm_sid=" + model.EndProduct + "";

            arr.Add(addPsi2);

            DbHelperSQL.ExecuteSqlTran(arr);


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
		public bool Delete(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from project_product_item ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

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
		public bool DeleteList(string sidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from project_product_item ");
			strSql.Append(" where sid in ("+sidlist + ")  ");
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
		public Maticsoft.Model.project_product_item GetModel(int sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 sid,parentID,ProductID,number,name,projectName,pic,size,paintColor,useSpace,spaceCount,install,usePart,unit,amount,paintPaletteNumber,EndProduct,sequence,state,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,create_person,create_date,update_person,update_date from project_product_item ");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
			parameters[0].Value = sid;

			Maticsoft.Model.project_product_item model=new Maticsoft.Model.project_product_item();
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
		public Maticsoft.Model.project_product_item DataRowToModel(DataRow row)
		{
			Maticsoft.Model.project_product_item model=new Maticsoft.Model.project_product_item();
			if (row != null)
			{
				if(row["sid"]!=null && row["sid"].ToString()!="")
				{
					model.sid=int.Parse(row["sid"].ToString());
				}
				if(row["parentID"]!=null && row["parentID"].ToString()!="")
				{
					model.parentID=int.Parse(row["parentID"].ToString());
				}
				if(row["ProductID"]!=null && row["ProductID"].ToString()!="")
				{
					model.ProductID=int.Parse(row["ProductID"].ToString());
				}
				if(row["number"]!=null)
				{
					model.number=row["number"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["projectName"]!=null)
				{
					model.projectName=row["projectName"].ToString();
				}
				if(row["pic"]!=null)
				{
					model.pic=row["pic"].ToString();
				}
				if(row["size"]!=null)
				{
					model.size=row["size"].ToString();
				}
				if(row["paintColor"]!=null)
				{
					model.paintColor=row["paintColor"].ToString();
				}
				if(row["useSpace"]!=null)
				{
					model.useSpace=row["useSpace"].ToString();
				}
				if(row["spaceCount"]!=null && row["spaceCount"].ToString()!="")
				{
					model.spaceCount=int.Parse(row["spaceCount"].ToString());
				}
				if(row["install"]!=null)
				{
					model.install=row["install"].ToString();
				}
				if(row["usePart"]!=null)
				{
					model.usePart=row["usePart"].ToString();
				}
				if(row["unit"]!=null)
				{
					model.unit=row["unit"].ToString();
				}
				if(row["amount"]!=null && row["amount"].ToString()!="")
				{
					model.amount=int.Parse(row["amount"].ToString());
				}
				if(row["paintPaletteNumber"]!=null)
				{
					model.paintPaletteNumber=row["paintPaletteNumber"].ToString();
				}
				if(row["EndProduct"]!=null)
				{
					model.EndProduct=row["EndProduct"].ToString();
				}
				if(row["sequence"]!=null && row["sequence"].ToString()!="")
				{
					model.sequence=int.Parse(row["sequence"].ToString());
				}
				if(row["state"]!=null && row["state"].ToString()!="")
				{
					model.state=int.Parse(row["state"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["v1"]!=null)
				{
					model.v1=row["v1"].ToString();
				}
				if(row["v2"]!=null)
				{
					model.v2=row["v2"].ToString();
				}
				if(row["v3"]!=null)
				{
					model.v3=row["v3"].ToString();
				}
				if(row["v4"]!=null)
				{
					model.v4=row["v4"].ToString();
				}
				if(row["v5"]!=null)
				{
					model.v5=row["v5"].ToString();
				}
				if(row["v6"]!=null)
				{
					model.v6=row["v6"].ToString();
				}
				if(row["v7"]!=null)
				{
					model.v7=row["v7"].ToString();
				}
				if(row["v8"]!=null)
				{
					model.v8=row["v8"].ToString();
				}
				if(row["v9"]!=null)
				{
					model.v9=row["v9"].ToString();
				}
				if(row["v10"]!=null)
				{
					model.v10=row["v10"].ToString();
				}
				if(row["create_person"]!=null)
				{
					model.create_person=row["create_person"].ToString();
				}
				if(row["create_date"]!=null && row["create_date"].ToString()!="")
				{
					model.create_date=DateTime.Parse(row["create_date"].ToString());
				}
				if(row["update_person"]!=null)
				{
					model.update_person=row["update_person"].ToString();
				}
				if(row["update_date"]!=null && row["update_date"].ToString()!="")
				{
					model.update_date=DateTime.Parse(row["update_date"].ToString());
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
			strSql.Append("select sid,parentID,ProductID,number,name,projectName,pic,size,paintColor,useSpace,spaceCount,install,usePart,unit,amount,paintPaletteNumber,EndProduct,sequence,state,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM project_product_item ");
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
			strSql.Append(" sid,parentID,ProductID,number,name,projectName,pic,size,paintColor,useSpace,spaceCount,install,usePart,unit,amount,paintPaletteNumber,EndProduct,sequence,state,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,create_person,create_date,update_person,update_date ");
			strSql.Append(" FROM project_product_item ");
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
			strSql.Append("select count(1) FROM project_product_item ");
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
				strSql.Append("order by T.sid desc");
			}
			strSql.Append(")AS Row, T.*  from project_product_item T ");
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
			parameters[0].Value = "project_product_item";
			parameters[1].Value = "sid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool Edit(List<Model.ProjectProductStage> insertList, List<Model.ProjectProductStage> updateList, List<Model.ProjectProductStage> delList, string uid, string pssid)
        {
            ArrayList al = new ArrayList();
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("IF NOT EXISTS(SELECT * FROM project_product WHERE ps_sid='"+pssid+"')" );
            sbSql.Append("begin ");
            sbSql.Append("insert into project_product(ps_sid) values('" + pssid + "') ");
            sbSql.Append("end ");
            al.Add(sbSql.ToString());
            //删除
            for (int i = 0; i < delList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProjectProductStage model = delList[i];
                sbSql.Append("delete from project_product_item where sid=" + model.sid);
                al.Add(sbSql.ToString());
            }
            //修改
            for (int i = 0; i < updateList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProjectProductStage model = updateList[i];
                sbSql.Append("update project_product_item set ProductID = '" + model.ProductID.ToString().Trim() + "',");
                sbSql.Append("number = '" + model.number.Trim() + "',");
                sbSql.Append("useSpace = '" + model.useSpace.Trim() + "',");
                sbSql.Append("paintColor = '" + model.PaintColor.Trim() + "',");
                sbSql.Append("spaceCount = '" + model.spaceCount.ToString().Trim() + "',");
                sbSql.Append("install = '" + model.install.Trim() + "',");
                sbSql.Append("usePart = '" + model.usePart.Trim() + "',");
                sbSql.Append("unit = '" + model.unit.Trim() + "',");
                sbSql.Append("amount = '" + model.amount.ToString().Trim() + "',");
                sbSql.Append("EndProduct = '" + model.EndProduct.Trim() + "',");
                sbSql.Append("remark = '" + model.remark.Trim() + "',");
                sbSql.Append("update_person = '" + uid + "',");
                sbSql.Append("update_date =getdate()");
                sbSql.Append(" where sid = '" + model.sid.ToString().Trim() + "'");
                al.Add(sbSql.ToString());
            }
            //添加
            for (int i = 0; i < insertList.Count; i++)
            {
                sbSql = new StringBuilder();
                Model.ProjectProductStage model = insertList[i];
                sbSql.Append("declare @id bigint select @id=sid from project_product where ps_sid='" + pssid + "';");
                sbSql.Append("insert into project_product_item(parentID,ProductID,number,paintColor,useSpace,spaceCount,install,usePart,unit,amount,EndProduct,remark,create_person,create_date");
                sbSql.Append(")values(");
                sbSql.Append("@id,'" + model.ProductID.ToString().Trim() + "','" + model.number.Trim() + "','"+model.PaintColor.Trim()+"','" + model.useSpace.Trim() + "','" + model.spaceCount.ToString().Trim() + "','" + model.install.Trim() + "','" + model.usePart.Trim() + "','" + model.unit.Trim() + "','" + model.amount.ToString().Trim() + "','" + model.EndProduct.Trim() + "','" + model.remark.Trim() + "','" + uid + "',getdate()");
                sbSql.Append(")");
                al.Add(sbSql.ToString());
            }

            DbHelperSQL.ExecuteSqlTran(al);

            return true;
        }

        public string  UpdateImage(Model.project_product_item model)
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
            paras[0].Value = model.sid;
            paras[1].Value = model.pic;
            paras[2].Value = "Update2";
            paras[3].Value = model.update_person;
            paras[4].Value = DateTime.Now ;
            DataSet ds = new DataSet();
            string sql = "update project_product_item set pic="+model.pic+",  UpdateUser="+model.update_person+", UpdateDate=getdate() WHERE sid="+model.sid+"";
            try
            {
                int i = DbHelperSQL.ExecuteSql(sql, paras);
                string getImg = "select Image from project_product_item where sid=" + model.sid + "";
                ds = DbHelperSQL.Query(getImg);
            }
            catch
            {
                
            }
            return ds.Tables[0].Rows[0]["pic"].ToString();
        }

		#endregion  ExtensionMethod
	}
}

