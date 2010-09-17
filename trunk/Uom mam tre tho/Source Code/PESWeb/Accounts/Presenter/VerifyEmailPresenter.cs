using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Accounts.Interface;
using Pes.Core;
using StructureMap;
using SubSonic.Security;

namespace PESWeb.Accounts.Presenter
{
    public class VerifyEmailPresenter
    {
        public void Init(IVerifyEmail view)
        {
            IWebContext webContext = ObjectFactory.GetInstance<IWebContext>();

            string username = webContext.UsernameToVerify;
            if (string.IsNullOrEmpty(username))
            {
                IRedirector rediretor = ObjectFactory.GetInstance<IRedirector>();
                rediretor.GoToHomePage();
                return;
            }

            username = Cryptography.Decrypt(username.Replace(" ", "+"), "verify");
            Account account = Account.GetAccountByUsername(username);
            if (account != null)
            {
                if (account.EmailVerified == false)
                {
                    account.EmailVerified = true;
                    account.Save();
                    view.ShowMessage("Email của bạn đã được xác nhận thành công!");
                    return;
                }
            }

            view.ShowMessage("Xin vui lòng thử lại");
        }
    }
}
