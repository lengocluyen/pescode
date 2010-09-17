using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;

namespace PESWeb.UserControls
{
    public interface IFriends
    {
        void LoadAccounts(List<Account> list);
    }
}
