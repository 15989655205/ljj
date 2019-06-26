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
    /// Project 的摘要说明
    /// </summary>
    public class Project : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            if (bu == null)
            {
                context.Response.Write("登录超时，请重新登录。");
                //context.Response.Redirect("~/Login.aspx"); 
                return;
                //context.Server.Transfer("/Login.aspx");
                //context.Response.Redirect("../Login.aspx"); 
                //context.Response.Write("<script type='text/javascript'>window.top.location.href='/Login.aspx';</script>");
            }
            string type = context.Request["action"];
            string reValue = "";
            switch (type)
            {
                case "list":
                    reValue = QueryList(context);
                    break;
                case "sub_list":
                    reValue = SubList(context);
                    break;
                case "add":
                    reValue = Add(context);
                    break;
                case "update":
                    reValue = Edit(context);
                    break;
                case "dels":
                    reValue = Dels(context);
                    break;
                case "stage_add":
                    reValue = StageAdd(context);
                    break;
                case "stage_edit":
                    reValue = StageEdit(context);
                    break;
                case "stage_del":
                    reValue = StageDel(context);
                    break;
                case "imp_list":
                    reValue = ImpList(context);
                    break;
                case "impList":
                    reValue = ImpAllList(context);
                    break;
                case "imp_edit":
                    reValue = ImpEdit(context);
                    break;
                case "imp_del_check":
                    reValue = ImpDelCheck(context);
                    break;
                case "imp_userUpdate_check":
                    reValue = ImpUserUpdateCheck(context);
                    break;
                case "group_list":
                    reValue = GroupList(context);
                    break;
                case "group_edit":
                    reValue = GroupEdit(context);
                    break;
                case "groupList":
                    reValue = GroupAllList(context);
                    break;
                case "group_del_check":
                    reValue = GroupDelCheck(context);
                    break;
                case "imp_add":
                    reValue = ImpAdd(context);
                    break;
                case "imp_update":
                    reValue = ImpUpdate(context);
                    break;
                case "imp_del":
                    reValue = ImpDel(context);
                    break;
                case "content_list":
                    reValue = ContentList(context);
                    break;
                case "content_master_list":
                    reValue = ContentMasterList(context);
                    break;
                case "content_item_list":
                    reValue = ContentItemList(context);
                    break;
                case "content_edit":
                    reValue = ContentEdit(context);
                    break;
                case "content_item_edit":
                    reValue = ContentItemEdit(context);
                    break;
                case "content_del_check":
                    reValue = ContentDelCheck(context);
                    break;
                case "project_group_combo":
                    reValue = ProjectGroupCombo(context);
                    break;
                case "project_implement_combo":
                    reValue = ProjectImplementCombo(context);
                    break;
                case "project_implement_user_combo":
                    reValue = ProjectImplementUserCombo(context);
                    break;
                case "get_imp_user":
                    reValue = GetProjectImpUsers(context);
                    break;
                case "project_content_combo":
                    reValue = ProjectContentCombo(context);
                    break;
                case "pro_content_add":
                    reValue = ProjectContentAdd(context);
                    break;
                case "get_content_group":
                    reValue = GetContentGroup(context);
                    break;
                case "get_imp_all_user":
                    reValue = GetAllImpUsers(context);
                    break;
                case "checkTime":
                    reValue = CheckTime(context);
                    break;
                case "pro_content_edit":
                    reValue = ProjectContentEdit(context);
                    break;
                case "content_view_item":
                    reValue = ContentViewItem(context);
                    break;
                case "content_item":
                    reValue = ContentItem(context);
                    break;
                case "content_common_item":
                    reValue = ContentCommonItem(context);
                    break;
                case "construction_item_gridedit":
                    reValue=ConstructionItem_gridedit(context);
                    break;
                case "construction_item":
                    reValue = ConstructionItem(context);
                    break;
                case "pro_content_del":
                    reValue = ProjectContentDel(context);
                    break;
                case "getAuditUser":
                    reValue = GetAuditUser(context);
                    break;
                case "getAllProjectNotic":
                    reValue = GetAllProjectNotic(context);
                    break;
                case "getStage":
                    reValue = GetStage(context);
                    break;
                case"flow_list":
                    reValue = FlowList(context);
                    break;
                case"flow_edit":
                    reValue = FlowEdit(context);
                    break;
                case "check_imp":
                    reValue = CheckImp(context);
                    break;
                case "flow_del_check":
                    reValue = flow_del_check(context);
                    break;
                case "content_del":
                    reValue = content_del(context);
                    break;
                case"item_del":
                    reValue = item_del(context);
                    break;
                case "del_headAppr_check":
                    reValue = del_headAppr_check(context);
                    break;
                case "del_finalAppr_check":
                    reValue = del_finalAppr_check(context);
                    break;
                case"all_template":
                    reValue = all_template(context);
                    break;
                case"stage_model":
                    reValue = stage_model(context);
                    break;
                case"stage_add_zxf":
                    reValue = stage_add_zxf(context);
                    break;
                case"short":
                    reValue = short_name(context);
                    break;
                case"stage_fw":
                    reValue = stage_fw(context);
                    break;
                case"model_class_change":
                    reValue = model_class_change(context);
                    break;
                case"project_model_class":
                    reValue = project_model_class(context);
                    break;
                case "getStageSEDate":
                    reValue = GetStageSEDate(context);
                    break;
                default: break;
            }
            context.Response.Write(reValue);
        }
        /// <summary>
        /// 项目模板
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string project_model_class(HttpContext context)
        {
            DataTable dt = new BLL.Common().GetList("select distinct isnull(v10,'未分类') as name,v10 as name1 from project ").Tables[0];
            string s = DBUtility.JsonHelper.DataTable2Json_Combo(dt);
            return s = s.Replace("[", "[{\"name\":\"请选择\",\"name1\":\"请选择\"},");
        }
        /// <summary>
        /// 改变project分类模板
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string model_class_change(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Proc_Project", WCDataAction.Query1);
            dsp.InputPars.Add("@p_sid",context.Request["p_sid"]);
            dsp.InputPars.Add("@tmp_type_ID",context.Request["v10"]);
            if (db.Execute(dsp).ExecuteState)
            {
                return "success";
            }
            else
            {
                return "faile";
            }
        }
        /// <summary>
        /// 获取阶段的工作流程
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string stage_fw(HttpContext context)
        {
            DataTable dt = new BLL.Common().GetList("select sid,work_flow_name from project_work_flow where s_sid=" + context.Request["s_sid"] + " order by sequence asc").Tables[0];
           return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        /// <summary>
        /// 获得简称（zxf）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string short_name(HttpContext context)
        {
            string sql = context.Request["sql"];
            DataTable dt = new BLL.Common().GetList("select dbo.getUserAbbr_fu('"+context.Request["sql"]+"')").Tables[0];
            return dt.Rows[0][0].ToString();
        }
        /// <summary>
        /// 添加阶段（zxf）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string stage_add_zxf(HttpContext context)
        {
            string sql = context.Request["selections"];
            string p_sid= context.Request["p_sid"];
            string tmp_type_ID = context.Request["s_sid"];
           return new BLL.project().insert1(sql, p_sid, tmp_type_ID);
        }
        /// <summary>
        /// 根据分类模板的sid，读取阶段（zxf）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string stage_model(HttpContext context)
        {
            DataTable dt = new BLL.Common().GetList("select * from  stage where p_sid='" + context.Request["sid"]+"'").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }
        /// <summary>
        /// 模板（zxf）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string all_template(HttpContext context)
        {
            
            DataTable dt = new BLL.Common().GetList("select sid,name from Project_Template_Type").Tables[0];
            DataRow dr = dt.NewRow();
            dr["sid"]=0;
            dr["name"]="公共";
            dt.Rows.Add(dr);
            if (!string.IsNullOrEmpty(context.Request["sid"]))
            {
                DataRow dr1 = new BLL.Common().GetList("select '0' as sid,isnull(v10,'未分类') as name from project where sid="+context.Request["sid"]).Tables[0].Rows[0];
                bool flag = true;
                
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dr1["name"].ToString().Trim()==dt.Rows[j]["name"].ToString().Trim())
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        dr = dt.NewRow();
                        dr["sid"] = dr1["sid"];
                        dr["name"] = dr1["name"];
                        dt.Rows.Add(dr);
                    }
               

            }
            string s = DBUtility.JsonHelper.DataTable2Json_Combo(dt);
            return s;
        }

        /// <summary>
        /// 删除项目中的细目(create by zxf)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string item_del(HttpContext context)
        {
            string sid = context.Request["sid"].ToString();
            DataTable dt = new BLL.project_review().GetList(" si_sid='" + sid + "'").Tables[0];
            if (dt.Rows.Count==0)
            {
                return new BLL.project_specific_item().Delete(sid);
            }
            else
            {
                return "该项目已经有提交记录，无法删除！";
            }
            
        }

        /// <summary>
        /// 删除项目中的工作内容（create by zxf)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string content_del(HttpContext context)
        {
            //ContentDelCheck(context);
            if (!DbHelperSQL.Exists("select count(1) from project_review where si_sid in (select sid from project_specific_item where parent_sid='" + context.Request.Params["sid"].Trim() + "')"))
            {
                //return "1";
                string csid = context.Request["sid"];
                return new BLL.project_specific_item().deleteContent(csid);
            }
            else
            {
                return "有部份或者全部工作被提交不能删除。";
            }
            
        }

        /// <summary>
        /// 工作流程删除时检测是否被引用（create by zxf）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string flow_del_check(HttpContext context)
        {
            if (DbHelperSQL.Exists("select count(1) from project_item_flow where fw_sid='" + context.Request.Params["sid"].Trim() + "'"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        /// <summary>
        /// create by zxf
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FlowEdit(HttpContext context)
        {
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            string p_sid = context.Request.Params["p_sid"].Trim();
            string s_sid = context.Request.Params["s_sid"].Trim();
            List<Model.project_work_flow> insert = new List<Model.project_work_flow>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_work_flow>(addstr);
            List<Model.project_work_flow> update = new List<Model.project_work_flow>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_work_flow>(updatestr);
            List<Model.project_work_flow> del = new List<Model.project_work_flow>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_work_flow>(delstr);

            List<Model.project_work_flow> sequence = new List<Model.project_work_flow>();
            sequence = JsonSerializerHelper.JSONStringToList<Model.project_work_flow>(allstr);

            return new BLL.project_work_flow().Edit(insert, update, del, sequence, p_sid,s_sid);
        }
        /// <summary>
        /// create by zxf
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FlowList(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList("select sid,work_flow_name,p_sid,s_sid,remark,sequence from project_work_flow where s_sid='" + context.Request.Params["s_sid"].Trim() + "' and p_sid='"+context.Request.Params["p_sid"]+"' order by sequence asc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }
        /// <summary>
        /// 删除阶段 （zxf）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string StageDel(HttpContext context)
        {
            string result = "";
            string selectid = context.Request.Params["cbx_select"].Trim();
            //return new BLL.flow_master().DeleteFlow(selectid);
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_Project", WCDataAction.Delete3);
            dsp.InputPars.Add("@s_sid", selectid);
            if (db.Execute(dsp).ExecuteState)
            {
                if (dsp.OutputPars["@out_str"].ToString().Trim() == "" || string.IsNullOrEmpty(dsp.OutputPars["@out_str"].ToString()))
                {
                    result = "success";
                }
                else
                {
                    result = dsp.OutputPars["@out_str"].ToString();
                }
            }
            return result;
        }
        /// <summary>
        /// 获取项目公告（zxf）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetAllProjectNotic(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_Project", WCDataAction.Query2);
            dsp.InputPars.Add("@end_date", DateTime.Now.ToString("yyyy-MM-dd"));
            dsp.InputPars.Add("@begin_date", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
            if (db.Execute(dsp).ExecuteState)
            {
                DataTable dt = new DataTable();
                dt = dsp.OutputDataSet.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
                }
                else
                {
                    return "{\"total\":0,\"rows\":[]}";
                }

            }
            else
            {
                return "{\"total\":0,\"rows\":[]}";
            }
        }

        //create by zxf
        public string GetAuditUser(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select v1 ,dbo.getNames_zxf(v1) as UserNames from project_specific_item where sid = '" + context.Request.Params["sid"].Trim() + "'");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["v1"] + "|" + dt.Rows[0]["UserNames"];
                }
                else
                {
                    return "";


                }

            }
            else
            {
                return "";
            }
        }

        public string ProjectContentEdit(HttpContext context)
        {
            string sid = context.Request.Params["sid"].Trim();
            string ssid = context.Request.Params["ssid"].Trim();
            string name = context.Request.Params["name"].Trim();
            string imp_content = context.Request.Params["imp_content"].Trim();
            string pgroup = context.Request.Params["pgroup"].Trim();
            string pw_content = context.Request.Params["pw_content"].Trim();
            string begin_date = context.Request.Params["begin_date"].Trim();
            string end_date = context.Request.Params["end_date"].Trim();
            string pc_remark = context.Request.Params["pc_remark"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            //string updatestr = context.Request.Params["updatestr"].Trim();
            //string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_work_implement> insert = new List<Model.project_work_implement>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_work_implement>(addstr);
            //List<Model.project_work_implement> update = new List<Model.project_work_implement>();
            //update = JsonSerializerHelper.JSONStringToList<Model.project_work_implement>(updatestr);
            //List<Model.project_work_implement> del = new List<Model.project_work_implement>();
            //del = JsonSerializerHelper.JSONStringToList<Model.project_work_implement>(delstr);
            Model.project_specific_item model = new Model.project_specific_item();
            if (int.Parse(imp_content) != 1)
            {
                model.parent_sid = int.Parse(pw_content);
                model.begin_date = DateTime.Parse(begin_date);
                model.end_date = DateTime.Parse(end_date);
                model.isChild = 1;
                model.v1 = context.Request["v1"];
            }
            else
            {
                model.parent_sid = 0;
                model.isChild = 0;
            }
            model.name = name;
            model.group_sid = pgroup;
            model.s_sid = ssid;
            model.remark = pc_remark;
            model.sid = int.Parse(sid);
            return new BLL.project_specific_item().update(int.Parse(imp_content), model, insert);

        }

        //create by zxf
        public string CheckTime(HttpContext context)
        {
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_Project", WCDataAction.Query1);
            dsp.InputPars.Add("@begin_date", context.Request["begin_date"]);
            dsp.InputPars.Add("@end_date", context.Request["end_date"]);
            dsp.InputPars.Add("@pc_sid", context.Request["pc_hsid"]);
            if (db.Execute(dsp).ExecuteState)
            {
                return dsp.OutputPars["@out_str"].ToString();
            }
            else
            {
                return "出错了！";
            }
        }
        //create by zxf
        public string GetAllImpUsers(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select *,b.implement_name as wtype,dbo.getNames_zxf(a.implementer_sid) as wusers from dbo.project_work_implement as a left join dbo.project_implement as b on a.imp_sid = b.sid where a.psi_sid='" + context.Request.Params["sid"].Trim() + "'");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
                }
                else
                {
                    return "{ total: 0, rows: [] }";


                }

            }
            else
            {
                return "";
            }
        }

        public string QueryList(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string type = context.Request.Params["type"] == null ? "" : context.Request.Params["type"].Trim();
            DataTable dt = new DataTable();
            int total = 0;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            string key = context.Request.Form["key"] != null ? context.Request.Form["key"].Trim() : "";
            string order = context.Request.Form["order"] != "" ? context.Request.Form["order"] : "desc";
            string sort = context.Request.Form["sort"] != "" ? context.Request.Form["sort"] : "sid";
            string where = " 1=1 ";
            string model_class = context.Request["class"];
            if (model_class != "" && !string.IsNullOrEmpty(model_class))
            {
                if (model_class != "请选择")
                {
                    if (model_class == "未分类")
                    {
                        where += " and v10 is null";
                    }

                    else
                    {
                        where += " and v10='" + model_class + "'";
                    }
                }
                
            }
            if (key != "" && !string.IsNullOrEmpty(key))
            {
                where += " and (project_name like '%" + key + "%' or project_code like '%" + key + "%' or prepared_by like '%" + key + "%' or project_manager like '%" + key + "%' or v10 like '%"+key+"%' )";
            }
            switch (type)
            {
                case "me":
                    where += " and ('" + bu.UserName + "' in (select implementer_sid from project_work_implement where psi_sid in (select sid from project_specific_item where s_sid in (select sid from project_stage where p_sid=project.sid) )))";
                    break;
                default:
                    break;
            }
            string table = "project";
            string show = "sid,project_name,project_code,prepared_by,reviewed_by,project_manager,remark,creation_date,create_date,create_person,update_date,update_person,dbo.getUserName_fu(create_person) as createP,dbo.getUserName_fu(update_person) as updateP,isnull(v10,'未分类') as model_class,v10";

            DataSet ds = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where);
            if (ds.Tables.Count > 0)
            {
                dt = new BLL.Common().GetList(table, sort, show, page, rows, out total, order, where).Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, total);

        }

        public string SubList(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string type = context.Request.Params["type"] == null ? "" : context.Request.Params["type"].Trim();
            string where = "";
            switch (type)
            {
                case "me":
                    where += " and ('" + bu.UserName + "' in (select implementer_sid from project_work_implement where psi_sid in (select sid from project_specific_item where s_sid =project_stage.sid) ))";
                    break;
                default:
                    break;
            }
            DataTable dt = new DataTable();
            //dt = new BLL.project_stage().GetList(" p_sid='" + context.Request.Params["psid"].Trim() + "' order by sequence asc").Tables[0];
            DataSet ds = new BLL.Common().GetList("select project_stage.*,[text] stageType,row_number()over (order by sequence) as rowid from project_stage left outer join project_stage_type on is_system=[value] where  p_sid='" + context.Request.Params["psid"].Trim() + "' "+where+" order by sequence asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);

        }

        public string Add(HttpContext context)
        {
            string projectName = context.Request["project_name"].Trim();
            string projectCode = context.Request["project_code"].Trim();
            string preparedBy = context.Request["prepared_by"].Trim();
            string reviewedBy = context.Request["reviewed_by"].Trim();
            string projectManager = context.Request["project_manager"].Trim();
            string creationDate = context.Request["creation_date"].Trim();
            string remark = context.Request["remark"].Trim();
            string groupAppr = context.Request["group_appr"] == null ? "" : context.Request["group_appr"].Trim();
            //string trialAppr = context.Request["trial_appr"].Trim();
            string qsAppr = context.Request["qs_appr"].Trim();
            string template = context.Request["template"] == null ? "" : context.Request["template"].Trim();
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];

            Model.project pModel = new Model.project();
            pModel.project_name = projectName;
            pModel.project_code = projectCode;
            pModel.prepared_by = preparedBy;
            pModel.reviewed_by = reviewedBy;
            pModel.project_manager = projectManager;
            pModel.creation_date = creationDate;
            pModel.remark = remark;//context.Session["UserID"].ToString();
            pModel.v1 = groupAppr;
            //pModel.v2 = trialAppr;
            pModel.v2 = qsAppr;
            pModel.v10 = template;
            pModel.create_person = bu.UserName.ToString().Trim();

            return new BLL.project().insert(pModel);
            
        }

        public string Edit(HttpContext context)
        {
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            string sid = context.Request["hsid"].Trim();
            string projectName = context.Request["project_name"].Trim();
            string projectCode = context.Request["project_code"].Trim();
            string preparedBy = context.Request["prepared_by"].Trim();
            string reviewedBy = context.Request["reviewed_by"].Trim();
            string projectManager = context.Request["project_manager"].Trim();
            string creationDate = context.Request["creation_date"].Trim();
            string remark = context.Request["remark"].Trim();
            string groupAppr = context.Request["group_appr"] == null ? "" : context.Request["group_appr"].Trim();
            //string groupAppr = context.Request["group_appr"].Trim();
            //string trialAppr = context.Request["trial_appr"].Trim();
            string qsAppr = context.Request["qs_appr"].Trim();

            Model.project pModel = new BLL.project().GetModel(int.Parse(sid));
            pModel.project_name = projectName;
            pModel.project_code = projectCode;
            pModel.prepared_by = preparedBy;
            pModel.reviewed_by = reviewedBy;
            pModel.project_manager = projectManager;
            pModel.creation_date = creationDate;
            pModel.remark = remark;//context.Session["UserID"].ToString();
            pModel.v1 = groupAppr;
            //pModel.v2 = trialAppr;
            pModel.v2 = qsAppr;
            pModel.update_date = DateTime.Now;
            pModel.update_person=bu.UserName.ToString().Trim();

            return new BLL.project().update(pModel);
        }

        public string Dels(HttpContext context)
        {
            string result = "";
            string selectid = context.Request.Params["cbx_select"].Trim();
            //return new BLL.flow_master().DeleteFlow(selectid);
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_Project", WCDataAction.Delete1);
            dsp.InputPars.Add("@p_sid", selectid);
            if (db.Execute(dsp).ExecuteState)
            {
                if (dsp.OutputPars["@out_str"].ToString().Trim() == "" || string.IsNullOrEmpty(dsp.OutputPars["@out_str"].ToString()))
                {
                    result = "success";
                }
                else
                {
                    result = dsp.OutputPars["@out_str"].ToString();
                }
            }
            return result;
        }

        public string StageAdd(HttpContext context)
        {
            string psid = context.Request["psid"].Trim();
            string stageName = context.Request["txtStageName"].Trim();
            string sDate = context.Request["txtBeginDate"].Trim();
            string eDate = context.Request["txtEndDate"].Trim();
            string remark = context.Request["stage_remark"].Trim();
            string sequence = context.Request["forwardStage"].Trim();
            string stageType = context.Request["stageType"].Trim();

            //Model.project_stage sModel = new Model.project_stage();
            //sModel.p_sid = psid;
            //sModel.stage_name = stageName;
            //sModel.sequence = int.Parse(sequence);
            //sModel.begin_date = DateTime.Parse(beginDate);
            //sModel.end_date = DateTime.Parse(endDate);
            //sModel.remark = remark;

            //return new BLL.project_stage().add(sModel);
            return new BLL.project_stage().add(stageName, psid, DateTime.Parse(sDate), DateTime.Parse(eDate), int.Parse(sequence), remark,stageType);
        }

        public string StageEdit(HttpContext context)
        {
            string sid = context.Request["pssid"].Trim();
            string psid = context.Request["psid"].Trim();
            string stageName = context.Request["txtStageName"].Trim();
            string sDate = context.Request["txtBeginDate"].Trim();
            string eDate = context.Request["txtEndDate"].Trim();
            string remark = context.Request["stage_remark"].Trim();
            string sequence = context.Request["forwardStage"].Trim();
            string stageType = context.Request["stageType"].Trim();
            return new BLL.project_stage().update(sid, stageName, psid, DateTime.Parse(sDate), DateTime.Parse(eDate), int.Parse(sequence), remark, stageType);
        }

        public string ImpList(HttpContext context)
        {
            DataTable dt = new DataTable();
            //dt = new BLL.project_implement().GetList(" s_sid='" + context.Request.Params["ssid"].Trim() + "' order by sid asc").Tables[0];
            dt = new BLL.Common().GetList("select sid,implement_name,s_sid,implementers_sid,implementers,remark,dbo.getusernames_fu(implementers_sid) as impUserNames,sequence,dbo.get_fw_name_zxf(v1) as fw_name,v1 from project_implement where s_sid='" + context.Request.Params["ssid"].Trim() + "' order by sequence asc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string ImpAllList(HttpContext context)
        {
            DataTable dt = new DataTable();
            string key = context.Request.Params["key"] == null ? "" : context.Request.Params["key"].Trim();
            string where = " where 1=1";
            if (key != "")
            {
                where += " and implement_name like '%" + key + "%' or dbo.getusernames_fu(implementers_sid) like '%" + key + "%'";
            }
            dt = new BLL.Common().GetList("select  distinct ROW_NUMBER() OVER(ORDER BY implement_name asc) as id,  implement_name,implementers_sid,implementers,dbo.getusernames_fu(implementers_sid) as impUserNames from project_implement  "+where).Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string ImpEdit(HttpContext context)
        {
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_implement> insert = new List<Model.project_implement>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_implement>(addstr);
            List<Model.project_implement> update = new List<Model.project_implement>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_implement>(updatestr);
            List<Model.project_implement> del = new List<Model.project_implement>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_implement>(delstr);

            List<Model.project_implement> sequence = new List<Model.project_implement>();
            sequence = JsonSerializerHelper.JSONStringToList<Model.project_implement>(allstr);

            return new BLL.project_implement().Edit(insert, update, del, sequence);
        }

        public string ImpDelCheck(HttpContext context)
        {
            if (DbHelperSQL.Exists("select count(1) from project_work_implement where imp_sid=" + context.Request.Params["sid"].Trim()))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public string ImpUserUpdateCheck(HttpContext context)
        {
            string str = DbHelperSQL.GetSingle("select dbo.getImpUid_fu(" + context.Request.Params["sid"].Trim() + ")").ToString();
            if (str != "")
            {
                string str2 = context.Request.Form["cusers"] == null ? "" : context.Request.Form["cusers"].Trim();
                string[] arr1 = str.Split(',');
                string[] arr2 = str2.Split(',');

                string reVal = "";
                for (int i = 0; i < arr1.Length; i++)
                {
                    bool isback = false;
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        if (arr1[i].Trim() == arr2[j].Trim())
                        {
                            isback = true;
                            break;
                        }
                    }
                    if (!isback)
                    {
                        reVal += arr1[i] + ",";
                        //break;
                    }
                }
                if (reVal != "")
                {
                    reVal = reVal.Substring(0, reVal.Length - 1);
                    object tmp = DbHelperSQL.GetSingle("select dbo.getUserNames_fu('" + reVal + "')");
                    reVal = tmp == null ? "" : tmp.ToString();
                }
                return reVal;
            }
            else
            {
                return "";
            }
        }

        public string GroupList(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.project_group().GetList(" ps_sid='" + context.Request.Params["ssid"].Trim() + "' order by sequence asc").Tables[0];
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string GroupAllList(HttpContext context)
        {
            DataTable dt = new DataTable();
            dt = new BLL.Common().GetList(" select distinct group_name id ,group_name as [text] from project_group").Tables[0];
            return DBUtility.JsonHelper.DataTable2List(dt);
        }

        public string GroupDelCheck(HttpContext context)
        {
            if( DbHelperSQL.Exists("select count(1) from project_specific_item where group_sid='" + context.Request.Params["sid"].Trim() + "'"))
            {
                return "1";
            }else{
                return "0";
            }
        }

        public string GroupEdit(HttpContext context)
        {
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_group> insert = new List<Model.project_group>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_group>(addstr);
            List<Model.project_group> update = new List<Model.project_group>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_group>(updatestr);
            List<Model.project_group> del = new List<Model.project_group>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_group>(delstr);

            List<Model.project_group> sequence = new List<Model.project_group>();
            sequence = JsonSerializerHelper.JSONStringToList<Model.project_group>(allstr);

            return new BLL.project_group().Edit(insert, update, del, sequence);
        }

        public string ImpAdd(HttpContext context)
        {
            string s_sid = context.Request["imp_hsid"].Trim();
            string implement_name = context.Request["imp_name"].Trim();
            string implementers_sid = context.Request["imp_uid"].Trim();
            string implementers = context.Request["imp_un"].Trim();
            string remark = context.Request["imp_remark"].Trim();

            Model.project_implement sModel = new Model.project_implement();
            sModel.s_sid = s_sid;
            sModel.implement_name = implement_name;
            sModel.implementers_sid = implementers_sid;
            sModel.implementers = implementers;
            sModel.remark = remark;

            return new BLL.project_implement().add(sModel);
        }

        public string ImpUpdate(HttpContext context)
        {
            string sid = context.Request["imp_sid"].Trim();
            string s_sid = context.Request["imp_hsid"].Trim();
            string implement_name = context.Request["imp_name"].Trim();
            string implementers_sid = context.Request["imp_uid"].Trim();
            string implementers = context.Request["imp_un"].Trim();
            string remark = context.Request["imp_remark"].Trim();

            Model.project_implement sModel = new BLL.project_implement().GetModel(int.Parse(sid));
            sModel.s_sid = s_sid;
            sModel.implement_name = implement_name;
            sModel.implementers_sid = implementers_sid;
            sModel.implementers = implementers;
            sModel.remark = remark;

            return new BLL.project_implement().update(sModel);
        }

        public string ImpDel(HttpContext context)
        {
            string selectid = context.Request.Params["imp_cbx_select"].Trim();
            return new BLL.project_implement().DeleteList(selectid);
        }

        public string ContentList(HttpContext context)
        {
            /* 20130826改版
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("  select * ,dbo.getUserNames_fu(dbo.getProItemUser_fu(a.sid)) implementer,group_name from project_specific_item a left outer join project_group b on a.group_sid=b.sid where s_sid=" + context.Request.Params["pssid"].Trim() + " ");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            //return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
            return DBUtility.JsonHelper.DT2GridTree(dt, "", "parent_sid");
             */

            //string dynamicColumn = "";

            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("  select * ,dbo.getUserNames_fu(dbo.getProItemUser_fu(a.sid)) implementer,group_name,dbo.getUserNames_fu(a.v1) groupAppr,dbo.getUserNames_fu(a.v2) trialAppr,dbo.getUserNames_fu(a.v3) qsAppr from project_specific_item a left outer join project_group b on a.group_sid=b.sid where s_sid=" + context.Request.Params["pssid"].Trim() + " ");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + context.Request.Params["pssid"].Trim() + "'");
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

                    datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "imp_abb" + impDT.Rows[i]["sid"].ToString().Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable impworkDT = new DataTable();
                        impDS = new BLL.project_work_implement().GetList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                dt.Rows[j]["imp_abb" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["implementer"].ToString().Trim();
                                dt.Rows[j]["imp" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["implementer_sid"].ToString().Trim();
                            }
                        }
                    }
                }
            }
            return DBUtility.JsonHelper.DT2GridTree(dt, "", "parent_sid");


            //DataTable impDT = new DataTable();
            //DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + context.Request.Params["pssid"].Trim() + "'");
            //if (impDS.Tables.Count > 0)
            //{
            //    impDT = impDS.Tables[0];
            //}
            //for (int i = 0; i < impDT.Rows.Count; i++)
            //{
            //    DataColumn datetimeColumn = new DataColumn();
            //    //该列的数据类型
            //    datetimeColumn.DataType = System.Type.GetType("System.String");
            //    //该列得名称
            //    datetimeColumn.ColumnName = "imp" + impDT.Rows[i]["sid"].ToString().Trim();
            //    //该列得默认值
            //    datetimeColumn.DefaultValue = "";
            //    dt.Columns.Add(datetimeColumn);

            //    dynamicColumn += "{\"field\":\"" + "imp" + impDT.Rows[i]["sid"].ToString().Trim() + "\",\"title\":\"" + impDT.Rows[i]["implement_name"].ToString().Trim() + "\",\"width\":100,align:\"center\",\"halign\": \"center\"},";

            //    for (int j = 0; j < dt.Rows.Count; j++)
            //    {
            //        DataTable impworkDT = new DataTable();
            //        impDS = new BLL.project_work_implement().GetList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
            //        if (impDS.Tables.Count > 0)
            //        {
            //            impworkDT = impDS.Tables[0];
            //            if (impworkDT.Rows.Count > 0)
            //            {
            //                dt.Rows[j]["imp" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["implementer"].ToString().Trim();
            //            }
            //        }
            //    }
            //}

            //string json = DBUtility.JsonHelper.DT2GridTree(dt, "", "parent_sid");
            //json = json.Substring(0, json.LastIndexOf('}'));
            //json += ",\"columns\":[  ";
            //json += "{ \"title\": \"小组\", \"field\": \"group_name\", \"width\": 60, \"halign\": \"center\", \"align\": \"center\", \"editor\": \"text\",\"formatter\": function (value, rowData, rowIndex) {if (rowData.parent_sid == 0) {return \"<a class='a_black' title='\" + value + \"'><span class='mlength'>\" + value + \"</span></a>\";}else {return \"\";}}},";
            //json += "{ \"title\": \"工作内容/细目\", \"field\":\"name\", \"width\": 150, \"halign\": \"center\", \"editor\":\"text\",                        \"formatter\": function (value, rowData, rowIndex) {return \"<a class='a_black' title='\" + value + \"'><span class='mlength'>\" + value + \"</span></a>\";}},";
            //json += dynamicColumn;
            //json += "{'field':'hobby','title':'Hobby','width':100,'align':'center'}";
            //json += "]}";
            //return json;
        }

        public string ContentMasterList(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("  select a.* ,dbo.getUserNames_fu(dbo.getProItemUser_fu(a.sid)) implementer,group_name,dbo.getUserNames_fu(a.v1) groupAppr,dbo.getUserNames_fu(a.v2) trialAppr,dbo.getUserNames_fu(a.v3) qsAppr,row_number()over (order by a.sequence) as rowid from project_specific_item a left outer join project_group b on a.group_sid=b.sid where s_sid=" + context.Request.Params["pssid"].Trim() + " and isChild=0 order by a.sequence asc ");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt,dt.Rows.Count);
        }

        public string ContentItemList(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("  select a.sid,a.name,a.parent_sid,a.s_sid,a.sequence,a.isChild,a.group_sid,convert(varchar(10),a.begin_date,120) begin_date,convert(varchar(10),a.end_date,120) as end_date,a.v1,a.v2,a.v3 ,a.remark,dbo.getUserNames_fu(dbo.getProItemUser_fu(a.sid)) implementer,group_name,dbo.getUserNames_fu(a.v1) groupAppr,dbo.getUserNames_fu(a.v2) trialAppr,dbo.getUserNames_fu(a.v3) qsAppr,row_number()over (order by a.sequence) as rowid from project_specific_item a left outer join project_group b on a.group_sid=b.sid where parent_sid='" + context.Request.Params["psid"].Trim() + "' order by a.sequence asc ");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + context.Request.Params["pssid"].Trim() + "'");
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

                    datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "imp_abb" + impDT.Rows[i]["sid"].ToString().Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable impworkDT = new DataTable();
                        impDS = new BLL.project_work_implement().GetList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                dt.Rows[j]["imp_abb" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["implementers"].ToString().Trim();
                                dt.Rows[j]["imp" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["implementer_sid"].ToString().Trim();
                            }
                        }
                    }
                }
            }
            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string ContentEdit(HttpContext context)
        {
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_specific_item> insert = new List<Model.project_specific_item>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_specific_item>(addstr);
            List<Model.project_specific_item> update = new List<Model.project_specific_item>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_specific_item>(updatestr);
            List<Model.project_specific_item> del = new List<Model.project_specific_item>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_specific_item>(delstr);

            List<Model.project_specific_item> sequence = new List<Model.project_specific_item>();
            sequence = JsonSerializerHelper.JSONStringToList<Model.project_specific_item>(allstr);

            return new BLL.project_specific_item().Edit(insert, update, del, sequence);
        }

        public string ContentItemEdit(HttpContext context)
        {
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_specific_item> insert = new List<Model.project_specific_item>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_specific_item>(addstr);
            List<Model.project_specific_item> update = new List<Model.project_specific_item>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_specific_item>(updatestr);
            List<Model.project_specific_item> del = new List<Model.project_specific_item>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_specific_item>(delstr);

            List<Model.project_specific_item> sequence = new List<Model.project_specific_item>();
            sequence = JsonSerializerHelper.JSONStringToList<Model.project_specific_item>(allstr);

            return new BLL.project_specific_item().ItemEdit(insert, update, del, sequence);
        }

        public string ContentDelCheck(HttpContext context)
        {
            if (DbHelperSQL.Exists("select count(1) from project_specific_item where parent_sid='" + context.Request.Params["sid"].Trim() + "'"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public string ProjectGroupCombo(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select sid,group_name from project_group where ps_sid=" + context.Request.Params["ps_sid"].Trim() + "");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        public string ProjectImplementCombo(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select sid,implement_name from project_implement where s_sid='" + context.Request.Params["ps_sid"].Trim() + "'");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        public string ProjectImplementUserCombo(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select username,name from baseuser where username in(select * from dbo.getTable('" + context.Request["usersid"] + "',','))");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            ds = new BLL.Common().GetList("select implementers_sid,implementers from project_implement where sid='" + context.Request["pi_sid"] + "'");
            DataTable tmpDT = new DataTable();
            DataTable reDT = dt.Clone();
            if (ds.Tables.Count > 0)
            {
                tmpDT = ds.Tables[0];
                if (tmpDT.Rows.Count > 0)
                {
                    string unames = tmpDT.Rows[0]["implementers_sid"].ToString().Trim();
                    string uns = tmpDT.Rows[0]["implementers"].ToString().Trim();
                    string[] arrUnames = unames.Split(',');
                    string[] arrUns = uns.Split(',');
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < arrUnames.Length; j++)
                        {
                            if (dt.Rows[i]["username"].ToString().Trim() == arrUnames[j].Trim())
                            {
                                DataRow dr = reDT.NewRow();
                                dr["username"] = dt.Rows[i]["username"].ToString().Trim();
                                dr["name"] = dt.Rows[i]["name"].ToString().Trim() + "-" + arrUns[j].Trim();
                                reDT.Rows.Add(dr);
                                break;
                            }
                        }
                    }
                }
            }
            return DBUtility.JsonHelper.DataTable2Json_Combo(reDT);
        }

        public string GetProjectImpUsers(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select implementers_sid from project_implement where sid='" + context.Request.Params["sid"].Trim() + "'");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                return dt.Rows[0]["implementers_sid"].ToString().Trim();
            }
            else
            {
                return "";
            }
        }

        public string ProjectContentCombo(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select sid,name from project_specific_item where s_sid='" + context.Request.Params["ps_sid"].Trim() + "' and isChild=0");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        public string ProjectContentAdd(HttpContext context)
        {
            string ssid = context.Request.Params["ssid"].Trim();
            string name = context.Request.Params["name"].Trim();
            string imp_content = context.Request.Params["imp_content"].Trim();
            string pgroup = context.Request.Params["pgroup"].Trim();
            string pw_content = context.Request.Params["pw_content"].Trim();
            string begin_date = context.Request.Params["begin_date"].Trim();
            string end_date = context.Request.Params["end_date"].Trim();
            string pc_remark = context.Request.Params["pc_remark"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.project_work_implement> insert = new List<Model.project_work_implement>();
            insert = JsonSerializerHelper.JSONStringToList<Model.project_work_implement>(addstr);
            List<Model.project_work_implement> update = new List<Model.project_work_implement>();
            update = JsonSerializerHelper.JSONStringToList<Model.project_work_implement>(updatestr);
            List<Model.project_work_implement> del = new List<Model.project_work_implement>();
            del = JsonSerializerHelper.JSONStringToList<Model.project_work_implement>(delstr);
            Model.project_specific_item model = new Model.project_specific_item();
            if (int.Parse(imp_content) != 1)
            {
                model.parent_sid = int.Parse(pw_content);
                model.begin_date = DateTime.Parse(begin_date);
                model.end_date = DateTime.Parse(end_date);
                model.isChild = 1;
                model.v1 = context.Request["v1"].Trim();
            }
            else
            {
                model.parent_sid = 0;
                model.isChild = 0;
            }
            model.name = name;
            model.group_sid = pgroup;
            model.s_sid = ssid;
            model.remark = pc_remark;


            return new BLL.project_specific_item().add(int.Parse(imp_content), model, insert);
        }

        public string GetContentGroup(HttpContext context)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select group_sid from project_specific_item where sid='" + context.Request.Params["sid"].Trim() + "'");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                return dt.Rows[0]["group_sid"].ToString().Trim();
            }
            else
            {
                return "";
            }
        }

        public string ContentViewItem(HttpContext context)
        {
            string worker = context.Request.Params["worker"] == null ? "" : context.Request.Params["worker"].Trim();
            string type = context.Request.Params["type"] == null ? "" : context.Request.Params["type"].Trim();
            string isConstruction = context.Request.Params["isConstruction"] == null ? "" : context.Request.Params["isConstruction"].Trim();
            Model.BaseUser bu = context.Session["login"] as Model.BaseUser;
            string where = "";
            switch (type)
            {
                case "me":
                    where += " and ('" + bu.UserName + "' in (select implementer_sid from project_work_implement where psi_sid =a.sid) )";
                    break;
                default:
                    break;
            }
            if (worker != "")
               // where += " and dbo.getProworkUid_fu(a.sid) in ('" + worker + "')";
                where += " and dbo.getInProworkUid_fu(a.sid,'" + worker + "')>0";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            //ds = new BLL.Common().GetList("select  a.sid,b.name as contentName,d.group_name,a.name as itemName,a.unfinished_reason,a.solution,a.reviewed,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_zxf(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate,dbo.getProReview_result_zxf(a.sid) as review_results,dbo.getProjectReviewers_zxf1(a.sid) as reviewers,dbo.getProjectReviewers_zxf(a.sid) as reviewer,dbo.getProjectReviewDate_zxf1(a.sid) as ReviewDates,dbo.getUserNames_fu(a.v1) as header,dbo.getUserNames_fu(a.v2) as finaler from project_specific_item a right outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where  b.s_sid=" + context.Request.Params["pssid"].Trim() + where+" and b.ischild=0 order by d.sid asc, b.sequence asc, a.sequence asc ");
            if (isConstruction == "3")
            {
                ds = new BLL.Common().GetList("select * from v_ProjectProductItem a where a.s_sid=" + context.Request.Params["pssid"].Trim() + where + " and a.ischild=0 order by a.group_sid asc, a.csequence asc, a.sequence asc");
                
            }
            else
            {
                ds = new BLL.Common().GetList("select  a.sid,b.name as contentName,d.group_name,a.name as itemName,a.unfinished_reason,a.solution,a.reviewed,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_zxf(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate,dbo.getProReview_result_zxf(a.sid) as review_results,dbo.getProjectReviewers_zxf1(a.sid) as reviewers,dbo.getProjectReviewers_zxf(a.sid) as reviewer,dbo.getProjectReviewDate_zxf1(a.sid) as ReviewDates,dbo.getUserNames_fu(a.v1) as header,dbo.getUserNames_fu(a.v2) as finaler from project_specific_item a right outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where  b.s_sid=" + context.Request.Params["pssid"].Trim() + where + " and b.ischild=0 order by d.sid asc, b.sequence asc, a.sequence asc ");
            }
                DataTable dt_item_flow = new BLL.Common().GetList("select * from project_item_flow as a left join project_specific_item as b on a.psi_sid = b.sid left join project_work_flow as c on a.fw_sid=c.sid where b.s_sid=" + context.Request.Params["pssid"].Trim() +" order by b.s_sid asc").Tables[0];
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

                if (isConstruction == "4")
                {
                    DataTable ProductDT = new DataTable();
                    DataSet ProductDS = new BLL.Common().GetList("select productID,number,productName,productPic,paintColor,productSize Specifications,useSpace,usePart,unit,amount,EndProduct,remark ppiRemark from v_Project_Product where ps_sid='" + context.Request.Params["pssid"].Trim() + "'");
                    if (ProductDS.Tables.Count > 0)
                    {
                        ProductDT = ProductDS.Tables[0];
                        //dt.Merge(ProductDT);
                        if (dt.Rows.Count >= ProductDT.Rows.Count)
                        {
                            for (int i = 0; i < ProductDT.Columns.Count; i++)
                            {
                                dt.Columns.Add(ProductDT.Columns[i].ColumnName);
                            }
                            int a = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                //int a = i;
                                //if (i >= ProductDT.Rows.Count)
                                //{
                                //    a = i - ProductDT.Rows.Count * (i / ProductDT.Rows.Count);
                                //}
                                a = i / ((dt.Rows.Count / ProductDT.Rows.Count) + (dt.Rows.Count % ProductDT.Rows.Count == 0 ? 0 : 1));
                                for (int j = 0; j < ProductDT.Columns.Count; j++)
                                {
                                    dt.Rows[i][ProductDT.Columns[j].ColumnName] = ProductDT.Rows[a][j];
                                }
                            }
                            //dt.DefaultView.Sort = "productID";
                            //dt = dt.DefaultView.ToTable();
                        }
                        else
                        {
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                ProductDT.Columns.Add(dt.Columns[i]);
                            }
                            int a = 0;
                            for (int i = 0; i < ProductDT.Rows.Count; i++)
                            {
                                //int a = i;
                                //if (i >= ProductDT.Rows.Count)
                                //{
                                //    a = i - ProductDT.Rows.Count * (i / ProductDT.Rows.Count);
                                //}
                                a = i - dt.Rows.Count * (i / dt.Rows.Count);
                                for (int j = 0; j < dt.Columns.Count; j++)
                                {
                                    ProductDT.Rows[i][dt.Columns[j]] = dt.Rows[a][j];
                                }
                            }
                            dt = ProductDT;
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                DateTime sDate = new DateTime();
                DateTime eDate = new DateTime();
                TimeSpan ts = TimeSpan.Zero;
                if (dt.Rows[0]["stage_sDate"].ToString().Trim() != "" && dt.Rows[0]["stage_eDate"].ToString().Trim() != "" && dt.Rows[0]["stage_sDate"] != null && dt.Rows[0]["stage_eDate"] != null)
                {
                    sDate = DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString().Trim());
                    eDate = DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString().Trim());
                    ts = eDate.AddDays(1).Subtract(sDate);
                    for (int i = 0; i < ts.Days; i++)
                    {
                        DataColumn datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "0";
                        dt.Columns.Add(datetimeColumn);

                        datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = "flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "";
                        dt.Columns.Add(datetimeColumn);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i]["begin_date"].ToString().Trim() != "" && dt.Rows[i]["end_date"].ToString().Trim() != "" && dt.Rows[i]["begin_date"] != null && dt.Rows[i]["end_date"] != null)
                        {
                            DateTime mysDate = DateTime.Parse(dt.Rows[i]["begin_date"].ToString().Trim());
                            DateTime myeDate = DateTime.Parse(dt.Rows[i]["end_date"].ToString().Trim());
                            if (mysDate.ToString("yyyy-MM-dd") != "1900-01-01" && myeDate.ToString("yyyy-MM-dd") != "1900-01-01")
                            {
                                TimeSpan myts = myeDate.AddDays(1).Subtract(mysDate);
                                for (int j = 0; j < myts.Days; j++)
                                {
                                    if (dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")].ToString().Trim() == "0")
                                    {
                                        dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "1";
                                        //dt.Rows[i]["flow_" + mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "0";
                                    }
                                    //object obj_showflow=DbHelperSQL.GetSingle("select dbo.getProjectFlowSN_fu('" + dt.Rows[i]["sid"].ToString().Trim() + "','" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "')");
                                    object obj_showflow = DbHelperSQL.GetSingle("select top 1 wf_text from project_item_flow_1 where psi_sid='" + dt.Rows[i]["sid"].ToString().Trim() + "' and convert(varchar(10),pif_time,120)='" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "'");
                                    //string showFlow = obj_showflow == null ? "✓" : obj_showflow.ToString().Trim();
                                    dt.Rows[i]["flow_" + mysDate.AddDays(j).ToString("yyyy-MM-dd")] = obj_showflow;
                                }
                            }

                        }


                    }


                }
                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + context.Request.Params["pssid"].Trim() + "' order by sequence");
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
                        DataTable impworkDT = new DataTable();
                        //impDS = new BLL.Common().GetList("select * ,dbo.getUserAbbr_fu(implementer_sid) as abbr from project_work_implement where psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        impDS = new BLL.Common().GetList("select * ,dbo.getUserName_fu(implementer_sid) as abbr from project_work_implement where psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                dt.Rows[j]["imp" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["abbr"].ToString().Trim();
                                string[] submitDate = dt.Rows[j]["submitDate"].ToString().Trim().Split(',');

                                for (int a = 0; a < submitDate.Length; a++)
                                {
                                    try
                                    {
                                        for (int n = 0; n < ts.Days; n++)
                                        {
                                            if (sDate.AddDays(n).Date == DateTime.Parse(submitDate[a].Trim()).Date)
                                            {
                                                dt.Rows[j][sDate.AddDays(n).ToString("yyyy-MM-dd")] = "2";
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);

        }

        public string ContentItem(HttpContext context)
        {
            DataTable dt = new DataTable();
            //DataSet ds = new BLL.Common().GetList(" select a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_fu(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate,a.v1,a.v2,a.sequence as itemSequence,b.sequence as contentSequence,b.remark as cremark,b.group_sid,a.parent_sid,b.sid as csid from project_specific_item a left outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on a.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where a.ischild=1 and a.s_sid=" + context.Request.Params["pssid"].Trim() + " order by b.sequence asc, a.sequence asc  ");
            DataSet ds = new BLL.Common().GetList("select row_number()over (order by b.sequence) as rowid,a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.reviewed,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_fu(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate,a.v1,a.v2,a.sequence as itemSequence,b.sequence as contentSequence,b.remark as cremark,b.group_sid,a.parent_sid,b.sid as csid,dbo.getUserNames_fu(a.v1) as header,dbo.getUserNames_fu(a.v2) as finaler from project_specific_item a right outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where  b.s_sid=" + context.Request.Params["pssid"].Trim() + " and b.ischild=0 order by d.sid asc,  b.sequence asc, a.sequence asc ");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                DateTime sDate = new DateTime();
                DateTime eDate = new DateTime(); 
                TimeSpan ts=TimeSpan.Zero ;
                if (dt.Rows[0]["stage_sDate"].ToString().Trim() != "" && dt.Rows[0]["stage_eDate"].ToString().Trim() != "" && dt.Rows[0]["stage_sDate"] != null && dt.Rows[0]["stage_eDate"] != null)
                {
                    sDate = DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString().Trim());
                    eDate = DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString().Trim());
                    ts = eDate.AddDays(1).Subtract(sDate);
                    for (int i = 0; i < ts.Days; i++)
                    {
                        DataColumn datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "0";
                        dt.Columns.Add(datetimeColumn);

                        datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = "flow_"+sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "";
                        dt.Columns.Add(datetimeColumn);
                    }
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["begin_date"].ToString().Trim() != "" && dt.Rows[i]["end_date"].ToString().Trim() != "" && dt.Rows[i]["begin_date"] != null && dt.Rows[i]["end_date"] != null)
                    {
                        DateTime mysDate = DateTime.Parse(dt.Rows[i]["begin_date"].ToString().Trim());
                        DateTime myeDate = DateTime.Parse(dt.Rows[i]["end_date"].ToString().Trim());
                        TimeSpan myts = myeDate.AddDays(1).Subtract(mysDate);
                        for (int j = 0; j < myts.Days; j++)
                        {
                            if (dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")].ToString().Trim() == "0")
                            {
                                dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "1";
                            }
                            //object obj_showflow=DbHelperSQL.GetSingle("select dbo.getProjectFlowSN_fu('" + dt.Rows[i]["sid"].ToString().Trim() + "','" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "')");
                            object obj_showflow = DbHelperSQL.GetSingle("select top 1 wf_text from project_item_flow_1 where psi_sid='" + dt.Rows[i]["sid"].ToString().Trim() + "' and convert(varchar(10),pif_time,120)='" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "'");
                            string showFlow = obj_showflow == null ? "" : obj_showflow.ToString().Trim();
                            dt.Rows[i]["flow_"+mysDate.AddDays(j).ToString("yyyy-MM-dd")] = showFlow;
                        }

                    }
                }


                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + context.Request.Params["pssid"].Trim() + "'");
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
                    datetimeColumn.ColumnName = "imp_" + impDT.Rows[i]["sid"].ToString().Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "impAbbr_" + impDT.Rows[i]["sid"].ToString().Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable impworkDT = new DataTable();
                        impDS = new DAL.project_work_implement().getList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");//new BLL.project_work_implement().GetList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                //dt.Rows[j]["imp_" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["impUserAbbr"].ToString().Trim();
                                dt.Rows[j]["imp_" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["implementer_sid"].ToString().Trim();
                                dt.Rows[j]["impAbbr_" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["impUserAbbr"].ToString().Trim();
                                string[] submitDate = dt.Rows[j]["submitDate"].ToString().Trim().Split(',');

                                for (int a = 0; a < submitDate.Length; a++)
                                {
                                    try
                                    {
                                        for (int n = 0; n < ts.Days; n++)
                                        {
                                            if (sDate.AddDays(n).Date == DateTime.Parse(submitDate[a].Trim()).Date)
                                            {
                                                dt.Rows[j][sDate.AddDays(n).ToString("yyyy-MM-dd")] = "2";
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string ContentCommonItem(HttpContext context)
        {
            string isConstruction = context.Request["isConstruction"];
            DataTable dt = new DataTable();
            DataSet ds = null ;
            //DataSet ds = new BLL.Common().GetList("select row_number()over (order by b.sequence) as rowid,a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.reviewed,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_fu(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate,a.v1,a.v2,a.sequence as itemSequence,b.sequence as contentSequence,b.remark as cremark,b.group_sid,a.parent_sid,b.sid as csid,dbo.getUserNames_fu(a.v1) as header,dbo.getUserNames_fu(a.v2) as finaler from project_specific_item a right outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where  b.s_sid=" + context.Request.Params["pssid"].Trim() + " and b.ischild=0 order by d.sid asc,  b.sequence asc, a.sequence asc ");
            if (isConstruction != "3")
            {
                 ds = new BLL.Common().GetList("select row_number()over (order by b.sequence) as rowid,a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.reviewed,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_fu(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate,(case when a.v1 is null or a.v1='' then d.v1 else a.v1 end) v1,(case when a.v2 is null or a.v2='' then e.v2 else a.v2 end)v2,a.sequence as itemSequence,b.sequence as contentSequence,b.remark as cremark,b.group_sid,a.parent_sid,b.sid as csid,(case when a.v1='' or a.v1 is null then dbo.getUserNames_fu(d.v1) else dbo.getUserNames_fu(a.v1) end) as header,(case when a.v2='' or a.v2 is null then dbo.getUserNames_fu(e.v2) else dbo.getUserNames_fu(a.v2) end ) as finaler,d.v1 groupHeader from project_specific_item a right outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid inner join project e on c.p_sid=e.sid where  b.s_sid=" + context.Request.Params["pssid"].Trim() + " and b.ischild=0 order by d.sid asc,  b.sequence asc, a.sequence asc ");
            }
            else
            {
                ds = new BLL.Common().GetList("select row_number()over (order by psi.sequence) as rowid, psi.sid sid,ppi.sid as ppiSid,ppi.parentID,psi.parent_sid,pp.sid ppSid,ppi.ProductID,psi.PP_sid,ppi.number,ppi.name,ppi.paintColor,ppi.useSpace,ppi.spaceCount,ppi.install,ppi.usePart,ppi.unit,ppi.amount,ppi.paintPaletteNumber,ppi.EndProduct,ppi.sequence,ppi.remark,pp.*,psi2.name contentName,psi.name as itemName,ps.stage_name,psi.begin_date,psi.end_date,ps.begin_date as stage_sDate,ps.end_date as stage_eDate ,d.Image AS productPic, d.Name AS productName,d.Specifications,psi.sid as csid,dbo.getProjectSubmitDate_fu(psi.sid) as submitDate,(case when psi.v2 is null or psi.v2='' then e.v2 else psi.v2 end)v2,(case when psi.v1 is null or psi.v1='' then pg.v1 else psi.v1 end)v1,psi.sequence as itemSequence,psi.sequence as contentSequence,psi.remark as cremark,psi.group_sid,psi.parent_sid,psi.sid as csid,(case when psi.v1='' or psi.v1 is null then dbo.getUserNames_fu(pg.v1) else dbo.getUserNames_fu(psi.v1) end) as header,(case when psi.v2='' or psi.v2 is null then dbo.getUserNames_fu(e.v2) else dbo.getUserNames_fu(psi.v2) end ) as finaler,pg.v1 groupHeader "
+"	from project_product pp"
+"	left join project_product_item ppi on ppi.sid = pp.ppiID"
+"	right join project_specific_item psi on psi.PP_sid=pp.sid"
+"	right join project_specific_item psi2 on psi2.sid=psi.parent_sid"
+"	left outer join project_stage ps on psi.s_sid=ps.sid "
+"	 INNER JOIN  dbo.v_ProductColorShip AS d ON ppi.ProductID = d.ID"
+"	left outer join project_stage c on psi.s_sid=c.sid "
+ "	left outer join project_group pg on psi.group_sid=pg.sid"
+"	inner join project e on c.p_sid=e.sid "
+"	where  pp.ps_sid=" + context.Request.Params["pssid"].Trim() + "");
            }
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
              
                //工作日历
                DateTime sDate = new DateTime();
                DateTime eDate = new DateTime();
                TimeSpan ts = TimeSpan.Zero;
                if (dt.Rows[0]["stage_sDate"].ToString().Trim() != "" && dt.Rows[0]["stage_eDate"].ToString().Trim() != "" && dt.Rows[0]["stage_sDate"] != null && dt.Rows[0]["stage_eDate"] != null)
                {
                    sDate = DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString().Trim());
                    eDate = DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString().Trim());
                    ts = eDate.AddDays(1).Subtract(sDate);
                    for (int i = 0; i < ts.Days; i++)
                    {
                        DataColumn datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "0";
                        dt.Columns.Add(datetimeColumn);

                        datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = "flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "";
                        dt.Columns.Add(datetimeColumn);
                    }
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["begin_date"].ToString().Trim() != "" && dt.Rows[i]["end_date"].ToString().Trim() != "" && dt.Rows[i]["begin_date"] != null && dt.Rows[i]["end_date"] != null)
                    {
                        DateTime mysDate = DateTime.Parse(dt.Rows[i]["begin_date"].ToString().Trim());
                        DateTime myeDate = DateTime.Parse(dt.Rows[i]["end_date"].ToString().Trim());
                        if (mysDate.ToString("yyyy-MM-dd") != "1900-01-01" && myeDate.ToString("yyyy-MM-dd") != "1900-01-01")
                        {
                            TimeSpan myts = myeDate.AddDays(1).Subtract(mysDate);
                            for (int j = 0; j < myts.Days; j++)
                            {
                                //dt.Rows[i]["flow_" + mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "√";
                                if (dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")].ToString().Trim() == "0")
                                {
                                    dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "1";
                                }
                                object obj_showflow = DbHelperSQL.GetSingle("select top 1 wf_text from project_item_flow_1 where psi_sid='" + dt.Rows[i]["sid"].ToString().Trim() + "' and convert(varchar(10),pif_time,120)='" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "'");
                                string showFlow = obj_showflow == null ? "✓" : obj_showflow.ToString().Trim();
                                dt.Rows[i]["flow_" + mysDate.AddDays(j).ToString("yyyy-MM-dd")] = showFlow;
                            }
                        }
                    }
                }

                //工作种类及人员
                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + context.Request.Params["pssid"].Trim() + "'");
                if (impDS.Tables.Count > 0)
                {
                    impDT = impDS.Tables[0];
                }
                for (int i = 0; i < impDT.Rows.Count; i++)
                {
                    //string[] dynImpUserArr = impDT.Rows[i]["impUsers"].ToString().Trim().Split(',');
                    //string[] dynImpUidArr = impDT.Rows[i]["implementers_sid"].ToString().Trim().Split(',');
                    //for (int m = 0; m < dynImpUidArr.Length; m++)
                    //{
                    DataColumn datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "imp_" + impDT.Rows[i]["sid"].ToString().Trim();// +"_" + dynImpUidArr[m].Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "Abbr_imp_" + impDT.Rows[i]["sid"].ToString().Trim();// +"_" + dynImpUidArr[m].Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable impworkDT = new DataTable();
                        impDS = new DAL.project_work_implement().getList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                string[] impUserArr = impworkDT.Rows[0]["implementers"].ToString().Trim().Split(',');
                                string[] impUidArr = impworkDT.Rows[0]["implementer_sid"].ToString().Trim().Split(',');
                                //for (int n = 0; n < impUidArr.Length; n++)
                                //{
                                //    if (dynImpUidArr[m] == impUidArr[n])
                                //    {
                                //        dt.Rows[j]["impAbbr_" + impDT.Rows[i]["sid"].ToString().Trim() + "_" + dynImpUidArr[m]] = "✓";
                                //        //dt.Rows[j]["impAbbr_" + impDT.Rows[i]["sid"].ToString().Trim() + "_" + dynImpUidArr[m]] = impUserArr[n];
                                //        dt.Rows[j]["imp_" + impDT.Rows[i]["sid"].ToString().Trim() + "_" + dynImpUidArr[m]] = impUidArr[n];
                                //    }
                                //}
                                dt.Rows[j]["imp_" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["implementer_sid"].ToString().Trim();
                                //dt.Rows[j]["Abbr_imp_" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["impUserAbbr"].ToString().Trim();
                                dt.Rows[j]["Abbr_imp_" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["implementers"].ToString().Trim();
                                string[] submitDate = dt.Rows[j]["submitDate"].ToString().Trim().Split(',');

                                for (int a = 0; a < submitDate.Length; a++)
                                {
                                    try
                                    {
                                        for (int n = 0; n < ts.Days; n++)
                                        {
                                            if (sDate.AddDays(n).Date == DateTime.Parse(submitDate[a].Trim()).Date)
                                            {
                                                dt.Rows[j][sDate.AddDays(n).ToString("yyyy-MM-dd")] = "2";
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                    //}
                }
            }

            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string ConstructionItem_gridedit(HttpContext context)
        {
            DataTable dt = new DataTable();
            //DataSet ds = new BLL.Common().GetList(" select a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_fu(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate,a.v1,a.v2,a.sequence as itemSequence,b.sequence as contentSequence,b.remark as cremark,b.group_sid,a.parent_sid,b.sid as csid from project_specific_item a left outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on a.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where a.ischild=1 and a.s_sid=" + context.Request.Params["pssid"].Trim() + " order by b.sequence asc, a.sequence asc  ");
            DataSet ds = new BLL.Common().GetList("select row_number()over (order by b.sequence) as rowid,a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.reviewed,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_fu(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate,a.v1,a.v2,a.sequence as itemSequence,b.sequence as contentSequence,b.remark as cremark,b.group_sid,a.parent_sid,b.sid as csid,dbo.getUserNames_fu(a.v1) as header,dbo.getUserNames_fu(a.v2) as finaler from project_specific_item a right outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where  b.s_sid=" + context.Request.Params["pssid"].Trim() + " and b.ischild=0 order by d.sid asc,  b.sequence asc, a.sequence asc ");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                DateTime sDate = new DateTime();
                DateTime eDate = new DateTime();
                TimeSpan ts = TimeSpan.Zero;
                if (dt.Rows[0]["stage_sDate"].ToString().Trim() != "" && dt.Rows[0]["stage_eDate"].ToString().Trim() != "" && dt.Rows[0]["stage_sDate"] != null && dt.Rows[0]["stage_eDate"] != null)
                {
                    sDate = DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString().Trim());
                    eDate = DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString().Trim());
                    ts = eDate.AddDays(1).Subtract(sDate);
                    for (int i = 0; i < ts.Days; i++)
                    {
                        DataColumn datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "0";
                        dt.Columns.Add(datetimeColumn);

                        datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = "flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "";
                        dt.Columns.Add(datetimeColumn);
                    }
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["begin_date"].ToString().Trim() != "" && dt.Rows[i]["end_date"].ToString().Trim() != "" && dt.Rows[i]["begin_date"] != null && dt.Rows[i]["end_date"] != null)
                    {
                        DateTime mysDate = DateTime.Parse(dt.Rows[i]["begin_date"].ToString().Trim());
                        DateTime myeDate = DateTime.Parse(dt.Rows[i]["end_date"].ToString().Trim());
                        if (mysDate.ToString("yyyy-MM-dd") != "1900-01-01" && myeDate.ToString("yyyy-MM-dd") != "1900-01-01")
                        {
                            TimeSpan myts = myeDate.AddDays(1).Subtract(mysDate);
                            for (int j = 0; j < myts.Days; j++)
                            {
                                if (dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")].ToString().Trim() == "0")
                                {
                                    dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "1";
                                    //dt.Rows[i]["flow_" + mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "0";
                                }
                                //object obj_showflow=DbHelperSQL.GetSingle("select dbo.getProjectFlowSN_fu('" + dt.Rows[i]["sid"].ToString().Trim() + "','" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "')");
                                object obj_showflow = DbHelperSQL.GetSingle("select top 1 wf_text from project_item_flow_1 where psi_sid='" + dt.Rows[i]["sid"].ToString().Trim() + "' and convert(varchar(10),pif_time,120)='" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "'");
                                string showFlow = obj_showflow == null ? "✓" : obj_showflow.ToString().Trim();
                                dt.Rows[i]["flow_" + mysDate.AddDays(j).ToString("yyyy-MM-dd")] = showFlow;
                            }
                        }
                    }
                }


                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + context.Request.Params["pssid"].Trim() + "'");
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
                    datetimeColumn.ColumnName = "imp_" + impDT.Rows[i]["sid"].ToString().Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "impAbbr_" + impDT.Rows[i]["sid"].ToString().Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable impworkDT = new DataTable();
                        impDS = new DAL.project_work_implement().getList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");//new BLL.project_work_implement().GetList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                //dt.Rows[j]["imp_" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["impUserAbbr"].ToString().Trim();
                                dt.Rows[j]["imp_" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["implementer_sid"].ToString().Trim();
                                dt.Rows[j]["impAbbr_" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["impUserAbbr"].ToString().Trim();
                                string[] submitDate = dt.Rows[j]["submitDate"].ToString().Trim().Split(',');

                                for (int a = 0; a < submitDate.Length; a++)
                                {
                                    try
                                    {
                                        for (int n = 0; n < ts.Days; n++)
                                        {
                                            if (sDate.AddDays(n).Date == DateTime.Parse(submitDate[a].Trim()).Date)
                                            {
                                                dt.Rows[j][sDate.AddDays(n).ToString("yyyy-MM-dd")] = "2";
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        public string ConstructionItem(HttpContext context)
        {
            DataTable dt = new DataTable();
            //DataSet ds = new BLL.Common().GetList(" select a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_fu(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate,a.v1,a.v2,a.sequence as itemSequence,b.sequence as contentSequence,b.remark as cremark,b.group_sid,a.parent_sid,b.sid as csid from project_specific_item a left outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on a.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where a.ischild=1 and a.s_sid=" + context.Request.Params["pssid"].Trim() + " order by b.sequence asc, a.sequence asc  ");
            DataSet ds = new BLL.Common().GetList("select row_number()over (order by b.sequence) as rowid,a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,a.unfinished_reason,a.solution,a.reviewed,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectReview_fu(a.sid) as reviews,dbo.getProjectSubmitDate_fu(a.sid) as submitDate,a.v1,a.v2,a.sequence as itemSequence,b.sequence as contentSequence,b.remark as cremark,b.group_sid,a.parent_sid,b.sid as csid,dbo.getUserNames_fu(a.v1) as header,dbo.getUserNames_fu(a.v2) as finaler from project_specific_item a right outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where  b.s_sid=" + context.Request.Params["pssid"].Trim() + " and b.ischild=0 order by d.sid asc,  b.sequence asc, a.sequence asc ");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                DateTime sDate = new DateTime();
                DateTime eDate = new DateTime();
                TimeSpan ts = TimeSpan.Zero;
                if (dt.Rows[0]["stage_sDate"].ToString().Trim() != "" && dt.Rows[0]["stage_eDate"].ToString().Trim() != "" && dt.Rows[0]["stage_sDate"] != null && dt.Rows[0]["stage_eDate"] != null)
                {
                    sDate = DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString().Trim());
                    eDate = DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString().Trim());
                    ts = eDate.AddDays(1).Subtract(sDate);
                    for (int i = 0; i < ts.Days; i++)
                    {
                        DataColumn datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "0";
                        dt.Columns.Add(datetimeColumn);

                        datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = "flow_" + sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "";
                        dt.Columns.Add(datetimeColumn);
                    }
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["begin_date"].ToString().Trim() != "" && dt.Rows[i]["end_date"].ToString().Trim() != "" && dt.Rows[i]["begin_date"] != null && dt.Rows[i]["end_date"] != null)
                    {
                        DateTime mysDate = DateTime.Parse(dt.Rows[i]["begin_date"].ToString().Trim());
                        DateTime myeDate = DateTime.Parse(dt.Rows[i]["end_date"].ToString().Trim());
                        TimeSpan myts = myeDate.AddDays(1).Subtract(mysDate);
                        for (int j = 0; j < myts.Days; j++)
                        {
                            if (dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")].ToString().Trim() == "0")
                            {
                                dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "1";
                                dt.Rows[i]["flow_" + mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "0";
                            }
                            //object obj_showflow = DbHelperSQL.GetSingle("select dbo.getProjectFlowSN_fu('" + dt.Rows[i]["sid"].ToString().Trim() + "','" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "')");
                            object obj_showflow = DbHelperSQL.GetSingle("select top 1 wf_text from project_item_flow_1 where psi_sid='" + dt.Rows[i]["sid"].ToString().Trim() + "' and convert(varchar(10),pif_time,120)='" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "'");
                            string showFlow = obj_showflow == null ? "" : obj_showflow.ToString().Trim();
                            dt.Rows[i]["flow_" + mysDate.AddDays(j).ToString("yyyy-MM-dd")] = showFlow;
                        }

                    }
                }


                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + context.Request.Params["pssid"].Trim() + "'");
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
                    datetimeColumn.ColumnName = "imp_" + impDT.Rows[i]["sid"].ToString().Trim();
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable impworkDT = new DataTable();
                        impDS = new DAL.project_work_implement().getList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");//new BLL.project_work_implement().GetList("psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                dt.Rows[j]["imp_" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["impUserAbbr"].ToString().Trim();
                                string[] submitDate = dt.Rows[j]["submitDate"].ToString().Trim().Split(',');

                                for (int a = 0; a < submitDate.Length; a++)
                                {
                                    try
                                    {
                                        for (int n = 0; n < ts.Days; n++)
                                        {
                                            if (sDate.AddDays(n).Date == DateTime.Parse(submitDate[a].Trim()).Date)
                                            {
                                                dt.Rows[j][sDate.AddDays(n).ToString("yyyy-MM-dd")] = "2";
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return DBUtility.JsonHelper.JsonForJqgrid(dt, dt.Rows.Count);
        }

        public string ProjectContentDel(HttpContext context)
        {
            string selectid = context.Request.Params["sid"].Trim();
            return new BLL.project_specific_item().DeleteList(selectid);
        }

        public string GetStage(HttpContext context){
            DataTable dt = new DataTable();
            string where = "";
            if (context.Request.Params["sid"].Trim() != "")
            {
                where = " and sid!=" + context.Request.Params["sid"].Trim();
            }
            DataSet ds = new BLL.Common().GetList("select row_number()over (order by sequence) as rowid,stage_name from project_stage where p_sid='" + context.Request.Params["p_sid"].Trim() + "'" + where);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            DataRow dr = dt.NewRow();
            dr["rowid"] = "0";
            dr["stage_name"] = "最顶";
            dt.Rows.InsertAt(dr,0);
            
            return DBUtility.JsonHelper.DataTable2Json_Combo(dt);
        }

        public string CheckImp(HttpContext context)
        {
            return DBUtility.DbHelperSQL.GetSingle("select count(1) from project_implement where s_sid=" + context.Request.Params["ssid"].Trim() + " and (implementers_sid is null or implementers_sid='')").ToString().Trim();
            //return "";
        }

        public string del_headAppr_check(HttpContext context)
        {
            if (DbHelperSQL.Exists("select count(1) from project_specific_item where ','+v1+',' like ',%" + context.Request.Params["uid"].Trim() + "%,' and s_sid in (select sid from project_stage where p_sid='" + context.Request.Params["sid"].Trim() + "')"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public string del_finalAppr_check(HttpContext context)
        {
            if (DbHelperSQL.Exists("select count(1) from project_specific_item where ','+v2+',' like ',%" + context.Request.Params["uid"].Trim() + "%,' and s_sid in (select sid from project_stage where p_sid='" + context.Request.Params["sid"].Trim() + "')"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public string GetStageSEDate(HttpContext context)
        {
            string id = context.Request == null ? "" : context.Request.Params["id"].Trim();
            DataSet ds = new BLL.Common().GetList("select convert(nvarchar(10),min(begin_date),23) begin_date,convert(nvarchar(10),max(end_date),23) end_date from project_specific_item where s_sid='" + id + "' and begin_date!='1900-01-01' and begin_date!='1900-1-1' and end_date!='1900-01-01' and end_date!='1900-1-1'");
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return DBUtility.JsonHelper.DataTable2Josn(dt);
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