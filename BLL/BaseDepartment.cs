using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// BaseDepartment
	/// </summary>
	public partial class BaseDepartment
	{
		private readonly Maticsoft.DAL.BaseDepartment dal=new Maticsoft.DAL.BaseDepartment();
		public BaseDepartment()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DeptID)
		{
			return dal.Exists(DeptID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.BaseDepartment model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.BaseDepartment model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DeptID)
		{
			
			return dal.Delete(DeptID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DeptIDlist )
		{
			return dal.DeleteList(DeptIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.BaseDepartment GetModel(int DeptID)
		{
			
			return dal.GetModel(DeptID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.BaseDepartment GetModelByCache(int DeptID)
		{
			
			string CacheKey = "BaseDepartmentModel-" + DeptID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DeptID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.BaseDepartment)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string value, string strWhere)
        {
            return dal.GetList(value, strWhere);
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
		public List<Maticsoft.Model.BaseDepartment> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.BaseDepartment> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.BaseDepartment> modelList = new List<Maticsoft.Model.BaseDepartment>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.BaseDepartment model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.BaseDepartment();
					if(dt.Rows[n]["DeptID"]!=null && dt.Rows[n]["DeptID"].ToString()!="")
					{
						model.DeptID=int.Parse(dt.Rows[n]["DeptID"].ToString());
					}
					if(dt.Rows[n]["ParentDeptID"]!=null && dt.Rows[n]["ParentDeptID"].ToString()!="")
					{
						model.ParentDeptID=int.Parse(dt.Rows[n]["ParentDeptID"].ToString());
					}
					if(dt.Rows[n]["DeptName"]!=null && dt.Rows[n]["DeptName"].ToString()!="")
					{
					model.DeptName=dt.Rows[n]["DeptName"].ToString();
					}
					if(dt.Rows[n]["CreatedDate"]!=null && dt.Rows[n]["CreatedDate"].ToString()!="")
					{
						model.CreatedDate=DateTime.Parse(dt.Rows[n]["CreatedDate"].ToString());
					}
					if(dt.Rows[n]["CreatedGuy"]!=null && dt.Rows[n]["CreatedGuy"].ToString()!="")
					{
						model.CreatedGuy=int.Parse(dt.Rows[n]["CreatedGuy"].ToString());
					}
					if(dt.Rows[n]["UpdatedDate"]!=null && dt.Rows[n]["UpdatedDate"].ToString()!="")
					{
						model.UpdatedDate=DateTime.Parse(dt.Rows[n]["UpdatedDate"].ToString());
					}
					if(dt.Rows[n]["UpdatedGuy"]!=null && dt.Rows[n]["UpdatedGuy"].ToString()!="")
					{
						model.UpdatedGuy=int.Parse(dt.Rows[n]["UpdatedGuy"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["DeptIDs"]!=null && dt.Rows[n]["DeptIDs"].ToString()!="")
					{
					model.DeptIDs=dt.Rows[n]["DeptIDs"].ToString();
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

