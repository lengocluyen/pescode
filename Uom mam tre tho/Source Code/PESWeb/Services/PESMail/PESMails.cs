using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Configuration;

/// <summary>
/// Summary description for ITBusMails
/// </summary>
public class PESMails
{
    public static bool Send(PESMail mail)
    {
        SmtpClient smtp = new SmtpClient();
        smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings.Get("Sender"), ConfigurationManager.AppSettings.Get("MailPass"));
        smtp.Host = ConfigurationManager.AppSettings.Get("SmtpHost");
        smtp.Port = Commons.ConvertToInt(ConfigurationManager.AppSettings.Get("SmtpPort"),25);
        smtp.EnableSsl = true;
        using (MailMessage message = new MailMessage())
        {
            message.From = new MailAddress(ConfigurationManager.AppSettings.Get("defaultSender"));
            for (int i = 0; i < mail.List.Count;i++ )
            {
                message.To.Add(mail.List[i].ToString());
            }
            message.Subject = mail.Subject;
            message.Body = mail.Content;
            message.IsBodyHtml = mail.IsHtml;
            try
            {
                smtp.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
