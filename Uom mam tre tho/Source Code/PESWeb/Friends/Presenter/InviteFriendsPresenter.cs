using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Friends.Interface;
using Pes.Core;
using StructureMap;

namespace PESWeb.Friends.Presenter
{
    public class InviteFriendsPresenter
    {
        private IInviteFriends _view;
        private IUserSession _userSession;
        private IEmail _email;
        private IWebContext _webContext;
        private Account _account;
        private Account _accountToInvite;

        public void Init(IInviteFriends view)
        {
            _view = view;
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _email = ObjectFactory.GetInstance<IEmail>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _account = _userSession.CurrentUser;

            if (_account != null)
            {
                _view.DisplayToData(_account.FirstName + " " + _account.LastName + " &lt;" + _account.Email + "&gt;");

                if (_webContext.AccoundIdToInvite > 0)
                {
                    _accountToInvite = Account.GetAccountByID(_webContext.AccoundIdToInvite);

                    if (_accountToInvite != null)
                    {
                        SendInvitation(_accountToInvite.Email,
                                       _account.FirstName + " " + _account.LastName + " would like to be your friend!");
                        _view.ShowMessage(_accountToInvite.Username + " has been sent a friend request!");
                        _view.TogglePnlInvite(false);
                    }
                }
            }
        }

        public void SendInvitation(string ToEmailArray, string Message)
        {
            string resultMessage = "Invitations sent to the following recipients:<BR>";
            resultMessage += _email.SendInvitations(_userSession.CurrentUser, ToEmailArray, Message);
            _view.ShowMessage(resultMessage);
            _view.ResetUI();
        }
    }
}
