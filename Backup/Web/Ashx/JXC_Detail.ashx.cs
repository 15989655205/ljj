using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.DBUtility;
using System.Data;
using System.Web.SessionState;
namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// JXC_Detail 的摘要说明
    /// </summary>
    public class JXC_Detail : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Session["login"] == null)
            {
                context.Response.Write("登录超时，请重新登录。");
                return;
            }

            string msg = string.Empty;
            string action = context.Request["action"].ToString();
            switch (action)
            {
                case "planDetail": msg=GetPlan(context); break;
                case "save": msg = Save(context); break;
                case "edit": msg = SaveAll(context); break;
                case "add": msg = SaveAdd(context); break;
                default: break;
            }
            context.Response.Write(msg);

        }

        //save all the add procurement plan
        public string SaveAdd(HttpContext context)
        {
           
            string txtOdd = context.Request["txtOdd"].ToString();
            string txtOrderDate = context.Request["txtOrderDate"].ToString();
            string txtSupplier = context.Request["txtSupplier"].ToString();
            string txtBuyer = context.Request["txtBuyer"].ToString();
            string txtSupplierHandled = context.Request["txtSupplierHandled"].ToString();
            string txtDeliveryDate = context.Request["txtDeliveryDate"].ToString();
            string txtCurrency = context.Request["txtCurrency"].ToString();
            string txtExchangeRate = context.Request["txtExchangeRate"].ToString();
            string txtPriceReduction = context.Request["txtPriceReduction"].ToString();
            string txtPayTerm = context.Request["txtPayTerm"].ToString();
            string txtDiscountRate = context.Request["txtDiscountRate"].ToString();
            string txtDeposit = context.Request["txtDeposit"].ToString();
            string txtAccountsMode = context.Request["txtAccountsMode"].ToString();
            string txtTaxRate = context.Request["txtTaxRate"].ToString();
            string txtOtherFees = context.Request["txtOtherFees"].ToString();
            string txtPlansFactoryDate = context.Request["txtPlansFactoryDate"].ToString();
            string txtFactoryDate = context.Request["txtFactoryDate"].ToString();
            string txtTransport = context.Request["txtTransport"].ToString();
            string txtDeliveryAddress = context.Request["txtDeliveryAddress"].ToString();
            string txtDirections = context.Request["txtDirections"].ToString();
            string txtRemark = context.Request["txtRemark"].ToString();

            Model.jxc_ProcurementPlan model = new Model.jxc_ProcurementPlan();
            model.Odd = txtOdd;
            model.OrderDate = Convert.ToDateTime(txtOrderDate);
            model.Supplier = txtSupplier;
            model.SupplierHandled = txtSupplierHandled;
            model.DeliveryDate = Convert.ToDateTime(txtDeliveryDate);
            model.Currency = txtCurrency;
            model.ExchangeRate = Convert.ToDecimal(txtExchangeRate);
            model.PriceReduction = Convert.ToDecimal(txtPriceReduction);
            model.PayTerm = txtPayTerm;

            model.DiscountRate = Convert.ToDecimal(txtDiscountRate);
            model.Deposit = Convert.ToDecimal(txtDeposit);
            model.AccountsMode = txtAccountsMode;
            model.TaxRate = Convert.ToDecimal(txtTaxRate);

            model.OtherFees = Convert.ToDecimal(txtOtherFees);
            model.PlansFactoryDate = Convert.ToDateTime(txtPlansFactoryDate);
            model.FactoryDate = Convert.ToDateTime(txtFactoryDate);
            model.Transport = txtTransport;
            model.DeliveryAddress = txtDeliveryAddress;
            model.Directions = txtDirections;
            model.remark = txtRemark;


            string addSrt = context.Request["addstr"];
            string updatestr = context.Request["updatestr"];
            string delstr = context.Request["delstr"];

            List<Model.jxc_ProcurementPlanItem> insertList = new List<Model.jxc_ProcurementPlanItem>();
            insertList = JsonSerializerHelper.JSONStringToList<Model.jxc_ProcurementPlanItem>(addSrt);
            List<Model.jxc_ProcurementPlanItem> updateList = new List<Model.jxc_ProcurementPlanItem>();
            updateList = JsonSerializerHelper.JSONStringToList<Model.jxc_ProcurementPlanItem>(updatestr);
            List<Model.jxc_ProcurementPlanItem> delList = new List<Model.jxc_ProcurementPlanItem>();
            delList = JsonSerializerHelper.JSONStringToList<Model.jxc_ProcurementPlanItem>(delstr);

            string result = new BLL.jxc_ProcurementPlanItem().EditStock(insertList, updateList, delList, ((Model.BaseUser)context.Session["login"]).UserID, model);
            if (result == "success")
            {
                return "success！";
            }
            else
            {
                return "操作失败！";
            }



        }

        //save procurement plan and procurement plan detail
        public string SaveAll(HttpContext context)
        {
            string id = context.Request["id"].ToString();
            string txtOdd = context.Request["txtOdd"].ToString();
            string txtOrderDate = context.Request["txtOrderDate"].ToString();
            string txtSupplier = context.Request["txtSupplier"].ToString();
            string txtBuyer = context.Request["txtBuyer"].ToString();
            string txtSupplierHandled = context.Request["txtSupplierHandled"].ToString();
            string txtDeliveryDate = context.Request["txtDeliveryDate"].ToString();
            string txtCurrency = context.Request["txtCurrency"].ToString();
            string txtExchangeRate = context.Request["txtExchangeRate"].ToString();
            string txtPriceReduction = context.Request["txtPriceReduction"].ToString();
            string txtPayTerm = context.Request["txtPayTerm"].ToString();
            string txtDiscountRate = context.Request["txtDiscountRate"].ToString();
            string txtDeposit = context.Request["txtDeposit"].ToString();
            string txtAccountsMode = context.Request["txtAccountsMode"].ToString();
            string txtTaxRate = context.Request["txtTaxRate"].ToString();
            string txtOtherFees = context.Request["txtOtherFees"].ToString();
            string txtPlansFactoryDate = context.Request["txtPlansFactoryDate"].ToString();
            string txtFactoryDate = context.Request["txtFactoryDate"].ToString();
            string txtTransport = context.Request["txtTransport"].ToString();
            string txtDeliveryAddress = context.Request["txtDeliveryAddress"].ToString();
            string txtDirections = context.Request["txtDirections"].ToString();
            string txtRemark = context.Request["txtRemark"].ToString();

            Model.jxc_ProcurementPlan model = new Model.jxc_ProcurementPlan();
            model.ID =Convert.ToInt64( id);
            model.Odd = txtOdd;
            model.OrderDate =Convert.ToDateTime( txtOrderDate);
            model.Supplier = txtSupplier;
            model.SupplierHandled = txtSupplierHandled;
            model.DeliveryDate =Convert.ToDateTime(txtDeliveryDate);
            model.Currency = txtCurrency;
            model.ExchangeRate =Convert.ToDecimal( txtExchangeRate);
            model.PriceReduction =Convert.ToDecimal( txtPriceReduction);
            model.PayTerm = txtPayTerm;

            model.DiscountRate =Convert.ToDecimal( txtDiscountRate);
            model.Deposit = Convert.ToDecimal(txtDeposit);
            model.AccountsMode = txtAccountsMode;
            model.TaxRate = Convert.ToDecimal(txtTaxRate);

            model.OtherFees = Convert.ToDecimal(txtOtherFees);
            model.PlansFactoryDate = Convert.ToDateTime(txtPlansFactoryDate);
            model.FactoryDate =Convert.ToDateTime( txtFactoryDate);
            model.Transport = txtTransport;
            model.DeliveryAddress = txtDeliveryAddress;
            model.Directions = txtDirections;
            model.remark = txtRemark;


            string addSrt = context.Request["addstr"];
            string updatestr = context.Request["updatestr"];
            string delstr = context.Request["delstr"];

            List<Model.jxc_ProcurementPlanItem> insertList = new List<Model.jxc_ProcurementPlanItem>();
            insertList = JsonSerializerHelper.JSONStringToList<Model.jxc_ProcurementPlanItem>(addSrt);
            List<Model.jxc_ProcurementPlanItem> updateList = new List<Model.jxc_ProcurementPlanItem>();
            updateList = JsonSerializerHelper.JSONStringToList<Model.jxc_ProcurementPlanItem>(updatestr);
            List<Model.jxc_ProcurementPlanItem> delList = new List<Model.jxc_ProcurementPlanItem>();
            delList = JsonSerializerHelper.JSONStringToList<Model.jxc_ProcurementPlanItem>(delstr);

            string result = new BLL.jxc_ProcurementPlanItem().EditStock(insertList, updateList, delList, ((Model.BaseUser)context.Session["login"]).UserID,model);
            if (result == "success")
            {
                return "success！";
            }
            else
            {
                return "操作失败！";
            }


            
        }

        //保存采购计划明细
        public string Save(HttpContext context)
        {
            string addSrt = context.Request["addstr"];
            string updatestr = context.Request["updatestr"];
            string delstr = context.Request["delstr"];

            List<Model.jxc_ProcurementPlanItem> insertList = new List<Model.jxc_ProcurementPlanItem>();
            insertList = JsonSerializerHelper.JSONStringToList<Model.jxc_ProcurementPlanItem>(addSrt);
            List<Model.jxc_ProcurementPlanItem> updateList = new List<Model.jxc_ProcurementPlanItem>();
            updateList = JsonSerializerHelper.JSONStringToList<Model.jxc_ProcurementPlanItem>(updatestr);
            List<Model.jxc_ProcurementPlanItem> delList = new List<Model.jxc_ProcurementPlanItem>();
            delList = JsonSerializerHelper.JSONStringToList<Model.jxc_ProcurementPlanItem>(delstr);

            string result = new BLL.jxc_ProcurementPlanItem().EditStock(insertList, updateList, delList, ((Model.BaseUser)context.Session["login"]).UserID);
            if (result == "success")
            {
                return "success！";
            }
            else
            {
                return "操作失败！";
            }
        }

        //获得采购明细表
        public string GetPlan(HttpContext context)
        {
            int id=Convert.ToInt32( context.Request["id"].ToString());
            DataSet ds= new BLL.jxc_ProcurementPlanItem().GetDataSetByProc(id,"Query1");
            string result;
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = JsonHelper.DataTable2Josn(ds.Tables[0]);
                return result;
            }
            else
            {
                return "数据为空！";
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}