using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Pes.Core;
using System.Web.Security;
using PESWeb.ActionFilter;

namespace PESWeb.Controllers
{
    //[UserAuthorize()]
    public class AccountGamesController : ApplicationController
    {
        //
        // GET: /Account/
        private IGameService _gameService;

        public AccountGamesController()
            : this(new GameService())
        { }


        public AccountGamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public ActionResult Index()
        {
            return View(@"~/Games/Views/AccountGames/Index.aspx");
        }

        public ActionResult LogOn(string email, string password)
        {
            string returnUrl = Request.UrlReferrer.ToString();

            Account acc = _gameService.LogOn(email, FormsAuthentication.HashPasswordForStoringInConfigFile(password + "FLYCHIPS", "MD5"));

             if (acc != null)
            {
                PESSession.PupilLogin = acc;
                return Redirect(returnUrl);
            }
            else
                 return View(@"~/Games/Views/AccountGames/Fail.aspx", (object)returnUrl); 
        }

        public ActionResult LogOut()
        {
            PESSession.PupilLogin = null;
            PESSession.PupilLogID = 0;
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
