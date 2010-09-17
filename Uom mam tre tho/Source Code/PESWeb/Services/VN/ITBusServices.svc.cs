using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.ServiceModel.Activation;
using Pes.Core;
using System.Data.Linq;
using System.IO;
using System.Web;
using System.Collections;
using StructureMap;
// NOTE: If you change the class name "ITBusServices" here, you must also update the reference to "ITBusServices" in Web.config.
//[ServiceContract(Namespace = "")]
//[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
//[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
public class ITBusServices : IITBusServices
{
    public void DoWork()
    {
    }

    public List<VLessionGroup> GetAllLessionGroup()
    {
        try
        {
            List<VLessionGroup> a = VLessionGroup.All().ToList();
            return a;
        }
        catch
        {
            return null;
        }
    }

    public List<VLession> GetLessions(int lessionGroupID)
    {
        try
        {
            List<VLession> a = VLession.GetLessionByGroup(lessionGroupID).ToList(); 
            return a;
        }
        catch
        {
            return null;
        }
    }

    public List<VPart> GetAllPartsByLession(int lession)
    {
        try
        {
            return VPart.GetPartsByLessionID(lession);
        }
        catch
        {
            return null;
        }
    }

    public VModule GetModuleByID(int moduleID)
    {
        try
        {
            return VModule.GetModuleByID(moduleID);
        }
        catch
        {
            return null;
        }
    }

    public List<VLessionGroup> GetHomeLessionGroup()
    {
        try
        {
            return (from lGroup in VLessionGroup.All()
                    where lGroup.LessionGroupView > 0
                    orderby lGroup.LessionGroupView
                    select lGroup).ToList(); 
        }
        catch
        {
            return null;
        }
    }

    public VLessionGroup GetLessionGroupByID(int idLG)
    {
        try
        {
            VLessionGroup a = (from lGroup in VLessionGroup.All()
                    where lGroup.LessionGroupID == idLG
                    select lGroup).SingleOrDefault();
            return a;
        }
        catch
        {
            return null;
        }
    }

    #region Pupil, Register
    #region userServices
    public Account GetPupilByID(int ID)
    {
        try
        {
            Account a = Account.GetAccountByID(ID);
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
        catch {  }
    }

    public Profile GetProfileByAccountID(int accounID)
    {
        Profile pf =  Profile.GetProfileByAccountID(accounID);
        return pf;
    }

    #endregion

    #endregion

    // Commons
    public string GetWebURL()
    {
        return Constants.WebURL;
    }

    public string MD5Hash(string input)
    {
        return Commons.EncodePassword(input, "");
    }


    #region Test

    public List<VQuestions> GetAllQuestionByTestLevel(int levelID)
    {
        try
        {
            return VQuestions.GetListQuestionByLevel(levelID);
        }
        catch
        {
            return null;
        }
    }

    public VQuestions GetQuestionByID(int questionID)
    {
        try
        {
            return VQuestions.GetQuestionByID(questionID);
        }
        catch
        {
            return null;
        }
    }

    public List<VAnswers> GetAllAnswersByQuestion(int questionID)
    {
        try
        {
            return VAnswers.GetListAnserForQuestion(questionID);
        }
        catch
        {
            return null;
        }
    }

    public bool InsertTestResult(VTestResults testResult)
    {
        try
        {
            VTestResults.InsertTestResult(testResult);
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion
}
