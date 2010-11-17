using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Interface;
using Pes.Core;
using StructureMap;

namespace PESWeb.Presenter
{
    public class DefaultPresenter
    {
        public IDefault _view;
        private IAlertService _alertService;
        private IWebContext _webContext;
        private IUserSession _userSession;
        private IAccountService _accountService;
        private IRedirector _redirector;
        private IPrivacyService _privacyService;
        private Account _accountBeingViewed;
        public static int currentItem = 20;

        public int AccountID { get { return _accountBeingViewed.AccountID; } }

        public DefaultPresenter()
        {
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            if (!_userSession.LoggedIn || _userSession.CurrentUser == null)
                _redirector.GoToAccountLoginPage();

            _alertService = ObjectFactory.GetInstance<IAlertService>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _accountService = ObjectFactory.GetInstance<IAccountService>();
            _privacyService = ObjectFactory.GetInstance<IPrivacyService>();
            if (_webContext.AccountID > 0 && _webContext.AccountID != _userSession.CurrentUser.AccountID)
                _accountBeingViewed = _accountService.GetAccountByID(_webContext.AccountID);
            else
                _accountBeingViewed = _userSession.CurrentUser;
        }
        public void Init(IDefault view, bool postBack)
        {
            _view = view;
            _view.TotalItem = Alert.CountAlertsByAccountID(_accountBeingViewed.AccountID);
            ShowDisplay();

        }
        public void AddStatus(string text)
        {
            StatusUpdate su = new StatusUpdate();
            su.CreateDate = DateTime.Now;
            su.AccountID = _userSession.CurrentUser.AccountID;
            su.Status = text;
            StatusUpdate.SaveStatusUpdate(su);

            _alertService.AddStatusUpdateAlert(su);
            //_redirector.GoToHomePage();
            ShowDisplay();
        }
        private void ShowDisplay()
        {
            List<Alert> list = _alertService.GetAlertsByAccountID(_accountBeingViewed.AccountID);
            _view.ShowAlerts(list);
            _view.ShowNavigation(list.Count == 20);
        }

    }
}
