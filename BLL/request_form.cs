/**  版本信息模板在安装目录下，可自行修改。
* request_form.cs
*
* 功 能： N/A
* 类 名： request_form
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-7-17 17:33:27   N/A    初版
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
	/// request_form
	/// </summary>
	public partial class request_form
	{
		private readonly Maticsoft.DAL.request_form dal=new Maticsoft.DAL.request_form();
		public request_form()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sid)
        {
            return dal.Exists(sid);
        }

        public bool Exists_where(string where)
        {
            return dal.Exists_where(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Maticsoft.Model.request_form model)
        {
            if (Exists_where(" where form_name='" + model.form_name.Trim() + "'"))
            {
                return "表单已存在";
            }
            else
            {
                if (dal.Add(model) > 0)
                {
                    return "success";
                }
                else
                {
                    return "新增失败！";
                }
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Maticsoft.Model.request_form model)
        {
            if (Exists_where(" where form_name='" + model.form_name.Trim() + "' and sid!="+model.sid))
            {
                return "表单已存在";
            }
            else
            {
                if (dal.Update(model))
                {
                    return "success";
                }
                else
                {
                    return "保存失败！";
                }
            }
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
        public string DeleteList(string sidlist)
        {
            if (dal.DeleteList(sidlist))
            {
                return "success";
            }
            else
            {
                return "删除失败！";
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.request_form GetModel(int sid)
        {

            return dal.GetModel(sid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.request_form GetModelByCache(int sid)
        {

            string CacheKey = "request_formModel-" + sid;
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
                catch { }
            }
            return (Maticsoft.Model.request_form)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.request_form> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.request_form> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.request_form> modelList = new List<Maticsoft.Model.request_form>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.request_form model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        public string Edit(List<Model.request_form> insertList, List<Model.request_form> updateList, List<Model.request_form> delList)
        {
            if (dal.Edit(insertList, updateList, delList))
            {
                return "success";
            }
            else
            {
                return "编辑失败！";
            }
        }
		#endregion  ExtensionMethod
	}
}

