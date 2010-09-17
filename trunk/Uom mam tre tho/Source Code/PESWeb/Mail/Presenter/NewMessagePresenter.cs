using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;
using StructureMap;

namespace PESWeb.Mail
{
    public class NewMessagePresenter
    {
        private INewMessage _view;
        private IWebContext _webContext;
        private IMessageService _messageService;
        private IUserSession _userSession;

        public NewMessagePresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _messageService = ObjectFactory.GetInstance<IMessageService>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }
        public void Init(INewMessage view)
        {
            _view = view;
            if (_webContext.MessageID != 0)
                _view.LoadReply(Messages.GetMessageByMessageID(_webContext.MessageID, _userSession.CurrentUser.AccountID));
            if (_webContext.AccountID != 0)
                _view.LoadTo(Account.GetAccountByID(_webContext.AccountID).Username);
        }
        public void SendMessage(string Subject, string Message, string[] To)
        {
            _messageService.SendMessage(Message,Subject,  To);
        }
    }
}
