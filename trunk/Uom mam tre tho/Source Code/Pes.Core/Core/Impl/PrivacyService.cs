using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Pes.Core.Impl
{
    public class PrivacyService : IPrivacyService
    {
        private IFriendService _friendService;
        public PrivacyService()
        {
            _friendService = ObjectFactory.GetInstance<IFriendService>();
        }

        public bool ShouldShow(int PrivacyFlagTypeID, Account AccountBeingViewed, Account Account, List<PrivacyFlag> Flags)
        {
            if (AccountBeingViewed.AccountID == Account.AccountID)
                return true;

            bool result;

            //CHAPTER 5 - come back to this when we start friends
            bool isFriend = _friendService.IsFriend(Account, AccountBeingViewed);

            //flag marked as private test
            if (Flags.Where(f => f.PrivacyFlagTypeID == PrivacyFlagTypeID && f.VisibilityLevelID == (int)VisibilityLevel.VisibilityLevels.Private).FirstOrDefault() != null)
                result = false;
            //flag marked as friends only test
            else if (Flags.Where(f => f.PrivacyFlagTypeID == PrivacyFlagTypeID && f.VisibilityLevelID == (int)VisibilityLevel.VisibilityLevels.Friends).FirstOrDefault() != null && isFriend)
                result = true;
            else if (Flags.Where(f => f.PrivacyFlagTypeID == PrivacyFlagTypeID && f.VisibilityLevelID == (int)VisibilityLevel.VisibilityLevels.Public).FirstOrDefault() != null)
                result = true;
            else
                result = false;

            return result;
        }
    }
}
