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
    public class ProjectTemplateTrack : IHttpHandler, IReadOnlySessionState
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
                case "ProcessCategoryClassCombo":
                    reValue = ProcessCategoryClassCombo(context);
                    break;
                case "WorkType": reValue = WorkType(); 
                    break;
                case "ReloadTableByType": reValue = ReloadTableByType(context); 
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        public string ProcessCategoryList(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList("select pcm.sid,pcm.category,pcm.v1,bdd.Caption,bdd.Value from project_processing_category_model pcm  INNER JOIN  BaseDictionaryDetail bdd on pcm.v1=bdd.Value where status=1      and type=1 and CatgID=13").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string ProcessCategoryEdit(HttpContext context)
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

        public string WorkBreakdowList(HttpContext context)
        {
            DataTable dt = new DataTable();
            int ppcsid = context.Request.Params["ppcsid"].Trim() == null ? 0 :Convert.ToInt32( context.Request.Params["ppcsid"].Trim() );
            dt = new BLL.Common().GetList("select * from project_pc_work_breakdown_model where status=1 and ppcm_sid='" + ppcsid + "' order by sequence").Tables[0];
            if (dt != null)
            {
                return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
            }
            else
            {
                return "{'total':0,'rows':[]}";
            }
        }

        public string WorkBreakdownEdit(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];

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

            return new DAL.project_pc_work_breakdown_model().Edit(insert, update, del, all, bu.UserName);
        }

        public string ProcessCategoryCombo(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList("select * from project_processing_category_model where status=1  and type=1").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        public string ProcessCategoryClassCombo(HttpContext context)
        {
            string type = context.Request.Params["type"] == null ? "" : context.Request.Params["type"].Trim();
            string where = "";
            DataTable dt = new DataTable();
            if (type != "")
            {
                where = "and v1='"+type+"'";
            }
            dt = new BLL.Common().GetList("select * from project_processing_category_model where status=1  and type=1 "+where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        public string WorkType()
        {
           DataTable dt= new BLL.BaseDictionaryDetail().GetList("  catgID=13").Tables[0];
           dt.Rows.InsertAt(dt.NewRow(), 0);
           dt.Rows[0]["Value"] = -1;
           dt.Rows[0]["Caption"] = "请选择";
           string result= JsonHelper.DataTable2Json_Combo(dt);
            return result;
        }

        public string ReloadTableByType(HttpContext context)
        {
            string v1=string.Empty;
            v1 = context.Request["id"];
            DataTable dt = new BLL.Common().GetList("select pcm.sid,category ,Caption Caption,v1 from project_processing_category_model pcm INNER JOIN  BaseDictionaryDetail bdd on pcm.v1=bdd.Value where status=1      and type=1 and CatgID=13 and v1=" + v1 + "").Tables[0];
            return JsonHelper.DataTable2Josn(dt);
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