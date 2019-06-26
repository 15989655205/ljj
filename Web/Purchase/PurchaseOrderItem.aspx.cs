using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Purchase
{
    public partial class PurchaseOrderItem : System.Web.UI.Page
    {
        protected string sid = "", type = "";
        protected string Code = "", Buyer = "", DeliveryDate = "", Currency = "", ExchangeRate = "", DiscountRate = "", TaxRate = "", PayTerm = "", AccountsMode = "", Deposit = "", OtherFees = "", PlansFactoryDate = "", FactoryDate = "", Transport = "", DeliveryAddress = "", remark = "", ProjectName = "", SupplierName = "", LinkMan = "", Mobile = "", Principal = "", create_date = "", PriceReduction = "", total = "";
        protected Model.jxc_PurchaseOrders model = new Model.jxc_PurchaseOrders();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sid = Request.Params["sid"] == null ? "" : Request.Params["sid"].Trim();
                type = Request.Params["action"] == null ? "" : Request.Params["action"].Trim();
                if (sid != "")
                {
                    DataSet ds = new DAL.Common().GetList("select *,(((isnull(Deposit,0)+isnull(OtherFees,0))-isnull(PriceReduction,0))*isnull(TaxRate,1)*isnull(DiscountRate,1)) as total from  v_PurchaseOrders  where ID=" + int.Parse(sid));
                   Code= ds.Tables[0].Rows[0]["Code"].ToString();
                    Buyer= ds.Tables[0].Rows[0]["Buyer"].ToString();
                    DeliveryDate = ds.Tables[0].Rows[0]["DeliveryDate"].ToString().Length > 10 ? ds.Tables[0].Rows[0]["DeliveryDate"].ToString().Substring(0, 10) : ds.Tables[0].Rows[0]["DeliveryDate"].ToString();
                    PriceReduction = ds.Tables[0].Rows[0]["PriceReduction"].ToString();
                    Currency= ds.Tables[0].Rows[0]["Currency"].ToString();
                    ExchangeRate= ds.Tables[0].Rows[0]["ExchangeRate"].ToString();
                    DiscountRate= ds.Tables[0].Rows[0]["DiscountRate"].ToString();
                    TaxRate= ds.Tables[0].Rows[0]["TaxRate"].ToString();
                    PayTerm= ds.Tables[0].Rows[0]["PayTerm"].ToString();
                    AccountsMode= ds.Tables[0].Rows[0]["AccountsMode"].ToString();
                    Deposit= ds.Tables[0].Rows[0]["Deposit"].ToString();
                    OtherFees= ds.Tables[0].Rows[0]["OtherFees"].ToString();
                    PlansFactoryDate = ds.Tables[0].Rows[0]["PlansFactoryDate"].ToString().Length > 9 ? ds.Tables[0].Rows[0]["PlansFactoryDate"].ToString().Substring(0, 9) : ds.Tables[0].Rows[0]["PlansFactoryDate"].ToString();
                    FactoryDate = ds.Tables[0].Rows[0]["FactoryDate"].ToString().Length > 9 ? ds.Tables[0].Rows[0]["FactoryDate"].ToString().Substring(0, 9) : ds.Tables[0].Rows[0]["FactoryDate"].ToString();
                    Transport= ds.Tables[0].Rows[0]["Transport"].ToString();
                    DeliveryAddress= ds.Tables[0].Rows[0]["DeliveryAddress"].ToString();
                    remark= ds.Tables[0].Rows[0]["remark"].ToString();
                    ProjectName= ds.Tables[0].Rows[0]["ProjectName"].ToString();
                    SupplierName= ds.Tables[0].Rows[0]["SupplierName"].ToString();
                    LinkMan= ds.Tables[0].Rows[0]["LinkMan"].ToString();
                    Mobile= ds.Tables[0].Rows[0]["Mobile"].ToString();
                    Principal= ds.Tables[0].Rows[0]["Principal"].ToString();
                    total = ds.Tables[0].Rows[0]["total"].ToString();
                    
                    create_date = ds.Tables[0].Rows[0]["create_date"].ToString().Length > 9 ? ds.Tables[0].Rows[0]["PlansFactoryDate"].ToString().Substring(0, 9) : ds.Tables[0].Rows[0]["PlansFactoryDate"].ToString();
                }
            }
        }

    }
}