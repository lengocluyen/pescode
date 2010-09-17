using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class MessageRecipient
    {
        public static List<MessageRecipient> GetMessageRecipientsByMessageID(Int32 MessageID)
        {
            var recipients = All().Where(mr => mr.MessageID == MessageID);
            return recipients.ToList();
        }

        public static MessageRecipient GetMessageRecipientByID(Int32 MessageRecipientID)
        {
            var result = All().Where(mr => mr.MessageRecipientID == MessageRecipientID).FirstOrDefault();
            return result;
        }

        public static void DeleteMessageRecipient(MessageRecipient messageRecipient)
        {
            Delete(messageRecipient.MessageRecipientID);
            int RemainingRecipientCount =
                All().Where(mr => mr.MessageID == messageRecipient.MessageID).Count();
             if (RemainingRecipientCount == 0)
             {
                Messages.DeleteMany(m => m.MessageID == messageRecipient.MessageID);
             }
        }
    }
}