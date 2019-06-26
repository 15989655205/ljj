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

namespace Maticsoft.Web.Project
{
    public partial class ProjectPlanAppr_IDE : System.Web.UI.Page
    {
        protected static DataTable dt = new DataTable();
        protected static string accessory = string.Empty;

        protected static string review_content =  string.Empty;
        protected static string review_accessory = string.Empty;
        protected static string status = string.Empty;
        protected static string reason	=string.Empty;
        protected static string solution	=string.Empty;
        protected static string result = string.Empty;
                
        protected static string review_accessory1 = string.Empty;
        protected static string status1 = string.Empty;
        protected static string review1 = string.Empty;

        protected string jsStr = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                accessory = string.Empty;

                review_accessory = string.Empty;
                review_content = "<div style='margin-right:6px'><textarea id='review_content' name='review_content' rows='3' cols='' style='width:100%'>{0}</textarea></div>";
                reason = "<div style='margin-right:6px'><textarea id='reason' name='reason' rows='3' cols='' style='width:100%'>{0}</textarea></div>";
                solution = "<div style='margin-right:6px'><textarea id='solution' name='solution' rows='3' cols='' style='width:100%'>{0}</textarea></div>";
                result = "<div style='margin-right:6px'><textarea id='result' name='result' rows='3' cols='' style='width:100%'>{0}</textarea></div>";
                status =
                      "<input type='radio' id='r_yes' name='review_results' value='1'/><label for='pass'>完成</label>&nbsp;&nbsp;" +
                      "<input type='radio' id='r_no' name='review_results' value='0'/><label for='nopass'>未完成</label>";

                review1 =
                    "<tr>" +
                    "    <td class='TDtitle'>总审意见：</td>" +
                    "    <td class='TDinput' colspan='3'>"+
                    "        <div style='margin-right:6px'><textarea id='review_content1' name='review_content1' cols='' rows='3' style='width:100%'>{0}</textarea></div>" +
                    "    </td>" +
                    "</tr>" +
                    "<tr>" +
                    "    <td class='TDtitle'>"+
                    "        <a href='#' style='text-decoration:none;color:blue;' onclick=\"addfile()\">"+
                    "            <img style='vertical-align:middle' src='../js/themes/icons/attach.png'/>总审附件："+
                    "        </a>"+
                    "    </td>" +
                    "    <td class='TDinput' colspan='3'>" +
                    "        <ul id='review_file_list1' style='margin:0;paddin:0;margin-left:-28px'>{1}</ul>" +
                    "    </td>" +
                    "</tr>" +
                    "<tr>" +
                    "    <td class='TDtitle'>总审结果：</td>" +
                    "    <td class='TDinput' colspan='3'>" +
                    "        <table bgcolor='#999999' cellpadding='2' cellspacing='1'>" +
                    "            <tr>" +
                    "                <td style='background-color:#e1f5fc;height:25px;text-align:center;'>完&nbsp;&nbsp;成</td>" +
                    "                <td style='background-color:#e1f5fc;height:25px;text-align:center;'>未完成</td></tr>" +
                    "            <tr>" +
                    "                <td style='background-color:#ffffff;height:25px;'>" +
                    "                    <img src='../Images/point/bullet_green.png'/>" +
                    "                        <input type='radio' id='r1' name='review_status' value='1'/>" +
                    "                        <label for='r1'>优</label>&nbsp;&nbsp;" +
                    "                    <img src='../Images/point/bullet_yellow.png'/>" +
                    "                        <input type='radio' id='r2' name='review_status' value='2'/>" +
                    "                        <label for='r2'>良</label>&nbsp;&nbsp;" +
                    "                    <img src='../Images/point/bullet_orange.png'/>" +
                    "                        <input type='radio' id='r3' name='review_status' value='3'/>" +
                    "                        <label for='r3'>差</label>&nbsp;&nbsp;" +
                    //"                    <img src='../Images/point/bullet_red.png'/>" +
                    //"                        <input type='radio' id='r4' name='review_status' value='4'/>" +
                    //"                        <label for='r4'>很差</label>&nbsp;&nbsp;" +
                    "                </td>" +
                    "                <td style='background-color:#ffffff;height:25px;'>" +
                    "                    <img src='../Images/point/bullet_error.png'/>" +
                    "                        <input type='radio' id='r5' name='review_status' value='5'/>" +
                    "                        <label for='r5'>不及格</label>&nbsp;&nbsp;" +
                    "                </td>" +
                    "            </tr>" +
                    "        </table>" +
                    "    </td>" +
                    "</tr>";

