using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class GameResult
    {
          public static GameResult GetGameResultByID(int id)
        {
            GameResult gameResult = (from g in All()
                                     where g.GameResultID == id
                                     select g).SingleOrDefault<GameResult>();
            return gameResult;
        }

        public static void InsertGameResult(GameResult gameResult)
        {
            Add(gameResult);
        }

        public static void DeleteGameResult(GameResult gameResult)
        {
            Delete(gameResult.GameResultID);
        }

        public static void UpdateGameResult(GameResult gr)
        {
            Update(gr);
        }

        public static void InsertOrUpdateGameResult(int gameID, int UserID, int score)
        {
            GameResult rs = (from grs in All().ToList()
                             where grs.GameID == gameID &&
                             grs.AccountID== UserID
                             select grs).SingleOrDefault();
            if (rs != null) // Update
            {
                if (rs.GameScores < score)
                {
                    rs.GameScores = score;
                    UpdateGameResult(rs);
                }
            }
            else // Insert
            {
                rs = new GameResult();
                rs.GameScores = score;
                rs.GameID = gameID;
                rs.AccountID =UserID;
                InsertGameResult(rs);
            }
        }
        public static void InsertOrUpdateGameResult1(int gameID, int profileDI, int score)
        {
            GameResult rs = (from grs in All().ToList()
                             where grs.GameID == gameID &&
                             Profile.Single(p => p.AccountID == grs.AccountID).ProfileID== profileDI
                             select grs).SingleOrDefault();
            if (rs != null) // Update
            {
                if (rs.GameScores < score)
                {
                    rs.GameScores = score;
                    UpdateGameResult(rs);
                }
            }
            else // Insert
            {
                rs = new GameResult();
                rs.GameScores = score;
                rs.GameID = gameID;
                rs.AccountID = Profile.Single(profileDI).AccountID;
                InsertGameResult(rs);
            }
        }
        public static List<GameResult> Get(IQueryable<GameResult> table, int start, int end)
        {
            if (start <= 0)
                start = 1;
            List<GameResult> l = table.Skip(start - 1).Take(end - start + 1).ToList<GameResult>();

            return l;
        }

        public static List<GameResult> GetRandomTopGameResult(int num)
        {
            List<Game> lstGames = Game.GetRandomXGame(num);
            List<GameResult> lstGameResults = new List<GameResult>();

            foreach (Game game in lstGames)
                lstGameResults.Add(All().Where
                    (result => result.GameID == game.GameID).OrderByDescending(result => result.GameScores).Take(1).SingleOrDefault());

            return lstGameResults;
        }
    }
}