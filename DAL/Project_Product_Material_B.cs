using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:Project_Product_Material_B
    /// </summary>
    public partial class Project_Product_Material_B
    {
        public Project_Product_Material_B()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Project_Product_Material_B");
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
        public int Add(Maticsoft.Model.Project_Product_Material_B model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Project_Product_Material_B(");
            strSql.Append("ProjectID,SpaceID,ProductID,FileNumber,DrawingNumber,Amount,AColor,ASize,ABrand,Color,Size,Brand,supplierID,Sumbit,SubmitPerson,SubmitDate,Audit,AuditPerson,AuditDate,Checking,CheckPerson,CheckDate,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date)");
            strSql.Append(" values (");
            strSql.Append("@ProjectID,@SpaceID,@ProductID,@FileNumber,@DrawingNumber,@Amount,@AColor,@ASize,@ABrand,@Color,@Size,@Brand,@supplierID,@Sumbit,@SubmitPerson,@SubmitDate,@Audit,@AuditPerson,@AuditDate,@Checking,@CheckPerson,@CheckDate,@sequence,@remark,@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@n1,@n2,@n3,@show,@show_name,@status,@create_person,@create_date,@update_person,@update_date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@SpaceID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.BigInt,8),
					new SqlParameter("@FileNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@DrawingNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Amount", SqlDbType.Decimal,17),
					new SqlParameter("@AColor", SqlDbType.NVarChar,50),
					new SqlParameter("@ASize", SqlDbType.NVarChar,50),
					new SqlParameter("@ABrand", SqlDbType.NVarChar,50),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierID", SqlDbType.NVarChar,50),
					new SqlParameter("@Sumbit", SqlDbType.Int,4),
					new SqlParameter("@SubmitPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@AuditPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@Checking", SqlDbType.Int,4),
					new SqlParameter("@CheckPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
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
            parameters[0].Value = model.ProjectID;
            parameters[1].Value = model.SpaceID;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.FileNumber;
            parameters[4].Value = model.DrawingNumber;
            parameters[5].Value = model.Amount;
            parameters[6].Value = model.AColor;
            parameters[7].Value = model.ASize;
            parameters[8].Value = model.ABrand;
            parameters[9].Value = model.Color;
            parameters[10].Value = model.Size;
            parameters[11].Value = model.Brand;
            parameters[12].Value = model.supplierID;
            parameters[13].Value = model.Sumbit;
            parameters[14].Value = model.SubmitPerson;
            parameters[15].Value = model.SubmitDate;
            parameters[16].Value = model.Audit;
            parameters[17].Value = model.AuditPerson;
            parameters[18].Value = model.AuditDate;
            parameters[19].Value = model.Checking;
            parameters[20].Value = model.CheckPerson;
            parameters[21].Value = model.CheckDate;
            parameters[22].Value = model.sequence;
            parameters[23].Value = model.remark;
            parameters[24].Value = model.v1;
            parameters[25].Value = model.v2;
            parameters[26].Value = model.v3;
            parameters[27].Value = model.v4;
            parameters[28].Value = model.v5;
            parameters[29].Value = model.v6;
            parameters[30].Value = model.v7;
            parameters[31].Value = model.v8;
            parameters[32].Value = model.v9;
            parameters[33].Value = model.v10;
            parameters[34].Value = model.n1;
            parameters[35].Value = model.n2;
            parameters[36].Value = model.n3;
            parameters[37].Value = model.show;
            parameters[38].Value = model.show_name;
            parameters[39].Value = model.status;
            parameters[40].Value = model.create_person;
            parameters[41].Value = model.create_date;
            parameters[42].Value = model.update_person;
            parameters[43].Value = model.update_date;

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
        public bool Update(Maticsoft.Model.Project_Product_Material_B model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Project_Product_Material_B set ");
            strSql.Append("ProjectID=@ProjectID,");
            strSql.Append("SpaceID=@SpaceID,");
            strSql.Append("ProductID=@ProductID,");
            strSql.Append("FileNumber=@FileNumber,");
            strSql.Append("DrawingNumber=@DrawingNumber,");
            strSql.Append("Amount=@Amount,");
            strSql.Append("AColor=@AColor,");
            strSql.Append("ASize=@ASize,");
            strSql.Append("ABrand=@ABrand,");
            strSql.Append("Color=@Color,");
            strSql.Append("Size=@Size,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("supplierID=@supplierID,");
            strSql.Append("Sumbit=@Sumbit,");
            strSql.Append("SubmitPerson=@SubmitPerson,");
            strSql.Append("SubmitDate=@SubmitDate,");
            strSql.Append("Audit=@Audit,");
            strSql.Append("AuditPerson=@AuditPerson,");
            strSql.Append("AuditDate=@AuditDate,");
            strSql.Append("Checking=@Checking,");
            strSql.Append("CheckPerson=@CheckPerson,");
            strSql.Append("CheckDate=@CheckDate,");
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
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectID", SqlDbType.Int,4),
					new SqlParameter("@SpaceID", SqlDbType.Int,4),
					new SqlParameter("@ProductID", SqlDbType.BigInt,8),
					new SqlParameter("@FileNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@DrawingNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Amount", SqlDbType.Decimal,17),
					new SqlParameter("@AColor", SqlDbType.NVarChar,50),
					new SqlParameter("@ASize", SqlDbType.NVarChar,50),
					new SqlParameter("@ABrand", SqlDbType.NVarChar,50),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierID", SqlDbType.NVarChar,50),
					new SqlParameter("@Sumbit", SqlDbType.Int,4),
					new SqlParameter("@SubmitPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@AuditPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@AuditDate", SqlDbType.DateTime),
					new SqlParameter("@Checking", SqlDbType.Int,4),
					new SqlParameter("@CheckPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckDate", SqlDbType.DateTime),
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
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ProjectID;
            parameters[1].Value = model.SpaceID;
            parameters[2].Value = model.ProductID;
            parameters[3].Value = model.FileNumber;
            parameters[4].Value = model.DrawingNumber;
            parameters[5].Value = model.Amount;
            parameters[6].Value = model.AColor;
            parameters[7].Value = model.ASize;
            parameters[8].Value = model.ABrand;
            parameters[9].Value = model.Color;
            parameters[10].Value = model.Size;
            parameters[11].Value = model.Brand;
            parameters[12].Value = model.supplierID;
            parameters[13].Value = model.Sumbit;
            parameters[14].Value = model.SubmitPerson;
            parameters[15].Value = model.SubmitDate;
            parameters[16].Value = model.Audit;
            parameters[17].Value = model.AuditPerson;
            parameters[18].Value = model.AuditDate;
            parameters[19].Value = model.Checking;
            parameters[20].Value = model.CheckPerson;
            parameters[21].Value = model.CheckDate;
            parameters[22].Value = model.sequence;
            parameters[23].Value = model.remark;
            parameters[24].Value = model.v1;
            parameters[25].Value = model.v2;
            parameters[26].Value = model.v3;
            parameters[27].Value = model.v4;
            parameters[28].Value = model.v5;
            parameters[29].Value = model.v6;
            parameters[30].Value = model.v7;
            parameters[31].Value = model.v8;
            parameters[32].Value = model.v9;
            parameters[33].Value = model.v10;
            parameters[34].Value = model.n1;
            parameters[35].Value = model.n2;
            parameters[36].Value = model.n3;
            parameters[37].Value = model.show;
            parameters[38].Value = model.show_name;
            parameters[39].Value = model.status;
            parameters[40].Value = model.create_person;
            parameters[41].Value = model.create_date;
            parameters[42].Value = model.update_person;
            parameters[43].Value = model.update_date;
            parameters[44].Value = model.ID;

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
            strSql.Append("delete from Project_Product_Material_B ");
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
            strSql.Append("delete from Project_Product_Material_B ");
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
        public Maticsoft.Model.Project_Product_Material_B GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ProjectID,SpaceID,ProductID,FileNumber,DrawingNumber,Amount,AColor,ASize,ABrand,Color,Size,Brand,supplierID,Sumbit,SubmitPerson,SubmitDate,Audit,AuditPerson,AuditDate,Checking,CheckPerson,CheckDate,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date from Project_Product_Material_B ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            Maticsoft.Model.Project_Product_Material_B model = new Maticsoft.Model.Project_Product_Material_B();
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
        public Maticsoft.Model.Project_Product_Material_B DataRowToModel(DataRow row)
        {
            Maticsoft.Model.Project_Product_Material_B model = new Maticsoft.Model.Project_Product_Material_B();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
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
                if (row["FileNumber"] != null)
                {
                    model.FileNumber = row["FileNumber"].ToString();
                }
                if (row["DrawingNumber"] != null)
                {
                    model.DrawingNumber = row["DrawingNumber"].ToString();
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["AColor"] != null)
                {
                    model.AColor = row["AColor"].ToString();
                }
                if (row["ASize"] != null)
                {
                    model.ASize = row["ASize"].ToString();
                }
                if (row["ABrand"] != null)
                {
                    model.ABrand = row["ABrand"].ToString();
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
                if (row["supplierID"] != null)
                {
                    model.supplierID = row["supplierID"].ToString();
                }
                if (row["Sumbit"] != null && row["Sumbit"].ToString() != "")
                {
                    model.Sumbit = int.Parse(row["Sumbit"].ToString());
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
                if (row["AuditPerson"] != null)
                {
                    model.AuditPerson = row["AuditPerson"].ToString();
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
            strSql.Append("select ID,ProjectID,SpaceID,ProductID,FileNumber,DrawingNumber,Amount,AColor,ASize,ABrand,Color,Size,Brand,supplierID,Sumbit,SubmitPerson,SubmitDate,Audit,AuditPerson,AuditDate,Checking,CheckPerson,CheckDate,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM Project_Product_Material_B ");
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
            strSql.Append(" ID,ProjectID,SpaceID,ProductID,FileNumber,DrawingNumber,Amount,AColor,ASize,ABrand,Color,Size,Brand,supplierID,Sumbit,SubmitPerson,SubmitDate,Audit,AuditPerson,AuditDate,Checking,CheckPerson,CheckDate,sequence,remark,v1,v2,v3,v4,v5,v6,v7,v8,v9,v10,n1,n2,n3,show,show_name,status,create_person,create_date,update_person,update_date ");
            strSql.Append(" FROM Project_Product_Material_B ");
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
            strSql.Append("select count(1) FROM Project_Product_Material_B ");
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
            strSql.Append(")AS Row, T.*  from Project_Product_Material_B T ");
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
            parameters[0].Value = "Project_Product_Material_B";
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
        public string BUpdate(List<Model.v_ProjectMaterialB> updateList, string user)
        {
            try
            {
                ArrayList al = new ArrayList();
                StringBuilder sbSql = new StringBuilder();
                //修改
                for (int i = 0; i < updateList.Count; i++)
                {
                    sbSql = new StringBuilder();
                    Model.v_ProjectMaterialB model = updateList[i];
                    sbSql.Append("update Project_Product_Material_B set Color = '" + model.ColorID.ToString().Trim() + "',");
                    //sbSql.Append("remark = '" + model.remark.Trim() + "',sequence='"+model.sequence+"'");
                    sbSql.Append("Brand = '" + model.Brand.ToString().Trim() + "',");
                    sbSql.Append("SupplierID = " + model.spID.ToString().Trim() + ",");
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
