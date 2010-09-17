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
using StructureMap;

namespace PESWeb.Photos
{
    public partial class ViewAlbum : System.Web.UI.Page, IViewAlbum 
    {
        private IWebContext _webContext;
        private ViewAlbumPresenter _presenter;
        private IRedirector _redirector;
        private IUserSession _userSession;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

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
            if(e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink linkImage = e.Item.FindControl("linkImage") as HyperLink;
                Literal litImageName = e.Item.FindControl("litImageName") as Literal;
                Label lblFileName = e.Item.FindControl("lblFileName") as Label;
                if (lblFileName.Text.Length > 25)
                    lblFileName.Text = lblFileName.Text.Substring(0, 25);
                Literal litFileExtension = e.Item.FindControl("litFileExtension") as Literal;
                Literal litFileID = e.Item.FindControl("litFileID") as Literal;
                PESWeb.UserControls.Tags Tags1 = e.Item.FindControl("Tags1") as PESWeb.UserControls.Tags;
                //PESWeb.UserControls.Moderations Moderations1 =
                //    e.Item.FindControl("Moderations1") as Fisharoo.FisharooWeb.UserControls.Moderations;

                //Moderations1.SystemObjectRecordID = Convert.ToInt64(litFileID.Text);
                Tags1.SystemObjectRecordID = Convert.ToInt64(litFileID.Text);
                string pathToImage = "~/files/photos/" + linkImage.NavigateUrl + "/" + litImageName.Text;
                linkImage.NavigateUrl = pathToImage + "__o." + litFileExtension.Text;
                linkImage.ImageUrl = pathToImage + "__s." + litFileExtension.Text;
            }
            if(e.Item.ItemType == ListViewItemType.EmptyItem)
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
            lblCreateDate.Text = folder.CreateDate.ToString();

            if(folder.AccountID != _userSession.CurrentUser.AccountID)
            {
                btnEditPhotos.Visible = false;
                btnEditAlbum.Visible = false;
                btnAddPhotos.Visible = false;
            }
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

        protected void btnAddPhotos_Click(object sender, EventArgs e)
        {
            _redirector.GoToPhotosAddPhotos(_webContext.AlbumID);
        }
    }
}
