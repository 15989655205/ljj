using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project.Material
{
    public partial class PrintC : System.Web.UI.Page
    {
        protected string productTypeName = "", projectName = "", productPic = "", supplierName = "", supplierMobile = "", supplierAddress = "", supplierContact = "", description = "", brand = "", model = "", size = "", length = "", width = "", height = "", thickness = "", seatHeight = "", seatDeep = "", sample = "", remark = "", tabby = "", drawingby = "", specifiedby = "", approvedby = "", productName = "", materialNo = "", drawingNo = "", drawingArea = "", date = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string projectSpaceID = "", productID = "", Color = "", Size = "", Brand = "",type="";
            type=Request.Params["type"]==null?"":Request.Params["type"].Trim();
            projectSpaceID = Request.Params["projectSpaceID"] == null ? "" : Request.Params["projectSpaceID"].Trim();
            productID = Request.Params["productID"] == null ? "" : Request.Params["productID"].Trim();
            Color = Request.Params["Color"] == null ? "" : Request.Params["Color"].Trim();
            Size = Request.Params["Size"] == null ? "" : Request.Params["Size"].Trim();
            Brand = Request.Params["Brand"] == null ? "" : Request.Params["Brand"].Trim();
            try
            {
                Model.BaseUser bu = (Model.BaseUser)Session["login"];
                tabby = bu.UserName;
            }
            catch
            {
            }
            DataTable dt = new DataTable();
            DataSet ds=new DataSet();
            if (type != "Ptrint_B")
            {
                ds = new BLL.Common().GetList("select *,dbo.getUserName(submitperson) SubmitUser,dbo.getUserName(Auditor) AuditorUser,dbo.getUserName(CheckPerson) CheckUser,(space+'('+place+')')usePlace from v_ProjectMaterialA where projectSpaceID='" + projectSpaceID + "' and productID='" + productID + "' and color='" + Color + "' and size='" + Size + "' and brand='" + Brand + "'");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt.Rows.Count > 0)
                {
                    productTypeName = dt.Rows[0]["productTypeName"].ToString().Trim();
                    projectName = dt.Rows[0]["projectName"].ToString().Trim();
                    productPic = dt.Rows[0]["image"].ToString().Trim();
                    supplierName = dt.Rows[0]["supplierName"].ToString().Trim();
                    supplierMobile = dt.Rows[0]["supplierMobile"].ToString().Trim();
                    supplierAddress = dt.Rows[0]["Address"].ToString().Trim();
                    supplierContact = dt.Rows[0]["Linkman"].ToString().Trim();
                    //description = dt.Rows[0]["image"].ToString().Trim();
                    brand = dt.Rows[0]["BrandB"].ToString().Trim();
                    //model = dt.Rows[0]["image"].ToString().Trim();
                    size = dt.Rows[0]["size"].ToString().Trim();
                    //length = dt.Rows[0]["image"].ToString().Trim();
                    //width = dt.Rows[0]["image"].ToString().Trim();
                    //height = dt.Rows[0]["image"].ToString().Trim();
                    //thickness = dt.Rows[0]["image"].ToString().Trim();
                    //seatHeight = dt.Rows[0]["image"].ToString().Trim();
                    //seatDeep = dt.Rows[0]["image"].ToString().Trim();
                    //sample = dt.Rows[0]["image"].ToString().Trim();
                    remark = dt.Rows[0]["remarkB"].ToString().Trim();
                    //tabby = dt.Rows[0]["image"].ToString().Trim();
                    drawingby = dt.Rows[0]["SubmitUser"].ToString().Trim();
                    specifiedby = dt.Rows[0]["AuditorUser"].ToString().Trim();
                    approvedby = dt.Rows[0]["CheckUser"].ToString().Trim();
                    productName = dt.Rows[0]["productName"].ToString().Trim();
                    materialNo = dt.Rows[0]["productCode"].ToString().Trim();
                    drawingNo = dt.Rows[0]["DrawingNumber"].ToString().Trim();
                    drawingArea = dt.Rows[0]["usePlace"].ToString().Trim();
                    date = DateTime.Now.ToShortDateString(); ;
                }
            }
            else
            {
                ds = new BLL.Common().GetList("select *,dbo.getUserName(submitperson) SubmitUser,dbo.getUserName(AuditPerson) AuditorUser,dbo.getUserName(CheckPerson) CheckUser,(space+'('+place+')')usePlace from v_ProjectMaterialB where SpaceID='" + projectSpaceID + "' and productID='" + productID + "' and colorName='" + Color + "' and size='" + Size + "' and brand='" + Brand + "'");

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt.Rows.Count > 0)
                {
                    productTypeName = dt.Rows[0]["productTypeName"].ToString().Trim();
                    projectName = dt.Rows[0]["project_name"].ToString().Trim();
                    productPic = dt.Rows[0]["image"].ToString().Trim();
                    supplierName = dt.Rows[0]["supplierName"].ToString().Trim();
                    supplierMobile = dt.Rows[0]["supplierMobile"].ToString().Trim();
                    supplierAddress = dt.Rows[0]["Address"].ToString().Trim();
                    supplierContact = dt.Rows[0]["Linkman"].ToString().Trim();
                    //description = dt.Rows[0]["image"].ToString().Trim();
                    brand = dt.Rows[0]["ABrand"].ToString().Trim();
                    //model = dt.Rows[0]["image"].ToString().Trim();
                    size = dt.Rows[0]["Size"].ToString().Trim();
                    //length = dt.Rows[0]["image"].ToString().Trim();
                    //width = dt.Rows[0]["image"].ToString().Trim();
                    //height = dt.Rows[0]["image"].ToString().Trim();
                    //thickness = dt.Rows[0]["image"].ToString().Trim();
                    //seatHeight = dt.Rows[0]["image"].ToString().Trim();
                    //seatDeep = dt.Rows[0]["image"].ToString().Trim();
                    //sample = dt.Rows[0]["image"].ToString().Trim();
                    remark = dt.Rows[0]["remark"].ToString().Trim();
                    //tabby = dt.Rows[0]["image"].ToString().Trim();
                    drawingby = dt.Rows[0]["SubmitPerson"].ToString().Trim();
                    specifiedby = dt.Rows[0]["AuditPerson"].ToString().Trim();
                    approvedby = dt.Rows[0]["CheckPerson"].ToString().Trim();
                    productName = dt.Rows[0]["productName"].ToString().Trim();
                    materialNo = dt.Rows[0]["productCode"].ToString().Trim();
                    drawingNo = dt.Rows[0]["DrawingNumber"].ToString().Trim();
                    //drawingArea = dt.Rows[0]["usePlace"].ToString().Trim();
                    date = DateTime.Now.ToShortDateString(); ;
                }
            }
        }
    }
}