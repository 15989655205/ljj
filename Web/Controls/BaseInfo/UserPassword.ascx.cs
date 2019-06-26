using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using Maticsoft.Model;

namespace Maticsoft.Web.Controls.BaseInfo
{
    public partial class UserPassword : System.Web.UI.UserControl
    {
        public string userName;
        public string userID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["login"]!=null)
            {
                Model.BaseUser baseUser = (Model.BaseUser)Session["login"];
                userName = baseUser.UserName;
                userID = baseUser.UserID.ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('登录信息安全时限过期，请重新登录！');top.location='../Login.aspx'</script>");
            }
        }
    }
}