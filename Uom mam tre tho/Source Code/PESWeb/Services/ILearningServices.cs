using System;
using System.Collections.Generic;
using System.Linq;using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Pes.Core;

// NOTE: If you change the interface name "IPESServices" here, you must also update the reference to "IPESServices" in Web.config.
[ServiceContract]
public interface ILearningServices
{

    #region Get Information Studying
    [OperationContract]
    List<StudyProgramming> StudyingProgrammingGetAll();
    [OperationContract]
    List<StudyLevel> StudyingLevelGet(int studyProgrameID);
    [OperationContract]
    List<Subject> SubjectGetAllWithLevel(int levelID);
    [OperationContract]
    Subject SubjectGetByName(string subjectName);
    [OperationContract]
    List<Part> PartGetAllWithSubject(int subjectID);
    [OperationContract]
    List<Lesson> LessonGetAllWithPart(int partID);
    #endregion

    #region BOOKS
    [OperationContract]
    Book BookGetByBookID(int bookID);
    [OperationContract]
    List<BookType> BookTypeGetAll();
    [OperationContract]
    List<Book> BookGetByBookType(int typeId);
    [OperationContract]
    List<Book> BookTop(int num);
    [OperationContract]
    List<Book> BookTopInBookType(int num, int typeID);
    #endregion

    #region USERS
    [OperationContract]
    Account AccountGetByID(int ID);
    [OperationContract]
    Pupils PupilGetByAccountID(int ID);
    #endregion

    #region Test
    [OperationContract]
    List<LessonTestType> GetLessonTestTypeByLessonID(int lessonID);
    [OperationContract]
    List<PartTestType> GetPartTestTypeByPartID(int partID);
    [OperationContract]
    List<SubjectTestType> GetSubjectTestTypebySubjectID(int subjectID);
    [OperationContract]
    List<Test> GetTestByTestID(int testID);
    #endregion
    #region Temple Tests
    [OperationContract]
    List<T_Question> GetAllQuestionByTestLevel(int levelID);
    [OperationContract]
    T_Question GetQuestionByID(int questionID);
    [OperationContract]
    List<T_Answers> GetAllAnswersByQuestion(int questionID);

    [OperationContract]
    int InsertTestResult(T_Test_Result testResult);

    #endregion

    #region Pupils, Register

    [OperationContract]
    void InsertPupil(Account pupil);
    [OperationContract]
    Account GetPupilByID(int id);
    [OperationContract]
    Account GetPupilLogin(string email, string password, bool isNeedEcode);
    [OperationContract]
    void UpdateProFile(Profile profile);
    [OperationContract]
    Account GetPupilByEmail(string email);
    [OperationContract]
    Profile GetProfileByAccountID(int profileID);

    //--------------------------------------
    [OperationContract]
    Account UserLogin(string username, string password);

    [OperationContract]
    Account GetUserByAccountID(int acc);

    #endregion

}
