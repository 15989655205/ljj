using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using Maticsoft.DBUtility;
using System.Text;

namespace Maticsoft.Web
{
    public partial class Desktop : System.Web.UI.Page
    {               
        /// <summary>
        /// 项目公告
        /// </summary>
        protected string projectNotice = string.Empty;
        protected string projectNonticeCount = string.Empty;
        /// <summary>
        /// 未完成项目计划
        /// </summary>
        protected string myProjectPlane = string.Empty;
        protected string myProjectPlaneCount = string.Empty;
        /// <summary>
        /// 待审批项目计划
        /// </summary>
        protected string projectPlanAppr = string.Empty;
        protected string projectPlanApprCount = string.Empty;
        /// <summary>
        /// 待办工作
        /// </summary>
        protected string apprRequest = string.Empty;
        protected string apprRequestCount = string.Empty;
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                Model.BaseUser bu = (Model.BaseUser)Session["login"];
                WCDataProvider db = new WCDataProvider();
                WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Disktop", WCDataAction.Query1);
                dsp.InputPars.Add("@end_date", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                dsp.InputPars.Add("@begin_date", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                dsp.InputPars.Add("@username",bu.UserName);
                dsp.InputPars.Add("@ApprRole", bu.ApprRole);
                dsp.InputPars.Add("@DeptID", bu.DeptID);
                if (db.Execute(dsp).ExecuteState)
                {
                    projectNotice = GetProjectNotice(dsp.OutputDataSet.Tables[0]);
                    projectNonticeCount = dsp.OutputDataSet.Tables[0].Rows.Count.ToString();
                    myProjectPlane = GetMyProjectPlane(dsp.OutputDataSet.Tables[1]);
                    myProjectPlaneCount = dsp.OutputDataSet.Tables[1].Rows.Count.ToString();
                    projectPlanAppr = GetProjectPlanAppr(dsp.OutputDataSet.Tables[2]);
                    projectPlanApprCount = dsp.OutputDataSet.Tables[2].Rows.Count.ToString();
                    apprRequest = GetApprRequest(dsp.OutputDataSet.Tables[3]);
                    apprRequestCount = dsp.OutputDataSet.Tables[3].Rows.Count.ToString();
                }
            }
        }

        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bytelength"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        private string GetStr(string value, int bytelength,bool title)
        {
            int length = Encoding.Default.GetBytes(value).Length;

            if (bytelength <= 2 || value.Length <= 1 || length <= bytelength)
            {
                return title ? "" : value;
            }
            if (title) { return value; }
            bytelength -= 2;
            string text = string.Empty;
            for (int i = 0; i < value.Length && bytelength > 0; i++)
            {
                text += value[i];
                bytelength -= Encoding.Default.GetBytes(value[i].ToString()).Length;
            }
            return text+"…";
        }

