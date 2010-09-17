using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;

/// <summary>
/// Summary description for ITBusSession
/// </summary>
public class PESSession
{
    public PESSession()
    {
    }
    public static object Get(string key)
    {
        object obj = new object();
        obj = HttpContext.Current.Session["CurrentUser"];
        
        return obj;
    }
    public static object Get1(string key)
    {
        object obj = new object();
        obj = HttpContext.Current.Session[key];

        return obj;
    }
    public static void Set1(string key, object value)
    {
        HttpContext.Current.Session.Add(key, value);
    }
    public static void Set(string key, object value)
    {
        HttpContext.Current.Session.Add("CurrentUser", value);
    }
    public static void Remove(string key)
    {
        HttpContext.Current.Session.Remove("CurrentUser");
    }



    // SESSION VARIABLES

    public static int LessionID
    {
        get
        {
            if (PESSession.Get("LessionID") == null)
                return 0;
            return int.Parse(PESSession.Get("LessionID").ToString());
        }
        set
        {
            PESSession.Set("LessionID", value);
        }
    }

    public static int LanguageStatus
    {
        get
        {
            if (PESSession.Get(SessionConstants.Session_LanguageState) == null)
                return 0;
            return CoreSupport.ConvertToInt(PESSession.Get(SessionConstants.Session_LanguageState), 0);
        }
        set
        {
            PESSession.Set(SessionConstants.Session_LanguageState, value);
        }
    }

    public static int PupilLogID
    {
        get
        {
            if (PESSession.Get(SessionConstants.Session_PupilLoginID) == null)
                return -1;
            return CoreSupport.ConvertToInt(PESSession.Get(SessionConstants.Session_PupilLoginID), -1);
        }
        set
        {
            PESSession.Set(SessionConstants.Session_PupilLoginID, value);
            int userID = value;
            try
            {
                Account p = Account.GetAccountByID(userID);
                if (p != null)
                {
                    PESSession.Set(SessionConstants.Session_PupilLoginID, userID);
                    PESSession.PupilLogin = p;
                }
            }
            catch
            {
            }
        }
    }

    public static Account PupilLogin
    {
        get
        {
            if (PESSession.Get(SessionConstants.Session_PupilLogin) == null)
                return null;
            return PESSession.Get(SessionConstants.Session_PupilLogin) as Account;
        }
        set
        {
            PESSession.Set(SessionConstants.Session_PupilLogin, value);
        }
    }

    public static Account Admin
    {
        get
        {
            if (PESSession.Get(SessionConstants.Session_Admin) == null)
                return null;
            return PESSession.Get(SessionConstants.Session_Admin) as Account;
        }
        set
        {
            PESSession.Set(SessionConstants.Session_Admin, value);
        }
    }

    public static List<Game> RandomGamesForTopTen
    {
        get
        {
            if (PESSession.Get(SessionConstants.Session_RandomGamesForTopTen) == null)
                return null;
            return (List<Game>)PESSession.Get(SessionConstants.Session_RandomGamesForTopTen);
        }
        set
        {
            PESSession.Set(SessionConstants.Session_RandomGamesForTopTen, value);
        }
    }

    public static int GamePlayingID
    {
        get
        {
            if (PESSession.Get(SessionConstants.Session_GamePlayingID) == null)
                return -1;
            return CoreSupport.ConvertToInt(PESSession.Get(SessionConstants.Session_GamePlayingID), -1);
        }
        set
        {
            PESSession.Set(SessionConstants.Session_GamePlayingID, value);
        }
    }
}
