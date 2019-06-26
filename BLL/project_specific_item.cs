/**  版本信息模板在安装目录下，可自行修改。
* project_specific_item.cs
*
* 功 能： N/A
* 类 名： project_specific_item
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-8-9 17:16:51   N/A    初版
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
	/// project_specific_item
	/// </summary>
	public partial class project_specific_item
	{
		private readonly Maticsoft.DAL.project_specific_item dal=new Maticsoft.DAL.project_specific_item();
		public project_specific_item()
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
		public int  Add(Maticsoft.Model.project_specific_item model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.project_specific_item model)
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
        public string Delete(string sid)
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
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public string DeleteList(string sidlist )
		{
            if (dal.DeleteList(sidlist))
            {
                return "success";
            }
            else
            {
                return "删除失败";
            }
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.project_specific_item GetModel(int sid)
		{
			
			return dal.GetModel(sid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.project_specific_item GetModelByCache(int sid)
		{
			
			string CacheKey = "project_specific_itemModel-" + sid;
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
			return (Maticsoft.Model.project_specific_item)objModel;
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
		public List<Maticsoft.Model.project_specific_item> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.project_specific_item> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.project_specific_item> modelList = new List<Maticsoft.Model.project_specific_item>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.project_specific_item model;
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
        public string add(int flag,Model.project_specific_item model, List<Model.project_work_implement> insertList)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and parent_sid="+model.parent_sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.add(flag,model, insertList))
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

        public string addItem(Model.project_specific_item model, List<Model.project_work_implement> allList)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and parent_sid=" + model.parent_sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.addItem(model, allList))
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

        public string addItem(Model.project_specific_item model, List<Model.project_item_flow> allList_ft, List<Model.project_work_implement> allList)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and parent_sid=" + model.parent_sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.addItem(model, allList_ft, allList))
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

        public string updateItem(Model.project_specific_item model, List<Model.project_work_implement> all)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and parent_sid=" + model.parent_sid+" and sid!="+model.sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.updateItem(model, all))
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

        public string updateItem(Model.project_specific_item model, List<Model.project_item_flow> allList_ft, List<Model.project_work_implement> all)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and parent_sid=" + model.parent_sid + " and sid!=" + model.sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.updateItem(model,allList_ft, all))
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


        public string addConstructionItem(Model.project_specific_item model, DataTable impDT, DataTable fwDT)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and parent_sid=" + model.parent_sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.addConstructionItem(model, impDT, fwDT))
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

        public string updateConstructionItem(Model.project_specific_item model, DataTable impDT,DataTable fwDT)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and parent_sid=" + model.parent_sid + " and sid!=" + model.sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.updateConstructionItem(model, impDT,fwDT))
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

        //create by zxf
        public string update(int flag, Model.project_specific_item model, List<Model.project_work_implement> insertList)
        {
            try
            {
                if (dal.exists(" where name='" + model.name + "' and parent_sid=" + model.parent_sid +" and sid !=" + model.sid))
                {
                    return "<" + model.name + ">已存在";
                }
                else
                {
                    if (dal.update(flag, model, insertList))
                    {
                        return "success";
                    }
                    else
                    {
                        return "修改失败!";
                    }
                }
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string Edit(List<Model.project_specific_item> insertList, List<Model.project_specific_item> updateList, List<Model.project_specific_item> delList, List<Model.project_specific_item> sequenceList)
        {
            if (dal.Edit(insertList, updateList, delList, sequenceList))
            {
                return "success";
            }
            else
            {
                return "编辑失败！";
            }
        }

        public string ItemEdit(List<Model.project_specific_item> insertList, List<Model.project_specific_item> updateList, List<Model.project_specific_item> delList, List<Model.project_specific_item> sequenceList)
        {
            if (dal.ItemEdit(insertList, updateList, delList, sequenceList))
            {
                return "success";
            }
            else
            {
                return "编辑失败！";
            }
        }

        public string add(Model.project_specific_item model, string actionStr, string categorySid)
        {
            return dal.insert(model,actionStr,categorySid);
        }

        public string update(Model.project_specific_item model, string actionStr, string categorySid)
        {
            return dal.update(model, actionStr, categorySid);
        }
		#endregion  ExtensionMethod
	}
}

