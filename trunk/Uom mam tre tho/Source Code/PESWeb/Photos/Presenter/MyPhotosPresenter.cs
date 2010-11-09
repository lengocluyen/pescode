using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using StructureMap;
using Pes.Core;

namespace PESWeb.Photos
{
    public class MyPhotosPresenter
    {
        private IUserSession _userSession;
        private IRedirector _redirector;
        private IMyPhotos _view;
        public MyPhotosPresenter()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }
        public void Init(IMyPhotos view)
        {
            _view = view;
            if (!(_userSession.CurrentUser == null))
                _view.LoadUI(Folder.GetFoldersByAccountID(_userSession.CurrentUser.AccountID));
        }
        public void DeleteFolder(Int64 FolderID)
        {
            File._webContext = ObjectFactory.GetInstance<IWebContext>();
            Folder folder = Folder.GetFolderByID(FolderID);
            File.DeleteFilesInFolder(folder);
            Folder.DeleteFolder(folder);
            _redirector.GoToPhotosMyPhotos();
        }
    }
}

