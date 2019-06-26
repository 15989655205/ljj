using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CompanyInformation
	/// </summary>
	public partial class CompanyInformation
	{
		private readonly Maticsoft.DAL.CompanyInformation dal=new Maticsoft.DAL.CompanyInformation();
		public CompanyInformation()
		{}
		#region  Method

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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

        public bool ExistsToNumber(string Number)
        {
            return dal.ExistsToNumber(Number);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Maticsoft.Model.CompanyInformation model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.CompanyInformation model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
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
		public Maticsoft.Model.CompanyInformation GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.CompanyInformation GetModelByCache(int ID)
		{
			
			string CacheKey = "CompanyInformationModel-" + ID;
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
			return (Maticsoft.Model.CompanyInformation)objModel;
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
		public List<Maticsoft.Model.CompanyInformation> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.CompanyInformation> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CompanyInformation> modelList = new List<Maticsoft.Model.CompanyInformation>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CompanyInformation model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CompanyInformation();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["Number"]!=null && dt.Rows[n]["Number"].ToString()!="")
					{
					model.Number=dt.Rows[n]["Number"].ToString();
					}
					if(dt.Rows[n]["Abbreviation"]!=null && dt.Rows[n]["Abbreviation"].ToString()!="")
					{
					model.Abbreviation=dt.Rows[n]["Abbreviation"].ToString();
					}
					if(dt.Rows[n]["FullName"]!=null && dt.Rows[n]["FullName"].ToString()!="")
					{
					model.FullName=dt.Rows[n]["FullName"].ToString();
					}
					if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
					{
					model.Address=dt.Rows[n]["Address"].ToString();
					}
					if(dt.Rows[n]["EnAddress"]!=null && dt.Rows[n]["EnAddress"].ToString()!="")
					{
					model.EnAddress=dt.Rows[n]["EnAddress"].ToString();
					}
					if(dt.Rows[n]["Head"]!=null && dt.Rows[n]["Head"].ToString()!="")
					{
					model.Head=dt.Rows[n]["Head"].ToString();
					}
					if(dt.Rows[n]["FixedPhone"]!=null && dt.Rows[n]["FixedPhone"].ToString()!="")
					{
					model.FixedPhone=dt.Rows[n]["FixedPhone"].ToString();
					}
					if(dt.Rows[n]["MobilePhone"]!=null && dt.Rows[n]["MobilePhone"].ToString()!="")
					{
					model.MobilePhone=dt.Rows[n]["MobilePhone"].ToString();
					}
					if(dt.Rows[n]["Fax"]!=null && dt.Rows[n]["Fax"].ToString()!="")
					{
					model.Fax=dt.Rows[n]["Fax"].ToString();
					}
					if(dt.Rows[n]["ZipCode"]!=null && dt.Rows[n]["ZipCode"].ToString()!="")
					{
					model.ZipCode=dt.Rows[n]["ZipCode"].ToString();
					}
					if(dt.Rows[n]["CorpId"]!=null && dt.Rows[n]["CorpId"].ToString()!="")
					{
					model.CorpId=dt.Rows[n]["CorpId"].ToString();
					}
					if(dt.Rows[n]["OpeningBank"]!=null && dt.Rows[n]["OpeningBank"].ToString()!="")
					{
					model.OpeningBank=dt.Rows[n]["OpeningBank"].ToString();
					}
					if(dt.Rows[n]["Account"]!=null && dt.Rows[n]["Account"].ToString()!="")
					{
					model.Account=dt.Rows[n]["Account"].ToString();
					}
					if(dt.Rows[n]["CustomsCode"]!=null && dt.Rows[n]["CustomsCode"].ToString()!="")
					{
					model.CustomsCode=dt.Rows[n]["CustomsCode"].ToString();
					}
					if(dt.Rows[n]["LegalRepresentative"]!=null && dt.Rows[n]["LegalRepresentative"].ToString()!="")
					{
					model.LegalRepresentative=dt.Rows[n]["LegalRepresentative"].ToString();
					}
					if(dt.Rows[n]["Remark"]!=null && dt.Rows[n]["Remark"].ToString()!="")
					{
					model.Remark=dt.Rows[n]["Remark"].ToString();
					}
					if(dt.Rows[n]["Status"]!=null && dt.Rows[n]["Status"].ToString()!="")
					{
						model.Status=int.Parse(dt.Rows[n]["Status"].ToString());
					}
					if(dt.Rows[n]["EticPrice"]!=null && dt.Rows[n]["EticPrice"].ToString()!="")
					{
						model.EticPrice=decimal.Parse(dt.Rows[n]["EticPrice"].ToString());
					}
					if(dt.Rows[n]["PackPrice"]!=null && dt.Rows[n]["PackPrice"].ToString()!="")
					{
						model.PackPrice=decimal.Parse(dt.Rows[n]["PackPrice"].ToString());
					}
					if(dt.Rows[n]["EnAbbreviation"]!=null && dt.Rows[n]["EnAbbreviation"].ToString()!="")
					{
					model.EnAbbreviation=dt.Rows[n]["EnAbbreviation"].ToString();
					}
					if(dt.Rows[n]["EnFullName"]!=null && dt.Rows[n]["EnFullName"].ToString()!="")
					{
					model.EnFullName=dt.Rows[n]["EnFullName"].ToString();
					}
					if(dt.Rows[n]["Value"]!=null && dt.Rows[n]["Value"].ToString()!="")
					{
					model.Value=dt.Rows[n]["Value"].ToString();
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

        #region  ExtensionMethod
        public DataSet GetList(string tableName, string orderFile, string showField, int page, int rows, out int count, string orderType, string where)
        {
            return dal.GetList(tableName, orderFile, showField, page, rows, out count, orderType, where);
        }
        #endregion  ExtensionMethod
	}
}

