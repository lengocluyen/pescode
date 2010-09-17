using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;

namespace PESWeb.Interface
{
    public interface ISearch
    {
        void LoadAccounts(List<Account> Accounts);
    }
}
