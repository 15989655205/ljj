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
    /// UserList 的摘要说明
    /// </summary>
    public class UserList : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request["action"];
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            if (bu == null && type != "login")
            {
                context.Response.Write("登录超时，请重新登录。");
                return;
            }
            
            string reValue = "";
            switch (type)
            {
                case "list":
                    reValue = QueryList(context);
                    break;
                case "edit":
                    reValue = Edit(context);
                    break;
               case "login":
                    reValue = Login(context);
                    break;
                case "password":
                    reValue = Password(context);
                    break;
                case "checkWorkID":
                    reValue = CheckWorkID(context);
                    break;
                case"checkPWD":
                    reValue = CheckPWD(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        

        

        private string QueryList(HttpContext context)
        {
            string table = " BaseUser ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "CreatedDate";
            switch (sort)
            {
                case "DeptName": sort = "dbo.getDeptNames(DeptID)"; break;
                case "RoleName": sort = "dbo.getRoleName(Roles)"; break;
                case "AppRoleName": sort = "dbo.getApprove_role(AppRoleID)"; break;
                default: break;
            }
            string show =
                " UserID, UserName, Roles, dbo.getRoleName(Roles)RoleName, dbo.getDeptNames(DeptID)DeptName, " +
                " dbo.getApprove_role(AppRoleID)AppRoleName, Name, Tel, WorkID, Pwd, Permissions ";
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string where = " 1=1 ";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : string.Empty;
            if (!string.IsNullOrWhiteSpace(key))
            {
                where +=
                    " and ( " +
                    "     UserID like '%" + key + "%' " +
                    "     or dbo.getDeptNames(DeptID) like '%" + key + "%' " +
                    "     or dbo.getRoleName(Roles)  like '%" + key + "%' " +
                    "     or UserName like '%" + key + "%' " +
                    "     or [Name] like '%" + key + "%' " +
                    "     or Tel like '%" + key + "%' " +
                    "     or WorkID like '%" + key + "%' " +
                    "     or dbo.getApprove_role(AppRoleID) like '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string Edit(HttpContext context)
        {
            Model.BaseUser buModel = new Model.BaseUser();
            try { buModel.Permissions = int.Parse(context.Request.Form["cbPermissions"]); }
            catch { buModel.Permissions = 0; }
            buModel.UserID = long.Parse(context.Request.Form["hdUserID"]);
            buModel.UserName = context.Request.Form["txtUserName"].Replace("'", "''").Trim();
            buModel.Pwd = string.IsNullOrWhiteSpace(context.Request.Form["hdPwd"]) ? DBUtility.WcSecurity.Des.Encrypt(buModel.UserName) : context.Request.Form["hdPwd"];
            buModel.Roles = context.Request.Form["txtRoles"].Trim();
            int flag = new BLL.BaseUser().Update(buModel);
            return flag > 0 ? "ok" : flag == 0 ? "保存失败。" : "【登录账号】“" + buModel.UserName + "”已存在。";
        }

        private string Dels(HttpContext context)
        {
            string selectid = context.Request.Params["cbx_select"].Trim();
            return new BLL.BaseUser().Deletes(selectid);
        }

        private string Login(HttpContext context)
        {
            string user = context.Request["user"].Trim();
            string pwd = DBUtility.WcSecurity.Des.Encrypt(context.Request["pwd"].Trim());
            Model.BaseUser userModel = new BLL.BaseUser().GetModel(user);
            if (userModel != null)
            {
                if (userModel.Permissions==0)
                {
                    return "该账号未激活！";
                }
                if (userModel.Pwd == pwd)
                {
                    context.Session.Timeout = 1440;//1440最大值
                    context.Session["login"] = userModel;
                    return "success";
                }
                else
                {
                    return "密码不正确！";
                }
            }
            else
            {
                return "帐号不存在！";
            }
        }

        private string Password(HttpContext context)
        {
            string uid = context.Request["uid"].Trim();
            Model.BaseUser buModel = new BLL.BaseUser().GetModel(int.Parse(uid));
            buModel.Pwd = DBUtility.WcSecurity.Des.Encrypt(context.Request["newpass"].Trim());
            int flag = new BLL.BaseUser().Update(buModel);
            return flag > 0 ? "success" : flag == 0 ? "修改失败。" : "账号不存在。";
        }
        /// <summary>
        /// 检查工号是否存在(create by zxf)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string CheckWorkID(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt =new BLL.BaseUser().GetList("WorkID='" + context.Request["WorkID"].ToString()+"'").Tables[0];
            if (dt.Rows.Count==0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }
        /// <summary>
        /// 检查密码是否正确（create by zxf）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string CheckPWD(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.BaseUser().GetList("UserID=" + context.Request["userID"].ToString() + " and UserName='" + context.Request["userName"].ToString() + "' and Pwd='" + DBUtility.WcSecurity.Des.Encrypt(context.Request["pwd"].Trim()) + "'").Tables[0];
            if (dt.Rows.Count == 1)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
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