using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class Profile
    {
        public LevelOfExperienceType LevelOfExperienceType { get; set; }
        public List<ProfileAttribute> Attributes { get; set; }

        public static Profile GetProfileByAccountID(int accountID)
        {
            return Profile.Single(x => x.AccountID == accountID);
        }

        public static int SaveProfile(Profile profile)
        {
            IAlertService _alertService = StructureMap.ObjectFactory.GetInstance<IAlertService>();

            int profileID;
            profile.LastUpdateDate = DateTime.Now;
            if (profile.ProfileID > 0)
            {
                Profile.Update(profile);
                _alertService.AddProfileModifiedAlert();
            }
            else
            {
                profile.CreateDate = DateTime.Now;
                Profile.Add(profile);
                _alertService.AddProfileCreatedAlert();
            }
            profileID = profile.ProfileID;
            return profileID;
        }

    }
}