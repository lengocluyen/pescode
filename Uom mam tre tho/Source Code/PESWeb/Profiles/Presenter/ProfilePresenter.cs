using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Profiles.Interface;
using Pes.Core;
using StructureMap;

namespace PESWeb.Profiles.Presenter
{
    public class ProfilePresenter
    {
        private IAlertService _alertService;
        private IProfile _view;
        private IWebContext _webContext;
        private IUserSession _userSession;
        private IAccountService _accountService;
        private IRedirector _redirector;
        private IPrivacyService _privacyService;

        private Account _accountBeingViewed;
        private Account _account;
        private List<PrivacyFlag> _privacyFlags;
        public int AccountID { get{return _accountBeingViewed.AccountID;} }
        public ProfilePresenter()
        {
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            if (!_userSession.LoggedIn || _userSession.CurrentUser == null)
                _redirector.GoToAccountLoginPage();

            _alertService = ObjectFactory.GetInstance<IAlertService>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _accountService = ObjectFactory.GetInstance<IAccountService>();
            _privacyService = ObjectFactory.GetInstance<IPrivacyService>();
            _account = _userSession.CurrentUser;

            if (_webContext.AccountID > 0 && _webContext.AccountID != _userSession.CurrentUser.AccountID)
            {
                _accountBeingViewed = _accountService.GetAccountByID(_webContext.AccountID);
                _accountBeingViewed.Profile = Profile.GetProfileByAccountID(_webContext.AccountID);
            }
            else
            {
                _accountBeingViewed = _userSession.CurrentUser;
                _accountBeingViewed.Profile = Profile.GetProfileByAccountID(_userSession.CurrentUser.AccountID);
            }
            if (_accountBeingViewed == null)
                _redirector.GoToAccountLoginPage();
            if (_accountBeingViewed.Profile != null && _accountBeingViewed.Profile.ProfileID > 0)
                _privacyFlags = PrivacyFlag.GetPrivacyFlagsByProfileID(_accountBeingViewed.Profile.ProfileID);
            else
                _redirector.GoToHomePage();

        }

        public void Init(IProfile View)
        {
            _view = View;
            _view.SetAvatar(_accountBeingViewed.AccountID);
            _view.DisplayInfo(_accountBeingViewed);
            _view.LoadFriends(Friend.GetFriendsAccountsByAccountID(_accountBeingViewed.AccountID));

            //_view.LoadStatusUpdates(StatusUpdate.GetTopNStatusUpdatesByAccountID(_accountBeingViewed.AccountID, 5));

            _view.ShowEditAccountInfo(_accountBeingViewed == _userSession.CurrentUser);

            TogglePrivacy();
            ShowDisplay();

        }

        public bool IsAttributeVisible(Int32 PrivacyFlagTypeID)
        {
            return _privacyService.ShouldShow(PrivacyFlagTypeID, _accountBeingViewed, _account, _privacyFlags);
        }

        private void TogglePrivacy()
        {
            _view.pnlPrivacyIMVisible(_privacyService.ShouldShow((int)PrivacyFlagType.PrivacyFlagTypes.IM, _accountBeingViewed, _account, _privacyFlags));
            _view.pnlPrivacyAccountInfoVisible(_privacyService.ShouldShow((int)PrivacyFlagType.PrivacyFlagTypes.AccountInfo, _accountBeingViewed, _account, _privacyFlags));
            _view.pnlPrivacyTankInfoVisible(_privacyService.ShouldShow((int)PrivacyFlagType.PrivacyFlagTypes.TankInfo, _accountBeingViewed, _account, _privacyFlags));
        }

        public void GoToStatusUpdates()
        {
            _redirector.GoToProfilesStatusUpdates(_accountBeingViewed.AccountID);
        }

        private void ShowDisplay()
        {
            List<Alert> list = _alertService.GetAlertsByAccountID(_accountBeingViewed.AccountID);
            _view.ShowAlerts(list);
            _view.ShowNavigation(list.Count == 20);
        }

        public void AddStatus(string text)
        {
            StatusUpdate su = new StatusUpdate();
            su.CreateDate = DateTime.Now;
            su.AccountID = _userSession.CurrentUser.AccountID;
            su.Status = text;
            StatusUpdate.SaveStatusUpdate(su);

            _alertService.AddStatusUpdateAlert(su);
            ShowDisplay();
        }
    }
}
