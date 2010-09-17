using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;

namespace PESWeb.UserControls.Interfaces
{
    public interface IProfileDisplay
    {
        void LoadDisplay(Account account);
        bool ShowFriendRequestButton { set; }
        bool ShowDeleteButton { set; }
    }
}
