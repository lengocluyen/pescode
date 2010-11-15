﻿using System;
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
using System.Text;
using SubSonic.Schema;

namespace PESWeb.Blogs
{
    public partial class MyPosts : System.Web.UI.Page, IMyPosts 
    {
        private MyPostsPresenter _presenter;
        public MyPosts()
        {
            _presenter = new MyPostsPresenter();
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
            _presenter.Init(this);
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
            lvBlogs.DataSource = Blogs;
            lvBlogs.DataBind();
        }
        
        public void lvBlogs_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Blog data = ((ListViewDataItem)e.Item).DataItem as Blog;
                HyperLink linkAvatar = e.Item.FindControl("linkAvatar") as HyperLink;
                linkAvatar.NavigateUrl = "~/profiles/profile.aspx?AccountID=" + data.AccountID;
                Image imaAvatar = e.Item.FindControl("imaAvatar") as Image;
                imaAvatar.ImageUrl = "~/images/ProfileAvatar/ProfileImage.aspx?AccountID=" + data.AccountID;
                Literal litBlogID = e.Item.FindControl("litBlogID") as Literal;
                HyperLink linkTitle = e.Item.FindControl("linkTitle") as HyperLink;
                Literal litPageName = e.Item.FindControl("litPageName") as Literal;
                Literal litUsername = e.Item.FindControl("litUsername") as Literal;
                linkTitle.NavigateUrl = "~/Blogs/ViewPost.aspx?BlogID=" + litBlogID.Text;
                //linkTitle.NavigateUrl = "~/Blogs/" + litUsername.Text + "/" + litPageName.Text + ".aspx";
            }
        }

        public void lbEdit_Click(object sender, EventArgs e)
        {
            LinkButton lbEdit = sender as LinkButton;
            _presenter.EditBlog(Convert.ToInt64(lbEdit.Attributes["BlogID"]));
        }

        public void lbDelete_Click(object sender, EventArgs e)
        {
            LinkButton lbDelete = sender as LinkButton;
            _presenter.DeletedBlog(Convert.ToInt64(lbDelete.Attributes["BlogID"]));
        }
    }
}
