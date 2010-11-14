using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;
using StructureMap;

namespace PESWeb.Mail
{
    public class FoldersPresenter
    {
        private IFolders _view;
        private IUserSession _userSession;

        public FoldersPresenter()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }
        public void Init(IFolders view)
        {
            _view = view;
            //_view.LoadFolders(MessageFolder.GetMessageFoldersByAccountID(_userSession.CurrentUser.AccountID));
        }

    }
}
