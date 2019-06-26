using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;
using System.Data;

namespace Maticsoft.Web.Controls
{
    public partial class toolbar : System.Web.UI.UserControl
    {
        /// <summary>
        /// 页面ID
        /// </summary>
        public string PageID { get; set; }

        /// <summary>
        /// 按钮id
        /// </summary>
        public string IDS { get; set; }

        protected string jsValue = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (PageID == null)
                {
                    string url= HttpContext.Current.Request.Url.AbsolutePath.Trim();
                    if (url.IndexOf('/') == 0)
                    {
                        url = url.Substring(1);
                    }
                    DataTable dt = new DataTable();
                    try
                    {
                        dt = new BLL.Common().GetList("select PageID from BaseMenu where LinkUrl like '%" + url + "%'").Tables[0];
                        PageID = dt.Rows[0]["PageID"].ToString().Trim();
                    }
                    catch
                    {
                    }
                }
                WCDataProvider db = new WCDataProvider();
                WCDataStoreProcedures dsp = new WCDataStoreProcedures("sp_permission", WCDataAction.Query4);
                dsp.InputPars.Add("@PageID", PageID);
                dsp.InputPars.Add("@RolseIDs", (Session["login"] as Model.BaseUser).Roles);
                if (db.Execute(dsp).ExecuteState)
                {
                    jsValue = dsp.OutputPars["@strOut"].ToString();
                }
                jsValue = string.IsNullOrWhiteSpace(jsValue) ? IDS : jsValue;
            }
        }
    }
}