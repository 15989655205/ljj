using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;
using System.Data;
//using Microsoft.Reporting.WebForms;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Maticsoft.Web.kaoqing
{
    public partial class KaoQinRdlc : System.Web.UI.Page
    {
        private string STime
        {
            get { return (ViewState["STime"] ?? "") as string; }
            set { ViewState["STime"] = value; }
        }
        private string ETime
        {
            get { return (ViewState["ETime"] ?? "") as string; }
            set { ViewState["ETime"] = value; }
        }
        private string WorkID
        {
            get { return (ViewState["WorkID"] ?? "") as string; }
            set { ViewState["WorkID"] = value; }
        }
        private string Name
        {
            get { return (ViewState["Name"] ?? "") as string; }
            set { ViewState["Name"] = value; }
        }
        private string status
        {
            get { return (ViewState["status"] ?? "") as string; }
            set { ViewState["status"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                LoadData();
            }
        }

        private void LoadData()
        {

            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_kaoqin", WCDataAction.Query4);
            string where = "1=1";
            if (STime != "" & ETime != "")
            {
                where += " and KaoQinRiQi between " + STime + " and " + ETime;
            }
            if (Name!="")
            {
                where += " and Name like '%" + Name + "%'";
            }
            if (WorkID!="")
            {
                where += " and WorkID like '%" + WorkID +"%'";
            }
            if (status != "")
            {
                string s = "";
                switch (status)
                {
                    case "1":
                        s = "'%(正常)%'";
                        break;
                    case "2":
                        s = "'%(迟到)%'";
                        break;
                    case "3":
                        s = "'%(早退)%'";
                        break;
                    case "4":
                        s = "'%未登记%'";
                        break;
                    default:
                        break;
                }
                if (status == "1")
                {
                    where += "  and (DengJiTime1 like " + s + " and DengJiTime2 like " + s + " and DengJiTime3 like " + s + " and DengJiTime4 like " + s + ")";
                }
                else
                {
                    where += "  and (DengJiTime1 like " + s + " or DengJiTime2 like " + s + " or DengJiTime3 like " + s + " or DengJiTime4 like " + s + ")";
                }
            }
            dsp.InputPars.Add("@where", where);
            if (db.Execute(dsp).ExecuteState)
            {
                DataTable dt = dsp.OutputDataSet.Tables[0];
                //this.ReportViewer1.LocalReport.DisplayName = "考勤统计 ";
                //this.ReportViewer1.LocalReport.LoadReportDefinition(GetRdlc(dt));
                //this.ReportViewer1.LocalReport.DataSources.Clear();
                //ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                //ReportViewer1.LocalReport.DataSources.Add(rds);
                //ReportViewer1.LocalReport.Refresh();
            }

        }

        private MemoryStream GetRdlc(DataTable dt)
        {


            string fileInfo = ReplaceRdlc(STime, ETime, Server.MapPath("~/RDLC/KaoQin.rdlc"),dt);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(fileInfo);
            return new MemoryStream(bytes);
        }
        private string ReplaceRdlc(string S, string E, string path,DataTable dt)
        {

            XDocument xd = XDocument.Load(path);
            XElement xe = xd.Elements().First();
            XElement pageNode = xe.Elements().First(p => p.Name.LocalName == "Page");
            XElement pageHeaderNode = pageNode.Elements().First(p => p.Name.LocalName == "PageHeader");
            XElement reportItemsNode = pageHeaderNode.Elements().First(p => p.Name.LocalName == "ReportItems");
            string str = "查询条件：";
            if (STime != "" & ETime != "")
            {
                str += "  时间：" + DateTime.Parse(STime).ToString("yyyy-MM-dd") + "至" + DateTime.Parse(ETime).ToString("yyyy-MM-dd");
            }
            if (Name != "")
            {
                str += "  姓名：" + Name;
            }
            if (WorkID != "")
            {
                str += "  工号：" + WorkID;
            }
            if (status!="")
            {
                switch (status)
                {
                    case"1":
                        str += "  状态：正常";
                        break;
                    case "2":
                        str += "  状态：迟到";
                        break;
                    case "3":
                        str += "  状态：早退";
                        break;
                    case "4":
                        str += "  状态：未登记";
                        break;
                    default:
                        break;
                }
            }
            //查询特定节点
            XElement note = reportItemsNode.Elements().First(p => p.Name.LocalName == "Textbox" && p.Attribute("Name").Value == "txb_serach");
            XElement paragraphsNode = note.Elements().First(p => p.Name.LocalName == "Paragraphs");
            XElement paragraphNode = paragraphsNode.Elements().First(p => p.Name.LocalName == "Paragraph");
            XElement textRunsNode = paragraphNode.Elements().First(p => p.Name.LocalName == "TextRuns");
            XElement textRunNode = textRunsNode.Elements().First(p => p.Name.LocalName == "TextRun");
            XElement valueNode = textRunNode.Elements().First(p => p.Name.LocalName == "Value");
            XElement visibilityNode = note.Elements().First(p => p.Name.LocalName == "Visibility");
            XElement hiddenNode = visibilityNode.Elements().First(p => p.Name.LocalName == "Hidden");
            //替换
            valueNode.Value = str;
            hiddenNode.Value = "false";
            //valueNode.Remove();



            return xd.ToString();
        }



        protected void search_Click(object sender, EventArgs e)
        {

            STime = startTime.Value;
            ETime = endTime.Value;
            Name = SUName.Value;
            WorkID = SWID.Value;
            status = select_status.Value;
            LoadData();
        }
    }
}