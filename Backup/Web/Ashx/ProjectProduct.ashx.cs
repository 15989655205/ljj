using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using Maticsoft.DBUtility;
using System.IO;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ProjctProduct 的摘要说明
    /// </summary>
    public class ProjctProduct : IHttpHandler, IReadOnlySessionState
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
                case "PPBatchList":
                    reValue = PPBatchList(context);
                    break;
                case "PPEdit":
                    reValue = PPEdit(context);
                    break;
                case "ChangeProcessCategory":
                    reValue = ChangeProcessCategory(context);
                    break;
                case "loadPro":
                   reValue= loadPro(context);
                    break;
                case "save":
                    reValue = Save(context);
                    break;
                case "edit":
                    reValue = Edit(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        public string Edit(HttpContext context)
        {
            string number = context.Request["number"];
            //string projectName = context.Request["projectName"];
            int detail = context.Request["detail"] == "" ? 0 : Convert.ToInt32(context.Request["detail"]);
            string paintColor = context.Request["paintColor"];
            string useSpace = context.Request["useSpace"];
            string spaceCount = context.Request["spaceCount"];
            string install = context.Request["install"];
            string usePart = context.Request["usePart"];
            string unit = context.Request["unit"];
            string amount = context.Request["amount"];
            string paintPaletteNumber = context.Request["paintPaletteNumber"];
            string EndProduct = context.Request["EndProduct"];
            string remark = context.Request["remark"];
            if (number != "" && detail != 0&& paintColor != "" && useSpace != "" && spaceCount != "" && install != "" && usePart != "" && unit != "" && amount != "" && paintPaletteNumber != "" && EndProduct != "")
            {
             
                int pssid = Convert.ToInt32(context.Request["ps_sid"]);   //项目类型
                int parent_sid = Convert.ToInt32(context.Request["parent_sid"]);  //psi --parent_sid
                int ppiSid = Convert.ToInt32(context.Request["ppiSid"]);   //ppiSid 
                int ppSid = Convert.ToInt32(context.Request["ppSid"]); //ppSid

                   DataSet ds= new BLL.project_product_item().GetList(" sid="+ppiSid+"");
                   if (ds.Tables[0].Rows[0]["EndProduct"].ToString() != EndProduct)
                   { }

                Model.project_product_item model = new Model.project_product_item();
                model.number = number;
                //model.projectName = projectName;
                model.paintColor = paintColor;
                model.useSpace = useSpace;
                model.spaceCount = Convert.ToInt32(spaceCount);
                model.install = install;
                model.usePart = usePart;
                model.unit = unit;
                model.amount = Convert.ToInt32(amount);
                model.paintPaletteNumber = paintPaletteNumber;
                model.EndProduct = EndProduct;
                model.remark = remark;
                model.sid = ppiSid;
                model.update_person = ((Model.BaseUser)context.Session["login"]).Name;
                model.update_date = DateTime.Now;
                string result = new BLL.project_product_item().Update(model, detail, pssid, ppiSid, parent_sid, ppSid);
                return result;
            }
            else
            {
                return "*号内容不能为空！";
            }
        }

        public string Save(HttpContext context)
        {
            string number = context.Request["number"];
            string projectName = context.Request["projectName"];
            int detail = context.Request["detail"] == "" ? 0 : Convert.ToInt32(context.Request["detail"]);
            string paintColor = context.Request["paintColor"];
            string useSpace = context.Request["useSpace"];
            string spaceCount = context.Request["spaceCount"];
            string install = context.Request["install"];
            string usePart = context.Request["usePart"];
            string unit = context.Request["unit"];
            string amount = context.Request["amount"];
            string paintPaletteNumber = context.Request["paintPaletteNumber"];
            string EndProduct = context.Request["EndProduct"];
            string remark = context.Request["remark"];
            int pssid = Convert.ToInt32(context.Request["ps_sid"]);   //项目类型
            if (number != "" && detail != 0 && paintColor != "" && useSpace != "" && spaceCount != "" && install != "" && usePart != "" && unit != "" && amount != "" && paintPaletteNumber != "" && EndProduct != "")
            {
            Model.project_product_item model = new Model.project_product_item();
            model.number = number;
            model.projectName = projectName;
            model.paintColor = paintColor;
            model.useSpace = useSpace;
            model.spaceCount = Convert.ToInt32(spaceCount);
            model.install = install;
            model.usePart = usePart;
            model.unit = unit;
            model.amount = Convert.ToInt32(amount);
            model.paintPaletteNumber = paintPaletteNumber;
            model.EndProduct = EndProduct;
            model.remark = remark;
            model.create_person = ((Model.BaseUser)context.Session["login"]).Name;
            model.create_date = DateTime.Now;

      
                int result = new BLL.project_product_item().Add(model, detail, pssid);
                if (result > 0)
                {
                    return "success";
                }
                else
                {
                    return "fail";
                }
            }
            else
            {
                return "*号内容不能为空！";
            }
        }

        public string loadPro(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select ppcs.ID,ppcs.ColorID,ppcs.ProductID, p.Name pName,pc.Name,p.Specifications from ProductItem ppcs"
+" 			left join Product p  on p.ID=ppcs.ProductID "
+" 			left join  ProductColor pc on  pc.ID=ppcs. ColorID  "
+"	where ppcs.ID in("
+ "	select min(ppcs.ID) from ProductItem ppcs"
 +"			left join Product p  on p.ID=ppcs.ProductID "
 +"			left join  ProductColor pc on  pc.ID=ppcs. ColorID  "
+"			group by  p.Name"
+")");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        private string PPBatchList(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select * from v_Project_Product where ps_sid='" + context.Request.Params["pssid"].Trim() + "'");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string PPEdit(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string pssid=context.Request["pssid"]==null?"0":context.Request["pssid"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.ProjectProductStage> insert = new List<Model.ProjectProductStage>();
            insert = JsonSerializerHelper.JSONStringToList<Model.ProjectProductStage>(addstr);
            List<Model.ProjectProductStage> update = new List<Model.ProjectProductStage>();
            update = JsonSerializerHelper.JSONStringToList<Model.ProjectProductStage>(updatestr);
            List<Model.ProjectProductStage> del = new List<Model.ProjectProductStage>();
            del = JsonSerializerHelper.JSONStringToList<Model.ProjectProductStage>(delstr);

            return new BLL.project_product_item().Edit(insert, update, del, bu.UserName, pssid);
        }

        private string ChangeProcessCategory(HttpContext context)
        {
            string pssid = context.Request["pssid"] == null ? "0" : context.Request["pssid"].Trim();
            string csid = context.Request["csid"] == null ? "0" : context.Request["csid"].Trim();
            string result = "";
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_Project", WCDataAction.Update1);
            dsp.InputPars.Add("@s_sid", pssid);
            dsp.InputPars.Add("@ppcm_sid", csid);
            if (db.Execute(dsp).ExecuteState)
            {
                if (dsp.OutputPars["@out_str"].ToString().Trim() == "" || string.IsNullOrEmpty(dsp.OutputPars["@out_str"].ToString()))
                {
                    result = "success";
                }
                else
                {
                    result = dsp.OutputPars["@out_str"].ToString();
                }
            }
            return result;
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