using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pes.Core;
using PESWeb.Profiles.Interface;
using StructureMap;

namespace PESWeb.Profiles.Presenter
{
    public class ManagePrivacyPresenter
    {
        private IProfileService _profileService;
        private Profile profile;
        private IUserSession _userSession;
        private Account account;
        private List<PrivacyFlagType> privacyFlagTypes;
        private List<VisibilityLevel> visibilityLevels;
        private List<PrivacyFlag> privacyFlags;
        private IManagePrivacy _view;

        public ManagePrivacyPresenter()
        {
            _profileService = ObjectFactory.GetInstance<IProfileService>();
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            account = _userSession.CurrentUser;
            profile = _profileService.LoadProfileByAccountID(account.AccountID);
        }

        public void Init(IManagePrivacy view)
        {
            _view = view;
            LoadPrivacyTypes();
        }

        private void LoadPrivacyTypes()
        {
            privacyFlagTypes = PrivacyFlag.GetPrivacyFlagTypes();
            visibilityLevels = PrivacyFlag.GetVisibilityLevels();
            privacyFlags = PrivacyFlag.GetPrivacyFlagsByProfileID(profile.ProfileID);
            _view.ShowPrivacyTypes(privacyFlagTypes, visibilityLevels, privacyFlags);
        }

        public List<PrivacyFlagType> GetPrivacyFlagType()
        {
            return privacyFlagTypes;
        }

        public void SavePrivacyFlag(int privacyFlagTypeID, int visibilityLevelID)
        {
            foreach (var flag in privacyFlags)
            {
                if (flag.PrivacyFlagTypeID == privacyFlagTypeID)
                {
                    flag.VisibilityLevelID = visibilityLevelID;
                    PrivacyFlag.SavePrivacyFlag(flag);
                    return;
                }
            }
            PrivacyFlag newFlag = new PrivacyFlag();
            newFlag.PrivacyFlagTypeID = privacyFlagTypeID;
            newFlag.VisibilityLevelID = visibilityLevelID;
            newFlag.ProfileID = profile.ProfileID;
            newFlag.CreateDate = DateTime.Now;
            privacyFlags.Add(newFlag);
            PrivacyFlag.SavePrivacyFlag(newFlag);
        }

        public bool IsFlagSelected(int PrivacyFlagTypeID, int VisibilityLevelID, List<PrivacyFlag> PrivacyFlags)
        {
            List<PrivacyFlag> result = PrivacyFlags.Where(
                pf => pf.PrivacyFlagTypeID == PrivacyFlagTypeID
                && pf.VisibilityLevelID == VisibilityLevelID).ToList();
            return result.Count > 0 ? true : false;
        }
    }
}
