using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Friends.Presenter;
using PESWeb.Friends.Interface;
using PESWeb.UserControls;
using Pes.Core;

namespace PESWeb.Friends
{
    public partial class Default : System.Web.UI.Page, IDefault
    {
        private DefaultPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new DefaultPresenter();
            _presenter.Init(this);
        }

        protected void repFriends_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ProfileDisplay pdProfileDisplay = e.Item.FindControl("pdProfileDisplay") as ProfileDisplay;
                pdProfileDisplay.LoadDisplay(((Account)e.Item.DataItem));
            }
        }

        public void LoadDisplay(List<Account> Accounts)
        {
            repFriends.DataSource = Accounts;
            repFriends.DataBind();
            if (Accounts.Count < 1)
                lbCountFriends.Text = "Bạn chưa có bạn bè nào";
            else
                lbCountFriends.Text = "Bạn có " + Accounts.Count.ToString() + " bạn bè";
        }
    }
}
