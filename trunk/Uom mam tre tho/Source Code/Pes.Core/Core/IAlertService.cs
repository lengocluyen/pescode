using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public interface IAlertService
    {
        void AddAccountCreatedAlert();
        void AddAccountModifiedAlert(Account modifiedAccount);
        void AddProfileCreatedAlert();
        void AddProfileModifiedAlert();
        void AddNewAvatarAlert();
        List<Alert> GetAlertsByAccountID(Int32 AccountID);
        List<Alert> GetAlertsByAccountID(int AccountID, int currentIndex, int itemAdd);

        void AddFriendAddedAlert(Account FriendRequestFrom, Account FriendRequestTo);
        void AddFriendRequestAlert(Account FriendRequestFrom, Account FriendRequestTo, Guid requestGuid, string Message);
        long AddStatusUpdateAlert(StatusUpdate statusUpdate);
        void AddNewBoardPostAlert(BoardCategory category, BoardForum forum, BoardPost post, BoardPost thread);
        void AddNewBoardThreadAlert(BoardCategory category, BoardForum forum, BoardPost post);
        void AddNewBoardThreadAlert(BoardCategory category, BoardForum forum, BoardPost post, Group group);
        void AddNewBoardPostAlert(BoardCategory category, BoardForum forum, BoardPost post, BoardPost thread,
                                  Group group);
        void AddNewBlogPostAlert(Blog blog);
        void AddUpdatedBlogPostAlert(Blog blog);
        List<Alert> GetAlertsOfMeAndFriendByAccountID(int accID);
    }
}
