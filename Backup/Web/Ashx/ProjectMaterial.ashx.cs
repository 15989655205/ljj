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
    /// ProjectMaterial 的摘要说明
    /// </summary>
    public class ProjectMaterial : IHttpHandler, IReadOnlySessionState
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
                case "MaterialAList":
                    reValue = MaterialAList(context);
                    break;
                case "isExistProduct":
                    reValue = IsExistProduct(context);
                    break;
                case "ASave":
                    reValue = ASave(context);
                    break;
                case "MaterialAListView":
                    reValue = MaterialAListView(context);
                    break;
                case "MaterialAAduitList":
                    reValue = MaterialAAduitList(context);
                    break;
                case "MaterialBListView":
                    reValue = MaterialBListView(context);
                    break;
                case "save":
                    reValue = Save(context);
                    break;
                case "edit":
                    reValue = Edit(context);
                    break;
                case "submit":
                    reValue = Submit(context);
                    break;
                case "cancelSubmit":
                    reValue = CancelSubmit(context);
                    break;
                case "sh":
                    reValue = Sh(context);
                    break;
                case "RefuseSh":
                    reValue = RefuseSh(context);
                    break;
                case "cancelSh":
                    reValue = CancelSh(context);
                    break;
                case "Check":
                    reValue = Check(context);
                    break;
                case "RefuseJH":
                    reValue = RefuseJH(context);
                    break;
                case "CancelCheck":
                    reValue = CancelCheck(context);
                    break;
                case "GetPM_B_List":
                    reValue = GetPM_B_List(context);
                    break;
                case "GetB":
                    reValue = GetB(context);
                    break;
                case "GetProjectName":
                    reValue= GetProjectName(context);
                    break;
                case "GetProductName":
                    reValue = GetProductName(context);
                    break;
                case "GetSupplier":
                    reValue = GetSupplier(context);
                    break;
                case "BEdit":
                    reValue = EditB(context);
                    break;
                case "GetSupplierTel":
                    reValue = GetSupplierTel(context);
                    break;
                case "MaterialBAduitList":
                    reValue = MaterialBAduitList(context);
                    break;
                case "GetColor":  //获取颜色下拉框数据
                    reValue = GetColor(context);
                    break;
                case "sh_B":  
                    reValue = Sh_B(context);
                    break;
                case "RefuseSh_B": 
                    reValue = RefuseSh_B(context);
                    break;
                case "Check_B": 
                    reValue = Check_B(context);
                    break;
                case "RefuseJH_B":
                    reValue = RefuseJH_B(context);
                    break;
                case "submit_B":
                    reValue = Submit_B(context);
                    break;
                case "cancelSubmit_B":
                    reValue = CancelSubmit_B(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        private string CancelSubmit_B(HttpContext context)
        {

            string sid = context.Request["sid"].ToString();

            WCDataProvider db = new WCDataProvider();


            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update13);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
        }

        private string Submit_B(HttpContext context)
        {

            string sid = context.Request["sid"].ToString();

            WCDataProvider db = new WCDataProvider();


            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update12);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
        }


        private string RefuseJH_B(HttpContext context)
        {

            string sid = context.Request["sid"].ToString();

            WCDataProvider db = new WCDataProvider();


            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update11);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
        }

        private string Check_B(HttpContext context)
        {

            string sid = context.Request["sid"].ToString();

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Process1);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
        }

        private string RefuseSh_B(HttpContext context)
        {

            string sid=context.Request["sid"].ToString();

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update10);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
        }

        private string Sh_B(HttpContext context)
        {
            
            string sid =context.Request["sid"].ToString();

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update9);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
        }
        private string GetColor(HttpContext context)
        {
            DataSet ds = new DAL.Common().GetList("select  ID as colorID,Code,Name  as colorName   from ProductColor");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return JsonHelper.DataTable2Json_Combo(ds.Tables[0]);
                }
                else
                {
                    return "{\"total\":0,\"rows\":[]}";
                }
        }
        private string MaterialBAduitList(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            string spaceID = context.Request.Params["spaceID"] == null ? "" : context.Request.Params["spaceID"].Trim();
            string placeID = context.Request.Params["placeID"] == null ? "" : context.Request.Params["placeID"].Trim();
            string wherestr = context.Request.Params["where"] == null ? "" : context.Request.Params["where"].Trim();
            string me = context.Request.Params["me"] == null ? "" : context.Request.Params["me"].Trim();
            int total = 0;
            string table = "v_ProjectMaterial_SH_B";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string order = "projectName,[space],place";
            string sort = "";
            string where = " 1=1 ";
            if (!string.IsNullOrEmpty(projectID) && projectID != "0")
            {
                where += " and projectID='" + projectID + "'";
            }
            if (!string.IsNullOrEmpty(spaceID) && spaceID != "0")
            {
                where += " and spaceID='" + spaceID + "'";
            }
            if (!string.IsNullOrEmpty(placeID) && placeID != "0")
            {
                where += " and placeID='" + placeID + "'";
            }
            if (!string.IsNullOrEmpty(wherestr))
            {
                where += " and " + wherestr + "";
            }
            if (!string.IsNullOrEmpty(me))
            {
                if (me == "1")
                {
                    where += " and (AuditPerson='" + bu.UserID + "' or checkPerson='" + bu.UserID + "')";
                }
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


        public string GetSupplierTel(HttpContext context)
        {
            //int projectID;
            //int.TryParse(context.Request["projectID"].ToString(), out projectID);
            DataSet ds = new DAL.Common().GetList("select ID spID,Code manufacturerNumber from dbo.Supplier");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string res = JsonHelper.DataTable2Json_Combo(ds.Tables[0]);
                return res;
            }
            else
            {
                return "{\"total\":0,\"rows\":[]}";
            }
        }

        public string EditB(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string updatestr = context.Request.Params["updatestr"].Trim();
            List<Model.v_ProjectMaterialB> update = new List<Model.v_ProjectMaterialB>();
            update = JsonSerializerHelper.JSONStringToList<Model.v_ProjectMaterialB>(updatestr);
            return (new DAL.Project_Product_Material_B().BUpdate(update,bu.UserID.ToString()));
        }

        public string GetSupplier(HttpContext context)
        {
            //int projectID;
            //int.TryParse(context.Request["projectID"].ToString(), out projectID);
            DataSet ds = new DAL.Common().GetList("select ID spID,Code manufacturerNumber,mobile phone,Abbreviation name from dbo.Supplier");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string res = JsonHelper.DataTable2Json_Combo(ds.Tables[0]);
                return res;
            }
            else
            {
                return "{\"total\":0,\"rows\":[]}";
            }
        }

        public string GetProductName(HttpContext context)
        {
            //int projectID;
            //int.TryParse(context.Request["projectID"].ToString(), out projectID);
            DataSet ds = new DAL.Common().GetList("select pt.ID ptID,pt.Name ptName from ProductType pt where Level=1");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["ptID"] = -1;
                dr["ptName"] = "所有";
                dt.Rows.InsertAt(dr, 0);
                string res = JsonHelper.DataTable2Json_Combo(dt);
                return res;
            }
            else
            {
                return "{\"total\":0,\"rows\":[]}";
            }
        }

        public string GetProjectName(HttpContext context)
        {
          DataSet ds=  new DAL.Common().GetList("select sid,project_name from project");
          if (ds.Tables[0].Rows.Count > 0)
          {
              string res = JsonHelper.DataTable2Json_Combo(ds.Tables[0]);
              return res;
          }
          else
          {
              return "{\"total\":0,\"rows\":[]}";
          }
        }

        public string GetB(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Query2);
            
            if (db.Execute(dsp).ExecuteState)
            {
                return "success";
            }

            return "{\"total\":0,\"rows\":[]}";
          

        }

        public string GetPM_B_List(HttpContext context)
        {
            string where = "1=1 ";
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            string ptID = context.Request.Params["ptID"] == null ? "" : context.Request.Params["ptID"].Trim();
            //if (!string.IsNullOrEmpty(projectID))
            //{
            where += " and ProjectID='" + projectID + "' ";
            //}
            if (!string.IsNullOrEmpty(ptID))
            {
                if (ptID != "-1")
                {
                    where += "   and productTypeRootID='" + ptID + "'  ";
                }
            }
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Query3);
            dsp.InputPars.Add("@Where", where);
            dsp.InputPars.Add("@Sort", " productTypeRootID,space,place  ");
            dsp.InputPars.Add("@PageSize", context.Request.Form["rows"]);
            dsp.InputPars.Add("@PageIndex", context.Request.Form["page"]);

            if (db.Execute(dsp).ExecuteState)
            {
                //if (dsp.OutputDataSet.Tables[0].Rows.Count > 0)
                //{
                    return JsonHelper.DataTable2Json_Datagrid(dsp.OutputDataSet.Tables[0], Convert.ToInt32(dsp.OutputPars["@RecordCount"].ToString()));
                //}
            }
            return "{\"total\":0,\"rows\":[]}";
            
        }

        public string MaterialBListView(HttpContext context)
        {
            //string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            //string spaceID = context.Request.Params["spaceID"] == null ? "" : context.Request.Params["spaceID"].Trim();
            //string placeID = context.Request.Params["placeID"] == null ? "" : context.Request.Params["placeID"].Trim();
            //int total = 0;
            //string table = "v_ProjectMaterialA";
            //string show = "*";
            //int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            //int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            //string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = "projectName,[space],place,locationID";
            //string sort = "";
            //string where = " 1=1 and Checking=1 and projectID='" + projectID + "'";
            //if (!string.IsNullOrEmpty(spaceID))
            //{
            //    where += " and spaceID='" + spaceID + "'";
            //}
            //if (!string.IsNullOrEmpty(placeID))
            //{
            //    where += " and placeID='" + placeID + "'";
            //}
            //DataTable dt = new DataTable();

            //DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            //if (ds.Tables.Count > 0)
            //{
            //    dt = ds.Tables[0];
            //}
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
            string where = "1=1 and Checking=1";
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            string ptID = context.Request.Params["ptID"] == null ? "" : context.Request.Params["ptID"].Trim();
            //if (!string.IsNullOrEmpty(projectID))
            //{
            where += " and ProjectID='" + projectID + "' ";
            //}
            if (!string.IsNullOrEmpty(ptID))
            {
                if (ptID != "-1")
                {
                    where += "   and productTypeRootID='" + ptID + "'  ";
                }
            }
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Query4);
            dsp.InputPars.Add("@Where", where);
            dsp.InputPars.Add("@Sort", " productTypeRootID,space,place  ");
            dsp.InputPars.Add("@PageSize", context.Request.Form["rows"]);
            dsp.InputPars.Add("@PageIndex", context.Request.Form["page"]);

            if (db.Execute(dsp).ExecuteState)
            {
                //if (dsp.OutputDataSet.Tables[0].Rows.Count > 0)
                //{
                return JsonHelper.DataTable2Json_Datagrid(dsp.OutputDataSet.Tables[0], Convert.ToInt32(dsp.OutputPars["@RecordCount"].ToString()));
                //}
            }
            return "{\"total\":0,\"rows\":[]}";
        }

        public string RefuseJH(HttpContext context)
        {
            int placeID;
            int sid;
            int.TryParse(context.Request["placeID"], out placeID);
            int.TryParse(context.Request["sid"], out sid);

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update8);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");

            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@projectSpaceID", placeID);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
        }

        public string RefuseSh(HttpContext context)
        {
            int placeID;
            int sid;
            int.TryParse(context.Request["placeID"], out placeID);
            int.TryParse(context.Request["sid"], out sid);

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update7);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@projectSpaceID", placeID);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
        }

        public string CancelCheck(HttpContext context)
        {
            int placeID;
            int sid;
            int.TryParse(context.Request["placeID"], out placeID);
            int.TryParse(context.Request["sid"], out sid);

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update6);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@projectSpaceID", placeID);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }

        }

        public string Check(HttpContext context)
        {
            int placeID;
            int sid;
            int.TryParse(context.Request["placeID"], out placeID);
            int.TryParse(context.Request["sid"], out sid);

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update5);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@projectSpaceID", placeID);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }

        }

        public string CancelSh(HttpContext context)
        {
            int placeID;
            int sid;
            int.TryParse(context.Request["placeID"], out placeID);
            int.TryParse(context.Request["sid"], out sid);

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update4);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@projectSpaceID", placeID);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }

        }

        public string Sh(HttpContext context)
        {
            int placeID;
            int sid;
            int.TryParse(context.Request["placeID"], out placeID);
            int.TryParse(context.Request["sid"], out sid);

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update3);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@projectSpaceID", placeID);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
       
        }
        public string CancelSubmit(HttpContext context)
        {
            int placeID;
            int sid;
            int.TryParse(context.Request["placeID"], out placeID);
            int.TryParse(context.Request["sid"], out sid);

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update2);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@projectSpaceID", placeID);
            dsp.InputPars.Add("@SubmitPerson", ((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
       
        }

        public string Submit(HttpContext context)
        {
            int placeID;
            int sid;
            int.TryParse(context.Request["placeID"], out placeID);
            int.TryParse(context.Request["sid"], out sid);

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Project_Material_Submit", WCDataAction.Update1);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@sid", sid);
            dsp.InputPars.Add("@projectSpaceID",placeID);
            dsp.InputPars.Add("@SubmitPerson",((Model.BaseUser)context.Session["login"]).UserID);
            if (db.Execute(dsp).ExecuteState)
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
            else
            {
                return Convert.ToString(dsp.OutputDataSet.Tables[0].Rows[0]["out_str"].ToString());
            }
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
            if (number != "" && detail != 0 && paintColor != "" && useSpace != "" && spaceCount != "" && install != "" && usePart != "" && unit != "" && amount != "" && paintPaletteNumber != "" && EndProduct != "")
            {

                int pssid = Convert.ToInt32(context.Request["ps_sid"]);   //项目类型
                int parent_sid = Convert.ToInt32(context.Request["parent_sid"]);  //psi --parent_sid
                int ppiSid = Convert.ToInt32(context.Request["ppiSid"]);   //ppiSid 
                int ppSid = Convert.ToInt32(context.Request["ppSid"]); //ppSid

                DataSet ds = new BLL.project_product_item().GetList(" sid=" + ppiSid + "");
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

        public string MaterialAListView(HttpContext context)
        {
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            string spaceID = context.Request.Params["spaceID"] == null ? "" : context.Request.Params["spaceID"].Trim();
            string placeID = context.Request.Params["placeID"] == null ? "" : context.Request.Params["placeID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_ProjectMaterialA";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string order = "projectName,[space],place,locationID";
            string sort = "";
            string where = " 1=1 and Checking=1 and projectID='" + projectID + "'";
            //if (!string.IsNullOrEmpty(projectID))
            //{
            //    where += " and projectID='" + projectID + "'";
            //}
            if (!string.IsNullOrEmpty(spaceID))
            {
                if (spaceID != "0")
                {
                    where += " and spaceID='" + spaceID + "'";
                }
            }
            if (!string.IsNullOrEmpty(placeID))
            {
                if (placeID != "0")
                {
                    where += " and placeID='" + placeID + "'";
                }
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
        }

        private string MaterialAList(HttpContext context)
        {
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            string spaceID = context.Request.Params["spaceID"] == null ? "" : context.Request.Params["spaceID"].Trim();
            string placeID = context.Request.Params["placeID"] == null ? "" : context.Request.Params["placeID"].Trim();
            //string where = " where 1=1 ";
            int total = 0;
            string table = "v_ProjectMaterialA";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string order = "projectName,[space],place,locationID";
            string sort = "";
            string where = " 1=1 ";
            //if (!string.IsNullOrEmpty(projectID))
           // {
                where += " and projectID='" + projectID + "'";
           // }
            if (!string.IsNullOrEmpty(spaceID))
            {
                where += " and spaceID='" + spaceID + "'";
            }
            if (!string.IsNullOrEmpty(placeID))
            {
                where += " and placeID='" + placeID + "'";
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

        private string MaterialAAduitList(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string projectID = context.Request.Params["projectID"] == null ? "" : context.Request.Params["projectID"].Trim();
            string spaceID = context.Request.Params["spaceID"] == null ? "" : context.Request.Params["spaceID"].Trim();
            string placeID = context.Request.Params["placeID"] == null ? "" : context.Request.Params["placeID"].Trim();
            string wherestr = context.Request.Params["where"] == null ? "" : context.Request.Params["where"].Trim();
            string me = context.Request.Params["me"] == null ? "" : context.Request.Params["me"].Trim();
            int total = 0;
            string table = "v_ProjectMaterialA";
            string show = "*";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            //string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            //string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string order = "projectName,[space],place,locationID";
            string sort = "";
            string where = " 1=1 ";
            if (!string.IsNullOrEmpty(projectID)&& projectID!="0")
            {
                where += " and projectID='" + projectID + "'";
            }
            if (!string.IsNullOrEmpty(spaceID) && spaceID != "0")
            {
                where += " and spaceID='" + spaceID + "'";
            }
            if (!string.IsNullOrEmpty(placeID) && placeID != "0")
            {
                where += " and placeID='" + placeID + "'";
            }
            if (!string.IsNullOrEmpty(wherestr))
            {
                where += " and " + wherestr + "";
            }
            if (!string.IsNullOrEmpty(me))
            {
                if (me == "1")
                {
                    where += " and (Auditor='" + bu.UserID + "' or checkPerson='"+bu.UserID+"')";
                }
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

        public string IsExistProduct(HttpContext context)
        {
            //if (!DbHelperSQL.Exists("select count(1) from Project_Product_Material_A where ProductID in(" + context.Request.Params["productID"].Trim() + ") and locationID='" + context.Request.Params["locationID"].Trim() + "' and projectSpaceID='" + context.Request.Params["placeID"].Trim() + "'"))
            //{
            //    return "success";
            //}
            //else
            //{
            //    return "0";
            //}
            string reVal = "";
            try
            {
                DataSet ds = DbHelperSQL.Query("select ProductID,dbo.getProductName_fu(ProductID) from Project_Product_Material_A where ProductID in(" + context.Request.Params["productID"].Trim() + ") and locationID='" + context.Request.Params["locationID"].Trim() + "' and projectSpaceID='" + context.Request.Params["placeID"].Trim() + "'");
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        reVal += dt.Rows[i][0] + ":" + dt.Rows[i][1] + "|";
                    }
                    if (reVal.Length > 0)
                    {
                        reVal = reVal.Remove(reVal.Length - 1);
                    }
                }
            }
            catch
            {
            }
            return reVal;
        }

        private string ASave(HttpContext context)
        {
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.v_ProjectMaterialA> insert = new List<Model.v_ProjectMaterialA>();
            insert = JsonSerializerHelper.JSONStringToList<Model.v_ProjectMaterialA>(addstr);
            List<Model.v_ProjectMaterialA> update = new List<Model.v_ProjectMaterialA>();
            update = JsonSerializerHelper.JSONStringToList<Model.v_ProjectMaterialA>(updatestr);
            List<Model.v_ProjectMaterialA> del = new List<Model.v_ProjectMaterialA>();
            del = JsonSerializerHelper.JSONStringToList<Model.v_ProjectMaterialA>(delstr);
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            return new DAL.Project_Product_Material_A().Save(insert, update, del, bu.UserID.ToString());
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