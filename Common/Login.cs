using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Maticsoft.Common
{
    public class Login
    {
        public static string _login = "login";

        //登陆信息
        [Serializable]
        public class LoginInfo
        {

            /// <summary>
            /// 登陆唯一编号
            /// </summary>
            public string ID { get; set; }

            //登陆id
            public string LoginID { get; set; }

            //姓名
            public string Name { get; set; }

            public List<string> Roles { get; set; }

            //权限
            public List<Permisson> Permission { get; set; }
        }

        //权限信息
        [Serializable]
        public class Permisson
        {
            public string MenuID { get; set; }

            public string ParentMenuID { get; set; }

            public string MenuName { get; set; }

            public string PageID { get; set; }

            public List<Cmd> Cmds { get; set; }

            public string LinkUrl { get; set; }

            public string Target { get; set; }

            public string Css { get; set; }

            public bool IsMenu { get; set; }

        }

        //按钮
        [Serializable]
        public class Cmd
        {
            public string CmdID { get; set; }

            public string CmdName { get; set; }

            public bool IsPermission { get; set; }

            public string ImageUrl { get; set; }
        }

        /// <summary>
        /// 检查登陆
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static bool CheckLogin(Page page)
        {
            if (page.Session[_login] == null)
            {
                //page.Response.Redirect("~/Login.aspx");
                page.Response.Write("<script type='text/javascript'>window.top.location.href='/Login.aspx';</script>");
                page.Response.End();
                return false;
            }
            else
            {
                return true;
            }
        }

        //设置登陆
        public static void SetLoginInfo(Page page, LoginInfo li)
        {
            WcCache1.AddCache(page, li.LoginID, li.Permission);
            li.Permission = null;
            page.Session[_login] = li;
        }

        //用户名
        public static string GetUserName(Page page)
        {
            return (page.Session[_login] as LoginInfo).LoginID;
        }
        //清空登陆信息
        public static void ClearLoginInfo(Page page)
        {
            page.Session[_login] = null;
        }
        //获取登陆信息
        public static LoginInfo GetLoginInfo(Page page)
        {
            if (CheckLogin(page))
                return page.Session[_login] as LoginInfo;
            else
                return null;
        }

        /// <summary>
        /// 登陆角色信息
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static List<string> GetRoles(Page page)
        {
            LoginInfo li = GetLoginInfo(page);
            if (li != null)
                return li.Roles;
            else
                return new List<string>();
        }
    }
}
