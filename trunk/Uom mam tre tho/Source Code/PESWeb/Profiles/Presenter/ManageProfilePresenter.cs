using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PESWeb.Profiles.Interface;
using Pes.Core;
using StructureMap;

namespace PESWeb.Profiles.Presenter
{
    public class ManageProfilePresenter
    {
        private IManageProfile _view;
        private IUserSession _userSession;
        private IProfileService _profileService;
        private IRedirector _redirector;
        public ManageProfilePresenter()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _profileService = ObjectFactory.GetInstance<IProfileService>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        public void Init(IManageProfile view, bool IsPostBack)
        {
            _view = view;
            _view.LoadLevelOfExperienceTypes(LevelOfExperienceType.GetAllLevelOfExperienceTypes());
            _view.LoadProfileAttributeTypes(ProfileAttribute.GetProfileAttributeTypes());
        }

        public void LoadProfile(bool IsPostback)
        {
            if (!IsPostback)
            {
                Profile profile = _profileService.LoadProfileByAccountID(_userSession.CurrentUser.AccountID);
                _view.LoadProfile(profile);
            }
        }

        public Profile GetProfile()
        {
            return Profile.GetProfileByAccountID(_userSession.CurrentUser.AccountID);
        }


        public Account GetAccount()
        {
            return _userSession.CurrentUser;
        }

        public void SaveProfile(Profile profile)
        {
            _profileService.SaveProfile(profile);
            _redirector.GoToProfilesProfile();
        }

        public List<ProfileAttributeType> GetProfileAttributeTypes()
        {
            return ProfileAttribute.GetProfileAttributeTypes();
        }
    }
}
