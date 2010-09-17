using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Configuration;
using Pes.Core;

/// <summary>
/// For All Message
/// X: Lession, Module, Part, Admin ...
/// Y: Function.
/// ABC: Optional.
/// </summary>
public class SessionConstants
{
    public SessionConstants() { }

    public static string Session_Admin = "SessionAdmin";
    public static string Session_GroupRole = "GroupRole";
    public static string Session_TempGroupBO = "TempGroupBO";

    public static string Session_PartEdit = "PartEdit";
    public static string Session_PartInsertEditCompleted = "PartEditCompleted";
    public static string Session_PartInsert = "PartInsert";
    public static string Session_PartInsertEditItem = "PartInsertEditItem";

    public static string Session_LessionInsertCompleted = "LessionInsertCompleted";
    public static string Session_LessionInsert = "LessionInsert";
    public static string Session_LessionDeleted = "LessionDeleted";
    public static string Session_LessionSearch = "LessionSearch";

    public static string Session_LessionGroupAction = "LessionGroupAction";
    public static string Session_LessionGroupAlert = "LessionGroupAlert";

    public static string Session_Action = "SessionAction";// 1: Insert      -       2: Update.

    public static string Session_PageWidth = "PageWidth";
    public static string Session_PageHeight = "PageHeight";
    public static string Session_PupilLoginID = "PupilLoginID";
    public static string Session_PupilLogin = "PupilLogin";

    public static string Session_LanguageState = "LanguageState";

    public static string Session_RandomGamesForTopTen = "RandomGamesForTopTen";
    public static string Session_GamePlayingID = "GamePlayingID";
}
