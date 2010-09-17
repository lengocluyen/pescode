using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;
using PESWeb.Profiles.Presenter;
using PESWeb.Profiles.Interface;

namespace PESWeb.Profiles
{
    public partial class StatusUpdates : System.Web.UI.Page, IStatusUpdates
    {
        private StatusUpdatesPresenter _presenter;
        private IWebContext _webContext;
        private IUserSession _userSession;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new StatusUpdatesPresenter();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();

            if (_webContext.AccountID > 0)
                _presenter.Init(this, _webContext.AccountID);
            else if (_userSession.CurrentUser != null)
                _presenter.Init(this, _userSession.CurrentUser.AccountID);
        }

        public void ShowUpdates(List<StatusUpdate> StatusUpdates)
        {
            repStatusUpdates.DataSource = StatusUpdates;
            repStatusUpdates.DataBind();
        }
    }
}
