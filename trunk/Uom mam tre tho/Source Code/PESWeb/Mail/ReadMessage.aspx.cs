using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;

namespace PESWeb.Mail
{
    public partial class ReadMessage : System.Web.UI.Page,IReadMessage
    {
        private ReadMessagePresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ReadMessagePresenter();
            _presenter.Init(this);
        }
        public void LoadMessage(MessageWithRecipient message)
        {
            linkFrom.Text = message.Sender.Username;
            linkFrom.NavigateUrl = "~/" + message.Sender.Username;
            lblSubject.Text = message.Message.Subject;
            lblMessage.Text = message.Message.Body;
        }

        public void btnReply_Click(object sender, EventArgs e)
        {
            _presenter.Reply();
        }
    }
}
