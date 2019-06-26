using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;
using System.IO;
using System.Configuration;

namespace Maticsoft.Web.Project111
{
    public partial class ProjectPlanAppr_IDE : System.Web.UI.Page
    {
        protected static DataTable dt = new DataTable();
        protected static string accessory = string.Empty;

        protected static string review_content =  string.Empty;
        protected static string review_accessory = string.Empty;
        protected static string status = string.Empty;

        protected static string review_content1 = string.Empty;
        protected static string review_accessory1 = string.Empty;
        protected static string status1 = string.Empty;
        protected static string review1 = string.Empty;

        protected static string review_content2 =  string.Empty;
        protected static string review_accessory2 = string.Empty;
        protected static string review2 = string.Empty;

        protected string jsStr = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                accessory = string.Empty;

                review_accessory = string.Empty;
                review_content = "<textarea id='review_content' name='review_content' cols='' rows='3' {0} style='width:98%'>{1}</textarea>";                
                status =
                      "<input type='radio' name='review_results' value='1' id='pass'/><label for='pass'>通过</label>&nbsp;&nbsp;" +
                      "<input type='radio' name='review_results' value='0' id='nopass'/><label for='nopass'>不通过</label>";

                review_accessory1 = string.Empty;
                review_content1 = "<textarea id='review_content1' name='review_content' cols='' rows='3' {0} style='width:98%'>{1}</textarea>";               
                status1 =
                    "<input type='radio' name='review_results1' value='1' id='pass'/><label for='pass'>通过</label>&nbsp;&nbsp;" +
                    "<input type='radio' name='review_results1' value='0' id='nopass'/><label for='nopass'>不通过</label>";
                review1 =
                     "<tr>" +
                     "    <td class='TDtitle'>复审意见：</td>" +
                     "    <td class='TDinput' colspan='3'>{0}</td>" +
                     "</tr>" +
                     "<tr>" +
                     "    <td class='TDtitle'>" + (Request.Params["review"] == "2" ? "<a href='#' onclick=\"addfile()\">复审附件：</a>" : "复审附件：") + "</td>" +
                     "    <td class='TDinput' colspan='3'>" +
                     "        <div id='review_file_list1'>{1}</div>" +
                     "    </td>" +
                     "</tr>" +
                     "<tr>" +
                     "    <td class='TDtitle'>复审结果：</td>" +
                     "    <td class='TDinput' colspan='3'>{2}</td>" +
                     "</tr>";

                review_accessory2 = string.Empty;
                review_content2 = "<textarea id='review_content2' name='review_content' cols='' rows='3' {0} style='width:98%'>{1}</textarea>";               
                review2 =
                    "<tr>" +
                    "    <td class='TDtitle'>终审意见：</td>" +
                    "    <td class='TDinput' colspan='3'>{0}</td>" +
                    "</tr>" +
                    "<tr>" +
                    "    <td class='TDtitle'><a href='#' onclick=\"addfile()\">终审附件：</a></td>" +
                    "    <td class='TDinput' colspan='3'>" +
                    "        <div id='review_file_list2'>{1}</div>" +
                    "    </td>" +
                    "</tr>" +
                    "<tr>" +
                    "    <td class='TDtitle'>终审结果：</td>" +
                    "    <td class='TDinput' colspan='3'>" +
                    "        <table bgcolor='#999999' cellpadding='2' cellspacing='1'>" +
                    "            <tr>"+
                    "                <td style='background-color:#e1f5fc;height:25px;text-align:center;'>通&nbsp;&nbsp;过</td>" +
                    "                <td style='background-color:#e1f5fc;height:25px;text-align:center;'>未通过</td></tr>" +
                    "            <tr>" +
                    "                <td style='background-color:#ffffff;height:25px;'>" +
                    "                    <img src='../Images/point/bullet_green.png'/>" +
                    "                    <input type='radio' name='review_results2' value='1' id='Radio1'/>" +
                    "                    <label for='Radio1'>优秀</label>&nbsp;&nbsp;" +
                    "                    <img src='../Images/point/bullet_yellow.png'/>" +
                    "                    <input type='radio' name='review_results2' value='2' id='Radio2'/>" +
                    "                    <label for='Radio2'>一般</label>&nbsp;&nbsp;" +
                    "                    <img src='../Images/point/bullet_orange.png'/>" +
                    "                    <input type='radio' name='review_results2' value='3' id='Radio3'/>" +
                    "                    <label for='Radio3'>较差</label>&nbsp;&nbsp;" +
                    "                    <img src='../Images/point/bullet_red.png'/>" +
                    "                    <input type='radio' name='review_results2' value='4' id='Radio4'/>" +
                    "                    <label for='Radio4'>很差</label>&nbsp;&nbsp;" +
                    "                </td>" +
                    "                <td style='background-color:#ffffff;height:25px;'>" +
                    "                    <img src='../Images/point/bullet_error.png'/>" +
                    "                    <input type='radio' name='review_results2' value='0' id='Radio0'/>" +
                    "                    <label for='Radio0'>未通过</label>&nbsp;&nbsp;" +
                    "                </td>" +
                    "            </tr>" +
                    "        </table>" +
                    "    </td>" +
                    "</tr>";

