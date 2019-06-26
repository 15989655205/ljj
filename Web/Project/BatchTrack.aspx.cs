using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Maticsoft.Web.Project
{
    public partial class BatchTrack : System.Web.UI.Page
    {
        protected string sid = "", pssid = "", pname = "", pcode = "", stageName = "", column = "", frozencolumns="",psid = "", sDateStr = "", eDateStr = "",showContentPro="";
        protected string showContent = "", showItem = "", isConstruction = "", is_system="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pssid = Request.Params["ps_sid"] == null ? "" : Request.Params["ps_sid"].Trim();
                CommonClass.ProjectContent.GetProjectContent(pssid, ref isConstruction, out stageName, out pname, out psid, out sDateStr, out eDateStr, out showContent, out showItem, out frozencolumns, out column);
            }

        }
    }
}