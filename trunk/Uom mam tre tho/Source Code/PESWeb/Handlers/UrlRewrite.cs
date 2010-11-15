﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using Pes.Core;
using System.Web.Routing;
using Pes.Core.Impl;
namespace PESWeb.Handlers
{
    public class UrlRewrite : IHttpModule
    {
        private IWebContext _WebContext;
        public UrlRewrite()
        {
            _WebContext = new WebContext();
        }

        public void Init(HttpApplication application)
        {
            //let's register our event handler
            application.PostResolveRequestCache +=
                (new EventHandler(this.Application_OnAfterProcess));
        }
        public void Dispose()
        {

        }
       
        private void Application_OnAfterProcess(object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            string[] extensionsToExclude = { ".axd", ".jpg", ".gif", ".png", ".xml", ".config", ".css", ".js", ".htm", ".html" };
            foreach (string s in extensionsToExclude)
            {
                if (application.Request.PhysicalPath.ToLower().Contains(s))
                    return;
            }

            if (!System.IO.File.Exists(application.Request.PhysicalPath))
            {
                #region BLOGS
                if (application.Request.PhysicalPath.ToLower().Contains("blogs"))
                {
                    string[] arr = application.Request.PhysicalPath.ToLower().Split('\\');
                    string blogPageName = arr[arr.Length - 1];
                    string blogUserName = arr[arr.Length - 2];
                    blogPageName = blogPageName.Replace(".aspx", "");

                    if (blogPageName.ToLower() != "profileimage" && blogUserName.ToLower() != "profileavatar")
                    {
                        if (blogPageName == "default")
                            return;

                        Account acc = Account.GetAccountByUsername(blogUserName);

                        if (acc == null)
                            return;

                        Blog blog = Blog.GetBlogByPageName(blogPageName, acc.AccountID);

                        context.RewritePath("~/blogs/ViewPost.aspx?BlogID=" + blog.BlogID.ToString());
                    }
                    else
                    {
                        return;
                    }
                }
                #endregion
                #region GROUPS
                else if (application.Request.PhysicalPath.ToLower().Contains("groups") && _WebContext.GroupID == 0)
                {
                    string[] arr = application.Request.PhysicalPath.ToLower().Split('\\');
                    string groupPageName = arr[arr.Length - 1];
                    groupPageName = groupPageName.Replace(".aspx", "");
                    Group group = Group.GetGroupByPageName(groupPageName);
                    context.RewritePath("~/groups/viewgroup.aspx?GroupID=" + group.GroupID.ToString());
                }
                #endregion
                #region TAGS
                else if (application.Request.PhysicalPath.ToLower().Contains("tags"))
                {
                    Tag tag = null;
                    int tagsPosition = 0;
                    string tagName;
                    string[] arr = application.Request.PhysicalPath.ToLowerInvariant().Split('\\');
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i].ToLower() == "tags")
                        {
                            tagsPosition = i;
                        }

                        if (tagsPosition > 0)
                        {
                            tagName = arr[i + 1];
                            tag = Tag.GetTagByName(tagName.Replace("-", " "));
                            break;
                        }
                    }

                    if (tag != null)
                    {
                        context.RewritePath("~/tags/tags.aspx?TagID=" + tag.TagID);
                    }
                }
                #endregion
                #region PROFILES
                else if (CoreSupport.StringCount(application.Request.Path, '/') <= 1)
                {
                    string username = application.Request.Path.Replace("/", "");
                    Account account = Account.GetAccountByUsername(username);
                    if (account != null)
                    {
                        string UserURL = "~/Profiles/profile.aspx?AccountID=" + account.AccountID.ToString();
                        context.Response.Redirect(UserURL);
                    }
                    else
                    {
                        context.Response.Redirect("~/PageNotFound.aspx");
                    }
                }
                else
                {
                }
                #endregion
            }
        }
    }
}
