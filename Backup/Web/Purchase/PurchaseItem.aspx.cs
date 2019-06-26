using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Purchase
{
    public partial class PurchaseItem : System.Web.UI.Page
    {
        protected string sid = "", type = "";
        protected string Code = "", Buyer = "", DeliveryDate = "", Currency = "", ExchangeRate = "", DiscountRate = "", DiscountPrice="", TaxRate = "", PayTerm = "", AccountsMode = "", Deposit = "", OtherFees = "", PlansFactoryDate = "", FactoryDate = "", Transport = "", DeliveryAddress = "", remark = "", ProjectName = "", SupplierName = "", LinkMan = "", Mobile = "", Principal = "", create_date = "", PriceReduction = "", total = "", Handled = "", Prepayments = "", SupplierHandled = "", DeliveryOdd = "";
        protected Model.jxc_PurchaseOrders model = new Model.jxc_PurchaseOrders();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sid = Request.Params["sid"] == null ? "" : Request.Params["sid"].Trim();
                type = Request.Params["action"] == null ? "" : Request.Params["action"].Trim();
                DataSet ds = new DataSet();
                if (sid != "")
                {
                    WCDataProvider db = new WCDataProvider();
                    WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Pruchase", WCDataAction.Query1);
                    //dsp.InputPars.Add("@Where", " ParentID=0 ");
                    dsp.InputPars.Add("@ID", sid);
                   
                    if (db.Execute(dsp).ExecuteState)
                    {
                        //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                        
                        ds = dsp.OutputDataSet;
                    }
      



                    Code = ds.Tables[0].Rows[0]["Code"].ToString();
                    DeliveryOdd = ds.Tables[0].Rows[0]["DeliveryOdd"].ToString();
                    PriceReduction = ds.Tables[0].Rows[0]["PriceReduction"].ToString();
                    Currency = ds.Tables[0].Rows[0]["Currency"].ToString();
                    ExchangeRate = ds.Tables[0].Rows[0]["ExchangeRate"].ToString();
                    DiscountRate = ds.Tables[0].Rows[0]["DiscountRate"].ToString();
                    TaxRate = ds.Tables[0].Rows[0]["TaxRate"].ToString();
                    PayTerm = ds.Tables[0].Rows[0]["PayTerm"].ToString();
                    AccountsMode = ds.Tables[0].Rows[0]["AccountsMode"].ToString();
                    OtherFees = ds.Tables[0].Rows[0]["OtherFees"].ToString();
                    Handled = ds.Tables[0].Rows[0]["Handled"].ToString();
                    Prepayments = ds.Tables[0].Rows[0]["Prepayments"].ToString();
                    //FactoryDate = ds.Tables[0].Rows[0]["FactoryDate"].ToString().Length > 9 ? ds.Tables[0].Rows[0]["FactoryDate"].ToString().Substring(0, 9) : ds.Tables[0].Rows[0]["FactoryDate"].ToString();
                    //Transport = ds.Tables[0].Rows[0]["Transport"].ToString();
                    DeliveryAddress = ds.Tables[0].Rows[0]["DeliveryAddress"].ToString();
                    remark = ds.Tables[0].Rows[0]["remark"].ToString();
                    SupplierName = ds.Tables[0].Rows[0]["Abbreviation"].ToString();
                    SupplierHandled = ds.Tables[0].Rows[0]["SupplierHandled"].ToString();
                    LinkMan = ds.Tables[0].Rows[0]["Handled"].ToString();
                    Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                   total = ds.Tables[0].Rows[0]["total"].ToString();

                    //create_date = ds.Tables[0].Rows[0]["create_date"].ToString().Length > 9 ? ds.Tables[0].Rows[0]["create_date"].ToString().Substring(0, 9) : ds.Tables[0].Rows[0]["create_date"].ToString();
                }
            }
        }
    }
}