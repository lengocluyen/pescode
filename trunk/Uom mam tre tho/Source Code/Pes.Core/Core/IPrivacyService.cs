using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public interface IPrivacyService
    {
        bool ShouldShow(Int32 PrivacyFlagTypeID,
                       Account AccountBeingViewed,
                       Account Account,
                       List<PrivacyFlag> Flags);
    }
}
