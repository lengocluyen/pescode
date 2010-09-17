using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PESWeb.Accounts.Interface
{
    public interface IRecoverPassword
    {
        void ShowMessage(string message);
        void ShowRecoverPasswordPanel(bool value);
    }
}
