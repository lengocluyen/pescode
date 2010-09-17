using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public interface IGameService
    {
        //Account
        Account LogOn(string email, string password);
        List<Account> GetTopGamers(Game game, int num);
        //Game Annoucement
        GameAnnoucement GetOneNewGameAnnoucement(int start);
        int CountGameAnnouncement();
        List<GameAnnoucement> GetGameAnnoucement(int currPage, int pageSize);
        GameAnnoucement GetGameAnnoucementByID(int id);
        //Game Manager
        List<Game> GetRandomGames(int num);
        List<Game> GetGamesByCategoryID(int catID, int begin, int end);
        Game GetGameByID(int gameID);
        //Game Category
        List<GameCategory> GetAllGameCateGories();
        List<GameCategory> GetGameCategoriesForHomePage();
        GameCategory GetGameCategoryByID(int id);

    }
}
