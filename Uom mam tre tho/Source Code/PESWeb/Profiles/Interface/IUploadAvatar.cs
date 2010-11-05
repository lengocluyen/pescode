using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PESWeb.Profiles.Interface
{
    public interface IUploadAvatar
    {
        void ShowMessage(string Message);
        void ShowCropPanel();
        void HideCropPanel();
        //void ShowApprovePanel();
        //void ShowUploadPanel();
    }
}
