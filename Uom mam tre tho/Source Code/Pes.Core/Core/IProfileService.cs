using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public interface IProfileService
    {
        Profile LoadProfileByAccountID(int accountID);
        void SaveProfile(Profile profile);
    }
}
