using System;
using System.Collections;
using System.Collections.Generic;
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
using SubSonic.Schema;

namespace PESWeb.Blogs
{
    public partial class Default : System.Web.UI.Page, IDefault
    {
        private DefaultPresenter _presenter;
        public Default()
        {
            _presenter = new DefaultPresenter();
            
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            pager.Command += new CommandEventHandler(pager_Command);
        }

        void pager_Command(object sender, CommandEventArgs e)
        {
            _presenter.DataBinding(pager.CurrentIndex, pager.PageSize);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.Init(this, IsPostBack);
            if (!IsPostBack)
            {
                _presenter.DataBinding(pager.CurrentIndex, pager.PageSize);
            }
        }
        public void LoadBlogs(PagedList<Blog> Blogs)
        {
            PagedList<Blog> list = Blogs;
            if (pager != null)
            {
                pager.ItemCount = list.TotalCount;
            }

            lvBlogs.DataSource = list;
            lvBlogs.DataBind();
        }
        public void lvBlogs_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Literal litBlogID = e.Item.FindControl("litBlogID") as Literal;
            HyperLink linkTitle = e.Item.FindControl("linkTitle") as HyperLink;
            Literal litPageName = e.Item.FindControl("litPageName") as Literal;
            Literal litUsername = e.Item.FindControl("litUsername") as Literal;

            //linkTitle.NavigateUrl = "~/Blogs/ViewPost.aspx?BlogID=" + litBlogID.Text;
            linkTitle.NavigateUrl = "~/Blogs/" + litUsername.Text + "/" + litPageName.Text + ".aspx";
            
        }
        
      
    }
}