                #region
                /*
                Model.BaseUser bu = Session["login"] as Model.BaseUser;
                string table =
                " project a " +
                " right outer join project_stage b on a.sid=b.p_sid " +
                " right outer join project_group c on b.sid=c.ps_sid " +
                " right outer join project_specific_item d on c.sid=d.group_sid and d.parent_sid=0 " +
                " right outer join project_specific_item e on d.sid=e.parent_sid " +
                " left outer join project_review f on e.sid=f.si_sid";
                string show =
                " a.sid project_id, project_name, project_code, " +
                " b.sid stage_id, stage_name, " +
                " c.sid group_id, group_name, " +
                " d.sid jobduties_id, d.name jobduties_name, " +
                " e.sid detail_id, e.name detail_name, convert(nvarchar,e.begin_date,23)begin_date, convert(nvarchar,e.end_date,23)end_date," +
                    "dbo.getProImpAndUser_fu(e.sid) as names,dbo.getUsername_fu(sumbit_user) as sumbit_user,sumbit_date," +
                    "review_status,sumbit_content,sumbit_file,f.sid as pr_sid," +
                " dbo.getFilesID(sumbit_file)sumbit_file_id,dbo.getFilesName(f.sumbit_file)sumbit_file_name, dbo.getFilesPath(f.sumbit_file)sumbit_file_path ";
                string where = " 1=1 and (f.sid in(select max(sid) from project_review group by si_sid) or f.sid is null) and ','+e.v1+',' like '%," + bu.UserName + ",%' and e.sid='" + Request.Params["sid"] + "'";
                int total = 0;
                dt = DbHelperSQL.GetList_ProcPage(table, "project_code", show, 1, 1, out total, "asc", where).Tables[0];
                dt.Rows.Add(dt.NewRow());
                string[] filesid = dt.Rows[0]["sumbit_file_id"].ToString().Split(',');
                string[] filesname = dt.Rows[0]["sumbit_file_name"].ToString().Split(':');
                string[] filespath = dt.Rows[0]["sumbit_file_path"].ToString().Split('|');
                accessory = string.Empty;
                for (int i = 0; i < filesname.Length; i++)
                {
                    accessory +=
                        "<img src=\"../uploadify/attach.png\"/>" +
                        "<a herf=\"#\" style=\"cursor:pointer;\" title=\"点击下载附件\" " +
                        "    onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "')\">" + filesname[i].Trim() +
                        "</a>" +
                        "<br/>";
                }
                accessory = string.IsNullOrWhiteSpace(accessory) ? accessory : accessory.Substring(0, accessory.Length - 5);
                */
                #endregion

