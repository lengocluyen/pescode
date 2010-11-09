using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;
using StructureMap;
using Pes.Core.Impl;

namespace PESWeb.Tags
{
    public class TagsPresenter
    {
        private ITags _view;
        private IWebContext _webContext;
        public TagsPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(ITags view, bool IsPostBack)
        {
            _view = view;
            _view.SetTitle(Tag.GetTagByID(_webContext.TagID).Name);
            _view.LoadUI(SystemObjectTag.GetSystemObjectsByTagID(_webContext.TagID));
        }
    }
}
