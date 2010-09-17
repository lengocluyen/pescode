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
    public partial class Friends : System.Web.UI.UserControl,IFriends
    {
        protected IConfiguration _config;
        public int numpage;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Init(this);
        }
        public FriendsPresenter _presenter;
        protected override void OnInit(EventArgs e)
        {
            _presenter.Init(this);
        }
        public Friends()
        {
            _presenter = new FriendsPresenter();
            _config = ObjectFactory.GetInstance<IConfiguration>();
            float dc = (float)FriendsPresenter.totalItems /(float) FriendsPresenter.pageSize;
            numpage =Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(dc)));

        }

        protected void repFriends_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ProfileDisplay pdProfileDisplay = e.Item.FindControl("pdProfileDisplay") as ProfileDisplay;
                pdProfileDisplay.LoadDisplay(((Account)e.Item.DataItem));
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
                    FriendsPresenter.currentPage = numpage-1;
                }
                else if (FriendsPresenter.currentPage >= numpage-1)
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
                if (FriendsPresenter.currentPage >= numpage-1)
                    FriendsPresenter.currentPage = 0;
                else
                    FriendsPresenter.currentPage++;
                _presenter.LoadAccounts();
            }
        }
    }
}