                #region 提交内容及最后一次审批内容

                Model.BaseUser bu = Session["login"] as Model.BaseUser;
                string where = " type=" + Request.Params["type"] + " and detail_id=" + Request.Params["sid"] + " and ','+vname+',' like '%," + bu.UserName + ",%'";
                int total = 0;
                dt = DbHelperSQL.GetList_ProcPage(" v_project_review ", " orderby ", " * ", 1, 1, out total, "asc", where).Tables[0];
                dt.Rows.Add(dt.NewRow());
                if (!string.IsNullOrWhiteSpace(dt.Rows[0]["sumbit_file_name"].ToString()))
                {
                    string[] filesid = dt.Rows[0]["sumbit_file_id"].ToString().Split(',');
                    string[] filesname = dt.Rows[0]["sumbit_file_name"].ToString().Split(':');
                    string[] filespath = dt.Rows[0]["sumbit_file_path"].ToString().Split('|');
                    accessory = "";
                    for (int i = 0; i < filesname.Length; i++)
                    {
                        accessory +=
                            "<li id='sumbit_file_list_sub_" + filesid[i + 1].Trim() + "'>" +
                            "    <img src='../uploadify/attach.png'/>" +
                            "    <a herf='#' style='cursor:pointer;' title='点击下载附件'" +
                            "        onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "')\">" +
                            "        " + filesname[i].Trim() +
                           // "    </a>&nbsp;&nbsp;<a href='#' class='a' onclick=\"openView('/FileUpload" + filespath[i].Trim() + "','" + filesid[i + 1].Trim() + "')\" >预览</a>&nbsp;&nbsp;<a href='#' class='a' style='cursor:pointer;' onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "');\">下载</a>" +
                            "    </a>&nbsp;&nbsp;<a href='#' class='a' onclick=\"openView('" + filesname[i].Trim() + "','" + filespath[i].Trim() + "','" + filesid[i + 1].Trim() + "')\" >预览</a>&nbsp;&nbsp;<a href='#' class='a' style='cursor:pointer;' onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "');\">下载</a>" +
                            "</li>";
                    }
                }

                #endregion

