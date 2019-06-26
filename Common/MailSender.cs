using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Maticsoft.Common
{
    public class MailSender
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">接收方邮件地址</param>
        /// <param name="title">邮件标题</param>
        /// <param name="content">邮件正文内容</param>
        /// <returns></returns>
        static bool sendMail(string to, string title, string content)
        {

            string strHost = ConfigurationManager.AppSettings["SendServer"].ToString();   //STMP服务器地址
            string strAccount = ConfigurationManager.AppSettings["UserName"].ToString();       //SMTP服务帐号
            string strPwd = ConfigurationManager.AppSettings["PassWord"].ToString();       //SMTP服务密码
            string strFrom = ConfigurationManager.AppSettings["SendEmail"].ToString();  //发送方邮件地址

            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = strHost; ;//指定SMTP服务器
            _smtpClient.Credentials = new System.Net.NetworkCredential(strAccount, strPwd);//用户名和密码

            MailMessage _mailMessage = new MailMessage(strFrom, to);
            _mailMessage.Subject = title;//主题
            _mailMessage.Body = content;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.UTF8;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.High;//优先级

            try
            {
                _smtpClient.Send(_mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void Send(string server, string sender, string recipient, string subject,
    string body, bool isBodyHtml, Encoding encoding, bool isAuthentication, params string[] files)
        {
            SmtpClient smtpClient = new SmtpClient(server);
            MailMessage message = new MailMessage(sender, recipient);
            message.IsBodyHtml = isBodyHtml;

            message.SubjectEncoding = encoding;
            message.BodyEncoding = encoding;

            message.Subject = subject;
            message.Body = body;

            message.Attachments.Clear();
            if (files != null && files.Length != 0)
            {
                for (int i = 0; i < files.Length; ++i)
                {
                    Attachment attach = new Attachment(files[i]);
                    message.Attachments.Add(attach);
                }
            }

            if (isAuthentication == true)
            {
                smtpClient.Credentials = new NetworkCredential(SmtpConfig.Create().SmtpSetting.User,
                    SmtpConfig.Create().SmtpSetting.Password);
            }
            smtpClient.Send(message);


        }

        public static void Send(string recipient, string subject, string body)
        {
            Send(SmtpConfig.Create().SmtpSetting.Server, SmtpConfig.Create().SmtpSetting.Sender, recipient, subject, body, true, Encoding.Default, true, null);
        }

        public static void Send(string Recipient, string Sender, string Subject, string Body)
        {
            Send(SmtpConfig.Create().SmtpSetting.Server, Sender, Recipient, Subject, Body, true, Encoding.UTF8, true, null);
        }

        static readonly string smtpServer = System.Configuration.ConfigurationManager.AppSettings["SmtpServer"];
        static readonly string userName = System.Configuration.ConfigurationManager.AppSettings["UserName"];
        static readonly string pwd = System.Configuration.ConfigurationManager.AppSettings["Pwd"];
        static readonly int smtpPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"]);
        static readonly string authorName = System.Configuration.ConfigurationManager.AppSettings["AuthorName"];
        static readonly string to = System.Configuration.ConfigurationManager.AppSettings["To"];


        public void Send(string subject, string body)
        {

            List<string> toList = StringPlus.GetSubStringList(StringPlus.ToDBC(to), ',');
            OpenSmtp.Mail.Smtp smtp = new OpenSmtp.Mail.Smtp(smtpServer, userName, pwd, smtpPort);
            foreach (string s in toList)
            {
                OpenSmtp.Mail.MailMessage msg = new OpenSmtp.Mail.MailMessage();
                msg.From = new OpenSmtp.Mail.EmailAddress(userName, authorName);
                
                msg.AddRecipient(s, OpenSmtp.Mail.AddressType.To);

                //设置邮件正文,并指定格式为 html 格式
                msg.HtmlBody = body;
                //设置邮件标题
                msg.Subject = subject;
                //指定邮件正文的编码
                msg.Charset = "gb2312";
                //发送邮件
                smtp.SendMail(msg);
            }
        }
    }

    public class SmtpSetting
    {
        private string _server;

        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        private bool _authentication;

        public bool Authentication
        {
            get { return _authentication; }
            set { _authentication = value; }
        }
        private string _user;

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        private string _sender;

        public string Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
    }

    public class SmtpConfig
    {
        private static SmtpConfig _smtpConfig;
        private string ConfigFile
        {
            get
            {
                string configPath = ConfigurationManager.AppSettings["SmtpConfigPath"];
                if (string.IsNullOrEmpty(configPath) || configPath.Trim().Length == 0)
                {
                    configPath = HttpContext.Current.Request.MapPath("/Config/SmtpSetting.config");
                }
                else
                {
                    if (!Path.IsPathRooted(configPath))
                        configPath = HttpContext.Current.Request.MapPath(Path.Combine(configPath, "SmtpSetting.config"));
                    else
                        configPath = Path.Combine(configPath, "SmtpSetting.config");
                }
                return configPath;
            }
        }
        public SmtpSetting SmtpSetting
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(this.ConfigFile);
                SmtpSetting smtpSetting = new SmtpSetting();
                smtpSetting.Server = doc.DocumentElement.SelectSingleNode("Server").InnerText;
                smtpSetting.Authentication = Convert.ToBoolean(doc.DocumentElement.SelectSingleNode("Authentication").InnerText);
                smtpSetting.User = doc.DocumentElement.SelectSingleNode("User").InnerText;
                smtpSetting.Password = doc.DocumentElement.SelectSingleNode("Password").InnerText;
                smtpSetting.Sender = doc.DocumentElement.SelectSingleNode("Sender").InnerText;

                return smtpSetting;
            }
        }
        private SmtpConfig()
        {

        }
        public static SmtpConfig Create()
        {
            if (_smtpConfig == null)
            {
                _smtpConfig = new SmtpConfig();
            }
            return _smtpConfig;
        }
    }
}
