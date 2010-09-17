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
    public partial class RecoverPassword : System.Web.UI.Page, IRecoverPassword
    {
        private RecoverPasswordPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new RecoverPasswordPresenter();
            _presenter.Init(this);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnRecoverPassword.Click += new EventHandler(btnRecoverPassword_Click);
        }

        void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            _presenter.RecoverPassword(txtEmail.Text);
        }

        public void ShowMessage(string message)
        {
            lblMessage.Text = message;
        }

        public void ShowRecoverPasswordPanel(bool value)
        {
            pnlRecoverPassword.Visible = value;
        }
    }
}
