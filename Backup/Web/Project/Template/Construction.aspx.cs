using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project.Template
{
    public partial class Construction : System.Web.UI.Page
    {
        protected string sid = "", pssid = "", pname = "", pcode = "", stageName = "", column = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pssid = Request.Params["ps_sid"] == null ? "" : Request.Params["ps_sid"].Trim();
                stageName = DBUtility.DbHelperSQL.GetSingle("select stage_name from stage where sid=" + pssid).ToString().Trim();

                //动态添加实施列
                string dynamicColumn = "";
                DataTable impDT = new DataTable();
                DataSet impDS = new BLL.project_stage_implement_model().GetList(" s_sid='" + pssid + "'");
                if (impDS.Tables.Count > 0)
                {
                    impDT = impDS.Tables[0];
                }
                for (int i = 0; i < impDT.Rows.Count; i++)
                {
                    dynamicColumn += "{field:'" + "imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',width:80,rowspan:3,align:'center',halign: 'center'},";
                }

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

                column += "[[";
                column += "{ title: '空间', field: 'contentName', width: 200, rowspan:3,halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}},";
                column += "{ title: '图纸及索引号', field: 'itemName', width: 200,rowspan:3, halign: 'center',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}},";
                column += "{ title: '月'},";
                column += "{ title: '(施工图立面框架"+flow+"(计划表中实际完成时间将用绿色色块做的标志))', field: 'tmp',width: 150,rowspan:3},";
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