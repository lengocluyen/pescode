using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Reflection;
using System.Configuration;
using System.Web.Security;

/// <summary>
/// Summary description for Commons
/// </summary>
public class Commons
{
	public Commons(){}

    /// <summary>
    /// Convert object to string with safe mode. Encode HTML.
    /// </summary>
    /// <param name="input">object data</param>
    /// <returns>string with encode html</returns>
    public static string ForceString(object input)
    {        
        if (input == null)
            return string.Empty;

        return HttpUtility.HtmlEncode(input.ToString().Trim());
    }

    /// <summary>
    /// Convert object to int with safe mode.
    /// </summary>
    /// <param name="data">input object Data</param>
    /// <param name="defaultValue">Default value - object</param>
    /// <returns>int</returns>
    public static int ConvertToInt(object data, int defaultValue)
    {
        return (int)ConvertDataType(data, typeof(int), defaultValue, System.Globalization.CultureInfo.CurrentCulture);
    }
    
    /// <summary>
    /// Convert to DataType.
    /// </summary>
    /// <param name="data">input object Data</param>
    /// <param name="type">input typeof(Type). Type: string, int, double ...</param>
    /// <param name="defaultValue">Default value - object</param>
    /// <param name="provider">IFormatProvider provider</param>
    /// <returns>object</returns>  
    public static object ConvertDataType(object data, Type type, object defaultValue, IFormatProvider provider)
    {
        if (data == null)
            return defaultValue;
        try
        {
            return Convert.ChangeType(data, type, provider);
        }
        catch
        {
            return defaultValue;
        }
    }

    /// <summary>
    /// Convert object to double with safe mode.
    /// </summary>
    /// <param name="data">input object Data</param>
    /// <param name="defaultValue">Default value - object</param>
    /// <returns>double</returns>
    public static double ConvertToDouble(object data, int defaultValue)
    {
        return (double)ConvertDataType(data, typeof(double), defaultValue, System.Globalization.CultureInfo.CurrentCulture);
    }

    public static string EncodePassword(string strPassword, string strFormat)
    {
        if (strFormat == "") { strFormat = "MD5"; }
        return FormsAuthentication.HashPasswordForStoringInConfigFile(strPassword + "FLYCHIPS", strFormat);
    }
    /// <summary>
    /// Delete file from path
    /// </summary>
    /// <param name="path">string path</param>
    /// <returns>true | false: Success or Error</returns>
    public static bool DeleteFile(string path)
    {
        bool bResult = false;
        path = HttpContext.Current.Server.MapPath(path);

        try
        {
            System.IO.File.Delete(path);
            bResult = true;
        }
        catch
        {
            bResult = false;
        }
        return bResult;
    }

