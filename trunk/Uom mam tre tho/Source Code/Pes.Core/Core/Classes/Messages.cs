using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Messages
    {
        public static int GetPageCount(MessageFolders messageFolder, Int32 RecipientAccountID)
        {
            int result = (from r in MessageRecipient.All()
                          where r.AccountID == RecipientAccountID && r.MessageFolderID == (int)messageFolder
                          select r).Count();
            if (result < 10)
                result = 1;
            else
            {
                if (result % 10 == 0)
                    result /= 10;
                else
                {
                    if ((result /= 10) < 1)
                        result = 1;
                    result /= 10 + 1;
                }
            }
            return result;
        }
        public static List<MessageWithRecipient> GetMessageByAccountID(Int64 AccountID, Int32 PageNumber, MessageFolders Folder)
        {
            //List<Messages> aMessage = All().ToList();
            //List<Account> aAccount = Account.All().ToList();
            //List<MessageRecipient> aMessageRecipient = MessageRecipient.All().ToList();

            //IEnumerable<MessageWithRecipient> messages =
            //     (from r in aMessageRecipient
            //      join m in aMessage on r.MessageID equals m.MessageID
            //      join a in aAccount on m.SentByAccountID equals a.AccountID
            //      where r.AccountID == AccountID && r.MessageFolderID == (int)Folder
            //      orderby m.CreateDate descending
            //      select new MessageWithRecipient()
            //      {
            //          Sender = a,
            //          Message = m,
            //          MessageRecipient = r
            //      }).Skip((PageNumber - 1) * 10).Take(10);

            //return messages.ToList();

            var query = (from r in MessageRecipient.All()
                         join m in Messages.All() on r.MessageID equals m.MessageID
                         join a in Account.All() on m.SentByAccountID equals a.AccountID
                         where r.AccountID == AccountID && r.MessageFolderID == (int)Folder
                         orderby m.CreateDate descending
                         select new
                         {
                             Sender = a,
                             Message = m,
                             MessageRecipient = r
                         }).Skip((PageNumber - 1) * 10).Take(10);

            List<MessageWithRecipient> list = new List<MessageWithRecipient>();
            foreach (var item in query)
            {
                MessageWithRecipient m = new MessageWithRecipient();
                m.Sender = item.Sender;
                m.Message = item.Message;
                m.MessageRecipient = item.MessageRecipient;
                list.Add(m);
            }
            return list;
        }

        public static MessageWithRecipient GetMessageByMessageID(Int32 MessageID, Int32 RecipientAccountID)
        {
            IEnumerable<Messages> aMessage = All();
            IEnumerable<Account> aAccount = Account.All();
            IEnumerable<MessageRecipient> aMessageRecipient = MessageRecipient.All();

            var message = (from r in aMessageRecipient
                           join m in aMessage on r.MessageID equals m.MessageID
                           join a in aAccount on m.SentByAccountID equals a.AccountID
                           where r.AccountID == RecipientAccountID &&
                           m.MessageID == MessageID
                           where r.AccountID == RecipientAccountID && m.MessageID == MessageID
                           select new MessageWithRecipient()
                           {
                               Sender = a,
                               Message = m,
                               MessageRecipient = r
                           }).FirstOrDefault();
            return message;
        }

        public static IEnumerable<MessageWithRecipient> GetListMessageByMessageID(Int32 MessageID, Int32 RecipientAccountID)
        {
            IEnumerable<Messages> aMessage = All();
            IEnumerable<Account> aAccount = Account.All();
            IEnumerable<MessageRecipient> aMessageRecipient = MessageRecipient.All();

            var message = (from r in aMessageRecipient
                           join m in aMessage on r.MessageID equals m.MessageID
                           join a in aAccount on m.SentByAccountID equals a.AccountID
                           where r.AccountID == RecipientAccountID &&
                           m.MessageID == MessageID
                           where r.AccountID == RecipientAccountID && m.MessageID == MessageID
                           select new MessageWithRecipient()
                           {
                               Sender = a,
                               Message = m,
                               MessageRecipient = r
                           }).Distinct();
            return message;
        }

        public static void DeleteMessage(Int32 messageID)
        {
            MessageRecipient.DeleteMany(mr => mr.MessageID == messageID);
            Delete(messageID);
        }

    }
}