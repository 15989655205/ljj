using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maticsoft.Model;
using System.Data;
using Maticsoft.DAL;

namespace Maticsoft.BLL
{
    /// <summary>
    /// project_work_flow
    /// </summary>
    public partial class project_work_flow
    {
        private readonly Maticsoft.DAL.project_work_flow dal = new Maticsoft.DAL.project_work_flow();
        public project_work_flow()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.project_work_flow model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.project_work_flow model)
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
        public Maticsoft.Model.project_work_flow GetModel(int sid)
        {

            return dal.GetModel(sid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.project_work_flow GetModelByCache(int sid)
        {

            string CacheKey = "project_work_flowModel-" + sid;
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
            return (Maticsoft.Model.project_work_flow)objModel;
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
        public List<Maticsoft.Model.project_work_flow> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.project_work_flow> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.project_work_flow> modelList = new List<Maticsoft.Model.project_work_flow>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.project_work_flow model;
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

        #endregion  ExtensionMethod

        public string Edit(List<Model.project_work_flow> insert, List<Model.project_work_flow> update, List<Model.project_work_flow> del, List<Model.project_work_flow> sequence, string p_sid, string s_sid)
        {
            if (dal.Edit(insert, update, del, sequence, p_sid, s_sid))
            {
                return "success";
            }
            else
            {
                return "编辑失败！";
            }
        }
    }
}

