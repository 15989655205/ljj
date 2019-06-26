using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.Project
{
    public partial class PrintProject : System.Web.UI.Page
    {
        protected string sid = "", pssid = "", pname = "", pcode = "", stageName = "",isConstruction = "";
        protected Model.project pModel = new Model.project();
        protected string trStr = "";
        protected string type = "",worker="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                worker = Request.Params["worker"] == null ? "" : Request.Params["worker"].Trim();
                type = Request.Params["type"] == null ? "" : Request.Params["type"].Trim();
                pssid = Request.Params["ps_sid"] == null ? "" : Request.Params["ps_sid"].Trim();
                isConstruction = Request.Params["isConstruction"] == null ? "" : Request.Params["isConstruction"].Trim();
                DataTable dt = new DataTable();
                DataSet ds = new BLL.Common().GetList("select project.sid as psid, project_name,project_code,stage_name,begin_date,end_date,project_stage.is_system from project_stage left outer join project on project_stage.p_sid=project.sid where project_stage.sid='" + pssid + "'");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt.Rows.Count > 0)
                {
                    isConstruction = dt.Rows[0]["is_system"].ToString().Trim();
                    pname = dt.Rows[0]["project_name"].ToString().Trim();
                    pcode = dt.Rows[0]["project_code"].ToString().Trim();
                    stageName = dt.Rows[0]["stage_name"].ToString().Trim();

                    pModel = new BLL.project().GetModel(int.Parse(dt.Rows[0]["psid"].ToString().Trim()));

                    string str0="", str1 = "", str2 = "", str3 = "", str4 = "";
                    DataTable impDT = new DataTable();
                    DataSet impDS = new BLL.Common().GetList("select * from project_implement where s_sid='" + pssid + "' order by sequence asc");
                    if (impDS.Tables.Count > 0)
                    {
                        impDT = impDS.Tables[0];

                        for (int i = 0; i < impDT.Rows.Count; i++)
                        {
                           
                            if (isConstruction=="1")
                            {
                                str1 += "<th  colspan='1'>" + impDT.Rows[i]["implement_name"].ToString().Trim() + "</th>";
                                str0 += "<th >" + new BLL.Common().GetList("select dbo.get_SNs_zxf('" + impDT.Rows[i]["v1"].ToString().Trim() + "')").Tables[0].Rows[0][0].ToString() + "</th>";
                            }
                            else
                            {
                                str1 += "<th  colspan='1' rowspan='2' >" + impDT.Rows[i]["implement_name"].ToString().Trim() + "</th>";
                            }

                            str2 += "<th style=''>" + new BLL.Common().GetList("select dbo.getUserName_fu('" + impDT.Rows[i]["implementers_sid"].ToString().Trim() + "')").Tables[0].Rows[0][0] + "</th>";
                        }
                    }
                    else
                    {
                       
                        if (isConstruction == "1")
                        {
                            str1 += "<th colspan='1'></th>";
                            str0 += "<th ></th>";
                        }
                        else
                        {
                            str1 += "<th colspan='1' rowspan='2'></th>";
                        }
                        str2 += "<th></th>";
                    }
                    string monthstr = "";
                    string cols="1";
                    if (dt.Rows[0]["begin_date"].ToString().Trim() != "" && dt.Rows[0]["end_date"].ToString().Trim() != "" && dt.Rows[0]["begin_date"] != null && dt.Rows[0]["end_date"] != null && DateTime.Parse(dt.Rows[0]["begin_date"].ToString()).ToString("yyyy-MM-dd") != "1900-01-01"&& DateTime.Parse(dt.Rows[0]["end_date"].ToString()).ToString("yyyy-MM-dd") != "1900-01-01")
                    {
                        DateTime sDate = DateTime.Parse(dt.Rows[0]["begin_date"].ToString().Trim());
                        DateTime eDate = DateTime.Parse(dt.Rows[0]["end_date"].ToString().Trim());

                        TimeSpan ts = eDate.AddDays(1).Subtract(sDate);
                        monthstr = "";
                        if (sDate.Month == eDate.Month)
                        {
                            monthstr = sDate.Month.ToString() + "月";
                        }
                        else
                        {
                            monthstr = sDate.Month.ToString() + "-" + eDate.Month.ToString() + "月";
                        }
                        cols = ts.Days.ToString();
                        for (int i = 0; i < ts.Days; i++)
                        {
                            str3 += "<th colspan='1'>" + sDate.AddDays(i).Day.ToString() + "</th>";
                            string w = "";
                            switch (sDate.AddDays(i).DayOfWeek)
                            {
                                case DayOfWeek.Sunday:
                                    w = "日";
                                    break;
                                case DayOfWeek.Monday:
                                    w = "一";
                                    break;
                                case DayOfWeek.Tuesday:
                                    w = "二";
                                    break;
                                case DayOfWeek.Wednesday:
                                    w = "三";
                                    break;
                                case DayOfWeek.Thursday:
                                    w = "四";
                                    break;
                                case DayOfWeek.Friday:
                                    w = "五";
                                    break;
                                case DayOfWeek.Saturday:
                                    w = "六";
                                    break;
                            }
                            str4 += "<th style='white-space:pre-wrap; word-wrap:break-word; '>" + w + "</th>";
                        }
                    }
                    else
                    {
                        monthstr = "";
                        str3 += "<th colspan='1'></th>";
                        str4 += "<th style='white-space:pre-wrap; word-wrap:break-word;'></th>";
                    }
                    int work_width = 200;
                    int showCount = 15;
                    if (int.Parse(cols) * 30 > 200)
                    {
                        work_width = int.Parse(cols) * 30;
                        if (work_width > 200)
                        {
                            showCount = showCount + ((work_width - 200) * 3 / 30);
                        }
                    }
                    string contentName = "", itemName = "", workTitleStr = "", showGroup = "\"\"", showData = "", showStage = "\"\"", showContent = "\"\"", widthContent = "200", widthItem = "300";
                    switch (isConstruction)
                    {
                        case "0":
                            contentName = "工作内容";
                            itemName = "细目";
                            showGroup = "\"\"";
                            workTitleStr = monthstr + "(黄色色块代表完成这项工作所需要的完成时间，计划表中实际完成时间将用绿色色块做标记)";
                            break;
                        case "1":
                            contentName = "空间";
                            itemName = "图纸及索引";
                            showGroup = "none";
                            string flow = "";
                            DataTable tmpDT = new DataTable();
                            DataSet tmpDS = new BLL.Common().GetList("select * from project_work_flow where s_sid='" + pssid + "' order by sequence asc");
                            if (tmpDS.Tables.Count > 0)
                            {
                                tmpDT = tmpDS.Tables[0];
                            }
                            for (int i = 0; i < tmpDT.Rows.Count; i++)
                            {
                                flow += (i + 1).ToString() + "." + tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
                            }

                            string workTitle = monthstr + "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))";
                            workTitleStr = workTitle;
                            //for (int i = 0; i < workTitle.Length; i++)
                            //{
                            //    workTitleStr += workTitle[i];
                            //    if ((i + 1) % showCount == 0)
                            //    {
                            //        workTitleStr += "<br/>";
                            //    }
                            //}
                            break;
                        case "2":
                            contentName = "货物类别";
                            itemName = "工作细目";
                            showGroup = "none";
                            widthContent = "100";
                            widthItem = "150";
                            workTitleStr = monthstr ;
                            break;

                        case "3":
                            showContent = "加工类别";
                            itemName = "工作细目";
                            showGroup = "none";
                            showStage = "none";
                            showContent = "none";
                            widthContent = "80";
                            widthItem = "80";
                            workTitleStr = monthstr + "(进程计划)";
                            break;

                        case "4":
                            contentName = "加工类别";
                            itemName = "工作细目";
                            showGroup = "none";
                            showStage = "none";
                            showContent = "none";
                            widthContent = "80";
                            widthItem = "80";
                            workTitleStr = monthstr + "(进程计划)";
                            break;
                        default:
                            break;
                    }
                    showData = ViewItem(pssid, isConstruction);

                    string tbCalss = "printinnertable";
                    //if (isConstruction == "3")
                    //{
                    //    tbCalss = "printinnertable3";
                    //}
                    //if (isConstruction == "4")
                    //{
                    //    tbCalss = "printinnertable2";
                    //}
                    trStr += "<table  height='100%' width='100%'  class='" + tbCalss + "' cellpadding='0' cellspacing='0' border='0'  style='table-layout:fixed; border:0px;' >";
                    trStr += "<thead>";
                    trStr += "<tr>";
                    trStr += "<th rowspan='3'  style='display:" + showStage + ";width:15px;'>阶段</th>";
                    if (isConstruction == "3")
                    {
                        trStr += "<th rowspan='3' style='width:40px;border-left:0px solid #000000;'>图纸编号 </th>";
                        trStr += "<th rowspan='1' colspan='4' style='width:328px'>细目</th>";

                        trStr += "<th rowspan='3' style='width:60px'>应用空间 </th>";
                        trStr += "<th rowspan='3' style='width:60px'>应用数量</th>";
                        trStr += "<th rowspan='3' style='width:60px'>安装位置</th>";
                        trStr += "<th rowspan='3' style='width:60px'>应用部位</th>";
                        trStr += "<th rowspan='3' style='width:40px'>单位 </th>";
                        trStr += "<th rowspan='3' style='width:40px'>数量</th>";
                        trStr += "<th rowspan='3' style='width:60px'>油漆色板编号 </th>";

                        trStr += "<th rowspan='3' style='width:60px'>备注</th>";
                        //trStr += "<th rowspan='3' style=''>加工类别  </th>";
                    }
                    else if (isConstruction == "4")
                    {
                        trStr += "<th rowspan='3' style='width:60px;border-left:0px solid #000000;'>图纸编号 </th>";
                        trStr += "<th rowspan='1' colspan='4' style='width:328px'>细目</th>";

                        trStr += "<th rowspan='3' style='width:60px'>应用空间 </th>";
                        trStr += "<th rowspan='3' style='width:60px'>应用部位</th>";
                       
                        trStr += "<th rowspan='3' style='width:40px'>单位 </th>";
                        trStr += "<th rowspan='3' style='width:40px'>数量</th>";
                        trStr += "<th rowspan='3' style='width:60px'>成品</th>";

                        trStr += "<th rowspan='3' style='width:60px'>备注</th>";
                    }
                    
                    trStr += "<th rowspan='3' style='display:" + showGroup + ";width:45px;'>小组</th>";
                    trStr += "<th rowspan='3' style='display:" + showContent + ";width:"+widthContent+"px'>" + contentName + "</th>";

                    trStr += "<th rowspan='3' style='width:" + widthItem + "px;border-left:0px solid #000000;'  >" + itemName + "</th>";

                    trStr += "<th colspan='1' style='width:14px;'>月</th>";
                    trStr += "<th colspan='" + cols + "' style='width:"+int.Parse(cols)*16+"px;'>" + workTitleStr + "</th>";
                    trStr += str1;
                    //trStr += "<th width='100px' rowspan='3'>完成情况(按照公司设计质量标准评定:绿，黄，橙，红。四种工作完成状况)</th>";
                    trStr += "<th rowspan='3' style=''>组长审核</th>";
                    trStr += "<th rowspan='3' style=''>组长审核结果</th>";
                    trStr += "<th rowspan='3' style=''>未完成的原因</th>";
                    trStr += "<th rowspan='3' style=''>解决的办法</th>";
                    trStr += "<th rowspan='3' style=''>解决的结果</th>";
                    trStr += "<th rowspan='3' style=''>总审人</th>";
                    trStr += "<th rowspan='3' style=''>总审结果</th>";
                    trStr += "<th rowspan='3' style=' border-right:0 solid #ffffff;'>备注</th>";

                    trStr += "</tr>";

                    trStr += "<tr>";
                    if (isConstruction == "3")
                    {
                        trStr += "<th colspan='1' rowspan='2' style='width:80px;'>项目产品名称 </th>";
                        trStr += "<th colspan='1' rowspan='2' style='width:80px;'>图片 </th>";
                        trStr += "<th colspan='1' rowspan='2' style='width:80px;'>图纸规格 </th>";
                        trStr += "<th rowspan='2' style='width:50px;'>漆面颜色 </th>";
                    }
                    else if (isConstruction == "4")
                    {
                        trStr += "<th colspan='1' rowspan='2' style='width:80px;'>项目产品名称 </th>";
                        trStr += "<th colspan='1' rowspan='2' style='width:80px;'>图片 </th>";
                        trStr += "<th colspan='1' rowspan='2' style='width:80px;'>图纸规格 </th>";
                        trStr += "<th rowspan='2' style='width:50px;'>漆面颜色 </th>";
                    }
                    trStr += "<th colspan='1'>日</th>";
                    trStr += str3;
                    trStr += str0;
                    trStr += "</tr>";

                    trStr += "<tr>";
                    trStr += "<th >星期</th>";
                    trStr += str4;
                    trStr += str2;
                    trStr += "</tr>";
                    trStr += "</thead>";
                    trStr += showData;
                    trStr += "</table>";

                    //if (isConstruction == "3")
                    //{
                    //    string productDT = GetProductTableBySingle(pssid);
                    //    trStr = "<table height='100%' width='100%' border='0' cellpadding='0' cellspacing='0'><tr><td style='vertical-align:top; height:100% !important;'>" + productDT + "</td><td style='vertical-align:top; height:100% !important;'>" + trStr + "</td></tr></table>";
                    //}

                    //if (isConstruction == "4")
                    //{
                    //    string productDT = GetProductTable(pssid);
                    //    trStr = "<table height='100%' width='100%' border='0' cellpadding='0' cellspacing='0' style='border:0px;' ><tr><td style='width:500px;vertical-align:top; height:100% !important;'>" + productDT + "</td><td style='vertical-align:top; height:100% !important;'>" + trStr + "</td></tr></table>";
                    //}



                    //if (isConstruction == "1")
                    //{

                    //    string flow = "";
                    //    DataTable tmpDT = new DataTable();
                    //    DataSet tmpDS = new BLL.Common().GetList("select * from project_work_flow where s_sid='" + pssid + "' order by sequence asc");
                    //    if (tmpDS.Tables.Count > 0)
                    //    {
                    //        tmpDT = tmpDS.Tables[0];
                    //    }
                    //    for (int i = 0; i < tmpDT.Rows.Count; i++)
                    //    {
                    //        flow += (i + 1).ToString() + "." + tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
                    //    }

                    //    string workTitle = monthstr + "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))";
                    //    string showWorkTitle = "";
                    //    for (int i = 0; i < workTitle.Length; i++)
                    //    {
                    //        showWorkTitle += workTitle[i];
                    //        if ((i + 1) % showCount == 0)
                    //        {
                    //            showWorkTitle += "<br/>";
                    //        }
                    //    }
                    //    trStr += "<table class='printinnertable' cellpadding='0' cellspacing='0'>";
                    //    trStr += "<thead>";
                    //    trStr += "<tr>";
                    //    trStr += "<th rowspan='3' >阶段</th>";
                    //    trStr += "<th rowspan='3'>空间</th>";

                    //    trStr += "<th rowspan='3'>图纸及索引</th>";

                    //    trStr += "<th colspan='1'>月</th>";
                    //    trStr += "<th colspan='" + cols + "'>" + workTitle+"</th>";
                    //    trStr += str1;
                    //    //trStr += "<th width='100px' rowspan='3'>完成情况(按照公司设计质量标准评定:绿，黄，橙，红。四种工作完成状况)</th>";
                    //    trStr += "<th width='60px' rowspan='3'>主管审核人</th>";
                    //    trStr += "<th width='60px' rowspan='3'>主管审核结果</th>";
                    //    trStr += "<th width='150px' rowspan='3'>未完成的原因</th>";
                    //    trStr += "<th width='150px' rowspan='3'>解决的办法</th>";
                    //    trStr += "<th width='150px' rowspan='3'>总审人</th>";
                    //    trStr += "<th width='150px' rowspan='3'>总审结果</th>";
                    //    trStr += "<th width='150px' rowspan='3'>备注</th>";
                        
                    //    trStr += "</tr>";

                    //    trStr += "<tr>";
                    //    trStr += "<th colspan='1'>日</th>";
                    //    trStr += str3;
                    //    trStr += str0;
                    //    trStr += "</tr>";

                    //    trStr += "<tr>";
                    //    trStr += "<th >星期</th>";
                    //    trStr += str4;
                    //    trStr += str2;
                    //    trStr += "</tr>";
                    //    trStr += "</thead>";
                    //    trStr += ContentViewItem1(pssid);
                    //    trStr += "</table>";
                    //}
                    //else
                    //{
                    //    trStr += "<table class='printinnertable' cellpadding='0' cellspacing='0'>";
                    //    trStr += "<thead>";
                    //    trStr += "<tr>";
                    //    trStr += "<th rowspan='3'>阶段</th>";
                    //    trStr += "<th rowspan='3'>小组</th>";
                    //    trStr += "<th rowspan='3' >工作内容</th>";

                    //    trStr += "<th rowspan='3'>细目</th>";

                    //    trStr += "<th colspan='1'>月</th>";
                    //    trStr += "<th colspan='" + cols + "'>" + monthstr + "(黄色色块代表完成这项工作所需要的完成时间，计划表中实际完成时间将用绿色色块做标记)</th>";
                    //    trStr += str1;
                    //    //trStr += "<th width='100px' rowspan='3'>完成情况(按照公司设计质量标准评定:绿，黄，橙，红。四种工作完成状况)</th>";
                    //    trStr += "<th width='60px' rowspan='3'>主管审核人</th>";
                    //    trStr += "<th width='60px' rowspan='3'>主管审核结果</th>";
                    //    trStr += "<th width='150px' rowspan='3'>未完成的原因</th>";
                    //    trStr += "<th width='150px' rowspan='3'>解决的办法</th>";
                    //    trStr += "<th width='150px' rowspan='3'>总审人</th>";
                    //    trStr += "<th width='150px' rowspan='3'>总审结果</th>";
                    //    trStr += "<th width='150px' rowspan='3'>备注</th>";
                       
                    //    trStr += "</tr>";

                    //    trStr += "<tr>";
                    //    trStr += "<th colspan='1'>日</th>";
                    //    trStr += str3;
                    //    trStr += "</tr>";

                    //    trStr += "<tr>";
                    //    trStr += "<th >星期</th>";
                    //    trStr += str4;
                    //    trStr += str2;
                    //    trStr += "</tr>";
                    //    trStr += "</thead>";
                    //    trStr += ContentViewItem(pssid);
                    //    trStr += "</table>";
                    //}
                }
            }
        }

        private string ViewItem(string pssid,string flag)
        {
            Model.BaseUser bu = Session["login"] as Model.BaseUser;
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
                where += " and dbo.getProworkUid_fu(a.sid) in ('" + worker + "')";

            string showGroup = "\"\"", showStage = "\"\"", showContent = "\"\"";
            switch (flag)
            {
                case "0":
                    showGroup = "\"\"";
                    break;
                case "1":
                    showGroup = "none";
                    break;
                case "2":
                    showGroup = "none";
                    break;
                case "3":
                    showGroup = "none";
                    showStage = "none";
                    showContent = "none";
                    break;
                case "4":
                    showGroup = "none";
                    showStage = "none";
                    showContent = "none";
                    break;
                default:
                    break;
            }
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            if (isConstruction != "3")
            {
                ds = new BLL.Common().GetList("  select a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,dbo.getUserNames_fu(a.v1) as header,dbo.getProReview_result_zxf(a.sid) as review_results,a.unfinished_reason,a.solution,a.reviewed,dbo.getUserNames_fu(a.v2) as finaler,dbo.getProjectReview_zxf(a.sid) as reviews,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectSubmitDate_fu(a.sid) as submitDate from project_specific_item a right outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where  b.s_sid=" + pssid + where + " and b.ischild=0 order by b.group_sid asc, b.sequence asc, a.sequence asc  ");
            }
            else
            {
                //ds = new BLL.Common().GetList("select a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,(case when a.v1='' or a.v1 is null then dbo.getUserNames_fu(d.v1) else dbo.getUserNames_fu(a.v1) end) as header,dbo.getProReview_result_zxf(a.sid) as review_results,a.unfinished_reason,a.solution,a.reviewed,(case when a.v2='' or a.v2 is null then dbo.getUserNames_fu(e.v2) else dbo.getUserNames_fu(a.v2) end ) as finaler,dbo.getProjectReview_zxf(a.sid) as reviews,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectSubmitDate_fu(a.sid) as submitDate "
//+ "		from project_specific_item a "
//+"		right outer join project_specific_item b on a.parent_sid=b.sid "
//+"		left outer join project_stage c on b.s_sid=c.sid"
//+"		left outer join project_group d on b.group_sid=d.sid "
//+"		inner join project e on c.p_sid=e.sid "
//+"		where  b.s_sid="+pssid+" and b.ischild=0 order by b.group_sid asc, b.sequence asc, a.sequence asc");
                ds = new BLL.Common().GetList("select * from v_ProjectProductItem a where a.s_sid=" + pssid + where + " and a.ischild=0 order by a.group_sid asc, a.csequence asc, a.sequence asc");
            }
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];

                if (isConstruction == "4")
                {
                    DataTable dt1 = new DataTable();
                    DataSet ds1 = new BLL.Common().GetList("select number,ProductID productID,productName,productPic,productSize,productColor,useSpace,usePart,unit,amount,EndProduct,remark ppiRemark from v_Project_Product where ps_sid='" + pssid + "'");
                    DataTable tempDT = new DataTable();
                    int min = 0, max = 0, dtflag = 0;
                    if (ds1.Tables.Count > 0)
                    {
                        dt1 = ds1.Tables[0];
                        tempDT.Columns.Add("sid");
                        tempDT.Columns.Add("stage_name");
                        for (int i = 0; i < dt1.Columns.Count; i++)
                        {
                            tempDT.Columns.Add(dt1.Columns[i].ColumnName);
                        }
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (dt.Columns[i].ColumnName != "stage_name" && dt.Columns[i].ColumnName != "sid")
                                tempDT.Columns.Add(dt.Columns[i].ColumnName);
                        }

                        if (dt.Rows.Count >= dt1.Rows.Count)
                        {
                            min = dt1.Rows.Count;
                            max = dt.Rows.Count;
                            dtflag = 0;
                        }
                        else
                        {
                            min = dt.Rows.Count;
                            max = dt1.Rows.Count;
                        }
                        int a = 0;
                        int quotient = max / min;
                        int mod = max % min;
                        for (int i = 0; i < max; i++)
                        {

                            //int iQuotient = i / quotient;
                            //if (iQuotient == min)
                            //{
                            //    a = iQuotient - 1;
                            //}
                            //else
                            //{
                            //    a = iQuotient;
                            //}
                            if (mod != 0)
                            {
                                if ((i / ((quotient + 1) * mod)) == 0)
                                {
                                    a = i / (quotient + 1);
                                }
                                else
                                {
                                    a = min - 1;
                                }
                            }
                            else
                            {
                                a = i / min;
                            }
                            DataRow dr = tempDT.NewRow();
                            for (int j = 0; j < dt1.Columns.Count; j++)
                            {
                                dr[j+2] = dt1.Rows[dtflag == 0 ? a : i][j];
                            }
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                if (dt.Columns[j].ColumnName == "sid")
                                    dr[0] = dt.Rows[dtflag == 0 ? i : a][j];
                                else if (dt.Columns[j].ColumnName == "stage_name")
                                    dr[1] = dt.Rows[dtflag == 0 ? i : a][j];
                                else
                                    dr[dt1.Columns.Count + j] = dt.Rows[dtflag == 0 ? i : a][j];
                            }
                            tempDT.Rows.Add(dr);
                        }
                        dt = tempDT;
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                DateTime sDate = new DateTime();
                DateTime eDate = new DateTime();
                TimeSpan ts = TimeSpan.Zero;

                DataColumn datetimeColumn1 = new DataColumn();
                //该列的数据类型
                datetimeColumn1.DataType = System.Type.GetType("System.String");
                //该列得名称
                datetimeColumn1.ColumnName = "week";
                //该列得默认值
                datetimeColumn1.DefaultValue = "";
                dt.Columns.Add(datetimeColumn1);

                if (isConstruction == "3")
                {
                    dt.Columns[datetimeColumn1.ColumnName].SetOrdinal(19);
                }
                else if (isConstruction == "4")
                {
                    dt.Columns[datetimeColumn1.ColumnName].SetOrdinal(17);
                }
                else
                {
                    dt.Columns[datetimeColumn1.ColumnName].SetOrdinal(5);
                }
                

                if (dt.Rows[0]["stage_sDate"].ToString().Trim() != "" && dt.Rows[0]["stage_eDate"].ToString().Trim() != "" && dt.Rows[0]["stage_sDate"] != null && dt.Rows[0]["stage_eDate"] != null && DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString()).ToString("yyyy-MM-dd") != "1900-01-01" && DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString()).ToString("yyyy-MM-dd") != "1900-01-01")
                {
                    sDate = DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString().Trim());
                    eDate = DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString().Trim());
                    ts = eDate.AddDays(1).Subtract(sDate);

                    //插入周期列
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
                        if (isConstruction == "3")
                        {
                            dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 20);
                        }
                        else if (isConstruction == "4")
                        {
                            dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 18);
                        }
                        else
                        {
                            dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 6);
                        }
                    }

                    //周期列赋值
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["begin_date"].ToString() != "" & dt.Rows[i]["end_date"].ToString() != "" && DateTime.Parse(dt.Rows[i]["begin_date"].ToString()).ToString("yyyy-MM-dd") != "1900-01-01" && DateTime.Parse(dt.Rows[i]["end_date"].ToString()).ToString("yyyy-MM-dd") != "1900-01-01")
                        {
                            DateTime mysDate = DateTime.Parse(dt.Rows[i]["begin_date"].ToString().Trim());
                            DateTime myeDate = DateTime.Parse(dt.Rows[i]["end_date"].ToString().Trim());
                            TimeSpan myts = myeDate.AddDays(1).Subtract(mysDate);
                            for (int j = 0; j < myts.Days; j++)
                            {
                                //if (dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")].ToString().Trim() == "0")
                                //{
                                //    dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "1";
                                //}

                                object obj_showflow = DbHelperSQL.GetSingle("select top 1 wf_text from project_item_flow_1 where psi_sid='" + dt.Rows[i]["sid"].ToString().Trim() + "' and convert(varchar(10),pif_time,120)='" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "'");
                                //string showFlow = obj_showflow == null ? "✓" : obj_showflow.ToString().Trim();
                                dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")] = obj_showflow == null ? "1" : obj_showflow.ToString().Trim();

                            }
                            //TimeSpan myts = myeDate.AddDays(1).Subtract(mysDate);
                            //for (int j = 0; j < myts.Days; j++)
                            //{
                            //    if (dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")].ToString().Trim() == "0")
                            //    {
                            //        dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd")] = "1";
                            //    }
                            //}
                        }

                        string[] submitDate = dt.Rows[i]["submitDate"].ToString().Trim().Split(',');
                        for (int j = 0; j < submitDate.Length; j++)
                        {
                            try
                            {
                                for (int n = 0; n < ts.Days; n++)
                                {
                                    if (sDate.AddDays(n).Date == DateTime.Parse(submitDate[j].Trim()).Date)
                                    {
                                        dt.Rows[i][sDate.AddDays(n).ToString("yyyy-MM-dd")] = "2";
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                else
                {
                    DataColumn datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "day";
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);
                    if (isConstruction == "3")
                    {
                        dt.Columns[datetimeColumn.ColumnName].SetOrdinal(20);
                    }
                    else if (isConstruction == "4")
                    {
                        dt.Columns[datetimeColumn.ColumnName].SetOrdinal(18);
                    }
                    else
                    {
                        dt.Columns[datetimeColumn.ColumnName].SetOrdinal(6);
                    }
                }

                //插入实施列并赋值
                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + pssid + "'  order by sequence asc");
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
                    if (isConstruction == "3")
                    {
                        dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 20 + (ts.Days == 0 ? 1 : ts.Days));
                    }
                    else if (isConstruction == "4")
                    {
                        dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 17 + (ts.Days == 0 ? 1 : ts.Days));
                    }
                    else
                    {
                        dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 6 + (ts.Days == 0 ? 1 : ts.Days));
                    }

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable impworkDT = new DataTable();
                        impDS = new BLL.Common().GetList("select * ,dbo.getUserName_fu(implementer_sid) as abbr from project_work_implement where psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                dt.Rows[j]["imp" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["abbr"].ToString().Trim();
                            }
                        }
                    }
                }
            }

            string reStr = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                reStr += "<tr>";
                //bool group = false, content = false;
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    if (j == 1)
                    {
                        if (dt.Columns[j].ColumnName == "stage_name" && i == 0)
                        {
                            reStr += "<td style='display:" + showStage + ";text-align:center;' rowspan='" + dt.Rows.Count + "' >" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (isConstruction == "3")
                    {
                        if (dt.Columns[j].ColumnName == "productID")
                        {
                            if (i == 0)
                            {
                                DataRow[] dr = dt.Select("productID='" + dt.Rows[i][j].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["number"].ToString().Trim() + "</td>";
                                reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["productName"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align: center;' rowspan='" + tmpCount + "'><img alt='' style='max-width:80px;max-height:80px;' src='/ProductPic/" + dt.Rows[i]["productPic"].ToString().Trim() + "' /></td>";
                                reStr += "<td style='text-align: center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["productSize"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["productColor"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["useSpace"].ToString().Trim() + "</td>";

                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["spaceCount"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["install"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["usePart"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["unit"].ToString().Trim() + "</td>";

                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["amount"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["paintPaletteNumber"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["ppiRemark"].ToString().Trim() + "</td>";
                                continue;
                            }
                            else if (dt.Rows[i][j].ToString().Trim() != dt.Rows[i - 1][j].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("productID='" + dt.Rows[i][j].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["number"].ToString().Trim() + "</td>";
                                reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["productName"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align: center;' rowspan='" + tmpCount + "'><img alt='' style='max-width:80px;max-height:80px;' src='/ProductPic/" + dt.Rows[i]["productPic"].ToString().Trim() + "' /></td>";
                                reStr += "<td style='text-align: center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["productSize"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["productColor"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["useSpace"].ToString().Trim() + "</td>";

                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["spaceCount"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["install"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["usePart"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["unit"].ToString().Trim() + "</td>";

                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["amount"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["paintPaletteNumber"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["ppiRemark"].ToString().Trim() + "</td>";
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (dt.Columns[j].ColumnName == "number" || dt.Columns[j].ColumnName == "productName" || dt.Columns[j].ColumnName == "productPic" || dt.Columns[j].ColumnName == "productSize" || dt.Columns[j].ColumnName == "productColor" || dt.Columns[j].ColumnName == "useSpace" || dt.Columns[j].ColumnName == "spaceCount" || dt.Columns[j].ColumnName == "install" || dt.Columns[j].ColumnName == "usePart" || dt.Columns[j].ColumnName == "unit" || dt.Columns[j].ColumnName == "amount" || dt.Columns[j].ColumnName == "paintPaletteNumber" || dt.Columns[j].ColumnName == "ppiRemark")
                        {
                            continue;
                        }
                    }
                    else 
                    if (isConstruction == "4")
                    {
                        if (dt.Columns[j].ColumnName == "productID")
                        {
                            if (i == 0)
                            {
                                DataRow[] dr = dt.Select("productID='" + dt.Rows[i][j].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["number"].ToString().Trim() + "</td>";
                                reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["productName"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align: center;' rowspan='" + tmpCount + "'><img alt='' style='max-width:80px;max-height:80px;' src='/ProductPic/" + dt.Rows[i]["productPic"].ToString().Trim() + "' /></td>";
                                reStr += "<td style='text-align: center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["productSize"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["productColor"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["useSpace"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["usePart"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["unit"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["amount"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["EndProduct"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["ppiRemark"].ToString().Trim() + "</td>";
                                continue;
                            }
                            else if (dt.Rows[i][j].ToString().Trim() != dt.Rows[i - 1][j].ToString().Trim())
                            {
                                DataRow[] dr = dt.Select("productID='" + dt.Rows[i][j].ToString().Trim() + "'");
                                int tmpCount = dr.Length;
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["number"].ToString().Trim() + "</td>";
                                reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i]["productName"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align: center;' rowspan='" + tmpCount + "'><img alt='' style='max-width:80px;max-height:80px;'  src='/ProductPic/" + dt.Rows[i]["productPic"].ToString().Trim() + "' /></td>";
                                reStr += "<td style='text-align: center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["productSize"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["productColor"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["useSpace"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["usePart"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["unit"].ToString().Trim() + "</td>";

                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["amount"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["EndProduct"].ToString().Trim() + "</td>";
                                reStr += "<td style='text-align:center;' rowspan='" + tmpCount + "'>" + dt.Rows[i]["ppiRemark"].ToString().Trim() + "</td>";
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (dt.Columns[j].ColumnName == "number" || dt.Columns[j].ColumnName == "productName" || dt.Columns[j].ColumnName == "productPic" || dt.Columns[j].ColumnName == "productSize" || dt.Columns[j].ColumnName == "productColor" || dt.Columns[j].ColumnName == "useSpace" || dt.Columns[j].ColumnName == "spaceCount" || dt.Columns[j].ColumnName == "install" || dt.Columns[j].ColumnName == "usePart" || dt.Columns[j].ColumnName == "unit" || dt.Columns[j].ColumnName == "amount" || dt.Columns[j].ColumnName == "EndProduct" || dt.Columns[j].ColumnName == "ppiRemark")
                        {
                            continue;
                        }
                    }

                    if (dt.Columns[j].ColumnName == "group_name")
                    {
                        if (i == 0)
                        {
                            DataRow[] dr = dt.Select("group_name='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td style='display:" + showGroup + ";' rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else if (dt.Rows[i][j].ToString().Trim() != dt.Rows[i - 1][j].ToString().Trim())
                        {
                            DataRow[] dr = dt.Select("group_name='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td style='display:" + showGroup + ";' rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (dt.Columns[j].ColumnName == "contentName")
                    {
                        if (i == 0)
                        {
                            DataRow[] dr = dt.Select("contentName='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td style='display:" + showContent + ";' rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else if (dt.Rows[i][j].ToString().Trim() != dt.Rows[i - 1][j].ToString().Trim())
                        {
                            DataRow[] dr = dt.Select("contentName='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td style='display:" + showContent + ";' rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (dt.Columns[j].ColumnName == "begin_date")
                    {
                        break;
                        //continue;
                    }
                    if (dt.Columns[j].ColumnName == "week")
                    {
                        reStr += "<td style='background-color:lightgray;'></td>";
                        //reStr += "<td style='background-color:#C0C0C0;'><img border='0' width='100%' height='100%' src='../Images/gray.bmp'/></td></td>";
                        continue;
                    }
                    //if (IsDate(dt.Columns[j].ColumnName))
                    if (dt.Columns[j].ColumnName.Contains('-'))
                    {
                        switch (dt.Rows[i][j].ToString().Trim())
                        {
                            case "0":
                                reStr += "<td></td>";
                                break;
                            case "1":
                                //reStr += "<td style='background-color:yellow;'><img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/></td>";
                                reStr += "<td style='background-color:yellow;'></td>";
                                //reStr += "<td style='background-color:yellow;'><img border='0'  width='100%' height='100%' src='../Images/yellow.bmp'/></td>";
                                break;
                            case "2":
                                //reStr += "<td style='background-color:green;'><img  width='16px' height='16px' src='../Images/point/bullet_green.png'/></td>";
                                reStr += "<td style='background-color:green;'></td>";
                                //reStr += "<td style='background-color:green;'><img border='0'  width='100%' height='100%' src='../Images/green.bmp'/></td>";
                                break;
                            default:
                                reStr += "<td></td>";
                                break;
                        }

                    }
                    else if (dt.Columns[j].ColumnName.ToString().Trim() == "header")
                    {
                        reStr += "<td style=\"text-align:center\">" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                    else if (dt.Columns[j].ColumnName.ToString().Trim() == "finaler")
                    {
                        reStr += "<td style=\"text-align:center\">" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                    else if (dt.Columns[j].ColumnName.ToString().Trim() == "review_results")
                    {
                        switch (dt.Rows[i][j].ToString().Trim())
                        {
                            case "0":
                                reStr += "<td style=\"color:Red;text-align:center\">未完成</td>";
                                break;
                            case "1":
                                reStr += "<td style=\"color:Green;text-align:center\">完成</td>";
                                break;
                            default:
                                reStr += "<td></td>";
                                break;
                        }

                    }

                    else if (dt.Columns[j].ColumnName.Trim() == "reviews")
                    {
                        string[] arr = dt.Rows[i][j].ToString().Trim().Split(',');
                        string pointStr = "";
                        for (int n = 0; n < arr.Length; n++)
                        {
                            switch (arr[n].Trim())
                            {
                                case "0":
                                    pointStr += "";
                                    break;
                                case "1":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_green.png'/>&nbsp;";
                                    break;
                                case "2":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/>&nbsp;";
                                    break;
                                case "3":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_orange.png'/>&nbsp;";
                                    break;
                                case "4":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_red.png'/>&nbsp;";
                                    break;
                                case "5":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_error.png'/>&nbsp;";
                                    break;
                                default:
                                    break;
                            }
                        }
                        reStr += "<td>" + pointStr + "</td>";
                    }
                    else if (dt.Columns[j].ColumnName.Contains("imp"))
                    {
                        reStr += "<td style=\"text-align:center\">" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                    else if (dt.Columns[j].ColumnName.Contains("itemName"))
                    {
                        reStr += "<td>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                    else
                    {
                        reStr += "<td style=\"text-align:center\">" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                }
                reStr += "</tr>";
            }
            return reStr;
        }





        private string ContentViewItem(string pssid)
        {
            DataTable dt = new DataTable();
            DataSet ds=new DataSet();
            if (isConstruction != "3")
            {
                ds = new BLL.Common().GetList("  select a.sid, c.stage_name,d.group_name,b.name as contentName,a.name as itemName,dbo.getUserNames_fu(a.v1) as header,dbo.getProReview_result_zxf(a.sid) as review_results,a.unfinished_reason,a.solution,dbo.getUserNames_fu(a.v2) as finaler,dbo.getProjectReview_zxf(a.sid) as reviews,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectSubmitDate_fu(a.sid) as submitDate from project_specific_item a right outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where  b.s_sid=" + pssid + " and b.ischild=0 order by b.group_sid asc, b.sequence asc, a.sequence asc  ");
            }
            else
            {
                ds = new BLL.Common().GetList("select row_number()over (order by psi.sequence) as rowid, psi.sid sid,ppi.sid as ppiSid,ppi.parentID,psi.parent_sid,pp.sid ppSid,ppi.ProductID,psi.PP_sid,ppi.number,ppi.name,ppi.paintColor,ppi.useSpace,ppi.spaceCount,ppi.install,ppi.usePart,ppi.unit,ppi.amount,ppi.paintPaletteNumber,ppi.EndProduct,ppi.sequence,ppi.remark,pp.*,psi2.name contentName,psi.name as itemName,ps.stage_name,psi.begin_date,psi.end_date,ps.begin_date as stage_sDate,ps.end_date as stage_eDate ,d.Image AS productPic, d.Name AS productName,d.Specifications,psi.sid as csid,dbo.getProjectSubmitDate_fu(psi.sid) as submitDate,(case when psi.v2 is null or psi.v2='' then e.v2 else psi.v2 end)v2,(case when psi.v1 is null or psi.v1='' then pg.v1 else psi.v1 end)v1,psi.sequence as itemSequence,psi.sequence as contentSequence,psi.remark as cremark,psi.group_sid,psi.parent_sid,psi.sid as csid,(case when psi.v1='' or psi.v1 is null then dbo.getUserNames_fu(pg.v1) else dbo.getUserNames_fu(psi.v1) end) as header,(case when psi.v2='' or psi.v2 is null then dbo.getUserNames_fu(e.v2) else dbo.getUserNames_fu(psi.v2) end ) as finaler,pg.v1 groupHeader "
+ "	from project_product pp"
+ "	left join project_product_item ppi on ppi.sid = pp.ppiID"
+ "	right join project_specific_item psi on psi.PP_sid=pp.sid"
+ "	right join project_specific_item psi2 on psi2.sid=psi.parent_sid"
+ "	left outer join project_stage ps on psi.s_sid=ps.sid "
+ "	 INNER JOIN  dbo.v_ProductColorShip AS d ON ppi.ProductID = d.ID"
+ "	left outer join project_stage c on psi.s_sid=c.sid "
+ "	left outer join project_group pg on psi.group_sid=pg.sid"
+ "	inner join project e on c.p_sid=e.sid "
+ "	where  pp.ps_sid=" + pssid + "");
            }
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                DateTime sDate = new DateTime();
                DateTime eDate = new DateTime();
                TimeSpan ts = TimeSpan.Zero;
                if (dt.Rows[0]["stage_sDate"].ToString().Trim() != "" && dt.Rows[0]["stage_eDate"].ToString().Trim() != "" && dt.Rows[0]["stage_sDate"] != null && dt.Rows[0]["stage_eDate"] != null && DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString()).ToString("yyyy-MM-dd") != "1900-01-01" && DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString()).ToString("yyyy-MM-dd") != "1900-01-01")
                {
                    sDate = DateTime.Parse(dt.Rows[0]["stage_sDate"].ToString().Trim());
                    eDate = DateTime.Parse(dt.Rows[0]["stage_eDate"].ToString().Trim());
                    ts = eDate.AddDays(1).Subtract(sDate);

                    DataColumn datetimeColumn1 = new DataColumn();
                    //该列的数据类型
                    datetimeColumn1.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn1.ColumnName = "week";
                    //该列得默认值
                    datetimeColumn1.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn1);

                    dt.Columns[datetimeColumn1.ColumnName].SetOrdinal(5);

                    //插入周期列
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

                        dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 6);
                    }

                    //周期列赋值
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["begin_date"].ToString() != "" & dt.Rows[i]["end_date"].ToString() != "" && DateTime.Parse(dt.Rows[i]["begin_date"].ToString()).ToString("yyyy-MM-dd") != "1900-01-01" && DateTime.Parse(dt.Rows[i]["end_date"].ToString()).ToString("yyyy-MM-dd") != "1900-01-01")
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
                            }
                        }

                        string[] submitDate = dt.Rows[i]["submitDate"].ToString().Trim().Split(',');
                        for (int j = 0; j < submitDate.Length; j++)
                        {
                            try
                            {
                                for (int n = 0; n < ts.Days; n++)
                                {
                                    if (sDate.AddDays(n).Date == DateTime.Parse(submitDate[j].Trim()).Date)
                                    {
                                        dt.Rows[i][sDate.AddDays(n).ToString("yyyy-MM-dd")] = "2";
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                else
                {
                    DataColumn datetimeColumn1 = new DataColumn();
                    //该列的数据类型
                    datetimeColumn1.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn1.ColumnName = "week";
                    //该列得默认值
                    datetimeColumn1.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn1);

                    dt.Columns[datetimeColumn1.ColumnName].SetOrdinal(5);

                    DataColumn datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "day";
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";



                    dt.Columns.Add(datetimeColumn);

                    dt.Columns[datetimeColumn.ColumnName].SetOrdinal(6);
                }

                //插入实施列并赋值
                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + pssid + "'");
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
                    dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 6 + (ts.Days == 0 ? 1 : ts.Days));

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable impworkDT = new DataTable();
                        impDS = new BLL.Common().GetList("select * ,dbo.getUserName_fu(implementer_sid) as abbr from project_work_implement where psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                dt.Rows[j]["imp" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["abbr"].ToString().Trim();
                            }
                        }
                    }
                }
            }

            string reStr = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                reStr += "<tr>";
                //bool group = false, content = false;
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    if (j == 1)
                    {
                        if (dt.Columns[j].ColumnName == "stage_name" && i == 0)
                        {
                            reStr += "<td rowspan='" + dt.Rows.Count + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (dt.Columns[j].ColumnName == "group_name")
                    {
                        if (i == 0)
                        {
                            DataRow[] dr = dt.Select("group_name='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else if (dt.Rows[i][j].ToString().Trim() != dt.Rows[i - 1][j].ToString().Trim())
                        {
                            DataRow[] dr = dt.Select("group_name='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (dt.Columns[j].ColumnName == "contentName")
                    {
                        if (i == 0)
                        {
                            DataRow[] dr = dt.Select("contentName='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else if (dt.Rows[i][j].ToString().Trim() != dt.Rows[i - 1][j].ToString().Trim())
                        {
                            DataRow[] dr = dt.Select("contentName='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (dt.Columns[j].ColumnName == "begin_date")
                    {
                        break;
                    }
                    if (dt.Columns[j].ColumnName == "week")
                    {
                        reStr += "<td style='background-color:lightgray;'></td>";
                        continue;
                    }
                    //if (IsDate(dt.Columns[j].ColumnName))
                    if (dt.Columns[j].ColumnName.Contains('-'))
                    {
                        switch (dt.Rows[i][j].ToString().Trim())
                        {
                            case "0":
                                reStr += "<td></td>";
                                break;
                            case "1":
                                //reStr += "<td style='background-color:yellow;'><img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/></td>";
                                reStr += "<td style='background-color:yellow;'></td>";
                                break;
                            case "2":
                                //reStr += "<td style='background-color:green;'><img  width='16px' height='16px' src='../Images/point/bullet_green.png'/></td>";
                                reStr += "<td style='background-color:green;'></td>";
                                break;
                            default:
                                reStr += "<td></td>";
                                break;
                        }

                    }
                    //else if (dt.Columns[j].ColumnName.Trim() == "reviews")
                    //{
                    //    string[] arr = dt.Rows[i][j].ToString().Trim().Split(',');
                    //    string pointStr = "";
                    //    for (int n = 0; n < arr.Length; n++)
                    //    {
                    //        switch (arr[n].Trim())
                    //        {
                    //            case "0":
                    //                pointStr += "";
                    //                break;
                    //            case "1":
                    //                pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_green.png'/>&nbsp;";
                    //                break;
                    //            case "2":
                    //                pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/>&nbsp;";
                    //                break;
                    //            case "3":
                    //                pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_orange.png'/>&nbsp;";
                    //                break;
                    //            case "4":
                    //                pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_red.png'/>&nbsp;";
                    //                break;
                    //            default:
                    //                break;
                    //        }
                    //    }
                    //    reStr += "<td>"+pointStr+"</td>";
                    //}
                    else if (dt.Columns[j].ColumnName.ToString().Trim()=="header")
                    {
                         reStr += "<td>"+dt.Rows[i][j].ToString().Trim()+"</td>";
                    }
                    else if (dt.Columns[j].ColumnName.ToString().Trim() == "finaler")
                    {
                        reStr += "<td>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                    else if (dt.Columns[j].ColumnName.ToString().Trim() == "review_results")
                    {
                        switch (dt.Rows[i][j].ToString().Trim())
                        {
                            case "0":
                                reStr += "<td style=\"color:Red;text-align:center\">未完成</td>";
                                break;
                            case "1":
                                reStr += "<td style=\"color:Green;text-align:center\">完成</td>";
                                break;
                            default:
                                reStr += "<td></td>";
                                break;
                        }

                    }

                    else if (dt.Columns[j].ColumnName.Trim() == "reviews")
                    {
                        string[] arr = dt.Rows[i][j].ToString().Trim().Split(',');
                        string pointStr = "";
                        for (int n = 0; n < arr.Length; n++)
                        {
                            switch (arr[n].Trim())
                            {
                                case "0":
                                    pointStr += "";
                                    break;
                                case "1":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_green.png'/>&nbsp;";
                                    break;
                                case "2":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/>&nbsp;";
                                    break;
                                case "3":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_orange.png'/>&nbsp;";
                                    break;
                                case "4":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_red.png'/>&nbsp;";
                                    break;
                                case"5":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_error.png'/>&nbsp;";
                                    break;
                                default:
                                    break;
                            }
                        }
                        reStr += "<td>" + pointStr + "</td>";
                    }
                    else if (dt.Columns[j].ColumnName.Contains("imp"))
                    {
                        reStr+="<td style=\"text-align:center\">" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                    else
                    {
                        reStr += "<td>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                }
                reStr += "</tr>";
            }
            return reStr;
        }
        private string ContentViewItem1(string pssid)
        {
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList(" select a.sid, c.stage_name,b.name as contentName,a.name as itemName,dbo.getUserNames_fu(a.v1) as header,dbo.getProReview_result_zxf(a.sid) as review_results,a.unfinished_reason,a.solution,dbo.getUserNames_fu(a.v2) as finaler,dbo.getProjectReview_zxf(a.sid) as reviews,a.remark,a.begin_date,a.end_date,c.begin_date as stage_sDate,c.end_date as stage_eDate,dbo.getProjectSubmitDate_fu(a.sid) as submitDate from project_specific_item a right outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project_group d on b.group_sid=d.sid where  b.s_sid=" + pssid + " and b.ischild=0 order by b.group_sid asc, b.sequence asc, a.sequence asc ");
            DataTable dt_item_flow = new BLL.Common().GetList("select * from project_item_flow as a left join project_specific_item as b on a.psi_sid = b.sid left join project_work_flow as c on a.fw_sid=c.sid where b.s_sid="+pssid+" order by b.s_sid asc").Tables[0];
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

                    DataColumn datetimeColumn1 = new DataColumn();
                    //该列的数据类型
                    datetimeColumn1.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn1.ColumnName = "week";
                    //该列得默认值
                    datetimeColumn1.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn1);

                    dt.Columns[datetimeColumn1.ColumnName].SetOrdinal(4);

                    //插入周期列
                    for (int i = 0; i < ts.Days; i++)
                    {
                        DataColumn datetimeColumn = new DataColumn();
                        //该列的数据类型
                        datetimeColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        datetimeColumn.ColumnName = sDate.AddDays(i).ToString("yyyy-MM-dd");
                        //该列得默认值
                        datetimeColumn.DefaultValue = "0";

                        DataColumn fwColumn = new DataColumn();
                        //该列的数据类型
                       fwColumn.DataType = System.Type.GetType("System.String");
                        //该列得名称
                        fwColumn.ColumnName = sDate.AddDays(i).ToString("yyyy-MM-dd").Replace("-","")+"_fw";
                        //该列得默认值
                        fwColumn.DefaultValue = "";



                        dt.Columns.Add(datetimeColumn);

                        dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 5);
                        dt.Columns.Add(fwColumn);

                        dt.Columns[fwColumn.ColumnName].SetOrdinal(dt.Columns.Count-1);
                    }

                    //周期列赋值
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //DataRow[] s_flow_item = dt_item_flow.Select("psi_sid=" + dt.Rows[i]["sid"].ToString());
                        if (dt.Rows[i]["begin_date"].ToString() != "" & dt.Rows[i]["end_date"].ToString() != "")
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
                                    }

                                    object obj_showflow = DbHelperSQL.GetSingle("select top 1 wf_text from project_item_flow_1 where psi_sid='" + dt.Rows[i]["sid"].ToString().Trim() + "' and convert(varchar(10),pif_time,120)='" + mysDate.AddDays(j).ToString("yyyy-MM-dd") + "'");
                                    //string showFlow = obj_showflow == null ? "✓" : obj_showflow.ToString().Trim();
                                    dt.Rows[i][mysDate.AddDays(j).ToString("yyyy-MM-dd").Replace("-", "") + "_fw"] = obj_showflow;

                                }
                            }
                            
                        }

                        string[] submitDate = dt.Rows[i]["submitDate"].ToString().Trim().Split(',');
                        for (int j = 0; j < submitDate.Length; j++)
                        {
                            try
                            {
                                for (int n = 0; n < ts.Days; n++)
                                {
                                    if (sDate.AddDays(n).Date == DateTime.Parse(submitDate[j].Trim()).Date)
                                    {
                                        dt.Rows[i][sDate.AddDays(n).ToString("yyyy-MM-dd")]= "2";
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                else
                {
                    DataColumn datetimeColumn1 = new DataColumn();
                    //该列的数据类型
                    datetimeColumn1.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn1.ColumnName = "week";
                    //该列得默认值
                    datetimeColumn1.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn1);

                    dt.Columns[datetimeColumn1.ColumnName].SetOrdinal(4);

                    DataColumn datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = "day";
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";



                    dt.Columns.Add(datetimeColumn);

                    dt.Columns[datetimeColumn.ColumnName].SetOrdinal(5);
                }

                //插入实施列并赋值
                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + pssid + "'");
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
                    dt.Columns[datetimeColumn.ColumnName].SetOrdinal(i + 5 + (ts.Days == 0 ? 1 : ts.Days));

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable impworkDT = new DataTable();
                        impDS = new BLL.Common().GetList("select * ,dbo.getUserNmae_fu(implementer_sid) as abbr from project_work_implement where psi_sid='" + dt.Rows[j]["sid"] + "' and imp_sid='" + impDT.Rows[i]["sid"] + "'");
                        if (impDS.Tables.Count > 0)
                        {
                            impworkDT = impDS.Tables[0];
                            if (impworkDT.Rows.Count > 0)
                            {
                                dt.Rows[j]["imp" + impDT.Rows[i]["sid"].ToString().Trim()] = impworkDT.Rows[0]["abbr"].ToString().Trim();
                            }
                        }
                    }
                }
            }

            string reStr = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                reStr += "<tr>";
                //bool group = false, content = false;
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    if (j == 1)
                    {
                        if (dt.Columns[j].ColumnName == "stage_name" && i == 0)
                        {
                            reStr += "<td rowspan='" + dt.Rows.Count + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    

                    if (dt.Columns[j].ColumnName == "contentName")
                    {
                        if (i == 0)
                        {
                            DataRow[] dr = dt.Select("contentName='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else if (dt.Rows[i][j].ToString().Trim() != dt.Rows[i - 1][j].ToString().Trim())
                        {
                            DataRow[] dr = dt.Select("contentName='" + dt.Rows[i][j].ToString().Trim() + "'");
                            int tmpCount = dr.Length;
                            reStr += "<td rowspan='" + tmpCount + "'>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (dt.Columns[j].ColumnName == "begin_date")
                    {
                        break;
                    }
                    if (dt.Columns[j].ColumnName == "week")
                    {
                        reStr += "<td style='background-color:lightgray;'></td>";
                        continue;
                    }
                    //if (IsDate(dt.Columns[j].ColumnName))
                    if (dt.Columns[j].ColumnName.Contains('-'))
                    {
                        
                        switch (dt.Rows[i][j].ToString().Trim())
                        {
                            case "0":
                                reStr += "<td></td>";
                                break;
                            case "1":
                                //reStr += "<td style='background-color:yellow;'><img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/></td>";


                                reStr += "<td style='background-color:yellow;'><span >" + dt.Rows[i][dt.Columns[j].ColumnName.ToString().Replace("-", "") + "_fw"].ToString().Trim() + "</span></td>";
                                break;
                            case "2":
                                //reStr += "<td style='background-color:green;'><img  width='16px' height='16px' src='../Images/point/bullet_green.png'/></td>";
                                reStr += "<td style='background-color:green;'><span >" + dt.Rows[i][dt.Columns[j].ColumnName.ToString().Replace("-", "") + "_fw"].ToString().Trim() + "</span></td>";
                                break;
                            default:
                                reStr += "<td></td>";
                                break;
                        }

                    }
                    else if (dt.Columns[j].ColumnName.Contains("_fw"))
                    {
                        break;
                    }
                    //else if (dt.Columns[j].ColumnName.Trim() == "reviews")
                    //{
                    //    string[] arr = dt.Rows[i][j].ToString().Trim().Split(',');
                    //    string pointStr = "";
                    //    for (int n = 0; n < arr.Length; n++)
                    //    {
                    //        switch (arr[n].Trim())
                    //        {
                    //            case "0":
                    //                pointStr += "";
                    //                break;
                    //            case "1":
                    //                pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_green.png'/>&nbsp;";
                    //                break;
                    //            case "2":
                    //                pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/>&nbsp;";
                    //                break;
                    //            case "3":
                    //                pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_orange.png'/>&nbsp;";
                    //                break;
                    //            case "4":
                    //                pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_red.png'/>&nbsp;";
                    //                break;
                    //            default:
                    //                break;
                    //        }
                    //    }
                    //    reStr += "<td>"+pointStr+"</td>";
                    //}
                    else if (dt.Columns[j].ColumnName.ToString().Trim() == "header")
                    {
                        reStr += "<td>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                    else if (dt.Columns[j].ColumnName.ToString().Trim() == "finaler")
                    {
                        reStr += "<td>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                    else if (dt.Columns[j].ColumnName.ToString().Trim() == "review_results")
                    {
                        switch (dt.Rows[i][j].ToString().Trim())
                        {
                            case "0":
                                reStr += "<td style=\"color:Red;text-align:center\">未完成</td>";
                                break;
                            case "1":
                                reStr += "<td style=\"color:Green;text-align:center\">完成</td>";
                                break;
                            default:
                                reStr += "<td></td>";
                                break;
                        }

                    }
                    else if (dt.Columns[j].ColumnName.Trim() == "reviews")
                    {
                        string[] arr = dt.Rows[i][j].ToString().Trim().Split(',');
                        string pointStr = "";
                        for (int n = 0; n < arr.Length; n++)
                        {
                            switch (arr[n].Trim())
                            {
                                case "0":
                                    pointStr += "";
                                    break;
                                case "1":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_green.png'/>&nbsp;";
                                    break;
                                case "2":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_yellow.png'/>&nbsp;";
                                    break;
                                case "3":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_orange.png'/>&nbsp;";
                                    break;
                                case "4":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_red.png'/>&nbsp;";
                                    break;
                                case "5":
                                    pointStr += "<img  width='16px' height='16px' src='../Images/point/bullet_error.png'/>&nbsp;";
                                    break;
                                default:
                                    break;
                            }
                        }
                        reStr += "<td>" + pointStr + "</td>";
                    }
                    else if (dt.Columns[j].ColumnName.Contains("imp"))
                    {
                        reStr += "<td style=\"text-align:center\">" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                    else
                    {
                        reStr += "<td>" + dt.Rows[i][j].ToString().Trim() + "</td>";
                    }
                }
                reStr += "</tr>";
            }
            return reStr;
        }


        //多个跟踪
        private string GetProductTable(string pssid)
        {
            string showData = GetProductContent(pssid);
            string productDT = "";
            productDT += "<table id='tbl'  height='100%' width='100%' class='printinnertable1' cellpadding='0' cellspacing='0' style='table-layout:fixed;border-top:0px solid #000000; ' >";
            productDT += "<thead >";
            productDT += "<tr>";
            productDT += "<th rowspan='2' style='width:60px;border-left:0px solid #000000;' >图纸编号 </th>";
            productDT += "<th rowspan='1' colspan='4' style='width:160px'>细目</th>";
            productDT += "<th rowspan='2' style='width:60px'>应用空间</th>";
            productDT += "<th rowspan='2' style='width:60px'>应用部位 </th>";
            productDT += "<th rowspan='2' style='width:30px'>单位</th>";
            productDT += "<th rowspan='2' style='width:30px'>数量</th>";
            productDT += "<th rowspan='2' style='width:50px'>成品</th>";
            productDT += "<th rowspan='2' style='width:50px;border-right:0px solid #000000;'>备注</th>";
            productDT += "</tr>";
            productDT += "<tr>";
            productDT += "<th colspan='1' style='width:60px'>名称</th>";
            productDT += "<th colspan='1' style='width:60px'>图片 </th>";
            productDT += "<th colspan='1' style='width:55px'>图纸规格 </th>";
            productDT += "<th colspan='1' style='width:55px'>漆面颜色</th>";
            productDT += "</tr>";
            productDT += "</thead>";
            productDT += showData;
            productDT += "</table>";
            return productDT;
        }

        //逐个跟踪
        private string GetProductTableBySingle(string pssid)
        {
            string showData = GetProductContentBySingle(pssid);
            string productDT = "";
            productDT += "<table height='100%' width='100%' class='printinnertable1' cellpadding='0' cellspacing='0'  style='table-layout:fixed;border-top:0px solid #000000;' >>";
            productDT += "<thead>";
            productDT += "<tr>";
            productDT += "<th rowspan='2'  border-left:0px solid #ffffff;>图纸编号 </th>";
            productDT += "<th rowspan='1' colspan='4'>细目</th>";
            productDT += "<th rowspan='2' >漆面颜色 </th>";
            productDT += "<th rowspan='2' >应用空间 </th>";
            productDT += "<th rowspan='2' >应用数量</th>";
            productDT += "<th rowspan='2' >安装位置</th>";
            productDT += "<th rowspan='2' >应用部位</th>";
            productDT += "<th rowspan='2'>单位 </th>";
            productDT += "<th rowspan='2'>数量</th>";
            productDT += "<th rowspan='2' style=''>油漆色板编号 </th>";
            productDT += "<th rowspan='2' style=''>加工类别  </th>";
            productDT += "<th rowspan='2' style='border-right:0px solid #ffffff;'>备注</th>";
            productDT += "</tr>";
            productDT += "<tr>";
            productDT += "<th colspan='1'>项目产品名称 </th>";
            productDT += "<th colspan='1'>图片 </th>";
            productDT += "<th colspan='1'>图纸规格 </th>";
            productDT += "</tr>";
            productDT += "</thead>";
            productDT += showData;
            productDT += "</table>";
            return productDT;
        }

        private string GetProductContent(string pssid)
        {
            string reStr = "";
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select * from v_Project_Product where ps_sid='" + pssid + "'");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                 
                        reStr += "<tr>";
                        reStr += "<td style='text-align:center;'>" + dt.Rows[i]["number"].ToString().Trim() + "</td>";
                        reStr += "<td>" + dt.Rows[i]["productName"].ToString().Trim() + "</td>";
                        reStr += "<td style='text-align: center;'><img alt='' height='45px' src='/ProductPic/" + dt.Rows[i]["productPic"].ToString().Trim() + "' /></td>";
                        reStr += "<td style='text-align: center;'>" + dt.Rows[i]["productSize"].ToString().Trim() + "</td>";
                        reStr += "<td style='text-align:center;'>" + dt.Rows[i]["paintColor"].ToString().Trim() + "</td>";
                        reStr += "<td style='text-align:center;'>" + dt.Rows[i]["useSpace"].ToString().Trim() + "</td>";
                        reStr += "<td style='text-align:center;'>" + dt.Rows[i]["usePart"].ToString().Trim() + "</td>";
                        reStr += "<td style='text-align:center;'>" + dt.Rows[i]["unit"].ToString().Trim() + "</td>";
                        reStr += "<td style='text-align:center;'>" + dt.Rows[i]["amount"].ToString().Trim() + "</td>";
                        reStr += "<td style='text-align:center;'>" + dt.Rows[i]["EndProduct"].ToString().Trim() + "</td>";
                        reStr += "<td>" + dt.Rows[i]["remark"].ToString().Trim() + "</td>";
                        reStr += "</tr>";
                    
                }
            }
            return reStr;
        }

        private string GetProductContentBySingle(string pssid)
        {
            string reStr = "";
            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select row_number()over (order by psi.sequence) as rowid, psi.sid sid,ppi.sid as ppiSid,ppi.parentID,psi.parent_sid,pp.sid ppSid,ppi.ProductID,psi.PP_sid,ppi.number,ppi.name,ppi.paintColor,ppi.useSpace,ppi.spaceCount,ppi.install,ppi.usePart,ppi.unit,ppi.amount,ppi.paintPaletteNumber,ppi.EndProduct,ppi.sequence,ppi.remark,pp.*,psi2.name contentName,psi.name as itemName,ps.stage_name,psi.begin_date,psi.end_date,ps.begin_date as stage_sDate,ps.end_date as stage_eDate ,d.Image AS productPic, d.Name AS productName,d.Specifications,psi.sid as csid,dbo.getProjectSubmitDate_fu(psi.sid) as submitDate,(case when psi.v2 is null or psi.v2='' then e.v2 else psi.v2 end)v2,(case when psi.v1 is null or psi.v1='' then pg.v1 else psi.v1 end)v1,psi.sequence as itemSequence,psi.sequence as contentSequence,psi.remark as cremark,psi.group_sid,psi.parent_sid,psi.sid as csid,(case when psi.v1='' or psi.v1 is null then dbo.getUserNames_fu(pg.v1) else dbo.getUserNames_fu(psi.v1) end) as header,(case when psi.v2='' or psi.v2 is null then dbo.getUserNames_fu(e.v2) else dbo.getUserNames_fu(psi.v2) end ) as finaler,pg.v1 groupHeader "
+ "	from project_product pp"
+ "	left join project_product_item ppi on ppi.sid = pp.ppiID"
+ "	right join project_specific_item psi on psi.PP_sid=pp.sid"
+ "	right join project_specific_item psi2 on psi2.sid=psi.parent_sid"
+ "	left outer join project_stage ps on psi.s_sid=ps.sid "
+ "	 INNER JOIN  dbo.v_ProductColorShip AS d ON ppi.ProductID = d.ID"
+ "	left outer join project_stage c on psi.s_sid=c.sid "
+ "	left outer join project_group pg on psi.group_sid=pg.sid"
+ "	inner join project e on c.p_sid=e.sid "
+ "	where  pp.ps_sid=" + pssid + "");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    reStr += "<tr>";
                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["number"].ToString().Trim() + "</td>";
                    reStr += "<td>" + dt.Rows[i]["productName"].ToString().Trim() + "</td>";
                    reStr += "<td style='text-align: center;'><img alt='' height='45px' src='/ProductPic/" + dt.Rows[i]["productPic"].ToString().Trim() + "' /></td>";
                    reStr += "<td style='text-align: center;'>" + dt.Rows[i]["Specifications"].ToString().Trim() + "</td>";
                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["paintColor"].ToString().Trim() + "</td>";
                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["useSpace"].ToString().Trim() + "</td>";

                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["spaceCount"].ToString().Trim() + "</td>";
                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["install"].ToString().Trim() + "</td>";
                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["usePart"].ToString().Trim() + "</td>";
                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["unit"].ToString().Trim() + "</td>";

                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["amount"].ToString().Trim() + "</td>";
                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["paintPaletteNumber"].ToString().Trim() + "</td>";
                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["contentName"].ToString().Trim() + "</td>";
                    reStr += "<td style='text-align:center;'>" + dt.Rows[i]["remark"].ToString().Trim() + "</td>";

               
                    reStr += "</tr>";
                }
            }
            return reStr;
        }

        private bool IsDate(string dateString)
        {
            Match m = Regex.Match(dateString, "/^(d{2}|d{4})-((0([1-9]{1}))|(1[1|2]))-(([0-2]([1-9]{1}))|(3[0|1]))$");
            return m.Success;
        }
    }
}