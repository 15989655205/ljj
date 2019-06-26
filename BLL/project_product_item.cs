using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// project_product_item
	/// </summary>
	public partial class project_product_item
	{
		private readonly Maticsoft.DAL.project_product_item dal=new Maticsoft.DAL.project_product_item();
		public project_product_item()
		{}
		#region  BasicMethod
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int sid)
		{
			return dal.Exists(sid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public int Add(Maticsoft.Model.project_product_item model, int detail, int pssid)
		{
            
            return dal.Add(model, detail, pssid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public string Update(Maticsoft.Model.project_product_item model, int detail, int pssid, int parentID, int parent_sid, int ppSid)
		{

            if (dal.Update(model, detail, pssid, parentID, parent_sid, ppSid))
            {
                return "success";
            }
            else
            {
                return "fail";
            }
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int sid)
		{
			
			return dal.Delete(sid);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string sidlist )
		{
			return dal.DeleteList(sidlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.project_product_item GetModel(int sid)
		{
			
			return dal.GetModel(sid);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Maticsoft.Model.project_product_item GetModelByCache(int sid)
		{
			
			string CacheKey = "project_product_itemModel-" + sid;
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
				catch{}
			}
			return (Maticsoft.Model.project_product_item)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.project_product_item> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.project_product_item> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.project_product_item> modelList = new List<Maticsoft.Model.project_product_item>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.project_product_item model;
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod
        public string Edit(List<Model.ProjectProductStage> insertList, List<Model.ProjectProductStage> updateList, List<Model.ProjectProductStage> delList, string uid, string pssid)
        {
            if (dal.Edit(insertList, updateList, delList, uid,pssid))
            {
                return "success";
            }
            else
            {
                return "�༭ʧ�ܣ�";
            }
        }

        public string UpdateImage(Model.project_product_item model)
        {
            return  new BLL.project_product_item().UpdateImage(model);
        }
		#endregion  ExtensionMethod
	}
}

