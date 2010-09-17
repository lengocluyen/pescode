using System.Net.Mail;

namespace Pes.Core
{
    public interface IEmailService
    {
        void Send(MailMessage Message);
        void ProcessEmails();
    }
}