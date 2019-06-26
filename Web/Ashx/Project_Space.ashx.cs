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
    /// Project_Space 的摘要说明
    /// </summary>
    public class Project_Space : IHttpHandler, IRequiresSessionState
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
            string type = context.Request["type"];
            string msg = string.Empty;
            switch(type){
                case "GetList":msg= GetList(context);
                    break;
                case "GetName": msg = GetName(context);
                    break;
                case "saveRow": msg = SaveRow(context);
                    break;
                default: break;
            }

            context.Response.Write(msg);
            
        }



        public string SaveRow(HttpContext context)
        {
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();

            List<Model.Project_Space> all = new List<Model.Project_Space>();
            all = JsonSerializerHelper.JSONStringToList<Model.Project_Space>(allstr);
            int psid;
            int.TryParse(context.Request.Params["psid"].ToString().Trim(), out psid);
            List<Model.Project_Space> insert = new List<Model.Project_Space>();
            insert = JsonSerializerHelper.JSONStringToList<Model.Project_Space>(addstr);
            List<Model.Project_Space> update = new List<Model.Project_Space>();
            update = JsonSerializerHelper.JSONStringToList<Model.Project_Space>(updatestr);
            List<Model.Project_Space> del = new List<Model.Project_Space>();
            del = JsonSerializerHelper.JSONStringToList<Model.Project_Space>(delstr);

            string res = new DAL.Project_Space().Edit(insert, update, del, all,psid);
          return res;
        }
        public string GetName(HttpContext context)
        {
            DataSet ds = new BLL.Project_Space().GetName(" parentID=0");
            string res= JsonHelper.DataTable2Json_Combo(ds.Tables[0]);
            return res;
        }

        public string GetList(HttpContext context)
        {
            int psid;
            //int parentID;
           bool ints= int.TryParse(context.Request["psid"], out  psid);
           // bool ints2= int.TryParse(context.Request["parentID"], out  parentID);
           DataSet ds = new BLL.Project_Space().GetList("ps1.p_sid=" + psid + "  and ps2.parentID=ps1.sid ");
           string res= JsonHelper.DataTable2Josn(ds.Tables[0]);
           return res;

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