using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PESWeb.Friends
{
    public interface IConfirmFriendInSite
    {
        void LoadDisplay(string FriendInvitationKey, Int32 AccountID, string AccountFirstName, string AccountLastName, string SiteName);
        void ShowConfirmPanel(bool value);
        void ShowMessage(string Message);
    }
}
