using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ProjectStage 的摘要说明
    /// </summary>
    public class ProjectStage : IHttpHandler, IReadOnlySessionState
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
            string reValue = "";
            switch (type)
            {
                case "template_list":
                    reValue = GetStageTemplateList(context);
                    break;
                case "template_list1":
                    reValue = GetStageTemplateList1(context);
                    break;
                case "viewSL":
                    reValue = GetViewSL(context);
                    break;
                case "stage_edit":
                    reValue = StageEdit(context);
                    break;
                case "stage_del_check":
                    reValue = StageDelCheck(context);
                    break;
                case "groupModelList":
                    reValue = GroupModelList(context);
                    break;
                case "group_list":
                    reValue = GroupList(context);
                    break;
                case "group_del_check":
                    reValue = GroupDelCheck(context);
                    break;
                case "group_edit":
                    reValue = GroupEdit(context);
                    break;
                case "impModelList":
                    reValue = ImpMoldeList(context);
                    break;
                case "imp_list":
                    reValue = ImpList(context);
                    break;
                //case "imp_del_check":
                //    reValue = ImpDelCheck(context);
                //    break;
                case "imp_edit":
                    reValue = ImpEdit(context);
                    break;
                case "flowModelList":
                    reValue = FlowModelList(context);
                    break;
                case "flow_list":
                    reValue = FlowList(context);
                    break;
                case "flow_edit":
                    reValue = FlowEdit(context);
                    break;
                case "content_list":
                    reValue = ContentList(context);
                    break;
                case "project_group_combo":
                    reValue = ProjectGroupCombo(context);
                    break;
                case "getStageContent":
                    reValue = GetStageContent(context);
                    break;
                case "getStageAllContent":
                    reValue = GetStageAllContent(context);
                    break;
                case "getContentJson":
                    reValue = GetContentJson(context);
                    break;
                case "pro_content_add":
                    reValue = ProContentAdd(context);
                    break;
                case "pro_content_edit":
                    reValue = ProContentUpdate(context);
                    break;
                case "content_del":
                    reValue = ContentDel(context);
                    break;
                case "getStageContentItem":
                    reValue = GetStageContentItem(context);
                    break;
                case "project_content_combo":
                    reValue = ProjectContentCombo(context);
                    break;
                case "pro_item_add":
                    reValue = ProItemAdd(context);
                    break;
                case "pro_item_edit":
                    reValue =ProItemUpdate(context);
                    break;
                case "item_del":
                    reValue = ItemDel(context);
                    break;
                case "getStageType":
                    reValue = GetStageType(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }

        private string GetStageTemplateList(HttpContext context)
        {
            string where = " where stage.p_sid=0 ";
            string key = context.Request["key"];
            if (!string.IsNullOrWhiteSpace(key))
            {
                key = key.Replace("'", "''");
                key = key == "可用" ? "1" : key == "不可用" ? "0" : key;
                where += " and( " +
                    " stage_name like '%" + key + "%' " +
                    " or text like '%" + key + "%' " +
                    " or status like '%" + key + "%' " +
                    " or remark like '%" + key + "%' " +
                    " or dbo.getUserName_fu(create_person) like '%" + key + "%' " +
                    " or create_date like '%" + key + "%' " +
                    " or dbo.getUserName_fu(update_person) like '%" + key + "%' " +
                    " or update_date like '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select stage.sid,stage_name,status,remark,number,is_system,[text] stageType,row_number()over (order by sequence) as rowid,create_date,create_person,update_date,update_person,dbo.getUserName_fu(create_person) as createP,dbo.getUserName_fu(update_person) as updateP from stage left outer join project_stage_type on stage.is_system=[value] " + where + " order by sequence asc");
            
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt,dt.Rows.Count);
        }

        private string GetStageTemplateList1(HttpContext context)
        {
            string where = " where 1=1 " +
                (context.Request["sid"] == "-1" ? "" : " and stage.p_sid=" + context.Request["sid"]);
            string key = context.Request["key"];
            if (!string.IsNullOrWhiteSpace(key))
            {
                key = key.Replace("'", "''");
                key = key == "可用" ? "1" : key == "不可用" ? "0" : key;               
                where += " and( " +
                    " stage_name like '%" + key + "%' " +
                    " or text like '%" + key + "%' " +
                    " or status like '%" + key + "%' " +
                    " or remark like '%" + key + "%' " +
                    " or dbo.getUserName_fu(create_person) like '%" + key + "%' " +
                    " or create_date like '%" + key + "%' " +
                    " or dbo.getUserName_fu(update_person) like '%" + key + "%' " +
                    " or update_date like '%" + key + "%' " +
                    " ) ";
            }
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select dbo.getPTTame(stage.p_sid)ptt_name, stage.sid,stage_name,status,remark,number,is_system,[text] stageType,row_number()over (order by sequence) as rowid,create_date,create_person,update_date,update_person,dbo.getUserName_fu(create_person) as createP,dbo.getUserName_fu(update_person) as updateP from stage left outer join project_stage_type on stage.is_system=[value] " + where + " order by sequence asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string GetViewSL(HttpContext context)
        {
            string sid = string.IsNullOrWhiteSpace(context.Request["sid"]) ? "0" : context.Request["action"];
            DataTable dt = new BLL.Common().GetList(" select sid, name from Project_Template_Type ").Tables[0];
            dt.Rows.InsertAt(dt.NewRow(), 0);
            dt.Rows[0]["sid"] = -1;
            dt.Rows[0]["name"] = "请选择";
            if (context.Request["type"] != null)
            {
                dt.Rows.InsertAt(dt.NewRow(), 1);
                dt.Rows[1]["sid"] = 0;
                dt.Rows[1]["name"] = "公共模版";
            }
            return DBUtility.JsonHelper.DataTable2Json_ValueText(dt, "sid", "name");
        }

        private string StageEdit(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.stage> insert = new List<Model.stage>();
            insert = JsonSerializerHelper.JSONStringToList<Model.stage>(addstr);
            List<Model.stage> update = new List<Model.stage>();
            update = JsonSerializerHelper.JSONStringToList<Model.stage>(updatestr);
            List<Model.stage> del = new List<Model.stage>();
            del = JsonSerializerHelper.JSONStringToList<Model.stage>(delstr);

            List<Model.stage> sequence = new List<Model.stage>();
            sequence = JsonSerializerHelper.JSONStringToList<Model.stage>(allstr);

            return new BLL.stage().Edit(insert, update, del, sequence,bu.UserName);
        }

        private string StageDelCheck(HttpContext context)
        {
            //if (DbHelperSQL.Exists("select count(1) from stage where sid='" + context.Request.Params["sid"].Trim() + "' and is_system=1"))
            //{
            //    return "2";
            //}
            //else 
            if (DbHelperSQL.Exists("select count(1) from project_specific_item_model where s_sid='" + context.Request.Params["sid"].Trim() + "'") || DbHelperSQL.Exists("select count(1) from project_stage_group_model where ps_sid='" + context.Request.Params["sid"].Trim() + "'") || DbHelperSQL.Exists("select count(1) from project_stage_implement_model where s_sid='" + context.Request.Params["sid"].Trim() + "'"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        private string GroupModelList(HttpContext context)
        {
            //DataTable dt = new DataTable();
            //dt = new BLL.project_group_model().GetList(" status=1").Tables[0];
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList(" select distinct group_name id ,group_name as [text] from project_group_model").Tables[0];
            return DBUtility.JsonHelper.DataTable2List(dt);
        }

        private string GroupList(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.project_stage_group_model().GetList(" ps_sid='" + context.Request.Params["ssid"].Trim() + "' order by sequence asc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string GroupDelCheck(HttpContext context)
        {
            if (DbHelperSQL.Exists("select count(1) from project_specific_item_model where group_sid='" + context.Request.Params["sid"].Trim() + "'"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        private string GroupEdit(HttpContext context)
        {
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_stage_group_model> insert = new List<Model.project_stage_group_model>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_stage_group_model>(addstr);
            List<Model.project_stage_group_model> update = new List<Model.project_stage_group_model>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_stage_group_model>(updatestr);
            List<Model.project_stage_group_model> del = new List<Model.project_stage_group_model>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_stage_group_model>(delstr);

            List<Model.project_stage_group_model> sequence = new List<Model.project_stage_group_model>();
            sequence = JsonSerializerHelper.JSONStringToList<Model.project_stage_group_model>(allstr);

            return new BLL.project_stage_group_model().Edit(insert, update, del, sequence);
        }

        private string ImpMoldeList(HttpContext context)
        {
            DataTable dt = new DataTable();
            string key = context.Request.Params["key"] == null ? "" : context.Request.Params["key"].Trim();
            string where = " where 1=1";
            if (key != "")
            {
                where += " and implement_name like '%" + key + "%'";
            }
            dt = new BLL.Common().GetList("select sid, implement_name from implement  " + where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string ImpList(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList("select sid,implement_name,s_sid,remark,sequence from project_stage_implement_model where s_sid='" + context.Request.Params["ssid"].Trim() + "' order by sequence asc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        //private string ImpDelCheck(HttpContext context)
        //{
        //    //if (DbHelperSQL.Exists("select count(1) from project_work_implement where imp_sid='" + context.Request.Params["sid"].Trim() + "' and "))
        //    //{
        //    //    return "1";
        //    //}
        //    //else
        //    //{
        //    //    return "0";
        //    //}
        //}

        private string ImpEdit(HttpContext context)
        {
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_stage_implement_model> insert = new List<Model.project_stage_implement_model>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_stage_implement_model>(addstr);
            List<Model.project_stage_implement_model> update = new List<Model.project_stage_implement_model>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_stage_implement_model>(updatestr);
            List<Model.project_stage_implement_model> del = new List<Model.project_stage_implement_model>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_stage_implement_model>(delstr);

            List<Model.project_stage_implement_model> sequence = new List<Model.project_stage_implement_model>();
            sequence = JsonSerializerHelper.JSONStringToList<Model.project_stage_implement_model>(allstr);

            return new BLL.project_stage_implement_model().Edit(insert, update, del, sequence);
        }

        private string FlowModelList(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList(" select distinct id ,work_flow_name as [text] from work_flow_model").Tables[0];
            return DBUtility.JsonHelper.DataTable2List(dt);
        }

        private string FlowList(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList("select sid,work_flow_name,s_sid,remark,sequence from project_stage_work_flow_model where s_sid='" + context.Request.Params["ssid"].Trim() + "' order by sequence asc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string FlowEdit(HttpContext context)
        {
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_stage_work_flow_model> insert = new List<Model.project_stage_work_flow_model>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_stage_work_flow_model>(addstr);
            List<Model.project_stage_work_flow_model> update = new List<Model.project_stage_work_flow_model>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_stage_work_flow_model>(updatestr);
            List<Model.project_stage_work_flow_model> del = new List<Model.project_stage_work_flow_model>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_stage_work_flow_model>(delstr);

            List<Model.project_stage_work_flow_model> sequence = new List<Model.project_stage_work_flow_model>();
            sequence = JsonSerializerHelper.JSONStringToList<Model.project_stage_work_flow_model>(allstr);

            return new BLL.project_stage_work_flow_model().Edit(insert, update, del, sequence);
        }

        private string ContentList(HttpContext context)
        {
            DataTable dt = new DataTable();

            //DataSet ds = new BLL.Common().GetList("select row_number()over (order by b.sequence) as rowid, a.sid,b.sid as csid,c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.reviewed,a.remark,'' [week],'' tmp,a.v1,a.v2,a.sequence as itemSequence,b.sequence as contentSequence,b.remark as cremark,b.group_sid,a.parent_sid from project_specific_item_model b left outer join project_specific_item_model a on a.parent_sid=b.sid left outer join stage c on b.s_sid=c.sid left outer join project_stage_group_model d on b.group_sid=d.sid where b.s_sid=" + context.Request.Params["pssid"].Trim() + " and b.ischild=0 order by d.sequence asc, b.sequence asc, a.sequence asc");
            DataSet ds = new BLL.Common().GetList("select row_number()over (order by b.sequence) as rowid, a.sid,b.sid as csid,c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.reviewed,a.remark,'' [week],'' tmp,a.v1,a.v2,a.sequence as itemSequence,b.sequence as contentSequence,b.remark as cremark,b.group_sid,a.parent_sid from project_specific_item_model b left outer join project_specific_item_model a on a.parent_sid=b.sid left outer join stage c on b.s_sid=c.sid left outer join project_stage_group_model d on b.group_sid=d.sid where b.s_sid=" + context.Request.Params["pssid"].Trim() + " and b.ischild=0 order by b.sequence asc, a.sequence asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_stage_implement_model().GetList(" s_sid='" + context.Request.Params["pssid"].Trim() + "'");
                if (impDS.Tables.Count > 0)
                {
                    impDT = impDS.Tables[0];
                }
                for (int i = 0; i < impDT.Rows.Count; i++)
                {
                    DataColumn datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "imp" + impDT.Rows[i]["sid"].ToString().Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        dt.Rows[j]["imp" + impDT.Rows[i]["sid"].ToString().Trim()] = "";
                    }
                }
            }

            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        private string ProjectGroupCombo(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select sid,group_name from project_stage_group_model where ps_sid=" + context.Request.Params["ps_sid"].Trim() + " order by sequence asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        private string GetStageContent(HttpContext context)
        {
            DataTable dt = new DataTable();
            string where = "";
            if (context.Request.Params["sid"].Trim() != "")
            {
                where = " and sid!=" + context.Request.Params["sid"].Trim();
            }
            DataSet ds = new BLL.Common().GetList("select row_number()over (order by sequence) as rowid,name from project_specific_item_model where s_sid='" + context.Request.Params["pssid"].Trim() + "' and isChild=0 " + where +" order by sequence asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            DataRow dr = dt.NewRow();
            dr["rowid"] = "0";
            dr["name"] = "最顶";
            dt.Rows.InsertAt(dr, 0);

            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        private string GetStageAllContent(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select sid,name from project_specific_item_model where s_sid='" + context.Request.Params["pssid"].Trim() + "' and isChild=0  order by sequence asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        private string GetContentJson(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select sid,name,group_sid,sequence from project_specific_item_model where s_sid='" + context.Request.Params["pssid"].Trim() + "' and isChild=0  order by sequence asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }

            return DBUtility.JsonHelper.DataTable2Josn(dt);
        }

        private string ProContentAdd(HttpContext context)
        {
            string type = context.Request.Params["type"].Trim();
            string content = context.Request.Params["pw_name"] == null ? "" : context.Request.Params["pw_name"].Trim();
            string categorySid = context.Request.Params["pw_sid"] == null ? "" : context.Request.Params["pw_sid"].Trim();
            string pgroup = context.Request.Params["pgroup"] == null ? "" : context.Request.Params["pgroup"].Trim();
            string remark = context.Request.Params["pc_remark"] == null ? "" : context.Request.Params["pc_remark"].Trim();
            string pssid = context.Request.Params["c_pssid"] == null ? "" : context.Request.Params["c_pssid"].Trim();
            string sequence = context.Request.Params["forwardContent"] == null ? "" : context.Request.Params["forwardContent"].Trim();
            Model.project_specific_item_model model = new Model.project_specific_item_model();
            model.name = content;
            model.group_sid = pgroup;
            model.remark = remark;
            model.s_sid = pssid;
            model.isChild = 0;
            model.parent_sid = 0;
            model.sequence =sequence==""?0: int.Parse(sequence);

            //return new BLL.project_specific_item_model().add(model);
            string revalue = "";
            switch (type)
            {
                case "0":
                    revalue= new DAL.project_specific_item_model().insert_proc(model, "Insert1");
                    break;
                case "2":
                    revalue = new DAL.project_specific_item_model().insert_proc(model, "Insert2", categorySid);
                    break;
                case "3":
                    revalue = new DAL.project_specific_item_model().insert_proc(model, "Insert2", categorySid);
                    break;
                default:
                    revalue = "操作失败。";
                    break;
            }
            return revalue;
        }

        private string ProContentUpdate(HttpContext context)
        {
            string type = context.Request.Params["type"].Trim();
            string sid = context.Request.Params["pc_sid"] == null ? "" : context.Request.Params["pc_sid"].Trim();
            string content = context.Request.Params["pw_name"] == null ? "" : context.Request.Params["pw_name"].Trim();
            string categorySid = context.Request.Params["pw_sid"] == null ? "" : context.Request.Params["pw_sid"].Trim();
            string pgroup = context.Request.Params["pgroup"] == null ? "" : context.Request.Params["pgroup"].Trim();
            string remark = context.Request.Params["pc_remark"] == null ? "" : context.Request.Params["pc_remark"].Trim();
            string pssid = context.Request.Params["c_pssid"] == null ? "" : context.Request.Params["c_pssid"].Trim();
            string sequence = context.Request.Params["forwardContent"] == null ? "" : context.Request.Params["forwardContent"].Trim();
            //string content = context.Request.Params["pw_name"].Trim();
            //string pgroup = context.Request.Params["pgroup"].Trim();
            //string remark = context.Request.Params["pc_remark"].Trim();
            //string pssid = context.Request.Params["c_pssid"].Trim();
            //string sequence = context.Request.Params["forwardContent"].Trim();
            Model.project_specific_item_model model = new BLL.project_specific_item_model().GetModel(int.Parse(sid));//new Model.project_specific_item_model();
            //model.sid = int.Parse(sid);
            model.name = content;
            model.group_sid = pgroup;
            model.remark = remark;
            model.s_sid = pssid;
            model.isChild = 0;
            model.sequence = int.Parse(sequence);

            string revalue = "";
            switch (type)
            {
                case "0":
                    revalue = new DAL.project_specific_item_model().update_proc(model, "Update1");
                    break;
                case "2":
                    revalue = new DAL.project_specific_item_model().update_proc(model, "Update2", categorySid);
                    break;
                default:
                    revalue = "操作失败。";
                    break;
            }
            return revalue;
        }

        private string ContentDel(HttpContext context)
        {
            string sid = context.Request.Params["sid"].Trim();
            ///return new BLL.project_specific_item_model().deleteContent(sid);
            return new DAL.project_specific_item_model().deleteContent(sid, "Delete1");
        }

        private string ItemDel(HttpContext context)
        {
            string sid = context.Request.Params["sid"].Trim();
            //return new BLL.project_specific_item_model().delete(sid);
            return new DAL.project_specific_item_model().deleteItem(sid, "DeleteItem");
        }

        private string GetStageContentItem(HttpContext context)
        {
            DataTable dt = new DataTable();
            string where = "";
            if (context.Request.Params["sid"].Trim() != "")
            {
                where = " and sid!=" + context.Request.Params["sid"].Trim();
            }
            DataSet ds = new BLL.Common().GetList("select row_number()over (order by sequence) as rowid,name from project_specific_item_model where  isChild=1 and parent_sid='" + context.Request.Params["pcsid"].Trim() + "' " + where + " order by sequence asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            DataRow dr = dt.NewRow();
            dr["rowid"] = "0";
            dr["name"] = "最顶";
            dt.Rows.InsertAt(dr, 0);

            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        private string ProjectContentCombo(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select sid,name from project_specific_item_model where s_sid='" + context.Request.Params["ps_sid"].Trim() + "' and isChild=0 order by sequence asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        private string ProItemAdd(HttpContext context)
        {
            string content = context.Request.Params["item_name"].Trim();
            string pcontent = context.Request.Params["pcontent"].Trim();
            string remark = context.Request.Params["item_remark"].Trim();
            string pssid = context.Request.Params["item_pssid"].Trim();
            string sequence = context.Request.Params["forwarditem"].Trim();
            Model.project_specific_item_model model = new Model.project_specific_item_model();
            model.name = content;
            model.parent_sid = int.Parse(pcontent);
            model.remark = remark;
            model.s_sid = pssid;
            model.isChild = 1;
            model.sequence = int.Parse(sequence);

            //return new BLL.project_specific_item_model().addItem(model);
            return new DAL.project_specific_item_model().insert_proc(model, "InsertItem");
        }

        private string ProItemUpdate(HttpContext context)
        {
            string sid = context.Request.Params["item_sid"].Trim();
            string content = context.Request.Params["item_name"].Trim();
            string pcontent = context.Request.Params["pcontent"].Trim();
            string remark = context.Request.Params["item_remark"].Trim();
            string pssid = context.Request.Params["item_pssid"].Trim();
            string sequence = context.Request.Params["forwarditem"].Trim();
            Model.project_specific_item_model model = new BLL.project_specific_item_model().GetModel(int.Parse(sid));//new Model.project_specific_item_model();
            //model.sid = int.Parse(sid);
            model.name = content;
            model.parent_sid = int.Parse(pcontent);
            model.remark = remark;
            model.s_sid = pssid;
            model.isChild = 1;
            model.sequence = int.Parse(sequence);

            //return new BLL.project_specific_item_model().updateItem(model);
            return new DAL.project_specific_item_model().update_proc(model, "UpdateItem");
        }

        private string GetStageType(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select value,text from project_stage_type");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
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