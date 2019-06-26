using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// Employees 的摘要说明
    /// </summary>
    public class Employees : IHttpHandler, IRequiresSessionState
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
            switch (context.Request["action"])
            {
                case "list":
                    reValue = QueryList(context);
                    break;
                case "add":
                    reValue = Add(context);
                    break;
                case "edit":
                    reValue = Update(context);
                    break;
                case "dels":
                    reValue = Dels(context);
                    break;
                case"checkUserName":
                    reValue = checkUserName(context);
                    break;
                case "checkAbbr":
                    reValue = checkAbbr(context);
                    break;
                case "UserDownloadFlag":
                    reValue = GetUserDownloadFlag(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        public string checkUserName(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.BaseUser().GetList("UserName='" + context.Request["UserName"].ToString() + "'").Tables[0];
            if (dt.Rows.Count == 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }

        public string checkAbbr(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.BaseUser().GetList("Value2='" + context.Request["Abbr"].ToString() + "'").Tables[0];
            if (dt.Rows.Count == 0)
            {
                return "success";
            }
            else
            {
                return "fail";
            }
        }

        public string GetUserDownloadFlag(HttpContext context)
        {
            return new BLL.BaseUser().GetUserDownloadFlag((context.Session["login"] as Model.BaseUser).UserID) ? "ok" : "no";
        }

        public string QueryList(HttpContext context)
        {
            string table = " BaseUser ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "WorkID";
            switch (sort)
            {
                case "BloodtypeName": sort = "dbo.getDictCaption(5,Bloodtype)"; break;
                case "PoliticsstatusName": sort = "dbo.getDictCaption(4,Politicsstatus)"; break;
                case "MaritalstatusName": sort = "dbo.getDictCaption(3,Maritalstatus)"; break;
                case "EducationName": sort = "dbo.getDictCaption(6,Education)"; break;
                case "DegreeName": sort = "dbo.getDictCaption(8,Degree)"; break;
                case "StateEmployeesName": sort = "dbo.getDictCaption(7,StateEmployees)"; break;
                case "DeptIDName": sort = "dbo.getDeptNames(DeptID)"; break;
                case "AppRoleIDName": sort = "dbo.getApprove_role(AppRoleID)"; break;
                default: break;
            }
            string show =
                " UserID, WorkID, UserName, Name, Sex, dbo.getDictCaption(2,Sex)SexName, IDCard, CONVERT(NVARCHAR(10),Dataofbirth,120)Dataofbirth, " +
                " Bloodtype, dbo.getDictCaption(5,Bloodtype)BloodtypeName, Pwd, Value1, " +
                " Nativeplace, RegdResd, Address, Nation, Politicsstatus, dbo.getDictCaption(4,Politicsstatus)PoliticsstatusName, " +
                " Maritalstatus, dbo.getDictCaption(3,Maritalstatus)MaritalstatusName, " +
                " Education, dbo.getDictCaption(6,Education)EducationName, Degree, dbo.getDictCaption(8,Degree)DegreeName, Major, " +
                " CONVERT(NVARCHAR(10),GraduationDate,120)GraduationDate, " +
                " Tel, Email, EmContact, EmContactTel, StateEmployees, dbo.getDictCaption(7,StateEmployees)StateEmployeesName, " +
                " CONVERT(NVARCHAR(10),EntryDate,120)EntryDate, CONVERT(NVARCHAR(10),Positivedates,120)Positivedates, " +
                " DeptID, dbo.getDeptNames(DeptID)DeptIDName, AppRoleID, dbo.getApprove_role(AppRoleID)AppRoleIDName, Remark,  Permissions ,Value0,Value2, CreateUser, CreateDate, UpdateUser, UpdateDate";
            int page = context.Request.Form["page"] != null ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != null ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "asc";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : string.Empty;
            string where = " 1=1 ";
            if (!string.IsNullOrWhiteSpace(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " and (" +
                    "     UserName like'%"+key+"%'"+
                    "     or WorkID like '%" + key + "%' " +
                    "     or Name like '%" + key + "%' " +
                    "     or dbo.getDictCaption(2,Sex) like '%" + key + "%' " +
                    "     or IDCard like '%" + key + "%' " +
                    "     or Dataofbirth like '%" + key + "%' " +
                    "     or Bloodtype like '%" + key + "%' " +
                    "     or dbo.getDictCaption(5,Bloodtype) like '%" + key + "%' " +
                    "     or Nativeplace like '%" + key + "%' " +
                    "     or RegdResd like '%" + key + "%' " +
                    "     or Address like '%" + key + "%' " +
                    "     or Nation like '%" + key + "%' " +
                    "     or Politicsstatus like '%" + key + "%' " +
                    "     or Education like '%" + key + "%' " +
                    "     or dbo.getDictCaption(6,Education) like '%" + key + "%' " +
                    "     or dbo.getDictCaption(8,Degree) like '%" + key + "%' " +
                    "     or Tel like '%" + key + "%' " +
                    "     or GraduationDate like '%" + key + "%' " +
                    "     or EntryDate like '%" + key + "%' " +
                    "     or Major like '%" + key + "%' " +
                    "     or Email like '%" + key + "%' " +
                    "     or EmContact like '%" + key + "%' " +
                    "     or EmContactTel like '%" + key + "%' " +
                    "     or dbo.getDictCaption(7,StateEmployees) like '%" + key + "%' " +
                    "     or Positivedates like '%" + key + "%' " +
                    "     or dbo.getApprove_role(AppRoleID) like '%" + key + "%' " +
                    "     or dbo.getDeptNames(DeptID) like '%" + key + "%' " +
                    "     or Remark like '%" + key + "%' " +
                    "     or CreateUser like '%" + key + "%' " +
                    "     or CreateDate like '%" + key + "%' " +
                    "     or UpdateUser like '%" + key + "%' " +
                    "     or UpdateDate like '%" + key + "%' " +
                    " )";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);            
        }

        public string Add(HttpContext context)
        {
            try
            {
                return new BLL.Employees().Add(GetEmployees(context));
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string Update(HttpContext context)
        {
            try
            {
                return new BLL.Employees().Update(GetEmployees(context));
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string Dels(HttpContext context)
        {
            string selectid = context.Request.Params["cbx_select"].Trim();
            return new BLL.Employees().DeleteList(selectid) ? "ok" : "删除失败。";
        }

        public Model.Employees GetEmployees(HttpContext context)
        {
            Model.Employees emp = new Model.Employees();
            emp.UserName = context.Request.Form["txtUserName"].Trim();
            emp.Value2 = context.Request.Form["txtAbbr"].Trim();
            emp.WorkID = context.Request.Form["txtWorkID"].Trim();
            emp.Pwd = string.IsNullOrWhiteSpace(context.Request.Form["hdPwd"])
                ? string.IsNullOrWhiteSpace(context.Request.Form["txtUserName"])
                    ? string.Empty
                    : DBUtility.WcSecurity.Des.Encrypt(context.Request.Form["txtUserName"])
                : context.Request.Form["hdPwd"];
            emp.Name = context.Request.Form["txtName"].Trim();
            emp.IDCard = context.Request.Form["txtIDCard"].Trim();
            emp.Nativeplace = context.Request.Form["txtNativeplace"].Trim();
            emp.RegdResd = context.Request.Form["txtRegdResd"].Trim();
            emp.Address = context.Request.Form["txtAddress"].Trim();
            emp.Nation = context.Request.Form["txtNation"].Trim();
            emp.Major = context.Request.Form["txtMajor"].Trim();
            emp.Tel = context.Request.Form["txtTel"].Trim();
            emp.Email = context.Request.Form["txtEmail"].Trim();
            emp.EmContact = context.Request.Form["txtEmContact"].Trim();
            emp.EmContactTel = context.Request.Form["txtEmContactTel"].Trim();
            emp.Remark = context.Request.Form["txtRemark"].Trim();
            emp.UserID = context.Request["action"] == "edit" ? long.Parse(context.Request.Form["hdID"]) : 0;
            try { emp.Permissions = int.Parse(context.Request.Form["cbPermissions"]); }
            catch { emp.Permissions = 0; }
            try { emp.Value0 = context.Request.Form["Checkbox2"].ToString(); }
            catch { emp.Value0 = "0"; }
            try { emp.Value1 = context.Request.Form["Checkbox3"].ToString(); }
            catch { emp.Value1 = "0"; }
            try { emp.EntryDate = Convert.ToDateTime(context.Request.Form["txtEntryDate"]); }
            catch { }
            try { emp.Positivedates = Convert.ToDateTime(context.Request.Form["txtPositivedates"]); }
            catch { }
            try { emp.Dataofbirth = Convert.ToDateTime(context.Request.Form["txtDataofbirth"]); }
            catch { }
            try { emp.Dataofbirth = Convert.ToDateTime(context.Request.Form["txtGraduationDate"]); }
            catch { }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["txtSex"]))
            {
                emp.Sex = int.Parse(context.Request.Form["txtSex"]);
            }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["txtBloodtype"]))
            {
                emp.Bloodtype = int.Parse(context.Request.Form["txtBloodtype"]);
            }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["txtPoliticsstatus"]))
            {
                emp.Politicsstatus = int.Parse(context.Request.Form["txtPoliticsstatus"]);
            }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["txtMaritalstatus"]))
            {
                emp.Maritalstatus = int.Parse(context.Request.Form["txtMaritalstatus"]);
            }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["txtEducation"]))
            {
                emp.Education = int.Parse(context.Request.Form["txtEducation"]);
            }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["txtDegree"]))
            {
                emp.Degree = int.Parse(context.Request.Form["txtDegree"]);
            }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["txtStateEmployees"]))
            {
                emp.StateEmployees = int.Parse(context.Request.Form["txtStateEmployees"]);
            }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["txtDeptID"]))
            {
                emp.DeptID = int.Parse(context.Request.Form["txtDeptID"]);
            }
            if (!string.IsNullOrWhiteSpace(context.Request.Form["txtAppRoleID"]))
            {
                emp.AppRoleID = int.Parse(context.Request.Form["txtAppRoleID"]);
                emp.ApprRole = context.Request.Form["txtAppRoleID"];
            }
  
            try {emp.CreateUser = ((Model.BaseUser)context.Session["login"]).UserName;}
            catch { }
            try{emp.CreateDate = DateTime.Now;}
            catch { }
            try { emp.UpdateUser = ((Model.BaseUser)context.Session["login"]).UserName; }
                  catch{ }
            try { emp.UpdateDate = DateTime.Now; }
            catch { }
      
            return emp;
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