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
    public class ViewAlbumPresenter
    {
        private IViewAlbum _view;

        private IWebContext _webContext;
        public ViewAlbumPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }
        public void Init(IViewAlbum view)
        {
            _view = view;
            LoadUI();
        }
        private void LoadUI()
        {
            _view.LoadPhotos(File.GetFilesByFolderID(_webContext.AlbumID));
            _view.LoadAlbumDetails(Folder.GetFolderByID(_webContext.AlbumID));
        }
    }

}
