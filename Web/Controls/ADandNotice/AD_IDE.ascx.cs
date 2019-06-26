using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Maticsoft.Web.Controls.ADandNotice
{
    public partial class AD_IDE : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btn_upload_Click(object sender, EventArgs e)
        //{
        //    string path = ConfigurationManager.AppSettings["ImagPath"];
        //    try
        //    {
        //        if (FileUpload1.PostedFile.FileName == "")
        //        //if (FileUpload1.FileName == "") 
        //        //if (!FileUpload1.HasFile)     //获取一个值，该值指示 System.Web.UI.WebControls.FileUpload 控件是否包含文件。包含文件，则为 true；否则为 false。 
        //        {
        //            this.Upload_info.Text = "请选择上传文件！";
        //        }
        //        else
        //        {
        //            this.Upload_info.Text = "";
        //            string filepath = FileUpload1.PostedFile.FileName;  //得到的是文件的完整路径,包括文件名，如：C:\Documents and Settings\Administrator\My Documents\My Pictures\20022775_m.jpg 
        //            //string filepath = FileUpload1.FileName;               //得到上传的文件名20022775_m.jpg 
        //            string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);//20022775_m.jpg 
        //            string serverpath = Server.MapPath(path) +"\\"+ filename;//取得文件在服务器上保存的位置C:\Inetpub\wwwroot\WebSite1\images\20022775_m.jpg 
        //            FileUpload1.PostedFile.SaveAs(serverpath);//将上传的文件另存为 
        //            this.Upload_info.Text = "上传成功！";

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Upload_info.Text = "上传发生错误！原因是：" + ex.ToString();
        //    }
        //}
       

    }
}