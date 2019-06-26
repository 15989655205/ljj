using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.DBUtility;
using System.Text;
using System.Web.SessionState;
using System.Configuration;
using System.IO;
using System.Web.UI;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// folder 的摘要说明
    /// </summary>
    public class folder : IHttpHandler, IReadOnlySessionState
    {
        DBUtility.JsonHelper jsonHelper = new JsonHelper();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            if (bu == null)
            {
                context.Response.Write("登录超时，请重新登录。");
                return;
            }
            //context.Response.Write("Hello World");
            string type = context.Request["action"];
            string ActionType = context.Request["ActionType"];
            string reValue = "";
            switch (type)
            {
                case "list":
                    reValue = QueryList(context);
                    break;
                case "get_comboxtree":
                    reValue = GetCombotree();
                    break;
                case "get_copycomboxtree":
                    reValue = GetCopyCombotree(context);
                    break;
                case "get_up_per_gt":
                    reValue = GetUpPer(context);
                    break;
                case "up_user":
                    reValue = GetUpUser(context);
                    break;
                case "get_dowm_per_gt":
                    reValue = GetDowmPer(context);
                    break;
                case "dowm_user":
                    reValue = GetDowmUser(context);
                    break;
                case"add":
                    reValue=save(context);
                    break;
                case"edit":
                    reValue = updata(context);
                    break;
                case"dept_users":
                    reValue = dept_user(context);
                    break;
                case"dowm_dept_users":
                    reValue = dowm_dept_users(context);
                    break;
                case"del":
                    reValue = Del(context);
                    break;
                case "copyFolder":
                    reValue = CopyFolder(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        /// <summary>
        /// 获取文件夹类表，树形结构
        /// </summary>
        /// <returns></returns>
        public string QueryList(HttpContext context)
        {
            //DataTable dt = new DataTable();
            //string where = "1=1";
            //dt = new BLL.Common().GetList("select ID,folder_name,dowm_permission,up_permission,remark,folder_path,create_person,update_person,folder_level,value1,convert(nvarchar,create_date,120) as create_date,convert(nvarchar,update_date,120) as update_date from folder ").Tables[0];
            //if (dt.Rows.Count <= 0)
            //{
            //    return "{[]}";
            //}
            //else
            //{
            //    return DT2GTree(dt, "", "folder_level");
            //}


            //string table = "folder";
            //string sort = "id";
            //string show = "ID,folder_name,dowm_permission,up_permission,remark,folder_path,create_person,update_person,folder_level,value1,convert(nvarchar,create_date,120) as create_date,convert(nvarchar,update_date,120) as update_date";
            //string order = "asc";
            //string where = "1=1 and folder_level=0";
            //int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            //int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            //int total = 0;
            //DataTable dt1 = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            //string where1 = "1=1";
            //for (int i = 0; i < dt1.Rows.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        where1 += " and ( value1 like '%," + dt1.Rows[i]["ID"].ToString().Trim() + ",%'";
            //    }
            //    where1 += " or value1 like '%," + dt1.Rows[i]["ID"].ToString().Trim() + ",%'";
            //    if (i == dt1.Rows.Count - 1)
            //    {
            //        where1 += " or value1 like '%," + dt1.Rows[i]["ID"].ToString().Trim() + ",%')";
            //    }
            //}
            //DataTable dt = new BLL.Common().GetList("select * from v_FolderAndFile where " + where1).Tables[0];
            //return DT2GTree(dt, "", "folder_level", total);

            string id = context.Request.Params["id"] == null ? "0" : context.Request.Params["id"].Trim();
            string table = "v_FolderAndFile_childCount";
            string sort = "id";
            string show = "*";
            string order = "asc";
            string where = "1=1 and folder_level=" + id;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            string json = "";
            if (id == "0")
            {
                json += "{\"total\":";
                //JsonString.Append(dt.Rows.Count.ToString());
                json += total.ToString();
                json += ",";
                json += "\"rows\":";
            }
            json += DT2GTree(dt, "", "folder_level", total);
            if (id == "0")
            {
                json += "}";
            }
            return json;
        }
        /// <summary>
        /// 获取文件夹列表，编辑添加页面
        /// </summary>
        /// <returns></returns>
        public string GetCombotree()
        {
            DataTable dt = new DataTable();
            string where = "1=1";
            dt = new BLL.folder().GetList(where).Tables[0];
            DataRow dr = dt.NewRow();
            dr["folder_name"] = "主文件夹";
            dr["ID"] = 0;
            dr["folder_level"] = -1;
            dt.Rows.Add(dr);
            return DataTable2Json_Tree(dt, "ID", "folder_name", "folder_level", -1, "", "");
        }

        /// <summary>
        /// 获取文件夹列表，编辑添加页面
        /// </summary>
        /// <returns></returns>
        public string GetCopyCombotree(HttpContext context)
        {
            string copyid = context.Request["copy_id"] == null ? "" : context.Request["copy_id"].Trim();
            DataTable dt = new DataTable();
            string where = "1=1 and id!=" + copyid;
            dt = new BLL.folder().GetList(where).Tables[0];
            DataRow dr = dt.NewRow();
            dr["folder_name"] = "主文件夹";
            dr["ID"] = 0;
            dr["folder_level"] = -1;
            dt.Rows.Add(dr);
            return DataTable2Json_Tree(dt, "ID", "folder_name", "folder_level", -1, "", "");
        }

        /// <summary>
        /// 获取上传部门列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetUpPer(HttpContext context)
        {
            WCDataProvider db1 = new WCDataProvider();
            WCDataStoreProcedures dsp1 = new WCDataStoreProcedures("pro_folder", WCDataAction.Query1);
            DataTable dt = new DataTable();
            DataTable per_dt = new DataTable();
            if (db1.Execute(dsp1).ExecuteState)
            {
                dt = dsp1.OutputDataSet.Tables[0];
            }
            //string sql = "";
            //string key = context.Request["key"] != null ? context.Request["key"].Trim() : "";
            //string ActionType = context.Request["ActionType"] != null ? context.Request["ActionType"].Trim() : "";
            //if (key != null || !string.IsNullOrEmpty(key))
            //    dt = new BLL.folder().GetUpDowmPer("Query1", key).Tables[0];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    sql = @sql + GetDeptID(per_dt, dt.Rows[i]["ParentDeptID"].ToString(), dt.Rows[i]["DeptID"].ToString()) + ",";
            //}
            //WCDataProvider db = new WCDataProvider();
            //WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Query2);
            //dsp.InputPars.Add("@sql", sql);
            //if (db.Execute(dsp).ExecuteState)
            //{
            //    dt = dsp.OutputDataSet.Tables[0];
            //}
            return jsonHelper.DataTable2Json_Tree(dt, "DeptID", "DeptName", "ParentDeptID", 0, "", "");
        }


        /// <summary>
        /// 获取上传人员列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetUpUser(HttpContext context)
        {

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Query3);

            DataTable dt = new DataTable();
            DataTable per_dt = new DataTable();
            //per_dt = new BLL.BaseDepartment().GetList(" 1=1").Tables[0];
            string sql = "";

            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string folder_id = context.Request.Form["folder_id"] != null ? context.Request.Form["folder_id"].Trim() : "";

            //string where = " 1=1";
            if (key != "" || !string.IsNullOrEmpty(key))
            {
                //if (folder_id != "" || !string.IsNullOrEmpty(folder_id))
                //{

                //    sql = GetDeptID2(per_dt, key);
                //    dsp.InputPars.Add("@sql", sql);
                //    dsp.InputPars.Add("@folder_id", folder_id);
                //    if (db.Execute(dsp).ExecuteState)
                //    {
                //        dt = dsp.OutputDataSet.Tables[0];
                //    }
                //}
                dsp.InputPars.Add("@DeptID", key);
                if (db.Execute(dsp).ExecuteState)
                {
                    if (dsp.OutputDataSet.Tables.Count>0)
                    {
                        dt = dsp.OutputDataSet.Tables[0];
                    }
                    
                }
            }

            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);

        }

        /// <summary>
        /// 获取下载部门列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetDowmPer(HttpContext context)
        {
            WCDataProvider db1 = new WCDataProvider();
            WCDataStoreProcedures dsp1 = new WCDataStoreProcedures("pro_folder", WCDataAction.Query1);
            DataTable dt = new DataTable();
            DataTable per_dt = new DataTable();
            if (db1.Execute(dsp1).ExecuteState)
            {
                dt = dsp1.OutputDataSet.Tables[0];
            }
            //string sql = "";
            //string key = context.Request["key"] != null ? context.Request["key"].Trim() : "";
            //dsp1.InputPars.Add("@folder_id", key);
            //if (key != null || !string.IsNullOrEmpty(key))
            //    dt = db1.Execute(dsp1).OutputDataSet.Tables[0];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    sql = @sql + GetDeptID(per_dt, dt.Rows[i]["ParentDeptID"].ToString(), dt.Rows[i]["DeptID"].ToString()) + ",";
            //}
            //WCDataProvider db = new WCDataProvider();
            //WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Query2);
            //dsp.InputPars.Add("@sql", sql);
            //if (db.Execute(dsp).ExecuteState)
            //{
            //    dt = dsp.OutputDataSet.Tables[0];
            //}
            
            return jsonHelper.DataTable2Json_Tree(dt, "DeptID", "DeptName", "ParentDeptID", "NULL", "", "");
        }


        /// <summary>
        /// 获取下载人员列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetDowmUser(HttpContext context)
        {

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Query3);

            DataTable dt = new DataTable();
            DataTable per_dt = new DataTable();
            //per_dt = new BLL.BaseDepartment().GetList(" 1=1").Tables[0];
            string sql = "";

            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string folder_id = context.Request.Form["folder_id"] != null ? context.Request.Form["folder_id"].Trim() : "";

            //string where = " 1=1";
            if (key != "" || !string.IsNullOrEmpty(key))
            {
                //if (folder_id != "" || !string.IsNullOrEmpty(folder_id))
                //{

                //    sql = GetDeptID2(per_dt, key);
                //    dsp.InputPars.Add("@sql", sql);
                //    dsp.InputPars.Add("@folder_id", folder_id);
                //    if (db.Execute(dsp).ExecuteState)
                //    {
                //        dt = dsp.OutputDataSet.Tables[0];
                //    }
                //}
                dsp.InputPars.Add("@DeptID", key);
                if (db.Execute(dsp).ExecuteState)
                {
                    if (dsp.OutputDataSet.Tables.Count > 0)
                    {
                        dt = dsp.OutputDataSet.Tables[0];
                    }

                }
            }

            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);

        }


        /// <summary>
        /// 递归获取部门层级ID，以“，”分隔
        /// </summary>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public string GetDeptID(DataTable dt, string ParentDeptID, string DeptID)
        {

            string ID;
            string sql = "";
            if (ParentDeptID != "0")
            {

                ID = dt.Select("DeptID=" + ParentDeptID)[0]["ParentDeptID"].ToString();
                sql += DeptID + "," + GetDeptID(dt, ID, dt.Select("DeptID=" + ParentDeptID)[0]["DeptID"].ToString());

            }
            else
            {
                sql = DeptID;
            }
            return sql;
        }
        /// <summary>
        /// 递归获取部门层级ID，以“，”隔开
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public string GetDeptID2(DataTable dt, string DeptID)
        {
            string ID;
            string sql = DeptID + ",";

            for (int i = 0; i < dt.Select("ParentDeptID=" + DeptID).Length; i++)
            {
                ID = dt.Select("ParentDeptID=" + DeptID)[i]["DeptID"].ToString();
                sql += GetDeptID2(dt, ID);
            }

            return sql;
        }

        /// <summary>
        /// 将table转换为treegrid的json形式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="type"></param>
        /// <param name="pidName"></param>
        /// <returns></returns>
        public string DT2GTree(DataTable dt, string type, string pidName,int total)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                //JsonString.Append("{\"total:\":");
                ////JsonString.Append(dt.Rows.Count.ToString());
                //JsonString.Append(total.ToString());
                //JsonString.Append(",");
                //JsonString.Append("\"rows\":");
                JsonString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    if(dt.Rows[i]["ftype"].ToString().Trim()=="1")
                        JsonString.Append("\"iconCls\":\"icon-folder\",");
                    else
                        JsonString.Append("\"iconCls\":\"icon-ffile\",");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + DBUtility.JsonHelper.DataConversion(dt.Rows[i][j].ToString()) + "\",");
                    }
                    if (Convert.ToInt16(dt.Rows[i][pidName]) != 0)
                    {
                        JsonString.Append("\"_parentId\":\"" + DBUtility.JsonHelper.DataConversion(dt.Rows[i][pidName].ToString()) + "\",");

                    }
                    //if (type == "p")
                    //{
                    //    JsonString.Append("\"state\":\"closed\"");
                    //}
                    //else
                    //{
                    //    JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    //}
                    if (Convert.ToInt32(dt.Rows[i]["child"]) >0)
                    {
                        JsonString.Append("\"state\":\"closed\"");
                    }
                    else
                    {
                        JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    }


                    JsonString.Append("},");
                }
                JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                JsonString.Append("]");
                //JsonString.Append("}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据DataTable生成Json树结构
        /// </summary>
        /// <param name="tabel">数据源</param>
        /// <param name="idCol">ID列</param>
        /// <param name="txtCol">Text列</param>
        /// <param name="rela">关系字段</param>
        /// <param name="pId">父ID</param>
        StringBuilder result = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        public string DataTable2Json_Tree(DataTable tabel, string idCol, string txtCol, string rela, object pId, string openStatus, string statusCol)
        {
            GetTreeJsonByTable(tabel, idCol, txtCol, rela, pId, openStatus, statusCol);
            return result.ToString();
        }



        private void GetTreeJsonByTable(DataTable tabel, string idCol, string txtCol, string rela, object pId, string openStatus, string statusCol)
        {
            result.Append(sb.ToString());
            sb.Remove(0, sb.Length);
            sb.Append("[");
            string filer = string.Format("{0}='{1}'", rela, pId);
            if (tabel.Rows.Count > 0)
            {

                DataRow[] rows = tabel.Select(filer);
                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        string oStatus = openStatus;
                        try
                        {
                            if (row[statusCol] == null)
                            {
                            }
                        }
                        catch
                        {
                        }
                        sb.Append("{\"id\":\"" + row[idCol] + "\",\"text\":\"" + row[txtCol] + "\",\"state\":\"" + oStatus + "\",\"iconCls\":\"icon-folder\"");
                        if (tabel.Select(string.Format("{0}='{1}'", rela, row[idCol])).Length > 0)
                        {
                            sb.Append(",\"children\":");
                            GetTreeJsonByTable(tabel, idCol, txtCol, rela, row[idCol], openStatus, statusCol);
                            result.Append(sb.ToString());
                            sb.Remove(0, sb.Length);
                        }
                        result.Append(sb.ToString());
                        sb.Remove(0, sb.Length);
                        sb.Append("},");
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                }

            }
            sb.Append("]");
            result.Append(sb.ToString());
            sb.Remove(0, sb.Length);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string save(HttpContext context)
        {
            string mainPath = ConfigurationManager.AppSettings["FolderPath"];
            string folder_path;
            string t = DateTime.Now.ToString("yyyyMMddhhmmss");
            Random rnd = new Random();
            int i = rnd.Next(100, 999);
            string r = i.ToString();
            DataTable dt = ParentPath(context.Request["level_ID"].ToString());
            string checkPathName = CheckPathName(context.Request["level_ID"].ToString(), "", context.Request["folder_name"].ToString());
            if (checkPathName != "")
            {
                return checkPathName;
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    folder_path = dt.Rows[0]["folder_path"].ToString() + "/" + context.Request["folder_name"].ToString();
                }
                else
                {
                    folder_path = "/" + context.Request["folder_name"].ToString();
                }
                string data = "";
                Model.BaseUser buModel = (Model.BaseUser)context.Session["login"];
                WCDataProvider db = new WCDataProvider();
                WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Insert1);
                dsp.InputPars.Add("@folder_name", context.Request["folder_name"].ToString());
                dsp.InputPars.Add("@folder_level", context.Request["level_ID"].ToString());
                dsp.InputPars.Add("@remark", context.Request["remark"].ToString());
                dsp.InputPars.Add("@up_permission", context.Request["up_user"].ToString());
                dsp.InputPars.Add("@dowm_permission", context.Request["dowm_user"].ToString());
                dsp.InputPars.Add("@folder_path", folder_path);
                dsp.InputPars.Add("@create_person", buModel.Name);
                if (db.Execute(dsp).ExecuteState)
                {
                    data = "success," + dsp.OutputPars["@OutID"].ToString();
                    string createPath = System.Web.HttpContext.Current.Server.MapPath(mainPath + folder_path);
                    if (!Directory.Exists(createPath))
                    {
                        Directory.CreateDirectory(createPath);
                    }
                    
                }
                else
                {
                    if (dsp.OutputPars["Error"].ToString() != "" || string.IsNullOrEmpty(dsp.OutputPars["Error"].ToString()))
                    {
                        data = dsp.OutputPars["Error"].ToString();
                    }
                }
                return data;
            }
        }
        public string CheckPathName(string level_ID, string ID,string name)
        {
            DataTable dt = new DataTable();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder",WCDataAction.Query12);
            if (level_ID == "")
            {
                dsp.InputPars.Add("@folder_id", ID);
            }
            else
            {
                dsp.InputPars.Add("@folder_level", level_ID);
            }
            dsp.InputPars.Add("@folder_name", name);
            if (db.Execute(dsp).ExecuteState)
            {
                if (dsp.OutputDataSet.Tables[0].Rows.Count>0)
                {
                    return "文件夹名重复!请重新输入文件夹名称！"; 
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "出错！";
            }
        }
        public DataTable ParentPath(string level_ID)
        {
            DataTable dt = new DataTable();

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Query10);
            dsp.InputPars.Add("@folder_ID", level_ID);
            if (db.Execute(dsp).ExecuteState)
            {
                dt = dsp.OutputDataSet.Tables[0];
            }
            return dt;
        }

        public string dept_user(HttpContext context)
        {
            DataTable dt = new DataTable();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder",WCDataAction.Query7);
            if (context.Request["folder_id"]!="0")
            {
                if (context.Request["folder_id"] != "" || !string.IsNullOrEmpty(context.Request["folder_id"]))
                {
                    dsp.InputPars.Add("@folder_id", context.Request["folder_id"]);
                    if (db.Execute(dsp).ExecuteState)
                    {
                        dt = dsp.OutputDataSet.Tables[0];
                    }
                }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
            }
            else
            {
                return "{\"total\":0,\"rows\":[]}";
            }
           
        }

        public string dowm_dept_users(HttpContext context)
        {
            DataTable dt = new DataTable();
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Query8);
            if (context.Request["folder_id"]!="0")
            {
                if (context.Request["folder_id"] != "" || !string.IsNullOrEmpty(context.Request["folder_id"]))
                {
                    dsp.InputPars.Add("@folder_id", context.Request["folder_id"]);
                    if (db.Execute(dsp).ExecuteState)
                    {
                        dt = dsp.OutputDataSet.Tables[0];
                    }
                }
                return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
            }
            else
            {
                return "{\"total\":0,\"rows\":[]}";
            }
            
        }

        public string updata(HttpContext context)
        {
            string mainPath = ConfigurationManager.AppSettings["FolderPath"];
            string checkPathName = CheckPathName("", context.Request["level_ID"].ToString(), context.Request["folder_name"].ToString());
             Model.BaseUser buModel = (Model.BaseUser)context.Session["login"];
            string data = "";
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Update2);
            //data = CheckData(context.Request["level_ID"].ToString(), context.Request["up_user"].ToString(), context.Request["dowm_user"].ToString());
            if (checkPathName != "")
            {
                return checkPathName;
            }
            else
            {
                if (data == "" || string.IsNullOrEmpty(data))
                {
                    dsp.InputPars.Add("@folder_name", context.Request["folder_name"].ToString());
                    dsp.InputPars.Add("@folder_id", context.Request["folder_id"].ToString());
                    dsp.InputPars.Add("@folder_level", context.Request["level_ID"].ToString());
                    dsp.InputPars.Add("@remark", context.Request["remark"].ToString());
                    dsp.InputPars.Add("@up_permission", context.Request["up_user"].ToString());
                    dsp.InputPars.Add("@dowm_permission", context.Request["dowm_user"].ToString());
                    dsp.InputPars.Add("@update_person", buModel.Name);
                    dsp.InputPars.Add("@ups_add", context.Request["ups_add"].ToString());
                    dsp.InputPars.Add("@ups_del", context.Request["ups_del"].ToString());
                    dsp.InputPars.Add("@downs_add", context.Request["downs_add"].ToString());
                    dsp.InputPars.Add("@downs_del", context.Request["downs_del"].ToString());
                    if (db.Execute(dsp).ExecuteState)
                    {
                        string oldPath = System.Web.HttpContext.Current.Server.MapPath(mainPath + dsp.OutputPars["@OutSql"].ToString());
                        string newPath = System.Web.HttpContext.Current.Server.MapPath(mainPath + dsp.OutputPars["@OutSql2"].ToString());
                        if (oldPath != newPath)
                        {
                            if (Directory.Exists(oldPath))
                            {
                                Directory.Move(oldPath, newPath);


                            }
                        }
                        data = "success";
                    }
                    else
                    {
                        data = "修改失败！";
                    }
                }
                return data;
            }
        }

        //public string CheckData(string ID,string up_per,string dowm_per)
        //{
        //    string data="";
        //    bool b = false;
        //    bool b1 = false;
        //    WCDataProvider db = new WCDataProvider();
        //    WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Query9);
        //    dsp.InputPars.Add("@folder_id", ID);
        //    DataTable dt = new DataTable();
        //    if (db.Execute(dsp).ExecuteState)
        //    {
        //        dt = dsp.OutputDataSet.Tables[0];
        //    }
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if (up_per.Length< dt.Rows[i]["up_permission"].ToString().Length)
        //            {
        //                b = true;
        //            }
        //            if (dowm_per.Length<dt.Rows[i]["dowm_permission"].ToString().Length)
        //            {
        //                b1 = true;
        //            }
        //        }

        //    }
        //    if (b)
        //    {
        //        data += "修改后该文件夹的上传权限小于它的子文件夹的上传权限\n,";
        //    }
        //    if (b1)
        //    {
        //        data+="修改后该文件夹的下载权限小于它的子文件夹的下载权限\n,";
        //    }
        //    return data;
        //}


        public string Del(HttpContext context)
        {
            string data="";
            string ftype = context.Request.Params["ftype"].Trim();
            if (ftype == "1")
            {
                WCDataProvider db = new WCDataProvider();
                WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Query11);
                dsp.InputPars.Add("@folder_id", context.Request["ID"].ToString());
                if (db.Execute(dsp).ExecuteState)
                {
                    if (dsp.OutputPars["@Error"].ToString() == "" || string.IsNullOrEmpty(dsp.OutputPars["@Error"].ToString()))
                    {
                        data = "success";
                        string mainPath = ConfigurationManager.AppSettings["FolderPath"];
                        string Path = System.Web.HttpContext.Current.Server.MapPath(mainPath + dsp.OutputPars["@OutPath"].ToString());
                        if (Directory.Exists(Path))
                        {
                            Directory.Delete(Path);
                        }
                    }
                    else
                    {
                        data = dsp.OutputPars["@Error"].ToString() + "请将该文件夹下的子文件夹和文件删除，再进行该操作！";
                    }
                }
                else
                {
                    data = "删除失败！";
                }
            }
            else if (ftype == "2")
            {
                int fileid = int.Parse(context.Request["ID"].Substring(2));
                string path = context.Server.MapPath(ConfigurationManager.AppSettings["FolderPath"] + "/" + context.Request["folder_path"]);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                data = new BLL.File().Delete(fileid) ? "success" : "删除失败";
            }
            return data;
        }

        private string CopyFolder(HttpContext context)
        {
            string fName = context.Request["folderName"].ToString();
            string pid = context.Request["parent_ct"].ToString();
            string cfid = context.Request["copyid"].ToString();
            string cpath = context.Request["showCopy"].ToString();
            string ppath = context.Request["parentPath"].ToString();

            Model.BaseUser buModel = (Model.BaseUser)context.Session["login"];
            string data = "";
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Insert2);
            dsp.InputPars.Add("@folder_name", context.Request["folderName"].ToString());
            dsp.InputPars.Add("@parent_ct", context.Request["parent_ct"].ToString());
            dsp.InputPars.Add("@copy_folderid", context.Request["copyid"].ToString());
            dsp.InputPars.Add("@copy_flag",Maticsoft.Common.Common.Str_char(6,true));
            dsp.InputPars.Add("@create_person", buModel.Name);
            try
            {
                if (db.Execute(dsp).ExecuteState)
                {
                    if (dsp.OutputPars["@Error"].ToString() == "" || string.IsNullOrEmpty(dsp.OutputPars["@Error"].ToString()))
                    {
                        data = "success";
                        string mainPath = ConfigurationManager.AppSettings["FolderPath"];
                        string sPath = System.Web.HttpContext.Current.Server.MapPath(mainPath + cpath);
                        string dPath = System.Web.HttpContext.Current.Server.MapPath(mainPath + dsp.OutputPars["@OutPath"].ToString());
                        string reval = Maticsoft.Common.Common.CopyFolder(sPath, dPath);
                        if (reval != "success")
                        {
                            WCDataStoreProcedures dsp1 = new WCDataStoreProcedures("pro_folder", WCDataAction.Delete1);
                            dsp1.InputPars.Add("@folder_id", dsp.OutputPars["@OutID"].ToString());
                            if (db.Execute(dsp1).ExecuteState)
                            {
                            }
                            data = reval;
                        }
                        //string createPath = System.Web.HttpContext.Current.Server.MapPath(mainPath + folder_path);
                        //if (!Directory.Exists(createPath))
                        //{
                        //    Directory.CreateDirectory(createPath);
                        //}
                    }
                    else
                    {
                        data = dsp.OutputPars["@Error"].ToString();
                    }
                }
                else
                {
                    if (dsp.OutputPars["@Error"].ToString() != "" || string.IsNullOrEmpty(dsp.OutputPars["@Error"].ToString()))
                    {
                        data = dsp.OutputPars["@Error"].ToString();
                    }
                }
            }
            catch (Exception exc)
            {
                data = exc.Message;
            }
            return data;
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