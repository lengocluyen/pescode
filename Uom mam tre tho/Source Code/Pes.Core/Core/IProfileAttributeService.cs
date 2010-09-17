using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core
{
    public interface IProfileAttributeService
    {
        List<ProfileAttribute> GetProfileAttributesByProfileID(int ProfileID);

    }
}
