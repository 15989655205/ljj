using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
    /// <summary>
    /// jxc_ProcurementPlanItem
    /// </summary>
    public partial class jxc_ProcurementPlanItem
    {
        public readonly Maticsoft.DAL.jxc_ProcurementPlanItem dal = new Maticsoft.DAL.jxc_ProcurementPlanItem();
        public jxc_ProcurementPlanItem()
        { }
        #region  BasicMethod
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
        public long Add(Maticsoft.Model.jxc_ProcurementPlanItem model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.jxc_ProcurementPlanItem model)
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
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.jxc_ProcurementPlanItem GetModel(long ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.jxc_ProcurementPlanItem GetModelByCache(long ID)
        {

            string CacheKey = "jxc_ProcurementPlanItemModel-" + ID;
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
                catch { }
            }
            return (Maticsoft.Model.jxc_ProcurementPlanItem)objModel;
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
        public List<Maticsoft.Model.jxc_ProcurementPlanItem> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.jxc_ProcurementPlanItem> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.jxc_ProcurementPlanItem> modelList = new List<Maticsoft.Model.jxc_ProcurementPlanItem>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.jxc_ProcurementPlanItem model;
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

        public DataSet GetDataSetByProc(int id, string actionType)
        {
            return new DAL.jxc_ProcurementPlanItem().GetDataSetByProc(id, actionType);
        }

        public string  EditStock(List<Model.jxc_ProcurementPlanItem> insertList, List<Model.jxc_ProcurementPlanItem> updateList, List<Model.jxc_ProcurementPlanItem> delList, long id,Model.jxc_ProcurementPlan ppmodel)
        {
            if (dal.EditStock(insertList, updateList, delList, id, ppmodel))
            {
                return "success";
            }
            else
            {
                return "编辑失败！";
            }
            
        }

        public string EditStock(List<Model.jxc_ProcurementPlanItem> insertList, List<Model.jxc_ProcurementPlanItem> updateList, List<Model.jxc_ProcurementPlanItem> delList, long id )
        {
            if (dal.EditStock(insertList, updateList, delList, id))
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

