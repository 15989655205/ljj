using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// approve_role
	/// </summary>
	public partial class approve_role
	{
		private readonly Maticsoft.DAL.approve_role dal=new Maticsoft.DAL.approve_role();
		public approve_role()
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
		public bool Exists(int sid)
		{
			return dal.Exists(sid);
		}
        public bool Exists(string rn)
        {
            return dal.Exists(rn);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(Maticsoft.Model.approve_role model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.approve_role model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int sid)
		{
			
			return dal.Delete(sid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string sidlist )
		{
			return dal.DeleteList(sidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.approve_role GetModel(int sid)
		{
			
			return dal.GetModel(sid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.approve_role GetModelByCache(int sid)
		{
			
			string CacheKey = "approve_roleModel-" + sid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(sid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.approve_role)objModel;
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
		public List<Maticsoft.Model.approve_role> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.approve_role> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.approve_role> modelList = new List<Maticsoft.Model.approve_role>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.approve_role model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.approve_role();
					if(dt.Rows[n]["sid"]!=null && dt.Rows[n]["sid"].ToString()!="")
					{
						model.sid=int.Parse(dt.Rows[n]["sid"].ToString());
					}
					if(dt.Rows[n]["role_name"]!=null && dt.Rows[n]["role_name"].ToString()!="")
					{
					model.role_name=dt.Rows[n]["role_name"].ToString();
					}
					if(dt.Rows[n]["role_level"]!=null && dt.Rows[n]["role_level"].ToString()!="")
					{
						model.role_level=int.Parse(dt.Rows[n]["role_level"].ToString());
					}
					if(dt.Rows[n]["role_post"]!=null && dt.Rows[n]["role_post"].ToString()!="")
					{
					model.role_post=dt.Rows[n]["role_post"].ToString();
					}
					if(dt.Rows[n]["role_status"]!=null && dt.Rows[n]["role_status"].ToString()!="")
					{
						model.role_status=int.Parse(dt.Rows[n]["role_status"].ToString());
					}
					if(dt.Rows[n]["remark"]!=null && dt.Rows[n]["remark"].ToString()!="")
					{
					model.remark=dt.Rows[n]["remark"].ToString();
					}
					if(dt.Rows[n]["value1"]!=null && dt.Rows[n]["value1"].ToString()!="")
					{
					model.value1=dt.Rows[n]["value1"].ToString();
					}
					if(dt.Rows[n]["value2"]!=null && dt.Rows[n]["value2"].ToString()!="")
					{
					model.value2=dt.Rows[n]["value2"].ToString();
					}
					if(dt.Rows[n]["value3"]!=null && dt.Rows[n]["value3"].ToString()!="")
					{
					model.value3=dt.Rows[n]["value3"].ToString();
					}
					if(dt.Rows[n]["value4"]!=null && dt.Rows[n]["value4"].ToString()!="")
					{
					model.value4=dt.Rows[n]["value4"].ToString();
					}
					if(dt.Rows[n]["value5"]!=null && dt.Rows[n]["value5"].ToString()!="")
					{
					model.value5=dt.Rows[n]["value5"].ToString();
					}
					if(dt.Rows[n]["value6"]!=null && dt.Rows[n]["value6"].ToString()!="")
					{
					model.value6=dt.Rows[n]["value6"].ToString();
					}
					if(dt.Rows[n]["status"]!=null && dt.Rows[n]["status"].ToString()!="")
					{
						model.status=int.Parse(dt.Rows[n]["status"].ToString());
					}
					if(dt.Rows[n]["create_person"]!=null && dt.Rows[n]["create_person"].ToString()!="")
					{
					model.create_person=dt.Rows[n]["create_person"].ToString();
					}
					if(dt.Rows[n]["create_date"]!=null && dt.Rows[n]["create_date"].ToString()!="")
					{
						model.create_date=DateTime.Parse(dt.Rows[n]["create_date"].ToString());
					}
					if(dt.Rows[n]["update_person"]!=null && dt.Rows[n]["update_person"].ToString()!="")
					{
					model.update_person=dt.Rows[n]["update_person"].ToString();
					}
					if(dt.Rows[n]["update_date"]!=null && dt.Rows[n]["update_date"].ToString()!="")
					{
						model.update_date=DateTime.Parse(dt.Rows[n]["update_date"].ToString());
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

