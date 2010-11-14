using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Pes.Core;
using PESWeb.ActionFilter;

namespace PESWeb.Controllers
{
    //[UserAuthorize()]
    public class AnnoucementController : ApplicationController
    {
        public IGameService _gamesServices;
        int _pageSize = 10;

        public AnnoucementController()
            : this(new GameService())
        { }


        public AnnoucementController(IGameService gamesServices)
        {
            _gamesServices = gamesServices;
        }

        //
        // GET: /Annoucement/
        public ActionResult Index(int? page)
        {
            int currPage = page ?? 1;
            ViewData["Items"] = _gamesServices.GetGameAnnoucement(currPage, _pageSize);
            ViewData["TotalItems"] = _gamesServices.CountGameAnnouncement();
            ViewData["PageSize"] = _pageSize;
            ViewData["CurrPage"] = currPage;

            return View(@"~/Games/Views/Annoucement/Index.aspx");
        }

        public ActionResult Details(int? id)
        {
            int newsID = id ?? 1;
            GameAnnoucement ann = _gamesServices.GetGameAnnoucementByID(newsID);
            ViewData["GA_DateAdded"] = ann.DateAdded.ToString();
            ViewData["GA_Content"] =ann.AnnoucementContent;
            ViewData["GA_Img"]= ann.GameImg;
            ViewData["GA_Tilte"] = ann.GameTitle;
            return View(@"~/Games/Views/Annoucement/Details.aspx");
        }
    }
}
