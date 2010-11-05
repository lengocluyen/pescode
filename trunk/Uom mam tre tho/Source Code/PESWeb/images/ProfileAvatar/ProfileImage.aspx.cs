using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pes.Core;
using StructureMap;
using Pes.Core.Impl;

namespace PESWeb.images.ProfileAvatar
{
    public partial class ProfileImage : System.Web.UI.Page
    {
        private IUserSession _userSession;
        private IWebContext _webContext;

        private Int32 accountID;
        private Account account;
        private Profile profile;
        private string gravatarURL;
        private string defaultAvatar;

        protected void Page_Load(object sender, EventArgs e)
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();

            if (_webContext.AccountID == -999 && _userSession.LoggedIn && _userSession.UploadImage != null)
            {
                Response.Clear();
                //Response.ContentType = profile.AvatarMimeType;
                Response.BinaryWrite(_userSession.UploadImage);
                return;
            }

            //load an image by passed in accountid
            if (_webContext.AccountID > 0)
            {
                accountID = _webContext.AccountID;
                profile = Profile.GetProfileByAccountID(accountID);
                account = Account.GetAccountByID(accountID);
            }
            //get an image for the current user
            else
            {
                if (_userSession.LoggedIn && _userSession.CurrentUser != null)
                {
                    account = _userSession.CurrentUser;
                    profile = Profile.GetProfileByAccountID(account.AccountID);
                }
            }

            //show the appropriate image
            if (_webContext.ShowGravatar || (profile != null && profile.UseGravatar == 1))
            {
                Response.Redirect(GetGravatarURL());
            }
            else if (profile != null && profile.Avatar != null)
            {
                Response.Clear();
                Response.ContentType = profile.AvatarMimeType;
                Response.BinaryWrite(profile.Avatar.ToArray());
            }
            else
            {
                Response.Redirect("~/images/ProfileAvatar/default.jpg");
            }
        }

        public string GetGravatarURL()
        {
            defaultAvatar = Server.UrlPathEncode(_webContext.RootUrl + "/images/ProfileAvatar/Male.jpg");

            gravatarURL = "http://www.gravatar.com/avatar.php?";
            gravatarURL += "gravatar_id=" + account.Email.ToMD5Hash();
            gravatarURL += "&rating=r";
            gravatarURL += "&size=80";
            gravatarURL += "&default=" + defaultAvatar;
            return gravatarURL;
        }
    }
}
