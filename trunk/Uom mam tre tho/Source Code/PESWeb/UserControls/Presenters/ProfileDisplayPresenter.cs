using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using PESWeb.UserControls.Interfaces;
using Pes.Core;

namespace PESWeb.UserControls.Presenters
{
    public class ProfileDisplayPresenter
    {
        private IProfileDisplay _view;
        private IRedirector _redirector;
        private IUserSession _userSession;

        public ProfileDisplayPresenter()
        {
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }

        public void Init(IProfileDisplay view)
        {
            _view = view;
        }

        public void SendFriendRequest(Int32 AccountIdToInvite)
        {
            _redirector.GoToFriendsInviteFriends(AccountIdToInvite);
        }

        public void DeleteFriend(Int32 FriendID)
        {
            if (_userSession.CurrentUser != null)
            {
                Friend.DeleteFriendByID(_userSession.CurrentUser.AccountID, FriendID);
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
    }
}
