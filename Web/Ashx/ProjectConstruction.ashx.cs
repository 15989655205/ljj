using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using Maticsoft.DBUtility;
using System.Web.SessionState;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// ProjectConstruction 的摘要说明
    /// </summary>
    public class ProjectConstruction : IHttpHandler, IReadOnlySessionState
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
                case "edit":
                    reValue = ConstructionEdit(context);
                    break;
                case "easyuiGridEdit":
                    reValue = ConstructionEdit_easyuidg(context);
                    break;
                case "easyuiGridEdit_common":
                    reValue = ConstructionEdit_common(context);
                    break;
                case "easyuiGridEdit_row":
                    reValue = ConstructionEdit_easyuidg_row(context);
                    break;
                case "item_del_check":
                    reValue = ItemDelCheck(context);
                    break;
                default:
                    break;
            }
            context.Response.Write(reValue);
        }

        private string ConstructionEdit(HttpContext context)
        {
            int paramsCount = context.Request.Form.Count;
            string sDate = "", eDate = "";

            DataTable impDT = new DataTable();
            DataColumn psiColumn = new DataColumn();
            //该列的数据类型
            psiColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            psiColumn.ColumnName = "psi_sid";
            //该列得默认值
            psiColumn.DefaultValue = "";
            impDT.Columns.Add(psiColumn);

            DataColumn impColumn = new DataColumn();
            //该列的数据类型
            impColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            impColumn.ColumnName = "imp_sid";
            //该列得默认值
            impColumn.DefaultValue = "";
            impDT.Columns.Add(impColumn);

            DataColumn userColumn = new DataColumn();
            //该列的数据类型
            userColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            userColumn.ColumnName = "imp_user";
            //该列得默认值
            userColumn.DefaultValue = "";
            impDT.Columns.Add(userColumn);

            //psi_sid, fw_sid, fw_name, begin_time,end_time,sn,abbr
            DataTable flowDT = new DataTable();
            DataColumn fwpsiColumn = new DataColumn();
            //该列的数据类型
            fwpsiColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            fwpsiColumn.ColumnName = "psi_sid";
            //该列得默认值
            fwpsiColumn.DefaultValue = "";
            flowDT.Columns.Add(fwpsiColumn);

            DataColumn fwsidColumn = new DataColumn();
            //该列的数据类型
            fwsidColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            fwsidColumn.ColumnName = "fw";
            //该列得默认值
            fwsidColumn.DefaultValue = "";
            flowDT.Columns.Add(fwsidColumn);

            DataColumn sdateColumn = new DataColumn();
            //该列的数据类型
            sdateColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            sdateColumn.ColumnName = "fwdate";
            //该列得默认值
            sdateColumn.DefaultValue = "";
            flowDT.Columns.Add(sdateColumn);


            for (int i = 0; i < paramsCount; i++)
            {
                if (context.Request.Form[i].Trim() != "")
                {
                    string column = context.Request.Form.AllKeys[i].Trim();
                    if (column.Contains("flow_"))
                    {
                        string[] arr = column.Split('_');
                        if (sDate == "")
                        {
                            sDate = arr[1].Trim();
                        }
                        eDate = arr[1].Trim();
                        if (context.Request.Form[i].Trim() != "0")
                        {
                            DataRow dr = flowDT.NewRow();
                            dr["psi_sid"] = context.Request.Form["psi_sid"].Trim();
                            dr["fwdate"] = arr[1].Trim();
                            dr["fw"] = context.Request.Form[i].Trim();
                            flowDT.Rows.Add(dr);
                        }
                    }
                    else if (column.Contains("imp_"))
                    {
                        string[] arr = column.Split('_');
                        DataRow dr = impDT.NewRow();
                        dr["psi_sid"] = context.Request.Form["psi_sid"].Trim();
                        dr["imp_sid"] = arr[1].Trim();
                        dr["imp_user"] = context.Request.Form[i].Trim();
                        impDT.Rows.Add(dr);
                    }
                }
            }

            string sid = context.Request.Params["psi_sid"] == null ? "" : context.Request.Params["psi_sid"].Trim();
            string csid = context.Request.Params["cid"] == null ? "" : context.Request.Params["cid"].Trim();
            //string ssid = context.Request.Params["ssid"] == null ? "" : context.Request.Params["ssid"].Trim();
            string name = context.Request.Params["itemName"] == null ? "" : context.Request.Params["itemName"].Trim();
            //string pw_content = context.Request.Params["pw_content"] == null ? "" : context.Request.Params["pw_content"].Trim();
            string begin_date = sDate;
            string end_date = eDate;
            string pc_remark = context.Request.Params["remark"] == null ? "" : context.Request.Params["remark"].Trim();
            string v1 = context.Request.Params["header"] == null ? "" : context.Request.Params["header"].Trim();
            string v2 = context.Request.Params["finaler"] == null ? "" : context.Request.Params["finaler"].Trim();

            if (sDate == "")
            {
                return "没有选择细目开始、结束时间";
            }
            if (impDT.Rows.Count == 0)
            {
                return "至少要选择一个工作种类及人员";
            }
            if (name.Length == 0)
            {
                return "图纸及索引号必填项";
            }

            //string sequence = context.Request.Params["sequence"] == null ? "" : context.Request.Params["sequence"].Trim();
            if (sid != "")
            {
                Model.project_specific_item model = new BLL.project_specific_item().GetModel(int.Parse(sid));
                model.parent_sid = int.Parse(csid);
                model.begin_date = DateTime.Parse(begin_date);
                model.end_date = DateTime.Parse(end_date);
                //model.isChild = 1;
                model.v1 = v1;
                model.v2 = v2;
                model.name = name;
                //model.s_sid = ssid;
                model.remark = pc_remark;
                return new BLL.project_specific_item().updateConstructionItem(model, impDT, flowDT);
            }
            else
            {
                Model.project_specific_item model = new Model.project_specific_item();
                model.parent_sid = int.Parse(csid);
                model.begin_date = DateTime.Parse(begin_date);
                model.end_date = DateTime.Parse(end_date);
                //model.isChild = 1;
                model.v1 = v1;
                model.v2 = v2;
                model.name = name;
                //model.s_sid = ssid;
                model.remark = pc_remark;
                model.sequence = 0;
                return new BLL.project_specific_item().addConstructionItem(model, impDT, flowDT);
            }
        }

        private string ConstructionEdit_easyuidg(HttpContext context)
        {
            string pssid=context.Request.Params["pssid"].Trim();
            //string addstr = context.Request.Params["addstr"].Trim();
            //string updatestr = context.Request.Params["updatestr"].Trim();
            //string delstr = context.Request.Params["delstr"].Trim();
            string allstr = context.Request.Params["allstr"].Trim();
            //List<Hashtable> insertDT = new List<Hashtable>();
            //insertDT = JsonSerializerHelper.JSONStringToList<Hashtable>(addstr);
            //List<Hashtable> updateDT = new List<Hashtable>();
            //updateDT = JsonSerializerHelper.JSONStringToList<Hashtable>(updatestr);
            //List<Hashtable> delDT = new List<Hashtable>();
            //delDT = JsonSerializerHelper.JSONStringToList<Hashtable>(delstr);
            List<Hashtable> allDT = new List<Hashtable>();
            allDT = JsonSerializerHelper.JSONStringToList<Hashtable>(allstr);


            //List<Model.project_specific_item> insert = new List<Model.project_specific_item>();
            //List<Model.project_specific_item> update = new List<Model.project_specific_item>();
            //List<Model.project_specific_item> del = new List<Model.project_specific_item>();
            ////List<DataTable> insertDT = new List<DataTable>();

            //int paramsCount = context.Request.Form.Count;
            

            DataTable impDT = new DataTable();
            DataColumn psiColumn = new DataColumn();
            //该列的数据类型
            psiColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            psiColumn.ColumnName = "psi_sid";
            //该列得默认值
            psiColumn.DefaultValue = "";
            impDT.Columns.Add(psiColumn);

            DataColumn impColumn = new DataColumn();
            //该列的数据类型
            impColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            impColumn.ColumnName = "imp_sid";
            //该列得默认值
            impColumn.DefaultValue = "";
            impDT.Columns.Add(impColumn);

            DataColumn userColumn = new DataColumn();
            //该列的数据类型
            userColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            userColumn.ColumnName = "imp_user";
            //该列得默认值
            userColumn.DefaultValue = "";
            impDT.Columns.Add(userColumn);

            //psi_sid, fw_sid, fw_name, begin_time,end_time,sn,abbr
            DataTable flowDT = new DataTable();
            DataColumn fwpsiColumn = new DataColumn();
            //该列的数据类型
            fwpsiColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            fwpsiColumn.ColumnName = "psi_sid";
            //该列得默认值
            fwpsiColumn.DefaultValue = "";
            flowDT.Columns.Add(fwpsiColumn);

            DataColumn fwsidColumn = new DataColumn();
            //该列的数据类型
            fwsidColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            fwsidColumn.ColumnName = "fw";
            //该列得默认值
            fwsidColumn.DefaultValue = "";
            flowDT.Columns.Add(fwsidColumn);

            DataColumn sdateColumn = new DataColumn();
            //该列的数据类型
            sdateColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            sdateColumn.ColumnName = "fwdate";
            //该列得默认值
            sdateColumn.DefaultValue = "";
            flowDT.Columns.Add(sdateColumn);
            try
            {
                string reval = "success";
                //for (int a = 0; a < insertDT.Count; a++)
                //{
                //    ArrayList akeys = new ArrayList(insertDT[a].Keys);
                //    ArrayList avalues = new ArrayList(insertDT[a].Values);
                //    akeys.Sort(); //按字母顺序进行排序
                //    for (int i = 0; i < akeys.Count; i++)
                //    {
                //        string column = akeys[i].ToString().Trim();
                //        if (insertDT[a][column].ToString().Trim() != "")
                //        {
                //            if (column.Contains("flow_"))
                //            {
                //                string[] arr = column.Split('_');
                //                if (sDate == "")
                //                {
                //                    sDate = arr[1].Trim();
                //                }
                //                eDate = arr[1].Trim();
                //                //if (insertDT[j][column].ToString().Trim() != "0")
                //                //{
                //                DataRow dr = flowDT.NewRow();
                //                dr["psi_sid"] = insertDT[a]["sid"].ToString().Trim();
                //                dr["fwdate"] = arr[1].Trim();
                //                dr["fw"] = insertDT[a][column].ToString().Trim();//context.Request.Form[i].Trim();
                //                flowDT.Rows.Add(dr);
                //                //}
                //            }
                //            else if (column.Contains("imp_"))
                //            {
                //                string[] arr = column.Split('_');
                //                DataRow dr = impDT.NewRow();
                //                dr["psi_sid"] = insertDT[a]["sid"].ToString().Trim();
                //                dr["imp_sid"] = arr[1].Trim();
                //                dr["imp_user"] = insertDT[a][column].ToString().Trim();
                //                impDT.Rows.Add(dr);
                //            }
                //        }
                //    }

                //    if (sDate == "")
                //    {
                //        return "没有选择细目开始、结束时间";
                //    }
                //    if (impDT.Rows.Count == 0)
                //    {
                //        return "至少要选择一个工作种类及人员";
                //    }

                //    string sid = insertDT[a]["sid"] == null ? "" : insertDT[a]["sid"].ToString().Trim();
                //    string csid = insertDT[a]["csid"] == null ? "" : insertDT[a]["csid"].ToString().Trim();
                //    //string ssid = context.Request.Params["ssid"] == null ? "" : context.Request.Params["ssid"].Trim();
                //    string name = insertDT[a]["itemName"] == null ? "" : insertDT[a]["itemName"].ToString().Trim();
                //    //string pw_content = context.Request.Params["pw_content"] == null ? "" : context.Request.Params["pw_content"].Trim();
                //    string begin_date = sDate;
                //    string end_date = eDate;
                //    string pc_remark = insertDT[a]["remark"] == null ? "" : insertDT[a]["remark"].ToString().Trim();
                //    string v1 = insertDT[a]["v1"] == null ? "" : insertDT[a]["v1"].ToString().Trim();
                //    string v2 = insertDT[a]["v2"] == null ? "" : insertDT[a]["v2"].ToString().Trim();
                //    //string sequence = insertDT[a]["itemSequence"] == null ? "" : insertDT[a]["itemSequence"].ToString().Trim();

                //    Model.project_specific_item model = new Model.project_specific_item();
                //    model.parent_sid = int.Parse(csid);
                //    model.begin_date = DateTime.Parse(begin_date);
                //    model.end_date = DateTime.Parse(end_date);
                //    //model.isChild = 1;
                //    model.v1 = v1;
                //    model.v2 = v2;
                //    model.name = name;
                //    //model.s_sid = ssid;
                //    model.remark = pc_remark;
                //    //model.sequence = int.Parse(sequence);
                //    reval=new BLL.project_specific_item().addConstructionItem(model, impDT, flowDT);
                //    if (reval != "success")
                //    {
                //        break;
                //    }
                //}
                int sequence = -1;
                string itemID = "'0'"; 
                for (int b = 0; b < allDT.Count; b++)
                {
                    itemID += ",'" + allDT[b]["sid"].ToString().Trim()+"'";
                }
                new DAL.project_specific_item().delList(itemID, pssid);
                for (int b = 0; b < allDT.Count; b++)
                {
                    sequence += 1;
                    if (b != 0)
                    {
                        if (allDT[b - 1]["contentName"].ToString().Trim() != allDT[b]["contentName"].ToString().Trim())
                            sequence = 0;
                    }
                    string sDate = "", eDate = "";
                    flowDT.Clear();
                    impDT.Clear();
                    ArrayList akeys = new ArrayList(allDT[b].Keys);
                    ArrayList avalues = new ArrayList(allDT[b].Values);
                    akeys.Sort(); //按字母顺序进行排序
                    for (int i = 0; i < akeys.Count; i++)
                    {

                        string column = akeys[i].ToString().Trim();
                        if (allDT[b][column].ToString().Trim() != "")
                        {
                            if (column.Contains("flow_"))
                            {
                                string[] arr = column.Split('_');
                                if (sDate == "")
                                {
                                    sDate = arr[1].Trim();
                                }
                                eDate = arr[1].Trim();
                                if (allDT[b][column].ToString().Trim() != "✓")
                                {
                                    DataRow dr = flowDT.NewRow();
                                    dr["psi_sid"] = allDT[b]["sid"].ToString().Trim();
                                    dr["fwdate"] = arr[1].Trim();
                                    dr["fw"] = allDT[b][column].ToString().Trim();//context.Request.Form[i].Trim();
                                    flowDT.Rows.Add(dr);
                                }
                            }
                            else if (column.Contains("imp_"))
                            {
                                string[] arr = column.Split('_');
                                DataRow dr = impDT.NewRow();
                                dr["psi_sid"] = allDT[b]["sid"].ToString().Trim();
                                dr["imp_sid"] = arr[1].Trim();
                                dr["imp_user"] = allDT[b][column].ToString().Trim();
                                impDT.Rows.Add(dr);
                            }
                        }
                    }

                    //if (sDate == "")
                    //{
                    //    return "没有选择细目开始、结束时间";
                    //}
                    //if (impDT.Rows.Count == 0)
                    //{
                    //    return "至少要选择一个工作种类及人员";
                    //}

                    string sid = allDT[b]["sid"] == null ? "" : allDT[b]["sid"].ToString().Trim();
                    string csid = allDT[b]["csid"] == null ? "" : allDT[b]["csid"].ToString().Trim();
                    //string ssid = context.Request.Params["ssid"] == null ? "" : context.Request.Params["ssid"].Trim();
                    string name = allDT[b]["itemName"] == null ? "" : allDT[b]["itemName"].ToString().Trim();
                    //string pw_content = context.Request.Params["pw_content"] == null ? "" : context.Request.Params["pw_content"].Trim();
                    string begin_date = sDate;
                    string end_date = eDate;
                    string pc_remark = allDT[b]["remark"] == null ? "" : allDT[b]["remark"].ToString().Trim();
                    string v1 = allDT[b]["v1"] == null ? "" : allDT[b]["v1"].ToString().Trim();
                    string v2 = allDT[b]["v2"] == null ? "" : allDT[b]["v2"].ToString().Trim();
                    if (sid != "")
                    {
                        Model.project_specific_item model = new BLL.project_specific_item().GetModel(int.Parse(sid));
                        model.parent_sid = int.Parse(csid);
                        if (begin_date != "" && end_date != "")
                        {
                            model.begin_date = DateTime.Parse(begin_date);
                            model.end_date = DateTime.Parse(end_date);
                        }
                        //model.isChild = 1;
                        model.v1 = v1;
                        model.v2 = v2;
                        model.name = name;
                        model.s_sid = pssid;
                        model.remark = pc_remark;
                        model.sequence = sequence;
                        reval=new BLL.project_specific_item().updateConstructionItem(model, impDT, flowDT);
                        if (reval != "success")
                        {
                            break;
                        }
                    }
                    else
                    {
                        Model.project_specific_item model = new Model.project_specific_item();
                     
                        model.parent_sid = int.Parse(csid);
                        if (begin_date != "" && end_date != "")
                        {
                            model.begin_date = DateTime.Parse(begin_date);
                            model.end_date = DateTime.Parse(end_date);
                        }
                        //model.isChild = 1;
                        model.v1 = v1;
                        model.v2 = v2;
                        model.name = name;
                        model.s_sid = pssid;
                        model.remark = pc_remark;
                        model.sequence = sequence;
                        reval=new BLL.project_specific_item().addConstructionItem(model, impDT, flowDT);
                        if (reval != "success")
                        {
                            break;
                        }
                    }
                }
                //if (reval == "success")
                //{
                   
                //}
                return reval;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private string ConstructionEdit_common(HttpContext context)
        {
            string pssid = context.Request.Params["pssid"].Trim();
            string allstr = context.Request.Params["allstr"].Trim();
            List<Hashtable> allDT = new List<Hashtable>();
            allDT = JsonSerializerHelper.JSONStringToList<Hashtable>(allstr);

            DataTable impDT = new DataTable();
            DataColumn psiColumn = new DataColumn();
            //该列的数据类型
            psiColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            psiColumn.ColumnName = "psi_sid";
            //该列得默认值
            psiColumn.DefaultValue = "";
            impDT.Columns.Add(psiColumn);

            DataColumn impColumn = new DataColumn();
            //该列的数据类型
            impColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            impColumn.ColumnName = "imp_sid";
            //该列得默认值
            impColumn.DefaultValue = "";
            impDT.Columns.Add(impColumn);

            DataColumn userColumn = new DataColumn();
            //该列的数据类型
            userColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            userColumn.ColumnName = "imp_user";
            //该列得默认值
            userColumn.DefaultValue = "";
            impDT.Columns.Add(userColumn);

            //psi_sid, fw_sid, fw_name, begin_time,end_time,sn,abbr
            DataTable flowDT = new DataTable();
            DataColumn fwpsiColumn = new DataColumn();
            //该列的数据类型
            fwpsiColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            fwpsiColumn.ColumnName = "psi_sid";
            //该列得默认值
            fwpsiColumn.DefaultValue = "";
            flowDT.Columns.Add(fwpsiColumn);

            DataColumn fwsidColumn = new DataColumn();
            //该列的数据类型
            fwsidColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            fwsidColumn.ColumnName = "fw";
            //该列得默认值
            fwsidColumn.DefaultValue = "";
            flowDT.Columns.Add(fwsidColumn);

            DataColumn sdateColumn = new DataColumn();
            //该列的数据类型
            sdateColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            sdateColumn.ColumnName = "fwdate";
            //该列得默认值
            sdateColumn.DefaultValue = "";
            flowDT.Columns.Add(sdateColumn);
            try
            {
                string reval = "success";
                int sequence = -1;
                string itemID = "'0'";
                for (int b = 0; b < allDT.Count; b++)
                {
                    itemID += ",'" + allDT[b]["sid"].ToString().Trim() + "'";
                }
                new DAL.project_specific_item().delList(itemID, pssid);
                for (int b = 0; b < allDT.Count; b++)
                {
                    sequence += 1;
                    if (b != 0)
                    {
                        if (allDT[b - 1]["contentName"].ToString().Trim() != allDT[b]["contentName"].ToString().Trim())
                            sequence = 0;
                    }
                    string sDate = "", eDate = "";
                    //string v1Str = "", v2Str = "";
                    flowDT.Clear();
                    impDT.Clear();
                    ArrayList akeys = new ArrayList(allDT[b].Keys);
                    ArrayList avalues = new ArrayList(allDT[b].Values);
                    akeys.Sort(); //按字母顺序进行排序
                    
                    for (int i = 0; i < akeys.Count; i++)
                    {

                        string column = akeys[i].ToString().Trim();
                        if (allDT[b][column].ToString().Trim() != "")
                        {
                            if (column.Contains("flow_"))
                            {
                                string[] arr = column.Split('_');
                                if (sDate == "")
                                {
                                    sDate = arr[1].Trim();
                                }
                                eDate = arr[1].Trim();
                                if (allDT[b][column].ToString().Trim() != "✓")
                                {
                                    DataRow dr = flowDT.NewRow();
                                    dr["psi_sid"] = allDT[b]["sid"].ToString().Trim();
                                    dr["fwdate"] = arr[1].Trim();
                                    dr["fw"] = allDT[b][column].ToString().Trim();//context.Request.Form[i].Trim();
                                    flowDT.Rows.Add(dr);
                                }
                            }
                            else if (column.Contains("imp_") && !column.Contains("Abbr_"))
                            {
                                string impUsers = "", impSid = "";
                                DataRow dr = impDT.NewRow();
                                //while (i < akeys.Count && akeys[i].ToString().Trim().Contains("imp_") && !column.Contains("Abbr_"))
                                //{
                                //    if (allDT[b][akeys[i].ToString().Trim()].ToString().Trim() != "")
                                //    {
                                        //string[] arr = column.Split('_');
                                        //if (i + 1 < akeys.Count)
                                        //{
                                        //    string column1 = akeys[i + 1].ToString().Trim();
                                        //    if (column1.Contains("Abbr_imp_"))
                                        //    {
                                        //        string[] arr1 = column1.Split('_');
                                        //        if (arr[1].Trim() == arr1[1].Trim())
                                        //        {
                                        //            impUsers += arr[2].Trim() + ",";
                                        //        }
                                        //        else
                                        //        {
                                        //            impUsers += arr[2].Trim() + ",";
                                        //        }
                                        //    }
                                        //    else
                                        //    {
                                        //        impUsers += arr[2].Trim() + ",";
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    impUsers += arr[2].Trim() + ",";
                                        //}
                                        //impSid = arr[1].Trim();
                                        
                                  //  }
                                  //  i = i + 1;
                                //}
                                string[] arr = column.Split('_');
                                impSid = arr[1].Trim();
                                impUsers = allDT[b][column].ToString().Trim();

                                dr["psi_sid"] = allDT[b]["sid"].ToString().Trim();
                                dr["imp_sid"] = impSid;
                                dr["imp_user"] = impUsers;//impUsers.Length > 0 ? impUsers.Substring(0, impUsers.Length - 1) : impUsers;//impUsers;
                                impDT.Rows.Add(dr);
                            }
                            //else if (column.Contains("v1_"))
                            //{
                            //    while (i < akeys.Count && akeys[i].ToString().Trim().Contains("v1_"))
                            //    {
                            //        if (allDT[b][akeys[i].ToString().Trim()].ToString().Trim() != "")
                            //        {
                            //            string[] arr = column.Split('_');
                            //            if (i + 1 < akeys.Count)
                            //            {
                            //                string column1 = akeys[i + 1].ToString().Trim();
                            //                if (column1.Contains("v1_"))
                            //                {
                            //                    string[] arr1 = column1.Split('_');
                            //                    if (arr[1].Trim() == arr1[1].Trim())
                            //                    {
                            //                        v1Str += arr[1].Trim() + ",";
                            //                    }
                            //                    else
                            //                    {
                            //                        v1Str += arr[1].Trim() + ",";
                            //                    }
                            //                }
                            //                else
                            //                {
                            //                    v1Str += arr[1].Trim() + ",";
                            //                }
                            //            }
                            //            else
                            //            {
                            //                v1Str += arr[1].Trim() + ",";
                            //            }
                            //        }
                            //        i = i + 1;
                            //    }
                            //}
                            //else if (column.Contains("v2_"))
                            //{
                            //    while (i < akeys.Count && akeys[i].ToString().Trim().Contains("v2_"))
                            //    {
                            //        if (allDT[b][akeys[i].ToString().Trim()].ToString().Trim() != "")
                            //        {
                            //            string[] arr = column.Split('_');
                            //            if (i + 1 < akeys.Count)
                            //            {
                            //                string column1 = akeys[i + 1].ToString().Trim();
                            //                if (column1.Contains("v2_"))
                            //                {
                            //                    string[] arr1 = column1.Split('_');
                            //                    if (arr[1].Trim() == arr1[1].Trim())
                            //                    {
                            //                        v2Str += arr[1].Trim() + ",";
                            //                    }
                            //                    else
                            //                    {
                            //                        v2Str += arr[1].Trim() + ",";
                            //                    }
                            //                }
                            //                else
                            //                {
                            //                    v2Str += arr[1].Trim() + ",";
                            //                }
                            //            }
                            //            else
                            //            {
                            //                v2Str += arr[1].Trim() + ",";
                            //            }
                            //        }
                            //        i = i + 1;
                            //    }
                            //}
                        }
                    }

                    string sid = allDT[b]["sid"] == null ? "" : allDT[b]["sid"].ToString().Trim();
                    string csid = allDT[b]["csid"] == null ? "" : allDT[b]["csid"].ToString().Trim();
                    string name = allDT[b]["itemName"] == null ? "" : allDT[b]["itemName"].ToString().Trim();
                    string begin_date = sDate;
                    string end_date = eDate;
                    string pc_remark = allDT[b]["remark"] == null ? "" : allDT[b]["remark"].ToString().Trim();
                    string v1 = allDT[b]["v1"] == null ? "" : allDT[b]["v1"].ToString().Trim();//v1Str.Length > 0 ? v1Str.Substring(0, v1Str.Length - 1) : v1Str;//allDT[b]["v1"] == null ? "" : allDT[b]["v1"].ToString().Trim();
                    string v2 = allDT[b]["v2"] == null ? "" : allDT[b]["v2"].ToString().Trim(); //v2Str.Length > 0 ? v2Str.Substring(0, v2Str.Length - 1) : v2Str;//allDT[b]["v2"] == null ? "" : allDT[b]["v2"].ToString().Trim();
                    if (sid != "")
                    {
                        Model.project_specific_item model = new BLL.project_specific_item().GetModel(int.Parse(sid));
                        model.parent_sid = int.Parse(csid);
                        if (begin_date != "" && end_date != "")
                        {
                            model.begin_date = DateTime.Parse(begin_date);
                            model.end_date = DateTime.Parse(end_date);
                        }
                        model.v1 = v1;
                        model.v2 = v2;
                        model.name = name;
                        model.s_sid = pssid;
                        model.remark = pc_remark;
                        model.sequence = sequence;
                        reval = new BLL.project_specific_item().updateConstructionItem(model, impDT, flowDT);
                        if (reval != "success")
                        {
                            break;
                        }
                    }
                    else
                    {
                        Model.project_specific_item model = new Model.project_specific_item();

                        int PP_sid = allDT[b]["PP_sid"] == null ? 0 :Convert.ToInt32( allDT[b]["PP_sid"].ToString().Trim());
                        model.PP_sid = Convert.ToInt32(PP_sid);
                        model.parent_sid = int.Parse(csid);
                        if (begin_date != "" && end_date != "")
                        {
                            model.begin_date = DateTime.Parse(begin_date);
                            model.end_date = DateTime.Parse(end_date);
                        }
                        model.v1 = v1;
                        model.v2 = v2;
                        model.name = name;
                        model.s_sid = pssid;
                        model.remark = pc_remark;
                        model.sequence = sequence;
                        reval = new BLL.project_specific_item().addConstructionItem(model, impDT, flowDT);
                        if (reval != "success")
                        {
                            break;
                        }
                    }
                }
                return reval;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private string ConstructionEdit_easyuidg1(HttpContext context)
        {
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Hashtable> insertDT = new List<Hashtable>();
            insertDT = JsonSerializerHelper.JSONStringToList<Hashtable>(addstr);
            List<Hashtable> updateDT = new List<Hashtable>();
            updateDT = JsonSerializerHelper.JSONStringToList<Hashtable>(updatestr);
            List<Hashtable> delDT = new List<Hashtable>();
            delDT = JsonSerializerHelper.JSONStringToList<Hashtable>(delstr);

            //List<Model.project_specific_item> insert = new List<Model.project_specific_item>();
            //List<Model.project_specific_item> update = new List<Model.project_specific_item>();
            //List<Model.project_specific_item> del = new List<Model.project_specific_item>();
            ////List<DataTable> insertDT = new List<DataTable>();

            //int paramsCount = context.Request.Form.Count;
            string sDate = "", eDate = "";

            DataTable impDT = new DataTable();
            DataColumn psiColumn = new DataColumn();
            //该列的数据类型
            psiColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            psiColumn.ColumnName = "psi_sid";
            //该列得默认值
            psiColumn.DefaultValue = "";
            impDT.Columns.Add(psiColumn);

            DataColumn impColumn = new DataColumn();
            //该列的数据类型
            impColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            impColumn.ColumnName = "imp_sid";
            //该列得默认值
            impColumn.DefaultValue = "";
            impDT.Columns.Add(impColumn);

            DataColumn userColumn = new DataColumn();
            //该列的数据类型
            userColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            userColumn.ColumnName = "imp_user";
            //该列得默认值
            userColumn.DefaultValue = "";
            impDT.Columns.Add(userColumn);

            //psi_sid, fw_sid, fw_name, begin_time,end_time,sn,abbr
            DataTable flowDT = new DataTable();
            DataColumn fwpsiColumn = new DataColumn();
            //该列的数据类型
            fwpsiColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            fwpsiColumn.ColumnName = "psi_sid";
            //该列得默认值
            fwpsiColumn.DefaultValue = "";
            flowDT.Columns.Add(fwpsiColumn);

            DataColumn fwsidColumn = new DataColumn();
            //该列的数据类型
            fwsidColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            fwsidColumn.ColumnName = "fw";
            //该列得默认值
            fwsidColumn.DefaultValue = "";
            flowDT.Columns.Add(fwsidColumn);

            DataColumn sdateColumn = new DataColumn();
            //该列的数据类型
            sdateColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            sdateColumn.ColumnName = "fwdate";
            //该列得默认值
            sdateColumn.DefaultValue = "";
            flowDT.Columns.Add(sdateColumn);
            try
            {
                string reval = "";
                for (int a = 0; a < insertDT.Count; a++)
                {
                    ArrayList akeys = new ArrayList(insertDT[a].Keys);
                    ArrayList avalues = new ArrayList(insertDT[a].Values);
                    akeys.Sort(); //按字母顺序进行排序
                    for (int i = 0; i < akeys.Count; i++)
                    {
                        string column = akeys[i].ToString().Trim();
                        if (insertDT[a][column].ToString().Trim() != "")
                        {
                            if (column.Contains("flow_"))
                            {
                                string[] arr = column.Split('_');
                                if (sDate == "")
                                {
                                    sDate = arr[1].Trim();
                                }
                                eDate = arr[1].Trim();
                                //if (insertDT[j][column].ToString().Trim() != "0")
                                //{
                                DataRow dr = flowDT.NewRow();
                                dr["psi_sid"] = insertDT[a]["sid"].ToString().Trim();
                                dr["fwdate"] = arr[1].Trim();
                                dr["fw"] = insertDT[a][column].ToString().Trim();//context.Request.Form[i].Trim();
                                flowDT.Rows.Add(dr);
                                //}
                            }
                            else if (column.Contains("imp_"))
                            {
                                string[] arr = column.Split('_');
                                DataRow dr = impDT.NewRow();
                                dr["psi_sid"] = insertDT[a]["sid"].ToString().Trim();
                                dr["imp_sid"] = arr[1].Trim();
                                dr["imp_user"] = insertDT[a][column].ToString().Trim();
                                impDT.Rows.Add(dr);
                            }
                        }
                    }

                    if (sDate == "")
                    {
                        return "没有选择细目开始、结束时间";
                    }
                    if (impDT.Rows.Count == 0)
                    {
                        return "至少要选择一个工作种类及人员";
                    }

                    string sid = insertDT[a]["sid"] == null ? "" : insertDT[a]["sid"].ToString().Trim();
                    string csid = insertDT[a]["csid"] == null ? "" : insertDT[a]["csid"].ToString().Trim();
                    //string ssid = context.Request.Params["ssid"] == null ? "" : context.Request.Params["ssid"].Trim();
                    string name = insertDT[a]["itemName"] == null ? "" : insertDT[a]["itemName"].ToString().Trim();
                    //string pw_content = context.Request.Params["pw_content"] == null ? "" : context.Request.Params["pw_content"].Trim();
                    string begin_date = sDate;
                    string end_date = eDate;
                    string pc_remark = insertDT[a]["remark"] == null ? "" : insertDT[a]["remark"].ToString().Trim();
                    string v1 = insertDT[a]["v1"] == null ? "" : insertDT[a]["v1"].ToString().Trim();
                    string v2 = insertDT[a]["v2"] == null ? "" : insertDT[a]["v2"].ToString().Trim();
                    string sequence = insertDT[a]["itemSequence"] == null ? "" : insertDT[a]["itemSequence"].ToString().Trim();

                    Model.project_specific_item model = new Model.project_specific_item();
                    model.parent_sid = int.Parse(csid);
                    model.begin_date = DateTime.Parse(begin_date);
                    model.end_date = DateTime.Parse(end_date);
                    //model.isChild = 1;
                    model.v1 = v1;
                    model.v2 = v2;
                    model.name = name;
                    //model.s_sid = ssid;
                    model.remark = pc_remark;
                    model.sequence = int.Parse(sequence);
                    new BLL.project_specific_item().addConstructionItem(model, impDT, flowDT);
                }

                for (int b = 0; b < updateDT.Count; b++)
                {
                    flowDT.Clear();
                    impDT.Clear();
                    ArrayList akeys = new ArrayList(updateDT[b].Keys);
                    ArrayList avalues = new ArrayList(updateDT[b].Values);
                    akeys.Sort(); //按字母顺序进行排序
                    for (int i = 0; i < akeys.Count; i++)
                    {

                        string column = akeys[i].ToString().Trim();
                        if (updateDT[b][column].ToString().Trim() != "")
                        {
                            if (column.Contains("flow_"))
                            {
                                string[] arr = column.Split('_');
                                if (sDate == "")
                                {
                                    sDate = arr[1].Trim();
                                }
                                eDate = arr[1].Trim();
                                if (updateDT[b][column].ToString().Trim() != "0")
                                {
                                    DataRow dr = flowDT.NewRow();
                                    dr["psi_sid"] = updateDT[b]["sid"].ToString().Trim();
                                    dr["fwdate"] = arr[1].Trim();
                                    dr["fw"] = updateDT[b][column].ToString().Trim();//context.Request.Form[i].Trim();
                                    flowDT.Rows.Add(dr);
                                }
                            }
                            else if (column.Contains("imp_"))
                            {
                                string[] arr = column.Split('_');
                                DataRow dr = impDT.NewRow();
                                dr["psi_sid"] = updateDT[b]["sid"].ToString().Trim();
                                dr["imp_sid"] = arr[1].Trim();
                                dr["imp_user"] = updateDT[b][column].ToString().Trim();
                                impDT.Rows.Add(dr);
                            }
                        }
                    }

                    if (sDate == "")
                    {
                        return "没有选择细目开始、结束时间";
                    }
                    if (impDT.Rows.Count == 0)
                    {
                        return "至少要选择一个工作种类及人员";
                    }

                    string sid = updateDT[b]["sid"] == null ? "" : updateDT[b]["sid"].ToString().Trim();
                    string csid = updateDT[b]["csid"] == null ? "" : updateDT[b]["csid"].ToString().Trim();
                    //string ssid = context.Request.Params["ssid"] == null ? "" : context.Request.Params["ssid"].Trim();
                    string name = updateDT[b]["itemName"] == null ? "" : updateDT[b]["itemName"].ToString().Trim();
                    //string pw_content = context.Request.Params["pw_content"] == null ? "" : context.Request.Params["pw_content"].Trim();
                    string begin_date = sDate;
                    string end_date = eDate;
                    string pc_remark = updateDT[b]["remark"] == null ? "" : updateDT[b]["remark"].ToString().Trim();
                    string v1 = updateDT[b]["v1"] == null ? "" : updateDT[b]["v1"].ToString().Trim();
                    string v2 = updateDT[b]["v2"] == null ? "" : updateDT[b]["v2"].ToString().Trim();

                    //Model.project_specific_item model = new BLL.project_specific_item().GetModel(int.Parse(sid));
                    //model.parent_sid = int.Parse(csid);
                    //model.begin_date = DateTime.Parse(begin_date);
                    //model.end_date = DateTime.Parse(end_date);
                    ////model.isChild = 1;
                    //model.v1 = v1;
                    //model.v2 = v2;
                    //model.name = name;
                    ////model.s_sid = ssid;
                    //model.remark = pc_remark;
                    //return new BLL.project_specific_item().updateConstructionItem(model, impDT, flowDT);
                    if (sid != "")
                    {
                        Model.project_specific_item model = new BLL.project_specific_item().GetModel(int.Parse(sid));
                        model.parent_sid = int.Parse(csid);
                        model.begin_date = DateTime.Parse(begin_date);
                        model.end_date = DateTime.Parse(end_date);
                        //model.isChild = 1;
                        model.v1 = v1;
                        model.v2 = v2;
                        model.name = name;
                        //model.s_sid = ssid;
                        model.remark = pc_remark;
                        new BLL.project_specific_item().updateConstructionItem(model, impDT, flowDT);
                    }
                    else
                    {
                        Model.project_specific_item model = new Model.project_specific_item();
                        model.parent_sid = int.Parse(csid);
                        model.begin_date = DateTime.Parse(begin_date);
                        model.end_date = DateTime.Parse(end_date);
                        //model.isChild = 1;
                        model.v1 = v1;
                        model.v2 = v2;
                        model.name = name;
                        //model.s_sid = ssid;
                        model.remark = pc_remark;
                        model.sequence = 0;
                        new BLL.project_specific_item().addConstructionItem(model, impDT, flowDT);
                    }
                }
                return reval;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }

            //if (sDate == "")
            //{
            //    return "没有选择细目开始、结束时间";
            //}
            //if (impDT.Rows.Count == 0)
            //{
            //    return "至少要选择一个工作种类及人员";
            //}
            //if (name.Length == 0)
            //{
            //    return "图纸及索引号必填项";
            //}

            ////string sequence = context.Request.Params["sequence"] == null ? "" : context.Request.Params["sequence"].Trim();
            //if (sid != "")
            //{
            //    Model.project_specific_item model = new BLL.project_specific_item().GetModel(int.Parse(sid));
            //    model.parent_sid = int.Parse(csid);
            //    model.begin_date = DateTime.Parse(begin_date);
            //    model.end_date = DateTime.Parse(end_date);
            //    //model.isChild = 1;
            //    model.v1 = v1;
            //    model.v2 = v2;
            //    model.name = name;
            //    //model.s_sid = ssid;
            //    model.remark = pc_remark;
            //    return new BLL.project_specific_item().updateConstructionItem(model, impDT, flowDT);
            //}
            //else
            //{
            //    Model.project_specific_item model = new Model.project_specific_item();
            //    model.parent_sid = int.Parse(csid);
            //    model.begin_date = DateTime.Parse(begin_date);
            //    model.end_date = DateTime.Parse(end_date);
            //    //model.isChild = 1;
            //    model.v1 = v1;
            //    model.v2 = v2;
            //    model.name = name;
            //    //model.s_sid = ssid;
            //    model.remark = pc_remark;
            //    model.sequence = 0;
            //    return new BLL.project_specific_item().addConstructionItem(model, impDT, flowDT);
            //}
        }


        private string ConstructionEdit_easyuidg_row(HttpContext context)
        {
            string allstr = context.Request.Params["editstr"].Trim();
            List<Hashtable> allDT = new List<Hashtable>();
            allDT = JsonSerializerHelper.JSONStringToList<Hashtable>("["+allstr+"]");
            string sDate = "", eDate = "";

            DataTable impDT = new DataTable();
            DataColumn psiColumn = new DataColumn();
            //该列的数据类型
            psiColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            psiColumn.ColumnName = "psi_sid";
            //该列得默认值
            psiColumn.DefaultValue = "";
            impDT.Columns.Add(psiColumn);

            DataColumn impColumn = new DataColumn();
            //该列的数据类型
            impColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            impColumn.ColumnName = "imp_sid";
            //该列得默认值
            impColumn.DefaultValue = "";
            impDT.Columns.Add(impColumn);

            DataColumn userColumn = new DataColumn();
            //该列的数据类型
            userColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            userColumn.ColumnName = "imp_user";
            //该列得默认值
            userColumn.DefaultValue = "";
            impDT.Columns.Add(userColumn);

            //psi_sid, fw_sid, fw_name, begin_time,end_time,sn,abbr
            DataTable flowDT = new DataTable();
            DataColumn fwpsiColumn = new DataColumn();
            //该列的数据类型
            fwpsiColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            fwpsiColumn.ColumnName = "psi_sid";
            //该列得默认值
            fwpsiColumn.DefaultValue = "";
            flowDT.Columns.Add(fwpsiColumn);

            DataColumn fwsidColumn = new DataColumn();
            //该列的数据类型
            fwsidColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            fwsidColumn.ColumnName = "fw";
            //该列得默认值
            fwsidColumn.DefaultValue = "";
            flowDT.Columns.Add(fwsidColumn);

            DataColumn sdateColumn = new DataColumn();
            //该列的数据类型
            sdateColumn.DataType = System.Type.GetType("System.String");
            //该列得名称
            sdateColumn.ColumnName = "fwdate";
            //该列得默认值
            sdateColumn.DefaultValue = "";
            flowDT.Columns.Add(sdateColumn);
            try
            {
                string reval = "success";
                int sequence = -1;
                string itemID = "0";
                for (int b = 0; b < allDT.Count; b++)
                {
                    flowDT.Clear();
                    impDT.Clear();
                    ArrayList akeys = new ArrayList(allDT[b].Keys);
                    ArrayList avalues = new ArrayList(allDT[b].Values);
                    akeys.Sort(); //按字母顺序进行排序
                    for (int i = 0; i < akeys.Count; i++)
                    {

                        string column = akeys[i].ToString().Trim();
                        if (allDT[b][column].ToString().Trim() != "")
                        {
                            if (column.Contains("flow_"))
                            {
                                string[] arr = column.Split('_');
                                if (sDate == "")
                                {
                                    sDate = arr[1].Trim();
                                }
                                eDate = arr[1].Trim();
                                if (allDT[b][column].ToString().Trim() != "✓")
                                {
                                    DataRow dr = flowDT.NewRow();
                                    dr["psi_sid"] = allDT[b]["sid"].ToString().Trim();
                                    dr["fwdate"] = arr[1].Trim();
                                    dr["fw"] = allDT[b][column].ToString().Trim();//context.Request.Form[i].Trim();
                                    flowDT.Rows.Add(dr);
                                }
                            }
                            else if (column.Contains("imp_"))
                            {
                                string[] arr = column.Split('_');
                                DataRow dr = impDT.NewRow();
                                dr["psi_sid"] = allDT[b]["sid"].ToString().Trim();
                                dr["imp_sid"] = arr[1].Trim();
                                dr["imp_user"] = allDT[b][column].ToString().Trim();
                                impDT.Rows.Add(dr);
                            }
                        }
                    }

                    if (sDate == "")
                    {
                        return "没有选择细目开始、结束时间";
                    }
                    if (impDT.Rows.Count == 0)
                    {
                        return "至少要选择一个工作种类及人员";
                    }

                    string sid = allDT[b]["sid"] == null ? "" : allDT[b]["sid"].ToString().Trim();
                    string csid = allDT[b]["csid"] == null ? "" : allDT[b]["csid"].ToString().Trim();
                    //string ssid = context.Request.Params["ssid"] == null ? "" : context.Request.Params["ssid"].Trim();
                    string name = allDT[b]["itemName"] == null ? "" : allDT[b]["itemName"].ToString().Trim();
                    //string pw_content = context.Request.Params["pw_content"] == null ? "" : context.Request.Params["pw_content"].Trim();
                    string begin_date = sDate;
                    string end_date = eDate;
                    string pc_remark = allDT[b]["remark"] == null ? "" : allDT[b]["remark"].ToString().Trim();
                    string v1 = allDT[b]["v1"] == null ? "" : allDT[b]["v1"].ToString().Trim();
                    string v2 = allDT[b]["v2"] == null ? "" : allDT[b]["v2"].ToString().Trim();
                    string sequencestr = allDT[b]["sequence"] == null ? "0" : allDT[b]["sequence"].ToString().Trim();
                    if (sid != "")
                    {
                        Model.project_specific_item model = new BLL.project_specific_item().GetModel(int.Parse(sid));
                        model.parent_sid = int.Parse(csid);
                        model.begin_date = DateTime.Parse(begin_date);
                        model.end_date = DateTime.Parse(end_date);
                        //model.isChild = 1;
                        model.v1 = v1;
                        model.v2 = v2;
                        model.name = name;
                        //model.s_sid = ssid;
                        model.remark = pc_remark;
                        model.sequence = int.Parse(sequencestr);
                        reval = new BLL.project_specific_item().updateConstructionItem(model, impDT, flowDT);
                        if (reval != "success")
                        {
                            break;
                        }
                    }
                    else
                    {
                        Model.project_specific_item model = new Model.project_specific_item();
                        model.parent_sid = int.Parse(csid);
                        model.begin_date = DateTime.Parse(begin_date);
                        model.end_date = DateTime.Parse(end_date);
                        //model.isChild = 1;
                        model.v1 = v1;
                        model.v2 = v2;
                        model.name = name;
                        //model.s_sid = ssid;
                        model.remark = pc_remark;
                        model.sequence = int.Parse(sequencestr);
                        reval = new BLL.project_specific_item().addConstructionItem(model, impDT, flowDT);
                        if (reval != "success")
                        {
                            break;
                        }
                    }
                }
                return reval;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        private string ItemDelCheck(HttpContext context)
        {
            return DBUtility.DbHelperSQL.GetSingle("select count(1) from project_review where si_sid='" + context.Request.Params["sid"].Trim() + "'").ToString().Trim();
            //return "";
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