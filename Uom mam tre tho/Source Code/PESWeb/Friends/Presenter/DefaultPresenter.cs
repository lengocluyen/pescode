using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Friends.Interface;
using Pes.Core;
using StructureMap;

namespace PESWeb.Friends.Presenter
{
    public class DefaultPresenter
    {
        private IDefault _view;
        private IUserSession _userSession;

        public DefaultPresenter()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }

        public void Init(IDefault view)
        {
            _view = view;
            LoadDisplay();
        }

        public void LoadDisplay()
        {
            _view.LoadDisplay(Friend.GetFriendsAccountsByAccountID(_userSession.CurrentUser.AccountID));
        }
    }
}
