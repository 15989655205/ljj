using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// ClientLevel
	/// </summary>
	public partial class ClientLevel
	{
		private readonly Maticsoft.DAL.ClientLevel dal=new Maticsoft.DAL.ClientLevel();
		public ClientLevel()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Maticsoft.Model.ClientLevel model)
		{
            DataTable dt = dal.GetList().Tables[0];
            for (int i = 1; i < int.MaxValue; i++)
            {
                if (dt.Select("Code='" + i.ToString() + "'").Length == 0)
                {
                    model.Code = i.ToString();
                    break;
                }
            }
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.ClientLevel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ID)
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
		public Maticsoft.Model.ClientLevel GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.ClientLevel GetModelByCache(long ID)
		{
			
			string CacheKey = "ClientLevelModel-" + ID;
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
			return (Maticsoft.Model.ClientLevel)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        public DataSet GetList()
		{
			return dal.GetList();
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
		public List<Maticsoft.Model.ClientLevel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.ClientLevel> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.ClientLevel> modelList = new List<Maticsoft.Model.ClientLevel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.ClientLevel model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.ClientLevel();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["Code"]!=null && dt.Rows[n]["Code"].ToString()!="")
					{
					model.Code=dt.Rows[n]["Code"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["ReferencePrice"]!=null && dt.Rows[n]["ReferencePrice"].ToString()!="")
					{
						model.ReferencePrice=int.Parse(dt.Rows[n]["ReferencePrice"].ToString());
					}
					if(dt.Rows[n]["Percentage"]!=null && dt.Rows[n]["Percentage"].ToString()!="")
					{
						model.Percentage=decimal.Parse(dt.Rows[n]["Percentage"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
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
					if(dt.Rows[n]["CreateUser"]!=null && dt.Rows[n]["CreateUser"].ToString()!="")
					{
						model.CreateUser=long.Parse(dt.Rows[n]["CreateUser"].ToString());
					}
					if(dt.Rows[n]["CreateDate"]!=null && dt.Rows[n]["CreateDate"].ToString()!="")
					{
						model.CreateDate=DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
					}
					if(dt.Rows[n]["UpdateUser"]!=null && dt.Rows[n]["UpdateUser"].ToString()!="")
					{
						model.UpdateUser=long.Parse(dt.Rows[n]["UpdateUser"].ToString());
					}
					if(dt.Rows[n]["UpdateDate"]!=null && dt.Rows[n]["UpdateDate"].ToString()!="")
					{
						model.UpdateDate=DateTime.Parse(dt.Rows[n]["UpdateDate"].ToString());
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

