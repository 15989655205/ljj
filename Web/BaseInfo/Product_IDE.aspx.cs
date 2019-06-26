using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Maticsoft.Web.BaseInfo
{
    public partial class Product_IDE : System.Web.UI.Page
    {
        protected static long ProductID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != "")
                {
                    ProductID = Convert.ToInt64(Request.QueryString["id"]);
                }
                else
                {
                    ProductID = 0;
                }
            }
            //if (action == "edit" && id != null)
            //{
           
            //}
        }

        [WebMethod()]
        public static string QueryList(string id, string action)
        {
            //产品ID


           //Convert.ToInt64(context.Request["id"]);
            //动作
            //string action =action context.Request["action"];
            //颜色
            string table = string.Empty;
            //string id = context.Request.Params["id"] == null ? "0" : context.Request.Params["id"].Trim();
            DataSet ds = new DataSet();
            ds = new BLL.Product().GetDataSetByProc(ProductID);
           //table += "{\"table\":";
            table= JsonHelper.DataTable2Josn(ds.Tables[0]);
           // table += "}";
            return table;
            
        }

    }
}