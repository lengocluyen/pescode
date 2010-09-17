using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PESWeb
{
    public class WebConstants
    {
        

        //Game Announcement
        public static string ViewDataKey_GA_AccountID = "GA_AccountID";
        public static string ViewDataKey_GA_AnnoucementContent = "GA_Content";
        public static string ViewDataKey_GA_DateAdded = "GA_DateAdded";
        public static string ViewDataKey_GA_GameAnnouncementID = "GA_AnnoucementID";
        public static string ViewDatakey_GA_GameImg = "GA_Img";
        public static string ViewDataKey_GA_GameTitle = "GA_Title";


        public static string ViewDataKey_RandomGameList = "RandomGameList";

        public static string ViewDataKey_GameAnnoucement = "GameAnnoucement";
        public static string ViewDataKey_GameAnnoucementIndex = "GameAnnoucementIndex";
        public static string ViewDataKey_GameAnnoucementHasMore = "GameAnnoucementHasMore";

        public static string ViewDataKey_RandomGames = "RandomGames";
        public static string ViewDataKey_TopPlayers = "TopPlayers";
        public static string ViewDataKey_TopPlayersIndex = "TopPlayersIndex";

        public static string ViewDataKey_GameCategories = "ViewDataKey_GameCategories";

        public static string[] subMenuGames = {"Game Category" };
        public static string[] actionNameMenuGames = {"IndexGC" };
        public static string[] ControllerMenuGames = {"GameManage" };

        public static string[] subMenuFamiles = { "MailBox", "Experience", "Exchanges"};
        public static string[] actionNameMenuFamiles = { "MailBox", "Experience", "Exchanges" };
        public static string[] ControllerMenuFamiles = { "Families", "Families", "Families" };

        public static string[] subMenuLearning = { "Class", "Subject", "Lesson" };
        public static string[] actionNameMenuLearning = { "Class", "Subject", "Lesson"};
        public static string[] ControllerMenuLearning = { "Learning", "Learning", "Learning" };

        //public static string[] subMenuUsers = { "User", "Users", "Game Announces" };
        //public static string[] actionNameMenuUsers = { "GameResults", "GameCatelogy", "GameAnnounces" };
        //public static string[] ControllerMenuUsers = { "Games", "Games", "Games" };
    }
}
