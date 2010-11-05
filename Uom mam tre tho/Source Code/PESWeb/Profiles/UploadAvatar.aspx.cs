using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PESWeb.Profiles.Interface;
using PESWeb.Profiles.Presenter;

namespace PESWeb.Profiles
{
    public partial class UploadAvatar : System.Web.UI.Page, IUploadAvatar
    {
        private UploadAvatarPresenter _presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new UploadAvatarPresenter();
            _presenter.Init(this);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnComplete.Click += new EventHandler(btnComplete_Click);
            //btnStartNew.Click += new EventHandler(btnStartNew_Click);
            btnCrop.Click += new EventHandler(btnCrop_Click);
            //btnIgnorCrop.Click += new EventHandler(btnComplete_Click);
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
            btnUseGravatar.Click += new EventHandler(btnUseGravatar_Click);
        }

        void btnUseGravatar_Click(object sender, EventArgs e)
        {
            if (cbUseGravatar.Checked)
                _presenter.UseGravatar();
            else
                lblGravatarMsg.Text = "Phải bấm chọn sử dụng Gravatar";
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            if (fuAvatarUpload.PostedFile != null || !string.IsNullOrEmpty(fuAvatarUpload.PostedFile.FileName))
            {
                _presenter.UploadFile(fuAvatarUpload.PostedFile);
            }
        }

        void btnCrop_Click(object sender, EventArgs e)
        {
            _presenter.CropFile(Convert.ToInt32(hidX1.Value),
                Convert.ToInt32(hidY1.Value),
                Convert.ToInt32(hidWidth.Value),
                Convert.ToInt32(hidHeight.Value));
            _presenter.Complete();
        }

        //void btnStartNew_Click(object sender, EventArgs e)
        //{
        //    _presenter.StartNewAvatar();
        //}

        void btnComplete_Click(object sender, EventArgs e)
        {
            _presenter.GetOriginalImage();
            _presenter.Complete();
        }

        #region IUploadAvatar Members

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
        }

        public void ShowCropPanel()
        {
            pnlCrop.Visible = true;
            //pnlApprove.Visible = false;
        }

        public void HideCropPanel()
        {
            pnlCrop.Visible = false;
        }

        //public void ShowApprovePanel()
        //{
        //    pnlCrop.Visible = false;
        //    pnlUpload.Visible = false;
        //    //pnlApprove.Visible = true;
        //}

        //public void ShowUploadPanel()
        //{
        //    //pnlCrop.Visible = false;
        //    pnlUpload.Visible = true;
        //    //pnlApprove.Visible = false;
        //}

        #endregion

      
    }
}
