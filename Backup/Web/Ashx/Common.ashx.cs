using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// Common 的摘要说明
    /// </summary>
    public class Common : IHttpHandler, IReadOnlySessionState
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
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();
            DBUtility.JsonHelper jsHelper = new DBUtility.JsonHelper();
            switch(type){
                case "dept_comb":
                    dt = new BLL.BaseDepartment().GetList("1=1").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "role_comb":
                    dt = new BLL.BaseRole().GetList("1=1").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "dept_tree":
                    dt = new BLL.BaseDepartment().GetList("1=1 order by ParentDeptID").Tables[0];
                    sb.Append(jsHelper.DataTable2Json_Tree(dt, "DeptID", "DeptName", "ParentDeptID", 0, "closed", ""));
                    break;
                case "dept_tree_open":
                    dt = new BLL.BaseDepartment().GetList("1=1 order by ParentDeptID").Tables[0];
                    sb.Append(jsHelper.DataTable2Json_Tree(dt, "DeptID", "DeptName", "ParentDeptID", 0, "open", ""));
                    break;
                case "rft_comb":
                    dt = new BLL.request_form_type().GetList("1=1").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "nodeType_comb":
                    dt = new BLL.node_type().GetList("1=1").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "banding_comb":
                    dt = new BLL.approve_role().GetList("1=1 order by role_level asc").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "form_comb":
                    dt = new BLL.request_form().GetList("1=1").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "role_tree":
                    dt = new BLL.BaseMenu().GetList("1=1").Tables[0];
                    sb.Append(jsHelper.DataTable2Json_Tree(dt,"MenuID","MenuName","ParentMenuID","0","",""));
                    break;
                case "dept_users":
                    dt = new BLL.Common().GetList("select UserName,Name from baseuser where deptid in (select * from dbo.getTable(dbo.getdeptids_zxf('" + context.Request["deptid"] + "'),','))").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "get_users":
                    dt = new BLL.Common().GetList("select UserName,Name from baseuser where Permissions=1 order by name ").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "get_stage":
                    dt = new BLL.Common().GetList("select sid,stage_name from stage").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "product_Series":
                    dt = new BLL.Common().GetList("select ID,Name from ProductSeries ").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Josn(dt));
                    break;
                case "product_ValuationMethods":
                    dt = new BLL.Common().GetList("select ID,Name from ProductPriceMethods ").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Josn(dt));
                    break;
                case "product_Unit":
                    dt = new BLL.Common().GetList("select ID as ID,UnitName as Name from dbo.ProductUnit  ").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Josn(dt));
                    break;
                case "product_Manufacturer":
                    dt = new BLL.Common().GetList("select ID,FullName as Name from Supplier order by FullName ").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Josn(dt));
                    break;
                case "productType":
                    dt = new BLL.ProductType().GetList("1=1").Tables[0];
                    sb.Append(jsHelper.DataTable2Json_Tree(dt, "ID", "Name", "ParentID", "0", "", ""));
                    break;
                case "work_users":
                    dt = new BLL.Common().GetList("select UserName,Name from baseuser where UserName in (select implementer_sid from project_work_implement where psi_sid in (select sid from project_specific_item where s_sid =" + context.Request["pssid"] + "))").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "getProject":
                    dt = new BLL.Common().GetList("select sid,project_name name from project").Tables[0];
                    DataRow dr=dt.NewRow();
                    dr[0]="0";
                    dr[1] = "所有";
                    dt.Rows.InsertAt(dr, 0);
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "getSpace":
                    string psid = context.Request["pid"] == null ? "" : context.Request["pid"].Trim();
                    psid = psid == "" ? "0" : psid;
                    dt = new BLL.Common().GetList("select sid, name from project_Space where p_sid='" + psid + "' and ischild=0").Tables[0];
                     dr=dt.NewRow();
                    dr[0]="0";
                    dr[1]="所有";
                    dt.Rows.InsertAt(dr, 0);
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "getPlace":
                    psid = context.Request["pid"] == null ? "" : context.Request["pid"].Trim();
                    psid = psid == "undefined" ? "0" : psid;
                    dt = new BLL.Common().GetList("select sid, name from project_Space where parentID='" + psid + "' and ischild=1").Tables[0];
                     dr=dt.NewRow();
                    dr[0]="0";
                    dr[1] = "所有";
                    dt.Rows.InsertAt(dr, 0);
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                case "getDic":
                    dt = new BLL.Common().GetList("select Value,Caption Text from BaseDictionaryDetail where CatgID='" + context.Request["catg"] + "'").Tables[0];
                    sb.Append(DBUtility.JsonHelper.DataTable2Json_Combo(dt));
                    break;
                default:
                    break;
            }
            context.Response.Write(sb.ToString());
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