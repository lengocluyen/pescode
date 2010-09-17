using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public interface IAccountService
    {
        bool UsernameInUse(string username);
        bool EmailInUse(string email);
        string Login(string username, string password);
        void Logout();
        Account GetAccountByID(int accountID);
        Account LoginService(string username, string password);
    }
}
