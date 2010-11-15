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
    public partial class MyPhotos : System.Web.UI.Page, IMyPhotos
    {
        private MyPhotosPresenter _presenter;
        protected IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _presenter = new MyPhotosPresenter();
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
                
                HyperLink lnkImage = e.Item.FindControl("lnkImage") as HyperLink;
                lnkImage.NavigateUrl = "~/Photos/ViewAlbum.aspx?AlbumID=" + data.FolderID;

                Image image = e.Item.FindControl("Image") as Image;
                image.ImageUrl = "~/Files/Photos/" + data.FullPathToCoverImage;
                image.AlternateText = data.Name;

                HyperLink lnkEdit = e.Item.FindControl("lnkEdit") as HyperLink;
                lnkEdit.NavigateUrl = "~/Photos/EditAlbum.aspx?AlbumID=" + data.FolderID;

                LinkButton linkDeleteAlbum = e.Item.FindControl("linkDeleteAlbum") as LinkButton;
                linkDeleteAlbum.Attributes.Add("OnClick", "javascript:return(confirm('Bạn có chắc chắn muốn xóa album này?'));");
                linkDeleteAlbum.Attributes.Add("FolderID", data.FolderID.ToString());

                HyperLink lnkView = e.Item.FindControl("lnkView") as HyperLink;
                lnkView.NavigateUrl = "~/Photos/ViewAlbum.aspx?AlbumID=" + data.FolderID;
                lnkView.Text = data.Name;
            }
        }

        protected void linkDeleteAlbum_Click(object sender, EventArgs e)
        {
            LinkButton linkDeleteAlbum = sender as LinkButton;
            _presenter.DeleteFolder(Convert.ToInt64(linkDeleteAlbum.Attributes["FolderID"]));
        }
    }
}
