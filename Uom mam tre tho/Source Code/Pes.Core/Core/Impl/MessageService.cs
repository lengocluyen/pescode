using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace Pes.Core
{
    public class MessageService:IMessageService
    {
        private IUserSession _userSession;
        private IConfiguration _configuration;
        private IEmail _email;
        public MessageService()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
            _email = ObjectFactory.GetInstance<IEmail>();
        }
        public void SendMessage(string Body, string Subject, string[] To)
        {
            Messages m = new Messages();
            m.Body = Body;
            m.Subject = Subject;
            m.CreateDate = DateTime.Now;
            m.MessageTypeID = (int)MessageTypes.Message;
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
            
            foreach (string s in To)
            {
                Account toAccount =
                    s.Contains("@") ? Account.GetAccountByEmail(s) : Account.GetAccountByUsername(s);
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

                    _email.SendNewMessageNotification(toAccount, toAccount.Email);
                }
            }
            
        }

        //public void SendMessageMail(string toEmail, string fromFirstName, string fromLastName, string GUID, string Message)
        //{
        //    Message = fromFirstName + " " + fromLastName +
        //   "Muốn kết bạn với bạn!<HR><a href=\"" + _configuration.RootURL +
        //   "Friends/ConfirmFriendInSite.aspx?InvitationKey=" + GUID + "\">" + _configuration.RootURL +
        //   "Friends/ConfirmFriendInSite.aspx?InvitationKey=" + GUID + "</a><HR>" + Message;
        //    Messages m = new Messages();
        //    m.Body = Message;
        //    m.Subject = "Thư mời kết bạn";
        //    m.CreateDate = DateTime.Now;
        //    m.MessageTypeID = (int)MessageTypes.FriendRequest;
        //    m.SentByAccountID = _userSession.CurrentUser.AccountID;
        //    m.MessageID = 0;
        //    m.Save();

        //    Int64 messageID = m.MessageID;

        //    MessageRecipient sendermr = new MessageRecipient();
        //    sendermr.AccountID = _userSession.CurrentUser.AccountID;
        //    sendermr.MessageFolderID = (int)MessageFolders.Sent;
        //    sendermr.MessageRecipientTypeID = (int)MessageRecipientTypes.TO;
        //    sendermr.MessageID = messageID;
        //    sendermr.MessageStatusTypeID = (int)MessageStatusTypes.Unread;
        //    sendermr.MessageRecipientID = 0;
        //    sendermr.Save();

        //    Account toAccount =Account.GetAccountByEmail(toEmail);
        //        if (toAccount != null)
        //        {
        //            MessageRecipient mr = new MessageRecipient();
        //            mr.AccountID = toAccount.AccountID;
        //            mr.MessageFolderID = (int)MessageFolders.Inbox;
        //            mr.MessageID = messageID;
        //            mr.MessageRecipientTypeID = (int)MessageRecipientTypes.TO;
        //            mr.MessageRecipientID = 0;
        //            mr.MessageStatusTypeID = 1;
        //            mr.Save();
        //            //_email.SendNewMessageNotification(toAccount, toAccount.Email);
        //        }
        
        //}

    }
}
