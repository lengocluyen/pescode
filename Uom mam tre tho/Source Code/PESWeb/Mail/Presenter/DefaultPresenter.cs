using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;
using StructureMap;

namespace PESWeb.Mail
{
    public class DefaultPresenter
    {
        private IDefault _view;
        private IUserSession _userSession;
        private IWebContext _webContext;

        public DefaultPresenter()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IDefault view)
        {
            _view = view;
            if (_userSession.CurrentUser != null)
            {
                _view.LoadMessages(Messages.GetMessageByAccountID(_userSession.CurrentUser.AccountID,
                    _webContext.PageNumber, (MessageFolders)_webContext.FolderID));

                _view.DisplayPageNavigation(Messages.GetPageCount((MessageFolders) _webContext.FolderID,
                    _userSession.CurrentUser.AccountID),(MessageFolders)_webContext.FolderID,_webContext.PageNumber);
            }
        }
        public void DeleteSelected()
        {
            List<Int32> messages = _view.ExtractSelectedMessages();
            foreach (int i in messages)
            {
                MessageWithRecipient m = Messages.GetMessageByMessageID(i, _userSession.CurrentUser.AccountID);
                MessageRecipient.DeleteMessageRecipient(m.MessageRecipient);
            }
            HttpContext.Current.Response.Redirect("~/mail/default.aspx?folder=" + _webContext.FolderID + "&page=" + _webContext.PageNumber);
        }
        public void MarkSelectedAsUnread()
        {
            List<Int32> messages = _view.ExtractSelectedMessages();
        }
    }
}
