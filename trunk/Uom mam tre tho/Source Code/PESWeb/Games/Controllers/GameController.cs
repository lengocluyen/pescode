using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Pes.Core;
using PESWeb;
using PESWeb.ActionFilter;

namespace PESWeb.Controllers
{
    [UserAuthorize()]
    public class GameController : ApplicationController
    {
        private IGameService _gameRepository;

        public GameController()
            : this(new GameService())
        { }


        public GameController(IGameService gameRepository)
        {
            _gameRepository = gameRepository;
        }
        //
        // GET: /Game/Play/1
        public ActionResult Play(int? id)
        {
            try
            {
                int gameid = (int)id;
                Game game = _gameRepository.GetGameByID(gameid);
                if (game != null)
                {
                    ViewData["G_File"] = game.GameFile;
                    ViewData["G_Name"] = game.Name;
                    ViewData["G_ID"] = game.GameID;
                    return View(@"~/Games/Views/Game/Play.aspx");

                }
                else
                    return RedirectToAction("Index", "Errors", new { errorMsg = "Không tìm thấy trò chơi này." });
            }
            catch { return RedirectToAction("Index", "Errors", new { errorMsg = "Không tìm thấy trò chơi này." }); }
        }

        public ActionResult Index()
        {
            // Game categories
            ViewData[WebConstants.ViewDataKey_GameCategories] = _gameRepository.GetAllGameCateGories();
            return View(@"~/Games/Views/Game/Index.aspx");
        }

        public ActionResult GameCatDetails(int? id)
        {
            int gameCatID = id ?? 1;
            GameCategory gameCat = _gameRepository.GetGameCategoryByID(gameCatID);
            ViewData["GC_Name"] = gameCat.GameCategoryName;
            ViewData["GC_ID"] = gameCat.GameCategoryID;
            return View(@"~/Games/Views/Game/GameCatDetails.aspx");
        }
    }
}
