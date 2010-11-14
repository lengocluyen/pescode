using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Photos.Interface;
using Pes.Core;
using StructureMap;

namespace PESWeb.Photos.Presenter
{
    public class ViewViewPresenter
    {
        public IViewView _view;
        public IWebContext _webContext;
        public ViewViewPresenter(IViewView view)
        {
            _view = view;
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }
        public void Init()
        {
            _view.LoadUI(File.GetFileByID(_webContext.FileID));
        }
        public long ImageNext(long id)
        {
            List<File> list = File.GetFilesByFolderID(File.GetFileByID(id).DefaultFolderID);
            if (list[list.Count - 1].FileID == id) { return list[0].FileID; }
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].FileID == id)
                {
                    return list[i + 1].FileID;
                }
            }
            return -1;
        }
        public void LoadImageNext(long id)
        {
            _view.LoadUI(File.GetFileByID(ImageNext(id)));
        }
    }
}
