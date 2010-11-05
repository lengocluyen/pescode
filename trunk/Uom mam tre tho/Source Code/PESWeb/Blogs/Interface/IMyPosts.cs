using System;
using System.Collections.Generic;
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
using Pes.Core;
using SubSonic.Schema;

namespace PESWeb.Blogs
{
    public interface IMyPosts
    {
        void LoadBlogs(PagedList<Blog> Blogs);
    }
}
