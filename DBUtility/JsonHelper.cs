using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.IO;
using System.ServiceModel.Web;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace Maticsoft.DBUtility
{
    public partial class JsonHelper
    {
        #region
        public static string DataConversion(string data)
        {
            string str = data;

            str = str.Replace("\\", "\\\\");// 反斜杠\

            str = str.Replace("'", "\'");// 单引号'
            str = str.Replace("\"", "\\\"");// 双引号"      
            str = str.Replace("\n", "\\n");// 换行符n
            str = str.Replace("\r", "\\r");// 回车符r
            str = str.Replace("\t", "\\t");// 横向跳格 (Ctrl-I)
            str = str.Replace("\b", "\\b");// 退格符b
            str = str.Replace("\f", "\\f");// 换页符f
            return str;
        }
        #endregion

        #region
        public static string DataTable2Json_Datagrid(DataTable dt, int total)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"total\":" + total.ToString() + ",");
            jsonBuilder.Append("\"rows\"");
            jsonBuilder.Append(":[");
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonBuilder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonBuilder.Append("\"");
                        jsonBuilder.Append(dt.Columns[j].ColumnName);
                        jsonBuilder.Append("\":\"");

                        string str = dt.Rows[i][j].ToString().Trim();
                        str = DataConversion(dt.Rows[i][j].ToString().Trim());

                        jsonBuilder.Append(str);
                        jsonBuilder.Append("\",");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        #endregion

        #region JQGrid
        public static string JsonForJqgrid(DataTable dt, int total)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.Append("\"page\":1,\"total\":" + total + ",\"records\":" + dt.Rows.Count + ",\"rows\"");
            jsonBuilder.Append(":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
        #endregion

        public static string DataTable2Json_Combo(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                StringBuilder jsonBuilder = new StringBuilder();
                jsonBuilder.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    jsonBuilder.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonBuilder.AppendFormat("\"{0}\":\"{1}\",", dt.Columns[j].ColumnName, DataConversion(dt.Rows[i][j].ToString().Trim()));
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("},");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("]");
                return jsonBuilder.ToString();
            }
            else
            {
                return "[{}]";
            }
        }

        /// <summary>
        /// 生成一个CheckBoxList的JSON,DataTable要手动生成
        /// </summary>
        /// <param name="dt">数据源,datatable包含三个列,分别是'id'、‘text’、‘checked’</param>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string DataTable2Json_Checkboxlist(DataTable dt)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder jsonBuilder = new StringBuilder();
                    jsonBuilder.Append("[");
                    jsonBuilder.Append("{");
                    jsonBuilder.AppendFormat("\"id\":\"0\",\"text\":\"全选\",\"children\":[");
                    //jsonBuilder.Append("}");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //jsonBuilder.Append(",");
                        jsonBuilder.Append("{");
                        jsonBuilder.AppendFormat("\"id\":\"{0}\",\"text\":\"{1}\",\"checked\":{2}", DataConversion(dt.Rows[i]["id"].ToString()), DataConversion(dt.Rows[i]["text"].ToString()), DataConversion(dt.Rows[i]["checked"].ToString()));
                        //jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                        jsonBuilder.Append("},");
                        //jsonBuilder.Append("}");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("]");
                    jsonBuilder.Append("}]");
                    return jsonBuilder.ToString();
                }
                else
                {
                    return "[{}]";
                }
            }
            catch
            {
                return "[{}]";
            }
        }

        public static string DataTable2List(DataTable dt)
        {
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder jsonBuilder = new StringBuilder();
                    jsonBuilder.Append("[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        jsonBuilder.Append("{");
                        jsonBuilder.AppendFormat("\"id\":\"{0}\",\"text\":\"{1}\"", DataConversion(dt.Rows[i]["id"].ToString()), DataConversion(dt.Rows[i]["text"].ToString()));
                        jsonBuilder.Append("},");
                    }
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                    jsonBuilder.Append("]");
                    return jsonBuilder.ToString();
                }
                else
                {
                    return "[{}]";
                }
            }
            catch
            {
                return "[{}]";
            }
        }

        /// <summary>
        /// 根据DataTable生成Json树结构
        /// </summary>
        /// <param name="tabel">数据源</param>
        /// <param name="idCol">ID列</param>
        /// <param name="txtCol">Text列</param>
        /// <param name="rela">关系字段</param>
        /// <param name="pId">父ID</param>
        StringBuilder result = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        public string DataTable2Json_Tree(DataTable tabel, string idCol, string txtCol, string rela, object pId, string openStatus, string statusCol)
        {
            GetTreeJsonByTable(tabel, idCol, txtCol, rela, pId, openStatus, statusCol);
            return result.ToString();
        }



        public void GetTreeJsonByTable(DataTable tabel, string idCol, string txtCol, string rela, object pId, string openStatus, string statusCol)
        {
            result.Append(sb.ToString());
            sb.Remove(0, sb.Length);
            sb.Append("[");
            string filer = string.Format("{0}='{1}'", rela, pId);
            if (tabel.Rows.Count > 0)
            {

                DataRow[] rows = tabel.Select(filer);
                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        string oStatus = openStatus;
                        try
                        {
                            if (row[statusCol] == null)
                            {
                            }
                        }
                        catch
                        {
                        }
                        sb.Append("{\"id\":\"" + row[idCol] + "\",\"text\":\"" + row[txtCol] + "\",\"state\":\"" + oStatus + "\"");
                        if (tabel.Select(string.Format("{0}='{1}'", rela, row[idCol])).Length > 0)
                        {
                            sb.Append(",\"children\":");
                            GetTreeJsonByTable(tabel, idCol, txtCol, rela, row[idCol], openStatus, statusCol);
                            result.Append(sb.ToString());
                            sb.Remove(0, sb.Length);
                        }
                        result.Append(sb.ToString());
                        sb.Remove(0, sb.Length);
                        sb.Append("},");
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                }

            }
            sb.Append("]");
            result.Append(sb.ToString());
            sb.Remove(0, sb.Length);
        }

        /// <summary>
        /// 编辑返回json
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="displayCount"></param>
        /// <returns></returns>
        public static string DataTable2Form(DataTable dt, string PrefixCode)
        {
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling        
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Columns[j].DataType.Name == "Boolean")
                        {
                            JsonString.Append("\"" + PrefixCode + dt.Columns[j].ColumnName.ToString() + "\":\"" + DataConversion(dt.Rows[i][j].ToString().ToLower()) + "\",");
                        }
                        else if (dt.Columns[j].DataType.Name == "DateTime")
                        {
                            JsonString.Append("\"" + PrefixCode + dt.Columns[j].ColumnName.ToString() + "\":\"" + Convert.ToDateTime(dt.Rows[i][j]).ToString("yyyy-MM-dd") + "\",");
                        }
                        else
                        {
                            JsonString.Append("\"" + PrefixCode + dt.Columns[j].ColumnName.ToString() + "\":\"" + DataConversion(dt.Rows[i][j].ToString()) + "\",");
                        }
                    }
                    JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    JsonString.Append("},");
                }
                JsonString = JsonString.Remove(JsonString.Length - 1, 1);

                return JsonString.ToString();
            }
            else
            {
                return null;
            }

        }

        public static string DT2JsChart(DataTable dt, string type)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{");

                JsonString.Append("\"JSChart\" : {");
                JsonString.Append("\"datasets\" : [");
                JsonString.Append("{");
                JsonString.Append("\"type\" :\"" + type + "\","); // "type" : "pie",
                JsonString.Append("\"data\" : [");



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    JsonString.Append("\"unit\" : \"" + dt.Rows[i][0].ToString() + "\",");
                    JsonString.Append("\"value\" :\" " + dt.Rows[i][1].ToString() + "\"");
                    JsonString.Append("}");
                    if (i < dt.Rows.Count - 1) JsonString.Append(",");
                }
                JsonString.Append("]");
                JsonString.Append("}");
                JsonString.Append("]");
                JsonString.Append("}");
                JsonString.Append("}");

                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// TreeGrid的Json
        /// </summary>
        /// <param name="dt">要转换表格数据</param>
        /// <param name="type">状态，0为收起，非0为展开</param>
        /// <param name="pidName">父字段</param>
        /// <returns></returns>
        public static string DT2GridTree(DataTable dt, int type, string pidName)
        {
            StringBuilder JsonString = new StringBuilder();
            JsonString.Append("{\"total\":" + dt.Rows.Count + ",\"rows\":[");
            if (dt != null && dt.Rows.Count > 0)
            {
                //JsonString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + DataConversion(dt.Rows[i][j].ToString()) + "\",");
                    }
                    if (dt.Rows[i][pidName].ToString().Trim() != "0")
                    {
                        JsonString.Append("\"_parentId\":\"" + DataConversion(dt.Rows[i][pidName].ToString()) + "\",");
                    }
                    if (type == 0)
                    {
                        JsonString.Append("\"state\":\"closed\"");
                    }
                    else
                    {
                        JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    }
                    JsonString.Append("},");
                }
                if (dt.Rows.Count > 0)
                {
                    JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                }
                //JsonString.Append("]");
                //return JsonString.ToString();
            }
            else
            {
                //return null;
            }
            //JsonString = JsonString.Remove(JsonString.Length - 1, 1);
            JsonString.Append("]}");
            return JsonString.ToString();
        }

        public static string DT2GridTree(DataTable dt, string type, string pidName)
        {
            StringBuilder JsonString = new StringBuilder();
            JsonString.Append("{\"total\":" + dt.Rows.Count + ",\"rows\":[");
            if (dt != null && dt.Rows.Count > 0)
            {
                //JsonString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + DataConversion(dt.Rows[i][j].ToString()) + "\",");
                    }
                    if (dt.Rows[i][pidName].ToString().Trim() != "0")
                    {
                        JsonString.Append("\"_parentId\":\"" + DataConversion(dt.Rows[i][pidName].ToString()) + "\",");
                    }
                    if (type == "p")
                    {
                        JsonString.Append("\"state\":\"closed\"");
                    }
                    else
                    {
                        JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    }
                    JsonString.Append("},");
                }
                if (dt.Rows.Count > 0)
                {
                    JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                }
                //JsonString.Append("]");
                //return JsonString.ToString();
            }
            else
            {
                //return null;
            }
            //JsonString = JsonString.Remove(JsonString.Length - 1, 1);
            JsonString.Append("]}");
            return JsonString.ToString();
        }

        public static string DT2GridTree(DataTable dt, string type, string pidName,int total)
        {
            StringBuilder JsonString = new StringBuilder();
            JsonString.Append("{\"total\":" + total.ToString() + ",\"rows\":[");
            if (dt != null && dt.Rows.Count > 0)
            {
                //JsonString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + DataConversion(dt.Rows[i][j].ToString()) + "\",");
                    }
                    if (dt.Rows[i][pidName].ToString().Trim() != "0")
                    {
                        JsonString.Append("\"_parentId\":\"" + DataConversion(dt.Rows[i][pidName].ToString()) + "\",");
                    }
                    if (type == "p")
                    {
                        JsonString.Append("\"state\":\"closed\"");
                    }
                    else
                    {
                        JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    }
                    JsonString.Append("},");
                }
                if (dt.Rows.Count > 0)
                {
                    JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                }
                //JsonString.Append("]");
                //return JsonString.ToString();
            }
            else
            {
                //return null;
            }
            //JsonString = JsonString.Remove(JsonString.Length - 1, 1);
            JsonString.Append("]}");
            return JsonString.ToString();
        }

        public static string DT2GTree(DataTable dt, string type, string pidName)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + DataConversion(dt.Rows[i][j].ToString()) + "\",");
                    }
                    JsonString.Append("\"_parentId\":\"" + DataConversion(dt.Rows[i][pidName].ToString()) + "\",");
                    if (type == "p")
                    {
                        JsonString.Append("\"state\":\"closed\"");
                    }
                    else
                    {
                        JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    }
                    JsonString.Append("},");
                }
                JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string DT2GTree1(DataTable dt, string idName, string pidName)
        {
            string JsonString = "{\"total\":" + dt.Rows.Count + ",\"rows\":[";
            foreach (DataRow dr in dt.Rows)
            {
                JsonString += "{";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dr.Table.Columns[i].ColumnName == idName)
                    {
                        JsonString += "\"" + dr.Table.Columns[i].ColumnName + "\":" + dr[i] + ",";
                    }
                    JsonString += "\"" + dr.Table.Columns[i].ColumnName + "\":\"" + dr[i] + "\",";
                }
                JsonString += "\"_parentId\":" + dr[pidName] + ",";

                //if (dt.Select(idName + "=" + dr[pidName]).Length > 0)
                //{
                //    JsonString += "\"_parentId\":" + dr[pidName] + ",";
                //}

                //if (dt.Select(pidName + "=" + dr[idName]).Length > 0)
                //{
                //    JsonString += "\"state\":\"closed\",";
                //}

                JsonString = JsonString.Remove(JsonString.Length - 1) + "},";
            }
            JsonString = JsonString.Remove(JsonString.Length - 1) + "]}";
            return JsonString;
        }


        /// <summary>
        /// 编辑返回json
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="displayCount"></param>
        /// <returns></returns>
        public static string CreateJsonOne(DataTable dt, string PrefixCode)
        {
            StringBuilder JsonString = new StringBuilder();
            //Exception Handling        
            if (dt != null && dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            if (dt.Columns[j].DataType.Name == "Boolean")
                            {
                                JsonString.Append(PrefixCode + dt.Columns[j].ColumnName.ToString() + ":" + "\"" + dt.Rows[i][j].ToString().ToLower() + "\",");
                            }
                            else if (dt.Columns[j].DataType.Name == "DateTime")
                            {
                                JsonString.Append(PrefixCode + dt.Columns[j].ColumnName.ToString() + ":" + "\"" + Convert.ToDateTime(dt.Rows[i][j]).ToString("yyyy-MM-dd") + "\",");
                            }
                            else
                            {
                                JsonString.Append(PrefixCode + dt.Columns[j].ColumnName.ToString() + ":" + "\"" + DataConversion(dt.Rows[i][j].ToString()) + "\",");
                            }
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            //判断是不是布尔型数据
                            if (dt.Columns[j].DataType.Name == "Boolean")
                            {
                                JsonString.Append(PrefixCode + dt.Columns[j].ColumnName.ToString() + ":" + "\"" + dt.Rows[i][j].ToString().ToLower() + "\"");
                            }
                            //判断是不是日期格式，如果是就把时分秒格式掉
                            else if (dt.Columns[j].DataType.Name == "DateTime")
                            {
                                JsonString.Append(PrefixCode + dt.Columns[j].ColumnName.ToString() + ":" + "\"" + Convert.ToDateTime(dt.Rows[i][j]).ToString("yyyy-MM-dd") + "\"");
                            }
                            else
                            {
                                JsonString.Append(PrefixCode + dt.Columns[j].ColumnName.ToString() + ":" + "\"" + DataConversion(dt.Rows[i][j].ToString()) + "\"");
                            }
                        }
                    }

                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }

                return JsonString.ToString();
            }
            else
            {
                return null;
            }

        }


        /// <summary>
        /// 返回[{value:'',text:''},{value:'',text:''}]的json ...jimmy2012/10/19
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="value"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string DataTable2Json_ValueText(DataTable dt, string value, string text)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{\"value\":\"" + Convert.ToString(dt.Rows[i][value]) + "\",\"text\":\"" + Convert.ToString(dt.Rows[i][text]) + "\"},");
            }
            string retVal = jsonBuilder.ToString();
            if (!string.IsNullOrEmpty(retVal))
            {
                return "[" + retVal.Remove(retVal.Length - 1) + "]";
            }
            else
            {
                return "";
            }
        }






        public static string DataTable2Josn_UserTree(DataTable dt, string cmpyIdF, string cmpyNMF, string deptIdF, string deptNMF, string userIdF, string userNMF)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            string split = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["split"]);

            string cmpyIdB = "";
            string deptIdB = "";


            string cmpyId = "";
            string cmpyNM = "";
            string deptId = "";
            string deptNM = "";
            string userId = "";
            string userNM = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                cmpyId = Convert.ToString(dt.Rows[i][cmpyIdF]);
                cmpyNM = Convert.ToString(dt.Rows[i][cmpyNMF]);

                deptId = Convert.ToString(dt.Rows[i][deptIdF]);
                deptNM = Convert.ToString(dt.Rows[i][deptNMF]);

                userId = Convert.ToString(dt.Rows[i][userIdF]);
                userNM = Convert.ToString(dt.Rows[i][userNMF]);

                //创建公司节点
                if (cmpyIdB != cmpyId)
                {
                    jsonBuilder.Append("{\"id\":\"Cmpy" + split + cmpyId + "\",");
                    jsonBuilder.Append("\"text\":\"" + cmpyNM + "\",");
                    jsonBuilder.Append("\"attributes\":{\"NodeType\":\"Cmpy\",\"CmpyId\":\"" + cmpyId + "\",\"CmpyNM\":\"" + cmpyNM + "\"},");
                    jsonBuilder.Append("\"children\":[");
                    cmpyIdB = cmpyId;
                }

                //创建部门节点
                if (deptIdB != deptId)
                {
                    jsonBuilder.Append("{\"id\":\"Dept" + split + cmpyId + split + deptId + "\",");
                    jsonBuilder.Append("\"text\":\"" + deptNM + "\",");
                    jsonBuilder.Append("\"attributes\":{\"NodeType\":\"Dept\",\"DeptId\":\"" + deptId + "\",\"DeptNM\":\"" + deptNM + "\",\"CmpyId\":\"" + cmpyId + "\",\"CmpyNM\":\"" + cmpyNM + "\"},");
                    jsonBuilder.Append("\"children\":[");
                    deptIdB = deptId;
                }


                //创建用户节点
                jsonBuilder.Append("{\"id\":\"User" + split + cmpyId + split + deptId + split + userId + "\",");
                jsonBuilder.Append("\"text\":\"" + userNM + "\",");
                jsonBuilder.Append("\"iconCls\":\"icon-user\",");
                jsonBuilder.Append("\"attributes\":{\"NodeType\":\"User\",\"UserSID\":\"" + userId + "\",\"UserNM\":\"" + userNM + "\",\"DeptId\":\"" + deptId + "\",\"DeptNM\":\"" + deptNM + "\",\"CmpyId\":\"" + cmpyId + "\",\"CmpyNM\":\"" + cmpyNM + "\"}}");


                //根据下一条记录来关闭公司和部门节点
                if (i < dt.Rows.Count - 1)
                {
                    //如果下一条记录部门起变化
                    if (deptId != Convert.ToString(dt.Rows[i + 1][deptIdF]))
                    {
                        //如果下一条记录公司起变化
                        if (cmpyId != Convert.ToString(dt.Rows[i + 1][cmpyIdF]))
                        {
                            //部门
                            jsonBuilder.Append("]}");
                            //公司
                            jsonBuilder.Append("]},");
                        }
                        else
                        {
                            //部门
                            jsonBuilder.Append("]},");
                        }
                    }
                    else
                    {
                        //用户
                        jsonBuilder.Append(",");
                    }
                }


                if (i == dt.Rows.Count - 1)
                {
                    //部门
                    jsonBuilder.Append("]}");
                    //公司
                    jsonBuilder.Append("]}");
                }
            }

            return "[" + jsonBuilder.ToString() + "]";
        }


        /// <summary>
        /// 把datatable转为josn
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTable2Josn(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            //   sb.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sb.Append("\"" + dt.Columns[j].ColumnName + "\":\"" + JsonHelper.DataConversion(dt.Rows[i][j].ToString().Trim()) + "\",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("},");
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            //   sb.Append("]");
            return "[" + sb.ToString() + "]";
        }


        /// <summary>
        /// 将table转换为treegrid的json形式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="type"></param>
        /// <param name="pidName"></param>
        /// <returns></returns>
        public string DT2GTree(DataTable dt, string pidName)
        {
            StringBuilder JsonString = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                //JsonString.Append("{\"total:\":");
                ////JsonString.Append(dt.Rows.Count.ToString());
                //JsonString.Append(total.ToString());
                //JsonString.Append(",");
                //JsonString.Append("\"rows\":");
                JsonString.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    if (int.Parse(dt.Rows[i]["child"].ToString().Trim()) > 0)
                        JsonString.Append("\"iconCls\":\"icon-folder\",");
                    else
                        JsonString.Append("\"iconCls\":\"icon-ffile\",");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() + "\":\"" + DBUtility.JsonHelper.DataConversion(dt.Rows[i][j].ToString()) + "\",");
                    }
                    if (Convert.ToInt16(dt.Rows[i][pidName]) != 0)
                    {
                        JsonString.Append("\"_parentId\":\"" + DBUtility.JsonHelper.DataConversion(dt.Rows[i][pidName].ToString()) + "\",");

                    }
                    //if (type == "p")
                    //{
                    //    JsonString.Append("\"state\":\"closed\"");
                    //}
                    //else
                    //{
                    //    JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    //}
                    if (Convert.ToInt32(dt.Rows[i]["child"]) > 0)
                    {
                        JsonString.Append("\"state\":\"closed\"");
                    }
                    else
                    {
                        JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                    }


                    JsonString.Append("},");
                }
                JsonString = JsonString.Remove(JsonString.Length - 1, 1);
                JsonString.Append("]");
                //JsonString.Append("}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }


        #region Json反序列
        //public static string Serialize<T>(T obj)
        //{
        //    System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
        //    MemoryStream ms = new MemoryStream();
        //    serializer.WriteObject(ms, obj);
        //    string retVal = Encoding.Default.GetString(ms.ToArray());
        //    ms.Dispose();
        //    return retVal;
        //}

        //public static T Deserialize1<T>(string json)
        //{
        //    T obj = Activator.CreateInstance<T>();
        //    MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
        //    System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
        //    obj = (T)serializer.ReadObject(ms);
        //    ms.Close();
        //    ms.Dispose();
        //    return obj;
        //}



        #endregion
    }

    public static class JsonSerializerHelper
    {
        public static List<T> JSONStringToList<T>(this string JsonStr)
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);
            return objs;
        }


        public static T Deserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                //System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }


    }//end public static class JsonHelper11




}

