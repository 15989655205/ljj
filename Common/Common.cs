using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net;
using System.IO;
using System.Web.UI.WebControls;

namespace Maticsoft.Common
{
    public class Common
    {
        public Common()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 获取文本编辑器的数据，并自动上传远程图片
        /// </summary>
        /// <param name="uc">文本编辑器数据</param>
        /// <returns></returns>
        public string GetText(string str)
        {
            string mycontext = Regex.Replace(str, @"src[^>]*[^/].(?:jpg|bmp|gif|png|jpeg|JPG|BMP|GIF|JPEG)(?:\""|\')", new MatchEvaluator(SaveYuanFile));

            return mycontext;
        }



        private string SaveYuanFile(Match m)
        {
            string imgurl = "";
            string matchstr = m.Value;//str[i].ToString();
            string tempimgurl = "";
            tempimgurl = matchstr.Substring(5);
            tempimgurl = tempimgurl.Substring(0, tempimgurl.IndexOf("\""));

            Regex re = new Regex(@"^http://*");
            if (re.Match(tempimgurl).Success)
            {
                matchstr = matchstr.Substring(5);
                matchstr = matchstr.Substring(0, matchstr.IndexOf("\""));

                //Response.Write(matchstr + "<br>");

                //远程文件保存路径
                string Folders = ConfigurationManager.AppSettings["yuanimg"].ToString();
                string fullname = matchstr;

                string huozui = fullname.Substring(fullname.LastIndexOf("."));
                string filename = Common.GetFileName();
                string path = Folders + filename + huozui;
                //Folders+fullname.Substring(fullname.LastIndexOf("\\") + 1);

                if (System.IO.File.Exists(System.Web.HttpContext.Current.Request.MapPath(path)))
                    System.IO.File.Delete(System.Web.HttpContext.Current.Request.MapPath(path));
                GetHttpFile(matchstr, System.Web.HttpContext.Current.Request.MapPath(path));
                imgurl = "src=\"" + path.Replace("~/", "") + "\"";
            }
            else
            {
                imgurl = matchstr;
            }


            return imgurl;
        }


        string sException = null;
        private bool GetHttpFile(string sUrl, string sSavePath)
        {
            bool bRslt = false;
            WebResponse oWebRps = null;
            WebRequest oWebRqst = WebRequest.Create(sUrl);
            oWebRqst.Timeout = 100000;
            try
            {
                oWebRps = oWebRqst.GetResponse();
            }
            catch (WebException e)
            {
                sException = e.Message.ToString();
            }
            catch (Exception e)
            {
                sException = e.ToString();
            }
            finally
            {
                if (oWebRps != null)
                {
                    BinaryReader oBnyRd = new BinaryReader(oWebRps.GetResponseStream(), System.Text.Encoding.GetEncoding("GB2312"));
                    int iLen = Convert.ToInt32(oWebRps.ContentLength);
                    FileStream oFileStream;
                    try
                    {
                        if (File.Exists(System.Web.HttpContext.Current.Request.MapPath("RecievedData.tmp")))
                        {
                            oFileStream = File.OpenWrite(sSavePath);
                        }
                        else
                        {
                            oFileStream = File.Create(sSavePath);
                        }
                        oFileStream.SetLength((Int64)iLen);
                        oFileStream.Write(oBnyRd.ReadBytes(iLen), 0, iLen);
                        oFileStream.Close();
                    }
                    catch (Exception ex)
                    {
                        //bRslt= false;
                    }
                    finally
                    {
                        oBnyRd.Close();
                        oWebRps.Close();

                    }
                    bRslt = true;

                }
            }
            return bRslt;

        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="fileupload">文件上传实例</param>
        /// <returns>保存的文件名称</returns>
        public static string UpLoadFile(FileUpload fileupload, string Folders)
        {
            //string Folders = "~/admin/eWebEditor/UpLoadFile/";
            string fullname = fileupload.PostedFile.FileName;
            if ((fullname == null) || (fullname.Equals("")))
                return "";
            string huozui = fullname.Substring(fullname.LastIndexOf("."));
            string filename = GetFileName();
            string p1 = Folders + filename + huozui;
            //Folders + fullname.Substring(fullname.LastIndexOf("\\") + 1); 
            string path = System.Web.HttpContext.Current.Server.MapPath(p1);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            fileupload.PostedFile.SaveAs(path);
            return p1;
        }
        public static string GetFileName()
        {
            System.Threading.Thread.Sleep(1000);
            string str1 = System.DateTime.Now.Year.ToString() + "-";

            if ((System.DateTime.Now.Month).ToString().Length < 2)
            {
                str1 += "0" + System.DateTime.Now.Month.ToString() + "-";
            }
            else
            {
                str1 += System.DateTime.Now.Month.ToString() + "-";
            }

            if ((System.DateTime.Now.Day).ToString().Length < 2)
            {
                str1 += "0" + System.DateTime.Now.Day.ToString() + "-";
            }
            else
            {
                str1 += System.DateTime.Now.Day.ToString() + "-";
            }

            if ((System.DateTime.Now.Hour).ToString().Length < 2)
            {
                str1 += "0" + System.DateTime.Now.Hour.ToString() + "-";
            }
            else
            {
                str1 += System.DateTime.Now.Hour.ToString() + "-";
            }

            if ((System.DateTime.Now.Minute).ToString().Length < 2)
            {
                str1 += "0" + System.DateTime.Now.Minute.ToString() + "-";
            }
            else
            {
                str1 += System.DateTime.Now.Minute.ToString() + "-";
            }

            if ((System.DateTime.Now.Second).ToString().Length < 2)
            {
                str1 += "0" + System.DateTime.Now.Second.ToString();
            }
            else
            {
                str1 += System.DateTime.Now.Second.ToString();
            }

            return str1;
        }

        /// <summary>          
        /// Copy文件夹          
        /// </summary>          
        /// <param name="sPath">源文件夹路径</param>          
        /// <param name="dPath">目的文件夹路径</param>          
        /// <returns>完成状态：success-完成；其他-报错</returns>          
        public static string CopyFolder(string sPath, string dPath,bool copyFile=false)
        {
            string flag = "success";
            try
            {
                // 创建目的文件夹                  
                if (!Directory.Exists(dPath))
                {
                    Directory.CreateDirectory
                   (dPath);
                }
                // 拷贝文件                  
                DirectoryInfo sDir = new DirectoryInfo(sPath);
                if (copyFile)
                {
                    FileInfo[] fileArray = sDir.GetFiles();
                    foreach (FileInfo file in fileArray)
                    {
                        file.CopyTo(dPath + "\\" + file.Name, true);
                    }
                }
                // 循环子文件夹                  
                DirectoryInfo dDir = new DirectoryInfo(dPath);
                DirectoryInfo[] subDirArray = sDir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirArray)
                {
                    CopyFolder(subDir.FullName, dPath + "//" + subDir.Name);
                }
            }
            catch (Exception ex)
            {
                flag = ex.ToString();
            }
            return flag;
        }


        /// <summary>
        /// 生成随机纯字母随机数
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="IsRepeat">是否允许重复</param>
        /// <returns></returns>
        public static string Str_char(int Length, bool IsRepeat)
        {
            char[] Pattern = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string result = "";
            int n = Pattern.Length;
            System.Random random = new Random(~unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < Length; i++)
            {
            Repeat://此处用到goto语句，不明白可以到百度上查一下
                int rnd = random.Next(0, n);
                if (!IsRepeat && Length <= Pattern.Length)//如果不允许重复，并且生成随机字符长度大于 元数据长度 才可以不重复~真绕口
                {
                    if (result.IndexOf(Pattern[rnd]) != -1)
                        goto Repeat;//返回到指定goto标记处，此方法尽量少用
                }
                result += Pattern[rnd];
            }
            return result;
        }
    }
}
