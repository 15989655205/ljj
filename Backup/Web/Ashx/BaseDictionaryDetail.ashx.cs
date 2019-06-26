using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// BaseDictionaryDetail 的摘要说明
    /// </summary>
    public class BaseDictionaryDetail : IHttpHandler, IRequiresSessionState
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
            string reValue = string.Empty;
            switch (context.Request["type"])
            {
                case "sex":
                    reValue = GetDictionaryComboBox(2);
                    break;
                case "maritalstatus":
                    reValue = GetDictionaryComboBox(3);
                    break;
                case "politicsstatus":
                    reValue = GetDictionaryComboBox(4);
                    break;
                case "bloodtype":
                    reValue = GetDictionaryComboBox(5);
                    break;
                case "education":
                    reValue = GetDictionaryComboBox(6);
                    break;
                case "stateEmployees":
                    reValue = GetDictionaryComboBox(7);
                    break;
                case "degree":
                    reValue = GetDictionaryComboBox(8);
                    break;
                case "price":
                    reValue = GetDictionaryComboBox(10);
                    break;
                case "ctype":
                    reValue = GetDictionaryComboBox(11);
                    break;
                case "dept":
                    reValue = GetDepartmentCombotree();
                    break;
                case "approle":
                    reValue = GetApprove_roleComboBox();
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string GetDictionaryComboBox(int CatgID)
        {
            DataTable dt = new BLL.BaseDictionaryDetail().GetList(CatgID).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_ValueText(dt, "value", "text");
        }

        private string GetDepartmentCombotree()
        {
            DataTable dt = new BLL.BaseDepartment().GetList(" 1=1 ").Tables[0];
            return new DBUtility.JsonHelper().DataTable2Json_Tree(dt, "DeptID", "DeptName", "ParentDeptID", 0, "", "");
        }

        private string GetApprove_roleComboBox()
        {
            DataTable dt = new BLL.approve_role().GetList(" 1=1 ").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_ValueText(dt, "sid", "role_name");
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