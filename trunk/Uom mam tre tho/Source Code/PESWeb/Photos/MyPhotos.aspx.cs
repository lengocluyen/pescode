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
                HyperLink linkEditAlbum = e.Item.FindControl("linkEditAlbum") as HyperLink;
                LinkButton linkDeleteAlbum = e.Item.FindControl("linkDeleteAlbum") as LinkButton;
                HyperLink linkViewAlbum = e.Item.FindControl("linkViewAlbum") as HyperLink;
                Literal litFolderID = e.Item.FindControl("litFolderID") as Literal;
                Label lblDescription = e.Item.FindControl("lblDescription") as Label;

                if (lblDescription.Text.Length > 150)
                {
                    lblDescription.Text = lblDescription.Text.Substring(0, 149);
                    lblDescription.Text += "...";
                }

                linkEditAlbum.NavigateUrl += "?AlbumID=" + litFolderID.Text;
                linkDeleteAlbum.Attributes.Add("OnClick","javascript:return(confirm('Bạn có chắc chắn muốn xóa album này?'));");
                linkDeleteAlbum.Attributes.Add("FolderID",litFolderID.Text);
                linkViewAlbum.NavigateUrl += "?AlbumID=" + litFolderID.Text;
            }
        }

        protected void linkDeleteAlbum_Click(object sender, EventArgs e)
        {
            LinkButton linkDeleteAlbum = sender as LinkButton;
            _presenter.DeleteFolder(Convert.ToInt64(linkDeleteAlbum.Attributes["FolderID"]));
        }
    }
}
