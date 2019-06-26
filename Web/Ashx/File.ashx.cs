using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;
using Maticsoft.DBUtility;
using System.Configuration;
using System.IO;
using System.Text;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// File 的摘要说明
    /// </summary>
    public class File : IHttpHandler, IRequiresSessionState
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
            string reValue = string.Empty;
            string type = context.Request["action"];
            type = string.IsNullOrWhiteSpace(type) ? context.Request.Params["action"] : type;
            switch (type)
            {
                case "list":
                    reValue = QueryList(context);
                    break;
                case "activate":
                    reValue = QueryListByActivate(context);
                    break;
                case "listbyuser":
                    reValue = QueryListByUser(context);
                    break;
                case "edit":
                    reValue = Edit(context);
                    break;
                case "update":
                    reValue = Update(context);
                    break;
                case "del":
                    reValue = Del(context);
                    break;  
                case "dels":
                    reValue = Dels(context);
                    break;             
                case "folder_uploade":
                    reValue = QueryFolderByUser(context);
                    break;
                case "file_download":
                    reValue = QueryFile_Download(context);
                    break;
                case "downloadlist":
                    reValue = QueryDownloadList(context);
                    break;
                case "sub_downloadlist":
                    reValue = QuerySubDownloadList(context);
                    break;
                case "fileDownloadCount":
                    reValue = FileDownloadCount(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            string table = " [File] ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "up_date";
            switch (sort)
            {
                case "up_personName": sort = "dbo.getUserName(up_person)"; break;
                case "cate_idName": sort = "dbo.getFolderName(cate_id)"; break;
                case "count": sort = "dbo.getFileDownloadCount(ID)"; break;
                default: break;
            }
            string show =
                 " ID, file_name, type, pwd, pwdflag, up_person, convert(nvarchar,up_date,120)up_date, updata_person, convert(nvarchar,updata_datetiem,120)updata_datetiem, dbo.getUserName(up_person)up_personName, " +
                 " cate_id, dbo.getFolderName(cate_id)cate_idName, flieGuid, withoutID, activate, Remark, dbo.getFileDownloadCount(ID)count, " +
                 " dbo.getFolderPath(cate_id)+'/'+flieGuid Path ";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string where = " 1=1 ";// " 1=1 and activate=1 ";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " and (" +                  
                    "     file_name like '%" + key + "%' " +
                    "     or type like '%" + key + "%' " +
                    "     or convert(nvarchar,up_date,120) like '%" + key + "%' " +
                    "     or dbo.getUserName(up_person) like '%" + key + "%' " +
                    "     or dbo.getFolderName(cate_id) like '%" + key + "%' " +
                    "     or dbo.getFileDownloadCount(ID) like '%" + key + "%' " +
                    "     or Remark like '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DTtoJson_Datagrid(dt, total);
        }

        private string QueryFile_Download(HttpContext context)
        {
            string table = " [file] fi JOIN folder fo on fi.cate_id=fo.ID ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "up_date";
            switch (sort)
            {
                case "up_personName": sort = "dbo.getUserName(up_person)"; break;
                case "cate_idName": sort = "replace(folder_path,'/',' | ')"; break;
                case "count": sort = "dbo.getFileDownloadCount(fi.ID)"; break;
                default: break;
            }
            string show =
                 " fi.ID, file_name, type, pwd, pwdflag, up_person, convert(nvarchar,up_date,120)up_date, updata_person, convert(nvarchar,updata_datetiem,120)updata_datetiem, dbo.getUserName(up_person)up_personName, " +
                 " cate_id, flieGuid, withoutID, activate, fi.Remark, dbo.getFileDownloadCount(fi.ID)count, replace(folder_path,'/',' | ')cate_idName, " +
                 " folder_path+'/'+flieGuid Path ";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string where = " 1=1 and dowm_permission like '%," + (context.Session["login"] as Model.BaseUser).UserID + ",%'";// and activate=1
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " and (" +                   
                    "     file_name like '%" + key + "%' " +
                    "     or type like '%" + key + "%' " +
                    "     or convert(nvarchar,up_date,120) like '%" + key + "%' " +
                    "     or dbo.getUserName(up_person) like '%" + key + "%' " +
                    "     or replace(folder_path,'/',' | ') like '%" + key + "%' " +
                    "     or dbo.getFileDownloadCount(fi.ID) like '%" + key + "%' " +
                    "     or fi.Remark like '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DTtoJson_Datagrid(dt, total);
        }

        private string DTtoJson_Datagrid(DataTable dt, int total)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"total\":" + total.ToString() + ",\"rows\":[");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    jsonBuilder.Append("{");                   
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        jsonBuilder.Append("\"" + dt.Columns[i].ColumnName + "\":\"" + dr[i] + "\",");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();
        }

        private string QueryListByUser(HttpContext context)
        {
            string table = " [File] fi JOIN folder on fi.cate_id=folder.ID";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "up_date";
            switch (sort)
            {
                case "cate_idName": sort = "replace(dbo.getFolderPath(fi.cate_id),'/',' | ')"; break;
                case "count": sort = "dbo.getFileDownloadCount(fi.ID)"; break;
                default: break;
            }
            string show =
                " fi.ID,fi.file_name, fi.type, replace(dbo.getFolderPath(fi.cate_id),'/',' | ')cate_idName, fi.pwd, fi.pwdflag, convert(nvarchar,fi.up_date,120)up_date, convert(nvarchar,fi.updata_datetiem,120)updata_datetiem,  fi.Remark, " +
                " dbo.getFileDownloadCount(fi.ID)count, folder_path+'/'+flieGuid Path ";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string where = " 1=1 AND  fi.up_person=" + (context.Session["login"] as Model.BaseUser).UserID + " ";//AND activate=1 
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";           
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " AND (fi.file_name LIKE '%" + key + "%' " +
                    "     OR fi.type LIKE '%" + key + "%' " +
                    "     OR convaert(nvarchar,fi.up_date,120) LIKE '%" + key + "%' " +
                    "     OR fi.updata_datetiem LIKE '%" + key + "%' " +
                    "     OR replace(dbo.getFolderPath(fi.cate_id),'/',' | ') LIKE '%" + key + "%' " +
                    "     or dbo.getFileDownloadCount(fi.ID) like '%" + key + "%' " +
                    "     OR fi.Remark LIKE '" + key + "' " +
                    " ) ";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string QueryListByActivate(HttpContext context)
        {
            string table = " [File] ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "up_date";
            switch (sort)
            {                
                case "cate_idName": sort = "dbo.getFolderName(cate_id)"; break;
                default: break;
            }
            string show = " ID, file_name, type, pwd, pwdflag, up_date, dbo.getFolderName(cate_id)cate_idName, Remark ";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string where = " 1=1 AND up_person=" + (context.Session["login"] as Model.BaseUser).UserID + " ";//AND activate=0 
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";       
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " AND (file_name LIKE '%" + key + "%' " +
                    "     OR type LIKE '%" + key + "%' " +
                    "     OR up_date LIKE '%" + key + "%' " +
                    "     OR dbo.getFolderName(cate_id) LIKE '%" + key + "%' " +
                    "     OR Remark LIKE '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string QueryFolderByUser(HttpContext context)
        {
            string table = " folder ";
            string show =
                 " ID, folder_name, folder_path, REPLACE(folder_path,'/','|')folderpath ";
            int total = 0;
            string where = " up_permission like '%," + (context.Session["login"] as Model.BaseUser).UserID + ",%' ";
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, " folder_path ", show, 1, int.MaxValue, out total, " asc ", where).Tables[0];
            return DTtoJson_Datagrid(dt, total);
        }

        private string QueryDownloadList(HttpContext context)
        {
            string table = " [File] fi JOIN folder fo on fi.cate_id=fo.ID ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "fi.up_date";
            switch (sort)
            {
                case "path": sort = "replace(dbo.getFolderPath(fi.cate_id),'/',' | ')"; break;
                case "count": sort = "dbo.getFileDownloadCount(fi.ID)"; break;
                case "UserName": sort = "dbo.getUserName(fi.up_person)"; break;
                default: break;
            }
            string show = " fi.ID, fi.file_name, fi.type, convert(nvarchar,fi.up_date,120)up_date, replace(dbo.getFolderPath(fi.cate_id),'/',' | ')path, dbo.getFileDownloadCount(fi.ID)count,  dbo.getUserName(fi.up_person)UserName , fo.folder_path+'/'+fi.flieGuid filePath";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string where = " 1=1 and dbo.getFileDownloadCount(fi.ID)>0 ";
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " AND(file_name LIKE '%" + key + "%' " +
                    "     OR fi.type LIKE '%" + key + "%' " +
                    "     OR convert(nvarchar,fi.up_date,120) LIKE '%" + key + "%' " +
                    "     OR replace(dbo.getFolderPath(fi.cate_id),'/',' | ') LIKE '%" + key + "%' " +
                    "     OR dbo.getFileDownloadCount(fi.ID) LIKE '%" + key + "%' " +
                    "     OR dbo.getUserName(fi.up_person) LIKE '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string QuerySubDownloadList(HttpContext context)
        {
            string table = " File_Dowm_Detail fdd join BaseUser bu on fdd.dowm_person=bu.UserID join  [file] fi on fdd.file_id=fi.id join folder fo on fi.cate_id=fo.ID ";
            string sort = context.Request.Form["sort"] != null ? context.Request.Form["sort"] : "dowm_date";
            switch (sort)
            {
                case "AppRole": sort = "dbo.getApprove_role(AppRoleID)"; break;
                case "DeptName": sort = "dbo.getDeptNames(DeptID)"; break;
                default: break;
            }
            string show = " WorkID, Name, dbo.getApprove_role(AppRoleID)AppRole, dbo.getDeptNames(DeptID)DeptName, convert(nvarchar,dowm_date,120)dowm_date ,fi.ID,fi.file_name,fo.folder_path+'/'+fi.flieGuid [Path]";
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            string order = context.Request.Form["order"] != null ? context.Request.Form["order"] : "desc";
            string where = " 1=1 and file_id=" + context.Request["fileid"];
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                key = key.Replace("'", "''");
                where +=
                    " AND(WorkID LIKE '%" + key + "%' " +
                    "     OR Name LIKE '%" + key + "%' " +
                    "     OR dbo.getApprove_role(AppRoleID) LIKE '%" + key + "%' " +
                    "     OR dbo.getDeptNames(DeptID) LIKE '%" + key + "%' " +
                    "     OR convert(nvarchar,dowm_date,120) LIKE '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);
        }

        private string Edit(HttpContext context)
        {
            try
            {
                List<Model.File> model = JsonSerializerHelper.JSONStringToList<Model.File>(context.Request.Params["filestring"]);

                return new BLL.File().Update(model) ? "success" : "";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private string Update(HttpContext context)
        {
            try
            {
                Model.File file = new Model.File();
                file.ID = int.Parse(context.Request.Form["hdID"]);
                file.file_name = context.Request.Form["txtfile_name"].Replace("'", "''");
                file.pwd = context.Request.Form["txtpwd"].Replace("'", "''");
                file.Remark = context.Request.Form["txtRemark"].Replace("'", "''");
                file.updata_person = Convert.ToInt32((context.Session["login"] as Model.BaseUser).UserID);
                file.updata_datetiem = DateTime.Now;
                try { file.pwdflag = int.Parse(context.Request.Form["cbpwdflag"]); }
                catch { file.pwdflag = 0; }
                return new BLL.File().Update(file) ? "success" : "";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private string Del(HttpContext context)
        {
            int fileid = int.Parse(context.Request["fileid"]);
            string path = context.Server.MapPath(ConfigurationManager.AppSettings["FolderPath"] + "/" + context.Request["filepath"]);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return new BLL.File().Delete(fileid) ? "success" : "";
        }

        private string Dels(HttpContext context)
        {            
            string root = ConfigurationManager.AppSettings["FolderPath"];
            string selectid = context.Request.Params["cbx_select"].Trim();
            DataTable dt =  new BLL.File().GetDeleteList(selectid).Tables[0];
            string path = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                path = context.Server.MapPath(root + "/" + dr[0].ToString());
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            return new BLL.File().DeleteList(selectid) ? "success" : "";
        }

        private string FileDownloadCount(HttpContext context)
        {
            try
            {
                string fid =context.Request["fid"].Trim();
                Model.File_Dowm_Detail fdd = new Model.File_Dowm_Detail();
                fdd.dowm_person = Convert.ToInt32((context.Session["login"] as Model.BaseUser).UserID);
                fdd.dowm_date = DateTime.Now;
                fdd.file_id = int.Parse(fid);
                new BLL.File_Dowm_Detail().Add(fdd);
                return "1";
            }
            catch
            {
                return "0";
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