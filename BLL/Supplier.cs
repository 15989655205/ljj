using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// Supplier
	/// </summary>
	public partial class Supplier
	{
		private readonly Maticsoft.DAL.Supplier dal=new Maticsoft.DAL.Supplier();
		public Supplier()
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
        public long Add(Maticsoft.Model.Supplier model, string ST_Code)
        {
            DataTable dt = dal.GetList("TypeID='" + model.TypeID + "'").Tables[0];
            for (int i = 1; true; i++)
            {
                string Code=i<10?ST_Code+"0"+i.ToString():ST_Code+i.ToString();
                if (dt.Select("Code='" + Code + "'").Length == 0)
                {
                    model.Code = Code;
                    break;
                }
            }
            return dal.Add(model);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Maticsoft.Model.Supplier model, string ST_Code)
        {
            if (model.Code.Substring(0, 2) != ST_Code)
            {
                DataTable dt = dal.GetList("TypeID='" + model.TypeID + "'").Tables[0];
                for (int i = 1; true; i++)
                {
                    string Code = i < 10 ? ST_Code + "0" + i.ToString() : ST_Code + i.ToString();
                    if (dt.Select("Code='" + Code + "'").Length == 0)
                    {
                        model.Code = Code;
                        break;
                    }
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
		public Maticsoft.Model.Supplier GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.Supplier GetModel(string name)
        {

            return dal.GetModel(name);
        }


		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.Supplier GetModelByCache(long ID)
		{
			
			string CacheKey = "SupplierModel-" + ID;
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
			return (Maticsoft.Model.Supplier)objModel;
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
		public List<Maticsoft.Model.Supplier> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.Supplier> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.Supplier> modelList = new List<Maticsoft.Model.Supplier>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.Supplier model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.Supplier();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=long.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["TypeID"]!=null && dt.Rows[n]["TypeID"].ToString()!="")
					{
					model.TypeID=dt.Rows[n]["TypeID"].ToString();
					}
					if(dt.Rows[n]["Code"]!=null && dt.Rows[n]["Code"].ToString()!="")
					{
					model.Code=dt.Rows[n]["Code"].ToString();
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
					if(dt.Rows[n]["Abbreviation"]!=null && dt.Rows[n]["Abbreviation"].ToString()!="")
					{
					model.Abbreviation=dt.Rows[n]["Abbreviation"].ToString();
					}
					if(dt.Rows[n]["FullName"]!=null && dt.Rows[n]["FullName"].ToString()!="")
					{
					model.FullName=dt.Rows[n]["FullName"].ToString();
					}
					if(dt.Rows[n]["EnAbbreviation"]!=null && dt.Rows[n]["EnAbbreviation"].ToString()!="")
					{
					model.EnAbbreviation=dt.Rows[n]["EnAbbreviation"].ToString();
					}
					if(dt.Rows[n]["EnFullName"]!=null && dt.Rows[n]["EnFullName"].ToString()!="")
					{
					model.EnFullName=dt.Rows[n]["EnFullName"].ToString();
					}
					if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
					{
					model.Address=dt.Rows[n]["Address"].ToString();
					}
					if(dt.Rows[n]["EnAddress"]!=null && dt.Rows[n]["EnAddress"].ToString()!="")
					{
					model.EnAddress=dt.Rows[n]["EnAddress"].ToString();
					}
					if(dt.Rows[n]["Margin"]!=null && dt.Rows[n]["Margin"].ToString()!="")
					{
						model.Margin=decimal.Parse(dt.Rows[n]["Margin"].ToString());
					}
					if(dt.Rows[n]["TaxRate"]!=null && dt.Rows[n]["TaxRate"].ToString()!="")
					{
						model.TaxRate=decimal.Parse(dt.Rows[n]["TaxRate"].ToString());
					}
					if(dt.Rows[n]["TypeCode"]!=null && dt.Rows[n]["TypeCode"].ToString()!="")
					{
					model.TypeCode=dt.Rows[n]["TypeCode"].ToString();
					}
					if(dt.Rows[n]["Currency"]!=null && dt.Rows[n]["Currency"].ToString()!="")
					{
					model.Currency=dt.Rows[n]["Currency"].ToString();
					}
					if(dt.Rows[n]["ZipCode"]!=null && dt.Rows[n]["ZipCode"].ToString()!="")
					{
					model.ZipCode=dt.Rows[n]["ZipCode"].ToString();
					}
					if(dt.Rows[n]["PaymentTerms"]!=null && dt.Rows[n]["PaymentTerms"].ToString()!="")
					{
					model.PaymentTerms=dt.Rows[n]["PaymentTerms"].ToString();
					}
					if(dt.Rows[n]["Principal"]!=null && dt.Rows[n]["Principal"].ToString()!="")
					{
					model.Principal=dt.Rows[n]["Principal"].ToString();
					}
					if(dt.Rows[n]["Linkman"]!=null && dt.Rows[n]["Linkman"].ToString()!="")
					{
					model.Linkman=dt.Rows[n]["Linkman"].ToString();
					}
					if(dt.Rows[n]["Buyer"]!=null && dt.Rows[n]["Buyer"].ToString()!="")
					{
					model.Buyer=dt.Rows[n]["Buyer"].ToString();
					}
					if(dt.Rows[n]["PurchasingCycle"]!=null && dt.Rows[n]["PurchasingCycle"].ToString()!="")
					{
					model.PurchasingCycle=dt.Rows[n]["PurchasingCycle"].ToString();
					}
					if(dt.Rows[n]["PurchasingCycleTable"]!=null && dt.Rows[n]["PurchasingCycleTable"].ToString()!="")
					{
					model.PurchasingCycleTable=dt.Rows[n]["PurchasingCycleTable"].ToString();
					}
					if(dt.Rows[n]["PurchasingGoodsCycle"]!=null && dt.Rows[n]["PurchasingGoodsCycle"].ToString()!="")
					{
					model.PurchasingGoodsCycle=dt.Rows[n]["PurchasingGoodsCycle"].ToString();
					}
					if(dt.Rows[n]["PaymentMethod"]!=null && dt.Rows[n]["PaymentMethod"].ToString()!="")
					{
					model.PaymentMethod=dt.Rows[n]["PaymentMethod"].ToString();
					}
					if(dt.Rows[n]["LandTransportation"]!=null && dt.Rows[n]["LandTransportation"].ToString()!="")
					{
					model.LandTransportation=dt.Rows[n]["LandTransportation"].ToString();
					}
					if(dt.Rows[n]["SeaTransportation"]!=null && dt.Rows[n]["SeaTransportation"].ToString()!="")
					{
					model.SeaTransportation=dt.Rows[n]["SeaTransportation"].ToString();
					}
					if(dt.Rows[n]["AirTransportation"]!=null && dt.Rows[n]["AirTransportation"].ToString()!="")
					{
					model.AirTransportation=dt.Rows[n]["AirTransportation"].ToString();
					}
					if(dt.Rows[n]["OtherTransportation"]!=null && dt.Rows[n]["OtherTransportation"].ToString()!="")
					{
					model.OtherTransportation=dt.Rows[n]["OtherTransportation"].ToString();
					}
					if(dt.Rows[n]["DepositBank"]!=null && dt.Rows[n]["DepositBank"].ToString()!="")
					{
					model.DepositBank=dt.Rows[n]["DepositBank"].ToString();
					}
					if(dt.Rows[n]["BankAccount"]!=null && dt.Rows[n]["BankAccount"].ToString()!="")
					{
					model.BankAccount=dt.Rows[n]["BankAccount"].ToString();
					}
					if(dt.Rows[n]["PSubject"]!=null && dt.Rows[n]["PSubject"].ToString()!="")
					{
					model.PSubject=dt.Rows[n]["PSubject"].ToString();
					}
					if(dt.Rows[n]["POSubject"]!=null && dt.Rows[n]["POSubject"].ToString()!="")
					{
					model.POSubject=dt.Rows[n]["POSubject"].ToString();
					}
					if(dt.Rows[n]["TSubject"]!=null && dt.Rows[n]["TSubject"].ToString()!="")
					{
					model.TSubject=dt.Rows[n]["TSubject"].ToString();
					}
					if(dt.Rows[n]["PCProject"]!=null && dt.Rows[n]["PCProject"].ToString()!="")
					{
					model.PCProject=dt.Rows[n]["PCProject"].ToString();
					}
					if(dt.Rows[n]["TCProject"]!=null && dt.Rows[n]["TCProject"].ToString()!="")
					{
					model.TCProject=dt.Rows[n]["TCProject"].ToString();
					}
					if(dt.Rows[n]["Fixed"]!=null && dt.Rows[n]["Fixed"].ToString()!="")
					{
					model.Fixed=dt.Rows[n]["Fixed"].ToString();
					}
					if(dt.Rows[n]["Fax"]!=null && dt.Rows[n]["Fax"].ToString()!="")
					{
					model.Fax=dt.Rows[n]["Fax"].ToString();
					}
					if(dt.Rows[n]["Mobile"]!=null && dt.Rows[n]["Mobile"].ToString()!="")
					{
					model.Mobile=dt.Rows[n]["Mobile"].ToString();
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

