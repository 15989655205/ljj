using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.SessionState;
using Maticsoft.DBUtility;


namespace Maticsoft.Web.Ashx
{
    /// <summary>
    /// Product 的摘要说明
    /// </summary>
    public class Product : IHttpHandler, IRequiresSessionState
    {
       
        public void ProcessRequest(HttpContext hc)
        {
            hc.Response.ContentType = "text/plain";
            Model.BaseUser bu = (Model.BaseUser)hc.Session["login"];
            if (bu == null)
            {
                hc.Response.Write("登录超时，请重新登录。");
                return;
            }

            hc.Response.ContentType = "text/plain";
            string msg = string.Empty;
            switch (hc.Request["action"])
            {
                case "add": msg = Add(hc); break;
                case "list": msg = QueryList(hc); break;
                case "plist": msg = ProductList(hc); break;
                case "detail": msg = ShowDeatil(hc); break;
                case "edit": msg = Update(hc); break;
                case "dels": msg = Dels(hc); break;
                case "list_Color": msg = List_Color(hc); break;
                case "group_edit": msg = Group_Edit(hc); break;
                case "upload": Upload(hc); break;
                case "GetPicName":msg=GetImageName(hc); break;
                case "DelPic": msg = DelPic(hc); break;
                default: break;
            }
            hc.Response.Write(msg);
        }


        

