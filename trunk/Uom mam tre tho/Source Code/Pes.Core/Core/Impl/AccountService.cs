using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using SubSonic.Security;

namespace Pes.Core.Impl
{
    public class AccountService : IAccountService
    {
        private IUserSession _userSession;
        private IEmail _email;
        private IRedirector _redirector;
        private IProfileService _profileService;
        private Account account;
        private IWebContext _webContext;
        private IFriendService _friendService;

        public AccountService()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _email = ObjectFactory.GetInstance<IEmail>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _profileService = ObjectFactory.GetInstance<IProfileService>();
            _friendService = ObjectFactory.GetInstance<IFriendService>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public bool UsernameInUse(string username)
        {
            return Account.Exists(x => x.Username == username);
        }

        public bool EmailInUse(string email)
        {
            return Account.Exists(x => x.Email == email);
        }
        public Account LoginService(string username, string password)
        {
            password = Cryptography.Encrypt(password, username);
            //account =  Account.GetAccountByUsername(username);
            account = Account.Single(a => a.Username == username && a.Password == password);
            if (account != null)
            {
                _userSession.LoggedIn = true;
                _userSession.Username = username;
                _userSession.CurrentUser = GetAccountByID(account.AccountID);
                return account;
            }
            return null;
        }
        public string Login(string username, string password)
        {
            password = Cryptography.Encrypt(password, username);
            account = Account.GetAccountByUsername(username);
            if (account != null)
            {
                if (account.Password == password)
                {
                    if (account.EmailVerified == true)
                    {
                        _userSession.LoggedIn = true;
                        _userSession.Username = username;
                        _userSession.CurrentUser = GetAccountByID(account.AccountID);

                        if (!string.IsNullOrEmpty(_webContext.FriendshipRequest))
                            _friendService.CreateFriendFromFriendInvitation(new Guid(_webContext.FriendshipRequest), _userSession.CurrentUser);

                        if (_userSession.CurrentUser.Profile != null)
                            _redirector.GoToHomePage();
                        else
                            _redirector.GoToProfilesManageProfile();
                    }
                    else
                    {
                        _email.SendEmailAddressVerificationEmail(username, account.Email);
                        return @"Xin vui lòng làm theo hướng dẫn trong email của bạn để kích hoạt tài khoản.";
                    }
                }
                else
                {
                    return "Mật khẩu hoặc tài khoản không đúng!";

                }
            }
            return "Mật khẩu hoặc tài khoản không đúng!";


        }

        public void Logout()
        {
            _userSession.LoggedIn = false;
            _userSession.CurrentUser = null;
            _userSession.Username = "";
            _redirector.GoToAccountLoginPage();
        }

        public Account GetAccountByID(int accountID)
        {
            if (account == null)
                account = Account.Single(accountID);
            if (account != null)
            {
                account.Profile = _profileService.LoadProfileByAccountID(accountID);
                foreach (var p in Permission.GetPermissionsByAccountID(accountID))
                    account.AddPermission(p);
            }
            return account;
        }
    }
}
