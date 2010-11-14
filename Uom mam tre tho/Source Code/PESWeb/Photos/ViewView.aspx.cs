using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using PESWeb.Photos.Interface;
using PESWeb.Photos.Presenter;

namespace PESWeb.Photos
{
    public partial class ViewView : System.Web.UI.Page, IViewView
    {
        ViewViewPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewViewPresenter(this);
            //if (!IsPostBack)
            //{
                _presenter.Init();
            //}
        }
        public string fileID = "";
        public void LoadUI(File file)
        {
            fileID = file.FileID.ToString();
            string path1 = file.CreateDate.Year.ToString() + file.CreateDate.Month.ToString();
            lblFileName.Text = file.FileName;
            litImageName.Text = file.FileSystemName.ToString();
            litFileExtension.Text = file.Extension.ToString();
            lblDescription.Text = file.Description;
            Tags1.SystemObjectRecordID = Convert.ToInt64(file.FileID);
            Tags1.SystemObjectID = 5;
            Comments1.SystemObjectRecordID = Convert.ToInt64(file.FileID);
            string pathToImage = "/files/photos/" + path1 + "/" + litImageName.Text;
            litFileID.Text = file.FileID.ToString();
            //linkImage.NavigateUrl = pathToImage + "__o." + litFileExtension.Text;
            linkImage.NavigateUrl = "~/photos/ViewView.aspx?FileID=" + _presenter.ImageNext(file.FileID);
            linkImage.ImageUrl = pathToImage + "__o." + litFileExtension.Text;
            //PESWeb.UserControls.Tags tags = (PESWeb.UserControls.Tags)LoadControl("~/Usercontrols/Tags.ascx");
            //tags.SystemObjectID = 5;
            //tags.Display = PESWeb.UserControls.TagState.ShowCloudAndTagBox;
            //tags.SystemObjectRecordID = file.FileID;
            //phControl.Controls.Add(tags);
            
        }

        //protected void img_Click(object sender, ImageClickEventArgs e)
        //{
        //    _presenter.LoadImageNext(long.Parse(this.litFileID.Text));
        //    //upPanelViewPhoto.Update();
        //}
    }
}
