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
using SubSonic.Extensions;

namespace PESWeb.Photos
{
    public partial class ViewAlbum : System.Web.UI.Page, IViewAlbum
    {
        public IWebContext _webContext;
        private ViewAlbumPresenter _presenter;
        private IRedirector _redirector;
        private IUserSession _userSession;


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public long albumID=0;
        protected override void OnInit(EventArgs e)
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _presenter = new ViewAlbumPresenter();
            _presenter.Init(this);
        }

        protected void lvAlbum_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                File data = ((ListViewDataItem)e.Item).DataItem as File;

                HyperLink lnkView = e.Item.FindControl("lnkView") as HyperLink;
                HyperLink lnkImage = e.Item.FindControl("lnkImage") as HyperLink;
                string pathToImage = "~/files/photos/" + lnkImage.NavigateUrl + "/" + data.FileSystemName;

                 lnkImage.NavigateUrl = "~/Photos/ViewView.aspx?FileID=" + data.FileID;

                lnkView.NavigateUrl = "~/Photos/ViewView.aspx?FileID=" + data.FileID;
                string name = data.FileName;
                if (name.Length > 25)
                    name = name.Substring(0, 25);
                lnkView.Text = System.IO.Path.GetFileNameWithoutExtension(name);
                lnkView.NavigateUrl = "~/Photos/ViewView.aspx?FileID=" + data.FileID;
               
                Image image = e.Item.FindControl("Image") as Image;
                image.ImageUrl = pathToImage + "__s." + data.Extension;
                image.AlternateText = data.FileName;

            }
            else if (e.Item.ItemType == ListViewItemType.EmptyItem)
            {
                HyperLink linkAddPhotos = e.Item.FindControl("linkAddPhotos") as HyperLink;
                linkAddPhotos.NavigateUrl = "~/photos/AddPhotos.aspx?AlbumID=" + _webContext.AlbumID.ToString();
            }
        }

        public void LoadAlbumDetails(Folder folder)
        {
            lblAlbumName.Text = folder.Name;
            lblLocation.Text = folder.Location;
            lblDescription.Text = folder.Description;
            lblCreateDate.Text = folder.CreateDate.ToString("dd-MM-yyyy lúc HH:mm");

            if (folder.AccountID != _userSession.CurrentUser.AccountID)
            {
                btnEditPhotos.Visible = false;
                btnEditAlbum.Visible = false;
                btnAddPhotos.Visible = false;
            }
            albumID = folder.FolderID;
            comments.SystemObjectRecordID = folder.FolderID;
            Tags1.SystemObjectRecordID = folder.FolderID;
        }

        public void LoadPhotos(List<File> files)
        {
            lvGallery.DataSource = files;
            lvGallery.DataBind();
        }

        protected void lbEditPhotos_Click(object sender, EventArgs e)
        {
            _redirector.GoToPhotosEditPhotos(_webContext.AlbumID);
        }

        protected void lbEditAlbum_Click(object sender, EventArgs e)
        {
            _redirector.GoToPhotosEditAlbum(_webContext.AlbumID);
        }

        protected void lbAddPhotos_Click(object sender, EventArgs e)
        {
            _redirector.GoToPhotosAddPhotos(_webContext.AlbumID);
        }
    }
}
