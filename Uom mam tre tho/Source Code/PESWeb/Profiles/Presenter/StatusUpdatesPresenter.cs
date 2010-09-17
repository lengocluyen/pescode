using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Profiles.Interface;
using Pes.Core;

namespace PESWeb.Profiles.Presenter
{
    public class StatusUpdatesPresenter
    {
        private IStatusUpdates _view;
        private Int32 _accountIDToShow;

        public StatusUpdatesPresenter()
        {
        }

        public void Init(IStatusUpdates view, Int32 AccountIDToShow)
        {
            _view = view;
            _accountIDToShow = AccountIDToShow;
            ShowStatusUpdates();
        }

        private void ShowStatusUpdates()
        {
            _view.ShowUpdates(StatusUpdate.GetStatusUpdatesByAccountID(_accountIDToShow));
        }
    }
}
