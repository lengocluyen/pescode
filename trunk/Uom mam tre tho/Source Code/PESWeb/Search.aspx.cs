using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Interface;
using Pes.Core;
using PESWeb.Presenter;
using StructureMap;
using PESWeb.UserControls;

namespace PESWeb
{
    public partial class Search : System.Web.UI.Page, ISearch
    {
        private IWebContext _webContext;
        private SearchPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _presenter = new SearchPresenter();
            _presenter.Init(this);


            if (string.IsNullOrEmpty(_webContext.SearchText))
            {
                lblSearchTerm.Text = "Please use the search box to the left!";
            }
            else
            {
                if (!IsPostBack)
                    lblSearchTerm.Text = "You searched for: " + _webContext.SearchText;

                if (_webContext.SearchText.Length > 3)
                    _presenter.PerformSearch(_webContext.SearchText);
                else
                    lblSearchTerm.Text += " <BR><BR> Your search must contain more than 3 characters!";
            }
        }

        public void LoadAccounts(List<Pes.Core.Account> Accounts)
        {
            repAccounts.DataSource = Accounts;
            repAccounts.DataBind();
        }

        protected void repAccounts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ProfileDisplay pd = e.Item.FindControl("pdProfileDisplay") as ProfileDisplay;
                pd.LoadDisplay((Account)e.Item.DataItem);
                if (_webContext.CurrentUser == null)
                    pd.ShowFriendRequestButton = false;
            }
        }
    }
}
