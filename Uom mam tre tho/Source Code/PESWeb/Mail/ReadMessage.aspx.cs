using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;

namespace PESWeb.Mail
{
    public partial class ReadMessage : System.Web.UI.Page, IReadMessage
    {
        private ReadMessagePresenter _presenter;

        protected MessageWithRecipient MessageReci { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ReadMessagePresenter();
            _presenter.Init(this);
            
        }
        public void LoadMessage(MessageWithRecipient message)
        {
            MessageReci = message;

            linkFrom.Text = message.Sender.Username;

            linkFrom.NavigateUrl = "../profiles/profile.aspx?AccountID=" + message.Sender.AccountID;
            Hyp_Account.NavigateUrl = "../profiles/profile.aspx?AccountID=" + message.Sender.AccountID;
            img_Account.ImageUrl = "../images/ProfileAvatar/ProfileImage.aspx?AccountID=" + message.Sender.AccountID;
            linkNext.NavigateUrl = "~/mail/ReadMessage.aspx?MessageID=" + (message.MessageRecipient.MessageID + 1).ToString();
            linkPrevious.NavigateUrl = "~/mail/ReadMessage.aspx?MessageID=" + (message.MessageRecipient.MessageID - 1).ToString();
        }

        public void btnReply_Click(object sender, EventArgs e)
        {
            _presenter.Reply();
        }
    }
}
