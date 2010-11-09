using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Accounts.Interface;
using Pes.Core;
using StructureMap;

namespace PESWeb.Accounts.Presenter
{
    public class LoginPresenter
    {
        private ILogin _view;
        private IRedirector _redirector;
        private IAccountService _accountService;
        private IUserSession _userSession;
        private IWebContext _webContext;

        public void Init(ILogin view)
        {
            _view = view;
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();

            if (_userSession.LoggedIn == true && _userSession.CurrentUser != null)
                _redirector.GoToHomePage();

            _accountService = ObjectFactory.GetInstance<IAccountService>();

            if (!string.IsNullOrEmpty(_webContext.FriendshipRequest))
                _view.DisplayMessage("Đăng nhập để kết bạn!");
        }

        public void Login(string username, string password)
        {
            string message = _accountService.Login(username, password);
            _view.DisplayMessage(message);
        }
        public void GoToRegister()
        {
            _redirector.GoToAccountRegisterPage();
        }

        public void GoToRecoverPassword()
        {
            _redirector.GoToAccountRecoverPasswordPage();
        }
    }
}
