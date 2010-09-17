using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class FriendInvitation
    {

        public static List<FriendInvitation> GetFriendInvitationsByAccountID(Int32 AccountID)
        {
            return FriendInvitation.Find(fi => fi.AccountID == AccountID);
        }

        public static FriendInvitation GetFriendInvitationByGUID(Guid guid)
        {
            return FriendInvitation.Single(fi => fi.GUID == guid);
        }

        public static void SaveFriendInvitation(FriendInvitation friendInvitation)
        {
            if (friendInvitation.InvitationID > 0)
            {
                FriendInvitation.Update(friendInvitation);
            }
            else
            {
                friendInvitation.CreateDate = DateTime.Now;
                FriendInvitation.Add(friendInvitation);
            }

        }

        //removes multiple requests by the same account to the same email account
        public static void CleanUpFriendInvitationsForThisEmail(FriendInvitation friendInvitation)
        {
            FriendInvitation.DeleteMany(fi => fi.Email == friendInvitation.Email &&
                                             fi.BecameAccountID == 0 &&
                                             fi.AccountID == friendInvitation.AccountID);
        }
    }
}