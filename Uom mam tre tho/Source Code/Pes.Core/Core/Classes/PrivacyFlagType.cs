using System;
using System.Collections.Generic;
using System.Linq;
using SubSonic.Extensions;

namespace Pes.Core
{
    public partial class PrivacyFlagType
    {
        public enum PrivacyFlagTypes
        {
            IM = 1,
            TankInfo = 2,
            AccountInfo = 3,
            Interests = 4,
            AboutYou = 5,
            Occupation = 6,
            YourSetup = 7,
            AnythingElse = 8
        }
    }
}