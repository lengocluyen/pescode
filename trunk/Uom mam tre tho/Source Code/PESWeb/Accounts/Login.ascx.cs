using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Accounts.Presenter;
using PESWeb.Accounts.Interface;
namespace PESWeb.Accounts
{
    public partial class Login1 : System.Web.UI.UserControl, ILogin
    {
        private LoginPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new LoginPresenter();
            _presenter.Init(this);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnLogin.Click += new EventHandler(btnLogin_Click);
        }

        void lbRegister_Click(object sender, EventArgs e)
        {
            _presenter.GoToRegister();
        }

        void lbRecoverPassword_Click(object sender, EventArgs e)
        {
            _presenter.GoToRecoverPassword();
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            _presenter.Login(txtUsername.Text, txtPassword.Text);
        }

        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
        }
    }
}