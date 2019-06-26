using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// ProductType
	/// </summary>
	public partial class ProductType
	{
		private readonly Maticsoft.DAL.ProductType dal=new Maticsoft.DAL.ProductType();
		public ProductType()
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
		public string Add(Maticsoft.Model.ProductType model)
		{
            DataTable dt = dal.GetList("ParentID=" + model.ParentID.ToString()).Tables[0];
            switch (model.Level)
            {
                case 1:
                    if (dt.Rows.Count == 26)
                    {
                        return "一级分类编码A-Z已使用完毕。";
                    }
                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        if (dt.Select("Code='" + c + "'").Length == 0)
                        {
                            model.Code = c.ToString();
                            break;
                        }
                    }
                    break;
                case 2:
                    for (char i = 'A'; i <= 'Z'; i++)
                    {
                        bool flag = false;
                        for (char j = 'A'; j <= 'Z'; j++)
                        {
                            if (dt.Select("Code='" + i + j + "'").Length == 0)
                            {
                                model.Code = i.ToString() + j.ToString();
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            break;
                        }
                    }
                    break;
                case 3:
                    for (int i = 1; true; i++)
                    {
                        string code = i < 10 ? "0" + i : i.ToString();
                        if (dt.Select("Code='" + code + "'").Length == 0)
                        {
                            model.Code = code;
                            break;
                        }
                    }
                    break;
                default: break;
            }
            return dal.Add(model) > 0 ? "ok" : "保存失败。";
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Maticsoft.Model.ProductType model, long ParentID)
        {
            if (model.ParentID != 0 && model.ParentID != ParentID)
            {
                DataTable dt = dal.GetList("ParentID=" + model.ParentID.ToString()).Tables[0];
                switch (model.Level)
                {
                    case 2:
                        for (char i = 'A'; i <= 'Z'; i++)
                        {
                            bool flag = false;
                            for (char j = 'A'; j <= 'Z'; j++)
                            {
                                if (dt.Select("Code='" + i + j + "'").Length == 0)
                                {
                                    model.Code = i.ToString() + j.ToString();
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag)
                            {
                                break;
                            }
                        }
                        break;
                    case 3:
                        for (int i = 1; true; i++)
                        {
                            string code = i < 10 ? "0" + i : i.ToString();
                            if (dt.Select("Code='" + code + "'").Length == 0)
                            {
                                model.Code = code;
                                break;
                            }
                        }
                        break;
                    default: break;
                }
            }
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
		public Maticsoft.Model.ProductType GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.ProductType GetModel(string name)
        {

            return dal.GetModel(name);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.ProductType GetModelByCache(long ID)
		{
			
			string CacheKey = "ProductTypeModel-" + ID;
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
			return (Maticsoft.Model.ProductType)objModel;
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
		public List<Maticsoft.Model.ProductType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.ProductType> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.ProductType> modelList = new List<Maticsoft.Model.ProductType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.ProductType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.ProductType();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["ParentID"]!=null && dt.Rows[n]["ParentID"].ToString()!="")
					{
						model.ParentID=long.Parse(dt.Rows[n]["ParentID"].ToString());
					}
					if(dt.Rows[n]["Code"]!=null && dt.Rows[n]["Code"].ToString()!="")
					{
					model.Code=dt.Rows[n]["Code"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Level"]!=null && dt.Rows[n]["Level"].ToString()!="")
					{
						model.Level=int.Parse(dt.Rows[n]["Level"].ToString());
					}
					if(dt.Rows[n]["Enabled"]!=null && dt.Rows[n]["Enabled"].ToString()!="")
					{
						if((dt.Rows[n]["Enabled"].ToString()=="1")||(dt.Rows[n]["Enabled"].ToString().ToLower()=="true"))
						{
						model.Enabled=true;
						}
						else
						{
							model.Enabled=false;
						}
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["Value0"]!=null && dt.Rows[n]["Value0"].ToString()!="")
					{
					model.Value0=dt.Rows[n]["Value0"].ToString();
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
					model.CreateUser=dt.Rows[n]["CreateUser"].ToString();
					}
					if(dt.Rows[n]["CreateDate"]!=null && dt.Rows[n]["CreateDate"].ToString()!="")
					{
						model.CreateDate=DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
					}
					if(dt.Rows[n]["UpdateUser"]!=null && dt.Rows[n]["UpdateUser"].ToString()!="")
					{
					model.UpdateUser=dt.Rows[n]["UpdateUser"].ToString();
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

