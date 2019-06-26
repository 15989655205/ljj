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
    /// ProductUnit 的摘要说明
    /// </summary>
    public class ProductUnit : IHttpHandler, IReadOnlySessionState
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
            string msg="";
            string type = context.Request["action"];
            switch (type)
            {
                case "list": msg = List(context);
                    break;
                case "Edit": msg = Edit(context);
                    break;
                default: break;
            }

            context.Response.Write(msg);
        }

        public string List(HttpContext context)
        {
            DataSet ds= new BLL.ProductUnit().GetList("");
            string res= JsonHelper.DataTable2Josn(ds.Tables[0]);
            return res;
        }

        public string Edit(HttpContext context)
        {
            string delstr = context.Request["delstr"].ToString();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            List<Model.ProductUnit> delList = new List<Model.ProductUnit>();
            delList = JsonSerializerHelper.JSONStringToList<Model.ProductUnit>(delstr);
            List<Model.ProductUnit> insert = new List<Model.ProductUnit>();
            insert = JsonSerializerHelper.JSONStringToList<Model.ProductUnit>(addstr);
            List<Model.ProductUnit> updateList = new List<Model.ProductUnit>();
            updateList = JsonSerializerHelper.JSONStringToList<Model.ProductUnit>(updatestr);
            bool res= new DAL.ProductUnit().Edit(insert,updateList,delList,((Model.BaseUser)context.Session["login"]).UserID);
            if (res)
            {
                return "success";
            }
            return "fail";
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