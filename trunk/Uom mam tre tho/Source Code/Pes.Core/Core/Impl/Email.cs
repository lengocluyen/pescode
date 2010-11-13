using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using StructureMap;
using System.Linq;
using System.Data.Linq;
using SubSonic.Security;
using SubSonic.Extensions;

namespace Pes.Core.Impl
{
    public class Email : IEmail
    {
        string TO_EMAIL_ADDRESS;
        string FROM_EMAIL_ADDRESS;

        private IConfiguration _configuration;
        private IUserSession _userSession;
        private IEmailService _emailService;
        private IAlertService _alertService;
        private IMessageService _messageService;
        public Email()
        {
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
            _alertService = ObjectFactory.GetInstance<IAlertService>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _emailService = ObjectFactory.GetInstance<IEmailService>();
            

            TO_EMAIL_ADDRESS = _configuration.ToEmailAddress;
            FROM_EMAIL_ADDRESS = _configuration.FromEmailAddress;
        }

        public void SendNewMessageNotification(Account sender, string ToEmail)
        {
            foreach (string s in ToEmail.Split(new char[] { ',', ';' }))
            {
                string message = sender.FirstName + " " + sender.LastName +
                " bạn có một tin nhấn trên " + _configuration.SiteName + "!  Xin vui lòng đăng nhập vào <a href='http://tieuhoc.net'>" + _configuration.SiteName +
                "</a> để xem.<HR>";

                SendEmail(s, "", "", sender.FirstName + " " + sender.LastName +
                    " bạn có một tin nhắn từ " +
                    _configuration.SiteName + "!", message);
            }
        }

        public string SendInvitations(Account sender, string ToEmailArray, string Message)
        {
            string resultMessage = Message;
            foreach (string s in ToEmailArray.Split(new char[] { ',', ';' }))
            {
                FriendInvitation friendInvitation = new FriendInvitation();
                friendInvitation.AccountID = sender.AccountID;
                friendInvitation.Email = s;
                friendInvitation.GUID = Guid.NewGuid();
                friendInvitation.BecameAccountID = 0;
                FriendInvitation.SaveFriendInvitation(friendInvitation);

                //add alert to existing users alerts
                Account account = Account.GetAccountByEmail(s);
                if (account != null)
                {
                    _alertService.AddFriendRequestAlert(_userSession.CurrentUser, account, friendInvitation.GUID,
                                                        Message);
                }

                //CHAPTER 6
                //TODO: MESSAGING - if this email is already in our system add a message through messaging system
                //if(email in system)
                //{
                //      add message to messaging system
                //}
                //else
                //{
                //      send email
                SendFriendInvitation(s, sender.FirstName, sender.LastName, friendInvitation.GUID.ToString(), Message);
                //send into mailbox
                Message = sender.FirstName + " " + sender.LastName +
          "Muốn kết bạn với bạn!<HR><a href=\"" + _configuration.RootURL +
          "Friends/ConfirmFriendInSite.aspx?InvitationKey=" + friendInvitation.GUID.ToString() + "\">" + _configuration.RootURL +
          "Friends/ConfirmFriendInSite.aspx?InvitationKey=" + friendInvitation.GUID.ToString() + "</a><HR>" + Message;
                Messages m = new Messages();
                m.Body = Message;
                m.Subject = "Thư mời kết bạn";
                m.CreateDate = DateTime.Now;
                m.MessageTypeID = (int)MessageTypes.FriendRequest;
                m.SentByAccountID = _userSession.CurrentUser.AccountID;
                m.MessageID = 0;
                m.Save();

                Int64 messageID = m.MessageID;

                MessageRecipient sendermr = new MessageRecipient();
                sendermr.AccountID = _userSession.CurrentUser.AccountID;
                sendermr.MessageFolderID = (int)MessageFolders.Sent;
                sendermr.MessageRecipientTypeID = (int)MessageRecipientTypes.TO;
                sendermr.MessageID = messageID;
                sendermr.MessageStatusTypeID = (int)MessageStatusTypes.Unread;
                sendermr.MessageRecipientID = 0;
                sendermr.Save();

                Account toAccount = Account.GetAccountByEmail(s);
                if (toAccount != null)
                {
                    MessageRecipient mr = new MessageRecipient();
                    mr.AccountID = toAccount.AccountID;
                    mr.MessageFolderID = (int)MessageFolders.Inbox;
                    mr.MessageID = messageID;
                    mr.MessageRecipientTypeID = (int)MessageRecipientTypes.TO;
                    mr.MessageRecipientID = 0;
                    mr.MessageStatusTypeID = 1;
                    mr.Save();
                    //_email.SendNewMessageNotification(toAccount, toAccount.Email);
                }
                //}
                resultMessage += "• " + s + "<BR>";
            }
            return resultMessage;
        }

