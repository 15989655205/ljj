using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ProjectTemplateTrack 的摘要说明
    /// </summary>
    public class ProjectTemplatePurchase : IHttpHandler, IReadOnlySessionState
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
                case "ProcessCategoryList":
                    reValue = ProcessCategoryList(context);
                    break;
                case "ProcessCategoryEdit":
                    reValue = ProcessCategoryEdit(context);
                    break;
                case "WorkBreakdowList":
                    reValue = WorkBreakdowList(context);
                    break;
                case "WorkBreakdownEdit":
                    reValue = WorkBreakdownEdit(context);
                    break;
                case "ProcessCategoryCombo":
                    reValue = ProcessCategoryCombo(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        private string ProcessCategoryList(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList("select * from project_processing_category_model where status=1 ").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string ProcessCategoryEdit(HttpContext context)
        {
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_processing_category_model> insert = new List<Model.project_processing_category_model>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_processing_category_model>(addstr);
            List<Model.project_processing_category_model> update = new List<Model.project_processing_category_model>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_processing_category_model>(updatestr);
            List<Model.project_processing_category_model> del = new List<Model.project_processing_category_model>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_processing_category_model>(delstr);

            return new DAL.project_processing_category_model().Edit(insert, update, del);
        }

        private string WorkBreakdowList(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList("select * from project_pc_work_breakdown_model where status=1 and ppcm_sid='" + context.Request.Params["ppcsid"].Trim() + "' order by sequence").Tables[0];
            if (dt != null)
            {
                return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
            }
            else
            {
                return "{'total':0,'rows':[]}";
            }
        }

        private string WorkBreakdownEdit(HttpContext context)
        {
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_pc_work_breakdown_model> insert = new List<Model.project_pc_work_breakdown_model>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_pc_work_breakdown_model>(addstr);
            List<Model.project_pc_work_breakdown_model> update = new List<Model.project_pc_work_breakdown_model>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_pc_work_breakdown_model>(updatestr);
            List<Model.project_pc_work_breakdown_model> del = new List<Model.project_pc_work_breakdown_model>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_pc_work_breakdown_model>(delstr);
            List<Model.project_pc_work_breakdown_model> all = new List<Model.project_pc_work_breakdown_model>();
            all = JsonSerializerHelper.JSONStringToList<Model.project_pc_work_breakdown_model>(allstr);

            return new DAL.project_pc_work_breakdown_model().Edit(insert, update, del,all);
        }

        private string ProcessCategoryCombo(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList("select * from project_processing_category_model where status=1 ").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
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