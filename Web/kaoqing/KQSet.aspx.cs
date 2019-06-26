using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.BLL;

namespace Maticsoft.Web.kaoqing
{
    public partial class KQSet : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //SDLX.Common.PublicMethod.CheckSession();

                Maticsoft.BLL.ERPKaoQinSetting MyModel = new Maticsoft.BLL.ERPKaoQinSetting();
                MyModel.GetModel(int.Parse(Maticsoft.DBUtility.DbHelperSQL1.GetSHSLInt("select top 1 [ID] FROM ERPKaoQinSetting")));

                string GuiDingTime1 = MyModel.GuiDingTime1;
                this.DropDownList1.SelectedValue = GuiDingTime1.Split(':')[0];
                this.DropDownList2.SelectedValue = GuiDingTime1.Split(':')[1];
                string GuiDingTime2 = MyModel.GuiDingTime2;
                this.DropDownList3.SelectedValue = GuiDingTime2.Split(':')[0];
                this.DropDownList4.SelectedValue = GuiDingTime2.Split(':')[1];
                string GuiDingTime3 = MyModel.GuiDingTime3;
                this.DropDownList5.SelectedValue = GuiDingTime3.Split(':')[0];
                this.DropDownList6.SelectedValue = GuiDingTime3.Split(':')[1];
                string GuiDingTime4 = MyModel.GuiDingTime4;
                this.DropDownList7.SelectedValue = GuiDingTime4.Split(':')[0];
                this.DropDownList8.SelectedValue = GuiDingTime4.Split(':')[1];
                string GuiDingTime5 = MyModel.GuiDingTime5;
                this.DropDownList9.SelectedValue = GuiDingTime5.Split(':')[0];
                this.DropDownList10.SelectedValue = GuiDingTime5.Split(':')[1];
                string GuiDingTime6 = MyModel.GuiDingTime6;
                this.DropDownList11.SelectedValue = GuiDingTime6.Split(':')[0];
                this.DropDownList12.SelectedValue = GuiDingTime6.Split(':')[1];

                //设定按钮权限            
                //ImageButton1.Visible = SDLX.Common.PublicMethod.StrIFIn("|040m|", SDLX.Common.PublicMethod.GetSessionValue("QuanXian"));
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Maticsoft.BLL.ERPKaoQinSetting Model = new Maticsoft.BLL.ERPKaoQinSetting();
            Model.ID = int.Parse(Maticsoft.DBUtility.DbHelperSQL1.GetSHSLInt("select top 1 [ID] FROM ERPKaoQinSetting"));
            Model.GuiDingTime1 = this.DropDownList1.SelectedItem.Text + ":" + this.DropDownList2.SelectedItem.Text + ":00";
            Model.GuiDingTime2 = this.DropDownList3.SelectedItem.Text + ":" + this.DropDownList4.SelectedItem.Text + ":00";
            Model.GuiDingTime3 = this.DropDownList5.SelectedItem.Text + ":" + this.DropDownList6.SelectedItem.Text + ":00";
            Model.GuiDingTime4 = this.DropDownList7.SelectedItem.Text + ":" + this.DropDownList8.SelectedItem.Text + ":00";
            Model.GuiDingTime5 = this.DropDownList9.SelectedItem.Text + ":" + this.DropDownList10.SelectedItem.Text + ":00";
            Model.GuiDingTime6 = this.DropDownList11.SelectedItem.Text + ":" + this.DropDownList12.SelectedItem.Text + ":00";
            Model.Update();

            //写系统日志
            //SDLX.BLL.ERPRiZhi MyRiZhi = new SDLX.BLL.ERPRiZhi();
            //MyRiZhi.UserName = SDLX.Common.PublicMethod.GetSessionValue("UserName");
            //MyRiZhi.DoSomething = "用户修改考勤时间设置";
            //MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            //MyRiZhi.Add();
            Common.MessageBox.ShowAndRedirect(this, "考勤时间设置成功！", "KQSet.aspx");
        }
    }
}