    /// <summary>
    /// Get Server URL (Value of currently address bar)
    /// </summary>
    /// <returns>string value</returns>
    public static string GetServerURL()
    {
        StringBuilder result = new StringBuilder();
        if (System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"] == "0")
            result.Append("http://");
        else
            result.Append("https://");
        result.Append(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_HOST"]);
        result.Append(System.Web.HttpContext.Current.Request.ApplicationPath);
        return result.ToString();
    }

    /// <summary>
    /// Set default even (Button_Click) for a Button control when Client pressing the ENTER key in a TextBox control on current page
    /// </summary>
    public static void SetDefaultButton(Page page, TextBox textControl, Button defaultButton)
    {
        string theScript = @"<script type=""text/javascript"">
                                <!--
                                function fnTrapKD(btn, event){
                                 if (document.all){
                                  if (event.keyCode == 13){
                                   event.returnValue=false;
                                   event.cancel = true;
                                   btn.click();
                                  }
                                 }
                                 else if (document.getElementById){
                                  if (event.which == 13){
                                   event.returnValue=false;
                                   event.cancel = true;
                                   btn.click();
                                  }
                                 }
                                 else if(document.layers){
                                  if(event.which == 13){
                                   event.returnValue=false;
                                   event.cancel = true;
                                   btn.click();
                                  }
                                 }
                                }
                                // -->
                                </script>";
        page.RegisterStartupScript("ForceDefaultToScript", theScript);
        textControl.Attributes.Add("onkeydown", "fnTrapKD(" + defaultButton.ClientID + ",event)");
    }

    public static string V_WriteMedia(string src, string idMedia, string moduleName)
    {
        string s = "";
        if (moduleName != string.Empty)
            s = "<span class=\"titName\"><img src=\"imgs/vi (3).jpg\" alt=\"\" />" + moduleName + "</span>";
        s += "<span><a href=\"#\" onclick=\"PlayMedia('" + src + "','" + idMedia + "')\"><img src=\"imgs/vi.jpg\" alt=\"\"/></a></span><span class=\"spaceImgAu\">&nbsp;</span>"
           + "<span><a href=\"#\" onclick=\"StopMedia('" + idMedia + "')\"><img src=\"imgs/vi (60).png\" alt=\"\"/></a></span>";
        return s;
    }

    public static string swapString(object text, int lenght)
    {
        string sContent = text.ToString().Trim();
        if (sContent == string.Empty || sContent.Length <= lenght)
            return sContent;

        int count = 0;
        int index = 0;
        string sResult = string.Empty;
        for (int i = 0; i < sContent.Length; i++)
        {
            if (sContent[i].ToString() != " ")
                count++;
            else
                count = 0;
            if (count == lenght)
            {
                if (sResult == string.Empty)
                {
                    sResult = sContent.Substring(0, count);
                }
                else
                {
                    sResult += "<br/>" + sContent.Substring(index, count);
                }
                index = i;
                count = 0;
            }
            if (i == sContent.Length - 1)
            {
                if (sResult == string.Empty)
                {
                    sResult = sContent;
                }
                else
                {
                    sResult += "<br/>" + sContent.Substring(index, sContent.Length - index);
                }
            }
        }
        if (sResult == string.Empty)
            return sContent;
        return sResult;
    }

    /// <summary>
    /// Check request param
    /// </summary>
    /// <param name="param">Param to check</param>
    /// <param name="param">Value to compare</param>
    /// <returns>bool</returns>
    public static bool CheckParam(string param, object value)
    {
        if (HttpContext.Current.Request[param] != null && HttpContext.Current.Request[param] == value.ToString())
            return true;
        return false;
    }

    /// <summary>
    /// Select item in dropdownlist with specified value
    /// </summary>
    /// <param name="drl">Your DropDownList</param>
    /// <param name="value"> The value that you want to select</param>
    public static void SelectDropDownList(DropDownList drl, string value)
    {
        foreach (ListItem item in drl.Items)
            if (item.Value == value)
            {
                item.Selected = true;
                return;
            }
    }

    /// <summary>
    /// Select item in dropdownlist with specified text
    /// </summary>
    /// <param name="drl">Your DropDownList</param>
    /// <param name="text"> The text that you want to select</param>
    public static void SelectDropDownListByText(DropDownList drl, string text)
    {
        foreach (ListItem item in drl.Items)
            if (item.Text == text)
            {
                item.Selected = true;
                return;
            }
    }

    /// <summary>
    /// Get host and application path
    /// </summary>
    /// <returns></returns>
    public static string GetHostAndApplicationPath()
    {
        string url = HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + HttpContext.Current.Request.ApplicationPath;
        if (url[url.Length - 1] == '/')
            url = url.Remove(url.Length - 1, 1);

        return url;
    }

    /// <summary>
    /// Load a UserControl and pass params to it
    /// </summary>
    /// <param name="page">Page</param>
    /// <param name="userControlPath">Path of the user control</param>
    /// <param name="constructorParameters">Contructor parameters of your user control, seperate them by comma (,)</param>
    /// <returns>Your UserControl</returns>
    public static UserControl LoadUserControl(Page page, string userControlPath, params object[] constructorParameters)
    {
        List<Type> constParamTypes = new List<Type>();
        foreach (object constParam in constructorParameters)
        {
            constParamTypes.Add(constParam.GetType());
        }
        UserControl ctl = page.LoadControl(userControlPath) as UserControl;

        // Find the relevant constructor
        ConstructorInfo constructor = ctl.GetType().BaseType.GetConstructor(constParamTypes.ToArray());

        //And then call the relevant constructor
        if (constructor == null)
        {
            throw new MemberAccessException("The requested constructor was not found on : " + ctl.GetType().BaseType.ToString());
        }
        else
        {
            constructor.Invoke(ctl, constructorParameters);
        }

        // Finally return the fully initialized UC
        return ctl;
    }

    public static string GetImageURL(object imgURL)
    {
        string urlResult = null;
        string currentURL = ForceString(imgURL);
        if (currentURL == string.Empty)
            urlResult = ForceString(ConfigurationManager.AppSettings.Get("HttpProtocol")) + GetHostAndApplicationPath() + ForceString(ConfigurationManager.AppSettings.Get("NoImage"));
        else
            urlResult = ForceString(ConfigurationManager.AppSettings.Get("HttpProtocol")) + GetHostAndApplicationPath() + ForceString(imgURL);

        return urlResult;
    }

    public static string GetURLApplication()
    {
        string urlResult = null;
        urlResult = ForceString(ConfigurationManager.AppSettings.Get("HttpProtocol")) + GetHostAndApplicationPath();
        return urlResult;
    }

    public static string StringToUpper(object sourceText)
    {        
        return ForceString(sourceText).ToUpper();
    }

    public static string callAudioPlayer(object sourceAudio, int widthIp)
    {
        string audioControl = "<object height='40' align='top' width='" + widthIp.ToString() + "' id='sonpamp3player' codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0'"
            + "classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' style='margin: 0px 0pt 0px 0px; vertical-align: top;'><param value='transparent' name='wmode' />"
            + "<param value='sameDomain' name='allowScriptAccess' /><param value='bg=0xf2fcc8&amp;leftbg=0xdcfb9c&amp;rightbg=0x86b454&amp;rightbghover=0xfd996d&amp;lefticon=0xfd8048&amp;righticon=0xffffff&amp;righticonhover=0xfffa6d&amp;text=0x666666&amp;slider=0xa1b746&amp;track=0xFFFFFF&amp;loader=0xe6fd88&amp;border=0x666666&amp;autostart=no&amp;loop=no&amp;soundFile="
            + ForceString(ConfigurationManager.AppSettings.Get("HttpProtocol")) + GetHostAndApplicationPath() + ForceString(sourceAudio) + "name='flashVars' />"
            + "<param value='" + ForceString(ConfigurationManager.AppSettings.Get("HttpProtocol")) + GetHostAndApplicationPath() + "/Swf/player.swf" + "' name='movie' />"
            + "<param value='high' name='quality' /> <embed height='40' align='middle' width='" + widthIp.ToString() + "' pluginspage='http://www.macromedia.com/go/getflashplayer'"
            + "type='application/x-shockwave-flash' allowscriptaccess='sameDomain' name='player' wmode='transparent' quality='high' "
            + "flashvars='bg=0xf2fcc8&amp;leftbg=0xdcfb9c&amp;rightbg=0x86b454&amp;rightbghover=0xfd996d&amp;lefticon=0xfd8048&amp;righticon=0xffffff&amp;righticonhover=0xfffa6d&amp;text=0x666666&amp;slider=0xa1b746&amp;track=0xFFFFFF&amp;loader=0xe6fd88&amp;border=0x666666&amp;autostart=no&amp;loop=no&amp;soundFile="
            + ForceString(ConfigurationManager.AppSettings.Get("HttpProtocol")) + GetHostAndApplicationPath() + ForceString(sourceAudio)
            + "'src='" + ForceString(ConfigurationManager.AppSettings.Get("HttpProtocol")) + GetHostAndApplicationPath() + "/Swf/player.swf" + "' style='margin: 0px 0pt 0px 0px;"
            + "vertical-align: top;' /> </object>";

        return audioControl;
    }
/*--------------Password Generator---------*/
    private static char[] characterArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

    private static Random randNum = new Random();

    private static char GetRandomCharacter()
    {
        return characterArray[(int)((characterArray.GetUpperBound(0) + 1) * randNum.NextDouble())];
    }
    public static string GenerateRandomString(int len)
    {
        StringBuilder sb = new StringBuilder();
        sb.Capacity = len;
        for (int count = 0; count <= sb.Capacity - 1; count++)
        {
            sb.Append(GetRandomCharacter());
        }
        if ((sb != null))
        {
            return sb.ToString();
        }
        return string.Empty;
    }
}
