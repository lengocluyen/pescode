using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public enum MessageStatusTypes
    {
        Unread = 1,
        Read = 2,
        Replied = 3,
        Forwarded = 4,
        Spam = 5,
        Filtered = 6
    }
    public partial class MessageStatusType
    {
    
    }
}