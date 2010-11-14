using System;
using Pes.Core;
using System.Collections.Generic;

namespace PESWeb.Mail
{
    public interface IReadMessage
    {
        void LoadMessage(MessageWithRecipient message);
    }
}
