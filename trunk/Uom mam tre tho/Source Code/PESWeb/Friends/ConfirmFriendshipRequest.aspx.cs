using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Friends.Interface;
using PESWeb.Friends.Presenter;

namespace PESWeb.Friends
{
    public partial class ConfirmFriendshipRequest : System.Web.UI.Page, IConfirmFriendshipRequest
    {
        private ConfirmFriendshipRequestPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ConfirmFriendshipRequestPresenter();
            _presenter.Init(this);
        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            _presenter.LoginClick();
        }

        protected void lbCreateAccount_Click(object sender, EventArgs e)
        {
            _presenter.RegisterClick();
        }

        public void LoadDisplay(string FriendInvitationKey, Int32 AccountID, string AccountFirstName, string AccountLastName, string SiteName)
        {
            lblFullName.Text = AccountFirstName + " " + AccountLastName;
            lblSiteName1.Text = SiteName;
            lblSiteName2.Text = SiteName;
            imgProfileAvatar.ImageUrl = "~/images/ProfileAvatar/ProfileImage.aspx?AccountID=" + AccountID.ToString();
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
        }

        public void ShowConfirmPanel(bool value)
        {
            pnlConfirm.Visible = value;
            pnlError.Visible = !value;
        }
    }
}
