using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Configuration;
using System.Data;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// FileUpload 的摘要说明
    /// </summary>
    public class FileUpload : IHttpHandler,IRequiresSessionState
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
            context.Response.Expires = -1;
            string write = string.Empty;
            switch (context.Request.Form["action"])
            {
                case "upload": write = UploadFile(context); break;
                case "review": write = ReviewFile(context); break;
                default: break;
            }
            context.Response.Write(write);
            context.Response.StatusCode = 200;
        }

        private string UploadFile(HttpContext context)
        {
            try
            {
                HttpPostedFile hpfile = context.Request.Files["Filedata"];                
                string path = context.Server.MapPath(ConfigurationManager.AppSettings["FolderPath"] + "/" + context.Request.Form["folderpath"]);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string kzm = hpfile.FileName.Substring(hpfile.FileName.LastIndexOf('.'));
                string fileName = hpfile.FileName.Remove(hpfile.FileName.LastIndexOf('.'));
                string fn = string.Empty;
                for (int i = 0; System.IO.File.Exists(path + "/" + fileName + fn + kzm); i++)
                {
                    fn = "(" + i + ")";
                }
                fileName = fileName + fn + kzm;
                hpfile.SaveAs(path + "/" + fileName);

                Model.File file = new Model.File();
                file.file_name = hpfile.FileName.Substring(0, hpfile.FileName.LastIndexOf('.')) + fn;
                file.type = hpfile.FileName.Substring(hpfile.FileName.LastIndexOf('.'));
                file.pwdflag = 0;
                file.up_person = Convert.ToInt32((context.Session["login"] as Model.BaseUser).UserID);
                file.up_date = DateTime.Now;
                file.cate_id = int.Parse(context.Request.Form["folderid"]);
                file.activate = 1;
                file.flieGuid = fileName;
                new BLL.File().Add(file);

                return fileName;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        private string ReviewFile(HttpContext context)
        {
            try
            {               
                HttpPostedFile hpfile = context.Request.Files["Filedata"];                
                string path = context.Server.MapPath(ConfigurationManager.AppSettings["FolderPath"] + "/" + context.Request.Form["folderpath"]);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string kzm = hpfile.FileName.Substring(hpfile.FileName.LastIndexOf('.'));
                string fileName = hpfile.FileName.Remove(hpfile.FileName.LastIndexOf('.'));
                string fn = string.Empty;
                for (int i = 0; System.IO.File.Exists(path + "/" + fileName + fn + kzm); i++)
                {
                    fn = "(" + i + ")";
                }
                fileName = fileName + fn + kzm;
                hpfile.SaveAs(path + "/" + fileName);

                Model.File file = new Model.File();
                file.file_name = hpfile.FileName.Substring(0, hpfile.FileName.LastIndexOf('.')) + fn;
                file.type = hpfile.FileName.Substring(hpfile.FileName.LastIndexOf('.'));
                file.pwdflag = 0;
                file.up_person = Convert.ToInt32((context.Session["login"] as Model.BaseUser).UserID);
                file.up_date = DateTime.Now;
                file.cate_id = int.Parse(context.Request.Form["folderid"]);                
                file.flieGuid = fileName;
                file.activate = 1;
                new BLL.File().Add(file);

                DataTable dt = new BLL.File().GetList(" flieGuid='" + fileName + "' ").Tables[0];
                dt.Rows.Add(dt.NewRow());

                return dt.Rows[0]["ID"].ToString() + "|" + fileName;

            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
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