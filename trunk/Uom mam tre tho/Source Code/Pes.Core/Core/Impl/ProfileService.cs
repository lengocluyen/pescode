using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Pes.Core.Impl
{
    public class ProfileService : IProfileService
    {
        private IUserSession _userSession;
        private IProfileAttributeService _profileAttributeService;

        public ProfileService()
        {
            _userSession = ObjectFactory.GetInstance<IUserSession>();
            _profileAttributeService = ObjectFactory.GetInstance<IProfileAttributeService>();
        }

        public Profile LoadProfileByAccountID(int accountID)
        {
            Profile profile = Profile.GetProfileByAccountID(accountID);
            LevelOfExperienceType levelOfExperienceType;
            if (profile != null)
            {
                List<ProfileAttribute> attributes = _profileAttributeService.GetProfileAttributesByProfileID(profile.ProfileID);
                levelOfExperienceType = LevelOfExperienceType.GetLevelOfExperienceTypeByID(profile.LevelOfExperienceTypeID);
                profile.Attributes = attributes;
                profile.LevelOfExperienceType = levelOfExperienceType;
            }
            return profile;
        }

        public void SaveProfile(Profile profile)
        {
            int profileID = Profile.SaveProfile(profile);
            foreach (var item in profile.Attributes)
                item.ProfileID = profileID;
            ProfileAttribute.UpdateMany(profile.Attributes);

            _userSession.CurrentUser.Profile = LoadProfileByAccountID(_userSession.CurrentUser.AccountID);
        }
    }
}
