using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using Maticsoft.DBUtility;

namespace Maticsoft.Web
{
    /// <summary>
    /// Pruchase 的摘要说明
    /// </summary>
    public class Pruchase : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            if (bu == null)
            {
                context.Response.Write("登录超时，请重新登录。");
                return;
            }
            string type = context.Request["action"];
            string reValue = "";
            switch (type)
            {
                case "PlanList":
                    reValue = PlanList(context);
                    break;
                case "PlanSave":
                    reValue = PlanSave(context);
                    break;
                case "PlanSubmit":
                    reValue = PlanSubmit(context);
                    break;
                case "PlanCancelSubmit":
                    reValue = PlanCancelSubmit(context);
                    break;
                case "PlanSHList":
                    reValue = PlanSHList(context);
                    break;
                case "PlanSH":
                    reValue = PlanSH(context);
                    break;
                case "PlanSHBtg":
                    reValue = PlanSHBtg(context);
                    break;
                case "PruchaseOrderList":
                    reValue = PruchaseOrderList(context);
                    break;
                case "PruchaseOrderItemList":
                    reValue = PruchaseOrderItemList(context);
                    break;
                case "Save":
                    reValue = Save(context);
                    break;
                case "PruchaseOrderAuditList":
                    reValue = PruchaseOrderAuditList(context);
                    break;
                case "OrderSH":
                    reValue = OrderSH(context);
                    break;
                case "OrderSHNP":
                    reValue = OrderSHNP(context);
                    break;
                case "PruchaseList":
                    reValue = PruchaseList(context);
                    break;
                case "PruchaseAuditList":
                    reValue = PruchaseAuditList(context);
                    break;
                case "PurchaseSH":
                    reValue = PurchaseSH(context);
                    break;
                case "PurchaseSHNP":
                    reValue = PurchaseSHNP(context);
                    break;
                case "PruchaseOrderSubmit":
                    reValue = PruchaseOrderSubmit(context);
                    break;
                case "PruchaseOrderCanCelSubmit":
                    reValue = PruchaseOrderCanCelSubmit(context);
                    break;
                case "PruchaseItemList":
                    reValue = PruchaseItemList(context);
                    break;
                case "SavePurchase":
                    reValue = SavePurchase(context);
                    break;
                case "PrePaymentList":
                    reValue = PrePaymentList(context);
                    break;
                case "PrePaymentAuditList":
                    reValue = PrePaymentAuditList(context);
                    break;
                case "PrePaymentAudit":
                    reValue = PrePaymentAudit(context);
                    break;
                case "CheckoutList":
                    reValue = CheckoutList(context);
                    break;
                case "CheckoutAuditList":
                    reValue = CheckoutAuditList(context);
                    break;
                case "CheckoutAudit":
                    reValue = CheckoutAudit(context);
                    break;
                case "PruchaseSubmit":
                    reValue = PruchaseSubmit(context);
                    break;
                case "PruchaseCancelSubmit":
                    reValue = PruchaseCancelSubmit(context);
                    break;
                case "PruchaseAudit":
                    reValue = PruchaseAudit(context);
                    break;
                case "PruchaseCanCelAudit":
                    reValue = PruchaseCanCelAudit(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        public string PruchaseCanCelAudit(HttpContext context)
        {
            string ids = context.Request["id"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Pruchase", WCDataAction.Process4);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@ID", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string PruchaseAudit(HttpContext context)
        {
            string ids = context.Request["id"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Pruchase", WCDataAction.Process3);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@ID", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }
        public string PruchaseSubmit(HttpContext context)
        {
            string ids = context.Request["selects"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Pruchase", WCDataAction.Process1);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@IDS", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string PruchaseCancelSubmit(HttpContext context)
        {
            string ids = context.Request["selects"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Pruchase", WCDataAction.Process2);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@IDS", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string SavePurchase(HttpContext context)
        {

            long sid = Convert.ToInt64(context.Request.Params["sid"].ToString());
            decimal OtherFees = context.Request.Params["OtherFees"].ToString() == "" ? 0 : Convert.ToDecimal(context.Request.Params["OtherFees"].ToString());
            int DeliveryOdd = context.Request["DeliveryOdd"].ToString() == "" ? 0 : Convert.ToInt32(context.Request["DeliveryOdd"].ToString());
            string remark = Convert.ToString(context.Request["remark"].ToString());
            Model.BaseUser user = ((Model.BaseUser)context.Session["login"]);

            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            Model.jxc_PurchaseItems model = new Model.jxc_PurchaseItems();

            List<Model.jxc_PurchaseItems> insert = new List<Model.jxc_PurchaseItems>();
            insert = JsonSerializerHelper.JSONStringToList<Model.jxc_PurchaseItems>(addstr);
            List<Model.jxc_PurchaseItems> update = new List<Model.jxc_PurchaseItems>();
            update = JsonSerializerHelper.JSONStringToList<Model.jxc_PurchaseItems>(updatestr);
            List<Model.jxc_PurchaseItems> del = new List<Model.jxc_PurchaseItems>();
            del = JsonSerializerHelper.JSONStringToList<Model.jxc_PurchaseItems>(delstr);


            bool res = new DAL.jxc_PurchaseItems().Edit(insert, update, del, Convert.ToInt32(((Model.BaseUser)(context.Session["login"])).UserID.ToString()), sid, DeliveryOdd, OtherFees);
            return "success";
        }

        private string PruchaseItemList(HttpContext context)
        {
            string PID = context.Request.Params["PID"] == null ? "" : context.Request.Params["PID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "jxc_PurchaseItems poi " +
    "left join Product p on p.ID=poi.ProductID " +
    "left join ProductColor pc on pc.ID=poi.ColorID  " +
    "left join  ProductUnit pu on pu.ID=p.Unit " +
    "left join  jxc_Purchase ppn on ppn.ID= poi.PID ";
            string show = " poi.ID, p.Code  productCode,p.Name  productName,p.Manufacturer,pc.Code pcCode,pc.Name pcName,pu.UnitName,poi.Amount, "
+ "   poi.PriceExcl,poi.TaxPrice,poi.DiscountRate ,isnull( Amount,0)*isnull( poi.TaxPrice,1) as BeforeDiscountPrice,isnull( Amount,0)*isnull(PriceExcl,1) as NoTaxPrice,isnull(poi.TaxPrice,1)*isnull     (Amount,0)*poi.DiscountRate as TaxAllPrice,poi.remark,p.Code,poi.OrderingProductDescription,poi.ReceivedAmount,ppn.Odd,poi.PurchaseItem  ";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string order = "PID";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(PID))
            {
                where += " and PID='" + PID + "'";
            }


            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }


        public string PruchaseOrderCanCelSubmit(HttpContext context)
        {
            string ids = context.Request["selects"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_PruchaseOrder", WCDataAction.Process2);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@IDS", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string PruchaseOrderSubmit(HttpContext context)
        {
            string ids = context.Request["selects"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_PruchaseOrder", WCDataAction.Process1);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@IDS", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string Save(HttpContext context)
        {
            decimal Deposit;
            decimal.TryParse(context.Request.Params["Deposit"].ToString(), out Deposit);
            long sid = Convert.ToInt64(context.Request.Params["sid"].ToString());
            //  int Deposit =context.Request["Deposit"].ToString()==""?0: Convert.ToInt32(context.Request["Deposit"].ToString());
            decimal OtherFees = context.Request.Params["OtherFees"].ToString() == "" ? 0 : Convert.ToDecimal(context.Request.Params["OtherFees"].ToString());
            string Transport = Convert.ToString(context.Request["Transport"].ToString());
            string DeliveryAddress = Convert.ToString(context.Request["DeliveryAddress"].ToString());
            string remark = Convert.ToString(context.Request["remark"].ToString());
            DateTime FactoryDate;
            DateTime.TryParse(context.Request["FactoryDate"].ToString(), out FactoryDate);
            Model.BaseUser user = ((Model.BaseUser)context.Session["login"]);

            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            Model.v_jxc_PurchaseOrdersItems model = new Model.v_jxc_PurchaseOrdersItems();

            List<Model.v_jxc_PurchaseOrdersItems> insert = new List<Model.v_jxc_PurchaseOrdersItems>();
            insert = JsonSerializerHelper.JSONStringToList<Model.v_jxc_PurchaseOrdersItems>(addstr);
            List<Model.v_jxc_PurchaseOrdersItems> update = new List<Model.v_jxc_PurchaseOrdersItems>();
            update = JsonSerializerHelper.JSONStringToList<Model.v_jxc_PurchaseOrdersItems>(updatestr);
            List<Model.v_jxc_PurchaseOrdersItems> del = new List<Model.v_jxc_PurchaseOrdersItems>();
            del = JsonSerializerHelper.JSONStringToList<Model.v_jxc_PurchaseOrdersItems>(delstr);


            bool res = new DAL.jxc_PurchaseOrders().Edit(insert, update, del, Convert.ToInt32(((Model.BaseUser)(context.Session["login"])).UserID.ToString()), sid, Deposit, OtherFees, Transport, DeliveryAddress, remark, FactoryDate);
            return "success";
        }


        private string PruchaseOrderItemList(HttpContext context)
        {
            string PID = context.Request.Params["PID"] == null ? "" : context.Request.Params["PID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "jxc_PurchaseOrdersItems poi"
+ "	left join Product p on p.ID=poi.ProductID"
+ "	left join ProductColor pc on pc.ID=poi.ColorID"
+ "	left join  ProductUnit pu on pu.ID=p.Unit"
+ "	left join  jxc_ProcurementPlanNew ppn on ppn.ID= poi.PlanOdd";
            string show = " poi.ID, p.Code  productCode,p.Name  productName,p.Manufacturer,pc.Code pcCode,pc.Name pcName,pu.UnitName,poi.Amount,"
+ "poi.PriceExcl,poi.TaxPrice,poi.DiscountRate ,isnull( Amount,0)*isnull( poi.TaxPrice,1) as BeforeDiscountPrice,isnull( Amount,0)*isnull(PriceExcl,1) as NoTaxPrice,isnull(poi.TaxPrice,1)*isnull" + "(Amount,0)*DiscountRate as TaxAllPrice,poi.remark,p.Code,poi.OrderingProductDescription,poi.ReceivedAmount,ppn.Odd  ";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string order = "PID";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(PID))
            {
                where += " and PID='" + PID + "'";
            }


            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }


        private string PlanSHList(HttpContext context)
        {
            string ID = context.Request.Params["ID"] == null ? "" : context.Request.Params["ID"].Trim();
            string status = context.Request.Params["status"] == null ? "" : context.Request.Params["status"].Trim();
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_ProcurementPlan";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string order = "curStatusNo";
            string sort = "";
            string where = " 1=1 and Submit=1 or (Audit=0  and Submit=0)";

            if (!string.IsNullOrEmpty(ID))
            {
                where += " and ID='" + ID + "'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status != "0")
                {
                    where += " and curStatusNo='" + status + "'";
                }
            }
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string PlanSHBtg(HttpContext context)
        {
            string ids = context.Request["selects"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_PruchasePlan", WCDataAction.Process4);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@IDS", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string PlanSH(HttpContext context)
        {
            string ids = context.Request["selects"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_PruchasePlan", WCDataAction.Process3);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@IDS", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string OrderSH(HttpContext context)
        {
            string id = context.Request["id"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_PruchaseOrder", WCDataAction.Process3);
            dsp.InputPars.Add("@ID", id);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string OrderSHNP(HttpContext context)
        {
            string id = context.Request["id"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_PruchaseOrder", WCDataAction.Process4);
            dsp.InputPars.Add("@ID", id);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string PurchaseSH(HttpContext context)
        {
            string id = context.Request["id"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Pruchase", WCDataAction.Process3);
            dsp.InputPars.Add("@ID", id);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string PurchaseSHNP(HttpContext context)
        {
            string id = context.Request["id"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Pruchase", WCDataAction.Process4);
            dsp.InputPars.Add("@ID", id);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        private string PlanList(HttpContext context)
        {
            string ID = context.Request.Params["ID"] == null ? "" : context.Request.Params["ID"].Trim();
            string status = context.Request.Params["status"] == null ? "" : context.Request.Params["status"].Trim();
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_ProcurementPlan";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string order = "curStatusNo";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(ID))
            {
                where += " and ID='" + ID + "'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status != "0")
                {
                    where += " and curStatusNo='" + status + "'";
                }
            }
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string PlanSave(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string updatestr = context.Request.Params["updatestr"].Trim();
            List<Model.v_ProcurementPlan> update = new List<Model.v_ProcurementPlan>();
            update = JsonSerializerHelper.JSONStringToList<Model.v_ProcurementPlan>(updatestr);
            return (new DAL.jxc_ProcurementPlanNew().Save(update, bu.UserID.ToString()));
        }

        public string PlanSubmit(HttpContext context)
        {
            string ids = context.Request["selects"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_PruchasePlan", WCDataAction.Process1);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@IDS", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        public string PlanCancelSubmit(HttpContext context)
        {
            string ids = context.Request["selects"].Trim();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_PruchasePlan", WCDataAction.Process2);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@IDS", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        private string PruchaseOrderList(HttpContext context)
        {
            string ID = context.Request.Params["ID"] == null ? "" : context.Request.Params["ID"].Trim();
            string status = context.Request.Params["status"] == null ? "" : context.Request.Params["status"].Trim();
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_PurchaseOrders";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = "curStatusNo";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(ID))
            {
                where += " and ID='" + ID + "'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status != "0")
                {
                    where += " and curStatusNo='" + status + "'";
                }
            }
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string PruchaseOrderAuditList(HttpContext context)
        {
            string uid = ((Model.BaseUser)context.Session["login"]).UserID.ToString();
            string ID = context.Request.Params["ID"] == null ? "" : context.Request.Params["ID"].Trim();
            string status = context.Request.Params["status"] == null ? "" : context.Request.Params["status"].Trim();
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_PurchaseOrders";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = "curStatusNo";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(ID))
            {
                where += " and ID='" + ID + "'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status != "0")
                {
                    if (status == "4")
                    {
                        where += " and (curStatusNo='3' or curStatusNo='4') and AuditGuy='" + uid + "'";
                    }
                    else
                    {
                        where += " and curStatusNo='2'";
                    }
                }
            }
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string PruchaseList(HttpContext context)
        {
            string ID = context.Request.Params["ID"] == null ? "" : context.Request.Params["ID"].Trim();
            string status = context.Request.Params["status"] == null ? "" : context.Request.Params["status"].Trim();
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_Purchase";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = "curStatusNo";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(ID))
            {
                where += " and ID='" + ID + "'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status != "0")
                {
                    where += " and curStatusNo='" + status + "'";
                }
            }
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string PruchaseAuditList(HttpContext context)
        {
            string uid = ((Model.BaseUser)context.Session["login"]).UserID.ToString();
            string ID = context.Request.Params["ID"] == null ? "" : context.Request.Params["ID"].Trim();
            string status = context.Request.Params["status"] == null ? "" : context.Request.Params["status"].Trim();
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_Purchase";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = "curStatusNo";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(ID))
            {
                where += " and ID='" + ID + "'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status != "0")
                {
                    //where += " and curStatusNo='" + status + "'";
                    //if (status == "4")
                    //{
                    //    where += " and AuditGuy='" + uid + "'";
                    //}
                    if (status == "4")
                    {
                        where += " and (curStatusNo='3' or curStatusNo='4') and AuditGuy='" + uid + "'";
                    }
                    else
                    {
                        where += " and curStatusNo='2'";
                    }
                }
            }
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string PrePaymentList(HttpContext context)
        {
            string ID = context.Request.Params["ID"] == null ? "" : context.Request.Params["ID"].Trim();
            string status = context.Request.Params["status"] == null ? "" : context.Request.Params["status"].Trim();
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_PrePayment";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = "curStatusNo";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(ID))
            {
                where += " and ID='" + ID + "'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status != "0")
                {
                    where += " and curStatusNo='" + status + "'";
                }
            }
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string PrePaymentAuditList(HttpContext context)
        {
            string uid = ((Model.BaseUser)context.Session["login"]).UserID.ToString();
            string ID = context.Request.Params["ID"] == null ? "" : context.Request.Params["ID"].Trim();
            string status = context.Request.Params["status"] == null ? "" : context.Request.Params["status"].Trim();
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_PrePayment";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = "curStatusNo";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(ID))
            {
                where += " and ID='" + ID + "'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status != "0")
                {
                    if (status == "4")
                    {
                        where += " and (curStatusNo='3' or curStatusNo='4') and AuditGuy='" + uid + "'";
                    }
                    else
                    {
                        where += " and curStatusNo='2'";
                    }
                }
            }
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string PrePaymentAudit(HttpContext context)
        {
            string ids = context.Request["selects"].Trim();
            string type = context.Request["type"].Trim();
            WCDataAction wcAction = WCDataAction.None;
            if (type == "pass")
            {
                wcAction = WCDataAction.Process3;
            }
            else if (type == "nopass")
            {
                wcAction = WCDataAction.Process4;
            }
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_PrePayment", wcAction);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@IDS", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
        }

        private string CheckoutList(HttpContext context)
        {
            string ID = context.Request.Params["ID"] == null ? "" : context.Request.Params["ID"].Trim();
            string status = context.Request.Params["status"] == null ? "" : context.Request.Params["status"].Trim();
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_Checkout";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = "curStatusNo";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(ID))
            {
                where += " and ID='" + ID + "'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status != "0")
                {
                    where += " and curStatusNo='" + status + "'";
                }
            }
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string CheckoutAuditList(HttpContext context)
        {
            string uid = ((Model.BaseUser)context.Session["login"]).UserID.ToString();
            string ID = context.Request.Params["ID"] == null ? "" : context.Request.Params["ID"].Trim();
            string status = context.Request.Params["status"] == null ? "" : context.Request.Params["status"].Trim();
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_Checkout";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = "curStatusNo";
            string sort = "";
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(ID))
            {
                where += " and ID='" + ID + "'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status != "0")
                {
                    if (status == "4")
                    {
                        where += " and (curStatusNo='3' or curStatusNo='4') and AuditGuy='" + uid + "'";
                    }
                    else
                    {
                        where += " and curStatusNo='2'";
                    }
                }
            }
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select * from v_ProjectMaterialA " + where);
            ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string CheckoutAudit(HttpContext context)
        {
            string ids = context.Request["selects"].Trim();
            string type = context.Request["type"].Trim();
            WCDataAction wcAction = WCDataAction.None;
            if (type == "pass")
            {
                wcAction = WCDataAction.Process3;
            }
            else if (type == "nopass")
            {
                wcAction = WCDataAction.Process4;
            }
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Checkout", wcAction);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@IDS", ids);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                //return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
                return dsp.OutputPars["@out_str"].ToString();
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