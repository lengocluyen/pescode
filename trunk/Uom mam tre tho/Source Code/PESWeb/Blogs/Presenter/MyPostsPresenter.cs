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
    public class MyPostsPresenter
    {
        private IMyPosts _view;
        private IWebContext _webContext;
        private IRedirector _redirector;
        public MyPostsPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        public void Init(IMyPosts View)
        {
            _view = View;
            _view.LoadBlogs(Blog.GetBlogsByAccountID(_webContext.CurrentUser.AccountID));
        }

        public void EditBlog(Int64 BlogID)
        {
            _redirector.GoToBlogsPostEdit(BlogID);
        }

        public void DeletedBlog(Int64 BlogID)
        {
            Blog.DeleteBlog(BlogID);
            Init(_view);
        }
    }
}
