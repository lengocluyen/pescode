using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Pes.Core;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using StructureMap;

namespace PESWeb
{
    /// <summary>
    /// Summary description for GameServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GameServices : System.Web.Services.WebService
    {
        private IUserSession _userSession;
        public GameServices()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
        }
        [WebMethod(true)]
        public int UpdateScore(string hash, int gameID, int score)
        {
            if (PESSession.GamePlayingID == gameID) // Checking session
            {
                PESSession.GamePlayingID = -1;

                // Game
                Game game = Pes.Core.Game.GetGameByID(gameID);

                // Pupil
                Pupils pupil = null;
                if (_userSession.Username != "")
                {

                    pupil = Pupils.GetPupilByAccountID(Account.GetAccountByUsername(_userSession.Username).AccountID);
                    if (game != null && pupil != null)
                    {
                        GameResult.InsertOrUpdateGameResult(gameID, Account.GetAccountByUsername(_userSession.Username).AccountID, score);
                        int mark = score / (int)game.ScoresPerPoint;
                        if (mark > 0)
                        {
                            if (pupil.Point == null)
                                pupil.Point = mark;
                            else
                                pupil.Point += mark;
                            Pes.Core.Pupils.Update(pupil);
                        }
                        else
                            mark = 0;

                        return mark;
                    }
                    else
                    {
                        Profile profile = Profile.GetProfileByAccountID(Account.GetAccountByUsername(_userSession.Username).AccountID);
                        if (game != null && profile != null)
                        {
                            GameResult.InsertOrUpdateGameResult1(gameID, profile.ProfileID, score);
                            int mark = score / (int)game.ScoresPerPoint;
                            if (mark > 0)
                            {
                                if (profile.GameScore == null)
                                    profile.GameScore = mark;
                                else
                                    profile.GameScore += mark;
                                Profile.Update(profile);
                            }
                            else
                                mark = 0;

                            return mark;
                        }
                    }
                }
            }

            return -1;
        }

        [WebMethod(true)]
        public int GetChallengeID(int gameID)
        {
            PESSession.GamePlayingID = gameID;
            return PESSession.GamePlayingID;
        }

        string CalculateHash(int score, string securityKey)
        {
            string str = score + "Secux" + securityKey + "ite";

            SHA256Managed sha = new SHA256Managed();
            Encoding encoding = Encoding.UTF8;

            return Convert.ToBase64String(sha.ComputeHash(encoding.GetBytes(str)));
        }
    }
}
