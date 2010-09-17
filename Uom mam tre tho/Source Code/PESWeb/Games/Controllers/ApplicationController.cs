using System;
using System.Web.Mvc;
using Pes.Core;
using StructureMap;

namespace PESWeb.Controllers
{
    public abstract class ApplicationController : Controller
    {
        //
        // GET: /Application/
        private IUserSession _userSession;
        public ApplicationController()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            if (_userSession.Username != "")
            {
                ViewData["UserLogin"] = _userSession.Username;
                _userSession.LoggedIn = true;
                _userSession.CurrentUser = Account.GetAccountByUsername(_userSession.Username);
            }
        }
    }
}
