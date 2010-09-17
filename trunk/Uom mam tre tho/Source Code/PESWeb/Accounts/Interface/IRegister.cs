using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pes.Core;

namespace PESWeb.Accounts.Interface
{
    public interface IRegister
    {
        void ShowErrorMessage(string message);
        void ShowAccountCreatedPanel();
        void ShowCreateAccountPanel();
        void ShowVerifyEmailTest();
        void LoadTerms(Term term);
        void LoadEmailAddressFromFriendInvitation(string Email);
    }
}