        /// <summary>
        /// 项目公告
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetProjectNotice(DataTable dt)
        {
            string pnString = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                pnString += "<tr>";
                pnString +=
                    "<td class='tt_td'>" +
                    "    <label title='" + GetStr(dr["project_code"].ToString(), 8, true) + "'>" +
                    "        " + GetStr(dr["project_code"].ToString(), 8, false) +
                    "    </label>" +
                    "</td>";
                pnString +=
                    "<td class='tt_td'>" +
                    "    <label title='" + GetStr(dr["project_name"].ToString(), 8, true) + "'>" +
                    "        " + GetStr(dr["project_name"].ToString(), 8, false) +
                    "    </label>" +
                    "</td>";
                pnString +=
                    "<td class='tt_td'>" +
                    "    <label title='" + GetStr(dr["stage_name"].ToString(), 8, true) + "'>" +
                    "        " + GetStr(dr["stage_name"].ToString(), 8, false) + 
                    "    </label>" +
                    "</td>";
                pnString +=
                    "<td class='tt_td'>" +
                    "    <label title='" + GetStr(dr["group_name"].ToString(), 8, true) + "'>" +
                    "        " + GetStr(dr["group_name"].ToString(), 8, false) +
                    "    </label>" +
                    "</td>";
                pnString +=
                    "<td class='tt_td'>" +
                    "    <label title='" + GetStr(dr["jobduties_name"].ToString(), 8, true) + "'>" +
                    "        " + GetStr(dr["jobduties_name"].ToString(), 8, false) + 
                    "    </label>" +
                    "</td>";
                pnString +=
                    "<td class='tt_td'>" +
                    "    <label title='" + GetStr(dr["detail_name"].ToString(), 8, true) + "'>" +
                    "        " + GetStr(dr["detail_name"].ToString(), 8, false) +
                    "    </label>" +
                    "</td>";
                pnString += "<td class='tt_td'>" + dr["person"].ToString().Replace("),", ")<br/>") + "</td>";
                switch (dr["review_results"].ToString())
                {
                    case "0":
                        pnString += "<td class='tt_td' style='color:red;'>未完成</td>";
                        pnString += "<td class='tt_td'></td>";
                        break;
                    case "1":
                        pnString += "<td class='tt_td' style='color:green;'>完成</td>";
                        switch (dr["review_status"].ToString())
                        {
                            case "0": pnString += "<td class='tt_td'></td>"; break;
                            case "1": pnString += "<td class='tt_td'><img src='../Images/point/bullet_green.png'/></td>"; break;
                            case "2": pnString += "<td class='tt_td'><img src='../Images/point/bullet_yellow.png'/></td>"; break;
                            case "3": pnString += "<td class='tt_td'><img src='../Images/point/bullet_orange.png'/></td>"; break;
                            case "4": pnString += "<td class='tt_td'><img src='../Images/point/bullet_red.png'/></td>"; break;
                            case "5": pnString += "<td class='tt_td'><img src='../Images/point/bullet_error.png'/></td>"; break;
                            default: pnString += "<td class='tt_td'></td>"; break;
                        }
                        break;
                    default: pnString += "<td class='tt_td'></td>"; break;
                }
                pnString += "    <td class='tt_td'>" + dr["recently_approver"] + "</td>";
                pnString += "    <td class='tt_td'>" + dr["recently_date"] + "</td>";
                pnString +=
                   "<td class='tt_td'>" +
                   "    <label title='" + GetStr(dr["person"].ToString(), 8, true) + "'>" +
                   "        " + GetStr(dr["remark"].ToString(), 12, false) + 
                   "     </label>" +
                   "</td>";
                pnString += "</tr>";
            }
            return pnString;
        }

