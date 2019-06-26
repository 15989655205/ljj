using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.IO;


namespace Maticsoft.DBUtility
{
    public class WcPage:MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            //if (WcUser.CheckLogin(this))
            //{
              
            //}
            //base.OnLoad(e);
        }

        protected override void OnInit(EventArgs e)
        {
            if (WcUser.CheckLogin(this))
            {

            }
            base.OnLoad(e);
        }

        /// <summary>
        /// 页面编号
        /// </summary>
        public string PageID
        {
            get{return(ViewState["PageID"]??"")as string;}
            set { ViewState["PageID"] = value; }
        }
        //查询页面按钮
        //public List<WcUser.Cmd> GetCmds(string page_id)
        //{
        //    WcUser.LoginInfo li = WcUser.GetLoginInfo(this) as WcUser.LoginInfo;
        //    List<WcUser.Permisson> perssions = WcCache.GetCache(this, li.LoginID) as List<WcUser.Permisson>;
        //    WcUser.Permisson pagePermission = perssions.Find(p => p.PageID == page_id);
        //    if (pagePermission != null)
        //        return pagePermission.Cmds;
        //    else
        //        return null;
        //}

        ////检查对某页面是否有编辑权限
        //public bool CheckEdit(string page_id)
        //{
        //    List<WcUser.Cmd> cmds = this.GetCmds(page_id);
        //    if (cmds != null)
        //        return cmds.Find(p => p.CmdID == "2") != null;
        //    else
        //        return false;
        //}
    }
}
