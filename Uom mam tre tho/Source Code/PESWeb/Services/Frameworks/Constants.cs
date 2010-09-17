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
public class Constants
{
    public Constants() { }

    public static string X_Y_ABC = "Password and confirmation do not match.";

    public static string Cache_AllUserAccount = "AllUserAccount";
    public static string Cache_AllModule = "AllModule";
    public static string Cache_AllPart = "AllPart";
    public static string Cache_AllLessionGroup = "AllLessionGroup";

    public static string UrlImage_Required = "Xin chọn hình ảnh cho môđun này.";
    public static string UrlAudio_Required = "Xin chọn âm thanh cho môđun này.";

    public static string QueryTestID = "TestID";
    public static string QuestionsNumberForTest = "QuestionsNumberForTest";
    public static string TestTimeExpire = "TestTimeExpire";

    public static string GameQuery_Action = "Action";
    public static string GameQuery_GameID = "GameID";

    public static string GameCategory_Delete_Fail = "Danh Mục Game này đang được sử dụng. Lệnh xoá không thể thực hiện.";
    public static string GameCategory_Delete_OK = "Lệnh xoá đã được thực hiện.";

    // Config

    //public static string webURL = ConfigurationSettings.AppSettings.Get("HttpProtocol");

    public static string WebURL
    {
        get
        {
            //string path = App.Current.Host.Source.AbsoluteUri;
            //string result = "";
            //result += path.Substring(0, path.IndexOf("://") + 3);
            //path = path.Remove(0, result.Length);
            //result += path.Substring(0, path.IndexOf("/"));
            //return result + ;
            return "abc";
        }
    }


    // Enum
    public enum WebAction
    {
        Insert,
        Update,
        Delete
    }

    public enum PermissionOfGetLession
    {
        Unlimit,
        Limit
    }

    // Structs
    public struct LessionSearchInfo
    {
        public VLession lession;
        public string authorName;
    }
}
