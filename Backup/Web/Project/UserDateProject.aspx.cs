using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project
{
    public partial class UserDateProject : System.Web.UI.Page
    {
        protected string trStr = "",data="[]";
        protected DateTime sDt = new DateTime();
        protected DateTime eDt = new DateTime();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                sDt = DateTime.Now;
                eDt = DateTime.Now;
                
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        sDt=sDt.AddDays(-6);
                        break;
                    case DayOfWeek.Monday:
                        eDt = eDt.AddDays(6);
                        break;
                    case DayOfWeek.Tuesday:
                        sDt = sDt.AddDays(-1);
                        eDt = eDt.AddDays(5);
                        break;
                    case DayOfWeek.Wednesday:
                        sDt = sDt.AddDays(-2);
                        eDt = eDt.AddDays(4);
                        break;
                    case DayOfWeek.Thursday:
                        sDt = sDt.AddDays(-3);
                        eDt = eDt.AddDays(3);
                        break;
                    case DayOfWeek.Friday:
                        sDt = sDt.AddDays(-4);
                        eDt = eDt.AddDays(2);
                        break;
                    case DayOfWeek.Saturday:
                         sDt = sDt.AddDays(-5);
                        eDt = eDt.AddDays(1);
                        break;
                }
                sDate.Value = sDt.ToShortDateString();
                eDate.Value = eDt.ToShortDateString();
                GetData(sDt,eDt);
            }
        }

        private void GetData(DateTime sDt,DateTime eDt)
        {
            string str1 = "", str2 = "";
            //DateTime sDt = DateTime.Parse("2013-08-10");
            //DateTime eDt = DateTime.Parse("2013-08-31");
            TimeSpan ts = eDt.AddDays(1).Subtract(sDt);
            for (int i = 0; i < ts.Days; i++)
            {
                string w = "";
                switch (sDt.AddDays(i).DayOfWeek)
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
                //str1 += "<th colspan='2' >" + sDt.AddDays(i).ToString("M月d号") + "(周" + w + ")" + "</th>";
                //str2 += "<th data-options=\\\"field:'" + sDt.AddDays(i).ToString("yyy-MM-dd") + "',width:150, halign: 'center', align: 'center'\\\">工作计划内容</th><th data-options=\\\"field:'" + sDt.AddDays(i).ToString("yyy-MM-dd") + "_done',width:50, halign:'center', align: 'center'\\\">实际完成状况</th>"; ;
                str1 += "{title:'" + sDt.AddDays(i).ToString("M月d号") + "(周" + w + ")" + "',colspan:2},";
                str2 += "{field:'" + sDt.AddDays(i).ToString("yyy-MM-dd") + "',title:'工作计划内容',width:150, halign: 'center'}," +
                    "{field:'" + sDt.AddDays(i).ToString("yyy-MM-dd") + "_done',title:'实际完成状况',width:50, halign: 'center', align: 'center'},";
            }

            //trStr += "<thead>";
            //trStr += "<tr>";
            //trStr += "<th data-options=\\\"field:'stage_name',width:50, halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:white;';}\\\" rowspan='2'>员工姓名</th>";
            //trStr += "<th data-options=\\\"field:'group_name',width:50, halign: 'center', align: 'center',styler: function(value,row,index){return 'background-color:white;';}\\\" rowspan='2'>项目</th>";
            //trStr += str1;
            //trStr += "</tr>";

            //trStr += "<tr>";
            //trStr += str2;
            //trStr += "</tr>";
            //trStr += "</thead>";

            trStr += "[[";
            trStr += "{field:'name',title:'员工姓名',width:80, halign: 'center', align: 'center',rowspan:2,styler: function(value,row,index){return 'background-color:white;';}},";
            trStr += "{field:'project_name',title:'项目',width:100, halign: 'center', align: 'center',rowspan:2},";
            trStr += str1.Substring(0, str1.Length - 1);

            trStr += "],[";
            trStr += str2.Substring(0, str2.Length - 1);
            trStr += "]]";

            string s1 = project.Value;
            string s2 = imp_dept.Value;
            string s3 = hvalue.Value;
            string whereStr = " 1=1 ";
            if (s1 != "")
            {
                whereStr += " and p_sid='" + s1 + "'";
            }
            if (s2 != "" && s3 == "")
            {
                whereStr += " and ','+deptIDS+',' like '%,"+s2+",%' ";
            }
            string[] arr = s3.Split(',');
            string s4 = "";
            for (int i = 0; i < arr.Length; i++)
            {
                s4 += "'"+arr[i].Trim()+"',";
            }
            if (s4.Length > 0)
            {
                s4 = s4.Substring(0, s4.Length - 1);
            }
            if (s3 != "")
            {
                whereStr += " and username in(" + s4 + ") ";
            }

            DataTable dt = new DataTable();
            DataSet ds = new BLL.Common().GetList("select * from v_projectUser_fu where "+whereStr+" order by name asc");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < ts.Days; i++)
                {
                    DataColumn datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = sDt.AddDays(i).ToString("yyyy-MM-dd");
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);

                    datetimeColumn = new DataColumn();
                    //该列的数据类型
                    datetimeColumn.DataType = System.Type.GetType("System.String");
                    //该列得名称
                    datetimeColumn.ColumnName = sDt.AddDays(i).ToString("yyyy-MM-dd") + "_done";
                    //该列得默认值
                    datetimeColumn.DefaultValue = "";
                    dt.Columns.Add(datetimeColumn);
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < ts.Days; j++)
                    {
                        DataTable contentDT = new DataTable();
                        ds = new BLL.Common().GetList("select a.name as itemName,b.name as content,dbo.getProItemSubmit_fu(a.sid,'" + sDt.AddDays(j).ToShortDateString() + "') as done from project_specific_item a left outer join project_specific_item b on a.parent_sid=b.sid left outer join project_stage c on b.s_sid=c.sid left outer join project d on c.p_sid=d.sid where a.ischild=1 and d.sid='" + dt.Rows[i]["p_sid"].ToString().Trim() + "' and a.begin_date<='" + sDt.AddDays(j).ToShortDateString() + "' and a.end_date>='" + sDt.AddDays(j).ToShortDateString() + "' and ','+dbo.getProItemUser_fu(a.sid)+',' like '%," + dt.Rows[i]["username"].ToString().Trim() + ",%' ");
                        if (ds.Tables.Count > 0)
                        {
                            contentDT = ds.Tables[0];
                            string tmp1 = "", tmp2 = "";
                            for (int n = 0; n < contentDT.Rows.Count; n++)
                            {
                                tmp1 += (n + 1).ToString() + "、" + contentDT.Rows[n]["content"].ToString().Trim() + "/" + contentDT.Rows[n]["itemName"].ToString().Trim();
                                if (n < contentDT.Rows.Count - 1)
                                {
                                    tmp1 += "<br/>";
                                }
                                if (tmp2 != "完成")
                                {
                                    tmp2 = contentDT.Rows[n]["done"].ToString().Trim();
                                }
                            }
                            dt.Rows[i][sDt.AddDays(j).ToString("yyyy-MM-dd")] = tmp1;
                            dt.Rows[i][sDt.AddDays(j).ToString("yyyy-MM-dd") + "_done"] = tmp2;
                        }
                    }
                }

            }

            data = DBUtility.JsonHelper.DataTable2Json_Datagrid(dt, dt.Rows.Count);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime sDt = DateTime.Parse(sDate.Value);
            DateTime eDt = DateTime.Parse(eDate.Value);
            GetData(sDt,eDt);
        }
    }
}