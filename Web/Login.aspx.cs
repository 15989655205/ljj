using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;
using System.Data;

namespace Maticsoft.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected string htmlstring = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WCDataProvider db = new WCDataProvider();
                WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_ad_img", WCDataAction.Query3);
                if (db.Execute(dsp).ExecuteState)
                {
                    ad_img.DataSource = dsp.OutputDataSet.Tables[0];
                    ad_img.DataBind();
                }
                string table = " notice ";
                string sort = " CreateTime ";
                string show = " id, title, summary ";
                int total = 0;
                DataTable dt = DbHelperSQL.GetList_ProcPage(table, sort, show, 1, 4, out total, "desc", " 1=1 ").Tables[0];                
                foreach (DataRow dr in dt.Rows)
                {
                    htmlstring += "<li><a href='ADAndNotice/noticeview.aspx?id=" + dr["id"] + "' target='_blank' title='" + dr["summary"] + "'>" + dr["title"] + "</a></li>";
                }                
            }
        }
    }
}