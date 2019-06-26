using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;

namespace Maticsoft.Web.File
{
    public partial class Folder_IDE : System.Web.UI.Page
    {
        protected string action;
        protected string folder_id;
        protected string folder_name="";
        protected string level_id = "";
        protected string up_permission = "";
        protected string dowm_permission = "";
        protected string remark = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            action = Request["action"].ToString();
            if (action == "add")
            {
                folder_id = "";
                folder_name = "";
                level_id = "";
                up_permission = ",";
                dowm_permission = ",";
            }
            else if (action == "edit")
            {
                folder_id = Request["id"].ToString();
                WCDataProvider db = new WCDataProvider();
                WCDataStoreProcedures dsp = new WCDataStoreProcedures("pro_folder", WCDataAction.Query6);
                dsp.InputPars.Add("@folder_id", folder_id);
                if (db.Execute(dsp).ExecuteState)
                {
                    folder_name = dsp.OutputDataSet.Tables[0].Rows[0]["folder_name"].ToString();
                    level_id = dsp.OutputDataSet.Tables[0].Rows[0]["folder_level"].ToString();
                    remark = dsp.OutputDataSet.Tables[0].Rows[0]["remark"].ToString();
                    if (dsp.OutputDataSet.Tables[1].Rows.Count>0)
                    {
                        up_permission = dsp.OutputDataSet.Tables[1].Rows[0]["up_permission"].ToString();
                        dowm_permission = dsp.OutputDataSet.Tables[1].Rows[0]["dowm_permission"].ToString();
                        
                    }
                    if (up_permission==""||string.IsNullOrEmpty(up_permission))
                    {
                        up_permission = "," + up_permission;
                    }
                    if (dowm_permission==""||string.IsNullOrEmpty(dowm_permission))
                    {
                        dowm_permission = "," + dowm_permission;
                    }
                }
            }
            

        }
    }
}