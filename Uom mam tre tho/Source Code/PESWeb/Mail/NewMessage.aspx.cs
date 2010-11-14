using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;
using System.Text;

namespace PESWeb.Mail
{
    public partial class NewMessage : System.Web.UI.Page,INewMessage
    {
        private NewMessagePresenter _presenter;
        protected IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BuildJS();
            _presenter = new NewMessagePresenter();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _presenter.Init(this);
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string[] to = txtTo.Text.Split(new char[] { ',', ';' });
            _presenter.SendMessage(txtSubject.Text, txtMessage.Value, to);

            pnlSendMessage.Visible = false;
            pnlSent.Visible = true;
        }

        public void LoadReply(MessageWithRecipient message)
        {
            txtSubject.Text = "RE: " + message.Message.Subject;
            txtTo.Text = message.Sender.Username;
            txtMessage.Value = "<BR><BR><HR>Gửi từ ngày: " + message.Message.CreateDate.ToString() + "<BR>Tiêu đề: " + message.Message.Subject + "<BR>Nội dung: " + message.Message.Body;
        }

        public void LoadTo(string Username)
        {
            txtTo.Text = Username;
        }
        private void BuildJS()
        {
            StringBuilder _js = new StringBuilder();
            _js.AppendLine("<script type=''text/javascript' language='javascript'>");
            _js.AppendLine("CKEDITOR.replace('" + txtMessage.ClientID + "',{extraPlugins : 'uicolor',uiColor: '#C1E8C1',skin:'kama'});");
            _js.AppendLine("</script>");
            ClientScript.RegisterStartupScript(GetType(), "CKEditor", _js.ToString());
        }
    }
}
