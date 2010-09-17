using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Pes.Core.Impl
{
    public class FriendService : IFriendService
    {
        private IAlertService _alertService;

        public FriendService()
        {
            _alertService = ObjectFactory.GetInstance<IAlertService>();
        }

        public bool IsFriend(Account account, Account accountBeingViewed)
        {
            if (account == null)
                return false;

            if (accountBeingViewed == null)
                return false;

            if (account.AccountID == accountBeingViewed.AccountID)
                return true;
            else
            {
                Friend friend = Friend.GetFriendsByAccountID(accountBeingViewed.AccountID).Where(f => f.MyFriendsAccountID == account.AccountID).FirstOrDefault();
                if (friend != null)
                    return true;
            }
            return false;
        }

        public void CreateFriendFromFriendInvitation(Guid InvitationKey, Account InvitationTo)
        {
            //update friend invitation request
            FriendInvitation friendInvitation = FriendInvitation.GetFriendInvitationByGUID(InvitationKey);
            friendInvitation.BecameAccountID = InvitationTo.AccountID;
            FriendInvitation.SaveFriendInvitation(friendInvitation);
            FriendInvitation.CleanUpFriendInvitationsForThisEmail(friendInvitation);

            //create friendship
            Friend friend = new Friend();
            friend.AccountID = friendInvitation.AccountID;
            friend.MyFriendsAccountID = InvitationTo.AccountID;
            Friend.SaveFriend(friend);

            Account InvitationFrom = Account.GetAccountByID(friendInvitation.AccountID);
            _alertService.AddFriendAddedAlert(InvitationFrom, InvitationTo);

            //CHAPTER 6
            //TODO: MESSAGING - Add message to inbox regarding new friendship!
        }
    }
}
