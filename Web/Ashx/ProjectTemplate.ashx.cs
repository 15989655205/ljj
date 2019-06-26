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
    /// ProjectTemplate 的摘要说明
    /// </summary>
    public class ProjectTemplate : IHttpHandler, IReadOnlySessionState
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
                case "AllTemplateType":
                    reValue = AllTemplateType(context);
                    break;
                case "TemplateEdit":
                    reValue = TemplateEdit(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        private string AllTemplateType(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList("select * from project_template_type ").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string TemplateEdit(HttpContext context)
        {
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.Project_Template_Type> insert = new List<Model.Project_Template_Type>();
            insert = JsonSerializerHelper.JSONStringToList<Model.Project_Template_Type>(addstr);
            List<Model.Project_Template_Type> update = new List<Model.Project_Template_Type>();
            update = JsonSerializerHelper.JSONStringToList<Model.Project_Template_Type>(updatestr);
            List<Model.Project_Template_Type> del = new List<Model.Project_Template_Type>();
            del = JsonSerializerHelper.JSONStringToList<Model.Project_Template_Type>(delstr);

            return new BLL.Project_Template_Type().Edit(insert, update, del);
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