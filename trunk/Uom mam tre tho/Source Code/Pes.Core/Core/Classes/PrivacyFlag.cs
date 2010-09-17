using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class PrivacyFlag
    {
        public static List<PrivacyFlagType> GetPrivacyFlagTypes()
        {
            return PrivacyFlagType.All().OrderBy(x => x.SortOrder).ToList();
        }

        public static List<VisibilityLevel> GetVisibilityLevels()
        {
            return VisibilityLevel.All().ToList();
        }

        public static List<PrivacyFlag> GetPrivacyFlagsByProfileID(int profileID)
        {
            return PrivacyFlag.Find(x => x.ProfileID == profileID);
        }

        public static void SavePrivacyFlag(PrivacyFlag privacyFlag)
        {
            if (privacyFlag.PrivacyFlagID > 0)
                PrivacyFlag.Update(privacyFlag);
            else
                PrivacyFlag.Add(privacyFlag);
        }
    }
}