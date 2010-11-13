using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using Pes.Core;

namespace PESWeb.Friends
{
    public class ConfirmFriendInSitePresenter
    {
        private IConfirmFriendInSite _view;
        private IWebContext _webContext;
        private IConfiguration _configuration;
        private IRedirector _redirector;
        private IFriendService _friendService;
        public ConfirmFriendInSitePresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _configuration = ObjectFactory.GetInstance<IConfiguration>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _friendService = ObjectFactory.GetInstance<IFriendService>();
        }

        public void Init(IConfirmFriendInSite view)
        {
            _view = view;
            if (!string.IsNullOrEmpty(_webContext.FriendshipRequest))
            {
                FriendInvitation friendInvitation =
                    FriendInvitation.GetFriendInvitationByGUID(new Guid(_webContext.FriendshipRequest));
                if (friendInvitation != null)
                {
                    if (_webContext.CurrentUser != null){
                        //LoginClick();
                        if (!string.IsNullOrEmpty(_webContext.FriendshipRequest))
                            _friendService.CreateFriendFromFriendInvitation(new Guid(_webContext.FriendshipRequest), _webContext.CurrentUser);
                         _view.ShowConfirmPanel(true);
                        return;
                    }

                    //Account account = Account.GetAccountByID(friendInvitation.AccountID);
                   
                    //_view.LoadDisplay(_webContext.FriendshipRequest, account.AccountID, account.FirstName, account.LastName, _configuration.SiteName);
                }
                else
                {
                    _view.ShowConfirmPanel(false);
                    _view.ShowMessage("Lỗi thực thi.");
                }
            }
            else
            {
                _redirector.GoToHomePage();
            }
        }

        public void LoginClick()
        {
            _redirector.GoToAccountLoginPage(_webContext.FriendshipRequest);
        }

        public void RegisterClick()
        {
            _redirector.GoToAccountRegisterPage(_webContext.FriendshipRequest);
        }
    }
}
