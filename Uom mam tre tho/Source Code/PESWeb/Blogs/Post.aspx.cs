using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Pes.Core;
using System.Text;
using StructureMap;

namespace PESWeb.Blogs
{
    public partial class Post : System.Web.UI.Page, IPost 
    {
        private PostPresenter _presenter;
        private IRedirector _redirector;
        private IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildJS();
            _presenter = new PostPresenter();
            _presenter.Init(this);
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }
        private void BuildJS()
        {
            StringBuilder _js = new StringBuilder();
            _js.AppendLine("<script type=''text/javascript' language='javascript'>");
            _js.AppendLine("CKEDITOR.replace('" + txtMessage.ClientID + "',{extraPlugins : 'uicolor',uiColor: '#C1E8C1',skin:'kama'});");
            _js.AppendLine("</script>");
            ClientScript.RegisterStartupScript(GetType(), "CKEditor", _js.ToString());
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Blog blog = new Blog();
            if (litBlogID.Text != "")
                blog.BlogID = Convert.ToInt64(litBlogID.Text);
            blog.IsPublished = chkIsPublished.Checked;
            blog.PageName = txtPageName.Text;
            blog.Post = txtMessage.Value;
            blog.Subject = txtSubject.Text;
            blog.Title = txtTitle.Text;
            _presenter.SavePost(blog);
            
            _redirector.GotoMyBlog(_webContext.Username,blog.PageName);
        }

        public void LoadPost(Blog blog)
        {
            txtTitle.Text = blog.Title;
            txtSubject.Text = blog.Subject;
            txtMessage.Value = blog.Post;
            txtPageName.Text = blog.PageName;
            chkIsPublished.Checked = blog.IsPublished;
            litBlogID.Text = blog.BlogID.ToString();
        }

        public void ShowError(string ErrorMessage)
        {
            lblErrorMessage.Text = ErrorMessage;
        }
    }
}
