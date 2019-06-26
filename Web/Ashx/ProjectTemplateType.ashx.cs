using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ProjectTemplateType 的摘要说明
    /// </summary>
    public class ProjectTemplateType : IHttpHandler, IReadOnlySessionState
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
            switch (type)
            {
                case "list": reValue = QueryList(context); break;
                case "stagelist": reValue = QueryStageList(context); break;
                case "stage_list": reValue = QueryStage_List(context); break;
                case "stage_edit": reValue = Stage_Edit(context); break;
                case "delete": reValue = Stage_Delete(context); break;
                case "delete1": reValue = Stage_Delete1(context); break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string QueryList(HttpContext context)
        {
            string where =" where 1=1 "+
                (context.Request["sid"] == "-1" ? "" : " and a.sid=" + context.Request["sid"]);
            string key = context.Request["key"];
            if (!string.IsNullOrWhiteSpace(key))
            {
                key = key.Replace("'", "''");
                key = key == "可用" ? "1" : key == "不可用" ? "0" : key;               
                where += " and( " +
                    " a.name like '%" + key + "%' " +
                    " or stage_name like '%" + key + "%' " +
                    " or text like '%" + key + "%' " +
                    " or status like '%" + key + "%' " +
                    " or b.remark like '%" + key + "%' " +
                    " or dbo.getUserName_fu(create_person) like '%" + key + "%' " +
                    " or create_date like '%" + key + "%' " +
                    " or dbo.getUserName_fu(create_person) like '%" + key + "%' " +
                    " or update_date like '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select a.sid ptt_sid, a.name ptt_name, b.sid, stage_name, status, b.remark, number, is_system, [text] stageType, row_number()over (order by b.sequence) as rowid,create_date, create_person, update_date, update_person, dbo.getUserName_fu(create_person) as createP,dbo.getUserName_fu(update_person) as updateP from Project_Template_Type a join stage b on a.sid=b.p_sid left outer join project_stage_type c on b.is_system=c.[value] " + where + " order by a.sid desc, b.sequence asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string QueryStageList(HttpContext context)
        {
            DataTable dt = new BLL.Common().GetList("select sid id, stage_name text from stage where p_sid=0 or p_sid is null order by sequence asc").Tables[0];
            return DBUtility.JsonHelper.DataTable2List(dt);
        }

        private string QueryStage_List(HttpContext context)
        {
            DataTable dt = new BLL.Common().GetList("select sid, stage_name, sequence, remark from stage where p_sid=" + context.Request["ssid"] + " order by sequence asc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string Stage_Edit(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("ProjectTemplateType", WCDataAction.Insert1);
            dsp.InputPars.Add("@Sql", " " + context.Request["SQLString"].Substring(0, context.Request["SQLString"].Length - 1));
            dsp.InputPars.Add("@UserName", bu.UserName);
            dsp.InputPars.Add("@ptt_sid", context.Request["ptt_sid"]);
            dsp.InputPars.Add("@ptt_name", context.Request["ptt_name"]);
            dsp.InputPars.Add("@pptt_sid", context.Request["pptt_sid"]);
            if (db.Execute(dsp).ExecuteState)
            {
                if (!string.IsNullOrWhiteSpace(dsp.OutputPars["@error"].ToString()))
                {
                    return dsp.OutputPars["@error"].ToString();
                }
                else
                {
                    return "success~" + dsp.OutputPars["@outputStr"].ToString();
                }
            }
            else
            {
                return "保存失败。";
            }
        }

        private string Stage_Delete(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("ProjectTemplateType", WCDataAction.Delete1);
            dsp.InputPars.Add("@ptt_sid", context.Request["ptt_sid"]);
            return db.Execute(dsp).ExecuteState ? "ok" : "";
        }

        private string Stage_Delete1(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("ProjectTemplateType", WCDataAction.Delete2);
            dsp.InputPars.Add("@stage_sid", context.Request["sid"]);
            return db.Execute(dsp).ExecuteState ? "ok" : "";
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