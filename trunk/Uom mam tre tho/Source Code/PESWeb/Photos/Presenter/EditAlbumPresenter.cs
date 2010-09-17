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
    public class EditAlbumPresenter
    {
        private IEditAlbum _view;
        private IWebContext _webContext;
        private IUserSession _userSession;
        private IRedirector _redirector;
        public EditAlbumPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        public void Init(IEditAlbum view, bool IsPostback)
        {
            _view = view;

            if (_webContext.AlbumID > 0 && !IsPostback)
                LoadAlbum(_webContext.AlbumID);
        }

        private void LoadAlbum(Int64 AlbumID)
        {
            Folder folder = Folder.GetFolderByID(AlbumID);
            if (folder.AccountID == _userSession.CurrentUser.AccountID)
                _view.LoadUI(folder);
        }

        public void SaveAlbum(string Name, string Description, string Location)
        {
            Folder folder = new Folder();
            if (_webContext.AlbumID > 0)
            {
                folder = Folder.GetFolderByID(_webContext.AlbumID);
            }
            else
            {
                folder.AccountID = _userSession.CurrentUser.AccountID;
            }
            folder.Description = Description;
            folder.Name = Name;
            folder.Location = Location;
            folder.IsPublicResource = false;
            folder.CreateDate = DateTime.Now;
            Int64 result = Folder.SaveFolder(folder);
            _redirector.GoToPhotosAddPhotos(result);
        }
    }
}

