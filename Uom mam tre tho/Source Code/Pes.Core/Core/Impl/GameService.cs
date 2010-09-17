using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public class GameService : IGameService
    {
        //Account
        public Account LogOn(string email, string password)
        {
            try { return Account.Single(a => a.Email == email && a.Password == password); }
            catch { return null; }
        }
        public List<Account> GetTopGamers(Game game, int num)
        {
            try { return Game.GetTopGamers(game, num); }
            catch { return null; }
        }

        //Game Annoucement
        public GameAnnoucement GetOneNewGameAnnoucement(int start)
        {
            try { return GameAnnoucement.GetOneNewAnnoucement(start); }
            catch { return null; }
        }
        public int CountGameAnnouncement()
        {
            try { return GameAnnoucement.CountGameAnnoucement(); }
            catch { return -1; }
        }
        public List<GameAnnoucement> GetGameAnnoucement(int currPage, int pageSize)
        {
            try { return GameAnnoucement.GetGameAnnoucementPaging̣(currPage, pageSize); }
            catch { return null; }
        }
        public GameAnnoucement GetGameAnnoucementByID(int id)
        {
            try { return GameAnnoucement.GetGameAnnoucementByID(id); }
            catch { return null; }
        }

        //Game Manager
        public List<Game> GetRandomGames(int num)
        {
            try { return Game.GetRandomXGame(num); }
            catch { return null; }
        }
        public List<Game> GetGamesByCategoryID(int catID, int begin, int end)
        {
            try { return Game.GetGameByCategoryID(catID, begin, end); }
            catch { return null; }
        }
        public Game GetGameByID(int gameID)
        {
            try { return Game.GetGameByID(gameID); }
            catch { return null; }
        }

        //Game Category
        public List<GameCategory> GetAllGameCateGories()
        {
            try { return GameCategory.GetAllGameCategories(); }
            catch { return null; }
        }
        public List<GameCategory> GetGameCategoriesForHomePage()
        {
            try { return GameCategory.GetGameCategoryForHomePage(); }
            catch { return null; }
        }
        public GameCategory GetGameCategoryByID(int id)
        {
            try { return GameCategory.GetGameCategoryByID(id); }
            catch { return null; }
        }
    }
}
