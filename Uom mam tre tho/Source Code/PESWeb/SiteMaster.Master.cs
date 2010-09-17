using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;

namespace PESWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private IUserSession _userSession;
        private INavigation _navigation;
        protected IRedirector _redirector;
        private IAlertService _alertService;
        protected IWebContext _webContext;
        public SiteMaster()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                if (!string.IsNullOrEmpty(_title))
                {
                    Page.Title = _title;
                    //lblPageTitle.Text = _title;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
         
            if (!_userSession.LoggedIn || _userSession.CurrentUser == null)
                _redirector.GoToAccountLoginPage();

            _navigation = ObjectFactory.GetInstance<INavigation>();
            _alertService = ObjectFactory.GetInstance<IAlertService>();

            //repPrimaryNav.DataSource = _navigation.PrimaryNodes();
            //repPrimaryNav.DataBind();

            if (_navigation.CurrentNode != null)
            {
                if (_navigation.CurrentNode["PageTitle"] != null &&
                    !String.IsNullOrEmpty(_navigation.CurrentNode["PageTitle"]))
                {
                    //lblPageTitle.Text = _navigation.CurrentNode["PageTitle"].ToString();
                    Page.Title = _navigation.CurrentNode["PageTitle"].ToString();
                }
                else
                {
                    //lblPageTitle.Text = _navigation.CurrentNode.Title;
                    Page.Title = _navigation.CurrentNode.Title;
                }
            }

            //if (_userSession.CurrentUser != null)
            //{
            //    LoadStatus();
            //    pnlStatusUpdate.Visible = true;
            //}
            //else
            //    pnlStatusUpdate.Visible = false;
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            lbLogOut.Click += new EventHandler(lbLogOut_Click);
            //repPrimaryNav.ItemDataBound += new RepeaterItemEventHandler(repPrimaryNav_ItemDataBound);
           // btSearch.ServerClick += new EventHandler(btnSearch_Click);
        
        }

        void lbLogOut_Click(object sender, EventArgs e)
        {
            IAccountService _acountService = ObjectFactory.GetInstance<IAccountService>();
            _acountService.Logout();
            _redirector.GoToWelcomePage();
        }

      

        void repPrimaryNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                HyperLink link = e.Item.FindControl("linkPrimaryNav") as HyperLink;
                SiteMapNode node = (SiteMapNode)e.Item.DataItem;
                link.Text = node.Title;
                link.NavigateUrl = node.Url;
                if (node == _navigation.CurrentNode
                    || node == _navigation.CurrentNode.ParentNode)
                {
                    link.CssClass = "PrimaryPrimaryActive";
                }
            }
        }
        protected void LoadStatus()
        {
            //repStatus.DataSource =
            //    StatusUpdate.GetTopNStatusUpdatesByAccountID(_userSession.CurrentUser.AccountID, 5);
            //repStatus.DataBind();
        }
        protected void btnAddStatus_Click(object sender, EventArgs e)
        {
            //StatusUpdate su = new StatusUpdate();
            //su.CreateDate = DateTime.Now;
            //su.AccountID = _userSession.CurrentUser.AccountID;
            //su.Status = txtStatusUpdate.Text;
            //StatusUpdate.SaveStatusUpdate(su);

            //_alertService.AddStatusUpdateAlert(su);
            //_redirector.GoToHomePage();
        }

        protected void btnShowAllStatusUpdates_Click(object sender, EventArgs e)
        {
            _redirector.GoToProfilesStatusUpdates();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
             if(txtSearch.Value.Trim().Length>0)
            _redirector.GoToSearch(txtSearch.Value);
        }
    }
}
