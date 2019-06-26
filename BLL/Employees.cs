using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
    /// Employees
	/// </summary>
	public partial class Employees
	{
        public readonly Maticsoft.DAL.Employees dal = new Maticsoft.DAL.Employees();
        public Employees()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UserID)
		{
			return dal.Exists(UserID);
		}

        public bool ExistsByUserName(string UserName, long UserID)
        {
            return dal.ExistsByUserName(UserName,UserID);
        }
        public bool ExistsByWorkID(string WorkID,long UserID)
        {
            return dal.ExistsByWorkID(WorkID, UserID);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public string Add(Maticsoft.Model.Employees model)
        {
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                if (ExistsByUserName(model.UserName, 0))
                {
                    return "【账号】“" + model.UserName + "”已存在。";
                }
            }
            if (ExistsByWorkID(model.WorkID, 0))
            {
                return "【工号】“" + model.WorkID + "”已存在。";
            }
            return dal.Add(model) > 0 ? "ok" : "保存失败。";
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public string Update(Maticsoft.Model.Employees model)
        {
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                if (ExistsByUserName(model.UserName, model.UserID))
                {
                    return "【账号】“" + model.UserName + "”已存在。";
                }
            }
            if (ExistsByWorkID(model.WorkID, model.UserID))
            {
                return "【工号】“" + model.WorkID + "”已存在。";
            }
            return dal.Update(model) ? "ok" : "保存失败。";
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long UserID)
		{
			
			return dal.Delete(UserID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			return dal.DeleteList(UserIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Maticsoft.Model.Employees GetModel(long UserID)
		{
			
			return dal.GetModel(UserID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public Maticsoft.Model.Employees GetModelByCache(long UserID)
		{
			
			string CacheKey = "BaseUserModel-" + UserID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (Maticsoft.Model.Employees)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Maticsoft.Model.Employees> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Maticsoft.Model.Employees> DataTableToList(DataTable dt)
		{
            List<Maticsoft.Model.Employees> modelList = new List<Maticsoft.Model.Employees>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Maticsoft.Model.Employees model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Maticsoft.Model.Employees();
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=long.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["DeptID"]!=null && dt.Rows[n]["DeptID"].ToString()!="")
					{
						model.DeptID=int.Parse(dt.Rows[n]["DeptID"].ToString());
					}
					if(dt.Rows[n]["Roles"]!=null && dt.Rows[n]["Roles"].ToString()!="")
					{
					model.Roles=dt.Rows[n]["Roles"].ToString();
					}
					if(dt.Rows[n]["UserName"]!=null && dt.Rows[n]["UserName"].ToString()!="")
					{
					model.UserName=dt.Rows[n]["UserName"].ToString();
					}
					if(dt.Rows[n]["Pwd"]!=null && dt.Rows[n]["Pwd"].ToString()!="")
					{
					model.Pwd=dt.Rows[n]["Pwd"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Tel"]!=null && dt.Rows[n]["Tel"].ToString()!="")
					{
					model.Tel=dt.Rows[n]["Tel"].ToString();
					}
					if(dt.Rows[n]["WorkID"]!=null && dt.Rows[n]["WorkID"].ToString()!="")
					{
					model.WorkID=dt.Rows[n]["WorkID"].ToString();
					}
					if(dt.Rows[n]["CreatedDate"]!=null && dt.Rows[n]["CreatedDate"].ToString()!="")
					{
						model.CreatedDate=DateTime.Parse(dt.Rows[n]["CreatedDate"].ToString());
					}
					if(dt.Rows[n]["CreatedGuy"]!=null && dt.Rows[n]["CreatedGuy"].ToString()!="")
					{
						model.CreatedGuy=int.Parse(dt.Rows[n]["CreatedGuy"].ToString());
					}
					if(dt.Rows[n]["ApprRole"]!=null && dt.Rows[n]["ApprRole"].ToString()!="")
					{
					model.ApprRole=dt.Rows[n]["ApprRole"].ToString();
					}
					if(dt.Rows[n]["IDCard"]!=null && dt.Rows[n]["IDCard"].ToString()!="")
					{
					model.IDCard=dt.Rows[n]["IDCard"].ToString();
					}
					if(dt.Rows[n]["Nation"]!=null && dt.Rows[n]["Nation"].ToString()!="")
					{
					model.Nation=dt.Rows[n]["Nation"].ToString();
					}
					if(dt.Rows[n]["Dataofbirth"]!=null && dt.Rows[n]["Dataofbirth"].ToString()!="")
					{
						model.Dataofbirth=DateTime.Parse(dt.Rows[n]["Dataofbirth"].ToString());
					}
					if(dt.Rows[n]["Sex"]!=null && dt.Rows[n]["Sex"].ToString()!="")
					{
						model.Sex=int.Parse(dt.Rows[n]["Sex"].ToString());
					}
					if(dt.Rows[n]["Nativeplace"]!=null && dt.Rows[n]["Nativeplace"].ToString()!="")
					{
					model.Nativeplace=dt.Rows[n]["Nativeplace"].ToString();
					}
					if(dt.Rows[n]["RegdResd"]!=null && dt.Rows[n]["RegdResd"].ToString()!="")
					{
					model.RegdResd=dt.Rows[n]["RegdResd"].ToString();
					}
					if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
					{
					model.Address=dt.Rows[n]["Address"].ToString();
					}
					if(dt.Rows[n]["Maritalstatus"]!=null && dt.Rows[n]["Maritalstatus"].ToString()!="")
					{
						model.Maritalstatus=int.Parse(dt.Rows[n]["Maritalstatus"].ToString());
					}
					if(dt.Rows[n]["Politicsstatus"]!=null && dt.Rows[n]["Politicsstatus"].ToString()!="")
					{
						model.Politicsstatus=int.Parse(dt.Rows[n]["Politicsstatus"].ToString());
					}
					if(dt.Rows[n]["Bloodtype"]!=null && dt.Rows[n]["Bloodtype"].ToString()!="")
					{
						model.Bloodtype=int.Parse(dt.Rows[n]["Bloodtype"].ToString());
					}
					if(dt.Rows[n]["Education"]!=null && dt.Rows[n]["Education"].ToString()!="")
					{
						model.Education=int.Parse(dt.Rows[n]["Education"].ToString());
					}
					if(dt.Rows[n]["GraduationDate"]!=null && dt.Rows[n]["GraduationDate"].ToString()!="")
					{
						model.GraduationDate=DateTime.Parse(dt.Rows[n]["GraduationDate"].ToString());
					}
					if(dt.Rows[n]["EntryDate"]!=null && dt.Rows[n]["EntryDate"].ToString()!="")
					{
						model.EntryDate=DateTime.Parse(dt.Rows[n]["EntryDate"].ToString());
					}
					if(dt.Rows[n]["Degree"]!=null && dt.Rows[n]["Degree"].ToString()!="")
					{
						model.Degree=int.Parse(dt.Rows[n]["Degree"].ToString());
					}
					if(dt.Rows[n]["Major"]!=null && dt.Rows[n]["Major"].ToString()!="")
					{
					model.Major=dt.Rows[n]["Major"].ToString();
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
					}
					if(dt.Rows[n]["EmContact"]!=null && dt.Rows[n]["EmContact"].ToString()!="")
					{
					model.EmContact=dt.Rows[n]["EmContact"].ToString();
					}
					if(dt.Rows[n]["EmContactTel"]!=null && dt.Rows[n]["EmContactTel"].ToString()!="")
					{
					model.EmContactTel=dt.Rows[n]["EmContactTel"].ToString();
					}
					if(dt.Rows[n]["Positivedates"]!=null && dt.Rows[n]["Positivedates"].ToString()!="")
					{
						model.Positivedates=DateTime.Parse(dt.Rows[n]["Positivedates"].ToString());
					}
					if(dt.Rows[n]["StateEmployees"]!=null && dt.Rows[n]["StateEmployees"].ToString()!="")
					{
						model.StateEmployees=int.Parse(dt.Rows[n]["StateEmployees"].ToString());
					}
					if(dt.Rows[n]["AppRoleID"]!=null && dt.Rows[n]["AppRoleID"].ToString()!="")
					{
						model.AppRoleID=int.Parse(dt.Rows[n]["AppRoleID"].ToString());
					}
					if(dt.Rows[n]["Permissions"]!=null && dt.Rows[n]["Permissions"].ToString()!="")
					{
						model.Permissions=int.Parse(dt.Rows[n]["Permissions"].ToString());
					}
					if(dt.Rows[n]["Photo"]!=null && dt.Rows[n]["Photo"].ToString()!="")
					{
					model.Photo=dt.Rows[n]["Photo"].ToString();
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["Value0"]!=null && dt.Rows[n]["Value0"].ToString()!="")
					{
					model.Value0=dt.Rows[n]["Value0"].ToString();
					}
					if(dt.Rows[n]["Value1"]!=null && dt.Rows[n]["Value1"].ToString()!="")
					{
					model.Value1=dt.Rows[n]["Value1"].ToString();
					}
					if(dt.Rows[n]["Value2"]!=null && dt.Rows[n]["Value2"].ToString()!="")
					{
					model.Value2=dt.Rows[n]["Value2"].ToString();
					}
					if(dt.Rows[n]["Value3"]!=null && dt.Rows[n]["Value3"].ToString()!="")
					{
					model.Value3=dt.Rows[n]["Value3"].ToString();
					}
					if(dt.Rows[n]["Value4"]!=null && dt.Rows[n]["Value4"].ToString()!="")
					{
					model.Value4=dt.Rows[n]["Value4"].ToString();
					}
					if(dt.Rows[n]["Value5"]!=null && dt.Rows[n]["Value5"].ToString()!="")
					{
					model.Value5=dt.Rows[n]["Value5"].ToString();
					}
					if(dt.Rows[n]["Value6"]!=null && dt.Rows[n]["Value6"].ToString()!="")
					{
					model.Value6=dt.Rows[n]["Value6"].ToString();
					}
					if(dt.Rows[n]["Value7"]!=null && dt.Rows[n]["Value7"].ToString()!="")
					{
					model.Value7=dt.Rows[n]["Value7"].ToString();
					}
					if(dt.Rows[n]["Value8"]!=null && dt.Rows[n]["Value8"].ToString()!="")
					{
					model.Value8=dt.Rows[n]["Value8"].ToString();
					}
					if(dt.Rows[n]["Value9"]!=null && dt.Rows[n]["Value9"].ToString()!="")
					{
					model.Value9=dt.Rows[n]["Value9"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

