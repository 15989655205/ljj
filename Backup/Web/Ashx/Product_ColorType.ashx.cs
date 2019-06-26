using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Maticsoft.DBUtility;
using System.Web.SessionState;
using System.IO;

namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// Product_ColorType 的摘要说明
    /// </summary>
    public class Product_ColorType : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.BaseUser bu = (Model.BaseUser)context.Session["login"];
            if (bu == null)
            {
                context.Response.Write("登录超时，请重新登录。");
                return;
            }
          string action=context.Request["action"].ToString();
          string msg = string.Empty;
          switch (action)
          {
              case "list": msg = GetList(context); break;
              case "group_edit": msg = Group_Edit(context); break;
              case "upload":  Upload(context); break;
            case "GetColor":msg= GetColor(context);break;
              default: break;
          }
          context.Response.Write(msg);
        }


        public string GetColor(HttpContext context)
        {
            DataSet ds= new BLL.ProductColor().GetList("");
            DataTable dt = ds.Tables[0];
            dt.Rows.InsertAt(dt.NewRow(), 0);
            dt.Rows[0]["Corlor"] = -1;
            dt.Rows[0]["Corlor"] = "请选择";
            string json= JsonHelper.DataTable2Json_Combo(dt);
            return json;
        }

        //上传图片
        public void Upload(HttpContext context)
        {
            try
            {
                HttpPostedFile file;
                string fileName = string.Empty;
                Model.ProductColor model = new Model.ProductColor();
                DataSet ds = new DataSet();
                long ID = Convert.ToInt64(context.Request["lbID"]);
                for (int i = 0; i < context.Request.Files.Count; ++i)
                {
                    file = context.Request.Files[i];
                    if (file == null || file.ContentLength == 0 || string.IsNullOrEmpty(file.FileName)) continue;
                    file.SaveAs(HttpContext.Current.Server.MapPath("../ProductPic/" + Path.GetFileName(file.FileName)));
                    fileName += file.FileName;
                    model.ID = ID;
                    model.UpdateUser = Convert.ToString(((Model.BaseUser)context.Session["login"]).UserID);
                    model.UpdateDate = DateTime.Now;
                    model.Image = file.FileName;
                    ds = new BLL.ProductColor().UpdateImageByProc(model, "Update3");
                    context.Response.Write(ds.Tables[0].Rows[0][0].ToString());

                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.Write(ex.Message);
                context.Response.End();
            }
            finally
            {
                context.Response.End();
            }
        }


        public string GetList(HttpContext context)
        {
            string type = context.Request.Params["type"];
            if (type != "add"&&type!="undefined")
            {
                string id = context.Request.Params["ID"] == null ? "0" : context.Request.Params["ID"].Trim();
                //[dbo].[getName_zxf](CreateUser)
                string table = "  ProductItem proi left join ProductColor pc on  pc.ID=proi.ColorID  ";
                string sort = "proi.ID";
                string show = "         proi.ID,proi.Code,proi.ProductID,proi.ColorID,proi.Corlor,proi.Size,proi.Quality,proi.Brand,proi.NFK,proi.Attribute,proi.BarginPriceOut,proi.ReferencePriceOut,proi.StandardPriceIn,proi.MinPriceOut,proi.Profit,proi.TagPrice,proi.MaxStock,proi.MinStock,proi.ReferencePriceA,proi.ReferencePriceB,proi.ReferencePriceC,proi.ReferencePriceD,proi.ReferencePriceE,proi.ReferencePriceF,proi.value0,proi.value1,pc.Name,pc.ID pcID  ";
                string order = "asc";
                int piID;
                if (id != "0")
                {
                    piID = Convert.ToInt32(id);
                }
                else
                {
                    piID = 0;
                }
                string where;
                if (piID != 0)
                {
                    where = "ProductID=" + piID + "  ";
                }
                else
                {
                    where = " ";
                }
                int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
                int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
                int total = 0;
                DataTable dt = new DataTable();
                dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0]; ;
                return JsonHelper.DataTable2Josn(dt);
            }
            else
            {
                return "{\"total\":0,\"rows\":[]}";
            }
        }

        public string Group_Edit(HttpContext context)
        {
            
            Model.BaseUser user = ((Model.BaseUser)context.Session["login"]);
            //string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            List<Model.ProductColor> insert = new List<Model.ProductColor>();
            insert = JsonSerializerHelper.JSONStringToList<Model.ProductColor>(addstr);
            List<Model.ProductColor> update = new List<Model.ProductColor>();
            update = JsonSerializerHelper.JSONStringToList<Model.ProductColor>(updatestr);
            List<Model.ProductColor> del = new List<Model.ProductColor>();
            del = JsonSerializerHelper.JSONStringToList<Model.ProductColor>(delstr);

            //List<Model.ProductColor> sequence = new List<Model.ProductColor>();
            //sequence = JsonSerializerHelper.JSONStringToList<Model.ProductColor>(allstr);
           string result= new BLL.ProductColor().EditColor(insert, update, del, Convert.ToInt32(((Model.BaseUser)(context.Session["login"])).UserID.ToString()));
           if (result == "success")
           {
                
           }
           return result;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}