using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections;
using Pes.Core;
using StructureMap;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using AjaxControlToolkit;

namespace PESWeb
{
    /// <summary>
    /// Summary description for PESServicesSession
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PESServicesSession : System.Web.Services.WebService
    {
        public PESServicesSession()
        {
          
        }

        [WebMethod(true)]
        public int GetUserLoginID()
        {
            try
            {
                IUserSession _userSession;
                _userSession = ObjectFactory.GetInstance<IUserSession>();
                Account a = _userSession.CurrentUser;
                if (a == null)
                {
                    a = Account.GetAccountByUsername(_userSession.Username);
                }

                return a.AccountID;
            }
            catch {
                return -1;
            }
        }

        [WebMethod(true)]
        public void SetPupilLoginID(int uID)
        {
            if (uID != -1)
            {
                IUserSession _userSession;
                _userSession = ObjectFactory.GetInstance<IUserSession>();
                Account a = Account.GetAccountByID(uID);
                _userSession.LoggedIn = true;
                _userSession.Username = a.Username;
                _userSession.CurrentUser = a;
            }
            else {
                IUserSession _userSession;
                _userSession = ObjectFactory.GetInstance<IUserSession>();
                _userSession.LoggedIn = false;
                _userSession.Username = "";
                _userSession.CurrentUser = null;

            }
        }

        [WebMethod(true)]
        public void SetLanguageState(int lgID)
        {
            PESSession.LanguageStatus = lgID;
        }
        [WebMethod(true)]

        public int GetLanguageState()
        {
            return PESSession.PupilLogID;
        }

        [WebMethod(true)]
        public bool SendMail_ActivePass(int uID, string email)
        {
            //sendMail
            ArrayList listTo = new ArrayList();
            PESMail mymail = new PESMail();
            listTo.Add(email);
            mymail.List = listTo;
            mymail.Subject = "Mật khẩu mới tại " + Commons.GetURLApplication();
            mymail.IsHtml = true;
            string newPass = Commons.GenerateRandomString(6);
            mymail.Content = "Để mật khẩu mới của bạn có hiệu lực bạn hãy click vào liên kết này <br/>" + "<a href='" + Commons.GetURLApplication() + "/PupilAccountProfile.aspx?act=activepass&pp_id=" + uID.ToString() + "&p=" + newPass + "'>Xác nhận đổi mật khẩu</a>";
            mymail.Content += "<br/><br/>Thông tin đăng nhập của bạn<br/><br/>Email đăng nhập :<b>" + email + "</b><br/><br>Mật khẩu mới :<b>" + newPass;
            if (PESMails.Send(mymail))
            {
                //Success
                return true;
            }
            else
                return false;
        }
        [WebMethod(true)]
        public string SessionVariable()
        {
            Session["CH"] = "Test";
            return Session["CH"].ToString();
        }



        
        [WebMethod]
        public CascadingDropDownNameValue[] GetProgrammingDropDownContents(string knownCategoryValues, string category)
        {
            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
            foreach(StudyProgramming i in StudyProgramming.All())
            {
                values.Add(new CascadingDropDownNameValue( i.ProgrammingName,i.ProgrammingID.ToString()));
            }
            return values.ToArray();
         }
        //[WebMethod]
        //public CascadingDropDownNameValue[] GetStudyLevelDropdow(string knownCategoryValues, string category)
        //{
        //    int progamStudyID;
        //    StringDictionary kv =  CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //    if (!kv.ContainsKey("ProgamStudy") || !Int32.TryParse(kv["ProgamStudy"], out progamStudyID))
        //        return null;
        //    List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        //    foreach (StudyLevel i in StudyLevel.GetStudyLevelBySLTID(progamStudyID))
        //    {
        //        values.Add(new CascadingDropDownNameValue(i.StudyLevelName, i.StudyLevelID.ToString()));
        //    }
        //    return values.ToArray();
        //}
        //[WebMethod]
        //public CascadingDropDownNameValue[] GetSubjectDropdow(string knownCategoryValues, string category)
        //{
        //    int studyLevelID;
        //    StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //    if (!kv.ContainsKey("studyLevel") || !Int32.TryParse(kv["studyLevel"], out studyLevelID))
        //        return null;
        //    List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        //    foreach (Subject i in Subject.Find(s => s.StudyLevelID == studyLevelID))
        //    {
        //        values.Add(new CascadingDropDownNameValue(i.SubjectName, i.SubjectID.ToString()));
        //    }
        //    return values.ToArray();
        //}
        //[WebMethod]
        //public CascadingDropDownNameValue[] GetSPartDropdow(string knownCategoryValues, string category)
        //{
        //    int subjectID;
        //    StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //    if (!kv.ContainsKey("Subject") || !Int32.TryParse(kv["Subject"], out subjectID))
        //        return null;
        //    List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        //    foreach (Part i in Part.Find(s => s.SubjectID == subjectID))
        //    {
        //        values.Add(new CascadingDropDownNameValue(i.PartName, i.PartID.ToString()));
        //    }
        //    return values.ToArray();
        //}
        //[WebMethod]
        //public CascadingDropDownNameValue[] GetLessonDropdow(string knownCategoryValues, string category)
        //{
        //    int partID;
        //    StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //    if (!kv.ContainsKey("Part") || !Int32.TryParse(kv["Part"], out partID))
        //        return null;
        //    List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        //    foreach (Lesson i in Lesson.Find(s => s.PartID == partID))
        //    {
        //        values.Add(new CascadingDropDownNameValue(i.LessonName, i.LessonID.ToString()));
        //    }
        //    return values.ToArray();
        //}
        //[WebMethod]
        //public CascadingDropDownNameValue[] GetTestDropdow(string knownCategoryValues, string category)
        //{
        //    int lessonID;
        //    StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //    if (!kv.ContainsKey("Lesson") || !Int32.TryParse(kv["Lesson"], out lessonID))
        //        return null;
        //    List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();
        //    foreach (Test i in Test.GetTestByLessonID(lessonID))
        //    {
        //        values.Add(new CascadingDropDownNameValue(i.TestTitle, i.TestID.ToString()));
        //    }
        //    return values.ToArray();
        //}
    }
    
}
