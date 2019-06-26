using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Maticsoft.DBUtility
{
    public class WcSecurity
    {
        public class WcMD5
        {
            //md5加密
            public static string Encryp(string input)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fromData = System.Text.Encoding.Unicode.GetBytes(input);
                byte[] targetData = md5.ComputeHash(fromData);
                string byte2String = null;
                for (int i = 0; i < targetData.Length; i++)
                {
                    byte2String += targetData[i].ToString("x");
                }
                return byte2String;
            }
        }

        //des加密解密类
        public class Des
        {
            /// <summary>
            /// 加密
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static string Encrypt(string input)
            {
                string key = "robertff";
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    if (!string.IsNullOrEmpty(input))
                    {
                        byte[] inputByteArray = Encoding.UTF8.GetBytes(input);
                        des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                        des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(inputByteArray, 0, inputByteArray.Length);
                            cs.FlushFinalBlock();
                            cs.Close();
                        }
                        string str = Convert.ToBase64String(ms.ToArray());
                        ms.Close();
                        return str;
                    }
                    return "";
                }
            }

            /**/
            /// <summary>
            /// 进行DES解密。
            /// </summary>
            /// <param name="input">要解密的以Base64</param>
            /// <param name="key">密钥，且必须为8位。</param>
            /// <returns>已解密的字符串。</returns>
            public static string Decrypt(string input)
            {
                string key = "robertff";
                byte[] inputByteArray = Convert.FromBase64String(input);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = ASCIIEncoding.ASCII.GetBytes(key);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(key);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    string str = Encoding.UTF8.GetString(ms.ToArray());
                    ms.Close();
                    return str;
                }
            }
        }
    }
}
