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

namespace PESWeb.Blogs
{
    public class DefaultPresenter
    {
        private IDefault _view;
        public DefaultPresenter()
        {
        }

        public void Init(IDefault View)
        {
            _view = View;
            _view.LoadBlogs(Blog.GetLatestBlogs());
        }
    }
}
