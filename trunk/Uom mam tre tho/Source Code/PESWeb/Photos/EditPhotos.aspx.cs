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
    public partial class EditPhotos : System.Web.UI.Page, IEditPhotos 
    {
        private EditPhotosPresenter _presenter;
        private IRedirector _redirector;
        private IWebContext _webContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _presenter = new EditPhotosPresenter();
            _presenter.Init(this);
        }

        public void LoadFiles(List<File> files)
        {
            if (!IsPostBack)
            {
                lvAlbums.DataSource = files;
                lvAlbums.DataBind();
            }
        }

        protected void lbPhotos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if(e.Item.ItemType == ListViewItemType.DataItem)
            {
                TextBox txtDescription = e.Item.FindControl("txtDescription") as TextBox;
                HyperLink linkImage = e.Item.FindControl("linkImage") as HyperLink;
                Literal litFileSystemName = e.Item.FindControl("litFileSystemName") as Literal;
                Literal litFileID = e.Item.FindControl("litFileID") as Literal;
                Literal litFileExtension = e.Item.FindControl("litFileExtension") as Literal;

                string imagePath = "~/files/photos/" + linkImage.NavigateUrl + "/" + litFileSystemName.Text + "__s." +
                                   litFileExtension.Text;
                linkImage.ImageUrl = imagePath;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<long, string> fileDescriptions = new Dictionary<long, string>();
                for (int i = 0; i < lvAlbums.Items.Count; i++)
                {
                    TextBox txtDescription = lvAlbums.Items[i].FindControl("txtDescription") as TextBox;
                    Literal litFileID = lvAlbums.Items[i].FindControl("litFileID") as Literal;
                    fileDescriptions.Add(Convert.ToInt32(litFileID.Text), txtDescription.Text);
                }
                _presenter.SaveResults(fileDescriptions);
                _redirector.GoToPhotosViewAlbum(_webContext.AlbumID);
            }
            catch {}
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            _redirector.GoToPhotosViewAlbum(_webContext.AlbumID);
        }
    }
}
