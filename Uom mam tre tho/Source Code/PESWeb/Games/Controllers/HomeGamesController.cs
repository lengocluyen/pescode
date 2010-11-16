using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Pes.Core;
using PESWeb;
using StructureMap;
using PESWeb.ActionFilter;

namespace PESWeb.Controllers
{
    [HandleError]
    //[UserAuthorize()]
    public class HomeGamesController : ApplicationController
    {
        private IGameService _gameRepository;
        protected IUserSession _userSession;
        protected IWebContext _webContext;
        public HomeGamesController()
            : this(new GameService())
        { }

        
        public HomeGamesController(IGameService gameRepository)
        {
            _gameRepository = gameRepository;
            //_userSession = ObjectFactory.GetInstance<IUserSession>();
            //_webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public ActionResult Index()
        {
                // Game Annoucements
                ViewData[WebConstants.ViewDataKey_GameAnnoucement] = ShortenGameAnnoucement(_gameRepository.GetOneNewGameAnnoucement(0));
                ViewData[WebConstants.ViewDataKey_GameAnnoucementIndex] = 0;

                // Random Games
                ViewData[WebConstants.ViewDataKey_RandomGameList] = _gameRepository.GetRandomGames(3);

                // Top ten
                List<Game> randomGames = _gameRepository.GetRandomGames(10);
                PESSession.RandomGamesForTopTen = randomGames;
                ViewData[WebConstants.ViewDataKey_TopPlayersIndex] = 0;
                ViewData[WebConstants.ViewDataKey_TopPlayers] = _gameRepository.GetTopGamers(randomGames[0], 8);

                // Game categories
                ViewData[WebConstants.ViewDataKey_GameCategories] = _gameRepository.GetGameCategoriesForHomePage();

                return View(@"~/Games/Views/HomeGames/Index.aspx");
        }

        public ActionResult LoadTopGamer(int curr, bool isNext)
        {
            List<Game> lstGames = PESSession.RandomGamesForTopTen;

            int newIndex = 0;
            if (isNext)
            {
                newIndex = curr + 1;
                if (newIndex > lstGames.Count - 1)
                    newIndex = 0;
            }
            else
            {
                newIndex = curr - 1;
                if (newIndex < 0)
                    newIndex = lstGames.Count - 1;
            }

            ViewData[WebConstants.ViewDataKey_TopPlayersIndex] = newIndex;
            ViewData[WebConstants.ViewDataKey_TopPlayers] = _gameRepository.GetTopGamers(lstGames[newIndex], 8);

            return PartialView(@"~/Games/Views/HomeGames/TopTen.ascx");
        }

        public ActionResult LoadAnnoucement(int start, bool isNext)
        {           
            int newIndex = 0;
            if (isNext)
            {
                newIndex = start + 1;
                if (newIndex > _gameRepository.CountGameAnnouncement() - 1)
                    newIndex = 0;
            }
            else
            {
                newIndex = start - 1;
                if (newIndex < 0)
                    newIndex = _gameRepository.CountGameAnnouncement() - 1;
            }

            ViewData[WebConstants.ViewDataKey_GameAnnoucementIndex] = newIndex;
            ViewData[WebConstants.ViewDataKey_GameAnnoucement] = ShortenGameAnnoucement(_gameRepository.GetOneNewGameAnnoucement(newIndex));

            return PartialView(@"~/Games/Views/HomeGames/GameAnnoucement.ascx");
        }


        // SUPPORT
        GameAnnoucement ShortenGameAnnoucement(GameAnnoucement ann)
        {
            if (ann.AnnoucementContent.Length > 250)
            {
                ann.AnnoucementContent = ann.AnnoucementContent.Substring(0, 250);
                ann.AnnoucementContent += " ... ";
                ViewData[WebConstants.ViewDataKey_GameAnnoucementHasMore] = "true";
            }

            return ann;
        }
    }
}
