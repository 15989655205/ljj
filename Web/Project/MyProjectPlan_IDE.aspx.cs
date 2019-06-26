using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.DBUtility;
using System.Configuration;
using System.IO;

namespace Maticsoft.Web.Project
{
    public partial class MyProjectPlan_IDE : System.Web.UI.Page
    {
        protected DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                Model.BaseUser bu = Session["login"] as Model.BaseUser;
                string table =
                    " project a " +
                    " join project_stage b on a.sid=b.p_sid " +
                    " join project_specific_item c on b.sid=c.s_sid " +
                    " join project_specific_item d on c.sid=d.parent_sid and d.sid=" + Request.QueryString["si_sid"] + " " +
                    " join project_work_implement e on d.sid=e.psi_sid and ','+e.implementer_sid+',' like '%," + bu.UserName + ",%' ";
                string show =
                    " a.project_code, a.project_name, b.stage_name, dbo.getProject_groupName(c.group_sid)group_name, " +
                    " c.name jobduties_name, d.sid detail_id, d.name detail_name, dbo.getAllWorkBySi_id_zxf(d.sid)names, " +
                    " convert(nvarchar,d.begin_date,23)begin_date, convert(nvarchar,d.end_date,23)end_date, " +
                    " dbo.getpsiStatus(d.sid)psiStatus ";
                string where = " 1=1 ";
                int total = 0;
                dt = DbHelperSQL.GetList_ProcPage(table, "project_code", show, 1, 1, out total, "asc", where).Tables[0];
                dt.Rows.Add(dt.NewRow());                
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
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
            catch
            {
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                //string fid = hdfid.Value;
                string[] file = hdfile.Value.Split('|');
                Model.File_Dowm_Detail fdd = new Model.File_Dowm_Detail();
                fdd.dowm_person = Convert.ToInt32((Session["login"] as Model.BaseUser).UserID);
                fdd.dowm_date = DateTime.Now;
                fdd.file_id = int.Parse(file[2]);
                new BLL.File_Dowm_Detail().Add(fdd);

                //Response.Write("<script>var nw = window.open('/FileUpload" + file[1] + "', 'big', 'top=0, left=0, toolbar=no, menubar=yes, scrollbars=yes, resizable=yes,location=no, status=no,channelmode = yes');try {nw.document.title = '预览';} catch (e) {}</script>");
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>openViewShow('/FileUpload" + file[1] + "');</script>");
            }
            catch
            {
            }
        }
    }
}