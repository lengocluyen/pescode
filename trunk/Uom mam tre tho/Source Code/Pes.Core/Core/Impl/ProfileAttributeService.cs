using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pes.Core.Impl
{
    public class ProfileAttributeService : IProfileAttributeService
    {
        public List<ProfileAttribute> GetProfileAttributesByProfileID(int ProfileID)
        {
            List<ProfileAttribute> attributes = ProfileAttribute.GetProfileAttributesByProfileID(ProfileID);
            foreach (var item in attributes)
                item.ProfileAttributeType = ProfileAttribute.GetProfileAttributeTypeByID(item.ProfileAttributeTypeID);
            return attributes;
        }
    }
}
