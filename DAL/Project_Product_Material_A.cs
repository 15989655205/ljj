using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;
using System.Collections;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:Project_Product_Material_A
    /// </summary>
    public partial class Project_Product_Material_A
    {
        public Project_Product_Material_A()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Project_Product_Material_A");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.Project_Product_Material_A model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Project_Product_Material_A(");
            strSql.Append("projectSpaceID,locationID,DrawingNumber,ProductID,Color,Size,Brand,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date)");
            strSql.Append(" values (");
            strSql.Append("@projectSpaceID,@locationID,@DrawingNumber,@ProductID,@Color,@Size,@Brand,@sequence,@remark,@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@n1,@n2,@n3,@show,@show_name,@status,@create_person,@create_date,@update_person,@update_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@projectSpaceID", SqlDbType.Int,4),
					new SqlParameter("@locationID", SqlDbType.Int,4),
					new SqlParameter("@DrawingNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductID", SqlDbType.NVarChar,50),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4),
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
            parameters[0].Value = model.projectSpaceID;
            parameters[1].Value = model.locationID;
            parameters[2].Value = model.DrawingNumber;
            parameters[3].Value = model.ProductID;
            parameters[4].Value = model.Color;
            parameters[5].Value = model.Size;
            parameters[6].Value = model.Brand;
            parameters[7].Value = model.sequence;
            parameters[8].Value = model.remark;
            parameters[9].Value = model.v1;
            parameters[10].Value = model.v2;
            parameters[11].Value = model.v3;
            parameters[12].Value = model.v4;
            parameters[13].Value = model.v5;
            parameters[14].Value = model.v6;
            parameters[15].Value = model.v7;
            parameters[16].Value = model.v8;
            parameters[17].Value = model.v9;
            parameters[18].Value = model.v10;
            parameters[19].Value = model.n1;
            parameters[20].Value = model.n2;
            parameters[21].Value = model.n3;
            parameters[22].Value = model.show;
            parameters[23].Value = model.show_name;
            parameters[24].Value = model.status;
            parameters[25].Value = model.create_person;
            parameters[26].Value = model.create_date;
            parameters[27].Value = model.update_person;
            parameters[28].Value = model.update_date;

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
        public bool Update(Maticsoft.Model.Project_Product_Material_A model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Project_Product_Material_A set ");
            strSql.Append("projectSpaceID=@projectSpaceID,");
            strSql.Append("locationID=@locationID,");
            strSql.Append("DrawingNumber=@DrawingNumber,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("Color=@Color,");
            strSql.Append("Size=@Size,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("sequence=@sequence,");
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
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@projectSpaceID", SqlDbType.Int,4),
					new SqlParameter("@locationID", SqlDbType.Int,4),
					new SqlParameter("@DrawingNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductID", SqlDbType.NVarChar,50),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@sequence", SqlDbType.Int,4),
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
					new SqlParameter("@sid", SqlDbType.Int,4)};
            parameters[0].Value = model.projectSpaceID;
            parameters[1].Value = model.locationID;
            parameters[2].Value = model.DrawingNumber;
            parameters[3].Value = model.ProductID;
            parameters[4].Value = model.Color;
            parameters[5].Value = model.Size;
            parameters[6].Value = model.Brand;
            parameters[7].Value = model.sequence;
            parameters[8].Value = model.remark;
            parameters[9].Value = model.v1;
            parameters[10].Value = model.v2;
            parameters[11].Value = model.v3;
            parameters[12].Value = model.v4;
            parameters[13].Value = model.v5;
            parameters[14].Value = model.v6;
            parameters[15].Value = model.v7;
            parameters[16].Value = model.v8;
            parameters[17].Value = model.v9;
            parameters[18].Value = model.v10;
            parameters[19].Value = model.n1;
            parameters[20].Value = model.n2;
            parameters[21].Value = model.n3;
            parameters[22].Value = model.show;
            parameters[23].Value = model.show_name;
            parameters[24].Value = model.status;
            parameters[25].Value = model.create_person;
            parameters[26].Value = model.create_date;
            parameters[27].Value = model.update_person;
            parameters[28].Value = model.update_date;
            parameters[29].Value = model.sid;

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
        public bool Delete(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Project_Product_Material_A ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

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
        public bool DeleteList(string sidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Project_Product_Material_A ");
            strSql.Append(" where sid in (" + sidlist + ")  ");
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
        public Maticsoft.Model.Project_Product_Material_A GetModel(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sid,projectSpaceID,locationID,DrawingNumber,ProductID,Color,Size,Brand,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date from Project_Product_Material_A ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

            Maticsoft.Model.Project_Product_Material_A model = new Maticsoft.Model.Project_Product_Material_A();
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
        public Maticsoft.Model.Project_Product_Material_A DataRowToModel(DataRow row)
        {
            Maticsoft.Model.Project_Product_Material_A model = new Maticsoft.Model.Project_Product_Material_A();
            if (row != null)
            {
                if (row["sid"] != null && row["sid"].ToString() != "")
                {
                    model.sid = int.Parse(row["sid"].ToString());
                }
                if (row["projectSpaceID"] != null && row["projectSpaceID"].ToString() != "")
                {
                    model.projectSpaceID = int.Parse(row["projectSpaceID"].ToString());
                }
                if (row["locationID"] != null && row["locationID"].ToString() != "")
                {
                    model.locationID = int.Parse(row["locationID"].ToString());
                }
                if (row["DrawingNumber"] != null)
                {
                    model.DrawingNumber = row["DrawingNumber"].ToString();
                }
                if (row["ProductID"] != null)
                {
                    model.ProductID = row["ProductID"].ToString();
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
                if (row["sequence"] != null && row["sequence"].ToString() != "")
                {
                    model.sequence = int.Parse(row["sequence"].ToString());
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
            strSql.Append("select sid,projectSpaceID,locationID,DrawingNumber,ProductID,Color,Size,Brand,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM Project_Product_Material_A ");
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
            strSql.Append(" sid,projectSpaceID,locationID,DrawingNumber,ProductID,Color,Size,Brand,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM Project_Product_Material_A ");
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
            strSql.Append("select count(1) FROM Project_Product_Material_A ");
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
                strSql.Append("order by T.sid desc");
            }
            strSql.Append(")AS Row, T.*  from Project_Product_Material_A T ");
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
            parameters[0].Value = "Project_Product_Material_A";
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
        public string Save(List<Model.v_ProjectMaterialA> insertList, List<Model.v_ProjectMaterialA> updateList, List<Model.v_ProjectMaterialA> delList,string user)
        {
            try
            {
                ArrayList al = new ArrayList();
                StringBuilder sbSql = new StringBuilder();
                //删除
                for (int i = 0; i < delList.Count; i++)
                {
                    sbSql = new StringBuilder();
                    Model.v_ProjectMaterialA model = delList[i];
                    sbSql.Append("delete from Project_Product_Material_A where sid=" + model.sid);
                    al.Add(sbSql.ToString());
                }
                //修改
                for (int i = 0; i < updateList.Count; i++)
                {
                    sbSql = new StringBuilder();
                    Model.v_ProjectMaterialA model = updateList[i];
                    sbSql.Append("update Project_Product_Material_A set locationID = '" + model.locationID.ToString().Trim() + "',");
                    //sbSql.Append("remark = '" + model.remark.Trim() + "',sequence='"+model.sequence+"'");
                    sbSql.Append("ProductID = '" + model.productID.ToString().Trim() + "',");
                    sbSql.Append("Amount = " + model.Amount.ToString().Trim() + ",");
                    sbSql.Append("Color = '" + model.colorName.ToString().Trim() + "',");
                    sbSql.Append("Size = '" + model.Size.ToString().Trim() + "',");
                    sbSql.Append("Brand = '" + model.Brand.ToString().Trim() + "',");
                    sbSql.Append("DrawingNumber = '" + model.DrawingNumber.ToString().Trim() + "',");
                    sbSql.Append("update_person = '" + user + "',");
                    sbSql.Append("update_date = getdate(),");
                    sbSql.Append("remark = '" + model.remark.Trim() + "'");
                    sbSql.Append(" where sid = " + model.sid.ToString().Trim() + "");
                    al.Add(sbSql.ToString());
                }
                //添加
                for (int i = 0; i < insertList.Count; i++)
                {

                    sbSql = new StringBuilder();
                    Model.v_ProjectMaterialA model = insertList[i];
                    sbSql.Append("insert into Project_Product_Material_A(projectSpaceID,locationID, ProductID,Amount,Color,Size,Brand,DrawingNumber,remark,create_person");
                    sbSql.Append(")values(");
                    sbSql.Append("'" + model.projectSpaceID + "','" + model.locationID.ToString().Trim() + "','" + model.productID.ToString().Trim() + "','" + model.Amount + "','" + model.colorName + "','" + model.Size + "','" + model.Brand + "','" + model.DrawingNumber + "','" + model.remark + "','" + user + "'");
                    sbSql.Append(")");
                    al.Add(sbSql.ToString());
                }

                DbHelperSQL.ExecuteSqlTran(al);

                return "success";
            }
            catch(Exception exc)
            {
                return exc.Message;
            }
        }


        public string BUpdate(List<Model.v_ProjectMaterialAToB> updateList, string user)
        {
            try
            {
                ArrayList al = new ArrayList();
                StringBuilder sbSql = new StringBuilder();
                //修改
                for (int i = 0; i < updateList.Count; i++)
                {
                    sbSql = new StringBuilder();
                    Model.v_ProjectMaterialAToB model = updateList[i];
                    sbSql.Append("update Project_Product_Material_A set ColorB = '" + model.colorB.ToString().Trim() + "',");
                    //sbSql.Append("remark = '" + model.remark.Trim() + "',sequence='"+model.sequence+"'");
                    sbSql.Append("BrandB = '" + model.brandB.ToString().Trim() + "',");
                    sbSql.Append("SupplierID = " + model.supplierID.ToString().Trim() + ",");
                    sbSql.Append("UpdateUserB = '" + user + "',");
                    sbSql.Append("UpdateDateB =getdate() ,");
                    sbSql.Append("remarkB = '" + model.remarkB.Trim() + "'");
                    sbSql.Append(" where ProductID=" + model.productID.ToString().Trim() + " and projectSpaceID='" + model.projectSpaceID.ToString().Trim() + "' and Color='" + model.Color.ToString().Trim() + "' and Size='" + model.Size.ToString().Trim() + "' and Brand='" + model.Brand.ToString().Trim() + "'");
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
