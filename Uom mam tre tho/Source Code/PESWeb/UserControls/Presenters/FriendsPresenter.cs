using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;
using StructureMap;

namespace PESWeb.UserControls
{
    public class FriendsPresenter
    {
        private Account _accountBeingViewed;
        IFriends _view;
        IWebContext _webContext;
        IUserSession _userSession;
        IConfiguration _config;
        public static int currentPage;
        public static int pageSize;
        public static int totalItems;
        public FriendsPresenter()
        {
            
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _config = ObjectFactory.GetInstance<IConfiguration>();
            if (_userSession.CurrentUser == null) return;
            if (_webContext.AccountID > 0 && _webContext.AccountID != _userSession.CurrentUser.AccountID)
                _accountBeingViewed = Account.GetAccountByID(_webContext.AccountID);
            else
                _accountBeingViewed = _userSession.CurrentUser;
            pageSize = _config.PageNumItem;
            totalItems = Friend.GetFriendsAccountsByAccountID(_accountBeingViewed.AccountID).Count;
        }
        internal void Init(IFriends view)
        {
            _view = view;
            this.LoadAccounts();
        }
        internal void LoadAccounts()
        {
            if (currentPage == null) currentPage = 0;
                _view.LoadAccounts(Friend.GetFriendsAccountsByAccountID(_accountBeingViewed.AccountID,currentPage,pageSize));
        }
    }
}