                switch (Request.Params["type"])
                {
                    case "1":
                        #region 主管审核
                        review_content = string.Format(review_content, dt.Rows[0]["review_content"].ToString());
                        review_accessory = string.Empty;
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_name"].ToString()))
                        {
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
                                    "    </a>&nbsp;&nbsp;<a href='#' class='a' onclick=\"openView('" + filesname[i].Trim() + "','" + filespath[i].Trim() + "','" + filesid[i + 1].Trim() + "')\" >预览</a>&nbsp;&nbsp;<a href='#' class='a' style='cursor:pointer;' onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "');\">下载</a>" +
                                    "    &nbsp;&nbsp;&nbsp;&nbsp;" +
                                    "    <a href='#' onclick=\"deletefile('review_file_list_sub_" + filesid[i + 1].Trim() + "'," +
                                    "        '" + filesid[i + 1].Trim() + "','" + filespath[i].Trim() + "');\">" +
                                    "        <img src='../uploadify/del.png'/>" +
                                    "    </a>" +
                                    "</li>";
                            }
                        }
                        hdfileid.Value = dt.Rows[0]["review_file_id"].ToString();
                        hdreview_file.Value = review_accessory;
                        //status = string.Format(status, dt.Rows[0]["review_results"].ToString() == "1", dt.Rows[0]["review_results"].ToString() == "0");
                        switch (dt.Rows[0]["review_results"].ToString())
                        {
                            case "0": jsStr = "document.getElementById('r_no').checked=true;"; break;
                            case "1": jsStr = "document.getElementById('r_yes').checked=true;"; break;
                        }
                        reason = string.Format(reason, dt.Rows[0]["reason"].ToString());
                        solution = string.Format(solution, dt.Rows[0]["solution"].ToString());
                        result = string.Format(result, dt.Rows[0]["result"].ToString());
                        review1 = string.Empty;
                        #endregion
                        break;
                    case "2":
                        #region 复审
                        #region 主管审核数据
                        review_content = dt.Rows[0]["review_content"].ToString();
                        review_accessory = string.Empty;
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["review_file_name"].ToString()))
                        {
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
                                    "</li>";
                            }
                        }
                        status = "已完成";
                        reason = dt.Rows[0]["reason"].ToString();
                        solution = dt.Rows[0]["solution"].ToString();
                        result = dt.Rows[0]["result"].ToString();

                        #endregion
                        if (!string.IsNullOrWhiteSpace(dt.Rows[0]["review_file1_name"].ToString()))
                        {
                            jsStr += "$('#hdreview_file1').val('" + dt.Rows[0]["review_file1_id"].ToString() + "');";
                            string[] filesid = dt.Rows[0]["review_file1_id"].ToString().Split(',');
                            string[] filesname = dt.Rows[0]["review_file1_name"].ToString().Split(':');
                            string[] filespath = dt.Rows[0]["review_file1_path"].ToString().Split('|');
                            review_accessory1 = string.Empty;
                            for (int i = 0; i < filesname.Length; i++)
                            {
                                review_accessory1 +=
                                    "<li id='review_file_list1_sub_" + filesid[i + 1].Trim() + "'>" +
                                    "    <img src='../uploadify/attach.png'/>" +
                                    "    <a herf='#' style='cursor:pointer;' title='点击下载附件'" +
                                    "        onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "')\">" +
                                    "        " + filesname[i].Trim() +
                                    "    </a>&nbsp;&nbsp;<a href='#' class='a' onclick=\"openView('" + filesname[i].Trim() + "','" + filespath[i].Trim() + "','" + filesid[i + 1].Trim() + "')\" >预览</a>&nbsp;&nbsp;<a href='#' class='a' style='cursor:pointer;' onclick=\"download('" + filesname[i].Trim() + "|" + filespath[i].Trim() + "|" + filesid[i + 1].Trim() + "');\">下载</a>" +
                                    "    &nbsp;&nbsp;&nbsp;&nbsp;" +
                                    "    <a href='#' onclick=\"deletefile('review_file_list1_sub_" + filesid[i + 1].Trim() + "'," +
                                    "        '" + filesid[i + 1].Trim() + "','" + filespath[i].Trim() + "');\">" +
                                    "        <img src='../uploadify/del.png'/>" +
                                    "    </a>" +
                                    "</li>";
                            }
                        }
                        hdfileid1.Value = dt.Rows[0]["review_file1_id"].ToString();
                        hdreview_file1.Value = review_accessory1;
                        review1 = string.Format(review1, dt.Rows[0]["review_content1"].ToString(), review_accessory1);
                        switch (dt.Rows[0]["review_status"].ToString()) {
                            //case "0": jsStr = "document.getElementById('r').checked=true;"; break;
                            case "1": jsStr = "document.getElementById('r1').checked=true;"; break;
                            case "2": jsStr = "document.getElementById('r2').checked=true;"; break;
                            case "3": jsStr = "document.getElementById('r3').checked=true;"; break;
                            //case "4": jsStr = "document.getElementById('r4').checked=true;"; break;
                            case "5": jsStr = "document.getElementById('r5').checked=true;"; break;
                            default: break;
                        }
                        #endregion
                        break;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string fid = hdfid.Value;
                Model.File_Dowm_Detail fdd = new Model.File_Dowm_Detail();
                fdd.dowm_person = Convert.ToInt32((Session["login"] as Model.BaseUser).UserID);
                fdd.dowm_date = DateTime.Now;
                fdd.file_id = int.Parse(fid);
                new BLL.File_Dowm_Detail().Add(fdd);
            }
            catch
            {
            }
        }
    }
}