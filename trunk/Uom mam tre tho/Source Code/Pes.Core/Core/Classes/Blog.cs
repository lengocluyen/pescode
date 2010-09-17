using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Blog
    {
        public static List<Blog> GetBlogsForIndexing(int PageNumber)
        {
            List<Blog> results = new List<Blog>();
            results =  Blog.GetPaged(100 * (PageNumber - 1), 100);
                //results = dc.Blogs.Skip(100 * (PageNumber - 1)).Take(100).ToList();
            return results;
        }

        public static Blog GetBlogByPageName(string PageName, Int32 AccountID)
        {
            Blog result = new Blog();

            result = All().Where(b => b.PageName == PageName && b.AccountID == AccountID).FirstOrDefault();
                //result = dc.Blogs.Where(b => b.PageName == PageName && b.AccountID == AccountID).FirstOrDefault();

            return result;
        }

        public static List<Blog> GetLatestBlogs()
        {
            List<Blog> result = new List<Blog>();
             
            IEnumerable<Blog> blogs = (from b in All()
                                           where b.IsPublished
                                           orderby b.UpdateDate descending
                                           select b).Take(30);
                //IEnumerable<Account> accounts =
                //    Account.All().Where(a => blogs.Select(b => b.AccountID).Distinct().Contains(a.AccountID));
                //foreach (Blog blog in blogs)
                //{
                //    blog.AccountID = accounts.Where(a => a.AccountID == blog.AccountID).FirstOrDefault().AccountID;
                //}
                result = blogs.ToList();
                //result.Reverse();
            return result;
        }

        public static List<Blog> GetBlogsByAccountID(Int32 AccountID)
        {
            List<Blog> result = new List<Blog>();
                IEnumerable<Blog> blogs = All().Where(b => b.AccountID == AccountID).OrderBy(b => b.CreateDate);
                Account account = Account.All().Where(a => a.AccountID == AccountID).FirstOrDefault();
                foreach (Blog blog in blogs)
                {
                    blog.AccountID = account.AccountID;
                }
                result = blogs.ToList();
                result.Reverse();
            return result;
        }

        public static Blog GetBlogByBlogID(Int64 BlogID)
        {
            Blog result = new Blog();
                result = All().Where(b => b.BlogID == BlogID).FirstOrDefault();
                Account account = Account.All().Where(a => a.AccountID == result.AccountID).FirstOrDefault();
                result.AccountID = account.AccountID;
            return result;
        }

        public static bool CheckPageNameIsUnique(Blog blog)
        {
            blog = CleanPageName(blog);
            bool result = true;
                int count = All().Where(b => b.PageName == blog.PageName && b.AccountID == blog.AccountID).Count();
                if (count > 0)
                    result = false;
            return result;
        }

        private static Blog CleanPageName(Blog blog)
        {
            blog.PageName = blog.PageName.Replace(" ", "-").Replace("!", "")
                .Replace("&", "").Replace("?", "").Replace(",", "");
            return blog;
        }

        public static Int64 SaveBlog(Blog blog)
        {
            blog = CleanPageName(blog);
            string post = blog.Post.Replace("<body>", "").Replace("<br /></body>", "").Replace("<html>", "")
                .Replace("</html>", "").Replace("<head>", "").Replace("</head>", "");
            blog.Post = post;
                if (blog.BlogID > 0)
                {
                    blog.UpdateDate = DateTime.Now;
                }
                else
                {
                    blog.CreateDate = DateTime.Now;
                    blog.UpdateDate = DateTime.Now;
                }
                Blog.Add(blog);
            return blog.BlogID;
        }

        public static void DeleteBlog(Int64 BlogID)
        {
            Blog.Delete(BlogID);
        }

        public static void DeleteBlog(Blog blog)
        {
            Blog.Delete(blog.BlogID);
        }
    }
}