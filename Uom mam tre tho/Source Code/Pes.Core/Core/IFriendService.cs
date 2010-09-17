using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public interface IFriendService
    {
        void CreateFriendFromFriendInvitation(Guid InvitationKey, Account InvitationTo);
        bool IsFriend(Account account, Account accountBeingViewed);
    }
}
