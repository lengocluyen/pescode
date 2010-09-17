using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Accounts.Interface;
using PESWeb.Accounts.Presenter;

namespace PESWeb.Accounts
{
    public partial class VerifyEmail : System.Web.UI.Page, IVerifyEmail
    {
        private VerifyEmailPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new VerifyEmailPresenter();
            _presenter.Init(this);
        }

        public void ShowMessage(string message)
        {
            lblMsg.Text = message;
        }
    }
}
