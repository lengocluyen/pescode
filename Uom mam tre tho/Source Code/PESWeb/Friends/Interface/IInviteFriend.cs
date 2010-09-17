using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PESWeb.Friends.Interface
{
    public interface IInviteFriends
    {
        void DisplayToData(string To);
        void ShowMessage(string Message);
        void ResetUI();
        void TogglePnlInvite(bool IsVisible);
    }
}
