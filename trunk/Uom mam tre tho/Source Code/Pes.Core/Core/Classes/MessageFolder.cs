using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public enum MessageFolders
    {
        Inbox = 1,
        Sent = 2,
        Trash = 3,
        Spam = 4
    }
    public partial class MessageFolder
    {
        public static MessageFolder GetMessageFolderByID(Int32 MessageFolderID)
        {
              return All().Where(mf => mf.MessageFolderID == MessageFolderID).FirstOrDefault();
        }

        public static List<MessageFolder> GetMessageFoldersByAccountID(Int32 AccountID)
        {
                IEnumerable<MessageFolder> systemFolders = All().Where(mf => mf.IsSystem == true);
                IEnumerable<MessageFolder> userFolders = All().Where(mf => mf.AccountID == AccountID);
                return systemFolders.Union(userFolders).ToList();
        }

        public static void DeleteMessageFolder(Int32 messageFolderID)
        {
            Delete(messageFolderID);
        }
    }
}