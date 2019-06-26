using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Project.Material
{
    public partial class PrintA : System.Web.UI.Page
    {
        protected string pname = "";
        protected Model.project pModel = new Model.project();
        protected string trStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string projectID = "", spaceID = "", placeID = "";
                projectID = Request.Params["projectID"] == null ? "" : Request.Params["projectID"].Trim();
                spaceID = Request.Params["spaceID"] == null ? "" : Request.Params["spaceID"].Trim();
                placeID = Request.Params["placeID"] == null ? "" : Request.Params["placeID"].Trim();
                DataTable dt = new DataTable();
                string where = "Checking=1 and projectID='" + projectID + "'";
                if (!string.IsNullOrEmpty(spaceID))
                {
                    where += " and spaceID='" + spaceID + "'";
                }
                if (!string.IsNullOrEmpty(placeID))
                {
                    where += " and placeID='" + placeID + "'";
                }
                string showData = "";
                DataSet ds = new BLL.Common().GetList("select * from v_ProjectMaterialA where " + where + " order by spaceID,placeID");
                DataTable dataDT = new DataTable();
                DataTable spaceDT = new DataTable();
                DataTable ceilingDT = new DataTable();
                DataTable groundDT = new DataTable();
                DataTable wallDT = new DataTable();
                spaceDT.Columns.Add("space");
                spaceDT.Columns.Add("place");
                ceilingDT.Columns.Add("key");
                ceilingDT.Columns.Add("description");
                ceilingDT.Columns.Add("size");
                ceilingDT.Columns.Add("color");
                ceilingDT.Columns.Add("quality");
                ceilingDT.Columns.Add("brand");
                ceilingDT.Columns.Add("nfk");
                groundDT.Columns.Add("key");
                groundDT.Columns.Add("description");
                groundDT.Columns.Add("size");
                groundDT.Columns.Add("color");
                groundDT.Columns.Add("quality");
                groundDT.Columns.Add("brand");
                groundDT.Columns.Add("nfk");
                wallDT.Columns.Add("key");
                wallDT.Columns.Add("description");
                wallDT.Columns.Add("size");
                wallDT.Columns.Add("color");
                wallDT.Columns.Add("quality");
                wallDT.Columns.Add("brand");
                wallDT.Columns.Add("nfk");
                dataDT.Columns.Add("space");
                dataDT.Columns.Add("place");
                dataDT.Columns.Add("ckey");
                dataDT.Columns.Add("cdescription");
                dataDT.Columns.Add("csize");
                dataDT.Columns.Add("ccolor");
                dataDT.Columns.Add("cquality");
                dataDT.Columns.Add("cbrand");
                dataDT.Columns.Add("cnfk");
                dataDT.Columns.Add("gkey");
                dataDT.Columns.Add("gdescription");
                dataDT.Columns.Add("gsize");
                dataDT.Columns.Add("gcolor");
                dataDT.Columns.Add("gquality");
                dataDT.Columns.Add("gbrand");
                dataDT.Columns.Add("gnfk");
                dataDT.Columns.Add("wkey");
                dataDT.Columns.Add("wdescription");
                dataDT.Columns.Add("wsize");
                dataDT.Columns.Add("wcolor");
                dataDT.Columns.Add("wquality");
                dataDT.Columns.Add("wbrand");
                dataDT.Columns.Add("wnfk");
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
                if (dt.Rows.Count > 0)
                {
                    pname = dt.Rows[0]["projectName"].ToString().Trim();
                    string prePlace = "", curPlace = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        spaceDT.Rows.Add();
                        curPlace = dt.Rows[i]["place"].ToString().Trim();
                        spaceDT.Rows[spaceDT.Rows.Count - 1]["space"] = dt.Rows[i]["space"].ToString().Trim();
                        spaceDT.Rows[spaceDT.Rows.Count - 1]["place"] = dt.Rows[i]["place"].ToString().Trim();
                        if (curPlace == prePlace || prePlace == "")
                        {
                            if (dt.Rows[i]["location"].ToString().Trim() == "天花")
                            {
                                ceilingDT.Rows.Add();
                                ceilingDT.Rows[ceilingDT.Rows.Count-1]["key"] = dt.Rows[i]["productCode"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["description"] = dt.Rows[i]["productName"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["size"] = dt.Rows[i]["Size"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["color"] = dt.Rows[i]["Color"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["quality"] = dt.Rows[i]["Quality"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["brand"] = dt.Rows[i]["Brand"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["nfk"] = dt.Rows[i]["NFK"].ToString().Trim();
                            }
                            if (dt.Rows[i]["location"].ToString().Trim() == "地面")
                            {
                                groundDT.Rows.Add();
                                groundDT.Rows[groundDT.Rows.Count - 1]["key"] = dt.Rows[i]["productCode"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["description"] = dt.Rows[i]["productName"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["size"] = dt.Rows[i]["Size"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["color"] = dt.Rows[i]["Color"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["quality"] = dt.Rows[i]["Quality"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["brand"] = dt.Rows[i]["Brand"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["nfk"] = dt.Rows[i]["NFK"].ToString().Trim();
                            }
                            if (dt.Rows[i]["location"].ToString().Trim() == "墙面")
                            {
                                wallDT.Rows.Add();
                                wallDT.Rows[wallDT.Rows.Count - 1]["key"] = dt.Rows[i]["productCode"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["description"] = dt.Rows[i]["productName"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["size"] = dt.Rows[i]["Size"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["color"] = dt.Rows[i]["Color"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["quality"] = dt.Rows[i]["Quality"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["brand"] = dt.Rows[i]["Brand"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["nfk"] = dt.Rows[i]["NFK"].ToString().Trim();
                            }
                        }
                        else
                        {
                            for (int j = 0; j < (ceilingDT.Rows.Count > groundDT.Rows.Count ? ceilingDT.Rows.Count > wallDT.Rows.Count ? ceilingDT.Rows.Count : wallDT.Rows.Count : groundDT.Rows.Count > wallDT.Rows.Count ? groundDT.Rows.Count : wallDT.Rows.Count); j++)
                            {
                                dataDT.Rows.Add();
                                dataDT.Rows[dataDT.Rows.Count - 1]["space"] = spaceDT.Rows[j]["space"];
                                dataDT.Rows[dataDT.Rows.Count - 1]["place"] = spaceDT.Rows[j]["place"];
                                try
                                {
                                    dataDT.Rows[dataDT.Rows.Count - 1]["ckey"] = ceilingDT.Rows[j]["key"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["cdescription"] = ceilingDT.Rows[j]["description"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["csize"] = ceilingDT.Rows[j]["size"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["ccolor"] = ceilingDT.Rows[j]["color"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["cquality"] = ceilingDT.Rows[j]["quality"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["cbrand"] = ceilingDT.Rows[j]["brand"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["cnfk"] = ceilingDT.Rows[j]["nfk"];
                                }
                                catch
                                {
                                }
                                try
                                {
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gkey"] = groundDT.Rows[j]["key"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gdescription"] = groundDT.Rows[j]["description"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gsize"] = groundDT.Rows[j]["size"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gcolor"] = groundDT.Rows[j]["color"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gquality"] = groundDT.Rows[j]["quality"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gbrand"] = groundDT.Rows[j]["brand"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gnfk"] = groundDT.Rows[j]["nfk"];
                                }
                                catch
                                {
                                }
                                try
                                {
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wkey"] = wallDT.Rows[j]["key"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wdescription"] = wallDT.Rows[j]["description"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wsize"] = wallDT.Rows[j]["size"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wcolor"] = wallDT.Rows[j]["color"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wquality"] = wallDT.Rows[j]["quality"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wbrand"] = wallDT.Rows[j]["brand"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wnfk"] = wallDT.Rows[j]["nfk"];
                                }
                                catch
                                {
                                }
                            }
                            spaceDT.Clear();
                            ceilingDT.Clear();
                            groundDT.Clear();
                            wallDT.Clear();
                            if (dt.Rows[i]["location"].ToString().Trim() == "天花")
                            {
                                ceilingDT.Rows.Add();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["key"] = dt.Rows[i]["productCode"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["description"] = dt.Rows[i]["productName"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["size"] = dt.Rows[i]["Size"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["color"] = dt.Rows[i]["Color"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["quality"] = dt.Rows[i]["Quality"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["brand"] = dt.Rows[i]["Brand"].ToString().Trim();
                                ceilingDT.Rows[ceilingDT.Rows.Count - 1]["nfk"] = dt.Rows[i]["NFK"].ToString().Trim();
                            }
                            if (dt.Rows[i]["location"].ToString().Trim() == "地面")
                            {
                                groundDT.Rows.Add();
                                groundDT.Rows[groundDT.Rows.Count - 1]["key"] = dt.Rows[i]["productCode"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["description"] = dt.Rows[i]["productName"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["size"] = dt.Rows[i]["Size"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["color"] = dt.Rows[i]["Color"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["quality"] = dt.Rows[i]["Quality"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["brand"] = dt.Rows[i]["Brand"].ToString().Trim();
                                groundDT.Rows[groundDT.Rows.Count - 1]["nfk"] = dt.Rows[i]["NFK"].ToString().Trim();
                            }
                            if (dt.Rows[i]["location"].ToString().Trim() == "墙面")
                            {
                                wallDT.Rows.Add();
                                wallDT.Rows[wallDT.Rows.Count - 1]["key"] = dt.Rows[i]["productCode"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["description"] = dt.Rows[i]["productName"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["size"] = dt.Rows[i]["Size"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["color"] = dt.Rows[i]["Color"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["quality"] = dt.Rows[i]["Quality"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["brand"] = dt.Rows[i]["Brand"].ToString().Trim();
                                wallDT.Rows[wallDT.Rows.Count - 1]["nfk"] = dt.Rows[i]["NFK"].ToString().Trim();
                            }
                        }
                        if (i == dt.Rows.Count - 1)
                        {
                            for (int j = 0; j < (ceilingDT.Rows.Count > groundDT.Rows.Count ? ceilingDT.Rows.Count > wallDT.Rows.Count ? ceilingDT.Rows.Count : wallDT.Rows.Count : groundDT.Rows.Count > wallDT.Rows.Count ? groundDT.Rows.Count : wallDT.Rows.Count); j++)
                            {
                                dataDT.Rows.Add();
                                dataDT.Rows[dataDT.Rows.Count - 1]["space"] = spaceDT.Rows[j]["space"];
                                dataDT.Rows[dataDT.Rows.Count - 1]["place"] = spaceDT.Rows[j]["place"];
                                try
                                {
                                    dataDT.Rows[dataDT.Rows.Count - 1]["ckey"] = ceilingDT.Rows[j]["key"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["cdescription"] = ceilingDT.Rows[j]["description"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["csize"] = ceilingDT.Rows[j]["size"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["ccolor"] = ceilingDT.Rows[j]["color"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["cquality"] = ceilingDT.Rows[j]["quality"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["cbrand"] = ceilingDT.Rows[j]["brand"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["cnfk"] = ceilingDT.Rows[j]["nfk"];
                                }
                                catch
                                {
                                }
                                try
                                {
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gkey"] = groundDT.Rows[j]["key"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gdescription"] = groundDT.Rows[j]["description"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gsize"] = groundDT.Rows[j]["size"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gcolor"] = groundDT.Rows[j]["color"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gquality"] = groundDT.Rows[j]["quality"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gbrand"] = groundDT.Rows[j]["brand"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["gnfk"] = groundDT.Rows[j]["nfk"];
                                }
                                catch
                                {
                                }
                                try
                                {
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wkey"] = wallDT.Rows[j]["key"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wdescription"] = wallDT.Rows[j]["description"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wsize"] = wallDT.Rows[j]["size"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wcolor"] = wallDT.Rows[j]["color"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wquality"] = wallDT.Rows[j]["quality"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wbrand"] = wallDT.Rows[j]["brand"];
                                    dataDT.Rows[dataDT.Rows.Count - 1]["wnfk"] = wallDT.Rows[j]["nfk"];
                                }
                                catch
                                {
                                }
                            }
                        }
                        prePlace = curPlace;
                    }
                    for (int i = 0; i < dataDT.Rows.Count; i++)
                    {
                        showData += "<tr>";
                        //for (int j = 0; j < dt.Columns.Count; j++)
                        //{
                            //if (dt.Columns[[j].ColumnName == "space")
                            //{
                                if (i == 0)
                                {
                                    DataRow[] dr = dataDT.Select("space='" + dt.Rows[i]["space"].ToString().Trim() + "'");
                                    int tmpCount = dr.Length;
                                    showData += "<td rowspan='" + tmpCount + "'  style='text-align:center;'>" + dt.Rows[i]["space"].ToString().Trim() + "</td>";
                                    //continue;
                                }
                                else if (dt.Rows[i]["space"].ToString().Trim() != dt.Rows[i - 1]["space"].ToString().Trim())
                                {
                                    DataRow[] dr = dt.Select("space='" + dt.Rows[i]["space"].ToString().Trim() + "'");
                                    int tmpCount = dr.Length;
                                    showData += "<td rowspan='" + tmpCount + "'  style='text-align:center;'>" + dt.Rows[i]["space"].ToString().Trim() + "</td>";
                                    //continue;
                                }
                                //else
                                //{
                                //    continue;
                                //}
                            //}
                            //if (dt.Columns[j].ColumnName == "place")
                            //{
                                if (i == 0)
                                {
                                    DataRow[] dr = dataDT.Select("place='" + dt.Rows[i]["place"].ToString().Trim() + "'");
                                    int tmpCount = dr.Length;
                                    showData += "<td rowspan='" + tmpCount + "'  style='text-align:center;'>" + dt.Rows[i]["place"].ToString().Trim() + "</td>";
                                    //continue;
                                }
                                else if (dt.Rows[i]["place"].ToString().Trim() != dt.Rows[i - 1]["place"].ToString().Trim())
                                {
                                    DataRow[] dr = dt.Select("place='" + dt.Rows[i]["place"].ToString().Trim() + "'");
                                    int tmpCount = dr.Length;
                                    showData += "<td rowspan='" + tmpCount + "'  style='text-align:center;'>" + dt.Rows[i]["place"].ToString().Trim() + "</td>";
                                    //continue;
                                }
                                //else
                                //{
                                //    continue;
                                //}
                           // }
                        //}
                        //showData += "<td style='text-align:center;'>" + dataDT.Rows[i]["space"].ToString().Trim() + "</td>";
                        //showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["place"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["ckey"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["cdescription"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'>" + dataDT.Rows[i]["csize"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'>" + dataDT.Rows[i]["ccolor"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'>" + dataDT.Rows[i]["cquality"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'>" + dataDT.Rows[i]["cbrand"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'>" + dataDT.Rows[i]["cnfk"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align:center;'>" + dataDT.Rows[i]["gkey"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["gdescription"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["gsize"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["gcolor"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["gquality"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["gbrand"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["gnfk"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["wkey"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["wdescription"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["wsize"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["wcolor"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["wquality"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["wbrand"].ToString().Trim() + "</td>";
                        showData += "<td style='text-align: center;'>" + dataDT.Rows[i]["wnfk"].ToString().Trim() + "</td>";
                        showData += "</tr>";
                    }
                }

                //showData = ViewItem(pssid, isConstruction);

                string tbCalss = "printinnertable";
                //if (isConstruction == "3")
                //{
                //    tbCalss = "printinnertable3";
                //}
                //if (isConstruction == "4")
                //{
                //    tbCalss = "printinnertable2";
                //}
                trStr += "<table  height='100%' width='100%'  class='" + tbCalss + "' cellpadding='0' cellspacing='0' border='0'  style='border:0px;' >";
                trStr += "<thead>";
                trStr += "<tr>";
                trStr += "<th colspan='2'  style='width:120px;'>位置LOCATION</th>";
                trStr += "<th colspan='7' style=''>天花CEILING</th>";
                trStr += "<th colspan='7' style=''>地面GROUND</th>";
                trStr += "<th colspan='7' style=''>墙面WALL</th>";
                trStr += "</tr>";
                trStr += "</thead>";

                trStr += "<thead>";
                trStr += "<tr>";
                trStr += "<th style=''>空间</th>";
                trStr += "<th style=''>部位</th>";
                trStr += "<th style=''>编号KEY</th>";
                trStr += "<th style=''>内容DESCRIPTION</th>";
                trStr += "<th style=''>尺寸<br/>SIZE</th>";
                trStr += "<th style=''>颜色<br/>COLOR</th>";
                trStr += "<th style=''>质地<br/>QUALITY</th>";
                trStr += "<th style=''>品牌<br/>BRAND</th>";
                trStr += "<th style=''>阻燃性<br/>NFK</th>";
                trStr += "<th style=''>编号KEY</th>";
                trStr += "<th style=''>内容DESCRIPTION</th>";
                trStr += "<th style=''>尺寸<br/>SIZE</th>";
                trStr += "<th style=''>颜色<br/>COLOR</th>";
                trStr += "<th style=''>质地<br/>QUALITY</th>";
                trStr += "<th style=''>品牌<br/>BRAND</th>";
                trStr += "<th style=''>阻燃性<br/>NFK</th>";
                trStr += "<th style=''>编号KEY</th>";
                trStr += "<th style=''>内容DESCRIPTION</th>";
                trStr += "<th style=''>尺寸<br/>SIZE</th>";
                trStr += "<th style=''>颜色<br/>COLOR</th>";
                trStr += "<th style=''>质地<br/>QUALITY</th>";
                trStr += "<th style=''>品牌<br/>BRAND</th>";
                trStr += "<th style=''>阻燃性<br/>NFK</th>";
                trStr += "</tr>";
                trStr += "</thead>";
                trStr += showData;
                trStr += "</table>";
            }
        }
    }
}