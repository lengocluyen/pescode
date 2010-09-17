using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Friends.Presenter;
using PESWeb.Friends.Interface;

namespace PESWeb.Friends
{
    public partial class InviteFriends : System.Web.UI.Page, IInviteFriends
    {
        private InviteFriendsPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new InviteFriendsPresenter();
            _presenter.Init(this);
        }

        protected void btnInvite_Click(object sender, EventArgs e)
        {
            _presenter.SendInvitation(txtTo.Text, txtMessage.Text);
        }

        public void DisplayToData(string To)
        {
            lblFrom.Text = To;
        }

        public void TogglePnlInvite(bool IsVisible)
        {
            pnlInvite.Visible = IsVisible;
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
        }

        public void ResetUI()
        {
            txtMessage.Text = "";
            txtTo.Text = "";
        }
    }
}
