using System;
using Pes.Core;

namespace PESWeb.Mail
{
    public interface IReadMessage
    {
        void LoadMessage(MessageWithRecipient message);
    }
}
