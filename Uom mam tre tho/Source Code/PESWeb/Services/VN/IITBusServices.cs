using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Pes.Core;

// NOTE: If you change the interface name "IITBusServices" here, you must also update the reference to "IITBusServices" in Web.config.
[ServiceContract]
public interface IITBusServices
{
    [OperationContract]
    List<VLessionGroup> GetAllLessionGroup();
    [OperationContract]
    List<VLession> GetLessions(int lessionGroupID);
    [OperationContract]
    List<VPart> GetAllPartsByLession(int lession);
    [OperationContract]
    VModule GetModuleByID(int moduleID);
    [OperationContract]
    List<VLessionGroup> GetHomeLessionGroup();
    [OperationContract]
    VLessionGroup GetLessionGroupByID(int idLG);


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

    #endregion


    // Commons 
    [OperationContract]
    string GetWebURL();
    [OperationContract]
    string MD5Hash(string input);

    #region Test

    [OperationContract]
    List<VQuestions> GetAllQuestionByTestLevel(int levelID);
    [OperationContract]
    VQuestions GetQuestionByID(int questionID);
    [OperationContract]
    List<VAnswers> GetAllAnswersByQuestion(int questionID);
    [OperationContract]
    bool InsertTestResult(VTestResults testResult);
    #endregion

   
}
