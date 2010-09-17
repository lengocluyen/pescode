using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;

namespace PESWeb.Mail
{
    public interface IFriends
    {
        void LoadFriends(List<Account> Friends);
    }
}
