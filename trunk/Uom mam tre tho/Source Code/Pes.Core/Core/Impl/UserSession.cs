using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using StructureMap;

namespace Pes.Core.Impl
{
    public class UserSession : IUserSession
    {
        private IWebContext _webContext; 

        public UserSession()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public bool LoggedIn
        {
            get
            {
                return _webContext.LoggedIn;
            }
            set
            {
                _webContext.LoggedIn = value;
            }
        }

        public Account CurrentUser
        {
            get
            {
                return _webContext.CurrentUser;
            }
            set
            {
                _webContext.CurrentUser = value;
            }
        }

        public string Username
        {
            get
            {
                return _webContext.Username;
            }

            set
            {
                _webContext.Username = value;
            }
        }


        public byte[] UploadImage
        {
            get
            {
                return _webContext.UploadImage;
            }
            set
            {
                _webContext.UploadImage = value;
            }
        }
    }
}
