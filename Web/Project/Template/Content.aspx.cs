using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project.Template
{
    public partial class Content : System.Web.UI.Page
    {
        protected string sid = "", pssid = "", pname = "", pcode = "", stageName = "", column = "";
        protected string showContent = "", showItem = "", isConstruction="",isView="0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pssid = Request.Params["ps_sid"] == null ? "" : Request.Params["ps_sid"].Trim();
                isConstruction = Request.Params["isConstruction"] == null ? "" : Request.Params["isConstruction"].Trim();
                isView = Request.Params["isView"] == null ? "0" : Request.Params["isView"].Trim();
                stageName = DBUtility.DbHelperSQL.GetSingle("select stage_name from stage where sid=" + pssid).ToString().Trim();


                //动态添加实施列
                string dynamicColumn = "";
                DataTable impDT = new DataTable();
                DataSet impDS = new DAL.project_stage_implement_model().GetList(" s_sid='" + pssid + "' order by sequence");//new BLL.project_stage_implement_model().GetList(" s_sid='" + pssid + "'");
                if (impDS.Tables.Count > 0)
                {
                    impDT = impDS.Tables[0];
                }
                for (int i = 0; i < impDT.Rows.Count; i++)
                {
                    dynamicColumn += "{field:'" + "imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',width:80,rowspan:3,align:'center',halign: 'center'},";
                }

                string calendarStr = "";
                string showGroup = "true";
                switch (isConstruction)
                {
                    case "1":
                        showContent = "空间";
                        showItem = "图纸及索引号";
                        string flow = "";
                        DataTable tmpDT = new DataTable();
                        DataSet tmpDS = new BLL.project_stage_work_flow_model().GetList(" s_sid='" + pssid + "'");
                        if (tmpDS.Tables.Count > 0)
                        {
                            tmpDT = tmpDS.Tables[0];
                        }
                        for (int i = 0; i < tmpDT.Rows.Count; i++)
                        {
                            flow += (i + 1).ToString() + tmpDT.Rows[i]["work_flow_name"].ToString().Trim() + ",";
                        }
                        calendarStr = "(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))";
                        
                        //column += "[[";
                        //column += "{ title: '空间', field: 'contentName', width: 200, rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}},";
                        //column += "{ title: '图纸及索引号', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}},";
                        //column += "{ title: '月'},";
                        //column += "{ title: '(施工图立面框架" + flow + "(计划表中实际完成时间将用绿色色块做的标志))', field: 'tmp',width: 200,rowspan:3},";
                        //column += dynamicColumn;
                        //column += "{ title: '主管审核', field: 'v1', width: 60,rowspan:3, halign: 'center', align: 'center'},";
                        //column += "{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, sortable: true, halign: 'center', align: 'center'},";
                        //column += "{ title: '解决的办法', field: 'solution', width: 60, rowspan:3,sortable: true, halign: 'center', align: 'center'},";
                        //column += "{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3,sortable: true, halign: 'center', align: 'center'},";
                        //column += "{ title: '总审', field: 'v2', width: 60, rowspan:3,sortable: true, halign: 'center', align: 'center'},";
                        //column += "{ title: '备注', field: 'remark', width: 60, rowspan:3,halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                        //column += "],";
                        //column += "[";
                        //column += "{ title: '日'}";
                        //column += "],[";
                        //column += "{ title: '星期', field: 'week',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';}}";
                        //column += "]]";
                        break;
                    case "0":
                        showContent = "工作内容";
                        showItem = "细目";
                        calendarStr = "(黄色色块代表完成这项工作所需要的完成时间，计划表中实际完成时间将用绿色色块做标记)";
                        showGroup = "false";
                        //column += "[[";
                        //column += "{ title: '小组', field: 'group_name', width: 60, rowspan:3, halign: 'center', align: 'center'},";
                        //column += "{ title: '工作内容', field: 'contentName', width: 200, rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}},";
                        //column += "{ title: '细目', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}},";
                        //column += "{ title: '月'},";
                        //column += "{ title: '(黄色色块代表完成这项工作所需要的完成时间，计划表中实际完成时间将用绿色色块做标记)', field: 'tmp',width: 150,rowspan:3},";
                        //column += dynamicColumn;
                        //column += "{ title: '主管审核', field: 'v1', width: 60,rowspan:3, halign: 'center', align: 'center'},";
                        //column += "{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, sortable: true, halign: 'center', align: 'center'},";
                        //column += "{ title: '解决的办法', field: 'solution', width: 60, rowspan:3,sortable: true, halign: 'center', align: 'center'},";
                        //column += "{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3,sortable: true, halign: 'center', align: 'center'},";
                        //column += "{ title: '总审', field: 'v2', width: 60, rowspan:3,sortable: true, halign: 'center', align: 'center'},";
                        //column += "{ title: '备注', field: 'remark', width: 60, rowspan:3,halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                        //column += "],";
                        //column += "[";
                        //column += "{ title: '日'}";
                        //column += "],[";
                        //column += "{ title: '星期', field: 'week',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';}}";
                        //column += "]]";
                        break;
                    case "2":
                        showContent = "货物类别";
                        showItem = "工作细目";
                        calendarStr = "工作日历";
                        break;
                    case "3":
                        showContent = "加工类别";
                        showItem = "内容";
                        calendarStr = "进程计划";
                        break;
                    default:
                        break;
                }

                column += "[[";
                column += "{ title: '小组', field: 'group_name', width: 60, rowspan:3, halign: 'center', align: 'center',hidden:"+showGroup+"},";
                column += "{ title: '" + showContent + "', field: 'contentName', width: 200, rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}},";
                column += "{ title: '" + showItem + "', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}},";
                column += "{ title: '月'},";
                column += "{ title: '"+calendarStr+"', field: 'tmp',width: 200,rowspan:3},";
                column += dynamicColumn;
                column += "{ title: '组长审核', field: 'v1', width: 60,rowspan:3, halign: 'center', align: 'center'},";
                column += "{ title: '未完成的原因', field: 'unfinished_reason', width: 60,rowspan:3, sortable: true, halign: 'center', align: 'center'},";
                column += "{ title: '解决的办法', field: 'solution', width: 60, rowspan:3,sortable: true, halign: 'center', align: 'center'},";
                column += "{ title: '解决的结果', field: 'reviewed', width: 60, rowspan:3,sortable: true, halign: 'center', align: 'center'},";
                column += "{ title: '总审', field: 'v2', width: 60, rowspan:3,sortable: true, halign: 'center', align: 'center'},";
                column += "{ title: '备注', field: 'remark', width: 60, rowspan:3,halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                column += "],";
                column += "[";
                column += "{ title: '日'}";
                column += "],[";
                column += "{ title: '星期', field: 'week',styler: function(value,row,index){return 'background-color:lightgray;color:lightgray;';}}";
                column += "]]";
            }
        }
    }
}