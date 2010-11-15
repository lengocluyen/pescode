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

namespace PESWeb.Blogs
{
    public partial class ViewPost : System.Web.UI.Page, IViewPost
    {
        private ViewPostPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            _presenter = new ViewPostPresenter();
            _presenter.Init(this);
        }
        public string blogID = "";
        public void LoadPost(Blog blog)
        {
            linkProfile.NavigateUrl = "/" + Account.GetAccountByID(blog.AccountID).Username;
            lblTitle.Text = blog.Title;
            lblPost.Text = blog.Post;
            imgAvatar.ImageUrl += "?AccountID=" + blog.AccountID.ToString();
            lblCreated.Text = blog.CreateDate.ToString("dd-MM-yyyy lúc HH:mm");
            //lblUpdated.Text = blog.UpdateDate.ToString("dd-MM-yyyy lúc HH:mm");
            comments.SystemObjectRecordID = blog.BlogID;
            blogID = blog.BlogID.ToString();
        }
    }
}
