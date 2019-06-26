using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Collections;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:base_post
	/// </summary>
    public partial class jxc_PurchaseItems
    {
        public jxc_PurchaseItems()
        { }

        public bool Edit(List<Model.jxc_PurchaseItems> insertList, List<Model.jxc_PurchaseItems> updateList, List<Model.jxc_PurchaseItems> delList, int userId, long sid, int DeliveryOdd, decimal OtherFees)
        {
            ArrayList arr = new ArrayList();
            StringBuilder sbSql = new StringBuilder();

            sbSql.Append("update jxc_Purchase set DeliveryOdd=" + DeliveryOdd + ",OtherFees=" + OtherFees + "  where ID=" + sid + "");
            arr.Add(sbSql);
            //for (int i = 0; i < updateList.Count; i++)
            //{
            //    sbSql = new StringBuilder();
            //    Model.jxc_PurchaseItems model = updateList[i];
            //    sbSql.Append("update jxc_PurchaseItems set PriceExcl='" + model.PriceExcl + "',TaxPrice='" + model.TaxPrice + "',DiscountRate='" + model.DiscountRate + "'");
            //    sbSql.Append(",OrderingProductDescription='" + model.OrderingProductDescription + "',update_date=getdate(),update_person='" + userId + "',remark='" + model.remark + "'");
            //    sbSql.Append(" where ID=" + model.ID);
            //    arr.Add(sbSql.ToString());
            //}
            DbHelperSQL.ExecuteSqlTran(arr);
            return true;
        }
    }
}
