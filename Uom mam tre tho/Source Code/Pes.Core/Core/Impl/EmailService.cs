using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using StructureMap;

namespace Pes.Core.Impl
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration;

        public EmailService()
        {
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
        }

        public void Send(MailMessage Message)
        {
            Message.Subject = _configuration.SiteName + " - " + Message.Subject;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(_configuration.FromEmailAddress, _configuration.PasswordEmail);
            smtp.EnableSsl = true;
            smtp.Send(Message);
        }

        public void ProcessEmails()
        {
            throw (new Exception("Lỗi thực thi!"));
        }
    }
}
