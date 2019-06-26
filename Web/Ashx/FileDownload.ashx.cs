using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// FileDownload 的摘要说明
    /// </summary>
    public class FileDownload : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string write = "ok";
            DataTable dt = new BLL.File().GetDownloadList(context.Request.QueryString["fileid"]).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string fileName = dt.Rows[0]["name"].ToString();
                string filePath = context.Server.MapPath(ConfigurationManager.AppSettings["FolderPath"] + dt.Rows[0]["path"].ToString());
                if (System.IO.File.Exists(filePath))
                {
                    context.Session.Add("download", new string[] { fileName, filePath });
                }
                else
                {
                    write = "文件不存在。";
                }
            }
            else
            {
                write = "文件不存在。";
            }
            context.Response.Write(write);
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