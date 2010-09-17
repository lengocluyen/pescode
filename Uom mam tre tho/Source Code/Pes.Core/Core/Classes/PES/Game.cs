using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Game
    {
       public static Game GetGameByID(int id)
        {
            Game game = (from g in All()
                         where g.GameID == id
                         select g).SingleOrDefault<Game>();
            return game;
        }

        public static bool InsertGame(Game game)
        {
            try
            {
                Add(game);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteGame(Game game)
        {
            try
            {
                Delete(game);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateGame(Game game)
        {
            try
            {
                Update(game);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Game> Get(IQueryable<Game> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<Game> l =table.ToList().Skip(start - 1).Take(end - start + 1).ToList();

            return l;
        }

        public static List<Game> GetGameByCategoryID(int catID, int begin, int end)
        {
         
            var lstGames = All().Where(g => g.GameCategoryID == catID);
            if (end > 0)
                return Get(lstGames, begin, end);
            else
                return lstGames.ToList();
        }

        public static List<Game> GetRandomXGame(int gameNum)
        {
            Random rand = new Random();
            List<int> lstGameNum = new List<int>();
            int totalGames = All().Count();

            if (gameNum > totalGames)
                gameNum = totalGames;

            for (int i = 0; i < gameNum; i++)
            {
                int num = rand.Next(totalGames);
                if (lstGameNum.Contains(num))
                    i--;
                else
                    lstGameNum.Add(num);
            }


            List<Game> lstGames = new List<Game>();
            for (int i = 0; i < lstGameNum.Count; i++)
                lstGames.Add(Game.All().ToList()[lstGameNum[i]]);

            return lstGames;
        }

        public static List<Account> GetTopGamers(Game game, int num)
        {
            return (from pupil in Account.All()
                    join rs in GameResult.All()
                    on pupil.AccountID equals rs.AccountID
                    where rs.GameID == game.GameID
                    orderby rs.GameScores descending
                    select pupil).Take(num).ToList();
        }

        public static int CountAllGames()
        {
            return All().Count();
        }

        public static IQueryable<Game> SearchGameByNameAndCategory(string gameName, int cateID)
        {
            if (cateID == 0)
                return (from listGame in All()
                        where listGame.Name.ToUpper().Contains(gameName.ToUpper())
                        select listGame);
            else
                if (gameName == string.Empty)
                    return (from listGame in All()
                            where listGame.GameCategoryID == cateID
                            select listGame);
                else
                    return (from listGame in All()
                            where listGame.Name.ToUpper().Contains(gameName.ToUpper()) && listGame.GameCategoryID == cateID
                            select listGame);
        }
  
    }
}