                #region
                Model.BaseUser bu = Session["login"] as Model.BaseUser;
                string table = " project a " +
                    " join project_stage b on a.sid=b.p_sid " +
                    " join project_group c on b.sid=c.ps_sid " +
                    " join project_specific_item d on c.sid=d.group_sid " +
                    " join project_specific_item e on d.sid=e.parent_sid " +
                    " left join project_review f on e.sid=f.si_sid " +
                    "     and(f.sid in(select max(sid)from project_review group by si_sid)or f.sid is null) ";
                string show =
                    " a.sid project_id, project_code, project_name " +
                    " , b.sid stage_id, stage_name " +
                    " , c.sid group_id, group_name " +
                    " , d.sid jobduties_id, d.name jobduties_name " +
                    " , e.sid detail_id, e.name detail_name, e.appr_results, e.v1 vname " +
                    " , convert(nvarchar,e.begin_date,23)begin_date " +
                    " , convert(nvarchar,e.end_date,23)end_date " +
                    " , dbo.getProImpAndUser_fu(e.sid)names " +
                    " , dbo.getUsername_fu(e.recently_approver)recently_approver " +
                    " , convert(nvarchar,e.recently_date,120)recently_date " +
                    " , f.sid review_id, dbo.getUsername_fu(f.sumbit_user)sumbit_user, sumbit_content " +
                    " , sumbit_file, dbo.getFilesID(sumbit_file)sumbit_file_id " +
                    " , dbo.getFilesName(f.sumbit_file)sumbit_file_name " +
                    " , dbo.getFilesPath(f.sumbit_file)sumbit_file_path " +
                    " , convert(nvarchar,f.sumbit_date,120)sumbit_date " +
                    " , review_results, review_status, review_content, review_file " +
                    " , convert(nvarchar,review_date,120)review_date " +
                    " , dbo.getFilesID(review_file)review_file_id " +
                    " , dbo.getFilesName(f.review_file)review_file_name " +
                    " , dbo.getFilesPath(f.review_file)review_file_path " +
                    " , review_results1, review_status1, review_content1, review_file1 " +
                    " , convert(nvarchar,review_date1,120)review_date1 " +
                    " , dbo.getFilesID(review_file1)review_file_id1 " +
                    " , dbo.getFilesName(f.review_file1)review_file_name1 " +
                    " , dbo.getFilesPath(f.review_file1)review_file_path1 " +
                    " , review_results2, review_status2, review_content2, review_file2 " +
                    " , convert(nvarchar,review_date2,120)review_date2 " +
                    " , dbo.getFilesID(review_file2)review_file_id2 " +
                    " , dbo.getFilesName(f.review_file2)review_file_name2 " +
                    " , dbo.getFilesPath(f.review_file2)review_file_path2 ";
                string where = string.Empty;
                switch (Request.Params["review"])
                {
                    case "1": where = " ','+e.v1+',' like '%," + bu.UserName + ",%' and e.sid='" + Request.Params["sid"] + "'"; break;
                    case "2": where = " ','+e.v2+',' like '%," + bu.UserName + ",%' and e.sid='" + Request.Params["sid"] + "'"; break;
                    case "3": where = " ','+e.v3+',' like '%," + bu.UserName + ",%' and e.sid='" + Request.Params["sid"] + "'"; break;
                    default: return;
                }
                int total = 0;
                dt = DbHelperSQL.GetList_ProcPage(table, "project_code", show, 1, 1, out total, "asc", where).Tables[0];
                dt.Rows.Add(dt.NewRow());
                #endregion

