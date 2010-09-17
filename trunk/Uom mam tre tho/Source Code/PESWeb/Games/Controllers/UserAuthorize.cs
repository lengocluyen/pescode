using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Diagnostics;
using Pes.Core;
using StructureMap;
using System.Web;

namespace PESWeb.ActionFilter
{
    public class UserAuthorize:AuthorizeAttribute
    {
        private IUserSession _userSession;
        private IWebContext _webContext;
        public UserAuthorize()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (FailRoleAu)
            {
                filterContext.Result = new RedirectResult(_webContext.RootUrl + "Learing/defaults.aspx");
            }
           
        }
        public bool FailRoleAu = false;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentException("httpContext");
            if (_userSession.CurrentUser==null)
            {
                FailRoleAu = true;
                return false;
            }
            return base.AuthorizeCore(httpContext);
        }
       
    }
}
