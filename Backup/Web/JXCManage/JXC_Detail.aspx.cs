using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.JXCManage
{
    public partial class JXC_Detail : System.Web.UI.Page
    {
        #region Model
        private long _id;
        private string _odd;
        private string _orderdate;
        private string _buyer;
        private string _supplier;
        private string _supplierhandled;
        private string _deliverydate;
        private string _currency;
        private decimal _exchangerate;
        private decimal _pricereduction;
        private string _payterm;
        private decimal _discountrate;
        private decimal _deposit;
        private string _accountsmode;
        private decimal _taxrate;
        private decimal _otherfees;
        private string _plansfactorydate;
        private string _factorydate;
        private string _transport;
        private string _deliveryaddress;
        private int _state;
        private string _directions;
        private string  _auditdate;
        private string _auditguy;
        private string _remark;
        private string _v1;
        private string _v2;
        private string _v3;
        private string _v4;
        private string _v5;
        private string _v6;
        private string _v7;
        private string _v8;
        private string _v9;
        private string _v10;
        private int _n1;
        private int _n2;
        private int _n3;
        private string _show;
        private string _show_name;
        private int _status = 1;
        private string _create_person;
        private string _create_date = DateTime.Now.ToString();
        private string _update_person;
        private string _update_date;

        private string _action;

        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public  long PPID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Odd
        {
            set { _odd = value; }
            get { return _odd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Buyer
        {
            set { _buyer = value; }
            get { return _buyer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Supplier
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SupplierHandled
        {
            set { _supplierhandled = value; }
            get { return _supplierhandled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeliveryDate
        {
            set { _deliverydate = value; }
            get { return _deliverydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ExchangeRate
        {
            set { _exchangerate = value; }
            get { return _exchangerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PriceReduction
        {
            set { _pricereduction = value; }
            get { return _pricereduction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayTerm
        {
            set { _payterm = value; }
            get { return _payterm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal DiscountRate
        {
            set { _discountrate = value; }
            get { return _discountrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Deposit
        {
            set { _deposit = value; }
            get { return _deposit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AccountsMode
        {
            set { _accountsmode = value; }
            get { return _accountsmode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal TaxRate
        {
            set { _taxrate = value; }
            get { return _taxrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal OtherFees
        {
            set { _otherfees = value; }
            get { return _otherfees; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlansFactoryDate
        {
            set { _plansfactorydate = value; }
            get { return _plansfactorydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FactoryDate
        {
            set { _factorydate = value; }
            get { return _factorydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Transport
        {
            set { _transport = value; }
            get { return _transport; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeliveryAddress
        {
            set { _deliveryaddress = value; }
            get { return _deliveryaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Directions
        {
            set { _directions = value; }
            get { return _directions; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditDate
        {
            set { _auditdate = value; }
            get { return _auditdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditGuy
        {
            set { _auditguy = value; }
            get { return _auditguy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v1
        {
            set { _v1 = value; }
            get { return _v1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v2
        {
            set { _v2 = value; }
            get { return _v2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v3
        {
            set { _v3 = value; }
            get { return _v3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v4
        {
            set { _v4 = value; }
            get { return _v4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v5
        {
            set { _v5 = value; }
            get { return _v5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v6
        {
            set { _v6 = value; }
            get { return _v6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v7
        {
            set { _v7 = value; }
            get { return _v7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v8
        {
            set { _v8 = value; }
            get { return _v8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v9
        {
            set { _v9 = value; }
            get { return _v9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string v10
        {
            set { _v10 = value; }
            get { return _v10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int n1
        {
            set { _n1 = value; }
            get { return _n1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int n2
        {
            set { _n2 = value; }
            get { return _n2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int n3
        {
            set { _n3 = value; }
            get { return _n3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string show
        {
            set { _show = value; }
            get { return _show; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string show_name
        {
            set { _show_name = value; }
            get { return _show_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string create_person
        {
            set { _create_person = value; }
            get { return _create_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string create_date
        {
            set { _create_date = value; }
            get { return _create_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string update_person
        {
            set { _update_person = value; }
            get { return _update_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string update_date
        {
            set { _update_date = value; }
            get { return _update_date; }
        }
        #endregion Model


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }

        }

        public void Bind()
        {
             Action = Request.QueryString["action"];
            string id = Request.QueryString["ID"];
            if (!string.IsNullOrEmpty(id) && Action == "edit")
            {
                DataSet ds = new BLL.jxc_ProcurementPlan().GetList(" ID=" + id + "");
                PPID = Convert.ToInt64(ds.Tables[0].Rows[0]["id"].ToString());
                Odd = ds.Tables[0].Rows[0]["Odd"].ToString();
                OrderDate = ds.Tables[0].Rows[0]["OrderDate"].ToString().Substring(0, 10);
                Buyer = ds.Tables[0].Rows[0]["Buyer"].ToString();
                Supplier = ds.Tables[0].Rows[0]["Supplier"].ToString();
                SupplierHandled = ds.Tables[0].Rows[0]["SupplierHandled"].ToString();
                DeliveryDate = ds.Tables[0].Rows[0]["DeliveryDate"].ToString().Substring(0,10);
                Currency = ds.Tables[0].Rows[0]["Currency"].ToString();
                ExchangeRate = Convert.ToDecimal(ds.Tables[0].Rows[0]["ExchangeRate"].ToString());
                PriceReduction = Convert.ToDecimal(ds.Tables[0].Rows[0]["PriceReduction"].ToString());
                PayTerm = ds.Tables[0].Rows[0]["PayTerm"].ToString();
                DiscountRate = Convert.ToDecimal(ds.Tables[0].Rows[0]["DiscountRate"].ToString());
                Deposit = Convert.ToDecimal(ds.Tables[0].Rows[0]["Deposit"].ToString());
                TaxRate = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxRate"].ToString());
                OtherFees = Convert.ToDecimal(ds.Tables[0].Rows[0]["OtherFees"].ToString());
                PlansFactoryDate = ds.Tables[0].Rows[0]["PlansFactoryDate"].ToString().Substring(0, 10);
                FactoryDate = ds.Tables[0].Rows[0]["FactoryDate"].ToString().Substring(0, 10);
                Transport = ds.Tables[0].Rows[0]["Transport"].ToString();
                DeliveryAddress = ds.Tables[0].Rows[0]["DeliveryAddress"].ToString();
                state = Convert.ToInt32(ds.Tables[0].Rows[0]["state"].ToString());
                Directions = ds.Tables[0].Rows[0]["Directions"].ToString();
                AuditDate = ds.Tables[0].Rows[0]["AuditDate"].ToString();
                AuditGuy = ds.Tables[0].Rows[0]["AuditGuy"].ToString();
                remark = ds.Tables[0].Rows[0]["remark"].ToString();
                create_person = ds.Tables[0].Rows[0]["create_person"].ToString();
                create_date = ds.Tables[0].Rows[0]["create_date"].ToString();
                update_person = ds.Tables[0].Rows[0]["update_person"].ToString();
                update_date = ds.Tables[0].Rows[0]["update_date"].ToString();
            }
            else
            {
                Odd = "";
                OrderDate = "";
                Buyer = "";
                Supplier = "";
                SupplierHandled = "";
                DeliveryDate = "";
                Currency = "";
                ExchangeRate = 0;
                PriceReduction = 0;
                PayTerm = "";
                DiscountRate = 0;
                Deposit = 0;
                TaxRate =0;
                OtherFees = 0;
                PlansFactoryDate = "";
                FactoryDate = "";
                Transport = "";
                DeliveryAddress = "";
                state =0;
                Directions = "";
                AuditDate = "";
                AuditGuy = "";
                remark = "";
            }
           
        }
    }
}