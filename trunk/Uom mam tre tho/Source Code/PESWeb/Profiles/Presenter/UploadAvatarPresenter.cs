using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using PESWeb.Profiles.Interface;
using Pes.Core;
using StructureMap;
using System.Drawing;
using System.Web.Caching;

namespace PESWeb.Profiles.Presenter
{
    public class UploadAvatarPresenter
    {
        private IUserSession _userSession;
        private IRedirector _redirector;
        private Profile profile;
        private IUploadAvatar _view;
        private IAlertService _alertService;

        public UploadAvatarPresenter()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
            _alertService = ObjectFactory.GetInstance<IAlertService>();
        }

        public void Init(IUploadAvatar View)
        {
            _view = View;
            if (_userSession.LoggedIn && _userSession.CurrentUser != null)
                profile = Profile.GetProfileByAccountID(_userSession.CurrentUser.AccountID);
            if (profile == null)
                _redirector.GoToAccountLoginPage();
        }

        public void UseGravatar()
        {
            profile.UseGravatar = 1;
            Profile.SaveProfile(profile);
            _alertService.AddNewAvatarAlert();
            _redirector.GoToProfilesProfile();
        }

        //public void StartNewAvatar()
        //{
        //    _view.ShowUploadPanel();
        //}

        public void Complete()
        {
            _alertService.AddNewAvatarAlert();
            _redirector.GoToProfilesProfile();
            _userSession.UploadImage = null;
        }
        public void Ignore()
        {
            _userSession.UploadImage = null;
            _view.HideCropPanel();
        }
        public void GetOriginalImage()
        {
            profile.Avatar = _userSession.UploadImage;
            Profile.SaveProfile(profile);
        }

        public void CropFile(Int32 X, Int32 Y, Int32 Width, Int32 Height)
        {
            //get byte array from profile
            //byte[] imageBytes = profile.Avatar.ToArray();
            byte[] imageBytes = _userSession.UploadImage;
            //stuff this byte array into a memory stream
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                //write the memory stream out for use
                ms.Write(imageBytes, 0, imageBytes.Length);

                //stuff the memory stream into an image to work with
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms, true);

                //create the destination (cropped) bitmap
                Bitmap bmpCropped = new Bitmap(200, 200);

                //create the graphics object to draw with
                Graphics g = Graphics.FromImage(bmpCropped);

                Rectangle rectDestination = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
                Rectangle rectCropArea = new Rectangle(X, Y, Width, Height);

                //draw the rectCropArea of the original image to the rectDestination of bmpCropped
                g.DrawImage(img, rectDestination, rectCropArea, GraphicsUnit.Pixel);

                //release system resources
                g.Dispose();

                MemoryStream stream = new MemoryStream();
                bmpCropped.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] bytes = stream.ToArray();

                profile.Avatar = bytes;
                Profile.SaveProfile(profile);
            }
            //_view.ShowApprovePanel();
        }

        public void UploadFile(HttpPostedFile File)
        {
            string extension = Path.GetExtension(File.FileName).ToLower();
            string minetype;
            byte[] uploadedImage = new byte[File.InputStream.Length];
            switch (extension)
            {
                case ".png":
                case ".jpg":
                case ".gif":
                    minetype = File.ContentType;
                    _view.ShowMessage("");
                    break;
                default:
                    _view.ShowMessage("Chỉ được phép đăng ảnh .png, .jpg, and .gif!");
                    _view.HideCropPanel();
                    return;
            }
            if (File.ContentLength / 1000 < 1000)
            {
                File.InputStream.Read(uploadedImage, 0, uploadedImage.Length);
                // _userSession.UploadImage = uploadedImage;

                _userSession.UploadImage = ImageResize.ResizeFromByteArray(700, uploadedImage, File.FileName);


                //profile.Avatar = uploadedImage;
                profile.AvatarMimeType = minetype;
                profile.UseGravatar = 0;

                Profile.SaveProfile(profile);
                _view.ShowCropPanel();
            }
            else
            {
                _view.ShowMessage("Ảnh đã đăng vượt quá giới hạn 1MB. Vui lòng giảm dung lượng ảnh và thử lại.");
                _view.HideCropPanel();
            }


        }

      
    }

}
