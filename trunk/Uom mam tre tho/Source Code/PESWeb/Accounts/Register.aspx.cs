using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Accounts.Interface;
using PESWeb.Accounts.Presenter;
using SubSonic.Extensions;
using Pes.Core;

namespace PESWeb.Accounts
{
    public partial class Register : System.Web.UI.Page, IRegister
    {
        private RegisterPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new RegisterPresenter();
            _presenter.Init(this, IsPostBack);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnSignUp.Click += new EventHandler(btnSignUp_Click);

            int i;
            for (i = 1; i <= 31; i++)
                ddlDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            for (i = 1; i <= 12; i++)
                ddlMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
            for (i = DateTime.Now.Year; i >= 1900; i--)
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        private DateTime Birthday
        {
            get
            {
                return DateTime.Parse(string.Format("{0}/{1}/{2}",
                    ddlDay.SelectedValue, ddlMonth.SelectedValue, ddlYear.SelectedValue));
            }
        }

        void btnSignUp_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                _presenter.Register(txtUsername.Text, txtPassword.Text, txtFirstName.Text, txtLastName.Text, txtEmail.Text,
                    Birthday, txtCaptcha.Text, chkAgreeWithTerms.Checked, lblTermID.Text.ChangeTypeTo<int>(0));
            }
        }

        #region IRegister Members

        public void ShowErrorMessage(string message)
        {
            lblErrorMessage.Text = message;
        }

        public void ShowAccountCreatedPanel()
        {
            pnlAccountCreated.Visible = true;
            pnlCreateAccount.Visible = false;
        }

        public void ShowCreateAccountPanel()
        {
            pnlAccountCreated.Visible = false;
            pnlCreateAccount.Visible = true;
        }

        public void ToggleWizardIndex(int index)
        {
        }

        public void LoadTerms(Term term)
        {
            lblTermID.Text = term.TermID.ToString();
        }

        public void LoadEmailAddressFromFriendInvitation(string Email)
        {
            txtEmail.Text = Email;
        }

        public void ShowVerifyEmailTest()
        {
            lnkVerifyEmail.NavigateUrl = "~/Accounts/VerifyEmail.aspx?a=" + txtUsername.Text.Encrypt("verify");
        }

        #endregion
    }
}
