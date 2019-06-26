using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// BaseUser
	/// </summary>
	public partial class BaseUser
	{
		private readonly Maticsoft.DAL.BaseUser dal=new Maticsoft.DAL.BaseUser();
		public BaseUser()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserName)
		{
			return dal.Exists(UserName);
		}

        public bool Exists(string UserName,string UserID)
        {
            return dal.Exists(UserName,UserID);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Maticsoft.Model.BaseUser model)
		{
			return dal.Add(model);
		}

        public string Insert(Maticsoft.Model.BaseUser model)
        {
            if (!Exists(model.UserName))
            {
                if (dal.Insert(model))
                {
                    return "success";
                }
                else
                {
                    return "保存失败！";
                }
            }
            else
            {
                return "用户帐号已经存在！";
            }
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public int Update(Maticsoft.Model.BaseUser model)
		{
            return Exists(model.UserName, model.UserID.ToString()) ? -1 : dal.Update(model);
		}

        public int UpdatePwd(Maticsoft.Model.BaseUser model)
        {
            return Exists(model.UserID.ToString()) ? dal.UpdatePwd(model) : -1;
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
		public bool Delete(string UserName)
		{
			
			return dal.Delete(UserName);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			return dal.DeleteList(UserIDlist );
		}

        public string Deletes(string UserIDlist)
        {
            return dal.Deletes(UserIDlist);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.BaseUser GetModel(long UserID)
		{
			
			return dal.GetModel(UserID);
		}

        public Maticsoft.Model.BaseUser GetModel(string UserName)
        {

            return dal.GetModel(UserName);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.BaseUser GetModelByCache(long UserID)
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
			return (Maticsoft.Model.BaseUser)objModel;
		}


        public bool GetUserDownloadFlag(long userid)
        {
            return dal.GetUserDownloadFlag(userid);
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
		public List<Maticsoft.Model.BaseUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.BaseUser> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.BaseUser> modelList = new List<Maticsoft.Model.BaseUser>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.BaseUser model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, out int rcount)
        {
            return dal.GetList(PageSize, PageIndex, strWhere,out rcount);
        }

        public DataSet GetList(string tableName, string orderFile, string showField, int page, int rows, out int count, string orderType, string where)
        {
            return dal.GetList(tableName, orderFile, showField, page, rows, out count, orderType, where);
        }

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

