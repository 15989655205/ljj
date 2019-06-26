using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ProductDetail 的摘要说明
    /// </summary>
    public class ProductDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            //if (bu == null)
            //{
            //    context.Response.Write("登录超时，请重新登录。");
            //    return;
            //}
            string reValue = string.Empty;
            switch (context.Request["type"])
            { 
                case "ValuationMethods":
                    reValue = GetProductPriceComboBox();
                    break;
                case "Unit":
                    reValue = GetPriceMethodsComboBox(12);
                    break;
                case "SeriesID":
                    reValue = GetProductSeriesComboBox();
                    break;
                case "Manufacturer":
                    reValue = GetSupplierComboBox();
                    break;
                case "TypeID":
                    reValue = GetProductTypeCombotree();
                    break;
                default: 
                    
                break;
            }
            context.Response.Write(reValue);
        }

        private string GetProductPriceComboBox()
        {
            DataTable dt = new BLL.ProductPriceMethods().GetList("").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_ValueText(dt, "ID", "Name");
        }

        private string GetPriceMethodsComboBox(int CatgID)
        {
            DataTable dt = new BLL.BaseDictionaryDetail().GetList(CatgID).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_ValueText(dt, "value", "text");
        }

        private string GetProductSeriesComboBox()
        {
            DataTable dt = new BLL.ProductSeries().GetList("").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_ValueText(dt, "ID", "Name");
        }

        private string GetSupplierComboBox()
        {
            DataTable dt = new BLL.Supplier().GetList("").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_ValueText(dt, "ID", "FullName");
        }

        private string GetProductTypeCombotree()
        {
            DataTable dt = new BLL.ProductType().GetList("").Tables[0];
            return new DBUtility.JsonHelper().DataTable2Json_Tree(dt, "ID", "Name", "ParentID",0,"","");
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