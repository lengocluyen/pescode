using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Accounts.Interface;
using Pes.Core;
using StructureMap;
using SubSonic.Extensions;

namespace PESWeb.Accounts.Presenter
{
    public class RecoverPasswordPresenter
    {
        private IRecoverPassword _view;
        private IEmail _email;
        private IAccountService _accountService;

        public void Init(IRecoverPassword view)
        {
            _view = view;
            _email = ObjectFactory.GetInstance<IEmail>();
            _accountService = ObjectFactory.GetInstance<IAccountService>();
        }

        public void RecoverPassword(string email)
        {
            Account account = Account.GetAccountByEmail(email);
            if (account != null)
            {
                _email.SendPasswordReminderEmail(account.Email, account.Password, account.Username);
                _view.ShowRecoverPasswordPanel(false);
                _view.ShowMessage("Xin vui lòng vào email để lấy lại mật khẩu!");

                //_view.ShowMessage("An email was sent to your account!" +
                //    account.Password.Decrypt(account.Username));
            }
            else
            {
                _view.ShowRecoverPasswordPanel(true);
                _view.ShowMessage("Không tồn tại thông tin tài khoản này trong hệ thống!");
            }
        }
    }
}
