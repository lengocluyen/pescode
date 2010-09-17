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
    public class ViewPostPresenter
    {
        private IViewPost _view;
        private IWebContext _webContext;
        public ViewPostPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IViewPost View)
        {
            _view = View;
            _view.LoadPost(Blog.GetBlogByBlogID(_webContext.BlogID));
        }
    }
}
