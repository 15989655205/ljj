using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Data;
namespace Maticsoft.BLL
{
    /// <summary>
    /// project_stage_work_flow_model
    /// </summary>
    public partial class project_stage_work_flow_model
    {
        private readonly Maticsoft.DAL.project_stage_work_flow_model dal = new Maticsoft.DAL.project_stage_work_flow_model();
        public project_stage_work_flow_model()
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
        public int Add(Maticsoft.Model.project_stage_work_flow_model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.project_stage_work_flow_model model)
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
        public bool DeleteList(string sidlist)
        {
            return dal.DeleteList(sidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.project_stage_work_flow_model GetModel(int sid)
        {

            return dal.GetModel(sid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.project_stage_work_flow_model GetModelByCache(int sid)
        {

            string CacheKey = "project_stage_work_flow_modelModel-" + sid;
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
            return (Maticsoft.Model.project_stage_work_flow_model)objModel;
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
        public List<Maticsoft.Model.project_stage_work_flow_model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.project_stage_work_flow_model> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.project_stage_work_flow_model> modelList = new List<Maticsoft.Model.project_stage_work_flow_model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.project_stage_work_flow_model model;
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
        public string Edit(List<Model.project_stage_work_flow_model> insertList, List<Model.project_stage_work_flow_model> updateList, List<Model.project_stage_work_flow_model> delList, List<Model.project_stage_work_flow_model> sequenceList)
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
        #endregion  ExtensionMethod
    }
}


