using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// File
	/// </summary>
	public partial class File
	{
		private readonly Maticsoft.DAL.File dal=new Maticsoft.DAL.File();
		public File()
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
		public int  Add(Maticsoft.Model.File model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.File model)
		{
			return dal.Update(model);
		}

        /// <summary>
		/// 提交数据
		/// </summary>
        public bool Update(List<Model.File> model)
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
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        public DataSet GetDeleteList(string IDlist)
        {
            return dal.GetDeleteList(IDlist);
        }
        public DataSet GetDownloadList(string IDlist)
        {
            return dal.GetDownloadList(IDlist);
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.File GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.File GetModelByCache(int ID)
		{
			
			string CacheKey = "FileModel-" + ID;
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
			return (Maticsoft.Model.File)objModel;
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
		public List<Maticsoft.Model.File> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.File> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.File> modelList = new List<Maticsoft.Model.File>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.File model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.File();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["file_name"]!=null && dt.Rows[n]["file_name"].ToString()!="")
					{
					model.file_name=dt.Rows[n]["file_name"].ToString();
					}
					if(dt.Rows[n]["type"]!=null && dt.Rows[n]["type"].ToString()!="")
					{
					model.type=dt.Rows[n]["type"].ToString();
					}
					if(dt.Rows[n]["pwd"]!=null && dt.Rows[n]["pwd"].ToString()!="")
					{
					model.pwd=dt.Rows[n]["pwd"].ToString();
					}
					if(dt.Rows[n]["pwdflag"]!=null && dt.Rows[n]["pwdflag"].ToString()!="")
					{
						model.pwdflag=int.Parse(dt.Rows[n]["pwdflag"].ToString());
					}
					if(dt.Rows[n]["up_person"]!=null && dt.Rows[n]["up_person"].ToString()!="")
					{
						model.up_person=int.Parse(dt.Rows[n]["up_person"].ToString());
					}
					if(dt.Rows[n]["up_date"]!=null && dt.Rows[n]["up_date"].ToString()!="")
					{
						model.up_date=DateTime.Parse(dt.Rows[n]["up_date"].ToString());
					}
					if(dt.Rows[n]["updata_person"]!=null && dt.Rows[n]["updata_person"].ToString()!="")
					{
						model.updata_person=int.Parse(dt.Rows[n]["updata_person"].ToString());
					}
					if(dt.Rows[n]["updata_datetiem"]!=null && dt.Rows[n]["updata_datetiem"].ToString()!="")
					{
						model.updata_datetiem=DateTime.Parse(dt.Rows[n]["updata_datetiem"].ToString());
					}
					if(dt.Rows[n]["cate_id"]!=null && dt.Rows[n]["cate_id"].ToString()!="")
					{
						model.cate_id=int.Parse(dt.Rows[n]["cate_id"].ToString());
					}
					if(dt.Rows[n]["flieGuid"]!=null && dt.Rows[n]["flieGuid"].ToString()!="")
					{
					model.flieGuid=dt.Rows[n]["flieGuid"].ToString();
					}
					if(dt.Rows[n]["withoutID"]!=null && dt.Rows[n]["withoutID"].ToString()!="")
					{
						model.withoutID=int.Parse(dt.Rows[n]["withoutID"].ToString());
					}
					if(dt.Rows[n]["activate"]!=null && dt.Rows[n]["activate"].ToString()!="")
					{
						model.activate=int.Parse(dt.Rows[n]["activate"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["value"]!=null && dt.Rows[n]["value"].ToString()!="")
					{
					model.value=dt.Rows[n]["value"].ToString();
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
					if(dt.Rows[n]["value7"]!=null && dt.Rows[n]["value7"].ToString()!="")
					{
					model.value7=dt.Rows[n]["value7"].ToString();
					}
					if(dt.Rows[n]["value8"]!=null && dt.Rows[n]["value8"].ToString()!="")
					{
					model.value8=dt.Rows[n]["value8"].ToString();
					}
					if(dt.Rows[n]["value9"]!=null && dt.Rows[n]["value9"].ToString()!="")
					{
					model.value9=dt.Rows[n]["value9"].ToString();
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

