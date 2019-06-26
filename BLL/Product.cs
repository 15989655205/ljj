using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
    /// <summary>
    /// Product
    /// </summary>
    public partial class Product
    {
        public readonly Maticsoft.DAL.Product dal = new Maticsoft.DAL.Product();
        public Product()
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
        public Maticsoft.Model.Product GetModel(long ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Product GetModel(string Name)
        {

            return dal.GetModel(Name);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.Product GetModelByCache(long ID)
        {

            string CacheKey = "ProductModel-" + ID;
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
            return (Maticsoft.Model.Product)objModel;
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
        public List<Maticsoft.Model.Product> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.Product> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.Product> modelList = new List<Maticsoft.Model.Product>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.Product model;
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
        public long CheckToAdd(Maticsoft.Model.Product model, List<Model.ProductPriceColorShip> insertList, string picFile)
        {
            if (dal.exists(" where Name='" + model.Name + "'"))
            {
               
                return -2;
            }
            long returnID = dal.Add(model, insertList, picFile);
            if ( returnID> 0)
            {

                return returnID;
            }
            else
            {
                
                return -3;
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string CheckToUpdate(Maticsoft.Model.Product model, List<Model.ProductPriceColorShip> delList, List<Model.ProductPriceColorShip> insert, List<Model.ProductPriceColorShip> updateList,string picFile, string id)
        {
            if (dal.GetDS(id).Tables[0].Rows[0]["Name"].ToString() != model.Name)
            {
                if (dal.exists(" where Name='" + model.Name + "'"))
                {
                    return "名称已存在,更新失败！";
                }
                else
                {
                    if (dal.Update(model, delList, insert,updateList, picFile, id) > 0)
                    {
                        return "success";
                    }
                    else
                    {
                        return "更新失败！";
                    }
                }
            }
            else
            {
                if (dal.Update(model, delList, insert,updateList, picFile, id) > 0)
                {
                    return "success";
                }
                else
                {
                    return "更新失败！";
                }
            }
        }

         

        public DataSet GetDataSetByProc(long ID)
        {
           return  new DAL.Product().GetDataSetByProc(ID);
        }

        public DataSet UpdateImageByProc(Model.Product model)
        {
            return new DAL.Product().UpdateImageByProc(model);
        }

        #endregion  ExtensionMethod
    }
}

