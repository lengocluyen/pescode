using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Profiles.Interface;
using Pes.Core;
using StructureMap;

namespace PESWeb.Profiles.Presenter
{
    public class DefaultPresenter
    {
        private IDefault _view;
        private IAlertService _alertService;
        private IUserSession _userSession;

        public DefaultPresenter()
        {
            _alertService = ObjectFactory.GetInstance<IAlertService>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }
        public void Init(IDefault view)
        {
            _view = view;
            ShowDisplay();
        }

        private void ShowDisplay()
        {
            _view.ShowAlerts(_alertService.GetAlertsByAccountID(_userSession.CurrentUser.AccountID));
        }
    }
}
