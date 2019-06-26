/**  版本信息模板在安装目录下，可自行修改。
* project_specific_item_model.cs
*
* 功 能： N/A
* 类 名： project_specific_item_model
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-8-29 14:53:13   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// project_specific_item_model
	/// </summary>
	public partial class project_specific_item_model
	{
		private readonly Maticsoft.DAL.project_specific_item_model dal=new Maticsoft.DAL.project_specific_item_model();
		public project_specific_item_model()
		{}
		#region  BasicMethod

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

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Maticsoft.Model.project_specific_item_model model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.project_specific_item_model model)
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
		public Maticsoft.Model.project_specific_item_model GetModel(int sid)
		{
			
			return dal.GetModel(sid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.project_specific_item_model GetModelByCache(int sid)
		{
			
			string CacheKey = "project_specific_item_modelModel-" + sid;
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
			return (Maticsoft.Model.project_specific_item_model)objModel;
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
		public List<Maticsoft.Model.project_specific_item_model> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.project_specific_item_model> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.project_specific_item_model> modelList = new List<Maticsoft.Model.project_specific_item_model>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.project_specific_item_model model;
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

        public string add(Model.project_specific_item_model model)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and s_sid=" + model.s_sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.Add(model)>0)
                    {
                        return "success";
                    }
                    else
                    {
                        return "保存失败!";
                    }
                }
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string update(Model.project_specific_item_model model)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and s_sid=" + model.s_sid +" and sid!="+model.sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.Update(model))
                    {
                        return "success";
                    }
                    else
                    {
                        return "保存失败!";
                    }
                }
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string addItem(Model.project_specific_item_model model)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and parent_sid=" + model.parent_sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.Add(model) > 0)
                    {
                        return "success";
                    }
                    else
                    {
                        return "保存失败!";
                    }
                }
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string updateItem(Model.project_specific_item_model model)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and parent_sid=" + model.parent_sid + " and sid!=" + model.sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.update(model))
                    {
                        return "success";
                    }
                    else
                    {
                        return "保存失败!";
                    }
                }
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string deleteContent(string sid)
        {
            if (dal.deleteContent(sid))
            {
                return "success";
            }
            else
            {
                return "删除失败！";
            }
        }

        public string delete(string sid)
        {
            if (dal.Delete(int.Parse(sid)))
            {
                return "success";
            }
            else
            {
                return "删除失败！";
            }
        }
		#endregion  ExtensionMethod
	}
}

