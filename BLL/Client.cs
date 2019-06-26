using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// Client
	/// </summary>
	public partial class Client
	{
		private readonly Maticsoft.DAL.Client dal=new Maticsoft.DAL.Client();
		public Client()
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
		public long Add(Maticsoft.Model.Client model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Client model)
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
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Client GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.Client GetModelByCache(long ID)
		{
			
			string CacheKey = "ClientModel-" + ID;
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
			return (Maticsoft.Model.Client)objModel;
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
		public List<Maticsoft.Model.Client> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.Client> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.Client> modelList = new List<Maticsoft.Model.Client>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.Client model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.Client();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["CLevel"]!=null && dt.Rows[n]["CLevel"].ToString()!="")
					{
						model.CLevel=long.Parse(dt.Rows[n]["CLevel"].ToString());
					}
					if(dt.Rows[n]["Type"]!=null && dt.Rows[n]["Type"].ToString()!="")
					{
						model.Type=long.Parse(dt.Rows[n]["Type"].ToString());
					}
					if(dt.Rows[n]["Code"]!=null && dt.Rows[n]["Code"].ToString()!="")
					{
					model.Code=dt.Rows[n]["Code"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
					{
					model.Address=dt.Rows[n]["Address"].ToString();
					}
					if(dt.Rows[n]["Head"]!=null && dt.Rows[n]["Head"].ToString()!="")
					{
					model.Head=dt.Rows[n]["Head"].ToString();
					}
					if(dt.Rows[n]["Phone"]!=null && dt.Rows[n]["Phone"].ToString()!="")
					{
					model.Phone=dt.Rows[n]["Phone"].ToString();
					}
					if(dt.Rows[n]["Tel"]!=null && dt.Rows[n]["Tel"].ToString()!="")
					{
					model.Tel=dt.Rows[n]["Tel"].ToString();
					}
					if(dt.Rows[n]["Fax"]!=null && dt.Rows[n]["Fax"].ToString()!="")
					{
					model.Fax=dt.Rows[n]["Fax"].ToString();
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
					}
					if(dt.Rows[n]["BusinessLicense"]!=null && dt.Rows[n]["BusinessLicense"].ToString()!="")
					{
					model.BusinessLicense=dt.Rows[n]["BusinessLicense"].ToString();
					}
					if(dt.Rows[n]["Currency"]!=null && dt.Rows[n]["Currency"].ToString()!="")
					{
					model.Currency=dt.Rows[n]["Currency"].ToString();
					}
					if(dt.Rows[n]["Parities"]!=null && dt.Rows[n]["Parities"].ToString()!="")
					{
						model.Parities=decimal.Parse(dt.Rows[n]["Parities"].ToString());
					}
					if(dt.Rows[n]["ReconciliationDate"]!=null && dt.Rows[n]["ReconciliationDate"].ToString()!="")
					{
						model.ReconciliationDate=DateTime.Parse(dt.Rows[n]["ReconciliationDate"].ToString());
					}
					if(dt.Rows[n]["SetupDate"]!=null && dt.Rows[n]["SetupDate"].ToString()!="")
					{
						model.SetupDate=DateTime.Parse(dt.Rows[n]["SetupDate"].ToString());
					}
					if(dt.Rows[n]["Supplier"]!=null && dt.Rows[n]["Supplier"].ToString()!="")
					{
						if((dt.Rows[n]["Supplier"].ToString()=="1")||(dt.Rows[n]["Supplier"].ToString().ToLower()=="true"))
						{
						model.Supplier=true;
						}
						else
						{
							model.Supplier=false;
						}
					}
					if(dt.Rows[n]["BeginDate"]!=null && dt.Rows[n]["BeginDate"].ToString()!="")
					{
						model.BeginDate=DateTime.Parse(dt.Rows[n]["BeginDate"].ToString());
					}
					if(dt.Rows[n]["EndDate"]!=null && dt.Rows[n]["EndDate"].ToString()!="")
					{
						model.EndDate=DateTime.Parse(dt.Rows[n]["EndDate"].ToString());
					}
					if(dt.Rows[n]["Enable"]!=null && dt.Rows[n]["Enable"].ToString()!="")
					{
						if((dt.Rows[n]["Enable"].ToString()=="1")||(dt.Rows[n]["Enable"].ToString().ToLower()=="true"))
						{
						model.Enable=true;
						}
						else
						{
							model.Enable=false;
						}
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["Area"]!=null && dt.Rows[n]["Area"].ToString()!="")
					{
					model.Area=dt.Rows[n]["Area"].ToString();
					}
					if(dt.Rows[n]["Industry"]!=null && dt.Rows[n]["Industry"].ToString()!="")
					{
					model.Industry=dt.Rows[n]["Industry"].ToString();
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
						model.CreateUser=long.Parse(dt.Rows[n]["CreateUser"].ToString());
					}
					if(dt.Rows[n]["CreateDate"]!=null && dt.Rows[n]["CreateDate"].ToString()!="")
					{
						model.CreateDate=DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
					}
					if(dt.Rows[n]["UpdateUser"]!=null && dt.Rows[n]["UpdateUser"].ToString()!="")
					{
						model.UpdateUser=long.Parse(dt.Rows[n]["UpdateUser"].ToString());
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

