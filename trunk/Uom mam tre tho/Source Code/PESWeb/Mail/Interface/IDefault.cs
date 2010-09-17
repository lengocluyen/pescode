using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;

namespace PESWeb.Mail
{
    public interface IDefault
    {
        void LoadMessages(List<MessageWithRecipient> Messages);
        List<Int32> ExtractSelectedMessages();
        void DisplayPageNavigation(Int32 PageCount, MessageFolders folder, Int32 CurrentPage);
    }
}
