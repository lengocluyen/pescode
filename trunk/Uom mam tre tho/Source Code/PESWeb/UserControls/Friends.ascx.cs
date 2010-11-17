using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;

namespace PESWeb.UserControls
{
    public partial class Friends : System.Web.UI.UserControl, IFriends
    {
        protected IConfiguration _config;
        public int numpage;

        protected void Page_Load(object sender, EventArgs e)
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            if (_userSession.CurrentUser == null) return;
            _presenter.Init(this);
        }
        IUserSession _userSession;
        public FriendsPresenter _presenter;
        protected override void OnInit(EventArgs e)
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            if (_userSession.CurrentUser == null) return;
            _presenter.Init(this);
        }
        public Friends()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            if (_userSession.CurrentUser == null) return;
            try
            {
                _presenter = new FriendsPresenter();
                _config = ObjectFactory.GetInstance<IConfiguration>();
                float dc = (float)FriendsPresenter.totalItems / (float)FriendsPresenter.pageSize;
                numpage = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(dc)));

            }
            catch
            {
                return;
            }

        }

        protected void repFriends_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Image imgAvatar = e.Item.FindControl("imgAvatar") as Image;
                Label lblName = e.Item.FindControl("lblName") as Label;
                HyperLink linkProfile = e.Item.FindControl("linkProfile") as HyperLink;
                Account acc = e.Item.DataItem as Account;
                HyperLink linkProfileName = e.Item.FindControl("linkProfileName") as HyperLink;
                imgAvatar.ImageUrl += "?AccountID=" + acc.AccountID.ToString();
                linkProfileName.NavigateUrl = "~/Profiles/Profile.aspx?AccountID=" + acc.AccountID;
                lblName.Text = acc.LastName + " " + acc.FirstName;
                linkProfile.NavigateUrl = "~/Profiles/Profile.aspx?AccountID=" + acc.AccountID;

            }
        }
        public void LoadAccounts(List<Account> list)
        {
            repFriends.DataSource = list;
            repFriends.DataBind();
        }
        protected void btPrevious_Click(object sender, EventArgs e)
        {
            if (numpage > 1)
            {
                if (FriendsPresenter.currentPage <= 0)
                {
                    FriendsPresenter.currentPage = numpage - 1;
                }
                else if (FriendsPresenter.currentPage >= numpage - 1)
                    FriendsPresenter.currentPage = 0;
                else
                    FriendsPresenter.currentPage--;
                _presenter.LoadAccounts();
            }
        }
        protected void btNext_Click(object sender, EventArgs e)
        {
            if (numpage > 1)
            {
                if (FriendsPresenter.currentPage >= numpage - 1)
                    FriendsPresenter.currentPage = 0;
                else
                    FriendsPresenter.currentPage++;
                _presenter.LoadAccounts();
            }
        }
    }
}