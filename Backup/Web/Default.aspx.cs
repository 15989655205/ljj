using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.DBUtility;

namespace Maticsoft.Web
{
    public partial class Default : Page
    {
        public string menu = "";
        private StringBuilder sb = new StringBuilder();
        private bool isopen = true;
        protected bool showMainPage = false;
        protected Model.BaseUser buModel = new Model.BaseUser();
        public string value0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["login"] == null)
                {
                    string tmp=DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss").Trim();
                    Response.Write("<script type='text/javascript'>window.top.location.href='Login.aspx';</script>");
                    return;
                }
                //Model.BaseUser bu = (Model.BaseUser)Session["login"];
                //Response.Write("<script>alert("+bu.UserID+");</script>");
                buModel = (Model.BaseUser)Session["login"];
                //BLL.BaseMenu bmBLL = new BLL.BaseMenu();
                //DataTable dt =bmBLL.GetList("1=1 order by idx asc").Tables[0];//重组树状数据源，所以此处的SQL可以不用排序  
               //alter by zxf 
                value0 = buModel.Value0;
                WCDataProvider db = new WCDataProvider();
                WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_permission", WCDataAction.Query3);
                dsp.InputPars.Add("@RolseIDs", buModel.Roles);
                DataTable dt = new DataTable();
                if (db.Execute(dsp).ExecuteState)
                {
                    dt = dsp.OutputDataSet.Tables[0];
                }

                menu = GetTreeList(dt, "MenuID", "ParentMenuID", 0, "MenuID");
                if (menu.Length > 0)
                {
                    menu = "[" + menu.Substring(0, menu.Length - 1) + "]";
                }
                else
                {
                    menu = "[]";
                }

                showMainPage = new BLL.BaseRolePagePermission().exists(buModel.Roles, 9, 9);
            }
        }

        /// <summary>    
        /// dt 要从中生成树状数据源    
        /// IdField ID字段列名    
        /// ParentField 父级ID列名    
        /// Pid 父级ID值    
        /// OrderField 排序字段    
        /// </summary>  
        public string GetTreeList(DataTable dt, string IdField, string ParentField, int Pid, string OrderField = "")
        {
            //DataTable newDT = dt.Clone();// 克隆dt 的结构，包括所有 dt 架构和约束,并无数据；  
            DataRow[] rows;

            /* 
             * 如果父级pid等于本ID时表示顶级分类的情况 用以下语句 
            */
            //if (Pid == 0)//选出顶级的类别  
            //{
            //    rows = dt.Select(ParentField + "=" + Pid, OrderField); // 从dt 中查询符合条件的记录（选出所有大类）；  
            //}
            //else//选出属于所传ID的子类  
            //{
            //    rows = dt.Select(ParentField + "<>" + IdField + " and " + ParentField + "=" + Pid, OrderField); // 从dt 中查询符合条件的记录（选出大类pid的子类）；  
            //}
            if (Pid == 0)
            {
                string tmp = "IsNull([ParentMenuID],0)=0";
                rows = dt.Select(tmp);
            }
            else
            {
                rows = dt.Select(ParentField + "=" + Pid);
            }

            /* 
             * 如果父ID为0的时候表示顶级分类,用以下语句 
             * rows = dt.Select(ParentField + "=" + Pid, OrderField);  
            */


            if (rows.Length > 0)
            {
                foreach (DataRow row in rows)  // 将查询的结果添加到dt中；  
                {
                    
                    //newDT.Rows.Add(row.ItemArray);
                    //sb.Append("{id:" + row["MenuID"].ToString() + ", pId:" + row["ParentMenuID"].ToString() + ", name:\"" + row["MenuName"].ToString() + "\",icon:\"" + row["Value1"].ToString() + "\"},");
                    int innerpid = int.Parse(row["MenuID"].ToString());
                    DataRow[] Childows = dt.Select(ParentField + "=" + innerpid);//选出子类  
                    if (Childows.Length > 0)//如果存在子类，对子类进行递归  
                    {
                        if (isopen)
                        {
                            sb.Append("{id:" + row["MenuID"].ToString().Trim() + ", pId:" + (row["ParentMenuID"].ToString().Trim() == "" ? 0:row["ParentMenuID"]) + ", name:\"" + row["MenuName"].ToString().Trim() + "\",icon:\"" + row["Value1"].ToString().Trim() + "\",open:true},");
                            isopen = false;
                        }
                        else
                        {
                            sb.Append("{id:" + row["MenuID"].ToString().Trim() + ", pId:" + (row["ParentMenuID"].ToString().Trim() == "" ? 0 : row["ParentMenuID"]) + ", name:\"" + row["MenuName"].ToString().Trim() + "\",icon:\"" + row["Value1"].ToString().Trim() + "\",open:false},");
                        }
                        //sb.Append("{id:" + row["MenuID"].ToString().Trim() + ", pId:" + row["ParentMenuID"].ToString().Trim() + ", name:\"" + row["MenuName"].ToString().Trim() + "\",icon:\"" + row["Value1"].ToString().Trim() + "\",open:false},");
                        //DataTable innerDT = GetTreeList(dt, IdField, ParentField, innerpid, OrderField);//获取子类DataTable  
                        //foreach (DataRow innerrow in innerDT.Rows)//对子类的DataTable添加进总数据源  
                        //{
                        //    newDT.Rows.Add(innerrow.ItemArray);
                        //}
                        GetTreeList(dt, IdField, ParentField, innerpid, OrderField);
                    }
                    else
                    {
                        sb.Append("{id:" + row["MenuID"].ToString().Trim() + ", pId:" + row["ParentMenuID"].ToString().Trim() + ", name:\"" + row["MenuName"].ToString().Trim() + "\",icon:\"" + row["Value1"].ToString().Trim() + "\",file:\"" + row["LinkUrl"].ToString().Trim() + "\"},");
                    }
                }
            }
            //dt.Dispose();//现不清楚是否需要该语句，执行该语句也正常显示  
            return sb.ToString();
        } 
    }
}
