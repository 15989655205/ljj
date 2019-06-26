using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;

namespace UploadifyDemo
{
    /// <summary>
    /// UploadHandler 的摘要说明
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;   //编码方式
            UploadSong(context);
            

        }

        public static void UploadSong(HttpContext context)
        {
            HttpPostedFile file = context.Request.Files["Filedata"];
            string uploadPath = HttpContext.Current.Server.MapPath("\\ProductPic" + "\\");
            long ID =Convert.ToInt64( context.Request["ID"].ToString());
            Maticsoft.Model.ProductColor model = new Maticsoft.Model.ProductColor();
            DataSet ds = new DataSet();
            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                string extName = file.FileName.Substring(file.FileName.LastIndexOf("."));
                string time = DateTime.Now.ToString("yyyyMMddhhmmssf");
                string name = "temp_" + time + extName;
                file.SaveAs(uploadPath + "temp_" + time + extName);
                model.ID = ID;
                model.Image = name;
                ds = new Maticsoft.BLL.ProductColor().UpdateImageByProc(model, "Update3");
                //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                context.Response.Write(context.Request.Params["type"] + "-temp_" + time + extName);
            }
            else
            {
                context.Response.Write("0");
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