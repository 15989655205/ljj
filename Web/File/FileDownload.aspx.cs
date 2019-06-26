using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;

namespace Maticsoft.Web.File
{
    public partial class FileDownload : System.Web.UI.Page
    {
        protected string path = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            path = Server.MapPath(ConfigurationManager.AppSettings["FolderPath"]);
        }

        protected void Button1_Click(object sender, EventArgs e)
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