        //CHAPTER 5
        public List<string> ParseEmailsFromText(string text)
        {
            List<string> emails = new List<string>();
            string strRegex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex re = new Regex(strRegex, RegexOptions.Multiline);
            foreach (Match m in re.Matches(text))
            {
                string email = m.ToString();
                if (!emails.Contains(email))
                    emails.Add(email);
            }
            return emails;
        }

        //CHAPTER 5
        public void SendFriendInvitation(string toEmail, string fromFirstName, string fromLastName, string GUID, string Message)
        {
            Message = fromFirstName + " " + fromLastName +
            "đã mời gia nhập vào " + _configuration.SiteName + "!<HR><a href=\"" + _configuration.RootURL +
            "Friends/ConfirmFriendshipRequest.aspx?InvitationKey=" + GUID + "\">" + _configuration.RootURL +
            "Friends/ConfirmFriendshipRequest.aspx?InvitationKey=" + GUID + "</a><HR>" + Message;

            SendEmail(toEmail, "", "", fromFirstName + " " + fromLastName +
                " có một thư mời gia nhập vào " +
                _configuration.SiteName + "!", Message);

        }

        public void SendPasswordReminderEmail(string To, string EncryptedPassword, string Username)
        {
            string Message = "mật khẩu: " +
                             Cryptography.Decrypt(EncryptedPassword, Username);
            SendEmail(To, "", "", "Mật khẩu", Message);
        }

        public void SendEmailAddressVerificationEmail(string Username, string To)
        {
            string msg = "Nhấn vào liên kết bên dưới để chứng thực tài khoản.<BR><BR>" +
                            "<a href=\"" + _configuration.RootURL + "Accounts/VerifyEmail.aspx?a=" +
                            Username.Encrypt("verify") + "\">" +
                            _configuration.RootURL + "Accounts/VerifyEmail.aspx?a=" +
                            Username.Encrypt("verify") + "</a>";

            SendEmail(To, "", "", "Tài khoản đã được tạo! Yêu cầu bạn chứng thực bằng Email.", msg);
        }

        public void SendEmail(string From, string Subject, string Message)
        {
            MailMessage mm = new MailMessage(From, TO_EMAIL_ADDRESS);
            mm.Subject = Subject;
            mm.Body = Message;

            _emailService.Send(mm);
        }

        public void SendEmail(string To, string CC, string BCC, string Subject, string Message)
        {
            MailMessage mm = new MailMessage(FROM_EMAIL_ADDRESS, To);

            if (!string.IsNullOrEmpty(CC))
                mm.CC.Add(CC);

            if (!string.IsNullOrEmpty(BCC))
                mm.Bcc.Add(BCC);

            mm.Subject = Subject;
            mm.Body = Message;
            mm.IsBodyHtml = true;

            _emailService.Send(mm);
        }

        public void SendEmail(string[] To, string[] CC, string[] BCC, string Subject, string Message)
        {
            MailMessage mm = new MailMessage();
            foreach (string to in To)
            {
                mm.To.Add(to);
            }
            foreach (string cc in CC)
            {
                mm.CC.Add(cc);
            }
            foreach (string bcc in BCC)
            {
                mm.Bcc.Add(bcc);
            }
            mm.From = new MailAddress(FROM_EMAIL_ADDRESS);
            mm.Subject = Subject;
            mm.Body = Message;
            mm.IsBodyHtml = true;

            _emailService.Send(mm);
        }

        public void SendIndividualEmailsPerRecipient(string[] To, string Subject, string Message)
        {
            foreach (string to in To)
            {
                MailMessage mm = new MailMessage(FROM_EMAIL_ADDRESS, to);
                mm.Subject = Subject;
                mm.Body = Message;
                mm.IsBodyHtml = true;

                _emailService.Send(mm);
            }
        }
    }
}
