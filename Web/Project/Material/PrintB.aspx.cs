using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project.Material
{
    public partial class PrintB : System.Web.UI.Page
    {
        protected string pname = "",fileNo="",productType="";
        protected Model.project pModel = new Model.project();
        protected string trStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string projectID = "", material = "";
                projectID = Request.Params["projectID"] == null ? "" : Request.Params["projectID"].Trim();
                material = Request.Params["material"] == null ? "" : Request.Params["material"].Trim();
                DataTable dt = new DataTable();
                string where = "Checking=1 and projectID='" + projectID + "' and productTypeRootID='" + material + "'";
                string showData = "";
                DataSet ds = new BLL.Common().GetList("select *,(space+'('+place+')')usePlace from v_ProjectMaterialAToB where " + where + " order by spaceID,placeID");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt.Rows.Count > 0)
                {
                    pname = dt.Rows[0]["projectName"].ToString().Trim();
                    productType = dt.Rows[0]["ProductTypeRoot"].ToString().Trim();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        showData += "<tr>";
                        showData += "<td style='text-align: center;'>" + (i+1).ToString() + "</td>";
                        showData += "<td style='text-align: center;'>" + dt.Rows[i]["ProductName"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'></td>";
                        showData += "<td style='text-align:center;'>" + dt.Rows[i]["productCode"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'>" + dt.Rows[i]["Size"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'>" + dt.Rows[i]["usePlace"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'>" + dt.Rows[i]["ColorB"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'>" + dt.Rows[i]["UnitName"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dt.Rows[i]["Amount"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dt.Rows[i]["BrandB"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dt.Rows[i]["SupplierCode"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dt.Rows[i]["supplierName"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dt.Rows[i]["supplierMobile"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dt.Rows[i]["remarkB"].ToString().Trim() + "</td>";
                        showData += "</tr>";
                    }
                }

                string tbCalss = "printinnertable";
                trStr += "<table  height='100%' width='100%'  class='" + tbCalss + "' cellpadding='0' cellspacing='0' border='0'  style='border:0px;' >";
                trStr += "<thead>";
                trStr += "<tr>";
                trStr += "<th style=''>序号</th>";
                trStr += "<th style=''>货品名称</th>";
                trStr += "<th style=''>货品细目</th>";
                trStr += "<th style=''>编号</th>";
                trStr += "<th style=''>规格</th>";
                trStr += "<th style=''>应用空间</th>";
                trStr += "<th style=''>颜色</th>";
                trStr += "<th style=''>单位</th>";
                trStr += "<th style=''>数量</th>";
                trStr += "<th style=''>品牌</th>";
                trStr += "<th style=''>厂商编号</th>";
                trStr += "<th style=''>厂商名称</th>";
                trStr += "<th style=''>厂商电话</th>";
                trStr += "<th style=''>备注</th>";
                trStr += "</tr>";
                trStr += "</thead>";
                trStr += showData;
                trStr += "</table>";
            }
        }
    }
}