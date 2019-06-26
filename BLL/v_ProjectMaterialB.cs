using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
    /// <summary>
    /// v_ProjectMaterialB
    /// </summary>
    public partial class v_ProjectMaterialB
    {
        private readonly Maticsoft.DAL.v_ProjectMaterialB dal = new Maticsoft.DAL.v_ProjectMaterialB();
        public v_ProjectMaterialB()
        { }
        #region  BasicMethod
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
        public bool Add(Maticsoft.Model.v_ProjectMaterialB model)
        {
            //return dal.Add(model);
            return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.v_ProjectMaterialB model)
        {
           // return dal.Update(model);
            return false;
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
        public bool DeleteList(string sidlist)
        {
            return dal.DeleteList(sidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.v_ProjectMaterialB GetModel(int sid)
        {
            return null;
            //return dal.GetModel(sid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.v_ProjectMaterialB GetModelByCache(int sid)
        {

            string CacheKey = "v_ProjectMaterialBModel-" + sid;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            //if (objModel == null)
            //{
            //    try
            //    {
            //        objModel = dal.GetModel(sid);
            //        if (objModel != null)
            //        {
            //            int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
            //            Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
            //        }
            //    }
            //    catch { }
            //}
            return (Maticsoft.Model.v_ProjectMaterialB)objModel;
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
        public List<Maticsoft.Model.v_ProjectMaterialB> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.v_ProjectMaterialB> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.v_ProjectMaterialB> modelList = new List<Maticsoft.Model.v_ProjectMaterialB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.v_ProjectMaterialB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    //model = dal.DataRowToModel(dt.Rows[n]);
                    //if (model != null)
                    //{
                    //    modelList.Add(model);
                    //}
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
        public bool Edit(List<Model.v_ProjectMaterialB> updateList)
        {
            return false; //new DAL.v_ProjectMaterialB().Edit( updateList);
        }
        #endregion  ExtensionMethod
    }
}