        /// <summary>
        /// 未完成项目计划
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetMyProjectPlane(DataTable dt)
        {
            string mppString = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                mppString += "<tr>";
                string title = "title='" +
                    dr["project_code"].ToString() + "/" +
                    dr["project_name"].ToString() + "/" +
                    dr["stage_name"].ToString() + "/" +
                    dr["group_name"].ToString() + "/" +
                    dr["jobduties_name"].ToString() + "/" +
                    dr["detail_name"].ToString() + "'";
                string value =
                    GetStr(dr["project_code"].ToString(), 8, false) + " / " +
                    GetStr(dr["project_name"].ToString(), 8, false) + " / " +
                    GetStr(dr["stage_name"].ToString(), 8, false) + " / " +
                    GetStr(dr["group_name"].ToString(), 8, false) + " / " +
                    GetStr(dr["jobduties_name"].ToString(), 8, false) + " / " +
                    GetStr(dr["detail_name"].ToString(), 8, false);
                string onclick = "onclick=\"parent.addTab_Ext('我的项目计划【提交】','/Project/MyProjectPlan_IDE.aspx?si_sid=" + dr["detail_id"] + "',false);\"";
                mppString += "<td class='tt_td' style='text-align:left;'><a href='#' style='text-decoration:none;color:blue;text-align:left;' " + title + " " + onclick + ">" + value + "</a></td>";
                mppString += "<td class='tt_td'>" + dr["names"].ToString().Replace("),", ")<br/>") + "</td>";
                mppString += "<td class='tt_td'>" + dr["begin_date"] + "</td>";
                mppString += "<td class='tt_td'>" + dr["end_date"] + "</td>";
                switch (dr["psiStatus"].ToString())
                {
                    case "":
                    case "null": mppString += "<td class='tt_td'>未提交</td>"; break;
                    case "-1~0": mppString += "<td class='tt_td' style='color:blue;'>已提交(主管未审核)</td>"; break;
                    case "0~0": mppString += "<td class='tt_td' style='color:red;'>主管审核未完成</td>"; break;
                    case "1~0": mppString += "<td class='tt_td' style='color:green;'>主管审核完成</td>"; break;
                    case "1~5": mppString += "<td class='tt_td'><img src='../Images/point/bullet_error.png'/></td>"; break;
                }
                mppString += "</tr>";
            }
            return mppString;
        }
            
        /// <summary>
        /// 待审批项目计划
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetProjectPlanAppr(DataTable dt)
        {
            string ppaString = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                ppaString += "<tr>";
                string title = "title='" +
                    dr["project_code"].ToString() + "/" +
                    dr["project_name"].ToString() + "/" +
                    dr["stage_name"].ToString() + "/" +
                    dr["group_name"].ToString() + "/" +
                    dr["jobduties_name"].ToString() + "/" +
                    dr["detail_name"].ToString() + "'";
                string value =
                    GetStr(dr["project_code"].ToString().Trim(), 8, false).Trim() + " / " +
                    GetStr(dr["project_name"].ToString().Trim(), 8, false).Trim() + " / " +
                    GetStr(dr["stage_name"].ToString().Trim(), 8, false).Trim() + " / " +
                    GetStr(dr["group_name"].ToString().Trim(), 8, false).Trim() + " / " +
                    GetStr(dr["jobduties_name"].ToString().Trim(), 8, false).Trim() + " / " +
                    GetStr(dr["detail_name"].ToString().Trim(), 8, false).Trim();
                string onclick =
                    "onclick=\"parent.addTab_Ext('项目审批【" + GetStr(dr["project_name"].ToString(), 5, false) + "】'," +
                    "'/Project/ProjectPlanAppr_IDE.aspx?type=" + dr["type"] + "&sid=" + dr["detail_id"] + "',false);\"";
                ppaString += "<td class='tt_td' style='text-align:left;'><a href='#' style='text-decoration:none;color:blue;text-align:left;width:100%;' " + title + " " + onclick + ">" + value.Trim() + "</a></td>";                   
                ppaString += "<td class='tt_td'>" + dr["names"].ToString().Replace("),", ")<br/>") + "</td>";
                ppaString += "<td class='tt_td'>" + dr["begin_date"] + "</td>";
                ppaString += "<td class='tt_td'>" + dr["end_date"] + "</td>";
                ppaString += "<td class='tt_td'>" + dr["sumbit_user"] + "</td>";
                ppaString += "<td class='tt_td'>" + dr["sumbit_date"] + "</td>";
                ppaString += "</tr>";
            }
            return ppaString;
        }

        /// <summary>
        /// 待办工作
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetApprRequest(DataTable dt)
        {
            string ppaString = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                ppaString += "<tr>";
                string title = "title='" + GetStr(dr["af_name"].ToString(), 8, true) + "'";
                string value = GetStr(dr["af_name"].ToString(), 8, false);
                string onclick =
                    "onclick=\"parent.addTab_Ext('" + dr["form_name"].ToString() + "【审批】'," +
                    "'/Flow/HandleRequestForm.aspx?type=bl&sid=" + dr["sid"] + "&rfsid=" + dr["rf_sid"] + "&ntsid=" + dr["node_type"] + "&currNode=" + dr["curr_node_no"] + "',false);\"";
                ppaString += "<td class='tt_td'>" + dr["sid"] + "</td>";               
                ppaString +=
                   "<td class='tt_td'>" +
                   "    <label title='" + GetStr(dr["form_name"].ToString(), 8, true) + "'>" +
                   "        " + GetStr(dr["form_name"].ToString(), 8, false) +
                   "    </label>" +
                   "</td>";
                ppaString += "<td class='tt_td' style='text-align:left;'><a href='#' style='text-decoration:none;color:blue;text-align:left;' " + title + " " + onclick + ">" + value + "</a></td>";
                ppaString += "<td class='tt_td'>" + dr["apply_name"] + "</td>";
                ppaString += "<td class='tt_td'>" + dr["DeptName"] + "</td>";
                ppaString += "<td class='tt_td'>" + dr["applicant_date"] + "</td>";
                ppaString += "<td class='tt_td'>" + dr["status_name"] + "</td>";
                ppaString += "<td class='tt_td'>" + dr["curr_node_no"] + "</td>";
                ppaString += "<td class='tt_td'>" + dr["recent_appr"] + "</td>";
                ppaString += "<td class='tt_td'>" + dr["recently_appr_date"] + "</td>";
                ppaString += "</tr>";
            }
            return ppaString;
        }
    }
}