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
using StructureMap;

namespace PESWeb.Photos
{
    public partial class Default : System.Web.UI.Page, IDefault 
    {
        private DefaultPresenter _presenter;
        protected IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _presenter = new DefaultPresenter();
            _presenter.Init(this);
        }

        public void LoadUI(List<Folder> folders)
        {
            if (!IsPostBack)
            {
                lvAlbums.DataSource = folders;
                lvAlbums.DataBind();
            }
        }
        protected void lbAlbums_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Folder data = ((ListViewDataItem)e.Item).DataItem as Folder;
                Literal litFolderID = e.Item.FindControl("litFolderID") as Literal;
                Literal litFullPath = e.Item.FindControl("litFullPath") as Literal;
                HyperLink linkAuthor = e.Item.FindControl("linkAuthor") as HyperLink;
                
                HyperLink lnkImage = e.Item.FindControl("lnkImage") as HyperLink;
                lnkImage.NavigateUrl = "~/Photos/ViewAlbum.aspx?AlbumID=" + data.FolderID;

                Image image = e.Item.FindControl("Image") as Image;
                image.ImageUrl = "~/Files/Photos/" + data.FullPathToCoverImage;
                image.AlternateText = data.Name;


                Label lable = e.Item.FindControl("alCountphoto") as Label;
                lable.Text = File.GetFilesByFolderID(long.Parse(litFolderID.Text)).Count.ToString();
                linkAuthor.NavigateUrl = "~/" + linkAuthor.Text;
                linkAuthor.Text = "Người đăng - " + linkAuthor.Text;
            }
        }
    }
}
