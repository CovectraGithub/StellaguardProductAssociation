using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace StellaguardProductAssociation.Utility
{
   public class EmailProcessing
    {
        public static string AdditionalEmailAddress { get; set; }
       public static void SendMail(string subject, string body,string attachedBody=null,string fileName=null)
       {
           try
           {
               SmtpClient client = new SmtpClient();
               MailMessage message = new MailMessage();
               message.From = new MailAddress(ConfigSetting.GetFromEmailAddress());
               //  message.To.Add(new MailAddress(ConfigurationSettings.AppSettings["ccTo"].ToString()));
               string addresses = ConfigSetting.GetCCEmailAddress();
               foreach (var address in addresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
               {
                   message.To.Add(address);
               }
               if(string.IsNullOrEmpty(AdditionalEmailAddress)==false)
               {
                   message.To.Add(AdditionalEmailAddress);
               }
               message.Subject = subject;
               message.IsBodyHtml = true;
               message.Body = EscapeHTMLTags(body);
               message.Body = message.Body.Substring(0, message.Body.Length > 1048575 ? 1048575 : message.Body.Length);
               if(!string.IsNullOrEmpty(attachedBody))
               {
                   if (!Directory.Exists(Constant.EMAIL_ATTACHMENT_FOLDER_PATH)) { Directory.CreateDirectory(Constant.EMAIL_ATTACHMENT_FOLDER_PATH); }
                   if(string.IsNullOrEmpty(fileName))
                   {
                       fileName = Guid.NewGuid().ToString() + ".xml";
                   }
                   File.WriteAllText(Path.Combine(Constant.EMAIL_ATTACHMENT_FOLDER_PATH, fileName), attachedBody);
                   System.Net.Mail.Attachment attachment;
                   attachment = new System.Net.Mail.Attachment(Path.Combine(Constant.EMAIL_ATTACHMENT_FOLDER_PATH, fileName));
                   message.Attachments.Add(attachment);

               }
               client.Port = Convert.ToInt16(ConfigSetting.GetPort());
               client.EnableSsl = Convert.ToBoolean(ConfigSetting.GetEnableSSL());
               client.Credentials = new System.Net.NetworkCredential(ConfigSetting.GetMailUsername(), ConfigSetting.GetMailPassword());
               client.Host = ConfigSetting.GetSMTPServerName();
               client.Send(message);
           }
           catch (Exception ex)
           {
           }


       }
       public static string EscapeHTMLTags(string str)
       {
           str = str.Replace("<", "&lt;");
           str = str.Replace(">", "&gt;");
           str = str.Replace("\r\n", "<br/>");
           return str;
       }
    }
}
