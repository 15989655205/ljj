using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// File_Dowm_Detail
	/// </summary>
	public partial class File_Dowm_Detail
	{
		private readonly Maticsoft.DAL.File_Dowm_Detail dal=new Maticsoft.DAL.File_Dowm_Detail();
		public File_Dowm_Detail()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Maticsoft.Model.File_Dowm_Detail model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.File_Dowm_Detail model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.File_Dowm_Detail GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.File_Dowm_Detail GetModelByCache(int ID)
		{
			
			string CacheKey = "File_Dowm_DetailModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.File_Dowm_Detail)objModel;
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
		public List<Maticsoft.Model.File_Dowm_Detail> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.File_Dowm_Detail> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.File_Dowm_Detail> modelList = new List<Maticsoft.Model.File_Dowm_Detail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.File_Dowm_Detail model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.File_Dowm_Detail();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["file_id"]!=null && dt.Rows[n]["file_id"].ToString()!="")
					{
						model.file_id=int.Parse(dt.Rows[n]["file_id"].ToString());
					}
					if(dt.Rows[n]["dowm_person"]!=null && dt.Rows[n]["dowm_person"].ToString()!="")
					{
						model.dowm_person=int.Parse(dt.Rows[n]["dowm_person"].ToString());
					}
					if(dt.Rows[n]["dowm_date"]!=null && dt.Rows[n]["dowm_date"].ToString()!="")
					{
						model.dowm_date=DateTime.Parse(dt.Rows[n]["dowm_date"].ToString());
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

