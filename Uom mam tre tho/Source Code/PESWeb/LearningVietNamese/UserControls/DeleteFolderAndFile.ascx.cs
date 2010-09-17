using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PESWeb.LearningVietNamese.UserControls
{
    public partial class DeleteFolderAndFile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["path"] != null && Request.Params["type"] != null)
            {
                string path = Request.QueryString["path"];
                string type = Request.QueryString["type"];
                string message = "";
                switch (type.ToLower())
                {
                    case "file":
                        FileHelper.DeleteFile(path, ref message);
                        Response.Write(message);
                        break;

                    case "folder":
                        DirectoryHelper direcHelper = new DirectoryHelper(path);
                        direcHelper.DeleteDirectory(ref message);
                        Response.Write(message);
                        break;
                }
            }
        }
    }
}