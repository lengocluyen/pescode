using System;
using System.Collections.Generic;
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
    public class EditPhotosPresenter
    {
        private IEditPhotos _view;
        private IWebContext _webContext;
        public EditPhotosPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IEditPhotos view)
        {
            _view = view;
            _view.LoadFiles(File.GetFilesByFolderID(_webContext.AlbumID));
        }

        public void SaveResults(Dictionary<long, string> fileDescriptions)
        {
            File.UpdateDescriptions(fileDescriptions);
        }
    }

}