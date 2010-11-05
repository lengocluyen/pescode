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
    public class RegisterPresenter
    {
        private IRegister _view;
        private IEmail _email;
        private IWebContext _webContext;
        private IAccountService _accountService;
        private IFriendService _friendService;
        private FriendInvitation friendInvitation;

        public void Init(IRegister view, bool IsPostBack)
        {
            _view = view;
            _email = ObjectFactory.GetInstance<IEmail>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _accountService = ObjectFactory.GetInstance<IAccountService>();
            _friendService = ObjectFactory.GetInstance<IFriendService>();

            if (!IsPostBack)
                _view.LoadTerms(Term.GetCurrentTerm());

            if (!string.IsNullOrEmpty(_webContext.FriendshipRequest))
            {
                friendInvitation = FriendInvitation.GetFriendInvitationByGUID(new Guid(_webContext.FriendshipRequest));
                _view.LoadEmailAddressFromFriendInvitation(friendInvitation.Email);
            }
        }

        public void LoginLinkClicked()
        {
            IRedirector redirector = ObjectFactory.GetInstance<IRedirector>();
            redirector.GoToAccountLoginPage();
        }

        public void Register(string username, string password, string firstname, string lastname, string email, DateTime birthDate, string captcha, bool agreeswithterms, int termid)
        {
            if (agreeswithterms)
            {
                if (captcha == _webContext.CaptchaImageText)
                {
                    if (_accountService.EmailInUse(email))
                    {
                        _view.ShowErrorMessage("Email này đã được sử dụng!");
                        //_view.ToggleWizardIndex(0);
                    }
                    else if (_accountService.UsernameInUse(username))
                    {
                        _view.ShowErrorMessage("Tên tài khoản này đã được sử dụng!");
                        //_view.ToggleWizardIndex(0);
                    }
                    else
                    {
                        Account account = new Account();
                        account.FirstName = firstname;
                        account.LastName = lastname;
                        account.Email = email;
                        account.BirthDate = birthDate;
                        account.Username = username;
                        account.Password = Cryptography.Encrypt(password, username);
                        account.TermID = termid;

                        try
                        {
                            Account.SaveAccount(account);

                            Permission publicPermission = Permission.GetPermissionByName("PUBLIC");
                            Permission registeredPermission = Permission.GetPermissionByName("REGISTERED");

                            List<Permission> list = new List<Permission>();
                            list.Add(publicPermission);
                            list.Add(registeredPermission);

                            Account.AddPermissions(account, list);

                            //if this registration came via a friend request...
                            if (friendInvitation != null)
                            {
                                _friendService.CreateFriendFromFriendInvitation(new Guid(_webContext.FriendshipRequest), account);
                            }

                           // _email.SendEmailAddressVerificationEmail(username, account.Email);
                            _view.ShowAccountCreatedPanel();
                            _view.ShowVerifyEmailTest();
                        }
                        catch (Exception)
                        {
                            _view.ShowErrorMessage("Lỗi hệ thống!");
                            //_view.ToggleWizardIndex(0);
                        }

                    }
                }
                else
                {
                    _view.ShowErrorMessage("Mã xác nhận không đúng, vui lòng nhập lại.");
                }
            }
            else
            {
                //_view.ToggleWizardIndex(2);
                _view.ShowErrorMessage("Vui lòng đồng ý với thỏa thuận sử dụng!");
            }
        }

    }
}
