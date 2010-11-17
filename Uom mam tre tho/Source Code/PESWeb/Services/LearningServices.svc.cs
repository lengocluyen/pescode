using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Pes.Core;
using StructureMap;
/// <summary>
/// Summary description for LearningServices
/// </summary>
//[WebService(Namespace = "http://tempuri.org/")]
//[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class LearningServices : ILearningServices
{
    private IWebContext _webContext;
    private IConfiguration _configuration;
    private IAccountService _userService;
    public LearningServices()
    {
        _webContext = ObjectFactory.GetInstance<IWebContext>();
        _configuration = ObjectFactory.GetInstance<IConfiguration>();
        _userService = ObjectFactory.GetInstance<IAccountService>();
    }

    #region Get Studying Info
    public List<StudyProgramming> StudyingProgrammingGetAll()
    {
        return StudyProgramming.StudyingProgrammingGetAll();
    }

    public List<StudyLevel> StudyingLevelGet(int studyProgrameID)
    {
        return StudyLevel.StudyingLevelGet(studyProgrameID);
    }

    public List<Subject> SubjectGetAllWithLevel(int levelID)
    {
        return Subject.SubjectGetAllWithLevel(levelID);
    }

    public Subject SubjectGetByName(string subjectName)
    {
        return Subject.SubjectGetByName(subjectName);
    }

    public List<Part> PartGetAllWithSubject(int subjectID)
    {
        return Part.PartGetAllWithSubject(subjectID);
    }

    public List<Lesson> LessonGetAllWithPart(int partID)
    {
        return Lesson.LessonGetAllWithPart(partID);
    }

    #endregion

    #region Book

    public Book BookGetByBookID(int bookID)
    {
        return Book.BookGetByBookID(bookID);
    }

    public List<BookType> BookTypeGetAll()
    {
        return Book.BookTypeGetAll();
    }

    public List<Book> BookGetByBookType(int typeId)
    {
        return Book.BookGetByBookType(typeId);
    }

    public List<Book> BookTop(int num)
    {
        return Book.BookTop(num);
    }

    public List<Book> BookTopInBookType(int num, int typeID)
    {
        return Book.BookTopInBookType(num, typeID);
    }
    #endregion

    #region userServices
    public Account AccountGetByID(int ID)
    {
        return Account.GetAccountByID(ID);
    }

    public Pupils PupilGetByAccountID(int ID)
    {
        return Pupils.GetPupilByAccountID(ID);
    }
    #endregion



    #region Tests
    public List<LessonTestType> GetLessonTestTypeByLessonID(int lessonID)
    {
        try
        {
            var a = LessonTestType.GetLessonTestTypeByLessonID(lessonID);
            return a;
        }
        catch { return null; }
    }
    public List<PartTestType> GetPartTestTypeByPartID(int partID)
    {
        try { return PartTestType.GetPartTestTypeByPartID(partID); }
        catch { return null; }
    }
    public List<SubjectTestType> GetSubjectTestTypebySubjectID(int subjectID)
    {
        try { return SubjectTestType.GetSubjectTestTypebySubjectID(subjectID); }
        catch { return null; }
    }
    public List<Test> GetTestByTestID(int testID)
    {
        try { return Test.GetTestByTestID(testID); }
        catch { return null; }
    }

    #endregion

    #region Temple Tests
    public List<T_Question> GetAllQuestionByTestLevel(int levelID)
    {
        try
        {
            List<T_Question> list = T_Question.GetAllQuestionByLevelID(levelID); //levelID duoc hieu la lessonID
            return list;
        }
        catch
        {
            return null;
        }
    }

    public T_Question GetQuestionByID(int questionID)
    {
        try
        {
            T_Question a = T_Question.GetQuestions(questionID);
            return a;
        }
        catch
        {
            return null;
        }
    }

    public List<T_Answers> GetAllAnswersByQuestion(int questionID)
    {
        try
        {
            List<T_Answers> a = T_Answers.GetAllAnswersByQuestion(questionID);
            return a;
        }
        catch
        {
            return null;
        }
    }

    public int InsertTestResult(T_Test_Result testResult)
    {
        try
        {
            T_Test_Result.Add(testResult);
            return 1;
        }
        catch
        {
            return 0;
        }
    }

    #endregion

    //------------------

    public Account GetPupilByID(int ID)
    {
        try
        {
            Account a = Account.GetAccountByID(ID);
            a.Profile = Profile.GetProfileByAccountID(ID);
            return a;
        }
        catch
        {
            return null;
        }
    }

    public Account GetPupilByEmail(string mail)
    {
        try
        {
            Account a = Account.GetAccountByEmail(mail);
            return a;
        }
        catch
        {
            return null;
        }
    }
    public Account GetPupilLogin(string userName, string password, bool isNeedEncode)
    {
        try
        {
            IAccountService _accountService = ObjectFactory.GetInstance<IAccountService>();
            Account a = _accountService.LoginService(userName, password);
            return a;
        }
        catch
        {
            return null;
        }
    }

    public void UpdateProFile(Profile profile)
    {
        try
        {
            Profile.Update(profile);
        }
        catch
        {

        }
    }
    public void InsertPupil(Account u)
    {
        try
        {
            Account.Add(u);
        }
        catch { }
    }


    public Account UserLogin(string username, string password)
    {
        return _userService.LoginService(username, password);
    }
    public Account GetUserByAccountID(int acc)
    {
        return Account.GetAccountByID(acc);
    }

    public Profile GetProfileByAccountID(int accounID)
    {
        Profile pf = Profile.GetProfileByAccountID(accounID);
        return pf;
    }
}

