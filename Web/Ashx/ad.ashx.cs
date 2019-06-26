using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maticsoft.DBUtility;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Text;

using System.Web.Script.Serialization;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ad 的摘要说明
    /// </summary>
    public class ad : IHttpHandler, IReadOnlySessionState
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
            string type = context.Request["action"];
            string revalue="";
            switch (type)
            {
                case"getAllAD":
                    revalue = GetAllAD(context);
                    break;
                case "upload":
                    revalue = UploadImg(context);
                    break;
                case"add_img":
                    revalue = add_img(context);
                    break;
                case"edit_img":
                    revalue = edit_img(context);
                    break;
                case "del":
                    revalue = del_img(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(revalue); 
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string del_img(HttpContext context)
        {
            string v = context.Request["v1"];
            System.IO.File.Delete(context.Server.MapPath(context.Request["v1"]));
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_ad_img", WCDataAction.Delete1);
            dsp.InputPars.Add("@id",context.Request["id"]);
            if (db.Execute(dsp).ExecuteState)
            {
                return "success";
            }
            else
            {
                return "删除失败！";
            }
        }
        private string CheckImgShow(HttpContext context)
        {
            string revalue = "";
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_ad_img", WCDataAction.Query2);
            if (context.Request["img_id"] != "")
            {
                
                dsp.InputPars.Add("@id", context.Request["img_id"]);
            }
            else
            {
                dsp.InputPars.Add("@id", 0);
            }
            if (db.Execute(dsp).ExecuteState)
            {
                revalue = dsp.OutputPars["@Error"].ToString();
            }
            return revalue;
        }
        /// <summary>
        /// 编辑图片基本信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string edit_img(HttpContext context)
        {
            string revalue = "";
            if (context.Session["login"] == null)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('登录信息安全时限过期，请重新登录！');top.location='../Login.aspx'</script>");
            }
            else
            {
                string v1;
                if (context.Request["ckb"] == "on")
                {
                    if (CheckImgShow(context) != "")
                    {
                        return CheckImgShow(context);
                    }
                    //dsp.InputPars.Add("@show", 1);
                }
                //else
                //{
                //    //dsp.InputPars.Add("@show", 0);
                //}
                if (context.Request.Files["uploadify"].FileName.ToString() != "")
                {
                    revalue = UploadImg(context);
                    //HttpPostedFile hpfile = context.Request.Files["uploadify"];
                    //string fileName = hpfile.FileName.Substring(hpfile.FileName.LastIndexOf(".") + 1);
                    string path = ConfigurationManager.AppSettings["ImagPath"];
                    //FileInfo fi = new FileInfo(context.Server.MapPath(path+ context.Request["v1_1"]) );
                    //string v1_1 = context.Request["img_load"];

                    System.IO.File.Delete(context.Server.MapPath(context.Request["img_load"]));
                    v1 = revalue.Split('|')[1];
                }
                else
                {

                    v1 = "";
                }
               
                Model.BaseUser buModel = (Model.BaseUser)context.Session["login"];
                WCDataProvider db = new WCDataProvider();
                WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_ad_img", WCDataAction.Update1);
                dsp.InputPars.Add("@img_name", context.Request["img_name"]);
                dsp.InputPars.Add("@title", context.Request["title"]);
                dsp.InputPars.Add("@CreateUserID", buModel.UserID);
                dsp.InputPars.Add("@v1", v1);
                dsp.InputPars.Add("id", context.Request["img_id"]);
                if (context.Request["ckb"] == "on")
                {
                    if (CheckImgShow(context)!="")
                    {
                        return CheckImgShow (context);
                    }
                    dsp.InputPars.Add("@show", 1);
                }
                else
                {
                    dsp.InputPars.Add("@show", 0);
                }
                if (db.Execute(dsp).ExecuteState)
                {
                    revalue = "|OK|" + dsp.InputPars["@v1"].ToString();
                }
                else
                {
                    revalue = dsp.ErrorMessage;
                }
            }
            return revalue;
        }
        /// <summary>
        /// 保存基本信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string add_img(HttpContext context)
        {
            string revalue = "";
            if (context.Session["login"] == null)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('登录信息安全时限过期，请重新登录！');top.location='../Login.aspx'</script>");
            }
            else
            {
                
                revalue = UploadImg(context);
                if (revalue.Split('|')[0] == "OK")
                {
                    //revalue = "";


                    HttpPostedFile hpfile = context.Request.Files["uploadify"];
                    string fileName = hpfile.FileName.Substring(hpfile.FileName.LastIndexOf("\\") + 1);
                    string path = ConfigurationManager.AppSettings["ImagPath"];
                    Model.BaseUser buModel = (Model.BaseUser)context.Session["login"];
                    WCDataProvider db = new WCDataProvider();
                    WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_ad_img", WCDataAction.Insert1);
                    dsp.InputPars.Add("@img_name", context.Request["img_name"]);
                    dsp.InputPars.Add("@title", context.Request["title"]);
                    dsp.InputPars.Add("@CreateUserID", buModel.UserID);
                    dsp.InputPars.Add("@v1", revalue.Split('|')[1]);
                    if (context.Request["ckb"]=="on")
                    {
                        if (CheckImgShow(context)!="")
                        {
                            return CheckImgShow(context);
                        }
                        dsp.InputPars.Add("@show", 1);
                    }
                    else
                    {
                        dsp.InputPars.Add("@show", 0);
                    }
                    if (db.Execute(dsp).ExecuteState)
                    {
                        revalue = "|OK|"+dsp.InputPars["@v1"].ToString();
                    }
                    else
                    {
                        revalue = dsp.ErrorMessage;
                    }
                }
            }
            return revalue;
        }
        /// <summary>
        /// 提取所有ADImg的详情
        /// </summary>
        /// <param name="context">参数</param>
        /// <returns>datagrid json格式</returns>
        private string GetAllAD(HttpContext context)
        {
            DataTable dt = new DataTable();
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "asc";
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "CreateTime";
            string where = "1=1";
            string table = "ad_img";
            string show = "*,dbo.getName_zxf(CreateUserID) as CreateUser,dbo.getName_zxf(UpdateUserID) as UpdateUser,(case when show=1 then '是' else '否' end) as showname ";

            dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return DataTable2Json_Datagrid(dt, total);
            }

            else
            {
                return "{\"total\":0,\"rows\":[]}";
            }


        }

        public static string DataConversion(string data)
        {
            string str = data;

            str = str.Replace("\\", "\\\\");// 反斜杠\

            str = str.Replace("'", "\'");// 单引号'
            str = str.Replace("\"", "\\\"");// 双引号"      
            str = str.Replace("\n", "\\n");// 换行符n
            str = str.Replace("\r", "\\r");// 回车符r
            str = str.Replace("\t", "\\t");// 横向跳格 (Ctrl-I)
            str = str.Replace("\b", "\\b");// 退格符b
            str = str.Replace("\f", "\\f");// 换页符f
            return str;
        }
        public static string DataTable2Json_Datagrid(DataTable dt, int total)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"total\":" + total.ToString() + ",");
            jsonBuilder.Append("\"rows\"");
            jsonBuilder.Append(":[");
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonBuilder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonBuilder.Append("\"");
                        jsonBuilder.Append(dt.Columns[j].ColumnName);
                        jsonBuilder.Append("\":\"");

                        string str = dt.Rows[i][j].ToString().Trim();
                        if (dt.Columns[j].ColumnName == "v1")
                        {
                            string str1;
                            str = "<img class='img_size' id='img" + i + "'; src='" + str + "'>";
                            jsonBuilder.Append(str);
                            jsonBuilder.Append("\",");
                            str1 = DataConversion(dt.Rows[i][j].ToString().Trim());
                            jsonBuilder.Append("\"");
                            jsonBuilder.Append(dt.Columns[j].ColumnName+"_1");
                            jsonBuilder.Append("\":\"");
                            jsonBuilder.Append(str1);
                            jsonBuilder.Append("\",");
                        }
                        else
                        {
                            str = DataConversion(dt.Rows[i][j].ToString().Trim());
                            jsonBuilder.Append(str);
                            jsonBuilder.Append("\",");
                        }
                        
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        /// <summary>
        /// 上传图片到服务器
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string UploadImg(HttpContext context)
        {
            try
            {
                string t = DateTime.Now.ToString("yyyyMMddhhmmss");
                Random rnd = new Random();
                int i = rnd.Next(100, 999);
                string r = i.ToString();
                HttpPostedFile hpfile = context.Request.Files["uploadify"];
                string fileName = hpfile.FileName.Substring(hpfile.FileName.LastIndexOf(".") + 1);
                //string path = context.Server.MapPath(ConfigurationManager.AppSettings["FolderPath"] + "/"
                string path = context.Server.MapPath(ConfigurationManager.AppSettings["ImagPath"]);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                hpfile.SaveAs(path + "/img" +t+r+"."+fileName );


                context.Response.Write(fileName);
                context.Response.StatusCode = 200;
                return "OK|" + ConfigurationManager.AppSettings["ImagPath"] + "/img" + t + r + "." + fileName;
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