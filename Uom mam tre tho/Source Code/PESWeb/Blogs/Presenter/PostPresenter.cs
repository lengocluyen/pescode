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
    public class PostPresenter
    {
        private IWebContext _webContext;
        private IAlertService _alertService;
        private IPost _view;
        public PostPresenter()
        {
            _alertService = ObjectFactory.GetInstance<IAlertService>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IPost View)
        {
            _view = View;
            if(_webContext.BlogID > 0)
            {
                _view.LoadPost(Blog.GetBlogByBlogID(_webContext.BlogID));
            }
        }

        public void SavePost(Blog blog)
        {
            bool result = Blog.CheckPageNameIsUnique(blog);
            if (result)
            {
                blog.AccountID = _webContext.CurrentUser.AccountID;
                Blog.SaveBlog(blog);
                _alertService.AddNewBlogPostAlert(blog);
            }
            else
            {
                _view.ShowError("The page name you have chosen is in use.  Please choose a different page name!");
            }
        }
    }
}
