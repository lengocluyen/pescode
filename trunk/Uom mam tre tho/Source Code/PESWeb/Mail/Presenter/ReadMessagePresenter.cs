using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;
using StructureMap;

namespace PESWeb.Mail
{
    public class ReadMessagePresenter
    {
        private IReadMessage _view;
        private IWebContext _webContext;
        private IUserSession _userSession;
        private IRedirector _redirector;

        public ReadMessagePresenter()
        {
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }
        public void Init(IReadMessage view)
        {
            _view = view;
            _view.LoadMessage(Messages.GetMessageByMessageID(_webContext.MessageID, _userSession.CurrentUser.AccountID));
        }
        public void Reply()
        {
            _redirector.GoToMailNewMessage(_webContext.MessageID);
        }
    }
}
