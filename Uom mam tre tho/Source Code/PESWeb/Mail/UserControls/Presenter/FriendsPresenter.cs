using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;
using StructureMap;

namespace PESWeb.Mail
{
    public class FriendsPresenter
    {
        private IFriends _view;
        private IUserSession _userSession;

        public FriendsPresenter()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }
        public void Init(IFriends view)
        {
            _view = view;
            _view.LoadFriends(Friend.GetFriendsAccountsByAccountID(_userSession.CurrentUser.AccountID));
        }
    }
}
