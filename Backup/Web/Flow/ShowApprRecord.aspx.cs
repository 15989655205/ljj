using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Maticsoft.Web.Flow
{
    public partial class ShowApprRecord : System.Web.UI.Page
    {
        protected string afsid = "";
        protected DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                afsid = Request.QueryString["af_sid"].Trim();
                dt = new BLL.Common().GetList("select * from request_form_appr_record where af_sid="+afsid+" order by create_date asc").Tables[0];
            }
        }
    }
}