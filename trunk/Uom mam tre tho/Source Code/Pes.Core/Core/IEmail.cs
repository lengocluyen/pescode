using System.Collections.Generic;

namespace Pes.Core
{
    public interface IEmail
    {
        void SendEmail(string From, string Subject, string Message);
        void SendEmail(string To, string CC, string BCC, string Subject, string Message);
        void SendEmail(string[] To, string[] CC, string[] BCC, string Subject, string Message);
        void SendIndividualEmailsPerRecipient(string[] To, string Subject, string Message);
        void SendEmailAddressVerificationEmail(string Username, string To);
        void SendPasswordReminderEmail(string To, string EncryptedPassword, string Username);
        void SendFriendInvitation(string toEmail, string fromFirstName, string fromLastName, string GUID, string Message);
        List<string> ParseEmailsFromText(string text);
        string SendInvitations(Account sender, string ToEmailArray, string Message);
        void SendNewMessageNotification(Account sender, string ToEmail);
    }
}