                #region 提交附件

                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["sumbit_file_id"].ToString())
                    && !string.IsNullOrWhiteSpace(dt.Rows[0]["sumbit_file_name"].ToString())
                    && !string.IsNullOrWhiteSpace(dt.Rows[0]["sumbit_file_path"].ToString()))
                {
                    string[] filesid = dt.Rows[0]["sumbit_file_id"].ToString().Split(',');
                    string[] filesname = dt.Rows[0]["sumbit_file_name"].ToString().Split(':');
                    string[] filespath = dt.Rows[0]["sumbit_file_path"].ToString().Split('|');
                    accessory = "<ul id='sumbit_file_list' style='margin:0;paddin:0;margin-left:-28px'>";
                    for (int i = 0; i < filesname.Length; i++)
                    {
                        accessory +=
                            "<li id='sumbit_file_list_sub_" + filesid[i + 1].Trim() + "'>" +
                            "    <img src='../uploadify/attach.png'/>" +
                            "    <a herf='#' style='cursor:pointer;' title='点击下载附件'" +
                            "        onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "')\">" +
                            "        "+filesname[i].Trim() +
                            "    </a>" +
                            "</li>";
                        //'   &nbsp;&nbsp;&nbsp;&nbsp;' +
                        //'   <a href="#" onclick="deletefile(\'filelist_sub' + liid[i + 1] + '\',\'' + liid[i + 1] + '\',\'' + lipath[i] + '\');">' +
                        //'       <img src="../uploadify/del.png"/>' +
                        //'   </a>';
                    }
                    accessory += "</ul>";
                }

                #endregion

                switch (Request.Params["review"])
                {
                    case "1":

                        #region 初审

                        review_content = string.Format(review_content, "", dt.Rows[0]["review_content"].ToString());
                        switch (dt.Rows[0]["review_results"].ToString())
                        {
                            case "0": jsStr = "document.getElementById('nopass').checked=true;"; break;
                            case "1": jsStr = "document.getElementById('pass').checked=true;"; break;
                            default: break;
                        }
                        review_accessory = "<ul id='review_file_list' style='margin:0;margin-left:-28px'>";
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_id"].ToString())
                            && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_name"].ToString())
                            && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_path"].ToString()))
                        {
                            jsStr += "$('#hdreview_file').val('" + dt.Rows[0]["review_file_id"].ToString() + "');";
                            string[] filesid = dt.Rows[0]["review_file_id"].ToString().Split(',');
                            string[] filesname = dt.Rows[0]["review_file_name"].ToString().Split(':');
                            string[] filespath = dt.Rows[0]["review_file_path"].ToString().Split('|');                            
                            for (int i = 0; i < filesname.Length; i++)
                            {
                                review_accessory +=
                                    "<li id='review_file_list_sub_" + filesid[i + 1].Trim() + "'>" +
                                    "    <img src='../uploadify/attach.png'/>" +
                                    "    <a herf='#' style='cursor:pointer;' title='点击下载附件'" +
                                    "        onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "')\">" +
                                    "        " + filesname[i].Trim() +
                                    "    </a>" +
                                    "    &nbsp;&nbsp;&nbsp;&nbsp;" +
                                    "    <a href='#' onclick=\"deletefile('review_file_list_sub_" + filesid[i + 1].Trim() + "'," +
                                    "        '" + filesid[i + 1].Trim() + "','" + filespath[i].Trim() + "');\">" +
                                    "        <img src='../uploadify/del.png'/>" +
                                    "    </a>" +
                                    "</li>";
                            }
                        }
                        review_accessory += "</ul>";
                        hdreview_file.Value = string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_id"].ToString()) ? "," : dt.Rows[0]["review_file_id"].ToString();
                        review1 = string.Empty;
                        review2 = string.Empty;
                        break;

                        #endregion

                    case "2":

                        #region 复审

                        review_content = string.Format(review_content, "readonly='true'", dt.Rows[0]["review_content"].ToString());
                        status = "通过";
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_id"].ToString())
                           && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_name"].ToString())
                           && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_path"].ToString()))
                        {
                            string[] filesid = dt.Rows[0]["review_file_id"].ToString().Split(',');
                            string[] filesname = dt.Rows[0]["review_file_name"].ToString().Split(':');
                            string[] filespath = dt.Rows[0]["review_file_path"].ToString().Split('|');
                            review_accessory = "<ul id='review_file_list' style='margin:0;paddin:0;margin-left:-28px'>";
                            for (int i = 0; i < filesname.Length; i++)
                            {
                                review_accessory +=
                                    "<li id='review_file_list_sub_" + filesid[i + 1].Trim() + "'>" +
                                    "    <img src='../uploadify/attach.png'/>" +
                                    "    <a herf='#' style='cursor:pointer;' title='点击下载附件'" +
                                    "        onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "')\">" +
                                    "        " + filesname[i].Trim() +
                                    "    </a>" +                                 
                                    "</li>";
                            }
                            review_accessory += "</ul>";
                        }

                        review_content1 = string.Format(review_content1, "", dt.Rows[0]["review_content1"].ToString());
                        switch (dt.Rows[0]["review_results1"].ToString()) {
                            case "0": jsStr = "document.getElementById('nopass').checked=true;"; break;
                            case "1": jsStr = "document.getElementById('pass').checked=true;"; break;
                            default: break;
                        }
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_id1"].ToString())
                           && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_name1"].ToString())
                           && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_path1"].ToString()))
                        {
                            jsStr += "$('#hdreview_file1').val('" + dt.Rows[0]["review_file_id1"].ToString() + "');";
                            string[] filesid = dt.Rows[0]["review_file_id1"].ToString().Split(',');
                            string[] filesname = dt.Rows[0]["review_file_name1"].ToString().Split(':');
                            string[] filespath = dt.Rows[0]["review_file_path1"].ToString().Split('|');
                            review_accessory1 = "<ul id='review_file_list1' style='margin:0;paddin:0;margin-left:-28px'>";
                            for (int i = 0; i < filesname.Length; i++)
                            {
                                review_accessory1 +=
                                    "<li id='review_file_list1_sub_" + filesid[i + 1].Trim() + "'>" +
                                    "    <img src='../uploadify/attach.png'/>" +
                                    "    <a herf='#' style='cursor:pointer;' title='点击下载附件'" +
                                    "        onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "')\">" +
                                    "        " + filesname[i].Trim() +
                                    "    </a>" +
                                    "    &nbsp;&nbsp;&nbsp;&nbsp;" +
                                    "    <a href='#' onclick=\"deletefile('review_file_list1_sub_" + filesid[i + 1].Trim() + "'," +
                                    "        '" + filesid[i + 1].Trim() + "','" + filespath[i].Trim() + "');\">" +
                                    "        <img src='../uploadify/del.png'/>" +
                                    "    </a>" +
                                    "</li>";
                            }
                            review_accessory1 += "</ul>";
                        }

                        review2 = string.Empty;
                        break;

                        #endregion

                    case "3":

                        #region 终审

                        review_content = string.Format(review_content, "readonly='true'", dt.Rows[0]["review_content"].ToString());
                        status = "通过";
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_id"].ToString())
                          && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_name"].ToString())
                          && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_path"].ToString()))
                        {
                            string[] filesid = dt.Rows[0]["review_file_id"].ToString().Split(',');
                            string[] filesname = dt.Rows[0]["review_file_name"].ToString().Split(':');
                            string[] filespath = dt.Rows[0]["review_file_path"].ToString().Split('|');
                            review_accessory = "<ul id='review_file_list' style='margin:0;paddin:0;margin-left:-28px'>";
                            for (int i = 0; i < filesname.Length; i++)
                            {
                                review_accessory +=
                                    "<li id='review_file_list_sub_" + filesid[i + 1].Trim() + "'>" +
                                    "    <img src='../uploadify/attach.png'/>" +
                                    "    <a herf='#' style='cursor:pointer;' title='点击下载附件'" +
                                    "        onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "')\">" +
                                    "        " + filesname[i].Trim() +
                                    "    </a>" +
                                    "</li>";
                            }
                            review_accessory += "</ul>";
                        }

                        review_content1 = string.Format(review_content1, "readonly='true'", dt.Rows[0]["review_content1"].ToString());
                        status1 = "通过";
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_id1"].ToString())
                           && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_name1"].ToString())
                           && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_path1"].ToString()))
                        {
                            string[] filesid = dt.Rows[0]["review_file_id1"].ToString().Split(',');
                            string[] filesname = dt.Rows[0]["review_file_name1"].ToString().Split(':');
                            string[] filespath = dt.Rows[0]["review_file_path1"].ToString().Split('|');
                            review_accessory1 = "<ul id='review_file_list1' style='margin:0;paddin:0;margin-left:-28px'>";
                            for (int i = 0; i < filesname.Length; i++)
                            {
                                review_accessory1 +=
                                    "<li id='review_file_list1_sub_" + filesid[i + 1].Trim() + "'>" +
                                    "    <img src='../uploadify/attach.png'/>" +
                                    "    <a herf='#' style='cursor:pointer;' title='点击下载附件'" +
                                    "        onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "')\">" +
                                    "        " + filesname[i].Trim() +
                                    "    </a>" +                                              
                                    "</li>";
                            }
                            review_accessory1 += "</ul>";
                        }

                        review_content2 = string.Format(review_content2, "", dt.Rows[0]["review_content2"].ToString());
                        switch (dt.Rows[0]["review_results2"].ToString()) {
                            case "0": jsStr = "document.getElementById('Radio0').checked=true;"; break;
                            case "1": jsStr = "document.getElementById('Radio1').checked=true;"; break;
                            case "2": jsStr = "document.getElementById('Radio2').checked=true;"; break;
                            case "3": jsStr = "document.getElementById('Radio3').checked=true;"; break;
                            case "4": jsStr = "document.getElementById('Radio4').checked=true;"; break;
                            default: break;
                        }
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_id2"].ToString())
                           && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_name2"].ToString())
                           && !string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_path2"].ToString()))
                        {
                            jsStr += "$('#hdreview_file2').val('" + dt.Rows[0]["review_file_id2"].ToString() + "');";
                            string[] filesid = dt.Rows[0]["review_file_id2"].ToString().Split(',');
                            string[] filesname = dt.Rows[0]["review_file_name2"].ToString().Split(':');
                            string[] filespath = dt.Rows[0]["review_file_path2"].ToString().Split('|');
                            review_accessory2 = "<ul id='review_file_list2' style='margin:0;paddin:0;margin-left:-28px'>";
                            for (int i = 0; i < filesname.Length; i++)
                            {
                                review_accessory2 +=
                                    "<li id='review_file_list2_sub_" + filesid[i + 1].Trim() + "'>" +
                                    "    <img src='../uploadify/attach.png'/>" +
                                    "    <a herf='#' style='cursor:pointer;' title='点击下载附件'" +
                                    "        onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "')\">" +
                                    "        " + filesname[i].Trim() +
                                    "    </a>" +
                                    "    &nbsp;&nbsp;&nbsp;&nbsp;" +
                                    "    <a href='#' onclick=\"deletefile('review_file_list2_sub_" + filesid[i + 1].Trim() + "'," +
                                    "        '" + filesid[i + 1].Trim() + "','" + filespath[i].Trim() + "');\">" +
                                    "        <img src='../uploadify/del.png'/>" +
                                    "    </a>" +
                                    "</li>";
                            }
                            review_accessory2 += "</ul>";
                        }
                        break;

                        #endregion

                    default: break;
                }
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string[] file = hdfile.Value.Split('|');
            string fileName = file[0];
            string filePath = Server.MapPath(ConfigurationManager.AppSettings["FolderPath"] + file[1]);
            if (System.IO.File.Exists(filePath))
            {
                Model.File_Dowm_Detail fdd = new Model.File_Dowm_Detail();
                fdd.dowm_person = Convert.ToInt32((Session["login"] as Model.BaseUser).UserID);
                fdd.dowm_date = DateTime.Now;
                fdd.file_id = int.Parse(file[2]);
                new BLL.File_Dowm_Detail().Add(fdd);

                FileStream fs = new FileStream(filePath, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
                Response.Clear();
                Response.Close();
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>showmsg();</script>");
            }
        }
    }
}