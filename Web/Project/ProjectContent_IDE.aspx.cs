using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project
{
    public partial class ProjectContent_IDE : System.Web.UI.Page
    {
        protected string sid = "", pssid = "", pname = "", pcode = "", stageName = "", column = "", groupJson = "[]";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pssid = Request.Params["ps_sid"] == null ? "" : Request.Params["ps_sid"].Trim();
                DataTable dt = new DataTable();
                DataSet ds = new BLL.Common().GetList("select project.sid as psid, project_name,project_code,stage_name,project.v1 as groupAppr,project.v2 as trialAppr,project.v3 as qsAppr from project_stage left outer join project on project_stage.p_sid=project.sid where project_stage.sid='" + pssid + "'");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt.Rows.Count > 0)
                {
                    pname = dt.Rows[0]["project_name"].ToString().Trim();
                    pcode = dt.Rows[0]["project_code"].ToString().Trim();
                    stageName = dt.Rows[0]["stage_name"].ToString().Trim();

                    //动态添加实施列
                    string dynamicColumn = "";
                    DataTable impDT = new DataTable();
                    DataSet impDS = new BLL.project_implement().GetList(" s_sid='" + pssid + "'");
                    if (impDS.Tables.Count > 0)
                    {
                        impDT = impDS.Tables[0];
                    }
                    for (int i = 0; i < impDT.Rows.Count; i++)
                    {
                        string json = "[]";
                        DataTable tmpDT1 = new DataTable();
                        DataSet tmpDS1 = new BLL.Common().GetList(" select username, name from baseuser where username in (  select * from  dbo.getTable('" + impDT.Rows[i]["implementers_sid"].ToString().Trim() + "',',')) order by name asc");
                        if (tmpDS1.Tables.Count > 0)
                        {
                            tmpDT1 = tmpDS1.Tables[0];
                            json = DBUtility.JsonHelper.DataTable2Json_Combo(tmpDT1).Replace('"', '\'');
                        }
                        //dynamicColumn += "{field:'" + "imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',width:80,align:'center',halign: 'center', formatter:function(value,row){return row.imp_abb" + impDT.Rows[i]["sid"].ToString().Trim() + ";},editor: {type:'combobox',options:{valueField:'username',textField:'name',data:" + json + ",panelHeight:'auto'}}},";
                        dynamicColumn += "{field:'" + "imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',width:80,align:'center',halign: 'center', editor: {type:'combobox',options:{valueField:'username',textField:'name',data:" + json + ",panelHeight:'auto'}}},";
                        //dynamicColumn += "{field:'" + "imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',width:80,align:'center',halign: 'center', editor: {type:'combobox',options:{valueField:'username',textField:'name',url:'../ashx/project.ashx?action=getImpJson&pisid=" + impDT.Rows[i]["sid"].ToString().Trim() + "',panelWidth:100}},formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + rowData.imp_abb" + impDT.Rows[i]["sid"].ToString().Trim() + " + '\\\"><span class=\\\"mlength\\\">' + rowData.imp_abb" + impDT.Rows[i]["sid"].ToString().Trim() + " + '</span></a>';}},";
                        //dynamicColumn += "{field:'" + "imp" + impDT.Rows[i]["sid"].ToString().Trim() + "',title:'" + impDT.Rows[i]["implement_name"].ToString().Trim() + "',width:80,align:'center',halign: 'center', formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + rowData.imp_abb" + impDT.Rows[i]["sid"].ToString().Trim() + " + '\\\"><span class=\\\"mlength\\\">' + rowData.imp_abb" + impDT.Rows[i]["sid"].ToString().Trim() + " + '</span></a>';}},";
                    }
                    //获取小组列表
                    //groupJson = "[]";
                    DataTable tmpDT = new DataTable();
                    DataSet tmpDS = new BLL.Common().GetList(" select sid, group_name from project_group where ps_sid='" + pssid + "' order by sequence asc");
                    if (tmpDS.Tables.Count > 0)
                    {
                        tmpDT = tmpDS.Tables[0];
                        groupJson = DBUtility.JsonHelper.DataTable2Json_Combo(tmpDT).Replace('"', '\'');
                    }

                    //小组审核
                    string groupAppJson = "[]";
                    tmpDT = new DataTable();
                    tmpDS = new BLL.Common().GetList(" select username, name from baseuser where username in (  select * from  dbo.getTable('" + dt.Rows[0]["groupAppr"].ToString().Trim() + "',',')) order by name asc");
                    if (tmpDS.Tables.Count > 0)
                    {
                        tmpDT = tmpDS.Tables[0];
                        groupAppJson = DBUtility.JsonHelper.DataTable2Json_Combo(tmpDT).Replace('"', '\'');
                    }

                    //初审
                    string trialAppJson = "[]";
                    tmpDT = new DataTable();
                    tmpDS = new BLL.Common().GetList(" select username, name from baseuser where username in (  select * from  dbo.getTable('" + dt.Rows[0]["trialAppr"].ToString().Trim() + "',',')) order by name asc");
                    if (tmpDS.Tables.Count > 0)
                    {
                        tmpDT = tmpDS.Tables[0];
                        trialAppJson = DBUtility.JsonHelper.DataTable2Json_Combo(tmpDT).Replace('"', '\'');
                    }

                    //质量监督
                    string qsAppJson = "[]";
                    tmpDT = new DataTable();
                    tmpDS = new BLL.Common().GetList(" select username as v3, name as qsAppr from baseuser where username in (  select * from  dbo.getTable('" + dt.Rows[0]["qsAppr"].ToString().Trim() + "',',')) order by name asc");
                    if (tmpDS.Tables.Count > 0)
                    {
                        tmpDT = tmpDS.Tables[0];
                        qsAppJson = DBUtility.JsonHelper.DataTable2Json_Combo(tmpDT).Replace('"', '\'');
                    }

                    column += "[[";
                    //column += "{ title: '小组', field: 'group_sid', width: 60,  halign: 'center', align: 'center', editor: {type:'combobox',options:{valueField:'sid',textField:'group_name',data:" + groupJson + ",panelWidth:100}},formatter: function (value, rowData, rowIndex) {if (rowData.parent_sid == 0) {return '<a class=\\\"a_black\\\" title=\\\"' + rowData.group_name + '\\\"><span class=\\\"mlength\\\">' + rowData.group_name + '</span></a>';}else {return '';}}},";
                    //column += "{ title: '小组', field: 'group_sid', width: 60, sortable: true, halign: 'center', align: 'center', editor: {type:'combobox',options:{valueField:'sid',textField:'group_name',data:"+groupJson+",panelWidth:100}},formatter: function (value, rowData, rowIndex) {if (rowData.parent_sid == 0) {return '<a class=\\\"a_black\\\" title=\\\"' + rowData.group_name + '\\\"><span class=\\\"mlength\\\">' + rowData.group_name + '</span></a>';}else {return '';}}},";

                    column += "{ title: '细目', field: 'name', width: 200,  halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}},";
                    column += "{ title: '开始日期', field: 'begin_date', width: 80,  halign: 'center', align: 'center', editor: 'date'},";
                    column += "{ title: '结束日期', field: 'end_date', width: 80, halign: 'center', align: 'center', editor: 'date'},";
                    column += dynamicColumn;
                    column += "{ title: '小组审核', field: 'v1', width: 100, halign: 'center', align: 'center',formatter:function(value,row){return row.groupAppr;}, editor: {type:'combobox',options:{valueField:'username',textField:'name',data:" + groupAppJson + ",panelHeight:'auto'}}},";
                    column += "{ title: '初审', field: 'v2', width: 100, halign: 'center', align: 'center',formatter: function (value, rowData, rowIndex) {return  rowData.trialAppr ;}, editor: {type:'combobox',options:{valueField:'username',textField:'name',data:" + trialAppJson + ",panelHeight:'auto'}}},";
                    column += "{ title: '质量监督', field: 'v3', width: 100, halign: 'center', align: 'center',formatter: function (value, rowData, rowIndex) {return  rowData.qsAppr;}, editor: {type:'combobox',options:{valueField:'v3',textField:'qsAppr',data:" + qsAppJson + ",panelHeight:'auto'}}}";
                    //column += ",{ title: '备注', field: 'remark', width: 100, halign: 'center', editor: 'text',formatter: function (value, rowData, rowIndex) {return '<a class=\\\"a_black\\\" title=\\\"' + value + '\\\"><span class=\\\"mlength\\\">' + value + '</span></a>';}}";
                    column += "]]";
                }
            }
        }
    }
}