        //删除图片
        public string DelPic(HttpContext context)
        {
            try
            {
                 DataSet ds = new DataSet();
                long ID = Convert.ToInt64(context.Request["lbID"]);
                ds = new BLL.Product().GetDataSetByProc(ID);

                string path = System.Web.HttpContext.Current.Server.MapPath("../ProductPic/" + ds.Tables[0].Rows[0]["Image"].ToString() + "");
                if (System.IO.File.Exists(path))
                {
                    string delFile = System.Web.HttpContext.Current.Server.MapPath("../ProductPic/" + ds.Tables[0].Rows[0]["Image"].ToString() + "");
                    System.IO.File.Delete(delFile);
                }

                Model.Product model = new Model.Product();
                model.ID = ID;
                model.Image = "";
               
                ds = new BLL.Product().UpdateImageByProc(model);
                
  
                if (ds.Tables[0].Rows[0][0].ToString()=="")
                {

                    return "success";
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           
        }

        //上传图片
        public void  Upload(HttpContext context)
        {
            try
            {
                HttpPostedFile file;
                string fileName = string.Empty;
                string action = context.Request["isAdd"].ToString();
                string result = string.Empty;
                long ID=0;
                Model.Product model = new Model.Product();
                DataSet ds = new DataSet();
                if (action != "add")
                {
                    ID = Convert.ToInt64(context.Request["lbID"]);
                }
             
              
            
                for (int i = 0; i < context.Request.Files.Count; ++i)
                {
                    file = context.Request.Files[i];
                    if (file == null || file.ContentLength == 0 || string.IsNullOrEmpty(file.FileName)) continue;
                    file.SaveAs(HttpContext.Current.Server.MapPath("../ProductPic/" + Path.GetFileName(file.FileName)));
                    fileName = file.FileName;
                    if (action != "add")
                    {
                       
                        model.ID = ID;
                        model.UpdateUser = Convert.ToString(((Model.BaseUser)context.Session["login"]).UserID);
                        model.UpdateDate = DateTime.Now;
                        model.Image = file.FileName;
                        ds = new BLL.Product().UpdateImageByProc(model);
                        result = ds.Tables[0].Rows[0][0].ToString();
                    }
                    result = fileName;
                    context.Response.Write(result);
                    
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


        //获得图片名字
        public string GetImageName(HttpContext context)
        {
            long ID = context.Request["lbID"] == "undefined" ? 0 : Convert.ToInt64(context.Request["lbID"]);
            if (ID == 0) return "";
            DataSet ds = new DataSet();
            ds = new BLL.Product().GetDataSetByProc(ID);
            return ds.Tables[0].Rows[0]["Image"].ToString();
        }


        public string Add(HttpContext context)
        {
            /*************基本资料***********/
            string BarCode = context.Request["BarCode"];
            string Name = context.Request["Name"];
            string Specifications = context.Request["Specifications"];
            string ValuationMethods = context.Request["ValuationMethods"];
            string Unit = context.Request["Unit"];
            if (context.Request["TypeID"]=="")
            {
                return "必须项不能为空！";
            }
            long TypeID = Convert.ToInt64(context.Request["TypeID"]);
            long SeriesID = Convert.ToInt64(context.Request["SeriesID"]);
            string Attribute = context.Request["Attribute"];
            string Manufacturer = context.Request["Manufacturer"];
            string Enabled = context.Request["Enabled"];
            string Install = context.Request["Install"];
            //decimal BarginPrice = context.Request["BarginPrice"] != "" ? Convert.ToDecimal(context.Request["BarginPrice"]) : 0;
            //decimal StandardPrice = context.Request["StandardPrice"] != "" ? Convert.ToDecimal(context.Request["StandardPrice"]) : 0;
            //decimal MaxStock = context.Request["MaxStock"] != "" ? Convert.ToDecimal(context.Request["MaxStock"]) : 0;
            //decimal MinStock = context.Request["MinStock"] != "" ? Convert.ToDecimal(context.Request["MinStock"]) : 0;
            //decimal ReferencePrice = context.Request["ReferencePrice"] != "" ? Convert.ToDecimal(context.Request["ReferencePrice"]) : 0;
            //decimal PriceTag = context.Request["PriceTag"] != "" ? Convert.ToDecimal(context.Request["PriceTag"]) : 0;
            //decimal MinPrice = context.Request["MinPrice"] != "" ? Convert.ToDecimal(context.Request["MinPrice"]) : 0;
            //decimal Profit = context.Request["Profit"] != "" ? Convert.ToDecimal(context.Request["Profit"]) : 0;
            //string StockProduct = context.Request["StockProduct"];
            //string ProductPurchase = context.Request["ProductPurchase"];
            //decimal SellingCost = context.Request["SellingCost"] != "" ? Convert.ToDecimal(context.Request["SellingCost"]) : 0;
            //decimal SellingPrice = context.Request["SellingPrice"] != "" ? Convert.ToDecimal(context.Request["SellingPrice"]) : 0;
            //decimal SellingProfit = context.Request["SellingProfit"] != "" ? Convert.ToDecimal(context.Request["SellingProfit"]) : 0;
            ///*************预设资料***********/
            //decimal ReferencePriceA = context.Request["ReferencePriceA"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceA"]) : 0;
            //decimal ReferencePriceB = context.Request["ReferencePriceB"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceB"]) : 0;
            //decimal ReferencePriceC = context.Request["ReferencePriceC"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceC"]) : 0;
            //decimal ReferencePriceD = context.Request["ReferencePriceD"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceD"]) : 0;
            //decimal ReferencePriceE = context.Request["ReferencePriceE"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceE"]) : 0;
            //decimal ReferencePriceF = context.Request["ReferencePriceF"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceF"]) : 0;
            //string SellingAward = context.Request["SellingAward"];
            //decimal SellingRoyaltyRate = context.Request["SellingRoyaltyRate"] != "" ? Convert.ToDecimal(context.Request["SellingRoyaltyRate"]) : 0;
            //string PreinstallStock = context.Request["PreinstallStock"];
            //string PreinstallStockArea = context.Request["PreinstallStockArea"];
            string BulkUnit = context.Request["BulkUnit"];
            string Bulk = context.Request["Bulk"];
            string PreinstallStockSite = context.Request["PreinstallStockSite"];
            string WeightUnit = context.Request["WeightUnit"];
            string Weight = context.Request["Weight"];
            decimal PackCount = context.Request["PackCount"] != "" ? Convert.ToDecimal(context.Request["PackCount"]) : 0;
            //decimal SellingLandTransportation = context.Request["SellingLandTransportation"] != "" ? Convert.ToDecimal(context.Request["SellingLandTransportation"]) : 0;
            //decimal DayLandTransportation = context.Request["DayLandTransportation"] != "" ? Convert.ToDecimal(context.Request["DayLandTransportation"]) : 0;
            //decimal Long = context.Request["Long"] != "" ? Convert.ToDecimal(context.Request["Long"]) : 0;
            //decimal SellingSeaTransportation = context.Request["SellingSeaTransportation"] != "" ? Convert.ToDecimal(context.Request["SellingSeaTransportation"]) : 0;
            //decimal DaySeaTransportation = context.Request["DaySeaTransportation"] != "" ? Convert.ToDecimal(context.Request["DaySeaTransportation"]) : 0;
            //decimal Width = context.Request["Width"] != "" ? Convert.ToDecimal(context.Request["Width"]) : 0;
            //decimal SellingOtherTransportation = context.Request["SellingOtherTransportation"] != "" ? Convert.ToDecimal(context.Request["SellingOtherTransportation"]) : 0;
            //decimal DayOtherTransportation = context.Request["DayOtherTransportation"] != "" ? Convert.ToDecimal(context.Request["DayOtherTransportation"]) : 0;
            //decimal Height = context.Request["Height"] != "" ? Convert.ToDecimal(context.Request["Height"]) : 0;

            string addstr = context.Request.Params["addstr"].Trim();
            List<Model.ProductPriceColorShip> insert = new List<Model.ProductPriceColorShip>();
            insert = JsonSerializerHelper.JSONStringToList<Model.ProductPriceColorShip>(addstr);
            string  picFile= context.Request.Params["picFile"].Trim();

            Maticsoft.Model.Product model = new Model.Product();
            model.BarCode = BarCode;
            model.Name = Name;
            model.Specifications = Specifications;
            model.ValuationMethods = ValuationMethods;
            model.Unit = Unit;
            model.TypeID = TypeID;
            model.SeriesID = SeriesID;
            model.Attribute = Attribute;
            model.Manufacturer = Manufacturer;
            //model.BarginPrice = BarginPrice;
            //model.StandardPrice = StandardPrice;
            //model.MaxStock = MaxStock;
            //model.MinStock = MinStock;
            //model.ReferencePrice = ReferencePrice;
            //model.PriceTag = PriceTag;
            //model.MinPrice = MinPrice;
            //model.Profit = Profit;
            //model.StockProduct = StockProduct;
            //model.ProductPurchase = ProductPurchase;
            //model.SellingCost = SellingCost;
            //model.SellingPrice = SellingPrice;
            //model.SellingProfit = SellingProfit;
            ///*************预设资料***********/
            //model.ReferencePriceA = ReferencePriceA;
            //model.ReferencePriceB = ReferencePriceB;
            //model.ReferencePriceC = ReferencePriceC;
            //model.ReferencePriceD = ReferencePriceD;
            //model.ReferencePriceE = ReferencePriceE;
            //model.ReferencePriceF = ReferencePriceF;
            //model.SellingAward = SellingAward;
            //model.SellingRoyaltyRate = SellingRoyaltyRate;
            //model.PreinstallStock = PreinstallStock;
            //model.PreinstallStockArea = PreinstallStockArea;
            model.BulkUnit = BulkUnit;
            model.UnitBulk = Bulk;
            model.PreinstallStockSite = PreinstallStockSite;
            model.WeightUnit = WeightUnit;
            model.UnitWeight = Weight;
            model.PackCount = PackCount;
            //model.SellingLandTransportation = SellingLandTransportation;
            //model.DayLandTransportation = DayLandTransportation;
            //model.Long = Long;
            //model.SellingSeaTransportation = SellingSeaTransportation;
            //model.DaySeaTransportation = DaySeaTransportation;
            //model.Width = Width;
            //model.SellingOtherTransportation = SellingOtherTransportation;
            //model.DayOtherTransportation = DayOtherTransportation;
            //model.Height = Height;
            model.CreateUser = ((Model.BaseUser)(context.Session["login"])).UserID.ToString();
            model.CreateDate = DateTime.Now;
            model.UpdateUser = ((Model.BaseUser)(context.Session["login"])).UserID.ToString();
            model.UpdateDate = DateTime.Now;
            long id=0;
            long result = new Maticsoft.BLL.Product().CheckToAdd(model, insert, picFile);
            if (result == -2)
            {
                return "名称已存在,添加失败！";
            }
            else if (result == -3)
            {
                return "添加失败！";
            }
            else {
                id = result;
                
                return "success";
            }

            
            //context.Response.Write(BarCode);

        }

        public string QueryList(HttpContext context)
        {
            ////DataTable dt = new DataTable();
            ////dt=DBUtility.DbHelperSQL.s
            //WCDataProvider db = new WCDataProvider();
            //WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Product", WCDataAction.Query1);
            ////dsp.InputPars.Add("@Where", " ParentID=0 ");
            //dsp.InputPars.Add("@Where", " 1=1 ");
            //dsp.InputPars.Add("@Sort", " p.ID");
            //dsp.InputPars.Add("@PageSize", hc.Request.Form["rows"]);
            //dsp.InputPars.Add("@PageIndex", hc.Request.Form["page"]);
            //if (db.Execute(dsp).ExecuteState)
            //{
            //    if (dsp.OutputDataSet.Tables[0].Rows.Count > 0)
            //    {
            //        //string json = "{\"total\":" + dsp.OutputPars["@RecordCount"].ToString() + ",\"rows\":[";
            //        //foreach (DataRow dr in dsp.OutputDataSet.Tables[0].Rows)
            //        //{
            //        //    json += "{\"" + dr.Table.Columns[0].Caption + "\":\"" + dr[0] + "\"";
            //        //    for (int i = 1; i < dr.Table.Columns.Count; i++)
            //        //    {
            //        //        json += ",\"" + dr.Table.Columns[i].Caption + "\":\"" + dr[i] + "\"";
            //        //    }
            //        //    DataRow[] drs = dsp.OutputDataSet.Tables[1].Select("ParentID=" + dr["ID"]);
            //        //    if (drs.Length > 0)
            //        //    {
            //        //        json += ",\"state\":\"closed\"}," + JsonChildren(dsp.OutputDataSet.Tables[1], drs);
            //        //    }
            //        //    else
            //        //    {
            //        //        json += "},";
            //        //    }
            //        //}
            //        //return json.Remove(json.Length - 1) + "]}";
            //        return JsonHelper.DataTable2Json_Datagrid(dsp.OutputDataSet.Tables[0], Convert.ToInt32(dsp.OutputPars["@RecordCount"].ToString()));
            //    }
            //}
            //return "{\"total\":0,\"rows\":[]}";

            string id = context.Request.Params["id"] == null ? "0" : context.Request.Params["id"].Trim();
            string table = "v_product_tree";
            string sort = "id";
            string show = "*,(select count(1) from productcolor where parentid=v_product_tree.id and type=1) child";
            string order = "asc";
            string where = "1=1 and ParentID=" + id;
            int page = context.Request.Form["page"] != "" ? Convert.ToInt32(context.Request.Form["page"]) : 0;
            int rows = context.Request.Form["rows"] != "" ? Convert.ToInt32(context.Request.Form["rows"]) : 0;
            int total = 0;
            DataTable dt=new DataTable();
            if (id == "0")
                dt = DbHelperSQL.GetList_ProcPage(table, sort, show, page, rows, out total, order, where).Tables[0];
            else
            {
                DataSet ds = new DataSet();
                ds = new BLL.Common().GetList("select *,(select count(1) from productcolor where parentid=v_product_tree.id and type=1) child from v_product_tree where ParentID=" + id+" ; select count(1) from product");
                if (ds.Tables.Count > 1)
                {
                    dt = ds.Tables[0];
                    total = int.Parse(ds.Tables[1].Rows[0][0].ToString().Trim());
                }
            }
            string json = "";
            if (id == "0")
            {
                json += "{\"total\":";
                //JsonString.Append(dt.Rows.Count.ToString());
                json += total.ToString();
                json += ",";
                json += "\"rows\":";
            }

            json += new JsonHelper().DT2GTree(dt, "ParentID");

            if (id == "0")
            {
                json += "}";
            }

            return json;
        }

        public string ProductList(HttpContext context)
        {
            //DataTable dt = new DataTable();
            //dt=DBUtility.DbHelperSQL.s
            WCDataProvider db = new WCDataProvider();
            WCDataStoreProcedures dsp = new WCDataStoreProcedures("Sp_Product", WCDataAction.Query5);
            //dsp.InputPars.Add("@Where", " ParentID=0 ");
            dsp.InputPars.Add("@Where", " 1=1 ");
            dsp.InputPars.Add("@Sort", "ptName,psName,Name");
            dsp.InputPars.Add("@PageSize", context.Request.Form["rows"]);
            dsp.InputPars.Add("@PageIndex", context.Request.Form["page"]);
            if (db.Execute(dsp).ExecuteState)
            {
                if (dsp.OutputDataSet.Tables[0].Rows.Count > 0)
                {
                    return JsonHelper.DataTable2Json_Datagrid(dsp.OutputDataSet.Tables[0], Convert.ToInt32(dsp.OutputPars["@RecordCount"].ToString()));
                }
            }
            return "{\"total\":0,\"rows\":[]}";

        }

        public string ShowDeatil(HttpContext context)
        {
            //产品ID
            long ID = Convert.ToInt64(context.Request["id"]);
            //动作
            string action = context.Request["action"];
            //颜色
            string table = string.Empty;
            //string id = context.Request.Params["id"] == null ? "0" : context.Request.Params["id"].Trim();
            DataSet ds = new DataSet();
            ds = new BLL.Product().GetDataSetByProc(ID);

            table = JsonHelper.DataTable2Josn(ds.Tables[0]);

            return table;

        }

        public string Update(HttpContext context)
        {
            string delstr = context.Request["delstr"].ToString();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            List<Model.ProductPriceColorShip> delList = new List<Model.ProductPriceColorShip>();
            delList = JsonSerializerHelper.JSONStringToList<Model.ProductPriceColorShip>(delstr);
           
            List<Model.ProductPriceColorShip> insert = new List<Model.ProductPriceColorShip>();
            insert = JsonSerializerHelper.JSONStringToList<Model.ProductPriceColorShip>(addstr);
            List<Model.ProductPriceColorShip> updateList = new List<Model.ProductPriceColorShip>();
            updateList = JsonSerializerHelper.JSONStringToList<Model.ProductPriceColorShip>(updatestr);
            string picFile = context.Request.Params["picFile"].Trim();
            string ID = context.Request.Params["ID"];

            try
            {
                return new BLL.Product().CheckToUpdate(GetProduct(context), delList, insert, updateList, picFile, ID);
               
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public Model.Product GetProduct(HttpContext context)
        {
            long ID = context.Request["ID"]!=""?Convert.ToInt64( context.Request["ID"]):0;
            string BarCode = context.Request["BarCode"];
            string Code = context.Request["Code"];
            string Name = context.Request["Name"];
            string Specifications = context.Request["Specifications"];
            string ValuationMethods = context.Request["ValuationMethods"];
            string Unit = context.Request["Unit"];
            string Type = context.Request["TypeID"].ToString();
            string  Series = context.Request["SeriesID"].ToString();
            string Attribute = context.Request["Attribute"];
            string Manufacturer = context.Request["Manufacturer"];
            //decimal BarginPrice = context.Request["BarginPrice"] != "" ? Convert.ToDecimal(context.Request["BarginPrice"]) : 0;
            //decimal StandardPrice = context.Request["StandardPrice"] != "" ? Convert.ToDecimal(context.Request["StandardPrice"]) : 0;
            //decimal MaxStock = context.Request["MaxStock"] != "" ? Convert.ToDecimal(context.Request["MaxStock"]) : 0;
            //decimal MinStock = context.Request["MinStock"] != "" ? Convert.ToDecimal(context.Request["MinStock"]) : 0;
            //decimal ReferencePrice = context.Request["ReferencePrice"] != "" ? Convert.ToDecimal(context.Request["ReferencePrice"]) : 0;
            //decimal PriceTag = context.Request["PriceTag"] != "" ? Convert.ToDecimal(context.Request["PriceTag"]) : 0;
            //decimal MinPrice = context.Request["MinPrice"] != "" ? Convert.ToDecimal(context.Request["MinPrice"]) : 0;
            //decimal Profit = context.Request["Profit"] != "" ? Convert.ToDecimal(context.Request["Profit"]) : 0;
            //string StockProduct = context.Request["StockProduct"];
            //string ProductPurchase = context.Request["ProductPurchase"];
            //decimal SellingCost = context.Request["SellingCost"] != "" ? Convert.ToDecimal(context.Request["SellingCost"]) : 0;
            //decimal SellingPrice = context.Request["SellingPrice"] != "" ? Convert.ToDecimal(context.Request["SellingPrice"]) : 0;
            //decimal SellingProfit = context.Request["SellingProfit"] != "" ? Convert.ToDecimal(context.Request["SellingProfit"]) : 0;
            ///*************预设资料***********/
            //decimal ReferencePriceA = context.Request["ReferencePriceA"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceA"]) : 0;
            //decimal ReferencePriceB = context.Request["ReferencePriceB"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceB"]) : 0;
            //decimal ReferencePriceC = context.Request["ReferencePriceC"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceC"]) : 0;
            //decimal ReferencePriceD = context.Request["ReferencePriceD"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceD"]) : 0;
            //decimal ReferencePriceE = context.Request["ReferencePriceE"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceE"]) : 0;
            //decimal ReferencePriceF = context.Request["ReferencePriceF"] != "" ? Convert.ToDecimal(context.Request["ReferencePriceF"]) : 0;
            //string SellingAward = context.Request["SellingAward"];
            //decimal SellingRoyaltyRate = context.Request["SellingRoyaltyRate"] != "" ? Convert.ToDecimal(context.Request["SellingRoyaltyRate"]) : 0;
            string PreinstallStock = context.Request["PreinstallStock"];
            string PreinstallStockArea = context.Request["PreinstallStockArea"];
            string BulkUnit = context.Request["BulkUnit"];
            string Bulk = context.Request["Bulk"];
            string PreinstallStockSite = context.Request["PreinstallStockSite"];
            string WeightUnit = context.Request["WeightUnit"];
            string Weight = context.Request["Weight"];
            decimal PackCount = context.Request["PackCount"] != "" ? Convert.ToDecimal(context.Request["PackCount"]) : 0;
            string Quality = context.Request["Quality"];
            string Brand = context.Request["Brand"];
            string NFK = context.Request["NFK"];
            string ProductKey = context.Request["ProductKey"];
            //decimal SellingLandTransportation = context.Request["SellingLandTransportation"] != "" ? Convert.ToDecimal(context.Request["SellingLandTransportation"]) : 0;
            //decimal DayLandTransportation = context.Request["DayLandTransportation"] != "" ? Convert.ToDecimal(context.Request["DayLandTransportation"]) : 0;
            //decimal Long = context.Request["Long"] != "" ? Convert.ToDecimal(context.Request["Long"]) : 0;
            //decimal SellingSeaTransportation = context.Request["SellingSeaTransportation"] != "" ? Convert.ToDecimal(context.Request["SellingSeaTransportation"]) : 0;
            //decimal DaySeaTransportation = context.Request["DaySeaTransportation"] != "" ? Convert.ToDecimal(context.Request["DaySeaTransportation"]) : 0;
            //decimal Width = context.Request["Width"] != "" ? Convert.ToDecimal(context.Request["Width"]) : 0;
            //decimal SellingOtherTransportation = context.Request["SellingOtherTransportation"] != "" ? Convert.ToDecimal(context.Request["SellingOtherTransportation"]) : 0;
            //decimal DayOtherTransportation = context.Request["DayOtherTransportation"] != "" ? Convert.ToDecimal(context.Request["DayOtherTransportation"]) : 0;
            //decimal Height = context.Request["Height"] != "" ? Convert.ToDecimal(context.Request["Height"]) : 0;


            Maticsoft.Model.Product model = new Model.Product();
            model.ID = ID;
            model.Code = Code;
            model.BarCode = BarCode;
            model.Name = Name;
            model.Specifications = Specifications;
            model.ValuationMethods =ValuationMethods;
            model.Unit = Unit;
            model.TypeID =Convert.ToInt32( Type);
            model.SeriesID =Convert.ToInt64( Series);
            model.Attribute = Attribute;
            model.Manufacturer =Convert.ToString( Manufacturer);
            //model.BarginPrice = BarginPrice;
            //model.StandardPrice = StandardPrice;
            //model.MaxStock = MaxStock;
            //model.MinStock = MinStock;
            //model.ReferencePrice = ReferencePrice;
            //model.PriceTag = PriceTag;
            //model.MinPrice = MinPrice;
            //model.Profit = Profit;
            //model.StockProduct = StockProduct;
            //model.ProductPurchase = ProductPurchase;
            //model.SellingCost = SellingCost;
            //model.SellingPrice = SellingPrice;
            //model.SellingProfit = SellingProfit;
            ///*************预设资料***********/
            //model.ReferencePriceA = ReferencePriceA;
            //model.ReferencePriceB = ReferencePriceB;
            //model.ReferencePriceC = ReferencePriceC;
            //model.ReferencePriceD = ReferencePriceD;
            //model.ReferencePriceE = ReferencePriceE;
            //model.ReferencePriceF = ReferencePriceF;
            //model.SellingAward = SellingAward;
            //model.SellingRoyaltyRate = SellingRoyaltyRate;
            model.PreinstallStock = PreinstallStock;
            model.PreinstallStockArea = PreinstallStockArea;
            model.BulkUnit = BulkUnit;
            model.UnitBulk = Bulk;
            model.PreinstallStockSite = PreinstallStockSite;
            model.WeightUnit = WeightUnit;
            model.UnitWeight = Weight;
            model.PackCount = PackCount;
            model.Quality = Quality;
            model.Brand = Brand;
            model.NFK = NFK;
            model.ProductKey = ProductKey;
            //model.SellingLandTransportation = SellingLandTransportation;
            //model.DayLandTransportation = DayLandTransportation;
            //model.Long = Long;
            //model.SellingSeaTransportation = SellingSeaTransportation;
            //model.DaySeaTransportation = DaySeaTransportation;
            //model.Width = Width;
            //model.SellingOtherTransportation = SellingOtherTransportation;
            //model.DayOtherTransportation = DayOtherTransportation;
            //model.Height = Height;
            model.CreateUser = ((Model.BaseUser)(context.Session["login"])).UserID.ToString();
            model.CreateDate = DateTime.Now;
            model.UpdateUser = ((Model.BaseUser)(context.Session["login"])).UserID.ToString();
            model.UpdateDate = DateTime.Now;
            return model;
        }

        public string Dels(HttpContext context)
        {
            string selectid = context.Request.Params["cbx_select"].Trim();
            return new BLL.Product().DeleteList(selectid) ? "ok" : "删除失败。";
        }

        public string List_Color(HttpContext context)
        {
            long id = Convert.ToInt64(context.Request["ParentID"].ToString());
            DataSet ds = new BLL.ProductColor().GetView(" ProductID=" + id + "");
            return JsonHelper.DataTable2Json_Datagrid(ds.Tables[0], ds.Tables[0].Rows.Count);
            
        }

        public string Group_Edit(HttpContext context)
        {
            long id = Convert.ToInt64(context.Request["ParentID"].ToString());
            Model.BaseUser user = ((Model.BaseUser)context.Session["login"]);
            string allstr = context.Request.Params["allstr"].Trim();
            string addstr = context.Request.Params["addstr"].Trim();
            string updatestr = context.Request.Params["updatestr"].Trim();
            string delstr = context.Request.Params["delstr"].Trim();
            Model.ProductPriceColorShip model = new Model.ProductPriceColorShip();

            List<Model.ProductPriceColorShip> insert = new List<Model.ProductPriceColorShip>();      
            insert = JsonSerializerHelper.JSONStringToList<Model.ProductPriceColorShip>(addstr);
            List<Model.ProductPriceColorShip> update = new List<Model.ProductPriceColorShip>();
            update = JsonSerializerHelper.JSONStringToList<Model.ProductPriceColorShip>(updatestr);
            List<Model.v_ProductColorShip> del = new List<Model.v_ProductColorShip>();
            del = JsonSerializerHelper.JSONStringToList<Model.v_ProductColorShip>(delstr);

            List<Model.ProductPriceColorShip> sequence = new List<Model.ProductPriceColorShip>();
            sequence = JsonSerializerHelper.JSONStringToList<Model.ProductPriceColorShip>(allstr);
            return new BLL.ProductPriceColorShip().Edit(insert, update, del, sequence, Convert.ToInt32(((Model.BaseUser)(context.Session["login"])).UserID.ToString()), id);
        }

        public string JsonChildren(DataTable dt, DataRow[] drs)
        {
            string jc = string.Empty;
            foreach (DataRow dr in drs)
            {
                jc += "{\"_parentId\":\"" + dr["ParentID"] + "\"";
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    jc += ",\"" + dr.Table.Columns[i].Caption + "\":\"" + dr[i] + "\"";
                }
                DataRow[] cdrs = dt.Select("ParentID=" + dr["ID"]);
                if (cdrs.Length > 0)
                {
                    jc += ",\"state\":\"closed\"}," + JsonChildren(dt, cdrs);
                }
                else
                {
                    jc += "},";
                }
            }
            return jc;
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